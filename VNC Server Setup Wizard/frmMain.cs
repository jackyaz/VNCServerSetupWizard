using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Tulpep.ActiveDirectoryObjectPicker;

namespace VNC_Server_Setup_Wizard
{
    public partial class frmMain : Form
    {
        bool domainmember = WindowsLogon.DomainMember;
        VNC_Configuration vncconfig = new VNC_Configuration();
        public frmMain()
        {
            InitializeComponent();
            listBxMenu.SelectedIndex = 0;
            listViewUsersGroups.Columns[1].Width = -2;
            string cloudcreds = "";
            string plantype = "";
            if (File.Exists(vncconfig.credentialfile))
            {
                cloudcreds = File.ReadAllText(vncconfig.credentialfile);
                plantype = cloudcreds.Substring(cloudcreds.LastIndexOf("cloud/plan") + 10, cloudcreds.IndexOf("cloud/principal") - (cloudcreds.LastIndexOf("cloud/plan") + 10));
                plantype = Regex.Replace(new string(plantype.Where(c => !char.IsControl(c)).ToArray()), @"[^\u0000-\u007F]", string.Empty);
                cloudcreds = null;
            }
            else if (RegistryManagement.GetRegistryValue(RegHives.HKLM_License, "vncserver_license").Length > 1)
            {
                plantype = "Enterprise";
            }

            switch (plantype)
            {
                case "Home":
                    vncconfig.Plan = VNC_Configuration.PlanType.Home;
                    radioVNCAuth.Checked = true;
                    radio128.Checked = true;
                    foreach (Control control in pnlFeaturesPaid.Controls)
                    {
                        if (control.GetType() == typeof(CheckBox))
                        {
                            ((CheckBox)control).Checked = false;
                        }
                    }
                    break;
                case "Professional":
                    vncconfig.Plan = VNC_Configuration.PlanType.Professional;
                    radioSystemAuth.Checked = true;
                    radio128.Checked = true;
                    break;
                case "Enterprise":
                    vncconfig.Plan = VNC_Configuration.PlanType.Enterprise;
                    radioSystemAuth.Checked = true;
                    radio256.Checked = true;
                    break;
                default:
                    MessageBox.Show("Please run the License Wizard to apply your subscription to VNC Server", "VNC Server is not licensed!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    plantype = null;
                    Environment.Exit(0);
                    break;
            }
            plantype = null;
        }

        private void listBxMenu_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Draw the background of the ListBox control for each item.
            e.DrawBackground();

            // Define the default color of the brush
            Brush myBrush;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected) { myBrush = Brushes.White; }
            else { myBrush = Brushes.Black; }

            // Draw the current item text based on the current Font and the custom brush settings.
            SizeF size = e.Graphics.MeasureString(listBxMenu.Items[e.Index].ToString(), e.Font);
            e.Graphics.DrawString(listBxMenu.Items[e.Index].ToString(), e.Font, myBrush, e.Bounds.Left + (e.Bounds.Width / 2 - size.Width / 2), e.Bounds.Top + (e.Bounds.Height / 2 - size.Height / 2), StringFormat.GenericDefault);

            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }

        private void listBxMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (listBxMenu.SelectedIndex)
            {
                case 0:
                    ButtonState(true, btnNext);
                    ButtonState(false, btnBack);
                    tabControlContent.SelectTab(listBxMenu.SelectedIndex);
                    break;
                case 1:
                    ButtonState(true, btnNext);
                    ButtonState(true, btnBack);
                    tabControlContent.SelectTab(listBxMenu.SelectedIndex);
                    break;
                case 2:
                    ButtonState(true, btnNext);
                    ButtonState(true, btnBack);
                    tabControlContent.SelectTab(listBxMenu.SelectedIndex);
                    break;
                case 3:
                    ButtonState(true, btnNext);
                    ButtonState(true, btnBack);
                    tabControlContent.SelectTab(listBxMenu.SelectedIndex);
                    break;
                case 4:
                    ButtonState(true, btnNext);
                    ButtonState(true, btnBack);
                    tabControlContent.SelectTab(listBxMenu.SelectedIndex);
                    break;
                case 5:
                    ButtonState(false, btnNext);
                    ButtonState(true, btnBack);
                    tabControlContent.SelectTab(listBxMenu.SelectedIndex);
                    break;
            }
        }

        private void ButtonState(bool showhide, Button button) { button.Enabled = showhide; button.Visible = showhide; }
        private void CheckboxState(bool enabledisable, CheckBox chkbox) { chkbox.Enabled = enabledisable; chkbox.Checked = enabledisable; }

        private void button1_Click(object sender, EventArgs e)
        {
            DirectoryObjectPickerDialog picker = new DirectoryObjectPickerDialog()
            {
                AllowedObjectTypes = ObjectTypes.Users | ObjectTypes.Groups | ObjectTypes.BuiltInGroups,
                DefaultObjectTypes = ObjectTypes.Users | ObjectTypes.Groups | ObjectTypes.BuiltInGroups,
                AllowedLocations = Locations.All,
                MultiSelect = true,
                ShowAdvancedView = true
            };

            if (domainmember) { picker.DefaultLocations = Locations.JoinedDomain; }
            else { picker.DefaultLocations = Locations.LocalComputer; }

            if (picker.ShowDialog() == DialogResult.OK)
            {
                foreach (var sel in picker.SelectedObjects)
                {
                    if (sel.Name.Length > 0)
                    {
                        ContextType ctxtype;

                        if (domainmember) { ctxtype = ContextType.Domain; }
                        else { ctxtype = ContextType.Machine; }

                        PrincipalContext prictx = new PrincipalContext(ctxtype);
                        UserPrincipal user = new UserPrincipal(prictx);
                        GroupPrincipal group = new GroupPrincipal(prictx);
                        var searcher = new PrincipalSearcher();

                        if (sel.SchemaClassName.ToLower() == "user")
                        {
                            if (sel.Path.Contains("WinNT")) { user.SamAccountName = sel.Name; }
                            else { user.UserPrincipalName = sel.Upn; }
                            searcher = new PrincipalSearcher(user);
                            user = searcher.FindOne() as UserPrincipal;
                            if (user == null) { user = new UserPrincipal(prictx); }
                        }
                        else if (sel.SchemaClassName.ToLower() == "group")
                        {
                            group.SamAccountName = sel.Name;
                            searcher = new PrincipalSearcher(group);
                            group = searcher.FindOne() as GroupPrincipal;
                            if (group == null) { group = new GroupPrincipal(prictx); }
                        }

                        if (user.Sid != null)
                        {
                            ListViewItem item = new ListViewItem(sel.SchemaClassName);
                            item.SubItems.Add(user.SamAccountName);
                            item.SubItems.Add(user.Sid.ToString());
                            listViewUsersGroups.Items.Add(item);
                        }
                        else if (group.Sid != null)
                        {
                            ListViewItem item = new ListViewItem(sel.SchemaClassName);
                            item.SubItems.Add(group.SamAccountName);
                            item.SubItems.Add("%" + group.Sid.ToString());
                            listViewUsersGroups.Items.Add(item);
                        }
                    }
                }
            }
        }

        private void listViewUsersGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewUsersGroups.SelectedItems.Count > 0)
            {
                textBox1.Text = listViewUsersGroups.SelectedItems[0].SubItems[2].Text;
            }
            else
            {
                textBox1.Text = "";
            }
        }

        private void listViewUsersGroups_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = this.listViewUsersGroups.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }

        private void btnBack_Click(object sender, EventArgs e) { listBxMenu.SelectedIndex -= 1; }

        private void btnNext_Click(object sender, EventArgs e) { listBxMenu.SelectedIndex += 1; }

        private void tabControlContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlContent.SelectedIndex == 1)
            {
                bool passwordenabled = WindowsLogon.PasswordEnabled;

                switch (vncconfig.Plan)
                {
                    case VNC_Configuration.PlanType.Home:
                        radioVNCAuth.Enabled = true;
                        radioSystemAuth.Enabled = false;
                        radioSingleSignOn.Enabled = false;
                        break;
                    case VNC_Configuration.PlanType.Professional:
                        radioVNCAuth.Enabled = true;
                        radioSystemAuth.Enabled = passwordenabled;
                        lblPasswordWarning.Visible = !passwordenabled;
                        radioSingleSignOn.Enabled = false;
                        break;
                    case VNC_Configuration.PlanType.Enterprise:
                        radioVNCAuth.Enabled = true;
                        radioSystemAuth.Enabled = passwordenabled;
                        lblPasswordWarning.Visible = !passwordenabled;
                        if (domainmember) { radioSingleSignOn.Enabled = true; } else { radioSingleSignOn.Enabled = false; lblDomainInfo.Visible = true; }
                        break;
                }
            }

            if (tabControlContent.SelectedIndex == 2)
            {
                switch (vncconfig.Plan)
                {
                    case VNC_Configuration.PlanType.Home:
                        radio128.Enabled = true;
                        radio256.Enabled = false;
                        break;
                    case VNC_Configuration.PlanType.Professional:
                        radio128.Enabled = true;
                        radio256.Enabled = false;
                        break;
                    case VNC_Configuration.PlanType.Enterprise:
                        radio128.Enabled = true;
                        radio256.Enabled = true;
                        break;
                }
            }

            if (tabControlContent.SelectedIndex == 3)
            {
                lblFeaturesSubtitle.Text = "Turn on to enable a feature, subject to permissions for individual users or groups.\n\rTurn off to disable a feature; this cannot be overridden.";
                switch (vncconfig.Plan)
                {
                    case VNC_Configuration.PlanType.Home:
                        pnlFeatureJoin.Visible = true;
                        pnlFeatureInfo.Visible = true;
                        foreach (Control control in pnlFeaturesPaid.Controls)
                        {
                            if(control.GetType() == typeof(CheckBox))
                            {
                                ((CheckBox)control).Checked = false;
                                ((CheckBox)control).Enabled = false;
                            }
                        }
                        break;
                    case VNC_Configuration.PlanType.Professional:
                        pnlFeaturesPaid.BorderStyle = BorderStyle.None;
                        break;
                    case VNC_Configuration.PlanType.Enterprise:
                        pnlFeaturesPaid.BorderStyle = BorderStyle.None;
                        break;
                }
            }

        }

        private void radioAuthType_CheckedChanged(object sender, EventArgs e)
        {
            if (radioVNCAuth.Checked) { vncconfig.Auth = VNC_Configuration.Authentication.VNCAuth; }
            if (radioSystemAuth.Checked) { vncconfig.Auth = VNC_Configuration.Authentication.SystemAuth; }
            if (radioSingleSignOn.Checked) { vncconfig.Auth = VNC_Configuration.Authentication.SingleSignOn_SystemAuth; }
        }
    }
}
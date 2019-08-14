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
        public frmMain()
        {
            InitializeComponent();
            listBxMenu.SelectedIndex = 0;
            string cloudcreds = "";
            string plantype = "";
            if (File.Exists(VNC_Definitions.credentialfile))
            {
                cloudcreds = File.ReadAllText(VNC_Definitions.credentialfile);
                plantype = cloudcreds.Substring(cloudcreds.LastIndexOf("cloud/plan") + 10, cloudcreds.IndexOf("cloud/principal") - (cloudcreds.LastIndexOf("cloud/plan") + 10));
                plantype = Regex.Replace(new string(plantype.Where(c => !char.IsControl(c)).ToArray()), @"[^\u0000-\u007F]", string.Empty);
                cloudcreds = null;
            }
            else if (RegistryManagement.GetRegistryValue(RegHives.HKLM_License,"vncserver_license").Length > 1)
            {
                plantype = "Enterprise";
            }

            switch (plantype)
            {
                case "Home":
                    VNC_Definitions.Plan = VNC_Definitions.PlanType.Home;
                    radioVNCAuth.Checked = true;
                    radio128.Checked = true;
                    break;
                case "Professional":
                    VNC_Definitions.Plan = VNC_Definitions.PlanType.Professional;
                    radioSystemAuth.Checked = true;
                    radio128.Checked = true;
                    break;
                case "Enterprise":
                    VNC_Definitions.Plan = VNC_Definitions.PlanType.Enterprise;
                    radioSystemAuth.Checked = true;
                    radio256.Checked = true;
                    break;
                default:
                    MessageBox.Show("Please run the License Wizard to apply your subscription to VNC Server", "VNC Server is not licensed!",MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
            Console.WriteLine(listBxMenu.SelectedItem.ToString());
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
                    ButtonState(false, btnNext);
                    ButtonState(true, btnBack);
                    tabControlContent.SelectTab(listBxMenu.SelectedIndex);
                    break;
            }
        }

        private void ButtonState(bool showhide, Button button) { button.Enabled = showhide; button.Visible = showhide; }

        private void button1_Click(object sender, EventArgs e)
        {
            DirectoryObjectPickerDialog picker = new DirectoryObjectPickerDialog()
            {
                AllowedObjectTypes = ObjectTypes.Users | ObjectTypes.Groups | ObjectTypes.BuiltInGroups | ObjectTypes.WellKnownPrincipals,
                DefaultObjectTypes = ObjectTypes.Users | ObjectTypes.Groups | ObjectTypes.BuiltInGroups | ObjectTypes.WellKnownPrincipals,
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
                        }
                        else if (sel.SchemaClassName.ToLower() == "group")
                        {
                            group.SamAccountName = sel.Name;
                            searcher = new PrincipalSearcher(group);
                            group = searcher.FindOne() as GroupPrincipal;
                        }

                        if (user.Sid != null)
                        {
                            ListViewItem item = new ListViewItem(user.SamAccountName);
                            item.SubItems.Add(user.Sid.ToString());
                            listViewUsersGroups.Items.Add(item);
                        }
                        else if (group.Sid != null)
                        {
                            ListViewItem item = new ListViewItem(group.SamAccountName);
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
                textBox1.Text = listViewUsersGroups.SelectedItems[0].SubItems[1].Text;
            }
            else
            {
                textBox1.Text = "";
            }
        }

        private void btnBack_Click(object sender, EventArgs e) { listBxMenu.SelectedIndex -= 1; }

        private void btnNext_Click(object sender, EventArgs e) { listBxMenu.SelectedIndex += 1; }

        private void tabControlContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlContent.SelectedIndex == 1)
            {
                bool passwordenabled = WindowsLogon.PasswordEnabled;
                if (!passwordenabled)
                {
                    lblPasswordWarning.Text = "WARNING: There is no password defined for your Windows user.\n\rYou will need to set a password to use Windows password!";
                }

                bool domainmember = WindowsLogon.DomainMember;
                if (!domainmember)
                {
                    lblDomainInfo.Text = "INFORMATION: This computer is not joined to a domain.";
                }

                switch (VNC_Definitions.Plan)
                {
                    case VNC_Definitions.PlanType.Home:
                        radioVNCAuth.Enabled = true;
                        radioSystemAuth.Enabled = false;
                        radioSingleSignOn.Enabled = false;
                        break;
                    case VNC_Definitions.PlanType.Professional:
                        radioVNCAuth.Enabled = true;
                        radioSystemAuth.Enabled = passwordenabled;
                        lblPasswordWarning.Visible = true;
                        radioSingleSignOn.Enabled = false;
                        break;
                    case VNC_Definitions.PlanType.Enterprise:
                        radioVNCAuth.Enabled = true;
                        radioSystemAuth.Enabled = passwordenabled;
                        lblPasswordWarning.Visible = true;
                        if (domainmember) { radioSingleSignOn.Enabled = true; lblDomainInfo.Visible = true; } else { radioSingleSignOn.Enabled = false; }
                        break;
                }
            }

            if (tabControlContent.SelectedIndex == 3)
            {
                switch (VNC_Definitions.Plan)
                {
                    case VNC_Definitions.PlanType.Home:
                        radio128.Enabled = true;
                        radio256.Enabled = false;
                        break;
                    case VNC_Definitions.PlanType.Professional:
                        radio128.Enabled = true;
                        radio256.Enabled = false;
                        break;
                    case VNC_Definitions.PlanType.Enterprise:
                        radio128.Enabled = true;
                        radio256.Enabled = true;
                        break;
                }
            }
        }
    }
}
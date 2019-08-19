using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        #region Variable declaration
        private bool domainmember = WindowsLogon.DomainMember;
        private VNC_Configuration vncconfig = new VNC_Configuration();
        private bool passwordenabled = WindowsLogon.PasswordEnabled;
        #endregion

        #region Form Constructor
        public frmMain()
        {
            InitializeComponent();
            listBxMenu.SelectedIndex = 0;
            listViewUsersGroups.Columns[1].Width = -2;
            SetConfigFromPlan(GetPlanType());

            for (int i = 0; i < listBxMenu.Items.Count; i++)
            {
                if (listBxMenu.Items[i].ToString() == "Users & Permissions") { listBxMenu.Items.RemoveAt(i); }
            }
        }
        #endregion

        private string GetPlanType()
        {
            string plantype = "";
            if (File.Exists(vncconfig.credentialfile))
            {
                string cloudcreds = "";
                cloudcreds = File.ReadAllText(vncconfig.credentialfile);
                plantype = cloudcreds.Substring(cloudcreds.LastIndexOf("cloud/plan") + 10, cloudcreds.IndexOf("cloud/principal") - (cloudcreds.LastIndexOf("cloud/plan") + 10));
                plantype = Regex.Replace(new string(plantype.Where(c => !char.IsControl(c)).ToArray()), @"[^\u0000-\u007F]", string.Empty);
                cloudcreds = null;
            }
            else if (RegistryManagement.GetRegistryValue(RegHives.HKLM_License, "vncserver_license").Length > 1)
            {
                plantype = "Enterprise";
            }
            return plantype;
        }

        private void SetConfigFromPlan(string plantype)
        {
            switch (plantype)
            {
                case "Home":
                    vncconfig.Plan = VNC_Configuration.PlanType.Home;
                    radioVNCAuth.Checked = true;
                    radioVNCAuth.Enabled = true;
                    radioSystemAuth.Enabled = false;
                    radioSingleSignOn.Enabled = false;
                    ToggleVNCPasswordFields(true);
                    radio128.Enabled = true;
                    radio128.Checked = true;
                    radio256.Enabled = false;
                    foreach (Control control in pnlFeaturesPaid.Controls)
                    {
                        if (control.GetType() == typeof(CheckBox))
                        {
                            ((CheckBox)control).Checked = false;
                        }
                    }
                    VNC_Feature.EnableFreeFeatures(vncconfig);
                    pnlFeatureJoin.Visible = true;
                    pnlFeatureInfo.Visible = true;
                    foreach (Control control in pnlFeaturesPaid.Controls)
                    {
                        if (control.GetType() == typeof(CheckBox))
                        {
                            ((CheckBox)control).Checked = false;
                            ((CheckBox)control).Enabled = false;
                        }
                    }
                    linkLabelUpsell.Visible = true;
                    break;
                case "Professional":
                    vncconfig.Plan = VNC_Configuration.PlanType.Professional;
                    radioVNCAuth.Enabled = true;
                    radioSystemAuth.Enabled = passwordenabled;
                    radioSystemAuth.Checked = true;
                    lblPasswordWarning.Visible = !passwordenabled;
                    radioSingleSignOn.Enabled = false;
                    ToggleVNCPasswordFields(false);
                    radio128.Enabled = true;
                    radio128.Checked = true;
                    radio256.Enabled = false;
                    VNC_Feature.EnableAllFeatures(vncconfig);
                    pnlFeaturesPaid.BorderStyle = BorderStyle.None;
                    break;
                case "Enterprise":
                    vncconfig.Plan = VNC_Configuration.PlanType.Enterprise;
                    radioVNCAuth.Enabled = true;
                    radioSystemAuth.Enabled = passwordenabled;
                    radioSystemAuth.Checked = true;
                    lblPasswordWarning.Visible = !passwordenabled;
                    if (domainmember) { radioSingleSignOn.Enabled = true; } else { radioSingleSignOn.Enabled = false; lblDomainInfo.Visible = true; }
                    ToggleVNCPasswordFields(false);
                    radio128.Enabled = true;
                    radio256.Enabled = true;
                    radio256.Checked = true;
                    VNC_Feature.EnableAllFeatures(vncconfig);
                    pnlFeaturesPaid.BorderStyle = BorderStyle.None;
                    break;
                default:
                    MessageBox.Show("Please run the License Wizard to apply your subscription to VNC Server", "VNC Server is not licensed!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Environment.Exit(0);
                    break;
            }
        }

        private void ToggleVNCPasswordFields(bool showhide)
        {
            lblPassword1.Visible = showhide;
            lblPassword2.Visible = showhide;
            txtBoxPassword1.Visible = showhide;
            txtBoxPassword2.Visible = showhide;

            if (vncconfig.EncryptedPassword.Length > 0)
            {
                txtBoxPassword1.Text = "";
                txtBoxPassword2.Text = "";
            }

            CheckVNCPassword();
            btnConfirmPassword.Visible = showhide;
        }

        private void CheckVNCPassword()
        {
            if (txtBoxPassword1.Text != txtBoxPassword2.Text)
            {
                lblVNCPasswordMatch.Visible = true;
            }
            else if (txtBoxPassword1.Text == txtBoxPassword2.Text)
            {
                lblVNCPasswordMatch.Visible = false;
            }
        }

        private void ListBxMenu_DrawItem(object sender, DrawItemEventArgs e)
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

        private void ListBxMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (listBxMenu.SelectedIndex)
            {
                case 0:
                    ButtonState(true, btnNext);
                    ButtonState(false, btnBack);
                    ButtonState(false, btnApply);
                    tabControlContent.SelectTab(listBxMenu.SelectedIndex);
                    break;
                case 1:
                    ButtonState(true, btnNext);
                    ButtonState(true, btnBack);
                    ButtonState(false, btnApply);
                    tabControlContent.SelectTab(listBxMenu.SelectedIndex);
                    break;
                case 2:
                    ButtonState(true, btnNext);
                    ButtonState(true, btnBack);
                    ButtonState(false, btnApply);
                    tabControlContent.SelectTab(listBxMenu.SelectedIndex);
                    break;
                case 3:
                    ButtonState(true, btnNext);
                    ButtonState(true, btnBack);
                    ButtonState(false, btnApply);
                    tabControlContent.SelectTab(listBxMenu.SelectedIndex);
                    break;
                /*case 4:
                    ButtonState(true, btnNext);
                    ButtonState(true, btnBack);
                    ButtonState(false, btnApply);
                    tabControlContent.SelectTab(listBxMenu.SelectedIndex);
                    break;
                case 5:*/
                case 4:
                    ButtonState(false, btnNext);
                    ButtonState(true, btnBack);
                    ButtonState(true, btnApply);
                    tabControlContent.SelectTab(listBxMenu.SelectedIndex + 1);
                    break;
            }
        }

        private void ButtonState(bool showhide, Button button) { button.Enabled = showhide; button.Visible = showhide; }
        private void CheckboxState(bool enabledisable, CheckBox chkbox) { chkbox.Enabled = enabledisable; chkbox.Checked = enabledisable; }

        private void BtnBack_Click(object sender, EventArgs e) { listBxMenu.SelectedIndex -= 1; }

        private void BtnNext_Click(object sender, EventArgs e) { listBxMenu.SelectedIndex += 1; }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            if (vncconfig.Authentication == VNC_Configuration.AuthenticationType.VNCAuth)
            {
                if(vncconfig.EncryptedPassword.Length == 0)
                {
                    MessageBox.Show("You need to set a VNC Password", "VNC Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    listBxMenu.SelectedIndex = 1;
                    return;
                }
            }

            if (vncconfig.SaveConfiguration())
            {
                Application.Exit();
            }
        }            
        private void LinkLabelUpsell_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                linkLabelUpsell.LinkVisited = true;
                System.Diagnostics.Process.Start("https://www.realvnc.com/en/connect/pricing/");
            }
            catch { MessageBox.Show("Unable to open link."); }
        }

        #region Authentication Tab events

        private void RadioAuthType_CheckedChanged(object sender, EventArgs e)
        {
            if (radioVNCAuth.Checked)
            {
                vncconfig.Authentication = VNC_Configuration.AuthenticationType.VNCAuth;
                lblPasswordWarning.Visible = false;
                ToggleVNCPasswordFields(true);
            }
            else if (radioSystemAuth.Checked)
            {
                vncconfig.Authentication = VNC_Configuration.AuthenticationType.SystemAuth;
                lblPasswordWarning.Visible = !passwordenabled;
                ToggleVNCPasswordFields(false);
            }
            else if (radioSingleSignOn.Checked)
            {
                vncconfig.Authentication = VNC_Configuration.AuthenticationType.SingleSignOn_SystemAuth;
                lblPasswordWarning.Visible = !passwordenabled;
                ToggleVNCPasswordFields(false);
            }
        }

        private void TxtBoxPassword_TextChanged(object sender, EventArgs e)
        {
            CheckVNCPassword();
        }

        private void btnConfirmPassword_Click(object sender, EventArgs e)
        {
            if (txtBoxPassword1.Text.Length > 0 && txtBoxPassword2.Text.Length > 0)
                if (txtBoxPassword1.Text == txtBoxPassword2.Text)
                {
                    vncconfig.EncryptedPassword = VNC_Password.GetEncryptedPassword(txtBoxPassword1.Text);
                    txtBoxPassword1.Text = "********";
                    txtBoxPassword2.Text = "********";
                    txtBoxPassword1.Enabled = false;
                    txtBoxPassword2.Enabled = false;
                    btnConfirmPassword.Enabled = false;
                }
        }

        private void LinkLabelSystemAuth_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                linkLabelSystemAuth.LinkVisited = true;
                System.Diagnostics.Process.Start("https://help.realvnc.com/hc/en-us/articles/360002250097-Setting-up-System-Authentication");
            }
            catch { MessageBox.Show("Unable to open link."); }
        }

        private void LinkLabelSSO_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                linkLabelSSO.LinkVisited = true;
                System.Diagnostics.Process.Start("https://help.realvnc.com/hc/en-us/articles/360002250257-Setting-up-Single-Sign-on-Authentication-SSO-");
            }
            catch { MessageBox.Show("Unable to open link."); }
        }

        #endregion

        #region Encryption Tab events

        private void RadioEncryptionType_CheckedChanged(object sender, EventArgs e)
        {
            if (radio128.Checked) { vncconfig.Encryption = VNC_Configuration.EncryptionType.AES128; }
            else if (radio256.Checked) { vncconfig.Encryption = VNC_Configuration.EncryptionType.AES256; }
        }

        #endregion

        #region Feature Tab events

        private void ChkFeatures_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            vncconfig.VNCFeatures.Find(x => x.Name.ToString() == chk.Name.Replace("chk", "")).Enabled = chk.Checked;
        }

        #endregion

        #region Users & Permissions Tab events

        private void Button1_Click(object sender, EventArgs e)
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

        private void ListViewUsersGroups_SelectedIndexChanged(object sender, EventArgs e)
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

        private void ListViewUsersGroups_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = this.listViewUsersGroups.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }

        #endregion

        private void TxtBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnConfirmPassword.PerformClick();
                e.Handled = true;
            }
        }
    }
}
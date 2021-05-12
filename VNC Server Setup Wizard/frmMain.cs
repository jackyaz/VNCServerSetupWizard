using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VNC_Server_Setup_Wizard
{
    public partial class FrmMain : Form
    {
        #region Variable declaration
        private VNC_Configuration vncconfig;
        #endregion

        #region Form Constructor
        public FrmMain()
        {
            vncconfig = new VNC_Configuration();
            InitializeComponent();
        }

        #endregion

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            listBxMenu.SelectedIndex = 0;
            //listViewUsersGroups.Columns[1].Width = -2;
            //vncconfig.Plan = VNC_Configuration.PlanType.Home;
            SetOptionsFromConfig();
            SetAvailableOptionsFromPlan();
            lblSubType.Text = "Detected subscription type as: " + vncconfig.Plan;
        }

        #region Set Available options and config

        private void SetAvailableOptionsFromPlan()
        {
            switch (vncconfig.Plan)
            {
                case VNC_Configuration.PlanType.Home:
                    radioVNCAuth.Checked = true;
                    radio128.Checked = true;
                    cbDirect.Checked = false;
                    radioVNCAuth.Enabled = true;
                    radioSystemAuth.Enabled = false;
                    radioSingleSignOn.Enabled = false;
                    radioCertificate.Enabled = false;
                    radio128.Enabled = true;
                    radio256.Enabled = false;
                    cbDirect.Enabled = false;
                    linkLabelUpsell.Visible = true;
                    break;
                case VNC_Configuration.PlanType.Professional:
                    radio128.Checked = true;
                    cbDirect.Checked = false;
                    radioVNCAuth.Enabled = true;
                    radioSystemAuth.Enabled = WindowsLogon.PasswordEnabled;
                    lblPasswordWarning.Visible = !WindowsLogon.PasswordEnabled;
                    radioSingleSignOn.Enabled = false;
                    if (WindowsLogon.DomainMember) { radioCertificate.Enabled = true; } else { radioCertificate.Enabled = false; lblDomainInfo.Visible = true; }
                    radio128.Enabled = true;
                    radio256.Enabled = false;
                    cbDirect.Enabled = false;
                    break;
                case VNC_Configuration.PlanType.Enterprise:
                    radioVNCAuth.Enabled = true;
                    radioSystemAuth.Enabled = WindowsLogon.PasswordEnabled;
                    lblPasswordWarning.Visible = !WindowsLogon.PasswordEnabled;
                    if (WindowsLogon.DomainMember) { radioSingleSignOn.Enabled = true; } else { radioSingleSignOn.Enabled = false; lblDomainInfo.Visible = true; }
                    if (WindowsLogon.DomainMember) { radioCertificate.Enabled = true; } else { radioCertificate.Enabled = false; lblDomainInfo.Visible = true; }
                    radio128.Enabled = true;
                    radio256.Enabled = true;
                    cbDirect.Enabled = true;
                    break;
                case VNC_Configuration.PlanType.None:
                    MessageBox.Show("Please run the License Wizard to apply your subscription to VNC Server", "VNC Server is not licensed!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    listBxMenu.SelectedIndex = 0;
                    break;
            }
        }

        private void SetOptionsFromConfig()
        {
            switch (vncconfig.Authentication)
            {
                case VNC_Configuration.AuthenticationType.VncAuth:
                    radioVNCAuth.Checked = true;
                    btnSetVNCPassword.Visible = true;
                    break;
                case VNC_Configuration.AuthenticationType.SystemAuth:
                    radioSystemAuth.Checked = true;
                    btnSetVNCPassword.Visible = false;
                    break;
                case VNC_Configuration.AuthenticationType.SingleSignOn:
                    radioSingleSignOn.Checked = true;
                    btnSetVNCPassword.Visible = false;
                    break;
                case VNC_Configuration.AuthenticationType.Certificate:
                    radioCertificate.Checked = true;
                    btnSetVNCPassword.Visible = false;

                    break;
            }

            switch (vncconfig.Encryption)
            {
                case VNC_Configuration.EncryptionType.AlwaysOn:
                    radio128.Checked = true;
                    break;
                case VNC_Configuration.EncryptionType.AlwaysMaximum:
                    radio256.Checked = true;
                    break;
            }

            switch (vncconfig.Permissions)
            {
                case VNC_Configuration.PermissionsType.Adminstrators:
                    radioAdministrators.Checked = true;
                    break;
                case VNC_Configuration.PermissionsType.Users:
                    radioUsers.Checked = true;
                    break;
                case VNC_Configuration.PermissionsType.CurrentUser:
                    radioCurrentUser.Checked = true;
                    break;
                case VNC_Configuration.PermissionsType.Custom:
                    radioCustomPermissions.Checked = true;
                    txtPermissionsCustom.Text = vncconfig.PermissionsString;
                    break;
            }

            cbQryConn.Checked = vncconfig.AttendedAccess;

            cbCloudRfb.Checked = vncconfig.CloudRfb;
            cbCloudRelay.Checked = vncconfig.CloudRelay;
            cbDirect.Checked = vncconfig.DirectRfb;
        }

        #endregion

        #region Custom Draw Event

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

        #endregion

        #region FormUI
        private void ButtonState(bool showhide, Button button) { button.Enabled = showhide; button.Visible = showhide; }
        //private void CheckboxState(bool enabledisable, CheckBox chkbox) { chkbox.Enabled = enabledisable; chkbox.Checked = enabledisable; }

        private void NavState(bool enabledisable)
        {
            btnNext.Enabled = enabledisable;
            btnBack.Enabled = enabledisable;
            btnSave.Enabled = enabledisable;
            listBxMenu.Enabled = enabledisable;
        }
        private void AccessControlState(bool enabledisable)
        {
            radioAdministrators.Enabled = enabledisable;
            radioCurrentUser.Enabled = enabledisable;
            radioUsers.Enabled = enabledisable;
            radioCustomPermissions.Enabled = enabledisable;
            lblAccessControlInfo.Visible = !enabledisable;

            if (enabledisable == true && radioCustomPermissions.Checked) { txtPermissionsCustom.Enabled = true; }
            else { txtPermissionsCustom.Enabled = false; }
        }

        private void ListBxMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBxMenu.SelectedIndex == 0)
            {
                ButtonState(true, btnNext);
                ButtonState(false, btnBack);
                ButtonState(false, btnSave);
            }
            else if (listBxMenu.SelectedIndex == listBxMenu.Items.Count - 1)
            {

                ButtonState(false, btnNext);
                ButtonState(true, btnBack);
                ButtonState(true, btnSave);
            }
            else
            {
                ButtonState(true, btnNext);
                ButtonState(true, btnBack);
                ButtonState(false, btnSave);
            }
            tabControlContent.SelectTab(listBxMenu.SelectedIndex);
        }

        private void BtnBack_Click(object sender, EventArgs e) { listBxMenu.SelectedIndex -= 1; }

        private void BtnNext_Click(object sender, EventArgs e) { listBxMenu.SelectedIndex += 1; }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (vncconfig.Authentication == VNC_Configuration.AuthenticationType.VncAuth && RegistryManagement.GetRegistryValue(RegHives.HKLM, "Password").Length == 0)
            {
                MessageBox.Show("You need to set a VNC Password", "VNC Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                listBxMenu.SelectedIndex = 1;
                return;
            }

            if (vncconfig.CloudRfb == false && vncconfig.DirectRfb == false)
            {
                MessageBox.Show("No connection types are enabled for VNC Server, please enable one", "No connectivity enabled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                listBxMenu.SelectedIndex = 3;
                return;
            }

            if (vncconfig.SaveConfigurationToRegistry())
            {
                listBxMenu.Enabled = false;
                NavState(false);
                lblCloudName.Text = "Name: " + vncconfig.CloudName;
                lblCloudTeam.Text = "Team: " + vncconfig.CloudTeam;
                lblRfbHostAddress.Text = "Hostname: " + vncconfig.RfbHostAddress;
                lblRfbIPAddress.Text = "IP Address: " + vncconfig.RfbIPAddress;
                lblRfbPort.Text = "Port: " + vncconfig.RfbPort.ToString();

                if (vncconfig.CloudRfb == true) { groupBoxConnectCloud.Visible = true; }
                if (vncconfig.DirectRfb == true) { groupBoxConnectDirect.Visible = true; }

                if ((vncconfig.CloudRfb == true && vncconfig.DirectRfb == false) || (vncconfig.CloudRfb == false && vncconfig.DirectRfb == true))
                {
                    //left 73,39
                    //centre 176,39
                    //right 279,39
                    groupBoxConnectCloud.Location = new Point(176, 65);
                    groupBoxConnectDirect.Location = new Point(176, 65);
                }

                groupBoxFinish.Visible = true;
            }
        }

        private void BtnDone_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel linklabel = (LinkLabel)sender;
            try
            {
                linklabel.LinkVisited = false;
                System.Diagnostics.Process.Start(linklabel.Tag.ToString());
            }
            catch { MessageBox.Show("Unable to open link."); }
        }

        #endregion

        #region Welcome Tab    

        private void BtnLicenseWiz_Click(object sender, EventArgs e)
        {
            if (!btnLicenseWiz.Enabled) { return; }
            NavState(false);
            System.Diagnostics.Process lwProc = new System.Diagnostics.Process();
            lwProc.StartInfo.UseShellExecute = false;
            lwProc.StartInfo.FileName = @"C:\Program Files\RealVNC\VNC Server\vnclicensewiz.exe";
            lwProc.Start();
            lwProc.WaitForExit();
            vncconfig = new VNC_Configuration();
            SetOptionsFromConfig();
            SetAvailableOptionsFromPlan();
            lblSubType.Text = "Detected subscription type as: " + vncconfig.Plan;
            Application.DoEvents();
            NavState(true);
        }

        #endregion

        #region Authentication & Encryption Tab

        private void RadioAuthType_CheckedChanged(object sender, EventArgs e)
        {
            if (radioVNCAuth.Checked)
            {
                vncconfig.Authentication = VNC_Configuration.AuthenticationType.VncAuth;
                lblPasswordWarning.Visible = false;
                btnSetVNCPassword.Visible = true;
                AccessControlState(false);
            }
            else if (radioSystemAuth.Checked)
            {
                vncconfig.Authentication = VNC_Configuration.AuthenticationType.SystemAuth;
                lblPasswordWarning.Visible = !WindowsLogon.PasswordEnabled;
                btnSetVNCPassword.Visible = false;
                AccessControlState(true);
            }
            else if (radioSingleSignOn.Checked)
            {
                vncconfig.Authentication = VNC_Configuration.AuthenticationType.SingleSignOn;
                lblPasswordWarning.Visible = !WindowsLogon.PasswordEnabled;
                btnSetVNCPassword.Visible = false;
                AccessControlState(true);
            }
            else if (radioCertificate.Checked)
            {
                vncconfig.Authentication = VNC_Configuration.AuthenticationType.Certificate;
                lblPasswordWarning.Visible = false;
                btnSetVNCPassword.Visible = false;
                AccessControlState(true);
            }
        }

        private void RadioEncryptionType_CheckedChanged(object sender, EventArgs e)
        {
            if (radio128.Checked) { vncconfig.Encryption = VNC_Configuration.EncryptionType.AlwaysOn; }
            else if (radio256.Checked) { vncconfig.Encryption = VNC_Configuration.EncryptionType.AlwaysMaximum; }
        }

        private void SetVNCPassword_Click(object sender, EventArgs e)
        {
            FrmVNCPassword frmpwd = new FrmVNCPassword();
            frmpwd.ShowDialog();
        }

        #endregion

        #region Access Control Tab

        #region Basic
        private void RadioPermissionsType_CheckedChanged(object sender, EventArgs e)
        {
            if (radioAdministrators.Checked)
            {
                vncconfig.Permissions = VNC_Configuration.PermissionsType.Adminstrators;
                txtPermissionsCustom.Enabled = false;
                linkLabelPermissionsCreator.Visible = false;
            }
            else if (radioUsers.Checked)
            {
                vncconfig.Permissions = VNC_Configuration.PermissionsType.Users;
                txtPermissionsCustom.Enabled = false;
                linkLabelPermissionsCreator.Visible = false;
            }
            else if (radioCurrentUser.Checked)
            {
                vncconfig.Permissions = VNC_Configuration.PermissionsType.CurrentUser;
                txtPermissionsCustom.Enabled = false;
                linkLabelPermissionsCreator.Visible = false;
            }
            else if (radioCustomPermissions.Checked)
            {
                vncconfig.Permissions = VNC_Configuration.PermissionsType.Custom;
                txtPermissionsCustom.Enabled = true;
                linkLabelPermissionsCreator.Visible = true;
            }
        }
        private void QryConn_CheckedChanged(object sender, EventArgs e)
        {
            if (cbQryConn.Checked == true)
            {
                vncconfig.AttendedAccess = true;
            }
            else
            {
                vncconfig.AttendedAccess = false;
            }
        }

        #endregion

        #region Advanced
        //private void AddUserGroup_Click(object sender, EventArgs e)
        //{
        //    DirectoryObjectPickerDialog picker = new DirectoryObjectPickerDialog()
        //    {
        //        AllowedObjectTypes = ObjectTypes.Users | ObjectTypes.Groups | ObjectTypes.BuiltInGroups,
        //        DefaultObjectTypes = ObjectTypes.Users | ObjectTypes.Groups | ObjectTypes.BuiltInGroups,
        //        AllowedLocations = Locations.All,
        //        MultiSelect = true,
        //        ShowAdvancedView = true
        //    };

        //    if (WindowsLogon.DomainMember) { picker.DefaultLocations = Locations.JoinedDomain; }
        //    else { picker.DefaultLocations = Locations.LocalComputer; }

        //    if (picker.ShowDialog() == DialogResult.OK)
        //    {
        //        foreach (DirectoryObject sel in picker.SelectedObjects)
        //        {
        //            VNC_User vncuser = new VNC_User(sel.Name, sel.Path, sel.SchemaClassName, sel.Upn);
        //            ListViewItem item = new ListViewItem(vncuser.Type.ToString());
        //            item.SubItems.Add(vncuser.Name);
        //            item.SubItems.Add(vncuser.SID);
        //            listViewUsersGroups.Items.Add(item);
        //        }
        //    }
        //}

        //private void ListViewUsersGroups_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    textBox1.Text = "";
        //    foreach (ListViewItem item in listViewUsersGroups.SelectedItems)
        //    {
        //        textBox1.Text += item.SubItems[2].Text + ",";
        //    }
        //    textBox1.Text = textBox1.Text.TrimEnd(',');
        //}

        //private void ListViewUsersGroups_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        //{
        //    e.NewWidth = listViewUsersGroups.Columns[e.ColumnIndex].Width;
        //    e.Cancel = true;
        //}

        #endregion

        #endregion

        #region Connections Tab

        private void ConnectionType_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.Name == "cbCloudRfb")
            {
                cbCloudRelay.Enabled = cbCloudRfb.Checked;
                vncconfig.CloudRfb = cbCloudRfb.Checked;
            }
            else if (cb.Name == "cbCloudRelay")
            {
                vncconfig.CloudRelay = cbCloudRelay.Checked;
            }
            else if (cb.Name == "cbDirect")
            {
                vncconfig.DirectRfb = cbDirect.Checked;
            }

            if (cbCloudRfb.Checked == false && cbDirect.Checked == false)
            {
                lblConnectionWarning.Visible = true;
            }
            else
            {
                lblConnectionWarning.Visible = false;
            }
        }

        #endregion

    }
}
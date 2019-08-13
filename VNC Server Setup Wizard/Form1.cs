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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBxMenu.SelectedIndex = 0;
            string cloudcreds = File.ReadAllText("C:\\ProgramData\\RealVNC-Service\\vncserver.d\\CloudCredentials.bed");
            string plantype = cloudcreds.Substring(cloudcreds.LastIndexOf("cloud/plan") + 10, cloudcreds.IndexOf("cloud/principal") - (cloudcreds.LastIndexOf("cloud/plan") + 10));
            plantype = Regex.Replace(new string(plantype.Where(c => !char.IsControl(c)).ToArray()), @"[^\u0000-\u007F]", string.Empty);
            cloudcreds = null;
            switch (plantype)
            {
                case "Home":
                    VNC_Definitions.Plan = VNC_Definitions.PlanType.Home;
                    break;
                case "Professional":
                    VNC_Definitions.Plan = VNC_Definitions.PlanType.Professional;
                    break;
                case "Enterprise":
                    VNC_Definitions.Plan = VNC_Definitions.PlanType.Enterprise;
                    break;
            }

            label2.Text = VNC_Definitions.Plan.ToString();
            plantype = null;
        }

        /// <summary>
        /// Determines whether the local machine is a member of a domain.
        /// </summary>
        /// <returns>A boolean value that indicated whether the local machine is a member of a domain.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/windows/desktop/aa394102%28v=vs.85%29.aspx</remarks>
        public bool IsDomainMember()
        {
            System.Management.ManagementObject ComputerSystem;
            using (ComputerSystem = new System.Management.ManagementObject(String.Format("Win32_ComputerSystem.Name='{0}'", Environment.MachineName)))
            {
                ComputerSystem.Get();
                object Result = ComputerSystem["PartOfDomain"];
                return (Result != null && (bool)Result);
            }
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

        private void ButtonState(bool showhide, Button button)
        {
            button.Enabled = showhide;
            button.Visible = showhide;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DirectoryObjectPickerDialog test = new DirectoryObjectPickerDialog();
            DirectoryObjectPickerDialog picker = new DirectoryObjectPickerDialog()
            {
                AllowedObjectTypes = ObjectTypes.Users | ObjectTypes.Groups | ObjectTypes.BuiltInGroups | ObjectTypes.WellKnownPrincipals,
                DefaultObjectTypes = ObjectTypes.Users | ObjectTypes.Groups | ObjectTypes.BuiltInGroups | ObjectTypes.WellKnownPrincipals,
                AllowedLocations = Locations.All,
                MultiSelect = true,
                ShowAdvancedView = true
            };

            if (IsDomainMember()) { picker.DefaultLocations = Locations.JoinedDomain; }
            else { picker.DefaultLocations = Locations.LocalComputer; }

            if (picker.ShowDialog() == DialogResult.OK)
            {
                foreach (var sel in picker.SelectedObjects)
                {
                    if (sel.Name.Length > 0)
                    {
                        ContextType ctxtype;

                        if (IsDomainMember()) { ctxtype = ContextType.Domain; }
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
                            listView1.Items.Add(item);
                            Console.WriteLine(user.SamAccountName + " is a user, with SID: " + user.Sid);
                        }
                        else if (group.Sid != null)
                        {
                            ListViewItem item = new ListViewItem(group.SamAccountName);
                            item.SubItems.Add("%" + group.Sid.ToString());
                            listView1.Items.Add(item);
                            Console.WriteLine(group.SamAccountName + " is a group, with SID: " + group.Sid);
                        }

                    }
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            }
            else
            {
                textBox1.Text = "";
            }
        }

        private void btnBack_Click(object sender, EventArgs e) { listBxMenu.SelectedIndex -= 1; }

        private void btnNext_Click(object sender, EventArgs e) { listBxMenu.SelectedIndex += 1; }

        private void TabControlContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlContent.SelectedIndex == 1)
            {
                switch (VNC_Definitions.Plan)
                {
                    case VNC_Definitions.PlanType.Home:
                        radioVNCAuth.Enabled = true;
                        radioSystemAuth.Enabled = false;
                        radioSingleSignOn.Enabled = false;
                        radioVNCAuth.Checked = true;
                        break;
                    case VNC_Definitions.PlanType.Professional:
                        radioVNCAuth.Enabled = true;
                        radioSystemAuth.Enabled = true;
                        radioSingleSignOn.Enabled = false;
                        break;
                    case VNC_Definitions.PlanType.Enterprise:
                        radioVNCAuth.Enabled = true;
                        radioSystemAuth.Enabled = true;
                        if (IsDomainMember()) { radioSingleSignOn.Enabled = true; } else { radioSingleSignOn.Enabled = false; }
                        break;
                }
            }
        }
    }
}
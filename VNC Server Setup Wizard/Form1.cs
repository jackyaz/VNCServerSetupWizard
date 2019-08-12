using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.Text;
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
            // Define the default color of the brush as black.
            Brush myBrush;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected) { myBrush = Brushes.White; }
            else { myBrush = Brushes.Black; }

            // Draw the current item text based on the current Font 
            // and the custom brush settings.
            SizeF size = e.Graphics.MeasureString(listBxMenu.Items[e.Index].ToString(), e.Font);
            e.Graphics.DrawString(listBxMenu.Items[e.Index].ToString(), e.Font, myBrush, e.Bounds.Left + (e.Bounds.Width / 2 - size.Width / 2), e.Bounds.Top + (e.Bounds.Height / 2 - size.Height / 2), StringFormat.GenericDefault);

            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }

        private void listBxMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(listBxMenu.SelectedItem.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DirectoryObjectPickerDialog test = new DirectoryObjectPickerDialog();
            DirectoryObjectPickerDialog picker = new DirectoryObjectPickerDialog()
            {
                AllowedObjectTypes = ObjectTypes.All,
                DefaultObjectTypes = ObjectTypes.All,
                AllowedLocations = Locations.All,
                DefaultLocations = Locations.LocalComputer,
                MultiSelect = true,
                ShowAdvancedView = true
            };

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

                        user.SamAccountName = sel.Name;
                        var searcher = new PrincipalSearcher(user);
                        user = searcher.FindOne() as UserPrincipal;

                        if (user == null)
                        {
                            group.SamAccountName = sel.Name;
                            searcher = new PrincipalSearcher(group);
                            group = searcher.FindOne() as GroupPrincipal;
                        }

                        if (user != null)
                        {
                            ListViewItem item = new ListViewItem(user.SamAccountName);
                            item.SubItems.Add(user.Sid.ToString());
                            listView1.Items.Add(item);
                            Console.WriteLine(user.SamAccountName + " is a user, with SID: " + user.Sid);
                            
                        }
                        else if (group != null)
                        {
                            ListViewItem item = new ListViewItem(group.SamAccountName);
                            item.SubItems.Add(group.Sid.ToString());
                            listView1.Items.Add(item);
                            Console.WriteLine(group.SamAccountName + " is a group, with SID: " + group.Sid);
                        }

                    }
                }
            }
        }
    }
}

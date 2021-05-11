using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VNC_Server_Setup_Wizard
{
    public partial class FrmVNCPassword : Form
    {
        public FrmVNCPassword()
        {
            InitializeComponent();
        }

        private void ToggleVNCPasswordFields(bool showhide)
        {
            lblPassword1.Visible = showhide;
            lblPassword2.Visible = showhide;
            txtBoxPassword1.Visible = showhide;
            txtBoxPassword2.Visible = showhide;

            if (RegistryManagement.GetRegistryValue(RegHives.HKLM, "Password").Length > 0)
            {
                txtBoxPassword1.Text = "";
                txtBoxPassword2.Text = "";
            }

            CheckVNCPassword();
            btnConfirmPassword.Visible = showhide;
        }

        private void CheckVNCPassword()
        {
            if (txtBoxPassword1.Text != txtBoxPassword2.Text) { lblVNCPasswordMessage.Visible = true; }
            else if (txtBoxPassword1.Text == txtBoxPassword2.Text) { lblVNCPasswordMessage.Visible = false; }
        }

        private void TxtBoxPassword_TextChanged(object sender, EventArgs e)
        {
            CheckVNCPassword();
        }

        private void TxtBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnConfirmPassword.PerformClick();
                e.Handled = true;
            }
        }

        private void btnConfirmPassword_Click(object sender, EventArgs e)
        {
            if (txtBoxPassword1.Text.Length > 0 && txtBoxPassword2.Text.Length > 0)
                if (txtBoxPassword1.Text == txtBoxPassword2.Text)
                {
                    if (VNC_Password.SetEncryptedPassword(txtBoxPassword1.Text))
                    {
                        txtBoxPassword1.Text = "********";
                        txtBoxPassword2.Text = "********";
                        txtBoxPassword1.Enabled = false;
                        txtBoxPassword2.Enabled = false;
                        btnConfirmPassword.Enabled = false;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("An error occurred when setting VNC Password, please try again.", "Error setting VNC Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        }
    }
}

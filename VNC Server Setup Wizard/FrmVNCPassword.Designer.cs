namespace VNC_Server_Setup_Wizard
{
    partial class FrmVNCPassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConfirmPassword = new System.Windows.Forms.Button();
            this.lblVNCPasswordMessage = new System.Windows.Forms.Label();
            this.lblPassword2 = new System.Windows.Forms.Label();
            this.lblPassword1 = new System.Windows.Forms.Label();
            this.txtBoxPassword2 = new System.Windows.Forms.TextBox();
            this.txtBoxPassword1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnConfirmPassword
            // 
            this.btnConfirmPassword.Location = new System.Drawing.Point(317, 31);
            this.btnConfirmPassword.Name = "btnConfirmPassword";
            this.btnConfirmPassword.Size = new System.Drawing.Size(106, 23);
            this.btnConfirmPassword.TabIndex = 5;
            this.btnConfirmPassword.Text = "Confirm password";
            this.btnConfirmPassword.UseVisualStyleBackColor = true;
            this.btnConfirmPassword.Click += new System.EventHandler(this.btnConfirmPassword_Click);
            // 
            // lblVNCPasswordMessage
            // 
            this.lblVNCPasswordMessage.BackColor = System.Drawing.Color.Yellow;
            this.lblVNCPasswordMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVNCPasswordMessage.Location = new System.Drawing.Point(292, 4);
            this.lblVNCPasswordMessage.Name = "lblVNCPasswordMessage";
            this.lblVNCPasswordMessage.Size = new System.Drawing.Size(156, 22);
            this.lblVNCPasswordMessage.TabIndex = 4;
            this.lblVNCPasswordMessage.Text = "Passwords do not match!";
            this.lblVNCPasswordMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblVNCPasswordMessage.Visible = false;
            // 
            // lblPassword2
            // 
            this.lblPassword2.AutoSize = true;
            this.lblPassword2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword2.Location = new System.Drawing.Point(12, 38);
            this.lblPassword2.Name = "lblPassword2";
            this.lblPassword2.Size = new System.Drawing.Size(93, 13);
            this.lblPassword2.TabIndex = 2;
            this.lblPassword2.Text = "Confirm password:";
            this.lblPassword2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPassword1
            // 
            this.lblPassword1.AutoSize = true;
            this.lblPassword1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword1.Location = new System.Drawing.Point(12, 9);
            this.lblPassword1.Name = "lblPassword1";
            this.lblPassword1.Size = new System.Drawing.Size(83, 13);
            this.lblPassword1.TabIndex = 0;
            this.lblPassword1.Text = "Enter password:";
            this.lblPassword1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBoxPassword2
            // 
            this.txtBoxPassword2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxPassword2.Location = new System.Drawing.Point(111, 34);
            this.txtBoxPassword2.Name = "txtBoxPassword2";
            this.txtBoxPassword2.Size = new System.Drawing.Size(175, 20);
            this.txtBoxPassword2.TabIndex = 3;
            this.txtBoxPassword2.UseSystemPasswordChar = true;
            this.txtBoxPassword2.TextChanged += new System.EventHandler(this.TxtBoxPassword_TextChanged);
            this.txtBoxPassword2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBoxPassword_KeyPress);
            // 
            // txtBoxPassword1
            // 
            this.txtBoxPassword1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxPassword1.Location = new System.Drawing.Point(111, 6);
            this.txtBoxPassword1.Name = "txtBoxPassword1";
            this.txtBoxPassword1.Size = new System.Drawing.Size(175, 20);
            this.txtBoxPassword1.TabIndex = 1;
            this.txtBoxPassword1.UseSystemPasswordChar = true;
            this.txtBoxPassword1.TextChanged += new System.EventHandler(this.TxtBoxPassword_TextChanged);
            this.txtBoxPassword1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBoxPassword_KeyPress);
            // 
            // frmVNCPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 60);
            this.Controls.Add(this.btnConfirmPassword);
            this.Controls.Add(this.lblVNCPasswordMessage);
            this.Controls.Add(this.lblPassword2);
            this.Controls.Add(this.lblPassword1);
            this.Controls.Add(this.txtBoxPassword2);
            this.Controls.Add(this.txtBoxPassword1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVNCPassword";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "VNC Password";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfirmPassword;
        private System.Windows.Forms.Label lblVNCPasswordMessage;
        private System.Windows.Forms.Label lblPassword2;
        private System.Windows.Forms.Label lblPassword1;
        private System.Windows.Forms.TextBox txtBoxPassword2;
        private System.Windows.Forms.TextBox txtBoxPassword1;
    }
}
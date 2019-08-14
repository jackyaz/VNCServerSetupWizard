namespace VNC_Server_Setup_Wizard
{
    partial class frmMain
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
            this.listBxMenu = new System.Windows.Forms.ListBox();
            this.splitContMenu = new System.Windows.Forms.SplitContainer();
            this.splitContSubMenu = new System.Windows.Forms.SplitContainer();
            this.tabControlContent = new System.Windows.Forms.TabControl();
            this.tabPageWelcome = new System.Windows.Forms.TabPage();
            this.lblWelcomeSubtitle = new System.Windows.Forms.Label();
            this.lblWelcomeTitle = new System.Windows.Forms.Label();
            this.tabPageAuth = new System.Windows.Forms.TabPage();
            this.lblAuthSubtitle = new System.Windows.Forms.Label();
            this.lblDomainInfo = new System.Windows.Forms.Label();
            this.lblPasswordWarning = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.radioVNCAuth = new System.Windows.Forms.RadioButton();
            this.radioSystemAuth = new System.Windows.Forms.RadioButton();
            this.radioSingleSignOn = new System.Windows.Forms.RadioButton();
            this.lblAuthTitle = new System.Windows.Forms.Label();
            this.tabPageUsers = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.listViewUsersGroups = new System.Windows.Forms.ListView();
            this.columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageEncryption = new System.Windows.Forms.TabPage();
            this.radio128 = new System.Windows.Forms.RadioButton();
            this.radio256 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEncryptionTitle = new System.Windows.Forms.Label();
            this.tabPageFinish = new System.Windows.Forms.TabPage();
            this.lblFinishTitle = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContMenu)).BeginInit();
            this.splitContMenu.Panel1.SuspendLayout();
            this.splitContMenu.Panel2.SuspendLayout();
            this.splitContMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContSubMenu)).BeginInit();
            this.splitContSubMenu.Panel1.SuspendLayout();
            this.splitContSubMenu.Panel2.SuspendLayout();
            this.splitContSubMenu.SuspendLayout();
            this.tabControlContent.SuspendLayout();
            this.tabPageWelcome.SuspendLayout();
            this.tabPageAuth.SuspendLayout();
            this.tabPageUsers.SuspendLayout();
            this.tabPageEncryption.SuspendLayout();
            this.tabPageFinish.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBxMenu
            // 
            this.listBxMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBxMenu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBxMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBxMenu.FormattingEnabled = true;
            this.listBxMenu.IntegralHeight = false;
            this.listBxMenu.ItemHeight = 50;
            this.listBxMenu.Items.AddRange(new object[] {
            "Welcome",
            "Authentication",
            "Users & Permissions",
            "Encryption",
            "Finish"});
            this.listBxMenu.Location = new System.Drawing.Point(0, 0);
            this.listBxMenu.Name = "listBxMenu";
            this.listBxMenu.Size = new System.Drawing.Size(185, 390);
            this.listBxMenu.TabIndex = 0;
            this.listBxMenu.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBxMenu_DrawItem);
            this.listBxMenu.SelectedIndexChanged += new System.EventHandler(this.listBxMenu_SelectedIndexChanged);
            // 
            // splitContMenu
            // 
            this.splitContMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContMenu.IsSplitterFixed = true;
            this.splitContMenu.Location = new System.Drawing.Point(0, 0);
            this.splitContMenu.Name = "splitContMenu";
            // 
            // splitContMenu.Panel1
            // 
            this.splitContMenu.Panel1.Controls.Add(this.listBxMenu);
            // 
            // splitContMenu.Panel2
            // 
            this.splitContMenu.Panel2.Controls.Add(this.splitContSubMenu);
            this.splitContMenu.Size = new System.Drawing.Size(764, 390);
            this.splitContMenu.SplitterDistance = 185;
            this.splitContMenu.TabIndex = 1;
            // 
            // splitContSubMenu
            // 
            this.splitContSubMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContSubMenu.IsSplitterFixed = true;
            this.splitContSubMenu.Location = new System.Drawing.Point(0, 0);
            this.splitContSubMenu.Name = "splitContSubMenu";
            this.splitContSubMenu.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContSubMenu.Panel1
            // 
            this.splitContSubMenu.Panel1.Controls.Add(this.tabControlContent);
            // 
            // splitContSubMenu.Panel2
            // 
            this.splitContSubMenu.Panel2.Controls.Add(this.btnNext);
            this.splitContSubMenu.Panel2.Controls.Add(this.btnBack);
            this.splitContSubMenu.Size = new System.Drawing.Size(575, 390);
            this.splitContSubMenu.SplitterDistance = 325;
            this.splitContSubMenu.TabIndex = 0;
            // 
            // tabControlContent
            // 
            this.tabControlContent.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControlContent.Controls.Add(this.tabPageWelcome);
            this.tabControlContent.Controls.Add(this.tabPageAuth);
            this.tabControlContent.Controls.Add(this.tabPageUsers);
            this.tabControlContent.Controls.Add(this.tabPageEncryption);
            this.tabControlContent.Controls.Add(this.tabPageFinish);
            this.tabControlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlContent.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControlContent.Location = new System.Drawing.Point(0, 0);
            this.tabControlContent.Name = "tabControlContent";
            this.tabControlContent.SelectedIndex = 0;
            this.tabControlContent.Size = new System.Drawing.Size(575, 325);
            this.tabControlContent.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlContent.TabIndex = 8;
            this.tabControlContent.SelectedIndexChanged += new System.EventHandler(this.tabControlContent_SelectedIndexChanged);
            // 
            // tabPageWelcome
            // 
            this.tabPageWelcome.Controls.Add(this.lblWelcomeSubtitle);
            this.tabPageWelcome.Controls.Add(this.lblWelcomeTitle);
            this.tabPageWelcome.Location = new System.Drawing.Point(4, 5);
            this.tabPageWelcome.Name = "tabPageWelcome";
            this.tabPageWelcome.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWelcome.Size = new System.Drawing.Size(567, 316);
            this.tabPageWelcome.TabIndex = 0;
            this.tabPageWelcome.UseVisualStyleBackColor = true;
            // 
            // lblWelcomeSubtitle
            // 
            this.lblWelcomeSubtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeSubtitle.Location = new System.Drawing.Point(6, 56);
            this.lblWelcomeSubtitle.Name = "lblWelcomeSubtitle";
            this.lblWelcomeSubtitle.Size = new System.Drawing.Size(555, 57);
            this.lblWelcomeSubtitle.TabIndex = 1;
            this.lblWelcomeSubtitle.Text = "This wizard will help you get up and running with VNC Server, and enable you to s" +
    "tart enjoying the benefits of VNC Connect by RealVNC.";
            this.lblWelcomeSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWelcomeTitle
            // 
            this.lblWelcomeTitle.AutoSize = true;
            this.lblWelcomeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeTitle.Location = new System.Drawing.Point(82, 4);
            this.lblWelcomeTitle.Name = "lblWelcomeTitle";
            this.lblWelcomeTitle.Size = new System.Drawing.Size(402, 24);
            this.lblWelcomeTitle.TabIndex = 0;
            this.lblWelcomeTitle.Text = "Welcome to the VNC Server Setup Wizard";
            // 
            // tabPageAuth
            // 
            this.tabPageAuth.Controls.Add(this.lblAuthSubtitle);
            this.tabPageAuth.Controls.Add(this.lblDomainInfo);
            this.tabPageAuth.Controls.Add(this.lblPasswordWarning);
            this.tabPageAuth.Controls.Add(this.linkLabel2);
            this.tabPageAuth.Controls.Add(this.linkLabel1);
            this.tabPageAuth.Controls.Add(this.radioVNCAuth);
            this.tabPageAuth.Controls.Add(this.radioSystemAuth);
            this.tabPageAuth.Controls.Add(this.radioSingleSignOn);
            this.tabPageAuth.Controls.Add(this.lblAuthTitle);
            this.tabPageAuth.Location = new System.Drawing.Point(4, 5);
            this.tabPageAuth.Name = "tabPageAuth";
            this.tabPageAuth.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAuth.Size = new System.Drawing.Size(567, 316);
            this.tabPageAuth.TabIndex = 1;
            this.tabPageAuth.UseVisualStyleBackColor = true;
            // 
            // lblAuthSubtitle
            // 
            this.lblAuthSubtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthSubtitle.Location = new System.Drawing.Point(6, 42);
            this.lblAuthSubtitle.Name = "lblAuthSubtitle";
            this.lblAuthSubtitle.Size = new System.Drawing.Size(555, 23);
            this.lblAuthSubtitle.TabIndex = 8;
            this.lblAuthSubtitle.Text = "Select the authentication method you want to use when connecting to this VNC Serv" +
    "er.";
            // 
            // lblDomainInfo
            // 
            this.lblDomainInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDomainInfo.ForeColor = System.Drawing.Color.Black;
            this.lblDomainInfo.Location = new System.Drawing.Point(6, 262);
            this.lblDomainInfo.Name = "lblDomainInfo";
            this.lblDomainInfo.Size = new System.Drawing.Size(549, 48);
            this.lblDomainInfo.TabIndex = 7;
            this.lblDomainInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDomainInfo.Visible = false;
            // 
            // lblPasswordWarning
            // 
            this.lblPasswordWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordWarning.ForeColor = System.Drawing.Color.Red;
            this.lblPasswordWarning.Location = new System.Drawing.Point(6, 188);
            this.lblPasswordWarning.Name = "lblPasswordWarning";
            this.lblPasswordWarning.Size = new System.Drawing.Size(549, 48);
            this.lblPasswordWarning.TabIndex = 6;
            this.lblPasswordWarning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPasswordWarning.Visible = false;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(491, 243);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(55, 13);
            this.linkLabel2.TabIndex = 5;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "linkLabel2";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(363, 169);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(55, 13);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel1";
            // 
            // radioVNCAuth
            // 
            this.radioVNCAuth.AutoSize = true;
            this.radioVNCAuth.Checked = true;
            this.radioVNCAuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioVNCAuth.Location = new System.Drawing.Point(9, 91);
            this.radioVNCAuth.Name = "radioVNCAuth";
            this.radioVNCAuth.Size = new System.Drawing.Size(117, 20);
            this.radioVNCAuth.TabIndex = 1;
            this.radioVNCAuth.TabStop = true;
            this.radioVNCAuth.Text = "VNC Password";
            this.radioVNCAuth.UseVisualStyleBackColor = true;
            // 
            // radioSystemAuth
            // 
            this.radioSystemAuth.AutoSize = true;
            this.radioSystemAuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioSystemAuth.Location = new System.Drawing.Point(9, 165);
            this.radioSystemAuth.Name = "radioSystemAuth";
            this.radioSystemAuth.Size = new System.Drawing.Size(348, 20);
            this.radioSystemAuth.TabIndex = 2;
            this.radioSystemAuth.Text = "Windows Password (Professional and Enterprise only)";
            this.radioSystemAuth.UseVisualStyleBackColor = true;
            // 
            // radioSingleSignOn
            // 
            this.radioSingleSignOn.AutoSize = true;
            this.radioSingleSignOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioSingleSignOn.Location = new System.Drawing.Point(9, 239);
            this.radioSingleSignOn.Name = "radioSingleSignOn";
            this.radioSingleSignOn.Size = new System.Drawing.Size(476, 20);
            this.radioSingleSignOn.TabIndex = 3;
            this.radioSingleSignOn.Text = "Single Sign On (Enterprise only, requires computer to be joined to a Domain)";
            this.radioSingleSignOn.UseVisualStyleBackColor = true;
            // 
            // lblAuthTitle
            // 
            this.lblAuthTitle.AutoSize = true;
            this.lblAuthTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthTitle.Location = new System.Drawing.Point(214, 4);
            this.lblAuthTitle.Name = "lblAuthTitle";
            this.lblAuthTitle.Size = new System.Drawing.Size(143, 24);
            this.lblAuthTitle.TabIndex = 0;
            this.lblAuthTitle.Text = "Authentication";
            // 
            // tabPageUsers
            // 
            this.tabPageUsers.Controls.Add(this.textBox1);
            this.tabPageUsers.Controls.Add(this.label1);
            this.tabPageUsers.Controls.Add(this.button1);
            this.tabPageUsers.Controls.Add(this.listViewUsersGroups);
            this.tabPageUsers.Location = new System.Drawing.Point(4, 5);
            this.tabPageUsers.Name = "tabPageUsers";
            this.tabPageUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUsers.Size = new System.Drawing.Size(567, 316);
            this.tabPageUsers.TabIndex = 2;
            this.tabPageUsers.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(148, 115);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(241, 20);
            this.textBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listViewUsersGroups
            // 
            this.listViewUsersGroups.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listViewUsersGroups.AutoArrange = false;
            this.listViewUsersGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader});
            this.listViewUsersGroups.FullRowSelect = true;
            this.listViewUsersGroups.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewUsersGroups.Location = new System.Drawing.Point(48, 161);
            this.listViewUsersGroups.MultiSelect = false;
            this.listViewUsersGroups.Name = "listViewUsersGroups";
            this.listViewUsersGroups.Scrollable = false;
            this.listViewUsersGroups.ShowGroups = false;
            this.listViewUsersGroups.Size = new System.Drawing.Size(341, 238);
            this.listViewUsersGroups.TabIndex = 1;
            this.listViewUsersGroups.UseCompatibleStateImageBehavior = false;
            this.listViewUsersGroups.View = System.Windows.Forms.View.Details;
            this.listViewUsersGroups.SelectedIndexChanged += new System.EventHandler(this.listViewUsersGroups_SelectedIndexChanged);
            // 
            // columnHeader
            // 
            this.columnHeader.Text = "";
            this.columnHeader.Width = 150;
            // 
            // tabPageEncryption
            // 
            this.tabPageEncryption.Controls.Add(this.radio128);
            this.tabPageEncryption.Controls.Add(this.radio256);
            this.tabPageEncryption.Controls.Add(this.label2);
            this.tabPageEncryption.Controls.Add(this.lblEncryptionTitle);
            this.tabPageEncryption.Location = new System.Drawing.Point(4, 5);
            this.tabPageEncryption.Name = "tabPageEncryption";
            this.tabPageEncryption.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEncryption.Size = new System.Drawing.Size(567, 316);
            this.tabPageEncryption.TabIndex = 3;
            this.tabPageEncryption.UseVisualStyleBackColor = true;
            // 
            // radio128
            // 
            this.radio128.AutoSize = true;
            this.radio128.Checked = true;
            this.radio128.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio128.Location = new System.Drawing.Point(9, 96);
            this.radio128.Name = "radio128";
            this.radio128.Size = new System.Drawing.Size(95, 20);
            this.radio128.TabIndex = 10;
            this.radio128.TabStop = true;
            this.radio128.Text = "128-bit AES";
            this.radio128.UseVisualStyleBackColor = true;
            // 
            // radio256
            // 
            this.radio256.AutoSize = true;
            this.radio256.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio256.Location = new System.Drawing.Point(9, 170);
            this.radio256.Name = "radio256";
            this.radio256.Size = new System.Drawing.Size(195, 20);
            this.radio256.TabIndex = 11;
            this.radio256.Text = "256-bit AES (Enterprise only)";
            this.radio256.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(555, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "Select the level of encryption you want to use when connecting to this VNC Server" +
    ".";
            // 
            // lblEncryptionTitle
            // 
            this.lblEncryptionTitle.AutoSize = true;
            this.lblEncryptionTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncryptionTitle.Location = new System.Drawing.Point(228, 4);
            this.lblEncryptionTitle.Name = "lblEncryptionTitle";
            this.lblEncryptionTitle.Size = new System.Drawing.Size(110, 24);
            this.lblEncryptionTitle.TabIndex = 0;
            this.lblEncryptionTitle.Text = "Encryption";
            // 
            // tabPageFinish
            // 
            this.tabPageFinish.Controls.Add(this.lblFinishTitle);
            this.tabPageFinish.Location = new System.Drawing.Point(4, 5);
            this.tabPageFinish.Name = "tabPageFinish";
            this.tabPageFinish.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFinish.Size = new System.Drawing.Size(567, 316);
            this.tabPageFinish.TabIndex = 4;
            this.tabPageFinish.UseVisualStyleBackColor = true;
            // 
            // lblFinishTitle
            // 
            this.lblFinishTitle.AutoSize = true;
            this.lblFinishTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinishTitle.Location = new System.Drawing.Point(250, 4);
            this.lblFinishTitle.Name = "lblFinishTitle";
            this.lblFinishTitle.Size = new System.Drawing.Size(67, 24);
            this.lblFinishTitle.TabIndex = 0;
            this.lblFinishTitle.Text = "Finish";
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(463, 10);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 40);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Next >>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(4, 10);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 40);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "<< Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 390);
            this.Controls.Add(this.splitContMenu);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VNC Server Setup Wizard";
            this.splitContMenu.Panel1.ResumeLayout(false);
            this.splitContMenu.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContMenu)).EndInit();
            this.splitContMenu.ResumeLayout(false);
            this.splitContSubMenu.Panel1.ResumeLayout(false);
            this.splitContSubMenu.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContSubMenu)).EndInit();
            this.splitContSubMenu.ResumeLayout(false);
            this.tabControlContent.ResumeLayout(false);
            this.tabPageWelcome.ResumeLayout(false);
            this.tabPageWelcome.PerformLayout();
            this.tabPageAuth.ResumeLayout(false);
            this.tabPageAuth.PerformLayout();
            this.tabPageUsers.ResumeLayout(false);
            this.tabPageUsers.PerformLayout();
            this.tabPageEncryption.ResumeLayout(false);
            this.tabPageEncryption.PerformLayout();
            this.tabPageFinish.ResumeLayout(false);
            this.tabPageFinish.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox listBxMenu;
        private System.Windows.Forms.SplitContainer splitContMenu;
        private System.Windows.Forms.SplitContainer splitContSubMenu;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listViewUsersGroups;
        private System.Windows.Forms.ColumnHeader columnHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEncryptionTitle;
        private System.Windows.Forms.Label lblAuthTitle;
        private System.Windows.Forms.Label lblWelcomeTitle;
        private System.Windows.Forms.TabControl tabControlContent;
        private System.Windows.Forms.TabPage tabPageWelcome;
        private System.Windows.Forms.TabPage tabPageAuth;
        private System.Windows.Forms.TabPage tabPageUsers;
        private System.Windows.Forms.TabPage tabPageEncryption;
        private System.Windows.Forms.TabPage tabPageFinish;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblFinishTitle;
        private System.Windows.Forms.RadioButton radioSystemAuth;
        private System.Windows.Forms.RadioButton radioVNCAuth;
        private System.Windows.Forms.RadioButton radioSingleSignOn;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label lblPasswordWarning;
        private System.Windows.Forms.Label lblDomainInfo;
        private System.Windows.Forms.Label lblWelcomeSubtitle;
        private System.Windows.Forms.Label lblAuthSubtitle;
        private System.Windows.Forms.RadioButton radio128;
        private System.Windows.Forms.RadioButton radio256;
        private System.Windows.Forms.Label label2;
    }
}


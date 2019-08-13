namespace VNC_Server_Setup_Wizard
{
    partial class Form1
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
            this.label2 = new System.Windows.Forms.Label();
            this.tabPageAuth = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPageUsers = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageEncryption = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPageFinish = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.radioVNCAuth = new System.Windows.Forms.RadioButton();
            this.radioSystemAuth = new System.Windows.Forms.RadioButton();
            this.radioSingleSignOn = new System.Windows.Forms.RadioButton();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
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
            this.listBxMenu.Size = new System.Drawing.Size(185, 469);
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
            this.splitContMenu.Size = new System.Drawing.Size(764, 469);
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
            this.splitContSubMenu.Size = new System.Drawing.Size(575, 469);
            this.splitContSubMenu.SplitterDistance = 414;
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
            this.tabControlContent.Size = new System.Drawing.Size(575, 414);
            this.tabControlContent.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlContent.TabIndex = 8;
            this.tabControlContent.SelectedIndexChanged += new System.EventHandler(this.TabControlContent_SelectedIndexChanged);
            // 
            // tabPageWelcome
            // 
            this.tabPageWelcome.Controls.Add(this.label2);
            this.tabPageWelcome.Location = new System.Drawing.Point(4, 5);
            this.tabPageWelcome.Name = "tabPageWelcome";
            this.tabPageWelcome.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWelcome.Size = new System.Drawing.Size(421, 405);
            this.tabPageWelcome.TabIndex = 0;
            this.tabPageWelcome.Text = "tabPage1";
            this.tabPageWelcome.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Welcome";
            // 
            // tabPageAuth
            // 
            this.tabPageAuth.Controls.Add(this.linkLabel2);
            this.tabPageAuth.Controls.Add(this.linkLabel1);
            this.tabPageAuth.Controls.Add(this.radioVNCAuth);
            this.tabPageAuth.Controls.Add(this.radioSystemAuth);
            this.tabPageAuth.Controls.Add(this.radioSingleSignOn);
            this.tabPageAuth.Controls.Add(this.label3);
            this.tabPageAuth.Location = new System.Drawing.Point(4, 5);
            this.tabPageAuth.Name = "tabPageAuth";
            this.tabPageAuth.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAuth.Size = new System.Drawing.Size(567, 405);
            this.tabPageAuth.TabIndex = 1;
            this.tabPageAuth.Text = "tabPage2";
            this.tabPageAuth.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(139, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Authentication";
            // 
            // tabPageUsers
            // 
            this.tabPageUsers.Controls.Add(this.textBox1);
            this.tabPageUsers.Controls.Add(this.label1);
            this.tabPageUsers.Controls.Add(this.button1);
            this.tabPageUsers.Controls.Add(this.listView1);
            this.tabPageUsers.Location = new System.Drawing.Point(4, 5);
            this.tabPageUsers.Name = "tabPageUsers";
            this.tabPageUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUsers.Size = new System.Drawing.Size(421, 405);
            this.tabPageUsers.TabIndex = 2;
            this.tabPageUsers.Text = "tabPage3";
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
            // listView1
            // 
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listView1.AutoArrange = false;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.Location = new System.Drawing.Point(48, 161);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Scrollable = false;
            this.listView1.ShowGroups = false;
            this.listView1.Size = new System.Drawing.Size(341, 238);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 150;
            // 
            // tabPageEncryption
            // 
            this.tabPageEncryption.Controls.Add(this.label4);
            this.tabPageEncryption.Location = new System.Drawing.Point(4, 5);
            this.tabPageEncryption.Name = "tabPageEncryption";
            this.tabPageEncryption.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEncryption.Size = new System.Drawing.Size(421, 405);
            this.tabPageEncryption.TabIndex = 3;
            this.tabPageEncryption.Text = "tabPage4";
            this.tabPageEncryption.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(165, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Encryption";
            // 
            // tabPageFinish
            // 
            this.tabPageFinish.Controls.Add(this.label5);
            this.tabPageFinish.Location = new System.Drawing.Point(4, 5);
            this.tabPageFinish.Name = "tabPageFinish";
            this.tabPageFinish.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFinish.Size = new System.Drawing.Size(421, 405);
            this.tabPageFinish.TabIndex = 4;
            this.tabPageFinish.Text = "tabPage5";
            this.tabPageFinish.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(113, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Finish";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(351, 16);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Next >>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(3, 16);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "<< Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // radioVNCAuth
            // 
            this.radioVNCAuth.AutoSize = true;
            this.radioVNCAuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioVNCAuth.Location = new System.Drawing.Point(15, 121);
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
            this.radioSystemAuth.Location = new System.Drawing.Point(15, 151);
            this.radioSystemAuth.Name = "radioSystemAuth";
            this.radioSystemAuth.Size = new System.Drawing.Size(348, 20);
            this.radioSystemAuth.TabIndex = 2;
            this.radioSystemAuth.TabStop = true;
            this.radioSystemAuth.Text = "Windows Password (Professional and Enterprise only)";
            this.radioSystemAuth.UseVisualStyleBackColor = true;
            // 
            // radioSingleSignOn
            // 
            this.radioSingleSignOn.AutoSize = true;
            this.radioSingleSignOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioSingleSignOn.Location = new System.Drawing.Point(15, 181);
            this.radioSingleSignOn.Name = "radioSingleSignOn";
            this.radioSingleSignOn.Size = new System.Drawing.Size(476, 20);
            this.radioSingleSignOn.TabIndex = 3;
            this.radioSingleSignOn.TabStop = true;
            this.radioSingleSignOn.Text = "Single Sign On (Enterprise only, requires computer to be joined to a Domain)";
            this.radioSingleSignOn.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(370, 157);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(55, 13);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel1";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(497, 185);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(55, 13);
            this.linkLabel2.TabIndex = 5;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "linkLabel2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 469);
            this.Controls.Add(this.splitContMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Form1";
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
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControlContent;
        private System.Windows.Forms.TabPage tabPageWelcome;
        private System.Windows.Forms.TabPage tabPageAuth;
        private System.Windows.Forms.TabPage tabPageUsers;
        private System.Windows.Forms.TabPage tabPageEncryption;
        private System.Windows.Forms.TabPage tabPageFinish;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioSystemAuth;
        private System.Windows.Forms.RadioButton radioVNCAuth;
        private System.Windows.Forms.RadioButton radioSingleSignOn;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}


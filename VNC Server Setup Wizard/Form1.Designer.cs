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
            this.button1 = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContMenu)).BeginInit();
            this.splitContMenu.Panel1.SuspendLayout();
            this.splitContMenu.Panel2.SuspendLayout();
            this.splitContMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContSubMenu)).BeginInit();
            this.splitContSubMenu.Panel1.SuspendLayout();
            this.splitContSubMenu.Panel2.SuspendLayout();
            this.splitContSubMenu.SuspendLayout();
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
            this.listBxMenu.Size = new System.Drawing.Size(139, 469);
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
            this.splitContMenu.Size = new System.Drawing.Size(572, 469);
            this.splitContMenu.SplitterDistance = 139;
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
            this.splitContSubMenu.Panel1.Controls.Add(this.listView1);
            this.splitContSubMenu.Panel1.Controls.Add(this.button1);
            // 
            // splitContSubMenu.Panel2
            // 
            this.splitContSubMenu.Panel2.Controls.Add(this.btnNext);
            this.splitContSubMenu.Panel2.Controls.Add(this.btnBack);
            this.splitContSubMenu.Size = new System.Drawing.Size(429, 469);
            this.splitContSubMenu.SplitterDistance = 414;
            this.splitContSubMenu.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(176, 315);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(351, 16);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Next >>";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(3, 16);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "<< Back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listView1.AutoArrange = false;
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(3, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Scrollable = false;
            this.listView1.ShowGroups = false;
            this.listView1.Size = new System.Drawing.Size(341, 238);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.SmallIcon;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 469);
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
    }
}


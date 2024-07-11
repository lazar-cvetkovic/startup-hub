namespace ClientProject.Forms
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnFundingPrograms = new FontAwesome.Sharp.IconButton();
            this.btnStartupEvents = new FontAwesome.Sharp.IconButton();
            this.btnHome = new FontAwesome.Sharp.IconButton();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.btnMaximize = new FontAwesome.Sharp.IconButton();
            this.btnMinimize = new FontAwesome.Sharp.IconButton();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnYourStartup = new FontAwesome.Sharp.IconButton();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panelMenu.Controls.Add(this.btnYourStartup);
            this.panelMenu.Controls.Add(this.btnFundingPrograms);
            this.panelMenu.Controls.Add(this.btnStartupEvents);
            this.panelMenu.Controls.Add(this.btnHome);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(300, 801);
            this.panelMenu.TabIndex = 0;
            this.panelMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseClickStart);
            this.panelMenu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMovement);
            this.panelMenu.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseClickEnd);
            // 
            // btnFundingPrograms
            // 
            this.btnFundingPrograms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.btnFundingPrograms.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFundingPrograms.FlatAppearance.BorderSize = 0;
            this.btnFundingPrograms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFundingPrograms.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFundingPrograms.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnFundingPrograms.IconChar = FontAwesome.Sharp.IconChar.House;
            this.btnFundingPrograms.IconColor = System.Drawing.Color.Gainsboro;
            this.btnFundingPrograms.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnFundingPrograms.IconSize = 35;
            this.btnFundingPrograms.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFundingPrograms.Location = new System.Drawing.Point(0, 195);
            this.btnFundingPrograms.Name = "btnFundingPrograms";
            this.btnFundingPrograms.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnFundingPrograms.Size = new System.Drawing.Size(300, 60);
            this.btnFundingPrograms.TabIndex = 8;
            this.btnFundingPrograms.Text = " Funding Programs";
            this.btnFundingPrograms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFundingPrograms.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFundingPrograms.UseVisualStyleBackColor = false;
            // 
            // btnStartupEvents
            // 
            this.btnStartupEvents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.btnStartupEvents.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStartupEvents.FlatAppearance.BorderSize = 0;
            this.btnStartupEvents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartupEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartupEvents.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnStartupEvents.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            this.btnStartupEvents.IconColor = System.Drawing.Color.Gainsboro;
            this.btnStartupEvents.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnStartupEvents.IconSize = 35;
            this.btnStartupEvents.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartupEvents.Location = new System.Drawing.Point(0, 135);
            this.btnStartupEvents.Name = "btnStartupEvents";
            this.btnStartupEvents.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnStartupEvents.Size = new System.Drawing.Size(300, 60);
            this.btnStartupEvents.TabIndex = 7;
            this.btnStartupEvents.Text = " Startup Events";
            this.btnStartupEvents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartupEvents.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStartupEvents.UseVisualStyleBackColor = false;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(36)))), ((int)(((byte)(81)))));
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnHome.IconChar = FontAwesome.Sharp.IconChar.House;
            this.btnHome.IconColor = System.Drawing.Color.Gainsboro;
            this.btnHome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnHome.IconSize = 35;
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(0, 75);
            this.btnHome.Name = "btnHome";
            this.btnHome.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnHome.Size = new System.Drawing.Size(300, 60);
            this.btnHome.TabIndex = 6;
            this.btnHome.Text = " Home";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHome.UseVisualStyleBackColor = false;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panelLogo.Controls.Add(this.label1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(300, 75);
            this.panelLogo.TabIndex = 0;
            this.panelLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseClickStart);
            this.panelLogo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMovement);
            this.panelLogo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseClickEnd);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Aquamarine;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Startup Hub";
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.panelTitle.Controls.Add(this.btnMaximize);
            this.panelTitle.Controls.Add(this.btnMinimize);
            this.panelTitle.Controls.Add(this.btnClose);
            this.panelTitle.Controls.Add(this.lblTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(300, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(1204, 75);
            this.panelTitle.TabIndex = 1;
            this.panelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseClickStart);
            this.panelTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMovement);
            this.panelTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseClickEnd);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnMaximize.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.btnMaximize.IconColor = System.Drawing.Color.Gainsboro;
            this.btnMaximize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMaximize.IconSize = 20;
            this.btnMaximize.Location = new System.Drawing.Point(1109, 0);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(47, 45);
            this.btnMaximize.TabIndex = 3;
            this.btnMaximize.UseVisualStyleBackColor = true;
            this.btnMaximize.Click += new System.EventHandler(this.MaximizeButtonClick);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnMinimize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.btnMinimize.IconColor = System.Drawing.Color.Gainsboro;
            this.btnMinimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMinimize.IconSize = 20;
            this.btnMinimize.Location = new System.Drawing.Point(1056, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(47, 45);
            this.btnMinimize.TabIndex = 2;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.MinimizeButtonClick);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btnClose.IconColor = System.Drawing.Color.Gainsboro;
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClose.IconSize = 23;
            this.btnClose.Location = new System.Drawing.Point(1157, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(47, 45);
            this.btnClose.TabIndex = 1;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.ExitButtonClick);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.lblTitle.Location = new System.Drawing.Point(450, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(305, 66);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "home";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(300, 75);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1204, 726);
            this.panelMain.TabIndex = 2;
            this.panelMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseClickStart);
            this.panelMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMovement);
            this.panelMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseClickEnd);
            // 
            // btnYourStartup
            // 
            this.btnYourStartup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.btnYourStartup.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnYourStartup.FlatAppearance.BorderSize = 0;
            this.btnYourStartup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYourStartup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYourStartup.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnYourStartup.IconChar = FontAwesome.Sharp.IconChar.UserAstronaut;
            this.btnYourStartup.IconColor = System.Drawing.Color.Gainsboro;
            this.btnYourStartup.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnYourStartup.IconSize = 35;
            this.btnYourStartup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnYourStartup.Location = new System.Drawing.Point(0, 255);
            this.btnYourStartup.Name = "btnYourStartup";
            this.btnYourStartup.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnYourStartup.Size = new System.Drawing.Size(300, 60);
            this.btnYourStartup.TabIndex = 9;
            this.btnYourStartup.Text = " Your Startup";
            this.btnYourStartup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnYourStartup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnYourStartup.UseVisualStyleBackColor = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1504, 801);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Startup Hub";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelMain;
        private FontAwesome.Sharp.IconButton btnHome;
        private FontAwesome.Sharp.IconButton btnFundingPrograms;
        private FontAwesome.Sharp.IconButton btnStartupEvents;
        private FontAwesome.Sharp.IconButton btnClose;
        private FontAwesome.Sharp.IconButton btnMaximize;
        private FontAwesome.Sharp.IconButton btnMinimize;
        private FontAwesome.Sharp.IconButton btnYourStartup;
    }
}
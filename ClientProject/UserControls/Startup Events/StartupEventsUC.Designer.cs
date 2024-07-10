namespace ClientProject.UserControls
{
    partial class StartupEventsUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSwitch = new FontAwesome.Sharp.IconButton();
            this.btnBack = new FontAwesome.Sharp.IconButton();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Aquamarine;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(542, 66);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "   Available Startup Events";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSwitch);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1204, 66);
            this.panel1.TabIndex = 3;
            // 
            // btnSwitch
            // 
            this.btnSwitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.btnSwitch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSwitch.FlatAppearance.BorderSize = 0;
            this.btnSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwitch.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSwitch.IconChar = FontAwesome.Sharp.IconChar.Table;
            this.btnSwitch.IconColor = System.Drawing.Color.Gainsboro;
            this.btnSwitch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSwitch.IconSize = 35;
            this.btnSwitch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSwitch.Location = new System.Drawing.Point(661, 0);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSwitch.Size = new System.Drawing.Size(352, 66);
            this.btnSwitch.TabIndex = 12;
            this.btnSwitch.Text = " Switch to User Panel";
            this.btnSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSwitch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSwitch.UseVisualStyleBackColor = false;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnBack.IconChar = FontAwesome.Sharp.IconChar.RotateBackward;
            this.btnBack.IconColor = System.Drawing.Color.Gainsboro;
            this.btnBack.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBack.IconSize = 35;
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBack.Location = new System.Drawing.Point(1013, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnBack.Size = new System.Drawing.Size(191, 66);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = " Go Back";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBack.UseVisualStyleBackColor = false;
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 66);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1204, 660);
            this.panelMain.TabIndex = 4;
            // 
            // StartupEventsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panel1);
            this.Name = "StartupEventsUC";
            this.Size = new System.Drawing.Size(1204, 726);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelMain;
        private FontAwesome.Sharp.IconButton btnSwitch;
        private FontAwesome.Sharp.IconButton btnBack;
    }
}

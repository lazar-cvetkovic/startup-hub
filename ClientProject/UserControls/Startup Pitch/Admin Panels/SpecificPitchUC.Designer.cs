namespace ClientProject.UserControls.Startup_Pitch.Admin_Panels
{
    partial class SpecificPitchUC
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
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnDownloadPitch = new FontAwesome.Sharp.IconButton();
            this.lblName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.txtFeedback = new System.Windows.Forms.RichTextBox();
            this.btnSendFeedback = new FontAwesome.Sharp.IconButton();
            this.BtnPlayGame = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblDescription.Location = new System.Drawing.Point(18, 155);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(1168, 193);
            this.lblDescription.TabIndex = 25;
            this.lblDescription.Text = "Description of the startup";
            // 
            // btnDownloadPitch
            // 
            this.btnDownloadPitch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDownloadPitch.BackColor = System.Drawing.Color.DarkGray;
            this.btnDownloadPitch.FlatAppearance.BorderSize = 0;
            this.btnDownloadPitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownloadPitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownloadPitch.ForeColor = System.Drawing.Color.Black;
            this.btnDownloadPitch.IconChar = FontAwesome.Sharp.IconChar.FileDownload;
            this.btnDownloadPitch.IconColor = System.Drawing.Color.Black;
            this.btnDownloadPitch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDownloadPitch.IconSize = 35;
            this.btnDownloadPitch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDownloadPitch.Location = new System.Drawing.Point(18, 579);
            this.btnDownloadPitch.Name = "btnDownloadPitch";
            this.btnDownloadPitch.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnDownloadPitch.Size = new System.Drawing.Size(256, 55);
            this.btnDownloadPitch.TabIndex = 24;
            this.btnDownloadPitch.Text = "Download Pitch";
            this.btnDownloadPitch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDownloadPitch.UseVisualStyleBackColor = false;
            this.btnDownloadPitch.Click += new System.EventHandler(this.HandleDownloadButtonClick);
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblName.Location = new System.Drawing.Point(-1, 85);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(1204, 46);
            this.lblName.TabIndex = 22;
            this.lblName.Text = "Name of the startup";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(18, 361);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1168, 30);
            this.label1.TabIndex = 26;
            this.label1.Text = "Feedback";
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.iconPictureBox1.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.UserAstronaut;
            this.iconPictureBox1.IconColor = System.Drawing.Color.Gainsboro;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 63;
            this.iconPictureBox1.Location = new System.Drawing.Point(571, 15);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(63, 67);
            this.iconPictureBox1.TabIndex = 27;
            this.iconPictureBox1.TabStop = false;
            // 
            // txtFeedback
            // 
            this.txtFeedback.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFeedback.BackColor = System.Drawing.Color.Gainsboro;
            this.txtFeedback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFeedback.Location = new System.Drawing.Point(18, 394);
            this.txtFeedback.Name = "txtFeedback";
            this.txtFeedback.Size = new System.Drawing.Size(1168, 149);
            this.txtFeedback.TabIndex = 40;
            this.txtFeedback.Text = "";
            // 
            // btnSendFeedback
            // 
            this.btnSendFeedback.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSendFeedback.BackColor = System.Drawing.Color.Aquamarine;
            this.btnSendFeedback.FlatAppearance.BorderSize = 0;
            this.btnSendFeedback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendFeedback.ForeColor = System.Drawing.Color.Black;
            this.btnSendFeedback.IconChar = FontAwesome.Sharp.IconChar.FileArrowUp;
            this.btnSendFeedback.IconColor = System.Drawing.Color.Black;
            this.btnSendFeedback.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSendFeedback.IconSize = 35;
            this.btnSendFeedback.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSendFeedback.Location = new System.Drawing.Point(928, 579);
            this.btnSendFeedback.Name = "btnSendFeedback";
            this.btnSendFeedback.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSendFeedback.Size = new System.Drawing.Size(258, 55);
            this.btnSendFeedback.TabIndex = 41;
            this.btnSendFeedback.Text = "Send Feedback";
            this.btnSendFeedback.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSendFeedback.UseVisualStyleBackColor = false;
            // 
            // BtnPlayGame
            // 
            this.BtnPlayGame.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnPlayGame.BackColor = System.Drawing.Color.MediumPurple;
            this.BtnPlayGame.FlatAppearance.BorderSize = 0;
            this.BtnPlayGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPlayGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPlayGame.ForeColor = System.Drawing.Color.Black;
            this.BtnPlayGame.IconChar = FontAwesome.Sharp.IconChar.Gamepad;
            this.BtnPlayGame.IconColor = System.Drawing.Color.Black;
            this.BtnPlayGame.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnPlayGame.IconSize = 35;
            this.BtnPlayGame.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnPlayGame.Location = new System.Drawing.Point(300, 579);
            this.BtnPlayGame.Name = "BtnPlayGame";
            this.BtnPlayGame.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnPlayGame.Size = new System.Drawing.Size(179, 55);
            this.BtnPlayGame.TabIndex = 42;
            this.BtnPlayGame.Text = "Play Game";
            this.BtnPlayGame.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnPlayGame.UseVisualStyleBackColor = false;
            this.BtnPlayGame.Click += new System.EventHandler(this.HandlePlayGameClick);
            // 
            // SpecificPitchUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.Controls.Add(this.BtnPlayGame);
            this.Controls.Add(this.btnSendFeedback);
            this.Controls.Add(this.txtFeedback);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnDownloadPitch);
            this.Controls.Add(this.lblName);
            this.Name = "SpecificPitchUC";
            this.Size = new System.Drawing.Size(1203, 660);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDescription;
        private FontAwesome.Sharp.IconButton btnDownloadPitch;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.RichTextBox txtFeedback;
        private FontAwesome.Sharp.IconButton btnSendFeedback;
        private FontAwesome.Sharp.IconButton BtnPlayGame;
    }
}

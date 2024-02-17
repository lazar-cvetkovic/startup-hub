namespace ClientProject.UserControls.Funding_Programs
{
    partial class FundingProgramPreviewUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FundingProgramPreviewUC));
            this.lblDate = new System.Windows.Forms.Label();
            this.lblProgramName = new System.Windows.Forms.Label();
            this.btnReadMore = new FontAwesome.Sharp.IconButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblAmount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDate.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.lblDate.Font = new System.Drawing.Font("Manrope ExtraLight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblDate.Location = new System.Drawing.Point(14, 88);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(203, 54);
            this.lblDate.TabIndex = 9;
            this.lblDate.Text = "12.12.2024. - 03:00 PM";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProgramName
            // 
            this.lblProgramName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblProgramName.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.lblProgramName.Font = new System.Drawing.Font("Manrope ExtraLight", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgramName.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblProgramName.Location = new System.Drawing.Point(13, 34);
            this.lblProgramName.Name = "lblProgramName";
            this.lblProgramName.Size = new System.Drawing.Size(203, 54);
            this.lblProgramName.TabIndex = 8;
            this.lblProgramName.Text = "Name of the funding program";
            this.lblProgramName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReadMore
            // 
            this.btnReadMore.BackColor = System.Drawing.Color.Gainsboro;
            this.btnReadMore.FlatAppearance.BorderSize = 0;
            this.btnReadMore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReadMore.Font = new System.Drawing.Font("Manrope ExtraLight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadMore.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnReadMore.IconColor = System.Drawing.Color.Black;
            this.btnReadMore.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReadMore.IconSize = 25;
            this.btnReadMore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReadMore.Location = new System.Drawing.Point(24, 235);
            this.btnReadMore.Name = "btnReadMore";
            this.btnReadMore.Size = new System.Drawing.Size(179, 37);
            this.btnReadMore.TabIndex = 10;
            this.btnReadMore.Text = "Read More";
            this.btnReadMore.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(230, 307);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // lblAmount
            // 
            this.lblAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAmount.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.lblAmount.Font = new System.Drawing.Font("Manrope ExtraLight", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.ForeColor = System.Drawing.Color.Aquamarine;
            this.lblAmount.Location = new System.Drawing.Point(14, 142);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(203, 54);
            this.lblAmount.TabIndex = 11;
            this.lblAmount.Text = "$120,000.00";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FundingProgramPreviewUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.btnReadMore);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblProgramName);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FundingProgramPreviewUC";
            this.Size = new System.Drawing.Size(230, 307);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnReadMore;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblProgramName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblAmount;
    }
}

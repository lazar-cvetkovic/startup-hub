namespace ClientProject.UserControls
{
    partial class EventPreviewUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventPreviewUC));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnReadMore = new FontAwesome.Sharp.IconButton();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblEventName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(230, 307);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnReadMore
            // 
            this.btnReadMore.BackColor = System.Drawing.Color.Gainsboro;
            this.btnReadMore.FlatAppearance.BorderSize = 0;
            this.btnReadMore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReadMore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadMore.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnReadMore.IconColor = System.Drawing.Color.Black;
            this.btnReadMore.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReadMore.IconSize = 25;
            this.btnReadMore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReadMore.Location = new System.Drawing.Point(24, 235);
            this.btnReadMore.Name = "btnReadMore";
            this.btnReadMore.Size = new System.Drawing.Size(179, 37);
            this.btnReadMore.TabIndex = 6;
            this.btnReadMore.Text = "Read More";
            this.btnReadMore.UseVisualStyleBackColor = false;
            // 
            // lblDate
            // 
            this.lblDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDate.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblDate.Location = new System.Drawing.Point(14, 88);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(203, 54);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "12.12.2024. - 03:00 PM";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEventName
            // 
            this.lblEventName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEventName.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.lblEventName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventName.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblEventName.Location = new System.Drawing.Point(13, 25);
            this.lblEventName.Name = "lblEventName";
            this.lblEventName.Size = new System.Drawing.Size(203, 63);
            this.lblEventName.TabIndex = 4;
            this.lblEventName.Text = "Name of the startup event";
            this.lblEventName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EventPreviewUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.Controls.Add(this.btnReadMore);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblEventName);
            this.Controls.Add(this.pictureBox1);
            this.Name = "EventPreviewUC";
            this.Size = new System.Drawing.Size(230, 307);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton btnReadMore;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblEventName;
    }
}

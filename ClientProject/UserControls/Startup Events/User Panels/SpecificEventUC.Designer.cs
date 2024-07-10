namespace ClientProject.UserControls
{
    partial class SpecificEventUC
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
            this.lblDate = new System.Windows.Forms.Label();
            this.lblPlace = new System.Windows.Forms.Label();
            this.lblEventName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnCreateEdit = new FontAwesome.Sharp.IconButton();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblDate.Location = new System.Drawing.Point(-1, 157);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(1204, 31);
            this.lblDate.TabIndex = 18;
            this.lblDate.Text = "12.12.2024. - 03:00 PM";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlace
            // 
            this.lblPlace.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPlace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.lblPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlace.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblPlace.Location = new System.Drawing.Point(2, 111);
            this.lblPlace.Name = "lblPlace";
            this.lblPlace.Size = new System.Drawing.Size(1204, 46);
            this.lblPlace.TabIndex = 17;
            this.lblPlace.Text = "Belgrade, Serbia";
            this.lblPlace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEventName
            // 
            this.lblEventName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEventName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.lblEventName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventName.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblEventName.Location = new System.Drawing.Point(-1, 65);
            this.lblEventName.Name = "lblEventName";
            this.lblEventName.Size = new System.Drawing.Size(1204, 46);
            this.lblEventName.TabIndex = 14;
            this.lblEventName.Text = "Name of the startup event";
            this.lblEventName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblDescription.Location = new System.Drawing.Point(0, 259);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(1204, 252);
            this.lblDescription.TabIndex = 21;
            this.lblDescription.Text = "Description of the startup event";
            // 
            // btnCreateEdit
            // 
            this.btnCreateEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCreateEdit.BackColor = System.Drawing.Color.Aquamarine;
            this.btnCreateEdit.FlatAppearance.BorderSize = 0;
            this.btnCreateEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateEdit.ForeColor = System.Drawing.Color.Black;
            this.btnCreateEdit.IconChar = FontAwesome.Sharp.IconChar.FileEdit;
            this.btnCreateEdit.IconColor = System.Drawing.Color.Black;
            this.btnCreateEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCreateEdit.IconSize = 35;
            this.btnCreateEdit.Location = new System.Drawing.Point(414, 547);
            this.btnCreateEdit.Name = "btnCreateEdit";
            this.btnCreateEdit.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnCreateEdit.Size = new System.Drawing.Size(367, 55);
            this.btnCreateEdit.TabIndex = 20;
            this.btnCreateEdit.Text = "Create Event Registration";
            this.btnCreateEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreateEdit.UseVisualStyleBackColor = false;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.iconPictureBox1.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.UsersLine;
            this.iconPictureBox1.IconColor = System.Drawing.Color.Gainsboro;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 63;
            this.iconPictureBox1.Location = new System.Drawing.Point(571, 14);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(63, 67);
            this.iconPictureBox1.TabIndex = 16;
            this.iconPictureBox1.TabStop = false;
            // 
            // SpecificEventUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnCreateEdit);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblPlace);
            this.Controls.Add(this.lblEventName);
            this.Controls.Add(this.iconPictureBox1);
            this.Name = "SpecificEventUC";
            this.Size = new System.Drawing.Size(1204, 660);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblPlace;
        private System.Windows.Forms.Label lblEventName;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconButton btnCreateEdit;
        private System.Windows.Forms.Label lblDescription;
    }
}

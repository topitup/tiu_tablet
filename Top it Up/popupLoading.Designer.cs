namespace TopitUp
{
    partial class popupLoading
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
            this.lbl_subtext = new System.Windows.Forms.Label();
            this.lblCaption = new System.Windows.Forms.Label();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.btn_popup_close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_subtext
            // 
            this.lbl_subtext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(121)))), ((int)(((byte)(196)))));
            this.lbl_subtext.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lbl_subtext.ForeColor = System.Drawing.Color.White;
            this.lbl_subtext.Location = new System.Drawing.Point(162, 86);
            this.lbl_subtext.Name = "lbl_subtext";
            this.lbl_subtext.Size = new System.Drawing.Size(386, 44);
            this.lbl_subtext.TabIndex = 3;
            this.lbl_subtext.Text = "...";
            this.lbl_subtext.Visible = false;
            // 
            // lblCaption
            // 
            this.lblCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(121)))), ((int)(((byte)(196)))));
            this.lblCaption.Font = new System.Drawing.Font("Tahoma", 14F);
            this.lblCaption.ForeColor = System.Drawing.Color.White;
            this.lblCaption.Location = new System.Drawing.Point(160, 42);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(386, 44);
            this.lblCaption.TabIndex = 5;
            this.lblCaption.Text = "Busy, Please wait...";
            // 
            // picIcon
            // 
            this.picIcon.Location = new System.Drawing.Point(46, 45);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(64, 64);
            this.picIcon.TabIndex = 4;
            this.picIcon.TabStop = false;
            // 
            // btn_popup_close
            // 
            this.btn_popup_close.BackColor = System.Drawing.Color.White;
            this.btn_popup_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_popup_close.Location = new System.Drawing.Point(607, 41);
            this.btn_popup_close.Name = "btn_popup_close";
            this.btn_popup_close.Size = new System.Drawing.Size(162, 77);
            this.btn_popup_close.TabIndex = 6;
            this.btn_popup_close.Text = "CLOSE";
            this.btn_popup_close.UseVisualStyleBackColor = false;
            // 
            // popupLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(121)))), ((int)(((byte)(196)))));
            this.ClientSize = new System.Drawing.Size(810, 159);
            this.Controls.Add(this.btn_popup_close);
            this.Controls.Add(this.lbl_subtext);
            this.Controls.Add(this.picIcon);
            this.Controls.Add(this.lblCaption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "popupLoading";
            this.Text = "popupLoading";
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_subtext;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Button btn_popup_close;
    }
}
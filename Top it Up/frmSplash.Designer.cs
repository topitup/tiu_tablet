namespace TopitUp
{
    partial class frmSplash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSplash));
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.picLoading = new System.Windows.Forms.PictureBox();
            this.lblContact = new System.Windows.Forms.Label();
            this.rchTopItUpProperty = new System.Windows.Forms.RichTextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCover = new TopitUp.TransparentLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // picLoader
            // 
            this.picLoader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picLoader.Image = ((System.Drawing.Image)(resources.GetObject("picLoader.Image")));
            this.picLoader.Location = new System.Drawing.Point(494, 209);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(64, 64);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picLoader.TabIndex = 2;
            this.picLoader.TabStop = false;
            // 
            // picLoading
            // 
            this.picLoading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picLoading.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picLoading.BackgroundImage")));
            this.picLoading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLoading.Location = new System.Drawing.Point(427, 131);
            this.picLoading.Name = "picLoading";
            this.picLoading.Size = new System.Drawing.Size(200, 50);
            this.picLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picLoading.TabIndex = 1;
            this.picLoading.TabStop = false;
            // 
            // lblContact
            // 
            this.lblContact.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblContact.AutoSize = true;
            this.lblContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContact.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblContact.Location = new System.Drawing.Point(405, 613);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(248, 42);
            this.lblContact.TabIndex = 3;
            this.lblContact.Text = "086 011 1723";
            // 
            // rchTopItUpProperty
            // 
            this.rchTopItUpProperty.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rchTopItUpProperty.BackColor = System.Drawing.Color.Black;
            this.rchTopItUpProperty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rchTopItUpProperty.Location = new System.Drawing.Point(103, 370);
            this.rchTopItUpProperty.Name = "rchTopItUpProperty";
            this.rchTopItUpProperty.ReadOnly = true;
            this.rchTopItUpProperty.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rchTopItUpProperty.Size = new System.Drawing.Size(847, 224);
            this.rchTopItUpProperty.TabIndex = 4;
            this.rchTopItUpProperty.TabStop = false;
            this.rchTopItUpProperty.Text = "";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblStatus.ForeColor = System.Drawing.Color.Silver;
            this.lblStatus.Location = new System.Drawing.Point(12, 28);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(1038, 23);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Starting up...";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCover
            // 
            this.lblCover.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCover.Location = new System.Drawing.Point(103, 370);
            this.lblCover.Name = "lblCover";
            this.lblCover.Size = new System.Drawing.Size(847, 224);
            this.lblCover.TabIndex = 6;
            // 
            // frmSplash
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1062, 690);
            this.ControlBox = false;
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblCover);
            this.Controls.Add(this.rchTopItUpProperty);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.picLoading);
            this.Controls.Add(this.picLoader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSplash";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading...";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picLoader;
        private System.Windows.Forms.PictureBox picLoading;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.RichTextBox rchTopItUpProperty;
        private TransparentLabel lblCover;
        private System.Windows.Forms.Label lblStatus;

    }
}
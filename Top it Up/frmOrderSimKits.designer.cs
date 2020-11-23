namespace TopitUp
{
    partial class frmOrderSimKits
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderSimKits));
            this.pnlKeyboard = new System.Windows.Forms.Panel();
            this.virtualKeyboard1 = new TopitUp.virtualKeyboard();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlFooterRHS = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.pnlFooterLogedin = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblComplete = new System.Windows.Forms.Label();
            this.pnlWrapper = new System.Windows.Forms.Panel();
            this.option1 = new TopitUp.TransparentLabel();
            this.option0 = new TopitUp.TransparentLabel();
            this.option1pic = new System.Windows.Forms.PictureBox();
            this.option0pic = new System.Windows.Forms.PictureBox();
            this.txtProvider1 = new System.Windows.Forms.TextBox();
            this.txtProvider10 = new System.Windows.Forms.TextBox();
            this.txtProvider2 = new System.Windows.Forms.TextBox();
            this.txtProvider3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblOption0 = new System.Windows.Forms.Label();
            this.lblOption1 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlKeyboard.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlFooterRHS.SuspendLayout();
            this.pnlFooterLogedin.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlWrapper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.option1pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.option0pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlKeyboard
            // 
            this.pnlKeyboard.Controls.Add(this.virtualKeyboard1);
            this.pnlKeyboard.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlKeyboard.Location = new System.Drawing.Point(880, 0);
            this.pnlKeyboard.Name = "pnlKeyboard";
            this.pnlKeyboard.Size = new System.Drawing.Size(400, 800);
            this.pnlKeyboard.TabIndex = 49;
            this.pnlKeyboard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlKeyboard_Paint);
            // 
            // virtualKeyboard1
            // 
            this.virtualKeyboard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.virtualKeyboard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.virtualKeyboard1.Location = new System.Drawing.Point(0, 0);
            this.virtualKeyboard1.Name = "virtualKeyboard1";
            this.virtualKeyboard1.Size = new System.Drawing.Size(400, 800);
            this.virtualKeyboard1.TabIndex = 0;
            this.virtualKeyboard1.TabStop = false;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.pnlFooter.Controls.Add(this.pnlFooterRHS);
            this.pnlFooter.Controls.Add(this.pnlFooterLogedin);
            this.pnlFooter.Controls.Add(this.btnAbout);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 710);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(880, 90);
            this.pnlFooter.TabIndex = 92;
            // 
            // pnlFooterRHS
            // 
            this.pnlFooterRHS.Controls.Add(this.btnOK);
            this.pnlFooterRHS.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFooterRHS.Location = new System.Drawing.Point(380, 0);
            this.pnlFooterRHS.Name = "pnlFooterRHS";
            this.pnlFooterRHS.Size = new System.Drawing.Size(500, 90);
            this.pnlFooterRHS.TabIndex = 37;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Tahoma", 20F);
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(249, 1);
            this.btnOK.Name = "btnOK";
            this.btnOK.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnOK.Size = new System.Drawing.Size(250, 89);
            this.btnOK.TabIndex = 41;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "Confirm";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlFooterLogedin
            // 
            this.pnlFooterLogedin.Controls.Add(this.btnClose);
            this.pnlFooterLogedin.Location = new System.Drawing.Point(0, 1);
            this.pnlFooterLogedin.Name = "pnlFooterLogedin";
            this.pnlFooterLogedin.Size = new System.Drawing.Size(539, 90);
            this.pnlFooterLogedin.TabIndex = 38;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 20F);
            this.btnClose.ForeColor = System.Drawing.Color.Maroon;
            this.btnClose.Image = global::TopitUp.Properties.Resources.btnClose;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(0, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.btnClose.Size = new System.Drawing.Size(250, 89);
            this.btnClose.TabIndex = 16;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.BackColor = System.Drawing.Color.White;
            this.btnAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(13)))), ((int)(((byte)(3)))));
            this.btnAbout.Location = new System.Drawing.Point(950, 1);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(140, 60);
            this.btnAbout.TabIndex = 36;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = false;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.lblComplete);
            this.pnlMain.Controls.Add(this.pnlWrapper);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(880, 710);
            this.pnlMain.TabIndex = 93;
            // 
            // lblComplete
            // 
            this.lblComplete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblComplete.AutoSize = true;
            this.lblComplete.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComplete.ForeColor = System.Drawing.Color.Maroon;
            this.lblComplete.Location = new System.Drawing.Point(253, 300);
            this.lblComplete.Name = "lblComplete";
            this.lblComplete.Size = new System.Drawing.Size(343, 35);
            this.lblComplete.TabIndex = 15;
            this.lblComplete.Text = "Thank you for your order!";
            this.lblComplete.Visible = false;
            // 
            // pnlWrapper
            // 
            this.pnlWrapper.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlWrapper.Controls.Add(this.option1);
            this.pnlWrapper.Controls.Add(this.option0);
            this.pnlWrapper.Controls.Add(this.option1pic);
            this.pnlWrapper.Controls.Add(this.option0pic);
            this.pnlWrapper.Controls.Add(this.txtProvider1);
            this.pnlWrapper.Controls.Add(this.txtProvider10);
            this.pnlWrapper.Controls.Add(this.txtProvider2);
            this.pnlWrapper.Controls.Add(this.txtProvider3);
            this.pnlWrapper.Controls.Add(this.label3);
            this.pnlWrapper.Controls.Add(this.lblOption0);
            this.pnlWrapper.Controls.Add(this.lblOption1);
            this.pnlWrapper.Controls.Add(this.pictureBox4);
            this.pnlWrapper.Controls.Add(this.pictureBox3);
            this.pnlWrapper.Controls.Add(this.pictureBox2);
            this.pnlWrapper.Controls.Add(this.pictureBox1);
            this.pnlWrapper.Location = new System.Drawing.Point(21, 83);
            this.pnlWrapper.Name = "pnlWrapper";
            this.pnlWrapper.Size = new System.Drawing.Size(839, 545);
            this.pnlWrapper.TabIndex = 14;
            // 
            // option1
            // 
            this.option1.Location = new System.Drawing.Point(12, 169);
            this.option1.Name = "option1";
            this.option1.Size = new System.Drawing.Size(806, 165);
            this.option1.TabIndex = 14;
            this.option1.Click += new System.EventHandler(this.option1_Click);
            // 
            // option0
            // 
            this.option0.Location = new System.Drawing.Point(14, 10);
            this.option0.Name = "option0";
            this.option0.Size = new System.Drawing.Size(537, 152);
            this.option0.TabIndex = 13;
            this.option0.Click += new System.EventHandler(this.option0_Click);
            // 
            // option1pic
            // 
            this.option1pic.Image = global::TopitUp.Properties.Resources.option0;
            this.option1pic.Location = new System.Drawing.Point(21, 183);
            this.option1pic.Name = "option1pic";
            this.option1pic.Size = new System.Drawing.Size(29, 29);
            this.option1pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.option1pic.TabIndex = 12;
            this.option1pic.TabStop = false;
            // 
            // option0pic
            // 
            this.option0pic.Image = global::TopitUp.Properties.Resources.option1;
            this.option0pic.Location = new System.Drawing.Point(21, 25);
            this.option0pic.Name = "option0pic";
            this.option0pic.Size = new System.Drawing.Size(29, 29);
            this.option0pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.option0pic.TabIndex = 11;
            this.option0pic.TabStop = false;
            // 
            // txtProvider1
            // 
            this.txtProvider1.Enabled = false;
            this.txtProvider1.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProvider1.ForeColor = System.Drawing.Color.Maroon;
            this.txtProvider1.Location = new System.Drawing.Point(638, 340);
            this.txtProvider1.MaxLength = 3;
            this.txtProvider1.Name = "txtProvider1";
            this.txtProvider1.Size = new System.Drawing.Size(180, 50);
            this.txtProvider1.TabIndex = 10;
            this.txtProvider1.Text = "0";
            this.txtProvider1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtProvider1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.digitsOnly_KeyPress);
            // 
            // txtProvider10
            // 
            this.txtProvider10.Enabled = false;
            this.txtProvider10.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProvider10.ForeColor = System.Drawing.Color.Maroon;
            this.txtProvider10.Location = new System.Drawing.Point(431, 340);
            this.txtProvider10.MaxLength = 3;
            this.txtProvider10.Name = "txtProvider10";
            this.txtProvider10.Size = new System.Drawing.Size(180, 50);
            this.txtProvider10.TabIndex = 9;
            this.txtProvider10.Text = "0";
            this.txtProvider10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtProvider10.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.digitsOnly_KeyPress);
            // 
            // txtProvider2
            // 
            this.txtProvider2.Enabled = false;
            this.txtProvider2.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProvider2.ForeColor = System.Drawing.Color.Maroon;
            this.txtProvider2.Location = new System.Drawing.Point(223, 340);
            this.txtProvider2.MaxLength = 3;
            this.txtProvider2.Name = "txtProvider2";
            this.txtProvider2.Size = new System.Drawing.Size(180, 50);
            this.txtProvider2.TabIndex = 8;
            this.txtProvider2.Text = "0";
            this.txtProvider2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtProvider2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.digitsOnly_KeyPress);
            // 
            // txtProvider3
            // 
            this.txtProvider3.Enabled = false;
            this.txtProvider3.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProvider3.ForeColor = System.Drawing.Color.Maroon;
            this.txtProvider3.Location = new System.Drawing.Point(15, 340);
            this.txtProvider3.MaxLength = 3;
            this.txtProvider3.Name = "txtProvider3";
            this.txtProvider3.Size = new System.Drawing.Size(180, 50);
            this.txtProvider3.TabIndex = 7;
            this.txtProvider3.Text = "0";
            this.txtProvider3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtProvider3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.digitsOnly_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(69, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 75);
            this.label3.TabIndex = 6;
            this.label3.Text = "3x Cell C\r\n4x MTN\r\n3x Vodacom";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOption0
            // 
            this.lblOption0.AutoSize = true;
            this.lblOption0.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOption0.ForeColor = System.Drawing.Color.Maroon;
            this.lblOption0.Location = new System.Drawing.Point(65, 27);
            this.lblOption0.Name = "lblOption0";
            this.lblOption0.Size = new System.Drawing.Size(181, 25);
            this.lblOption0.TabIndex = 5;
            this.lblOption0.Text = "Standard Package";
            this.lblOption0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOption1
            // 
            this.lblOption1.AutoSize = true;
            this.lblOption1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOption1.ForeColor = System.Drawing.Color.Gray;
            this.lblOption1.Location = new System.Drawing.Point(65, 185);
            this.lblOption1.Name = "lblOption1";
            this.lblOption1.Size = new System.Drawing.Size(205, 25);
            this.lblOption1.TabIndex = 4;
            this.lblOption1.Text = "Individual Quantities";
            this.lblOption1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(638, 234);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(180, 100);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(431, 234);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(180, 100);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(223, 234);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(180, 100);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 234);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmOrderSimKits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlKeyboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frmOrderSimKits";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "frmBillPayments";
            this.Load += new System.EventHandler(this.frmOrderSimKits_Load);
            this.pnlKeyboard.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooterRHS.ResumeLayout(false);
            this.pnlFooterLogedin.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlWrapper.ResumeLayout(false);
            this.pnlWrapper.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.option1pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.option0pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlKeyboard;
        private virtualKeyboard virtualKeyboard1;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlFooterLogedin;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlFooterRHS;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlWrapper;
        private System.Windows.Forms.TextBox txtProvider1;
        private System.Windows.Forms.TextBox txtProvider10;
        private System.Windows.Forms.TextBox txtProvider2;
        private System.Windows.Forms.TextBox txtProvider3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblOption0;
        private System.Windows.Forms.Label lblOption1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox option1pic;
        private System.Windows.Forms.PictureBox option0pic;
        private TransparentLabel option1;
        private TransparentLabel option0;
        private System.Windows.Forms.Label lblComplete;
    }
}
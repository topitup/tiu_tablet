namespace TopitUp
{
    partial class frmNoPrinter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNoPrinter));
            this.pnlAdmin = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnReprint = new System.Windows.Forms.Button();
            this.lblHeader2 = new System.Windows.Forms.Label();
            this.lblDetail = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCashDrawer = new System.Windows.Forms.Label();
            this.picPrinter = new System.Windows.Forms.PictureBox();
            this.pnlAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPrinter)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlAdmin
            // 
            this.pnlAdmin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlAdmin.BackColor = System.Drawing.Color.White;
            this.pnlAdmin.Controls.Add(this.lblCashDrawer);
            this.pnlAdmin.Controls.Add(this.btnCancel);
            this.pnlAdmin.Controls.Add(this.btnReprint);
            this.pnlAdmin.Controls.Add(this.lblHeader2);
            this.pnlAdmin.Controls.Add(this.lblDetail);
            this.pnlAdmin.Controls.Add(this.label2);
            this.pnlAdmin.Controls.Add(this.label1);
            this.pnlAdmin.Controls.Add(this.picPrinter);
            this.pnlAdmin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlAdmin.Location = new System.Drawing.Point(130, 35);
            this.pnlAdmin.Name = "pnlAdmin";
            this.pnlAdmin.Size = new System.Drawing.Size(925, 414);
            this.pnlAdmin.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Maroon;
            this.btnCancel.FlatAppearance.BorderSize = 2;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(42, 295);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(250, 90);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReprint
            // 
            this.btnReprint.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReprint.BackColor = System.Drawing.Color.Green;
            this.btnReprint.FlatAppearance.BorderSize = 2;
            this.btnReprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReprint.ForeColor = System.Drawing.Color.White;
            this.btnReprint.Location = new System.Drawing.Point(495, 295);
            this.btnReprint.Name = "btnReprint";
            this.btnReprint.Size = new System.Drawing.Size(250, 91);
            this.btnReprint.TabIndex = 11;
            this.btnReprint.Text = "Re-Print";
            this.btnReprint.UseVisualStyleBackColor = false;
            this.btnReprint.Visible = false;
            this.btnReprint.Click += new System.EventHandler(this.btnReprint_Click);
            // 
            // lblHeader2
            // 
            this.lblHeader2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHeader2.AutoSize = true;
            this.lblHeader2.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader2.ForeColor = System.Drawing.Color.Maroon;
            this.lblHeader2.Location = new System.Drawing.Point(281, 22);
            this.lblHeader2.Name = "lblHeader2";
            this.lblHeader2.Size = new System.Drawing.Size(277, 45);
            this.lblHeader2.TabIndex = 10;
            this.lblHeader2.Text = "or out of paper!";
            // 
            // lblDetail
            // 
            this.lblDetail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDetail.AutoSize = true;
            this.lblDetail.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetail.ForeColor = System.Drawing.Color.Gray;
            this.lblDetail.Location = new System.Drawing.Point(47, 150);
            this.lblDetail.Name = "lblDetail";
            this.lblDetail.Size = new System.Drawing.Size(407, 92);
            this.lblDetail.TabIndex = 9;
            this.lblDetail.Text = "- Check the printer USB cable.\r\n- Check printer power.\r\n- If printer is connected" +
    ", turn off and on again.\r\n- Check that there is printer paper.";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(34, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(255, 45);
            this.label2.TabIndex = 8;
            this.label2.Text = "Printer Offline,";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(37, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(461, 58);
            this.label1.TabIndex = 7;
            this.label1.Text = "Please make sure the printer is connected\r\nand turned on before selling a voucher" +
    ".";
            // 
            // lblCashDrawer
            // 
            this.lblCashDrawer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCashDrawer.AutoSize = true;
            this.lblCashDrawer.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashDrawer.ForeColor = System.Drawing.Color.Maroon;
            this.lblCashDrawer.Location = new System.Drawing.Point(47, 244);
            this.lblCashDrawer.Name = "lblCashDrawer";
            this.lblCashDrawer.Size = new System.Drawing.Size(390, 23);
            this.lblCashDrawer.TabIndex = 12;
            this.lblCashDrawer.Text = "- NOTE: Cash drawer is connected to printer.";
            this.lblCashDrawer.Visible = false;
            // 
            // picPrinter
            // 
            this.picPrinter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picPrinter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picPrinter.BackgroundImage")));
            this.picPrinter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picPrinter.Image = global::TopitUp.Properties.Resources.printer_offline_probem;
            this.picPrinter.Location = new System.Drawing.Point(615, 31);
            this.picPrinter.Name = "picPrinter";
            this.picPrinter.Size = new System.Drawing.Size(267, 283);
            this.picPrinter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picPrinter.TabIndex = 6;
            this.picPrinter.TabStop = false;
            // 
            // frmNoPrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1125, 485);
            this.ControlBox = false;
            this.Controls.Add(this.pnlAdmin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNoPrinter";
            this.Opacity = 0.8D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "frmAirtime";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmNoPrinter_Load);
            this.VisibleChanged += new System.EventHandler(this.frmNoPrinter_VisibleChanged);
            this.pnlAdmin.ResumeLayout(false);
            this.pnlAdmin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPrinter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAdmin;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox picPrinter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDetail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblHeader2;
        private System.Windows.Forms.Button btnReprint;
        private System.Windows.Forms.Label lblCashDrawer;

    }
}
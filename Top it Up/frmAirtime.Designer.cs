namespace TopitUp
{
    partial class frmAirtime
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
            this.components = new System.ComponentModel.Container();
            this.pnlVoucherSale = new System.Windows.Forms.Panel();
            this.lblRetryAttempt = new System.Windows.Forms.Label();
            this.pnlMultiVoucher = new System.Windows.Forms.Panel();
            this.pnlMultiVoucherSide = new System.Windows.Forms.Panel();
            this.lblPnlMultiVoucherHeader = new System.Windows.Forms.Label();
            this.btnMulti9 = new System.Windows.Forms.Button();
            this.btnMulti8 = new System.Windows.Forms.Button();
            this.btnMulti7 = new System.Windows.Forms.Button();
            this.btnMulti6 = new System.Windows.Forms.Button();
            this.btnMulti5 = new System.Windows.Forms.Button();
            this.btnMulti4 = new System.Windows.Forms.Button();
            this.btnMulti3 = new System.Windows.Forms.Button();
            this.btnMulti2 = new System.Windows.Forms.Button();
            this.lblVoucherProcess = new System.Windows.Forms.Label();
            this.btnVoucherCancel = new System.Windows.Forms.Button();
            this.btnVoucherOK = new System.Windows.Forms.Button();
            this.lblVoucherDesc = new System.Windows.Forms.Label();
            this.lblVoucherNotice = new System.Windows.Forms.Label();
            this.tmr_delayed_load = new System.Windows.Forms.Timer(this.components);
            this.timer_voucher_retry = new System.Windows.Forms.Timer(this.components);
            this.pnlMultiPrint = new System.Windows.Forms.Panel();
            this.lbl_plnMultiTotalValue = new System.Windows.Forms.Label();
            this.lbl_plnMultiTotal = new System.Windows.Forms.Label();
            this.lstMultiVoucher = new System.Windows.Forms.ListBox();
            this.pnlVoucherSale.SuspendLayout();
            this.pnlMultiVoucher.SuspendLayout();
            this.pnlMultiPrint.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlVoucherSale
            // 
            this.pnlVoucherSale.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlVoucherSale.BackColor = System.Drawing.Color.White;
            this.pnlVoucherSale.Controls.Add(this.pnlMultiPrint);
            this.pnlVoucherSale.Controls.Add(this.lblRetryAttempt);
            this.pnlVoucherSale.Controls.Add(this.pnlMultiVoucher);
            this.pnlVoucherSale.Controls.Add(this.lblVoucherProcess);
            this.pnlVoucherSale.Controls.Add(this.btnVoucherCancel);
            this.pnlVoucherSale.Controls.Add(this.btnVoucherOK);
            this.pnlVoucherSale.Controls.Add(this.lblVoucherDesc);
            this.pnlVoucherSale.Controls.Add(this.lblVoucherNotice);
            this.pnlVoucherSale.Location = new System.Drawing.Point(8, 118);
            this.pnlVoucherSale.Name = "pnlVoucherSale";
            this.pnlVoucherSale.Size = new System.Drawing.Size(1100, 480);
            this.pnlVoucherSale.TabIndex = 0;
            // 
            // lblRetryAttempt
            // 
            this.lblRetryAttempt.AutoSize = true;
            this.lblRetryAttempt.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetryAttempt.ForeColor = System.Drawing.Color.Gray;
            this.lblRetryAttempt.Location = new System.Drawing.Point(393, 415);
            this.lblRetryAttempt.Name = "lblRetryAttempt";
            this.lblRetryAttempt.Size = new System.Drawing.Size(0, 16);
            this.lblRetryAttempt.TabIndex = 5;
            // 
            // pnlMultiVoucher
            // 
            this.pnlMultiVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMultiVoucher.BackColor = System.Drawing.Color.White;
            this.pnlMultiVoucher.Controls.Add(this.pnlMultiVoucherSide);
            this.pnlMultiVoucher.Controls.Add(this.lblPnlMultiVoucherHeader);
            this.pnlMultiVoucher.Controls.Add(this.btnMulti9);
            this.pnlMultiVoucher.Controls.Add(this.btnMulti8);
            this.pnlMultiVoucher.Controls.Add(this.btnMulti7);
            this.pnlMultiVoucher.Controls.Add(this.btnMulti6);
            this.pnlMultiVoucher.Controls.Add(this.btnMulti5);
            this.pnlMultiVoucher.Controls.Add(this.btnMulti4);
            this.pnlMultiVoucher.Controls.Add(this.btnMulti3);
            this.pnlMultiVoucher.Controls.Add(this.btnMulti2);
            this.pnlMultiVoucher.Location = new System.Drawing.Point(838, 13);
            this.pnlMultiVoucher.Name = "pnlMultiVoucher";
            this.pnlMultiVoucher.Size = new System.Drawing.Size(245, 445);
            this.pnlMultiVoucher.TabIndex = 1;
            // 
            // pnlMultiVoucherSide
            // 
            this.pnlMultiVoucherSide.BackColor = System.Drawing.Color.Green;
            this.pnlMultiVoucherSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMultiVoucherSide.Location = new System.Drawing.Point(0, 0);
            this.pnlMultiVoucherSide.Name = "pnlMultiVoucherSide";
            this.pnlMultiVoucherSide.Size = new System.Drawing.Size(3, 445);
            this.pnlMultiVoucherSide.TabIndex = 15;
            // 
            // lblPnlMultiVoucherHeader
            // 
            this.lblPnlMultiVoucherHeader.AutoSize = true;
            this.lblPnlMultiVoucherHeader.Font = new System.Drawing.Font("Tahoma", 20F);
            this.lblPnlMultiVoucherHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPnlMultiVoucherHeader.Location = new System.Drawing.Point(22, -1);
            this.lblPnlMultiVoucherHeader.Name = "lblPnlMultiVoucherHeader";
            this.lblPnlMultiVoucherHeader.Size = new System.Drawing.Size(224, 33);
            this.lblPnlMultiVoucherHeader.TabIndex = 14;
            this.lblPnlMultiVoucherHeader.Text = "Multiple Vouchers";
            // 
            // btnMulti9
            // 
            this.btnMulti9.BackColor = System.Drawing.Color.White;
            this.btnMulti9.BackgroundImage = global::TopitUp.Properties.Resources.airtimeMultiBg;
            this.btnMulti9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMulti9.FlatAppearance.BorderSize = 0;
            this.btnMulti9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMulti9.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMulti9.ForeColor = System.Drawing.Color.Green;
            this.btnMulti9.Location = new System.Drawing.Point(139, 354);
            this.btnMulti9.Name = "btnMulti9";
            this.btnMulti9.Size = new System.Drawing.Size(105, 90);
            this.btnMulti9.TabIndex = 13;
            this.btnMulti9.TabStop = false;
            this.btnMulti9.Tag = "9";
            this.btnMulti9.Text = "9";
            this.btnMulti9.UseVisualStyleBackColor = false;
            // 
            // btnMulti8
            // 
            this.btnMulti8.BackColor = System.Drawing.Color.White;
            this.btnMulti8.BackgroundImage = global::TopitUp.Properties.Resources.airtimeMultiBg;
            this.btnMulti8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMulti8.FlatAppearance.BorderSize = 0;
            this.btnMulti8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMulti8.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMulti8.ForeColor = System.Drawing.Color.Green;
            this.btnMulti8.Location = new System.Drawing.Point(24, 353);
            this.btnMulti8.Name = "btnMulti8";
            this.btnMulti8.Size = new System.Drawing.Size(105, 90);
            this.btnMulti8.TabIndex = 12;
            this.btnMulti8.TabStop = false;
            this.btnMulti8.Tag = "8";
            this.btnMulti8.Text = "8";
            this.btnMulti8.UseVisualStyleBackColor = false;
            // 
            // btnMulti7
            // 
            this.btnMulti7.BackColor = System.Drawing.Color.White;
            this.btnMulti7.BackgroundImage = global::TopitUp.Properties.Resources.airtimeMultiBg;
            this.btnMulti7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMulti7.FlatAppearance.BorderSize = 0;
            this.btnMulti7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMulti7.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMulti7.ForeColor = System.Drawing.Color.Green;
            this.btnMulti7.Location = new System.Drawing.Point(139, 251);
            this.btnMulti7.Name = "btnMulti7";
            this.btnMulti7.Size = new System.Drawing.Size(105, 90);
            this.btnMulti7.TabIndex = 11;
            this.btnMulti7.TabStop = false;
            this.btnMulti7.Tag = "7";
            this.btnMulti7.Text = "7";
            this.btnMulti7.UseVisualStyleBackColor = false;
            // 
            // btnMulti6
            // 
            this.btnMulti6.BackColor = System.Drawing.Color.White;
            this.btnMulti6.BackgroundImage = global::TopitUp.Properties.Resources.airtimeMultiBg;
            this.btnMulti6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMulti6.FlatAppearance.BorderSize = 0;
            this.btnMulti6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMulti6.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMulti6.ForeColor = System.Drawing.Color.Green;
            this.btnMulti6.Location = new System.Drawing.Point(24, 251);
            this.btnMulti6.Name = "btnMulti6";
            this.btnMulti6.Size = new System.Drawing.Size(105, 90);
            this.btnMulti6.TabIndex = 10;
            this.btnMulti6.TabStop = false;
            this.btnMulti6.Tag = "6";
            this.btnMulti6.Text = "6";
            this.btnMulti6.UseVisualStyleBackColor = false;
            // 
            // btnMulti5
            // 
            this.btnMulti5.BackColor = System.Drawing.Color.White;
            this.btnMulti5.BackgroundImage = global::TopitUp.Properties.Resources.airtimeMultiBg;
            this.btnMulti5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMulti5.FlatAppearance.BorderSize = 0;
            this.btnMulti5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMulti5.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMulti5.ForeColor = System.Drawing.Color.Green;
            this.btnMulti5.Location = new System.Drawing.Point(139, 150);
            this.btnMulti5.Name = "btnMulti5";
            this.btnMulti5.Size = new System.Drawing.Size(105, 90);
            this.btnMulti5.TabIndex = 9;
            this.btnMulti5.TabStop = false;
            this.btnMulti5.Tag = "5";
            this.btnMulti5.Text = "5";
            this.btnMulti5.UseVisualStyleBackColor = false;
            // 
            // btnMulti4
            // 
            this.btnMulti4.BackColor = System.Drawing.Color.White;
            this.btnMulti4.BackgroundImage = global::TopitUp.Properties.Resources.airtimeMultiBg;
            this.btnMulti4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMulti4.FlatAppearance.BorderSize = 0;
            this.btnMulti4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMulti4.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMulti4.ForeColor = System.Drawing.Color.Green;
            this.btnMulti4.Location = new System.Drawing.Point(24, 149);
            this.btnMulti4.Name = "btnMulti4";
            this.btnMulti4.Size = new System.Drawing.Size(105, 90);
            this.btnMulti4.TabIndex = 8;
            this.btnMulti4.TabStop = false;
            this.btnMulti4.Tag = "4";
            this.btnMulti4.Text = "4";
            this.btnMulti4.UseVisualStyleBackColor = false;
            // 
            // btnMulti3
            // 
            this.btnMulti3.BackColor = System.Drawing.Color.White;
            this.btnMulti3.BackgroundImage = global::TopitUp.Properties.Resources.airtimeMultiBg;
            this.btnMulti3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMulti3.FlatAppearance.BorderSize = 0;
            this.btnMulti3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMulti3.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMulti3.ForeColor = System.Drawing.Color.Green;
            this.btnMulti3.Location = new System.Drawing.Point(139, 48);
            this.btnMulti3.Name = "btnMulti3";
            this.btnMulti3.Size = new System.Drawing.Size(105, 90);
            this.btnMulti3.TabIndex = 7;
            this.btnMulti3.TabStop = false;
            this.btnMulti3.Tag = "3";
            this.btnMulti3.Text = "3";
            this.btnMulti3.UseVisualStyleBackColor = false;
            // 
            // btnMulti2
            // 
            this.btnMulti2.BackColor = System.Drawing.Color.White;
            this.btnMulti2.BackgroundImage = global::TopitUp.Properties.Resources.airtimeMultiBg;
            this.btnMulti2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMulti2.FlatAppearance.BorderSize = 0;
            this.btnMulti2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMulti2.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMulti2.ForeColor = System.Drawing.Color.Green;
            this.btnMulti2.Location = new System.Drawing.Point(24, 47);
            this.btnMulti2.Name = "btnMulti2";
            this.btnMulti2.Size = new System.Drawing.Size(105, 90);
            this.btnMulti2.TabIndex = 6;
            this.btnMulti2.TabStop = false;
            this.btnMulti2.Tag = "2";
            this.btnMulti2.Text = "2";
            this.btnMulti2.UseVisualStyleBackColor = false;
            // 
            // lblVoucherProcess
            // 
            this.lblVoucherProcess.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoucherProcess.ForeColor = System.Drawing.Color.Gray;
            this.lblVoucherProcess.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblVoucherProcess.Location = new System.Drawing.Point(35, 212);
            this.lblVoucherProcess.Name = "lblVoucherProcess";
            this.lblVoucherProcess.Size = new System.Drawing.Size(780, 115);
            this.lblVoucherProcess.TabIndex = 2;
            this.lblVoucherProcess.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnVoucherCancel
            // 
            this.btnVoucherCancel.BackColor = System.Drawing.Color.Maroon;
            this.btnVoucherCancel.FlatAppearance.BorderSize = 0;
            this.btnVoucherCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoucherCancel.Font = new System.Drawing.Font("Tahoma", 20F);
            this.btnVoucherCancel.ForeColor = System.Drawing.Color.White;
            this.btnVoucherCancel.Location = new System.Drawing.Point(41, 370);
            this.btnVoucherCancel.Name = "btnVoucherCancel";
            this.btnVoucherCancel.Size = new System.Drawing.Size(250, 90);
            this.btnVoucherCancel.TabIndex = 4;
            this.btnVoucherCancel.Text = "Cancel";
            this.btnVoucherCancel.UseVisualStyleBackColor = false;
            this.btnVoucherCancel.Visible = false;
            this.btnVoucherCancel.Click += new System.EventHandler(this.btnVoucherCancel_Click);
            // 
            // btnVoucherOK
            // 
            this.btnVoucherOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnVoucherOK.FlatAppearance.BorderSize = 0;
            this.btnVoucherOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoucherOK.Font = new System.Drawing.Font("Tahoma", 20F);
            this.btnVoucherOK.ForeColor = System.Drawing.Color.White;
            this.btnVoucherOK.Location = new System.Drawing.Point(544, 370);
            this.btnVoucherOK.Name = "btnVoucherOK";
            this.btnVoucherOK.Size = new System.Drawing.Size(250, 90);
            this.btnVoucherOK.TabIndex = 3;
            this.btnVoucherOK.Text = "OK";
            this.btnVoucherOK.UseVisualStyleBackColor = false;
            this.btnVoucherOK.Visible = false;
            this.btnVoucherOK.Click += new System.EventHandler(this.btnVoucherOK_Click);
            // 
            // lblVoucherDesc
            // 
            this.lblVoucherDesc.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoucherDesc.ForeColor = System.Drawing.Color.DarkGray;
            this.lblVoucherDesc.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblVoucherDesc.Location = new System.Drawing.Point(41, 70);
            this.lblVoucherDesc.Name = "lblVoucherDesc";
            this.lblVoucherDesc.Size = new System.Drawing.Size(774, 215);
            this.lblVoucherDesc.TabIndex = 1;
            this.lblVoucherDesc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblVoucherNotice
            // 
            this.lblVoucherNotice.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoucherNotice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblVoucherNotice.Location = new System.Drawing.Point(41, 20);
            this.lblVoucherNotice.Name = "lblVoucherNotice";
            this.lblVoucherNotice.Size = new System.Drawing.Size(774, 125);
            this.lblVoucherNotice.TabIndex = 0;
            this.lblVoucherNotice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tmr_delayed_load
            // 
            this.tmr_delayed_load.Interval = 500;
            this.tmr_delayed_load.Tick += new System.EventHandler(this.tmr_delayed_load_Tick);
            // 
            // timer_voucher_retry
            // 
            this.timer_voucher_retry.Interval = 5000;
            this.timer_voucher_retry.Tick += new System.EventHandler(this.timer_voucher_retry_Tick);
            // 
            // pnlMultiPrint
            // 
            this.pnlMultiPrint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMultiPrint.BackColor = System.Drawing.Color.LightGray;
            this.pnlMultiPrint.Controls.Add(this.lbl_plnMultiTotalValue);
            this.pnlMultiPrint.Controls.Add(this.lbl_plnMultiTotal);
            this.pnlMultiPrint.Controls.Add(this.lstMultiVoucher);
            this.pnlMultiPrint.Location = new System.Drawing.Point(837, 2);
            this.pnlMultiPrint.Name = "pnlMultiPrint";
            this.pnlMultiPrint.Size = new System.Drawing.Size(260, 475);
            this.pnlMultiPrint.TabIndex = 33;
            this.pnlMultiPrint.Visible = false;
            // 
            // lbl_plnMultiTotalValue
            // 
            this.lbl_plnMultiTotalValue.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbl_plnMultiTotalValue.AutoSize = true;
            this.lbl_plnMultiTotalValue.BackColor = System.Drawing.Color.Transparent;
            this.lbl_plnMultiTotalValue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_plnMultiTotalValue.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_plnMultiTotalValue.Location = new System.Drawing.Point(49, 437);
            this.lbl_plnMultiTotalValue.Name = "lbl_plnMultiTotalValue";
            this.lbl_plnMultiTotalValue.Size = new System.Drawing.Size(61, 19);
            this.lbl_plnMultiTotalValue.TabIndex = 3;
            this.lbl_plnMultiTotalValue.Text = "R 0.00";
            // 
            // lbl_plnMultiTotal
            // 
            this.lbl_plnMultiTotal.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbl_plnMultiTotal.AutoSize = true;
            this.lbl_plnMultiTotal.BackColor = System.Drawing.Color.Transparent;
            this.lbl_plnMultiTotal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_plnMultiTotal.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_plnMultiTotal.Location = new System.Drawing.Point(48, 405);
            this.lbl_plnMultiTotal.Name = "lbl_plnMultiTotal";
            this.lbl_plnMultiTotal.Size = new System.Drawing.Size(71, 19);
            this.lbl_plnMultiTotal.TabIndex = 1;
            this.lbl_plnMultiTotal.Text = "Total (0)";
            // 
            // lstMultiVoucher
            // 
            this.lstMultiVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstMultiVoucher.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstMultiVoucher.Enabled = false;
            this.lstMultiVoucher.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMultiVoucher.FormattingEnabled = true;
            this.lstMultiVoucher.ItemHeight = 24;
            this.lstMultiVoucher.Location = new System.Drawing.Point(2, 2);
            this.lstMultiVoucher.Name = "lstMultiVoucher";
            this.lstMultiVoucher.ScrollAlwaysVisible = true;
            this.lstMultiVoucher.Size = new System.Drawing.Size(253, 360);
            this.lstMultiVoucher.TabIndex = 0;
            // 
            // frmAirtime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1117, 677);
            this.ControlBox = false;
            this.Controls.Add(this.pnlVoucherSale);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAirtime";
            this.Opacity = 0.75D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Airtime";
            this.Load += new System.EventHandler(this.frmAirtime_Load);
            this.pnlVoucherSale.ResumeLayout(false);
            this.pnlVoucherSale.PerformLayout();
            this.pnlMultiVoucher.ResumeLayout(false);
            this.pnlMultiVoucher.PerformLayout();
            this.pnlMultiPrint.ResumeLayout(false);
            this.pnlMultiPrint.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlVoucherSale;
        private System.Windows.Forms.Label lblVoucherNotice;
        private System.Windows.Forms.Label lblVoucherDesc;
        private System.Windows.Forms.Label lblVoucherProcess;
        private System.Windows.Forms.Timer tmr_delayed_load;
        private System.Windows.Forms.Button btnVoucherOK;
        private System.Windows.Forms.Button btnVoucherCancel;
        private System.Windows.Forms.Timer timer_voucher_retry;
        private System.Windows.Forms.Panel pnlMultiVoucher;
        private System.Windows.Forms.Button btnMulti9;
        private System.Windows.Forms.Button btnMulti8;
        private System.Windows.Forms.Button btnMulti7;
        private System.Windows.Forms.Button btnMulti6;
        private System.Windows.Forms.Button btnMulti5;
        private System.Windows.Forms.Button btnMulti4;
        private System.Windows.Forms.Button btnMulti3;
        private System.Windows.Forms.Button btnMulti2;
        private System.Windows.Forms.Label lblPnlMultiVoucherHeader;
        private System.Windows.Forms.Panel pnlMultiVoucherSide;
        private System.Windows.Forms.Label lblRetryAttempt;
        private System.Windows.Forms.Panel pnlMultiPrint;
        private System.Windows.Forms.Label lbl_plnMultiTotalValue;
        private System.Windows.Forms.Label lbl_plnMultiTotal;
        private System.Windows.Forms.ListBox lstMultiVoucher;
    }
}
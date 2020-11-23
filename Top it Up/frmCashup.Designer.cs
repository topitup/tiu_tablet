namespace TopitUp
{
    partial class frmCashup
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new System.Windows.Forms.Button();
            this.grdCashierZHistory = new System.Windows.Forms.DataGridView();
            this.grdCashierZCol1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdCashierZCol2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdCashierZCol3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRunX = new System.Windows.Forms.Button();
            this.btnZReportCashup = new System.Windows.Forms.Button();
            this.btnYReportHistory = new System.Windows.Forms.Button();
            this.lblWIntraday = new System.Windows.Forms.Label();
            this.lblYShift = new System.Windows.Forms.Label();
            this.lblLastYReports = new System.Windows.Forms.Label();
            this.btnZHistoryReprint = new System.Windows.Forms.Button();
            this.pnlMainWrapper = new System.Windows.Forms.Panel();
            this.btnRestart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdCashierZHistory)).BeginInit();
            this.pnlMainWrapper.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackgroundImage = global::TopitUp.Properties.Resources.generalbtn1;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.Location = new System.Drawing.Point(630, 392);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(166, 89);
            this.btnClose.TabIndex = 91;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grdCashierZHistory
            // 
            this.grdCashierZHistory.AllowUserToAddRows = false;
            this.grdCashierZHistory.AllowUserToDeleteRows = false;
            this.grdCashierZHistory.AllowUserToResizeColumns = false;
            this.grdCashierZHistory.AllowUserToResizeRows = false;
            this.grdCashierZHistory.BackgroundColor = System.Drawing.Color.White;
            this.grdCashierZHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdCashierZHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdCashierZHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCashierZHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grdCashierZCol1,
            this.grdCashierZCol2,
            this.grdCashierZCol3});
            this.grdCashierZHistory.Location = new System.Drawing.Point(246, 45);
            this.grdCashierZHistory.MultiSelect = false;
            this.grdCashierZHistory.Name = "grdCashierZHistory";
            this.grdCashierZHistory.ReadOnly = true;
            this.grdCashierZHistory.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdCashierZHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdCashierZHistory.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(3);
            this.grdCashierZHistory.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdCashierZHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCashierZHistory.ShowCellErrors = false;
            this.grdCashierZHistory.ShowCellToolTips = false;
            this.grdCashierZHistory.ShowRowErrors = false;
            this.grdCashierZHistory.Size = new System.Drawing.Size(550, 320);
            this.grdCashierZHistory.TabIndex = 92;
            this.grdCashierZHistory.Visible = false;
            // 
            // grdCashierZCol1
            // 
            this.grdCashierZCol1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.grdCashierZCol1.HeaderText = "Date";
            this.grdCashierZCol1.Name = "grdCashierZCol1";
            this.grdCashierZCol1.ReadOnly = true;
            this.grdCashierZCol1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grdCashierZCol1.Width = 180;
            // 
            // grdCashierZCol2
            // 
            this.grdCashierZCol2.HeaderText = "Time";
            this.grdCashierZCol2.Name = "grdCashierZCol2";
            this.grdCashierZCol2.ReadOnly = true;
            this.grdCashierZCol2.Width = 150;
            // 
            // grdCashierZCol3
            // 
            this.grdCashierZCol3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.grdCashierZCol3.HeaderText = "Total Sales";
            this.grdCashierZCol3.Name = "grdCashierZCol3";
            this.grdCashierZCol3.ReadOnly = true;
            // 
            // btnRunX
            // 
            this.btnRunX.BackgroundImage = global::TopitUp.Properties.Resources.generalbtn1;
            this.btnRunX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRunX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRunX.FlatAppearance.BorderSize = 0;
            this.btnRunX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRunX.Location = new System.Drawing.Point(38, 38);
            this.btnRunX.Margin = new System.Windows.Forms.Padding(0);
            this.btnRunX.Name = "btnRunX";
            this.btnRunX.Size = new System.Drawing.Size(166, 89);
            this.btnRunX.TabIndex = 93;
            this.btnRunX.Text = "W - Intraday\r\nSales";
            this.btnRunX.UseVisualStyleBackColor = false;
            this.btnRunX.Click += new System.EventHandler(this.btnRunX_Click);
            // 
            // btnZReportCashup
            // 
            this.btnZReportCashup.BackgroundImage = global::TopitUp.Properties.Resources.generalbtn2;
            this.btnZReportCashup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnZReportCashup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZReportCashup.FlatAppearance.BorderSize = 0;
            this.btnZReportCashup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZReportCashup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZReportCashup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnZReportCashup.Location = new System.Drawing.Point(38, 159);
            this.btnZReportCashup.Margin = new System.Windows.Forms.Padding(0);
            this.btnZReportCashup.Name = "btnZReportCashup";
            this.btnZReportCashup.Size = new System.Drawing.Size(166, 89);
            this.btnZReportCashup.TabIndex = 94;
            this.btnZReportCashup.Text = "Y - Shift\r\nCashup";
            this.btnZReportCashup.UseVisualStyleBackColor = false;
            this.btnZReportCashup.Click += new System.EventHandler(this.btnZReportCashup_Click);
            // 
            // btnYReportHistory
            // 
            this.btnYReportHistory.BackgroundImage = global::TopitUp.Properties.Resources.generalbtn1;
            this.btnYReportHistory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnYReportHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYReportHistory.FlatAppearance.BorderSize = 0;
            this.btnYReportHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYReportHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYReportHistory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnYReportHistory.Location = new System.Drawing.Point(38, 276);
            this.btnYReportHistory.Margin = new System.Windows.Forms.Padding(0);
            this.btnYReportHistory.Name = "btnYReportHistory";
            this.btnYReportHistory.Size = new System.Drawing.Size(166, 89);
            this.btnYReportHistory.TabIndex = 95;
            this.btnYReportHistory.Text = "Y - Report\r\nHistory";
            this.btnYReportHistory.UseVisualStyleBackColor = false;
            this.btnYReportHistory.Click += new System.EventHandler(this.btnYReportHistory_Click);
            // 
            // lblWIntraday
            // 
            this.lblWIntraday.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblWIntraday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblWIntraday.Location = new System.Drawing.Point(265, 59);
            this.lblWIntraday.Name = "lblWIntraday";
            this.lblWIntraday.Size = new System.Drawing.Size(363, 43);
            this.lblWIntraday.TabIndex = 97;
            this.lblWIntraday.Text = "Print Sales Summary for the current shift.";
            // 
            // lblYShift
            // 
            this.lblYShift.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblYShift.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblYShift.Location = new System.Drawing.Point(265, 161);
            this.lblYShift.Name = "lblYShift";
            this.lblYShift.Size = new System.Drawing.Size(363, 83);
            this.lblYShift.TabIndex = 99;
            this.lblYShift.Text = "Close the current shift\'s sales by running the \"Y Shift Cashup\".\r\nA Sales Summary" +
    " will be printed for the Cashier who executed this function.";
            // 
            // lblLastYReports
            // 
            this.lblLastYReports.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblLastYReports.ForeColor = System.Drawing.Color.Black;
            this.lblLastYReports.Location = new System.Drawing.Point(244, 17);
            this.lblLastYReports.Name = "lblLastYReports";
            this.lblLastYReports.Size = new System.Drawing.Size(294, 25);
            this.lblLastYReports.TabIndex = 101;
            this.lblLastYReports.Text = "Last 10 Y Reports";
            this.lblLastYReports.Visible = false;
            // 
            // btnZHistoryReprint
            // 
            this.btnZHistoryReprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnZHistoryReprint.BackgroundImage = global::TopitUp.Properties.Resources.generalbtn1;
            this.btnZHistoryReprint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnZHistoryReprint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZHistoryReprint.FlatAppearance.BorderSize = 0;
            this.btnZHistoryReprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZHistoryReprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZHistoryReprint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnZHistoryReprint.Location = new System.Drawing.Point(246, 392);
            this.btnZHistoryReprint.Margin = new System.Windows.Forms.Padding(0);
            this.btnZHistoryReprint.Name = "btnZHistoryReprint";
            this.btnZHistoryReprint.Size = new System.Drawing.Size(166, 89);
            this.btnZHistoryReprint.TabIndex = 102;
            this.btnZHistoryReprint.Text = "Reprint";
            this.btnZHistoryReprint.UseVisualStyleBackColor = false;
            this.btnZHistoryReprint.Visible = false;
            this.btnZHistoryReprint.Click += new System.EventHandler(this.btnZHistoryReprint_Click);
            // 
            // pnlMainWrapper
            // 
            this.pnlMainWrapper.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlMainWrapper.BackColor = System.Drawing.Color.White;
            this.pnlMainWrapper.Controls.Add(this.btnRestart);
            this.pnlMainWrapper.Controls.Add(this.btnRunX);
            this.pnlMainWrapper.Controls.Add(this.btnZHistoryReprint);
            this.pnlMainWrapper.Controls.Add(this.btnClose);
            this.pnlMainWrapper.Controls.Add(this.lblLastYReports);
            this.pnlMainWrapper.Controls.Add(this.btnZReportCashup);
            this.pnlMainWrapper.Controls.Add(this.grdCashierZHistory);
            this.pnlMainWrapper.Controls.Add(this.btnYReportHistory);
            this.pnlMainWrapper.Controls.Add(this.lblYShift);
            this.pnlMainWrapper.Controls.Add(this.lblWIntraday);
            this.pnlMainWrapper.Location = new System.Drawing.Point(70, 38);
            this.pnlMainWrapper.Name = "pnlMainWrapper";
            this.pnlMainWrapper.Size = new System.Drawing.Size(861, 497);
            this.pnlMainWrapper.TabIndex = 103;
            // 
            // btnRestart
            // 
            this.btnRestart.BackgroundImage = global::TopitUp.Properties.Resources.generalbtn2;
            this.btnRestart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRestart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestart.FlatAppearance.BorderSize = 0;
            this.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRestart.Location = new System.Drawing.Point(38, 389);
            this.btnRestart.Margin = new System.Windows.Forms.Padding(0);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(166, 89);
            this.btnRestart.TabIndex = 103;
            this.btnRestart.Text = "Restart\r\nDevice";
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Visible = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // frmCashup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1005, 590);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMainWrapper);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCashup";
            this.Opacity = 0.7D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCashup";
            this.Load += new System.EventHandler(this.frmCashup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdCashierZHistory)).EndInit();
            this.pnlMainWrapper.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView grdCashierZHistory;
        private System.Windows.Forms.Button btnRunX;
        private System.Windows.Forms.Button btnZReportCashup;
        private System.Windows.Forms.Button btnYReportHistory;
        private System.Windows.Forms.Label lblWIntraday;
        private System.Windows.Forms.Label lblYShift;
        private System.Windows.Forms.Label lblLastYReports;
        private System.Windows.Forms.Button btnZHistoryReprint;
        private System.Windows.Forms.DataGridViewTextBoxColumn grdCashierZCol1;
        private System.Windows.Forms.DataGridViewTextBoxColumn grdCashierZCol2;
        private System.Windows.Forms.DataGridViewTextBoxColumn grdCashierZCol3;
        private System.Windows.Forms.Panel pnlMainWrapper;
        private System.Windows.Forms.Button btnRestart;
    }
}
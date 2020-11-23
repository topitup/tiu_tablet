namespace TopitUp
{
    partial class frmSalesSearch
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
            this.pnlSalesRpt = new System.Windows.Forms.Panel();
            this.btnSRClose = new System.Windows.Forms.Button();
            this.btnSRReprint = new System.Windows.Forms.Button();
            this.grdSR = new System.Windows.Forms.DataGridView();
            this.grdSRCol1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdSRCol2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdSRCol3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdSRCol4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdSRCol5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSRFilter = new System.Windows.Forms.Button();
            this.cboVoucher = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.cboEtime = new System.Windows.Forms.ComboBox();
            this.cboStime = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.cboEday = new System.Windows.Forms.ComboBox();
            this.cboEyear = new System.Windows.Forms.ComboBox();
            this.cboEmonth = new System.Windows.Forms.ComboBox();
            this.cboSday = new System.Windows.Forms.ComboBox();
            this.cboSyear = new System.Windows.Forms.ComboBox();
            this.cboSmonth = new System.Windows.Forms.ComboBox();
            this.pnlSalesRpt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSR)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSalesRpt
            // 
            this.pnlSalesRpt.BackColor = System.Drawing.Color.White;
            this.pnlSalesRpt.Controls.Add(this.btnSRClose);
            this.pnlSalesRpt.Controls.Add(this.btnSRReprint);
            this.pnlSalesRpt.Controls.Add(this.grdSR);
            this.pnlSalesRpt.Controls.Add(this.btnSRFilter);
            this.pnlSalesRpt.Controls.Add(this.cboVoucher);
            this.pnlSalesRpt.Controls.Add(this.label24);
            this.pnlSalesRpt.Controls.Add(this.cboEtime);
            this.pnlSalesRpt.Controls.Add(this.cboStime);
            this.pnlSalesRpt.Controls.Add(this.label22);
            this.pnlSalesRpt.Controls.Add(this.label23);
            this.pnlSalesRpt.Controls.Add(this.cboEday);
            this.pnlSalesRpt.Controls.Add(this.cboEyear);
            this.pnlSalesRpt.Controls.Add(this.cboEmonth);
            this.pnlSalesRpt.Controls.Add(this.cboSday);
            this.pnlSalesRpt.Controls.Add(this.cboSyear);
            this.pnlSalesRpt.Controls.Add(this.cboSmonth);
            this.pnlSalesRpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSalesRpt.Location = new System.Drawing.Point(0, 0);
            this.pnlSalesRpt.Name = "pnlSalesRpt";
            this.pnlSalesRpt.Size = new System.Drawing.Size(652, 437);
            this.pnlSalesRpt.TabIndex = 1;
            // 
            // btnSRClose
            // 
            this.btnSRClose.BackgroundImage = global::TopitUp.Properties.Resources.generalbtn1;
            this.btnSRClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSRClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSRClose.FlatAppearance.BorderSize = 0;
            this.btnSRClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSRClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSRClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSRClose.Location = new System.Drawing.Point(459, 341);
            this.btnSRClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnSRClose.Name = "btnSRClose";
            this.btnSRClose.Size = new System.Drawing.Size(166, 89);
            this.btnSRClose.TabIndex = 90;
            this.btnSRClose.Text = "Close";
            this.btnSRClose.UseVisualStyleBackColor = false;
            this.btnSRClose.Click += new System.EventHandler(this.btnSRClose_Click);
            // 
            // btnSRReprint
            // 
            this.btnSRReprint.BackgroundImage = global::TopitUp.Properties.Resources.generalbtn1;
            this.btnSRReprint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSRReprint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSRReprint.FlatAppearance.BorderSize = 0;
            this.btnSRReprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSRReprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSRReprint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSRReprint.Location = new System.Drawing.Point(17, 341);
            this.btnSRReprint.Margin = new System.Windows.Forms.Padding(0);
            this.btnSRReprint.Name = "btnSRReprint";
            this.btnSRReprint.Size = new System.Drawing.Size(166, 89);
            this.btnSRReprint.TabIndex = 89;
            this.btnSRReprint.Text = "Re-Print";
            this.btnSRReprint.UseVisualStyleBackColor = false;
            this.btnSRReprint.Click += new System.EventHandler(this.btnSRReprint_Click);
            // 
            // grdSR
            // 
            this.grdSR.AllowUserToAddRows = false;
            this.grdSR.AllowUserToDeleteRows = false;
            this.grdSR.AllowUserToResizeColumns = false;
            this.grdSR.AllowUserToResizeRows = false;
            this.grdSR.BackgroundColor = System.Drawing.Color.White;
            this.grdSR.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSR.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdSR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSR.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grdSRCol1,
            this.grdSRCol2,
            this.grdSRCol3,
            this.grdSRCol4,
            this.grdSRCol5});
            this.grdSR.Location = new System.Drawing.Point(17, 145);
            this.grdSR.MultiSelect = false;
            this.grdSR.Name = "grdSR";
            this.grdSR.ReadOnly = true;
            this.grdSR.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grdSR.RowHeadersVisible = false;
            this.grdSR.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSR.ShowCellErrors = false;
            this.grdSR.ShowCellToolTips = false;
            this.grdSR.ShowRowErrors = false;
            this.grdSR.Size = new System.Drawing.Size(618, 183);
            this.grdSR.TabIndex = 86;
            // 
            // grdSRCol1
            // 
            this.grdSRCol1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.grdSRCol1.HeaderText = "Date & Time";
            this.grdSRCol1.Name = "grdSRCol1";
            this.grdSRCol1.ReadOnly = true;
            // 
            // grdSRCol2
            // 
            this.grdSRCol2.HeaderText = "Description";
            this.grdSRCol2.Name = "grdSRCol2";
            this.grdSRCol2.ReadOnly = true;
            this.grdSRCol2.Width = 150;
            // 
            // grdSRCol3
            // 
            this.grdSRCol3.HeaderText = "Value";
            this.grdSRCol3.Name = "grdSRCol3";
            this.grdSRCol3.ReadOnly = true;
            this.grdSRCol3.Width = 150;
            // 
            // grdSRCol4
            // 
            this.grdSRCol4.HeaderText = "Serial/Meter";
            this.grdSRCol4.Name = "grdSRCol4";
            this.grdSRCol4.ReadOnly = true;
            // 
            // grdSRCol5
            // 
            this.grdSRCol5.HeaderText = "User";
            this.grdSRCol5.Name = "grdSRCol5";
            this.grdSRCol5.ReadOnly = true;
            // 
            // btnSRFilter
            // 
            this.btnSRFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSRFilter.FlatAppearance.BorderSize = 0;
            this.btnSRFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSRFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSRFilter.Location = new System.Drawing.Point(486, 98);
            this.btnSRFilter.Margin = new System.Windows.Forms.Padding(0);
            this.btnSRFilter.Name = "btnSRFilter";
            this.btnSRFilter.Size = new System.Drawing.Size(138, 31);
            this.btnSRFilter.TabIndex = 42;
            this.btnSRFilter.Text = "Filter";
            this.btnSRFilter.UseVisualStyleBackColor = false;
            this.btnSRFilter.Click += new System.EventHandler(this.btnSRFilter_Click);
            // 
            // cboVoucher
            // 
            this.cboVoucher.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.cboVoucher.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.cboVoucher.Location = new System.Drawing.Point(131, 98);
            this.cboVoucher.Name = "cboVoucher";
            this.cboVoucher.Size = new System.Drawing.Size(319, 31);
            this.cboVoucher.TabIndex = 38;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label24.Location = new System.Drawing.Point(40, 100);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(83, 27);
            this.label24.TabIndex = 39;
            this.label24.Text = "Voucher:";
            // 
            // cboEtime
            // 
            this.cboEtime.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.cboEtime.Location = new System.Drawing.Point(486, 52);
            this.cboEtime.Name = "cboEtime";
            this.cboEtime.Size = new System.Drawing.Size(139, 31);
            this.cboEtime.TabIndex = 35;
            // 
            // cboStime
            // 
            this.cboStime.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.cboStime.Location = new System.Drawing.Point(486, 15);
            this.cboStime.Name = "cboStime";
            this.cboStime.Size = new System.Drawing.Size(138, 31);
            this.cboStime.TabIndex = 34;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label22.Location = new System.Drawing.Point(40, 52);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(83, 27);
            this.label22.TabIndex = 40;
            this.label22.Text = "To Date:";
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label23.Location = new System.Drawing.Point(20, 18);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(105, 27);
            this.label23.TabIndex = 41;
            this.label23.Text = "From Date:";
            // 
            // cboEday
            // 
            this.cboEday.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.cboEday.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.cboEday.Location = new System.Drawing.Point(131, 50);
            this.cboEday.Name = "cboEday";
            this.cboEday.Size = new System.Drawing.Size(60, 31);
            this.cboEday.TabIndex = 33;
            // 
            // cboEyear
            // 
            this.cboEyear.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.cboEyear.Location = new System.Drawing.Point(370, 50);
            this.cboEyear.Name = "cboEyear";
            this.cboEyear.Size = new System.Drawing.Size(80, 31);
            this.cboEyear.TabIndex = 32;
            // 
            // cboEmonth
            // 
            this.cboEmonth.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.cboEmonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cboEmonth.Location = new System.Drawing.Point(210, 50);
            this.cboEmonth.Name = "cboEmonth";
            this.cboEmonth.Size = new System.Drawing.Size(140, 31);
            this.cboEmonth.TabIndex = 31;
            // 
            // cboSday
            // 
            this.cboSday.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.cboSday.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.cboSday.Location = new System.Drawing.Point(131, 15);
            this.cboSday.Name = "cboSday";
            this.cboSday.Size = new System.Drawing.Size(60, 31);
            this.cboSday.TabIndex = 30;
            // 
            // cboSyear
            // 
            this.cboSyear.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.cboSyear.Location = new System.Drawing.Point(370, 16);
            this.cboSyear.Name = "cboSyear";
            this.cboSyear.Size = new System.Drawing.Size(80, 31);
            this.cboSyear.TabIndex = 29;
            // 
            // cboSmonth
            // 
            this.cboSmonth.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.cboSmonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cboSmonth.Location = new System.Drawing.Point(210, 15);
            this.cboSmonth.Name = "cboSmonth";
            this.cboSmonth.Size = new System.Drawing.Size(140, 31);
            this.cboSmonth.TabIndex = 28;
            // 
            // frmSalesSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 437);
            this.ControlBox = false;
            this.Controls.Add(this.pnlSalesRpt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmSalesSearch";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Search";
            this.Load += new System.EventHandler(this.frmSalesSearch_Load);
            this.pnlSalesRpt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSR)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSalesRpt;
        private System.Windows.Forms.ComboBox cboVoucher;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cboEtime;
        private System.Windows.Forms.ComboBox cboStime;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cboEday;
        private System.Windows.Forms.ComboBox cboEyear;
        private System.Windows.Forms.ComboBox cboEmonth;
        private System.Windows.Forms.ComboBox cboSday;
        private System.Windows.Forms.ComboBox cboSyear;
        private System.Windows.Forms.ComboBox cboSmonth;
        private System.Windows.Forms.Button btnSRFilter;
        private System.Windows.Forms.DataGridView grdSR;
        private System.Windows.Forms.DataGridViewTextBoxColumn grdSRCol1;
        private System.Windows.Forms.DataGridViewTextBoxColumn grdSRCol2;
        private System.Windows.Forms.DataGridViewTextBoxColumn grdSRCol3;
        private System.Windows.Forms.DataGridViewTextBoxColumn grdSRCol4;
        private System.Windows.Forms.DataGridViewTextBoxColumn grdSRCol5;
        private System.Windows.Forms.Button btnSRReprint;
        private System.Windows.Forms.Button btnSRClose;
    }
}
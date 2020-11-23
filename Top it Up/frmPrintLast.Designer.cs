namespace TopitUp
{
    partial class frmPrintLast
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.rdoFilterType0 = new System.Windows.Forms.RadioButton();
            this.rdoFilterType1 = new System.Windows.Forms.RadioButton();
            this.rdoFilterType2 = new System.Windows.Forms.RadioButton();
            this.rdoFilterType3 = new System.Windows.Forms.RadioButton();
            this.lblReprintSerialMeter = new System.Windows.Forms.Label();
            this.txtReprint = new System.Windows.Forms.TextBox();
            this.pnlRefInput = new System.Windows.Forms.Panel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlFooterLogedin = new System.Windows.Forms.Panel();
            this.btnSalesHistory = new System.Windows.Forms.Button();
            this.btnMainClose = new System.Windows.Forms.Button();
            this.pnlFooterRHS = new System.Windows.Forms.Panel();
            this.btnReprint = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.pnlKeyboard = new System.Windows.Forms.Panel();
            this.virtualKeyboard1 = new TopitUp.virtualKeyboard();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlWrapper = new System.Windows.Forms.Panel();
            this.dgLast10 = new System.Windows.Forms.DataGridView();
            this.grdDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlRefInput.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlFooterLogedin.SuspendLayout();
            this.pnlFooterRHS.SuspendLayout();
            this.pnlKeyboard.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlWrapper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLast10)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 2;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.Green;
            this.btnRefresh.Location = new System.Drawing.Point(569, 37);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(200, 80);
            this.btnRefresh.TabIndex = 100;
            this.btnRefresh.Text = "View Last\r\nSales";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // rdoFilterType0
            // 
            this.rdoFilterType0.AutoSize = true;
            this.rdoFilterType0.Checked = true;
            this.rdoFilterType0.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoFilterType0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdoFilterType0.Location = new System.Drawing.Point(25, 26);
            this.rdoFilterType0.Name = "rdoFilterType0";
            this.rdoFilterType0.Size = new System.Drawing.Size(47, 24);
            this.rdoFilterType0.TabIndex = 101;
            this.rdoFilterType0.TabStop = true;
            this.rdoFilterType0.Text = "All";
            this.rdoFilterType0.UseVisualStyleBackColor = true;
            this.rdoFilterType0.CheckedChanged += new System.EventHandler(this.rdoFilterType0_CheckedChanged);
            // 
            // rdoFilterType1
            // 
            this.rdoFilterType1.AutoSize = true;
            this.rdoFilterType1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoFilterType1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdoFilterType1.Location = new System.Drawing.Point(92, 26);
            this.rdoFilterType1.Name = "rdoFilterType1";
            this.rdoFilterType1.Size = new System.Drawing.Size(83, 24);
            this.rdoFilterType1.TabIndex = 102;
            this.rdoFilterType1.Text = "Airtime";
            this.rdoFilterType1.UseVisualStyleBackColor = true;
            this.rdoFilterType1.CheckedChanged += new System.EventHandler(this.rdoFilterType1_CheckedChanged);
            // 
            // rdoFilterType2
            // 
            this.rdoFilterType2.AutoSize = true;
            this.rdoFilterType2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoFilterType2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdoFilterType2.Location = new System.Drawing.Point(92, 61);
            this.rdoFilterType2.Name = "rdoFilterType2";
            this.rdoFilterType2.Size = new System.Drawing.Size(105, 24);
            this.rdoFilterType2.TabIndex = 103;
            this.rdoFilterType2.Text = "Electricity";
            this.rdoFilterType2.UseVisualStyleBackColor = true;
            this.rdoFilterType2.CheckedChanged += new System.EventHandler(this.rdoFilterType2_CheckedChanged);
            // 
            // rdoFilterType3
            // 
            this.rdoFilterType3.AutoSize = true;
            this.rdoFilterType3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoFilterType3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdoFilterType3.Location = new System.Drawing.Point(92, 96);
            this.rdoFilterType3.Name = "rdoFilterType3";
            this.rdoFilterType3.Size = new System.Drawing.Size(134, 24);
            this.rdoFilterType3.TabIndex = 104;
            this.rdoFilterType3.Text = "Bill Payments";
            this.rdoFilterType3.UseVisualStyleBackColor = true;
            this.rdoFilterType3.CheckedChanged += new System.EventHandler(this.rdoFilterType3_CheckedChanged);
            // 
            // lblReprintSerialMeter
            // 
            this.lblReprintSerialMeter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReprintSerialMeter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblReprintSerialMeter.Location = new System.Drawing.Point(258, 42);
            this.lblReprintSerialMeter.Name = "lblReprintSerialMeter";
            this.lblReprintSerialMeter.Size = new System.Drawing.Size(258, 48);
            this.lblReprintSerialMeter.TabIndex = 106;
            this.lblReprintSerialMeter.Text = "Or Filter By Reference/Serial:\r\n";
            // 
            // txtReprint
            // 
            this.txtReprint.BackColor = System.Drawing.Color.White;
            this.txtReprint.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtReprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReprint.Location = new System.Drawing.Point(8, 5);
            this.txtReprint.MaxLength = 30;
            this.txtReprint.Name = "txtReprint";
            this.txtReprint.Size = new System.Drawing.Size(242, 31);
            this.txtReprint.TabIndex = 105;
            this.txtReprint.TabStop = false;
            // 
            // pnlRefInput
            // 
            this.pnlRefInput.BackgroundImage = global::TopitUp.Properties.Resources.input_bg;
            this.pnlRefInput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlRefInput.Controls.Add(this.txtReprint);
            this.pnlRefInput.Location = new System.Drawing.Point(259, 70);
            this.pnlRefInput.Name = "pnlRefInput";
            this.pnlRefInput.Size = new System.Drawing.Size(257, 39);
            this.pnlRefInput.TabIndex = 107;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.pnlFooter.Controls.Add(this.pnlFooterLogedin);
            this.pnlFooter.Controls.Add(this.pnlFooterRHS);
            this.pnlFooter.Controls.Add(this.btnAbout);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 649);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(874, 90);
            this.pnlFooter.TabIndex = 147;
            // 
            // pnlFooterLogedin
            // 
            this.pnlFooterLogedin.Controls.Add(this.btnSalesHistory);
            this.pnlFooterLogedin.Controls.Add(this.btnMainClose);
            this.pnlFooterLogedin.Location = new System.Drawing.Point(0, 1);
            this.pnlFooterLogedin.Name = "pnlFooterLogedin";
            this.pnlFooterLogedin.Size = new System.Drawing.Size(512, 90);
            this.pnlFooterLogedin.TabIndex = 38;
            // 
            // btnSalesHistory
            // 
            this.btnSalesHistory.BackColor = System.Drawing.Color.White;
            this.btnSalesHistory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSalesHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalesHistory.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSalesHistory.FlatAppearance.BorderSize = 0;
            this.btnSalesHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalesHistory.Font = new System.Drawing.Font("Tahoma", 20F);
            this.btnSalesHistory.ForeColor = System.Drawing.Color.Maroon;
            this.btnSalesHistory.Location = new System.Drawing.Point(251, 0);
            this.btnSalesHistory.Margin = new System.Windows.Forms.Padding(5);
            this.btnSalesHistory.Name = "btnSalesHistory";
            this.btnSalesHistory.Size = new System.Drawing.Size(250, 89);
            this.btnSalesHistory.TabIndex = 17;
            this.btnSalesHistory.TabStop = false;
            this.btnSalesHistory.Text = "Sales\r\nSearch";
            this.btnSalesHistory.UseVisualStyleBackColor = false;
            this.btnSalesHistory.Click += new System.EventHandler(this.btnSalesHistory_Click);
            // 
            // btnMainClose
            // 
            this.btnMainClose.BackColor = System.Drawing.Color.White;
            this.btnMainClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMainClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMainClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMainClose.FlatAppearance.BorderSize = 0;
            this.btnMainClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainClose.Font = new System.Drawing.Font("Tahoma", 20F);
            this.btnMainClose.ForeColor = System.Drawing.Color.Maroon;
            this.btnMainClose.Location = new System.Drawing.Point(0, 0);
            this.btnMainClose.Margin = new System.Windows.Forms.Padding(5);
            this.btnMainClose.Name = "btnMainClose";
            this.btnMainClose.Size = new System.Drawing.Size(250, 89);
            this.btnMainClose.TabIndex = 16;
            this.btnMainClose.TabStop = false;
            this.btnMainClose.Text = "Close";
            this.btnMainClose.UseVisualStyleBackColor = false;
            this.btnMainClose.Click += new System.EventHandler(this.btnMainClose_Click);
            // 
            // pnlFooterRHS
            // 
            this.pnlFooterRHS.Controls.Add(this.btnReprint);
            this.pnlFooterRHS.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFooterRHS.Location = new System.Drawing.Point(578, 0);
            this.pnlFooterRHS.Name = "pnlFooterRHS";
            this.pnlFooterRHS.Size = new System.Drawing.Size(296, 90);
            this.pnlFooterRHS.TabIndex = 37;
            // 
            // btnReprint
            // 
            this.btnReprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReprint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(163)))));
            this.btnReprint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnReprint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReprint.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnReprint.FlatAppearance.BorderSize = 0;
            this.btnReprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReprint.Font = new System.Drawing.Font("Tahoma", 20F);
            this.btnReprint.ForeColor = System.Drawing.Color.White;
            this.btnReprint.Location = new System.Drawing.Point(45, 0);
            this.btnReprint.Margin = new System.Windows.Forms.Padding(5);
            this.btnReprint.Name = "btnReprint";
            this.btnReprint.Size = new System.Drawing.Size(250, 89);
            this.btnReprint.TabIndex = 17;
            this.btnReprint.TabStop = false;
            this.btnReprint.Text = "Reprint";
            this.btnReprint.UseVisualStyleBackColor = false;
            this.btnReprint.Click += new System.EventHandler(this.btnReprint_Click);
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
            this.btnAbout.Location = new System.Drawing.Point(944, 1);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(140, 60);
            this.btnAbout.TabIndex = 36;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = false;
            // 
            // pnlKeyboard
            // 
            this.pnlKeyboard.Controls.Add(this.virtualKeyboard1);
            this.pnlKeyboard.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlKeyboard.Location = new System.Drawing.Point(874, 0);
            this.pnlKeyboard.Name = "pnlKeyboard";
            this.pnlKeyboard.Size = new System.Drawing.Size(400, 739);
            this.pnlKeyboard.TabIndex = 148;
            // 
            // virtualKeyboard1
            // 
            this.virtualKeyboard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.virtualKeyboard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.virtualKeyboard1.Location = new System.Drawing.Point(0, 0);
            this.virtualKeyboard1.Name = "virtualKeyboard1";
            this.virtualKeyboard1.Size = new System.Drawing.Size(400, 739);
            this.virtualKeyboard1.TabIndex = 0;
            this.virtualKeyboard1.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlKeyboard_Paint);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlWrapper);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(874, 649);
            this.pnlMain.TabIndex = 149;
            // 
            // pnlWrapper
            // 
            this.pnlWrapper.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlWrapper.Controls.Add(this.dgLast10);
            this.pnlWrapper.Controls.Add(this.pnlRefInput);
            this.pnlWrapper.Controls.Add(this.rdoFilterType0);
            this.pnlWrapper.Controls.Add(this.rdoFilterType3);
            this.pnlWrapper.Controls.Add(this.rdoFilterType2);
            this.pnlWrapper.Controls.Add(this.lblReprintSerialMeter);
            this.pnlWrapper.Controls.Add(this.rdoFilterType1);
            this.pnlWrapper.Controls.Add(this.btnRefresh);
            this.pnlWrapper.Location = new System.Drawing.Point(8, 9);
            this.pnlWrapper.Name = "pnlWrapper";
            this.pnlWrapper.Size = new System.Drawing.Size(856, 628);
            this.pnlWrapper.TabIndex = 109;
            // 
            // dgLast10
            // 
            this.dgLast10.AllowUserToAddRows = false;
            this.dgLast10.AllowUserToDeleteRows = false;
            this.dgLast10.AllowUserToResizeColumns = false;
            this.dgLast10.AllowUserToResizeRows = false;
            this.dgLast10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgLast10.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgLast10.BackgroundColor = System.Drawing.Color.White;
            this.dgLast10.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgLast10.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgLast10.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgLast10.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgLast10.ColumnHeadersHeight = 48;
            this.dgLast10.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgLast10.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grdDateTime,
            this.grdDescription,
            this.grdValue,
            this.grdSerial,
            this.grdUser});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgLast10.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgLast10.EnableHeadersVisualStyles = false;
            this.dgLast10.Font = new System.Drawing.Font("Tahoma", 12F);
            this.dgLast10.Location = new System.Drawing.Point(4, 137);
            this.dgLast10.MultiSelect = false;
            this.dgLast10.Name = "dgLast10";
            this.dgLast10.ReadOnly = true;
            this.dgLast10.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgLast10.RowHeadersVisible = false;
            this.dgLast10.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgLast10.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgLast10.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Maroon;
            this.dgLast10.RowTemplate.DividerHeight = 1;
            this.dgLast10.RowTemplate.Height = 48;
            this.dgLast10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgLast10.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgLast10.ShowCellErrors = false;
            this.dgLast10.ShowCellToolTips = false;
            this.dgLast10.ShowEditingIcon = false;
            this.dgLast10.ShowRowErrors = false;
            this.dgLast10.Size = new System.Drawing.Size(849, 469);
            this.dgLast10.TabIndex = 109;
            this.dgLast10.TabStop = false;
            // 
            // grdDateTime
            // 
            this.grdDateTime.HeaderText = "Date & Time";
            this.grdDateTime.MinimumWidth = 70;
            this.grdDateTime.Name = "grdDateTime";
            this.grdDateTime.ReadOnly = true;
            // 
            // grdDescription
            // 
            this.grdDescription.HeaderText = "Description";
            this.grdDescription.MinimumWidth = 100;
            this.grdDescription.Name = "grdDescription";
            this.grdDescription.ReadOnly = true;
            // 
            // grdValue
            // 
            this.grdValue.HeaderText = "Value";
            this.grdValue.MinimumWidth = 90;
            this.grdValue.Name = "grdValue";
            this.grdValue.ReadOnly = true;
            // 
            // grdSerial
            // 
            this.grdSerial.HeaderText = "Serial/Meter";
            this.grdSerial.MinimumWidth = 130;
            this.grdSerial.Name = "grdSerial";
            this.grdSerial.ReadOnly = true;
            // 
            // grdUser
            // 
            this.grdUser.HeaderText = "User";
            this.grdUser.MinimumWidth = 130;
            this.grdUser.Name = "grdUser";
            this.grdUser.ReadOnly = true;
            // 
            // frmPrintLast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1274, 739);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlKeyboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrintLast";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmSettingsPrint_Load);
            this.pnlRefInput.ResumeLayout(false);
            this.pnlRefInput.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooterLogedin.ResumeLayout(false);
            this.pnlFooterRHS.ResumeLayout(false);
            this.pnlKeyboard.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlWrapper.ResumeLayout(false);
            this.pnlWrapper.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLast10)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.RadioButton rdoFilterType0;
        private System.Windows.Forms.RadioButton rdoFilterType1;
        private System.Windows.Forms.RadioButton rdoFilterType2;
        private System.Windows.Forms.RadioButton rdoFilterType3;
        private System.Windows.Forms.Label lblReprintSerialMeter;
        private System.Windows.Forms.TextBox txtReprint;
        private System.Windows.Forms.Panel pnlRefInput;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlFooterLogedin;
        private System.Windows.Forms.Button btnMainClose;
        private System.Windows.Forms.Panel pnlFooterRHS;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Panel pnlKeyboard;
        private virtualKeyboard virtualKeyboard1;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlWrapper;
        private System.Windows.Forms.DataGridView dgLast10;
        private System.Windows.Forms.DataGridViewTextBoxColumn grdDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn grdDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn grdValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn grdSerial;
        private System.Windows.Forms.DataGridViewTextBoxColumn grdUser;
        private System.Windows.Forms.Button btnSalesHistory;
        private System.Windows.Forms.Button btnReprint;
    }
}
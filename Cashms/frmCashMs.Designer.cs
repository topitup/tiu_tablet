namespace cashms
{
    partial class frmCashMs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCashMs));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnpCustomerSelector = new System.Windows.Forms.Panel();
            this.btnProvider1 = new System.Windows.Forms.Button();
            this.versionlabel = new System.Windows.Forms.Label();
            this.btnCashMxHistory = new System.Windows.Forms.Button();
            this.pnlWrapper = new System.Windows.Forms.Panel();
            this.lblNoPaper = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnPrintStoreCopy = new System.Windows.Forms.Button();
            this.pnlComplete = new System.Windows.Forms.Panel();
            this.lblProcessedOk = new System.Windows.Forms.Label();
            this.pnlaccpayment = new System.Windows.Forms.Panel();
            this.txtDriverCell = new System.Windows.Forms.TextBox();
            this.txtLoadNo = new System.Windows.Forms.TextBox();
            this.txtDriverNo = new System.Windows.Forms.TextBox();
            this.txtPONumber = new System.Windows.Forms.TextBox();
            this.txtRandValue = new System.Windows.Forms.TextBox();
            this.picRandBg = new System.Windows.Forms.PictureBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.btn_cashms_clear = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLoadNoPre = new System.Windows.Forms.TextBox();
            this.lblload = new System.Windows.Forms.Label();
            this.lbldriver1 = new System.Windows.Forms.Label();
            this.lbldrivercell = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblload2 = new System.Windows.Forms.Label();
            this.lbldriver2 = new System.Windows.Forms.Label();
            this.pnlSalesRpt = new System.Windows.Forms.Panel();
            this.btnSRFilter = new System.Windows.Forms.Button();
            this.btnSRClose = new System.Windows.Forms.Button();
            this.btnSRReprint = new System.Windows.Forms.Button();
            this.txtCashMsSearch = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlSalesRptBreak = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.cboEday = new System.Windows.Forms.ComboBox();
            this.cboEyear = new System.Windows.Forms.ComboBox();
            this.cboEmonth = new System.Windows.Forms.ComboBox();
            this.cboSday = new System.Windows.Forms.ComboBox();
            this.cboSyear = new System.Windows.Forms.ComboBox();
            this.cboSmonth = new System.Windows.Forms.ComboBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlFooterRHS = new System.Windows.Forms.Panel();
            this.btnProcessPayment = new System.Windows.Forms.Button();
            this.pnlFooterLogedin = new System.Windows.Forms.Panel();
            this.btn_admin_report = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlKeyboard = new System.Windows.Forms.Panel();
            this.tmr_download_images = new System.Windows.Forms.Timer(this.components);
            this.tmr_delayed_load = new System.Windows.Forms.Timer(this.components);
            this.virtualKeyboard1 = new TopitUp.virtualKeyboard();
            this.pnlMain.SuspendLayout();
            this.pnpCustomerSelector.SuspendLayout();
            this.pnlWrapper.SuspendLayout();
            this.pnlComplete.SuspendLayout();
            this.pnlaccpayment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRandBg)).BeginInit();
            this.pnlSalesRpt.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlFooterRHS.SuspendLayout();
            this.pnlFooterLogedin.SuspendLayout();
            this.pnlKeyboard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnpCustomerSelector);
            this.pnlMain.Controls.Add(this.pnlWrapper);
            this.pnlMain.Controls.Add(this.pnlSalesRpt);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(880, 678);
            this.pnlMain.TabIndex = 94;
            // 
            // pnpCustomerSelector
            // 
            this.pnpCustomerSelector.BackColor = System.Drawing.Color.White;
            this.pnpCustomerSelector.Controls.Add(this.btnProvider1);
            this.pnpCustomerSelector.Controls.Add(this.versionlabel);
            this.pnpCustomerSelector.Controls.Add(this.btnCashMxHistory);
            this.pnpCustomerSelector.Location = new System.Drawing.Point(8, 600);
            this.pnpCustomerSelector.Name = "pnpCustomerSelector";
            this.pnpCustomerSelector.Size = new System.Drawing.Size(845, 391);
            this.pnpCustomerSelector.TabIndex = 17;
            // 
            // btnProvider1
            // 
            this.btnProvider1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnProvider1.BackColor = System.Drawing.Color.White;
            this.btnProvider1.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnProvider1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnProvider1.Location = new System.Drawing.Point(52, 49);
            this.btnProvider1.Name = "btnProvider1";
            this.btnProvider1.Size = new System.Drawing.Size(244, 80);
            this.btnProvider1.TabIndex = 150;
            this.btnProvider1.Text = "Peninsula Beverages";
            this.btnProvider1.UseVisualStyleBackColor = false;
            this.btnProvider1.Click += new System.EventHandler(this.btnProvider1_Click);
            // 
            // versionlabel
            // 
            this.versionlabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.versionlabel.Font = new System.Drawing.Font("Tahoma", 9F);
            this.versionlabel.ForeColor = System.Drawing.Color.Gray;
            this.versionlabel.Location = new System.Drawing.Point(231, 309);
            this.versionlabel.Name = "versionlabel";
            this.versionlabel.Size = new System.Drawing.Size(100, 20);
            this.versionlabel.TabIndex = 0;
            this.versionlabel.Text = "version";
            // 
            // btnCashMxHistory
            // 
            this.btnCashMxHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCashMxHistory.BackColor = System.Drawing.Color.White;
            this.btnCashMxHistory.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnCashMxHistory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCashMxHistory.Location = new System.Drawing.Point(52, 276);
            this.btnCashMxHistory.Name = "btnCashMxHistory";
            this.btnCashMxHistory.Size = new System.Drawing.Size(164, 80);
            this.btnCashMxHistory.TabIndex = 49;
            this.btnCashMxHistory.Text = "History";
            this.btnCashMxHistory.UseVisualStyleBackColor = false;
            this.btnCashMxHistory.Click += new System.EventHandler(this.btnCashMxHistory_Click);
            // 
            // pnlWrapper
            // 
            this.pnlWrapper.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlWrapper.Controls.Add(this.lblNoPaper);
            this.pnlWrapper.Controls.Add(this.lblDescription);
            this.pnlWrapper.Controls.Add(this.btnPrintStoreCopy);
            this.pnlWrapper.Controls.Add(this.pnlComplete);
            this.pnlWrapper.Controls.Add(this.pnlaccpayment);
            this.pnlWrapper.Location = new System.Drawing.Point(14, 54);
            this.pnlWrapper.Name = "pnlWrapper";
            this.pnlWrapper.Size = new System.Drawing.Size(851, 545);
            this.pnlWrapper.TabIndex = 15;
            // 
            // lblNoPaper
            // 
            this.lblNoPaper.Font = new System.Drawing.Font("Tahoma", 14F);
            this.lblNoPaper.ForeColor = System.Drawing.Color.Red;
            this.lblNoPaper.Location = new System.Drawing.Point(128, 72);
            this.lblNoPaper.Name = "lblNoPaper";
            this.lblNoPaper.Size = new System.Drawing.Size(574, 27);
            this.lblNoPaper.TabIndex = 66;
            this.lblNoPaper.Text = "Please check paper! Click Process Payment to Continue.";
            this.lblNoPaper.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblNoPaper.Visible = false;
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Tahoma", 18F);
            this.lblDescription.Location = new System.Drawing.Point(159, 28);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(514, 45);
            this.lblDescription.TabIndex = 67;
            this.lblDescription.Text = "Peninsula Beverages";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnPrintStoreCopy
            // 
            this.btnPrintStoreCopy.BackColor = System.Drawing.Color.Maroon;
            this.btnPrintStoreCopy.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnPrintStoreCopy.ForeColor = System.Drawing.Color.White;
            this.btnPrintStoreCopy.Location = new System.Drawing.Point(637, 279);
            this.btnPrintStoreCopy.Name = "btnPrintStoreCopy";
            this.btnPrintStoreCopy.Size = new System.Drawing.Size(192, 80);
            this.btnPrintStoreCopy.TabIndex = 63;
            this.btnPrintStoreCopy.Text = "Print Store Copy";
            this.btnPrintStoreCopy.UseVisualStyleBackColor = false;
            this.btnPrintStoreCopy.Visible = false;
            this.btnPrintStoreCopy.Click += new System.EventHandler(this.btnPrintStoreCopy_Click);
            // 
            // pnlComplete
            // 
            this.pnlComplete.BackColor = System.Drawing.Color.White;
            this.pnlComplete.Controls.Add(this.lblProcessedOk);
            this.pnlComplete.Location = new System.Drawing.Point(142, 400);
            this.pnlComplete.Name = "pnlComplete";
            this.pnlComplete.Size = new System.Drawing.Size(577, 127);
            this.pnlComplete.TabIndex = 3;
            this.pnlComplete.Visible = false;
            // 
            // lblProcessedOk
            // 
            this.lblProcessedOk.Font = new System.Drawing.Font("Tahoma", 16F);
            this.lblProcessedOk.ForeColor = System.Drawing.Color.Green;
            this.lblProcessedOk.Location = new System.Drawing.Point(138, 58);
            this.lblProcessedOk.Name = "lblProcessedOk";
            this.lblProcessedOk.Size = new System.Drawing.Size(313, 24);
            this.lblProcessedOk.TabIndex = 0;
            this.lblProcessedOk.Text = "Payment has been processed.";
            // 
            // pnlaccpayment
            // 
            this.pnlaccpayment.BackColor = System.Drawing.Color.White;
            this.pnlaccpayment.Controls.Add(this.txtDriverCell);
            this.pnlaccpayment.Controls.Add(this.txtLoadNo);
            this.pnlaccpayment.Controls.Add(this.txtDriverNo);
            this.pnlaccpayment.Controls.Add(this.txtPONumber);
            this.pnlaccpayment.Controls.Add(this.txtRandValue);
            this.pnlaccpayment.Controls.Add(this.picRandBg);
            this.pnlaccpayment.Controls.Add(this.lblAmount);
            this.pnlaccpayment.Controls.Add(this.btn_cashms_clear);
            this.pnlaccpayment.Controls.Add(this.label5);
            this.pnlaccpayment.Controls.Add(this.txtLoadNoPre);
            this.pnlaccpayment.Controls.Add(this.lblload);
            this.pnlaccpayment.Controls.Add(this.lbldriver1);
            this.pnlaccpayment.Controls.Add(this.lbldrivercell);
            this.pnlaccpayment.Controls.Add(this.label1);
            this.pnlaccpayment.Controls.Add(this.lblload2);
            this.pnlaccpayment.Controls.Add(this.lbldriver2);
            this.pnlaccpayment.Location = new System.Drawing.Point(23, 116);
            this.pnlaccpayment.Name = "pnlaccpayment";
            this.pnlaccpayment.Size = new System.Drawing.Size(600, 244);
            this.pnlaccpayment.TabIndex = 1;
            // 
            // txtDriverCell
            // 
            this.txtDriverCell.Font = new System.Drawing.Font("Tahoma", 22F);
            this.txtDriverCell.Location = new System.Drawing.Point(372, 63);
            this.txtDriverCell.MaxLength = 10;
            this.txtDriverCell.Name = "txtDriverCell";
            this.txtDriverCell.Size = new System.Drawing.Size(225, 43);
            this.txtDriverCell.TabIndex = 86;
            // 
            // txtLoadNo
            // 
            this.txtLoadNo.Font = new System.Drawing.Font("Tahoma", 22F);
            this.txtLoadNo.Location = new System.Drawing.Point(453, 5);
            this.txtLoadNo.MaxLength = 6;
            this.txtLoadNo.Name = "txtLoadNo";
            this.txtLoadNo.Size = new System.Drawing.Size(144, 43);
            this.txtLoadNo.TabIndex = 85;
            // 
            // txtDriverNo
            // 
            this.txtDriverNo.Font = new System.Drawing.Font("Tahoma", 22F);
            this.txtDriverNo.Location = new System.Drawing.Point(112, 63);
            this.txtDriverNo.MaxLength = 4;
            this.txtDriverNo.Name = "txtDriverNo";
            this.txtDriverNo.Size = new System.Drawing.Size(144, 43);
            this.txtDriverNo.TabIndex = 84;
            // 
            // txtPONumber
            // 
            this.txtPONumber.Font = new System.Drawing.Font("Tahoma", 22F);
            this.txtPONumber.Location = new System.Drawing.Point(112, 8);
            this.txtPONumber.MaxLength = 6;
            this.txtPONumber.Name = "txtPONumber";
            this.txtPONumber.Size = new System.Drawing.Size(144, 43);
            this.txtPONumber.TabIndex = 83;
            // 
            // txtRandValue
            // 
            this.txtRandValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRandValue.Font = new System.Drawing.Font("Tahoma", 26F);
            this.txtRandValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(203)))), ((int)(((byte)(51)))));
            this.txtRandValue.Location = new System.Drawing.Point(164, 136);
            this.txtRandValue.MaxLength = 6;
            this.txtRandValue.Name = "txtRandValue";
            this.txtRandValue.Size = new System.Drawing.Size(155, 42);
            this.txtRandValue.TabIndex = 82;
            this.txtRandValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRandValue_KeyPress);
            this.txtRandValue.LostFocus += new System.EventHandler(this.numericTextBox_LostFocus);
            // 
            // picRandBg
            // 
            this.picRandBg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.picRandBg.Location = new System.Drawing.Point(115, 124);
            this.picRandBg.Name = "picRandBg";
            this.picRandBg.Size = new System.Drawing.Size(210, 67);
            this.picRandBg.TabIndex = 81;
            this.picRandBg.TabStop = false;
            // 
            // lblAmount
            // 
            this.lblAmount.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblAmount.Location = new System.Drawing.Point(14, 143);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(95, 24);
            this.lblAmount.TabIndex = 0;
            this.lblAmount.Text = "Amount";
            // 
            // btn_cashms_clear
            // 
            this.btn_cashms_clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_cashms_clear.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btn_cashms_clear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_cashms_clear.Location = new System.Drawing.Point(372, 125);
            this.btn_cashms_clear.Name = "btn_cashms_clear";
            this.btn_cashms_clear.Size = new System.Drawing.Size(118, 67);
            this.btn_cashms_clear.TabIndex = 72;
            this.btn_cashms_clear.Text = "Clear";
            this.btn_cashms_clear.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(11, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 73;
            this.label5.Text = "6 Digit Code";
            // 
            // txtLoadNoPre
            // 
            this.txtLoadNoPre.Font = new System.Drawing.Font("Tahoma", 22F);
            this.txtLoadNoPre.Location = new System.Drawing.Point(372, 5);
            this.txtLoadNoPre.MaxLength = 3;
            this.txtLoadNoPre.Name = "txtLoadNoPre";
            this.txtLoadNoPre.Size = new System.Drawing.Size(78, 43);
            this.txtLoadNoPre.TabIndex = 64;
            // 
            // lblload
            // 
            this.lblload.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblload.Location = new System.Drawing.Point(271, 8);
            this.lblload.Name = "lblload";
            this.lblload.Size = new System.Drawing.Size(95, 24);
            this.lblload.TabIndex = 74;
            this.lblload.Text = "Load #";
            // 
            // lbldriver1
            // 
            this.lbldriver1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbldriver1.Location = new System.Drawing.Point(13, 63);
            this.lbldriver1.Name = "lbldriver1";
            this.lbldriver1.Size = new System.Drawing.Size(95, 24);
            this.lbldriver1.TabIndex = 75;
            this.lbldriver1.Text = "Driver #";
            // 
            // lbldrivercell
            // 
            this.lbldrivercell.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbldrivercell.Location = new System.Drawing.Point(270, 72);
            this.lbldrivercell.Name = "lbldrivercell";
            this.lbldrivercell.Size = new System.Drawing.Size(96, 24);
            this.lbldrivercell.TabIndex = 77;
            this.lbldrivercell.Text = "Driver Cell";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label1.Location = new System.Drawing.Point(11, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 24);
            this.label1.TabIndex = 78;
            this.label1.Text = "Customer#";
            // 
            // lblload2
            // 
            this.lblload2.ForeColor = System.Drawing.Color.Maroon;
            this.lblload2.Location = new System.Drawing.Point(273, 31);
            this.lblload2.Name = "lblload2";
            this.lblload2.Size = new System.Drawing.Size(103, 25);
            this.lblload2.TabIndex = 79;
            this.lblload2.Text = "3 Alpha 6 Digits";
            // 
            // lbldriver2
            // 
            this.lbldriver2.ForeColor = System.Drawing.Color.Maroon;
            this.lbldriver2.Location = new System.Drawing.Point(14, 87);
            this.lbldriver2.Name = "lbldriver2";
            this.lbldriver2.Size = new System.Drawing.Size(94, 20);
            this.lbldriver2.TabIndex = 80;
            this.lbldriver2.Text = "4 Digit Code";
            // 
            // pnlSalesRpt
            // 
            this.pnlSalesRpt.BackColor = System.Drawing.Color.White;
            this.pnlSalesRpt.Controls.Add(this.btnSRFilter);
            this.pnlSalesRpt.Controls.Add(this.btnSRClose);
            this.pnlSalesRpt.Controls.Add(this.btnSRReprint);
            this.pnlSalesRpt.Controls.Add(this.txtCashMsSearch);
            this.pnlSalesRpt.Controls.Add(this.label8);
            this.pnlSalesRpt.Controls.Add(this.pnlSalesRptBreak);
            this.pnlSalesRpt.Controls.Add(this.label22);
            this.pnlSalesRpt.Controls.Add(this.label23);
            this.pnlSalesRpt.Controls.Add(this.cboEday);
            this.pnlSalesRpt.Controls.Add(this.cboEyear);
            this.pnlSalesRpt.Controls.Add(this.cboEmonth);
            this.pnlSalesRpt.Controls.Add(this.cboSday);
            this.pnlSalesRpt.Controls.Add(this.cboSyear);
            this.pnlSalesRpt.Controls.Add(this.cboSmonth);
            this.pnlSalesRpt.Location = new System.Drawing.Point(763, 26);
            this.pnlSalesRpt.Name = "pnlSalesRpt";
            this.pnlSalesRpt.Size = new System.Drawing.Size(800, 431);
            this.pnlSalesRpt.TabIndex = 19;
            this.pnlSalesRpt.Visible = false;
            // 
            // btnSRFilter
            // 
            this.btnSRFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSRFilter.BackColor = System.Drawing.Color.White;
            this.btnSRFilter.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnSRFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSRFilter.Location = new System.Drawing.Point(610, 18);
            this.btnSRFilter.Name = "btnSRFilter";
            this.btnSRFilter.Size = new System.Drawing.Size(160, 80);
            this.btnSRFilter.TabIndex = 153;
            this.btnSRFilter.Text = "Filter";
            this.btnSRFilter.UseVisualStyleBackColor = false;
            this.btnSRFilter.Click += new System.EventHandler(this.btnSRFilter_Click_1);
            // 
            // btnSRClose
            // 
            this.btnSRClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSRClose.BackColor = System.Drawing.Color.White;
            this.btnSRClose.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnSRClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSRClose.Location = new System.Drawing.Point(610, 330);
            this.btnSRClose.Name = "btnSRClose";
            this.btnSRClose.Size = new System.Drawing.Size(160, 80);
            this.btnSRClose.TabIndex = 152;
            this.btnSRClose.Text = "Close";
            this.btnSRClose.UseVisualStyleBackColor = false;
            this.btnSRClose.Click += new System.EventHandler(this.btnSRClose_Click);
            // 
            // btnSRReprint
            // 
            this.btnSRReprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSRReprint.BackColor = System.Drawing.Color.White;
            this.btnSRReprint.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnSRReprint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSRReprint.Location = new System.Drawing.Point(15, 330);
            this.btnSRReprint.Name = "btnSRReprint";
            this.btnSRReprint.Size = new System.Drawing.Size(160, 80);
            this.btnSRReprint.TabIndex = 151;
            this.btnSRReprint.Text = "REPRINT";
            this.btnSRReprint.UseVisualStyleBackColor = false;
            this.btnSRReprint.Click += new System.EventHandler(this.btnSRReprint_Click);
            // 
            // txtCashMsSearch
            // 
            this.txtCashMsSearch.Font = new System.Drawing.Font("Tahoma", 18F);
            this.txtCashMsSearch.Location = new System.Drawing.Point(145, 89);
            this.txtCashMsSearch.MaxLength = 6;
            this.txtCashMsSearch.Name = "txtCashMsSearch";
            this.txtCashMsSearch.Size = new System.Drawing.Size(251, 36);
            this.txtCashMsSearch.TabIndex = 113;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label8.Location = new System.Drawing.Point(13, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 27);
            this.label8.TabIndex = 114;
            this.label8.Text = "Load Number:";
            // 
            // pnlSalesRptBreak
            // 
            this.pnlSalesRptBreak.BackColor = System.Drawing.Color.Black;
            this.pnlSalesRptBreak.Location = new System.Drawing.Point(15, 317);
            this.pnlSalesRptBreak.Name = "pnlSalesRptBreak";
            this.pnlSalesRptBreak.Size = new System.Drawing.Size(755, 2);
            this.pnlSalesRptBreak.TabIndex = 115;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label22.Location = new System.Drawing.Point(52, 52);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(83, 27);
            this.label22.TabIndex = 116;
            this.label22.Text = "To Date:";
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label23.Location = new System.Drawing.Point(35, 18);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(105, 27);
            this.label23.TabIndex = 117;
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
            this.cboEday.Location = new System.Drawing.Point(145, 50);
            this.cboEday.Name = "cboEday";
            this.cboEday.Size = new System.Drawing.Size(60, 31);
            this.cboEday.TabIndex = 33;
            // 
            // cboEyear
            // 
            this.cboEyear.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.cboEyear.Location = new System.Drawing.Point(432, 50);
            this.cboEyear.Name = "cboEyear";
            this.cboEyear.Size = new System.Drawing.Size(107, 31);
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
            this.cboEmonth.Location = new System.Drawing.Point(240, 50);
            this.cboEmonth.Name = "cboEmonth";
            this.cboEmonth.Size = new System.Drawing.Size(156, 31);
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
            this.cboSday.Location = new System.Drawing.Point(145, 15);
            this.cboSday.Name = "cboSday";
            this.cboSday.Size = new System.Drawing.Size(60, 31);
            this.cboSday.TabIndex = 30;
            // 
            // cboSyear
            // 
            this.cboSyear.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.cboSyear.Location = new System.Drawing.Point(432, 16);
            this.cboSyear.Name = "cboSyear";
            this.cboSyear.Size = new System.Drawing.Size(107, 31);
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
            this.cboSmonth.Location = new System.Drawing.Point(240, 15);
            this.cboSmonth.Name = "cboSmonth";
            this.cboSmonth.Size = new System.Drawing.Size(156, 31);
            this.cboSmonth.TabIndex = 28;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.pnlFooter.Controls.Add(this.pnlFooterRHS);
            this.pnlFooter.Controls.Add(this.pnlFooterLogedin);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 678);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(880, 90);
            this.pnlFooter.TabIndex = 93;
            // 
            // pnlFooterRHS
            // 
            this.pnlFooterRHS.Controls.Add(this.btnProcessPayment);
            this.pnlFooterRHS.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFooterRHS.Location = new System.Drawing.Point(629, 0);
            this.pnlFooterRHS.Name = "pnlFooterRHS";
            this.pnlFooterRHS.Size = new System.Drawing.Size(251, 90);
            this.pnlFooterRHS.TabIndex = 37;
            // 
            // btnProcessPayment
            // 
            this.btnProcessPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcessPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnProcessPayment.FlatAppearance.BorderSize = 0;
            this.btnProcessPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcessPayment.Font = new System.Drawing.Font("Tahoma", 20F);
            this.btnProcessPayment.ForeColor = System.Drawing.Color.White;
            this.btnProcessPayment.Image = ((System.Drawing.Image)(resources.GetObject("btnProcessPayment.Image")));
            this.btnProcessPayment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcessPayment.Location = new System.Drawing.Point(0, 1);
            this.btnProcessPayment.Name = "btnProcessPayment";
            this.btnProcessPayment.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnProcessPayment.Size = new System.Drawing.Size(250, 89);
            this.btnProcessPayment.TabIndex = 41;
            this.btnProcessPayment.TabStop = false;
            this.btnProcessPayment.Text = "Process";
            this.btnProcessPayment.UseVisualStyleBackColor = false;
            this.btnProcessPayment.Click += new System.EventHandler(this.btnProcessPayment_Click);
            // 
            // pnlFooterLogedin
            // 
            this.pnlFooterLogedin.Controls.Add(this.btn_admin_report);
            this.pnlFooterLogedin.Controls.Add(this.btnClose);
            this.pnlFooterLogedin.Location = new System.Drawing.Point(0, 1);
            this.pnlFooterLogedin.Name = "pnlFooterLogedin";
            this.pnlFooterLogedin.Size = new System.Drawing.Size(629, 90);
            this.pnlFooterLogedin.TabIndex = 38;
            // 
            // btn_admin_report
            // 
            this.btn_admin_report.BackColor = System.Drawing.Color.DimGray;
            this.btn_admin_report.FlatAppearance.BorderSize = 0;
            this.btn_admin_report.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_admin_report.Font = new System.Drawing.Font("Tahoma", 20F);
            this.btn_admin_report.ForeColor = System.Drawing.Color.White;
            this.btn_admin_report.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_admin_report.Location = new System.Drawing.Point(251, 1);
            this.btn_admin_report.Name = "btn_admin_report";
            this.btn_admin_report.Size = new System.Drawing.Size(250, 89);
            this.btn_admin_report.TabIndex = 43;
            this.btn_admin_report.TabStop = false;
            this.btn_admin_report.Text = "Admin Report";
            this.btn_admin_report.UseVisualStyleBackColor = false;
            this.btn_admin_report.Visible = false;
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
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
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
            // pnlKeyboard
            // 
            this.pnlKeyboard.Controls.Add(this.virtualKeyboard1);
            this.pnlKeyboard.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlKeyboard.Location = new System.Drawing.Point(880, 0);
            this.pnlKeyboard.Name = "pnlKeyboard";
            this.pnlKeyboard.Size = new System.Drawing.Size(400, 768);
            this.pnlKeyboard.TabIndex = 146;
            // 
            // tmr_download_images
            // 
            this.tmr_download_images.Interval = 1500;
            this.tmr_download_images.Tick += new System.EventHandler(this.tmr_download_images_Tick);
            // 
            // tmr_delayed_load
            // 
            this.tmr_delayed_load.Interval = 800;
            this.tmr_delayed_load.Tick += new System.EventHandler(this.tmr_delayed_load_Tick_1);
            // 
            // virtualKeyboard1
            // 
            this.virtualKeyboard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.virtualKeyboard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.virtualKeyboard1.Location = new System.Drawing.Point(0, 0);
            this.virtualKeyboard1.Name = "virtualKeyboard1";
            this.virtualKeyboard1.Size = new System.Drawing.Size(400, 768);
            this.virtualKeyboard1.TabIndex = 0;
            // 
            // frmCashMs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 768);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlKeyboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCashMs";
            this.Text = "frmCashManagement";
            this.Load += new System.EventHandler(this.frmCashManagement_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnpCustomerSelector.ResumeLayout(false);
            this.pnlWrapper.ResumeLayout(false);
            this.pnlComplete.ResumeLayout(false);
            this.pnlaccpayment.ResumeLayout(false);
            this.pnlaccpayment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRandBg)).EndInit();
            this.pnlSalesRpt.ResumeLayout(false);
            this.pnlSalesRpt.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooterRHS.ResumeLayout(false);
            this.pnlFooterLogedin.ResumeLayout(false);
            this.pnlKeyboard.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlFooterRHS;
        private System.Windows.Forms.Button btnProcessPayment;
        private System.Windows.Forms.Panel pnlFooterLogedin;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btn_admin_report;
        private System.Windows.Forms.Panel pnlWrapper;
        private System.Windows.Forms.Panel pnlaccpayment;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Button btn_cashms_clear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLoadNoPre;
        private System.Windows.Forms.Label lblload;
        private System.Windows.Forms.Label lbldriver1;
        private System.Windows.Forms.Label lbldrivercell;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblload2;
        private System.Windows.Forms.Label lbldriver2;
        private System.Windows.Forms.Panel pnlKeyboard;
        private TopitUp.virtualKeyboard virtualKeyboard1;
        private System.Windows.Forms.Panel pnpCustomerSelector;
        private System.Windows.Forms.Label versionlabel;
        private System.Windows.Forms.Button btnCashMxHistory;
        private System.Windows.Forms.Label lblNoPaper;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnPrintStoreCopy;
        private System.Windows.Forms.Panel pnlComplete;
        private System.Windows.Forms.Label lblProcessedOk;
        private System.Windows.Forms.Button btnProvider1;
        private System.Windows.Forms.PictureBox picRandBg;
        private System.Windows.Forms.TextBox txtRandValue;
        private System.Windows.Forms.TextBox txtDriverCell;
        private System.Windows.Forms.TextBox txtLoadNo;
        private System.Windows.Forms.TextBox txtDriverNo;
        private System.Windows.Forms.TextBox txtPONumber;
        private System.Windows.Forms.Timer tmr_download_images;
        private System.Windows.Forms.Timer tmr_delayed_load;
        private System.Windows.Forms.Panel pnlSalesRpt;
        private System.Windows.Forms.Button btnSRClose;
        private System.Windows.Forms.Button btnSRReprint;
        private System.Windows.Forms.TextBox txtCashMsSearch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pnlSalesRptBreak;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cboEday;
        private System.Windows.Forms.ComboBox cboEyear;
        private System.Windows.Forms.ComboBox cboEmonth;
        private System.Windows.Forms.ComboBox cboSday;
        private System.Windows.Forms.ComboBox cboSyear;
        private System.Windows.Forms.ComboBox cboSmonth;
        private System.Windows.Forms.Button btnSRFilter;
    }
}
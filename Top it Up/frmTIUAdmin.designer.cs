namespace TopitUp
{
    partial class frmTIUAdmin
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tabControlSettings = new System.Windows.Forms.TabControl();
            this.tbLogin = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblAllSettings = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOTP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCell = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnSMS = new System.Windows.Forms.Button();
            this.tbConnection = new System.Windows.Forms.TabPage();
            this.btnTextConnection = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.connLocation = new System.Windows.Forms.TextBox();
            this.ConnPort = new System.Windows.Forms.TextBox();
            this.ConnURL = new System.Windows.Forms.TextBox();
            this.ConnHttp = new System.Windows.Forms.ComboBox();
            this.pnlConnTest = new System.Windows.Forms.TextBox();
            this.tbSettings = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.chkCustomerMin = new System.Windows.Forms.CheckBox();
            this.btnUpdateFirewall = new System.Windows.Forms.Button();
            this.pnlDivider = new System.Windows.Forms.Panel();
            this.btnShowPrinters = new System.Windows.Forms.Button();
            this.btnSoftwareUpdate = new System.Windows.Forms.Button();
            this.btnShutdown = new System.Windows.Forms.Button();
            this.btnLockdown = new System.Windows.Forms.Button();
            this.btnTaskManager = new System.Windows.Forms.Button();
            this.btnServiceManager = new System.Windows.Forms.Button();
            this.btnExitApplication = new System.Windows.Forms.Button();
            this.optServerTx = new System.Windows.Forms.RadioButton();
            this.btnSettingsSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.optServerDemo = new System.Windows.Forms.RadioButton();
            this.tbRegisterPC = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRefreshEMIE = new System.Windows.Forms.Button();
            this.txtIMEI = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAssetId = new System.Windows.Forms.Label();
            this.txtAssetId = new System.Windows.Forms.TextBox();
            this.lblStep1 = new System.Windows.Forms.Label();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRegisterPC = new System.Windows.Forms.Button();
            this.tbLicense = new System.Windows.Forms.TabPage();
            this.lblLicenseDone = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSecret = new System.Windows.Forms.Label();
            this.btnSecret = new System.Windows.Forms.Button();
            this.txtSecret = new System.Windows.Forms.TextBox();
            this.btnActivate = new System.Windows.Forms.Button();
            this.lblGeneralLicense = new System.Windows.Forms.Label();
            this.btnLoadItems = new System.Windows.Forms.Button();
            this.lblLicense = new System.Windows.Forms.Label();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.pnlKeyboard = new System.Windows.Forms.Panel();
            this.virtualKeyboard1 = new TopitUp.virtualKeyboard();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlFooterLogedin = new System.Windows.Forms.Panel();
            this.pnlFooterRHS = new System.Windows.Forms.Panel();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.lblFirewallStatus = new System.Windows.Forms.Label();
            this.btnFirewallDisable = new System.Windows.Forms.Button();
            this.btnFirewallEnable = new System.Windows.Forms.Button();
            this.btnShowFirewall = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.tabControlSettings.SuspendLayout();
            this.tbLogin.SuspendLayout();
            this.tbConnection.SuspendLayout();
            this.tbSettings.SuspendLayout();
            this.tbRegisterPC.SuspendLayout();
            this.tbLicense.SuspendLayout();
            this.pnlKeyboard.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlFooterLogedin.SuspendLayout();
            this.pnlFooterRHS.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.tabControlSettings);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(880, 900);
            this.pnlMain.TabIndex = 0;
            // 
            // tabControlSettings
            // 
            this.tabControlSettings.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tabControlSettings.Controls.Add(this.tbLogin);
            this.tabControlSettings.Controls.Add(this.tbConnection);
            this.tabControlSettings.Controls.Add(this.tbSettings);
            this.tabControlSettings.Controls.Add(this.tbRegisterPC);
            this.tabControlSettings.Controls.Add(this.tbLicense);
            this.tabControlSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlSettings.ForeColor = System.Drawing.Color.White;
            this.tabControlSettings.ItemSize = new System.Drawing.Size(64, 40);
            this.tabControlSettings.Location = new System.Drawing.Point(12, 103);
            this.tabControlSettings.Name = "tabControlSettings";
            this.tabControlSettings.Padding = new System.Drawing.Point(10, 5);
            this.tabControlSettings.SelectedIndex = 0;
            this.tabControlSettings.Size = new System.Drawing.Size(853, 565);
            this.tabControlSettings.TabIndex = 1;
            this.tabControlSettings.SelectedIndexChanged += new System.EventHandler(this.tabControlSettings_SelectedIndexChanged);
            // 
            // tbLogin
            // 
            this.tbLogin.Controls.Add(this.panel2);
            this.tbLogin.Controls.Add(this.lblAllSettings);
            this.tbLogin.Controls.Add(this.label3);
            this.tbLogin.Controls.Add(this.txtOTP);
            this.tbLogin.Controls.Add(this.label2);
            this.tbLogin.Controls.Add(this.txtCell);
            this.tbLogin.Controls.Add(this.btnLogin);
            this.tbLogin.Controls.Add(this.btnSMS);
            this.tbLogin.ForeColor = System.Drawing.Color.White;
            this.tbLogin.Location = new System.Drawing.Point(4, 44);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tbLogin.Size = new System.Drawing.Size(845, 517);
            this.tbLogin.TabIndex = 3;
            this.tbLogin.Text = "Login";
            this.tbLogin.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Location = new System.Drawing.Point(570, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2, 445);
            this.panel2.TabIndex = 57;
            // 
            // lblAllSettings
            // 
            this.lblAllSettings.BackColor = System.Drawing.Color.White;
            this.lblAllSettings.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllSettings.ForeColor = System.Drawing.Color.Black;
            this.lblAllSettings.Location = new System.Drawing.Point(594, 40);
            this.lblAllSettings.Name = "lblAllSettings";
            this.lblAllSettings.Size = new System.Drawing.Size(223, 423);
            this.lblAllSettings.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(36, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(452, 59);
            this.label3.TabIndex = 13;
            this.label3.Text = "Step 2:\r\nLogin OTP (SMS Sent to registered cell number)";
            // 
            // txtOTP
            // 
            this.txtOTP.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOTP.Location = new System.Drawing.Point(40, 295);
            this.txtOTP.MaxLength = 8;
            this.txtOTP.Name = "txtOTP";
            this.txtOTP.PasswordChar = '*';
            this.txtOTP.Size = new System.Drawing.Size(284, 40);
            this.txtOTP.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(36, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(512, 68);
            this.label2.TabIndex = 11;
            this.label2.Text = "Step 1: \r\nCell Number (Only registered Top it Up Staff)";
            // 
            // txtCell
            // 
            this.txtCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCell.Location = new System.Drawing.Point(40, 111);
            this.txtCell.MaxLength = 25;
            this.txtCell.Name = "txtCell";
            this.txtCell.Size = new System.Drawing.Size(284, 40);
            this.txtCell.TabIndex = 0;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.White;
            this.btnLogin.FlatAppearance.BorderSize = 2;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLogin.Location = new System.Drawing.Point(348, 295);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(200, 70);
            this.btnLogin.TabIndex = 9;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnSMS
            // 
            this.btnSMS.BackColor = System.Drawing.Color.White;
            this.btnSMS.FlatAppearance.BorderSize = 2;
            this.btnSMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSMS.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnSMS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSMS.Location = new System.Drawing.Point(348, 111);
            this.btnSMS.Name = "btnSMS";
            this.btnSMS.Size = new System.Drawing.Size(200, 70);
            this.btnSMS.TabIndex = 8;
            this.btnSMS.Text = "Send SMS";
            this.btnSMS.UseVisualStyleBackColor = false;
            this.btnSMS.Click += new System.EventHandler(this.btnSMS_Click);
            // 
            // tbConnection
            // 
            this.tbConnection.Controls.Add(this.btnTextConnection);
            this.tbConnection.Controls.Add(this.button1);
            this.tbConnection.Controls.Add(this.connLocation);
            this.tbConnection.Controls.Add(this.ConnPort);
            this.tbConnection.Controls.Add(this.ConnURL);
            this.tbConnection.Controls.Add(this.ConnHttp);
            this.tbConnection.Controls.Add(this.pnlConnTest);
            this.tbConnection.Location = new System.Drawing.Point(4, 44);
            this.tbConnection.Name = "tbConnection";
            this.tbConnection.Size = new System.Drawing.Size(845, 517);
            this.tbConnection.TabIndex = 4;
            this.tbConnection.Text = "Connection";
            this.tbConnection.UseVisualStyleBackColor = true;
            // 
            // btnTextConnection
            // 
            this.btnTextConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTextConnection.BackColor = System.Drawing.Color.Maroon;
            this.btnTextConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTextConnection.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnTextConnection.ForeColor = System.Drawing.Color.White;
            this.btnTextConnection.Location = new System.Drawing.Point(529, 383);
            this.btnTextConnection.Name = "btnTextConnection";
            this.btnTextConnection.Size = new System.Drawing.Size(200, 79);
            this.btnTextConnection.TabIndex = 17;
            this.btnTextConnection.Text = "Test Connection";
            this.btnTextConnection.UseVisualStyleBackColor = false;
            this.btnTextConnection.Click += new System.EventHandler(this.btnTextConnection_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 14F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(529, 362);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 35);
            this.button1.TabIndex = 23;
            this.button1.Text = "WMI";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // connLocation
            // 
            this.connLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.connLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connLocation.Location = new System.Drawing.Point(23, 424);
            this.connLocation.MaxLength = 100;
            this.connLocation.Name = "connLocation";
            this.connLocation.Size = new System.Drawing.Size(487, 35);
            this.connLocation.TabIndex = 22;
            // 
            // ConnPort
            // 
            this.ConnPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ConnPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnPort.Location = new System.Drawing.Point(396, 383);
            this.ConnPort.MaxLength = 25;
            this.ConnPort.Name = "ConnPort";
            this.ConnPort.Size = new System.Drawing.Size(114, 35);
            this.ConnPort.TabIndex = 21;
            this.ConnPort.Text = "25";
            // 
            // ConnURL
            // 
            this.ConnURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ConnURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnURL.Location = new System.Drawing.Point(142, 383);
            this.ConnURL.MaxLength = 25;
            this.ConnURL.Name = "ConnURL";
            this.ConnURL.Size = new System.Drawing.Size(248, 35);
            this.ConnURL.TabIndex = 20;
            this.ConnURL.Text = "www.google.com";
            // 
            // ConnHttp
            // 
            this.ConnHttp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ConnHttp.FormattingEnabled = true;
            this.ConnHttp.Items.AddRange(new object[] {
            "http://",
            "https://"});
            this.ConnHttp.Location = new System.Drawing.Point(22, 383);
            this.ConnHttp.Name = "ConnHttp";
            this.ConnHttp.Size = new System.Drawing.Size(114, 33);
            this.ConnHttp.TabIndex = 19;
            this.ConnHttp.Text = "https://";
            // 
            // pnlConnTest
            // 
            this.pnlConnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlConnTest.Font = new System.Drawing.Font("Courier New", 10F);
            this.pnlConnTest.Location = new System.Drawing.Point(23, 24);
            this.pnlConnTest.Multiline = true;
            this.pnlConnTest.Name = "pnlConnTest";
            this.pnlConnTest.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.pnlConnTest.Size = new System.Drawing.Size(706, 339);
            this.pnlConnTest.TabIndex = 18;
            // 
            // tbSettings
            // 
            this.tbSettings.BackColor = System.Drawing.Color.White;
            this.tbSettings.Controls.Add(this.btnShowFirewall);
            this.tbSettings.Controls.Add(this.btnFirewallEnable);
            this.tbSettings.Controls.Add(this.btnFirewallDisable);
            this.tbSettings.Controls.Add(this.lblFirewallStatus);
            this.tbSettings.Controls.Add(this.label9);
            this.tbSettings.Controls.Add(this.chkCustomerMin);
            this.tbSettings.Controls.Add(this.btnUpdateFirewall);
            this.tbSettings.Controls.Add(this.pnlDivider);
            this.tbSettings.Controls.Add(this.btnShowPrinters);
            this.tbSettings.Controls.Add(this.btnSoftwareUpdate);
            this.tbSettings.Controls.Add(this.btnShutdown);
            this.tbSettings.Controls.Add(this.btnLockdown);
            this.tbSettings.Controls.Add(this.btnTaskManager);
            this.tbSettings.Controls.Add(this.btnServiceManager);
            this.tbSettings.Controls.Add(this.btnExitApplication);
            this.tbSettings.Controls.Add(this.optServerTx);
            this.tbSettings.Controls.Add(this.btnSettingsSave);
            this.tbSettings.Controls.Add(this.label1);
            this.tbSettings.Controls.Add(this.optServerDemo);
            this.tbSettings.Location = new System.Drawing.Point(4, 44);
            this.tbSettings.Name = "tbSettings";
            this.tbSettings.Size = new System.Drawing.Size(845, 517);
            this.tbSettings.TabIndex = 1;
            this.tbSettings.Text = "Settings";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(30, 283);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(306, 18);
            this.label9.TabIndex = 139;
            this.label9.Text = "Warning: PC only, and if customer requested.";
            // 
            // chkCustomerMin
            // 
            this.chkCustomerMin.Font = new System.Drawing.Font("Arial", 14F);
            this.chkCustomerMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkCustomerMin.Location = new System.Drawing.Point(31, 250);
            this.chkCustomerMin.Name = "chkCustomerMin";
            this.chkCustomerMin.Size = new System.Drawing.Size(291, 25);
            this.chkCustomerMin.TabIndex = 138;
            this.chkCustomerMin.Text = "Allow Customer to Minimize.";
            this.chkCustomerMin.CheckedChanged += new System.EventHandler(this.chkCustomerMin_CheckedChanged);
            // 
            // btnUpdateFirewall
            // 
            this.btnUpdateFirewall.FlatAppearance.BorderSize = 2;
            this.btnUpdateFirewall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateFirewall.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateFirewall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnUpdateFirewall.Location = new System.Drawing.Point(27, 154);
            this.btnUpdateFirewall.Name = "btnUpdateFirewall";
            this.btnUpdateFirewall.Size = new System.Drawing.Size(200, 70);
            this.btnUpdateFirewall.TabIndex = 136;
            this.btnUpdateFirewall.Text = "Import Firewall\r\nSettings";
            this.btnUpdateFirewall.Click += new System.EventHandler(this.btnUpdateFirewall_Click);
            // 
            // pnlDivider
            // 
            this.pnlDivider.BackColor = System.Drawing.Color.Gray;
            this.pnlDivider.Location = new System.Drawing.Point(27, 127);
            this.pnlDivider.Name = "pnlDivider";
            this.pnlDivider.Size = new System.Drawing.Size(777, 2);
            this.pnlDivider.TabIndex = 135;
            // 
            // btnShowPrinters
            // 
            this.btnShowPrinters.FlatAppearance.BorderSize = 2;
            this.btnShowPrinters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowPrinters.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowPrinters.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnShowPrinters.Location = new System.Drawing.Point(216, 330);
            this.btnShowPrinters.Name = "btnShowPrinters";
            this.btnShowPrinters.Size = new System.Drawing.Size(170, 70);
            this.btnShowPrinters.TabIndex = 134;
            this.btnShowPrinters.Text = "Show\r\nPrinters";
            this.btnShowPrinters.Click += new System.EventHandler(this.btnShowPrinters_Click);
            // 
            // btnSoftwareUpdate
            // 
            this.btnSoftwareUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSoftwareUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSoftwareUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSoftwareUpdate.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnSoftwareUpdate.ForeColor = System.Drawing.Color.White;
            this.btnSoftwareUpdate.Location = new System.Drawing.Point(594, 241);
            this.btnSoftwareUpdate.Name = "btnSoftwareUpdate";
            this.btnSoftwareUpdate.Size = new System.Drawing.Size(200, 70);
            this.btnSoftwareUpdate.TabIndex = 133;
            this.btnSoftwareUpdate.Text = "Software Update";
            this.btnSoftwareUpdate.UseVisualStyleBackColor = false;
            this.btnSoftwareUpdate.Click += new System.EventHandler(this.btnSoftwareUpdate_Click);
            // 
            // btnShutdown
            // 
            this.btnShutdown.FlatAppearance.BorderSize = 2;
            this.btnShutdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShutdown.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShutdown.ForeColor = System.Drawing.Color.Maroon;
            this.btnShutdown.Location = new System.Drawing.Point(594, 330);
            this.btnShutdown.Name = "btnShutdown";
            this.btnShutdown.Size = new System.Drawing.Size(200, 70);
            this.btnShutdown.TabIndex = 132;
            this.btnShutdown.Text = "Restart Windows";
            this.btnShutdown.Click += new System.EventHandler(this.btnShutdown_Click);
            // 
            // btnLockdown
            // 
            this.btnLockdown.FlatAppearance.BorderSize = 2;
            this.btnLockdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLockdown.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLockdown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLockdown.Location = new System.Drawing.Point(27, 330);
            this.btnLockdown.Name = "btnLockdown";
            this.btnLockdown.Size = new System.Drawing.Size(170, 70);
            this.btnLockdown.TabIndex = 131;
            this.btnLockdown.Text = "Open\r\nLockdown";
            this.btnLockdown.Click += new System.EventHandler(this.btnLockdown_Click);
            // 
            // btnTaskManager
            // 
            this.btnTaskManager.FlatAppearance.BorderSize = 2;
            this.btnTaskManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaskManager.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaskManager.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnTaskManager.Location = new System.Drawing.Point(215, 416);
            this.btnTaskManager.Name = "btnTaskManager";
            this.btnTaskManager.Size = new System.Drawing.Size(170, 70);
            this.btnTaskManager.TabIndex = 130;
            this.btnTaskManager.Text = "Show Windows\r\nTask Manager";
            this.btnTaskManager.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnServiceManager
            // 
            this.btnServiceManager.FlatAppearance.BorderSize = 2;
            this.btnServiceManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServiceManager.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServiceManager.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnServiceManager.Location = new System.Drawing.Point(27, 416);
            this.btnServiceManager.Name = "btnServiceManager";
            this.btnServiceManager.Size = new System.Drawing.Size(170, 70);
            this.btnServiceManager.TabIndex = 129;
            this.btnServiceManager.Text = "Show Windows\r\nServices Manager";
            this.btnServiceManager.Click += new System.EventHandler(this.btnServiceManager_Click);
            // 
            // btnExitApplication
            // 
            this.btnExitApplication.FlatAppearance.BorderSize = 2;
            this.btnExitApplication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExitApplication.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExitApplication.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExitApplication.Location = new System.Drawing.Point(594, 416);
            this.btnExitApplication.Name = "btnExitApplication";
            this.btnExitApplication.Size = new System.Drawing.Size(200, 70);
            this.btnExitApplication.TabIndex = 128;
            this.btnExitApplication.Text = "Exit\r\nApplication";
            this.btnExitApplication.Click += new System.EventHandler(this.btnExitApplication_Click);
            // 
            // optServerTx
            // 
            this.optServerTx.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optServerTx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.optServerTx.Location = new System.Drawing.Point(398, 42);
            this.optServerTx.Name = "optServerTx";
            this.optServerTx.Size = new System.Drawing.Size(177, 34);
            this.optServerTx.TabIndex = 48;
            this.optServerTx.Text = "Live";
            // 
            // btnSettingsSave
            // 
            this.btnSettingsSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettingsSave.BackColor = System.Drawing.Color.Green;
            this.btnSettingsSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettingsSave.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnSettingsSave.ForeColor = System.Drawing.Color.White;
            this.btnSettingsSave.Location = new System.Drawing.Point(604, 42);
            this.btnSettingsSave.Name = "btnSettingsSave";
            this.btnSettingsSave.Size = new System.Drawing.Size(200, 70);
            this.btnSettingsSave.TabIndex = 7;
            this.btnSettingsSave.Text = "Save";
            this.btnSettingsSave.UseVisualStyleBackColor = false;
            this.btnSettingsSave.Click += new System.EventHandler(this.btnSettingsSave_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(22, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 26);
            this.label1.TabIndex = 68;
            this.label1.Text = "Select server:";
            // 
            // optServerDemo
            // 
            this.optServerDemo.Checked = true;
            this.optServerDemo.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optServerDemo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.optServerDemo.Location = new System.Drawing.Point(227, 42);
            this.optServerDemo.Name = "optServerDemo";
            this.optServerDemo.Size = new System.Drawing.Size(95, 33);
            this.optServerDemo.TabIndex = 8;
            this.optServerDemo.TabStop = true;
            this.optServerDemo.Text = "Demo";
            // 
            // tbRegisterPC
            // 
            this.tbRegisterPC.Controls.Add(this.label8);
            this.tbRegisterPC.Controls.Add(this.label7);
            this.tbRegisterPC.Controls.Add(this.btnRefreshEMIE);
            this.tbRegisterPC.Controls.Add(this.txtIMEI);
            this.tbRegisterPC.Controls.Add(this.label6);
            this.tbRegisterPC.Controls.Add(this.lblAssetId);
            this.tbRegisterPC.Controls.Add(this.txtAssetId);
            this.tbRegisterPC.Controls.Add(this.lblStep1);
            this.tbRegisterPC.Controls.Add(this.txtSerialNumber);
            this.tbRegisterPC.Controls.Add(this.label4);
            this.tbRegisterPC.Controls.Add(this.btnRegisterPC);
            this.tbRegisterPC.Location = new System.Drawing.Point(4, 44);
            this.tbRegisterPC.Name = "tbRegisterPC";
            this.tbRegisterPC.Padding = new System.Windows.Forms.Padding(3);
            this.tbRegisterPC.Size = new System.Drawing.Size(845, 517);
            this.tbRegisterPC.TabIndex = 2;
            this.tbRegisterPC.Text = "Register Device (Step 1)";
            this.tbRegisterPC.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(284, 464);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(413, 20);
            this.label8.TabIndex = 24;
            this.label8.Text = "IMEI number is retreived from the onboard cellular device.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(332, 361);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(363, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = "Updated from server once hardware ID registered.";
            // 
            // btnRefreshEMIE
            // 
            this.btnRefreshEMIE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshEMIE.BackColor = System.Drawing.Color.White;
            this.btnRefreshEMIE.BackgroundImage = global::TopitUp.Properties.Resources.refresh;
            this.btnRefreshEMIE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRefreshEMIE.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRefreshEMIE.FlatAppearance.BorderSize = 2;
            this.btnRefreshEMIE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshEMIE.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnRefreshEMIE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRefreshEMIE.Location = new System.Drawing.Point(718, 423);
            this.btnRefreshEMIE.Name = "btnRefreshEMIE";
            this.btnRefreshEMIE.Size = new System.Drawing.Size(98, 38);
            this.btnRefreshEMIE.TabIndex = 22;
            this.btnRefreshEMIE.UseVisualStyleBackColor = false;
            this.btnRefreshEMIE.Click += new System.EventHandler(this.btnRefreshEMIE_Click);
            // 
            // txtIMEI
            // 
            this.txtIMEI.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIMEI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtIMEI.Location = new System.Drawing.Point(33, 423);
            this.txtIMEI.Name = "txtIMEI";
            this.txtIMEI.ReadOnly = true;
            this.txtIMEI.Size = new System.Drawing.Size(668, 38);
            this.txtIMEI.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(29, 385);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 25);
            this.label6.TabIndex = 20;
            this.label6.Text = "Device IMEI:";
            // 
            // lblAssetId
            // 
            this.lblAssetId.AutoSize = true;
            this.lblAssetId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblAssetId.Location = new System.Drawing.Point(28, 110);
            this.lblAssetId.Name = "lblAssetId";
            this.lblAssetId.Size = new System.Drawing.Size(210, 25);
            this.lblAssetId.TabIndex = 19;
            this.lblAssetId.Text = "Unique Hardware ID:";
            // 
            // txtAssetId
            // 
            this.txtAssetId.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssetId.Location = new System.Drawing.Point(287, 104);
            this.txtAssetId.MaxLength = 6;
            this.txtAssetId.Name = "txtAssetId";
            this.txtAssetId.Size = new System.Drawing.Size(414, 46);
            this.txtAssetId.TabIndex = 18;
            // 
            // lblStep1
            // 
            this.lblStep1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep1.ForeColor = System.Drawing.Color.Maroon;
            this.lblStep1.Location = new System.Drawing.Point(29, 29);
            this.lblStep1.Name = "lblStep1";
            this.lblStep1.Size = new System.Drawing.Size(787, 56);
            this.lblStep1.TabIndex = 17;
            this.lblStep1.Text = "Please make sure this hardware device has been added to the system.\r\nOr call Top " +
    "it Up support for assistance.";
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerialNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSerialNumber.Location = new System.Drawing.Point(32, 321);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.ReadOnly = true;
            this.txtSerialNumber.Size = new System.Drawing.Size(668, 38);
            this.txtSerialNumber.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(28, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(226, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Device Serial Number:";
            // 
            // btnRegisterPC
            // 
            this.btnRegisterPC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegisterPC.BackColor = System.Drawing.Color.White;
            this.btnRegisterPC.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRegisterPC.FlatAppearance.BorderSize = 2;
            this.btnRegisterPC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegisterPC.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnRegisterPC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRegisterPC.Location = new System.Drawing.Point(501, 182);
            this.btnRegisterPC.Name = "btnRegisterPC";
            this.btnRegisterPC.Size = new System.Drawing.Size(200, 70);
            this.btnRegisterPC.TabIndex = 9;
            this.btnRegisterPC.Text = "Save Hardware\r\nSettings";
            this.btnRegisterPC.UseVisualStyleBackColor = false;
            this.btnRegisterPC.Click += new System.EventHandler(this.btnRegisterPC_Click);
            // 
            // tbLicense
            // 
            this.tbLicense.BackColor = System.Drawing.Color.White;
            this.tbLicense.Controls.Add(this.lblLicenseDone);
            this.tbLicense.Controls.Add(this.panel1);
            this.tbLicense.Controls.Add(this.lblSecret);
            this.tbLicense.Controls.Add(this.btnSecret);
            this.tbLicense.Controls.Add(this.txtSecret);
            this.tbLicense.Controls.Add(this.btnActivate);
            this.tbLicense.Controls.Add(this.lblGeneralLicense);
            this.tbLicense.Controls.Add(this.btnLoadItems);
            this.tbLicense.Controls.Add(this.lblLicense);
            this.tbLicense.Location = new System.Drawing.Point(4, 44);
            this.tbLicense.Name = "tbLicense";
            this.tbLicense.Size = new System.Drawing.Size(845, 517);
            this.tbLicense.TabIndex = 0;
            this.tbLicense.Text = "License (Step 2)";
            // 
            // lblLicenseDone
            // 
            this.lblLicenseDone.BackColor = System.Drawing.Color.White;
            this.lblLicenseDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseDone.ForeColor = System.Drawing.Color.Silver;
            this.lblLicenseDone.Location = new System.Drawing.Point(159, 82);
            this.lblLicenseDone.Name = "lblLicenseDone";
            this.lblLicenseDone.Size = new System.Drawing.Size(541, 55);
            this.lblLicenseDone.TabIndex = 57;
            this.lblLicenseDone.Text = "License linked to this device.";
            this.lblLicenseDone.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblLicenseDone.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Location = new System.Drawing.Point(31, 182);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(780, 2);
            this.panel1.TabIndex = 56;
            // 
            // lblSecret
            // 
            this.lblSecret.BackColor = System.Drawing.Color.White;
            this.lblSecret.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.lblSecret.ForeColor = System.Drawing.Color.Black;
            this.lblSecret.Location = new System.Drawing.Point(26, 105);
            this.lblSecret.Name = "lblSecret";
            this.lblSecret.Size = new System.Drawing.Size(225, 32);
            this.lblSecret.TabIndex = 0;
            this.lblSecret.Text = "Secret Upgrade PIN:";
            this.lblSecret.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSecret
            // 
            this.btnSecret.BackColor = System.Drawing.Color.Maroon;
            this.btnSecret.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSecret.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnSecret.ForeColor = System.Drawing.Color.White;
            this.btnSecret.Location = new System.Drawing.Point(609, 86);
            this.btnSecret.Name = "btnSecret";
            this.btnSecret.Size = new System.Drawing.Size(200, 70);
            this.btnSecret.TabIndex = 52;
            this.btnSecret.Text = "Get Current\r\nActive License";
            this.btnSecret.UseVisualStyleBackColor = false;
            this.btnSecret.Click += new System.EventHandler(this.btnSecret_Click);
            // 
            // txtSecret
            // 
            this.txtSecret.BackColor = System.Drawing.Color.White;
            this.txtSecret.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold);
            this.txtSecret.Location = new System.Drawing.Point(257, 102);
            this.txtSecret.MaxLength = 7;
            this.txtSecret.Name = "txtSecret";
            this.txtSecret.Size = new System.Drawing.Size(198, 46);
            this.txtSecret.TabIndex = 51;
            // 
            // btnActivate
            // 
            this.btnActivate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnActivate.BackColor = System.Drawing.Color.Green;
            this.btnActivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivate.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnActivate.ForeColor = System.Drawing.Color.White;
            this.btnActivate.Location = new System.Drawing.Point(29, 418);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(200, 70);
            this.btnActivate.TabIndex = 1;
            this.btnActivate.Text = "Fetch Active\r\nLicense";
            this.btnActivate.UseVisualStyleBackColor = false;
            this.btnActivate.Click += new System.EventHandler(this.btnActivate_Click);
            // 
            // lblGeneralLicense
            // 
            this.lblGeneralLicense.BackColor = System.Drawing.Color.White;
            this.lblGeneralLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lblGeneralLicense.ForeColor = System.Drawing.Color.Maroon;
            this.lblGeneralLicense.Location = new System.Drawing.Point(29, 29);
            this.lblGeneralLicense.Name = "lblGeneralLicense";
            this.lblGeneralLicense.Size = new System.Drawing.Size(541, 55);
            this.lblGeneralLicense.TabIndex = 54;
            this.lblGeneralLicense.Text = "Getting a current active license is only valid for upgrades.\r\nNew registraions wi" +
    "ll need to \"Fetch Active License\"";
            // 
            // btnLoadItems
            // 
            this.btnLoadItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnLoadItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadItems.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnLoadItems.ForeColor = System.Drawing.Color.White;
            this.btnLoadItems.Location = new System.Drawing.Point(609, 418);
            this.btnLoadItems.Name = "btnLoadItems";
            this.btnLoadItems.Size = new System.Drawing.Size(200, 70);
            this.btnLoadItems.TabIndex = 35;
            this.btnLoadItems.Text = "Refresh\r\nRetailer Data";
            this.btnLoadItems.UseVisualStyleBackColor = false;
            this.btnLoadItems.Click += new System.EventHandler(this.btnLoadItems_Click);
            // 
            // lblLicense
            // 
            this.lblLicense.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLicense.BackColor = System.Drawing.Color.White;
            this.lblLicense.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblLicense.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblLicense.Location = new System.Drawing.Point(29, 204);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(776, 189);
            this.lblLicense.TabIndex = 55;
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.BackColor = System.Drawing.Color.White;
            this.btnCloseForm.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCloseForm.FlatAppearance.BorderSize = 0;
            this.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseForm.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseForm.ForeColor = System.Drawing.Color.Maroon;
            this.btnCloseForm.Image = global::TopitUp.Properties.Resources.btnClose;
            this.btnCloseForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseForm.Location = new System.Drawing.Point(0, 1);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.btnCloseForm.Size = new System.Drawing.Size(250, 89);
            this.btnCloseForm.TabIndex = 36;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.UseVisualStyleBackColor = false;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // pnlKeyboard
            // 
            this.pnlKeyboard.Controls.Add(this.virtualKeyboard1);
            this.pnlKeyboard.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlKeyboard.Location = new System.Drawing.Point(880, 0);
            this.pnlKeyboard.Name = "pnlKeyboard";
            this.pnlKeyboard.Size = new System.Drawing.Size(400, 900);
            this.pnlKeyboard.TabIndex = 49;
            this.pnlKeyboard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlKeyboard_Paint);
            // 
            // virtualKeyboard1
            // 
            this.virtualKeyboard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.virtualKeyboard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.virtualKeyboard1.Location = new System.Drawing.Point(0, 0);
            this.virtualKeyboard1.Name = "virtualKeyboard1";
            this.virtualKeyboard1.Size = new System.Drawing.Size(400, 900);
            this.virtualKeyboard1.TabIndex = 0;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.pnlFooter.Controls.Add(this.pnlFooterLogedin);
            this.pnlFooter.Controls.Add(this.pnlFooterRHS);
            this.pnlFooter.Controls.Add(this.btnAbout);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 810);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(880, 90);
            this.pnlFooter.TabIndex = 92;
            // 
            // pnlFooterLogedin
            // 
            this.pnlFooterLogedin.Controls.Add(this.btnCloseForm);
            this.pnlFooterLogedin.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFooterLogedin.Location = new System.Drawing.Point(0, 0);
            this.pnlFooterLogedin.Name = "pnlFooterLogedin";
            this.pnlFooterLogedin.Size = new System.Drawing.Size(436, 90);
            this.pnlFooterLogedin.TabIndex = 38;
            // 
            // pnlFooterRHS
            // 
            this.pnlFooterRHS.Controls.Add(this.btnRestart);
            this.pnlFooterRHS.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFooterRHS.Location = new System.Drawing.Point(625, 0);
            this.pnlFooterRHS.Name = "pnlFooterRHS";
            this.pnlFooterRHS.Size = new System.Drawing.Size(255, 90);
            this.pnlFooterRHS.TabIndex = 37;
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.Maroon;
            this.btnRestart.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRestart.FlatAppearance.BorderSize = 0;
            this.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestart.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestart.ForeColor = System.Drawing.Color.White;
            this.btnRestart.Location = new System.Drawing.Point(5, 1);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(250, 89);
            this.btnRestart.TabIndex = 37;
            this.btnRestart.Text = "Restart\r\nApplication";
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
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
            // lblFirewallStatus
            // 
            this.lblFirewallStatus.AutoSize = true;
            this.lblFirewallStatus.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirewallStatus.ForeColor = System.Drawing.Color.Green;
            this.lblFirewallStatus.Location = new System.Drawing.Point(261, 182);
            this.lblFirewallStatus.Name = "lblFirewallStatus";
            this.lblFirewallStatus.Size = new System.Drawing.Size(99, 18);
            this.lblFirewallStatus.TabIndex = 141;
            this.lblFirewallStatus.Text = "Firewall Status";
            // 
            // btnFirewallDisable
            // 
            this.btnFirewallDisable.FlatAppearance.BorderSize = 2;
            this.btnFirewallDisable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirewallDisable.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirewallDisable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnFirewallDisable.Location = new System.Drawing.Point(474, 154);
            this.btnFirewallDisable.Name = "btnFirewallDisable";
            this.btnFirewallDisable.Size = new System.Drawing.Size(150, 70);
            this.btnFirewallDisable.TabIndex = 142;
            this.btnFirewallDisable.Text = "Disable\r\nPublic Profile";
            this.btnFirewallDisable.Click += new System.EventHandler(this.btnFirewallDisable_Click);
            // 
            // btnFirewallEnable
            // 
            this.btnFirewallEnable.FlatAppearance.BorderSize = 2;
            this.btnFirewallEnable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirewallEnable.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirewallEnable.ForeColor = System.Drawing.Color.Green;
            this.btnFirewallEnable.Location = new System.Drawing.Point(644, 154);
            this.btnFirewallEnable.Name = "btnFirewallEnable";
            this.btnFirewallEnable.Size = new System.Drawing.Size(150, 70);
            this.btnFirewallEnable.TabIndex = 143;
            this.btnFirewallEnable.Text = "Enable \r\nPublic Profile";
            this.btnFirewallEnable.Click += new System.EventHandler(this.btnFirewallEnable_Click);
            // 
            // btnShowFirewall
            // 
            this.btnShowFirewall.FlatAppearance.BorderSize = 2;
            this.btnShowFirewall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowFirewall.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowFirewall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnShowFirewall.Location = new System.Drawing.Point(404, 330);
            this.btnShowFirewall.Name = "btnShowFirewall";
            this.btnShowFirewall.Size = new System.Drawing.Size(170, 70);
            this.btnShowFirewall.TabIndex = 144;
            this.btnShowFirewall.Text = "Show Windows\r\nFirewall";
            this.btnShowFirewall.Click += new System.EventHandler(this.btnShowFirewall_Click);
            // 
            // frmTIUAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 900);
            this.ControlBox = false;
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlKeyboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTIUAdmin";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.vsGuardian_Load);
            this.pnlMain.ResumeLayout(false);
            this.tabControlSettings.ResumeLayout(false);
            this.tbLogin.ResumeLayout(false);
            this.tbLogin.PerformLayout();
            this.tbConnection.ResumeLayout(false);
            this.tbConnection.PerformLayout();
            this.tbSettings.ResumeLayout(false);
            this.tbSettings.PerformLayout();
            this.tbRegisterPC.ResumeLayout(false);
            this.tbRegisterPC.PerformLayout();
            this.tbLicense.ResumeLayout(false);
            this.tbLicense.PerformLayout();
            this.pnlKeyboard.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooterLogedin.ResumeLayout(false);
            this.pnlFooterRHS.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TabControl tabControlSettings;
        private System.Windows.Forms.TabPage tbLicense;
        private System.Windows.Forms.TabPage tbSettings;
        private System.Windows.Forms.Button btnActivate;
        private System.Windows.Forms.Button btnSettingsSave;
        private System.Windows.Forms.Label lblLicense;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton optServerDemo;
        private System.Windows.Forms.Button btnLoadItems;
        private System.Windows.Forms.Label lblGeneralLicense;
        private System.Windows.Forms.RadioButton optServerTx;
        private System.Windows.Forms.TextBox txtSecret;
        private System.Windows.Forms.Label lblSecret;
        private System.Windows.Forms.Button btnSecret;
        private System.Windows.Forms.TabPage tbRegisterPC;
        private System.Windows.Forms.TabPage tbLogin;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnSMS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOTP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCell;
        private System.Windows.Forms.Button btnRegisterPC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.Label lblAllSettings;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Button btnExitApplication;
        private System.Windows.Forms.Panel pnlKeyboard;
        private virtualKeyboard virtualKeyboard1;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlFooterLogedin;
        private System.Windows.Forms.Panel pnlFooterRHS;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.TabPage tbConnection;
        private System.Windows.Forms.TextBox pnlConnTest;
        private System.Windows.Forms.Button btnTextConnection;
        private System.Windows.Forms.TextBox ConnPort;
        private System.Windows.Forms.TextBox ConnURL;
        private System.Windows.Forms.ComboBox ConnHttp;
        private System.Windows.Forms.TextBox connLocation;
        private System.Windows.Forms.Button btnServiceManager;
        private System.Windows.Forms.Button btnTaskManager;
        private System.Windows.Forms.Button btnLockdown;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblAssetId;
        private System.Windows.Forms.TextBox txtAssetId;
        private System.Windows.Forms.Label lblStep1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtIMEI;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnRefreshEMIE;
        private System.Windows.Forms.Label lblLicenseDone;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnShutdown;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSoftwareUpdate;
        private System.Windows.Forms.Button btnShowPrinters;
        private System.Windows.Forms.Panel pnlDivider;
        private System.Windows.Forms.Button btnUpdateFirewall;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkCustomerMin;
        private System.Windows.Forms.Label lblFirewallStatus;
        private System.Windows.Forms.Button btnFirewallDisable;
        private System.Windows.Forms.Button btnFirewallEnable;
        private System.Windows.Forms.Button btnShowFirewall;
    }
}


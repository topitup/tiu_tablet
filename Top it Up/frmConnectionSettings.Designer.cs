namespace TopitUp
{
    partial class frmConnectionSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConnectionSettings));
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlFooterLogedin = new System.Windows.Forms.Panel();
            this.btnMainClose = new System.Windows.Forms.Button();
            this.pnlFooterRHS = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lnkLoadNetworkSettings = new System.Windows.Forms.LinkLabel();
            this.lblHeaderExtra = new System.Windows.Forms.Label();
            this.lblHeader2 = new System.Windows.Forms.Label();
            this.lblHeader3 = new System.Windows.Forms.Label();
            this.lblHeader1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlLHSHeader = new System.Windows.Forms.Panel();
            this.lblLHSHeader = new System.Windows.Forms.Label();
            this.pnlWrapper = new System.Windows.Forms.Panel();
            this.lblResponseCode = new System.Windows.Forms.Label();
            this.lblConnDescription = new System.Windows.Forms.Label();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.pnlTest = new System.Windows.Forms.Panel();
            this.lblneedadmin = new System.Windows.Forms.Label();
            this.pnlFooter.SuspendLayout();
            this.pnlFooterLogedin.SuspendLayout();
            this.pnlFooterRHS.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlLHSHeader.SuspendLayout();
            this.pnlWrapper.SuspendLayout();
            this.pnlTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.pnlFooter.Controls.Add(this.pnlFooterLogedin);
            this.pnlFooter.Controls.Add(this.pnlFooterRHS);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 610);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1280, 90);
            this.pnlFooter.TabIndex = 147;
            // 
            // pnlFooterLogedin
            // 
            this.pnlFooterLogedin.Controls.Add(this.btnMainClose);
            this.pnlFooterLogedin.Location = new System.Drawing.Point(0, 1);
            this.pnlFooterLogedin.Name = "pnlFooterLogedin";
            this.pnlFooterLogedin.Size = new System.Drawing.Size(261, 90);
            this.pnlFooterLogedin.TabIndex = 38;
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
            this.btnMainClose.Image = global::TopitUp.Properties.Resources.btnClose;
            this.btnMainClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMainClose.Location = new System.Drawing.Point(0, 0);
            this.btnMainClose.Margin = new System.Windows.Forms.Padding(5);
            this.btnMainClose.Name = "btnMainClose";
            this.btnMainClose.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.btnMainClose.Size = new System.Drawing.Size(250, 89);
            this.btnMainClose.TabIndex = 16;
            this.btnMainClose.TabStop = false;
            this.btnMainClose.Text = "Close";
            this.btnMainClose.UseVisualStyleBackColor = false;
            this.btnMainClose.Click += new System.EventHandler(this.btnMainClose_Click);
            // 
            // pnlFooterRHS
            // 
            this.pnlFooterRHS.Controls.Add(this.btnRefresh);
            this.pnlFooterRHS.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFooterRHS.Location = new System.Drawing.Point(634, 0);
            this.pnlFooterRHS.Name = "pnlFooterRHS";
            this.pnlFooterRHS.Size = new System.Drawing.Size(646, 90);
            this.pnlFooterRHS.TabIndex = 37;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Tahoma", 20F);
            this.btnRefresh.ForeColor = System.Drawing.Color.Green;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(396, 1);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnRefresh.Size = new System.Drawing.Size(250, 89);
            this.btnRefresh.TabIndex = 17;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.Text = "   Refresh\r\n     Connections";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.pnlMain.Controls.Add(this.lnkLoadNetworkSettings);
            this.pnlMain.Controls.Add(this.lblHeaderExtra);
            this.pnlMain.Controls.Add(this.lblHeader2);
            this.pnlMain.Controls.Add(this.lblHeader3);
            this.pnlMain.Controls.Add(this.lblHeader1);
            this.pnlMain.Controls.Add(this.panel1);
            this.pnlMain.Controls.Add(this.pnlLHSHeader);
            this.pnlMain.Controls.Add(this.pnlWrapper);
            this.pnlMain.Controls.Add(this.pnlTest);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1280, 610);
            this.pnlMain.TabIndex = 149;
            // 
            // lnkLoadNetworkSettings
            // 
            this.lnkLoadNetworkSettings.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lnkLoadNetworkSettings.AutoSize = true;
            this.lnkLoadNetworkSettings.BackColor = System.Drawing.Color.White;
            this.lnkLoadNetworkSettings.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkLoadNetworkSettings.LinkColor = System.Drawing.Color.DimGray;
            this.lnkLoadNetworkSettings.Location = new System.Drawing.Point(1029, 382);
            this.lnkLoadNetworkSettings.Name = "lnkLoadNetworkSettings";
            this.lnkLoadNetworkSettings.Size = new System.Drawing.Size(197, 23);
            this.lnkLoadNetworkSettings.TabIndex = 134;
            this.lnkLoadNetworkSettings.TabStop = true;
            this.lnkLoadNetworkSettings.Text = "View Network Settings";
            this.lnkLoadNetworkSettings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLoadNetworkSettings_LinkClicked);
            // 
            // lblHeaderExtra
            // 
            this.lblHeaderExtra.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblHeaderExtra.AutoSize = true;
            this.lblHeaderExtra.BackColor = System.Drawing.Color.White;
            this.lblHeaderExtra.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderExtra.ForeColor = System.Drawing.Color.Silver;
            this.lblHeaderExtra.Location = new System.Drawing.Point(439, 72);
            this.lblHeaderExtra.Name = "lblHeaderExtra";
            this.lblHeaderExtra.Size = new System.Drawing.Size(155, 19);
            this.lblHeaderExtra.TabIndex = 138;
            this.lblHeaderExtra.Text = "Extra Information";
            // 
            // lblHeader2
            // 
            this.lblHeader2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblHeader2.AutoSize = true;
            this.lblHeader2.BackColor = System.Drawing.Color.White;
            this.lblHeader2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader2.ForeColor = System.Drawing.Color.Silver;
            this.lblHeader2.Location = new System.Drawing.Point(776, 72);
            this.lblHeader2.Name = "lblHeader2";
            this.lblHeader2.Size = new System.Drawing.Size(79, 19);
            this.lblHeader2.TabIndex = 137;
            this.lblHeader2.Text = "Network";
            // 
            // lblHeader3
            // 
            this.lblHeader3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblHeader3.AutoSize = true;
            this.lblHeader3.BackColor = System.Drawing.Color.White;
            this.lblHeader3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader3.ForeColor = System.Drawing.Color.Silver;
            this.lblHeader3.Location = new System.Drawing.Point(918, 72);
            this.lblHeader3.Name = "lblHeader3";
            this.lblHeader3.Size = new System.Drawing.Size(61, 19);
            this.lblHeader3.TabIndex = 136;
            this.lblHeader3.Text = "Status";
            // 
            // lblHeader1
            // 
            this.lblHeader1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblHeader1.AutoSize = true;
            this.lblHeader1.BackColor = System.Drawing.Color.White;
            this.lblHeader1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader1.ForeColor = System.Drawing.Color.Silver;
            this.lblHeader1.Location = new System.Drawing.Point(111, 72);
            this.lblHeader1.Name = "lblHeader1";
            this.lblHeader1.Size = new System.Drawing.Size(101, 19);
            this.lblHeader1.TabIndex = 135;
            this.lblHeader1.Text = "Description";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(20, 430);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1240, 41);
            this.panel1.TabIndex = 136;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "CONNECTION TEST";
            // 
            // pnlLHSHeader
            // 
            this.pnlLHSHeader.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlLHSHeader.BackColor = System.Drawing.Color.LightGray;
            this.pnlLHSHeader.Controls.Add(this.lblLHSHeader);
            this.pnlLHSHeader.Location = new System.Drawing.Point(20, 15);
            this.pnlLHSHeader.Name = "pnlLHSHeader";
            this.pnlLHSHeader.Size = new System.Drawing.Size(1240, 40);
            this.pnlLHSHeader.TabIndex = 135;
            // 
            // lblLHSHeader
            // 
            this.lblLHSHeader.AutoSize = true;
            this.lblLHSHeader.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLHSHeader.ForeColor = System.Drawing.Color.Maroon;
            this.lblLHSHeader.Location = new System.Drawing.Point(6, 8);
            this.lblLHSHeader.Name = "lblLHSHeader";
            this.lblLHSHeader.Size = new System.Drawing.Size(258, 25);
            this.lblLHSHeader.TabIndex = 0;
            this.lblLHSHeader.Text = "NETWORK CONNECTIONS";
            // 
            // pnlWrapper
            // 
            this.pnlWrapper.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pnlWrapper.BackColor = System.Drawing.Color.White;
            this.pnlWrapper.Controls.Add(this.lblResponseCode);
            this.pnlWrapper.Controls.Add(this.lblConnDescription);
            this.pnlWrapper.Controls.Add(this.btnTestConnection);
            this.pnlWrapper.Location = new System.Drawing.Point(20, 470);
            this.pnlWrapper.Name = "pnlWrapper";
            this.pnlWrapper.Size = new System.Drawing.Size(1240, 122);
            this.pnlWrapper.TabIndex = 109;
            // 
            // lblResponseCode
            // 
            this.lblResponseCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResponseCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResponseCode.ForeColor = System.Drawing.Color.Green;
            this.lblResponseCode.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblResponseCode.Location = new System.Drawing.Point(556, 9);
            this.lblResponseCode.Name = "lblResponseCode";
            this.lblResponseCode.Size = new System.Drawing.Size(670, 99);
            this.lblResponseCode.TabIndex = 110;
            this.lblResponseCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblConnDescription
            // 
            this.lblConnDescription.AutoSize = true;
            this.lblConnDescription.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblConnDescription.Location = new System.Drawing.Point(244, 49);
            this.lblConnDescription.Name = "lblConnDescription";
            this.lblConnDescription.Size = new System.Drawing.Size(264, 25);
            this.lblConnDescription.TabIndex = 109;
            this.lblConnDescription.Text = "Connection response code:";
            this.lblConnDescription.Visible = false;
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(163)))));
            this.btnTestConnection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTestConnection.FlatAppearance.BorderSize = 0;
            this.btnTestConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestConnection.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestConnection.ForeColor = System.Drawing.Color.White;
            this.btnTestConnection.Location = new System.Drawing.Point(18, 19);
            this.btnTestConnection.Margin = new System.Windows.Forms.Padding(0);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(199, 89);
            this.btnTestConnection.TabIndex = 108;
            this.btnTestConnection.Text = "Connectivity\r\nTest";
            this.btnTestConnection.UseVisualStyleBackColor = false;
            this.btnTestConnection.Click += new System.EventHandler(this.btnConnectionTest_Click);
            // 
            // pnlTest
            // 
            this.pnlTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pnlTest.AutoScroll = true;
            this.pnlTest.BackColor = System.Drawing.Color.White;
            this.pnlTest.Controls.Add(this.lblneedadmin);
            this.pnlTest.Location = new System.Drawing.Point(20, 51);
            this.pnlTest.Name = "pnlTest";
            this.pnlTest.Size = new System.Drawing.Size(1240, 367);
            this.pnlTest.TabIndex = 139;
            // 
            // lblneedadmin
            // 
            this.lblneedadmin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblneedadmin.AutoSize = true;
            this.lblneedadmin.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblneedadmin.ForeColor = System.Drawing.Color.Maroon;
            this.lblneedadmin.Location = new System.Drawing.Point(429, 142);
            this.lblneedadmin.Name = "lblneedadmin";
            this.lblneedadmin.Size = new System.Drawing.Size(382, 25);
            this.lblneedadmin.TabIndex = 111;
            this.lblneedadmin.Text = "Currently not running as Administrator!";
            this.lblneedadmin.Visible = false;
            // 
            // frmConnectionSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 700);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConnectionSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmConnectionSettings_Load);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooterLogedin.ResumeLayout(false);
            this.pnlFooterRHS.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlLHSHeader.ResumeLayout(false);
            this.pnlLHSHeader.PerformLayout();
            this.pnlWrapper.ResumeLayout(false);
            this.pnlWrapper.PerformLayout();
            this.pnlTest.ResumeLayout(false);
            this.pnlTest.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlFooterLogedin;
        private System.Windows.Forms.Button btnMainClose;
        private System.Windows.Forms.Panel pnlFooterRHS;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlWrapper;
        private System.Windows.Forms.Label lblResponseCode;
        private System.Windows.Forms.Label lblConnDescription;
        private System.Windows.Forms.LinkLabel lnkLoadNetworkSettings;
        private System.Windows.Forms.Panel pnlLHSHeader;
        private System.Windows.Forms.Label lblLHSHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblHeaderExtra;
        private System.Windows.Forms.Label lblHeader2;
        private System.Windows.Forms.Label lblHeader3;
        private System.Windows.Forms.Label lblHeader1;
        private System.Windows.Forms.Panel pnlTest;
        private System.Windows.Forms.Label lblneedadmin;
    }
}
namespace TopitUp
{
    partial class UcNetworkAdapter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcNetworkAdapter));
            this.lblDeviceName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblNetwork = new System.Windows.Forms.Label();
            this.lblExtra = new System.Windows.Forms.Label();
            this.pnlDivider = new System.Windows.Forms.Panel();
            this.pctNetworkAdapter = new System.Windows.Forms.PictureBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.btnWifiNetworks = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pctNetworkAdapter)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDeviceName
            // 
            this.lblDeviceName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceName.ForeColor = System.Drawing.Color.Gray;
            this.lblDeviceName.Location = new System.Drawing.Point(74, 29);
            this.lblDeviceName.Name = "lblDeviceName";
            this.lblDeviceName.Size = new System.Drawing.Size(319, 22);
            this.lblDeviceName.TabIndex = 1;
            this.lblDeviceName.Text = "lblDeviceName";
            this.lblDeviceName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(74, 7);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(319, 22);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Wi-Fi";
            // 
            // lblNetwork
            // 
            this.lblNetwork.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetwork.Location = new System.Drawing.Point(737, 10);
            this.lblNetwork.Name = "lblNetwork";
            this.lblNetwork.Size = new System.Drawing.Size(126, 46);
            this.lblNetwork.TabIndex = 5;
            this.lblNetwork.Text = "connected";
            // 
            // lblExtra
            // 
            this.lblExtra.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExtra.ForeColor = System.Drawing.Color.Gray;
            this.lblExtra.Location = new System.Drawing.Point(399, 7);
            this.lblExtra.Name = "lblExtra";
            this.lblExtra.Size = new System.Drawing.Size(333, 53);
            this.lblExtra.TabIndex = 6;
            // 
            // pnlDivider
            // 
            this.pnlDivider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDivider.BackColor = System.Drawing.Color.LightGray;
            this.pnlDivider.Location = new System.Drawing.Point(10, 63);
            this.pnlDivider.Name = "pnlDivider";
            this.pnlDivider.Size = new System.Drawing.Size(1120, 1);
            this.pnlDivider.TabIndex = 7;
            // 
            // pctNetworkAdapter
            // 
            this.pctNetworkAdapter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pctNetworkAdapter.Location = new System.Drawing.Point(5, 6);
            this.pctNetworkAdapter.Name = "pctNetworkAdapter";
            this.pctNetworkAdapter.Padding = new System.Windows.Forms.Padding(0, 17, 0, 0);
            this.pctNetworkAdapter.Size = new System.Drawing.Size(53, 49);
            this.pctNetworkAdapter.TabIndex = 0;
            this.pctNetworkAdapter.TabStop = false;
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.BackColor = System.Drawing.Color.Gray;
            this.btnConnect.FlatAppearance.BorderSize = 0;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.Location = new System.Drawing.Point(1005, 8);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(125, 48);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.TabStop = false;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Visible = false;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkEnabled.Location = new System.Drawing.Point(871, 10);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(94, 24);
            this.chkEnabled.TabIndex = 9;
            this.chkEnabled.Text = "Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // btnWifiNetworks
            // 
            this.btnWifiNetworks.BackColor = System.Drawing.Color.Gainsboro;
            this.btnWifiNetworks.FlatAppearance.BorderSize = 0;
            this.btnWifiNetworks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWifiNetworks.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWifiNetworks.ForeColor = System.Drawing.Color.White;
            this.btnWifiNetworks.Image = ((System.Drawing.Image)(resources.GetObject("btnWifiNetworks.Image")));
            this.btnWifiNetworks.Location = new System.Drawing.Point(638, 8);
            this.btnWifiNetworks.Name = "btnWifiNetworks";
            this.btnWifiNetworks.Size = new System.Drawing.Size(57, 48);
            this.btnWifiNetworks.TabIndex = 10;
            this.btnWifiNetworks.TabStop = false;
            this.btnWifiNetworks.UseVisualStyleBackColor = false;
            this.btnWifiNetworks.Visible = false;
            // 
            // UcNetworkAdapter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnWifiNetworks);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.pnlDivider);
            this.Controls.Add(this.lblExtra);
            this.Controls.Add(this.lblNetwork);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblDeviceName);
            this.Controls.Add(this.pctNetworkAdapter);
            this.Name = "UcNetworkAdapter";
            this.Size = new System.Drawing.Size(1140, 65);
            ((System.ComponentModel.ISupportInitialize)(this.pctNetworkAdapter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctNetworkAdapter;
        private System.Windows.Forms.Label lblDeviceName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblNetwork;
        private System.Windows.Forms.Label lblExtra;
        private System.Windows.Forms.Panel pnlDivider;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.Button btnWifiNetworks;

    }
}

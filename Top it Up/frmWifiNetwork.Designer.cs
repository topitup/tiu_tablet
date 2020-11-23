namespace TopitUp
{
    partial class frmWifiNetwork
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlAdmin = new System.Windows.Forms.Panel();
            this.pnlConnectOver = new System.Windows.Forms.Panel();
            this.btnClose2 = new System.Windows.Forms.Button();
            this.lblConnect = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grdNetworks = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.virtualKeyboard1 = new TopitUp.virtualKeyboard();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassKey = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chk_show_password = new System.Windows.Forms.CheckBox();
            this.pnlAdmin.SuspendLayout();
            this.pnlConnectOver.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNetworks)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlAdmin
            // 
            this.pnlAdmin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlAdmin.BackColor = System.Drawing.Color.White;
            this.pnlAdmin.Controls.Add(this.pnlConnectOver);
            this.pnlAdmin.Controls.Add(this.panel1);
            this.pnlAdmin.Controls.Add(this.grdNetworks);
            this.pnlAdmin.Controls.Add(this.virtualKeyboard1);
            this.pnlAdmin.Controls.Add(this.label1);
            this.pnlAdmin.Controls.Add(this.txtPassKey);
            this.pnlAdmin.Controls.Add(this.btnConnect);
            this.pnlAdmin.Controls.Add(this.btnCancel);
            this.pnlAdmin.Controls.Add(this.chk_show_password);
            this.pnlAdmin.Location = new System.Drawing.Point(115, 95);
            this.pnlAdmin.Name = "pnlAdmin";
            this.pnlAdmin.Size = new System.Drawing.Size(1040, 600);
            this.pnlAdmin.TabIndex = 0;
            // 
            // pnlConnectOver
            // 
            this.pnlConnectOver.Controls.Add(this.btnClose2);
            this.pnlConnectOver.Controls.Add(this.lblConnect);
            this.pnlConnectOver.Location = new System.Drawing.Point(5, 5);
            this.pnlConnectOver.Name = "pnlConnectOver";
            this.pnlConnectOver.Size = new System.Drawing.Size(628, 590);
            this.pnlConnectOver.TabIndex = 13;
            // 
            // btnClose2
            // 
            this.btnClose2.BackColor = System.Drawing.Color.Maroon;
            this.btnClose2.FlatAppearance.BorderSize = 2;
            this.btnClose2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose2.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose2.ForeColor = System.Drawing.Color.White;
            this.btnClose2.Location = new System.Drawing.Point(202, 380);
            this.btnClose2.Name = "btnClose2";
            this.btnClose2.Size = new System.Drawing.Size(200, 90);
            this.btnClose2.TabIndex = 6;
            this.btnClose2.Text = "Close";
            this.btnClose2.UseVisualStyleBackColor = false;
            this.btnClose2.Click += new System.EventHandler(this.btnClose2_Click);
            // 
            // lblConnect
            // 
            this.lblConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnect.Location = new System.Drawing.Point(48, 65);
            this.lblConnect.Name = "lblConnect";
            this.lblConnect.Size = new System.Drawing.Size(493, 283);
            this.lblConnect.TabIndex = 0;
            this.lblConnect.Text = "Busy connecting to wi-fi network:\r\n\r\nN/A\r\n\r\nPlease wait until the connection has " +
    "established and the connected icon appears at the top right of the screen.";
            this.lblConnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Location = new System.Drawing.Point(11, 367);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(609, 2);
            this.panel1.TabIndex = 12;
            // 
            // grdNetworks
            // 
            this.grdNetworks.AllowUserToAddRows = false;
            this.grdNetworks.AllowUserToDeleteRows = false;
            this.grdNetworks.AllowUserToResizeColumns = false;
            this.grdNetworks.AllowUserToResizeRows = false;
            this.grdNetworks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdNetworks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdNetworks.BackgroundColor = System.Drawing.Color.White;
            this.grdNetworks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdNetworks.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grdNetworks.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdNetworks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdNetworks.ColumnHeadersHeight = 48;
            this.grdNetworks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdNetworks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdNetworks.DefaultCellStyle = dataGridViewCellStyle4;
            this.grdNetworks.EnableHeadersVisualStyles = false;
            this.grdNetworks.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grdNetworks.Location = new System.Drawing.Point(16, 14);
            this.grdNetworks.MultiSelect = false;
            this.grdNetworks.Name = "grdNetworks";
            this.grdNetworks.ReadOnly = true;
            this.grdNetworks.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grdNetworks.RowHeadersVisible = false;
            this.grdNetworks.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdNetworks.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grdNetworks.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Maroon;
            this.grdNetworks.RowTemplate.DividerHeight = 1;
            this.grdNetworks.RowTemplate.Height = 48;
            this.grdNetworks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdNetworks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdNetworks.ShowCellErrors = false;
            this.grdNetworks.ShowCellToolTips = false;
            this.grdNetworks.ShowEditingIcon = false;
            this.grdNetworks.ShowRowErrors = false;
            this.grdNetworks.Size = new System.Drawing.Size(604, 337);
            this.grdNetworks.TabIndex = 11;
            this.grdNetworks.TabStop = false;
            this.grdNetworks.SelectionChanged += new System.EventHandler(this.grdNetworks_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Wi-Fi Network";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 150;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Signal Strength";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 70;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // virtualKeyboard1
            // 
            this.virtualKeyboard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.virtualKeyboard1.Location = new System.Drawing.Point(640, 0);
            this.virtualKeyboard1.Name = "virtualKeyboard1";
            this.virtualKeyboard1.Size = new System.Drawing.Size(400, 600);
            this.virtualKeyboard1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 395);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Password";
            // 
            // txtPassKey
            // 
            this.txtPassKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassKey.Location = new System.Drawing.Point(135, 387);
            this.txtPassKey.MaxLength = 50;
            this.txtPassKey.Name = "txtPassKey";
            this.txtPassKey.PasswordChar = '*';
            this.txtPassKey.Size = new System.Drawing.Size(284, 47);
            this.txtPassKey.TabIndex = 8;
            this.txtPassKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.Green;
            this.btnConnect.FlatAppearance.BorderSize = 2;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.Location = new System.Drawing.Point(402, 478);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(200, 90);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Maroon;
            this.btnCancel.FlatAppearance.BorderSize = 2;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(29, 478);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(200, 90);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chk_show_password
            // 
            this.chk_show_password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_show_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_show_password.Location = new System.Drawing.Point(447, 399);
            this.chk_show_password.Name = "chk_show_password";
            this.chk_show_password.Size = new System.Drawing.Size(139, 24);
            this.chk_show_password.TabIndex = 14;
            this.chk_show_password.Text = "Show Password";
            this.chk_show_password.UseVisualStyleBackColor = true;
            this.chk_show_password.CheckedChanged += new System.EventHandler(this.chk_show_password_CheckedChanged);
            // 
            // frmWifiNetwork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.ControlBox = false;
            this.Controls.Add(this.pnlAdmin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWifiNetwork";
            this.Opacity = 0.75D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "frmAirtime";
            this.Load += new System.EventHandler(this.frmWifiNetwork_Load);
            this.pnlAdmin.ResumeLayout(false);
            this.pnlAdmin.PerformLayout();
            this.pnlConnectOver.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNetworks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAdmin;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassKey;
        private virtualKeyboard virtualKeyboard1;
        private System.Windows.Forms.DataGridView grdNetworks;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlConnectOver;
        private System.Windows.Forms.Button btnClose2;
        private System.Windows.Forms.Label lblConnect;
        private System.Windows.Forms.CheckBox chk_show_password;

    }
}
namespace TopitUp
{
    partial class frmPrint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrint));
            this.wbSlip = new System.Windows.Forms.WebBrowser();
            this.pnlSlipWrapper = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pnlMainWrap = new System.Windows.Forms.Panel();
            this.pnlSlipWrapper.SuspendLayout();
            this.pnlMainWrap.SuspendLayout();
            this.SuspendLayout();
            // 
            // wbSlip
            // 
            this.wbSlip.AllowNavigation = false;
            this.wbSlip.AllowWebBrowserDrop = false;
            this.wbSlip.IsWebBrowserContextMenuEnabled = false;
            this.wbSlip.Location = new System.Drawing.Point(7, 5);
            this.wbSlip.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbSlip.Name = "wbSlip";
            this.wbSlip.ScriptErrorsSuppressed = true;
            this.wbSlip.Size = new System.Drawing.Size(344, 434);
            this.wbSlip.TabIndex = 0;
            // 
            // pnlSlipWrapper
            // 
            this.pnlSlipWrapper.BackgroundImage = global::TopitUp.Properties.Resources.slip_bg;
            this.pnlSlipWrapper.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlSlipWrapper.Controls.Add(this.wbSlip);
            this.pnlSlipWrapper.Location = new System.Drawing.Point(38, 28);
            this.pnlSlipWrapper.Name = "pnlSlipWrapper";
            this.pnlSlipWrapper.Size = new System.Drawing.Size(365, 447);
            this.pnlSlipWrapper.TabIndex = 2;
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
            this.btnClose.Location = new System.Drawing.Point(433, 386);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(166, 89);
            this.btnClose.TabIndex = 92;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackgroundImage = global::TopitUp.Properties.Resources.generalbtn2;
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPrint.Location = new System.Drawing.Point(433, 28);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(166, 89);
            this.btnPrint.TabIndex = 95;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // pnlMainWrap
            // 
            this.pnlMainWrap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlMainWrap.BackColor = System.Drawing.Color.White;
            this.pnlMainWrap.Controls.Add(this.pnlSlipWrapper);
            this.pnlMainWrap.Controls.Add(this.btnPrint);
            this.pnlMainWrap.Controls.Add(this.btnClose);
            this.pnlMainWrap.Location = new System.Drawing.Point(19, 88);
            this.pnlMainWrap.Name = "pnlMainWrap";
            this.pnlMainWrap.Size = new System.Drawing.Size(630, 506);
            this.pnlMainWrap.TabIndex = 96;
            // 
            // frmPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(673, 671);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMainWrap);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrint";
            this.Opacity = 0.75D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmPrintSlip_Load);
            this.pnlSlipWrapper.ResumeLayout(false);
            this.pnlMainWrap.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbSlip;
        private System.Windows.Forms.Panel pnlSlipWrapper;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Panel pnlMainWrap;
    }
}
namespace TopitUp
{
    partial class frmPinless
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
            this.txtCellNumber = new System.Windows.Forms.TextBox();
            this.lblAccountNumber = new System.Windows.Forms.Label();
            this.txtElecRand = new System.Windows.Forms.TextBox();
            this.lblElecRand = new System.Windows.Forms.Label();
            this.lblEnterValue = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblProvider = new System.Windows.Forms.Label();
            this.lblRefundWarning = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlCapture = new System.Windows.Forms.Panel();
            this.flowPnlProvider = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.picTick = new System.Windows.Forms.Button();
            this.pnlCapture.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCellNumber
            // 
            this.txtCellNumber.BackColor = System.Drawing.Color.White;
            this.txtCellNumber.Font = new System.Drawing.Font("Tahoma", 26F, System.Drawing.FontStyle.Bold);
            this.txtCellNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCellNumber.Location = new System.Drawing.Point(274, 141);
            this.txtCellNumber.MaxLength = 10;
            this.txtCellNumber.Name = "txtCellNumber";
            this.txtCellNumber.Size = new System.Drawing.Size(436, 49);
            this.txtCellNumber.TabIndex = 2;
            // 
            // lblAccountNumber
            // 
            this.lblAccountNumber.Font = new System.Drawing.Font("Tahoma", 24F);
            this.lblAccountNumber.Location = new System.Drawing.Point(3, 143);
            this.lblAccountNumber.Name = "lblAccountNumber";
            this.lblAccountNumber.Size = new System.Drawing.Size(230, 33);
            this.lblAccountNumber.TabIndex = 26;
            this.lblAccountNumber.Text = "Cell Number:";
            // 
            // txtElecRand
            // 
            this.txtElecRand.BackColor = System.Drawing.Color.White;
            this.txtElecRand.Font = new System.Drawing.Font("Tahoma", 26F, System.Drawing.FontStyle.Bold);
            this.txtElecRand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtElecRand.Location = new System.Drawing.Point(274, 203);
            this.txtElecRand.MaxLength = 7;
            this.txtElecRand.Name = "txtElecRand";
            this.txtElecRand.Size = new System.Drawing.Size(207, 49);
            this.txtElecRand.TabIndex = 3;
            this.txtElecRand.Leave += new System.EventHandler(this.txtElecRand_Leave);
            // 
            // lblElecRand
            // 
            this.lblElecRand.Font = new System.Drawing.Font("Tahoma", 28F, System.Drawing.FontStyle.Bold);
            this.lblElecRand.Location = new System.Drawing.Point(233, 203);
            this.lblElecRand.Name = "lblElecRand";
            this.lblElecRand.Size = new System.Drawing.Size(234, 50);
            this.lblElecRand.TabIndex = 24;
            this.lblElecRand.Text = "R";
            // 
            // lblEnterValue
            // 
            this.lblEnterValue.Font = new System.Drawing.Font("Tahoma", 24F);
            this.lblEnterValue.ForeColor = System.Drawing.Color.Black;
            this.lblEnterValue.Location = new System.Drawing.Point(3, 202);
            this.lblEnterValue.Name = "lblEnterValue";
            this.lblEnterValue.Size = new System.Drawing.Size(208, 50);
            this.lblEnterValue.TabIndex = 25;
            this.lblEnterValue.Text = "Enter Value:";
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Tahoma", 18F);
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMessage.Location = new System.Drawing.Point(35, 279);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(729, 133);
            this.lblMessage.TabIndex = 23;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblProvider
            // 
            this.lblProvider.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProvider.ForeColor = System.Drawing.Color.Maroon;
            this.lblProvider.Location = new System.Drawing.Point(143, 102);
            this.lblProvider.Name = "lblProvider";
            this.lblProvider.Size = new System.Drawing.Size(386, 34);
            this.lblProvider.TabIndex = 27;
            this.lblProvider.Text = "Please Select Provider";
            this.lblProvider.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblRefundWarning
            // 
            this.lblRefundWarning.AutoSize = true;
            this.lblRefundWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefundWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblRefundWarning.Location = new System.Drawing.Point(92, 335);
            this.lblRefundWarning.Name = "lblRefundWarning";
            this.lblRefundWarning.Size = new System.Drawing.Size(623, 18);
            this.lblRefundWarning.TabIndex = 30;
            this.lblRefundWarning.Text = "No refunds will be made for airtime purchased for the incorrect cellphone number." +
    "";
            this.lblRefundWarning.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(113, 425);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(563, 40);
            this.label2.TabIndex = 31;
            this.label2.Text = "Please Note: If your purchase is not confirmed, check your \'Transaction History\'\r" +
    "\nbefore you try again, to avoid duplication.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlCapture
            // 
            this.pnlCapture.Controls.Add(this.flowPnlProvider);
            this.pnlCapture.Controls.Add(this.lblProvider);
            this.pnlCapture.Controls.Add(this.lblAccountNumber);
            this.pnlCapture.Controls.Add(this.txtCellNumber);
            this.pnlCapture.Controls.Add(this.lblEnterValue);
            this.pnlCapture.Controls.Add(this.txtElecRand);
            this.pnlCapture.Controls.Add(this.lblElecRand);
            this.pnlCapture.Location = new System.Drawing.Point(30, 5);
            this.pnlCapture.Name = "pnlCapture";
            this.pnlCapture.Size = new System.Drawing.Size(733, 264);
            this.pnlCapture.TabIndex = 32;
            this.pnlCapture.Visible = false;
            // 
            // flowPnlProvider
            // 
            this.flowPnlProvider.Location = new System.Drawing.Point(5, 2);
            this.flowPnlProvider.Name = "flowPnlProvider";
            this.flowPnlProvider.Size = new System.Drawing.Size(725, 95);
            this.flowPnlProvider.TabIndex = 29;
            this.flowPnlProvider.WrapContents = false;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.BackgroundImage = global::TopitUp.Properties.Resources.rica_next;
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(546, 480);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(213, 45);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::TopitUp.Properties.Resources.btn_small_close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(32, 480);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(173, 45);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // picTick
            // 
            this.picTick.BackColor = System.Drawing.Color.Transparent;
            this.picTick.BackgroundImage = global::TopitUp.Properties.Resources.over_tick;
            this.picTick.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picTick.Enabled = false;
            this.picTick.FlatAppearance.BorderSize = 0;
            this.picTick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.picTick.Location = new System.Drawing.Point(10, 5);
            this.picTick.Name = "picTick";
            this.picTick.Size = new System.Drawing.Size(47, 42);
            this.picTick.TabIndex = 75;
            this.picTick.UseVisualStyleBackColor = false;
            this.picTick.Visible = false;
            // 
            // frmPinless
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(793, 547);
            this.Controls.Add(this.picTick);
            this.Controls.Add(this.pnlCapture);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblRefundWarning);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPinless";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pinless Airtime";
            this.Load += new System.EventHandler(this.frmPinless_Load);
            this.pnlCapture.ResumeLayout(false);
            this.pnlCapture.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCellNumber;
        private System.Windows.Forms.Label lblAccountNumber;
        private System.Windows.Forms.TextBox txtElecRand;
        private System.Windows.Forms.Label lblElecRand;
        private System.Windows.Forms.Label lblEnterValue;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblProvider;
        private System.Windows.Forms.Label lblRefundWarning;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlCapture;
        private System.Windows.Forms.FlowLayoutPanel flowPnlProvider;
        private System.Windows.Forms.Button picTick;
    }
}
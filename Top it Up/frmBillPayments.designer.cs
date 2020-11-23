namespace TopitUp
{
    partial class frmBillPayments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBillPayments));
            this.lblAccountNumber = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.lblAccNoLen = new System.Windows.Forms.Label();
            this.picTick = new System.Windows.Forms.PictureBox();
            this.txtAccountNumber = new System.Windows.Forms.TextBox();
            this.txtRandValue = new System.Windows.Forms.TextBox();
            this.picRandBg = new System.Windows.Forms.PictureBox();
            this.tmr_delayed_load = new System.Windows.Forms.Timer(this.components);
            this.pnlKeyboard = new System.Windows.Forms.Panel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlFooterRHS = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.pnlFooterLogedin = new System.Windows.Forms.Panel();
            this.btnOKNoFee = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnBillSearch = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlWrapper = new System.Windows.Forms.Panel();
            this.picBackground = new System.Windows.Forms.PictureBox();
            this.btnDC = new TopitUp.MyButton();
            this.btnCC = new TopitUp.MyButton();
            this.btnCash = new TopitUp.MyButton();
            this.virtualKeyboard1 = new TopitUp.virtualKeyboard();
            this.pnlInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRandBg)).BeginInit();
            this.pnlKeyboard.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlFooterRHS.SuspendLayout();
            this.pnlFooterLogedin.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlWrapper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAccountNumber
            // 
            this.lblAccountNumber.AutoSize = true;
            this.lblAccountNumber.Font = new System.Drawing.Font("Tahoma", 20F);
            this.lblAccountNumber.ForeColor = System.Drawing.Color.Maroon;
            this.lblAccountNumber.Location = new System.Drawing.Point(17, 22);
            this.lblAccountNumber.Name = "lblAccountNumber";
            this.lblAccountNumber.Size = new System.Drawing.Size(196, 33);
            this.lblAccountNumber.TabIndex = 39;
            this.lblAccountNumber.Text = "Confirmation #";
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.White;
            this.lblMessage.Font = new System.Drawing.Font("Courier New", 18F);
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMessage.Location = new System.Drawing.Point(23, 230);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(787, 242);
            this.lblMessage.TabIndex = 13;
            // 
            // pnlInput
            // 
            this.pnlInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.pnlInput.Controls.Add(this.lblAccNoLen);
            this.pnlInput.Controls.Add(this.picTick);
            this.pnlInput.Controls.Add(this.txtAccountNumber);
            this.pnlInput.Controls.Add(this.btnDC);
            this.pnlInput.Controls.Add(this.txtRandValue);
            this.pnlInput.Controls.Add(this.btnCC);
            this.pnlInput.Controls.Add(this.btnCash);
            this.pnlInput.Controls.Add(this.lblAccountNumber);
            this.pnlInput.Controls.Add(this.picRandBg);
            this.pnlInput.Location = new System.Drawing.Point(0, 0);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(839, 156);
            this.pnlInput.TabIndex = 12;
            // 
            // lblAccNoLen
            // 
            this.lblAccNoLen.AutoSize = true;
            this.lblAccNoLen.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccNoLen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblAccNoLen.Location = new System.Drawing.Point(776, 25);
            this.lblAccNoLen.Name = "lblAccNoLen";
            this.lblAccNoLen.Size = new System.Drawing.Size(0, 29);
            this.lblAccNoLen.TabIndex = 41;
            // 
            // picTick
            // 
            this.picTick.BackColor = System.Drawing.Color.White;
            this.picTick.Location = new System.Drawing.Point(28, 86);
            this.picTick.Name = "picTick";
            this.picTick.Size = new System.Drawing.Size(62, 48);
            this.picTick.TabIndex = 0;
            this.picTick.TabStop = false;
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAccountNumber.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAccountNumber.Location = new System.Drawing.Point(165, 17);
            this.txtAccountNumber.MaxLength = 38;
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Size = new System.Drawing.Size(599, 43);
            this.txtAccountNumber.TabIndex = 0;
            this.txtAccountNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAccountNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAccountNumber_KeyPress);
            this.txtAccountNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAccountNumber_KeyUp);
            // 
            // txtRandValue
            // 
            this.txtRandValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRandValue.Font = new System.Drawing.Font("Tahoma", 26F);
            this.txtRandValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(203)))), ((int)(((byte)(51)))));
            this.txtRandValue.Location = new System.Drawing.Point(604, 89);
            this.txtRandValue.MaxLength = 6;
            this.txtRandValue.Name = "txtRandValue";
            this.txtRandValue.Size = new System.Drawing.Size(155, 42);
            this.txtRandValue.TabIndex = 1;
            this.txtRandValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRandValue_KeyPress);
            this.txtRandValue.LostFocus += new System.EventHandler(this.numericTextBox_LostFocus);
            // 
            // picRandBg
            // 
            this.picRandBg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.picRandBg.Location = new System.Drawing.Point(555, 77);
            this.picRandBg.Name = "picRandBg";
            this.picRandBg.Size = new System.Drawing.Size(210, 67);
            this.picRandBg.TabIndex = 40;
            this.picRandBg.TabStop = false;
            // 
            // tmr_delayed_load
            // 
            this.tmr_delayed_load.Interval = 2000;
            this.tmr_delayed_load.Tick += new System.EventHandler(this.tmr_delayed_load_Tick);
            // 
            // pnlKeyboard
            // 
            this.pnlKeyboard.Controls.Add(this.virtualKeyboard1);
            this.pnlKeyboard.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlKeyboard.Location = new System.Drawing.Point(880, 0);
            this.pnlKeyboard.Name = "pnlKeyboard";
            this.pnlKeyboard.Size = new System.Drawing.Size(400, 800);
            this.pnlKeyboard.TabIndex = 49;
            this.pnlKeyboard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlKeyboard_Paint);
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.pnlFooter.Controls.Add(this.pnlFooterRHS);
            this.pnlFooter.Controls.Add(this.pnlFooterLogedin);
            this.pnlFooter.Controls.Add(this.btnAbout);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 710);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(880, 90);
            this.pnlFooter.TabIndex = 92;
            // 
            // pnlFooterRHS
            // 
            this.pnlFooterRHS.Controls.Add(this.btnOK);
            this.pnlFooterRHS.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFooterRHS.Location = new System.Drawing.Point(629, 0);
            this.pnlFooterRHS.Name = "pnlFooterRHS";
            this.pnlFooterRHS.Size = new System.Drawing.Size(251, 90);
            this.pnlFooterRHS.TabIndex = 37;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Tahoma", 20F);
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(0, 1);
            this.btnOK.Name = "btnOK";
            this.btnOK.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnOK.Size = new System.Drawing.Size(250, 89);
            this.btnOK.TabIndex = 41;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "Confirm";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlFooterLogedin
            // 
            this.pnlFooterLogedin.Controls.Add(this.btnOKNoFee);
            this.pnlFooterLogedin.Controls.Add(this.btnClear);
            this.pnlFooterLogedin.Controls.Add(this.btnClose);
            this.pnlFooterLogedin.Controls.Add(this.btnBillSearch);
            this.pnlFooterLogedin.Location = new System.Drawing.Point(0, 1);
            this.pnlFooterLogedin.Name = "pnlFooterLogedin";
            this.pnlFooterLogedin.Size = new System.Drawing.Size(629, 90);
            this.pnlFooterLogedin.TabIndex = 38;
            // 
            // btnOKNoFee
            // 
            this.btnOKNoFee.BackColor = System.Drawing.Color.ForestGreen;
            this.btnOKNoFee.FlatAppearance.BorderSize = 0;
            this.btnOKNoFee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOKNoFee.Font = new System.Drawing.Font("Tahoma", 20F);
            this.btnOKNoFee.ForeColor = System.Drawing.Color.White;
            this.btnOKNoFee.Image = ((System.Drawing.Image)(resources.GetObject("btnOKNoFee.Image")));
            this.btnOKNoFee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOKNoFee.Location = new System.Drawing.Point(378, 0);
            this.btnOKNoFee.Name = "btnOKNoFee";
            this.btnOKNoFee.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnOKNoFee.Size = new System.Drawing.Size(250, 89);
            this.btnOKNoFee.TabIndex = 42;
            this.btnOKNoFee.TabStop = false;
            this.btnOKNoFee.Text = "Pay Bill\r\nNo Fee";
            this.btnOKNoFee.UseVisualStyleBackColor = false;
            this.btnOKNoFee.Visible = false;
            this.btnOKNoFee.Click += new System.EventHandler(this.btnOKNoFee_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.ForestGreen;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 20F);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(251, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnClear.Size = new System.Drawing.Size(250, 89);
            this.btnClear.TabIndex = 24;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
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
            this.btnClose.Image = global::TopitUp.Properties.Resources.btnClose;
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
            // btnBillSearch
            // 
            this.btnBillSearch.BackColor = System.Drawing.Color.White;
            this.btnBillSearch.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnBillSearch.FlatAppearance.BorderSize = 0;
            this.btnBillSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBillSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBillSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBillSearch.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBillSearch.ForeColor = System.Drawing.Color.Gray;
            this.btnBillSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnBillSearch.Image")));
            this.btnBillSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBillSearch.Location = new System.Drawing.Point(251, 0);
            this.btnBillSearch.Name = "btnBillSearch";
            this.btnBillSearch.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnBillSearch.Size = new System.Drawing.Size(250, 89);
            this.btnBillSearch.TabIndex = 23;
            this.btnBillSearch.TabStop = false;
            this.btnBillSearch.Text = "Bill Issuer\r\nLookup";
            this.btnBillSearch.UseVisualStyleBackColor = false;
            this.btnBillSearch.Click += new System.EventHandler(this.btnBillSearch_Click);
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
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlWrapper);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(880, 710);
            this.pnlMain.TabIndex = 93;
            // 
            // pnlWrapper
            // 
            this.pnlWrapper.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlWrapper.Controls.Add(this.picBackground);
            this.pnlWrapper.Controls.Add(this.pnlInput);
            this.pnlWrapper.Controls.Add(this.lblMessage);
            this.pnlWrapper.Location = new System.Drawing.Point(21, 83);
            this.pnlWrapper.Name = "pnlWrapper";
            this.pnlWrapper.Size = new System.Drawing.Size(839, 545);
            this.pnlWrapper.TabIndex = 14;
            // 
            // picBackground
            // 
            this.picBackground.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picBackground.Location = new System.Drawing.Point(95, 219);
            this.picBackground.Name = "picBackground";
            this.picBackground.Size = new System.Drawing.Size(653, 253);
            this.picBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picBackground.TabIndex = 14;
            this.picBackground.TabStop = false;
            // 
            // btnDC
            // 
            this.btnDC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.btnDC.Font = new System.Drawing.Font("Arial", 22F, System.Drawing.FontStyle.Bold);
            this.btnDC.Location = new System.Drawing.Point(363, 80);
            this.btnDC.Name = "btnDC";
            this.btnDC.Size = new System.Drawing.Size(148, 59);
            this.btnDC.TabIndex = 27;
            this.btnDC.UseVisualStyleBackColor = false;
            this.btnDC.Click += new System.EventHandler(this.btnDC_Click);
            // 
            // btnCC
            // 
            this.btnCC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.btnCC.Font = new System.Drawing.Font("Arial", 22F, System.Drawing.FontStyle.Bold);
            this.btnCC.Location = new System.Drawing.Point(194, 80);
            this.btnCC.Name = "btnCC";
            this.btnCC.Size = new System.Drawing.Size(148, 59);
            this.btnCC.TabIndex = 28;
            this.btnCC.UseVisualStyleBackColor = false;
            this.btnCC.Click += new System.EventHandler(this.btnCC_Click);
            // 
            // btnCash
            // 
            this.btnCash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.btnCash.Font = new System.Drawing.Font("Arial", 22F, System.Drawing.FontStyle.Bold);
            this.btnCash.Location = new System.Drawing.Point(21, 80);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(148, 59);
            this.btnCash.TabIndex = 30;
            this.btnCash.UseVisualStyleBackColor = false;
            this.btnCash.Click += new System.EventHandler(this.btnCash_Click);
            // 
            // virtualKeyboard1
            // 
            this.virtualKeyboard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.virtualKeyboard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.virtualKeyboard1.Location = new System.Drawing.Point(0, 0);
            this.virtualKeyboard1.Name = "virtualKeyboard1";
            this.virtualKeyboard1.Size = new System.Drawing.Size(400, 800);
            this.virtualKeyboard1.TabIndex = 0;
            this.virtualKeyboard1.TabStop = false;
            // 
            // frmBillPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlKeyboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frmBillPayments";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Bill Payments";
            this.Load += new System.EventHandler(this.frmBillPayments_Load);
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRandBg)).EndInit();
            this.pnlKeyboard.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooterRHS.ResumeLayout(false);
            this.pnlFooterLogedin.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlWrapper.ResumeLayout(false);
            this.pnlWrapper.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblAccountNumber;
        private System.Windows.Forms.Label lblMessage;
        private MyButton btnDC;
        private MyButton btnCC;
        private System.Windows.Forms.PictureBox picTick;
        private MyButton btnCash;
        private System.Windows.Forms.TextBox txtRandValue;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.TextBox txtAccountNumber;
        private System.Windows.Forms.PictureBox picRandBg;
        private System.Windows.Forms.Timer tmr_delayed_load;
        private System.Windows.Forms.Panel pnlKeyboard;
        private virtualKeyboard virtualKeyboard1;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlFooterLogedin;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnBillSearch;
        private System.Windows.Forms.Panel pnlFooterRHS;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlWrapper;
        private System.Windows.Forms.Label lblAccNoLen;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.PictureBox picBackground;
        private System.Windows.Forms.Button btnOKNoFee;
    }
}
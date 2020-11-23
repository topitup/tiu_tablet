namespace TopitUp
{
    partial class frmWebBrowser
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
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlFooterLogedin = new System.Windows.Forms.Panel();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.pnlKeyboard = new System.Windows.Forms.Panel();
            this.virtualKeyboard1 = new TopitUp.virtualKeyboard();
            this.pnlFooter.SuspendLayout();
            this.pnlFooterLogedin.SuspendLayout();
            this.pnlKeyboard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.pnlFooter.Controls.Add(this.pnlFooterLogedin);
            this.pnlFooter.Controls.Add(this.btnAbout);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 623);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1008, 90);
            this.pnlFooter.TabIndex = 93;
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
            // btnCloseForm
            // 
            this.btnCloseForm.BackColor = System.Drawing.Color.White;
            this.btnCloseForm.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCloseForm.FlatAppearance.BorderSize = 0;
            this.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseForm.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.BackColor = System.Drawing.Color.White;
            this.btnAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(13)))), ((int)(((byte)(3)))));
            this.btnAbout.Location = new System.Drawing.Point(1078, 1);
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
            this.pnlKeyboard.Location = new System.Drawing.Point(608, 0);
            this.pnlKeyboard.Name = "pnlKeyboard";
            this.pnlKeyboard.Size = new System.Drawing.Size(400, 623);
            this.pnlKeyboard.TabIndex = 94;
            this.pnlKeyboard.Visible = false;
            // 
            // virtualKeyboard1
            // 
            this.virtualKeyboard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(218)))), ((int)(((byte)(222)))));
            this.virtualKeyboard1.CausesValidation = false;
            this.virtualKeyboard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.virtualKeyboard1.Location = new System.Drawing.Point(0, 0);
            this.virtualKeyboard1.Name = "virtualKeyboard1";
            this.virtualKeyboard1.Size = new System.Drawing.Size(400, 623);
            this.virtualKeyboard1.TabIndex = 0;
            this.virtualKeyboard1.TabStop = false;
            // 
            // frmWebBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 713);
            this.ControlBox = false;
            this.Controls.Add(this.pnlKeyboard);
            this.Controls.Add(this.pnlFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWebBrowser";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmWebBrowser_Load);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooterLogedin.ResumeLayout(false);
            this.pnlKeyboard.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlFooterLogedin;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Panel pnlKeyboard;
        private virtualKeyboard virtualKeyboard1;
    }
}
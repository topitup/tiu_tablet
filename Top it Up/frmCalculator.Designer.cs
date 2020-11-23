namespace TopitUp
{
    partial class frmCalculator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalculator));
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlFooterLogedin = new System.Windows.Forms.Panel();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.pnlWrapper = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtInput = new System.Windows.Forms.Label();
            this.lblHistory = new System.Windows.Forms.Label();
            this.tblKeypad = new System.Windows.Forms.TableLayoutPanel();
            this.cmd7 = new System.Windows.Forms.Button();
            this.cmd8 = new System.Windows.Forms.Button();
            this.cmd9 = new System.Windows.Forms.Button();
            this.btnPercent = new System.Windows.Forms.Button();
            this.cmd4 = new System.Windows.Forms.Button();
            this.cmd0 = new System.Windows.Forms.Button();
            this.cmd1 = new System.Windows.Forms.Button();
            this.cmdDivide = new System.Windows.Forms.Button();
            this.cmdEqual = new System.Windows.Forms.Button();
            this.cmd5 = new System.Windows.Forms.Button();
            this.cmd2 = new System.Windows.Forms.Button();
            this.cmdDecimal = new System.Windows.Forms.Button();
            this.cmd3 = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.btnVatSubtract = new System.Windows.Forms.Button();
            this.btnVatAdd = new System.Windows.Forms.Button();
            this.cmd6 = new System.Windows.Forms.Button();
            this.cmdSubtract = new System.Windows.Forms.Button();
            this.cmdMultiply = new System.Windows.Forms.Button();
            this.cmdBackspace = new System.Windows.Forms.Button();
            this.cmdClearEntry = new System.Windows.Forms.Button();
            this.cmdClearAll = new System.Windows.Forms.Button();
            this.pnlFooter.SuspendLayout();
            this.pnlFooterLogedin.SuspendLayout();
            this.pnlWrapper.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tblKeypad.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.pnlFooter.Controls.Add(this.pnlFooterLogedin);
            this.pnlFooter.Controls.Add(this.btnAbout);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 610);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1000, 90);
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
            this.btnAbout.Location = new System.Drawing.Point(1070, 1);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(140, 60);
            this.btnAbout.TabIndex = 36;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = false;
            // 
            // pnlWrapper
            // 
            this.pnlWrapper.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlWrapper.Controls.Add(this.lblHistory);
            this.pnlWrapper.Controls.Add(this.panel1);
            this.pnlWrapper.Controls.Add(this.tblKeypad);
            this.pnlWrapper.Controls.Add(this.cmdBackspace);
            this.pnlWrapper.Controls.Add(this.cmdClearEntry);
            this.pnlWrapper.Controls.Add(this.cmdClearAll);
            this.pnlWrapper.Location = new System.Drawing.Point(63, 17);
            this.pnlWrapper.Name = "pnlWrapper";
            this.pnlWrapper.Size = new System.Drawing.Size(877, 569);
            this.pnlWrapper.TabIndex = 94;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.txtInput);
            this.panel1.Location = new System.Drawing.Point(68, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(738, 79);
            this.panel1.TabIndex = 29;
            // 
            // txtInput
            // 
            this.txtInput.BackColor = System.Drawing.Color.Transparent;
            this.txtInput.Font = new System.Drawing.Font("Digital-7 Mono", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtInput.ForeColor = System.Drawing.Color.White;
            this.txtInput.Location = new System.Drawing.Point(24, 8);
            this.txtInput.Name = "txtInput";
            this.txtInput.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtInput.Size = new System.Drawing.Size(712, 55);
            this.txtInput.TabIndex = 30;
            this.txtInput.Text = "0";
            this.txtInput.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            // 
            // lblHistory
            // 
            this.lblHistory.BackColor = System.Drawing.Color.Transparent;
            this.lblHistory.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblHistory.Location = new System.Drawing.Point(264, 83);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.Size = new System.Drawing.Size(532, 23);
            this.lblHistory.TabIndex = 28;
            this.lblHistory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tblKeypad
            // 
            this.tblKeypad.ColumnCount = 5;
            this.tblKeypad.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblKeypad.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblKeypad.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblKeypad.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblKeypad.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblKeypad.Controls.Add(this.cmd7, 0, 0);
            this.tblKeypad.Controls.Add(this.cmd8, 1, 0);
            this.tblKeypad.Controls.Add(this.cmd9, 2, 0);
            this.tblKeypad.Controls.Add(this.btnPercent, 4, 2);
            this.tblKeypad.Controls.Add(this.cmd4, 0, 1);
            this.tblKeypad.Controls.Add(this.cmd0, 0, 3);
            this.tblKeypad.Controls.Add(this.cmd1, 0, 2);
            this.tblKeypad.Controls.Add(this.cmdDivide, 3, 0);
            this.tblKeypad.Controls.Add(this.cmdEqual, 4, 3);
            this.tblKeypad.Controls.Add(this.cmd5, 1, 1);
            this.tblKeypad.Controls.Add(this.cmd2, 1, 2);
            this.tblKeypad.Controls.Add(this.cmdDecimal, 2, 3);
            this.tblKeypad.Controls.Add(this.cmd3, 2, 2);
            this.tblKeypad.Controls.Add(this.cmdAdd, 3, 3);
            this.tblKeypad.Controls.Add(this.btnVatSubtract, 4, 1);
            this.tblKeypad.Controls.Add(this.btnVatAdd, 4, 0);
            this.tblKeypad.Controls.Add(this.cmd6, 2, 1);
            this.tblKeypad.Controls.Add(this.cmdSubtract, 3, 2);
            this.tblKeypad.Controls.Add(this.cmdMultiply, 3, 1);
            this.tblKeypad.Location = new System.Drawing.Point(78, 197);
            this.tblKeypad.Name = "tblKeypad";
            this.tblKeypad.RowCount = 4;
            this.tblKeypad.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblKeypad.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblKeypad.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblKeypad.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblKeypad.Size = new System.Drawing.Size(712, 365);
            this.tblKeypad.TabIndex = 27;
            // 
            // cmd7
            // 
            this.cmd7.BackColor = System.Drawing.Color.White;
            this.cmd7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmd7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd7.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd7.ForeColor = System.Drawing.Color.Gray;
            this.cmd7.Location = new System.Drawing.Point(5, 5);
            this.cmd7.Margin = new System.Windows.Forms.Padding(5);
            this.cmd7.Name = "cmd7";
            this.cmd7.Size = new System.Drawing.Size(132, 81);
            this.cmd7.TabIndex = 7;
            this.cmd7.Text = "7";
            this.cmd7.UseVisualStyleBackColor = false;
            this.cmd7.Click += new System.EventHandler(this.digit_Click);
            // 
            // cmd8
            // 
            this.cmd8.BackColor = System.Drawing.Color.White;
            this.cmd8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmd8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd8.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd8.ForeColor = System.Drawing.Color.Gray;
            this.cmd8.Location = new System.Drawing.Point(147, 5);
            this.cmd8.Margin = new System.Windows.Forms.Padding(5);
            this.cmd8.Name = "cmd8";
            this.cmd8.Size = new System.Drawing.Size(132, 81);
            this.cmd8.TabIndex = 18;
            this.cmd8.Text = "8";
            this.cmd8.UseVisualStyleBackColor = false;
            this.cmd8.Click += new System.EventHandler(this.digit_Click);
            // 
            // cmd9
            // 
            this.cmd9.BackColor = System.Drawing.Color.White;
            this.cmd9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmd9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd9.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd9.ForeColor = System.Drawing.Color.Gray;
            this.cmd9.Location = new System.Drawing.Point(289, 5);
            this.cmd9.Margin = new System.Windows.Forms.Padding(5);
            this.cmd9.Name = "cmd9";
            this.cmd9.Size = new System.Drawing.Size(132, 81);
            this.cmd9.TabIndex = 17;
            this.cmd9.Text = "9";
            this.cmd9.UseVisualStyleBackColor = false;
            this.cmd9.Click += new System.EventHandler(this.digit_Click);
            // 
            // btnPercent
            // 
            this.btnPercent.BackColor = System.Drawing.Color.White;
            this.btnPercent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPercent.FlatAppearance.BorderSize = 2;
            this.btnPercent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPercent.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPercent.ForeColor = System.Drawing.Color.Maroon;
            this.btnPercent.Location = new System.Drawing.Point(573, 187);
            this.btnPercent.Margin = new System.Windows.Forms.Padding(5);
            this.btnPercent.Name = "btnPercent";
            this.btnPercent.Size = new System.Drawing.Size(134, 81);
            this.btnPercent.TabIndex = 25;
            this.btnPercent.Text = "%";
            this.btnPercent.UseVisualStyleBackColor = false;
            this.btnPercent.Click += new System.EventHandler(this.btnPercent_Click);
            // 
            // cmd4
            // 
            this.cmd4.BackColor = System.Drawing.Color.White;
            this.cmd4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmd4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd4.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd4.ForeColor = System.Drawing.Color.Gray;
            this.cmd4.Location = new System.Drawing.Point(5, 96);
            this.cmd4.Margin = new System.Windows.Forms.Padding(5);
            this.cmd4.Name = "cmd4";
            this.cmd4.Size = new System.Drawing.Size(132, 81);
            this.cmd4.TabIndex = 16;
            this.cmd4.Text = "4";
            this.cmd4.UseVisualStyleBackColor = false;
            this.cmd4.Click += new System.EventHandler(this.digit_Click);
            // 
            // cmd0
            // 
            this.cmd0.BackColor = System.Drawing.Color.White;
            this.cmd0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmd0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd0.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd0.ForeColor = System.Drawing.Color.Gray;
            this.cmd0.Location = new System.Drawing.Point(5, 278);
            this.cmd0.Margin = new System.Windows.Forms.Padding(5);
            this.cmd0.Name = "cmd0";
            this.cmd0.Size = new System.Drawing.Size(132, 82);
            this.cmd0.TabIndex = 10;
            this.cmd0.Text = "0";
            this.cmd0.UseVisualStyleBackColor = false;
            this.cmd0.Click += new System.EventHandler(this.digit_Click);
            // 
            // cmd1
            // 
            this.cmd1.BackColor = System.Drawing.Color.White;
            this.cmd1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmd1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd1.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd1.ForeColor = System.Drawing.Color.Gray;
            this.cmd1.Location = new System.Drawing.Point(5, 187);
            this.cmd1.Margin = new System.Windows.Forms.Padding(5);
            this.cmd1.Name = "cmd1";
            this.cmd1.Size = new System.Drawing.Size(132, 81);
            this.cmd1.TabIndex = 13;
            this.cmd1.Text = "1";
            this.cmd1.UseVisualStyleBackColor = false;
            this.cmd1.Click += new System.EventHandler(this.digit_Click);
            // 
            // cmdDivide
            // 
            this.cmdDivide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.cmdDivide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdDivide.FlatAppearance.BorderSize = 0;
            this.cmdDivide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdDivide.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDivide.ForeColor = System.Drawing.Color.White;
            this.cmdDivide.Location = new System.Drawing.Point(431, 5);
            this.cmdDivide.Margin = new System.Windows.Forms.Padding(5);
            this.cmdDivide.Name = "cmdDivide";
            this.cmdDivide.Size = new System.Drawing.Size(132, 81);
            this.cmdDivide.TabIndex = 8;
            this.cmdDivide.Text = "/";
            this.cmdDivide.UseVisualStyleBackColor = false;
            this.cmdDivide.Click += new System.EventHandler(this.operator_Click);
            // 
            // cmdEqual
            // 
            this.cmdEqual.BackColor = System.Drawing.Color.ForestGreen;
            this.cmdEqual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdEqual.FlatAppearance.BorderSize = 0;
            this.cmdEqual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdEqual.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEqual.ForeColor = System.Drawing.Color.White;
            this.cmdEqual.Location = new System.Drawing.Point(573, 278);
            this.cmdEqual.Margin = new System.Windows.Forms.Padding(5);
            this.cmdEqual.Name = "cmdEqual";
            this.cmdEqual.Size = new System.Drawing.Size(134, 82);
            this.cmdEqual.TabIndex = 22;
            this.cmdEqual.Text = "=";
            this.cmdEqual.UseVisualStyleBackColor = false;
            this.cmdEqual.Click += new System.EventHandler(this.cmdEqual_Click);
            // 
            // cmd5
            // 
            this.cmd5.BackColor = System.Drawing.Color.White;
            this.cmd5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmd5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd5.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd5.ForeColor = System.Drawing.Color.Gray;
            this.cmd5.Location = new System.Drawing.Point(147, 96);
            this.cmd5.Margin = new System.Windows.Forms.Padding(5);
            this.cmd5.Name = "cmd5";
            this.cmd5.Size = new System.Drawing.Size(132, 81);
            this.cmd5.TabIndex = 15;
            this.cmd5.Text = "5";
            this.cmd5.UseVisualStyleBackColor = false;
            this.cmd5.Click += new System.EventHandler(this.digit_Click);
            // 
            // cmd2
            // 
            this.cmd2.BackColor = System.Drawing.Color.White;
            this.cmd2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmd2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd2.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd2.ForeColor = System.Drawing.Color.Gray;
            this.cmd2.Location = new System.Drawing.Point(147, 187);
            this.cmd2.Margin = new System.Windows.Forms.Padding(5);
            this.cmd2.Name = "cmd2";
            this.cmd2.Size = new System.Drawing.Size(132, 81);
            this.cmd2.TabIndex = 12;
            this.cmd2.Text = "2";
            this.cmd2.UseVisualStyleBackColor = false;
            this.cmd2.Click += new System.EventHandler(this.digit_Click);
            // 
            // cmdDecimal
            // 
            this.cmdDecimal.BackColor = System.Drawing.Color.White;
            this.cmdDecimal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdDecimal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdDecimal.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDecimal.ForeColor = System.Drawing.Color.Gray;
            this.cmdDecimal.Location = new System.Drawing.Point(289, 278);
            this.cmdDecimal.Margin = new System.Windows.Forms.Padding(5);
            this.cmdDecimal.Name = "cmdDecimal";
            this.cmdDecimal.Size = new System.Drawing.Size(132, 82);
            this.cmdDecimal.TabIndex = 20;
            this.cmdDecimal.Text = ".";
            this.cmdDecimal.UseVisualStyleBackColor = false;
            this.cmdDecimal.Click += new System.EventHandler(this.digit_Click);
            // 
            // cmd3
            // 
            this.cmd3.BackColor = System.Drawing.Color.White;
            this.cmd3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmd3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd3.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd3.ForeColor = System.Drawing.Color.Gray;
            this.cmd3.Location = new System.Drawing.Point(289, 187);
            this.cmd3.Margin = new System.Windows.Forms.Padding(5);
            this.cmd3.Name = "cmd3";
            this.cmd3.Size = new System.Drawing.Size(132, 81);
            this.cmd3.TabIndex = 11;
            this.cmd3.Text = "3";
            this.cmd3.UseVisualStyleBackColor = false;
            this.cmd3.Click += new System.EventHandler(this.digit_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.cmdAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdAdd.FlatAppearance.BorderSize = 0;
            this.cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAdd.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAdd.ForeColor = System.Drawing.Color.White;
            this.cmdAdd.Location = new System.Drawing.Point(431, 278);
            this.cmdAdd.Margin = new System.Windows.Forms.Padding(5);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(132, 82);
            this.cmdAdd.TabIndex = 21;
            this.cmdAdd.Text = "+";
            this.cmdAdd.UseVisualStyleBackColor = false;
            this.cmdAdd.Click += new System.EventHandler(this.operator_Click);
            // 
            // btnVatSubtract
            // 
            this.btnVatSubtract.BackColor = System.Drawing.Color.White;
            this.btnVatSubtract.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVatSubtract.FlatAppearance.BorderSize = 2;
            this.btnVatSubtract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVatSubtract.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVatSubtract.ForeColor = System.Drawing.Color.Maroon;
            this.btnVatSubtract.Location = new System.Drawing.Point(573, 96);
            this.btnVatSubtract.Margin = new System.Windows.Forms.Padding(5);
            this.btnVatSubtract.Name = "btnVatSubtract";
            this.btnVatSubtract.Size = new System.Drawing.Size(134, 81);
            this.btnVatSubtract.TabIndex = 24;
            this.btnVatSubtract.Text = "-VAT";
            this.btnVatSubtract.UseVisualStyleBackColor = false;
            this.btnVatSubtract.Click += new System.EventHandler(this.btnVatSubtract_Click);
            // 
            // btnVatAdd
            // 
            this.btnVatAdd.BackColor = System.Drawing.Color.White;
            this.btnVatAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVatAdd.FlatAppearance.BorderSize = 2;
            this.btnVatAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVatAdd.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVatAdd.ForeColor = System.Drawing.Color.Maroon;
            this.btnVatAdd.Location = new System.Drawing.Point(573, 5);
            this.btnVatAdd.Margin = new System.Windows.Forms.Padding(5);
            this.btnVatAdd.Name = "btnVatAdd";
            this.btnVatAdd.Size = new System.Drawing.Size(134, 81);
            this.btnVatAdd.TabIndex = 23;
            this.btnVatAdd.Text = "+VAT";
            this.btnVatAdd.UseVisualStyleBackColor = false;
            this.btnVatAdd.Click += new System.EventHandler(this.btnVatAdd_Click);
            // 
            // cmd6
            // 
            this.cmd6.BackColor = System.Drawing.Color.White;
            this.cmd6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmd6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd6.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd6.ForeColor = System.Drawing.Color.Gray;
            this.cmd6.Location = new System.Drawing.Point(289, 96);
            this.cmd6.Margin = new System.Windows.Forms.Padding(5);
            this.cmd6.Name = "cmd6";
            this.cmd6.Size = new System.Drawing.Size(132, 81);
            this.cmd6.TabIndex = 14;
            this.cmd6.Text = "6";
            this.cmd6.UseVisualStyleBackColor = false;
            this.cmd6.Click += new System.EventHandler(this.digit_Click);
            // 
            // cmdSubtract
            // 
            this.cmdSubtract.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.cmdSubtract.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdSubtract.FlatAppearance.BorderSize = 0;
            this.cmdSubtract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSubtract.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSubtract.ForeColor = System.Drawing.Color.White;
            this.cmdSubtract.Location = new System.Drawing.Point(431, 187);
            this.cmdSubtract.Margin = new System.Windows.Forms.Padding(5);
            this.cmdSubtract.Name = "cmdSubtract";
            this.cmdSubtract.Size = new System.Drawing.Size(132, 81);
            this.cmdSubtract.TabIndex = 19;
            this.cmdSubtract.Text = "-";
            this.cmdSubtract.UseVisualStyleBackColor = false;
            this.cmdSubtract.Click += new System.EventHandler(this.operator_Click);
            // 
            // cmdMultiply
            // 
            this.cmdMultiply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.cmdMultiply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdMultiply.FlatAppearance.BorderSize = 0;
            this.cmdMultiply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMultiply.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMultiply.ForeColor = System.Drawing.Color.White;
            this.cmdMultiply.Location = new System.Drawing.Point(431, 96);
            this.cmdMultiply.Margin = new System.Windows.Forms.Padding(5);
            this.cmdMultiply.Name = "cmdMultiply";
            this.cmdMultiply.Size = new System.Drawing.Size(132, 81);
            this.cmdMultiply.TabIndex = 9;
            this.cmdMultiply.Text = "*";
            this.cmdMultiply.UseVisualStyleBackColor = false;
            this.cmdMultiply.Click += new System.EventHandler(this.operator_Click);
            // 
            // cmdBackspace
            // 
            this.cmdBackspace.FlatAppearance.BorderSize = 2;
            this.cmdBackspace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBackspace.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBackspace.ForeColor = System.Drawing.Color.Gray;
            this.cmdBackspace.Location = new System.Drawing.Point(81, 111);
            this.cmdBackspace.Name = "cmdBackspace";
            this.cmdBackspace.Size = new System.Drawing.Size(276, 80);
            this.cmdBackspace.TabIndex = 4;
            this.cmdBackspace.Text = "Backspace";
            this.cmdBackspace.UseVisualStyleBackColor = true;
            this.cmdBackspace.Click += new System.EventHandler(this.cmdBackspace_Click);
            // 
            // cmdClearEntry
            // 
            this.cmdClearEntry.FlatAppearance.BorderSize = 2;
            this.cmdClearEntry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdClearEntry.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClearEntry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdClearEntry.Location = new System.Drawing.Point(507, 111);
            this.cmdClearEntry.Name = "cmdClearEntry";
            this.cmdClearEntry.Size = new System.Drawing.Size(136, 80);
            this.cmdClearEntry.TabIndex = 5;
            this.cmdClearEntry.Text = "CE";
            this.cmdClearEntry.UseVisualStyleBackColor = true;
            this.cmdClearEntry.Click += new System.EventHandler(this.cmdClearEntry_Click);
            // 
            // cmdClearAll
            // 
            this.cmdClearAll.BackColor = System.Drawing.Color.Maroon;
            this.cmdClearAll.FlatAppearance.BorderSize = 0;
            this.cmdClearAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdClearAll.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClearAll.ForeColor = System.Drawing.Color.White;
            this.cmdClearAll.Location = new System.Drawing.Point(649, 111);
            this.cmdClearAll.Name = "cmdClearAll";
            this.cmdClearAll.Size = new System.Drawing.Size(138, 80);
            this.cmdClearAll.TabIndex = 6;
            this.cmdClearAll.Text = "C";
            this.cmdClearAll.UseVisualStyleBackColor = false;
            this.cmdClearAll.Click += new System.EventHandler(this.cmdClearAll_Click);
            // 
            // frmCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.ControlBox = false;
            this.Controls.Add(this.pnlWrapper);
            this.Controls.Add(this.pnlFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCalculator";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmCalculator_Load);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooterLogedin.ResumeLayout(false);
            this.pnlWrapper.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tblKeypad.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlFooterLogedin;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Panel pnlWrapper;
        internal System.Windows.Forms.Button btnPercent;
        internal System.Windows.Forms.Button btnVatSubtract;
        internal System.Windows.Forms.Button cmdBackspace;
        internal System.Windows.Forms.Button btnVatAdd;
        internal System.Windows.Forms.Button cmdClearEntry;
        internal System.Windows.Forms.Button cmdEqual;
        internal System.Windows.Forms.Button cmdClearAll;
        internal System.Windows.Forms.Button cmdAdd;
        internal System.Windows.Forms.Button cmd7;
        internal System.Windows.Forms.Button cmdDecimal;
        internal System.Windows.Forms.Button cmdDivide;
        internal System.Windows.Forms.Button cmdSubtract;
        internal System.Windows.Forms.Button cmdMultiply;
        internal System.Windows.Forms.Button cmd8;
        internal System.Windows.Forms.Button cmd0;
        internal System.Windows.Forms.Button cmd9;
        internal System.Windows.Forms.Button cmd3;
        internal System.Windows.Forms.Button cmd4;
        internal System.Windows.Forms.Button cmd2;
        internal System.Windows.Forms.Button cmd5;
        internal System.Windows.Forms.Button cmd1;
        internal System.Windows.Forms.Button cmd6;
        private System.Windows.Forms.TableLayoutPanel tblKeypad;
        private System.Windows.Forms.Label lblHistory;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtInput;
    }
}
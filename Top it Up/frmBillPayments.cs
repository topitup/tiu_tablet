using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TopitUp
{
    public partial class frmBillPayments : Form
    {

        private System.Windows.Forms.WebBrowser wbBillIssuer;
        bool wbBillIssuerVisible = false;

        public bool is_mamamoney = false;

        private string _current_action = "";
        private string _current_acc_number = "";

        //private readonly frmHome _frmHome;

        int step = 0;
        String payment_type = "0";

        public frmBillPayments()
        {
            InitializeComponent();
        }

        //public frmBillPayments(frmHome FrmHome)
        //{
        //    _frmHome = FrmHome;
        //    InitializeComponent();
        //}

        //private void digitsOnly(object sender, System.Windows.Forms.KeyEventArgs e)
        //{
        //    bool nonNumberEntered = false;
        //    if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
        //    {
        //        if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
        //        {
        //            if (e.KeyCode != Keys.Back)
        //            {
        //                nonNumberEntered = true;
        //            }
        //        }
        //    }
        //    if (nonNumberEntered == true)
        //    {
        //        e.Handled = true;
        //    }
        //}

        private void frmBillPayments_Load(object sender, EventArgs e)
        {

            if (globalSettings.allow_screen_resize == "0")
            {
                this.Left = 0;
                this.Width = Screen.PrimaryScreen.Bounds.Width;
                this.Top = 100;
                this.Height = Screen.PrimaryScreen.Bounds.Height - 100;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.Left = Util._home_form.Left + 8;
                this.Width = Util._home_form.Width - 16;
                this.Top = Util._home_form.Top + 131;
                this.Height = 700;
            }

            if (globalSettings.gen_virtual_keyboard == "1")
            {
                pnlKeyboard.Visible = true;

                //virtualKeyboard1.setKeyPadOnly(true);
                virtualKeyboard1.showKeyPadPoint();

            }
            else
            {
                pnlKeyboard.Visible = false;
            }

            //txtRandValue.AllowDecimal = true;
            //txtRandValue.SetMaxLength = 5;

            //txtAccountNumber.SetMaxLength = 20;

            // this.txtAccountNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.digitsOnly);

            //btnClose.ImageDefault = Util.btngeneral1;
            //btnClose.ImagePressed = Util.btngeneral0;
            //btnOK.ImageDefault = Util.btngeneral4;
            //btnOK.ImagePressed = Util.btngeneral0;
            //btnBillSearch.ImageDefault = Util.btngeneralsearch;
            //btnBillSearch.ImagePressed = Util.btngeneral0;

            btnCash.Image = new Bitmap(globalSettings.app_path + @"\images\bill_cash.gif");
            btnDC.Image = new Bitmap(globalSettings.app_path + @"\images\bill_dc.gif");
            btnCC.Image = new Bitmap(globalSettings.app_path + @"\images\bill_cc.gif");

            picTick.Image = new Bitmap(globalSettings.app_path + @"\images\bill_tick.gif");
            picRandBg.Image = new Bitmap(globalSettings.app_path + @"\images\elec_rand.gif");

            if (is_mamamoney)
            {
                lblAccountNumber.Text = "Confirmation #";
                txtAccountNumber.Width = 599 - 55;
                txtAccountNumber.Left = 165 + 55;

                picBackground.Image = new Bitmap(globalSettings.app_path + @"\images\mamamoney-bg.jpg");
                btnBillSearch.Visible = false;
            }
            else
            {

                picBackground.Image = new Bitmap(globalSettings.app_path + @"\images\bill-payments-bg.jpg");

                this.wbBillIssuer = new System.Windows.Forms.WebBrowser();
                this.wbBillIssuer.Parent = this;
                this.wbBillIssuer.Dock = DockStyle.Fill;

                this.wbBillIssuer.Name = "wbBillIssuer";
                this.wbBillIssuer.Visible = false;
                this.wbBillIssuer.BringToFront();

            }

           
            btnClose.BringToFront();

            step = 0;

            Util.showWait(false);

            this.Activate();

            txtAccountNumber.Select();

        }


        private void showMsg(string msg, int align, Color txtColor)
        {

            lblMessage.Hide();

            if (msg.Length == 0)
            {
                return;
            }

            this.SuspendLayout();

            lblMessage.ForeColor = txtColor;

            if (align == 1)
            {
                lblMessage.TextAlign = ContentAlignment.TopCenter;
            }
            else
            {
                lblMessage.TextAlign = ContentAlignment.TopLeft;
            }

            lblMessage.Text = msg;
            lblMessage.Show();
            lblMessage.Refresh();

            this.ResumeLayout();
            this.Refresh();

            Application.DoEvents();

        }



        private void btnClose_Click(object sender, EventArgs e)
        {

            no_fee = 1;

            if (wbBillIssuerVisible)
            {
                wbBillIssuerVisible = false;
                wbBillIssuer.Visible = false;
                pnlInput.Visible = true;
                btnOK.Visible = true;
                btnBillSearch.Visible = true;
                return;
            }

            if (btnClose.Text.Equals("Cancel")) 
            {
                
                showMsg("",1,Color.Black);
                btnOK.Text= "Confirm";
                btnOK.Enabled = true;
                btnClear.Visible = true;
                btnClose.Text = "Close";
                btnClose.Enabled = true;

                txtAccountNumber.Enabled = true;
                txtRandValue.Enabled = true;

                txtRandValue.Focus();
                
                step = 0;

                return;
            }

            this.Close();

        }



        private void btnOK_Click(object sender, EventArgs e)
        {

            picBackground.Visible = false;

            showMsg("",1,Color.Black);

            btnBillSearch.Visible = false;
            txtAccountNumber.Enabled = false;
            txtRandValue.Enabled = false;

            _current_acc_number = txtAccountNumber.Text.Replace("-", "").Trim();

            if (_current_acc_number == "")
            {
                showMsg("Please enter a payment reference number.", 1, Color.Firebrick);
                txtAccountNumber.Enabled = true;
                txtRandValue.Enabled = true;
                txtAccountNumber.Focus();
                return;
            }

            if (txtRandValue.Text == "")
            {
                showMsg("Please enter a payment amount.", 1, Color.Firebrick);
                txtAccountNumber.Enabled = true;
                txtRandValue.Enabled = true;
                txtRandValue.Focus();
                return;
            }

            string value = txtRandValue.Text.Replace(".", "");
                   value = value.Replace(",", "");

            if (Convert.ToInt32(value) > 2000000)
            {
                showMsg("Amount entered is too high.", 1, Color.Firebrick);
                txtAccountNumber.Enabled = true;
                txtRandValue.Enabled = true;
                txtRandValue.Focus();
                return;
            }

            btnOK.Text = "...";
            btnOK.Enabled = false;
            btnOK.Refresh();

            btnClose.Enabled = false;
            btnClose.Refresh();

            string htmlResponse = "";

            string process = "0";
            if (step == 1)
            {
                process = "1";
            }

            String convenience_fee = "";

            if (no_fee == 0) convenience_fee = "&fee=0";

            Util.showWait("Processing Bill Payment Request.");

            Web WebResponse = new Web(60000);

            if (is_mamamoney)
            {
                htmlResponse = WebResponse.GetURL("/payaccount/payment/do-payment-mamamoney?accno=" + _current_acc_number + "&amt=" + value + "&cc=" + payment_type + "&p=" + process + convenience_fee);
            }
            else
            {
                htmlResponse = WebResponse.GetURL("/payaccount/payment/do-payment?accno=" + _current_acc_number + "&amt=" + value + "&cc=" + payment_type + "&p=" + process + convenience_fee);
            }
            WebResponse = null;

            Util.showWait(false);

            if (htmlResponse.IndexOf("err>") > -1)
            {

                showMsg(htmlResponse.StripErrorTags(), 1, Color.Firebrick);
                
                btnOK.Enabled = true;
                btnClose.Enabled = true;

                txtAccountNumber.Enabled = true;
                txtRandValue.Enabled = true;

                txtAccountNumber.Focus();

                btnOK.Text = "Confirm";
                step = 0;

            }
            else
            {

                if (step == 0)
                {

                    showMsg(htmlResponse, 0, Color.Black);

                    btnOK.Text = "Pay Bill";
                    btnOK.Enabled = true;

                    btnOKNoFee.Visible = false;

                    if (globalSettings.pos_user_admin)
                    {
                        if (globalSettings.gen_cashier_billconvenience_admin.Equals("1"))
                        {
                            btnOKNoFee.Visible = true;
                        }
                    }
                    else
                    {
                        if (globalSettings.gen_cashier_billconvenience_cashier.Equals("1"))
                        {
                            btnOKNoFee.Visible = true;
                        }
                    }

                    btnClear.Visible = false;

                    btnClose.Text = "Cancel";
                    btnClose.Enabled = true;
                    step = 1;
                }
                else
                {

                    btnOKNoFee.Visible = false;
                    btnOK.Visible = false;
                    btnClose.Enabled = true;
                    btnClose.Text = "Done!";

                    if (globalSettings.gen_cashdr == "1")
                    {
                        //Util.OpenCashDrawer();
                        Util.DoOpenCashDrawer = true;
                    }

                    try
                    {
                        Newtonsoft.Json.Linq.JObject json = Newtonsoft.Json.Linq.JObject.Parse(htmlResponse);

                        finBalance.populateBalanceFromJson(json);

                        string print_data = "";
                        if (!String.IsNullOrEmpty((string)json["print_data"]))
                        {
                            byte[] data = Convert.FromBase64String((string)json["print_data"]);
                            print_data = System.Text.Encoding.UTF8.GetString(data,0, data.Length);
                        }

                        Util.printBillPaymentSlip(print_data);

                        String _value = String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:0.00}", Decimal.Parse(txtRandValue.Text.Replace(",", ""), System.Globalization.CultureInfo.InvariantCulture));

                        //String _value = value.Substring(0, value.Length - 2) + "." + value.Substring(value.Length - 2, value.Length);

                        if (globalSettings.gen_show_last_sale_login == "1")
                        {
                            try
                            {
                                globalVoucher.setLastSaleDetail("Bill Payment, " + txtAccountNumber.Text, "R " + _value, globalSettings.pos_user_firstname, "", finBalance.dtmd, finBalance.dtmt);
                            }
                            catch
                            {
                                globalVoucher.clearLastSaleDetail();
                            }
                        }

                        //_frmHome.refreshBalanceStatus();

                    }
                    catch (Exception ex)
                    {
                        Util.showMessage(ex.Message, Color.Red);
                    }

                    showMsg(Environment.NewLine + "Payment complete." + Environment.NewLine + Environment.NewLine + "Please check your reprint history if there was a problem printing the confirmation slip.", 1, Color.Black);

                }

            }


        }

        private void btnDC_Click(object sender, EventArgs e)
        {
            if (step == 1) return;

            btnOK.Focus();
            picTick.Left = 371;
            payment_type = "2";
            txtRandValue.Focus();

        }

        private void btnCC_Click(object sender, EventArgs e)
        {

            if (step == 1) return;

            btnOK.Focus();
            picTick.Left = 201;
            payment_type = "1";
            txtRandValue.Focus();

        }

        private void btnCash_Click(object sender, EventArgs e)
        {

            if (step == 1) return;

            btnOK.Focus();
            picTick.Left = 28;
            payment_type = "0";
            txtRandValue.Focus();

        }

        private void numericTextBox_LostFocus(object sender, EventArgs e)
        {
            decimal amount = 0.0m;

            try
            {
                amount = Decimal.Parse(txtRandValue.Text.Replace(",", ""), System.Globalization.CultureInfo.InvariantCulture);
                txtRandValue.Text = String.Format( System.Globalization.CultureInfo.InvariantCulture , "{0:0.00}", amount);
            }
            catch
            {
                //
            }   
          
        }


        private void btnBillSearch_Click(object sender, EventArgs e)
        {
            
            wbBillIssuerVisible = true;

            pnlInput.Visible = false;
            btnOK.Visible = false;
            btnBillSearch.Visible = false;

            wbBillIssuer.Visible = true;

            this.wbBillIssuer.Url = new Uri("file://c:/topitup/html/busyWait.htm");
            this.wbBillIssuer.Show();

            start_delayed_load("refresh_bill_issuers", 2000);

        }

        private void start_delayed_load(String action, int interval)
        {
            _current_action = action;
            tmr_delayed_load.Interval = interval;
            tmr_delayed_load.Enabled = true;
        }

        private void tmr_delayed_load_Tick(object sender, EventArgs e)
        {

            tmr_delayed_load.Interval = 2000;
            tmr_delayed_load.Enabled = false;

            if (_current_action == "refresh_bill_issuers")
            {

                string htmlResponse = "";
                try
                {

                    Web WebResponse = new Web(45000);
                    htmlResponse = WebResponse.GetURL("/payaccount/general/get-utility");
                    WebResponse = null;

                    if (htmlResponse.IndexOf("err>") > -1) {
                        Util.showMessage(htmlResponse.StripErrorTags(), Color.Red);
                    } else if (htmlResponse != "") {
                        this.wbBillIssuer.DocumentText = htmlResponse;
                    } else {
                        Util.showMessage("The server has not responded in time, please check your internet connection.", Color.Red);
                    }

                }
                catch (Exception ex)
                {
                    Util.showMessage(ex.Message, Color.Red);
                }


            }

            _current_action = "";

        }

        private void pnlKeyboard_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = pnlKeyboard.CreateGraphics();

            Rectangle panelRect = pnlKeyboard.ClientRectangle;

            Point p1 = new Point(panelRect.Left, panelRect.Top); //top left
            Point p2 = new Point(panelRect.Right - 1, panelRect.Top); //Top Right
            Point p3 = new Point(panelRect.Left, panelRect.Bottom - 1); //Bottom Left
            Point p4 = new Point(panelRect.Right - 1, panelRect.Bottom - 1); //Bottom

            Pen pen1 = new Pen(System.Drawing.Color.White);
            Pen pen2 = new Pen(System.Drawing.Color.LightGray);

            g.DrawLine(pen1, p1, p2);
            g.DrawLine(pen2, p1, p3);
            g.DrawLine(pen1, p2, p4);
            g.DrawLine(pen1, p3, p4);
        }

        private void txtAccountNumber_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)  && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txtRandValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtAccountNumber_KeyUp(object sender, KeyEventArgs e)
        {

            String val = txtAccountNumber.Text.Trim().Replace("-", "");
            txtAccountNumber.Text = Regex.Replace(val, @".{5}(?!$)", "$0-").ToUpper();
            txtAccountNumber.SelectionStart = txtAccountNumber.Text.Length;

            lblAccNoLen.Text = (val.Length > 0) ? val.Length.ToString() : "";

            btnClear.Visible = (val.Length > 0) ? true : false;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            no_fee = 1;
            txtAccountNumber.Text = "";
            txtRandValue.Text = "";
            lblAccNoLen.Text = "";
            showMsg("", 1, Color.Black);
            btnClear.Visible = false;

        }


        private int no_fee = 1;
        private void btnOKNoFee_Click(object sender, EventArgs e)
        {

            btnOKNoFee.Text = "...";
            btnOKNoFee.Enabled = false;
            btnOKNoFee.Refresh();

            no_fee = 0;
            btnOK.PerformClick();

        }
       
    

    }
}
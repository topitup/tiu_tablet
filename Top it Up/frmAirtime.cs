using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopitUp
{
    public partial class frmAirtime : Form
    {

        Form centerWrapper = new Form();

        int voucher_prov_arr_id = 0;
        int voucher_item_arr_id = 0;

        public String _item_id = "0";
        public bool _is_quick_print = false;
        bool is_multi_voucher = false;



        private string _current_action = ""; 

        public frmAirtime(ListBox listBox)
        {
            InitializeComponent();
            lstMultiVoucher.Items.AddRange(listBox.Items);
        }

        private void start_delayed_load(String action, int interval)
        {
            _current_action = action;
            tmr_delayed_load.Interval = interval;
            tmr_delayed_load.Enabled = true;
        }

        private void tmr_delayed_load_Tick(object sender, EventArgs e)
        {

            tmr_delayed_load.Enabled = false;

            if (_current_action == "start_quick_print")
            {
                btnVoucherOKClick();
            }

            _current_action = "";

        }

        private void frmAirtime_Load(object sender, EventArgs e)
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

            centerWrapper.StartPosition = FormStartPosition.Manual;
            centerWrapper.FormBorderStyle = FormBorderStyle.None;
            centerWrapper.ShowInTaskbar = false;

            centerWrapper.BackColor = Color.White;

            if ((_is_quick_print && globalSettings.gen_quick_print_confirm.Equals("0")) || globalSettings.gen_show_voucher_only.Equals("1") && !_item_id.Equals("-1")) 
            {
                pnlMultiVoucher.Visible = false;
                pnlVoucherSale.Left = pnlVoucherSale.Left  + 100;
                pnlVoucherSale.Width = 850;
            }


            if (globalSettings.allow_screen_resize == "0")
            {
                centerWrapper.Top = this.pnlVoucherSale.Top;
                centerWrapper.Left = this.pnlVoucherSale.Left;
                centerWrapper.Width = this.pnlVoucherSale.Width;
                centerWrapper.Height = this.pnlVoucherSale.Height;
            }
            else
            {
                centerWrapper.Top = this.Top + this.pnlVoucherSale.Top;
                centerWrapper.Left = this.Left + this.pnlVoucherSale.Left;
                centerWrapper.Width = this.pnlVoucherSale.Width;
                centerWrapper.Height = this.pnlVoucherSale.Height;
            }

            this.AddOwnedForm(centerWrapper);

            this.pnlVoucherSale.Parent = centerWrapper;
            this.pnlVoucherSale.Top = 0;
            this.pnlVoucherSale.Left = 0;

            btnMulti2.Click += new System.EventHandler(doBtnMulti_Click);
            btnMulti3.Click += new System.EventHandler(doBtnMulti_Click);
            btnMulti4.Click += new System.EventHandler(doBtnMulti_Click);
            btnMulti5.Click += new System.EventHandler(doBtnMulti_Click);
            btnMulti6.Click += new System.EventHandler(doBtnMulti_Click);
            btnMulti7.Click += new System.EventHandler(doBtnMulti_Click);
            btnMulti8.Click += new System.EventHandler(doBtnMulti_Click);
            btnMulti9.Click += new System.EventHandler(doBtnMulti_Click);

            centerWrapper.Show();


            if (_item_id.Equals("-1")) {
                voucherPanelShowMulti();
            } else
            {
                voucherPanelShow();
            }


            this.Activate();

        }



  



        private void doBtnMulti_Click(object sender, EventArgs e)
        {
            Button btnClick = (Button)sender;
            globalVoucher.request_qty = Int32.Parse(btnClick.Tag.ToString());
            decimal cost_total = globalVoucher.request_qty * globalVoucher.voucher_value;
            showVoucherMsg("x " + globalVoucher.request_qty.ToString() + " = " + String.Format("R {0:n}", cost_total), Color.Green);
        }


        private void showVoucherMsg(string msg, Color txtColor)
        {
            lblVoucherProcess.ForeColor = txtColor;
            lblVoucherProcess.Text = msg;
            lblVoucherProcess.Refresh();
        }

        private void showVoucherNotice(string msg, Color txtColor)
        {
            lblVoucherNotice.ForeColor = txtColor;
            lblVoucherNotice.Text = msg;
            lblVoucherNotice.Refresh();

        }

        private void voucherPanelShow()
        {

            if (_item_id.Equals(""))
            {
                Util.showMessage("Could not load voucher detail.",Color.Red);
                Close();
            };

            is_multi_voucher = false;

            _voucher_retry_count = 0;

            btnVoucherOK.Text = "OK";

            globalVoucher.Clear();

            globalVoucher.service_provider_item_id = int.Parse(_item_id);

            //if (Util.ConnectedByLocalHostname != 2)
            //{

            //    lblVoucherDesc.Text = "";

            //    btnVoucherCancel.Text = "Cancel";
            //    btnVoucherCancel.Visible = true;
            //    btnVoucherOK.Visible = false;

            //    btnVoucherAdd.Visible = false;
            //    btnVoucherSub.Visible = false;
            //    lblVoucherCount.Visible = false;

            //    showVoucherNotice("Internet connection problems!", Color.DarkGray);
            //    showVoucherMsg("Please make sure there is a connection before requesting a voucher.", Color.FromArgb(0, 118, 163));

            //    pnlVoucherSale.Show();
            //    pnlVoucherSale.BringToFront();

            //    return;
            //}


            if (_is_quick_print && globalSettings.gen_quick_print_confirm.Equals("0"))
            {
                //
            }
            else
            {

                btnVoucherOK.Text = "OK";
                btnVoucherOK.Visible = true;

                btnVoucherCancel.Text = "Cancel";
                btnVoucherCancel.Visible = true;

            }

            int arr_id = -1;
            try
            {
                foreach (stockProvider sp in Util.stock_provider)
                {
                    arr_id++;
                    for (int x = 0; x < Util.stock_provider[arr_id].itemcount; x++)
                    {
                        if (_item_id == Util.stock_provider[arr_id].item[x].item_id.ToString())
                        {
                            voucher_prov_arr_id = arr_id;
                            voucher_item_arr_id = x;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Util.showMessage(ex.Message, Color.Yellow);
                Close();
            }

            try
            {
                globalVoucher.voucher_value = Decimal.Parse(Util.stock_provider[voucher_prov_arr_id].item[voucher_item_arr_id].item_value, System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                globalVoucher.voucher_value = 0;
            }

            try
            {
                lblVoucherDesc.Text = Util.stock_provider[voucher_prov_arr_id].provider_desc + " " + Util.stock_provider[voucher_prov_arr_id].item[voucher_item_arr_id].item_print_desc + Environment.NewLine + String.Format("R {0:n}", globalVoucher.voucher_value);
            }
            catch
            {
                lblVoucherDesc.Text = "";
            }

            //try
            //{
            //    decimal cost_total = globalVoucher.request_qty * globalVoucher.voucher_value;
            //    showVoucherMsg("Total Cost: " + String.Format("R {0:n}", cost_total), Color.White);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Show Voucher Cost: " + ex.Message);
            //}

            showVoucherNotice("Due to security reasons, we are unable to refund vouchers", Color.FromArgb(12, 12, 12));

            if (globalSettings.gen_print_copy == "1")
            {
                pnlMultiVoucher.Visible = false;
            }

            if (_is_quick_print && globalSettings.gen_quick_print_confirm.Equals("0"))
            {
                start_delayed_load("start_quick_print", 500);
            }
            else
            {
                btnVoucherOK.Focus();
            }

        }



        private void voucherPanelShowMulti()
        {

            is_multi_voucher = true;

            lstMultiVoucher.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            lstMultiVoucher.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstMultiVoucher_DrawItem);
            lstMultiVoucher.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.lstMultiVoucher_MeasureItem);

            update_multivoucher_status();

            pnlMultiVoucher.Hide();
            pnlMultiPrint.Show();

            _voucher_retry_count = 0;

            globalVoucher.Clear();
            globalVoucher.service_provider_item_id = int.Parse(_item_id);

            globalVoucher.request_qty = lstMultiVoucher.Items.Count;

            btnVoucherOK.Text = "Start";
            btnVoucherOK.Visible = true;

            btnVoucherCancel.Text = "Cancel";
            btnVoucherCancel.Visible = true;

            _item_id = mv_get_first_voucher();

            int arr_id = -1;
            try
            {
                foreach (stockProvider sp in Util.stock_provider)
                {
                    arr_id++;
                    for (int x = 0; x < Util.stock_provider[arr_id].itemcount; x++)
                    {
                        if (_item_id == Util.stock_provider[arr_id].item[x].item_id.ToString())
                        {
                            voucher_prov_arr_id = arr_id;
                            voucher_item_arr_id = x;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Util.showMessage(ex.Message, Color.Yellow);
                Close();
            }

            try
            {
                globalVoucher.voucher_value = Decimal.Parse(Util.stock_provider[voucher_prov_arr_id].item[voucher_item_arr_id].item_value, System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                globalVoucher.voucher_value = 0;
            }

            try
            {
                lblVoucherDesc.Text = Util.stock_provider[voucher_prov_arr_id].provider_desc + " " + Util.stock_provider[voucher_prov_arr_id].item[voucher_item_arr_id].item_print_desc + Environment.NewLine + String.Format("R {0:n}", globalVoucher.voucher_value);
            }
            catch
            {
                lblVoucherDesc.Text = "";
            }

            showVoucherNotice("Due to security reasons, we are unable to refund vouchers", Color.FromArgb(12, 12, 12));

            btnVoucherOK.Focus();

        }



        private void btnVoucherOK_Click(object sender, EventArgs e)
        {
            btnVoucherOKClick();
        }


        private void btnVoucherOKClick()
        {

          
            if (btnVoucherOK.Text.Equals("OK") || btnVoucherOK.Text.Equals("Start"))
            {

                btnVoucherOK.Visible = false;
                btnVoucherOK.Refresh();

                pnlMultiVoucher.Enabled = false;
                pnlMultiVoucher.Refresh();

                btnVoucherCancel.Visible = false;
                btnVoucherCancel.Refresh();

                voucherStartRequest(false);

            }

        }


        private void btnVoucherCancel_Click(object sender, EventArgs e)
        {
            voucherPanelClose(false);
        }


        private void voucherPanelClose(bool forseClose)
        {

            if (btnVoucherCancel.Visible == false && !forseClose)
                return;
            
            Close();

        }





        private void voucherStartRequest(bool isPendingRequest)
        {

            string ret = "";


            if (is_multi_voucher)
            {

                if (!isPendingRequest)
                {

                    _item_id = mv_get_first_voucher();

                    globalVoucher.service_provider_item_id = int.Parse(_item_id);

                    int arr_id = -1;
                    try
                    {
                        foreach (stockProvider sp in Util.stock_provider)
                        {
                            arr_id++;
                            for (int x = 0; x < Util.stock_provider[arr_id].itemcount; x++)
                            {
                                if (_item_id == Util.stock_provider[arr_id].item[x].item_id.ToString())
                                {
                                    voucher_prov_arr_id = arr_id;
                                    voucher_item_arr_id = x;
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Util.showMessage(ex.Message, Color.Yellow);
                        Close();
                    }

                    try
                    {
                        globalVoucher.voucher_value = Decimal.Parse(Util.stock_provider[voucher_prov_arr_id].item[voucher_item_arr_id].item_value, System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch
                    {
                        globalVoucher.voucher_value = 0;
                    }

                    try
                    {
                        lblVoucherDesc.Text = Util.stock_provider[voucher_prov_arr_id].provider_desc + " " + Util.stock_provider[voucher_prov_arr_id].item[voucher_item_arr_id].item_print_desc + Environment.NewLine + String.Format("R {0:n}", globalVoucher.voucher_value);
                    }
                    catch
                    {
                        lblVoucherDesc.Text = "";
                    }

                    Application.DoEvents();

                }
            }


            if (globalSettings.gen_show_voucher_only.Equals("0") && Util.OutOfPaper() && !isPendingRequest)
            {
                showVoucherMsg("Please check the printer paper!", Color.DarkRed);
                btnVoucherOK.Visible = true;
                return;
            }

            if (!isPendingRequest)
            {

                _voucher_retry_count = 0;

                if (!globalVoucher.voucherStatsNewRequest())
                {
                    showVoucherMsg("System could not generate voucher request."+ Environment.NewLine + "Please contact Top it Up.", Color.DarkRed);
                    btnVoucherCancel.Visible = true;
                    return;
                }
                globalVoucher.request_qty_current++;

                if (globalVoucher.request_qty == 1)
                {
                    showVoucherMsg("Requesting Voucher", Color.Green);
                }
                else
                {
                    showVoucherMsg("Requesting Voucher (" + globalVoucher.request_qty_current + "/" + globalVoucher.request_qty + ")", Color.Green);
                }

            }
            else
            {
                showVoucherMsg("Checking pending voucher status.", Color.Green);
            }

            ret = getVoucher(isPendingRequest, _voucher_retry_count, 35000);
            //ret = getVoucher(isPendingRequest, _voucher_retry_count, 2000);

            if (globalVoucher.response_status == 0)
            {

                globalVoucher.voucherStatsRequestProblem();

                lblRetryAttempt.Text = "";

                Util.showWait(false);

                showVoucherMsg(ret, Color.DarkRed);
                //showVoucherMsg("There was a network issue, please check that your internet connection is working.", Color.DarkRed);
                btnVoucherCancel.Text = "Close";
                btnVoucherCancel.Show();
                return;

            }

            if (globalVoucher.response_status == 1)             // Response OK
            {

                Util.showWait(false);

                globalVoucher.voucher_prov_arr_id = voucher_prov_arr_id;
                globalVoucher.voucher_item_arr_id = voucher_item_arr_id;
                globalVoucher.pin_number = Util.str_decrypt_pin(globalVoucher.pin_number_encryped);
                globalVoucher.refreshLastSale();

                if (is_multi_voucher) mv_remove_first_voucher();

                voucherPrint();
               
                if (globalVoucher.request_qty_current < globalVoucher.request_qty)
                {
                    voucherStartRequest(false);
                }
                else
                {
                    voucherPanelClose(true);
                }

                return;
            }


            if (globalVoucher.response_status == 2)             // Error Response from WS
            {

                globalVoucher.voucherStatsRequestProblem();

                Util.showWait(false);

                showVoucherNotice("", Color.DarkRed);
                showVoucherMsg(Util.str_proper_case(ret), Color.CadetBlue);
                btnVoucherCancel.Text = "Close";
                btnVoucherCancel.Show();

                return;
            }

            if (globalVoucher.response_status == 3)             // Timeout etc error
            {

                if (_voucher_retry_count >= 6)
                {

                    timer_voucher_retry.Enabled = false;

                    globalVoucher.voucherStatsRequestProblem();

                    lblRetryAttempt.Text = "";

                    Util.showWait(false);

                    showVoucherNotice("Internet Connection Issue. Could not fetch voucher.", Color.FromArgb(158, 11, 15));
                    showVoucherMsg("Please reprint or view your sales history when your internet connection returns.", Color.Firebrick);
                    btnVoucherCancel.Text = "Close";
                    btnVoucherCancel.Show();

                    return;
                }


                showVoucherNotice(Util.str_proper_case(ret), Color.DarkRed);

                Util.showWait("Voucher is in a pending status because of a network issue. Please do NOT restart." + Environment.NewLine + "Trying to connect...");

                if (isPendingRequest)
                {
                    timer_voucher_retry.Enabled = true;
                }
                else
                {
                    voucher_retry();
                }

            }


        }




        private int _voucher_retry_count = 0;
        private void timer_voucher_retry_Tick(object sender, EventArgs e)
        {

            timer_voucher_retry.Enabled = false;
            voucher_retry();

        }

        private void voucher_retry()
        {

            _voucher_retry_count++;

            lblRetryAttempt.Text = "Retry (" + _voucher_retry_count.ToString() + ")";
            lblRetryAttempt.Refresh();

            Util.IsConnectedToInternet();

            // + Environment.NewLine + _voucher_retry_count.ToString() + " of 5"

            //if (_voucher_retry_count == 3)
            //{

            //    showVoucherNotice("Restarting Cellular Connection", Color.DarkRed);

            //    Util.ConnectionStatus = 1;
            //    //update_connection_status("Reset Modem");
            //    //gprsReboot();
            //    //update_connection_status("Reconnect");
            //    //gprsDial(false);
            //    //Thread.Sleep(1000);

            //}

            voucherStartRequest(true);

        }






        private void voucherPrint()
        {

            globalVoucher.voucherStatsRequestOK();

            try
            {
                if (globalVoucher.request_qty == 1)
                {
                    showVoucherMsg("...printing...", Color.FromArgb(0, 114, 54));
                }
                else
                {
                    showVoucherMsg("...printing...(" + globalVoucher.request_qty_current + "/" + globalVoucher.request_qty + ")", Color.FromArgb(0, 114, 54));
                }
            }
            catch
            {
                //
            }

            if (globalVoucher.request_qty_current == 1 && globalSettings.gen_cashdr == "1")
            {
                Util.DoOpenCashDrawer = true;
            }

            Util.printVoucher();

            if (!globalSettings.gen_show_voucher_only.Equals("1")) Thread.Sleep(1300);

        }





        private String getVoucher(bool isPendingRequest, int retryCount, int _timeout)
        {

            string htmlResponse = "";
            string ret = "";

            globalVoucher.response_status = 0;

            Web WebResponse = new Web(_timeout);

            if (isPendingRequest)
            {
                
                htmlResponse = WebResponse.GetURL("/terminal/voucher/check-voucher" +
                    "?uid=" + globalVoucher.stats_air_busy +
                    "&retry=" + retryCount.ToString() +
                    "&last=" + globalVoucher.stats_air_lastprinted);

                //htmlResponse = WebResponse.GetURL("/terminal/voucher/check-voucher" +
                //    "?uid=" + globalVoucher.request_id + 
                //    "&retry=" + retryCount.ToString() + 
                //    "&last=" + globalVoucher.stats_air_lastprinted);
            }
            else
            {
                
                htmlResponse = WebResponse.GetURL("/terminal/voucher/get-voucher?p1=" + globalVoucher.stats_air_busy + "&p2=" + globalVoucher.stats_air_request.ToString() + "&p3=" + globalVoucher.stats_air_print.ToString() + "&item_id=" + globalVoucher.service_provider_item_id + "&last=" + globalVoucher.stats_air_lastprinted);

                //htmlResponse = WebResponse.GetURL("/terminal/voucher/get-voucher" + 
                //        "?p1=" + globalVoucher.request_id + 
                //        "&p2=0&p3=0" + 
                //        "&item_id=" + globalVoucher.service_provider_item_id + 
                //        "&last=" + globalVoucher.stats_air_lastprinted);
            }

            WebResponse = null;

            System.Diagnostics.Debug.WriteLine(htmlResponse);


            if (htmlResponse.IndexOf("<webreqerr>") > -1)
            {

                globalVoucher.response_status = 3;
                ret = htmlResponse.GetStrBetweenTags("<webreqerr>", "</webreqerr>");

            }
            else if (htmlResponse.IndexOf("err>") > -1)
            {

                globalVoucher.response_status = 2;
                ret = htmlResponse.GetStrBetweenTags("<err>", "</err>");

                try
                {
                    if (ret.IndexOf("nofunds") > -1)
                    {
                        finBalance.low_balance = "1";
                        string[] tokens = ret.Split('^');
                        finBalance.available_balance = tokens[1];
                        ret = tokens[2];
                    }
                } catch
                {
                    //
                }

            }
            else if (htmlResponse.IndexOf("uid=") == 0)
            {

                globalVoucher.response_status = 1;

                try
                {

                    globalVoucher.is_reprint = false;

                    char[] del = new char[] {'=', '^'};
                    string[] tokens = htmlResponse.Split(del);

                    for (int token = 0; token < tokens.Length; token += 2)
                    {
                        string s1 = tokens[token];
                        string s2 = tokens[token + 1];

                        if (s1.Equals("uid")) globalVoucher.stock_uid = s2;
                        if (s1.Equals("p")) globalVoucher.pin_number_encryped = s2;
                        if (s1.Equals("s")) globalVoucher.serial_number = s2;
                        if (s1.Equals("n")) globalVoucher.sale_count = s2;
                        if (s1.Equals("sp")) globalVoucher.service_provider_id = Int32.Parse(s2);
                        if (s1.Equals("spi")) globalVoucher.service_provider_item_id = Int32.Parse(s2);
                        if (s1.Equals("dtm")) globalVoucher.tx_date = s2;
                        if (s1.Equals("b")) finBalance.updateFromAvailable(s2);
                        if (s1.Equals("l"))
                            if (s2.Equals("1"))
                                finBalance.low_balance = "1";
                            else
                                finBalance.low_balance = "0";

                        if (s1.Equals("balance")) finBalance.balance = s2;
                        if (s1.Equals("balance_cash")) finBalance.balance_cash = s2;
                        if (s1.Equals("available_balance")) finBalance.available_balance = s2;
                        if (s1.Equals("credit_limit")) finBalance.credit_limit = s2;
                        if (s1.Equals("credit_extended")) finBalance.credit_extended = s2;

                        //if (!String.IsNullOrEmpty((string)json["low_balance"])) finBalance.low_balance = (string)json["low_balance"];
                        //if (!String.IsNullOrEmpty((string)json["cash_customer"])) finBalance.cash_customer = (string)json["cash_customer"];

                        //if (!String.IsNullOrEmpty((string)json["dtmd"])) dtmd = (string)json["dtmd"];
                        //if (!String.IsNullOrEmpty((string)json["dtmt"])) dtmt = (string)json["dtmt"];


                    }
                }
                catch (Exception ex)
                {
                    globalVoucher.response_status = 3;
                    ret = ex.Message;
                }

            }
          

            return ret;

        }




        private void lstMultiVoucher_DrawItem(object sender, DrawItemEventArgs e)
        {

            e.DrawBackground();
            e.DrawFocusRectangle();

            if (e.Index < 0) return;

            multiVoucher x = (multiVoucher)lstMultiVoucher.Items[e.Index];

            e.Graphics.DrawString(
                 x.ToString(),
                 e.Font,
                 new SolidBrush(e.ForeColor),
                 e.Bounds);

            // draw some item separator
            e.Graphics.DrawLine(Pens.LightGray, e.Bounds.X, e.Bounds.Y + e.Bounds.Height - 2, e.Bounds.X + e.Bounds.Width, e.Bounds.Y + e.Bounds.Height - 2);


        }

        private void lstMultiVoucher_MeasureItem(object sender, MeasureItemEventArgs e)
        {

            if (e.Index < 0) return;

            multiVoucher x = (multiVoucher)lstMultiVoucher.Items[e.Index];

            e.ItemHeight = 35 * GetLinesNumber((string)x.ToString());
        }

        private int GetLinesNumber(string text)
        {
            int count = 1;
            int pos = 0;
            while ((pos = text.IndexOf("\r\n", pos)) != -1) { count++; pos += 2; }
            return count;
        }

        private void update_multivoucher_status()
        {

            Decimal total_value = 0.0M;
            int total = 0;

            foreach (var listBoxItem in lstMultiVoucher.Items)
            {
                total++;
                multiVoucher x = (multiVoucher)listBoxItem;
                total_value += x.item_value;
            }

            lbl_plnMultiTotal.Text = "Total (" + total.ToString() + ")";
            lbl_plnMultiTotalValue.Text = "R " + total_value.ToString();

        }


        private string mv_get_first_voucher()
        {

            String ret = "";

            multiVoucher x = (multiVoucher)lstMultiVoucher.Items[0];
            ret = x.service_provider_item_id.ToString();

            return ret;

        }

        private void mv_remove_first_voucher()
        {

            try {
                lstMultiVoucher.Items.RemoveAt(0);
            }
            catch (Exception ex){
                //
            }
            

        }

        



    }


    

}

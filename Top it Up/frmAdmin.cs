using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Net;
using System.Threading;
using Newtonsoft.Json.Linq;
using System.IO;


namespace TopitUp
{


    public partial class frmAdmin : Form
    {

        private int _customer_report_z_id = 0;
        private string _license_code = "";

        private int intSelectedInvoiceID = 0;
        private int intSelectedPOSUserID = 0;

        Panel _activePanel;

        bool wbExtendedCreditShown = false;

        private string _current_action = "";

        private string _current_action_save = "";

        String reportType = "Daily";
        public frmAdmin()
        {

            InitializeComponent();


            tmr_logout.Enabled = true;

            DateTime lastmonth = DateTime.Now.AddMonths(-1);

            cboInvSy.Text = lastmonth.Year.ToString();
            cboInvEy.Text = DateTime.Today.Year.ToString();

            cboInvSm.Text = lastmonth.ToString("MMMM");
            cboInvEm.Text = DateTime.Today.ToString("MMMM");

            cboInvSd.Text = lastmonth.Day.ToString();
            cboInvEd.Text = DateTime.Today.Day.ToString();
            pullReportFlag();


            if (globalSettings.enable_rpt_monthly_deposit.Equals("0"))
                btnRptDaily.Hide();

            if (globalSettings.enable_rpt_comm_statement.Equals("0"))
                btnCommission.Hide();

         


            for (int loop = DateTime.Today.Year - 3; loop <= DateTime.Today.Year; loop++)
            {
                cboInvSy.Items.Add(loop.ToString());
                cboInvEy.Items.Add(loop.ToString());
            }

        }

        //private Bitmap _btnlhs0;
        //private Bitmap _btnlhs1;
        //private Bitmap _btnlhs2;

        bool loading;

        private void vStreamAdmin_Load(object sender, EventArgs e)
        {

            this.SuspendLayout();

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

            btnXReport.Enabled = true;
            btnEndOfDayZ.Enabled = true;
            btnPrintInvoice.Enabled = true;
            btnZReport.Enabled = true;
            btnGetBalance.Enabled = true;
            btnSlipExtra.Enabled = true;

            if (globalSettings.gen_virtual_keyboard == "1")
            {
                pnlKeyboard.Visible = true;
            }
            else
            {
                pnlKeyboard.Visible = false;
            }

            loading = true;

            pnlCustomiseProducts.Dock = DockStyle.Fill;
            pnlSlipExtra.Dock = DockStyle.Fill;
            pnlQuickLaunch.Dock = DockStyle.Fill;
            pnlElectraSettings.Dock = DockStyle.Fill;
            pnlZReports.Dock = DockStyle.Fill;

            txt_elec_preset_val1.MaxLength = 3;

            chkLowBalance.Checked = false;
            chkLogout.Checked = false;

            radioButtonNever.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            radioButton5.Visible = false;
            radioButton6.Visible = false;
            radioButton7.Visible = false;

            if (globalSettings.gen_logout == "0")
            {
                radioButtonNever.Visible = true;
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
                radioButton4.Visible = true;
                radioButton5.Visible = true;
                radioButton6.Visible = true;
                radioButton7.Visible = true;

                if (globalSettings.gen_logout_time == 2000000000)
                {
                    radioButtonNever.Checked = true;
                    lblDisclaimer.Visible = true;
                    chkLogoutAccept.Checked = true;
                }
                if (globalSettings.gen_logout_time == 10000) radioButton1.Checked = true;
                if (globalSettings.gen_logout_time == 15000) radioButton2.Checked = true;
                if (globalSettings.gen_logout_time == 30000) radioButton3.Checked = true;
                if (globalSettings.gen_logout_time == 60000) radioButton4.Checked = true;
                if (globalSettings.gen_logout_time == 120000) radioButton5.Checked = true;
                if (globalSettings.gen_logout_time == 180000) radioButton6.Checked = true;
                if (globalSettings.gen_logout_time == 300000) radioButton7.Checked = true;
            }

            //try {
            //    pic_fin_bg.Image = new Bitmap(globalSettings.app_path + @"\images\admin_fin_bg.gif");
            //}catch {
            //    Util.showMessage("Missing Image", Color.Red);
            //}


            //_btnlhs0 = new Bitmap(globalSettings.app_path + @"\images\btnlhs0.gif");
            //_btnlhs1 = new Bitmap(globalSettings.app_path + @"\images\btnlhs1.gif");
            //_btnlhs2 = new Bitmap(globalSettings.app_path + @"\images\btnlhs2.gif");

            //_btngeneral0 = new Bitmap(globalSettings.app_path + @"\images\adm_generalbtn0.gif");
            //_btngeneral1 = new Bitmap(globalSettings.app_path + @"\images\adm_generalbtn1.gif");
            //_btngeneral2 = new Bitmap(globalSettings.app_path + @"\images\adm_generalbtn2.gif");
            //_btngeneral3 = new Bitmap(globalSettings.app_path + @"\images\adm_generalbtn3.gif");
            //_btngeneral4 = new Bitmap(globalSettings.app_path + @"\images\adm_generalbtn4.gif");
            //_btngeneral5 = new Bitmap(globalSettings.app_path + @"\images\adm_generalbtn5.gif");
            //_btngeneral6 = new Bitmap(globalSettings.app_path + @"\images\adm_generalbtn6.gif");
            //_btnswipe = new Bitmap(globalSettings.app_path + @"\images\adm_swipe.gif");

            lastButton = 1;

            this.pnl_main_reports.Dock = DockStyle.Fill;
            this.pnl_main_financial.Dock = DockStyle.Fill;
            this.pnl_main_users.Dock = DockStyle.Fill;
            this.pnl_main_settings.Dock = DockStyle.Fill;
            this.pnl_customer_accept.Dock = DockStyle.Fill;

            this.txtPOSUserName.BackColor = Color.White;
            this.txtPOSUserLastname.BackColor = Color.White;

            this.txtSlipExtra1.BackColor = Color.White;
            this.txtSlipExtra2.BackColor = Color.White;
            this.txtSlipExtra3.BackColor = Color.White;
            this.txtSlipExtra4.BackColor = Color.White;
            this.txtSlipExtra5.BackColor = Color.White;

            this.pnl_main_reports.BringToFront();

            loading = false;

            check_for_accept();

            this.ResumeLayout();

            this.Activate();

            Util.showWait(false);

        }




        private void doNotice(String notice, int type)
        {
            if (type == 2)
            {
                Util.showMessage(notice, Color.Red);
            }
            else
            {
                Util.showMessage(notice, Color.White);
            }
        }


        private void RestartLogoutTimer()
        {
            tmr_logout.Enabled = false;
            tmr_logout.Enabled = true;
        }




        bool _loading_z_report = false;
        private void btnZReport_Click(object sender, EventArgs e)
        {

            RestartLogoutTimer();

            Util.showWait(true);

            txtZID.Text = "";
            _customer_report_z_id = 0;
            _loading_z_report = true;
            _license_code = globalSettings.license_code;

            enablePanel(pnlZReports, "");

            start_delayed_load("populate_z_history", 500);

        }


        private void PopulateZReportGrid(String license_id)
        {

            Util.showWait(true);

            grdZReports.Rows.Clear();

            String htmlResponse = "";

            Web WebResponse = new Web(45000, 1, "");
            htmlResponse = WebResponse.GetURL("/terminal/cashup/z-report-history?q=" + license_id);
            WebResponse = null;

            if (htmlResponse.IndexOf("err>") > -1) {
                doNotice(htmlResponse.StripErrorTags(), 2);
            } else if (htmlResponse != "")
            {
                try
                {
                    string[] lines = htmlResponse.Split('\n');

                    for (int i = 0; i < lines.Length - 1; i++)
                    {
                        string[] items = lines[i].Split('^');

                        grdZReports.Rows.Add();
                        grdZReports.Rows[i].Tag = items[0];
                        grdZReports.Rows[i].Cells[0].Value = items[1];
                        grdZReports.Rows[i].Cells[1].Value = items[2];
                        grdZReports.Rows[i].Cells[2].Value = items[3];
                        grdZReports.Rows[i].Cells[3].Value = String.Format(" R {0:n}", items[4]);
                        grdZReports.Rows[i].Cells[4].Value = String.Format(" R {0:n}", items[5]);

                        decimal total = 0;
                        try {
                            total = decimal.Parse(items[4], System.Globalization.CultureInfo.InvariantCulture) + decimal.Parse(items[5], System.Globalization.CultureInfo.InvariantCulture);
                        } catch {
                            //
                        }

                        grdZReports.Rows[i].Cells[5].Value = String.Format(" R {0:n}", total);

                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }

            Util.showWait(false);

        }


        private void PopulateInvoicesGridDtm(string sdate, string edate)
        {

            grdInvoiceList.Rows.Clear();

            String htmlResponse = "";

            String query_string = "?sdtm=" + sdate;
            query_string += "&edtm=" + edate;

            Web WebResponse = new Web(45000, 1, "");
            htmlResponse = WebResponse.GetURL("/terminal/customer/get-invoice-list" + query_string);
            WebResponse = null;

            if (htmlResponse.IndexOf("err>") > -1)
            {
                doNotice(htmlResponse.StripErrorTags(), 2);
            }
            else if (htmlResponse != "")
            {
                try
                {
                    string[] lines = htmlResponse.Split('\n');

                    for (int i = 0; i < lines.Length - 1; i++)
                    {
                        string[] items = lines[i].Split('^');

                        grdInvoiceList.Rows.Add();
                        grdInvoiceList.Rows[i].Tag = items[0];
                        //grdInvoiceList.Rows[i].Cells[0].Value = items[0].ToString();
                        grdInvoiceList.Rows[i].Cells[0].Value = items[1].ToString();
                        grdInvoiceList.Rows[i].Cells[1].Value = items[2].ToString();
                        grdInvoiceList.Rows[i].Cells[2].Value = String.Format(" R {0:n}", items[3].ToString());

                        //Resco.Controls.SmartGrid.Row r = new Resco.Controls.SmartGrid.Row(4);
                        //r.Height = 30;
                        //r[0] = " " + items[0].ToString();
                        //r[1] = " " + items[1].ToString();
                        //r[2] = " " + items[2].ToString();
                        //r[3] = String.Format(" R {0:n}", items[3].ToString());
                        //grdInvoiceList.Rows.Add(r);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }

        }


        private void btnXReport_Click(object sender, EventArgs e)
        {

            RestartLogoutTimer();

            //if (globalSettings.gen_ignore_paper == "0")
            //{
            //    if (WintecIDT700.ReadPrinterState() == 1)
            //    {
            //        doNotice("Please check paper!", 2);
            //        return;
            //    }
            //}

            doNotice("Fetching X - Intraday report.", 1);

            string htmlResponse = "";

            Web WebResponse = new Web(60000, 0, globalSettings.customer_id);
            htmlResponse = WebResponse.GetURL("/terminal/cashup/x-intraday");
            WebResponse = null;

            if (htmlResponse.IndexOf("err>") > -1)
            {
                doNotice(htmlResponse.StripErrorTags(), 1);
            }
            else
            {
                Util.printText(htmlResponse, false);
            }

        }

        private void btnXCashierFull_Click(object sender, EventArgs e)
        {
            RestartLogoutTimer();

            //if (globalSettings.gen_ignore_paper == "0")
            //{
            //    if (WintecIDT700.ReadPrinterState() == 1)
            //    {
            //        doNotice("Please check paper!", 2);
            //        return;
            //    }
            //}

            doNotice("Fetching X - Intraday by cashier report.", 1);

            string htmlResponse = "";

            Web WebResponse = new Web(60000, 0, globalSettings.customer_id);
            htmlResponse = WebResponse.GetURL("/terminal/cashup/x-intraday-cashier");
            WebResponse = null;

            if (htmlResponse.IndexOf("err>") > -1)
            {
                doNotice(htmlResponse.StripErrorTags(), 1);
            }
            else
            {
                Util.printText(htmlResponse, false);
            }

        }


        private void btnXCashierReport_Click(object sender, EventArgs e)
        {

            RestartLogoutTimer();

            //if (globalSettings.gen_ignore_paper == "0")
            //{
            //    if (WintecIDT700.ReadPrinterState() == 1)
            //    {
            //        doNotice("Please check paper!", 2);
            //        return;
            //    }
            //}

            doNotice("Fetching X - Intraday by cashier summary report.", 1);

            string htmlResponse = "";

            Web WebResponse = new Web(60000, 0, globalSettings.customer_id);
            htmlResponse = WebResponse.GetURL("/terminal/cashup/x-intraday-cashier?q=1");
            WebResponse = null;

            if (htmlResponse.IndexOf("err>") > -1)
            {
                doNotice(htmlResponse.StripErrorTags(), 1);
            }
            else
            {
                Util.printText(htmlResponse, false);
            }

        }



        private void populatePosUserGrid()
        {

            grdPosUsers.Rows.Clear();
            int i = 0;
            try
            {
                foreach (string s in Util.pos_users)
                {
                    if (s.IndexOf("^") != -1)
                    {
                        string[] line = s.Split('^');

                        //Resco.Controls.SmartGrid.Row r = new Resco.Controls.SmartGrid.Row(7);

                        grdPosUsers.Rows.Add();
                        grdPosUsers.Rows[i].Tag = Convert.ToInt32(line[0].ToString());

                        string statusDesc = "";

                        //grdPosUsers.Rows[i].Cells[0].Value = Convert.ToInt32(line[0].ToString());
                        grdPosUsers.Rows[i].Cells[0].Value = " " + line[1].ToString() + " " + line[2].ToString();

                        statusDesc = " Cashier";
                        if (line[3].ToString() == "1") statusDesc = " Admin";
                        grdPosUsers.Rows[i].Cells[1].Value = statusDesc;

                        statusDesc = " Active";
                        if (line[4].ToString() == "2") statusDesc = " Suspended";
                        grdPosUsers.Rows[i].Cells[2].Value = statusDesc;

                        //statusDesc = "";
                        //if (line[6].ToString().Trim() != "") statusDesc = " Yes";
                        //grdPosUsers.Rows[i].Cells[4].Value = statusDesc;

                        statusDesc = " No";
                        if (line[9].ToString() != "0" && line[10].ToString() != "0") statusDesc = " Yes";
                        grdPosUsers.Rows[i].Cells[3].Value = statusDesc;

                        statusDesc = "";
                        if (line[8].ToString().Trim() != "") statusDesc = " " + line[8].ToString();
                        grdPosUsers.Rows[i].Cells[4].Value = statusDesc;

                        i++;
                    }

                }
            }
            catch
            {
                doNotice("Error loading users!", 2);
            }

        }



        private void btnWebBrowser_Click(object sender, EventArgs e)
        {

            WebBrowser wbForm = new WebBrowser();
            wbForm.Show();

        }


        private void btnGetBalance_Click(object sender, EventArgs e)
        {

            txtDepositAmount.Text = "";

            Util.showWait(true);

            RestartLogoutTimer();
            getBallance();


            Util.showWait(false);

        }

        private void getBallance()
        {

            btnPrintBalance.Hide();
            btnTransferPanel.Hide();
            btnTransferShow.Hide();

            if (PopulateBalance())
            {

                lblPleaseRefreshBalance.Hide();
                grp_finw1.Show();


                //if (finBalance.cash_customer.Equals("0"))
                //{

                decimal amount = 0.0m;

                try
                {
                    amount = Decimal.Parse(finBalance.balance_cash, System.Globalization.CultureInfo.InvariantCulture);
                }
                catch
                {
                    amount = 0.0m;
                }

                if (amount > 0)
                {
                    btnTransferPanel.Show();
                    btnTransferShow.Show();
                }

                txtRandValue.Text = "0.00";
                lblWxfeMax.Text = "R " + finBalance.balance_cash;

                lblProducts1.Text = finBalance.w1_desc;
                lblProducts1.Show();

                lblProducts2.Text = finBalance.w2_desc;
                lblProducts2.Show();

                lblacn1.Text = finBalance.acn1;
                lblacn2.Text = finBalance.acn2;

                //}
                //else
                //{
                //    lblProducts1.Text = finBalance.w1_desc;
                //    lblProducts1.Show();
                //    lblProducts2.Hide();
                //}

                grp_finw1_lbl.Text = "Financials - Last Updated: " + finBalance.dtmd + ", " + finBalance.dtmt;

                if (finBalance.enable_remote_ext_credit.Equals("1"))
                {
                    btnReqExtendedCredit.Show();
                }
                if (finBalance.allow_transfer_cash.Equals("1"))
                {
                    btnTransferPanel.Show();
                }
                if (finBalance.allow_transfer_interstore.Equals("1"))
                {
                    btnTransferShow.Show();
                }

                if (globalSettings.enable_rpt_monthly_deposit.Equals("0"))
                    btnPrintBalance.Hide();
                else
                btnPrintBalance.Show();

            }

        }


        private Boolean PopulateBalance()
        {

            Boolean is_ok = true;

            fin_lbl3.Visible = false;
            credit_limit.Visible = false;
            fin_lbl4.Visible = false;
            credit_extended.Visible = false;

            String ret = finBalance.getBalance(1);

            if (!ret.Equals(""))
            {
                is_ok = false;
                Util.showMessage(ret, Color.Red);
            }
            else
            {
                try
                {

                    available_balance.Text = "R " + finBalance.available_balance;
                    balance.Text = "R " + finBalance.balance;
                    balance_cash.Text = "R " + finBalance.balance_cash;

                    if (finBalance.cash_customer.Equals("0"))
                    {
                        credit_limit.Text = "R " + finBalance.credit_limit;
                        fin_lbl3.Visible = true;
                        credit_limit.Visible = true;
                    }

                    if (finBalance.credit_extended != "0.00")
                    {
                        credit_extended.Text = "R " + finBalance.credit_extended;
                        fin_lbl4.Visible = true;
                        credit_extended.Visible = true;
                    }

                }
                catch (Exception ex)
                {
                    Util.showMessage(ex.Message, Color.Red);
                    is_ok = false;
                }
            }

            return is_ok;

        }



        private void btnLoadItems_Click(object sender, EventArgs e)
        {

            RestartLogoutTimer();

            txtSlipExtra1.Text = Util.voucher_print_extra[0];
            txtSlipExtra2.Text = Util.voucher_print_extra[1];
            txtSlipExtra3.Text = Util.voucher_print_extra[2];
            txtSlipExtra4.Text = Util.voucher_print_extra[3];
            txtSlipExtra5.Text = Util.voucher_print_extra[4];

            chkPrintAddress.Checked = false;
            chkPrintSlipCopy.Checked = false;
            chkPrintBarcodeAir.Checked = false;
            chkPinlessSlip.Checked = false;
            chkPrintBarcodeEle.Checked = false;

            //if (globalSettings.gen_ignore_paper == "1") chkOutOfPaper.Checked = true;
            if (globalSettings.gen_print_address == "1") chkPrintAddress.Checked = true;
            if (globalSettings.gen_print_copy == "1") chkPrintSlipCopy.Checked = true;
            if (globalSettings.gen_print_pinless_slip == "1") chkPinlessSlip.Checked = true;
            if (globalSettings.gen_prnt_b == "1") chkPrintBarcodeAir.Checked = true;
            if (globalSettings.gen_prnt_be == "1") chkPrintBarcodeEle.Checked = true;
            if (globalSettings.gen_prnt_bb == "1") chkPrintBarcodeBill.Checked = true;

            if (globalSettings.gen_pinless == "0") chkPinlessSlip.Visible = false;

            chkShowVoucherOnly.Checked = false;
            if (globalSettings.gen_show_voucher_only == "1") chkShowVoucherOnly.Checked = true;

            chkCashDrawer.Checked = false;
            if (globalSettings.gen_cashdr == "1") chkCashDrawer.Checked = true;

            chkSlipPrinter.Checked = false;
            if (globalSettings.gen_slip_printer == "1")
            {
                chkSlipPrinter.Checked = true;
                chkCashDrawer.Enabled = true;
            }
            else
            {
                chkCashDrawer.Enabled = false;
                chkCashDrawer.Checked = false;
            }

            enablePanel(pnlSlipExtra, "general_4_2");

        }


        private void logoutTimer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }




        private void btnSavePosUsers_Click(object sender, EventArgs e)
        {

            RestartLogoutTimer();

            lblPOSUSER1.Text = "Add New POS User";

            selPOSUserIsAdmin1.Checked = true;
            selPOSUserIsAdmin2.Checked = false;
            chkRicaTraining.Checked = false;
            txtPOSUserLastname.Text = "";
            txtPOSUserName.Text = "";
            txtPOSUserPIN.Text = "";
            txtIDNumber.Text = "";
            //totalstring = "";
            //newstring = "";

            lblRicaInfo.Visible = false;
            btnRicaRegister.Visible = false;

            chkPosuserSuspended.Visible = false;
            lblUserStatus.Visible = false;

            enablePanel(pnlAddEditUser, "users_3_1");

        }



        private void chkLogout_CheckStateChanged(object sender, EventArgs e)
        {

            if (chkLogout.Checked == false)
            {
                radioButtonNever.Visible = true;
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
                radioButton4.Visible = true;
                radioButton5.Visible = true;
                radioButton6.Visible = true;
                radioButton7.Visible = true;

                if (radioButtonNever.Checked)
                {
                    lblDisclaimer.Visible = true;
                    chkLogoutAccept.Visible = true;
                    chkLogoutAccept.Checked = false;
                }

            }
            else
            {
                radioButtonNever.Visible = false;
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                radioButton4.Visible = false;
                radioButton5.Visible = false;
                radioButton6.Visible = false;
                radioButton7.Visible = false;
                lblDisclaimer.Visible = false;
                chkLogoutAccept.Visible = false;

            }

        }



        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {

            tmr_logout.Enabled = false;

            enablePanel(pnlInvoices, "");

            txtDepositAmount.Text = "";
            btnPrintInvoice.Enabled = false;

            doNotice("Showing Last 10 Invoices.", 1);
            PopulateInvoicesGridDtm("0", "0");

            btnPrintInvoice.Enabled = true;

            RestartLogoutTimer();

        }

        private void btnEndOfDayZ_Click(object sender, EventArgs e)
        {

            RestartLogoutTimer();

            //if (globalSettings.gen_ignore_paper == "0")
            //{
            //    if (WintecIDT700.ReadPrinterState() == 1)
            //    {
            //        doNotice("Please check paper!", 2);
            //        return;
            //    }
            //}

            btnEndOfDayZ.Enabled = false;

            doNotice("Processing Z - End-of-Day report.", 1);

            string htmlResponse = "";

            Web WebResponse = new Web(60000, 0, globalSettings.customer_id);
            htmlResponse = WebResponse.GetURL("/terminal/cashup/z-end-of-day");
            WebResponse = null;

            if (htmlResponse.IndexOf("err>") > -1)
            {
                doNotice(htmlResponse.StripErrorTags(), 2);
            }
            else
            {
                Util.printText(htmlResponse, false);
            }

            btnEndOfDayZ.Enabled = true;

        }

        private void btnReprint_Click(object sender, EventArgs e)
        {

            RestartLogoutTimer();

            try
            {
                DataGridViewRow row = grdZReports.Rows[grdZReports.CurrentCell.RowIndex];
                _customer_report_z_id = Convert.ToInt32(row.Tag);
            }
            catch
            {
                _customer_report_z_id = 0;
            }


            if (_customer_report_z_id == 0)
            {
                doNotice("Please select Z Report.", 2);
                return;
            }

            RestartLogoutTimer();

            doNotice("Fetching X - Intraday report for reprint.", 1);

            string htmlResponse = "";

            Web WebResponse = new Web(60000);
            htmlResponse = WebResponse.GetURL("/terminal/cashup/z-reprint?zid=" + _customer_report_z_id.ToString());
            WebResponse = null;

            if (htmlResponse.IndexOf("err>") > -1)
            {
                doNotice(htmlResponse.StripErrorTags(), 1);
            }
            else
            {
                Util.printText(htmlResponse, false);
            }

        }



        private void btnInvoiceReprint_Click(object sender, EventArgs e)
        {

            RestartLogoutTimer();

            try
            {
                DataGridViewRow row = grdInvoiceList.Rows[grdInvoiceList.CurrentCell.RowIndex];
                intSelectedInvoiceID = Convert.ToInt32(row.Tag);
            }
            catch
            {
                intSelectedInvoiceID = 0;
            }


            if (intSelectedInvoiceID == 0)
            {
                doNotice("Please select an invoice.", 2);
                return;
            }

            //if (globalSettings.gen_ignore_paper == "0")
            //{
            //    if (WintecIDT700.ReadPrinterState() == 1)
            //    {
            //        doNotice("Please check paper!", 2);
            //        return;
            //    }
            //}


            String htmlResponse = "";

            doNotice("Printing Invoice.", 1);

            Web WebResponse = new Web(10000, 1, "");
            htmlResponse = WebResponse.GetURL("/terminal/customer/get-invoice?invoice_id=" + intSelectedInvoiceID.ToString());
            WebResponse = null;

            if (htmlResponse != "")
            {
                if (htmlResponse.IndexOf("err>") > -1)
                {
                    doNotice(htmlResponse.StripErrorTags(), 2);
                }
                else
                {

                    Util.printText(htmlResponse, false);

                    // int printSize = 0;
                    // string[] toPrintX = new string[1];
                    // string[] toPrint = htmlResponse.Split("\n".ToCharArray());

                    //// WintecIDT700.FeedPaper(100);

                    // foreach (string s in toPrint)
                    // {
                    //     if (s.Length < 2)
                    //     {
                    //         toPrintX[0] = "";
                    //         Util.Print(toPrintX, 1);
                    //     }
                    //     else
                    //     {
                    //         printSize = 1;
                    //         try
                    //         {
                    //             printSize = int.Parse(s[0].ToString());
                    //         }
                    //         catch { }
                    //         toPrintX[0] = s.Remove(0, 1);
                    //         Util.Print(toPrintX, printSize);
                    //     }
                    // }

                    // WintecIDT700.FeedPaper(150);

                    doNotice("Printing Invoice complete.", 1);
                }
            }
            else
            {
                doNotice("Could not print invoice details!", 2);
            }



        }



        private void grdInvoiceList_Click(object sender, EventArgs e)
        {

            try
            {
                DataGridViewRow row = grdInvoiceList.Rows[grdInvoiceList.CurrentCell.RowIndex];
                intSelectedInvoiceID = Convert.ToInt32(row.Tag);
            }
            catch
            {
                intSelectedInvoiceID = 0;
            }

        }

        private void btnReprintByCashier_Click(object sender, EventArgs e)
        {

            RestartLogoutTimer();

            try
            {
                DataGridViewRow row = grdZReports.Rows[grdZReports.CurrentCell.RowIndex];
                _customer_report_z_id = Convert.ToInt32(row.Tag);
            }
            catch
            {
                _customer_report_z_id = 0;
            }


            if (_customer_report_z_id == 0)
            {
                doNotice("Please select Z Report.", 2);
                return;
            }


            RestartLogoutTimer();

            doNotice("Fetching X - Intraday report for reprint.", 1);

            string htmlResponse = "";

            Web WebResponse = new Web(60000);
            htmlResponse = WebResponse.GetURL("/terminal/cashup/z-reprint?zid=" + _customer_report_z_id.ToString() + "&c=1");
            WebResponse = null;

            if (htmlResponse.IndexOf("err>") > -1)
            {
                doNotice(htmlResponse.StripErrorTags(), 1);
            }
            else
            {
                Util.printText(htmlResponse, false);
            }

        }

        private void radioButtonNever_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNever.Checked)
            {
                lblDisclaimer.Visible = true;
                chkLogoutAccept.Visible = true;
                chkLogoutAccept.Checked = false;
            }
            else
            {
                chkLogoutAccept.Checked = false;
                chkLogoutAccept.Visible = false;
                lblDisclaimer.Visible = false;
            }
        }





        private void btnShowEditPosUsers_Click(object sender, EventArgs e)
        {

            RestartLogoutTimer();

            txtPOSUserLastname.Text = "";
            txtPOSUserName.Text = "";
            txtPOSUserPIN.Text = "";

            try
            {
                DataGridViewRow row = grdPosUsers.Rows[grdPosUsers.CurrentCell.RowIndex];
                intSelectedPOSUserID = Convert.ToInt32(row.Tag);
            }
            catch
            {
                intSelectedPOSUserID = 0;
            }

            if (intSelectedPOSUserID == 0)
            {
                doNotice("Please select a user before pressing the 'Edit' button", 2);
                return;
            }


            loading_pos_user = true;

            lblPOSUSER1.Text = "Modify POS User";

            lblUserStatus.Visible = true;
            chkPosuserSuspended.Visible = true;
            selIDType1.Checked = true;
            selIDType2.Checked = false;
            selPOSUserIsAdmin1.Checked = true;
            selPOSUserIsAdmin2.Checked = false;
            chkPosuserSuspended.Checked = false;
            chkRicaTraining.Checked = false;
            lblRicaInfo.Visible = true;
            btnRicaRegister.Visible = false;

            lblRicaInfo.Text = "Rica Registered: No";
            lblRicaInfo.ForeColor = Color.FromArgb(64, 64, 64);
            btnRicaRegister.Visible = true;
            lblRicaChangeNotice.Visible = false;

            bool loadedPOSUser = false;
            try
            {
                foreach (string s in Util.pos_users)
                {
                    string[] line = s.Split('^');
                    if (intSelectedPOSUserID == Convert.ToInt32(line[0].ToString()))
                    {
                        loadedPOSUser = true;

                        txtPOSUserName.Text = line[1].ToString();
                        txtPOSUserLastname.Text = line[2].ToString();
                        txtPOSUserPIN.Text = line[5].ToString();

                        if (line[11].ToString() == "1")
                        {
                            selIDType1.Checked = false;
                            selIDType2.Checked = true;
                        }
                        txtIDNumber.Text = line[12].ToString();
                        if (line[9].ToString() == "1")
                        {
                            chkRicaTraining.Checked = true;
                            btnRicaRegister.Visible = true;
                        }
                        if (line[10].ToString() != "0")
                        {
                            lblRicaInfo.Text = "Rica Registered: Yes";
                            lblRicaInfo.ForeColor = Color.Green;
                            btnRicaRegister.Visible = false;
                            btnRicaRegister.Enabled = false;
                        }
                        else
                        {
                            btnRicaRegister.Enabled = true;
                        }

                        if (line[3].ToString() == "1")
                        {
                            selPOSUserIsAdmin1.Checked = false;
                            selPOSUserIsAdmin2.Checked = true;
                        }

                        if (line[4].ToString() == "2")
                        {
                            chkPosuserSuspended.Checked = true;
                        }


                    }

                }
            }
            catch { }

            if (!loadedPOSUser)
            {
                Util.showMessage("Unable to load Pos User Details!", Color.Red);
                return;
            }

            enablePanel(pnlAddEditUser, "users_3_2");

            checkIDNumber();

            loading_pos_user = false;

            txtPOSUserName.Focus();

        }

        //private void tmrPOSUSERTextBox_Tick(object sender, EventArgs e)
        //{
        //    doPOSUSERTextUpdate(true);
        //}


        //private void doPOSUSERTextUpdate(bool updatetype)
        //{
        //    if (updatetype == true)
        //    {
        //        tmrPOSUSERTextBox.Enabled = false;
        //        m_LastPressedButton = "none";
        //    }

        //    m_charIndex = 0;

        //    totalstring += newstring;

        //    newstring = "";

        //    currentTextbox.Text = totalstring;

        //    if (currentTextbox.Text.Length > 0)
        //    {
        //        currentTextbox.Select(currentTextbox.Text.Length, currentTextbox.Text.Length);
        //        currentTextbox.ScrollToCaret();
        //    }
        //}

        //string newstring = "";
        //string totalstring = "";

        //string m_LastTextbox;
        //string m_LastPressedButton;
        //int m_charIndex = 0;

        //TextBox currentTextbox;

        //private void textBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        //{

        //    RestartLogoutTimer();

        //    currentTextbox = (TextBox)sender;

        //    if (!currentTextbox.Name.Equals(m_LastTextbox))
        //    {
        //        m_LastTextbox = currentTextbox.Name;
        //        m_charIndex = 0;
        //        newstring = "";
        //        totalstring = currentTextbox.Text;
        //    }

        //    string pressedButton = e.KeyCode.ToString();
        //    string thisTag = "";
        //    char buttonChar;

        //    if (pressedButton == "Back")
        //    {

        //        m_charIndex = 0;
        //        totalstring = totalstring + newstring;
        //        newstring = "";

        //        if (totalstring.Length > 1)
        //            totalstring = totalstring.Substring(0, totalstring.Length - 1);
        //        else
        //            totalstring = "";

        //        currentTextbox.Text = totalstring;
        //        if (currentTextbox.Text.Length > 0)
        //        {
        //            currentTextbox.Select(currentTextbox.Text.Length, currentTextbox.Text.Length);
        //            currentTextbox.ScrollToCaret();
        //        }
        //        return;
        //    }

        //    //tmrPOSUSERTextBox.Enabled = false;
        //    tmrPOSUSERTextBox.Enabled = true;

        //    if (currentTextbox.Name == "txtSlipExtra1" || currentTextbox.Name == "txtSlipExtra2" || currentTextbox.Name == "txtSlipExtra3" || currentTextbox.Name == "txtSlipExtra4" || currentTextbox.Name == "txtSlipExtra5")
        //    {
        //        if (pressedButton == "ShiftKey")
        //            thisTag = "#";
        //        if (pressedButton == "Decimal")
        //            thisTag = "*.";
        //        if (pressedButton == "Return")
        //            thisTag = "R";
        //    }
        //    if (pressedButton == "D0")
        //        thisTag = " 0";
        //    if (pressedButton == "D1")
        //        thisTag = " -1";
        //    if (pressedButton == "D2")
        //        thisTag = "abc2";
        //    if (pressedButton == "D3")
        //        thisTag = "def3";
        //    if (pressedButton == "D4")
        //        thisTag = "ghi4";
        //    if (pressedButton == "D5")
        //        thisTag = "jkl5";
        //    if (pressedButton == "D6")
        //        thisTag = "mno6";
        //    if (pressedButton == "D7")
        //        thisTag = "pqrs7";
        //    if (pressedButton == "D8")
        //        thisTag = "tuv8";
        //    if (pressedButton == "D9")
        //        thisTag = "wxyz9";

        //    if (currentTextbox.Name == "txtReprint")
        //    {
        //        if (pressedButton == "D0")
        //            thisTag = "0";
        //        if (pressedButton == "D1")
        //            thisTag = "1";
        //        if (pressedButton == "D2")
        //            thisTag = "2abc";
        //        if (pressedButton == "D3")
        //            thisTag = "3def";
        //        if (pressedButton == "D4")
        //            thisTag = "4ghi";
        //        if (pressedButton == "D5")
        //            thisTag = "5jkl";
        //        if (pressedButton == "D6")
        //            thisTag = "6mno";
        //        if (pressedButton == "D7")
        //            thisTag = "7pqrs";
        //        if (pressedButton == "D8")
        //            thisTag = "8tuv";
        //        if (pressedButton == "D9")
        //            thisTag = "9wxyz";
        //    }

        //    if (thisTag == "")
        //        return;

        //    if (currentTextbox.Name == "txtPOSUserName" || currentTextbox.Name == "txtPOSUserLastname")
        //    {
        //        thisTag = thisTag.Replace("0", "");
        //        thisTag = thisTag.Replace("1", "");
        //        thisTag = thisTag.Replace("2", "");
        //        thisTag = thisTag.Replace("3", "");
        //        thisTag = thisTag.Replace("4", "");
        //        thisTag = thisTag.Replace("5", "");
        //        thisTag = thisTag.Replace("6", "");
        //        thisTag = thisTag.Replace("7", "");
        //        thisTag = thisTag.Replace("8", "");
        //        thisTag = thisTag.Replace("9", "");
        //    }

        //    if (pressedButton.Equals(m_LastPressedButton))
        //    {

        //        m_charIndex++;

        //        if (m_charIndex >= thisTag.Length)
        //            m_charIndex = 0;

        //        buttonChar = thisTag[m_charIndex];

        //        if (newstring.Length == 0)
        //            newstring += buttonChar;
        //        else
        //            newstring = newstring.Substring(0, newstring.Length - 1) + buttonChar;

        //    }
        //    else
        //    {
        //        doPOSUSERTextUpdate(false);

        //        m_LastPressedButton = pressedButton;
        //        buttonChar = thisTag[m_charIndex];
        //        if (newstring.Length == 0)
        //            newstring += buttonChar;
        //        else
        //            newstring = newstring.Substring(0, newstring.Length - 1) + buttonChar;
        //    }

        //    if (currentTextbox.Name == "txtSerialReprint")
        //    {
        //        totalstring = totalstring.ToUpper();
        //        newstring = newstring.ToUpper();
        //    }
        //    else
        //    {
        //        totalstring = Util.str_camel_case(totalstring);
        //    }

        //    currentTextbox.Text = totalstring + newstring;

        //    if (currentTextbox.Text.Length > 0)
        //    {
        //        currentTextbox.Select(currentTextbox.Text.Length, currentTextbox.Text.Length);
        //        currentTextbox.ScrollToCaret();
        //    }

        //}







        //private void btnSerialNumberReprint_Click(object sender, EventArgs e)
        //{

        //    RestartLogoutTimer();

        //    if (txtReprint.Text == "")
        //    {
        //        doNotice("Please enter a value.", 2);
        //        return;
        //    }

        //    if (globalSettings.gen_ignore_paper == "0")
        //    {
        //        if (WintecIDT700.ReadPrinterState() == 1)
        //        {
        //            doNotice("Please check printer paper!", 2);
        //            return;
        //        }
        //    }

        //    int reprint_type = 1;

        //    if (rdoReprint2.Checked) reprint_type = 2;
        //    if (rdoReprint3.Checked) reprint_type = 2;

        //    String ret = webService.getReprint(reprint_type, txtReprint.Text);

        //    if (ret == "OK")
        //    {
        //        if (globalVoucher.service_provider_item_id == 51)
        //        {

        //            //vStreamWS voucherWS = new vStreamWS();
        //            //string retVal = voucherWS.elecReprintByMeter(txtReprint.Text);
        //            //if (retVal.Length != 0)
        //            //{
        //            //    string elecVoucher = "";
        //            //    int rowCount = 0;
        //            //    string[] toSplit = retVal.Split("\n".ToCharArray());
        //            //    foreach (string s in toSplit)
        //            //    {
        //            //        rowCount++;
        //            //        if (rowCount == 1)
        //            //        {
        //            //            //
        //            //        }
        //            //        else
        //            //        {
        //            //            elecVoucher += "\n" + s;
        //            //        }
        //            //    }

        //            //    voucherWS.PrintElectricityToken(elecVoucher);
        //            //    txtReprint.Text = "";
        //            //    lblStatusBottom.Text = "Re-Printing Electricity Token. Done.";
        //            //}
        //            //else
        //            //{
        //            //    lblStatusBottom.Text = "Unable to retrieve last Electricity Token.";
        //            //}
        //            //voucherWS = null;

        //        }
        //        else
        //        {
        //            globalVoucher.pin_number = Util.str_decrypt_pin(globalVoucher.pin_number_encryped);
        //            globalVoucher.getArrayId();
        //            Util.printVoucher();
        //        }

        //        doNotice("Re-Printing Voucher complete.", 1);

        //    }
        //    else
        //    {
        //        doNotice(ret, 2);
        //    }

        //    //lblStatusBottom.Text = "Re-Printing Airtime.";
        //    //Application.DoEvents();

        //    //vsVoucher ReprintVoucher = new vsVoucher();

        //    //ReprintVoucher.user_id = Int32.Parse(globalSettings.pos_user_id);

        //    //vStreamWS voucherWS = new vStreamWS();

        //    //voucherWS.GetReprintBySerial(ref ReprintVoucher, txtReferenceReprint.Text);

        //    //if (ReprintVoucher.v_ok == true)
        //    //{
        //    //    ReprintVoucher.getDescriptionAndBarcode();
        //    //    voucherWS.PrintVoucher(ReprintVoucher);
        //    //    totalstring = "";
        //    //    newstring = "";
        //    //    txtReferenceReprint.Text = "";
        //    //    txtSerialReprint.Text = "";
        //    //}

        //    //voucherWS = null;

        //    //Application.DoEvents();

        //    //ReprintVoucher = null;




        //}



        private void btnReprintAirtime_Click(object sender, EventArgs e)
        {
            doNotice("Printing Last Airtime Reprints", 1);
            print_reprints("1");
        }

        private void btnReprintElectricity_Click(object sender, EventArgs e)
        {
            doNotice("Printing Last Electricity Reprints", 1);
            print_reprints("2");
        }

        private void print_reprints(String reprint_type)
        {

            RestartLogoutTimer();


            string htmlResponse = "";

            Web WebResponse = new Web(35000);
            htmlResponse = WebResponse.GetURL("/terminal/customer/get-reprint-list?t=" + reprint_type);
            WebResponse = null;

            if (htmlResponse.IndexOf("err>") > -1)
            {
                doNotice(htmlResponse.StripErrorTags(), 2);
            }
            else
            {

                Util.printText(htmlResponse, false);

                //int printSize = 0;
                //string[] toPrintX = new string[1];
                //if (htmlResponse != "")
                //{

                //    string[] toPrint = htmlResponse.Split("\n".ToCharArray());

                //    foreach (string s in toPrint)
                //    {

                //        if (s.Length < 2)
                //        {
                //            toPrintX[0] = "";
                //            Util.Print(toPrintX, 1);
                //        }
                //        else
                //        {
                //            printSize = 1;
                //            try
                //            {
                //                printSize = int.Parse(s[0].ToString());
                //            }
                //            catch { }
                //            toPrintX[0] = s.Remove(0, 1);
                //            Util.Print(toPrintX, printSize);
                //        }
                //    }

                //    WintecIDT700.FeedPaper(100);
                //}

            }

        }


        private void btnQuickLanuch_Click(object sender, EventArgs e)
        {

            RestartLogoutTimer();

            chkQuickPrintDisable.Checked = false;
            if (globalSettings.gen_quick_print_disable == "1") chkQuickPrintDisable.Checked = true;

            chkQuickPrintConfirm.Checked = false;
            if (globalSettings.gen_quick_print_confirm == "1") chkQuickPrintConfirm.Checked = true;

            try
            {

                int voucher_prov_arr_id = -1;
                foreach (stockProvider sp in Util.stock_provider)
                {
                    voucher_prov_arr_id++;
                    for (int x = 0; x < Util.stock_provider[voucher_prov_arr_id].itemcount; x++)
                    {

                        cboQLaunch1.Items.Add(Util.stock_provider[voucher_prov_arr_id].item[x].item_desc);
                        if (globalSettings.quickprint_item1 == Util.stock_provider[voucher_prov_arr_id].item[x].item_id.ToString())
                        {
                            cboQLaunch1.Text = Util.stock_provider[voucher_prov_arr_id].item[x].item_desc;
                        }

                        cboQLaunch2.Items.Add(Util.stock_provider[voucher_prov_arr_id].item[x].item_desc);
                        if (globalSettings.quickprint_item2 == Util.stock_provider[voucher_prov_arr_id].item[x].item_id.ToString())
                        {
                            cboQLaunch2.Text = Util.stock_provider[voucher_prov_arr_id].item[x].item_desc;
                        }

                        cboQLaunch3.Items.Add(Util.stock_provider[voucher_prov_arr_id].item[x].item_desc);
                        if (globalSettings.quickprint_item3 == Util.stock_provider[voucher_prov_arr_id].item[x].item_id.ToString())
                        {
                            cboQLaunch3.Text = Util.stock_provider[voucher_prov_arr_id].item[x].item_desc;
                        }

                        cboQLaunch4.Items.Add(Util.stock_provider[voucher_prov_arr_id].item[x].item_desc);
                        if (globalSettings.quickprint_item4 == Util.stock_provider[voucher_prov_arr_id].item[x].item_id.ToString())
                        {
                            cboQLaunch4.Text = Util.stock_provider[voucher_prov_arr_id].item[x].item_desc;
                        }

                        cboQLaunch5.Items.Add(Util.stock_provider[voucher_prov_arr_id].item[x].item_desc);
                        if (globalSettings.quickprint_item5 == Util.stock_provider[voucher_prov_arr_id].item[x].item_id.ToString())
                        {
                            cboQLaunch5.Text = Util.stock_provider[voucher_prov_arr_id].item[x].item_desc;
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                doNotice(ex.Message, 2);
            }

            enablePanel(pnlQuickLaunch, "general_4_3");

        }



        private void btnPosuserDelete_Click(object sender, EventArgs e)
        {
            RestartLogoutTimer();

            try
            {
                DataGridViewRow row2 = grdPosUsers.Rows[grdPosUsers.CurrentCell.RowIndex];
                intSelectedPOSUserID = Convert.ToInt32(row2.Tag);
            }
            catch
            {
                intSelectedPOSUserID = 0;
            }

            if (intSelectedPOSUserID == 0)
            {
                doNotice("Please select a user before pressing the 'Edit' button", 2);
                return;
            }

            //String posusername = grdPosUsers.Cells[grdPosUsers.ActiveRowIndex, 1].Text;

            DataGridViewRow row = grdPosUsers.Rows[grdPosUsers.CurrentCell.RowIndex];
            String posusername = row.Cells[1].Value.ToString();

            if (btnPosuserDelete.Text == "3.3 Delete")
            {

                doNotice("Are you sure you want to delete user:" + posusername, 2);

                btnPosuserDelete.Text = "Confirm";
                btnShowAddPosUsers.Visible = false;
                btnShowEditPosUsers.Visible = false;
                btnRefreshPOSUsers.Text = "Cancel";

                grdPosUsers.Enabled = false;

                return;

            }

            if (btnPosuserDelete.Text == "Confirm")
            {

                string ret = "";

                try
                {
                    ret = webService.deletePosUser(intSelectedPOSUserID.ToString());
                    if (ret == "1")
                    {
                        doNotice(posusername + " successfully deleted.", 1);
                    }
                    else
                    {
                        doNotice(ret, 2);
                        return;
                    }

                }
                catch { }

                webService.getPosUsers();
                Util.loadPosUsers();

                populatePosUserGrid();

                btnPosuserDelete.Text = "3.3 Delete";
                btnShowAddPosUsers.Visible = true;
                btnRefreshPOSUsers.Visible = true;
                btnShowEditPosUsers.Text = "3.2 Modify";

                grdPosUsers.Enabled = true;

            }


        }




        private void btnPrintTest_Click(object sender, EventArgs e)
        {

            RestartLogoutTimer();

            //WintecIDT700.FeedPaper(100);

            string printlines = "             Top it Up";
            //Util.Print(printlines, 3);

            printlines += "1      Would like to welcome\n";
            printlines += "3" + Util.str_wrap(globalSettings.company_name, 32, true) + "\n";

            printlines += "1\n";
            string currentDate = DateTime.Now.ToString("dd/MM/yyyy");
            string currentTime = DateTime.Now.ToString("HH:mm");

            printlines += "1Date: " + currentDate + "\n";
            printlines += "1Time: " + currentTime + "\n";

            printlines += "1\n";

            printlines += "1 Convenience at your fingertips" + "\n";
            printlines += "1          0860 111 723" + "\n";
            printlines += "1       www.itopitup.co.za" + "\n";

            printlines += "1\n";

            printlines += "1" + txtSlipExtra1.Text.Trim() + "\n";
            printlines += "1" + txtSlipExtra2.Text.Trim() + "\n";
            printlines += "1" + txtSlipExtra3.Text.Trim() + "\n";
            printlines += "1" + txtSlipExtra4.Text.Trim() + "\n";
            printlines += "1" + txtSlipExtra5.Text.Trim() + "\n";

            Util.printText(printlines, false);

            //WintecIDT700.FeedPaper(230);
        }

        //private void btmExitApp_Click(object sender, EventArgs e)
        //{

        //    System.Windows.Forms.Application.Exit();

        //}







        //private void btnSalesRpt_Click(object sender, EventArgs e)
        //{

        //    RestartLogoutTimer();

        //    cboStime.Items.Clear();
        //    cboEtime.Items.Clear();
        //    for (var time = new DateTime(2000, 1, 1, 1, 0, 0); time <= new DateTime(2000, 1, 1, 23, 0, 0); time = time.AddMinutes(15))
        //    {
        //        cboStime.Items.Add(time.ToString("HH:mm"));
        //        cboEtime.Items.Add(time.ToString("HH:mm"));
        //    }
        //    cboStime.Text = "09:00";
        //    cboEtime.Text = "12:00";

        //    cboSyear.Text = DateTime.Today.Year.ToString();
        //    cboEyear.Text = DateTime.Today.Year.ToString();

        //    cboSmonth.Text = DateTime.Today.ToString("MMMM");
        //    cboEmonth.Text = DateTime.Today.ToString("MMMM");

        //    cboSday.Text = DateTime.Today.Day.ToString();
        //    cboEday.Text = DateTime.Today.Day.ToString();

        //    for (int loop = DateTime.Today.Year - 1; loop <= DateTime.Today.Year; loop++)
        //    {
        //        cboSyear.Items.Add(loop.ToString());
        //        cboEyear.Items.Add(loop.ToString());
        //    }
        //    cboSyear.Text = DateTime.Today.ToString("yyyy");
        //    cboEyear.Text = DateTime.Today.ToString("yyyy"); 

        //    pnlSalesRpt.Dock = DockStyle.Fill;
        //    pnlSalesRpt.BringToFront();
        //    pnlSalesRpt.Show();

        //    getLastSales();

        //    doNotice("Last 10 Sales.", 1);

        //}



        //private void getLastSalesSearch(string sdate, string stime, string edate, string etime, string service_provider_item_id)
        //{
        //    grdSR.Rows.Clear();

        //    String htmlResponse = webService.getLastSalesSearch(sdate, stime, edate, etime, service_provider_item_id);

        //    if (htmlResponse.IndexOf("err>") > -1)
        //    {
        //        doNotice(htmlResponse.StripErrorTags(), 2);
        //    }
        //    else if (htmlResponse != "")
        //    {
        //        try
        //        {
        //            string[] lines = htmlResponse.Split('\n');

        //            for (int i = 0; i < lines.Length - 1; i++)
        //            {
        //                string[] items = lines[i].Split('^');
        //                Resco.Controls.SmartGrid.Row r = new Resco.Controls.SmartGrid.Row(6);
        //                r.Height = 30;
        //                r[0] = " " + Convert.ToInt32(items[0].ToString());
        //                r[1] = " " + items[1].ToString();
        //                r[2] = " " + items[2].ToString();
        //                r[3] = String.Format(" R {0:n}", items[3]).Replace(".0", ".00");
        //                r[4] = " " + items[4].ToString();
        //                r[5] = " " + items[5].ToString();
        //                grdSR.Rows.Add(r);
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //}

        //private void getLastSales()
        //{

        //    grdSR.Rows.Clear();

        //    String htmlResponse = webService.getLastSales();

        //    if (htmlResponse.IndexOf("<webreqerr>", 0) >= 0)
        //    {
        //        doNotice(htmlResponse,2);
        //    }
        //    else if (htmlResponse.IndexOf("<err>", 0) >= 0)
        //    {
        //        doNotice(htmlResponse,2);
        //    }
        //    else if (htmlResponse != "")
        //    {
        //        try
        //        {
        //            string[] lines = htmlResponse.Split('\n');

        //            for (int i = 0; i < lines.Length - 1; i++)
        //            {
        //                string[] items = lines[i].Split('^');
        //                Resco.Controls.SmartGrid.Row r = new Resco.Controls.SmartGrid.Row(6);
        //                r.Height = 30;
        //                r[0] = " " + Convert.ToInt32(items[0].ToString());
        //                r[1] = " " + items[1].ToString();
        //                r[2] = " " + items[2].ToString();
        //                r[3] = String.Format(" R {0:n}", items[3]).Replace(".0", ".00");
        //                r[4] = " " + items[4].ToString();
        //                r[5] = " " + items[5].ToString();
        //                grdSR.Rows.Add(r);
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }

        //}


        private void btnInvoiceFilter_Click(object sender, EventArgs e)
        {

            string sDate = cboInvSy.Text + DateTime.ParseExact(cboInvSm.Text, "MMMM", CultureInfo.CurrentCulture).Month.ToString().PadLeft(2, '0') + cboInvSd.Text.ToString().PadLeft(2, '0');
            string eDate = cboInvEy.Text + DateTime.ParseExact(cboInvEm.Text, "MMMM", CultureInfo.CurrentCulture).Month.ToString().PadLeft(2, '0') + cboInvEd.Text.ToString().PadLeft(2, '0');

            doNotice("From: " + sDate + ", To: " + eDate, 1);

            PopulateInvoicesGridDtm(sDate, eDate);

        }


        private void btnRefreshPOSUsers_Click(object sender, EventArgs e)
        {
            RestartLogoutTimer();

            Util.showWait(true);

            if (btnRefreshPOSUsers.Text == "Cancel")
            {
                btnPosuserDelete.Text = "3.3 Delete";
                btnRefreshPOSUsers.Visible = true;
                btnShowAddPosUsers.Visible = true;
                btnShowEditPosUsers.Visible = true;
                btnRefreshPOSUsers.Text = "3.4 Refresh";
                grdPosUsers.Enabled = true;
                return;
            }

            intSelectedPOSUserID = 0;
            doNotice("Refreshing Pos Users.", 1);

            grdPosUsers.Rows.Clear();

            try
            {

                string htmlresponse = webService.getPosUsers();
                if (htmlresponse.Length > 0)
                {
                    doNotice(htmlresponse, 2);
                }
                else
                {
                    doNotice("Refreshing Pos Users. Complete.", 1);
                    Util.loadPosUsers();
                    populatePosUserGrid();
                }

            }
            catch
            {
                doNotice("Connection Problem.", 2);
            }

            Util.showWait(false);

            RestartLogoutTimer();

        }




        private void btnPingServer_Click(object sender, EventArgs e)
        {

            //try
            //{
            //    OpenNETCF.Net.NetworkInformation.Ping ping = new OpenNETCF.Net.NetworkInformation.Ping();

            //    lblSIMDetails.Text = "Pinging server: " + globalSettings.svr_hostname + "\n";

            //    for (int i = 0; i < 6; i++)
            //    {
            //        OpenNETCF.Net.NetworkInformation.PingReply pingReply = ping.Send(globalSettings.svr_ip);
            //        if (pingReply.Status == OpenNETCF.Net.NetworkInformation.IPStatus.Success)
            //        {
            //            string pingDesc = "SPEED SLOW";
            //            if (pingReply.RoundTripTime < 1200)
            //                pingDesc = "SPEED AVERAGE";
            //            if (pingReply.RoundTripTime < 700)
            //                pingDesc = "SPEED GOOD";
            //            if (pingReply.RoundTripTime < 300)
            //                pingDesc = "SPEED FAST";

            //            lblSIMDetails.Text += "Time: " + pingReply.RoundTripTime.ToString() + "ms - " + pingDesc + "\n";

            //            Application.DoEvents();

            //        }
            //        else
            //        {
            //            lblSIMDetails.Text += "Time out - There are connection Issues.\n";
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    lblSIMDetails.Text = ex.Message;
            //}
        }





        //private void btnSRFilter_Click(object sender, EventArgs e)
        //{

        //    String sDate = cboSyear.Text + "-" + DateTime.ParseExact(cboSmonth.Text, "MMMM", CultureInfo.CurrentCulture).Month.ToString().PadLeft(2, '0') + "-" + cboSday.Text.ToString().PadLeft(2, '0');
        //    String eDate = cboEyear.Text + "-" + DateTime.ParseExact(cboEmonth.Text, "MMMM", CultureInfo.CurrentCulture).Month.ToString().PadLeft(2, '0') + "-" + cboEday.Text.ToString().PadLeft(2, '0');

        //    String service_provider_item_id = "0";

        //    try
        //    {
        //        service_provider_item_id = ((ComboboxItem)cboVoucher.SelectedItem).Value;
        //    }
        //    catch
        //    {
        //        service_provider_item_id = "0";
        //    }

        //    doNotice("Searching Sales (100 results max).", 1);

        //    getLastSalesSearch(sDate, cboStime.Text, eDate, cboEtime.Text, service_provider_item_id);

        //}





        //private void btnSRReprint_Click(object sender, EventArgs e)
        //{
        //    RestartLogoutTimer();

        //    if (globalSettings.gen_ignore_paper == "0")
        //    {
        //        if (WintecIDT700.ReadPrinterState() == 1)
        //        {
        //            doNotice("Please check paper!", 2);
        //            return;
        //        }
        //    }

        //    int _reprint_uid = 0;

        //    //if (grdSR.Cells[grdSR.ActiveRowIndex, 2].Text.Trim() == "Electricity")
        //    //{
        //    //    MessageBox.Show("Electra");
        //    //   // isElectraReprint = true;
        //    //}

        //    if (grdSR.Cells[grdSR.ActiveRowIndex, 0].Text != "")
        //    {
        //        try
        //        {
        //            _reprint_uid = Convert.ToInt32(grdSR.Cells[grdSR.ActiveRowIndex, 0].Text); ;
        //        }
        //        catch
        //        {
        //            _reprint_uid = 0;
        //        }
        //    }
        //    else
        //    {
        //        _reprint_uid = 0;
        //    }

        //    if (_reprint_uid == 0)
        //    {
        //        doNotice("Please select an voucher.", 2);
        //        return;
        //    }

        //    String ret = webService.getReprint(1, _reprint_uid.ToString());

        //    if (ret == "OK")
        //    {

        //        doNotice("Re-Printing Voucher.", 2);

        //        if (globalVoucher.service_provider_item_id == 51)
        //        {
        //            Web WebResponse = new Web(60000);
        //            String htmlResponse = "";
        //            htmlResponse = WebResponse.GetURL("/itron/electricity/vendGetReprint?lic=" + globalSettings.license_code + "&uid=" + globalVoucher.stock_uid + "&s=1&d=false");
        //            WebResponse = null;
        //            if (htmlResponse.IndexOf("err>") > -1)
        //            {
        //                doNotice(htmlResponse.StripErrorTags(),2);
        //            }
        //            else
        //            {
        //                Util.printText(htmlResponse);
        //            }
        //        }
        //        else
        //        {
        //            globalVoucher.pin_number = Util.str_decrypt_pin(globalVoucher.pin_number_encryped);
        //            globalVoucher.getArrayId();
        //            Util.printVoucher();
        //        }
        //    }
        //    else
        //    {
        //        doNotice("Could not Re-Printing Voucher.", 2);
        //    }



        //}

        string CleanString(string numberonly)
        {
            System.Text.RegularExpressions.Regex digitsOnly = new System.Text.RegularExpressions.Regex(@"[^\d]");
            return digitsOnly.Replace(numberonly, "");
        }

        private void btnZIDReprint_Click(object sender, EventArgs e)
        {

            RestartLogoutTimer();

            //if (globalSettings.gen_ignore_paper == "0")
            //{
            //    if (WintecIDT700.ReadPrinterState() == 1)
            //    {
            //        doNotice("Please check paper!", 2);
            //        return;
            //    }
            //}

            txtZID.Text = CleanString(txtZID.Text);

            if (txtZID.Text == "")
            {
                doNotice("Please enter a Z #", 2);
                return;
            }

            doNotice("Fetching X - Intraday report for reprint.", 1);

            string htmlResponse = "";

            Web WebResponse = new Web(60000);
            htmlResponse = WebResponse.GetURL("/terminal/cashup/z-reprint?license=" + globalSettings.license_code + "&uid=" + txtZID.Text);
            WebResponse = null;

            if (htmlResponse.IndexOf("err>") > -1)
            {
                doNotice(htmlResponse.StripErrorTags(), 2);
            }
            else
            {
                Util.printText(htmlResponse, false);
            }

        }



        private void btnPrintBalance_Click(object sender, EventArgs e)
        {
            dtSalesReport.Format = DateTimePickerFormat.Custom;
            dtSalesReport.CustomFormat = "yyyy-MM";
            dtSalesReport.ShowUpDown = true;
            reportType = "Monthly Deposit";
            pnlReport.Show();
            pnlReport.BringToFront();
            //  RestartLogoutTimer();
            // btnPrintBalanceGo();

        }

        private void btnPrintBalanceGo()
        {

            String print_balance = "";
            //if (globalSettings.gen_ignore_paper == "0")
            //{
            //    if (WintecIDT700.ReadPrinterState() == 1)
            //    {
            //        doNotice("Please check paper!", 2);
            //        return;
            //    }
            //}

            //try
            //{
            //    WintecIDT700.FeedPaper(100);

            print_balance += "1" + globalSettings.company_name + "\n";


            print_balance += "1Current Balance Report\n";
            //    WintecIDT700.FeedPaper(80);

            print_balance += "1Date: " + finBalance.dtmd + "\n";
            print_balance += "1Time: " + finBalance.dtmt + "\n";
            //    WintecIDT700.FeedPaper(80);

            print_balance += "1Available: R " + finBalance.available_balance + "\n";
            print_balance += "1Balance: R " + finBalance.balance + "\n";

            if (finBalance.credit_limit != "0.00")
            {
                print_balance += "1Credit: R " + finBalance.credit_limit + "\n";
            }
            if (finBalance.credit_extended != "0.00")
            {
                print_balance += "1Temp Credit: R " + finBalance.credit_extended + "\n";
            }

            //if (finBalance.cash_customer.Equals("0"))
            //{
            print_balance += "1Cash : R " + finBalance.balance_cash + "\n";
            //}

            Util.printText(print_balance, false);

            //    WintecIDT700.FeedPaper(230);

            //}
            //catch { }
        }


        private void btnAdminSaveSettings_Click(object sender, EventArgs e)
        {



        }





        String OriginalLicenseDesc = "";


        public void setLicenseDesc(string newLicenseName)
        {
            String htmlResponse = "";
            try
            {
                Web WebResponse = new Web(10000, 1, "");
                htmlResponse = WebResponse.GetURL("/terminal/general/set-terminal-desc?desc=" + txtTerminalName.Text);
                WebResponse = null;

                if (htmlResponse.IndexOf("err>") > -1)
                {
                    doNotice(htmlResponse.StripErrorTags(), 1);
                }
                else
                {
                    OriginalLicenseDesc = txtTerminalName.Text;
                }
            }
            catch
            {
                doNotice("Error saving terminal description.", 2);
            }
        }




        private void btnGenerateDeposit_Click(object sender, EventArgs e)
        {

            RestartLogoutTimer();

            if (txtDepositAmount.Text.Length == 0)
            {
                doNotice("Please enter a deposit amount!", 2);
                return;
            }

            string htmlResponse = "";

            Web WebResponse = new Web(60000);
            htmlResponse = WebResponse.GetURL("/terminal/general/get-deposit-slip?v=" + txtDepositAmount.Text);
            WebResponse = null;

            if (htmlResponse.IndexOf("err>") > -1)
            {
                doNotice(htmlResponse.StripErrorTags(), 2);
            }
            else
            {


                Util.printText(htmlResponse, false);

                //int printSize = 0;
                //string[] toPrintX = new string[1];
                //if (htmlResponse != "")
                //{

                //    string[] toPrint = htmlResponse.Split("\n".ToCharArray());

                //    //WintecIDT700.FeedPaper(100);

                //    foreach (string s in toPrint)
                //    {

                //        if (s.Length < 2)
                //        {
                //            toPrintX[0] = "";
                //            Util.Print(toPrintX, 1);
                //        }
                //        else
                //        {
                //            printSize = 1;
                //            try
                //            {
                //                printSize = int.Parse(s[0].ToString());
                //            }
                //            catch { }
                //            toPrintX[0] = s.Remove(0, 1);
                //            Util.Print(toPrintX, printSize);
                //        }
                //    }

                //    //WintecIDT700.FeedPaper(100);
                //}

            }

        }



        private void btnLogout_Click(object sender, EventArgs e)
        {

            tmr_delayed_load.Enabled = false;
            tmr_logout.Enabled = false;

            this.Close();

        }

        private void btnUsers_Click(object sender, EventArgs e)
        {

            RestartLogoutTimer();

            if (!check_for_accept()) return;

            hideAllPanels();

            setPressed(3);

            intSelectedPOSUserID = 0;

            grdPosUsers.Enabled = true;

            txtPOSUserLastname.Text = "";
            txtPOSUserName.Text = "";
            txtPOSUserPIN.Text = "";
            //totalstring = "";
            //newstring = "";

            pnlAddEditUser.Hide();

            virtualKeyboard1.setKeyPadOnly(false);

            pnl_main_users.BringToFront();
            pnl_main_users.Refresh();

            populatePosUserGrid();

        }

        private void btnFinancial_Click(object sender, EventArgs e)
        {

            RestartLogoutTimer();

            if (!check_for_accept()) return;

            hideAllPanels();

            Util.showWait(true);

            setPressed(2);

            btnReqExtendedCredit.Hide();
            btnPrintBalance.Hide();
            pnlInvoices.Hide();
            pnlFundTransfer.Hide();
            //pnlFundsTransfer.Hide();
            pnlFinancialTx.Hide();


            grp_finw1.Hide();
            btnTransferPanel.Hide();
            btnTransferShow.Hide();
            lblPleaseRefreshBalance.Show();

            txtDepositAmount.Text = "";

            virtualKeyboard1.setKeyPadOnly(true);

            getBallance();

            pnl_main_financial.BringToFront();

            RestartLogoutTimer();

            Util.showWait(false);

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {

            RestartLogoutTimer();

            if (!check_for_accept()) return;

            hideAllPanels();

            setPressed(4);


            //btnSkype.Visible = false;
            //if (globalSettings.gen_show_btn_skype == "1")
            //{
            //    if (Util.setSkypePath().Length > 0)
            //    {
            //        btnSkype.Visible = true;
            //    }
            //}


            if (globalSettings.gen_show_btn_teamviewer == "1")
            {
                btnLoginTeamViewer.Visible = true;
            }


            //bool showSettingsBtn = false;

            //if (globalSettings.gen_show_login_desktop_icon == "1")
            //{
            //    showSettingsBtn = true;
            //}
            //if (globalSettings.gen_show_login_lockpc_icon == "1")
            //{
            //    showSettingsBtn = true;
            //}
            //if (globalSettings.gen_show_login_netcon_icon == "1")
            //{
            //    showSettingsBtn = true;
            //}
            //if (globalSettings.gen_show_login_shutdown == "1")
            //{
            //    showSettingsBtn = true;
            //}

            //if (showSettingsBtn)
            //{
            //    btnPCSettings.Show();
            //}

            virtualKeyboard1.setKeyPadOnly(false);

            pnl_main_settings.BringToFront();

        }

        private void hideAllPanels()
        {
            this.SuspendLayout();

            _current_action_save = "";
            btnSaveGlobal.Hide();

            try
            {
                _activePanel.Hide();
            }
            catch
            {
                //
            }

            btnCloseAll.Hide();

            this.ResumeLayout(false);

            RestartLogoutTimer();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {

            RestartLogoutTimer();

            if (!check_for_accept()) return;

            hideAllPanels();

            setPressed(1);

            pnlZReports.Visible = false;
            //pnlReprintManagement.Visible = false;
            //pnlSalesRpt.Visible = false;

            virtualKeyboard1.setKeyPadOnly(true);

            pnl_main_reports.BringToFront();
        }






        private void chkCashierZ_CheckStateChanged(object sender, EventArgs e)
        {

            if (loading) return;

            //globalSettings.gen_cashier_z = "0";
            //if (chkCashierZ.Checked) globalSettings.gen_cashier_z = "1";
            globalSettings.SaveGeneral();
            doNotice("Settings saved!", 1);
        }


        private void cmbLinkedLicenses_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (_loading_z_report) return;

            //String value = ((ComboboxItem)cmbLinkedLicenses.SelectedItem).Value;
            String value = ((ComboboxItem)cmbLinkedLicenses.SelectedItem).Value;

            _license_code = value;

            grdZReports.Rows.Clear();

            doNotice("Showing last 10 Z - End-of-Day reports for selected license/terminal.", 1);

            PopulateZReportGrid(_license_code);

        }


        int lastButton = 0;
        public void setPressed(int currentButton)
        {

            if (lastButton == currentButton) {
                return;

            } else {
                if (lastButton == 1)
                {
                    this.btnReports.BackColor = Color.Gainsboro;
                    this.btnReports.ForeColor = Color.Maroon;
                    this.btnReports.Refresh();
                }
                else if (lastButton == 2)
                {
                    this.btnFinancial.BackColor = Color.Gainsboro;
                    this.btnFinancial.ForeColor = Color.Maroon;
                    this.btnFinancial.Refresh();
                }
                else if (lastButton == 3)
                {
                    this.btnUsers.BackColor = Color.Gainsboro;
                    this.btnUsers.ForeColor = Color.Maroon;
                    this.btnUsers.Refresh();
                }
                else if (lastButton == 4)
                {
                    this.btnSettings.BackColor = Color.Gainsboro;
                    this.btnSettings.ForeColor = Color.Maroon;
                    this.btnSettings.Refresh();
                }

                lastButton = currentButton;

            }

            if (currentButton == 1)
            {
                this.btnReports.BackColor = Color.Maroon;
                this.btnReports.ForeColor = Color.White;
                this.btnReports.Refresh();
            }
            else if (currentButton == 2)
            {
                this.btnFinancial.BackColor = Color.Maroon;
                this.btnFinancial.ForeColor = Color.White;
                this.btnFinancial.Refresh();
            }
            else if (currentButton == 3)
            {
                this.btnUsers.BackColor = Color.Maroon;
                this.btnUsers.ForeColor = Color.White;
                this.btnUsers.Refresh();
            }
            else if (currentButton == 4)
            {
                this.btnSettings.BackColor = Color.Maroon;
                this.btnSettings.ForeColor = Color.White;
                this.btnSettings.Refresh();
            }

        }




        private void enablePanel(Panel _thisPanel, String new_action_save)
        {

            _activePanel = _thisPanel;
            _thisPanel.Dock = DockStyle.Fill;
            _thisPanel.BringToFront();
            _thisPanel.Show();

            btnCloseAll.Show();

            _current_action_save = new_action_save;

            if (!new_action_save.Equals("")) btnSaveGlobal.Show();

        }




        private void doPanelCustomProducts()
        {


            chkListProducts.Items.Clear();


            JObject jsonObj = new JObject();
            String disableList = "";

            try
            {
                using (StreamReader file = File.OpenText(globalSettings.app_path + @"\conf\provider_item_" + custom_product_file + ".dis"))
                using (Newtonsoft.Json.JsonTextReader reader = new Newtonsoft.Json.JsonTextReader(file))
                {
                    jsonObj = (JObject)JToken.ReadFrom(reader);
                }

            }
            catch
            {
                //
            }

            disableList = jsonObj.ToString();

            bool enabled;

            int voucher_prov_arr_id = -1;
            foreach (stockProvider sp in Util.stock_provider)
            {
                voucher_prov_arr_id++;

                for (int x = 0; x < Util.stock_provider[voucher_prov_arr_id].itemcount; x++)
                {

                    if (disableList.IndexOf("\"" + Util.stock_provider[voucher_prov_arr_id].item[x].item_id.ToString() + "\"") != -1)
                    {
                        enabled = false;
                    }
                    else
                    {
                        enabled = true;
                    }

                    ListViewItem lvi = new ListViewItem(Util.stock_provider[voucher_prov_arr_id].item[x].item_desc.Replace(@"\n", " "));
                    lvi.Checked = enabled;
                    lvi.Tag = Util.stock_provider[voucher_prov_arr_id].item[x].item_id.ToString();
                    chkListProducts.Items.Add(lvi);

                }

            }





        }



        String custom_product_file = "";
        private void btnCustomProductAdmin_Click(object sender, EventArgs e)
        {
            RestartLogoutTimer();
            custom_product_file = "admin";
            doPanelCustomProducts();
            enablePanel(pnlCustomiseProducts, "users_3_7");
        }


        private void btnCustomProduct_Click(object sender, EventArgs e)
        {
            RestartLogoutTimer();
            custom_product_file = "cashier";
            doPanelCustomProducts();
            enablePanel(pnlCustomiseProducts, "users_3_6");
        }





        private void btnTransferPanel_Click(object sender, EventArgs e)
        {

            //txtRandValue.AllowDecimal = true;
            txtRandValue.MaxLength = 5;

            try
            {
                picRandBg.Image = new Bitmap(globalSettings.app_path + @"\images\elec_rand.gif");
            }
            catch
            {
                //
            }

            grpWalletXfer.Show();
            txtRandValue.Text = "";
            txtRandValue.Enabled = true;
            lblFundTransferComplete.Hide();
            btnWalletXfer.Text = "Transfer" + Environment.NewLine + "Funds";
            btnWalletXfer.Enabled = true;
            btnWalletXfer.Show();
            lblConfirmTransfer.Hide();

            enablePanel(pnlFundTransfer, "");

            btnPrintBalance.Hide();
            btnTransferPanel.Hide();
            btnTransferShow.Hide();
            grp_finw1.Hide();
            lblPleaseRefreshBalance.Show();

            txtRandValue.Focus();

        }

        private void numericTextBox_LostFocus(object sender, EventArgs e)
        {
            try
            {
                //amount = Convert.ToDouble(txtRandValue.Text);
                txtRandValue.Text = String.Format("{0:n}", Decimal.Parse(txtRandValue.Text.Replace(",", ""), System.Globalization.CultureInfo.InvariantCulture));
            }
            catch
            {
                //
            }

        }





        private void btnTransferPnlClose_Click(object sender, EventArgs e)
        {


            pnlFundTransfer.Hide();


        }

        private void btnFinTxRefresh_Click(object sender, EventArgs e)
        {

            Util.showWait(true);

            grdFinTx.Rows.Clear();

            String alltx = "1";
            if (chkAllTx.Checked) alltx = "0";

            String htmlResponse = "";
            int i = 0;

            try
            {

                Web WebResponse = new Web(10000);
                htmlResponse = WebResponse.GetURL("/terminal/financial/get-fintx?alltx=" + alltx);
                WebResponse = null;

                if (htmlResponse.IndexOf("err>") > -1)
                {
                    //
                }
                else if (htmlResponse.Length > 0)
                {

                    JObject json = JObject.Parse(htmlResponse);
                    JArray a = (JArray)json["arr"];

                    foreach (var item in a.Children())
                    {

                        grdFinTx.Rows.Add();
                        grdFinTx.Rows[i].Tag = item["tx_id"].ToString().Replace("\"", "");
                        grdFinTx.Rows[i].Cells[0].Value = item["tx_type"].ToString().Replace("\"", "");
                        grdFinTx.Rows[i].Cells[1].Value = item["customer_tx_date"].ToString().Replace("\"", "");
                        grdFinTx.Rows[i].Cells[2].Value = item["customer_order_no"].ToString().Replace("\"", "");
                        grdFinTx.Rows[i].Cells[3].Value = item["customer_tx_amount"].ToString().Replace("\"", "");
                        grdFinTx.Rows[i].Cells[4].Value = item["bank_description"].ToString().Replace("\"", "");

                        i++;

                    }



                }

            }
            catch (Exception ex)
            {
                doNotice(ex.Message, 2);
            }

            Util.showWait(false);

        }

        private void btnFinTxClose_Click(object sender, EventArgs e)
        {

            pnlFinancialTx.Hide();

        }

        private void btnGetDeposits_Click(object sender, EventArgs e)
        {

            tmr_logout.Enabled = false;

            txtDepositAmount.Text = "";
            enablePanel(pnlFinancialTx, "");

            RestartLogoutTimer();
        }




        private void btnElectraSettings_Click(object sender, EventArgs e)
        {

            chk_elec_preset_enabled.Checked = false;
            if (globalSettings.elec_preset_enabled == "1") chk_elec_preset_enabled.Checked = true;

            txt_elec_preset_val1.Text = globalSettings.elec_preset_val1;
            txt_elec_preset_val2.Text = globalSettings.elec_preset_val2;
            txt_elec_preset_val3.Text = globalSettings.elec_preset_val3;
            txt_elec_preset_val4.Text = globalSettings.elec_preset_val4;

            txt_elec_max_warning.Enabled = false;

            chkElectraShowMaxVend.Checked = false;
            if (globalSettings.elec_max_vend_show == "1") chkElectraShowMaxVend.Checked = true;

            chkElectraMaxWarning.Checked = false;
            if (globalSettings.elec_max_warning_show == "1") chkElectraMaxWarning.Checked = true;

            txt_elec_max_warning.Text = globalSettings.elec_max_warning_val;


            enablePanel(pnlElectraSettings, "general_4_4");

            lbl_system_electra_max.Text = "";

            start_delayed_load("system_electra_max", 500);


        }

        private void start_delayed_load(String action, int interval)
        {
            _current_action = action;
            tmr_delayed_load.Interval = interval;
            tmr_delayed_load.Enabled = true;
        }



        private void btnCloseAll_Click(object sender, EventArgs e)
        {
            hideAllPanels();
        }



        private void btnUpdateManagement_Click(object sender, EventArgs e)
        {

            lblcurrspiver.Text = "?";
            lblcurrswver.Text = "?";

            try
            {
                lblcurrspiver.Text = String.Format("{0:####-##-##-####}", Convert.ToInt64(globalSettings.spi_ver));
                lblcurrswver.Text = String.Format("{0:####-##-##-####}", Convert.ToInt64(globalSettings.app_ver));
                lbl_app_ver_desc.Text = globalSettings.app_ver_desc;
            }
            catch
            {
                //
            }

            enablePanel(pnlUpdateManagement, "");

        }

        private void btnTxPrint_Click(object sender, EventArgs e)
        {

            int _printtx_uid = 0;

            try
            {
                DataGridViewRow row = grdFinTx.Rows[grdFinTx.CurrentCell.RowIndex];
                _printtx_uid = Convert.ToInt32(row.Tag);
            }
            catch
            {
                _printtx_uid = 0;
            }

            if (_printtx_uid == 0)
            {
                Util.showMessage("No Transaction selected.", Color.Red);
                return;
            }

            String htmlResponse = "";

            doNotice("Printing Financial Transaction.", 1);

            Web WebResponse = new Web(15000, 1, "");
            htmlResponse = WebResponse.GetURL("/terminal/financial/print-fintx?tx_id=" + _printtx_uid.ToString());
            WebResponse = null;

            if (htmlResponse != "")
            {
                if (htmlResponse.IndexOf("err>") > -1)
                {
                    doNotice(htmlResponse.StripErrorTags(), 2);
                }
                else
                {

                    Util.printText(htmlResponse, false);

                }
            }
            else
            {
                doNotice("Could not print financial transaction!", 2);
            }


        }

        private void btnRefreshMessage_Click(object sender, EventArgs e)
        {

            Util.showWait(true);

            string ret = webService.getSystemNotice("");
            if (ret.Length > 0)
            {
                doNotice(ret, 2);
            }
            else
            {
                doNotice("Message Updated.", 1);
            }

            Util.showWait(false);

        }

        private void btnRefreshAdvert_Click(object sender, EventArgs e)
        {

            //Util.showWait(true);

            //string ret = webService.getNewAdvert();
            //if (ret.Length > 0)
            //{
            //    doNotice(ret, 2);
            //}
            //else
            //{
            //    doNotice("Advert Updated.", 1);
            //}

            //Util.showWait(false);

            doNotice("Advert remains the same for this version.", 1);

        }

        private System.Windows.Forms.WebBrowser wbMessageSystem;

        private void btnRefreshSoftware_Click(object sender, EventArgs e)
        {

            if (Util.getSoftwareUpdate()) {

                btnCheckforUpdate.Hide();
                btnRefreshAdvert.Hide();
                btnRefreshMessage.Hide();
                btnReports.Hide();
                btnFinancial.Hide();
                btnUsers.Hide();
                btnSettings.Hide();
                btnLogout.Hide();

                lblHeadUpdateMx.Visible = false;
                btnCloseAll.Visible = false;

                pnl_main_settings.Left = 0;
                pnl_main_settings.Width = 800;

                Application.DoEvents();

                try
                {
                    this.wbMessageSystem = new System.Windows.Forms.WebBrowser();
                    this.wbMessageSystem.Parent = pnlUpdateManagement;
                    this.wbMessageSystem.Bounds = new Rectangle(0, 38, 800, 442);
                    this.wbMessageSystem.Url = new Uri("file://c://topitup/html/noContent.htm");
                    this.wbMessageSystem.BringToFront();
                    this.wbMessageSystem.Show();
                }
                catch (Exception err)
                {
                    doNotice(err.Message, 2);
                    return;
                }

                updates_available();

            } else {

                doNotice("No Update Available.", 1);

            }






        }



        private void updates_available()
        {

            try
            {
                this.wbMessageSystem.Url = new Uri("file://c:/topitup/html/softwareUpdate.htm");
            }
            catch
            {
                //
            }

            doNotice("Downloading Update...(" + globalSettings.app_ver + " -> " + globalSettings.app_update_ver + ")", 1);

            Application.DoEvents();

            Thread t = new Thread(new ThreadStart(conUpdateSoftwareThread));
            t.Start();

        }

        private void conUpdateSoftwareThread()
        {

            //Web WebResponse = new Web(440000);
            //bool dl_ok = WebResponse.GetURLSoftwareUpdate(globalSettings.app_update_location, globalSettings.app_path + @"\update\new.zip");
            //WebResponse = null;

            //if (dl_ok)
            //{

            //    try
            //    {
            //        string filename = globalSettings.app_path + @"\pos.old";
            //        if (File.Exists(filename) == true) { File.Delete(filename); }

            //        if (File.Exists(Path.Combine(globalSettings.app_path, "pos.exe")) == true)
            //        {
            //            System.IO.File.Move(Path.Combine(globalSettings.app_path, "pos.exe"), Path.Combine(globalSettings.app_path, "pos.old"));
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        doNotice(ex.Message, 2);
            //    }

            //    string zipToUnpack = globalSettings.app_path + @"\update\new.zip";
            //    string unpackDirectory = globalSettings.app_path + @"\";

            //    try
            //    {
            //        using (Ionic.Zip.ZipFile zip1 = Ionic.Zip.ZipFile.Read(zipToUnpack))
            //        {
            //            foreach (Ionic.Zip.ZipEntry e in zip1)
            //            {
            //                e.Extract(unpackDirectory, Ionic.Zip.ExtractExistingFileAction.OverwriteSilently);
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        try
            //        {
            //            if (File.Exists(Path.Combine(globalSettings.app_path, "pos.exe")) == false)
            //            {
            //                if (File.Exists(Path.Combine(globalSettings.app_path, "pos.old")) == true)
            //                {
            //                    System.IO.File.Move(Path.Combine(globalSettings.app_path, "pos.old"), Path.Combine(globalSettings.app_path, "pos.exe"));
            //                }
            //            }
            //        }
            //        catch
            //        {
            //            //
            //        }

            //        doNotice(ex.Message, 2);
            //    }

            //    try
            //    {
            //        string filename = globalSettings.app_path + @"\update\new.zip";
            //        if (File.Exists(filename) == true) { File.Delete(filename); }
            //    }
            //    catch (Exception ex)
            //    {
            //        doNotice(ex.Message, 2);
            //    }


            //}
            //else
            //{
            //    //
            //}

            //this.Invoke(new EventHandler(software_update_status));

        }

        //private void software_update_status(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        this.wbMessageSystem.Url = new Uri("file://c:/topitup/html/softwareUpdateComplete.htm");
        //    }
        //    catch (Exception err)
        //    {
        //        doNotice(err.Message, 2);
        //        return;
        //    }
        //}

        private void btnCashierOptions_Click(object sender, EventArgs e)
        {

            RestartLogoutTimer();

            chkCashDrawerCashier.Checked = false;
            if (globalSettings.gen_cashdr_cashier == "1") chkCashDrawerCashier.Checked = true;

            chkCashierOwnSales.Checked = false;
            if (globalSettings.gen_cashier_ownsales == "1") chkCashierOwnSales.Checked = true;

            chkCashierW.Checked = false;
            if (globalSettings.gen_cashier_w == "1") chkCashierW.Checked = true;

            chkCashierY.Checked = false;
            if (globalSettings.gen_cashier_y == "1") chkCashierY.Checked = true;

            chkCashierAllSalesY.Checked = false;
            if (globalSettings.gen_cashier_y_all == "1") chkCashierAllSalesY.Checked = true;

            chkCashierYHistory.Checked = false;
            if (globalSettings.gen_cashier_y_history == "1") chkCashierYHistory.Checked = true;

            chkCashierElectricityDisabled.Checked = false;
            if (globalSettings.gen_cashier_elec_disabled == "1") chkCashierElectricityDisabled.Checked = true;

            chkCashierBillDisabled.Checked = false;
            if (globalSettings.gen_cashier_bill_disabled == "1") chkCashierBillDisabled.Checked = true;

            chkDisableSalesHistory.Checked = false;
            if (globalSettings.gen_cashier_salehistory_disabled == "1") chkDisableSalesHistory.Checked = true;

            chkCashierReprint.Checked = false;
            if (globalSettings.gen_cashier_allowreprint == "1") chkCashierReprint.Checked = true;
            chkCashierReprintLast.Checked = false;
            if (globalSettings.gen_cashier_allowreprintlast == "1") chkCashierReprintLast.Checked = true;

            chkBillConvenienceCashier.Checked = false;
            if (globalSettings.gen_cashier_billconvenience_cashier == "1") chkBillConvenienceCashier.Checked = true;

            chkBillConvenienceAdmin.Checked = false;
            if (globalSettings.gen_cashier_billconvenience_admin == "1") chkBillConvenienceAdmin.Checked = true;

            if (globalSettings.gen_cashier_allowreprintlast_admin == "1")
            {
                chkCashierReprintLastAdmin.Checked = true;
            }
            else
            {
                chkCashierReprintLast.Checked = false;
                chkCashierReprintLast.Enabled = false;
                globalSettings.gen_cashier_allowreprintlast = "0";
            }

            if (globalSettings.gen_cashdr == "0")
            {
                chkCashDrawerCashier.Checked = false;
                chkCashDrawerCashier.Visible = false;
            }

            chkCashierRestart.Checked = false;
            if (globalSettings.gen_cashier_restart == "1") chkCashierRestart.Checked = true;

            enablePanel(pnlCashierOptions, "users_3_5");

        }

        private void btnRptDaily_Click(object sender, EventArgs e)
        {
            dtSalesReport.Format = DateTimePickerFormat.Custom;
            dtSalesReport.CustomFormat = "yyyy-MM";
            dtSalesReport.ShowUpDown = true;
            reportType = "Monthly";
            pnlReport.Show();
            pnlReport.BringToFront();
            /*
            RestartLogoutTimer();

            string htmlResponse = "";

            Web WebResponse = new Web(35000);
            htmlResponse = WebResponse.GetURL("/terminal/reports/get-last-seven-days");
            WebResponse = null;

            if (htmlResponse.IndexOf("err>") > -1)
            {
                doNotice(htmlResponse.StripErrorTags(), 2);
            }
            else
            {

                Util.printText(htmlResponse, false);

                //int printSize = 0;
                //string[] toPrintX = new string[1];
                //if (htmlResponse != "")
                //{

                //    string[] toPrint = htmlResponse.Split("\n".ToCharArray());

                //    WintecIDT700.FeedPaper(200);

                //    foreach (string s in toPrint)
                //    {

                //        if (s.Length < 2)
                //        {
                //            toPrintX[0] = "";
                //            Util.Print(toPrintX, 1);
                //        }
                //        else
                //        {
                //            printSize = 1;
                //            try
                //            {
                //                printSize = int.Parse(s[0].ToString());
                //            }
                //            catch { }
                //            toPrintX[0] = s.Remove(0, 1);
                //            Util.Print(toPrintX, printSize);
                //        }
                //    }

                //    WintecIDT700.FeedPaper(200);
                //}

                doNotice("Report complete.", 1);

            }
            */

        }

        private void btnRptYesterday_Click(object sender, EventArgs e)
        {
            dtSalesReport.Format = DateTimePickerFormat.Custom;
            dtSalesReport.CustomFormat = "yyyy-MM-dd";
            dtSalesReport.ShowUpDown = true;
            reportType = "Daily";
            pnlReport.Show();
            pnlReport.BringToFront();
            /*   RestartLogoutTimer();

               string htmlResponse = "";

               Web WebResponse = new Web(35000);
               htmlResponse = WebResponse.GetURL("/terminal/reports/get-yesterdays-sales");
               WebResponse = null;

               if (htmlResponse.IndexOf("err>") > -1)
               {
                   doNotice(htmlResponse.StripErrorTags(), 2);
               }
               else
               {

                   Util.printText(htmlResponse, false);

                   //int printSize = 0;
                   //string[] toPrintX = new string[1];
                   //if (htmlResponse != "")
                   //{

                   //    string[] toPrint = htmlResponse.Split("\n".ToCharArray());

                   //    WintecIDT700.FeedPaper(200);

                   //    foreach (string s in toPrint)
                   //    {

                   //        if (s.Length < 2)
                   //        {
                   //            toPrintX[0] = "";
                   //            Util.Print(toPrintX, 1);
                   //        }
                   //        else
                   //        {
                   //            printSize = 1;
                   //            try
                   //            {
                   //                printSize = int.Parse(s[0].ToString());
                   //            }
                   //            catch { }
                   //            toPrintX[0] = s.Remove(0, 1);
                   //            Util.Print(toPrintX, printSize);
                   //        }
                   //    }

                   //    WintecIDT700.FeedPaper(200);
                   //}

                   doNotice("Report complete.", 1);

               }
               */
        }
        private void saleConfirm()
        {


            pnlReport.Hide();
            pnlReport.SendToBack();

            RestartLogoutTimer();
            //String q = "202010";
            String q = (dtSalesReport.Text).Replace("-", "");
            // MessageBox.Show(q);
            string htmlResponse = "";

            Web WebResponse = new Web(35000);
            // htmlResponse = WebResponse.GetURL("/terminal/reports/get-last-seven-days");
            if (reportType.Equals("Daily"))
                htmlResponse = WebResponse.GetURL("/terminal/reports/get-sales-by-day?q=" + q);
            else if (reportType.Equals("Monthly"))
                htmlResponse = WebResponse.GetURL("/terminal/reports/get-sales-by-month?q=" + q);
            else if (reportType.Equals("Monthly Deposit"))
                htmlResponse = WebResponse.GetURL("/terminal/reports/get-monthly-deposit-statement?q=" + q);
            else if (reportType.Equals("Monthly Commission"))
                htmlResponse = WebResponse.GetURL("/terminal/reports/get-monthly-commission-statement?q=" + q);

            WebResponse = null;

            if (htmlResponse.IndexOf("err>") > -1)
            {
                doNotice(htmlResponse.StripErrorTags(), 2);
            }
            else
            {
                Util.printText(htmlResponse, false);
                /*int printSize = 0;
                string[] toPrintX = new string[1];
                if (htmlResponse != "")
                {

                    string[] toPrint = htmlResponse.Split("\n".ToCharArray());

                    WintecIDT700.FeedPaper(200);

                    foreach (string s in toPrint)
                    {

                        if (s.Length < 2)
                        {
                            toPrintX[0] = "";
                            Util.Print(toPrintX, 1);
                        }
                        else
                        {
                            printSize = 1;
                            try
                            {
                                printSize = int.Parse(s[0].ToString());
                            }
                            catch { }
                            toPrintX[0] = s.Remove(0, 1);
                            Util.Print(toPrintX, printSize);
                        }
                    }

                    WintecIDT700.FeedPaper(200);
                }*/
                // pnlReport.Hide();
                // pnlReport.SendToBack();
                doNotice("Report complete.", 1);



            }

        }


        private void txtIDNumber_TextChanged(object sender, EventArgs e)
        {
            ricaPosUserUpdate();
            checkIDNumber();
        }

        private void selIDType1_CheckedChanged(object sender, EventArgs e)
        {
            if (selIDType1.Checked)
            {
                txtIDNumber.MaxLength = 13;
                txtIDNumber.Text = txtIDNumber.Text.Left(13);
            }
            ricaPosUserUpdate();
            checkIDNumber();
        }


        private void checkIDNumber()
        {
            lblIDNotValid.Visible = false;
            if (selIDType1.Checked)
            {

                if (!Util.checkIDNumber(txtIDNumber.Text)) lblIDNotValid.Visible = true;
            }
        }

        Boolean loading_pos_user = false;
        private void ricaPosUserUpdate()
        {

            if (loading_pos_user) return;

            if (btnRicaRegister.Visible)
            {
                lblRicaChangeNotice.Show();
                btnRicaRegister.Hide();
            }

        }


        //private Control FindControl(Control parent, string ctlName)
        //{
        //    foreach (Control ctl in parent.Controls)
        //    {
        //        if (ctl.Name.Equals(ctlName))
        //        {
        //            return ctl;
        //        }
        //    }
        //    return null;
        //}



        private void btnReqExtendedCredit_Click(object sender, EventArgs e)
        {

            tmr_logout.Enabled = false;

            //Util.SetCursor(Screen.PrimaryScreen.Bounds.Width, 0);

            picRandBgExt.Image = new Bitmap(globalSettings.app_path + @"\images\elec_rand.gif");

            ext_credit_amount = 0.0d;
            txtRandValueExt.Text = "";
            //txtRandValueExt.AllowDecimal = true;
            txtRandValueExt.MaxLength = 5;

            txtReqExtendedCrOtp.Text = "";
            chkReqExtendedCr.Checked = false;

            btnReqExtendedCreditProcess.Visible = false;
            lblotp.Visible = false;
            txtReqExtendedCrOtp.Visible = false;
            chkReqExtendedCr.Visible = false;

            globalSettings.credit_req_is_allowed = false;
            globalSettings.credit_req_data = "";
            globalSettings.credit_req_otp = "x";

            //Control ctl = FindControl(this.pnlReqExtendedCredit, "wbExtendedCredit");
            //if (ctl != null)
            //{
            try
            {

                if (!wbExtendedCreditShown)
                {
                    //this.wbExtendedCredit = new System.Windows.Forms.WebBrowser();
                    //this.wbExtendedCredit.Parent = this.pnlReqExtendedCredit;
                    //this.wbExtendedCredit.Bounds = new Rectangle(10, 45, 640, 245);
                    //this.wbExtendedCredit.Name = "wbExtendedCredit";
                }

                this.wbExtendedCredit.Url = new Uri("file://c:/topitup/html/busyWait.htm");
                Application.DoEvents();
                this.wbExtendedCredit.Show();

            }
            catch (Exception ex)
            {
                Util.showMessage(ex.Message, Color.Red);
            }

            wbExtendedCreditShown = true;

            //}

            btnPrintBalance.Hide();
            btnTransferPanel.Hide();
            grp_finw1.Hide();
            lblPleaseRefreshBalance.Show();

            pnlExtCreditAmount.Hide();
            btnReqExtendedCredit.Hide();

            enablePanel(pnlReqExtendedCredit, "");

            start_delayed_load("request_credit_status", 3000);

        }

        private void tmr_delayed_load_Tick(object sender, EventArgs e)
        {

            tmr_delayed_load.Interval = 2000;
            tmr_delayed_load.Enabled = false;

            if (_current_action == "update_service_provider_items")
            {

                Util.showUpdate("Updating Product Catalog...");


                //String err = webService.getStockProviderUpdate(false);
                String err = webService.get_update_all();

                if (err.Length > 0)
                {
                    Util.showMessage(err, Color.Red);
                    lblcurrspiver.Text = "Error Updating Product Catalog.";
                }
                else
                {

                    Boolean changes_made = false;

                    try
                    {


                        Web _wr_update = new Web(45000, 1, "");
                        String htmlResponse = _wr_update.GetURL("/terminal/update/get-update-sp");
                        _wr_update = null;

                        if (htmlResponse.IndexOf("err>") > -1 && !htmlResponse.Equals(""))
                        {
                            Util.showMessage("Error Updating Layout", Color.Red);
                        }
                        else
                        {

                            Util.showMessage("Updating Layout...(" + globalSettings.sp_ver + " -> " + globalSettings.sp_ver_latest + ")", Color.Green);

                            string filename = globalSettings.app_path + @"\conf\settings_layout.dat";
                            if (File.Exists(filename) == true) { File.Delete(filename); }
                            TextWriter tw = new StreamWriter(filename, false);
                            tw.Write(htmlResponse);
                            tw.Close();

                            globalSettings.sp_ver = globalSettings.sp_ver_latest;

                            changes_made = true;

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }


                    try
                    {
                        lblcurrspiver.Text = String.Format("{0:####-##-##-####}", Convert.ToInt64(globalSettings.spi_ver));
                    }
                    catch
                    {
                        lblcurrspiver.Text = globalSettings.spi_ver;
                    }

                    if (globalSettings.spi_ver.Equals(orig_spi_ver))
                    {
                        //
                    } else {
                        Util.showUpdate("Product Catalog Updated.");
                        changes_made = true;
                    }


                    if (changes_made)
                    {
                        globalSettings.SaveSPI();
                        lblPleaseReboot.Show();
                    } else
                    {
                        Util.showUpdate("Product Catalog Already up to date, no changes made.");
                    }

                    Util.loadProviderItem();

                }

                btnUpdateSPI.Enabled = true;

                Util.showWait(false);

            }


            if (_current_action == "request_license_desc")
            {

                string htmlResponse = "";
                try
                {
                    Web WebResponse = new Web(10000, 1, "");
                    htmlResponse = WebResponse.GetURL("/terminal/general/get-terminal-desc");
                    WebResponse = null;

                    if (htmlResponse != "")
                    {
                        if (htmlResponse.IndexOf("err>") == -1)
                        {
                            lblTermName.Text = "Terminal Name";
                            lblTermName.ForeColor = Color.Black;
                            txtTerminalName.Enabled = true;
                            txtTerminalName.Text = htmlResponse.Trim();

                        }
                        else
                        {
                            doNotice("Error getting terminal description.", 2);
                            lblTermName.Text = "Terminal Name (No Connection)";
                            lblTermName.ForeColor = Color.Firebrick;
                        }
                    }
                }
                catch
                {
                    lblTermName.Text = "Terminal Name (Error)";
                    lblTermName.ForeColor = Color.Firebrick;
                    doNotice("Error getting terminal description.", 2);
                }

                OriginalLicenseDesc = txtTerminalName.Text;

                Util.showWait(false);

            }

            if (_current_action == "customer_accept")
            {

                string htmlResponse = "";
                try
                {

                    Web WebResponse = new Web(35000);
                    htmlResponse = WebResponse.GetURL("/terminal/general/retailer-accept-terms");
                    WebResponse = null;

                    if (htmlResponse.ToLower().Equals("ok"))
                    {
                        //pnl_customer_accept.Visible = false;
                        RestartLogoutTimer();

                        globalSettings.customer_accept = "1";
                        globalSettings.Save();

                        Util.showMessage("Thank you! Welcome to Top it Up.", Color.Green);
                        btn_customer_accept.Visible = false;
                        label45.ForeColor = Color.Firebrick;
                        label45.Text = "Thank you for accepting, the application will now restart.";

                        Application.DoEvents();

                        globalSettings.app_restart = true;
                        Thread.Sleep(1000);
                        Close();

                    }
                    else
                    {
                        Util.showMessage(htmlResponse.StripErrorTags(), Color.Red);
                        btn_customer_accept.Text = "Accept";
                        btn_customer_accept.Enabled = true;
                    }

                }
                catch (Exception ex)
                {
                    Util.showMessage(ex.Message, Color.Red);
                }

                Util.showWait(false);

            }


            if (_current_action == "populate_z_history")
            {

                cmbLinkedLicenses.Items.Clear();
                PopulateZReportGrid("0");

                try
                {

                    String htmlResponse = "";
                    Web WebResponse = new Web(20000, 1, "");
                    htmlResponse = WebResponse.GetURL("/terminal/general/get-license-list");
                    WebResponse = null;
                    if (htmlResponse != "")
                    {
                        if (htmlResponse.IndexOf("err>") > -1)
                        {
                            //
                        }
                        else
                        {

                            //Util.printText(htmlResponse, false);

                            string[] lineItem = htmlResponse.Split("\n".ToCharArray());
                            int currentIndex = -1;
                            foreach (string items in lineItem)
                            {
                                currentIndex++;
                                string[] stritem = items.Split('^');

                                String item_text = "";
                                if (stritem[1] == globalSettings.license_code)
                                {
                                    item_text = stritem[2].Replace("(enabled)", " - Current");
                                }
                                else
                                {
                                    item_text = stritem[2];
                                }

                                ComboboxItem item = new ComboboxItem(item_text, stritem[0]);
                                cmbLinkedLicenses.Items.Add(item);
                                if (stritem[1] == globalSettings.license_code)
                                {
                                    cmbLinkedLicenses.SelectedIndex = currentIndex;
                                }

                            }
                        }
                    }

                }
                catch
                {
                    //updateAvailable = false;
                }

                _loading_z_report = false;
                Util.showWait(false);

            }

            if (_current_action == "rica_register_agent")
            {

                string htmlResponse = "";
                try
                {

                    Web WebResponse = new Web(75000);
                    htmlResponse = WebResponse.GetURL("/rica/general/register-agent?pid=" + intSelectedPOSUserID.ToString());
                    WebResponse = null;

                    lblRicaInfo.Text = "";

                    if (htmlResponse.IndexOf("err>") > -1)
                    {
                        Util.showMessage("There was a problem trying to RICA this agent, please try later.", Color.Red);
                    }
                    else if (htmlResponse != "")
                    {

                        Newtonsoft.Json.Linq.JObject json = Newtonsoft.Json.Linq.JObject.Parse(htmlResponse);

                        if (!String.IsNullOrEmpty((string)json["err"]))
                        {
                            Util.showMessage((string)json["err"], Color.Red);
                        }
                        else
                        {

                            String error_id = "";
                            if (!String.IsNullOrEmpty((string)json["error_id"])) error_id = (string)json["error_id"];

                            String rica_msg = "";
                            if (!String.IsNullOrEmpty((string)json["msg"])) rica_msg = (string)json["msg"];

                            if (error_id == "0")
                            {
                                lblRicaInfo.Text = "Rica Registered: Yes";
                                lblRicaInfo.ForeColor = Color.Green;
                                lblRicaInfo.Visible = true;
                                Util.showMessage("User registed as a RICA agent.", Color.Red);
                            }
                            else
                            {
                                lblRicaInfo.Text = "Error: " + rica_msg;
                                lblRicaInfo.ForeColor = Color.Red;
                                lblRicaInfo.Visible = true;
                                Util.showMessage("There was a problem registering RICA agent.", Color.Red);
                            }

                        }
                    }
                    else
                    {
                        Util.showMessage("There was a problem trying to RICA this agent, please try later.", Color.Red);
                    }

                }
                catch (Exception ex)
                {
                    Util.showMessage(ex.Message, Color.Red);
                }

                Util.showWait(false);

            }



            if (_current_action == "request_credit_status")
            {
                string ret = webService.getCreditRequestStatus();
                if (ret.Length > 0)
                {
                    this.wbExtendedCredit.Url = new Uri("file://c:/topitup/html/noContent.htm");
                    doNotice(ret, 2);
                }
                else
                {

                    try
                    {
                        if (!String.IsNullOrEmpty(globalSettings.credit_req_data))
                        {
                            byte[] data = Convert.FromBase64String(globalSettings.credit_req_data);

                            this.wbExtendedCredit.Navigate("about:blank");
                            this.wbExtendedCredit.Document.OpenNew(false);
                            this.wbExtendedCredit.Document.Write(System.Text.Encoding.UTF8.GetString(data, 0, data.Length));
                            this.wbExtendedCredit.Refresh();

                            //this.wbExtendedCredit.DocumentText = System.Text.Encoding.UTF8.GetString(data, 0, data.Length);
                        }
                    }
                    catch
                    {
                        //
                    }

                    if (globalSettings.credit_req_is_allowed)
                    {
                        pnlExtCreditAmount.Show();
                        txtRandValueExt.Focus();
                    }

                }

                Util.showWait(false);

            }


            if (_current_action == "request_credit_amount")
            {

                globalSettings.credit_req_high = false;

                string ret = webService.getCreditRequest(ext_credit_amount);
                if (ret.Length > 0)
                {
                    this.wbExtendedCredit.Url = new Uri("file://c:/topitup/html/noContent.htm");
                    doNotice(ret, 2);
                }
                else
                {

                    try
                    {
                        if (!String.IsNullOrEmpty(globalSettings.credit_req_data))
                        {
                            byte[] data = Convert.FromBase64String(globalSettings.credit_req_data);

                            this.wbExtendedCredit.Navigate("about:blank");
                            this.wbExtendedCredit.Document.OpenNew(false);
                            this.wbExtendedCredit.Document.Write(System.Text.Encoding.UTF8.GetString(data, 0, data.Length));
                            this.wbExtendedCredit.Refresh();


                            //this.wbExtendedCredit.DocumentText = System.Text.Encoding.UTF8.GetString(data, 0, data.Length);
                        }
                    }
                    catch
                    {
                        //
                    }

                    if (globalSettings.credit_req_high)
                    {
                        pnlExtCreditAmount.Show();
                    }
                    else if (globalSettings.credit_req_is_allowed)
                    {
                        btnReqExtendedCreditProcess.Visible = true;
                        lblotp.Visible = true;
                        chkReqExtendedCr.Visible = true;
                        txtReqExtendedCrOtp.Visible = true;
                        txtReqExtendedCrOtp.Focus();
                    }

                }

                Util.showWait(false);

            }


            if (_current_action == "request_credit_process")
            {

                string htmlResponse = "";
                try
                {

                    Web WebResponse = new Web(45000);
                    htmlResponse = WebResponse.GetURL("/terminal/financial/credit-request-process?amt=" + ext_credit_amount.ToString());
                    WebResponse = null;

                    if (htmlResponse != "")
                    {

                        Newtonsoft.Json.Linq.JObject json = Newtonsoft.Json.Linq.JObject.Parse(htmlResponse);

                        if (!String.IsNullOrEmpty((string)json["err"]))
                        {
                            this.wbExtendedCredit.DocumentText = (string)json["err"];
                        }
                        else
                        {

                            String cr_data = "";
                            if (!String.IsNullOrEmpty((string)json["cr_data"])) cr_data = (string)json["cr_data"];

                            byte[] data = Convert.FromBase64String(cr_data);

                            this.wbExtendedCredit.Navigate("about:blank");
                            this.wbExtendedCredit.Document.OpenNew(false);
                            this.wbExtendedCredit.Document.Write(System.Text.Encoding.UTF8.GetString(data, 0, data.Length));
                            this.wbExtendedCredit.Refresh();


                            //this.wbExtendedCredit.DocumentText = System.Text.Encoding.UTF8.GetString(data, 0, data.Length);

                        }
                    }
                    else
                    {
                        Util.showMessage("The server has not responded in time, please check your financial balance.", Color.Red);
                    }

                }
                catch (Exception ex)
                {
                    Util.showMessage(ex.Message, Color.Red);
                }

                Util.showWait(false);

            }

            if (_current_action == "system_electra_max")
            {
                String htmlResponse = "";
                try
                {

                    Web WebResponse = new Web(4000);
                    htmlResponse = WebResponse.GetURL("/terminal/customer/get-electra-max");
                    WebResponse = null;

                    if (htmlResponse.IndexOf("err>") > -1)
                    {
                        //
                    }
                    else if (htmlResponse.Length > 0)
                    {
                        JObject json = JObject.Parse(htmlResponse);
                        if (!String.IsNullOrEmpty((string)json["system_electra_max"])) lbl_system_electra_max.Text = (string)json["system_electra_max"];
                    }
                }
                catch
                {
                    //
                }

                Util.showWait(false);

            }

            if (_current_action == "get_automated_z")
            {

                Util.showWait(true);

                String htmlResponse = "";

                Web WebResponse = new Web(25000, 1, "");
                htmlResponse = WebResponse.GetURL("/terminal/cashup/z-report-auto");
                WebResponse = null;

                if (htmlResponse.IndexOf("err>") > -1)
                {
                    doNotice(htmlResponse.StripErrorTags(), 2);
                }
                else if (!htmlResponse.Equals(""))
                {
                    try
                    {
                        string[] lines = htmlResponse.Split('\n');

                        for (int i = 0; i < lines.Length - 1; i++)
                        {

                            if (i == 0)
                            {
                                lblLastZDetail.Text = lines[i].Trim();
                            }
                            else
                            {
                                string[] items = lines[i].Split('^');
                                grdZReportsAuto.Rows.Add();
                                grdZReportsAuto.Rows[i - 1].Tag = items[0];
                                grdZReportsAuto.Rows[i - 1].Cells[0].Value = items[1];
                                grdZReportsAuto.Rows[i - 1].Cells[1].Value = items[2];

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Util.showMessage(ex.Message, Color.Red);
                    }
                }

                Util.showWait(false);

            }

            _current_action = "";

        }


        double ext_credit_amount = 0.0d;
        private void btnExtValueRequest_Click(object sender, EventArgs e)
        {

            globalSettings.credit_req_is_allowed = false;

            if (txtRandValueExt.Text.Length == 0)
            {
                Util.showMessage("Please check your Request Amount!", Color.Red);
                txtRandValueExt.Focus();
                return;
            }

            try
            {
                ext_credit_amount = Convert.ToDouble(txtRandValueExt.Text);
            }
            catch
            {
                ext_credit_amount = 0.0d;
                Util.showMessage("Please check your Request Amount!", Color.Red);
                txtRandValueExt.Focus();
                return;
            }

            pnlExtCreditAmount.Visible = false;
            this.wbExtendedCredit.Url = new Uri("file://c:/topitup/html/busyWait.htm");

            start_delayed_load("request_credit_amount", 2000);

        }


        private void btnReqExtendedCreditProcess_Click(object sender, EventArgs e)
        {


            if (txtReqExtendedCrOtp.Text.Length < 4)
            {
                Util.showMessage("Please check your OTP!", Color.Red);
                txtReqExtendedCrOtp.Focus();
                return;
            }

            if (!chkReqExtendedCr.Checked)
            {
                Util.showMessage("Please accept the terms and conditions.", Color.Red);
                return;
            }

            if (!txtReqExtendedCrOtp.Text.Trim().Equals(globalSettings.credit_req_otp))
            {
                Util.showMessage("OTP is incorrect!", Color.Red);
                txtReqExtendedCrOtp.Focus();
                return;
            }

            btnReqExtendedCreditProcess.Visible = false;
            lblotp.Visible = false;
            txtReqExtendedCrOtp.Visible = false;
            chkReqExtendedCr.Visible = false;

            this.wbExtendedCredit.Url = new Uri("file://c:/topitup/html/busyWait.htm");

            start_delayed_load("request_credit_process", 2000);


        }




        private void btnAutomatedZShow_Click(object sender, EventArgs e)
        {

            RestartLogoutTimer();

            Util.showWait(true);

            grdZReportsAuto.Rows.Clear();

            enablePanel(pnlAutomatedZreports, "");

            start_delayed_load("get_automated_z", 500);

        }



        private void btnWalletXfer_Click(object sender, EventArgs e)
        {

            btnWalletXfer.Enabled = false;

            if (txtRandValue.Text.Trim() == "" || txtRandValue.Text.Equals("0.00"))
            {
                doNotice("Incorrect Amount!", 2);
                btnWalletXfer.Enabled = true;
                txtRandValue.Focus();
                return;
            }

            Decimal amount = 0.0m;
            Decimal balance_cash = 0.0m;

            String str_amount = System.Text.RegularExpressions.Regex.Replace(txtRandValue.Text.Trim(), @"[^A-Za-z0-9.]+", "");
            String str_amount2 = System.Text.RegularExpressions.Regex.Replace(finBalance.balance_cash, @"[^A-Za-z0-9.]+", "");

            try
            {
                amount = Decimal.Parse(str_amount, System.Globalization.CultureInfo.InvariantCulture);
                balance_cash = Decimal.Parse(str_amount2, System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                doNotice("Problem with Amount!", 2);
                btnWalletXfer.Enabled = true;
                txtRandValue.Focus();
                return;
            }

            if (amount > balance_cash)
            {
                doNotice("Incorrect Amount!", 2);
                btnWalletXfer.Enabled = true;
                txtRandValue.Focus();
                return;
            }

            if (btnWalletXfer.Text == "Transfer" + Environment.NewLine + "Funds")
            {
                btnWalletXfer.Text = "Confirm";
                btnWalletXfer.Enabled = true;
                txtRandValue.Enabled = false;
                lblConfirmTransfer.Show();
                return;
            }

            string htmlResponse = "";

            try
            {

                Web WebResponse = new Web(10000, 1, "");
                htmlResponse = WebResponse.GetURL("/terminal/financial/wallet-transfer?w=1&amt=" + amount.ToString());
                WebResponse = null;

                if (htmlResponse.IndexOf("err", 0) >= 0)
                {
                    btnWalletXfer.Text = "Transfer" + Environment.NewLine + "Funds";
                    lblConfirmTransfer.Hide();
                    doNotice("There was an error while making the transfer!", 2);
                    btnWalletXfer.Enabled = true;
                    txtRandValue.Focus();
                    return;
                }
                else if (htmlResponse.IndexOf("ok", 0) >= 0)
                {
                    lblFundTransferComplete.Show();
                    grpWalletXfer.Hide();
                    btnWalletXfer.Hide();
                    lblConfirmTransfer.Hide();
                }

            }
            catch (Exception ex)
            {
                doNotice(ex.Message, 2);
                btnWalletXfer.Enabled = true;
                txtRandValue.Focus();
                return;
            }


        }

        private void btnAutomatedZDelete_Click(object sender, EventArgs e)
        {

            int _automated_z_id = 0;
            btnAutomatedZDelete.Enabled = false;

            try
            {
                DataGridViewRow row = grdZReportsAuto.Rows[grdZReportsAuto.CurrentCell.RowIndex];
                _automated_z_id = Convert.ToInt32(row.Tag);
            }
            catch
            {
                _automated_z_id = 0;
            }

            if (_automated_z_id > 0)
            {

                try
                {
                    String ret = webService.deleteAutomatedZ(_automated_z_id.ToString());
                    if (ret == "")
                    {
                        doNotice("Automated Z Report successfully deleted.", 1);
                    }
                    else
                    {
                        doNotice(ret, 2);
                    }

                    grdZReportsAuto.Rows.Clear();
                    start_delayed_load("get_automated_z", 500);

                }
                catch (Exception ex) {
                    Util.showMessage(ex.Message, Color.Red);
                }


            }
            else
            {
                Util.showMessage("Please select a Z report to delete.", Color.Red);
            }

            btnAutomatedZDelete.Enabled = true;

        }

        private void btnAutomatedZAdd_Click(object sender, EventArgs e)
        {


            try
            {
                String ret = webService.addAutomatedZ(cboAutomatedZTime.Text);
                if (ret == "")
                {
                    doNotice("Automated Z Report successfully added.", 1);
                }
                else
                {
                    doNotice(ret, 2);
                }

                grdZReportsAuto.Rows.Clear();
                start_delayed_load("get_automated_z", 500);

            }
            catch (Exception ex)
            {
                Util.showMessage(ex.Message, Color.Red);
            }


        }


        private void btnRicaRegister_Click(object sender, EventArgs e)
        {

            if (intSelectedPOSUserID == 0)
            {
                doNotice("Cannot RICA this User, please close and try again.", 2);
                return;
            }

            btnRicaRegister.Enabled = false;

            lblRicaInfo.Text = "Registering Agent, please wait...";
            lblRicaInfo.ForeColor = Color.FromArgb(0, 137, 181);

            start_delayed_load("rica_register_agent", 1000);

        }

        private Boolean check_for_accept()
        {
            if (globalSettings.customer_accept == "0")
            {
                tmr_logout.Enabled = false;
                doNotice("Please accept to continue using this terminal.", 1);
                pnl_customer_accept.BringToFront();
                pnl_customer_accept.Visible = true;
                return false;
            }
            return true;

        }

        private void btn_customer_accept_Click(object sender, EventArgs e)
        {

            btn_customer_accept.Enabled = false;
            btn_customer_accept.Text = "Busy...";

            start_delayed_load("customer_accept", 1000);

        }



        String orig_spi_ver = "";
        private void btnUpdateSPI_Click(object sender, EventArgs e)
        {

            Util.showWait(true);

            btnUpdateSPI.Enabled = false;
            lblcurrspiver.Text = "Updating...";

            orig_spi_ver = globalSettings.spi_ver;

            start_delayed_load("update_service_provider_items", 500);


        }

        private void chkElectraMaxWarning_CheckStateChanged(object sender, EventArgs e)
        {

            if (chkElectraMaxWarning.Checked)
            {
                txt_elec_max_warning.Enabled = true;
            }
            else
            {
                txt_elec_max_warning.Enabled = false;
            }

        }

        private void btnRefreshUsers_Click(object sender, EventArgs e)
        {

            Util.showWait(true);

            string htmlresponse = webService.getPosUsers();
            if (htmlresponse.Length == 0)
            {
                Util.loadPosUsers();
                doNotice("Updated list of users.", 1);
            }
            else
            {
                doNotice(htmlresponse, 2);
            }

            Util.showWait(false);

        }

        private void btnGeneralSettings_Click(object sender, EventArgs e)
        {

            RestartLogoutTimer();

            if (globalSettings.gen_show_balance_login == "1") chkLowBalance.Checked = true;
            if (globalSettings.gen_logout == "1") chkLogout.Checked = true;

            chk_show_financials.Checked = false;
            if (globalSettings.gen_show_financials == "1") chk_show_financials.Checked = true;

            chk_show_financials_cashier.Checked = false;
            if (globalSettings.gen_show_financials_cashier == "1") chk_show_financials_cashier.Checked = true;

            chk_show_last_sale.Checked = false;
            if (globalSettings.gen_show_last_sale_login == "1") chk_show_last_sale.Checked = true;

            chkSound.Checked = false;
            if (globalSettings.gen_sound == "1") chkSound.Checked = true;

            chkMultiVoucher.Checked = false;
            if (globalSettings.gen_show_multi_voucher == "1") chkMultiVoucher.Checked = true;

            if (!chk_show_financials.Checked)
            {
                chk_show_financials_cashier.Checked = false;
                chk_show_financials_cashier.Enabled = false;
            }

            chk_keyboard.Checked = false;
            if (globalSettings.gen_virtual_keyboard == "1") chk_keyboard.Checked = true;


            txtTerminalName.Text = "Fetching from server...";
            txtTerminalName.Enabled = false;

            enablePanel(pnlGeneralSettings, "general_4_1");

            start_delayed_load("request_license_desc", 500);

        }

        private void selIDType2_CheckedChanged(object sender, EventArgs e)
        {
            if (selIDType2.Checked)
            {
                txtIDNumber.MaxLength = 25;
                txtIDNumber.Text = txtIDNumber.Text.Left(25);
            }
            checkIDNumber();
        }

        private void btnCheckforUpdate_Click(object sender, EventArgs e)
        {

            frmAppUpdate frmAppUpdate = new frmAppUpdate();
            frmAppUpdate.ShowDialog(this);

            if (globalSettings.app_restart)
            {
                Close();
            }

        }




        private void chk_show_financials_CheckedChanged(object sender, EventArgs e)
        {

            if (!chk_show_financials.Checked)
            {
                chk_show_financials_cashier.Enabled = false;
                chk_show_financials_cashier.Checked = false;
            }
            else
            {
                chk_show_financials_cashier.Enabled = true;
            }


        }

        private void pnlFooter_Paint(object sender, PaintEventArgs e)
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


        private void txtPOSUserName_Leave(object sender, EventArgs e)
        {

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            txtPOSUserName.Text = textInfo.ToTitleCase(txtPOSUserName.Text);
        }

        private void txtPOSUserLastname_Leave(object sender, EventArgs e)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            txtPOSUserLastname.Text = textInfo.ToTitleCase(txtPOSUserLastname.Text);
        }

        private void lnkLoadPrinterSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            try
            {
                var Process = new System.Diagnostics.Process();
                var ProcessStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/C control printers");
                ProcessStartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                Process.StartInfo = ProcessStartInfo;
                Process.Start();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private void chkCashierReprintLastAdmin_CheckedChanged(object sender, EventArgs e)
        {

            if (!chkCashierReprintLastAdmin.Checked)
            {
                chkCashierReprintLast.Checked = false;
                chkCashierReprintLast.Enabled = false;
            }
            else
            {
                chkCashierReprintLast.Enabled = true;
            }


        }

        private void btnLoginTeamViewer_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(globalSettings.gen_teamviewer_location);
            }
            catch (Exception ex)
            {
                Util.showMessage(ex.Message, Color.Red);
            }
        }



        private void txtDepositAmount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtRandValueExt_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnSkype_Click(object sender, EventArgs e)
        {

            try
            {
                System.Diagnostics.Process.Start(Util.skype_path);
            }
            catch (Exception ex)
            {
                Util.showMessage(ex.Message, Color.Red);
            }

        }



        private void chkSlipPrinter_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSlipPrinter.Checked)
            {
                chkCashDrawer.Enabled = true;
            }
            else
            {
                chkCashDrawer.Checked = false;
                chkCashDrawer.Enabled = false;
            }
        }











        private void btnSaveGlobal_Click(object sender, EventArgs e)
        {

            tmr_logout.Enabled = false;
            btnSaveGlobal.Enabled = false;
            btnCloseAll.Enabled = false;

            Util.showWait(true);

            if (_current_action_save.Equals("general_4_1")) save_general(1);
            if (_current_action_save.Equals("general_4_2")) save_general(2);
            if (_current_action_save.Equals("general_4_3")) save_general(3);
            if (_current_action_save.Equals("general_4_4")) save_general(4);

            if (_current_action_save.Equals("users_3_1"))
            {
                if (save_users(1))
                {
                    webService.getPosUsers();
                    Util.loadPosUsers();
                    populatePosUserGrid();
                    hideAllPanels();
                }
            }
            if (_current_action_save.Equals("users_3_2"))
            {

                if (save_users(2))
                {
                    webService.getPosUsers();
                    Util.loadPosUsers();
                    populatePosUserGrid();
                }
            }

            if (_current_action_save.Equals("users_3_5")) save_users(5);
            if (_current_action_save.Equals("users_3_6")) save_users(6);
            if (_current_action_save.Equals("users_3_7")) save_users(7);

            btnCloseAll.Enabled = true;
            btnSaveGlobal.Enabled = true;
            tmr_logout.Enabled = true;

            Util.showWait(false);

        }


        private bool save_users(int section_id)
        {

            bool ret = true;


            if (section_id == 1 || section_id == 2)
            {
                if (txtPOSUserName.Text.Trim().Length == 0)
                {
                    doNotice("Name cannot be blank!", 2);
                    txtPOSUserName.Focus();
                    return false;
                }
                if (txtPOSUserLastname.Text.Trim().Length == 0)
                {
                    doNotice("Surname cannot be blank!", 2);
                    txtPOSUserLastname.Focus();
                    return false;
                }
                if (txtPOSUserPIN.Text.IndexOf("0") > -1)
                {
                    doNotice("PIN #contains a 0, please use numbers 1-9 only!", 2);
                    txtPOSUserPIN.Focus();
                    return false;
                }
                if (txtPOSUserPIN.Text.Trim().Length != 4)
                {
                    doNotice("Password must be 4 characters!", 2);
                    txtPOSUserPIN.Focus();
                    return false;
                }
            }

            if (section_id == 1)
            {

                try
                {
                    foreach (string s in Util.pos_users)
                    {
                        string[] line = s.Split('^');
                        if ((txtPOSUserName.Text == line[1].Trim()) && (txtPOSUserLastname.Text == line[2].Trim()))
                        {
                            doNotice(txtPOSUserName.Text + " " + txtPOSUserLastname.Text + " already exists!", 2);
                            return false;
                        }
                    }
                }
                catch { }

                try
                {

                    String res = webService.addPosUser(
                                    txtPOSUserName.Text.Trim(),
                                    txtPOSUserLastname.Text.Trim(),
                                    txtPOSUserPIN.Text,
                                    "", "1",
                                    (selPOSUserIsAdmin2.Checked) ? "1" : "0",
                                    (selIDType2.Checked) ? "1" : "0",
                                    txtIDNumber.Text.Trim(),
                                    (chkRicaTraining.Checked) ? "1" : "0");
                    if (res == "OK")
                    {
                        doNotice(txtPOSUserName.Text + " " + txtPOSUserLastname.Text + " has been added.", 1);
                    }
                    else
                    {
                        doNotice(res, 2);
                        return false;
                    }

                }
                catch (Exception err)
                {
                    doNotice(err.Message, 2);
                    return false;
                }


            }


            if (section_id == 2)
            {

                try
                {

                    if (intSelectedPOSUserID == 0)
                    {
                        doNotice("Cannot Update this User, please close and try again.", 2);
                        return false;
                    }

                    String res = webService.updatePosUser(
                            intSelectedPOSUserID.ToString(),
                            txtPOSUserName.Text.Trim(),
                            txtPOSUserLastname.Text.Trim(),
                            txtPOSUserPIN.Text,
                            "",
                            (chkPosuserSuspended.Checked) ? "2" : "1",
                            (selPOSUserIsAdmin2.Checked) ? "1" : "0",
                            (selIDType2.Checked) ? "1" : "0",
                            txtIDNumber.Text.Trim(),
                            (chkRicaTraining.Checked) ? "1" : "0");
                    if (res.Equals("OK"))
                    {
                        doNotice(txtPOSUserName.Text + " " + txtPOSUserLastname.Text + " has been succesfully updated.", 1);
                    }
                    else
                    {
                        doNotice(res, 2);
                        return false;
                    }

                }
                catch (Exception err)
                {
                    doNotice(err.Message, 2);
                    return false;
                }

            }

            if (section_id == 5)
            {

                globalSettings.gen_cashdr_cashier = "0";
                if (chkCashDrawerCashier.Checked) globalSettings.gen_cashdr_cashier = "1";

                globalSettings.gen_cashier_ownsales = "0";
                if (chkCashierOwnSales.Checked) globalSettings.gen_cashier_ownsales = "1";

                globalSettings.gen_cashier_w = "0";
                if (chkCashierW.Checked) globalSettings.gen_cashier_w = "1";

                globalSettings.gen_cashier_y = "0";
                if (chkCashierY.Checked) globalSettings.gen_cashier_y = "1";

                globalSettings.gen_cashier_y_all = "0";
                if (chkCashierAllSalesY.Checked) globalSettings.gen_cashier_y_all = "1";

                globalSettings.gen_cashier_y_history = "0";
                if (chkCashierYHistory.Checked) globalSettings.gen_cashier_y_history = "1";

                globalSettings.gen_cashier_elec_disabled = "0";
                if (chkCashierElectricityDisabled.Checked) globalSettings.gen_cashier_elec_disabled = "1";

                globalSettings.gen_cashier_bill_disabled = "0";
                if (chkCashierBillDisabled.Checked) globalSettings.gen_cashier_bill_disabled = "1";

                globalSettings.gen_cashier_salehistory_disabled = "0";
                if (chkDisableSalesHistory.Checked) globalSettings.gen_cashier_salehistory_disabled = "1";

                globalSettings.gen_cashier_allowreprint = "0";
                if (chkCashierReprint.Checked) globalSettings.gen_cashier_allowreprint = "1";

                globalSettings.gen_cashier_allowreprintlast = "0";
                if (chkCashierReprintLast.Checked) globalSettings.gen_cashier_allowreprintlast = "1";

                globalSettings.gen_cashier_allowreprintlast_admin = "0";
                if (chkCashierReprintLastAdmin.Checked) globalSettings.gen_cashier_allowreprintlast_admin = "1";

                globalSettings.gen_cashier_billconvenience_cashier = "0";
                if (chkBillConvenienceCashier.Checked) globalSettings.gen_cashier_billconvenience_cashier = "1";

                globalSettings.gen_cashier_billconvenience_admin = "0";
                if (chkBillConvenienceAdmin.Checked) globalSettings.gen_cashier_billconvenience_admin = "1";

                globalSettings.gen_cashier_restart = "0";
                if (chkCashierRestart.Checked) globalSettings.gen_cashier_restart = "1";

                globalSettings.SaveGeneral();

                doNotice("Cashier Settings Saved!", 1);

            }


            if (section_id == 6 || section_id == 7)
            {

                try
                {

                    JArray array = new JArray();
                    foreach (ListViewItem item in this.chkListProducts.Items)
                    {
                        if (!item.Checked)
                        {
                            array.Add(item.Tag);
                        }
                    }

                    JObject jsonObj = new JObject();
                    jsonObj["disabledProducts"] = array;

                    using (StreamWriter file = File.CreateText(globalSettings.app_path + @"\conf\provider_item_" + custom_product_file + ".dis"))
                    using (Newtonsoft.Json.JsonTextWriter writer = new Newtonsoft.Json.JsonTextWriter(file))
                    {
                        jsonObj.WriteTo(writer);
                    }

                    doNotice("Saved Customised Product List", 1);

                }
                catch (Exception ex)
                {
                    doNotice(ex.Message, 2);
                }

                Util.loadDisabledItems(custom_product_file);

            }

            return ret;

        }


        private void save_general(int section_id)
        {

            if (section_id == 1)
            {

                if (!chkLogout.Checked && radioButtonNever.Checked && !chkLogoutAccept.Checked)
                {
                    doNotice("Please confirm the legal disclaimer.", 2);
                    return;
                }

                if (txtTerminalName.Text.Equals("") && lblTermName.Text.Equals("Terminal Name"))
                {
                    doNotice("Please enter a proper terminal description!", 2);
                    return;
                }

                globalSettings.gen_show_balance_login = "0";
                globalSettings.gen_logout = "0";

                if (chkLowBalance.Checked) globalSettings.gen_show_balance_login = "1";
                if (chkLogout.Checked) globalSettings.gen_logout = "1";

                globalSettings.gen_show_financials = "0";
                if (chk_show_financials.Checked) globalSettings.gen_show_financials = "1";

                globalSettings.gen_show_financials_cashier = "0";
                if (chk_show_financials_cashier.Checked) globalSettings.gen_show_financials_cashier = "1";

                globalSettings.gen_show_last_sale_login = "0";
                if (chk_show_last_sale.Checked) globalSettings.gen_show_last_sale_login = "1";

                globalSettings.gen_sound = "0";
                if (chkSound.Checked) globalSettings.gen_sound = "1";

                globalSettings.gen_show_multi_voucher = "0";
                if (chkMultiVoucher.Checked) globalSettings.gen_show_multi_voucher = "1";

                if (!chkLogout.Checked)
                {
                    if (radioButtonNever.Checked) globalSettings.gen_logout_time = 2000000000;
                    if (radioButton1.Checked) globalSettings.gen_logout_time = 10000;
                    if (radioButton2.Checked) globalSettings.gen_logout_time = 15000;
                    if (radioButton3.Checked) globalSettings.gen_logout_time = 30000;
                    if (radioButton4.Checked) globalSettings.gen_logout_time = 60000;
                    if (radioButton5.Checked) globalSettings.gen_logout_time = 120000;
                    if (radioButton6.Checked) globalSettings.gen_logout_time = 180000;
                    if (radioButton7.Checked) globalSettings.gen_logout_time = 300000;
                }


                globalSettings.gen_virtual_keyboard = "0";
                if (chk_keyboard.Checked) globalSettings.gen_virtual_keyboard = "1";


                globalSettings.SaveGeneral();


                if (lblTermName.Text.Equals("Terminal Name"))
                {
                    if (OriginalLicenseDesc != txtTerminalName.Text)
                    {
                        doNotice("Updating Terminal Name!", 1);
                        setLicenseDesc(txtTerminalName.Text);
                    }
                }




            }


            if (section_id == 2)
            {

                try
                {

                    txtSlipExtra1.Text = txtSlipExtra1.Text.Trim();
                    txtSlipExtra2.Text = txtSlipExtra2.Text.Trim();
                    txtSlipExtra3.Text = txtSlipExtra3.Text.Trim();
                    txtSlipExtra4.Text = txtSlipExtra4.Text.Trim();
                    txtSlipExtra5.Text = txtSlipExtra5.Text.Trim();

                    String strToWrite = txtSlipExtra1.Text + "^" + txtSlipExtra2.Text + "^" + txtSlipExtra3.Text + "^" + txtSlipExtra4.Text + "^" + txtSlipExtra5.Text;

                    string filename = globalSettings.app_path + @"\conf\settings_slipextra.dat";
                    if (System.IO.File.Exists(filename) == true) { System.IO.File.Delete(filename); }
                    System.IO.TextWriter tw = new System.IO.StreamWriter(filename, false);
                    tw.Write(strToWrite);
                    tw.Close();

                    Util.voucher_print_extra[0] = txtSlipExtra1.Text;
                    Util.voucher_print_extra[1] = txtSlipExtra2.Text;
                    Util.voucher_print_extra[2] = txtSlipExtra3.Text;
                    Util.voucher_print_extra[3] = txtSlipExtra4.Text;
                    Util.voucher_print_extra[4] = txtSlipExtra5.Text;

                    String do_print = txtSlipExtra1.Text + txtSlipExtra2.Text + txtSlipExtra3.Text + txtSlipExtra4.Text + txtSlipExtra5.Text;

                    globalSettings.do_print_extra = (do_print.Length > 0) ? true : false;

                    globalSettings.gen_print_address = "0";
                    globalSettings.gen_prnt_b = "0";
                    globalSettings.gen_prnt_be = "0";
                    globalSettings.gen_prnt_bb = "0";
                    globalSettings.gen_print_copy = "0";
                    globalSettings.gen_print_pinless_slip = "0";
                    globalSettings.gen_slip_printer = "0";
                    globalSettings.gen_cashdr = "0";
                    globalSettings.gen_show_voucher_only = "0";

                    //globalSettings.gen_ignore_paper = "0";

                    if (chkPinlessSlip.Checked) globalSettings.gen_print_pinless_slip = "1";
                    if (chkPrintAddress.Checked) globalSettings.gen_print_address = "1";
                    if (chkPrintBarcodeAir.Checked) globalSettings.gen_prnt_b = "1";
                    if (chkPrintBarcodeEle.Checked) globalSettings.gen_prnt_be = "1";
                    if (chkPrintBarcodeBill.Checked) globalSettings.gen_prnt_bb = "1";
                    if (chkPrintSlipCopy.Checked) globalSettings.gen_print_copy = "1";
                    //if (chkOutOfPaper.Checked) globalSettings.gen_ignore_paper = "1";

                    if (!chkSlipPrinter.Checked) chkCashDrawer.Checked = false;
                    if (chkSlipPrinter.Checked) globalSettings.gen_slip_printer = "1";

                    if (chkCashDrawer.Checked) globalSettings.gen_cashdr = "1";

                    if (chkShowVoucherOnly.Checked) globalSettings.gen_show_voucher_only = "1";

                    globalSettings.SaveGeneral();

                }
                catch (Exception ex)
                {
                    doNotice(ex.Message, 2);
                    return;
                }

            }


            if (section_id == 3)
            {

                globalSettings.quickprint_item1 = "";
                globalSettings.quickprint_item2 = "";
                globalSettings.quickprint_item3 = "";
                globalSettings.quickprint_item4 = "";
                globalSettings.quickprint_item5 = "";

                try
                {

                    int voucher_prov_arr_id = -1;
                    foreach (stockProvider sp in Util.stock_provider)
                    {
                        voucher_prov_arr_id++;
                        for (int x = 0; x < Util.stock_provider[voucher_prov_arr_id].itemcount; x++)
                        {
                            if (cboQLaunch1.Text == Util.stock_provider[voucher_prov_arr_id].item[x].item_desc)
                                globalSettings.quickprint_item1 = Util.stock_provider[voucher_prov_arr_id].item[x].item_id.ToString();
                            if (cboQLaunch2.Text == Util.stock_provider[voucher_prov_arr_id].item[x].item_desc)
                                globalSettings.quickprint_item2 = Util.stock_provider[voucher_prov_arr_id].item[x].item_id.ToString();
                            if (cboQLaunch3.Text == Util.stock_provider[voucher_prov_arr_id].item[x].item_desc)
                                globalSettings.quickprint_item3 = Util.stock_provider[voucher_prov_arr_id].item[x].item_id.ToString();
                            if (cboQLaunch4.Text == Util.stock_provider[voucher_prov_arr_id].item[x].item_desc)
                                globalSettings.quickprint_item4 = Util.stock_provider[voucher_prov_arr_id].item[x].item_id.ToString();
                            if (cboQLaunch5.Text == Util.stock_provider[voucher_prov_arr_id].item[x].item_desc)
                                globalSettings.quickprint_item5 = Util.stock_provider[voucher_prov_arr_id].item[x].item_id.ToString();
                        }
                    }

                    globalSettings.gen_quick_print_disable = "0";
                    if (chkQuickPrintDisable.Checked) globalSettings.gen_quick_print_disable = "1";

                    globalSettings.gen_quick_print_confirm = "0";
                    if (chkQuickPrintConfirm.Checked) globalSettings.gen_quick_print_confirm = "1";

                    globalSettings.SaveGeneral();

                }
                catch (Exception ex)
                {
                    doNotice(ex.Message, 2);
                    return;
                }

            }


            if (section_id == 4)
            {

                try
                {
                    if (Convert.ToDecimal(txt_elec_preset_val1.Text.ToString()) == 0 || txt_elec_preset_val1.Text.Trim() == "")
                    {
                        doNotice("Electricity Value cannot be zero or blank!", 2);
                        txt_elec_preset_val1.Focus();
                        return;
                    }
                    if (Convert.ToDecimal(txt_elec_preset_val2.Text.ToString()) == 0 || txt_elec_preset_val2.Text.Trim() == "")
                    {
                        doNotice("Electricity Value cannot be zero or blank!", 2);
                        txt_elec_preset_val2.Focus();
                        return;
                    }
                    if (Convert.ToDecimal(txt_elec_preset_val3.Text.ToString()) == 0 || txt_elec_preset_val3.Text.Trim() == "")
                    {
                        doNotice("Electricity Value cannot be zero or blank!", 2);
                        txt_elec_preset_val3.Focus();
                        return;
                    }
                    if (Convert.ToDecimal(txt_elec_preset_val4.Text.ToString()) == 0 || txt_elec_preset_val4.Text.Trim() == "")
                    {
                        doNotice("Electricity Value cannot be zero or blank!", 2);
                        txt_elec_preset_val4.Focus();
                        return;
                    }

                    if (chkElectraMaxWarning.Checked)
                    {
                        if (Convert.ToDecimal(txt_elec_max_warning.Text.ToString()) == 0 || txt_elec_max_warning.Text.Trim() == "")
                        {
                            doNotice("Electricity Max Value cannot be zero or blank!", 2);
                            txt_elec_max_warning.Focus();
                            return;
                        }
                    }

                }
                catch
                {
                    doNotice("Error trying to save!", 2);
                    return;
                }

                globalSettings.elec_preset_enabled = "0";
                if (chk_elec_preset_enabled.Checked) globalSettings.elec_preset_enabled = "1";

                globalSettings.elec_preset_val1 = txt_elec_preset_val1.Text;
                globalSettings.elec_preset_val2 = txt_elec_preset_val2.Text;
                globalSettings.elec_preset_val3 = txt_elec_preset_val3.Text;
                globalSettings.elec_preset_val4 = txt_elec_preset_val4.Text;

                globalSettings.elec_max_warning_show = "0";
                if (chkElectraMaxWarning.Checked) globalSettings.elec_max_warning_show = "1";

                globalSettings.elec_max_vend_show = "0";
                if (chkElectraShowMaxVend.Checked) globalSettings.elec_max_vend_show = "1";

                globalSettings.elec_max_warning_val = txt_elec_max_warning.Text;

                globalSettings.SaveGeneral();

            }



            doNotice("Updated settings.", 1);

        }

        private void lblDisclaimer_Click(object sender, EventArgs e)
        {
            chkLogoutAccept.Checked = !chkLogoutAccept.Checked;
        }

        private void btnReboot_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("shutdown", "/s /t 0");
            }
            catch
            {
                //
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("shutdown", "/r /t 0");
            }
            catch
            {
                //
            }
        }

        private void btnTransferShow_Click(object sender, EventArgs e)
        {

            ist_startup();

            btnPrintBalance.Hide();
            btnTransferPanel.Hide();
            btnTransferShow.Hide();
            grp_finw1.Hide();
            lblPleaseRefreshBalance.Show();

            virtualKeyboard1.setKeyPadOnly(false);
            virtualKeyboard1.showKeyPadPoint();

            enablePanel(pnlFundsTransfer, "");

        }







        private void ist_startup()
        {

            Util.showWait(true);

            fft_rand_value.MaxLength = 8;

            ist_store_accnumber.CharacterCasing = CharacterCasing.Upper;

            try
            {
                ist_rand_bg.Image = new Bitmap(globalSettings.app_path + @"\images\elec_rand.gif");
            }
            catch
            {
                //
            }

            if (finBalance.cash_customer.Equals("1"))
            {
                ist_wallet0.Checked = true;
                ist_funds_available.Text = "R " + finBalance.available_balance;
            }
            else
            {
                ist_wallet0.Enabled = false;
                ist_wallet1.Checked = true;
                ist_funds_available.Text = "R " + finBalance.balance_cash;
            }

            ist_update_controls(true);

            ist_btn_confirm.Visible = false;
            ist_btn_transfer.Visible = true;
            ist_lbl_complete.Visible = false;
            ist_pnl_outlet.Visible = false;

            load_customer_groups();

            Util.showWait(false);

        }

        private void load_customer_groups()
        {

            ist_group_store.Items.Clear();

            String htmlResponse = "";

            Web WebResponse = new Web(10000, 1, "");
            htmlResponse = WebResponse.GetURL("/terminal/general/get-customer-group-outlets");
            WebResponse = null;

            if (htmlResponse != "")
            {
                if (htmlResponse.IndexOf("err>") > -1)
                {
                    Console.WriteLine("No Outlets in Group");
                }
                else
                {

                    try
                    {
                        foreach (string s in htmlResponse.Split("\n".ToCharArray()))
                        {
                            string[] toadd = s.Split("^".ToCharArray());
                            ist_group_store.Items.Add(new ComboboxItem(toadd[1].ToString() + " [" + toadd[0].ToString() + "]", toadd[0].ToString()));
                        }
                    }
                    catch (Exception e)
                    {
                        //
                    }

                }

            }
            else
            {
                Console.WriteLine("No Outlets in Group");
            }

        }

        private bool confirm_customer_amount()
        {

            bool ret = false;
            String htmlResponse = "";

            String param = "?acc=" + ist_selected_account;
            param += "&w=" + ist_wallet.ToString();
            param += "&amt=" + ist_credit_amount.ToString();

            Web WebResponse = new Web(10000, 1, "");
            htmlResponse = WebResponse.GetURL("/terminal/financial/confirm-customer-transfer" + param);
            WebResponse = null;

            if (htmlResponse != "")
            {

                if (htmlResponse.hasErrorCode())
                {
                    Util.showMessage(htmlResponse.StripErrorTags(), Color.Red);
                    return false;
                }
                else
                {
                    try
                    {
                        ist_lbl_outlet.Text = htmlResponse;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

            }
            else
            {
                Util.showMessage("Could not find outlet account number.", Color.Red);
                return false;
            }

            return true;

        }

        String ist_selected_account = "";
        double ist_credit_amount = 0.0d;
        int ist_wallet = 0;
        private void ist_transfer_Click(object sender, EventArgs e)
        {

            ist_selected_account = "";
            ist_credit_amount = 0.0d;
            ist_wallet = 0;

            if (ist_btn_transfer.Text.Equals("Close"))
            {
                ist_grd_tx_history.Hide();
                return;
            }

            if (ist_btn_transfer.Text.Equals("Cancel"))
            {
                ist_btn_transfer.Text = "OK";
                ist_btn_confirm.Visible = false;
                ist_pnl_outlet.Visible = false;
                ist_update_controls(true);
                ist_btn_tx_history.Visible = true;
                return;
            }

            ist_btn_tx_history.Visible = false;

            try
            {
                ComboboxItem itm = (ComboboxItem)ist_group_store.SelectedItem;
                //Console.WriteLine("{0}, {1}", itm.Name, itm.Value);
                ist_selected_account = itm.Value;
            }
            catch
            {
                ist_selected_account = "";
            }

            if (ist_store_accnumber.Text.Trim().Length == 6)
            {
                ist_selected_account = ist_store_accnumber.Text.Trim();
            }

            if (ist_selected_account.Equals(""))
            {
                Util.showMessage("Please select or enter an account number!", Color.Red);
                return;
            }

            if (fft_rand_value.Text.Length == 0)
            {
                Util.showMessage("Please enter a transfer amount!", Color.Red);
                fft_rand_value.Focus();
                return;
            }

            try
            {
                ist_credit_amount = Convert.ToDouble(fft_rand_value.Text);
            }
            catch
            {
                ist_credit_amount = 0.0d;
                Util.showMessage("Please check the transfer amount!", Color.Red);
                fft_rand_value.Focus();
                return;
            }

            //Console.WriteLine(ist_credit_amount.ToString());

            if (ist_wallet1.Checked) ist_wallet = 1;

            Util.showWait(true);

            ist_update_controls(false);

            if (confirm_customer_amount())
            {
                if (ist_btn_transfer.Text.Equals("OK")) ist_btn_transfer.Text = "Cancel";
                ist_btn_confirm.Visible = true;
                ist_pnl_outlet.Visible = true;
                //return ok
            }
            else
            {
                ist_btn_confirm.Visible = false;
                ist_pnl_outlet.Visible = false;
                ist_update_controls(true);
            }

            Util.showWait(false);

        }

        private void ist_btn_confirm_Click(object sender, EventArgs e)
        {

            ist_btn_confirm.Enabled = false;

            Util.showWait("Processing Transfer...");

            try
            {

                String param = "?acc=" + ist_selected_account;
                param += "&w=" + ist_wallet.ToString();
                param += "&amt=" + ist_credit_amount.ToString();

                Web WebResponse = new Web(15000);
                String htmlResponse = WebResponse.GetURL("/terminal/financial/wallet-transfer-interstore" + param);
                WebResponse = null;

                if (htmlResponse.hasErrorCode())
                {
                    Util.showMessage(htmlResponse.StripErrorTags(), Color.Red);
                    ist_btn_confirm.Enabled = true;
                }
                else if (htmlResponse.IndexOf("\"ok\"", 0) > -1)
                {
                    ist_lbl_complete.Visible = true;
                    ist_btn_transfer.Visible = false;
                    ist_btn_confirm.Visible = false;

                    finBalance.getBalance(1);

                }

            }
            catch (Exception ex)
            {
                Util.showMessage(ex.Message, Color.Red);
                ist_btn_confirm.Enabled = true;
            }

            Util.showWait(false);

        }

        private void ist_update_controls(bool state)
        {
            ist_wallet0.Enabled = state;
            ist_wallet1.Enabled = state;
            if (finBalance.cash_customer.Equals("0")) ist_wallet0.Enabled = false;
            ist_group_store.Enabled = state;
            ist_store_accnumber.Enabled = state;
            fft_rand_value.Enabled = state;
        }

        private void ist_wallet1_CheckedChanged(object sender, EventArgs e)
        {
            ist_funds_available.Text = "R " + finBalance.balance_cash;
        }

        private void ist_wallet0_CheckedChanged(object sender, EventArgs e)
        {
            ist_funds_available.Text = "R " + finBalance.available_balance;
        }

        private void ist_numericTextBox_LostFocus(object sender, EventArgs e)
        {
            try
            {
                //amount = Convert.ToDouble(txtRandValue.Text);
                fft_rand_value.Text = String.Format("{0:n}", Decimal.Parse(fft_rand_value.Text.Replace(",", ""), System.Globalization.CultureInfo.InvariantCulture));
            }
            catch
            {
                //
            }

        }

        private void ist_RandValue_KeyPress(object sender, KeyPressEventArgs e)
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





        private void btn_settings_backup_Click(object sender, EventArgs e)
        {

            Util.showWait(true);

            String settings = globalSettings.get_general_settings();

            if (!settings.Equals(""))
            {

                Web WebResponse = new Web(25000);
                String htmlResponse = WebResponse.PostData("/terminal/general/settings-backup", "settings=" + settings);
                WebResponse = null;

                if (htmlResponse.hasErrorCode()) {

                    Util.showMessage(htmlResponse.StripErrorTags(), Color.Red);

                } else if (htmlResponse.Equals("ok")) {

                    Util.showMessage("Setings saved!", Color.Green);

                }

            }
            else
            {
                Util.showMessage("Could not get Settings!", Color.Red);
            }

            Util.showWait(false);

        }

        private void btn_settings_restore_Click(object sender, EventArgs e)
        {

            Util.showWait(true);


            Web WebResponse = new Web(25000);
            String htmlResponse = WebResponse.GetURL("/terminal/general/settings-restore");
            WebResponse = null;

            if (htmlResponse.hasErrorCode())
            {

                Util.showMessage(htmlResponse.StripErrorTags(), Color.Red);

            }
            else
            {

                string filename = globalSettings.app_path + @"\conf\settings_restore.dat";
                if (File.Exists(filename) == true) { File.Delete(filename); }
                TextWriter tw = new StreamWriter(filename, false);
                tw.Write(htmlResponse);
                tw.Close();

                if (globalSettings.load_from_backup())
                {
                    globalSettings.SaveGeneral();
                    Util.showMessage("Settings restored. Please restart.", Color.Green);
                    lblPleaseReboot.Visible = true;
                }
                else
                {
                    Util.showMessage("Could not load settings.", Color.Red);
                }

            }

            Util.showWait(false);

        }

        private void ist_btn_tx_history_Click(object sender, EventArgs e)
        {

            Util.showWait(true);

            ist_grd_tx_history.Rows.Clear();

            String htmlResponse = "";

            Web WebResponse = new Web(45000);
            htmlResponse = WebResponse.GetURL("/terminal/financial/wallet-transfer-gethistory");
            WebResponse = null;

            if (htmlResponse.hasErrorCode())
            {
                Util.showMessage(htmlResponse.StripErrorTags(), Color.Red);
            }
            else if (htmlResponse == "")
            {
                Util.showMessage("No Previous Y Reports.", Color.Red);
            }
            else if (htmlResponse != "")
            {
                try
                {
                    string[] lines = htmlResponse.Split('\n');

                    for (int i = 0; i < lines.Length - 1; i++)
                    {
                        string[] items = lines[i].Split('^');

                        ist_grd_tx_history.Rows.Add();

                        ist_grd_tx_history.Rows[i].Tag = items[0];
                        ist_grd_tx_history.Rows[i].Cells[0].Value = items[1];
                        ist_grd_tx_history.Rows[i].Cells[1].Value = items[2];
                        ist_grd_tx_history.Rows[i].Cells[2].Value = String.Format(" R {0:n}", decimal.Parse(items[3], System.Globalization.CultureInfo.InvariantCulture), System.Globalization.CultureInfo.InvariantCulture);

                    }

                    ist_btn_transfer.Text = "Close";
                    ist_grd_tx_history.Show();

                }
                catch (Exception ex)
                {
                    Util.showMessage(ex.Message, Color.Red);
                }
            }

            Util.showWait(false);

        }

        private void btnCommission_Click(object sender, EventArgs e)
        {
            dtSalesReport.Format = DateTimePickerFormat.Custom;
            dtSalesReport.CustomFormat = "yyyy-MM";
            dtSalesReport.ShowUpDown = true;
            reportType = "Monthly Commission";
            pnlReport.Show();
            pnlReport.BringToFront();
        }

        private void btnsaleConfirm_Click_1(object sender, EventArgs e)
        {
            saleConfirm();
        }
        private void pullReportFlag(){

            string ret = "";
            string htmlResponse = "";

            try
            {

     

                Web WebResponse = new Web(60000, 1, "");
                htmlResponse = WebResponse.GetURL("/terminal/general/get-status-full");
                WebResponse = null;

                if (htmlResponse.IndexOf("err>") == -1 && htmlResponse != "")
                {

                

                    Newtonsoft.Json.Linq.JObject json = Newtonsoft.Json.Linq.JObject.Parse(htmlResponse);

                    if (!String.IsNullOrEmpty((string)json["err"]))
                    {
                        ret = (string)json["err"];
                    }
                    else
                    {
                        //MessageBox.Show((string)json["enable_rpt_monthly_deposit"]);

                        if(!String.IsNullOrEmpty((string)json["enable_rpt_monthly_deposit"])) globalSettings.enable_rpt_monthly_deposit = (string)json["enable_rpt_monthly_deposit"];
                        if (!String.IsNullOrEmpty((string)json["enable_rpt_comm_statement"])) globalSettings.enable_rpt_comm_statement = (string)json["enable_rpt_comm_statement"];
                        if (!String.IsNullOrEmpty((string)json["enable_rpt_monthly_sales"])) globalSettings.enable_rpt_monthly_sales = (string)json["enable_rpt_monthly_sales"];

                        
                    }

                   

                    
                    ret = "";

                }
              
            }
            catch (Exception ex)
            {
                ret = ex.Message;
            }



        }
        private void btnsaleCancel_Click_1(object sender, EventArgs e)
        {
            pnlReport.Hide();
            pnlReport.SendToBack();
        }
    }



    //public string wsGet_ZReportList(bool ShowAllZReports)
    //{

    //    string URI = serverURL + "/idt700_api/reports/list_z_reports?";
    //           URI = URI + "lic=" + licenseCode;

    //    if (ShowAllZReports == true)
    //    {
    //        URI = URI + "&q=10";
    //        URI = URI + "&c=" + globalSettings.customer_id;
    //    }

    //    //string wsresult = new clsWebfunctions().StringGetWebPage(URI, 25000);
    //    string wsresult = "";
    //    if (wsresult.IndexOf("ERR:") > -1)
    //        wsresult = "";

    //    return wsresult;
    //}



    //public string wsReprint_Z(int prev_z_id)
    //{

    //    string URI = serverURL + "/idt700_api/reports/reprint_z?";
    //    URI = URI + "lic=" + licenseCode;
    //    URI = URI + "&z_id=" + prev_z_id.ToString();
    //    string wsresult = "";
    //    //string wsresult = new clsWebfunctions().StringGetWebPage(URI, 25000);

    //    if (wsresult.IndexOf("ERR:") > -1)
    //        wsresult = "";

    //    return wsresult;
    //}

    //public string wsReprint_Z_Cashier(int prev_z_id)
    //{

    //    string URI = serverURL + "/idt700_api/reports/do_all_cashier_x?";
    //    URI = URI + "lic=" + licenseCode;
    //    URI = URI + "&posuser_id=" + globalSettings.pos_user_id;
    //    URI = URI + "&z_id=-1";
    //    URI = URI + "&crzid=" + prev_z_id.ToString();
    //    string wsresult = "";
    //    //string wsresult = new clsWebfunctions().StringGetWebPage(URI, 35000);

    //    if (wsresult.IndexOf("ERR:") > -1)
    //        wsresult = "";

    //    return wsresult;
    //}

    public class ComboboxItem
    {
        public string Text { get; set; }
        public string Value { get; set; }

        public ComboboxItem(string name, string value)
        {
            Text = name; Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
    }

    //public class ItemInfo
    //{
    //    public string Name;
    //    public string Id;
    //    public bool Enabled;

    //    public override string ToString()
    //    {
    //        return Name;
    //    }
    //}


}
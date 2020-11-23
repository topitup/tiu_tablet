using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;


namespace cashms
{
    public partial class frmCashMs : Form
    {

        String payment_slip_toprint = "";



        public frmCashMs()
        {

            InitializeComponent();

            TopitUp.globalSettings.dll_version_cashms_runonce = true;
            TopitUp.globalSettings.dll_version_cashms = "20181207";
            TopitUp.globalSettings.save_dll_versions();

        }

        private void frmCashManagement_Load(object sender, EventArgs e)
        {

            if (TopitUp.globalSettings.allow_screen_resize == "0")
            {
                this.Left = 0;
                this.Width = Screen.PrimaryScreen.Bounds.Width;
                this.Top = 100;
                this.Height = Screen.PrimaryScreen.Bounds.Height - 100;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.Left = TopitUp.Util._home_form.Left + 8;
                this.Width = TopitUp.Util._home_form.Width - 16;
                this.Top = TopitUp.Util._home_form.Top + 131;
                this.Height = 700;
            }

           

            try
            {
                CloseAllForms();

                //this.Invoke((System.Threading.ThreadStart)delegate
                //{
                //   TopitUp.Util.hideLoading();
                //   TopitUp.Util.popLoading.Hide();
                //});

            } catch (Exception ex)
            {
                //
            }


            pnpCustomerSelector.Top = 45;

            try
            {
                //btnProvider1.ImageDefault = imageCheckOnly(TopitUp.globalSettings.app_path + @"\images\cashms_penbev.gif");
                //btnProvider1.ImagePressed = imageCheckOnly(TopitUp.globalSettings.app_path + @"\images\cashms_penbev.gif");
                //btnProvider2.ImageDefault = imageCheckOnly(TopitUp.globalSettings.app_path + @"\images\cashms_demo.gif");
                //btnProvider2.ImagePressed = imageCheckOnly(TopitUp.globalSettings.app_path + @"\images\cashms_demo.gif");
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

            //TopitUp.showMessage("test", false);

            //versionlabel.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Revision.ToString();
            versionlabel.Text = TopitUp.globalSettings.dll_version_cashms;

            picRandBg.Image = new Bitmap(TopitUp.globalSettings.app_path + @"\images\elec_rand.gif");

            txtLoadNo.Focus();

            if (missingImages.Count > 0)
            {
                tmr_download_images.Enabled = true;
            }


            pnpCustomerSelector.BringToFront();

        }


        static void showMessage(String msg, Color c)
        {
            TopitUp.PopupNotifier popupNotifier = new TopitUp.PopupNotifier();
            popupNotifier.ContentColor = c;
            popupNotifier.ContentText = msg;

            //popupNotifier.Image = global::TopitUp.Properties.Resources.popup_info;

            popupNotifier.Popup();
        }


        static public void CloseAllForms()
        {
            // get array because collection changes as we close forms
            //Form[] forms = Application.OpenForms;

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name.Equals("popupLoading")) CloseForm(form);
            }

            // close every open form
            //foreach (Form form in forms)
            //{
//                CloseForm(form);
            //}
        }

        delegate void CloseMethod(Form form);
        static private void CloseForm(Form form)
        {
            if (!form.IsDisposed)
            {
                if (form.InvokeRequired)
                {
                    CloseMethod method = new CloseMethod(CloseForm);
                    form.Invoke(method, new object[] { form });
                }
                else
                {
                    //form.Close();
                    form.Hide();
                }
            }
        }


        private void start_delayed_load(String action, int interval)
        {
            _current_action = action;
            tmr_delayed_load.Interval = interval;
            tmr_delayed_load.Enabled = true;
        }



        private string _current_action = "";
        private void tmr_delayed_load_Tick_1(object sender, EventArgs e)
        {

            tmr_delayed_load.Interval = 2000;
            tmr_delayed_load.Enabled = false;

            if (_current_action == "get_customer_information")
            {
                String htmlResponse = "";
                try
                {

                    TopitUp.Web WebResponse = new TopitUp.Web(10000);
                    htmlResponse = WebResponse.GetURL("/terminal/cashmx/get-customer-info");
                    WebResponse = null;

                    if (htmlResponse.IndexOf("err>") > -1)
                    {
                        //
                    }
                    else if (htmlResponse.Length > 0)
                    {
                        JObject json = JObject.Parse(htmlResponse);
                        if (!String.IsNullOrEmpty((string)json["dc_code"])) txtLoadNoPre.Text = (string)json["dc_code"];
                        if (!String.IsNullOrEmpty((string)json["cashms_acc_number"])) txtPONumber.Text = (string)json["cashms_acc_number"];
                    }
                }
                catch (Exception ex)
                {
                    showMessage(ex.Message, Color.Red);
                }

            }

            _current_action = "";

        }












        //public static Bitmap _btnkeypad0;
        //public static Bitmap _btnkeypad1;
        //private void setButtonKeyPad(Resco.Controls.OutlookControls.ImageButton btn)
        //{
        //    btn.Click += new System.EventHandler(btnClick_Click);
        //    btn.ImageDefault = _btnkeypad0;
        //    btn.ImagePressed = _btnkeypad1;
        //}

        //bool isText = true;
        //private void txtBox_GotFocus(object sender, EventArgs e)
        //{
        //    isText = true;
        //    currentTextbox = (TextBox)sender;
        //}


        //private void btnClick_Click(object sender, EventArgs e)
        //{
        //    Resco.Controls.OutlookControls.ImageButton btn = (Resco.Controls.OutlookControls.ImageButton)sender;
        //    key_press_logic(btn.TextDefault);
        //}


        //private void key_press_logic(string Key)
        //{


        //    if (Key.Equals("<-"))
        //    {

        //        if (currentTextbox.Text.Length > 1)
        //            currentTextbox.Text = currentTextbox.Text.Substring(0, currentTextbox.Text.Length - 1);
        //        else
        //            currentTextbox.Text = "";

        //        if (currentTextbox.Text.Length > 0)
        //        {
        //            currentTextbox.Select(currentTextbox.Text.Length, currentTextbox.Text.Length);
        //            currentTextbox.ScrollToCaret();
        //        }

        //        return;
        //    }


        //    if (currentTextbox.MaxLength <= currentTextbox.Text.Length)
        //        return;

        //    String doText = Key;

        //    if (Key.Equals("Space"))
        //    {
        //        doText = " ";
        //    }


        //    if (currentTextbox.Name.Equals("txtRandValue") || currentTextbox.Name.Equals("txtLoadNo") || currentTextbox.Name.Equals("txtPONumber") || currentTextbox.Name.Equals("txtDriverNo") || currentTextbox.Name.Equals("txtDriverCell"))
        //    {
        //        if (!doText.Equals(".") && !doText.Equals("0") && !doText.Equals("1")
        //            && !doText.Equals("2") && !doText.Equals("3")
        //            && !doText.Equals("4") && !doText.Equals("5")
        //            && !doText.Equals("6") && !doText.Equals("7")
        //            && !doText.Equals("8") && !doText.Equals("9"))
        //        {
        //            return;
        //        }
        //    }


        //    try
        //    {
        //        if (isText)
        //        {

        //            currentTextbox.Text += doText;
        //            if (currentTextbox.Text.Length > 0)
        //            {
        //                currentTextbox.Select(currentTextbox.Text.Length, currentTextbox.Text.Length);
        //                currentTextbox.ScrollToCaret();
        //            }


        //        }
        //        else
        //        {


        //        }
        //    }
        //    catch { }
        //}



        //TextBox currentTextbox;
        //string m_LastPressedButton;
        //int m_charIndex = 0;
        //string newstring = "";
        //string totalstring = "";


        //string m_LastTextbox;
        //private void textBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        //{

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
        //    //tmrPOSUSERTextBox.Enabled = true;

        //    if (pressedButton == "D0")
        //        thisTag = " 0";
        //    if (pressedButton == "D1")
        //        thisTag = "1";
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

        //    if (thisTag == "")
        //        return;



        //    //if (currentTextbox.Name == "txtPONumber")
        //    //{
        //    //    thisTag = thisTag.Replace("0", "");
        //    //    thisTag = thisTag.Replace("1", "");
        //    //    thisTag = thisTag.Replace("2", "");
        //    //    thisTag = thisTag.Replace("3", "");
        //    //    thisTag = thisTag.Replace("4", "");
        //    //    thisTag = thisTag.Replace("5", "");
        //    //    thisTag = thisTag.Replace("6", "");
        //    //    thisTag = thisTag.Replace("7", "");
        //    //    thisTag = thisTag.Replace("8", "");
        //    //    thisTag = thisTag.Replace("9", "");
        //    //}

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
        //        //doPOSUSERTextUpdate(false);

        //        m_LastPressedButton = pressedButton;
        //        buttonChar = thisTag[m_charIndex];
        //        if (newstring.Length == 0)
        //            newstring += buttonChar;
        //        else
        //            newstring = newstring.Substring(0, newstring.Length - 1) + buttonChar;
        //    }

        //    totalstring = TopitUp.Util.str_camel_case(totalstring);

        //    currentTextbox.Text = totalstring + newstring;

        //    if (currentTextbox.Text.Length > 0)
        //    {
        //        currentTextbox.Select(currentTextbox.Text.Length, currentTextbox.Text.Length);
        //        currentTextbox.ScrollToCaret();
        //    }

        //}







      //  private void btnClose_Click(object sender, EventArgs e)
        //{
            //pnlKeypad.Visible = false;
            //pnpCustomerSelector.Show();
            //this.Close();

        //}



        private void btnPrintStoreCopy_Click(object sender, EventArgs e)
        {

            if (payment_slip_toprint.Length > 0)
            {
                String retailer_copy = "";

                retailer_copy += "1\n";
                retailer_copy += "1***********************\n";
                retailer_copy += "1     RETAILER COPY\n";
                retailer_copy += "1***********************\n";

                TopitUp.Util.printText(retailer_copy + payment_slip_toprint , false);
            }
        }

        private void btnCashMxHistory_Click(object sender, EventArgs e)
        {

            //this.Invoke((System.Threading.ThreadStart)delegate
            //{
            //TopitUp.Util.showWait(true);
            //});


            pnlSalesRpt.Top = 0;
            pnlSalesRpt.Left = 0;

            txtCashMsSearch.Text = "";

            cboSyear.Text = DateTime.Today.Year.ToString();
            cboEyear.Text = DateTime.Today.Year.ToString();

            cboSmonth.Text = DateTime.Today.ToString("MMMM");
            cboEmonth.Text = DateTime.Today.ToString("MMMM");

            cboSday.Text = DateTime.Today.Day.ToString();
            cboEday.Text = DateTime.Today.Day.ToString();

            cboSyear.Items.Clear();
            cboEyear.Items.Clear();
            for (int loop = DateTime.Today.Year - 1; loop <= DateTime.Today.Year; loop++)
            {
                cboSyear.Items.Add(loop.ToString());
                cboEyear.Items.Add(loop.ToString());
            }
            cboSyear.Text = DateTime.Today.ToString("yyyy");
            cboEyear.Text = DateTime.Today.ToString("yyyy");

            pnlSalesRpt.Visible = true;
            pnlSalesRpt.BringToFront();

            getCashMsSearch("", "", "");
        }

        private void btnSRClose_Click(object sender, EventArgs e)
        {

            pnlSalesRpt.Visible = false;

        }





        private void getCashMsSearch(string sdate, string edate, string txtCashMsSearch)
        {
            //grdSR.Rows.Clear();

            //TopitUp.Web WebResponse = new TopitUp.Web(45000);
            //String htmlResponse = WebResponse.GetURL("/terminal/cashmx/get-payment-search?sdate=" + sdate + "&edate=" + edate + "&txt=" + txtCashMsSearch);
            //WebResponse = null;

            //if (htmlResponse.IndexOf("err", 0) >= 0)
            //{
            //    showMessage(htmlResponse.StripErrorTags(), true);
            //}
            //else if (htmlResponse != "")
            //{
            //    try
            //    {
            //        string[] lines = htmlResponse.Split('\n');

            //        for (int i = 0; i < lines.Length - 1; i++)
            //        {
            //            string[] items = lines[i].Split('^');
            //            Resco.Controls.SmartGrid.Row r = new Resco.Controls.SmartGrid.Row(6);
            //            r.Height = 30;
            //            r[0] = " " + Convert.ToInt32(items[0].ToString());
            //            r[1] = " " + items[1].ToString();
            //            r[2] = " " + items[2].ToString();
            //            r[3] = String.Format(" R {0:n}", items[3]).Replace(".0", ".00");
            //            r[4] = " " + items[4].ToString();
            //            r[5] = " " + items[5].ToString();
            //            grdSR.Rows.Add(r);
            //        }

            //        int x = lines.Length;
            //        x = x - 1;
            //        showMessage("Total results: " + x.ToString(), false);

            //    }
            //    catch (Exception ex)
            //    {
            //        showMessage(ex.Message, true);
            //    }
            //}
            //else
            //{
            //    showMessage("No results found.", false);
            //}

        }



        

        private void btn_cashms_clear_Click(object sender, EventArgs e)
        {
            if (provider_type == 2)
            {
                txtPONumber.Text = "";
            }

            txtRandValue.Text = "";
            //txtLoadNoPre.Text = "";
            txtLoadNo.Text = "";
            txtDriverNo.Text = "";
            txtDriverCell.Text = "";
            //txtPONumber.Focus();
        }

        private void btnProcessPayment_Click(object sender, EventArgs e)
        {

            if (btnProcessPayment.Text == "Clear")
            {

                btnProcessPayment.BackColor = System.Drawing.Color.Green;
                btn_cashms_clear.Visible = true;
                btnPrintStoreCopy.Visible = false;

                if (provider_type == 2)
                {
                    txtPONumber.Text = "";
                }

                //picRandBg.Visible = true;
                txtRandValue.Text = "";
                txtLoadNo.Text = "";
                txtDriverNo.Text = "";
                txtDriverCell.Text = "";

                //txtLoadNoPre.Text = TopitUp.globalSettings.cashms_depot_prefix;
                //txtPONumber.Text = TopitUp.globalSettings.cashms_customer_number;


                pnlComplete.Visible = false;

                //pnlKeypad.Visible = true;
                //keyb_shown_full = true;

                btnProcessPayment.Text = "Process Payment";
                return;
            }


            if (txtRandValue.Text == "")
            {
                showMessage("Please enter a payment amount.", Color.Red);
                txtRandValue.Enabled = true;
                txtRandValue.Focus();
                return;
            }



            string value = txtRandValue.Text.Replace(".", "");

            //           if (Convert.ToInt32(value) > 2000000)
            //         {
            //           Util.showMessage("Amount entered is too high.", false);
            //         txtRandValue.Enabled = true;
            //       txtRandValue.Focus();
            //     return;
            //}


            if (provider_type == 2)
            {

                if (txtPONumber.Text.Length < 2)
                {
                    showMessage("Please check the customer number!", Color.Red);
                    txtPONumber.Enabled = true; txtPONumber.Focus(); return;
                }

            }

            if (provider_type == 1)
            {

                if (txtPONumber.Text.Length != 6)
                {
                    showMessage("Please check the customer number!", Color.Red);
                    txtPONumber.Enabled = true; txtPONumber.Focus(); return;
                }

                if (txtLoadNoPre.Text.Length != 3)
                {
                    showMessage("Please check the load prefix!", Color.Red);
                    txtLoadNoPre.Enabled = true; txtLoadNoPre.Focus(); return;
                }
                if (txtLoadNo.Text.Length != 6)
                {
                    showMessage("Please check the load number!", Color.Red);
                    txtLoadNo.Enabled = true; txtLoadNo.Focus(); return;
                }
                if (txtDriverNo.Text.Length != 4)
                {
                    showMessage("Please check your driver number!", Color.Red);
                    txtDriverNo.Enabled = true; txtDriverNo.Focus(); return;
                }
                if (txtDriverCell.Text.Length != 10)
                {
                    showMessage("Please check the cell number!", Color.Red);
                    txtDriverCell.Enabled = true; txtDriverCell.Focus(); return;
                }

            }


            //if (!lblNoPaper.Visible)
            //{
            //    if (TopitUp.globalSettings.gen_ignore_paper == "0")
            //    {
            //        if (TopitUp.Util.checkPrinterState() == 1)
            //        {
            //            lblNoPaper.Show();
            //            return;
            //        }
            //    }
            //}

            lblNoPaper.Hide();

            String htmlResponse = "";
            String storeno = txtPONumber.Text;
            String loadno = txtLoadNoPre.Text + txtLoadNo.Text;
            String driverno = txtDriverNo.Text;
            String drivercell = txtDriverCell.Text;

            TopitUp.Web WebResponse = new TopitUp.Web(60000, 1, "");
            htmlResponse = WebResponse.GetURL("/terminal/cashmx/account-payment?ptype=" + provider_type + "&storeno=" + storeno + "&loadno=" + loadno + "&driverno=" + driverno + "&drivercell=" + drivercell + "&amt=" + value);
            WebResponse = null;

            if (htmlResponse.IndexOf("err") > -1)
            {

                showMessage(htmlResponse.StripErrorTags(), Color.Red);

            }
            else
            {

                btnPrintStoreCopy.Visible = true;

                //picRandBg.Visible = false;
                btn_cashms_clear.Visible = false;

                pnlComplete.Visible = true;

                String driver_copy = "";

                driver_copy += "1\n";
                driver_copy += "1***********************\n";
                driver_copy += "1      DRIVER COPY\n";
                driver_copy += "1***********************\n";

                payment_slip_toprint = htmlResponse;

                TopitUp.Util.printText(driver_copy + payment_slip_toprint ,false);

                btnProcessPayment.Text = "Clear";
                btnProcessPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));

                //pnlKeypad.Visible = false;
                //keyb_shown_full = false;

            }




        }

        private void btnPrintStoreCopy_Click_1(object sender, EventArgs e)
        {

            if (payment_slip_toprint.Length > 0)
            {
                String retailer_copy = "";

                retailer_copy += "1\n";
                retailer_copy += "1***********************\n";
                retailer_copy += "1     RETAILER COPY\n";
                retailer_copy += "1***********************\n";

                TopitUp.Util.printText(retailer_copy + payment_slip_toprint, false);


                lblProcessedOk.Text = "Store copy printed.";

            }
        }


        private void btnSRReprint_Click(object sender, EventArgs e)
        {

            int _reprint_uid = 0;

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
        //        showMessage("Please select a payment!", Color.Red);
        //        return;
        //    }

            btnSRReprint.Enabled = false;

        //    String htmlResponse = "";

        //    TopitUp.Web WebResponse = new TopitUp.Web(60000, 1, "");
        //    htmlResponse = WebResponse.GetURL("/terminal/cashmx/account-payment-reprint?uid=" + _reprint_uid);
        //    WebResponse = null;

        //    if (htmlResponse.IndexOf("err") > -1)
        //    {

        //        showMessage(htmlResponse.StripErrorTags(), Color.Red);

        //    }
        //    else
        //    {

        //        String driver_copy = "";

        //        driver_copy += "1\n";
        //        driver_copy += "1***********************\n";
        //        driver_copy += "1      DRIVER COPY\n";
        //        driver_copy += "1***********************\n";

        //        String retailer_copy = "";

        //        retailer_copy += "1\n";
        //        retailer_copy += "1***********************\n";
        //        retailer_copy += "1     RETAILER COPY\n";
        //        retailer_copy += "1***********************\n";

        //        TopitUp.Util.printText(driver_copy + htmlResponse + retailer_copy + htmlResponse, false);

        //    }

            btnSRReprint.Enabled = true;

        }

        private void btnSRFilter_Click_1(object sender, EventArgs e)
        {
            btnSRFilter.Enabled = false;

            String sDate = cboSyear.Text + "-" + DateTime.ParseExact(cboSmonth.Text, "MMMM", System.Globalization.CultureInfo.CurrentCulture).Month.ToString().PadLeft(2, '0') + "-" + cboSday.Text.ToString().PadLeft(2, '0');
            String eDate = cboEyear.Text + "-" + DateTime.ParseExact(cboEmonth.Text, "MMMM", System.Globalization.CultureInfo.CurrentCulture).Month.ToString().PadLeft(2, '0') + "-" + cboEday.Text.ToString().PadLeft(2, '0');

            getCashMsSearch(sDate, eDate, txtCashMsSearch.Text);
            //getCashMsSearch(sDate, eDate, "");

            btnSRFilter.Enabled = true;

        }

        private void btnCloseMain_Click(object sender, EventArgs e)
        {

            this.Close();
        }


        int provider_type = 0;

        private void btnProvider1_Click(object sender, EventArgs e)
        {

            provider_type = 1;

            txtPONumber.Text = "";
            //txtPONumber.Enabled = false;
            lblDescription.Text = "Peninsula Beverages";
            lblload.Visible = true;
            lblload2.Visible = true;
            txtLoadNoPre.Visible = true;
            txtLoadNo.Visible = true;
            lbldrivercell.Visible = true;
            txtDriverCell.Visible = true;
            lbldriver1.Visible = true;
            lbldriver2.Visible = true;
            txtDriverNo.Visible = true;

            pnpCustomerSelector.Hide();

          //  start_delayed_load("get_customer_information", 500);

            //pnlKeypad.Visible = true;
            //pnlKeypad.BringToFront();


        }

        private void btnProvider2_Click(object sender, EventArgs e)
        {

            provider_type = 2;


            txtPONumber.Text = "";
            txtPONumber.Enabled = true;
            lblDescription.Text = "Digital Food and Beverage";
            lblload.Visible = false;
            lblload2.Visible = false;
            txtLoadNoPre.Visible = false;
            txtLoadNo.Visible = false;
            lbldrivercell.Visible = false;
            txtDriverCell.Visible = false;
            lbldriver1.Visible = false;
            lbldriver2.Visible = false;
            txtDriverNo.Visible = false;

            pnpCustomerSelector.Hide();

            //pnlKeypad.Visible = true;
            //pnlKeypad.BringToFront();

        }









        List<String> missingImages = new List<String>();

        private Bitmap imageCheckOnly(String image_file_name)
        {

            Bitmap bm = null;

            try
            {

                if (System.IO.File.Exists(image_file_name))
                {
                    bm = new Bitmap(image_file_name);
                }
                else
                {
                    missingImages.Add(image_file_name);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //showMessage(ex.Message, true);
            }

            return bm;

        }


        private void tmr_download_images_Tick(object sender, EventArgs e)
        {

        }


        private void download_image(String image_file_name)
        {

            //try
            //{

            //    if (System.IO.File.Exists(image_file_name))
            //    {
            //        // Ok we found the file ? odd...
            //    }
            //    else
            //    {

            //        showMessage("Updating Image...", Color.Red);

            //        String file_url = image_file_name.Replace(TopitUp.globalSettings.app_path + @"\images\", "/updates/img_terminal/");

            //        Web WebResponse = new Web(50000);
            //        bool dl_ok = WebResponse.GetURLSoftwareUpdate(file_url, image_file_name);
            //        WebResponse = null;

            //        if (dl_ok)
            //        {
            //            showMessage("Image Updated.", Color.Red);
            //        }
            //        else
            //        {
            //            showMessage("Image NOT Updated!", Color.Red);
            //        }

            //    }

            //}
            //catch (Exception ex)
            //{
            //    showMessage(ex.Message, Color.Red);
            //}

        }


        private void numericTextBox_LostFocus(object sender, EventArgs e)
        {
            decimal amount = 0.0m;

            try
            {
                amount = Decimal.Parse(txtRandValue.Text.Replace(",", ""), System.Globalization.CultureInfo.InvariantCulture);
                txtRandValue.Text = String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:0.00}", amount);
            }
            catch
            {
                //
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


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }
    }


    static public class Util2
    {
        public static string StripErrorTags(this string value)
        {
            string ret = "";

            if (value.IndexOf("<webreqerr>") > -1)
            {
                ret = value.GetStrBetweenTags("<webreqerr>", "</webreqerr>");
            }
            else if (value.IndexOf("<err>") > -1)
            {
                ret = value.GetStrBetweenTags("<err>", "</err>");
            }
            else if (value.IndexOf("\"err\"") > -1)
            {
                ret = value.GetStrBetweenTags("{\"err\":\"", "\"}");
            }
            else
            {
                ret = value;
            }

            return ret;
        }
        public static string GetStrBetweenTags(this string value, string startTag, string endTag)
        {
            if (value.Contains(startTag) && value.Contains(endTag))
            {
                int index = value.IndexOf(startTag) + startTag.Length;
                return value.Substring(index, value.IndexOf(endTag) - index);
            }
            else
                return null;
        }
    }






    
}

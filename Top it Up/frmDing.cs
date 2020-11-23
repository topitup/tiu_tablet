using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Xml;
using System.Linq;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace TopitUp
{

    public partial class frmDing : Form
    {

        //private System.Windows.Forms.TextBox _hidden_key_capture = new System.Windows.Forms.TextBox();

        private string _currentMeterNo = "";
        private string _currentElecRandValue = "0";
        int _ignorelicenselevel = 0;
        public static int RVal = 0;
        string vending_type = "";
        string _tov = "";
 
        string _elecVoucherStockUid = "";
        string _elecVoucher = "";
        bool _elecConfirmed = false;

        String[] vouchers = new String[50];
        String voucher;
        String voucherName;
        String[] voucherdesc = new String[50];
        String Network;
        String strResp;
        String amount;
        String denomination = "true";
        String textPrefix = "91";
        public Button newPanelButton = new Button();


        [DllImport("Coredll.dll", SetLastError = true)]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("coredll.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        //string newstring = "";
        //string totalstring = "";

        //string m_LastTextbox;
        //string m_LastPressedButton;
        //int m_charIndex = 0;

        //TextBox currentTextbox;

        //bool _loading = true;


        public frmDing()
        {
            InitializeComponent();
        
            //try
            //{
            //    this._hidden_key_capture.Parent = this;
            //    this._hidden_key_capture.AcceptsReturn = true;
            //    this._hidden_key_capture.AcceptsTab = true;
            //    this._hidden_key_capture.Bounds = new Rectangle(-1, -1, 1, 1);
            //    this._hidden_key_capture.MaxLength = 4;
            //    this._hidden_key_capture.Name = "_hidden_key_capture";
            //    this._hidden_key_capture.TabIndex = 1;
            //    this._hidden_key_capture.KeyDown += new System.Windows.Forms.KeyEventHandler(this._hidden_key_capture_KeyDown);
            //}
            //catch
            //{
            //    //
            //}

        }


        private void reqElectricity_Load(object sender, EventArgs e)
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

            if (globalSettings.gen_virtual_keyboard == "1")
            {
                pnlKeyboard.Visible = true;
                virtualKeyboard1.showKeyPadPoint();
            }
            else
            {
                pnlKeyboard.Visible = false;
            }


            //txtRandValue.Enabled = false;

            btnOK.Text = "Next";

            if (globalSettings.elec_preset_enabled == "0")
            {
                pnlSetValues.Visible = false;
            }
            else
            {
                btnElecSetValue1.Text = "R " + globalSettings.elec_preset_val1;
                btnElecSetValue2.Text = "R " + globalSettings.elec_preset_val2;
                btnElecSetValue3.Text = "R " + globalSettings.elec_preset_val3;
                btnElecSetValue4.Text = "R " + globalSettings.elec_preset_val4;

                btnElecSetValue1.Tag = globalSettings.elec_preset_val1;
                btnElecSetValue2.Tag = globalSettings.elec_preset_val2;
                btnElecSetValue3.Tag = globalSettings.elec_preset_val3;
                btnElecSetValue4.Tag = globalSettings.elec_preset_val4;

                btnElecSetValue1.Click += new System.EventHandler(doBtnElecSet_Click);
                btnElecSetValue2.Click += new System.EventHandler(doBtnElecSet_Click);
                btnElecSetValue3.Click += new System.EventHandler(doBtnElecSet_Click);
                btnElecSetValue4.Click += new System.EventHandler(doBtnElecSet_Click);

            }

            btnMulti2.Click += new System.EventHandler(doBtnMulti_Click);
            btnMulti3.Click += new System.EventHandler(doBtnMulti_Click);
            btnMulti4.Click += new System.EventHandler(doBtnMulti_Click);
            btnMulti5.Click += new System.EventHandler(doBtnMulti_Click);
            btnMulti6.Click += new System.EventHandler(doBtnMulti_Click);
            btnMulti7.Click += new System.EventHandler(doBtnMulti_Click);
            btnMulti8.Click += new System.EventHandler(doBtnMulti_Click);

            SetupGetSavedMeters();

            this.wbInfo.Bounds = new Rectangle(0, 80, 855, 320);
          
                this.wbInfo.Url = new Uri("file://c:/topitup/html/dingMessage.htm");
       

            wbInfo.BringToFront();
            wbInfo.Show();

            btnClose.BringToFront();
            btnOK.BringToFront();

            //picSwipeImage.Image = new Bitmap(globalSettings.app_path + @"\images\elec_swipe_card.gif");

            try
            {
                picRandBg.Image = new Bitmap(globalSettings.app_path + @"\images\elec_rand.gif");
                //picMultiBackground.Image = new Bitmap(globalSettings.app_path + @"\images\elec_multi.gif");
            } catch {
                //
            }


            

            //btnElecSetValue1.Image = new Bitmap(globalSettings.app_path + @"\images\elec_set_value.gif");
            //btnElecSetValue1.ImagePressed = btnElecSetValue1.ImageDefault;
            //btnElecSetValue2.Image = btnElecSetValue1.Image;
            //btnElecSetValue2.ImagePressed = btnElecSetValue1.ImageDefault;
            //btnElecSetValue3.Image = btnElecSetValue1.Image;
            //btnElecSetValue3.ImagePressed = btnElecSetValue1.ImageDefault;
            //btnElecSetValue4.Image = btnElecSetValue1.Image;
            //btnElecSetValue4.ImagePressed = btnElecSetValue1.ImageDefault;

            globalVoucher.Clear();

            //Util.SetCursor(Screen.PrimaryScreen.Bounds.Width, 0);

            //btnClose.Image = Util.btngeneral1;
            //btnClose.ImagePressed = Util.btngeneral0;
            //btnOK.Image = Util.btngeneral4;
            //btnOK.ImagePressed = Util.btngeneral0;
            //btnFaultReport.Image = Util.btngeneral2;
            //btnFaultReport.ImagePressed = Util.btngeneral0;
            //btnFreeElec.Image = Util.btngeneral1;
            //btnFreeElec.ImagePressed = Util.btngeneral0;

    

            //this.txtRandValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            //this.txtElecMeterNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);

          
            this.ResumeLayout();
            
            Util.showWait(false);

            this.Activate();

            txtElecMeterNo.Focus();

        }


        private void SetupGetSavedMeters()
        {

            if (globalSettings.saved_meter_1.Length > 0)
            {
                btnGetMeter1.Text = globalSettings.saved_meter_1;
                lblGetMeter1.Text = globalSettings.saved_meter_1_desc;
            }
            else
            {
                btnGetMeter1.Text = ""; lblGetMeter1.Text = "";
            }

            if (globalSettings.saved_meter_2.Length > 0)
            {
                btnGetMeter2.Text = globalSettings.saved_meter_2;
                lblGetMeter2.Text = globalSettings.saved_meter_2_desc;
            }
            else
            {
                btnGetMeter2.Text = ""; lblGetMeter2.Text = "";
            }

            if (globalSettings.saved_meter_3.Length > 0)
            {
                btnGetMeter3.Text = globalSettings.saved_meter_3;
                lblGetMeter3.Text = globalSettings.saved_meter_3_desc;
            }
            else
            {
                btnGetMeter3.Text = ""; lblGetMeter3.Text = "";
            }

            if (globalSettings.saved_meter_4.Length > 0)
            {
                btnGetMeter4.Text = globalSettings.saved_meter_4;
                lblGetMeter4.Text = globalSettings.saved_meter_4_desc;
            }
            else
            {
                btnGetMeter4.Text = ""; lblGetMeter4.Text = "";
            }

            if (globalSettings.saved_meter_5.Length > 0)
            {
                btnGetMeter5.Text = globalSettings.saved_meter_5;
                lblGetMeter5.Text = globalSettings.saved_meter_5_desc;
            }
            else
            {
                btnGetMeter5.Text = ""; lblGetMeter5.Text = "";
            }

        }


        private void doBtnMulti_Click(object sender, EventArgs e)
        {
            Button btnClick = (Button)sender;

            lblCost.Width = 395;
            lblCost.TextAlign = ContentAlignment.TopRight;

            globalVoucher.request_qty = Int32.Parse(btnClick.Tag.ToString());
            
            decimal cost_total = globalVoucher.request_qty * globalVoucher.voucher_value;

            lblTotalCost.Text = "x " + globalVoucher.request_qty.ToString() + " = " + String.Format("R {0:n}", cost_total);
            lblTotalCost.Visible = true;

        }




        private void doBtnElecSet_Click(object sender, EventArgs e)
        {
            Button btnClick = (Button)sender;
            txtRandValue.Text = btnClick.Tag.ToString() + ".00";
            btnOKClick();
        }

     
       
        private void showMsgAction(string msg, Color txtColor)
        {

            this.SuspendLayout();

            if (msg == "")
            {
                lblStatus2.Hide();
                return;
            }

            lblStatus2.ForeColor = txtColor;
            lblStatus2.Text = msg;
            lblStatus2.Show();

            this.ResumeLayout();
            this.Refresh();

            Application.DoEvents();

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


        private void RetOk()
        {
            this.Close();
        }


        private bool IsVoucherOk(string retWS)
        {

            showMsg("", 0, Color.Firebrick);

            _elecVoucherStockUid = "0";
            _elecVoucher = "";

            try
            {

                int rowCount = 0;
                string[] toSplit = retWS.Split("\n".ToCharArray());
                foreach (string s in toSplit)
                {
                    rowCount++;
                    if (rowCount == 1)
                    {

                        char[] del = new char[] { '=', '^' };
                        string[] tokens = s.Split(del);

                        for (int token = 0; token < tokens.Length; token += 2)
                        {
                            string s1 = tokens[token];
                            string s2 = tokens[token + 1];

                            if (s1 == "uid")
                            {
                               // AppSettings.lastVoucherUID = s2;
                                _elecVoucherStockUid = s2;
                                globalVoucher.stock_uid = s2;
                                globalVoucher.serial_number = _currentMeterNo;
                                
                            }

                            if (s1 == "l")
                                if (s2 == "1")
                                    finBalance.low_balance = "1";
                                else
                                    finBalance.low_balance = "0";

                            if (s1 == "dtm")
                            {
                                // AppSettings.lastVoucherUID = s2;
                                globalVoucher.tx_date = s2;
                            }

                        }

                    }
                    else
                    {
                        _elecVoucher += "\n" + s;
                    }
                }

                return true;

            }
            catch
            {
                return false;
            }


        }



        private void ConfirmElectricityToken()
        {

            _elecConfirmed = false;
            //_confirmationCount++;

            if (_tokenRequestRetryCount >= 6)
            {
                //CancelVoucherRequest("Could not confirm electricity token.");
                return;
            }

            showMsg(Environment.NewLine + "Confirming Token, please wait....", 1, Color.DarkRed);
            showMsgAction("Do not turn machine off!", Color.Firebrick);

            if (_tokenRequestRetryCount > 1)
            {
                Application.DoEvents();
                Thread.Sleep(5000);
            }

            //}
            //else
            //{

            //    if (_tokenRequestRetryCount == 1 || _tokenRequestRetryCount == 2)
            //    {
            //        showMsg("Confirming Token, retrying, please wait....", 1, Color.DarkRed);
            //        showMsgAction("Do not turn machine off!", Color.Firebrick);

            //        Application.DoEvents();

            //        Thread.Sleep(5000);
            //    }

            //    //if (_tokenRequestRetryCount == 3 || _tokenRequestRetryCount == 6)
            //    //{
            //    //    showMsg("Confirming Token, re-connecting, please wait....", 1, Color.DarkRed, 90, 50, "", "Do not turn machine off!");
            //    //    Application.DoEvents();

            //    //    Util.ConnectionStatus = 1;
            //    //    Program.tiuMain.gprsHangup();
            //    //    Program.tiuMain.update_connection_status("Reconnect");
            //    //    Program.tiuMain.gprsDial(false);
            //    //    Thread.Sleep(1000);
            //    //}


            //    if (_tokenRequestRetryCount == 3)
            //    {
            //        showMsg("Confirming Token, restarting connection, please wait....", 1, Color.DarkRed);
            //        showMsgAction("Do not turn machine off!",Color.Firebrick);
            //        Application.DoEvents();

            //        Util.ConnectionStatus = 1;
            //        //Program.tiuMain.update_connection_status("Reset Modem");
            //        //Program.tiuMain.gprsReboot();
            //        //Program.tiuMain.update_connection_status("Reconnect");
            //        //Program.tiuMain.gprsDial(false);
            //        Thread.Sleep(1000);
            //    }

            //    if (_tokenRequestRetryCount == 4 || _tokenRequestRetryCount == 5)
            //    {
            //        showMsg("Confirming Token, please wait....", 1, Color.DarkRed);
            //        showMsgAction("Do not turn machine off!", Color.Firebrick);
            //        Application.DoEvents();

            //        Thread.Sleep(5000);
            //    }

            //}

            string wsRes = MakeWebRequest("/itron/electricity/vendConfirmBalance?uid=" + _elecVoucherStockUid + "&lic=" + globalSettings.license_code, 35000);
            
            if (wsRes.IndexOf("OK=1") > -1)
            {
                try
                {
                    char[] del = new char[] { '=', '^' };
                    string[] tokens = wsRes.Split(del);

                    for (int token = 0; token < tokens.Length; token += 2)
                    {
                        string s1 = tokens[token];
                        string s2 = tokens[token + 1];

                        if (s1 == "b")
                        {
                            finBalance.available_balance = s2;
                        }
                    }
                }
                catch
                {
                    //
                }

                _elecConfirmed = true;

            } 
            else if (wsRes.IndexOf("<webreqerr>", 0) >= 0)
            {
                ConfirmElectricityToken();
            }
            else if (wsRes.IndexOf("ERR:") > -1)
            {
                //CancelVoucherRequest(wsRes);
            }

           
        }


        bool _isPrinted = false;

        private void PrintElectricityToken()
        {

            if (globalVoucher.request_qty == 1)
            {
                showMsg(Environment.NewLine + "Printing Electricity Token", 1, Color.Black);
            }
            else
            {
                showMsg(Environment.NewLine + "Printing Electricity Token " + globalVoucher.request_qty_current.ToString() + "/" + globalVoucher.request_qty.ToString(), 1, Color.Black);
            }
            showMsgAction("", Color.Firebrick);

            if (globalSettings.gen_cashdr == "1")
            {
                //Util.OpenCashDrawer();
                Util.DoOpenCashDrawer = true;
            }

            if (globalVoucher.request_qty > 1)
            {
                _elecVoucher += "2    " + globalVoucher.request_qty_current.ToString() + " of " + globalVoucher.request_qty.ToString() + Environment.NewLine;
            }


            bool _print_ok = Util.printElectricitySlip(_elecVoucher);


            if (!_print_ok)
            {
                globalVoucher.clearLastSaleDetail();

                showMsgAction("Please confirm that the voucher has printed correctly." + Environment.NewLine + "Or use sales history/reprint to reprint last request.", Color.Firebrick);

                this.btnClose.Text = "Close";
                this.btnClose.Show();

                _voucherRequestError = true;

                return;
            }
            
            _isPrinted = true;

            if (!globalSettings.gen_show_voucher_only.Equals("1")) Thread.Sleep(1500);

            if (globalSettings.gen_show_last_sale_login == "1")
            {
                try
                {

                    globalVoucher.tx_date = globalVoucher.tx_date.Replace("  ", " ");

                    String _date_dtm = globalVoucher.tx_date.Split(' ')[0];
                    String _date_time = globalVoucher.tx_date.Split(' ')[1];

                    globalVoucher.setLastSaleDetail("Electricity, " + _currentMeterNo,"R " + _currentElecRandValue, globalSettings.pos_user_firstname, "", _date_dtm, _date_time);
                }
                catch
                {
                    globalVoucher.clearLastSaleDetail();
                }
            }

        }





        private void ShowElecStart()
        {

            globalVoucher.Clear();
            lblNetworkDeno.Text = "";
            pnlAirtime.Controls.Clear();

            pnlNonDeno.Hide();
            //vouchers.Clear();
            /*   Array.Clear(vouchers, 0, vouchers.Length);
               Array.Clear(voucherdesc, 0, voucherdesc.Length);
               voucher.Equals("");
               voucherName.Equals("");

               Network.Equals(""); 

       amount.Equals("");
               */

            this.SuspendLayout();
            pnlTxn.Hide();

            lblmunicipality.Visible = false;
            lblmunicipality.Text = "";
       
            btnOK.Show();
      
            //btnFreeElec.Hide();
            pnlSavedMeters.Hide();
            lblCost.Hide();
            pnlCapture.Height = 75;
            pnlAirtime.Hide();
            pnlAmount.Hide();
            btnSaveMeter.Visible = false;

     
            txtElecMeterNo.Enabled = true;
            txtElecMeterNo.Text = "";
            _currentMeterNo = "";

            lblTotalCost.Visible = false;
          

            //  btnFreeElec.TextDefault = "My" + Environment.NewLine + "Meters";
            //  btnFreeElec.Visible = true;

            showMsg("", 0, Color.Black);
            showMsgAction("", Color.Firebrick);

            txtRandValue.Text = "";
            // txtRandValue.Enabled = false;
            btnClearValue.Visible = false;

          
            cmdElecrtraClear.Visible = true;

            wbInfo.Show();

            txtElecMeterNo.Focus();

            this.ResumeLayout(false);
        }


        String _meter_detail_to_save = "";


        //global airtime
        private void populateVoucher()
        {

            showMsg("", 0, Color.Gray);
            showMsgAction("Requesting Vouchers Please Wait...", Color.Gray);

            _meter_detail_to_save = "";

            string retWS = MakeWebRequest("/ding/connect/get-vouchers?lic=" + globalSettings.license_code + "&posuser=" + globalSettings.pos_user_id + "&phonenum=" + _currentMeterNo, 45000);


            _tov = "";

            bool retError = retWS.IndexOf("ERR:") > -1;

            if (retError == false)
            {

                string strName = "";
                string strUtility = "";
                string strAddress = "";
                string strPending = "0";
                string strExtra = "";
                string strMaxVend = "";

                string fC = "FFFFFF";
                string bC = "B22222";
                lblNetworkDeno.Text = "";

                try
                {
                    string xml = retWS;
                    XmlDocument doc = new XmlDocument();
                    if (xml.Contains("ipayMsg"))
                    {
                        doc.LoadXml(retWS);
                        XmlNode currNode = doc.DocumentElement.FirstChild;
                        XmlNode nextNode = currNode.ChildNodes[0];
                        //Console.WriteLine(nextNode.OuterXml);
                        XmlNode nextNode1 = nextNode.ChildNodes[0];

                        //Console.WriteLine(nextNode1.InnerText);
                        XmlNode nextNode2 = nextNode.ChildNodes[1];
                        if (nextNode2.InnerText.Equals("OK"))
                        {
                            showMsgAction("", Color.Black);

                            XmlNode networkInfo = nextNode.ChildNodes[3];
                            Network = networkInfo.Attributes["network"].Value;
                            //Console.WriteLine("\r\nNetwork=" + Network);
                            //  MessageBox.Show("Network=" + Network);
                            //  String msg = "";
                            //   msg = "Name   : " + strName.Replace(",null", "");
                            //  msg += "\nAddress: " + strAddress.Replace(",null", "");
                            //msg += "\nMeter: " + txtElecMeterNo.Text;

                            // lblmunicipality.ForeColor = Util.HexToColor(fC);
                            //  lblmunicipality.BackColor = Util.HexToColor(bC);
                            // lblmunicipality.Text = "Network : " + Network;
                            // lblmunicipality.Show();





                            XmlNodeList xnList = nextNode.SelectNodes("tokenTypeInfo");

                            //for non deno
                            if (xnList[0].Attributes["isDenominated"].InnerText.Equals("false"))
                            {
                                pnlAirtime.Hide();
                                pnlNonDeno.Location = new Point(0, 130);
                                pnlWrapper.SendToBack();
                                pnlNonDeno.BringToFront();
                               voucherName = xnList[0].Attributes["tokenType"].InnerText;
                                pnlNonDeno.Show();

                                lblndCountry.Text = voucherName;
                                txtRandValue.Enabled = true;
                                //MessageBox.Show("test");
                                txtRandValue.Focus();
                                txtRandValue.Show();
                                denomination = "false";
                                lblNetworkDeno.Text = "Network : " + Network;
                            }
                            else
                            {
                                denomination = "true";
                                pnlNonDeno.Hide();
                                pnlAirtime.BringToFront();
                                int i = 1;
                                // int basex = 16;
                                int basex = 50;
                                /// int basey = 15;
                                /// 
                                int basey = 35;
                                vouchers = new String[50];
                                voucherdesc = new String[50];
                                // manoj
                                foreach (XmlNode node in xnList)
                                {

                                    //SetupNewItemButton(0, 19, 5);
                                    //Console.WriteLine("\r\n" + node.OuterXml);
                                    //  MessageBox.Show(node.InnerText);
                                    // Create a Button object 
                                    vouchers[i] = node.OuterXml;
                                    newPanelButton = new Button();
                                    // b.Width = 370;
                                    // b.Height = 90;
                                    newPanelButton.Width = 325;
                                    newPanelButton.Height = 60;

                                    newPanelButton.BackColor = Color.White;
                                    newPanelButton.ForeColor = Color.FromArgb(0, 118, 163);
                                    newPanelButton.Click += new System.EventHandler(this.btnCurExc_Click);
                                    newPanelButton.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);

                                    //  b.FlatAppearance.BorderColor = Color.FromArgb(0, 118, 163);
                                    // b.FlatAppearance.BorderSize = 3;
                                    newPanelButton.Tag = i;
                                    newPanelButton.Location = new System.Drawing.Point(basex, basey);
                                    //manoj
                                    newPanelButton.Name = String.Format("v", i + 1);
                                    String vouc = node.InnerText;
                                    voucherdesc[i] = node.InnerText;
                                    string[] words = vouc.Split('(');
                                    // String vouc = node.InnerText.Replace("(", Environment.NewLine + "(");
                                    //MessageBox.Show(words[0]);
                                    newPanelButton.Text = String.Format(words[0]);

                                    pnlAirtime.Controls.Add(newPanelButton);
                                    // btnElecSetValue1.Text = node.InnerText;
                                    // btnElecSetValue1.TextDefault = node.InnerText;
                                    // btnElecSetValue1.Tag = node.InnerText;
                                    //Console.WriteLine("\r\n" + node.InnerText);
                                    // MessageBox.Show(node.InnerText);
                                    // MessageBox.Show("i="+i % 2);
                                    if (i % 2 == 0)
                                    {
                                        // basey += 120;
                                        basey += 80;
                                        // basex = 16;
                                        basex = 50;

                                    }
                                    else
                                    {

                                        basey += 2;
                                        //basex += 385;
                                        basex += 375;
                                    }
                                    i++;
                                }
                                lblNetworkDeno.Text = "Network : " + Network + "       Total Vouchers:" + (i - 1) + "\n (Please Scroll down more vouchers)";
                                // lblTotalVouchers.Text = "Total Vouchers:" + (i - 1) + "\n Please Scroll down more vouchers";
                                pnlAirtime.Location = new Point(0, 130);
                                pnlAirtime.Show();
                            }

                        }
                    }

                }
                catch
                {

                    showMsgAction("There was a problem retrieving the vouchers." + Environment.NewLine + "Please try again later.", Color.Firebrick);

                    btnOK.Show();

                    //txtRandValue.Enabled = false;
                    txtElecMeterNo.Enabled = true;
                    txtElecMeterNo.Focus();

                    btnSaveMeter.Visible = false;

                    return;
                }

                // txtRandValue.Enabled = true;
                //txtRandValue.Enabled = false;
                if (!strPending.Equals("0", StringComparison.Ordinal))
                {

                    txtRandValue.Text = strPending;
                    // txtRandValue.Enabled = false;


                    /*  String msg = "";
                      msg = "Name   : " + strName.Replace(",null", "");
                      msg += "\nAddress: " + strAddress.Replace(",null", "");
                      //msg += "\nMeter: " + txtElecMeterNo.Text;
                      //msg += "\nUtility: " + strUtility;

                      lblmunicipality.ForeColor = Util.HexToColor(fC);
                      lblmunicipality.BackColor = Util.HexToColor(bC);
                      lblmunicipality.Text = strUtility;
                      lblmunicipality.Show();

                      if (globalSettings.elec_max_vend_show == "1" && strMaxVend.Length > 0)
                      {
                          msg += "\nMaximum Vend Amount: " + strMaxVend;
                      }

                      showMsg(msg, 0, Color.Black);
                      showMsgAction("R " + strPending + ".00 pending voucher available.", Color.FromArgb(130, 203, 51));

                      pnlSetValues.Visible = false;
                      btnClearValue.Visible = true;*/

                }
                else
                {
                    String msg = "";
                    /*    msg = "Name   : " + strName.Replace(",null", "");
                        msg += "\nAddress: " + strAddress.Replace(",null", "");
                        //msg += "\nMeter: " + txtElecMeterNo.Text;

                        lblmunicipality.ForeColor = Util.HexToColor(fC);
                        lblmunicipality.BackColor = Util.HexToColor(bC);
                        lblmunicipality.Text = strUtility;
                        lblmunicipality.Show();

                        //msg += "\nUtility: " + strUtility;
                        if (strExtra.Length > 0) msg += "\n" + strExtra;

                        if (globalSettings.elec_max_vend_show == "1" && strMaxVend.Length > 0)
                        {
                            msg += "\nMaximum Vend Amount: " + strMaxVend;
                        }

                        showMsg( msg , 0, Color.Black);
                        showMsgAction("", Color.Gray);

                        pnlSetValues.Visible = true;*/

                }
                pnlSetValues.Visible = false;
               // btnClose.TextDefault = "Back";
                // btnOK.TextDefault = "OK";

                pnlAmount.Hide();
                pnlTxn.Hide();


                // btnOK.Show();

                //  btnFreeElec.TextDefault = "Get Free" + Environment.NewLine + "Tokens";
                //  btnFreeElec.Show();
                // btnFreeElec.Refresh();

                btnClose.Show();

                // txtRandValue.Enabled = true;
                //  txtRandValue.Focus();
                //  txtRandValue.Show();

                //  pnlCapture.Height = 155;

            }
            else
            {

                showMsg(retWS.Replace("ERR:", ""), 1, Color.Firebrick);
                showMsgAction("The request was not successful.", Color.Black);

                //txtRandValue.Enabled = false;
              //  btnOK.TextDefault = "Next";
                btnOK.Show();
            }

        }




        private void StepGetAddressDetails()
        {

            showMsg("Please wait",1, Color.Gray);
            showMsgAction("Requesting Address Details...", Color.Gray);

            _meter_detail_to_save = "";

            string retWS = MakeWebRequest("/itron/electricity/custInfoReq?lic=" + globalSettings.license_code + "&m=" + _currentMeterNo + _tov, 45000);

            _tov = "";

            bool retError = retWS.IndexOf("ERR:") > -1;

            if (retError == false)
            {

                string strName = "";
                string strUtility = "";
                string strAddress = "";
                string strPending = "0";
                string strExtra = "";
                string strMaxVend = "";

                string fC = "FFFFFF";
                string bC = "B22222";

                try
                {
                    char[] del = new char[] { '=', '^' };
                    string[] tokens = retWS.Split(del);

                    for (int token = 0; token < tokens.Length; token += 2)
                    {
                        string s1 = tokens[token];
                        string s2 = tokens[token + 1];

                        if (s1 == "name")       strName = s2;
                        if (s1 == "address")    strAddress = s2;
                        if (s1 == "utility")    strUtility = s2;
                        if (s1 == "extra")      strExtra = s2;
                        if (s1 == "p")          strPending = s2;
                        if (s1 == "max")        strMaxVend = s2;

                        if (s1 == "fc") fC = s2;
                        if (s1 == "bc") bC = s2;

                        if (s1 == "f")
                        {
                            if (s2 == "1")
                            {
                                //btnFaultReport.Text = "Fault" + Environment.NewLine + "Report";
                                //btnFaultReport.Visible = true;
                            }
                        }

                        if (s1 == "tov")
                        {
                            if (!s2.Equals("-1"))
                            {
                                _tov = "&tov=" + s2;
                               //// btnFaultReport.Text = "Alternate" + Environment.NewLine + "Municipality" + Environment.NewLine + "Lookup";
                               // btnFaultReport.Visible = true;
                            }
                        }


                    }

                    string result_name = System.Text.RegularExpressions.Regex.Replace(strName, @"\r\n?|\n", " ");
                    string result_addr = System.Text.RegularExpressions.Regex.Replace(strAddress, @"\r\n?|\n", " ");
                    _meter_detail_to_save = "Utility: " + strUtility + "\nCustomer: " + result_name + "\nAddress: " + result_addr;
                    btnSaveMeter.Visible = true;

                }
                catch
                {

                    //btnFaultReport.Text = "Meter" + Environment.NewLine + "Support";
                    //btnFaultReport.Visible = true;

                    showMsgAction("There was a problem retrieving the address details." + Environment.NewLine + "Please try again later.", Color.Firebrick);

                    btnOK.Show();

                    txtRandValue.Enabled = false;
                    txtElecMeterNo.Enabled = true;
                    txtElecMeterNo.Focus();

                    cmdElecrtraClear.Visible = true;
                    btnClose.Visible = true;

                    return;
                }

                txtRandValue.Enabled = true;

                if (!strPending.Equals("0", StringComparison.Ordinal))
                {

                    txtRandValue.Text = strPending;
                    txtRandValue.Enabled = false;


                    String msg = "";
                    msg = "Name   : " + strName.Replace(",null", "");
                    msg += "\nAddress: " + strAddress.Replace(",null", "");
                    //msg += "\nMeter: " + txtElecMeterNo.Text;
                    //msg += "\nUtility: " + strUtility;

                    lblmunicipality.ForeColor = Util.HexToColor(fC);
                    lblmunicipality.BackColor = Util.HexToColor(bC);
                    lblmunicipality.Text = strUtility;
                    lblmunicipality.Show();

                    if (globalSettings.elec_max_vend_show == "1" && strMaxVend.Length > 0)
                    {
                        msg += "\nMaximum Vend Amount: " + strMaxVend;
                    }

                    showMsg(msg, 0, Color.Black);
                    showMsgAction("R " + strPending + ".00 pending voucher available.", Color.FromArgb(130, 203, 51));

                    pnlSetValues.Visible = false;
                    btnClearValue.Visible = true;

                }
                else
                {

                    lblmunicipality.ForeColor = Util.HexToColor(fC);
                    lblmunicipality.BackColor = Util.HexToColor(bC);
                    lblmunicipality.Text = strUtility;
                    lblmunicipality.Show();

                    String msg = "";
                    msg = "Name   : " + strName.Replace(",null", "");
                    msg += "\nAddress: " + strAddress.Replace(",null", "");
                    //msg += "\nMeter: " + txtElecMeterNo.Text;

                    if (globalSettings.elec_max_vend_show == "1" && strMaxVend.Length > 0)
                    {
                        msg += "\nMaximum Vend Amount: " + strMaxVend;
                    }

                    //msg += "\nUtility: " + strUtility;
                    if (strExtra.Length > 0)
                    {
                        showMsgAction(strExtra, Color.Firebrick);
                        //msg += "\n" + strExtra;
                    }
                    else
                    {
                        showMsgAction("", Color.Gray);
                    }

                    showMsg( msg , 0, Color.Black);
                    //showMsgAction("", Color.Gray);

                    pnlSetValues.Visible = true;

                }

                btnClose.Text = "Back";
                btnOK.Text = "OK";

                cmdElecrtraClear.Visible = true;
                btnClose.Visible = true;

                btnOK.Show();
                btnFreeElec.Text = "Get Free" + Environment.NewLine + "Tokens";
                btnFreeElec.Show();
                btnClose.Show();

                //newstring = "";
                //totalstring = "";

                txtRandValue.Focus();
                txtRandValue.Show();

                pnlCapture.Height = 155;

            }
            else
            {

                cmdElecrtraClear.Visible = true;
                btnClose.Visible = true;

                //btnFaultReport.Text = "Meter" + Environment.NewLine + "Support";
                //btnFaultReport.Visible = true;

                showMsg(retWS.Replace("ERR:", ""), 1, Color.Firebrick);
                showMsgAction("The request was not successful.", Color.Black);

                txtRandValue.Enabled = false;
                btnOK.Text = "Next";
                btnOK.Show();
            }

        }




        private void StepProcessVoucherResponse(string wsRes)
        {
            if (IsVoucherOk(wsRes))
            {

                _tokenRequestRetryCount = 0;
                ConfirmElectricityToken();

                if (_elecConfirmed)
                {

                    globalVoucher.voucherStatsRequestOK();
                    PrintElectricityToken();

                }
                else
                {

                    CancelVoucherRequest("Unable to confirm electricity token.");

                }

            }
            else
            {
                // CHECK THIS STEP -- 
                StepReGetElectricityVoucher(true);
            }

        }


        // Reget voucher if there was a problem
        int _tokenRequestRetryCount = 0;

        private void StepReGetElectricityVoucher(bool wasFormatintProblem)
        {

            _tokenRequestRetryCount++;

            if (_tokenRequestRetryCount >= 6)
            {
                CancelVoucherRequest("Could not retrieve electricity token.");
                return;
            }

            //if (Util.IsADSL)
            //{
                showMsg("Retrying, please wait....", 1, Color.DarkRed);
                showMsgAction("Do not turn machine off!", Color.Firebrick);
                Application.DoEvents();
                Thread.Sleep(5000);
            //}
            //else
            //{

            //    if (_tokenRequestRetryCount == 1 || _tokenRequestRetryCount == 2)
            //    {
            //        showMsg("Retrying, please wait....", 1, Color.DarkRed);
            //        showMsgAction("Do not turn machine off!", Color.Firebrick);
            //        Application.DoEvents();
            //        Thread.Sleep(5000);
            //    }

            //    //if (_tokenRequestRetryCount == 3 || _tokenRequestRetryCount == 6)
            //    //{
            //    //    showMsg("Re-connecting, please wait....", 1, Color.DarkRed, 90, 50, "", "Do not turn machine off!");
            //    //    Application.DoEvents();

            //    //    Util.ConnectionStatus = 1;
            //    //    Program.tiuMain.gprsHangup();
            //    //    Program.tiuMain.update_connection_status("Reconnect");
            //    //    Program.tiuMain.gprsDial(false);
            //    //    Thread.Sleep(2000);
            //    //}


            //    //if (_tokenRequestRetryCount == 4)
            //    if (_tokenRequestRetryCount == 3)
            //    {
            //        showMsg("Restarting Connection, please wait....", 1, Color.DarkRed);
            //        showMsgAction("Do not turn machine off!", Color.Firebrick);
            //        Application.DoEvents();

            //        Util.ConnectionStatus = 1;
            //        //Program.tiuMain.update_connection_status("Reset Modem");
            //        //Program.tiuMain.gprsReboot();
            //        //Program.tiuMain.update_connection_status("Reconnect");
            //        //Program.tiuMain.gprsDial(false);
            //        Thread.Sleep(1000);
            //    }

            //    if (_tokenRequestRetryCount == 4 || _tokenRequestRetryCount == 5)
            //    {
            //        showMsg("Retrying, please wait....", 1, Color.DarkRed);
            //        showMsgAction("Do not turn machine off!", Color.Firebrick);
            //        Application.DoEvents();

            //        Thread.Sleep(5000);
            //    }

            //}

            string URI = "";
            
            URI = "/itron/electricity/vendReqRetry?";
            URI = URI + "lic=" + globalSettings.license_code;
            URI = URI + "&v=" + _currentElecRandValue;
            URI = URI + "&m=" + _currentMeterNo;
            URI = URI + "&p=" + globalSettings.pos_user_id;
            URI = URI + "&uid=" + globalVoucher.stats_ele_busy;
            URI = URI + "&last=" + globalVoucher.stats_ele_lastprinted;

            if (wasFormatintProblem)
            {
                URI = URI + "&problem=" + _tokenRequestRetryCount.ToString();
            }

            string wsRes = MakeWebRequest(URI, 20000);

            if (wsRes.IndexOf("<webreqerr>", 0) >= 0)
            {
                StepReGetElectricityVoucher(false);
            } 
            else if (wsRes.IndexOf("ERR:") > -1)
            {

                if (wsRes == "ERR:NO DATA" && _tokenRequestRetryCount == 1)
                {
                    showMsg("Waiting for Token...Retrying...", 1, Color.DarkRed);
                    showMsgAction("Do not turn machine off!", Color.Firebrick);
                    Thread.Sleep(10000);
                    StepReGetElectricityVoucher(false);
                }
                else
                {
                    CancelVoucherRequest(wsRes);
                }
            
            }
            else
            {
                StepProcessVoucherResponse(wsRes);
            }

        }


        bool _voucherRequestError = false;
        private void CancelVoucherRequest(string errorResponse)
        {

            //#region Debug
           // if (DebugMode) txtdebug.Text += "cancelVoucherRequest()" + Environment.NewLine;
            //#endregion Debug

            _voucherRequestError = true;

            btnOK.Hide();

            if (errorResponse.Equals("ERR:NO DATA"))
            {
                showMsg("Your electricity token request" + Environment.NewLine + "has not responded in time.", 1, Color.Firebrick);
                showMsgAction("Please retry meter or check your last sales.", Color.Firebrick);
            }
            else
            {
                errorResponse = errorResponse.Replace("ERR:", "");
                showMsg(errorResponse, 1, Color.Firebrick);
                showMsgAction("", Color.Firebrick);
            }

            this.btnClose.Text = "Close";
            this.btnClose.Show();

        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            btnOKClick();
        }

        private void btnOKClick()
        {

            pnlSavedMeters.Visible = false;

            if (btnOK.Text == ("Merchant" + Environment.NewLine + "Copy"))
            {

                //bool _print_ok = Util.printElectricitySlip(_elecVoucher);

                Util.printVoucherCopy(true);

                RetOk();
                return;
            }

            //btnUniPIN.Visible = false;

            if (btnOK.Text == "Send")
            {

                if (txtElecCell.Text == "")
                {
                    lblMeterSupportResult.ForeColor = Color.Firebrick;
                    lblMeterSupportResult.Text = "Please enter a contact cell number.";
                    txtElecCell.Focus();
                    return;
                }
                if (txtElectName.Text.ToString().Length <= 3)
                {
                    lblMeterSupportResult.ForeColor = Color.Firebrick;
                    lblMeterSupportResult.Text = "Please enter a contact name.";
                    txtElectName.Focus();
                    return;
                }

                btnOK.Hide();

                txtElecCell.Enabled = false;
                txtElectName.Enabled = false;

                btnClose.Text = "Close";

                lblMeterSupportResult.ForeColor = Color.LightGray;
                lblMeterSupportResult.Text = "Sending Request...";

                start_delayed_load("meter_support", 1000);

                return;
            }

            if (btnOK.Text == "Next")
            {
                
                wbInfo.Hide();
                //btnFaultReport.Hide();               

                if (txtElecMeterNo.Text == "")
                {
                    showMsgAction("Please enter a meter number!",Color.Firebrick);
                    txtElecMeterNo.Focus();
                    return;
                }
                if (txtElecMeterNo.Text.ToString().Length <= 4)
                {
                    showMsgAction("Meter number too short!", Color.Firebrick);
                    txtElecMeterNo.Focus();
                    return;
                }

                _currentMeterNo = txtElecMeterNo.Text;
                txtElecMeterNo.Enabled = false;

                globalSettings.electra_last = _currentMeterNo;

                btnOK.Hide();
                btnClose.Text = "Cancel";
                cmdElecrtraClear.Text = "Clear";

                cmdElecrtraClear.Visible = false;
                btnClose.Visible = false;

                //  StepGetAddressDetails();
                populateVoucher();

                return;

            }


            if (btnOK.Text == "OK" || btnOK.Text == "Accept")
            {

                if (txtRandValue.Text.Trim() == "")
                {
                    txtRandValue.Focus();
                    showMsgAction("Please enter a Rand value!", Color.Firebrick);
                    return;
                }

                pnlCapture.Height = 75;
                txtRandValue.Enabled = false;
                //btnFaultReport.Visible = false;
                btnFreeElec.Visible = false;


                Decimal rand_val = 0;

                try
                {

                    rand_val = Decimal.Parse(txtRandValue.Text.ToString().Trim(), System.Globalization.CultureInfo.InvariantCulture);

                    globalVoucher.voucher_value = rand_val;

                    rand_val = rand_val * 100;
                    _currentElecRandValue = rand_val.ToString("#");
                    
                    //globalVoucher.voucher_value = Decimal.Parse(txtRandValue.Text.Replace(",", ""), System.Globalization.CultureInfo.InvariantCulture);

                }
                catch (Exception ex)
                {
                    txtRandValue.Focus();
                    showMsgAction("Error: " + ex.Message, Color.Firebrick);
                    return;
                }
                
                lblCost.Text = "R " + globalVoucher.voucher_value.ToString();
                lblCost.Show();

                if (globalSettings.elec_max_warning_show == "1" && btnOK.Text == "OK")
                {
                    try
                    {
                        
                        decimal d1 = Decimal.Parse(txtRandValue.Text.Replace(",", ""), System.Globalization.CultureInfo.InvariantCulture);
                        decimal d2 = Decimal.Parse(globalSettings.elec_max_warning_val.Trim().Replace(",", ""), System.Globalization.CultureInfo.InvariantCulture);

                        if (d1 > d2)
                        {
                            btnOK.Text = "Accept";
                            showMsgAction("Warning: The amount entered is R " + globalSettings.elec_max_warning_val + Environment.NewLine + "Please click Accept if correct.", Color.Firebrick);
                            return;
                        }

                    }
                    catch (Exception ex)
                    {
                        Util.showMessage(ex.Message, Color.Red);
                    }

                }

                //decimal cost_total = globalVoucher.request_qty * globalVoucher.voucher_value;
                //lblVoucherCount.Text = globalVoucher.request_qty.ToString();

                if (globalSettings.gen_print_copy == "1" || globalVoucher.voucher_value == 0)
                {
                    //
                }
                else
                {
                    //btnPlus.Visible = true;
                    //lblVoucherCount.Visible = true;
                    //picMultiBackground.Visible = true;
                    pnlMultiVoucher.Visible = true;
                }

                btnClose.Text = "Cancel";
                btnOK.Text = "Confirm";

                showMsgAction("Confirm to proccess electricity.", Color.Gray);

                //this._hidden_key_capture.Focus();

                return;

            }

            if (btnOK.Text == "Confirm")
            {

                cmdElecrtraClear.Enabled = false;
                //btnAZ.Enabled = false;

                ConfirmProcedure();
                return;
            }

        }


        private void ConfirmProcedure(){

            if (globalSettings.gen_show_voucher_only.Equals("0") && Util.OutOfPaper())
            {
                showMsgAction("Please check the printer paper!", Color.DarkRed);
                btnOK.Show();
                btnClose.Show();
                return;
            }

            btnOK.Hide();
            btnOK.Refresh();
            btnClose.Hide();
            btnClose.Refresh();

            //lblVoucherCount.Visible = false;
            //btnMinus.Visible = false;
            //btnPlus.Visible = false;
            //picMultiBackground.Visible = false;

            pnlMultiVoucher.Visible = false;

            _voucherRequestError = false;

            globalVoucher.voucherStatsNewRequest();
            globalVoucher.request_qty_current++;

            if ((globalVoucher.request_qty_current <= globalVoucher.request_qty) && !_voucherRequestError)
            {

                _isPrinted = false;

                StepGetElectricityVoucher();

                if (!_voucherRequestError)
                {
                    ConfirmProcedure();
                }

            }
            else
            {

                if (!_voucherRequestError)
                {
                    if (_isPrinted == true)
                    {
                        if (globalSettings.gen_print_copy == "1")
                        {

                            showMsg("Printing Complete", 1, Color.Black);

                            btnOK.Text = ("Merchant" + Environment.NewLine + "Copy");
                            btnOK.Enabled = true;
                            btnOK.Visible = true;
                            btnClose.Enabled = true;
                            btnClose.Visible = true;

                            return;
                        }

                    }

                    RetOk();
                }

            }

        }



        private void StepGetElectricityVoucher()
        {

            _tokenRequestRetryCount = 0;
            _elecConfirmed = false;
            //_confirmationCount = 0;

            if (globalVoucher.request_qty == 1)
            {
                showMsg(Environment.NewLine + "Requesting Electricity Token", 1, Color.CadetBlue);
                showMsgAction("Do not turn machine off!", Color.Firebrick);
            }
            else
            {
                showMsg(Environment.NewLine + "Requesting Electricity Token " + globalVoucher.request_qty_current.ToString() + "/" + globalVoucher.request_qty.ToString(), 1, Color.CadetBlue);
                showMsgAction("Do not turn machine off!", Color.Firebrick);
            }

            string URI = "/itron/electricity/vendReq?lic=" + globalSettings.license_code + "&v=" + _currentElecRandValue + "&m=" + _currentMeterNo + "&p=" + globalSettings.pos_user_id + "&uid=" + globalVoucher.stats_ele_busy + "&last=" + globalVoucher.stats_ele_lastprinted;

            if (globalSettings.svr_id == "dmo")
            {
                URI = "/itron/electricity/vendReq?lic=" + globalSettings.license_code + "&v=" + _currentElecRandValue + "&m=" + _currentMeterNo + "&p=" + globalSettings.pos_user_id + "&uid=" + globalVoucher.stats_ele_busy + "&last=" + globalVoucher.stats_ele_lastprinted;
                //URI = "/itron/elecdemo/vendReq?lic=" + globalSettings.license_code + "&v=" + _currentElecRandValue + "00&m=" + _currentMeterNo + "&p=" + globalSettings.pos_user_id + "&uid=" + globalVoucher.stats_ele_busy + "&last=" + globalVoucher.stats_ele_lastprinted;
            }

            String wsRes = MakeWebRequest(URI, 60000);

            if (wsRes.Trim().Length == 0)
            {
                wsRes = "ERR:Empty electricity response.";
            }

            if (wsRes.IndexOf("<webreqerr>", 0) >= 0)
            {
                Util.showMessage(wsRes.StripErrorTags(), Color.Red);
                StepReGetElectricityVoucher(false);
            } 
            else if (wsRes.Substring(0, 4) == "ERR:")
            {
                Util.showMessage(wsRes.Replace("ERR:",""),Color.Red);
                CancelVoucherRequest(wsRes);
            }
            else
            {
                StepProcessVoucherResponse(wsRes);
            }

        }


        

        private void btnCancelClick()
        {
ShowElecStart();
           

            RetOk();

        }
        


        private void cmdElecrtraClear_Click(object sender, EventArgs e)
        {

          

            ShowElecStart();

          
        }



        private string MakeWebRequest(string URL, int Timeout)
        {
            string htmlResponse = "";

            Web WebResponse = new Web(Timeout);

                htmlResponse = WebResponse.GetURL(URL);

            WebResponse = null;

            return htmlResponse;
        }







        private void btnFreeElec_Click(object sender, EventArgs e)
        {

            if (btnFreeElec.Text.Equals("Get Free" + Environment.NewLine + "Tokens"))
            {

                _currentElecRandValue = "0";
                txtRandValue.Text = "0";
                txtRandValue.Enabled = false;

                cmdElecrtraClear.Enabled = false;
                //btnAZ.Enabled = false;

                pnlCapture.Height = 75;

                showMsgAction("", Color.Black);
                showMsg("", 0, Color.Black);

                btnFreeElec.Hide();

                lblCost.Text = "Free Token";
                lblCost.Show();
                lblCost.Refresh();

                btnOK.Hide();
                btnClose.Hide();
                //btnFaultReport.Hide();

                StepGetElectricityVoucher();

                btnClose.Show();
                btnClose.Text = "Close";

            }
            else
            {

                if (pnlSavedMeters.Visible)
                {
                    pnlSavedMeters.Visible = false;
                    return;
                }

                meter_save_mode = false;
                lblSavedMeterHeading.Text =  "Click on Saved Meter Number:";
                lblSavedMeterHeading.BackColor = Color.Green;

                SetupGetSavedMeters();

                pnlSavedMeters.BringToFront();
                pnlSavedMeters.Visible = true;

            }

        }

        private void btnClearValue_Click(object sender, EventArgs e)
        {
            btnClearValue.Visible = false;
            txtRandValue.Enabled = true;
            pnlSetValues.Visible = true;
            txtRandValue.Text = "";
            txtRandValue.Focus();
        }

        

        //bool _textTypeNumeric = true;
        //private void btnAZ_Click(object sender, EventArgs e)
        //{

        //    if (this.btnAZ.Text == "A-Z")
        //    {
        //        _textTypeNumeric = false;
        //        this.btnAZ.Text = "0-9";
        //    }
        //    else
        //    {
        //        _textTypeNumeric = true;
        //        this.btnAZ.Text = "A-Z";
        //    }

        //}

        //private void btnMinus_Click(object sender, EventArgs e)
        //{
        //    btnPlus.Visible = true;
        //    if (globalVoucher.request_qty == 1)
        //    {
        //        return;
        //    }

        //    globalVoucher.request_qty--;

        //    if (globalVoucher.request_qty == 1)
        //    {
        //        lblTotalCost.Visible = false;
        //        btnMinus.Visible = false;

        //        lblCost.Width = 800;
        //        lblCost.TextAlign = ContentAlignment.TopCenter;

        //    }

        //    decimal cost_total = globalVoucher.request_qty * globalVoucher.voucher_value;
        //    lblVoucherCount.Text = globalVoucher.request_qty.ToString();
        //    lblTotalCost.Text = "x " + globalVoucher.request_qty.ToString() + " = " + String.Format("R {0:n}", cost_total);

        //}

        //private void btnPlus_Click(object sender, EventArgs e)
        //{
        //    btnMinus.Visible = true;
        //    lblTotalCost.Visible = true;

        //    if (globalVoucher.request_qty == 9)
        //    {
        //        return;
        //    }

        //    globalVoucher.request_qty++;

        //    if (globalVoucher.request_qty == 9)
        //    {
        //        btnPlus.Visible = false;
        //    }

        //    lblCost.Width = 395;
        //    lblCost.TextAlign = ContentAlignment.TopRight;

        //    decimal cost_total = globalVoucher.request_qty * globalVoucher.voucher_value;
        //    lblVoucherCount.Text = globalVoucher.request_qty.ToString();
        //    lblTotalCost.Text = "x " + globalVoucher.request_qty.ToString() + " = " + String.Format("R {0:n}", cost_total);


        //}


        private void btnClose_Click(object sender, EventArgs e)
        {
            btnCancelClick();
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



        private string _current_action = ""; 
        private void start_delayed_load(String action, int interval)
        {
            _current_action = action;
            tmr_delayed_load.Interval = interval;
            tmr_delayed_load.Enabled = true;
        }

        private void tmr_delayed_load_Tick(object sender, EventArgs e)
        {

            tmr_delayed_load.Enabled = false;

            if (_current_action == "meter_support")
            {
                String htmlResponse = "";
                try
                {

                    String URI = "";
                    URI = "/itron/general/meter-support?";
                    URI = URI + "lic=" + globalSettings.license_code;
                    URI = URI + "&p=" + globalSettings.pos_user_id;
                    URI = URI + "&mnum=" + _currentMeterNo;
                    URI = URI + "&mcell=" + txtElecCell.Text;
                    URI = URI + "&mname=" + txtElectName.Text;

                    Web WebResponse = new Web(25000);
                    htmlResponse = WebResponse.GetURL(URI);
                    WebResponse = null;

                    if (htmlResponse.Equals("ok")) {                        

                        lblMeterSupportResult.ForeColor = Color.Green;
                        lblMeterSupportResult.Text = "Your request has been sent.";


                    } else {

                        lblMeterSupportResult.ForeColor = Color.Firebrick;
                        lblMeterSupportResult.Text = "There was a problem sending your request." + Environment.NewLine + "Please check your internet connection.";
                        
                    }

                }
                catch
                {
                    //
                }

            }

            _current_action = "";
        }

        private void btnUniPIN_Click(object sender, EventArgs e)
        {

           // Util.showUniPIN = true;
          //  this.Close();

        }



        private void btnGetMeter1_Click(object sender, EventArgs e)
        {
            if (meter_save_mode)
            {
                globalSettings.saved_meter_1 = _currentMeterNo.Trim();
                globalSettings.saved_meter_1_desc = _meter_detail_to_save.Trim();
                globalSettings.SaveGeneral();
                Util.showMessage("Meter Number Saved.", Color.White);
                pnlSavedMeters.Visible = false;
            }
            else 
            {
                txtElecMeterNo.Text = globalSettings.saved_meter_1.Trim();
                btnOKClick();
            }
            meter_save_mode = false;
        }

        private void btnGetMeter2_Click(object sender, EventArgs e)
        {
            if (meter_save_mode)
            {
                globalSettings.saved_meter_2 = _currentMeterNo.Trim();
                globalSettings.saved_meter_2_desc = _meter_detail_to_save.Trim();
                globalSettings.SaveGeneral();
                Util.showMessage("Meter Number Saved.", Color.White);
                pnlSavedMeters.Visible = false;
            }
            else
            {
                txtElecMeterNo.Text = globalSettings.saved_meter_2.Trim();
                btnOKClick();
            }
            meter_save_mode = false;
        }

        private void btnGetMeter3_Click(object sender, EventArgs e)
        {
            if (meter_save_mode)
            {
                globalSettings.saved_meter_3 = _currentMeterNo.Trim();
                globalSettings.saved_meter_3_desc = _meter_detail_to_save.Trim();
                globalSettings.SaveGeneral();
                Util.showMessage("Meter Number Saved.", Color.White);
                pnlSavedMeters.Visible = false;
            }
            else
            {
                txtElecMeterNo.Text = globalSettings.saved_meter_3.Trim();
                btnOKClick();
            }
            meter_save_mode = false;
        }

        private void btnGetMeter4_Click(object sender, EventArgs e)
        {
            if (meter_save_mode)
            {
                globalSettings.saved_meter_4 = _currentMeterNo.Trim();
                globalSettings.saved_meter_4_desc = _meter_detail_to_save.Trim();
                globalSettings.SaveGeneral();
                Util.showMessage("Meter Number Saved.", Color.White);
                pnlSavedMeters.Visible = false;
            }
            else
            {
                txtElecMeterNo.Text = globalSettings.saved_meter_4.Trim();
                btnOKClick();
            }
            meter_save_mode = false;
        }

        private void btnGetMeter5_Click(object sender, EventArgs e)
        {
            if (meter_save_mode)
            {
                globalSettings.saved_meter_5 = _currentMeterNo.Trim();
                globalSettings.saved_meter_5_desc = _meter_detail_to_save.Trim();
                globalSettings.SaveGeneral();
                Util.showMessage("Meter Number Saved.", Color.White);
                pnlSavedMeters.Visible = false;
            }
            else
            {
                txtElecMeterNo.Text = globalSettings.saved_meter_5.Trim();
                btnOKClick();
            }
            meter_save_mode = false;
        }


        bool meter_save_mode = false;
        private void btnSaveMeter_Click(object sender, EventArgs e)
        {

            meter_save_mode = true;

            lblSavedMeterHeading.Text = "Click to SAVE Meter Number:";
            lblSavedMeterHeading.BackColor = Color.Firebrick;

            pnlSavedMeters.Visible = true;

        }

        private void txtRandValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                    && !char.IsDigit(e.KeyChar)
                    && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point 
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

            if (Regex.IsMatch(txtRandValue.Text, @"\.\d\d") && e.KeyChar != 8)
            {
                e.Handled = true;
            }

        }



        //manish

        void btnCurExc_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int i = Convert.ToInt32(btn.Tag);

            voucher = vouchers[i];
            // System.Uri myUri = new System.Uri("http://tx.itopitup.co.za:25812/ding/connect/exchange-estimate-req");
            //"http://" + globalSettings.svr_ip + ":" + globalSettings.svr_port + uri
            try
            {
                System.Uri myUri = new System.Uri("http://" + globalSettings.svr_ip + ":" + globalSettings.svr_port + "/ding/connect/exchange-estimate-req");
                HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(myUri);
                webRequest.Method = @"POST";


                webRequest.KeepAlive = false;
                webRequest.Proxy = null;
                webRequest.Timeout = 100000;
                // webRequest.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                webRequest.ContentType = "text/plain";
                webRequest.Headers.Add("ignore", _ignorelicenselevel.ToString());
                webRequest.Headers.Add("license", globalSettings.license_code);
                webRequest.Headers.Add("posuser", globalSettings.pos_user_id);
                string requestBody = string.Format(voucher);

                byte[] byteArray = Encoding.UTF8.GetBytes(requestBody);
                webRequest.ContentLength = byteArray.Length;

                // Get the request stream.
                Stream dataStream = webRequest.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();

                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();

                using (Stream respStream = response.GetResponseStream())
                {
                    StreamReader rdr = new StreamReader(respStream, Encoding.UTF8);
                    strResp = rdr.ReadToEnd();
                    rdr.Close();
                }

                response.Close();
            }
            catch
            {
                MessageBox.Show("ERR:HTTP error check signal/connection.");
            }


            voucherName = voucherdesc[i];
            // pnlAirtime.Size = new Size(0, 0);

            pnlAirtime.Hide();
            lblPhone.Text = "+" + _currentMeterNo;
            lblVoucher.Text = voucherName;
            lblNetwork.Text = Network;
            amount = strResp;
            lblAmount.Text = "R " + strResp;
            pnlAmount.Location = new Point(0, 84);
            pnlAmount.Show();

            
        }




        private void txnRequest()
        {
            strResp = "";

            //MessageBox.Show("" + amount1);
            //voucher = "<reqInfo tokenType=\"INR 1000 Recharge (AIININ58153)\" network=\"Airtel India - AIIN\" payType=\"cash\" phoneNum=\"+919880343423\" amt=\"32007\"></reqInfo>";
            if (denomination.Equals("false"))
            {
                float amount1 = 0;
                try
                {
                    amount1 = float.Parse(txtRandValue.Text) * 100;
                }
                catch
                {

                }


                voucher = "<reqInfo tokenType=\"" + voucherName + "\" network=\"" + Network + "\" payType=\"cash\" phoneNum=\"" + txtElecMeterNo.Text + "\" amt=\"" + amount1 + "\" non_denominated=\"true\"></reqInfo>";
                // voucher = "<reqInfo tokenType=\"ETB 37.12-5345.85 (BHETET55310)\" network=\"Ethio Telecom Ethiopia - BHET\" payType=\"cash\" phoneNum=\"251912781775\" amt=\"10000\" non_denominated=\"true\"></reqInfo>";
            }
            else
            {
                float amount1 = float.Parse(amount) * 100;
                voucher = "<reqInfo tokenType=\"" + voucherName + "\" network=\"" + Network + "\" payType=\"cash\" phoneNum=\"" + txtElecMeterNo.Text + "\" amt=\"" + amount1 + "\"></reqInfo>";
            }
            //  MessageBox.Show(voucher);
            try
            {
                System.Uri myUri = new System.Uri("http://" + globalSettings.svr_ip + ":" + globalSettings.svr_port + "/ding/connect/vend-req");
                //MessageBox.Show("myUri=" + myUri);
                HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(myUri);
                webRequest.Method = @"POST";


                webRequest.KeepAlive = false;
                webRequest.Proxy = null;
                webRequest.Timeout = 100000;
                // webRequest.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                webRequest.ContentType = "text/plain";
                webRequest.Headers.Add("ignore", _ignorelicenselevel.ToString());
                webRequest.Headers.Add("license", globalSettings.license_code);
                webRequest.Headers.Add("posuser", globalSettings.pos_user_id);
                string requestBody = string.Format(voucher);

                byte[] byteArray = Encoding.UTF8.GetBytes(requestBody);
                webRequest.ContentLength = byteArray.Length;

                // Get the request stream.
                Stream dataStream = webRequest.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();

                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();

                using (Stream respStream = response.GetResponseStream())
                {
                    StreamReader rdr = new StreamReader(respStream, Encoding.UTF8);
                    strResp = rdr.ReadToEnd();
                    rdr.Close();
                }

                response.Close();
            }
            catch
            {
                MessageBox.Show("ERR:HTTP error check signal/connection.");
            }


            if (strResp.Contains("nofunds"))
            {
                MessageBox.Show("Insufficient funds to print voucher. Please contact Top it Up.", "Global Airtime", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                //MessageBox.Show("Insufficient funds to print voucher. Please contact Top it Up.");
            }
            else if (strResp.Contains("ERR:General error"))
            {
                MessageBox.Show("General Error. Please contact Top it Up.", "Global Airtime", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                //MessageBox.Show("Insufficient funds to print voucher. Please contact Top it Up.");
            }
            else
            {
                showMsg("Printing Voucher", 1, Color.Black);


                showMsgAction("", Color.Firebrick);

                if (globalSettings.gen_cashdr == "1")
                {
                    Util.OpenCashDrawer();
                }

                try
                {

                    Newtonsoft.Json.Linq.JObject json = Newtonsoft.Json.Linq.JObject.Parse(strResp);

                    finBalance.populateBalanceFromJson(json);


                    string print_data = "";
                    if (!String.IsNullOrEmpty((string)json["real_tx_value"]))
                    {
                        lblTxnVou.Text = voucherName;
                        lblPayAmount.Text = "";
                        string real_tx_value = (string)json["real_tx_value"];
                        try
                        {

                            float txAmnt = float.Parse(real_tx_value) / 100;
                            lblPayAmount.Text = "R " + txAmnt;
                        }
                        catch
                        {

                        }

                        pnlAmount.Hide();
                        pnlNonDeno.Hide();
                        pnlTxn.Show();
                        pnlTxn.Location = new Point(0, 84);
                    }
                    if (!String.IsNullOrEmpty((string)json["print_data"]))
                    {

                        print_data = (string)json["print_data"];
                    }
                     
                    Util.printText(print_data, false);



                }
                catch (Exception ex)
                {
                   // Util.showMessage(ex.Message, true);
                }









                _isPrinted = true;
            }

            //MessageBox.Show(strResp);


        }





        private void txtRandValue_Leave(object sender, EventArgs e)
        {

            try {
                Decimal amount = Decimal.Parse(txtRandValue.Text.ToString());
                txtRandValue.Text = amount.ToString("#.00");
            } catch
            {
                txtRandValue.Text = "";
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txnRequest();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pnlAirtime.Show();
            pnlAmount.Hide();
        }

        private void btnndTxnConfirm_Click(object sender, EventArgs e)
        {
            float amount1 = 0;
            if (denomination.Equals("false"))
            {
                try
                {
                    amount1 = float.Parse(txtRandValue.Text);
                    //MessageBox.Show("amount="+amount1);
                }
                catch
                {

                }

                if (amount1.Equals(0))
                {
                    lblNonDenoWar.Text = "Please enter an Amount between R 25.00 to R 2000.00!!!";

                    return;
                }
                else if (amount1 < 25)
                {
                    lblNonDenoWar.Text = "Please enter an Amount greater than R 25.00!!!";

                    //showMsgAction("Please enter an Amount greater than R 25.00!!!", Color.Firebrick);
                    return;
                }
                else if (amount1 > 2000)
                {
                    lblNonDenoWar.Text = "Please enter an Amount less than R 2000.00!!!";
                    //showMsgAction("Please enter an Amount less than R 2000.00!!!", Color.Firebrick);
                    return;
                }
                else
                {
                    txnRequest();
                }

            }
        }

        private void btnndTxnCancel_Click(object sender, EventArgs e)
        {

            ShowElecStart();
        }
    }





}
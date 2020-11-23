using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;
using System.IO;

//using WebSocket4Net;

using CefSharp;
using CefSharp.WinForms;
using System.Collections.Generic;

namespace TopitUp
{

    public partial class frmTopitUp : Form
    {
        
        bool _tiu_adminMode = false;
        bool _emergencyMode = false;

        string _login_text = "";

        int _progressState = 0;
        int _productPanel = 0;
        int _provider_id = 0;
        int _productPanelPage = 0;

        int _providerPanelState = 0;

        int voucher_prov_arr_id = 0;
        int voucher_item_arr_id = 0;

        private MyButton[] btnItem = new MyButton[25];

        List<String> missingImages = new List<String>();

        private String _last_sale_rtf = @"{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Tahoma;}}{\colortbl ;\red255\green255\blue255;}\pard\sl360\slmult1\cf1\f0\fs24\lang9 Voucher:\b\tab\tab [VOUCHER]\b0\par Value:\b\tab\tab\tab [VALUE]\b0\par Cashier:\b\tab\tab [CASHIER]\b0\par }";

        private frmSplash splasher = null;

        const int domainProfile = 1;
        const int privateProfile = 2;
        const int publicProfile = 4;

        public static ChromiumWebBrowser wbInfo;

        public frmTopitUp(frmSplash splasherer)
        {


            InitializeComponent();

            try
            {
                System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.High;
            }
            catch
            {
                //
            }

            try
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("EN-US");
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.splasher = splasherer;

            Util._home_form = this;

            if (globalSettings.allow_screen_resize == "0") {

                this.AutoScaleMode = AutoScaleMode.None;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
            }


            //update_windows_firewall(domainProfile, true);
            //update_windows_firewall(privateProfile, true);
            //update_windows_firewall(publicProfile, true);
            lblDemo.Text = "FIREWALL DISABLED !!";

                try
                {

                    if (!Cef.IsInitialized)
                    {
                        CefSettings settings = new CefSettings();
                        settings.BrowserSubprocessPath = @"c:\topitup\CefSharp.BrowserSubprocess.exe";
                        settings.IgnoreCertificateErrors = true;
                        settings.CefCommandLineArgs.Add("no-proxy-server", "1");
                        settings.CefCommandLineArgs.Add("disable-gpu-vsync", "1");
                        settings.CefCommandLineArgs.Add("disable-gpu", "1");
                        Cef.Initialize(settings, performDependencyCheck: false, browserProcessHandler: null);
                    }


                    wbInfo = new ChromiumWebBrowser("");
                    BrowserSettings browser_setting = new BrowserSettings();
                    browser_setting.LocalStorage = CefState.Enabled;
                    browser_setting.FileAccessFromFileUrls = CefState.Enabled;
                    browser_setting.UniversalAccessFromFileUrls = CefState.Enabled;
                    browser_setting.WebSecurity = CefState.Disabled;
                    wbInfo.BrowserSettings = browser_setting;

                    pnlCefContainer.Controls.Add(wbInfo);
                    pnlCefContainer.BorderStyle = BorderStyle.None;

                    wbInfo.IsBrowserInitializedChanged += (sender, args) =>
                    {
                        wbMessageGetMessage();
                    };

                    wbInfo.LoadingStateChanged += (sender, args) =>
                    {
                        if (args.IsLoading == false)
                        {
                        //
                    }
                    };


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            GeneralSetup();

        }




        public void update_windows_firewall(int this_domainProfile, bool enableFirewall)
        {
            Type netFwPolicy2Type = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            dynamic mgr = Activator.CreateInstance(netFwPolicy2Type);
            mgr.FirewallEnabled[this_domainProfile] = enableFirewall;
        }

        
        //private object getFwPolicy2()
        //{
        //    Type netFwPolicy2Type = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
        //    dynamic mgr = Activator.CreateInstance(netFwPolicy2Type);
        //    return mgr;
        //}

        private void ShowConnectionStatus(InternetConnectionType connectiontype)
        {
            try
            {
                switch (connectiontype)
                {
                    case InternetConnectionType.None:
                        UpdateTextBox("Offline", TopitUp.Properties.Resources.network_none);
                        break;
                    case InternetConnectionType.Cable:
                        UpdateTextBox("Lan Cable" + Environment.NewLine + "Connected", TopitUp.Properties.Resources.network_lan);
                        break;
                    case InternetConnectionType.Wifi:
                        UpdateTextBox("Wi-Fi" + Environment.NewLine + "Connected", TopitUp.Properties.Resources.network_wifi);
                        break;
                    case InternetConnectionType.Mobile:
                        UpdateTextBox("Mobile" + Environment.NewLine + "Connected", TopitUp.Properties.Resources.network_mobile);
                        break;
                    default:
                        UpdateTextBox("Unknown", TopitUp.Properties.Resources.network_none);
                        break;
                }
            }
            catch
            {
                //
            }
            
        }

        private void UpdateTextBox(string text, Image img)
        {
            if (this.status_connection.InvokeRequired)
            {
                status_connection.Invoke(new MethodInvoker(delegate
                {
                    status_connection.Text = text;
                    status_connection_img.Image = img;
                }));
            }
            else
            {
                status_connection.Text = text;
                status_connection_img.Image = img;
            }
        }

       


        private void frmTopitUp_Load(object sender, EventArgs e)
        {

            //Util.syncScreenshots();

            if (missingImages.Count > 0)
            {

                tmr_download_images.Enabled = true;

            }
            else
            {


                ShowLogin();

                if (Util.system_uid.Contains("0000000000000"))
                {
                    Util.showMessage("Please register this device.", Color.Yellow);
                }

                tmr_delayed_load.Enabled = true;

                this.Activate();

            }

        }


        private void tmr_delayed_load_Tick(object sender, EventArgs e)
        {

            tmr_delayed_load.Enabled = false;

            Util.showWait(true);

            Util.setDefaultPrinterName();

            print_pending_electrcity();

            async_getSystemStatus();
            tmr_check_status.Enabled = true;

            async_getBatteryStatus();
            tmr_battery.Enabled = _is_there_a_battery;

            tmrUpdateDateTime.Enabled = true;

            ShowConnectionStatus(InternetTools.InternetConnectionType);
            InternetTools.InternetConnectionChanged += (senderer, args) => ShowConnectionStatus(args.ConnectionType);

            pnlWrapperCharge.Visible = true;
            pnlWrapperInternet.Visible = true;

            //startWebSocketWatcher();

            //Console.WriteLine("http://" + globalSettings.sync_hostname + ":" + globalSettings.sync_port + "/info/ping");
            //browser.Load("www.google.com");

            Util.showWait(false);

        }


        private void print_pending_electrcity()
        {

            //Check for pending electra!
            if (globalSettings.bootup_electra.Length > 0)
            {
                splasher.doUpdate("Pending Electricity...");

                String htmlResponse = "";

                Web WebResponse = new Web(45000, 1, "");
                htmlResponse = WebResponse.GetURL("/itron/electricity/vendGetReprint2?lic=" + globalSettings.license_code + "&uid=" + globalSettings.bootup_electra + "&s=2");
                WebResponse = null;

                if (htmlResponse.IndexOf("<webreqerr>") > -1)
                {
                    //lblReprintMessage.Text = htmlResponse.GetStrBetweenTags("<webreqerr>", "</webreqerr>");
                }
                else if (htmlResponse.IndexOf("ERR:") > -1)
                {
                    //lblReprintMessage.Text = htmlResponse.GetStrBetweenTags("<err>", "</err>");
                }
                else
                {

                    Web WebResponseConfirm = new Web(45000, 1, "");
                    String ConfirmOK = WebResponseConfirm.GetURL("/itron/electricity/vendConfirmBalance?uid=" + globalSettings.bootup_electra + "&lic=" + globalSettings.license_code);
                    WebResponseConfirm = null;

                    if (ConfirmOK.IndexOf("OK=1") > -1)
                    {
                        try
                        {
                            char[] del = new char[] { '=', '^' };
                            string[] tokens = ConfirmOK.Split(del);

                            for (int token = 0; token < tokens.Length; token += 2)
                            {
                                string s1 = tokens[token];
                                string s2 = tokens[token + 1];
                            }
                        }
                        catch
                        {
                            //
                        }

                        Util.printElectricitySlip(Util.RemoveFirstLine(htmlResponse));

                    }

                }

                globalSettings.bootup_electra = "";

                Util.showWait(false);

            }

        }


        //WebSocket websocket = null;

        //private void startWebSocketWatcher()
        //{

        //    if (globalSettings.license_code.Equals("nolicense")) return;

        //    websocket = new WebSocket("ws://demo.itopitup.co.za:25812/messageservice/connect/" + globalSettings.license_code);
        //    websocket.Opened += new EventHandler(websocket_Opened);
        //    //websocket.Error += new EventHandler(webSocketClient_Error);
        //    websocket.Error += new EventHandler<SuperSocket.ClientEngine.ErrorEventArgs>(webSocketClient_Error);

        //    websocket.Closed += new EventHandler(websocket_Closed);
        //    //websocket.MessageReceived += new EventHandler(websocket_MessageReceived);
        //    websocket.MessageReceived += new EventHandler<MessageReceivedEventArgs>(webSocketClient_MessageReceived);
        //    websocket.Open();


        //}

        //protected void websocket_MessageReceived(object sender, EventArgs e)
        //protected void webSocketClient_MessageReceived(object sender, MessageReceivedEventArgs e)
        //{
        //    this.wbInfo.Invoke((MethodInvoker)delegate()
        //    {
                
        //        this.wbInfo.Navigate("about:blank");
        //        this.wbInfo.Document.OpenNew(false);
        //        this.wbInfo.Document.Write(e.Message.ToString());
        //        this.wbInfo.Refresh();

        //    });
        //    //m_MessageReceiveEvent.Set();
        //}


        //private void websocket_Opened(object sender, EventArgs e)
        //{
        //    //websocket.Send("Hello World!");
        //}

        //void websocket_Closed(object sender, EventArgs e)
        //{
        //    //m_CloseEvent.Set();
        //}


        //protected void webSocketClient_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        //{
        //    //Console.WriteLine(e.Exception.GetType() + ":" + e.Exception.Message + Environment.NewLine + e.Exception.StackTrace);

        //    //if (e.Exception.InnerException != null)
        //    //{
        //    //    Console.WriteLine(e.Exception.InnerException.GetType());
        //    //}
        //}













        private void GeneralSetup()
        {

            pnlLogin.Dock = DockStyle.Fill;
            pnlLogin.BringToFront();

            //update_windows_firewall(publicProfile, true);

            if (globalSettings.svr_id == "dmo") lblDemo.Show();
           
            logoutTimer.Interval = globalSettings.gen_logout_time;

            if (globalSettings.company_name.Trim().Length == 0)
            {
                lbl_status_company.Text = "";
                lbl_status_accno.Text = "";
            }
            else
            {
                lbl_status_company.Text = globalSettings.company_name;
                lbl_status_accno.Text = "(" + globalSettings.account_number + ")";
            }

            splasher.doUpdate("Checking in...");

            if (Util.getTerminalStatusFromServer())     // Also a check to see if there is connectivity
            {

                //Check for pending electra!
                // Moved to after startup else freezes bootup screen

                if (!globalSettings.advert_id_latest.Equals(globalSettings.advert_id))
                {

                    // Disabled Adverts for now //
                    globalSettings.advert_id = globalSettings.advert_id_latest;
                    globalSettings.advert_data = "";
                    globalSettings.SaveAdvert();

                    //webService.getNewAdvert();
                }
                if (!globalSettings.notice_id_latest.Equals(globalSettings.notice_id))
                {
                    splasher.doUpdate("Updating Notice...");
                    webService.getSystemNotice("");
                }

                if (!globalSettings.spi_ver_latest.Equals(globalSettings.spi_ver))
                {
                    if (!globalSettings.license_code.Equals("nolicense"))
                    {
                        String err = webService.get_update_all();
                        if (err.Length > 0)
                        {
                            Util.showMessage(err, Color.Red);
                        }
                    }
                }



                if (!globalSettings.sp_ver_latest.Equals(globalSettings.sp_ver))
                {

                    try
                    {

                        splasher.doUpdate("Updating Layout...(" + globalSettings.sp_ver + " -> " + globalSettings.sp_ver_latest + ")");

                        Web _wr_update = new Web(45000, 1, "");
                        String htmlResponse = _wr_update.GetURL("/terminal/update/get-update-sp");
                        _wr_update = null;

                        if (htmlResponse.IndexOf("err>") > -1 && !htmlResponse.Equals(""))
                        {
                            //
                        }
                        else
                        {

                            string filename = globalSettings.app_path + @"\conf\settings_layout.dat";
                            if (File.Exists(filename) == true) { File.Delete(filename); }
                            TextWriter tw = new StreamWriter(filename, false);
                            tw.Write(htmlResponse);
                            tw.Close();

                            globalSettings.sp_ver = globalSettings.sp_ver_latest;
                            globalSettings.SaveSPI();

                        }

                    }
                    catch
                    {
                        //
                    }

                }




                splasher.doUpdate("Fetching Financial Balance...");
                PopulateBalance(true);

            }

            splasher.doUpdate("Updating Interface...");

            try
            {
                Util.btngeneral0 = new Bitmap(globalSettings.app_path + @"\images\generalbtn0.gif");
                Util.btngeneral1 = new Bitmap(globalSettings.app_path + @"\images\generalbtn1.gif");
                Util.btngeneral2 = new Bitmap(globalSettings.app_path + @"\images\generalbtn2.gif");
                Util.btngeneral3 = new Bitmap(globalSettings.app_path + @"\images\generalbtn3.gif");
                Util.btngeneral4 = new Bitmap(globalSettings.app_path + @"\images\generalbtn4.gif");
                Util.btngeneral5 = new Bitmap(globalSettings.app_path + @"\images\generalbtn5.gif");
                Util.btngeneralsearch = new Bitmap(globalSettings.app_path + @"\images\generalbtnsearch.gif");
            }
            catch
            {
                //
            }

            try
            {
                setupLoginBtn(button1);
                setupLoginBtn(button2);
                setupLoginBtn(button3);
                setupLoginBtn(button4);
                setupLoginBtn(button5);
                setupLoginBtn(button6);
                setupLoginBtn(button7);
                setupLoginBtn(button8);
                setupLoginBtn(button9);
                setupLoginBtn(btnLoginC);
            }
            catch
            {
                //
            }




            //Byte[] bitmapData = Convert.FromBase64String(FixBase64ForImage(ImageText));
            //System.IO.MemoryStream streamBitmap = new System.IO.MemoryStream(bitmapData);
            //Bitmap bitImage = new Bitmap((Bitmap)Image.FromStream(streamBitmap));

            setupProviderButtons();






            //Util.getStockProviderUpdate(forceUpdate);

            splasher.doUpdate("Loading Settings...");

            Util.loadPosUsers();
            Util.loadSlipExtra();

            Util.loadProviderItem();
            Util.loadDisabledItems("admin");
            Util.loadDisabledItems("cashier");

            SetupNewItemButton(0, 0, 0);
            SetupNewItemButton(1, 1, 0);
            SetupNewItemButton(2, 2, 0);
            SetupNewItemButton(3, 3, 0);

            SetupNewItemButton(4, 0, 1);
            SetupNewItemButton(5, 1, 1);
            SetupNewItemButton(6, 2, 1);
            SetupNewItemButton(7, 3, 1);

            SetupNewItemButton(8, 0, 2);
            SetupNewItemButton(9, 1, 2);
            SetupNewItemButton(10, 2, 2);
            SetupNewItemButton(11, 3, 2);

            SetupNewItemButton(12, 0, 3);
            SetupNewItemButton(13, 1, 3);
            SetupNewItemButton(14, 2, 3);
            SetupNewItemButton(15, 3, 3);
            
            setupQuickPrintButtons();

            voucherPanel.Visible = false;

            lstMultiVoucher.SelectedIndexChanged += new EventHandler(lstMultiVoucher_SelectedIndexChanged);
            lstMultiVoucher.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            lstMultiVoucher.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstMultiVoucher_DrawItem);
            lstMultiVoucher.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.lstMultiVoucher_MeasureItem);


            try
            {
                byte[] data = Convert.FromBase64String(globalSettings.gen_tiu_contact);
                lblTiUConcact.Rtf = System.Text.Encoding.UTF8.GetString(data, 0, data.Length);
            } catch
            {
                //
            }

            splasher.doUpdate("Refreshing Wallet...");

            wallet_refresh();

            splasher.doUpdate("Refreshing Provider Settings...");

            enable_disable_provider_buttons();

            splasher.doUpdate("Updating Date and Time...");

            update_date_and_time();

            //splasher.doUpdate("Getting Default Printer...");


            //try
            //{
            //    if (!String.IsNullOrEmpty(globalSettings.advert_data))
            //    {
                    
            //        //picLoginAd.BackgroundImage = Image.FromFile(");

            //        //TODO !!!!!!

            //        //byte[] data = Convert.FromBase64String(globalSettings.advert_data);
            //        //String adverthtml = System.Text.Encoding.UTF8.GetString(data, 0, data.Length);

            //        //this.wbAdvert.Navigate("about:blank");
            //        //this.wbAdvert.Document.OpenNew(false);
            //        //this.wbAdvert.Document.Write(adverthtml);
            //        //this.wbAdvert.Refresh();
            //    }
            //}
            //catch
            //{
            //    //
            //}


        }




        private void setupProviderButtons()
        {

            //Setup Main Buttons
            for (int x = 0; x < 20; x++)
            {
                Util.btnProduct[x] = new btnProductType();
                Util.btnProduct[x].Name = "btndata" + x.ToString();
                Util.btnProduct[x].Visible = false;
            }


            int uid = 0;
            int uidrow = 0;
            String prevgroup = "";
            /* Load Layout Settings*/
            try
            {
                if (System.IO.File.Exists(globalSettings.app_path + @"\conf\settings_layout.dat"))
                {

                    System.IO.StreamReader myFile = new System.IO.StreamReader(globalSettings.app_path + @"\conf\settings_layout.dat");
                    string line;
                    while ((line = myFile.ReadLine()) != null)
                    {

                        if (line.Substring(0, 9).Equals("btngroup:"))
                        {

                            uid++;
                            

                            btnProductType newButtonGroup = new btnProductType();

                            newButtonGroup.Name = "btngroup" + uid.ToString();
                            newButtonGroup.Visible = false;

                            String get_btndata = line.Replace("btngroup:", "").Trim();


                            try
                            {
                                Newtonsoft.Json.Linq.JObject json = Newtonsoft.Json.Linq.JObject.Parse(get_btndata);

                                if (!String.IsNullOrEmpty((string)json["icon"])) newButtonGroup.icon = (string)json["icon"];
                                if (!String.IsNullOrEmpty((string)json["type"])) newButtonGroup.type = (string)json["type"];
                                if (!String.IsNullOrEmpty((string)json["id_parent"])) newButtonGroup.id_parent = (string)json["id_parent"];
                                if (!String.IsNullOrEmpty((string)json["spi"])) newButtonGroup.service_provider_id = (string)json["spi"];
                                if (!String.IsNullOrEmpty((string)json["btype"])) newButtonGroup.bill_payment_type = (string)json["btype"];
                                
                                if (!newButtonGroup.id_parent.Equals(prevgroup))
                                {
                                    prevgroup = (string)json["spi"];
                                    uidrow = 0; 
                                }
                                else {
                                    uidrow++; 
                                }



                                newButtonGroup.Width = 120;
                                newButtonGroup.Height = 72;
                                newButtonGroup.Image = load_image(globalSettings.app_path + @"\images\" + newButtonGroup.icon);

                                newButtonGroup.Visible = true;
                                if (globalSettings.gen_airtime == "0" && newButtonGroup.type.Equals("1")) newButtonGroup.Visible = false;
                                if (globalSettings.gen_elec == "0" && newButtonGroup.type.Equals("2")) newButtonGroup.Visible = false;
                                if (globalSettings.gen_rica == "0" && newButtonGroup.type.Equals("5")) newButtonGroup.Visible = false;
                                if (globalSettings.gen_bills == "0" && newButtonGroup.type.Equals("3")) newButtonGroup.Visible = false;
                                if (globalSettings.gen_pinless == "0" && newButtonGroup.service_provider_id.Equals("12")) newButtonGroup.Visible = false;

                                newButtonGroup.Click += new System.EventHandler(this.doItemActionProvider_Click);

                                Util.btnProductGroup.Add(newButtonGroup);

                                /* OLD ORIGINAL */
                                //Image btn_image = new Bitmap(globalSettings.app_path + @"\images\" + newButtonGroup.icon);
                                //newButtonGroup.BackgroundImage = btn_image;
                                //newButtonGroup.Visible = true;
                                //newButtonGroup.Click += new System.EventHandler(this.doItemActionProvider_Click);
                                //Util.btnProductGroup.Add(newButtonGroup);
                                /**/

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                            


                        }
                        else
                        {

                            for (int x = 0; x < 20; x++)
                            {

                                if (line.IndexOf("btndata" + x.ToString() + ":") >= 0)
                                {

                                    String get_btndata = line.Replace("btndata" + x.ToString() + ":", "").Trim();

                                    //Util.btnProduct[x] = new btnProductType();
                                    try
                                    {
                                        Newtonsoft.Json.Linq.JObject json = Newtonsoft.Json.Linq.JObject.Parse(get_btndata);
                                        if (!String.IsNullOrEmpty((string)json["icon"])) Util.btnProduct[x].icon = (string)json["icon"];
                                        if (!String.IsNullOrEmpty((string)json["type"])) Util.btnProduct[x].type = (string)json["type"];
                                        //if (!String.IsNullOrEmpty((string)json["id"])) Util.btnProduct[x].id = (string)json["id"];
                                        if (!String.IsNullOrEmpty((string)json["id_parent"])) Util.btnProduct[x].id_parent = (string)json["id_parent"];
                                        if (!String.IsNullOrEmpty((string)json["spi"])) Util.btnProduct[x].service_provider_id = (string)json["spi"];
                                        if (!String.IsNullOrEmpty((string)json["btype"])) Util.btnProduct[x].bill_payment_type = (string)json["btype"];
                                    
                                        Util.btnProduct[x].Parent = pnlProviderListOther;
                                        Util.btnProduct[x].Image = load_image(globalSettings.app_path + @"\images\" + Util.btnProduct[x].icon);

                                        Util.btnProduct[x].Visible = true;
                                        if (globalSettings.gen_airtime == "0" && Util.btnProduct[x].type.Equals("1")) Util.btnProduct[x].Visible = false;
                                        if (globalSettings.gen_elec == "0" && Util.btnProduct[x].type.Equals("2")) Util.btnProduct[x].Visible = false;
                                        if (globalSettings.gen_rica == "0" && Util.btnProduct[x].type.Equals("5")) Util.btnProduct[x].Visible = false;
                                        if (globalSettings.gen_bills == "0" && Util.btnProduct[x].type.Equals("3")) Util.btnProduct[x].Visible = false;
                                        if (globalSettings.gen_pinless == "0" && Util.btnProduct[x].service_provider_id.Equals("12")) Util.btnProduct[x].Visible = false;

                                        Util.btnProduct[x].Click += new System.EventHandler(this.doItemActionProvider_Click);

                                        //Image btn_image = new Bitmap(globalSettings.app_path + @"\images\" + Util.btnProduct[x].icon);
                                        //Util.btnProduct[x].BackgroundImage = btn_image;
                                        //Util.btnProduct[x].Visible = true;
                                        //Util.btnProduct[x].Click += new System.EventHandler(this.doItemActionProvider_Click);
                                       // MessageBox.Show(globalSettings.enable_cashms);
                                        if (globalSettings.enable_mamamoney.Equals("0") && Util.btnProduct[x].bill_payment_type.Equals("mamamoney"))
                                        {
                                            Util.btnProduct[x].Visible = false;
                                        }

                                       // else if (globalSettings.enable_cashms.Equals("0") && Util.btnProduct[x].bill_payment_type.Equals("cashms"))
                                       // {
                                        //    Util.btnProduct[x].Visible = false;
                                       // }
                                        else
                                        {
                                            if (x == 0) this.pnlProviderList.Controls.Add(Util.btnProduct[x], 0, 0);
                                            if (x == 1) this.pnlProviderList.Controls.Add(Util.btnProduct[x], 1, 0);
                                            if (x == 2) this.pnlProviderList.Controls.Add(Util.btnProduct[x], 2, 0);
                                            if (x == 3) this.pnlProviderList.Controls.Add(Util.btnProduct[x], 3, 0);
                                            if (x == 4) this.pnlProviderList.Controls.Add(Util.btnProduct[x], 4, 0);

                                            if (x == 5) this.pnlProviderList.Controls.Add(Util.btnProduct[x], 0, 1);
                                            if (x == 6) this.pnlProviderList.Controls.Add(Util.btnProduct[x], 1, 1);
                                            if (x == 7) this.pnlProviderList.Controls.Add(Util.btnProduct[x], 2, 1);
                                            if (x == 8) this.pnlProviderList.Controls.Add(Util.btnProduct[x], 3, 1);
                                            if (x == 9) this.pnlProviderList.Controls.Add(Util.btnProduct[x], 4, 1);

                                            if (x == 10) this.pnlProviderList.Controls.Add(Util.btnProduct[x], 0, 2);
                                            if (x == 11) this.pnlProviderList.Controls.Add(Util.btnProduct[x], 1, 2);
                                            if (x == 12) this.pnlProviderList.Controls.Add(Util.btnProduct[x], 2, 2);
                                            if (x == 13) this.pnlProviderList.Controls.Add(Util.btnProduct[x], 3, 2);
                                            if (x == 14) this.pnlProviderList.Controls.Add(Util.btnProduct[x], 4, 2);

                                            if (x == 15) this.pnlProviderList.Controls.Add(Util.btnProduct[x], 0, 3);
                                            if (x == 16) this.pnlProviderList.Controls.Add(Util.btnProduct[x], 1, 3);
                                            if (x == 17) this.pnlProviderList.Controls.Add(Util.btnProduct[x], 2, 3);
                                            if (x == 18) this.pnlProviderList.Controls.Add(Util.btnProduct[x], 3, 3);
                                            if (x == 19) this.pnlProviderList.Controls.Add(Util.btnProduct[x], 4, 3);
                                        }

                                    }
                                    catch
                                    {
                                        //
                                    }

                                    //parent_id
                                }


                            }

                        }

                    }
                    myFile.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }










            //myimage = new Bitmap(globalSettings.app_path + @"\images\prov51.png");

            //Util.btnProduct[9] = new btnProductType();
            //Util.btnProduct[9].BackgroundImage = myimage;
            //Util.btnProduct[9].location = 1;
            //Util.btnProduct[9].type = 2;
            //Util.btnProduct[9].service_provider_id = 0;
            //Util.btnProduct[1].Visible = true;
            //Util.btnProduct[9].Click += new System.EventHandler(this.doItemActionProvider_Click);

            //this.pnlProviderList.Controls.Add(Util.btnProduct[9], 0, 3);

        }





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
                Util.showMessage(ex.Message, Color.Red);
            }

            return bm;

        }


        private void tmr_download_images_Tick(object sender, EventArgs e)
        {

            tmr_download_images.Enabled = false;

            Util.showLoading(true, "Updating (" + missingImages.Count + ") system files...");

            for (var i = 0; i < missingImages.Count; i++)
            {
                download_image(missingImages[i]);
            }

            Util.popLoading.setText("Update complete, please restart.");
            Util.popLoading.setSubText("");
            Util.popLoading.showButton("Restart", "restart");
            Util.EnableInput(this, false);

        }


        private void download_image(String image_file_name)
        {

            try
            {

                if (System.IO.File.Exists(image_file_name))
                {
                    // Ok we found the file ? odd...
                }
                else
                {

                    Util.showMessage("Updating Image...", Color.Green);

                    String file_url = image_file_name.Replace(globalSettings.app_path + @"\images\", "/updates/img_tablet/");

                    Web WebResponse = new Web(50000);
                    bool dl_ok = WebResponse.GetURLSoftwareUpdate(file_url, image_file_name);
                    WebResponse = null;

                    if (dl_ok)
                    {
                        Util.showMessage("Image Updated.", Color.Green);
                    }
                    else
                    {
                        Util.showMessage("Image NOT Updated!", Color.Red);
                    }

                }

            }
            catch (Exception ex)
            {
                Util.showMessage(ex.Message, Color.Red);
            }

        }



        private Bitmap load_image(String image_file_name)
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

                    Util.showMessage("Updating Image...", Color.Green);

                    String file_url = image_file_name.Replace(globalSettings.app_path + @"\images\", "/updates/img_tablet/");

                    Web WebResponse = new Web(50000);
                    bool dl_ok = WebResponse.GetURLSoftwareUpdate(file_url, image_file_name);

                    //MessageBox.Show(WebResponse._ret_error);

                    WebResponse = null;

                    if (dl_ok)
                    {
                        Util.showMessage("Image Updated.", Color.Green);
                        bm = new Bitmap(image_file_name);
                    }
                    else
                    {
                        Util.showMessage("Image NOT Updated!", Color.Red);
                    }

                }

            }
            catch (Exception ex)
            {
                Util.showMessage(ex.Message, Color.Red);
            }

            return bm;

        }



        private void wallet_refresh()
        {

            if (!globalSettings.pos_user_admin) {
                if (globalSettings.gen_show_financials_cashier == "0")
                {
                    grp_financial.Visible = false;
                    return;
                }
            }

            if (globalSettings.gen_show_financials == "1")
            {
                    grp_financial.Show();
            }
            else
            {
                    grp_financial.Hide();
            }

        }
      



        private void SetupNewItemButton(int arrItemId, int row, int col)
        {

            try
            {
                btnItem[arrItemId] = new MyButton();

                btnItem[arrItemId].Click += new System.EventHandler(doItemAction_Click);

                this.voucherPanel.Controls.Add(btnItem[arrItemId], row, col);

                btnItem[arrItemId].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                btnItem[arrItemId].Dock = System.Windows.Forms.DockStyle.Fill;
                btnItem[arrItemId].Margin = new System.Windows.Forms.Padding(10);

                btnItem[arrItemId].FlatStyle = FlatStyle.Flat;
                btnItem[arrItemId].FlatAppearance.BorderSize = 0;

                btnItem[arrItemId].FlatAppearance.MouseDownBackColor = Color.LightGray;
                btnItem[arrItemId].FlatAppearance.MouseOverBackColor = Color.White;

                btnItem[arrItemId].Visible = true;
                btnItem[arrItemId].Font = new System.Drawing.Font("Arial", 32F, System.Drawing.FontStyle.Bold);

                btnItem[arrItemId].TabStop = false;
                btnItem[arrItemId].Cursor = Cursors.Hand;

                btnItem[arrItemId].Text = "btn" + arrItemId.ToString();
                btnItem[arrItemId].Tag = arrItemId.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private void loginBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            LoginKeyLogic(btn.Text);
        }


        private void LoginKeyLogic(string Key)
        {

            tmr_invalid_pin.Enabled = false;
            
            if (Key == "C")
            {

                _login_text = "";
                lbl_login.Text = "";
                lbl_login.Visible = false;
                _tiu_adminMode = false;
                picLoginPin.Visible = false;
                _emergencyMode = false;
                picTiUAdmin.Visible = false;

                return;
            }

            //if (lbl_login.Text == "Invalid PIN #")
            //{
            //    _login_text = "";
            //    lbl_login.Visible = false;
            //}

            if (lbl_login.Text == "Emergency")
            {
                _login_text = "";
            }

            _login_text = _login_text + Key;
            //string s = new string('#', _login_text.Length);
            //if (s.Length > 0 && s.Length < 5)
            //{
            //    lbl_login.Text = s;
            //}

            lbl_login.Text ="";
            lbl_login.Visible = false;

            picLoginPin.Visible = true;
            picLoginPin.Width = _login_text.Length * 46;
            picLoginPin.Refresh();

            if (_login_text.Length == 3 && _emergencyMode == true && _login_text == "911")
            {
                _emergencyMode = false;

                _login_text = "";

                lbl_login.Text = "Sending...";
                lbl_login.Refresh();

                if (wsSendAlarm())
                {
                    lbl_login.Text = "Emergency Sent";
                }

                tmr_invalid_pin.Enabled = true;

                return;

            }

            if (_login_text.Length > 3)
            {

                _emergencyMode = false;

                if (_tiu_adminMode)
                {

                    _tiu_adminMode = false;


                    // Retailer User Refresh
                    if (_login_text == "7777")
                    {

                        Util.showWait("Refreshing Active Users...");

                        try
                        {
                            string htmlresponse = webService.getPosUsers();
                            if (htmlresponse.Length == 0)
                            {
                                Util.loadPosUsers();
                                lbl_login.Text = "Complete.";
                            }
                            else
                            {
                                lbl_login.Text = "Error.";
                            }
                        }
                        catch
                        {
                            lbl_login.Text = "Connection Problem.";
                        }

                        picTiUAdmin.Visible = false;
                        picLoginPin.Visible = false;
                        _login_text = "";

                        tmr_invalid_pin.Enabled = true;

                        Util.showWait(false);

                        return;
                    }


                    if (Util.checkLoginAdmin(_login_text))
                    {

                        logoutTimer.Enabled = false;

                        Util.showWait(true);

                        frmTIUAdmin frmTIUAdmin = new frmTIUAdmin();
                        frmTIUAdmin.ShowDialog(this);

                        if (globalSettings.app_restart)
                        {
                            System.Diagnostics.Process.Start(@"\topitup\StartUp.exe");
                            this.Close();
                        }

                        lbl_login.Text = "";
                        lbl_login.Visible = false;

                    }
                    else
                    {
                        lbl_login.Text = "Invalid PIN #";
                        lbl_login.Visible = true;
                    }

                    picTiUAdmin.Visible = false;
                    picLoginPin.Visible = false;
                    _login_text = "";
                    
                    tmr_invalid_pin.Enabled = true;
                    return;

                }
                
                if (Util.checkLogin(_login_text, false))
                {
                    System.Threading.Thread.Sleep(200);
                    loginLogic();
                    picLoginPin.Visible = false;
                }
                else
                {
                    _login_text = "";
                    System.Threading.Thread.Sleep(200);
                    lbl_login.Text = "Invalid PIN #";
                    lbl_login.Visible = true;
                    tmr_invalid_pin.Enabled = true;
                    picLoginPin.Visible = false;
                }

            }

        }


        private void loginLogic()
        {

            //this.SuspendLayout();
            //Util.LockWindowUpdate(this.Handle);
            Util.SuspendDrawing(this);

            pnl_status_balance.Visible = false;
            
            //picLowBalanceWarningLogin.Visible = false;

            _login_text = "";
            lbl_login.Text = "";
            lbl_login.Visible = false;

            _progressState = 1;

            btnShowLogin.Enabled = true;


            btnLast10Sales.Text = "Sales" + Environment.NewLine + "History";
            btnReprintLast.Text = "Reprint Last" + Environment.NewLine + "Voucher";
            lstMultiVoucher.Items.Clear();
            is_multi_voucher_active = false;
            lbl_plnMultiTotal.Text = "Total (0)";
            lbl_plnMultiTotalValue.Text = "R 0.00";
            pnlMultiPrint.Hide();

            _providerPanelState = 0;
            //updateProviderPanel();

            btnReprintLast.Visible = true;
            btnLast10Sales.Visible = true;

            if (tmr_battery.Enabled) tmr_battery.Interval = 600000;

            if (globalSettings.pos_user_admin)
            {
                //pic_status_user.Image = global::TopitUp.Properties.Resources.user_icon_36_admin;
                lbl_status_user_type.Text = "(Admin)";
                lbl_status_user_type.ForeColor = Color.Firebrick;
                btnAdminOrXY.Text = "Admin";
                btnAdminOrXY.Visible = true;

                if (globalSettings.gen_cashier_allowreprintlast_admin.Equals("0")) btnReprintLast.Visible = false;

            }
            else
            {

                //if (globalSettings.gen_show_financials_cashier == "0") grp_finw1.Visible = false;

                //pic_status_user.Image = global::TopitUp.Properties.Resources.ico_user_36;
                lbl_status_user_type.Text = "(Cashier)";
                lbl_status_user_type.ForeColor = Color.Gray;

                if (globalSettings.gen_cashier_allowreprint.Equals("0"))     btnLast10Sales.Visible = false;
                if (globalSettings.gen_cashier_allowreprintlast.Equals("0")) btnReprintLast.Visible = false;

                if (globalSettings.gen_cashier_w.Equals("1") || globalSettings.gen_cashier_y.Equals("1") || globalSettings.gen_cashier_y_history.Equals("1"))
                {
                    btnAdminOrXY.Visible = true;
                    btnAdminOrXY.Text = "Cashup";
                }
                else
                {
                    btnAdminOrXY.Visible = false;
                }

            }

            if (globalSettings.gen_cashdr.Equals("1"))
            {
                btnOpenDrawer.Visible = true;
                if (!globalSettings.pos_user_admin && globalSettings.gen_cashdr_cashier.Equals("0"))
                {
                    btnOpenDrawer.Visible = false;
                }
            }

            btnMultiVouchersShow.Visible = false;
            if (globalSettings.gen_show_multi_voucher.Equals("1")) btnMultiVouchersShow.Visible = true;

            enable_disable_provider_buttons();

            globalSettings.pos_user_loggedin = true;

            lbl_status_user.Text = globalSettings.pos_user_fullname;

            pnlFooterLogin.Visible = false;

            pnlLHS.Visible = true;
            pnlRHS.Visible = true;

            tiuLogo.Enabled = false;

            PopulateBalance(false);
            
            wallet_refresh();

            pnl_status_bar.Visible = true;

            Application.DoEvents();

            pnlLogin.Visible = false;
            pnlFooterLogedin.Visible = true;

            tmr_fetch_update.Enabled = false;

            logoutTimer.Enabled = false;
            logoutTimer.Enabled = true;

            //Util.LockWindowUpdate(IntPtr.Zero);
            Util.ResumeDrawing(this);
            //this.ResumeLayout();

        }



        private void enable_disable_provider_buttons()
        {

            // todo: reset any drilldown product pages.

            if (globalSettings.pos_user_admin)
            {
                for (int x = 0; x < 20; x++)
                {
                    if (Util.btnProduct[x].type.Equals("2")) Util.btnProduct[x].Visible = true;
                    if (Util.btnProduct[x].type.Equals("3")) Util.btnProduct[x].Visible = true;
                }
            }
            else
            {
                for (int x = 0; x < 20; x++)
                {
                    if (Util.btnProduct[x].type.Equals("2")) Util.btnProduct[x].Visible = globalSettings.gen_cashier_elec_disabled.Equals("0");
                    if (Util.btnProduct[x].type.Equals("3")) Util.btnProduct[x].Visible = globalSettings.gen_cashier_bill_disabled.Equals("0");
                }
            }

            if (globalSettings.gen_airtime == "0")
            {
                for (int x = 0; x < 20; x++)
                {
                    if (Util.btnProduct[x].type.Equals("1")) Util.btnProduct[x].Visible = false;
                }
            }
            if (globalSettings.gen_elec == "0")
            {
                for (int x = 0; x < 20; x++)
                {
                    if (Util.btnProduct[x].type.Equals("2")) Util.btnProduct[x].Visible = false;
                }
            }
            if (globalSettings.gen_rica == "0")
            {
                for (int x = 0; x < 20; x++)
                {
                    if (Util.btnProduct[x].type.Equals("5")) Util.btnProduct[x].Visible = false;
                }
            }
            if (globalSettings.gen_bills == "0")
            {
                for (int x = 0; x < 20; x++)
                {
                    if (Util.btnProduct[x].type.Equals("3")) Util.btnProduct[x].Visible = false;
                }
            }
            if (globalSettings.gen_pinless == "0")
            {
                for (int x = 0; x < 20; x++)
                {
                    if (Util.btnProduct[x].type.Equals("7")) Util.btnProduct[x].Visible = false;
                }
            }
            if (globalSettings.gen_pinless == "0")
            {
                for (int x = 0; x < 20; x++)
                {
                    if (Util.btnProduct[x].type.Equals("6")) Util.btnProduct[x].Visible = false;
                }
            }

        }



        private void btnShowLogin_Click(object sender, EventArgs e)
        {

            ShowLogin();

        }

        private void ShowLogin()
        {

            Util.LockWindowUpdate(this.Handle);

            _progressState = 0;
            logoutTimer.Enabled = false;

            //this.SuspendLayout();

            if (tmr_battery.Enabled) tmr_battery.Interval = 30000;

            globalSettings.pos_user_admin = false;
            globalSettings.pos_user_id = "0";
            globalSettings.pos_user_admin = false;
            globalSettings.pos_user_loggedin = false;

            lbl_login.Text = "";
            lbl_login.Visible = false;
            lbl_status_user.Text = "";
            
            pnl_status_bar.Visible = false;

            pnlProviderListOther.Hide();
            closeVoucherPanel();

            login_update_balance("0.00");
            
            wbMessageGetMessage();

            pnlLHS.Visible = false;
            pnlRHS.Visible = false;
            pnlFooterLogin.Visible = true;

            pnlLogin.Visible = true;
            pnlFooterLogedin.Visible = false;

            grp_financial.Visible = false;

            btnLast10Sales.Visible = false;
            btnReprintLast.Visible = false;

            tiuLogo.Enabled = true;

            show_last_sale_login();

            if (globalSettings.gen_show_balance_login == "1") tmr_fetch_update.Enabled = true;

            //this.ResumeLayout();

            Util.LockWindowUpdate(IntPtr.Zero);

        }

        private void show_last_sale_login()
        {

            if (globalVoucher.lastSaleDetailAvailable && globalSettings.gen_show_last_sale_login == "1")
            {
                String rtf = _last_sale_rtf;

                rtf = rtf.Replace("[VOUCHER]", globalVoucher.last_voucher);
                rtf = rtf.Replace("[VALUE]", globalVoucher.last_value);
                rtf = rtf.Replace("[CASHIER]", globalVoucher.last_cashier);
                if (globalVoucher.last_dtm.Length > 0)
                {
                    lblLastSaleDtm.Text = "Sale Date: " + globalVoucher.last_dtm;
                }
                else
                {
                    lblLastSaleDtm.Text = "Sale Date: " + globalVoucher.last_dtm_date + ", " + globalVoucher.last_dtm_time;
                }

                txtLastSale.Rtf = rtf;

                picAdvertSmall.Hide();

            }
            else
            {
                picAdvertSmall.Show();
            }

        }

        private void wbMessageGetMessage()
        {

            if (!wbInfo.IsBrowserInitialized) return;

            try
            {

                if (!String.IsNullOrEmpty(globalSettings.notice_data))
                {
                    byte[] data = Convert.FromBase64String(globalSettings.notice_data);

                    String datahtml = System.Text.Encoding.UTF8.GetString(data, 0, data.Length);

                    wbInfo.LoadString(datahtml, "http://myfakeurl.com");

                    //this.wbInfo.Navigate("about:blank");
                    //this.wbInfo.Document.OpenNew(false);
                    //this.wbInfo.Document.Write(datahtml);
                    //this.wbInfo.Refresh();

                }
                else
                {

                    string datahtml = File.ReadAllText("c:/topitup/html/systemNotice.htm");
                    wbInfo.LoadString(datahtml, "http://myfakeurl.com");

                    //this.wbInfo.Url = new Uri("file://c:/topitup/html/systemNotice.htm");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }



        public bool wsSendAlarm()
        {

            string htmlResponse = "";
            bool ret = false;

            try
            {
                Web WebResponse = new Web(25000, 1, "");

                htmlResponse = WebResponse.GetURLSync("/message/emergency/?l=" + globalSettings.license_code);
                WebResponse = null;

                if (htmlResponse.IndexOf("err>") == -1)
                {
                    ret = true;
                }
                else
                {
                    ret = false;
                }
            }
            catch
            {
                ret = false;
            }

            return ret;
        }




     

        private void login_update_balance(String orig_available_balance)
        {

            if ((globalSettings.gen_show_balance_login == "0" || !finBalance.is_balance_available) || finBalance.available_balance.Equals("0.00"))
            {
                pnl_status_balance.Hide();
            }
            else
            {

                lbl_status_balance.Text = "R " + finBalance.available_balance;
                if (finBalance.low_balance == "1")
                {
                    pic_status_lb.Show();
                }
                else
                {
                    pic_status_lb.Hide();
                }
                pnl_status_balance.Show();

                // Dont Play sound if we just updating from login
                if (!orig_available_balance.Equals("0.00"))
                {

                    try{
                        if (Decimal.Parse(finBalance.available_balance.Replace(",", ""), System.Globalization.CultureInfo.InvariantCulture) > Decimal.Parse(orig_available_balance.Replace(",", ""), System.Globalization.CultureInfo.InvariantCulture))
                        {
                            lbl_login.Text = "Balance Updated";
                            lbl_login.Show();
                            Util.playSound("deposit.wav");
                        }
                    } catch {
                       //
                    }
                    

                }

            }

        }


        private void doItemActionProvider_Click(object sender, EventArgs e)
        {

            var btn = (btnProductType)sender;

            //provider.Tag

            //int provider_id = Convert.ToInt32(provider.Name.Replace("id_", ""));
          //  MessageBox.Show(btn.service_provider_id);
            if (btn.type.Equals("1"))
            {
              provider_airtime_show(Int32.Parse(btn.service_provider_id));
                btnVoucherBack.Visible = true;
            }
            if (btn.type.Equals("2"))
            {
                load_electricity_screen(btn.bill_payment_type);
            }
            if (btn.type.Equals("3"))
            {
                load_billpayment_screen(false);
            }
            if (btn.type.Equals("4"))
            {
                //load_stockitup_screen();
                load_billpayment_screen(true);
            }
            if (btn.type.Equals("5"))
            {
                load_rica_screen();
            }
            if (btn.type.Equals("6"))
            {
                load_pinless_screen();
            }
            if (btn.type.Equals("7"))
            {
                load_cashmanagement_screen();
            }
            if (btn.type.Equals("10"))
            {
                load_group_screen(btn.Name);
            }
            if (btn.type.Equals("21"))
            {
                load_ding_screen();
            }
        }


        private void showVoucherPanel(int provider_id, int selfcount)
        {

            _progressState = 2;
            _provider_id = provider_id;

            providerPanelPager.Visible = false;

            switch (provider_id)
            {
                case 1: picBoxProviderSmall.Image = global::TopitUp.Properties.Resources.prov1_small; break;
                case 2: picBoxProviderSmall.Image = global::TopitUp.Properties.Resources.prov2_small; break;
                case 3: picBoxProviderSmall.Image = global::TopitUp.Properties.Resources.prov3_small; break;
                case 4: picBoxProviderSmall.Image = global::TopitUp.Properties.Resources.prov4_small; break;
                case 5: picBoxProviderSmall.Image = global::TopitUp.Properties.Resources.prov5_small; break;
                case 7: picBoxProviderSmall.Image = global::TopitUp.Properties.Resources.prov7_small; break;
                case 10: picBoxProviderSmall.Image = global::TopitUp.Properties.Resources.prov10_small; break;
                case 11: picBoxProviderSmall.Image = global::TopitUp.Properties.Resources.prov11_small; break;
                case 12: picBoxProviderSmall.Image = global::TopitUp.Properties.Resources.prov12_small; break;


                case 23: picBoxProviderSmall.Image = global::TopitUp.Properties.Resources.prov_ikeja_small; break;
               case 25: picBoxProviderSmall.Image = global::TopitUp.Properties.Resources.prov_ott_small; break;
                default: picBoxProviderSmall.Image = global::TopitUp.Properties.Resources.btnlhs1; break;
            }
            picBoxProviderSmall.Visible = true;

            btnProvAirtime.Visible = true;
            btnProvData.Visible = true;
            btnProvSpecial.Visible = true;

            if (provider_id == 12)
            {
                btnProvAirtime.Visible = false;
                btnProvData.Visible = false;
                btnProvSpecial.Visible = false;
            }
            if (provider_id == 23)
            {
                btnProvAirtime.Visible = true;
                btnProvAirtime.Text = "Hotspot";
                btnProvData.Visible = false;
                btnProvSpecial.Visible = false;
            }
            else
            {
                btnProvAirtime.Text = "Airtime";
            }

            for (int x = 0; x < 16; x++)
            {
                btnItem[x].Visible = false;
            }

            voucher_prov_arr_id = -1;
            Boolean found_items = false;
            foreach (stockProvider sp in Util.stock_provider)
            {
                voucher_prov_arr_id++;
                if (sp.provider_id == provider_id)
                {
                    found_items = true;
                    break;
                }
            }

            if (!found_items)
            {

                voucherPanel.Show();
                logoutTimer.Enabled = true;
                return;
            }

            //bool show_button_airtime = false;
            //bool show_button_data = false;
            //bool show_button_special = false;


            int total_airtime = 0;
            int total_data = 0;
            int total_special = 0;
            bool show_item;
            
            try
            {
                for (int x = 0; x < Util.stock_provider[voucher_prov_arr_id].itemcount; x++)
                {

                    show_item = true;

                    if (globalSettings.pos_user_admin && !Util.stock_provider[voucher_prov_arr_id].item[x].visible_admin) show_item = false;
                    if (!globalSettings.pos_user_admin && !Util.stock_provider[voucher_prov_arr_id].item[x].visible_cashier) show_item = false;

                    if (show_item)
                    {
                        if (Util.stock_provider[voucher_prov_arr_id].item[x].item_type == 0) total_airtime++;
                        if (Util.stock_provider[voucher_prov_arr_id].item[x].item_type == 2) total_data++;
                        if (Util.stock_provider[voucher_prov_arr_id].item[x].item_type == 1) total_special++;
                        if (Util.stock_provider[voucher_prov_arr_id].item[x].item_type == 3) total_special++;
                        if (Util.stock_provider[voucher_prov_arr_id].item[x].item_type == 4) total_special++;
                    }
                }
            }
            catch
            {
                //
            }

            bool show_up_down = false;
            if (_productPanel == 0 && total_airtime > 16) show_up_down = true;
            if (_productPanel == 2 && total_data > 16) show_up_down = true;
            if (_productPanel == 1 && total_special > 16) show_up_down = true;

            if (!show_up_down)
            {
                _productPanelPage = 0;
            }
            else if (_productPanelPage < 0)
            {
                if (_productPanel == 0) _productPanelPage = (total_airtime - 1) / 16;
                if (_productPanel == 2) _productPanelPage = (total_data - 1) / 16;
                if (_productPanel == 1) _productPanelPage = (total_special - 1) / 16;
            }
            else
            {
                if (_productPanel == 0 && _productPanelPage > ((total_airtime - 1) / 16)) _productPanelPage = 0;
                if (_productPanel == 2 && _productPanelPage > ((total_data - 1) / 16)) _productPanelPage = 0;
                if (_productPanel == 1 && _productPanelPage > ((total_special - 1) / 16)) _productPanelPage = 0;
            }

            int total_displayed = 0;












            try
            {

                int btn_loc = 0;

                int new_location = -1;
                int x_start = 0;

                for (int x = 0; x < Util.stock_provider[voucher_prov_arr_id].itemcount; x++)
                {

                    show_item = true;

                    if (globalSettings.pos_user_admin)
                    {
                        if (!Util.stock_provider[voucher_prov_arr_id].item[x].visible_admin)
                            show_item = false;
                    }
                    else
                    {
                        if (!Util.stock_provider[voucher_prov_arr_id].item[x].visible_cashier)
                            show_item = false;
                    }

                    /* Airtime Panel */
                    if (_productPanel == 0 && Util.stock_provider[voucher_prov_arr_id].item[x].item_type != 0) show_item = false;
                    /* Data */
                    if (_productPanel == 2 && Util.stock_provider[voucher_prov_arr_id].item[x].item_type != 2) show_item = false;
                    /* Special Panel */
                    if (_productPanel == 1 && (Util.stock_provider[voucher_prov_arr_id].item[x].item_type == 0 || Util.stock_provider[voucher_prov_arr_id].item[x].item_type == 2)) show_item = false;


                    if (show_item) x_start++;
                    if (x_start < (_productPanelPage * 17)) show_item = false;


                    //if (Util.stock_provider[voucher_prov_arr_id].item[x].item_type == 0) show_button_airtime = true;
                    //if (Util.stock_provider[voucher_prov_arr_id].item[x].item_type == 2) show_button_data = true;
                    //if (Util.stock_provider[voucher_prov_arr_id].item[x].item_type == 1) show_button_special = true;
                    //if (Util.stock_provider[voucher_prov_arr_id].item[x].item_type == 3) show_button_special = true;
                    //if (Util.stock_provider[voucher_prov_arr_id].item[x].item_type == 4) show_button_special = true;


                    // Work out which page
                    if (show_item)
                    {
                        new_location++;
                        if (new_location > 16) show_item = false;
                        if (show_up_down && new_location > 15) show_item = false;
                        //if (show_up_down)
                       // {
                        //    if (new_location == 3 || new_location == 7 || new_location == 11) new_location++;
                        //}
                    }


                    if (!show_item)
                    {
                        //
                    }
                    else
                    {

                        //new_location++;
                        //if (new_location > 15) new_location = 15;
                        //btn_loc = new_location;
                        total_displayed++;
                        btn_loc = new_location;



                        if (Util.stock_provider[voucher_prov_arr_id].item[x].item_show_value)
                        {

                            btnItem[btn_loc].button_extra = "R " + Util.stock_provider[voucher_prov_arr_id].item[x].item_value;
                        }
                        else
                        {
                            btnItem[btn_loc].button_extra = "";
                        }
                       
                      
                            btnItem[btn_loc].Text = Util.stock_provider[voucher_prov_arr_id].item[x].item_btn_desc.Replace(@"\n", Environment.NewLine);

                        
                        btnItem[btn_loc].Tag = Util.stock_provider[voucher_prov_arr_id].item[x].item_id.ToString();

                        btnItem[btn_loc].checkSize();

                        btnItem[btn_loc].Visible = true;

                        if (provider_id == 12)
                        {
                            btnItem[btn_loc].ForeColor = Color.Black;
                            btnItem[btn_loc].BackgroundImage = global::TopitUp.Properties.Resources.btnvoucherSpecial;
                        }
                        else if (Util.stock_provider[voucher_prov_arr_id].item[x].item_type == 0)
                        {
                            if (provider_id == 23)
                            {
                                btnItem[btn_loc].Text = "";
                                if (x==0)
                                btnItem[btn_loc].BackgroundImage = global::TopitUp.Properties.Resources.btnvoucherik1;
                                else if (x == 1)
                                    btnItem[btn_loc].BackgroundImage = global::TopitUp.Properties.Resources.btnvoucherik2;
                                else if (x == 2)
                                    btnItem[btn_loc].BackgroundImage = global::TopitUp.Properties.Resources.btnvoucherik3;
                                else if (x == 3)
                                    btnItem[btn_loc].BackgroundImage = global::TopitUp.Properties.Resources.btnvoucherik4;
                                else if (x == 4)
                                    btnItem[btn_loc].BackgroundImage = global::TopitUp.Properties.Resources.btnvoucherik5;
                                else
                                    btnItem[btn_loc].BackgroundImage = global::TopitUp.Properties.Resources.btnvoucherAirtime;
                            }
                            else {
                            btnItem[btn_loc].ForeColor = Color.Black;
                            btnItem[btn_loc].BackgroundImage = global::TopitUp.Properties.Resources.btnvoucherAirtime;
                             }
                        }
                        else if (Util.stock_provider[voucher_prov_arr_id].item[x].item_type == 1)
                        {
                            btnItem[btn_loc].ForeColor = Color.FromArgb(0, 114, 54);
                            btnItem[btn_loc].BackgroundImage = global::TopitUp.Properties.Resources.btnvouchersms0;
                        }
                        else if (Util.stock_provider[voucher_prov_arr_id].item[x].item_type == 2)
                        {
                            btnItem[btn_loc].ForeColor = Color.FromArgb(0, 118, 163);
                            btnItem[btn_loc].BackgroundImage = global::TopitUp.Properties.Resources.btnvoucherdata0;
                        }
                        else if (Util.stock_provider[voucher_prov_arr_id].item[x].item_type == 3)
                        {
                            btnItem[btn_loc].ForeColor = Color.FromArgb(158, 11, 15);
                            btnItem[btn_loc].BackgroundImage = global::TopitUp.Properties.Resources.btnvoucherall0;
                        }
                        else if (Util.stock_provider[voucher_prov_arr_id].item[x].item_type == 4)
                        {
                            btnItem[btn_loc].ForeColor = Color.FromArgb(88, 88, 88);
                            btnItem[btn_loc].BackgroundImage = global::TopitUp.Properties.Resources.btnvoucherSpecial;
                        }


                    }


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




            if (show_up_down)
            {

                int total_items = 0;
                if (_productPanel == 0) total_items = total_airtime;
                if (_productPanel == 2) total_items = total_data;
                if (_productPanel == 1) total_items = total_special;

                String qty_desc = total_items.ToString();
                if (_productPanel == 0) qty_desc = qty_desc + Environment.NewLine + "Airtime" + Environment.NewLine + "Products";
                if (_productPanel == 2) qty_desc = qty_desc + Environment.NewLine + "Data" + Environment.NewLine + "Bundles";
                if (_productPanel == 1) qty_desc = qty_desc + Environment.NewLine + "Special" + Environment.NewLine + "Items";


                if (_productPanelPage == 0)
                {
                    providerItemCount2.Text = "1 - " + total_displayed.ToString();
                }
                else
                {
                    providerItemCount2.Text = (((_productPanelPage) * 16) + 1) + " - " + (((_productPanelPage) * 16) + total_displayed);
                }

                providerItemCount.Text = qty_desc;

                providerPanelPager.Visible = true;
                providerPanelPager.BringToFront();

                btn_panel_up.Visible = true;
                if (_productPanelPage <= 0) btn_panel_up.Visible = false;
                btn_panel_down.Visible = true;

                if (_productPanel == 0 && _productPanelPage >= ((total_airtime - 1) / 16)) btn_panel_down.Visible = false;
                if (_productPanel == 2 && _productPanelPage >= ((total_data - 1) / 16)) btn_panel_down.Visible = false;
                if (_productPanel == 1 && _productPanelPage >= ((total_special - 1) / 16)) btn_panel_down.Visible = false;

            }




            //btnProvAirtime.Visible = show_button_airtime;
            //btnProvData.Visible = show_button_data;
            //btnProvSpecial.Visible = show_button_special;


            btnProvData.Visible = (total_data > 0);
            btnProvSpecial.Visible = (total_special > 0);


            //if (selfcount == 0)
            //{
            //    if (!show_button_airtime && show_button_data)
            //    {
            //        set_provider_lhs_default(2, 1);
            //    }
            //    else if (!show_button_airtime && show_button_special)
            //    {
            //        set_provider_lhs_default(1, 1);
            //    }
            //}

            voucherPanel.Show();

            logoutTimer.Enabled = true;

        }


        private void doItemAction_Click(object sender, EventArgs e)
        {


            MyButton btnClick = (MyButton)sender;

            //MessageBox.Show(btnClick.Tag.ToString());

            if (is_multi_voucher_active) {
                multiVoucher mv = new multiVoucher();

                mv.service_provider_item_id = Int32.Parse(btnClick.Tag.ToString());

                int arr_id = -1;
                try
                {
                    foreach (stockProvider sp in Util.stock_provider)
                    {
                        arr_id++;
                        for (int x = 0; x < Util.stock_provider[arr_id].itemcount; x++)
                        {
                            if (mv.service_provider_item_id.ToString() == Util.stock_provider[arr_id].item[x].item_id.ToString())
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
                   //
                }

                try
                {
                    mv.item_value = Decimal.Parse(Util.stock_provider[voucher_prov_arr_id].item[voucher_item_arr_id].item_value, System.Globalization.CultureInfo.InvariantCulture);
                }
                catch
                {
                    //
                }

                try
                {
                    mv.item_description = "R " + mv.item_value.ToString()  + Environment.NewLine + Util.stock_provider[voucher_prov_arr_id].provider_desc + " " + Util.stock_provider[voucher_prov_arr_id].item[voucher_item_arr_id].item_print_desc;
                }
                catch
                {
                    //
                }

                lstMultiVoucher.Items.Add(mv);

                update_multivoucher_status();
            } else
            {
                voucherPanelShow(btnClick.Tag.ToString(), false);
            }
            
            

        }


        

        private void voucherPanelShow(string item_id, bool is_quick_print)
        {

            logoutTimer.Enabled = false;

            if (globalSettings.gen_show_voucher_only.Equals("0") && (!Util.getDefaultPrinterStatus(true) || Util.OutOfPaper()))
            {
                Util.showPrinterProblem(true, "",false);
                return;
            }

            frmAirtime frmAirtime = new frmAirtime(lstMultiVoucher);
            frmAirtime._is_quick_print = is_quick_print;
            frmAirtime._item_id = item_id;
            frmAirtime.ShowDialog(this);

            PopulateBalance(false);
            login_update_balance("0.00");

            if (globalSettings.gen_logout == "1")
            {
                ShowLogin();
            }
            else
            {

                btnLast10Sales.Text = "Sales" + Environment.NewLine + "History";
                btnReprintLast.Text = "Reprint Last" + Environment.NewLine + "Voucher";
                pnlQuickPrint.Show();
                pnlMultiPrint.Hide();

                lstMultiVoucher.Items.Clear();
                lbl_plnMultiTotal.Text = "Total (0)";
                lbl_plnMultiTotalValue.Text = "R 0.00";

                is_multi_voucher_active = false;

                logoutTimer.Enabled = true;
            }
            
        }


        private void closeVoucherPanel()
        {

            picBoxProviderSmall.Visible = false;
            btnProvAirtime.Visible = false;
            btnProvData.Visible = false;
            btnProvSpecial.Visible = false;
            voucherPanel.Visible = false;
            btnVoucherBack.Visible = false;
            providerPanelPager.Visible = false;

        }




        private void PopulateBalance(bool force_from_web)
        {

            fin_lbl3.Visible = false;
            credit_limit.Visible = false;
            fin_lbl4.Visible = false;
            credit_extended.Visible = false;

            if (force_from_web) finBalance.getBalance(0);

            try
            {

                available_balance.Text = "R " + finBalance.available_balance;
                balance.Text = "R " + finBalance.balance;

                if (finBalance.cash_customer.Equals("0"))
                {

                    balance_cash.Text = "R " + finBalance.balance_cash;
                    fin_lbl_cash.Show();
                    balance_cash.Show();

                    credit_limit.Text = "R " + finBalance.credit_limit;
                    fin_lbl3.Visible = true;
                    credit_limit.Visible = true;

                }

                if (finBalance.credit_extended != "0.00")
                {
                    credit_extended.Text = "R " + finBalance.credit_extended;
                    fin_lbl4.Visible = true;
                    credit_extended.Visible = true;

                    fin_lbl_cash.Left = 771;
                    balance_cash.Left = 771;
                    picLowBalanceWarningLogin.Left = 908;

                }
                else
                {
                    fin_lbl_cash.Left = 621;
                    balance_cash.Left = 621;
                    picLowBalanceWarningLogin.Left = 771;
                }

                fin_lbl_date.Text = finBalance.dtmd + ", " + finBalance.dtmt;
                picLowBalanceWarningLogin.Visible = finBalance.low_balance == "1";

            }
            catch (Exception ex)
            {
                Util.showMessage(ex.Message, Color.Red);
            }


        }



        //private void reprintFromSerial(String SerialToReprint)
        //{

        //    int reprint_type = 1;

        //    String ret = webService.getReprint(reprint_type, SerialToReprint);

        //    if (ret == "OK")
        //    {
        //        Util.doReprintLogic();
        //    }
        //    else
        //    {
        //        Util.showMessage("Incorrect voucher number!", Color.Red);
        //    }

        //}


        private void btnSettings_Click(object sender, EventArgs e)
        {


            logoutTimer.Enabled = false;


            if (!globalSettings.pos_user_admin)
            {

                frmCashup frmCashup = new frmCashup();
                frmCashup.ShowDialog(this);

            }
            else
            {

                Util.showWait(true);

                closeVoucherPanel();

                String advert_data_original = globalSettings.advert_data;

                frmAdmin frmAdmin = new frmAdmin();
                frmAdmin.ShowDialog(this);

                Util.showWait(false);

                if (globalSettings.app_restart)
                {
                    System.Diagnostics.Process.Start(@"\topitup\StartUp.exe");
                    this.Close();
                }

                Util.SuspendDrawing(this);

                setupQuickPrintButtons();

                if (globalSettings.gen_show_last_sale_login == "0")
                {
                    picAdvertSmall.Show();
                }

                if (!advert_data_original.Equals(globalSettings.advert_data))
                {
                    globalSettings.advert_id_latest = globalSettings.advert_id;
                    try
                    {
                        if (!String.IsNullOrEmpty(globalSettings.advert_data))
                        {
                            //byte[] data = Convert.FromBase64String(globalSettings.advert_data);
                            //String adverthtml = System.Text.Encoding.UTF8.GetString(data, 0, data.Length);

                            //this.wbAdvert.Navigate("about:blank");
                            //this.wbAdvert.Document.OpenNew(false);
                            //this.wbAdvert.Document.Write(adverthtml);
                            //this.wbAdvert.Refresh();

                            //TODO !!!!

                            //this.wbAdvert.DocumentText = adverthtml;
                        }
                    }
                    catch
                    {
                        //
                    }
                }
             
                grp_financial.Visible = false;

                _providerPanelState = 0;
                //enableDisableProviders();

                logoutTimer.Interval = globalSettings.gen_logout_time;

                wallet_refresh();

                ShowLogin();

                Util.ResumeDrawing(this);

            }
            
        }
        

        private void setupQuickPrintButtons()
        {

            if (globalSettings.gen_quick_print_disable.Equals("1") || globalSettings.customer_accept.Equals("0") || globalSettings.gen_airtime.Equals("0"))
            {
                btnQP1.Visible = false;
                btnQP2.Visible = false;
                btnQP3.Visible = false;
                btnQP4.Visible = false;
                btnQP5.Visible = false;
            }
            else
            {

                btnQP1.Text = "";
                btnQP2.Text = "";
                btnQP3.Text = "";
                btnQP4.Text = "";
                btnQP5.Text = "";

                int arr_id = -1;
                try
                {
                    foreach (stockProvider sp in Util.stock_provider)
                    {
                        arr_id++;
                        for (int x = 0; x < Util.stock_provider[arr_id].itemcount; x++)
                        {
                            if (globalSettings.quickprint_item1 == Util.stock_provider[arr_id].item[x].item_id.ToString())
                            {
                                btnQP1.Text = Util.stock_provider[arr_id].item[x].item_quickprint;
                                if (Util.stock_provider[arr_id].item[x].item_show_value) btnQP1.Text += Environment.NewLine + "R " + Util.stock_provider[arr_id].item[x].item_value;
                            }

                            if (globalSettings.quickprint_item2 == Util.stock_provider[arr_id].item[x].item_id.ToString())
                            { 
                                btnQP2.Text = Util.stock_provider[arr_id].item[x].item_quickprint;
                                if (Util.stock_provider[arr_id].item[x].item_show_value) btnQP2.Text += Environment.NewLine + "R " + Util.stock_provider[arr_id].item[x].item_value;
                            }
                            if (globalSettings.quickprint_item3 == Util.stock_provider[arr_id].item[x].item_id.ToString())
                            {
                                btnQP3.Text = Util.stock_provider[arr_id].item[x].item_quickprint;
                                if (Util.stock_provider[arr_id].item[x].item_show_value) btnQP3.Text += Environment.NewLine + "R " + Util.stock_provider[arr_id].item[x].item_value;
                            }
                            if (globalSettings.quickprint_item4 == Util.stock_provider[arr_id].item[x].item_id.ToString())
                            {
                                btnQP4.Text = Util.stock_provider[arr_id].item[x].item_quickprint;
                                if (Util.stock_provider[arr_id].item[x].item_show_value) btnQP4.Text += Environment.NewLine + "R " + Util.stock_provider[arr_id].item[x].item_value;
                            }
                            if (globalSettings.quickprint_item5 == Util.stock_provider[arr_id].item[x].item_id.ToString())
                            {
                                btnQP5.Text = Util.stock_provider[arr_id].item[x].item_quickprint;
                                if (Util.stock_provider[arr_id].item[x].item_show_value) btnQP5.Text += Environment.NewLine + "R " + Util.stock_provider[arr_id].item[x].item_value;
                            }

                        }
                    }
                }
                catch 
                {
                    //
                }

                btnQP1.Visible = (btnQP1.Text.Equals("")) ? false : true;
                btnQP2.Visible = (btnQP2.Text.Equals("")) ? false : true;
                btnQP3.Visible = (btnQP3.Text.Equals("")) ? false : true;
                btnQP4.Visible = (btnQP4.Text.Equals("")) ? false : true;
                btnQP5.Visible = (btnQP5.Text.Equals("")) ? false : true;
            }

        }




        private void load_group_screen(String group)
        {

            this.pnlProviderListOther.Controls.Clear();

            _productPanel = 0;

            logoutTimer.Enabled = false;
            logoutTimer.Enabled = true;

            int row = -1;
            int r = 0;
            for (int x = 0; x < Util.btnProductGroup.Count; x++)
            {
                if (Util.btnProductGroup[x].id_parent.Equals(group))
                {
                    row++;
                    if (row > 4) r = 1;
                    this.pnlProviderListOther.Controls.Add(Util.btnProductGroup[x], (row % 4), r);
                }
            }

            btnProvAirtime.Visible = false;
            btnProvData.Visible = false;
            btnProvSpecial.Visible = false;

            //this.pnlProviderListOther.Controls.Add(Util.btnProductGroup[0], 0, 0);
            //this.pnlProviderListOther.Controls.Add(Util.btnProductGroup[1], 1, 0);
            //this.pnlProviderListOther.Controls.Add(Util.btnProductGroup[2], 2, 0);

            //if (uidrow == 3) this.pnlProviderListOther.Controls.Add(newButtonGroup, 3, 0);
            //if (uidrow == 4) this.pnlProviderListOther.Controls.Add(newButtonGroup, 0, 1);
            //if (uidrow == 5) this.pnlProviderListOther.Controls.Add(newButtonGroup, 1, 1);
            //if (uidrow == 6) this.pnlProviderListOther.Controls.Add(newButtonGroup, 2, 1);
            //if (uidrow == 7) this.pnlProviderListOther.Controls.Add(newButtonGroup, 3, 1);

            if (System.IO.File.Exists(globalSettings.app_path + @"\images\" + group + "_small.gif"))
            {
                Image btn_image = new Bitmap(globalSettings.app_path + @"\images\" + group + "_small.gif");
                picBoxProviderSmall.Image = btn_image;
                picBoxProviderSmall.Visible = true;
            }
            else
            {
                picBoxProviderSmall.Visible = false;
            }
               

            
            btnVoucherBack.Visible = true;

            pnlProviderListOther.Show();



        }

        private void load_cashmanagement_screen()
        {

            logoutTimer.Enabled = false;

            closeVoucherPanel();

            Util.showLoading(true, "Loading Cash Management Services.");
            Util.EnableInput(this, false);

            Thread t = new Thread(new ThreadStart(threadCheckForDllUpdateCashms));
            t.Start();

          // frmCashManagement frmCashManagement = new frmCashManagement();
           // frmCashManagement.ShowDialog(this);

           // ShowLogin();

        }


        private void threadCheckForDllUpdateCashms()
        {

            try
            {
                string filename_update = globalSettings.app_path + @"\update\cashms.dll";
                if (File.Exists(filename_update) == true) { File.Delete(filename_update); }
            }
            catch
            {
                //
            }

            bool new_version_available = false;

            Web WebResponse = new Web(15000, 2, "");
            String htmlResponse = WebResponse.GetURL("/terminal/general/get-dll-version?dll=cashmswin10");
            WebResponse = null;


            //Console.WriteLine("current v: " + globalSettings.dll_version_cashms);
            //Console.WriteLine(htmlResponse);


            if (htmlResponse.Equals("")) {
                this.Invoke((System.Threading.ThreadStart)delegate
                {
                    Util.hideLoading();
                    Util.showMessage("No Cash Management Version!", Color.Red);
                });
                return;
            }

            if (htmlResponse.IndexOf("err>") > -1)
            {
                this.Invoke((System.Threading.ThreadStart)delegate
                {
                    Util.EnableInput(this, true);
                });
                this.Invoke((System.Threading.ThreadStart)delegate
                {
                    Util.hideLoading();
                });
                this.Invoke((System.Threading.ThreadStart)delegate
                {
                    Util.showMessage(htmlResponse.StripErrorTags(), Color.Red);
                });
                return;
            }
            else
            {
                if (!htmlResponse.Equals(globalSettings.dll_version_cashms)) new_version_available = true;
            }


            if (new_version_available && globalSettings.dll_version_cashms_runonce)
            {
                this.Invoke((System.Threading.ThreadStart)delegate
                {
                    Util.popLoading.setText("Update available, please restart.");
                    Util.popLoading.setSubText("");
                    Util.popLoading.showButton("Restart", "restart");
                    Util.EnableInput(this, false);
                });
                return;
            }


            string filename = Path.Combine(globalSettings.app_path, "cashms.dll");
            if (!File.Exists(filename)) { new_version_available = true; }


            if (new_version_available)
            {

                //Console.WriteLine("getting new version");

                this.Invoke((System.Threading.ThreadStart)delegate
                {
                    Util.popLoading.setText("Downloading...");
                    Util.popLoading.setSubText("Please wait...");
                });

                Web WebResp = new Web(120000);
                bool dl_ok = WebResp.GetURLSoftwareUpdate(@"/updates/win10/cashms.dll", globalSettings.app_path + @"\update\cashms.dll");
                WebResp = null;

                Console.WriteLine(dl_ok);

                if (dl_ok)
                {

                    try
                    {
                        if (File.Exists(filename) == true) { File.Delete(filename); }

                        System.IO.File.Move(Path.Combine(globalSettings.app_path, @"update\cashms.dll"), filename);

                        this.Invoke((System.Threading.ThreadStart)delegate
                        {
                            Util.showMessage("Cash Ms Updated", Color.Green);
                        });

                    }
                    catch (Exception ex)
                    {
                        this.Invoke((System.Threading.ThreadStart)delegate
                        {
                            Util.showMessage(ex.Message, Color.Red);
                        });
                    }

                }
                else
                {
                    this.Invoke((System.Threading.ThreadStart)delegate
                    {
                        Util.showMessage("Unable to download update.", Color.Red);
                    });
                }

            }

            try
            {

                this.Invoke((System.Threading.ThreadStart)delegate
                {
                    Util.hideLoading();
                });

                Assembly DLL = Assembly.LoadFrom(filename);
                Type classType = DLL.GetType("cashms.frmCashMs");
                Form form = (Form)Activator.CreateInstance(classType);
                form.ShowDialog(); // Or Application.Run(form)

                form.Dispose();
                DLL = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Invoke((System.Threading.ThreadStart)delegate
            {
                Util.EnableInput(this, true);
            });
            this.Invoke((System.Threading.ThreadStart)delegate
            {
                Util.hideLoading();
            });

        }











        private void load_pinless_screen()
        {
            logoutTimer.Enabled = false;

            closeVoucherPanel();

            frmPinless frmPinless = new frmPinless();
            frmPinless.ShowDialog(this);

            ShowLogin();
        }


        private void load_rica_screen()
        {
            if (!globalSettings.pos_user_rica_registered)
            {
                Util.showMessage("You are currently not registered for RICA.", Color.White);
                return;
            }

            logoutTimer.Enabled = false;

            Util.showWait(true);

            closeVoucherPanel();

            RICA frmRica = new RICA();
            frmRica.ShowDialog(this);

            ShowLogin();
        }

        private void load_stockitup_screen()
        {

            //

        }

        private void load_billpayment_screen(bool is_mamamoney)
        {

            logoutTimer.Enabled = false;

            if (globalSettings.gen_show_voucher_only.Equals("0") && (!Util.getDefaultPrinterStatus(true) || Util.OutOfPaper()))
            {
                Util.showPrinterProblem(true, "", false);
                return;
            }

            Util.showWait(true);

            closeVoucherPanel();

            frmBillPayments frmBillPayments = new frmBillPayments();

            frmBillPayments.is_mamamoney = is_mamamoney;

          frmBillPayments.ShowDialog(this);

            ShowLogin();

        }



        private void load_ding_screen()
        {


            if (globalSettings.gen_show_voucher_only.Equals("0") && (!Util.getDefaultPrinterStatus(true) || Util.OutOfPaper()))
            {
                Util.showPrinterProblem(true, "", false);
                return;
            }

            Util.showWait(true);

            logoutTimer.Enabled = false;
            closeVoucherPanel();

            frmDing frmDing = new frmDing();
            frmDing.ShowDialog(this);

            //if (Util.showUniPIN)
            //{
            //    Util.showUniPIN = false;
            //    logoutTimer.Enabled = true;
            //    provider_airtime_show(12);
            //    btnVoucherBack.Visible = true;
            //    return;
            //}

            if (globalSettings.gen_logout == "1")
            {
                ShowLogin();
            }
            else
            {
                logoutTimer.Enabled = true;
            }

        }



        private void load_electricity_screen(string vending_type)
        {

         
            if (globalSettings.gen_show_voucher_only.Equals("0") && (!Util.getDefaultPrinterStatus(true) || Util.OutOfPaper()))
            {
                Util.showPrinterProblem(true,"",false);
                return;
            }

            Util.showWait(true);

            logoutTimer.Enabled = false;
            closeVoucherPanel();

            frmElectricity frmElec = new frmElectricity();
            globalSettings.vending_type = vending_type;
             frmElec.ShowDialog(this);

            //if (Util.showUniPIN)
            //{
            //    Util.showUniPIN = false;
            //    logoutTimer.Enabled = true;
            //    provider_airtime_show(12);
            //    btnVoucherBack.Visible = true;
            //    return;
            //}

            if (globalSettings.gen_logout == "1")
            {
                ShowLogin();
            }
            else
            {
                logoutTimer.Enabled = true;
            }

        }
        


        private void btnLast10Sales_Click(object sender, EventArgs e)
        {

            logoutTimer.Enabled = false;

            if (btnLast10Sales.Text.Equals("Cancel" + Environment.NewLine + "Multi Vouchers"))
            {

                btnLast10Sales.Text = "Sales" + Environment.NewLine + "History";
                btnReprintLast.Text = "Reprint Last" + Environment.NewLine + "Voucher";
                pnlQuickPrint.Show();
                pnlMultiPrint.Hide();

                lstMultiVoucher.Items.Clear();
                lbl_plnMultiTotal.Text = "Total (0)";
                lbl_plnMultiTotalValue.Text = "R 0.00";

                is_multi_voucher_active = false;

                logoutTimer.Enabled = true;
                return;
            }

            logoutTimer.Enabled = false;

            Util.showWait(true);

            frmPrintLast frmPrintLast = new frmPrintLast();
            frmPrintLast.ShowDialog(this);

            logoutTimer.Enabled = true;

        }

     

        private void btnLoginCalc_Click(object sender, EventArgs e)
        {

            Util.showWait(true);

            frmCalculator frmCalculator = new frmCalculator();
            frmCalculator.ShowDialog(this);

            Util.showWait(false);

        }

        private void btnLoginActivationInfo_Click(object sender, EventArgs e)
        {

            Util.showWait(true);

            frmWebBrowser frmWebBrowser = new frmWebBrowser(false);
            frmWebBrowser.Nav("http://" + globalSettings.sync_hostname + ":" + globalSettings.sync_port + "/message/activation/?l=" + globalSettings.license_code);
            frmWebBrowser.ShowDialog(this);

            Util.showWait(false);
        }

        private void btnLoginBanking_Click(object sender, EventArgs e)
        {

            Util.showWait(true);

            frmWebBrowser frmWebBrowser = new frmWebBrowser(false);
            frmWebBrowser.Nav("http://" + globalSettings.sync_hostname + ":" + globalSettings.sync_port + "/message/bankdetails/1/?l=" + globalSettings.license_code);
            frmWebBrowser.ShowDialog(this);

            Util.showWait(false);
        }


        private void btnLoginOrder_Click(object sender, EventArgs e)
        {

            Util.showWait(true);

            //frmWebBrowser.Nav("http://" + globalSettings.sync_hostname + ":" + globalSettings.sync_port + "/message/simkits/?l=" + globalSettings.license_code);

            frmOrderSimKits frmOrderSimKits = new frmOrderSimKits();
            frmOrderSimKits.ShowDialog(this);

            Util.showWait(false);

        }


        private void logoutTimer_Tick(object sender, EventArgs e)
        {

            logoutTimer.Enabled = false;
            ShowLogin();

        }

        private void tiuLogo_Click(object sender, EventArgs e)
        {


           // MessageBox.Show(globalSettings.customer_id);

            
            if (globalSettings.customer_id == "167")
            {

                logoutTimer.Enabled = false;

                Util.showWait(true);

                frmTIUAdmin frmTIUAdmin = new frmTIUAdmin();
                frmTIUAdmin.ShowDialog(this);

                if (globalSettings.app_restart)
                {
                    System.Diagnostics.Process.Start(@"\topitup\StartUp.exe");
                    this.Close();
                }

                lbl_login.Text = "";
                lbl_login.Visible = false;
                _login_text = "";
                picLoginPin.Visible = false;

            }
            else
            {

                picLoginPin.Visible = false;
                picTiUAdmin.Visible = true;
                _tiu_adminMode = true;
                _login_text = "";
                lbl_login.Visible = true;
                tmr_invalid_pin.Enabled = true;

            }

            

        }


        private void tmrUpdateDateTime_Tick(object sender, EventArgs e)
        {
            update_date_and_time();
        }


        private void update_date_and_time()
        {
            lblDtmGlobalTime.Text = DateTime.Now.ToString("t");
            lblDtmGlobalDate.Text = DateTime.Now.ToString("ddd, d MMM yyyy");
        }




        private void btnEmergency_Click(object sender, EventArgs e)
        {

            tmr_invalid_pin.Enabled = false;
            _emergencyMode = true;
            lbl_login.Text = "";

            lbl_login.Visible = true;
            lbl_login.Text = "Emergency";
         
        }

     

  
        private void btnReprintLast_Click(object sender, EventArgs e)
        {

            if (is_multi_voucher_active)
            {

                voucherPanelShow("-1", false);

            } else { 

                String ret = webService.getReprint(3, "");

                if (ret == "OK")
                {
                    Util.doReprintLogic();
                }
                else
                {
                    Util.showMessage(ret,Color.Red);
                }

            }

        }



       


      
     
        //private void updateProviderPanel()
        //{

        //    if (_providerPanelState == 0)
        //    {
                
        //        //id_3.Visible = true;
        //        id_2.Visible = true;
        //        id_1.Visible = true;
        //        id_4.Visible = true;
        //        id_11.Visible = true;
        //        id_10.Visible = true;
        //        id_5.Visible = true;

        //        //id_13.Visible = false;
        //        id_7.Visible = true;

        //    }
        //    else
        //    {
        //        //id_3.Visible = false;
        //        id_2.Visible = false;
        //        id_1.Visible = false;
        //        id_4.Visible = false;
        //        id_11.Visible = false;
        //        id_10.Visible = false;
        //        id_5.Visible = false;

        //        //id_13.Visible = true;
        //        id_7.Visible = false;
        //    }

        //    enable_disable_provider_buttons();

        //}

        private void btnBalanceRefresh_Click(object sender, EventArgs e)
        {

            Util.showWait(true);

            logoutTimer.Enabled = false;

            btnBalanceRefresh.Visible = false;
            btnBalanceRefresh.Refresh();

            PopulateBalance(true);
            //checkLowBalanceStatus();

            btnBalanceRefresh.Visible = true;
            logoutTimer.Enabled = true;

            Util.showWait(false);

        }




       


        private void provider_airtime_show(int provider_id)
        {

            logoutTimer.Enabled = false;
            logoutTimer.Enabled = true;

            _productPanel = 0;
            btnProvAirtime.ForeColor = Color.White;
            btnProvSpecial.ForeColor = Color.FromArgb(128, 0, 0);
            btnProvData.ForeColor = Color.FromArgb(128, 0, 0);
            btnProvData.BackgroundImage = global::TopitUp.Properties.Resources.prov_extra0;
            btnProvSpecial.BackgroundImage = global::TopitUp.Properties.Resources.prov_extra0;
            btnProvAirtime.BackgroundImage = global::TopitUp.Properties.Resources.prov_extra1;

            if (provider_id > 0) showVoucherPanel(provider_id,0);
        }

        private void set_provider_lhs_default(int item_type, int self_count)
        {

            if (item_type == 2)
            {
                _productPanel = 2;
                btnProvData.ForeColor = Color.White;
                btnProvAirtime.ForeColor = Color.FromArgb(128, 0, 0);
                btnProvSpecial.ForeColor = Color.FromArgb(128, 0, 0);
                btnProvData.BackgroundImage = global::TopitUp.Properties.Resources.prov_extra1;
                btnProvSpecial.BackgroundImage = global::TopitUp.Properties.Resources.prov_extra0;
                btnProvAirtime.BackgroundImage = global::TopitUp.Properties.Resources.prov_extra0;
            }
            else
            {
                _productPanel = 1;
                btnProvSpecial.ForeColor = Color.White;
                btnProvData.ForeColor = Color.FromArgb(128, 0, 0);
                btnProvAirtime.ForeColor = Color.FromArgb(128, 0, 0);
                btnProvData.BackgroundImage = global::TopitUp.Properties.Resources.prov_extra0;
                btnProvSpecial.BackgroundImage = global::TopitUp.Properties.Resources.prov_extra1;
                btnProvAirtime.BackgroundImage = global::TopitUp.Properties.Resources.prov_extra0;
            }

            showVoucherPanel(_provider_id, self_count);

        }


        private void btnProvAirtime_Click(object sender, EventArgs e)
        {
            provider_airtime_show(_provider_id);
        }

        private void btnProvData_Click(object sender, EventArgs e)
        {
            set_provider_lhs_default(2,0);
        }

        private void btnProvSpecial_Click(object sender, EventArgs e)
        {
            set_provider_lhs_default(1,0);
        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = pnlHeader.CreateGraphics();

            Rectangle panelRect = pnlHeader.ClientRectangle;

            Point p1 = new Point(panelRect.Left, panelRect.Top); //top left
            Point p2 = new Point(panelRect.Right-1, panelRect.Top); //Top Right
            Point p3 = new Point(panelRect.Left, panelRect.Bottom-1); //Bottom Left
            Point p4 = new Point(panelRect.Right - 1, panelRect.Bottom -1); //Bottom

            Pen pen1 = new Pen(System.Drawing.Color.White);
            Pen pen2 = new Pen(System.Drawing.Color.LightGray);

            g.DrawLine(pen1, p1, p2);
            g.DrawLine(pen1, p1, p3);
            g.DrawLine(pen1, p2, p4);
            g.DrawLine(pen2, p3, p4);
        }

   

        private void btnVoucherBack_Click(object sender, EventArgs e)
        {
            pnlProviderListOther.Hide();
            closeVoucherPanel();
        }

        private void grp_finw1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = grp_financial.CreateGraphics();

            Rectangle panelRect = grp_financial.ClientRectangle;

            Point p1 = new Point(panelRect.Left, panelRect.Top); //top left
            Point p2 = new Point(panelRect.Right - 1, panelRect.Top); //Top Right
            Point p3 = new Point(panelRect.Left, panelRect.Bottom - 1); //Bottom Left
            Point p4 = new Point(panelRect.Right - 1, panelRect.Bottom - 1); //Bottom

            Pen pen1 = new Pen(System.Drawing.Color.White);
            Pen pen2 = new Pen(System.Drawing.Color.LightGray);

            g.DrawLine(pen2, p1, p2);
            g.DrawLine(pen1, p1, p3);
            g.DrawLine(pen1, p2, p4);
            g.DrawLine(pen1, p3, p4);
        }

        private void btnLoginMsgService_Click(object sender, EventArgs e)
        {

            Util.showWait(true);

            frmWebBrowser frmWebBrowser = new frmWebBrowser(true);
            frmWebBrowser.Nav("http://" + globalSettings.sync_hostname + ":" + globalSettings.sync_port + "/message/msg/?l=" + globalSettings.license_code);
            frmWebBrowser.ShowDialog(this);

            Util.showWait(false);

        }

        private void tmr_invalid_pin_Tick(object sender, EventArgs e)
        {

            lbl_login.Text = "";
            _tiu_adminMode = false;
            tmr_invalid_pin.Enabled = false;
            picTiUAdmin.Visible = false;

        }




        private void tmr_fetch_update_Tick(object sender, EventArgs e)
        {
            tmr_fetch_update.Enabled = false;
            async_getBalanceFromServer();
            tmr_fetch_update.Enabled = true;
        }
        private async void async_getBalanceFromServer()
        {

            await Task.Run(() => GetBalanceFromServer());
            login_update_balance(_origAvailableBalance);

        }



        String _origAvailableBalance = "";
        private void GetBalanceFromServer()
        {


            /**/
                webService.setTrackPrint();
            /**/


            _origAvailableBalance = finBalance.available_balance;
            finBalance.getBalance(0);
            //login_update_balance(_origAvailableBalance);

            globalSettings.notice_id_latest = globalSettings.notice_id;
            webService.getSystemNotice(globalSettings.notice_id);
            if (!globalSettings.notice_id_latest.Equals(globalSettings.notice_id))
            {
                globalSettings.notice_id_latest = globalSettings.notice_id;
                wbMessageGetMessage();
            }

        }



        
        private void btnOpenDrawer_Click(object sender, EventArgs e)
        {

            if (!Util.getDefaultPrinterStatus(true) || Util.OutOfPaper())
            {
                Util.showPrinterProblem(true, "", true);
                return;
            }

            Util.OpenCashDrawer();

        }



        private void setupLoginBtn(Button btn)
        {
            btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnLoginMouseDown);
            btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnLoginMouseUp);
        }

        private void btnLoginMouseDown(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.BackgroundImage = global::TopitUp.Properties.Resources.login_btn_pressed;
        }

        private void btnLoginMouseUp(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Text.Equals("C"))
            {
                btn.BackgroundImage = global::TopitUp.Properties.Resources.login_btn_clear;
            } else {
                btn.BackgroundImage = global::TopitUp.Properties.Resources.login_btn_normal;
            }
        }




        private void tmr_check_status_Tick(object sender, EventArgs e)
        {
            tmr_check_status.Enabled = false;
            async_getSystemStatus();
        }

        private async void async_getSystemStatus()
        {
            await Task.Run(() => getSystemStatus());
            tmr_check_status.Enabled = true;
        }


        private void getSystemStatus()
        {

            try
            {

                bool internetstatus_visibility = !Util.IsConnectedToInternet();

                if (this.pnlWrapperNoInternet.InvokeRequired)
                {
                    this.pnlWrapperNoInternet.Invoke((MethodInvoker) delegate()
                    {
                        this.pnlWrapperNoInternet.Visible = internetstatus_visibility;
                    });
                }
                else
                {
                    this.pnlWrapperNoInternet.Visible = internetstatus_visibility;
                }

            } catch (Exception e) {
                //Util.showMessage("1: " + e.Message, Color.Red);
            }

            try
            {
                if (globalSettings.printer_name.Equals("")) {
                    //
                } else {

                    bool printerstatus_visibility = !Util.getDefaultPrinterStatus(false);

                    if (this.pnlWrapperPrinter.InvokeRequired)
                    {
                        this.pnlWrapperPrinter.Invoke((MethodInvoker) delegate()
                        {
                            this.pnlWrapperPrinter.Visible = printerstatus_visibility;
                        });
                    }
                    else
                    {
                        this.pnlWrapperPrinter.Visible = printerstatus_visibility;
                    }

                }

            }
            catch (Exception e)
            {
               // Util.showMessage("2: " + e.Message, Color.Red);
            }


        }


        private bool _is_there_a_battery = true;
        private void tmr_battery_Tick(object sender, EventArgs e)
        {
            tmr_battery.Enabled = false;
            async_getBatteryStatus();
        }

        private async void async_getBatteryStatus()
        {
            await Task.Run(() => getBatteryStatus());
            tmr_battery.Enabled = _is_there_a_battery;
        }

        private int _batterychargestatus = -1;
        private void getBatteryStatus()
        {

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("EN-US");

            Double dblBatteryLifePercent = 0;
            try
            {
                dblBatteryLifePercent = Math.Round(SystemInformation.PowerStatus.BatteryLifePercent * 100,2);
            } catch
            { 
                //
            }

            try
            {

                String strBatteryLifePercent = dblBatteryLifePercent.ToString() + "%";

                switch (SystemInformation.PowerStatus.BatteryChargeStatus)
                {
                    case BatteryChargeStatus.Charging:
                        status_battery.Text = "Charging" + Environment.NewLine + strBatteryLifePercent;
                        break;
                    case BatteryChargeStatus.Critical:
                    case BatteryChargeStatus.Low:

                        if (SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Online)
                        {
                            status_battery.Text = "Charging" + Environment.NewLine + strBatteryLifePercent;
                        }
                        else
                        {
                            status_battery.Text = "Low Power";
                        }
                        
                        break;

                    case BatteryChargeStatus.NoSystemBattery:
                        _batterychargestatus = 128;
                        pnlWrapperCharge.Visible = false;
                        _is_there_a_battery = false;
                        return;
                    case BatteryChargeStatus.Unknown:
                        _batterychargestatus = 255;
                        pnlWrapperCharge.Visible = false;
                        return;
                    default:
                        status_battery.Text = "Charged" + Environment.NewLine + strBatteryLifePercent;
                        break;
                }

                switch (SystemInformation.PowerStatus.PowerLineStatus)
                {
                    case PowerLineStatus.Online:
                        status_battery_img.Image = TopitUp.Properties.Resources.charging0;
                        if (_batterychargestatus != 0)
                        {
                            status_battery_img.Image = TopitUp.Properties.Resources.charging0;
                            _batterychargestatus = 0;
                            Util.playSound("connect.wav");
                        }
                        break;
                    case PowerLineStatus.Offline:
                        status_battery.Text = "Unplugged" + Environment.NewLine + strBatteryLifePercent;
                        if (_batterychargestatus != 1)
                        {
                            status_battery_img.Image = TopitUp.Properties.Resources.charging1;
                            _batterychargestatus = 1;
                            Util.playSound("connect.wav");
                        }
                        break;
                }

            }
            catch
            {
                //
            }



        }





        private void network_conn_settings_Click(object sender, EventArgs e)
        {

            Util.showWait(true);

            frmConnectionSettings frmConnectionSettings = new frmConnectionSettings();
            frmConnectionSettings.ShowDialog(this);

            Util.showWait(false);

        }

        private void btnQP1_Click(object sender, EventArgs e)
        {
            voucherPanelShow(globalSettings.quickprint_item1, true);
        }

        private void btnQP2_Click(object sender, EventArgs e)
        {
            voucherPanelShow(globalSettings.quickprint_item2, true);
        }

        private void btnQP3_Click(object sender, EventArgs e)
        {
            voucherPanelShow(globalSettings.quickprint_item3, true);
        }

        private void btnQP4_Click(object sender, EventArgs e)
        {
            voucherPanelShow(globalSettings.quickprint_item4, true);
        }

        private void btnQP5_Click(object sender, EventArgs e)
        {
            voucherPanelShow(globalSettings.quickprint_item5, true);
        }

        private void frmTopitUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            Util.showWaitClose();
            Util.showPrinterClose();

            try{
                Cef.Shutdown();
            }
            catch
            {
                //
            }


        }

        private void btn_take_screenshot_Click(object sender, EventArgs e)
        {
            //string[] filePaths = Directory.GetFiles(@"c:\topitup\screenshots\new", "*.png");

            //foreach (String file in filePaths)
            //{
            //    try
            //    {
            //        File.Move(file, file.Replace(@"c:\topitup\screenshots\new\", @"c:\topitup\screenshots\sent\"));
            //    }
            //    catch
            //    {
            //        //
            //    }
            //}

            try
            {

                Rectangle b = new Rectangle();
                b.Width = Screen.PrimaryScreen.Bounds.Width;
                b.Height = Screen.PrimaryScreen.Bounds.Height;
                Bitmap bmp = new Bitmap(b.Width, b.Height);
                Graphics g = Graphics.FromImage(bmp);
                g.CopyFromScreen(Point.Empty, Point.Empty, b.Size);

                String file_name = DateTime.Now.ToString("yyyyMMddHHmmssfff");

                bmp.Save(@"c:\topitup\screenshots\new\" + file_name + ".png", System.Drawing.Imaging.ImageFormat.Png);

                Util.showMessage("Screen image saved. Sending to Top it Up.", Color.White);
                Util.playSound("camera_click1.wav");

                Util.syncScreenshots();

            }
            catch
            {
                Util.showMessage("Could not capture screen image.", Color.Red);
            }

        }

        private void btn_panel_up_Click(object sender, EventArgs e)
        {
            logoutTimer.Enabled = false;
            logoutTimer.Enabled = true;
            _productPanelPage++;
            showVoucherPanel(_provider_id,0);
        }

        private void btn_panel_down_Click(object sender, EventArgs e)
        {
            logoutTimer.Enabled = false;
            logoutTimer.Enabled = true;
            _productPanelPage--;
            showVoucherPanel(_provider_id,0);
        }





        Boolean is_multi_voucher_active = false;

        private void btnMultiVouchersShow_Click(object sender, EventArgs e)
        {

            logoutTimer.Enabled = false;
            logoutTimer.Enabled = true;

            pnlMultiPrint.BringToFront();
            pnlMultiPrint.Show();

            btnLast10Sales.Text = "Cancel" + Environment.NewLine + "Multi Vouchers";
            btnReprintLast.Text = "Print Multi" + Environment.NewLine + "Vouchers";

            is_multi_voucher_active = true;

    }



        private void lstMultiVoucher_SelectedIndexChanged(object sender, System.EventArgs e)
        {


            //multiVoucher x = (multiVoucher)lstMultiVoucher.SelectedItem;
            //MessageBox.Show(x.service_provider_item_id.ToString() + " -- " + x.item_value.ToString());

            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(lstMultiVoucher);
            selectedItems = lstMultiVoucher.SelectedItems;

            if (lstMultiVoucher.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    lstMultiVoucher.Items.Remove(selectedItems[i]);
            }
            else
            {
                //
            }

            update_multivoucher_status();
         

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
            e.Graphics.DrawLine(Pens.LightGray, e.Bounds.X, e.Bounds.Y +  e.Bounds.Height - 2, e.Bounds.X + e.Bounds.Width, e.Bounds.Y + e.Bounds.Height - 2);


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

            logoutTimer.Enabled = false;
            logoutTimer.Enabled = true;

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



    }





    public class multiVoucher
    {

        public int service_provider_item_id = 0;
        public String item_description = "";
        public Decimal item_value = 0.0M;

        public override string ToString()
        {
            return item_description;
        }

    }


    public class RenderProcessMessageHandler : IRenderProcessMessageHandler
    {
        public void OnContextReleased(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {
            throw new NotImplementedException();
        }

        public void OnFocusedNodeChanged(IWebBrowser browserControl, IBrowser browser, IFrame frame, IDomNode node)
        {
            throw new NotImplementedException();
        }

        // Wait for the underlying `Javascript Context` to be created, this is only called for the main frame.
        // If the page has no javascript, no context will be created.
        void IRenderProcessMessageHandler.OnContextCreated(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {
            //const string script = "document.addEventListener('DOMContentLoaded', function(){ alert('DomLoaded'); });";

            //frame.ExecuteJavaScriptAsync(script);
        }
    }



}

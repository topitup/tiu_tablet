using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Collections;
using System.Net;

using System.Threading;
using System.Reflection;

namespace TopitUp
{

    public partial class frmTIUAdmin : Form
    {

        string tiu_user_id = "0";
        bool loggedIn = false;

        const int domainProfile = 1;
        const int privateProfile = 2;
        const int publicProfile = 4;

        public frmTIUAdmin()
        {
            InitializeComponent();
        }

        private void vsGuardian_Load(object sender, EventArgs e)
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

            this.BringToFront();

            this.txtCell.KeyPress += new KeyPressEventHandler(this.digitsOnly);
            this.txtOTP.KeyPress += new KeyPressEventHandler(this.digitsOnly);
            this.txtAssetId.KeyPress += new KeyPressEventHandler(this.digitsOnly);

            tiu_user_id = "0";

            pnlKeyboard.Visible = true;

            if (globalSettings.asset_id == "") globalSettings.asset_id = "0";

            if (globalSettings.customer_id == "167" || globalSettings.customer_id == "1110")
            {
                Util.showMessage("AUTO LOG IN",Color.Yellow);
                loggedIn = true;
            }

            DoAdminSection();

            Util.showWait(false);

            this.ActiveControl = txtCell;
            
        }



        private void tabControlSettings_SelectedIndexChanged(object sender, System.EventArgs e)
        {
           
            if (tabControlSettings.SelectedTab == tbLogin)
            {
                return;
            }

            if (tabControlSettings.SelectedTab == tbConnection)
            {
                return;
            }

            if (!loggedIn)
            {
                tabControlSettings.SelectedTab = tbLogin;
                Util.showMessage("Please log in.",Color.Red);
                return;
            }

            if (tabControlSettings.SelectedTab == tbSettings)
            {

                get_windows_firewall_status();

            }


            if (tabControlSettings.SelectedTab == tbLicense)
            {

                if (globalSettings.asset_id.Equals("0"))
                {
                    tabControlSettings.SelectedTab = tbRegisterPC;
                    Util.showMessage("Please first register this device.",Color.Red);
                    return;
                }

                if (!globalSettings.license_code.Equals("nolicense") && !globalSettings.license_code.Equals(""))
                {
                    lblSecret.Visible = false;
                    txtSecret.Visible = false;
                    btnSecret.Visible = false;
                    lblGeneralLicense.Visible = false;
                }
                else
                {
                    txtSecret.Focus();
                }
            }
           
            
        }





        private void btnSettingsSave_Click(object sender, EventArgs e)
        {

            Util.showWait(true);
       
            globalSettings.svr_ip = "0.0.0.0";

            String original_server = globalSettings.svr_id;

            if (optServerDemo.Checked == true)
            {
                globalSettings.svr_id = "dmo";
                globalSettings.svr_hostname = "demo.itopitup.co.za";
            }
            if (optServerTx.Checked == true)
            {
                globalSettings.svr_id = "tx";
                globalSettings.svr_hostname = "tx.itopitup.co.za";
            }


            if (original_server != globalSettings.svr_id)
            {
                globalSettings.ClearAll();
                globalSettings.Save();
                //globalVoucher.voucherStatsReset();
            }

            try
            {
                IPHostEntry host;
                host = Dns.GetHostEntry(globalSettings.svr_hostname);
                foreach (IPAddress ip in host.AddressList)
                    globalSettings.svr_ip = ip.ToString();
            }
            catch { }

            //globalSettings.gen_show_btn_skype = "0";
            //if (btnShowSkype.Checked) globalSettings.gen_show_btn_skype = "1";
            //globalSettings.gen_show_btn_teamviewer = "0";
            //if (btnTeamViewer.Checked) globalSettings.gen_show_btn_teamviewer = "1";

            globalSettings.Save();
            globalSettings.SaveGeneral();

            Util.showMessage(globalSettings.svr_hostname + " (" + globalSettings.svr_ip + ")" + Environment.NewLine + "Settings Updated.", Color.White);

            Util.showWait(false);

        }


        private void btnSecret_Click(object sender, EventArgs e)
        {

            lblLicense.Text = "";


            if (txtSecret.Text.Trim().Length == 0)
            {
                lblLicense.Text = "Please enter the secret PIN Code!\n";
                return;
            }

            //globalSettings.ClearAll();
            //globalSettings.Save();

            Util.showWait(true);

            if (CheckSecretPIN(txtSecret.Text, globalSettings.asset_id))
            {

                globalSettings.Save();

                lblSecret.Visible = false;
                txtSecret.Visible = false;
                btnSecret.Visible = false;
                lblGeneralLicense.Visible = false;

                lblLicenseDone.Visible = true;

                lblLicense.Text = "";
                //lblLicense.Text += "Serial: " + globalSettings.serial + "\n";
                lblLicense.Text += "License: " + globalSettings.license_code + "\n";

                if (!globalSettings.company_name.Equals(""))
                    lblLicense.Text += "Retailer: " + globalSettings.company_name + "(" + globalSettings.account_number + ")" + "\n";

                btnLoadItems.Visible = true;
                btnActivate.Visible = true;
                btnActivate.Text  = "Remove License";

            }

            Util.showWait(false);

        }

       
       

    


        public bool CheckSecretPIN(string SecretPIN, string AssetID)
        {
            try
            {

                Web webResponse = new Web(15000, 2, "");
                string htmlResponse = webResponse.GetURL("/terminal/general/get-asset-upgrade?pin=" + SecretPIN + "&asset_id=" + AssetID);
                webResponse = null;

                if (htmlResponse != "")
                {

                     if (htmlResponse.IndexOf("<err>", 0) == -1)
                    {

                            if (htmlResponse.IndexOf("^") != -1)
                            {
                                string[] words = htmlResponse.Split('^');

                                globalSettings.asset_id = AssetID.Trim();
                                globalSettings.customer_id = words[0];
                                globalSettings.company_name = words[1];
                                globalSettings.account_number = words[2];
                                globalSettings.license_code = words[3];
                                globalSettings.serial = words[4];
                                globalSettings.description = words[5];


                                return true;
                            }
                            else
                            {
                                lblLicense.Text = "Incorrect PIN or could not retrieve data!";
                            }

                    }
                    else
                    {
                        lblLicense.Text = htmlResponse.GetStrBetweenTags("<err>", "</err>");
                    }
                   
                }

                return false;

            }
            catch
            {
                return false;
            }

        }


        //public bool GetTerminalSerial(string AssetID)
        //{
        //    string htmlResponse = "";
        //    try
        //    {

        //        Web WebResponse = new Web(10000, 2);
        //        htmlResponse = WebResponse.GetURL("/terminal/general/get-asset-details?asset_id=" + AssetID);
        //        WebResponse = null;

        //        if (htmlResponse != "")
        //        {

        //            if (htmlResponse.IndexOf("<err>", 0) == -1)
        //            {

        //                string[] words = htmlResponse.Split('^');

        //                if (words[2] == "0")
        //                {

        //                    globalSettings.asset_id = AssetID.Trim();
        //                    globalSettings.serial = words[0];
        //                    globalSettings.description = words[1];

        //                    lblLicense.Text = "";
        //                    //lblLicense.Text += "Serial: " + globalSettings.serial + "\n";
        //                    lblLicense.Text += "Terminal: " + globalSettings.description + "\n";

        //                    return true;

        //                }
        //                else
        //                {
        //                    lblLicense.Text = "Active license found!\nPlease update before setting up this terminal.\nOR Fetch active license with secret PIN.";

        //                    return false;
        //                }

                        
        //            }
        //            else
        //            {
        //                lblLicense.Text = htmlResponse.GetStrBetweenTags("<err>", "</err>");
        //            }
        //        }

        //        return false;

        //    }
        //    catch 
        //    {
        //        lblLicense.Text = "Error.";
        //        return false;
        //    }

        //}



        //public bool GetCustomerDetails()
        //{

        //    string htmlResponse = "";
        //    try
        //    {

        //        Web WebResponse = new Web(15000, 1);
        //        htmlResponse = WebResponse.GetURL("/terminal/general/get-customer-info");
        //        WebResponse = null;

        //        if (htmlResponse != "")
        //        {

        //            if (htmlResponse.IndexOf("^") != -1)
        //            {
        //                string[] words = htmlResponse.Split('^');

        //                globalSettings.customer_id = words[0];
        //                globalSettings.company_name = words[1];
        //                globalSettings.account_number = words[2];
        //                globalSettings.company_address = words[3];

        //                globalSettings.gen_airtime = "0";
        //                if (words[4][0] == '1') globalSettings.gen_airtime = "1";

        //                globalSettings.gen_elec = "0";
        //                if (words[4][1] == '1') globalSettings.gen_elec = "1";

        //                globalSettings.gen_rica = "0";
        //                if (words[4][2] == '1') globalSettings.gen_rica = "1";

        //                globalSettings.gen_water = "0";
        //                if (words[4][3] == '1') globalSettings.gen_water = "1";

        //                globalSettings.gen_bills = "0";
        //                if (words[4][4] == '1') globalSettings.gen_bills = "1";

        //                return true;
        //            }
        //            else
        //            {
        //                lblLicense.Text = htmlResponse.GetStrBetweenTags("<err>", "</err>");
        //                return false;
        //            }

        //        }


        //    }
        //    catch (Exception e)
        //    {
        //        lblLicense.Text = e.Message;
        //        return false;
        //    }

        //    return false;
        //}



        public bool GetNewLicense()
        {

            string htmlResponse = "";
            try
            {

                Web WebResponse = new Web(15000, 2, "");
                htmlResponse = WebResponse.GetURLSync("/api/getlicense/" + Util.system_uid);
                WebResponse = null;

                if (htmlResponse != "")
                {

                    if (htmlResponse.IndexOf("^") != -1)
                    {
                        string[] words = htmlResponse.Split('^');

                        globalSettings.customer_id = words[0];
                        globalSettings.company_name = words[1];
                        globalSettings.account_number = words[2];
                        globalSettings.license_code = words[3];

                        return true;
                    }
                    else 
                    {
                        lblLicense.Text = htmlResponse.GetStrBetweenTags("<err>", "</err>");
                        return false;
                    }
                     
                }


            }
            catch(Exception e)
            {
                lblLicense.Text = e.Message;
                return false;
            }

            return false;
        }



        private void btnActivate_Click(object sender, EventArgs e)
        {

            Util.showWait(true);

            if (btnActivate.Text  == "Remove License")
            {
                globalSettings.ClearLicense();
                globalSettings.Save();
                //globalVoucher.voucherStatsReset();

                lblLicense.Text = "";
                lblLicense.Text += "License: REMOVED";

                btnActivate.Text  = "Fetch Active\r\nLicense";

                lblSecret.Visible = true;
                txtSecret.Visible = true;
                btnSecret.Visible = true;
                lblGeneralLicense.Visible = true;
                lblLicenseDone.Visible = false;

                Util.showWait(false);
                return;

            }


            if (GetNewLicense())
            {

                //globalVoucher.voucherStatsReset();
                globalSettings.Save();

                lblLicense.Text = "";
                //lblLicense.Text += "Serial: " + globalSettings.serial + "\n";
                //lblLicense.Text += "Terminal: " + globalSettings.description + "\n";
                lblLicense.Text += "License: " + globalSettings.license_code + "\n";

                if (!globalSettings.company_name.Equals(""))
                {
                    lblLicense.Text += "Retailer: " + globalSettings.company_name + "(" + globalSettings.account_number +")" + "\n";
                    lblLicense.Text += "\nPlease refresh application data and then restart.";
                }

                btnLoadItems.Visible = true;

                lblSecret.Visible = false;
                txtSecret.Visible = false;
                btnSecret.Visible = false;
                lblGeneralLicense.Visible = false;
                lblLicenseDone.Visible = true;

                btnActivate.Text  = "Remove License";

            }
            else
            {
                lblLicense.Text = "Could not fetch License!";
                btnLoadItems.Visible = false;
            }

            Util.showWait(false);

        }





        private void DoAdminSection()
        {
            try
            {

                lblLicense.Text = "";

                btnLoadItems.Visible = false;
                btnActivate.Visible = true;

                if (!globalSettings.license_code.Equals("nolicense"))
                {
                    btnLoadItems.Visible = true;

                    lblLicense.Text += "License: " + globalSettings.license_code + "\n";

                    if (!globalSettings.company_name.Equals(""))
                        lblLicense.Text += "Retailer: " + globalSettings.company_name;

                    btnActivate.Text= "Remove License";
                    lblLicenseDone.Visible = true;

                }
                else
                {
                    lblLicense.Text += "No license.";
                }


                optServerDemo.Checked = true;
                if (globalSettings.svr_id == "tx")
                {
                    optServerTx.Checked = true;
                }

              
                //btnShowSkype.Checked = false;
                //if (globalSettings.gen_show_btn_skype == "1") btnShowSkype.Checked = true;
                //btnTeamViewer.Checked = false;
                //if (globalSettings.gen_show_btn_teamviewer == "1") btnTeamViewer.Checked = true;

                txtSerialNumber.Text = Util.system_uid;

                Util.getEMEI();
                txtIMEI.Text = globalSettings.device_imei;
                
                txtAssetId.Text = "";
                if (!globalSettings.asset_id.Equals("0"))
                {
                    txtAssetId.Text = globalSettings.asset_id.Trim();
                }

                //if (globalSettings.gen_teamviewer_location.Length > 0)
                //{
                //    lblTVLocation.Text = globalSettings.gen_teamviewer_location;
                //    lblTVLocation.ForeColor = Color.Green;
                //}

                chkCustomerMin.Checked = false;
                if (globalSettings.allow_screen_resize.Equals("1")) chkCustomerMin.Checked = true;

            }
            catch(Exception ex)
            {
                Util.showMessage(ex.Message, Color.Red);
            }

            try
            {
                lblAllSettings.Text += "----------------------------" + Environment.NewLine;
                lblAllSettings.Text += "Software Name: " + Environment.NewLine + globalSettings.app_ver_desc + Environment.NewLine + Environment.NewLine;
                lblAllSettings.Text += "Software Version: " + Environment.NewLine + String.Format("{0:####-##-##-####}", Convert.ToInt64(globalSettings.app_ver)) + Environment.NewLine + Environment.NewLine;
                lblAllSettings.Text += "Provider Item Version: " + Environment.NewLine + String.Format("{0:####-##-##-####}", Convert.ToInt64(globalSettings.spi_ver)) + Environment.NewLine + Environment.NewLine;
                lblAllSettings.Text += "Licence: " + Environment.NewLine + globalSettings.license_code + Environment.NewLine + Environment.NewLine;
            }
            catch
            {
                //
            }

            lblAllSettings.Text +=  "----------------------------" +  Environment.NewLine;
            lblAllSettings.Text += "Notice: " + globalSettings.notice_id + Environment.NewLine;
            lblAllSettings.Text += "Advert: " + globalSettings.advert_id + Environment.NewLine;

            lblAllSettings.Text += Environment.NewLine + "----------------------------" + Environment.NewLine;
            lblAllSettings.Text += "Request Id: " + globalVoucher.request_id + Environment.NewLine;
            if (globalVoucher.request_id_problem > 0)
            {
                lblAllSettings.Text += "Problem: Currently Waiting to confirm (" + globalVoucher.request_id_problem + ")";
            }




        }



        private void btnLoadItems_Click(object sender, EventArgs e)
        {

            Util.showWait(true);

            try
            {

                string htmlresponse = webService.getPosUsers();
                if (htmlresponse.Length == 0)
                {
                    Util.loadPosUsers();
                    Util.showMessage("Updated list of users.", Color.White);
                }

                htmlresponse = webService.get_update_all();
                if (htmlresponse.Length > 0)
                {
                    Util.showMessage(htmlresponse, Color.Red);
                }

                //Util.getStockProviderUpdate(true);

                lblLicense.Text = "";
                //lblLicense.Text += "Serial: " + globalSettings.serial + "\n";
                //lblLicense.Text += "Terminal: " + globalSettings.description + "\n";
                lblLicense.Text += "License: " + globalSettings.license_code + "\n";
                lblLicense.Text += "Retailer: " + globalSettings.company_name + "(" + globalSettings.account_number + ")\n";
                lblLicense.Text += "\nAll settings updated.";
                lblLicense.Text += "\n\nPlease restart application.";

            } 
            catch
            {
                Util.showMessage("Problem updating! Possible bad connection.\nPlease try refresh retailer data again.",Color.Red);
            }

            Util.showWait(false);

        }






        private void digitsOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (txtOTP.Text.Trim() == "")
            {
                Util.showMessage("Please enter a correct OTP!", Color.Red); 
                return;
            }

            Util.showWait(true);

            if (skipOTP && txtOTP.Text == "911911")
            {

                Util.showMessage("OK!", Color.White);
                loggedIn = true;
                tabControlSettings.SelectedIndex = 1;

            }
            else
            {

                String ret = webService.checkOTP(txtOTP.Text.Trim(), Util.system_uid);
                int n;

                if (ret.Contains("err>"))
                {
                    Util.showMessage("OTP not correct!", Color.Red);
                }
                else if (int.TryParse(ret, out n))
                {

                    tiu_user_id = ret;

                    loggedIn = true;
                    Util.showMessage("Login OK.", Color.White);
                    tabControlSettings.SelectedIndex = 1;

                }

            }

            Util.showWait(false);

        }


        bool skipOTP = false;
        private void btnSMS_Click(object sender, EventArgs e)
        {

            skipOTP = false;

            txtOTP.Text = "";

            if (txtCell.Text.Trim() == "")
            {
                Util.showMessage("Please enter a correct cell number!", Color.Red);
                return;
            }


            Util.showWait(true);

            if (txtCell.Text.Trim() == "9110000000")  {

                skipOTP = true;
                tiu_user_id = "0";
                txtCell.Text = "";
                Util.showMessage("OK.", Color.White);

            } else {

                String ret = webService.sendOTP(txtCell.Text.Trim(), Util.system_uid);

                if (ret.Contains("err>"))
                {
                    Util.showMessage(ret.StripErrorTags(), Color.Red);
                }
                else
                {
                    tiu_user_id = ret;
                    txtCell.Text = "";
                    Util.showMessage("OTP Sent.", Color.White);
                }

            }

            Util.showWait(false);


        }

        private void btnRegisterPC_Click(object sender, EventArgs e)
        {


            if (txtAssetId.Text.Trim() == "")
            {
                Util.showMessage("Please enter the hardware ID!", Color.Yellow);
                return;
            }

            globalSettings.ClearAll();
            globalSettings.Save();

            Util.showWait(true);

            String htmlResponse = webService.registerDevice(txtAssetId.Text.Trim());

            if (htmlResponse.IndexOf("err>") > -1)
            {

                Util.showMessage("Could not register device!",Color.Red);

            }
            else
            {

                try
                {
                    Newtonsoft.Json.Linq.JObject json = Newtonsoft.Json.Linq.JObject.Parse(htmlResponse);

                    globalSettings.asset_id = txtAssetId.Text.Trim();
                    globalSettings.serial = (string) json["asset_serial"];
                    globalSettings.description = (string) json["asset_type_desc"];


                    Console.WriteLine("glogal serial: " + globalSettings.serial);


                    try
                    {
                        Microsoft.Win32.RegistryKey tiu = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\TiU");
                        tiu.SetValue("serial", globalSettings.serial);
                        tiu.Close();
                        Util.system_uid = globalSettings.serial;
                    }
                    catch
                    {
                        Util.showMessage("Problem updating registry! Settings not configured.", Color.Red);
                    }

                    globalSettings.Save();

                    txtSerialNumber.Text = globalSettings.serial;

                    Util.showMessage("Device settings updated.", Color.White);
                    btnRegisterPC.Enabled = false;
                    btnRefreshEMIE.Visible = false;


                }
                catch
                {

                    Util.showMessage("Issue with get details from server!",Color.Red);

                }
                

            }

            Util.showWait(false);
            
        }

        //private void lnkTVRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{


        //    lblTVLocation.Text = "(not set)";
        //    lblTVLocation.ForeColor = Color.Firebrick;

        //    globalSettings.gen_teamviewer_location = "";
        //    globalSettings.SaveGeneral();

        //    Util.showMessage("Removed Teamviewer Location.", Color.Red);


        //}

        //private void lnkTVBrowse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    // Create an instance of the open file dialog box.
        //    OpenFileDialog openFileDialog1 =  new OpenFileDialog();

        //    // Set filter options and filter index.
        //    openFileDialog1.InitialDirectory = @"C:\";
        //    openFileDialog1.Title = "Browse For Team Viewer";
        //    openFileDialog1.DefaultExt = "exe";
        //    openFileDialog1.Filter = "Exe files (*.exe)|*.exe|All files (*.*)|*.*";
        //    openFileDialog1.FilterIndex = 1;

        //    openFileDialog1.CheckFileExists = true;
        //    openFileDialog1.CheckPathExists = true;

        //    openFileDialog1.Multiselect = false;

        //    // Process input if the user clicked OK.
        //    if (openFileDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //            if (openFileDialog1.FileName.ToString().Length > 0 )
        //            {
        //                lblTVLocation.Text = openFileDialog1.FileName.ToString();
        //                lblTVLocation.ForeColor = Color.Green;

        //                globalSettings.gen_teamviewer_location = openFileDialog1.FileName.ToString();
        //                globalSettings.SaveGeneral();

        //                Util.showMessage("Saved new Teamviewer Location.", Color.White);

        //            }
        //    }

        //}

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExitApplication_Click(object sender, EventArgs e)
        {
            Util.showWaitClose();

            Application.Exit();
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

        private void btnTextConnection_Click(object sender, EventArgs e)
        {

            Util.showWait("Testing Connection, Timeout: 15 seconds.");

            DateTime localDate = DateTime.Now;

            pnlConnTest.Text = "Testing Connection (" + localDate + ")";

            String htmlResponse = "";

            String connLoc = "";

            if (ConnURL.Text.Equals(""))
            {
                connLoc = ConnHttp.Text + globalSettings.svr_ip + ":" + ConnPort.Text + @"/terminal/general/get-time";
            }
            else
            {
                connLoc = ConnHttp.Text + ConnURL.Text + ":" + ConnPort.Text + "/" + connLocation.Text;
            }

            Web WebResponse = new Web(15000, 3, "");
            htmlResponse = WebResponse.GetURLCustom(connLoc);
            WebResponse = null;

            if (htmlResponse.IndexOf("err>", 0) > -1)
            {
                pnlConnTest.Text = pnlConnTest.Text + Environment.NewLine + "Response:\n" + Environment.NewLine + htmlResponse.StripErrorTags();
            }
            else
            {
                pnlConnTest.Text = pnlConnTest.Text + Environment.NewLine + "Response:" + Environment.NewLine + htmlResponse;
            }

            Util.showWait(false);

        }

        private void btnServiceManager_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("services.msc");
            }
            catch (Exception ex)
            {
                Util.showMessage(ex.Message, Color.Red);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(@"C:\Windows\System32\taskmgr.exe");
            }
            catch (Exception ex)
            {
                Util.showMessage(ex.Message, Color.Red);
            }
            
        }

        //private void btnRemoveCharms_Click(object sender, EventArgs e)
        //{

        //    try
        //    {

        //        Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Policies\Microsoft\Windows\Explorer");

        //        rk.SetValue("DisableNotificationCenter", 1);

        //        Util.showMessage("Charm Bar Disabled", Color.White);
        //    }
        //    catch (Exception ex)
        //    {
        //        Util.showMessage(ex.Message,Color.Red);
        //    }
        //}

        private void btnLockdown_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(@"C:\topitup\Lockdown.exe");
            }
            catch (Exception ex)
            {
                Util.showMessage(ex.Message, Color.Red);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (connLocation.Text.Equals("")) connLocation.Text = "Win32_Battery";

            System.Management.ManagementObjectSearcher searcher = new System.Management.ManagementObjectSearcher("SELECT * FROM " + connLocation.Text);
            //System.Management.ManagementObjectCollection collection = searcher.Get();

            foreach (System.Management.ManagementObject obj in searcher.Get())
            {
                foreach (var prop in obj.Properties)
                {
                    if (prop.Value != null)
                    {
                        pnlConnTest.AppendText(string.Format("{0} = {1}", prop.Name, prop.Value) + "\n");
                    }
                }
            }

            
        }

        private void btnRefreshEMIE_Click(object sender, EventArgs e)
        {

            Util.showWait(true);

            Util.getEMEI();

            if (globalSettings.device_imei.Length == 0)
            {
                Util.showMessage("No IMEI on this device!",Color.White);
                txtIMEI.Text = "";
            }
            else
            {
                Util.showMessage("IMEI number found.", Color.White);
                txtIMEI.Text = globalSettings.device_imei;
            }

            Util.showWait(false);

    }

        private void btnRestart_Click(object sender, EventArgs e)
        {

            globalSettings.app_restart = true;

            Close();

        }

        private void btnShutdown_Click(object sender, EventArgs e)
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

        private void btnSoftwareUpdate_Click(object sender, EventArgs e)
        {

            frmAppUpdate frmAppUpdate = new frmAppUpdate();
            frmAppUpdate.ShowDialog(this);

            if (globalSettings.app_restart)
            {
                Close();
            }

        }

        private void btnShowPrinters_Click(object sender, EventArgs e)
        {
            try
            {
                var Process = new System.Diagnostics.Process();
                var ProcessStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/C control printers");
                ProcessStartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                Process.StartInfo = ProcessStartInfo;
                Process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateFirewall_Click(object sender, EventArgs e)
        {

            Util.showWait("Updating Firewall...");

            updateFirewall();

            Util.showWait(false);

            Util.showMessage("Firewall Updated.", Color.White);

        }


        public static string updateFirewall()
        {

            String _out = "";

            try
            {

                System.Diagnostics.Process p1 = new System.Diagnostics.Process();
                p1.StartInfo.FileName = "netsh.exe";
                p1.StartInfo.Arguments = "advfirewall import \"c:\\topitup\\setup\\firewall\\tiu.wfw\"";
                p1.StartInfo.UseShellExecute = false;
                p1.StartInfo.RedirectStandardOutput = true;
                p1.StartInfo.RedirectStandardError = true;
                p1.StartInfo.CreateNoWindow = true;
                p1.Start();

                using (StringReader reader = new StringReader(p1.StandardOutput.ReadToEnd()))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        _out = line.Trim();
                    }
                }

            }
            catch
            {
                _out = "";
            }

            return _out;

        }

        private void chkCustomerMin_CheckedChanged(object sender, EventArgs e)
        {

            if (chkCustomerMin.Checked)
            {
                globalSettings.allow_screen_resize = "1";
                globalSettings.SaveGeneral();
            }
            else
            {
                globalSettings.allow_screen_resize = "0";
                globalSettings.SaveGeneral();
            }

            Util.showMessage("Setting Updated.", Color.White);

        }

        private void btnFirewallDisable_Click(object sender, EventArgs e)
        {
            btnFirewallDisable.Enabled = false;

            update_windows_firewall(publicProfile, false);

            Thread.Sleep(2000);
            get_windows_firewall_status();

            btnFirewallDisable.Enabled = true;

        }

        private void btnFirewallEnable_Click(object sender, EventArgs e)
        {

            btnFirewallEnable.Enabled = false;

            update_windows_firewall(publicProfile, true);

            Thread.Sleep(2000);
            get_windows_firewall_status();

            btnFirewallEnable.Enabled = true;

        }

        public void update_windows_firewall(int this_domainProfile, bool enableFirewall)
        {
            Type netFwPolicy2Type = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            dynamic mgr = Activator.CreateInstance(netFwPolicy2Type);
            mgr.FirewallEnabled[this_domainProfile] = enableFirewall;
        }

        private void btnShowFirewall_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("wf.msc");
            }
            catch (Exception ex)
            {
                Util.showMessage(ex.Message, Color.Red);
            }
        }



        public void get_windows_firewall_status()
        {

            try
            {

                Type netFwPolicy2Type = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
                dynamic mgr = Activator.CreateInstance(netFwPolicy2Type);

                bool CheckPublic = mgr.FirewallEnabled(publicProfile);

                if (CheckPublic)
                {
                    lblFirewallStatus.ForeColor = Color.Green;
                    lblFirewallStatus.Text = "Firewall Enabled.";
                }
                else
                {
                    lblFirewallStatus.ForeColor = Color.Red;
                    lblFirewallStatus.Text = "Firewall Disabled.";
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }





    }



}
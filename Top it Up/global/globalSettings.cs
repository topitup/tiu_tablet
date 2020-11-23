using System;
using System.IO;
using System.Collections.Generic;

namespace TopitUp
{
    static public class globalSettings
    {


        /* TEMP PRINTER OFFLINE TRACKER ****/
        public static int track_print_paper_out = 0;
        public static int track_print_offline_windows = 0;
        public static int track_print_offline = 0;
        /*****/

        public static string app_ver_desc = "Stratus";
        public static string app_ver = "201909100000";
        public static string app_update_ver = "";
        public static string app_update_location = "";

        public static string app_path = "";
        // public static string available_balance = "";
        public static bool do_print_extra = false;

        public static string printer_name = "";

        public static string bootup_electra = "";
        public static string electra_last = "";

        /* extended credit request */
        public static bool credit_req_is_allowed = false;
        public static bool credit_req_high = false;
        public static string credit_req_data = "";
        public static string credit_req_otp = "x";

        /* current logged in user */
        public static string pos_user_fullname = "";
        public static string pos_user_firstname = "";
        public static string pos_user_id = "0";
        public static bool pos_user_admin = false;
        public static bool pos_user_loggedin = false;
        public static bool pos_user_rica_registered = false;

        /* license and terminal */
        public static string sim_pin = "5562";
        public static string asset_model = "PC";
        public static string asset_id = "0";
        public static string serial = "";
        public static string description = "";
        public static string customer_id = "";
        public static string account_number = "";
        public static string company_name = "";
        public static string company_name30 = "";
        public static string company_address = "";
        public static string license_code = "nolicense";
        public static string skip_modem = "0";
        public static string customer_accept = "0";
        public static string registry_set = "0";
        public static string device_imei = "";
        public static string enable_unipin = "0";

        public static string enable_rpt_monthly_deposit = "0";
        public static string enable_rpt_comm_statement = "0";
        public static string enable_rpt_monthly_sales = "0";

        public static string enable_mamamoney = "0";
        public static string enable_cashms = "0";

        /* server */
        //public static string svr_id = "tx";
        //public static string svr_ip = "41.203.10.186";
        //public static string svr_hostname = "tx.itopitup.co.za";

        public static string svr_id = "dmo";
        public static string svr_ip = "197.221.53.66";
        public static string svr_hostname = "demo.itopitup.co.za";
        public static string svr_port = "25812";

        public static string sync_port = "25815";
        public static string sync_hostname = "sync.itopitup.co.za";

        /* general */
        public static string gen_is3g = "0";
        public static string gen_airtime = "1";
        public static string gen_elec = "1";
        public static string gen_rica = "0";
        public static string gen_water = "0";
        public static string gen_bills = "0";
        public static string gen_pinless = "0";
        public static string gen_cashdr = "0";
        public static string gen_cashdr_cashier = "0";
        public static string gen_cashdrrj12 = "0";
        public static string gen_logout = "1";
        public static int gen_logout_time = 15000;
        public static string gen_prnt_b = "0";
        public static string gen_prnt_be = "0";
        public static string gen_prnt_bb = "0";
        public static string gen_show_balance_login = "0";
        public static string gen_show_balance = "0";
        public static string gen_quick_print_disable = "0";
        public static string gen_quick_print_confirm = "0";
        public static string gen_disable_clock = "0";
        
        public static string gen_show_lowfunds = "0";
        public static string gen_show_lowfunds_cashier = "0";
        
        //public static string gen_current_low_balance = "0";
        public static string gen_show_financials = "0";
        public static string gen_show_financials_cashier = "0";
        public static string gen_show_last_sale_login = "0";

        /* cashier */
        public static string gen_cashier_allowreprint = "1";
        public static string gen_cashier_allowreprintlast = "1";
        public static string gen_cashier_allowreprintlast_admin = "1";
        public static string gen_cashier_billconvenience_cashier = "0";
        public static string gen_cashier_billconvenience_admin = "0";


        //public static string gen_cashier_swipe = "0";
        //public static string gen_ignore_paper = "0";
        public static string gen_print_address = "0";
        public static string gen_print_copy = "0";
        public static string gen_print_pinless_slip = "0";
        public static string gen_cashier_ownsales = "0";
        public static string gen_cashier_w = "0";
        public static string gen_cashier_y = "0";
        public static string gen_cashier_y_all = "0";
        public static string gen_cashier_y_history = "0";
        public static string gen_cashier_elec_disabled = "0";
        public static string gen_cashier_bill_disabled = "0";
        public static string gen_cashier_salehistory_disabled = "0";
        public static string gen_cashier_restart = "0";

        /* quickprint */
        public static string quickprint_item1 = "9";
        public static string quickprint_item2 = "10";
        public static string quickprint_item3 = "1";
        public static string quickprint_item4 = "3";
        public static string quickprint_item5 = "16";

        /* electra */
        public static string elec_preset_enabled = "1";
        public static string elec_preset_val1 = "10";
        public static string elec_preset_val2 = "20";
        public static string elec_preset_val3 = "50";
        public static string elec_preset_val4 = "100";

        public static string elec_max_vend_show = "0";
        public static string elec_max_warning_show = "0";
        public static string elec_max_warning_val = "0";

        /* notices */
        public static string notice_id_latest = "0";
        public static string notice_id = "0";
        public static string notice_data = "";

        /* advert */
        public static string advert_id_latest = "0";
        public static string advert_id = "0";
        public static string advert_data = "";

        /* service provider items*/
        public static string spi_ver_latest = "0";
        public static string spi_ver = "0";
        public static string sp_ver_latest = "0";
        public static string sp_ver = "0";

        /* desktop app */
        public static string gen_show_voucher_only = "0";
        public static string gen_show_btn_skype = "0";
        public static string gen_show_btn_teamviewer = "0";
        public static string gen_teamviewer_location = "";
        

        //public static string gen_show_login_desktop_icon = "0";
        //public static string gen_show_login_lockpc_icon = "0";
        //public static string gen_show_login_netcon_icon = "0";
        //public static string gen_show_login_shutdown = "0";

        public static string gen_slip_printer = "1";

        public static string gen_virtual_keyboard = "1";

        public static string gen_sound = "1";

        public static string gen_show_multi_voucher = "0";

        public static string gen_tiu_contact = "0860 111 723 | 021 637 3061 | info@itopitup.co.za";

        public static Boolean app_restart = false;

        public static string vending_type = "";
        /* 5 Saved Meter Numbers */
        public static string saved_meter_1 = "";
        public static string saved_meter_2 = "";
        public static string saved_meter_3 = "";
        public static string saved_meter_4 = "";
        public static string saved_meter_5 = "";
        public static string saved_meter_1_desc = "";
        public static string saved_meter_2_desc = "";
        public static string saved_meter_3_desc = "";
        public static string saved_meter_4_desc = "";
        public static string saved_meter_5_desc = "";

        public static string allow_screen_resize = "1";

        /* DLL SETTINGS */
        public static string dll_version_cashms = "";
        public static bool dll_version_cashms_runonce = false;

        public static string dll_version_rica = "";
        public static bool dll_version_rica_runonce = false;


        static globalSettings()
        {
          
            app_path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            Util.system_uid = Util.getUniqueID();

            try
            {
                if (File.Exists(app_path + @"\conf\track_print.dat"))
                {
                    StreamReader myFile = new StreamReader(app_path + @"\conf\track_print.dat");
                    string line;
                    while ((line = myFile.ReadLine()) != null)
                    {

                        try {
                            if (line.IndexOf("track_print_paper_out:") >= 0) track_print_paper_out = Convert.ToInt32(line.Replace("track_print_paper_out:", "").Trim());
                        } catch {
                            track_print_paper_out = 0;
                        }

                        try {
                            if (line.IndexOf("track_print_offline_windows:") >= 0) track_print_paper_out = Convert.ToInt32(line.Replace("track_print_offline_windows:", "").Trim());
                        } catch {
                            track_print_offline_windows = 0;
                        }

                        try
                        {
                            if (line.IndexOf("track_print_offline:") >= 0) track_print_paper_out = Convert.ToInt32(line.Replace("track_print_offline:", "").Trim());
                        }
                        catch
                        {
                            track_print_offline = 0;
                        }

                    }
                    myFile.Close();
                }
            }
            catch
            {
                //
            }




            try
            {
                if (File.Exists(app_path + "\\conf\\wifi_settings.dat"))
                {
                    StreamReader myFile = new StreamReader(app_path + @"\conf\wifi_settings.dat");

                    string line;
                    while ((line = myFile.ReadLine()) != null)
                    {

                        string splitMe = line;
                        string[] lineSplits = splitMe.Split(new char[] { ':' });

                        wifi_passwords.Add(lineSplits[0].Trim(), lineSplits[1].Trim());

                    }
                    myFile.Close();

                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }




            try
            {
                if (File.Exists(app_path + "\\conf\\settings.dat"))
                {
                    StreamReader myFile = new StreamReader(app_path + @"\conf\settings.dat");

                    string line;
                    while ((line = myFile.ReadLine()) != null)
                    {

                        line = Util.Decrypt(line);


                        if (line.IndexOf("license_code:") >= 0) license_code = line.Replace("license_code:", "").Trim();
                        if (line.IndexOf("asset_model:") >= 0) asset_model = line.Replace("asset_model:", "").Trim();
                        if (line.IndexOf("asset_id:") >= 0) asset_id = line.Replace("asset_id:", "").Trim();
                        if (line.IndexOf("serial:") >= 0) serial = line.Replace("serial:", "").Trim();
                        if (line.IndexOf("description:") >= 0) description = line.Replace("description:", "").Trim();
                        if (line.IndexOf("customer_id:") >= 0) customer_id = line.Replace("customer_id:", "").Trim();

                        if (line.IndexOf("company_name:") >= 0)
                        {
                            company_name = line.Replace("company_name:", "").Trim();
                            if (company_name.Length > 30)
                            {
                                company_name30 = company_name.Substring(0, 29);
                            }
                            else
                            {
                                company_name30 = company_name;
                            }
                        }
                        if (line.IndexOf("company_address:") >= 0)
                        {
                            company_address = line.Replace("company_address:", "").Trim();
                            try
                            {
                                string[] address_line = company_address.Split('|');
                                Util.voucher_print_address[0] = address_line[0];
                                Util.voucher_print_address[1] = address_line[1];
                            }
                            catch
                            {
                                //
                            }
                        }
                        if (line.IndexOf("account_number:") >= 0) account_number = line.Replace("account_number:", "").Trim();
                        if (line.IndexOf("svr_id:") >= 0) svr_id = line.Replace("svr_id:", "").Trim();
                        if (line.IndexOf("svr_ip:") >= 0) svr_ip = line.Replace("svr_ip:", "").Trim();
                        if (line.IndexOf("svr_hostname:") >= 0) svr_hostname = line.Replace("svr_hostname:", "").Trim();
                        if (line.IndexOf("svr_port:") >= 0) svr_port = line.Replace("svr_port:", "").Trim();
                        if (line.IndexOf("sync_hostname:") >= 0) sync_hostname = line.Replace("sync_hostname:", "").Trim();
                        if (line.IndexOf("sync_port:") >= 0) sync_port = line.Replace("sync_port:", "").Trim();
                        if (line.IndexOf("customer_accept:") >= 0) customer_accept = line.Replace("customer_accept:", "").Trim();
                        if (line.IndexOf("registry_set:") >= 0) registry_set = line.Replace("registry_set:", "").Trim();
                        if (line.IndexOf("device_imei:") >= 0) device_imei = line.Replace("device_imei:", "").Trim();
                        if (line.IndexOf("enable_unipin:") >= 0) enable_unipin = line.Replace("enable_unipin:", "").Trim();
                        if (line.IndexOf("enable_mamamoney:") >= 0)
                        {
                            enable_mamamoney = line.Replace("enable_mamamoney:", "").Trim();
                            //Console.WriteLine("WTF LOAD: " + line.Replace("enable_mamamoney:", "").Trim());
                        }

                        


                    }
                    myFile.Close();

                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }


            try
            {
                if (File.Exists(app_path + @"\conf\settings_notice.dat"))
                {
                    StreamReader myFile = new StreamReader(app_path + @"\conf\settings_notice.dat");
                    string line;
                    while ((line = myFile.ReadLine()) != null)
                    {
                        if (line.IndexOf("notice_id:") >= 0) notice_id = line.Replace("notice_id:", "").Trim();
                        if (line.IndexOf("notice_data:") >= 0) notice_data = line.Replace("notice_data:", "").Trim();
                    }
                    myFile.Close();
                }
            }
            catch
            {
                //
            }




            try
            {
                if (File.Exists(app_path + @"\conf\settings_ad.dat"))
                {
                    StreamReader myFile = new StreamReader(app_path + @"\conf\settings_ad.dat");
                    string line;
                    while ((line = myFile.ReadLine()) != null)
                    {
                        if (line.IndexOf("advert_id:") >= 0) advert_id = line.Replace("advert_id:", "").Trim();
                        if (line.IndexOf("advert_data:") >= 0) advert_data = line.Replace("advert_data:", "").Trim();
                    }
                    myFile.Close();
                }
            }
            catch
            {
                //
            }

            try
            {
                if (File.Exists(app_path + @"\conf\settings_spi.dat"))
                {
                    StreamReader myFile = new StreamReader(app_path + @"\conf\settings_spi.dat");
                    string line;
                    while ((line = myFile.ReadLine()) != null)
                    {
                        if (line.IndexOf("sp_ver:") >= 0) sp_ver = line.Replace("sp_ver:", "").Trim();
                        if (line.IndexOf("spi_ver:") >= 0) spi_ver = line.Replace("spi_ver:", "").Trim();
                    }
                    myFile.Close();
                }
            }
            catch
            {
                //
            }

            try
            {
                if (File.Exists(app_path + @"\conf\settings_gen.dat"))
                {
                    StreamReader myFile = new StreamReader(app_path + @"\conf\settings_gen.dat");

                        string line;
                        while ((line = myFile.ReadLine()) != null)
                        {

                            line = Util.Decrypt(line);

                            if (line.IndexOf("sim_pin:") >= 0)              sim_pin = line.Replace("sim_pin:", "").Trim();

                            if (line.IndexOf("gen_is3g:") >= 0)             gen_is3g = line.Replace("gen_is3g:", "").Trim();
                            if (line.IndexOf("gen_airtime:") >= 0)          gen_airtime = line.Replace("gen_airtime:", "").Trim();
                            if (line.IndexOf("gen_elec:") >= 0)             gen_elec = line.Replace("gen_elec:", "").Trim();
                            if (line.IndexOf("gen_rica:") >= 0)             gen_rica = line.Replace("gen_rica:", "").Trim();
                            if (line.IndexOf("gen_water:") >= 0)            gen_water = line.Replace("gen_water:", "").Trim();
                            if (line.IndexOf("gen_bills:") >= 0)            gen_bills = line.Replace("gen_bills:", "").Trim();
                            if (line.IndexOf("gen_pinless:") >= 0)          gen_pinless = line.Replace("gen_pinless:", "").Trim();

                            if (line.IndexOf("gen_cashdr:") >= 0)           gen_cashdr = line.Replace("gen_cashdr:", "").Trim();
                            if (line.IndexOf("gen_cashdr_cashier:") >= 0)   gen_cashdr_cashier = line.Replace("gen_cashdr_cashier:", "").Trim();
                            if (line.IndexOf("gen_cashdrrj12:") >= 0)       gen_cashdrrj12 = line.Replace("gen_cashdrrj12:", "").Trim();

                            if (line.IndexOf("gen_logout:") >= 0)           gen_logout = line.Replace("gen_logout:", "").Trim();

                            if (line.IndexOf("gen_logout_time:") >= 0)
                            {
                                try
                                {
                                    gen_logout_time = Convert.ToInt32(line.Replace("gen_logout_time:", "").Trim());
                                }
                                catch
                                {
                                    gen_logout_time = 0;
                                }
                            }

                            if (line.IndexOf("gen_prnt_b:") >= 0)           gen_prnt_b = line.Replace("gen_prnt_b:", "").Trim();
                            if (line.IndexOf("gen_prnt_be:") >= 0)          gen_prnt_be = line.Replace("gen_prnt_be:", "").Trim();
                            if (line.IndexOf("gen_prnt_bb:") >= 0)          gen_prnt_bb = line.Replace("gen_prnt_bb:", "").Trim();
                            if (line.IndexOf("gen_show_balance_login:") >= 0) gen_show_balance_login = line.Replace("gen_show_balance_login:", "").Trim();
                            if (line.IndexOf("gen_show_balance:") >= 0)     gen_show_balance = line.Replace("gen_show_balance:", "").Trim();
                            if (line.IndexOf("gen_quick_print_disable:") >= 0) gen_quick_print_disable = line.Replace("gen_quick_print_disable:", "").Trim();
                            if (line.IndexOf("gen_quick_print_confirm:") >= 0) gen_quick_print_confirm = line.Replace("gen_quick_print_confirm:", "").Trim();

                            if (line.IndexOf("gen_disable_clock:") >= 0)    gen_disable_clock = line.Replace("gen_disable_clock:", "").Trim();


                        //if (line.IndexOf("gen_cashier_z:") >= 0)
                        //{
                        //    gen_cashier_z = line.Replace("gen_cashier_z:", "").Trim();
                        //}
                        //if (line.IndexOf("gen_cashier_swipe:") >= 0)    gen_cashier_swipe = line.Replace("gen_cashier_swipe:", "").Trim();
                        //if (line.IndexOf("gen_ignore_paper:") >= 0)     gen_ignore_paper = line.Replace("gen_ignore_paper:", "").Trim();
                        if (line.IndexOf("gen_print_address:") >= 0)    gen_print_address = line.Replace("gen_print_address:", "").Trim();
                        if (line.IndexOf("gen_print_copy:") >= 0)       gen_print_copy = line.Replace("gen_print_copy:", "").Trim();
                        if (line.IndexOf("gen_print_pinless_slip:") >= 0)   gen_print_pinless_slip = line.Replace("gen_print_pinless_slip:", "").Trim();
                        

                        if (line.IndexOf("gen_cashier_ownsales:") >= 0) gen_cashier_ownsales = line.Replace("gen_cashier_ownsales:", "").Trim();
                        if (line.IndexOf("gen_cashier_w:") >= 0)        gen_cashier_w = line.Replace("gen_cashier_w:", "").Trim();
                        if (line.IndexOf("gen_cashier_y:") >= 0)        gen_cashier_y = line.Replace("gen_cashier_y:", "").Trim();
                        if (line.IndexOf("gen_cashier_y_all:") >= 0)    gen_cashier_y_all = line.Replace("gen_cashier_y_all:", "").Trim();
                        if (line.IndexOf("gen_cashier_y_history:") >= 0) gen_cashier_y_history = line.Replace("gen_cashier_y_history:", "").Trim();
                        if (line.IndexOf("gen_cashier_elec_disabled:") >= 0) gen_cashier_elec_disabled = line.Replace("gen_cashier_elec_disabled:", "").Trim();
                        if (line.IndexOf("gen_cashier_bill_disabled:") >= 0) gen_cashier_bill_disabled = line.Replace("gen_cashier_bill_disabled:", "").Trim();
                        if (line.IndexOf("gen_cashier_salehistory_disabled:") >= 0) gen_cashier_salehistory_disabled = line.Replace("gen_cashier_salehistory_disabled:", "").Trim();
                        if (line.IndexOf("gen_cashier_restart:") >= 0) gen_cashier_restart = line.Replace("gen_cashier_restart:", "").Trim();
                      
                        if (line.IndexOf("gen_cashier_allowreprint:") >= 0) gen_cashier_allowreprint = line.Replace("gen_cashier_allowreprint:", "").Trim();
                        if (line.IndexOf("gen_cashier_allowreprintlast:") >= 0) gen_cashier_allowreprintlast = line.Replace("gen_cashier_allowreprintlast:", "").Trim();
                        if (line.IndexOf("gen_cashier_allowreprintlast_admin:") >= 0) gen_cashier_allowreprintlast_admin = line.Replace("gen_cashier_allowreprintlast_admin:", "").Trim();
                        if (line.IndexOf("gen_cashier_billconvenience_cashier:") >= 0) gen_cashier_billconvenience_cashier = line.Replace("gen_cashier_billconvenience_cashier:", "").Trim();
                        if (line.IndexOf("gen_cashier_billconvenience_admin:") >= 0) gen_cashier_billconvenience_admin = line.Replace("gen_cashier_billconvenience_admin:", "").Trim();

                        if (line.IndexOf("quickprint_item1:") >= 0)     quickprint_item1 = line.Replace("quickprint_item1:", "").Trim();
                        if (line.IndexOf("quickprint_item2:") >= 0)     quickprint_item2 = line.Replace("quickprint_item2:", "").Trim();
                        if (line.IndexOf("quickprint_item3:") >= 0)     quickprint_item3 = line.Replace("quickprint_item3:", "").Trim();
                        if (line.IndexOf("quickprint_item4:") >= 0)     quickprint_item4 = line.Replace("quickprint_item4:", "").Trim();
                        if (line.IndexOf("quickprint_item5:") >= 0)     quickprint_item5 = line.Replace("quickprint_item5:", "").Trim();

                        if (line.IndexOf("elec_preset_enabled:") >= 0)  elec_preset_enabled = line.Replace("elec_preset_enabled:", "").Trim();
                        if (line.IndexOf("elec_preset_val1:") >= 0)     elec_preset_val1 = line.Replace("elec_preset_val1:", "").Trim();
                        if (line.IndexOf("elec_preset_val2:") >= 0)     elec_preset_val2 = line.Replace("elec_preset_val2:", "").Trim();
                        if (line.IndexOf("elec_preset_val3:") >= 0)     elec_preset_val3 = line.Replace("elec_preset_val3:", "").Trim();
                        if (line.IndexOf("elec_preset_val4:") >= 0)     elec_preset_val4 = line.Replace("elec_preset_val4:", "").Trim();

                        if (line.IndexOf("elec_max_vend_show:") >= 0) elec_max_vend_show = line.Replace("elec_max_vend_show:", "").Trim();
                        if (line.IndexOf("elec_max_warning_show:") >= 0) elec_max_warning_show = line.Replace("elec_max_warning_show:", "").Trim();
                        if (line.IndexOf("elec_max_warning_val:") >= 0) elec_max_warning_val = line.Replace("elec_max_warning_val:", "").Trim();

                        /* desktop app */
                        if (line.IndexOf("gen_show_voucher_only:") >= 0) gen_show_voucher_only = line.Replace("gen_show_voucher_only:", "").Trim();
                        if (line.IndexOf("gen_show_btn_skype:") >= 0) gen_show_btn_skype = line.Replace("gen_show_btn_skype:", "").Trim();
                        if (line.IndexOf("gen_show_btn_teamviewer:") >= 0) gen_show_btn_teamviewer = line.Replace("gen_show_btn_teamviewer:", "").Trim();
                        if (line.IndexOf("gen_teamviewer_location:") >= 0) gen_teamviewer_location = line.Replace("gen_teamviewer_location:", "").Trim();
                        
                        //if (line.IndexOf("gen_show_login_desktop_icon:") >= 0) gen_show_login_desktop_icon = line.Replace("gen_show_login_desktop_icon:", "").Trim();
                        //if (line.IndexOf("gen_show_login_lockpc_icon:") >= 0) gen_show_login_lockpc_icon = line.Replace("gen_show_login_lockpc_icon:", "").Trim();
                        //if (line.IndexOf("gen_show_login_netcon_icon:") >= 0) gen_show_login_netcon_icon = line.Replace("gen_show_login_netcon_icon:", "").Trim();
                        //if (line.IndexOf("gen_show_login_shutdown:") >= 0) gen_show_login_shutdown = line.Replace("gen_show_login_shutdown:", "").Trim();
                        if (line.IndexOf("gen_slip_printer:") >= 0) gen_slip_printer = line.Replace("gen_slip_printer:", "").Trim();

                        if (line.IndexOf("gen_show_financials:") >= 0) gen_show_financials = line.Replace("gen_show_financials:", "").Trim();
                        if (line.IndexOf("gen_show_financials_cashier:") >= 0) gen_show_financials_cashier = line.Replace("gen_show_financials_cashier:", "").Trim();
                        if (line.IndexOf("gen_show_last_sale_login:") >= 0) gen_show_last_sale_login = line.Replace("gen_show_last_sale_login:", "").Trim();

                        if (line.IndexOf("gen_virtual_keyboard:") >= 0) gen_virtual_keyboard = line.Replace("gen_virtual_keyboard:", "").Trim();
                        if (line.IndexOf("gen_sound:") >= 0) gen_sound = line.Replace("gen_sound:", "").Trim();
                        if (line.IndexOf("gen_show_multi_voucher:") >= 0) gen_show_multi_voucher = line.Replace("gen_show_multi_voucher:", "").Trim();

                        if (line.IndexOf("gen_tiu_contact:") >= 0) gen_tiu_contact = line.Replace("gen_tiu_contact:", "").Trim();

                        if (line.IndexOf("saved_meter_1:") >= 0) saved_meter_1 = line.Replace("saved_meter_1:", "").Trim();
                        if (line.IndexOf("saved_meter_2:") >= 0) saved_meter_2 = line.Replace("saved_meter_2:", "").Trim();
                        if (line.IndexOf("saved_meter_3:") >= 0) saved_meter_3 = line.Replace("saved_meter_3:", "").Trim();
                        if (line.IndexOf("saved_meter_4:") >= 0) saved_meter_4 = line.Replace("saved_meter_4:", "").Trim();
                        if (line.IndexOf("saved_meter_5:") >= 0) saved_meter_5 = line.Replace("saved_meter_5:", "").Trim();
                        if (line.IndexOf("saved_meter_1_desc:") >= 0) saved_meter_1_desc = line.Replace("saved_meter_1_desc:", "").Trim();
                        if (line.IndexOf("saved_meter_2_desc:") >= 0) saved_meter_2_desc = line.Replace("saved_meter_2_desc:", "").Trim();
                        if (line.IndexOf("saved_meter_3_desc:") >= 0) saved_meter_3_desc = line.Replace("saved_meter_3_desc:", "").Trim();
                        if (line.IndexOf("saved_meter_4_desc:") >= 0) saved_meter_4_desc = line.Replace("saved_meter_4_desc:", "").Trim();
                        if (line.IndexOf("saved_meter_5_desc:") >= 0) saved_meter_5_desc = line.Replace("saved_meter_5_desc:", "").Trim();

                        if (line.IndexOf("allow_screen_resize:") >= 0) allow_screen_resize = line.Replace("allow_screen_resize:", "").Trim();


                        }
                    myFile.Close();

                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }





            try
            {
                if (File.Exists(app_path + @"\conf\settings_dll.dat"))
                {
                    StreamReader myFile = new StreamReader(app_path + @"\conf\settings_dll.dat");
                    string line;
                    while ((line = myFile.ReadLine()) != null)
                    {
                        if (line.IndexOf("dll_version_cashms:") >= 0) dll_version_cashms = line.Replace("dll_version_cashms:", "").Trim();
                    }
                    myFile.Close();
                }
            }
            catch
            {
                //
            }




            if (svr_id == "dmo")
            {
                sync_hostname = "demo.itopitup.co.za";
            }
            


        }


        public static bool save_dll_versions()
        {
            string outStr = "";

            outStr += "dll_version_cashms:" + dll_version_cashms + Environment.NewLine;
            outStr += "dll_version_rica:" + dll_version_rica + Environment.NewLine;

            TextWriter tw = new StreamWriter(app_path + @"\conf\settings_dll.dat", false);
            tw.Write(outStr);
            tw.Close();

            return true;
        }




        public static bool touch()
        {
            return true;
        }

        public static bool ClearAll()
        {

            asset_id = "";
            serial = "";
            description = "";
            customer_id = "";
            company_name = "";
            company_name30 = "";
            company_address = "";
            account_number = "";
            customer_accept = "0";

            license_code = "nolicense";

            try { File.Delete(app_path + @"\conf\posusers.dat"); }
            catch { }

            return true;
        }


        public static bool ClearLicense()
        {
            customer_id = "";
            company_name = "";
            license_code = "nolicense";

            //RegistryStuff regSettings = new RegistryStuff();
            //regSettings.SetValue("vsSettings", "license_code", "");
            //regSettings = null;

            try { File.Delete(app_path + @"\conf\posusers.dat"); }
            catch { }

            return true;
        }



        public static Dictionary<string, string> wifi_passwords = new Dictionary<string, string>();

        public static bool SaveWifiPasswords(string network_name, string password)
        {

            //wifi_passwords.Add(network_name, password);

            wifi_passwords[network_name] = password;

            if (File.Exists(app_path + @"\conf\wifi_settings.dat"))
            {
                try { File.Delete(app_path + @"\conf\wifi_settings.dat"); }
                catch { }
            }

            using (StreamWriter file = new StreamWriter(app_path + @"\conf\wifi_settings.dat", true))
                foreach (var entry in wifi_passwords)
                    file.WriteLine("{0}:{1}", entry.Key, entry.Value);

            return true;

        }

        public static bool Save()
        {

            if (license_code.Length == 0) license_code = "nolicense";

            //RegistryStuff regSettings = new RegistryStuff();
            //regSettings.SetValue("vsSettings", "license_code", license_code);
            //regSettings = null;

            string outStr = "";

            outStr += Util.Encrypt("license_code:" + license_code) + Environment.NewLine;
            outStr += Util.Encrypt("asset_model:" + asset_model) + Environment.NewLine;
            outStr += Util.Encrypt("asset_id:" + asset_id) + Environment.NewLine;
            outStr += Util.Encrypt("serial:" + serial) + Environment.NewLine;
            outStr += Util.Encrypt("description:" + description) + Environment.NewLine;
            outStr += Util.Encrypt("customer_id:" + customer_id) + Environment.NewLine;
            outStr += Util.Encrypt("company_name:" + company_name) + Environment.NewLine;
            outStr += Util.Encrypt("company_address:" + company_address) + Environment.NewLine;
            outStr += Util.Encrypt("account_number:" + account_number) + Environment.NewLine;
            outStr += Util.Encrypt("svr_id:" + svr_id) + Environment.NewLine;
            outStr += Util.Encrypt("svr_ip:" + svr_ip) + Environment.NewLine;
            outStr += Util.Encrypt("svr_hostname:" + svr_hostname) + Environment.NewLine;
            outStr += Util.Encrypt("svr_port:" + svr_port) + Environment.NewLine;
            outStr += Util.Encrypt("customer_accept:" + customer_accept) + Environment.NewLine;
            outStr += Util.Encrypt("registry_set:" + registry_set) + Environment.NewLine;
            outStr += Util.Encrypt("device_imei:" + device_imei) + Environment.NewLine;
            outStr += Util.Encrypt("enable_unipin:" + enable_unipin) + Environment.NewLine;
            outStr += Util.Encrypt("enable_mamamoney:" + enable_mamamoney) + Environment.NewLine;

            TextWriter tw = new StreamWriter(app_path + @"\conf\settings.dat", false);
            tw.Write(outStr);
            tw.Close();

            return true;
        }


        public static bool SaveNotice()
        {

            string outStr = "";

            outStr += "notice_id:" + notice_id + Environment.NewLine;
            outStr += "notice_data:" + notice_data + Environment.NewLine;

            TextWriter tw = new StreamWriter(app_path + @"\conf\settings_notice.dat", false);
            tw.Write(outStr);
            tw.Close();

            return true;
        }
        

        public static bool SaveAdvert()
        {

            string outStr = "";

            outStr += "advert_id:" + advert_id + Environment.NewLine;
            outStr += "advert_data:" + advert_data + Environment.NewLine;

            TextWriter tw = new StreamWriter(app_path + @"\conf\settings_ad.dat", false);
            tw.Write(outStr);
            tw.Close();

            return true;
        }

        public static bool SaveSPI()
        {

            string outStr = "";

            outStr += "sp_ver:" + sp_ver + Environment.NewLine;
            outStr += "spi_ver:" + spi_ver + Environment.NewLine;

            TextWriter tw = new StreamWriter(app_path + @"\conf\settings_spi.dat", false);
            tw.Write(outStr);
            tw.Close();

            return true;
        }






        public static bool track_print_save()
        {

            string outStr = "";

            outStr += "track_print_paper_out:" + track_print_paper_out.ToString() + Environment.NewLine;
            outStr += "track_print_offline_windows:" + track_print_offline_windows.ToString() + Environment.NewLine;
            outStr += "track_print_offline:" + track_print_offline.ToString() + Environment.NewLine;

            TextWriter tw = new StreamWriter(app_path + @"\conf\track_print.dat", false);
            tw.Write(outStr);
            tw.Close();

            return true;
        }




        public static bool SaveGeneral()
        {

            string outStr = "";

            outStr += Util.Encrypt("sim_pin:" + sim_pin) + Environment.NewLine;

            outStr += Util.Encrypt("gen_is3g:" + gen_is3g) + Environment.NewLine;
            outStr += Util.Encrypt("gen_airtime:" + gen_airtime) + Environment.NewLine;
            outStr += Util.Encrypt("gen_elec:" + gen_elec) + Environment.NewLine;
            outStr += Util.Encrypt("gen_rica:" + gen_rica) + Environment.NewLine;
            outStr += Util.Encrypt("gen_water:" + gen_water) + Environment.NewLine;
            outStr += Util.Encrypt("gen_bills:" + gen_bills) + Environment.NewLine;
            outStr += Util.Encrypt("gen_pinless:" + gen_pinless) + Environment.NewLine;
            outStr += Util.Encrypt("gen_cashdr:" + gen_cashdr) + Environment.NewLine;
            outStr += Util.Encrypt("gen_cashdr_cashier:" + gen_cashdr_cashier) + Environment.NewLine;
            outStr += Util.Encrypt("gen_cashdrrj12:" + gen_cashdrrj12) + Environment.NewLine;
            outStr += Util.Encrypt("gen_logout:" + gen_logout) + Environment.NewLine;
            outStr += Util.Encrypt("gen_logout_time:" + gen_logout_time.ToString()) + Environment.NewLine;
            outStr += Util.Encrypt("gen_prnt_b:" + gen_prnt_b) + Environment.NewLine;
            outStr += Util.Encrypt("gen_prnt_be:" + gen_prnt_be) + Environment.NewLine;
            outStr += Util.Encrypt("gen_prnt_bb:" + gen_prnt_bb) + Environment.NewLine;
            outStr += Util.Encrypt("gen_show_balance_login:" + gen_show_balance_login) + Environment.NewLine;
            outStr += Util.Encrypt("gen_show_balance:" + gen_show_balance) + Environment.NewLine;
            outStr += Util.Encrypt("gen_quick_print_disable:" + gen_quick_print_disable) + Environment.NewLine;
            outStr += Util.Encrypt("gen_quick_print_confirm:" + gen_quick_print_confirm) + Environment.NewLine;
            outStr += Util.Encrypt("gen_disable_clock:" + gen_disable_clock) + Environment.NewLine;

            //outStr += "gen_cashier_z:" + gen_cashier_z + Environment.NewLine;
            //outStr += Util.Encrypt("gen_cashier_swipe:" + gen_cashier_swipe) + Environment.NewLine;
            //outStr += Util.Encrypt("gen_ignore_paper:" + gen_ignore_paper) + Environment.NewLine;
            outStr += Util.Encrypt("gen_print_address:" + gen_print_address) + Environment.NewLine;
            outStr += Util.Encrypt("gen_print_copy:" + gen_print_copy) + Environment.NewLine;
            outStr += Util.Encrypt("gen_print_pinless_slip:" + gen_print_pinless_slip) + Environment.NewLine;
            outStr += Util.Encrypt("gen_cashier_ownsales:" + gen_cashier_ownsales) + Environment.NewLine;

            outStr += Util.Encrypt("gen_cashier_w:" + gen_cashier_w) + Environment.NewLine;
            outStr += Util.Encrypt("gen_cashier_y:" + gen_cashier_y) + Environment.NewLine;
            outStr += Util.Encrypt("gen_cashier_y_all:" + gen_cashier_y_all) + Environment.NewLine;
            outStr += Util.Encrypt("gen_cashier_y_history:" + gen_cashier_y_history) + Environment.NewLine;
            outStr += Util.Encrypt("gen_cashier_elec_disabled:" + gen_cashier_elec_disabled) + Environment.NewLine;
            outStr += Util.Encrypt("gen_cashier_bill_disabled:" + gen_cashier_bill_disabled) + Environment.NewLine;
            outStr += Util.Encrypt("gen_cashier_salehistory_disabled:" + gen_cashier_salehistory_disabled) + Environment.NewLine;
            outStr += Util.Encrypt("gen_cashier_restart:" + gen_cashier_restart) + Environment.NewLine;

            outStr += Util.Encrypt("gen_cashier_allowreprint:" + gen_cashier_allowreprint) + Environment.NewLine;
            outStr += Util.Encrypt("gen_cashier_allowreprintlast:" + gen_cashier_allowreprintlast) + Environment.NewLine;
            outStr += Util.Encrypt("gen_cashier_allowreprintlast_admin:" + gen_cashier_allowreprintlast_admin) + Environment.NewLine;
            outStr += Util.Encrypt("gen_cashier_billconvenience_cashier:" + gen_cashier_billconvenience_cashier) + Environment.NewLine;
            outStr += Util.Encrypt("gen_cashier_billconvenience_admin:" + gen_cashier_billconvenience_admin) + Environment.NewLine;

            outStr += Util.Encrypt("quickprint_item1:" + quickprint_item1) + Environment.NewLine;
            outStr += Util.Encrypt("quickprint_item2:" + quickprint_item2) + Environment.NewLine;
            outStr += Util.Encrypt("quickprint_item3:" + quickprint_item3) + Environment.NewLine;
            outStr += Util.Encrypt("quickprint_item4:" + quickprint_item4) + Environment.NewLine;
            outStr += Util.Encrypt("quickprint_item5:" + quickprint_item5) + Environment.NewLine;

            outStr += Util.Encrypt("elec_preset_enabled:" + elec_preset_enabled) + Environment.NewLine;
            outStr += Util.Encrypt("elec_preset_val1:" + elec_preset_val1) + Environment.NewLine;
            outStr += Util.Encrypt("elec_preset_val2:" + elec_preset_val2) + Environment.NewLine;
            outStr += Util.Encrypt("elec_preset_val3:" + elec_preset_val3) + Environment.NewLine;
            outStr += Util.Encrypt("elec_preset_val4:" + elec_preset_val4) + Environment.NewLine;

            outStr += Util.Encrypt("elec_max_vend_show:" + elec_max_vend_show) + Environment.NewLine;
            outStr += Util.Encrypt("elec_max_warning_show:" + elec_max_warning_show) + Environment.NewLine;
            outStr += Util.Encrypt("elec_max_warning_val:" + elec_max_warning_val) + Environment.NewLine;

            outStr += Util.Encrypt("gen_show_voucher_only:" + gen_show_voucher_only) + Environment.NewLine;
            outStr += Util.Encrypt("gen_show_btn_skype:" + gen_show_btn_skype) + Environment.NewLine;
            outStr += Util.Encrypt("gen_show_btn_teamviewer:" + gen_show_btn_teamviewer) + Environment.NewLine;
            outStr += Util.Encrypt("gen_teamviewer_location:" + gen_teamviewer_location) + Environment.NewLine;
            outStr += Util.Encrypt("gen_slip_printer:" + gen_slip_printer) + Environment.NewLine;

            //outStr += Util.Encrypt("gen_show_login_desktop_icon:" + gen_show_login_desktop_icon) + Environment.NewLine;
            //outStr += Util.Encrypt("gen_show_login_lockpc_icon:" + gen_show_login_lockpc_icon) + Environment.NewLine;
            //outStr += Util.Encrypt("gen_show_login_netcon_icon:" + gen_show_login_netcon_icon) + Environment.NewLine;
            //outStr += Util.Encrypt("gen_show_login_shutdown:" + gen_show_login_shutdown) + Environment.NewLine;

            outStr += Util.Encrypt("gen_show_financials:" + gen_show_financials) + Environment.NewLine;
            outStr += Util.Encrypt("gen_show_financials_cashier:" + gen_show_financials_cashier) + Environment.NewLine;
            outStr += Util.Encrypt("gen_show_last_sale_login:" + gen_show_last_sale_login) + Environment.NewLine;

            outStr += Util.Encrypt("gen_virtual_keyboard:" + gen_virtual_keyboard) + Environment.NewLine;
            outStr += Util.Encrypt("gen_sound:" + gen_sound) + Environment.NewLine;
            outStr += Util.Encrypt("gen_show_multi_voucher:" + gen_show_multi_voucher) + Environment.NewLine;

            outStr += Util.Encrypt("gen_tiu_contact:" + gen_tiu_contact) + Environment.NewLine;

            outStr += Util.Encrypt("saved_meter_1:" + saved_meter_1) + Environment.NewLine;
            outStr += Util.Encrypt("saved_meter_2:" + saved_meter_2) + Environment.NewLine;
            outStr += Util.Encrypt("saved_meter_3:" + saved_meter_3) + Environment.NewLine;
            outStr += Util.Encrypt("saved_meter_4:" + saved_meter_4) + Environment.NewLine;
            outStr += Util.Encrypt("saved_meter_5:" + saved_meter_5) + Environment.NewLine;
            outStr += Util.Encrypt("saved_meter_1_desc:" + saved_meter_1_desc) + Environment.NewLine;
            outStr += Util.Encrypt("saved_meter_2_desc:" + saved_meter_2_desc) + Environment.NewLine;
            outStr += Util.Encrypt("saved_meter_3_desc:" + saved_meter_3_desc) + Environment.NewLine;
            outStr += Util.Encrypt("saved_meter_4_desc:" + saved_meter_4_desc) + Environment.NewLine;
            outStr += Util.Encrypt("saved_meter_5_desc:" + saved_meter_5_desc) + Environment.NewLine;

            outStr += Util.Encrypt("allow_screen_resize:" + allow_screen_resize) + Environment.NewLine;

            TextWriter tw = new StreamWriter(app_path + @"\conf\settings_gen.dat", false);
            tw.Write(outStr);
            tw.Close();

            return true;
        }



        public static String get_general_settings()
        {

            string outStr = "";

            //outStr += "sim_pin:" + sim_pin + Environment.NewLine;

            outStr += "gen_is3g:" + gen_is3g + Environment.NewLine;
            outStr += "gen_airtime:" + gen_airtime + Environment.NewLine;
            outStr += "gen_elec:" + gen_elec + Environment.NewLine;
            outStr += "gen_rica:" + gen_rica + Environment.NewLine;
            outStr += "gen_water:" + gen_water + Environment.NewLine;
            outStr += "gen_bills:" + gen_bills + Environment.NewLine;
            outStr += "gen_pinless:" + gen_pinless + Environment.NewLine;
            outStr += "gen_cashdr:" + gen_cashdr + Environment.NewLine;
            outStr += "gen_cashdr_cashier:" + gen_cashdr_cashier + Environment.NewLine;
            outStr += "gen_cashdrrj12:" + gen_cashdrrj12 + Environment.NewLine;
            outStr += "gen_logout:" + gen_logout + Environment.NewLine;
            outStr += "gen_logout_time:" + gen_logout_time.ToString() + Environment.NewLine;
            outStr += "gen_prnt_b:" + gen_prnt_b + Environment.NewLine;
            outStr += "gen_prnt_be:" + gen_prnt_be + Environment.NewLine;
            outStr += "gen_prnt_bb:" + gen_prnt_bb + Environment.NewLine;
            outStr += "gen_show_balance_login:" + gen_show_balance_login + Environment.NewLine;
            outStr += "gen_show_balance:" + gen_show_balance + Environment.NewLine;
            outStr += "gen_quick_print_disable:" + gen_quick_print_disable + Environment.NewLine;
            outStr += "gen_quick_print_confirm:" + gen_quick_print_confirm + Environment.NewLine;
            outStr += "gen_disable_clock:" + gen_disable_clock + Environment.NewLine;

            outStr += "gen_print_address:" + gen_print_address + Environment.NewLine;
            outStr += "gen_print_copy:" + gen_print_copy + Environment.NewLine;
            outStr += "gen_print_pinless_slip:" + gen_print_pinless_slip + Environment.NewLine;
            outStr += "gen_cashier_ownsales:" + gen_cashier_ownsales + Environment.NewLine;

            outStr += "gen_cashier_w:" + gen_cashier_w + Environment.NewLine;
            outStr += "gen_cashier_y:" + gen_cashier_y + Environment.NewLine;
            outStr += "gen_cashier_y_all:" + gen_cashier_y_all + Environment.NewLine;
            outStr += "gen_cashier_y_history:" + gen_cashier_y_history +  Environment.NewLine;
            outStr += "gen_cashier_elec_disabled:" + gen_cashier_elec_disabled + Environment.NewLine;
            outStr += "gen_cashier_bill_disabled:" + gen_cashier_bill_disabled + Environment.NewLine;
            outStr += "gen_cashier_salehistory_disabled:" + gen_cashier_salehistory_disabled + Environment.NewLine;
            outStr += "gen_cashier_restart:" + gen_cashier_restart + Environment.NewLine;

            outStr += "gen_cashier_allowreprint:" + gen_cashier_allowreprint + Environment.NewLine;
            outStr += "gen_cashier_allowreprintlast:" + gen_cashier_allowreprintlast + Environment.NewLine;
            outStr += "gen_cashier_allowreprintlast_admin:" + gen_cashier_allowreprintlast_admin + Environment.NewLine;
            outStr += "gen_cashier_billconvenience_cashier:" + gen_cashier_billconvenience_cashier + Environment.NewLine;
            outStr += "gen_cashier_billconvenience_admin:" + gen_cashier_billconvenience_admin + Environment.NewLine;

            outStr += "quickprint_item1:" + quickprint_item1 + Environment.NewLine;
            outStr += "quickprint_item2:" + quickprint_item2 + Environment.NewLine;
            outStr += "quickprint_item3:" + quickprint_item3 + Environment.NewLine;
            outStr += "quickprint_item4:" + quickprint_item4 + Environment.NewLine;
            outStr += "quickprint_item5:" + quickprint_item5 + Environment.NewLine;

            outStr += "elec_preset_enabled:" + elec_preset_enabled + Environment.NewLine;
            outStr += "elec_preset_val1:" + elec_preset_val1 + Environment.NewLine;
            outStr += "elec_preset_val2:" + elec_preset_val2 + Environment.NewLine;
            outStr += "elec_preset_val3:" + elec_preset_val3 + Environment.NewLine;
            outStr += "elec_preset_val4:" + elec_preset_val4 + Environment.NewLine;

            outStr += "elec_max_vend_show:" + elec_max_vend_show + Environment.NewLine;
            outStr += "elec_max_warning_show:" + elec_max_warning_show + Environment.NewLine;
            outStr += "elec_max_warning_val:" + elec_max_warning_val + Environment.NewLine;

            outStr += "gen_show_voucher_only:" + gen_show_voucher_only + Environment.NewLine;
            outStr += "gen_show_btn_skype:" + gen_show_btn_skype + Environment.NewLine;
            outStr += "gen_show_btn_teamviewer:" + gen_show_btn_teamviewer + Environment.NewLine;
            outStr += "gen_teamviewer_location:" + gen_teamviewer_location + Environment.NewLine;
            outStr += "gen_slip_printer:" + gen_slip_printer + Environment.NewLine;

            outStr += "gen_show_financials:" + gen_show_financials + Environment.NewLine;
            outStr += "gen_show_financials_cashier:" + gen_show_financials_cashier + Environment.NewLine;
            outStr += "gen_show_last_sale_login:" + gen_show_last_sale_login + Environment.NewLine;

            outStr += "gen_virtual_keyboard:" + gen_virtual_keyboard + Environment.NewLine;
            outStr += "gen_sound:" + gen_sound + Environment.NewLine;

            outStr += "gen_tiu_contact:" + gen_tiu_contact + Environment.NewLine;

            outStr += "saved_meter_1:" + saved_meter_1 + Environment.NewLine;
            outStr += "saved_meter_2:" + saved_meter_2 + Environment.NewLine;
            outStr += "saved_meter_3:" + saved_meter_3 + Environment.NewLine;
            outStr += "saved_meter_4:" + saved_meter_4 + Environment.NewLine;
            outStr += "saved_meter_5:" + saved_meter_5 + Environment.NewLine;
            outStr += "saved_meter_1_desc:" + saved_meter_1_desc + Environment.NewLine;
            outStr += "saved_meter_2_desc:" + saved_meter_2_desc + Environment.NewLine;
            outStr += "saved_meter_3_desc:" + saved_meter_3_desc + Environment.NewLine;
            outStr += "saved_meter_4_desc:" + saved_meter_4_desc + Environment.NewLine;
            outStr += "saved_meter_5_desc:" + saved_meter_5_desc + Environment.NewLine;

            outStr += "allow_screen_resize:" + allow_screen_resize + Environment.NewLine;

            return outStr;

        }


        public static bool load_from_backup()
        {

            bool ret = false;

            try
            {
                if (File.Exists(app_path + @"\conf\settings_restore.dat"))
                {
                    StreamReader myFile = new StreamReader(app_path + @"\conf\settings_restore.dat");

                    string line;
                    while ((line = myFile.ReadLine()) != null)
                    {

                        //line = Util.Decrypt(line);

                        //if (line.IndexOf("sim_pin:") >= 0) sim_pin = line.Replace("sim_pin:", "").Trim();

                        if (line.IndexOf("gen_is3g:") >= 0) gen_is3g = line.Replace("gen_is3g:", "").Trim();
                        if (line.IndexOf("gen_airtime:") >= 0) gen_airtime = line.Replace("gen_airtime:", "").Trim();
                        if (line.IndexOf("gen_elec:") >= 0) gen_elec = line.Replace("gen_elec:", "").Trim();
                        if (line.IndexOf("gen_rica:") >= 0) gen_rica = line.Replace("gen_rica:", "").Trim();
                        if (line.IndexOf("gen_water:") >= 0) gen_water = line.Replace("gen_water:", "").Trim();
                        if (line.IndexOf("gen_bills:") >= 0) gen_bills = line.Replace("gen_bills:", "").Trim();
                        if (line.IndexOf("gen_pinless:") >= 0) gen_pinless = line.Replace("gen_pinless:", "").Trim();

                        if (line.IndexOf("gen_cashdr:") >= 0) gen_cashdr = line.Replace("gen_cashdr:", "").Trim();
                        if (line.IndexOf("gen_cashdr_cashier:") >= 0) gen_cashdr_cashier = line.Replace("gen_cashdr_cashier:", "").Trim();
                        if (line.IndexOf("gen_cashdrrj12:") >= 0) gen_cashdrrj12 = line.Replace("gen_cashdrrj12:", "").Trim();

                        if (line.IndexOf("gen_logout:") >= 0) gen_logout = line.Replace("gen_logout:", "").Trim();

                        if (line.IndexOf("gen_logout_time:") >= 0)
                        {
                            try
                            {
                                gen_logout_time = Convert.ToInt32(line.Replace("gen_logout_time:", "").Trim());
                            }
                            catch
                            {
                                gen_logout_time = 0;
                            }
                        }

                        if (line.IndexOf("gen_prnt_b:") >= 0) gen_prnt_b = line.Replace("gen_prnt_b:", "").Trim();
                        if (line.IndexOf("gen_prnt_be:") >= 0) gen_prnt_be = line.Replace("gen_prnt_be:", "").Trim();
                        if (line.IndexOf("gen_prnt_bb:") >= 0) gen_prnt_bb = line.Replace("gen_prnt_bb:", "").Trim();
                        if (line.IndexOf("gen_show_balance_login:") >= 0) gen_show_balance_login = line.Replace("gen_show_balance_login:", "").Trim();
                        if (line.IndexOf("gen_show_balance:") >= 0) gen_show_balance = line.Replace("gen_show_balance:", "").Trim();
                        if (line.IndexOf("gen_quick_print_disable:") >= 0) gen_quick_print_disable = line.Replace("gen_quick_print_disable:", "").Trim();
                        if (line.IndexOf("gen_quick_print_confirm:") >= 0) gen_quick_print_confirm = line.Replace("gen_quick_print_confirm:", "").Trim();

                        if (line.IndexOf("gen_disable_clock:") >= 0) gen_disable_clock = line.Replace("gen_disable_clock:", "").Trim();


                        //if (line.IndexOf("gen_cashier_z:") >= 0)
                        //{
                        //    gen_cashier_z = line.Replace("gen_cashier_z:", "").Trim();
                        //}
                        //if (line.IndexOf("gen_cashier_swipe:") >= 0)    gen_cashier_swipe = line.Replace("gen_cashier_swipe:", "").Trim();
                        //if (line.IndexOf("gen_ignore_paper:") >= 0)     gen_ignore_paper = line.Replace("gen_ignore_paper:", "").Trim();
                        if (line.IndexOf("gen_print_address:") >= 0) gen_print_address = line.Replace("gen_print_address:", "").Trim();
                        if (line.IndexOf("gen_print_copy:") >= 0) gen_print_copy = line.Replace("gen_print_copy:", "").Trim();
                        if (line.IndexOf("gen_print_pinless_slip:") >= 0) gen_print_pinless_slip = line.Replace("gen_print_pinless_slip:", "").Trim();


                        if (line.IndexOf("gen_cashier_ownsales:") >= 0) gen_cashier_ownsales = line.Replace("gen_cashier_ownsales:", "").Trim();
                        if (line.IndexOf("gen_cashier_w:") >= 0) gen_cashier_w = line.Replace("gen_cashier_w:", "").Trim();
                        if (line.IndexOf("gen_cashier_y:") >= 0) gen_cashier_y = line.Replace("gen_cashier_y:", "").Trim();
                        if (line.IndexOf("gen_cashier_y_all:") >= 0) gen_cashier_y_all = line.Replace("gen_cashier_y_all:", "").Trim();
                        if (line.IndexOf("gen_cashier_y_history:") >= 0) gen_cashier_y_history = line.Replace("gen_cashier_y_history:", "").Trim();
                        if (line.IndexOf("gen_cashier_elec_disabled:") >= 0) gen_cashier_elec_disabled = line.Replace("gen_cashier_elec_disabled:", "").Trim();
                        if (line.IndexOf("gen_cashier_bill_disabled:") >= 0) gen_cashier_bill_disabled = line.Replace("gen_cashier_bill_disabled:", "").Trim();
                        if (line.IndexOf("gen_cashier_salehistory_disabled:") >= 0) gen_cashier_salehistory_disabled = line.Replace("gen_cashier_salehistory_disabled:", "").Trim();
                        if (line.IndexOf("gen_cashier_restart:") >= 0) gen_cashier_restart = line.Replace("gen_cashier_restart:", "").Trim();

                        if (line.IndexOf("gen_cashier_allowreprint:") >= 0) gen_cashier_allowreprint = line.Replace("gen_cashier_allowreprint:", "").Trim();
                        if (line.IndexOf("gen_cashier_allowreprintlast:") >= 0) gen_cashier_allowreprintlast = line.Replace("gen_cashier_allowreprintlast:", "").Trim();
                        if (line.IndexOf("gen_cashier_allowreprintlast_admin:") >= 0) gen_cashier_allowreprintlast_admin = line.Replace("gen_cashier_allowreprintlast_admin:", "").Trim();
                        if (line.IndexOf("gen_cashier_billconvenience_cashier:") >= 0) gen_cashier_billconvenience_cashier = line.Replace("gen_cashier_billconvenience_cashier:", "").Trim();
                        if (line.IndexOf("gen_cashier_billconvenience_admin:") >= 0) gen_cashier_billconvenience_admin = line.Replace("gen_cashier_billconvenience_admin:", "").Trim();

                        if (line.IndexOf("quickprint_item1:") >= 0) quickprint_item1 = line.Replace("quickprint_item1:", "").Trim();
                        if (line.IndexOf("quickprint_item2:") >= 0) quickprint_item2 = line.Replace("quickprint_item2:", "").Trim();
                        if (line.IndexOf("quickprint_item3:") >= 0) quickprint_item3 = line.Replace("quickprint_item3:", "").Trim();
                        if (line.IndexOf("quickprint_item4:") >= 0) quickprint_item4 = line.Replace("quickprint_item4:", "").Trim();
                        if (line.IndexOf("quickprint_item5:") >= 0) quickprint_item5 = line.Replace("quickprint_item5:", "").Trim();

                        if (line.IndexOf("elec_preset_enabled:") >= 0) elec_preset_enabled = line.Replace("elec_preset_enabled:", "").Trim();
                        if (line.IndexOf("elec_preset_val1:") >= 0) elec_preset_val1 = line.Replace("elec_preset_val1:", "").Trim();
                        if (line.IndexOf("elec_preset_val2:") >= 0) elec_preset_val2 = line.Replace("elec_preset_val2:", "").Trim();
                        if (line.IndexOf("elec_preset_val3:") >= 0) elec_preset_val3 = line.Replace("elec_preset_val3:", "").Trim();
                        if (line.IndexOf("elec_preset_val4:") >= 0) elec_preset_val4 = line.Replace("elec_preset_val4:", "").Trim();

                        if (line.IndexOf("elec_max_vend_show:") >= 0) elec_max_vend_show = line.Replace("elec_max_vend_show:", "").Trim();
                        if (line.IndexOf("elec_max_warning_show:") >= 0) elec_max_warning_show = line.Replace("elec_max_warning_show:", "").Trim();
                        if (line.IndexOf("elec_max_warning_val:") >= 0) elec_max_warning_val = line.Replace("elec_max_warning_val:", "").Trim();

                        /* desktop app */
                        if (line.IndexOf("gen_show_voucher_only:") >= 0) gen_show_voucher_only = line.Replace("gen_show_voucher_only:", "").Trim();
                        if (line.IndexOf("gen_show_btn_skype:") >= 0) gen_show_btn_skype = line.Replace("gen_show_btn_skype:", "").Trim();
                        if (line.IndexOf("gen_show_btn_teamviewer:") >= 0) gen_show_btn_teamviewer = line.Replace("gen_show_btn_teamviewer:", "").Trim();
                        if (line.IndexOf("gen_teamviewer_location:") >= 0) gen_teamviewer_location = line.Replace("gen_teamviewer_location:", "").Trim();
                        if (line.IndexOf("gen_slip_printer:") >= 0) gen_slip_printer = line.Replace("gen_slip_printer:", "").Trim();

                        if (line.IndexOf("gen_show_financials:") >= 0) gen_show_financials = line.Replace("gen_show_financials:", "").Trim();
                        if (line.IndexOf("gen_show_financials_cashier:") >= 0) gen_show_financials_cashier = line.Replace("gen_show_financials_cashier:", "").Trim();
                        if (line.IndexOf("gen_show_last_sale_login:") >= 0) gen_show_last_sale_login = line.Replace("gen_show_last_sale_login:", "").Trim();

                        if (line.IndexOf("gen_virtual_keyboard:") >= 0) gen_virtual_keyboard = line.Replace("gen_virtual_keyboard:", "").Trim();
                        if (line.IndexOf("gen_sound:") >= 0) gen_virtual_keyboard = line.Replace("gen_sound:", "").Trim();

                        if (line.IndexOf("gen_tiu_contact:") >= 0) gen_tiu_contact = line.Replace("gen_tiu_contact:", "").Trim();

                        if (line.IndexOf("saved_meter_1:") >= 0) saved_meter_1 = line.Replace("saved_meter_1:", "").Trim();
                        if (line.IndexOf("saved_meter_2:") >= 0) saved_meter_2 = line.Replace("saved_meter_2:", "").Trim();
                        if (line.IndexOf("saved_meter_3:") >= 0) saved_meter_3 = line.Replace("saved_meter_3:", "").Trim();
                        if (line.IndexOf("saved_meter_4:") >= 0) saved_meter_4 = line.Replace("saved_meter_4:", "").Trim();
                        if (line.IndexOf("saved_meter_5:") >= 0) saved_meter_5 = line.Replace("saved_meter_5:", "").Trim();
                        if (line.IndexOf("saved_meter_1_desc:") >= 0) saved_meter_1_desc = line.Replace("saved_meter_1_desc:", "").Trim();
                        if (line.IndexOf("saved_meter_2_desc:") >= 0) saved_meter_2_desc = line.Replace("saved_meter_2_desc:", "").Trim();
                        if (line.IndexOf("saved_meter_3_desc:") >= 0) saved_meter_3_desc = line.Replace("saved_meter_3_desc:", "").Trim();
                        if (line.IndexOf("saved_meter_4_desc:") >= 0) saved_meter_4_desc = line.Replace("saved_meter_4_desc:", "").Trim();
                        if (line.IndexOf("saved_meter_5_desc:") >= 0) saved_meter_5_desc = line.Replace("saved_meter_5_desc:", "").Trim();

                        if (line.IndexOf("allow_screen_resize:") >= 0) allow_screen_resize = line.Replace("allow_screen_resize:", "").Trim();


                    }
                    myFile.Close();

                    ret = true;

                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }


            return ret;

        }


    }

}

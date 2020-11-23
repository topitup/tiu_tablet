using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace TopitUp
{

    static class webService
    {



        public static string elecCustInfoReq(string meterNumber)
        {

            string htmlResponse = "";

            Web WebResponse = new Web(45000, 1,"");
            htmlResponse = WebResponse.GetURL("/itron/electricity/custInfoReq?lic=" + globalSettings.license_code + "&m=" + meterNumber);
            WebResponse = null;

            if (htmlResponse.IndexOf("Communication error. Check signal/connection.") > -1)
                htmlResponse = "";

            if (htmlResponse.IndexOf("ERR:") > -1)
                htmlResponse = "";

            return htmlResponse;
        }



        public static string elecReprint(string stock_uid, string useDateRange)
        {

            string htmlResponse = "";
            string url_extra = "";
            if (useDateRange == "false")
            {
                url_extra = "&d=" + useDateRange;
            }

            Web WebResponse = new Web(45000, 1,"");
            htmlResponse = WebResponse.GetURL("/itron/electricity/vendGetReprint?lic=" + globalSettings.license_code + "&uid=" + stock_uid + "&s=1" + url_extra);
            WebResponse = null;

            if (htmlResponse.IndexOf("ERR:") > -1)
                htmlResponse = "";

            return htmlResponse;
        }

        public static string elecReprintByMeter(string meter)
        {

            string htmlResponse = "";

            Web WebResponse = new Web(45000, 1, "");
            htmlResponse = WebResponse.GetURL("/itron/electricity/vendGetReprintMeter?lic=" + globalSettings.license_code + "&meter=" + meter);
            WebResponse = null;

            if (htmlResponse.IndexOf("ERR:") > -1)
                htmlResponse = "";

            return htmlResponse;
        }




        public static bool getItems()
        {

            string htmlResponse = "";
            bool ret = false;

            try
            {
                Web WebResponse = new Web(45000, 1, "");
                htmlResponse = WebResponse.GetURL("/terminal/general/get-items");
                WebResponse = null;

                if (htmlResponse.IndexOf("err>") == -1)
                {
                    if (htmlResponse.Substring(0, 2) == "p^")
                    {
                        string filename = globalSettings.app_path + @"\conf\provider_item.dat";
                        if (File.Exists(filename) == true) { File.Delete(filename); }
                        TextWriter tw = new StreamWriter(filename, false);
                        tw.Write(htmlResponse);
                        tw.Close();
                        ret = true;
                    }
                    else
                    {
                        ret = false;
                    }
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


        public static String getPosUsers()
        {

            string htmlResponse = "";
            string errDesc = "";

            try
            {

                Web WebResponse = new Web(45000, 1, globalSettings.customer_id);
                htmlResponse = WebResponse.GetURL("/terminal/customer/get-posuser-list");
                WebResponse = null;

                if (htmlResponse.IndexOf("err>") == -1)
                {
                    string filename = globalSettings.app_path + @"\conf\posusers.dat";
                    if (File.Exists(filename) == true) { File.Delete(filename); }
                    TextWriter tw = new StreamWriter(filename, false);
                    tw.Write(htmlResponse);
                    tw.Close();
                }
                else
                {
                    errDesc = htmlResponse.GetStrBetweenTags("<err>", "</err>");
                }
            }
            catch
            {
                errDesc = "Could not retrieve POS users.";
            }

            return errDesc;

        }

        public static String savePosUser(
                String posuser_id,
                String posuser_firstname,
                String posuser_surname,
                String posuser_pin,
                String posuser_pin_swipe,
                String posuser_status,
                String posuser_isadmin,
                String id_type,
                String id_number,
                String rica_training
            )
        {

            string htmlResponse = "";
            string ret = "";
            string query_string = "";

            try
            {

                query_string = "ver=2";
                query_string += "&pid=" + posuser_id;
                query_string += "&fn=" + posuser_firstname;
                query_string += "&ln=" + posuser_surname;
                query_string += "&p=" + posuser_pin;
                query_string += "&s=" + posuser_pin_swipe;
                query_string += "&e=" + posuser_status;
                query_string += "&a=" + posuser_isadmin;
                query_string += "&idt=" + id_type;
                query_string += "&idn=" + id_number;
                query_string += "&rt=" + rica_training;

                Web WebResponse = new Web(45000, 1, "");
                htmlResponse = WebResponse.GetURL("/terminal/customer/save-posuser?" + query_string);
                WebResponse = null;

                if (htmlResponse.IndexOf("err>") == -1)
                {
                    ret = "OK";
                }
                else
                {
                    ret = htmlResponse.GetStrBetweenTags("<err>", "</err>");
                }
            }
            catch
            {
                ret = "Could not save POS user.";
            }

            return ret;

        }


        public static String deletePosUser(String posuser_id){

            string htmlResponse = "";
            string errDesc = "";
            string query_string = "";

            try
            {

                query_string = "pid=" + posuser_id;

                Web WebResponse = new Web(45000, 1, "");
                htmlResponse = WebResponse.GetURL("/terminal/customer/delete-posuser?" + query_string);
                WebResponse = null;

                if (htmlResponse.IndexOf("<err>") == -1)
                {
                    // Delete OK
                }
                else
                {
                    errDesc = htmlResponse.GetStrBetweenTags("<err>", "</err>");
                }
            }
            catch
            {
                errDesc = "Could not remove POS user.";
            }

            return errDesc;

        }


        
        public static String checkRICA( String service_provider_item_id, String register_number)
        {

            string htmlResponse = "";
            string ret = "";
            string query_string = "";

            try
            {

                query_string = "spi=" + service_provider_item_id;
                query_string += "&ref=" + register_number;

                Web WebResponse = new Web(45000);
                htmlResponse = WebResponse.GetURL("/terminal/rica/check-status?" + query_string);
                WebResponse = null;

                ret = htmlResponse;

            }
            catch
            {
                ret = "<err>Could not confirm SIM." + Environment.NewLine + "Please contact Top it Up.</err>";
            }

            return ret;

        }

        public static String saveRICA(
                String service_provider_item_id,
                String register_type,
                String register_number,
                String register_digits,
                String id_type,
                String id_number,
                String fname,
                String lname,
                String nationality,
                String contact_number,
                String addr1,
                String addr2,
                String city,
                String suburb,
                String suburd_code,
                String country,
                String confirm)
        {

            string htmlResponse = "";
            string ret = "";
            string query_string = "";

            try
            {

                query_string = "spi=" + service_provider_item_id;
                query_string += "&q1=" + register_type;
                query_string += "&q2=" + register_number;
                query_string += "&q3=" + register_digits;
                query_string += "&q4=" + id_type;
                query_string += "&q5=" + id_number;
                query_string += "&q6=" + fname;
                query_string += "&q7=" + lname;
                query_string += "&q8=" + nationality;
                query_string += "&q9=" + contact_number;
                query_string += "&q10=" + addr1;
                query_string += "&q11=" + addr2;
                query_string += "&q12=" + city;
                query_string += "&q13=" + suburb;
                query_string += "&q14=" + suburd_code;
                query_string += "&q15=" + country;
                query_string += "&q16=" + confirm;

                Web WebResponse = new Web(45000);
                htmlResponse = WebResponse.GetURL("/rica/general/register?" + query_string);
                WebResponse = null;

                ret = htmlResponse;
               
            }
            catch
            {
                ret = "<err>Could not register RICA request." + Environment.NewLine + "Please contact Top it Up.</err>";
            }

            return ret;

        }


        public static String getCustomerDetails()
        {

            string errDesc = "";

            string htmlResponse = "";
            try
            {

                Web WebResponse = new Web(15000, 1, "");
                htmlResponse = WebResponse.GetURL("/terminal/customer/get-info");
                WebResponse = null;

                if (htmlResponse != "")
                {

                    Newtonsoft.Json.Linq.JObject json = Newtonsoft.Json.Linq.JObject.Parse(htmlResponse);

                    globalSettings.customer_id = (string)json["customer_id"];
                    globalSettings.company_name = (string)json["company_name"];
                    globalSettings.account_number = (string)json["account_number"];
                    globalSettings.company_address = (string)json["address"];
                    
                    globalSettings.Save();

                    String products = (string)json["products"];

                    globalSettings.gen_airtime = "0";
                    if (products[0] == '1') globalSettings.gen_airtime = "1";

                    globalSettings.gen_elec = "0";
                    if (products[1] == '1') globalSettings.gen_elec = "1";

                    globalSettings.gen_rica = "0";
                    if (products[2] == '1') globalSettings.gen_rica = "1";

                    globalSettings.gen_water = "0";
                    if (products[3] == '1') globalSettings.gen_water = "1";

                    globalSettings.gen_bills = "0";
                    if (products[4] == '1') globalSettings.gen_bills = "1";

                    globalSettings.gen_pinless = "0";
                    if (products[5] == '1') globalSettings.gen_pinless = "1";

                    globalSettings.SaveGeneral();

                    try
                    {
                        string[] address_line = globalSettings.company_address.Split('|');
                        Util.voucher_print_address[0] = address_line[0];
                        Util.voucher_print_address[1] = address_line[1];
                    }
                    catch
                    {
                        //
                    }

                }


            }
            catch (Exception e)
            {
                errDesc = e.Message;
            }

            return errDesc;
        }




        public static String getReprint(int type, String param)
        {
            String ret = "";
            String htmlResponse = "";

            globalVoucher.Clear();

            // response
            // ret = "uid=" + rs.getInt("stock_uid");
            // ret += "^p=" + rs.getString("pin_number");
            // ret += "^s=" + rs.getString("serial_number");
            // ret += "^l=" + low_balance;
            // ret += "^b=" + available_balance;
            // ret += "^pid=" + rs.getInt("service_provider_id");
            // ret += "^spid=" + rs.getInt("service_provider_item_id");
            // ret += "^c=" + rs.getInt("reprint_count");
            // ret += "^d=" + rs.getString("reprint_dtm");

            Web WebResponse = new Web(45000);
            htmlResponse = WebResponse.GetURL("/terminal/voucher/reprint-voucher?t=" + type.ToString() + "&s=" + param);
            WebResponse = null;

            if (htmlResponse.IndexOf("<webreqerr>") > -1)
            {
                ret = htmlResponse.GetStrBetweenTags("<webreqerr>", "</webreqerr>");
            }
            else if (htmlResponse.IndexOf("<err>") > -1)
            {
                ret = htmlResponse.GetStrBetweenTags("<err>", "</err>");
            }
            else
            {

                if (htmlResponse.IndexOf("uid=") > -1)
                {
                    ret = "OK";
                }

                try {

                    globalVoucher.is_reprint = true;

                    char[] del = new char[] { '=', '^' };
                    string[] tokens = htmlResponse.Split(del);

                    for (int token = 0; token < tokens.Length; token += 2)
                    {
                        string s1 = tokens[token];
                        string s2 = tokens[token + 1];

                        if (s1 == "uid")
                            globalVoucher.stock_uid = s2;
                        if (s1 == "p")
                            globalVoucher.pin_number_encryped = s2;
                        if (s1 == "s")
                            globalVoucher.serial_number = s2;
                        if (s1 == "t")
                            globalVoucher.reprint_dtm = s2;
                        if (s1 == "c")
                            globalVoucher.reprint_count = s2;
                        if (s1 == "sp")
                            globalVoucher.service_provider_id = Int32.Parse(s2);
                        if (s1 == "spi")
                            globalVoucher.service_provider_item_id = Int32.Parse(s2);
                        if (s1 == "dtm")
                            globalVoucher.tx_date = s2;
                        
                        if (s1 == "l")
                            if (s2 == "1")
                                finBalance.low_balance = "1";
                            else
                                finBalance.low_balance = "0";

                        if (s1 == "b") finBalance.available_balance = s2;
                    }
                } 
                catch (Exception ex) 
                {
                    ret = ex.Message;
                }

            }

            return ret;

        }


            
            
        public static String getLastSales(int _filter_type,String _filter_value)
        {

            string htmlResponse = "";
            string ret = "";

            try
            {

                String urlParam = "?q=0";
                if (globalSettings.pos_user_admin || globalSettings.gen_cashier_ownsales == "0")
                {
                    urlParam = "?q=1";
                }

                urlParam += "&t=" + _filter_type;

                if (_filter_value.Length > 0)
                {
                    urlParam += "&f=" + _filter_value;
                }

                Web WebResponse = new Web(45000);
                htmlResponse = WebResponse.GetURL("/terminal/customer/get-last-sales-filter" + urlParam);
                WebResponse = null;

                ret = htmlResponse;
               
            }
            catch
            {
                ret = "<err>Could not retrieve last sales.</err>";
            }

            return ret;

        }



        public static String addPosUser(
                String posuser_firstname,
                String posuser_surname,
                String posuser_pin,
                String posuser_pin_swipe,
                String posuser_status,
                String posuser_isadmin,
                String idt,
                String idn,
                String rt)
        {

            string htmlResponse = "";
            string ret = "";
            string query_string = "";

            try
            {

                query_string += "&fn=" + posuser_firstname;
                query_string += "&ln=" + posuser_surname;
                query_string += "&p=" + posuser_pin;
                query_string += "&s=" + posuser_pin_swipe;
                query_string += "&e=" + posuser_status;
                query_string += "&a=" + posuser_isadmin;
                query_string += "&idt=" + idt;
                query_string += "&idn=" + idn;
                query_string += "&rt=" + rt;

                Web WebResponse = new Web(45000, 1, "");
                htmlResponse = WebResponse.GetURL("/terminal/customer/user-add?" + query_string);
                WebResponse = null;

                if (htmlResponse.IndexOf("err>") == -1)
                {
                    ret = "OK";
                }
                else
                {
                    ret = htmlResponse.StripErrorTags();
                }
            }
            catch
            {
                ret = "Could not add POS user.";
            }

            return ret;

        }


        public static String updatePosUser(
                String posuser_id,
                String posuser_firstname,
                String posuser_surname,
                String posuser_pin,
                String posuser_pin_swipe,
                String posuser_status,
                String posuser_isadmin,
                String idt,
                String idn,
                String rt
            )
        {

            string htmlResponse = "";
            string ret = "";
            string query_string = "";

            try
            {

                query_string = "pid=" + posuser_id;
                query_string += "&fn=" + posuser_firstname;
                query_string += "&ln=" + posuser_surname;
                query_string += "&p=" + posuser_pin;
                query_string += "&s=" + posuser_pin_swipe;
                query_string += "&e=" + posuser_status;
                query_string += "&a=" + posuser_isadmin;
                query_string += "&idt=" + idt;
                query_string += "&idn=" + idn;
                query_string += "&rt=" + rt;

                Web WebResponse = new Web(45000, 1, "");
                htmlResponse = WebResponse.GetURL("/terminal/customer/user-update?" + query_string);
                WebResponse = null;

                if (htmlResponse.IndexOf("err>") == -1)
                {
                    ret = "OK";
                }
                else
                {
                    ret = htmlResponse.StripErrorTags();
                }
            }
            catch
            {
                ret = "Could not save POS user.";
            }

            return ret;

        }



        public static String getSystemNotice(String current_notice_id)
        {

            string errDesc = "";
            string htmlResponse = "";
            try
            {

                Web WebResponse = new Web(25000, 2, "");
                htmlResponse = WebResponse.GetURL("/terminal/general/get-notice?id=" + current_notice_id);
                WebResponse = null;

                if (htmlResponse != "")
                {

                    Newtonsoft.Json.Linq.JObject json = Newtonsoft.Json.Linq.JObject.Parse(htmlResponse);

                    if (!String.IsNullOrEmpty((string)json["err"]))
                    {
                        errDesc = (string)json["err"];
                    }
                    else
                    {
                        globalSettings.notice_id = (string)json["notice_id"];
                        globalSettings.notice_data = (string)json["notice_data"];
                        globalSettings.SaveNotice();
                    }
                }

            }
            catch (Exception e)
            {
                errDesc = e.Message;
            }

            return errDesc;

        }




        public static string get_update_all()
        {

            string ret = "";
            string htmlResponse = "";

            try
            {

                String url_extra = "?spi=" + globalSettings.spi_ver;

                Web WebResponse = new Web(60000, 1, "");
                    htmlResponse = WebResponse.GetURL("/terminal/update/get-update-all" + url_extra);
                    WebResponse = null;

                if (htmlResponse.IndexOf("err>") == -1 && htmlResponse != "")
                {

                    String _provider_data = "";
                    String published_data = "";

                    Newtonsoft.Json.Linq.JObject json = Newtonsoft.Json.Linq.JObject.Parse(htmlResponse);

                    if (!String.IsNullOrEmpty((string)json["err"]))
                    {
                        ret = (string)json["err"];
                    }
                    else
                    {

                        if (!String.IsNullOrEmpty((string)json["customer_id"])) globalSettings.customer_id = (string)json["customer_id"];
                        if (!String.IsNullOrEmpty((string)json["company_name"])) globalSettings.company_name = (string)json["company_name"];
                        if (!String.IsNullOrEmpty((string)json["account_number"])) globalSettings.account_number = (string)json["account_number"];
                        if (!String.IsNullOrEmpty((string)json["address"])) globalSettings.company_address = (string)json["address"];
                        if (!String.IsNullOrEmpty((string)json["customer_accept"])) globalSettings.customer_accept = (string)json["customer_accept"];
                        if (!String.IsNullOrEmpty((string)json["enable_unipin"])) globalSettings.enable_unipin = (string)json["enable_unipin"];
                    
                        //Console.WriteLine("WTF SAVE: " + (string)json["enable_mamamoney"]);

                        if (!String.IsNullOrEmpty((string)json["enable_mamamoney"])) globalSettings.enable_mamamoney = (string)json["enable_mamamoney"];

                        globalSettings.Save();

                        String products = "000000";
                        if (!String.IsNullOrEmpty((string)json["products"])) products = (string)json["products"];
                        products = products.PadRight(6, '0');

                        globalSettings.gen_airtime = "0";
                        if (products[0] == '1') globalSettings.gen_airtime = "1";

                        globalSettings.gen_elec = "0";
                        if (products[1] == '1') globalSettings.gen_elec = "1";

                        globalSettings.gen_rica = "0";
                        if (products[2] == '1') globalSettings.gen_rica = "1";

                        globalSettings.gen_water = "0";
                        if (products[3] == '1') globalSettings.gen_water = "1";

                        globalSettings.gen_bills = "0";
                        if (products[4] == '1') globalSettings.gen_bills = "1";

                        globalSettings.gen_pinless = "0";
                        if (products[5] == '1') globalSettings.gen_pinless = "1";

                        globalSettings.SaveGeneral();

                        try
                        {
                            string[] address_line = globalSettings.company_address.Split('|');
                            Util.voucher_print_address[0] = address_line[0];
                            Util.voucher_print_address[1] = address_line[1];
                        }
                        catch
                        {
                            //
                        }

                        if (!String.IsNullOrEmpty((string)json["spi_ver"])) globalSettings.spi_ver = (string)json["spi_ver"];
                        if (!String.IsNullOrEmpty((string)json["published_data"])) published_data = (string)json["published_data"];

                        byte[] data = Convert.FromBase64String(published_data.ToString().Replace("\"", ""));
                        _provider_data = System.Text.Encoding.UTF8.GetString(data, 0, data.Length);
                    }

                    if (!_provider_data.Equals(""))
                    {
                        string filename = globalSettings.app_path + @"\conf\provider_item.dat";
                        if (File.Exists(filename) == true) { File.Delete(filename); }
                        TextWriter tw = new StreamWriter(filename, false);
                        tw.Write(_provider_data);
                        tw.Close();

                        //if (load_items) Util.loadProviderItem();

                    }

                    url_extra = "?spi=" + globalSettings.spi_ver;

                    Web _wr_update = new Web(15000, 1, "");
                    htmlResponse = _wr_update.GetURL("/terminal/update/update-spi-ver" + url_extra);
                    WebResponse = null;

                    if (htmlResponse.Equals("ok"))
                    {
                        globalSettings.SaveSPI();
                    }

                    ret = "";

                }
                else
                {
                    ret = htmlResponse.StripErrorTags();
                }
            }
            catch (Exception ex)
            {
                ret = ex.Message;
            }

            return ret;

        }


        public static String getNewAdvert()
        {

            string errDesc = "";
            string htmlResponse = "";
            try
            {

                Web WebResponse = new Web(45000, 2, "");
                htmlResponse = WebResponse.GetURL("/terminal/general/get-advert");
                WebResponse = null;

                if (htmlResponse != "")
                {

                    Newtonsoft.Json.Linq.JObject json = Newtonsoft.Json.Linq.JObject.Parse(htmlResponse);

                    if (!String.IsNullOrEmpty((string)json["err"]))
                    {
                        errDesc = (string)json["err"];
                    }
                    else
                    {
                        globalSettings.advert_id = (string)json["ad_id"];
                        globalSettings.advert_data = (string)json["ad_data"];

                        globalSettings.SaveAdvert();

                        Newtonsoft.Json.Linq.JArray a = (Newtonsoft.Json.Linq.JArray)json["images"];

                        foreach (var item in a.Children())
                        {
                            byte[] data = Convert.FromBase64String(item["img_data"].ToString().Replace("\"", ""));
                            Util.WriteAllBytes(globalSettings.app_path + @"\ads\" + item["img_name"].ToString().Replace("\"", ""), data);
                        }

                    }
                }

            }
            catch (Exception e)
            {
                errDesc = e.Message;
            }

            return errDesc;
        }





        public static String getCreditRequestStatus()
        {

            string errDesc = "";
            string htmlResponse = "";
            try
            {

                Web WebResponse = new Web(45000);
                htmlResponse = WebResponse.GetURL("/terminal/financial/credit-request-status");
                WebResponse = null;

                if (htmlResponse != "")
                {
                    Newtonsoft.Json.Linq.JObject json = Newtonsoft.Json.Linq.JObject.Parse(htmlResponse);

                    if (!String.IsNullOrEmpty((string)json["err"]))
                    {
                        errDesc = (string)json["err"];
                    }
                    else
                    {
                        if ((string)json["cr_allowed"] == "true")
                        {
                            globalSettings.credit_req_is_allowed = true;
                        }
                        globalSettings.credit_req_data = (string)json["cr_data"];
                    }
                }

            }
            catch (Exception e)
            {
                errDesc = e.Message;
            }

            return errDesc;
        }


        public static String getCreditRequest(double request_amount)
        {

            string errDesc = "";
            string htmlResponse = "";
            try
            {

                Web WebResponse = new Web(45000);
                htmlResponse = WebResponse.GetURL("/terminal/financial/credit-request?amt=" + request_amount.ToString());
                WebResponse = null;

                if (htmlResponse != "")
                {
                    Newtonsoft.Json.Linq.JObject json = Newtonsoft.Json.Linq.JObject.Parse(htmlResponse);

                    if (!String.IsNullOrEmpty((string)json["err"]))
                    {
                        errDesc = (string)json["err"];
                    }
                    else
                    {
                        if ((string)json["cr_allowed"] == "true")
                        {
                            globalSettings.credit_req_is_allowed = true;
                        }
                        if ((string)json["cr_high"] == "true")
                        {
                            globalSettings.credit_req_high = true;
                        }

                        globalSettings.credit_req_otp = (string)json["cr_otp"];
                        globalSettings.credit_req_data = (string)json["cr_data"];

                    }
                }

            }
            catch (Exception e)
            {
                errDesc = e.Message;
            }

            return errDesc;
        }




        //PopulateSRGrid(string sdate, string stime, string edate, string etime, string service_provider_item_id)

        //grdSR.Rows.Clear();

        //string URI = "http://" + globalSettings.svr_ip + ":" + globalSettings.svr_port +"/idt700_api/reprint/sales?";
        //        URI = URI + "lic=" + globalSettings.license_code;
        //        URI = URI + "&sdtm=" + sdate;
        //        URI = URI + "&st=" + stime;
        //        URI = URI + "&edtm=" + edate;
        //        URI = URI + "&et=" + etime;
        //        URI = URI + "&spi=" + service_provider_item_id;


        public static String getLastSalesSearch(string sdate, string stime, string edate, string etime, string service_provider_item_id)
        {

            string htmlResponse = "";
            string ret = "";

            String isAdmin = "&q=0";
            if (globalSettings.pos_user_admin || globalSettings.gen_cashier_ownsales == "0")
            {
                isAdmin = "&q=1";
            }

            try
            {

                Web WebResponse = new Web(45000);
                htmlResponse = WebResponse.GetURL("/terminal/customer/get-sales-search?p1=" + sdate + "&p2=" + stime + "&p3=" + edate + "&p4=" + etime + "&spi=" + service_provider_item_id + isAdmin);
                WebResponse = null;

                ret = htmlResponse;

            }
            catch
            {
                ret = "<err>Could not retrieve last sales.</err>";
            }

            return ret;

        }


        public static String deleteAutomatedZ(String automated_z_id)
        {

            string htmlResponse = "";
            string errDesc = "";

            try
            {

                Web WebResponse = new Web(45000);
                htmlResponse = WebResponse.GetURL("/terminal/cashup/z-report-auto-delete?zid=" + automated_z_id);
                WebResponse = null;

                if (htmlResponse.IndexOf("<err>") == -1)
                {
                    // Delete OK
                }
                else
                {
                    errDesc = htmlResponse.GetStrBetweenTags("<err>", "</err>");
                }
            }
            catch
            {
                errDesc = "Could not remove Automated Z report.";
            }

            return errDesc;

        }

        public static String addAutomatedZ(String automated_z_time)
        {

            string htmlResponse = "";
            string errDesc = "";

            try
            {

                Web WebResponse = new Web(45000);
                htmlResponse = WebResponse.GetURL("/terminal/cashup/z-report-auto-add?t=" + automated_z_time);
                WebResponse = null;

                if (htmlResponse.IndexOf("<err>") == -1)
                {
                    // Delete OK
                }
                else
                {
                    errDesc = htmlResponse.GetStrBetweenTags("<err>", "</err>");
                }
            }
            catch
            {
                errDesc = "Could not add Automated Z report.";
            }

            return errDesc;

        }



        public static String sendOTP(string sCell, string pc_serial)
        {

            string htmlResponse = "";
            string ret = "";

            try
            {

                Web WebResponse = new Web(45000, 2, "");
                htmlResponse = WebResponse.GetURL("/terminal/general/otp-send?user_cell=" + sCell + "&pc_serial=" + pc_serial);
                WebResponse = null;

                ret = htmlResponse;

            }
            catch
            {
                ret = "<err>Could not send OTP.</err>";
            }

            return ret;

        }



        public static String checkOTP(string sOTP, string pc_serial)
        {

            string htmlResponse = "";
            string ret = "";

            try
            {

                Web WebResponse = new Web(45000, 2, "");
                htmlResponse = WebResponse.GetURL("/terminal/general/otp-check?otp=" + sOTP + "&pc_serial=" + pc_serial);
                WebResponse = null;

                ret = htmlResponse;

            }
            catch
            {
                ret = "<err>Could not retrieve OTP status.</err>";
            }

            return ret;

        }


        public static String registerDevice(string asset_id)
        {

            string htmlResponse = "";
            string ret = "";

            try
            {

                Web WebResponse = new Web(45000, 2, "");
                htmlResponse = WebResponse.GetURL("/terminal/general/device-register?aid=" + asset_id + "&imei=" + globalSettings.device_imei);
                WebResponse = null;

                ret = htmlResponse;

            }
            catch
            {
                ret = "<err>Could not register device!</err>";
            }

            return ret;

        }




        public static String setTrackPrint()
        {

            string htmlResponse = "";
            string ret = "";

            string  param  = "track_print_paper_out=" + globalSettings.track_print_paper_out.ToString();
                    param += "&track_print_offline_windows=" + globalSettings.track_print_offline_windows.ToString();
                    param += "&track_print_offline=" + globalSettings.track_print_offline.ToString();

            try
            {

                Web WebResponse = new Web(15000, 1, "");
                htmlResponse = WebResponse.GetURL("/terminal/general/track-print?" + param);
                WebResponse = null;

                //ret = htmlResponse;

            }
            catch
            {
                //ret = "<err>Could not register device!</err>";
            }

            return ret;

        }



        
       

    }
    
}

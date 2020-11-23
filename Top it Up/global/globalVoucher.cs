using System;
using System.Collections.Generic;

namespace TopitUp
{
    static class globalVoucher
    {

        public static string stock_uid = "";

        public static int request_qty = 1;
        public static int request_qty_current = 0;

        public static int response_status = 0;
        //public static bool response_retry = false;
        public static int response_retry_count = 0;

        public static string pin_number_encryped = "";
        public static string pin_number = "";
        public static string serial_number = "";
        public static string tx_date = "";
        public static string sale_count = "";
        public static Decimal voucher_value = 0;

        public static int service_provider_id = 0;
        public static int service_provider_item_id = 0;

        public static bool is_reprint = false;
        public static string reprint_count = "";
        public static string reprint_dtm = "";

        public static int voucher_prov_arr_id = 0;
        public static int voucher_item_arr_id = 0;

        /* voucher stats */
        public static string stats_air_busy = "";
        public static int stats_air_request = 0;
        public static int stats_air_print = 0;
        public static int stats_air_lastprinted = 0;
        
        public static string stats_ele_busy = "";
        public static int stats_ele_request = 0;
        //public static int stats_ele_print = 0;
        public static int stats_ele_lastprinted = 0;
        


        /* use for tracking */

        public static int request_id = 0;
        public static int request_id_problem = 0;

        public static string last_voucher = "";
        public static string last_value = "";
        public static string last_cashier = "";
        public static string last_dtm = "";
        public static string last_dtm_date = "";
        public static string last_dtm_time = "";

        public static bool lastSaleDetailAvailable = false;

        //public static int lastSaleCounter = 0;


        public static void clearLastSaleDetail()
        {
            lastSaleDetailAvailable = false;
            last_voucher = "";
            last_value = "";
            last_cashier = "";
            last_dtm = "";
            last_dtm_date = "";
            last_dtm_time = "";
        }


        public static void setLastSaleDetail(String _last_voucher, String _last_value, String _last_cashier, String _last_dtm, String _last_dtm_date, String _last_dtm_time)
        {
            
            //lastSaleCounter++;

            lastSaleDetailAvailable = true;
            last_voucher = _last_voucher;
            last_value = _last_value;
            last_cashier = _last_cashier;
            last_dtm = _last_dtm;
            last_dtm_date = _last_dtm_date;
            last_dtm_time = _last_dtm_time;
        }


        static globalVoucher()
        {

            try
            {
                if (System.IO.File.Exists(globalSettings.app_path + @"\conf\request.dat"))
                {

                    System.IO.StreamReader myFile = new System.IO.StreamReader(globalSettings.app_path + @"\conf\request.dat");

                    string line;
                    while ((line = myFile.ReadLine()) != null)
                    {

                        if (line.IndexOf("request_id:") >= 0)
                        {
                            request_id = Int32.Parse(line.Replace("request_id:", "").Trim());
                        }

                        if (line.IndexOf("request_id_problem:") >= 0)
                        {
                            request_id_problem = Int32.Parse(line.Replace("request_id_problem:", "").Trim());
                        }

            //            if (line.IndexOf("stats_air_request:") >= 0)
            //            {
            //                stats_air_request = Int32.Parse(line.Replace("stats_air_request:", "").Trim());
            //            }
                        if (line.IndexOf("stats_air_print:") >= 0)
                        {
                            stats_air_print = Int32.Parse(line.Replace("stats_air_print:", "").Trim());
                        }
            //            if (line.IndexOf("stats_air_lastprinted:") >= 0)
            //            {
            //                stats_air_lastprinted = line.Replace("stats_air_lastprinted:", "").Trim();
            //            }

            //            if (line.IndexOf("stats_ele_busy:") >= 0)
            //            {
            //                stats_ele_busy = line.Replace("stats_ele_busy:", "").Trim();
            //            }
            //            if (line.IndexOf("stats_ele_request:") >= 0)
            //            {
            //                stats_ele_request = Int32.Parse(line.Replace("stats_ele_request:", "").Trim());
            //            }
            //            if (line.IndexOf("stats_ele_print:") >= 0)
            //            {
            //                stats_ele_print = Int32.Parse(line.Replace("stats_ele_print:", "").Trim());
            //            }
            //            if (line.IndexOf("stats_ele_lastprinted:") >= 0)
            //            {
            //                stats_ele_lastprinted = line.Replace("stats_ele_lastprinted:", "").Trim();
            //            }

                    }
                    myFile.Close();

                }

            }
            catch (Exception ex)
            {
                try
                {
                    System.IO.TextWriter tw = new System.IO.StreamWriter(globalSettings.app_path + @"\stats.error", true);
                    tw.Write(Environment.NewLine + DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongDateString() + ": error reading stats file: " + ex.Message + Environment.NewLine);
                    tw.Close();
                }
                catch { }
            }
        }


        //public static void voucherStatsReset()
        //{
        //    stats_air_busy = "";
        //    stats_air_request = 0;
        //    stats_air_print = 0;
        //    stats_ele_busy = "";
        //    stats_ele_request = 0;
        //    stats_ele_print = 0;

        //    voucherStatsSave();

        //}

        private static bool voucherStatsSave()
        {
            bool ret = false;

            string outStr = "";
            try
            {

                outStr += "request_id:" + request_id.ToString() + Environment.NewLine;

                outStr += "stats_air_print:" + stats_air_print.ToString() + Environment.NewLine;

                

                outStr += "request_id_problem:" + request_id_problem.ToString() + Environment.NewLine;
                


                System.IO.TextWriter tw = new System.IO.StreamWriter(globalSettings.app_path + @"\conf\request.dat", false);
                tw.Write(outStr);
                tw.Close();

                ret = true;

            }
            catch (Exception ex)
            {
                try
                {
                    System.IO.TextWriter tw = new System.IO.StreamWriter(globalSettings.app_path + @"\request.error", true);
                    tw.Write(Environment.NewLine + DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongDateString() + ": error reading request file: " + ex.Message + Environment.NewLine);
                    tw.Close();
                }
                catch { }
                
                ret = false;

           }

          return ret;
        }


        
        //private static string RandomString(int size)
        //{

        //    Random random = new Random((int)DateTime.Now.Ticks);

        //    System.Text.StringBuilder builder = new System.Text.StringBuilder();
        //    char ch;
        //    for (int i = 0; i < size; i++)
        //    {
        //        ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
        //        builder.Append(ch);
        //    }

        //    return builder.ToString();
        //}

        private static String getUniqueID()
        {

            Random rnd = new Random();
            return DateTime.Now.ToString("yyMMddHHmmss") + rnd.Next(1000, 10000).ToString();
            //return DateTime.Now.ToString("yyMMddHHmmss") + PadLeft(10, Int32.TryParse(12));
            
        }


        public static bool voucherStatsNewRequest()
        {

            //request_id++;

            //request_id = getUniqueID();

            //if (voucherType == 1)
            //{
                  stats_air_busy = getUniqueID();
            //    stats_air_request += 1;
            //}
            //else 
            //{
            //    stats_ele_busy = getUniqueID();
            //    stats_ele_request += 1;
            //}

            return voucherStatsSave();

        }

        //public static bool voucherStatsRequestError(int voucherType)
        //{

        //    if (voucherType == 1)
        //    {
        //        stats_air_busy = "";
        //    }
        //    else
        //    {
        //        stats_ele_busy = "";
        //    }

        //    return voucherStatsSave();

        //}

        //public static bool voucherStatsRequestFailed(int voucherType)
        //{

        //    if (voucherType == 1)
        //    {
        //        stats_air_busy = "";
        //        stats_air_request -= 1;
        //    }
        //    else
        //    {
        //        stats_ele_busy = "";
        //        stats_ele_request -= 1;
        //    }

        //    return voucherStatsSave();

        //}

        public static void voucherStatsRequestProblem()
        {

            request_id_problem = request_id;

            voucherStatsSave();

        }


        public static void voucherStatsRequestOK()
        {

            request_id_problem = 0;

            voucherStatsSave();

        }
        


        public static void Clear()
        {
            is_reprint = false;
            stock_uid = "";
            pin_number_encryped = "";
            pin_number = "";
            serial_number = "";
            tx_date = "";
            voucher_value = 0;
            sale_count = "";
            service_provider_id = 0;
            service_provider_item_id = 0;
            reprint_count = "";
            reprint_dtm = "";
            voucher_prov_arr_id = 0;
            voucher_item_arr_id = 0;

            response_status = 0;
            //response_retry = false;
            response_retry_count = 0;

            request_qty = 1;
            request_qty_current = 0;

        }

        public static void getArrayId()
        {
            voucher_prov_arr_id = 0;
            voucher_item_arr_id = 0;

            int stock_provider_counter = -1;

            try
            {

                foreach (stockProvider sp in Util.stock_provider)
                {
                    stock_provider_counter++;
                    if (sp.provider_id == service_provider_id)
                    {

                        for (int x = 0; x < Util.stock_provider[stock_provider_counter].itemcount; x++)
                        {
                            if (Util.stock_provider[stock_provider_counter].item[x].item_id == service_provider_item_id)
                            {
                                voucher_prov_arr_id = stock_provider_counter;
                                voucher_item_arr_id = x;
                                break;
                            }
                        }
                    }

                }

            }
            catch
            {
                //
            }
            

        }


        public static void refreshLastSale()
        {
            if (globalSettings.gen_show_last_sale_login == "1")
            {
                try
                {

                    tx_date = tx_date.Replace("  ", " ");

                    String _date_dtm = tx_date.Split(' ')[0];
                    String _date_time = tx_date.Split(' ')[1];

                    setLastSaleDetail(Util.stock_provider[voucher_prov_arr_id].item[voucher_item_arr_id].item_desc,
                        "R " + Util.stock_provider[voucher_prov_arr_id].item[voucher_item_arr_id].item_value, 
                        globalSettings.pos_user_firstname, "", _date_dtm, _date_time);
                }
                catch
                {
                    clearLastSaleDetail();
                }
            }
        }


    }
}

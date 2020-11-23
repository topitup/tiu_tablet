using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopitUp
{
    static class finBalance
    {

        public static bool is_balance_available = false;

        public static string balance = "0.00";
        public static string balance_cash = "0.00";
        public static string available_balance = "0.00";
        public static string credit_limit = "0.00";
        public static string credit_extended = "0.00";
        public static string low_balance = "0";
        public static string cash_customer = "0";

        public static string dtmd = "01/01/2015";
        public static string dtmt = "12:00:00";

        public static string w1_desc = "";
        public static string w2_desc = "";

        public static string acn1 = "";
        public static string acn2 = "";

        public static string enable_remote_ext_credit = "0";

        public static string allow_transfer_cash = "0";
        public static string allow_transfer_interstore = "0";

        private static void clearData()
        {

            balance = "0.00";
            balance_cash = "0.00";
            available_balance = "0.00";
            credit_limit = "0.00";
            credit_extended = "0.00";
            low_balance = "0";
            cash_customer = "0";

            dtmd = "01/01/2015";
            dtmt = "12:00:00";

            w1_desc = "";
            w2_desc = "";

            acn1 = "";
            acn2 = "";

        }


        public static void updateFromAvailable(String newAvailableBalance)
        {

            try
            {
                    
                Decimal _balance = Decimal.Parse(balance, System.Globalization.CultureInfo.InvariantCulture);
                Decimal _availableBalance = Decimal.Parse(available_balance, System.Globalization.CultureInfo.InvariantCulture);
                Decimal _availableBalanceNew = Decimal.Parse(newAvailableBalance, System.Globalization.CultureInfo.InvariantCulture);

                balance = (_balance - (_availableBalance - _availableBalanceNew)).ToString("#,##0.00");

                //balance = String.Format("{0:n2}" , (_balance - (_availableBalance - _availableBalanceNew)));

                available_balance = Convert.ToDecimal(newAvailableBalance).ToString("#,##0.00");

            }
            catch
            {
                //
            }


        }
        
        public static void populateBalanceFromJson(Newtonsoft.Json.Linq.JObject json)
        {

            try
            {
                if (!String.IsNullOrEmpty((string)json["balance"])) balance = (string)json["balance"];
                if (!String.IsNullOrEmpty((string)json["balance_cash"])) balance_cash = (string)json["balance_cash"];
                if (!String.IsNullOrEmpty((string)json["available_balance"])) available_balance = (string)json["available_balance"];
                if (!String.IsNullOrEmpty((string)json["credit_limit"])) credit_limit = (string)json["credit_limit"];
                if (!String.IsNullOrEmpty((string)json["credit_extended"])) credit_extended = (string)json["credit_extended"];
                if (!String.IsNullOrEmpty((string)json["cash_customer"])) cash_customer = (string)json["cash_customer"];
                if (!String.IsNullOrEmpty((string)json["low_balance"])) low_balance = (string)json["low_balance"];

                if (!String.IsNullOrEmpty((string)json["dtmd"])) dtmd = (string)json["dtmd"];
                if (!String.IsNullOrEmpty((string)json["dtmt"])) dtmt = (string)json["dtmt"];

                is_balance_available = true;

            }
            catch
            {
                //
            }

        }

        public static string getBalance(int detailLevel)
        {

            string htmlResponse = "";
            string ret = "";

            clearData();

            try
            {

                is_balance_available = false;

                Web WebResponse = new Web(25000, 1, "");
                htmlResponse = WebResponse.GetURL("/terminal/financial/get-balance?lvl=" + detailLevel.ToString());
                WebResponse = null;

                if (htmlResponse.IndexOf("err>", 0) >= 0)
                {
                    ret = htmlResponse.StripErrorTags();
                }
                else if (htmlResponse.Length > 0)
                {

                    Newtonsoft.Json.Linq.JObject json = Newtonsoft.Json.Linq.JObject.Parse(htmlResponse);

                    if (!String.IsNullOrEmpty((string)json["balance"])) balance = (string)json["balance"];
                    if (!String.IsNullOrEmpty((string)json["balance_cash"])) balance_cash = (string)json["balance_cash"];
                    if (!String.IsNullOrEmpty((string)json["available_balance"])) available_balance = (string)json["available_balance"];
                    if (!String.IsNullOrEmpty((string)json["credit_limit"])) credit_limit = (string)json["credit_limit"];
                    if (!String.IsNullOrEmpty((string)json["credit_extended"])) credit_extended = (string)json["credit_extended"];
                    if (!String.IsNullOrEmpty((string)json["low_balance"])) low_balance = (string)json["low_balance"];
                    if (!String.IsNullOrEmpty((string)json["cash_customer"])) cash_customer = (string)json["cash_customer"];

                    if (!String.IsNullOrEmpty((string)json["dtmd"])) dtmd = (string)json["dtmd"];
                    if (!String.IsNullOrEmpty((string)json["dtmt"])) dtmt = (string)json["dtmt"];

                    if (detailLevel == 1) {

                        if (!String.IsNullOrEmpty((string)json["acn1"])) acn1 = (string)json["acn1"];
                        if (!String.IsNullOrEmpty((string)json["acn2"])) acn2 = (string)json["acn2"];
                        
                        if (!String.IsNullOrEmpty((string)json["w1desc"])) w1_desc = (string)json["w1desc"];
                        if (!String.IsNullOrEmpty((string)json["w2desc"])) w2_desc = (string)json["w2desc"];

                        if (!String.IsNullOrEmpty((string)json["allow_transfer_cash"])) allow_transfer_cash = (string)json["allow_transfer_cash"];
                        if (!String.IsNullOrEmpty((string)json["allow_transfer_interstore"])) allow_transfer_interstore = (string)json["allow_transfer_interstore"];

                        if (!String.IsNullOrEmpty((string)json["enable_remote_ext_credit"])) enable_remote_ext_credit = (string)json["enable_remote_ext_credit"];

                    }

                    is_balance_available = true;

                }

            }
            catch (Exception ex)
            {
                ret = ex.Message;
            }

            return ret;

        }



    }
}


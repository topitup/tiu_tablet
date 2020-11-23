using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using System.Threading;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Management;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


namespace TopitUp
{
    static public class Util
    {

        public static Form _home_form;

        public static string system_uid = "0000000000000";
        public static string skype_path = "";

        static readonly string SaltKey = "S@LTY&KEYDOG";
        static readonly string VIKey = "@34gDF4563Fgbgf$^";

        public static int ConnectionStatus = 0;
        public static bool showUniPIN = false;

        public static string itemDisabledList = "";

        public static PopupWait frmPopupWait = null;
        private static bool popupwaitcreated = false;

        public static frmNoPrinter frmNoPrinter = null;
        private static bool popupprintercreated = false;

        private static LoadPOSDll PosPrint = new LoadPOSDll();
        private static libUsbContorl.UsbOperation NewUsb = new libUsbContorl.UsbOperation();



        [DllImport("user32")]
        public static extern void LockWorkStation();




        [StructLayout(LayoutKind.Sequential)]
        public class SystemTime
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMilliseconds;
        }

        [DllImport("CoreDLL.dll")]
        public static extern int RunAppAtTime(string application, SystemTime startTime);

        [DllImport("CoreDLL.dll")]
        public static extern int FileTimeToSystemTime(ref long lpFileTime, SystemTime lpSystemTime);

        [DllImport("CoreDLL.dll")]
        public static extern int FileTimeToLocalFileTime(ref long lpFileTime, ref long lpLocalFileTime);

        public static void RunAppAtTime(string applicationEvent, DateTime startTime)
        {
            long fileTimeUTC = startTime.ToFileTime();
            long fileTimeLocal = 0;
            SystemTime systemStartTime = new SystemTime();
            FileTimeToLocalFileTime(ref fileTimeUTC, ref fileTimeLocal);
            FileTimeToSystemTime(ref fileTimeLocal, systemStartTime);
            RunAppAtTime(applicationEvent, systemStartTime);

        }

        public static void RunAppAtTime(string applicationEvent, TimeSpan timeDisplacement)
        {
            DateTime targetTime = DateTime.Now + timeDisplacement;
            RunAppAtTime(applicationEvent, targetTime);
        }



        [System.Runtime.InteropServices.DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        public static List<stockProvider> stock_provider = new List<stockProvider>();

        public static List<string> pos_users = new List<string>();

        //string[] voucher_print_dtm_cashier = new string[4];
        public static string[] voucher_print_address = new string[] { "", "" };
        public static string[] voucher_print_footer = new string[] { "", "          Top it Up", "      www.itopitup.co.za", "" };
        public static string[] voucher_print_dtm_cashier = new string[] { "", "Date        Time Cashier", "", "" };
        public static string[] voucher_print_extra = new string[] { "", "", "", "", "" };

        //public static System.Drawing.Font fontDroidSans = new System.Drawing.Font("DroidSansMono", 10, System.Drawing.FontStyle.Regular);

        public static Bitmap btngeneral0;
        public static Bitmap btngeneral1;
        public static Bitmap btngeneral2;
        public static Bitmap btngeneral3;
        public static Bitmap btngeneral4;
        public static Bitmap btngeneral5;
        public static Bitmap btngeneralsearch;

        public static btnProductType[] btnProduct = new btnProductType[25];
        public static List<btnProductType> btnProductGroup = new List<btnProductType>();

        public static bool DoOpenCashDrawer = false;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        
        [DllImport("user32.dll")]
        public static extern bool LockWindowUpdate(IntPtr hWndLock);

        /*
        [DllImport("coredll.dll", CharSet = CharSet.Auto)]
        static extern bool EnableWindow(IntPtr hwnd, bool enabled);
        */

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnableWindow(IntPtr hWnd, bool bEnable);


        public static void EnableInput(Control control, bool enabled)
        {
            IntPtr controlPtr = (IntPtr)control.Handle.ToInt32();
            EnableWindow(controlPtr, enabled);
        }


        private const int WM_SETREDRAW = 11; 


        public static String netsh(String Arguments)
        {

            System.Diagnostics.Process p1 = new System.Diagnostics.Process();
            p1.StartInfo.FileName = "netsh.exe";
            p1.StartInfo.Arguments = Arguments;
            p1.StartInfo.UseShellExecute = false;
            p1.StartInfo.RedirectStandardOutput = true;
            p1.StartInfo.RedirectStandardError = true;
            p1.StartInfo.CreateNoWindow = true;
            p1.Start();

            String _process_data = p1.StandardOutput.ReadToEnd();

            return _process_data;

        }

        public static void SuspendDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
        }

        public static void ResumeDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
            parent.Refresh();
        }


        public static bool IsConnectedToInternet()
        {

            bool isConnected = false;

            // Removed for Firewall rules
            //int flags;
            //bool isConnected = InternetGetConnectedState(out flags, 0);
            //if (!isConnected) return false;

            try {
                isConnected = new System.Net.NetworkInformation.Ping().Send("8.8.8.8", 3000).Status == System.Net.NetworkInformation.IPStatus.Success;
            } catch (Exception ex)
            {
                //Console.Write(ex.Message);
                isConnected = false;
            }

//Console.Write(isConnected.ToString());

            //isConnected = TcpSocketTest();

            return isConnected;

            //try {
            //     System.Net.IPHostEntry objIPHE = System.Net.Dns.GetHostEntry(globalSettings.svr_hostname);
            //}
            //catch
            //{
            //    return false;
            //}

            //return true;
        }


        public static bool TcpSocketTest()
        {
            try
            {
                System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient("www.google.com", 80);
                client.Close();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }



        private static void SendData2USB(byte[] str)
        {
            NewUsb.SendData2USB(str, str.Length);
        }
        private static void SendData2USB(string str)
        {
            byte[] by_SendData = System.Text.Encoding.Default.GetBytes(str);
            SendData2USB(by_SendData);
        }






        private static bool _sync_screenshot_busy = false;
        public static async void syncScreenshots()
        {

            if (_sync_screenshot_busy) return;

            _sync_screenshot_busy = true;

            await Task.Run(() => syncScreenshotsRun());

            _sync_screenshot_busy = false;

        }

        private static void syncScreenshotsRun()
        {

            string[] filePaths = Directory.GetFiles(@"c:\topitup\screenshots\new", "*.png");

            foreach (String file in filePaths)
            {
                Util.showMessage(file, Color.Green);
            }


        }




        public static void showDesktop()
        {
            try
            {
                Shell32.Shell shell = new Shell32.Shell();
                shell.MinimizeAll();
            } 
            catch
            {
                //showMessage(ex.Message, Color.Red);
            }
        }

        public static void lockWorkstation()
        {
            try
            {
                LockWorkStation();
            }
            catch 
            {
                //showMessage(ex.Message, Color.Red);
            }
        }

        public static Color HexToColor(string hexColor)
        {
            int red = 0;
            int green = 0;
            int blue = 0;

            try
            {
                if (hexColor.Length == 6)
                {
                    //#RRGGBB


                    red = int.Parse(hexColor.Substring(0, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
                    green = int.Parse(hexColor.Substring(2, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
                    blue = int.Parse(hexColor.Substring(4, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
                }
                else if (hexColor.Length == 3)
                {
                    //#RGB
                    red = int.Parse(hexColor[0].ToString() + hexColor[0].ToString(), System.Globalization.NumberStyles.AllowHexSpecifier);
                    green = int.Parse(hexColor[1].ToString() + hexColor[1].ToString(), System.Globalization.NumberStyles.AllowHexSpecifier);
                    blue = int.Parse(hexColor[2].ToString() + hexColor[2].ToString(), System.Globalization.NumberStyles.AllowHexSpecifier);
                }
            }
            catch
            {
                //
            }


            return Color.FromArgb(red, green, blue);
        }

        public static void setDefaultPrinterName()
        {
            try
            {
                PrinterSettings settings = new PrinterSettings();
                globalSettings.printer_name = settings.PrinterName;
            }
            catch
            {
                //
            }
        }


        public static bool getDefaultPrinterStatus(bool track)
        {

            bool ret = true;

            try
            {
                ManagementScope scope = new ManagementScope(@"\root\cimv2");
                scope.Connect();

                ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_Printer");
                ManagementObjectCollection collection = searcher.Get();

                foreach (ManagementObject printer in collection)
                {
                    if (printer["Name"].ToString() == globalSettings.printer_name)
                    {
                        if (printer["WorkOffline"].ToString().ToLower().Equals("true"))
                        {
                            if (track)
                            { 
                                globalSettings.track_print_offline_windows++;
                                globalSettings.track_print_save();
                            }
                            ret = false;
                        }
                        else
                        {
                            ret = true;
                        }
                    }
                }
            }
            catch
            {
                //
            }

            return ret;

        }




        public static void printVoucherCopy(bool electricity)
        {


            String printStr = "";

            printStr += "3Merchant Copy\n";

            printStr += "1" + globalSettings.company_name30 + "\n";

            if (globalSettings.gen_print_address == "1")
            {
                printStr += "1" + voucher_print_address[0].ToString() + "\n";
                printStr += "1" + voucher_print_address[1].ToString() + "\n";
            }


            DateTime RequestDate = DateTime.Now;
            voucher_print_dtm_cashier[2] = RequestDate.ToString("dd/MM/yyyy") + "  " + RequestDate.ToString("HH:mm") + " " + globalSettings.pos_user_firstname;
            
            printStr += "1" + voucher_print_dtm_cashier[1] + "\n";
            printStr += "1" + voucher_print_dtm_cashier[2] + "\n";

            if (electricity)
            {
                 printStr += "1Electricity\n";
            }
            else
            {
                 printStr += "1" + Util.stock_provider[globalVoucher.voucher_prov_arr_id].item[globalVoucher.voucher_item_arr_id].item_desc + "\n";
            }

            printStr += "1Value: R " + globalVoucher.voucher_value.ToString() + "\n";


            if (globalVoucher.is_reprint)
            {
                printStr += "1Voucher Reprint # : " + globalVoucher.reprint_count + "\n";
            }
            else
            {
                if (electricity)
                {
                    printStr += "1Print# : 1" + "\n";
                }
                else
                {
                    printStr += "1Print# : 1    Count# : " + globalVoucher.sale_count + "\n";
                }
            }
            if (electricity)
            {
                printStr += "1Meter : " + globalVoucher.serial_number + "\n";
            }
            else
            {
                printStr += "1Serial : " + globalVoucher.serial_number + "\n";
            }

            printStr += "1Ref#   : " + globalVoucher.stock_uid + "\n";



            if (globalSettings.gen_prnt_b == "1")
            {
                string bcode = Util.stock_provider[globalVoucher.voucher_prov_arr_id].item[globalVoucher.voucher_item_arr_id].item_barcode;
                //    if (bcode.Length > 10)
                //    {
                //        Util.printEAN(bcode.Substring(0, 12));
                //    }

                printStr += "1" + "\n";
                printStr += "1Barcode:" + bcode + "\n";

            }

            printText(printStr, false);


        }




        public static void printVoucher()
        {


            String printStr = "";

            printStr += "1" + globalSettings.company_name30 + "\n";

            if (globalSettings.gen_print_address == "1")
            {
                printStr += "1" + voucher_print_address[0].ToString() + "\n";
                printStr += "1" + voucher_print_address[1].ToString() + "\n";
            }

            //DateTime RequestDate = DateTime.Now;
            //voucher_print_dtm_cashier[2] = RequestDate.ToString("dd/MM/yyyy") + "  " + RequestDate.ToString("HH:mm") + " " + globalSettings.pos_user_firstname;

            printStr += "1" + voucher_print_dtm_cashier[1] + "\n";

            if (globalVoucher.is_reprint)
            {
                voucher_print_dtm_cashier[2] = globalVoucher.reprint_dtm + " " + globalSettings.pos_user_firstname;
                printStr += "1" + voucher_print_dtm_cashier[2] + "\n";
            }
            else
            {
                voucher_print_dtm_cashier[2] = globalVoucher.tx_date + " " + globalSettings.pos_user_firstname;
                printStr += "1" + voucher_print_dtm_cashier[2] + "\n";
            }

            printStr += "1" + "\n";

            printStr += "2" + Util.str_wrap(Util.stock_provider[globalVoucher.voucher_prov_arr_id].item[globalVoucher.voucher_item_arr_id].item_desc, 16, true).Aggregate((aggregate, current) => aggregate + "\n2" + current) + "\n";

            printStr += "2" + Util.str_format_pin(globalVoucher.pin_number).Aggregate((aggregate, current) => aggregate + "\n2" + current) + "\n";

            printStr += "1\n";
            printStr += "1" + Util.stock_provider[globalVoucher.voucher_prov_arr_id].provider_print.Aggregate((aggregate, current) => aggregate + "\n1" + current) + "\n";
            
            //Console.WriteLine(printStr);

            if (globalVoucher.is_reprint)
            {
                printStr += "1" + "Voucher Reprint # : " + globalVoucher.reprint_count + "\n";
            }
            else
            {
                printStr += "1" + "Print#  : 1    Count# : " + globalVoucher.request_id + "\n";
                //printStr += "1" + "Print#  : 1" + Environment.NewLine;
            }

            printStr += "1" + "Serial  : " + globalVoucher.serial_number + "\n";
            printStr += "1" + "Ref#    : " + globalVoucher.stock_uid + "\n";
            if (globalVoucher.is_reprint)
            {
                printStr += "1" + "Print #1: " + globalVoucher.tx_date + "\n";    
            }


            printStr += "1" + voucher_print_footer.Aggregate((aggregate, current) => aggregate + "\n" + "1" + current) + "\n";

            if (globalSettings.do_print_extra)
            {

                if (voucher_print_extra[0].Length > 0) printStr += "1" + voucher_print_extra[0] + "\n";
                if (voucher_print_extra[1].Length > 0) printStr += "1" + voucher_print_extra[1] + "\n";
                if (voucher_print_extra[2].Length > 0) printStr += "1" + voucher_print_extra[2] + "\n";
                if (voucher_print_extra[3].Length > 0) printStr += "1" + voucher_print_extra[3] + "\n";
                if (voucher_print_extra[4].Length > 0) printStr += "1" + voucher_print_extra[4] + "\n";

            }

            if (globalSettings.gen_prnt_b == "1")
            {
                string bcode = Util.stock_provider[globalVoucher.voucher_prov_arr_id].item[globalVoucher.voucher_item_arr_id].item_barcode;
            //    if (bcode.Length > 10)
            //    {
            //        Util.printEAN(bcode.Substring(0, 12));
            //    }

                printStr += "1" + "\n";
                printStr += "1Barcode:" + bcode  + "\n";

            }

            printText(printStr, false);

        }



        public static bool getTerminalStatusFromServer()
        {

            bool ret = false;
            string htmlResponse = "";

            try
            {

                string url_extra = "";
                string dtm = "";

                globalSettings.advert_id_latest = globalSettings.advert_id;
                globalSettings.notice_id_latest = globalSettings.notice_id;
                globalSettings.spi_ver_latest = globalSettings.spi_ver;

                url_extra = "?api=2";
                url_extra += "&swv=" + globalSettings.app_ver;
                url_extra += "&spi=" + globalSettings.spi_ver;

                finBalance.is_balance_available = false;

                Web WebResponse = new Web(25000, 1, "");
                htmlResponse = WebResponse.GetURL("/terminal/general/get-status-full" + url_extra);
                WebResponse = null;

                if (htmlResponse != "")
                {

                    if (htmlResponse.IndexOf("err>", 0) >= 0)
                    {
                        ret = false;
                    }
                    else
                    {

                        ret = true;

                        try
                        {
                            Newtonsoft.Json.Linq.JObject json = Newtonsoft.Json.Linq.JObject.Parse(htmlResponse);

                            finBalance.populateBalanceFromJson(json);

                            if (!String.IsNullOrEmpty((string)json["suid"])) globalSettings.bootup_electra = (string)json["suid"];

                            if (!String.IsNullOrEmpty((string)json["adid"])) { globalSettings.advert_id_latest = (string)json["adid"]; } else { globalSettings.advert_id_latest = globalSettings.advert_id; }
                            if (!String.IsNullOrEmpty((string)json["noticeid"])) { globalSettings.notice_id_latest = (string)json["noticeid"]; } else { globalSettings.notice_id_latest = globalSettings.notice_id; }
                            if (!String.IsNullOrEmpty((string)json["spiver"])) { globalSettings.spi_ver_latest = (string)json["spiver"]; } else { globalSettings.spi_ver_latest = globalSettings.spi_ver; }

                            dtm = "11/11/2011 11:11:11";
                            if (!String.IsNullOrEmpty((string)json["dtmd"])) dtm = (string)json["dtmd"] + " " + (string)json["dtmt"];

                            if (!String.IsNullOrEmpty((string)json["tiucontact"])) globalSettings.gen_tiu_contact = (string)json["tiucontact"];

                        }
                        catch (Exception ex)
                        {
                            showMessage(ex.Message, Color.Red);
                            ret = false;
                        }

                    }
                }

                return ret;

            }
            catch
            {
                //LocalMessages = ex.Message + Environment.NewLine + LocalMessages;
                return ret;
            }

        }




        public static void printBillPaymentSlip(string strElecSlip)
        {

            if (globalSettings.gen_prnt_bb == "1")
            {
                string barcode = "6001111111122";
                strElecSlip += "1" + Environment.NewLine;
                strElecSlip += "1Barcode:" + barcode + Environment.NewLine;
            }

            printText(strElecSlip, false);

        }

        public static bool printElectricitySlip(string strElecSlip)
        {

            if (globalSettings.gen_prnt_be == "1")
            {
                string barcode = "6001111111115";
                strElecSlip += "1" + Environment.NewLine;
                strElecSlip += "1Barcode:" + barcode + Environment.NewLine;
            }

            return printText(strElecSlip, false);

        }


        public static string[] str_wrap(string wrapText, int wrapLength, bool center)
        {
            string[] words = wrapText.Split(' ');

            StringBuilder newSentence = new StringBuilder();

            string line = "";
            foreach (string word in words)
            {
                if ((line + word).Length > wrapLength)
                {

                    if (center)
                    {
                        line = line.Trim();
                        int amountToPad = wrapLength - line.Length;
                        if (amountToPad > 0) amountToPad = amountToPad / 2;
                        line = line.PadLeft(line.Length + amountToPad, ' ');
                    }

                    //newSentence.AppendLine(line,'\n');
                    newSentence.Append(line);
                    newSentence.Append("\n");
                    line = "";
                }

                line += word + " ";
            }

            if (line.Length > 0)
            {
                if (center)
                {
                    line = line.Trim();
                    int amountToPad = wrapLength - line.Length;
                    if (amountToPad > 0) amountToPad = amountToPad / 2;
                    line = line.PadLeft(line.Length + amountToPad, ' ');
                    //newSentence.AppendLine(line, "\n");
                    newSentence.Append(line);
                    newSentence.Append("\n");
                }
                else
                {
                    newSentence.Append(line.Trim());
                    newSentence.Append("\n");
                }
            }

            return newSentence.ToString().Split('\n');

        }


        public static string[] str_format_pin(string wrapPin)
        {

            string[] PrintString;

            if (wrapPin.Length == 17)
                PrintString = str_break(wrapPin, 9);
            else
                PrintString = str_break(wrapPin, 8);

            for (int j = 0; j < PrintString.Length; j++)
            {
                if (PrintString[j].Length == 9)
                    PrintString[j] = "  " + PrintString[j].Insert(6, " ").Insert(3, " ");
                else if (PrintString[j].Length > 5)
                    PrintString[j] = "   " + PrintString[j].Insert(4, " ");
                else
                    PrintString[j] = "      " + PrintString[j];
            }

            return PrintString;

        }

        public static string[] str_break(string wrapText, int length)
        {
            string[] ret = new string[(wrapText.Length + length - 1) / length];

            for (int i = 0; i < ret.Length - 1; i++)
            {
                ret[i] = wrapText.Substring(i * length, length);
            }
            ret[ret.Length - 1] = wrapText.Substring((ret.Length - 1) * length);
            return ret;
        }


        public static string str_decrypt_pin(string pin)
        {
            string ret = "";

            try
            {

                clsCrypt decrypt = new clsCrypt();
                ret = decrypt.decryptVoucher(pin);
                decrypt = null;

                ret = ret.Replace("\0", "");

                if (globalSettings.svr_id == "dmo")
                {
                    ret = "DEMO" + ret.Substring(4, ret.Length - 4);
                }

            }
            catch
            {
                return "error with pin";
            }

            return ret;
        }


        public static string encrypt_blowfish(string str_in, string password)
        {
            string ret = "";

            try
            {
                clsCrypt encrypt = new clsCrypt();
                ret = encrypt.encryptString(str_in, password);
                encrypt = null;
            }
            catch
            {
                ret = "ERROR";
            }

            return ret;
        }


        public static string str_proper_case(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            return char.ToUpper(s[0]) + s.Substring(1);
        }

        public static string str_camel_case(string stringInput)
        {
            if (string.IsNullOrEmpty(stringInput))
            {
                return string.Empty;
            }

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            bool fEmptyBefore = true;
            foreach (char ch in stringInput)
            {
                char chThis = ch;
                if (Char.IsWhiteSpace(chThis))
                    fEmptyBefore = true;
                else
                {
                    if (Char.IsLetter(chThis) && fEmptyBefore)
                        chThis = Char.ToUpper(chThis);
                    else
                        chThis = Char.ToLower(chThis);
                    fEmptyBefore = false;
                }
                sb.Append(chThis);
            }
            return sb.ToString();
        }


        public static string RemoveFirstLine(string s)
        {
            return s.Substring(s.IndexOf("\n") + 1);
        }

        public static string toHexString(string s)
        {
            String ret = "";
            
            foreach (char c in s)
            {
              ret += String.Format(@"\x{0:x2}", (ushort)c);
            }

            return ret;
        }


        //private static String _print_text = "";
        //private static bool _do_print_text = false;
        //public static void popupPrint(Form _parent)
        //{
        //    if (!_do_print_text) return;
        //    frmPrint frmPrint = new frmPrint();
        //    frmPrint.toPrint = _print_text;
        //    frmPrint.ShowDialog(_parent);
        //}



        private static byte[] InitialisePrinter = { 0x1b, 0x40 };
        private static byte[] FontNormal = { 0x1b, 0x21, 0x00 };
        //private static byte[] FontLarge = { 0x1b, 0x21, 0x31 };

        private static byte[] font_w = { 0x1B, 0x21, 0x16 };
        private static byte[] font_h = { 0x1B, 0x21, 0x32 };

        private static byte[] enddata = { 0x0a };

        private static byte[] setBarcode = { 0x1d, 0x6b, 0x02 };
        private static byte[] setBarcode_CharOn = { 0x1d, 0x48, 0x02 };  // Numbers at bottom
        private static byte[] setBarcodeSizeH = { 0x1d, 0x68, 0x60 };   // Height
        private static byte[] setBarcodeSizeW = { 0x1d, 0x77, 0x03 };   // Width

        private static void do_usb_print(string toPrint)
        {


            //Console.WriteLine(toPrint);
            

            NewUsb.FindUSBPrinter();

            for (int i = 0; i < NewUsb.USBPortCount; i++)
            {
                if (NewUsb.LinkUSB(i))
                {

                    SendData2USB(InitialisePrinter);

                    if (Util.DoOpenCashDrawer)
                    {
                        Util.DoOpenCashDrawer = false;
                        SendData2USB(new byte[] { 0x1b, 0x70, 0x00, 0x19, 0xff});
                    }

                    SendData2USB(FontNormal);

                    int printSize = 0;
                    string[] toPrintX = new string[1];
                    try
                    {
                        if (toPrint != "")
                        {

                            string[] toPrintArr = toPrint.Split("\n".ToCharArray());

                            foreach (string s in toPrintArr)
                            {

                                if (s.Trim().Length > 1)
                                {

                                    printSize = 1;
                                    try
                                    {
                                        printSize = int.Parse(s[0].ToString());
                                    }
                                    catch { }
                                    toPrintX[0] = s.Remove(0, 1);

                                    if (toPrintX[0].ToString().Left(8) == "Barcode:")
                                    {
                                        String barprint = toPrintX[0].ToString().Replace("Barcode:", "");
                                        //barprint = barprint.ToString().Replace("\n", "");
                                        barprint = barprint.ToString().Replace(Environment.NewLine, "");
                                        barprint = barprint.ToString().Replace("\r", "");

                                        SendData2USB(setBarcode_CharOn);
                                        SendData2USB(setBarcodeSizeH);
                                        SendData2USB(setBarcodeSizeW);
                                        SendData2USB(setBarcode);
                                        SendData2USB(barprint);
                                        SendData2USB(enddata);
                                        //SendData2USB(enddata);

                                    }
                                    else
                                    {
                                        if (printSize > 1)
                                        {
                                            //SendData2USB(FontLarge);
                                            SendData2USB(font_w);
                                            SendData2USB(font_h);
                                            SendData2USB(toPrintX[0].ToString());
                                            SendData2USB(FontNormal);
                                            SendData2USB(enddata);
                                        }
                                        else
                                        {
                                            SendData2USB(toPrintX[0].ToString());
                                            SendData2USB(enddata);
                                        }
                                    }

                                }
                                else
                                {
                                    SendData2USB(enddata);
                                }

                            }
                        }
                    }
                    catch
                    {
                        //
                    }

                    SendData2USB(enddata);
                    SendData2USB(enddata);

                    NewUsb.CloseUSBPort();

                }
            }

        }




        public static bool printText(string toPrint, bool forcePrint)
        {

            if (globalSettings.gen_show_voucher_only.Equals("1") && !forcePrint)
            {
                frmPrint frmPrint = new frmPrint();
                frmPrint.toPrint = toPrint;
                frmPrint.ShowDialog(_home_form);
                return true;
            }

            String printStr = ""; //Environment.NewLine;

            if (globalSettings.gen_slip_printer == "1")
            {

                if (isPrinterOffline())
                {
                    Util.showPrinterProblem(true, toPrint,false);
                    return false;
                }

                do_usb_print(toPrint);
                return true;

            }

            //if (globalSettings.gen_slip_printer == "1")
            //{
            //    printStr = "\x1b\x40";        //Initialize printer
            //    if (Util.DoOpenCashDrawer)
            //    {
            //        Util.DoOpenCashDrawer = false;
            //        printStr += "\x1b\x70\x00\x19\xff";
            //    }
            //    printStr += "\x1b\x21\x00";    //Print style normal
            //}


            int printSize = 0;
            string[] toPrintX = new string[1];
            try
            {
                if (toPrint != "")
                {
                   
                    string[] toPrintArr = toPrint.Split("\n".ToCharArray());

                    //WintecIDT700.FeedPaper(50);
                    foreach (string s in toPrintArr)
                    {

                        if (s.Trim().Length > 1)
                        {
                            printSize = 1;
                            try
                            {
                                printSize = int.Parse(s[0].ToString());
                            }
                            catch { }
                            toPrintX[0] = s.Remove(0, 1);

                            if (globalSettings.gen_slip_printer == "1")
                            {
                                if (toPrintX[0].ToString().Left(8) == "Barcode:")
                                {
                                    String barprint = toPrintX[0].ToString().Replace("Barcode:", "");
                                           barprint = barprint.ToString().Replace(Environment.NewLine, "");
                                           barprint = barprint.ToString().Replace("\r", "");
                                           //barprint = toHexString(barprint);

                                           printStr += "\x1D\x6b\x02";
                                           printStr += barprint;
                                           printStr += "\x00";

                                           //printStr += "\x1D\x6B\x02" + barprint  + "\x00\n";
                                           //printStr += "\x1D\x6B\x02" + barprint.Replace(@"\\", @"\") + "\x00\n";

                                }
                                else
                                {
                                    if (printSize > 1)
                                    {
                                        printStr += "\x1b\x21\x80" + toPrintX[0].ToString() + "\x1b\x21\x00" + Environment.NewLine;
                                    }
                                    else
                                    {
                                        printStr += toPrintX[0].ToString() + Environment.NewLine;
                                    }
                                }
                            }
                            else
                            {
                                printStr += toPrintX[0].ToString() + Environment.NewLine;
                            }

                        }
                        else
                        {
                            printStr += "" + Environment.NewLine;
                        }
                    }
                }
            }
            catch
            {
                //
            }


            //if (globalSettings.gen_slip_printer == "1")
            //{
            //    printStr += "\x0a";
            //    RawPrinterHelper.SendStringToPrinter(globalSettings.printer_name, printStr);
            //}
            //else
            //{
                try
                {
                    PCPrint printer = new PCPrint();
                    Margins margins = new Margins(0, 0, 0, 0);
                    printer.DefaultPageSettings.Margins = margins;
                    printer.TextToPrint = printStr;
                    printer.Print();
                }
                catch (Exception ex)
                {
                    showMessage(ex.Message, Color.Red);
                }
           //}

                return true;

        }



        public static void loadDisabledItems(String fileName)
        {

            if (!File.Exists(globalSettings.app_path + @"\conf\provider_item_" + fileName + ".dis")) return;

            string itemDisabledList = "";

            try
            {

                JObject jsonObj = new JObject();

                using (StreamReader file = File.OpenText(globalSettings.app_path + @"\conf\provider_item_" + fileName + ".dis"))
                using (Newtonsoft.Json.JsonTextReader reader = new Newtonsoft.Json.JsonTextReader(file))
                {
                    jsonObj = (JObject)JToken.ReadFrom(reader);
                }

                itemDisabledList = jsonObj.ToString();

                int voucher_prov_arr_id = -1;
                foreach (stockProvider sp in Util.stock_provider)
                {
                    voucher_prov_arr_id++;
                    for (int x = 0; x < Util.stock_provider[voucher_prov_arr_id].itemcount; x++)
                    {
                        if (itemDisabledList.IndexOf("\"" + Util.stock_provider[voucher_prov_arr_id].item[x].item_id.ToString() + "\"") != -1)
                        {
                            if (fileName.Equals("admin"))
                            {
                                stock_provider[voucher_prov_arr_id].item[x].visible_admin = false;
                            }
                            else
                            {
                                stock_provider[voucher_prov_arr_id].item[x].visible_cashier = false;
                            }
                        }
                        else
                        {
                            if (fileName.Equals("admin"))
                            {
                                stock_provider[voucher_prov_arr_id].item[x].visible_admin = true;
                            }
                            else
                            {
                                stock_provider[voucher_prov_arr_id].item[x].visible_cashier = true;
                            }
                        }
                    }
                }


            }
            catch
            {
                //showMessage(ex.Message, true);
            }

        }


        public static void WriteAllBytes(string path, byte[] data)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fs.Write(data, 0, data.Length);
            }
        }


        public static bool doReprintLogic()
        {

            if (globalVoucher.service_provider_item_id == 51)
            {

                Web WebResponse = new Web(60000);
                String htmlResponse = "";
                htmlResponse = WebResponse.GetURL("/itron/electricity/vendGetReprint?lic=" + globalSettings.license_code + "&uid=" + globalVoucher.stock_uid + "&s=1&d=false");
                WebResponse = null;
                if (htmlResponse.IndexOf("err>") > -1)
                {
                    showMessage(htmlResponse.StripErrorTags(), Color.Red);
                }
                else
                {
                    printElectricitySlip(Util.RemoveFirstLine(htmlResponse));
                }

            }
            else if (globalVoucher.service_provider_item_id == 107)
            {

                Web WebResponse = new Web(60000);
                String htmlResponse = WebResponse.GetURL("/payaccount/payment/reprint?q=" + globalVoucher.stock_uid);
                WebResponse = null;

                if (htmlResponse.IndexOf("err>") > -1)
                {
                    showMessage(htmlResponse.StripErrorTags(), Color.Red);
                }
                else
                {

                    try
                    {

                        Newtonsoft.Json.Linq.JObject json = Newtonsoft.Json.Linq.JObject.Parse(htmlResponse);

                        finBalance.populateBalanceFromJson(json);

                        string print_data = "";
                        if (!String.IsNullOrEmpty((string)json["print_data"]))
                        {
                            byte[] data = Convert.FromBase64String((string)json["print_data"]);
                            print_data = System.Text.Encoding.UTF8.GetString(data, 0, data.Length);
                        }

                        printBillPaymentSlip(print_data);
                        //printText(,false);

                    }
                    catch (Exception ex)
                    {
                        showMessage(ex.Message, Color.Red);
                    }

                }

            }
            else
            {
                globalVoucher.pin_number = Util.str_decrypt_pin(globalVoucher.pin_number_encryped);
                globalVoucher.getArrayId();
                Util.printVoucher();
            }

            return true;

        }


        //public static bool setSoftwareVersion()
        //{

        //    bool ret = false;
        //    string htmlResponse = "";

        //    try
        //    {

        //        Web WebResponse = new Web(10000, 1);
        //        htmlResponse = WebResponse.GetURL("/terminal/general/set-software-version?v=" + globalSettings.app_ver);
        //        WebResponse = null;

        //        if (htmlResponse != "")
        //        {
        //            if (htmlResponse.IndexOf("<webreqerr>", 0) >= 0)
        //            {
        //                ret = false;
        //            }
        //            else if (htmlResponse.IndexOf("<err>", 0) >= 0)
        //            {
        //                ret = false;
        //            }
        //            else
        //            {
        //                ret = true;
        //            }
        //        }

        //        return ret;

        //    }
        //    catch
        //    {
        //        return ret;
        //    }

        //}




        public static bool getSoftwareUpdate()
        {
            bool updateAvailable = false;
            try
            {

                String htmlResponse = "";

                try
                {
                    Web WebResponse = new Web(10000, 1, "");
                    htmlResponse = WebResponse.GetURL("/terminal/general/get-software-update-available?q=" + globalSettings.app_ver);
                    WebResponse = null;

                    if (htmlResponse != "")
                    {
                        if (htmlResponse.IndexOf("err>", 0) >= 0)
                        {
                            //
                        }
                        else if (htmlResponse.Length < 50)
                        {
                            string[] stritems = htmlResponse.Split('^');
                            globalSettings.app_update_ver = stritems[0];
                            globalSettings.app_update_location = stritems[1];
                            updateAvailable = true;
                        }
                    }

                }
                catch
                {
                   // updateAvailable = false;
                }

            }
            catch
            {
                //updateAvailable = false;
            }

            return updateAvailable;
        }


        //public static void getStockProviderUpdate(bool forceUpdate)
        //{
            
        //    String htmlResponse = "";

        //    try
        //    {

        //        Web WebResponse = new Web(15000, 3);

        //        if (forceUpdate)
        //        {
        //            htmlResponse = WebResponse.GetURL("/terminal/general/get-items-update-available?q=1001011212");
        //        }
        //        else
        //        {
        //            htmlResponse = WebResponse.GetURL("/terminal/general/get-items-update-available?q=" + globalSettings.gen_spi_ver);
        //        }
        //        WebResponse = null;

        //        if (htmlResponse != "")
        //        {
        //            if (htmlResponse.IndexOf("err>", 0) >= 0)
        //            {
        //                //
        //            }
        //            else if (htmlResponse.Length == 10)
        //            {
        //                if (webService.getItems())
        //                {
        //                    globalSettings.gen_spi_ver = htmlResponse;
        //                    globalSettings.SaveGeneral();
        //                    loadProviderItem();
        //                }
        //            }
        //        }

        //    }
        //    catch
        //    {
        //        //
        //    }

        //}




        public static bool getIPChange()
        {

            bool networkConn = false;
            try
            {

                //LocalMessages = "Dns.GetHostEntry(" + globalSettings.svr_hostname + ")" + Environment.NewLine + LocalMessages;

                IPHostEntry host = Dns.GetHostEntry(globalSettings.svr_hostname);
                string tmpIP = "";
                foreach (IPAddress ip in host.AddressList)
                    tmpIP = ip.ToString();

                networkConn = true;

                if (tmpIP == "" || tmpIP == "0.0.0.0" || tmpIP == "127.0.0.1")
                {
                    networkConn = false;
                }
                else if (tmpIP != globalSettings.svr_ip)
                {
                    globalSettings.svr_ip = tmpIP;
                    globalSettings.Save();
                }

            }
            catch
            {
                //LocalMessages = ex.Message + Environment.NewLine + LocalMessages;
                networkConn = false;
            }

            return networkConn;
        }


        public static string Left(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            maxLength = Math.Abs(maxLength);

            return (value.Length <= maxLength
                   ? value
                   : value.Substring(0, maxLength)
                   );
        }


        public static bool hasErrorCode(this string value)
        {
            bool ret = false;

            if (value.IndexOf("<webreqerr>") > -1)
            {
                ret = true;
            }
            else if (value.IndexOf("<err>") > -1)
            {
                ret = true;
            }
            else if (value.IndexOf("\"err\"") > -1)
            {
                ret = true;
            }
            else if (value.IndexOf("err:") > -1)
            {
                ret = true;
            }

            return ret;
        }

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


        public static IEnumerable<string> GetFileLines(string filename)
        {
            using (var stream = File.OpenRead(filename))
            {
                using (var reader = new StreamReader(stream))
                {
                    reader.ReadLine(); // skip one line
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        yield return line;
                    }
                }
            }
        }



        public static void OpenCashDrawer()
        {
            try
            {
                if (globalSettings.gen_slip_printer == "1")
                {

                    NewUsb.FindUSBPrinter();
                    for (int i = 0; i < NewUsb.USBPortCount; i++)
                    {
                        if (NewUsb.LinkUSB(i))
                        {
                            SendData2USB(new byte[] { 0x1b, 0x70, 0x00, 0x19, 0xff});
                            NewUsb.CloseUSBPort();
                        }
                    }

                    //String printStr = "";
                    //printStr += "\x1b\x40";        //Initialize printer
                    //printStr += "\x0a";
                    //printStr += "\x1b\x70\x00\x19\xff";
                    //PrinterSettings settings = new PrinterSettings();
                    //RawPrinterHelper.SendStringToPrinter(settings.PrinterName, printStr);

                }
            }
            catch { }

        }


        public static bool OutOfPaper()
        {


            int timeOut = 200;

            bool _outofpaper = false;

            try
            {

                if (globalSettings.gen_slip_printer == "1")
                {

                    NewUsb.FindUSBPrinter();
                    for (int i = 0; i < NewUsb.USBPortCount; i++)
                    {
                        if (NewUsb.LinkUSB(i))
                        {

                            var tokenSource = new CancellationTokenSource();
                            CancellationToken token = tokenSource.Token;

                            SendData2USB(new byte[] { 0x1b, 0x40 });
                            SendData2USB(new byte[] { 0x10, 0x04, 0x01 });

                            try
                            {
                                byte[] GD = new byte[] { };
                                //NewUsb.ReadDataFmUSB(ref GD);

                                var task = Task.Factory.StartNew(() => NewUsb.ReadDataFmUSB(ref GD), token);

                                if (!task.Wait(timeOut, token))
                                {
                                    //NewUsb.CloseUSBPort();
                                    globalSettings.track_print_offline++;
                                    globalSettings.track_print_save();
                                    return true;
                                }

                                byte bufbak = GD[0];
                                string strreturn = "";
                                if ((bufbak & 0x12) == 0x12)
                                {
                                    if ((bufbak & 0x08) == 0x08)
                                    {
                                        globalSettings.track_print_paper_out++;
                                        globalSettings.track_print_save();
                                        _outofpaper = true;
                                    }
                                    else
                                    { 
                                        _outofpaper = false;
                                    }
                                }
                                else
                                {
                                        _outofpaper = false;
                                }
                            }
                            catch
                            {
                                //
                            }

                            NewUsb.CloseUSBPort();
                        }
                    }

                }
            }
            catch { }

            return _outofpaper;

        }

        public static bool isPrinterOffline()
        {


            if (globalSettings.gen_slip_printer == "0") return false;

            int timeOut = 200;

            bool _isOffline = false;

            try
            {
                    NewUsb.FindUSBPrinter();

                    if (NewUsb.USBPortCount == 0) return true;

                    for (int i = 0; i < NewUsb.USBPortCount; i++)
                    {
                        if (NewUsb.LinkUSB(i))
                        {

                            var tokenSource = new CancellationTokenSource();
                            CancellationToken token = tokenSource.Token;

                            SendData2USB(new byte[] { 0x1b, 0x40 });
                            SendData2USB(new byte[] { 0x10, 0x04, 0x01 });

                            try
                            {
                                byte[] GD = new byte[] { };
                                var task = Task.Factory.StartNew(() => NewUsb.ReadDataFmUSB(ref GD), token);
                                if (!task.Wait(timeOut, token))
                                {
                                    globalSettings.track_print_offline++;
                                    globalSettings.track_print_save();
                                    return true;
                                }

                                byte bufbak = GD[0];
                                string strreturn = "";
                                if ((bufbak & 0x12) == 0x12)
                                {
                                    if ((bufbak & 0x08) == 0x08)
                                    {
                                        globalSettings.track_print_paper_out++;
                                        globalSettings.track_print_save();
                                        _isOffline = true;
                                    }
                                    else
                                    {
                                        _isOffline = false;
                                    }
                                }
                                else
                                {
                                    _isOffline = false;
                                }

                            }
                            catch
                            {
                                //MessageBox.Show(e.Message);
                            }

                            SendData2USB(enddata);
                            SendData2USB(enddata);

                            NewUsb.CloseUSBPort();
                        }
                    }

            }
            catch
            {
                //MessageBox.Show(ex.Message);
            }

            return _isOffline;

        }






        public static void LaunchApp(string filename, string workingdirectory)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.FileName = filename;

                if (workingdirectory.Length == 0)
                {
                    startInfo.WorkingDirectory = null;
                }
                else
                {
                    startInfo.WorkingDirectory = workingdirectory;
                }
                //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
                System.Diagnostics.Process.Start(startInfo);
            }
            catch
            {
                // log_error(e.Message);
            }
        }


        static public bool checkLoginAdmin(string loginPin)
        {

            bool loginok = false;

            if (loginPin != "")
            {
                try
                {

                    int m = int.Parse(DateTime.Now.ToString("MM")) + 2;
                    int d = int.Parse(DateTime.Now.ToString("dd")) + 2;
                    string month = m.ToString();
                    string day = d.ToString();

                    string checkdateAdmin = month.PadLeft(2, '0') + day.PadLeft(2, '0');
                    checkdateAdmin = checkdateAdmin.Replace("0", "1");

                    if (loginPin == checkdateAdmin)
                    {
                        loginok = true;
                    }

                } 
                catch 
                {
                    loginok = false;
                }
            }

            return loginok;

        }
       

        static public bool checkLogin(string loginPin, bool isSwipe)
        {
            bool loginok = false;
            string pin = "";

            if (loginPin != "")
            {
                try
                {

                    foreach (string s in Util.pos_users)
                    {
                        string[] line = s.Split('^');

                        if (isSwipe)
                        {
                            pin = line[6].ToString();
                        }
                        else
                        {
                            pin = line[5].ToString();
                        }

                        // Ok found a pin
                        if (loginPin == pin && line[4].Equals("1"))
                        {

                            globalSettings.pos_user_fullname = line[1].ToString() + " " + line[2].ToString();
                            globalSettings.pos_user_firstname = line[1].ToString();
                            globalSettings.pos_user_id = line[0].ToString();

                            if (line[3].Equals("1"))
                            {
                                globalSettings.pos_user_admin = true;
                            }
                            else
                            {
                                globalSettings.pos_user_admin = false;
                            }

                            globalSettings.pos_user_rica_registered = false;
                            try
                            {
                                if (line[9].Equals("1") && !line[10].Equals("0"))
                                {
                                    globalSettings.pos_user_rica_registered = true;
                                }
                            }
                            catch
                            {
                                //
                            }

                            loginok = true;
                            break;
                        }
                    }

                }
                catch
                {
                    loginok = false;
                }
            }

            return loginok;

        }





       
      



        

        public static void loadPosUsers()
        {
            try
            {
                if (File.Exists(globalSettings.app_path + @"\conf\posusers.dat"))
                {
                    using (StreamReader r = new StreamReader(globalSettings.app_path + @"\conf\posusers.dat"))
                    {
                        pos_users.Clear();
                        string line;
                        while ((line = r.ReadLine()) != null)
                        {
                           pos_users.Add(line);
                        }
                    }
                }
            } catch { }
        }


        public static void loadSlipExtra()
        {
            try
            {
                if (File.Exists(globalSettings.app_path + @"\conf\settings_slipextra.dat"))
                {
                    using (StreamReader r = new StreamReader(globalSettings.app_path + @"\conf\settings_slipextra.dat"))
                    {
                        string line = r.ReadLine();
                        try
                        {
                            string[] extra_line = line.Split('^');
                            Util.voucher_print_extra[0] = extra_line[0];
                            Util.voucher_print_extra[1] = extra_line[1];
                            Util.voucher_print_extra[2] = extra_line[2];
                            Util.voucher_print_extra[3] = extra_line[3];
                            Util.voucher_print_extra[4] = extra_line[4];
                        }
                        catch
                        {
                            //
                        }

                        if (line.Length > 4)
                        {
                            globalSettings.do_print_extra = true;
                        }

                    }
                }
            }
            catch { }
        }


        public static string Encrypt(string plainText)
        {

            //Console.WriteLine("Encypt: " + system_uid);


            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            byte[] keyBytes = new Rfc2898DeriveBytes(system_uid, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }

        public static string Decrypt(string encryptedText)
        {

            //Console.WriteLine("Decrypt:" + system_uid);

            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = new Rfc2898DeriveBytes(system_uid, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }



        public static string getUniqueID()
        {

            string tiu_guid = "0000000000000";

            try
            {
                
                //Microsoft.Win32.RegistryKey tiu = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\TiU\", true);
                Microsoft.Win32.RegistryKey tiu = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\TiU");

                if (tiu != null && tiu.GetValue("serial") != null && tiu.GetValue("serial").ToString().Length > 0)
                {
                    tiu_guid = tiu.GetValue("serial").ToString();
                }
                else
                {

                    //try
                    //{
                    //    tiu.CreateSubKey("serial");
                    //}
                    //catch ( Exception ex){
                    //    MessageBox.Show(ex.Message);
                    //}

                    //string new_guid = getEMEI();

                    //if (new_guid.Length == 0)
                    //{
                    //    new_guid = Util.CalculateMD5Hash(Guid.NewGuid().ToString()).ToUpper();
                    //}

                    ////string new_guid = System.Guid.NewGuid().ToString().ToUpper().Replace("-", "");
                    //tiu.SetValue("serial", new_guid);
                    //tiu_guid = new_guid;

                    

                }

                tiu.Close();

            } catch(Exception ex)
            {
                tiu_guid = "0000000000000";
                MessageBox.Show(ex.Message);
            }
            
            return tiu_guid;

        }


        public static string getEMEI()
        {

            String _imei = "";

            try
            {

                System.Diagnostics.Process p1 = new System.Diagnostics.Process();
                p1.StartInfo.FileName = "netsh.exe";
                p1.StartInfo.Arguments = "mbn show interface";
                p1.StartInfo.UseShellExecute = false;
                p1.StartInfo.RedirectStandardOutput = true;
                p1.StartInfo.RedirectStandardError = true;
                p1.StartInfo.CreateNoWindow = true;
                p1.Start();

                String _mobile_network_name_all = p1.StandardOutput.ReadToEnd();
                using (StringReader reader = new StringReader(_mobile_network_name_all))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains("Device Id"))
                        {

                            _imei = line.Split(':')[1].Trim();

                            globalSettings.device_imei = _imei;
                            globalSettings.SaveGeneral();
                        }
                    }
                }

            }
            catch
            {
                 _imei = "";
            }

            return _imei;

        }



        private static string ICCID()
        {

            String _imei = "";

            try
            {

                System.Diagnostics.Process p1 = new System.Diagnostics.Process();
                p1.StartInfo.FileName = "netsh.exe";
                p1.StartInfo.Arguments = "mbn show interface";
                p1.StartInfo.UseShellExecute = false;
                p1.StartInfo.RedirectStandardOutput = true;
                p1.StartInfo.RedirectStandardError = true;
                p1.StartInfo.CreateNoWindow = true;
                p1.Start();

                String _mobile_network_name_all = p1.StandardOutput.ReadToEnd();
                using (StringReader reader = new StringReader(_mobile_network_name_all))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains("Device Id"))
                        {
                            _imei = line.Split(':')[0].Trim();
                        }
                    }
                }

            }
            catch
            {
                _imei = "";
            }


            return _imei;

        }



        public static string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
 
            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }


        //public static String setSkypePath()
        //{
        //    Microsoft.Win32.RegistryKey skype = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Skype\Phone");

        //    if (skype != null && skype.GetValue("SkypePath") != null)
        //    {
        //        skype_path = skype.GetValue("SkypePath").ToString();
        //        return skype.GetValue("SkypePath").ToString();
        //    }
        //    else
        //    {
        //        return "";
        //    }
        //}




        public static void showPrinterProblem(Boolean visible, String printText, Boolean showCashDrawer)
        {
            if (!popupprintercreated)
            {
                createPrinterPopup(printText, showCashDrawer);
            }
            else
            {
                if (visible)
                {
                    frmNoPrinter.Invoke((MethodInvoker)delegate()
                    {
                        frmNoPrinter.setIsCashDrawer = showCashDrawer;
                        frmNoPrinter.setReprintText = printText;
                        frmNoPrinter.Show();
                    });
                }
                else
                {
                    frmNoPrinter.Invoke((MethodInvoker)delegate()
                    {
                        frmNoPrinter.Hide();
                    });
                }
            }
        }

        private static void createPrinterPopup(String printText, Boolean showCashDrawer)
        {
            popupprintercreated = true;
            Thread waitThread = new Thread(new ThreadStart(
            delegate
            {
                frmNoPrinter = new frmNoPrinter();
                frmNoPrinter.setIsCashDrawer = showCashDrawer;
                frmNoPrinter.setReprintText = printText;
                Application.Run(frmNoPrinter);
            }
            ));
            waitThread.SetApartmentState(ApartmentState.STA);
            waitThread.Start();
        }

        public static void showPrinterClose()
        {
            try
            {
                frmNoPrinter.Invoke((MethodInvoker)delegate()
                {
                    frmNoPrinter.Close();
                });
            }
            catch
            {
                //
            }
        }







        public static popupLoading popLoading = new popupLoading();

        public static void showLoading(Boolean modal, String display_text)
        {
            popLoading.setContent(modal, display_text);
            popLoading.Show();
            //SetCursor(Screen.PrimaryScreen.Bounds.Width, 0);
            if (modal)
            {
                EnableInput(popLoading, true);
            }
        }
        public static void hideLoading()
        {
            if (popLoading.is_modal) EnableInput(popLoading, false);
            popLoading.Hide();
        }






        public static void showWait(String caption)
        {

            if (!popupwaitcreated)
            {
                createWaitPopup();
            }
            else
            {
                frmPopupWait.Invoke((MethodInvoker) delegate()
                {
                    frmPopupWait.setCaption(caption);
                    frmPopupWait.setColor(Color.Yellow);
                    frmPopupWait.Show();
                });
            }
        }

        public static void showWait(Boolean visible)
        {
            if (!popupwaitcreated)
            {
                createWaitPopup();
            }
            else
            {
                if (visible)
                {
                    frmPopupWait.Invoke((MethodInvoker)delegate()
                    {
                        frmPopupWait.setColor(Color.White);
                        frmPopupWait.setCaption("Busy, Please Wait...");
                        frmPopupWait.Show();
                    });
                }
                else
                {
                    frmPopupWait.Invoke((MethodInvoker)delegate()
                    {
                        frmPopupWait.Hide();
                    });
                }
            }
        }

        private static void createWaitPopup()
        {
            popupwaitcreated = true;
            Thread waitThread = new Thread(new ThreadStart(
            delegate
            {
                frmPopupWait = new PopupWait();
                Application.Run(frmPopupWait);
            }
            ));
            waitThread.SetApartmentState(ApartmentState.STA);
            waitThread.Start();
        }

        public static void showWaitClose()
        {
            try
            {
                frmPopupWait.Invoke((MethodInvoker)delegate()
                {
                    frmPopupWait.Close();
                });
            }
            catch
            {
                //
            }
        }
       



        public static void showMessage(String msg, Color c)
        {
            PopupNotifier popupNotifier = new PopupNotifier();
            popupNotifier.ContentColor = c;
            popupNotifier.ContentText = msg;

            popupNotifier.Image = global::TopitUp.Properties.Resources.popup_info;

            popupNotifier.Popup();
        }

        public static void showUpdate(String msg)
        {
            PopupNotifier popupNotifier = new PopupNotifier();
            popupNotifier.ContentText = msg;
            //popupNotifier.isUpdate = true;
            popupNotifier.Popup();
        }



        public static void playSound(String wavfile)
        {

            if (globalSettings.gen_sound.Equals("0")) return;

            try
            {
                (new System.Media.SoundPlayer(@"c:\topitup\sounds\" + wavfile)).Play();
            }
            catch
            {
                //
            }
        }


        public static bool checkIDNumber(string id_number)
        {

            if (id_number.Length < 13) return false;

            if (id_number.Substring(id_number.Length - 1, 1) == GetControlDigit(id_number).ToString()) return true;

            return false;

        }

        private static int GetControlDigit(string id_number)
        {
            int d = -1;
            try
            {
                int a = 0;
                for (int i = 0; i < 6; i++)
                {
                    a += int.Parse(id_number[2 * i].ToString());
                }
                int b = 0;
                for (int i = 0; i < 6; i++)
                {
                    b = b * 10 + int.Parse(id_number[2 * i + 1].ToString());
                }
                b *= 2;
                int c = 0;
                do
                {
                    c += b % 10;
                    b = b / 10;
                }
                while (b > 0);
                c += a;
                d = 10 - (c % 10);
                if (d == 10) d = 0;
            }
            catch {/*ignore*/} return d;
        }



        public static void loadProviderItem()
        {

            int provider_counter = -1;
            int item_counter = -1;

            stock_provider.Clear();

            try
            {

                if (File.Exists(globalSettings.app_path + @"\conf\provider_item.dat"))
                {
                    using (StreamReader r = new StreamReader(globalSettings.app_path + @"\conf\provider_item.dat"))
                    {
                        string line;
                        while ((line = r.ReadLine()) != null)
                        {

                            if (line.Length > 0)
                            {
                                string[] result;
                                result = line.Split('^');

                                if (result[0] == "p")
                                {
                                    provider_counter++;
                                    item_counter = -1;
                                    stock_provider.Add(new stockProvider(Convert.ToInt32(result[1]), result[2], result[3]));
                                }
                                else
                                {
                                    item_counter++;
                                    //if (item_counter < 15)
                                    //{
                                        //stock_provider[provider_counter].item[item_counter] = new stockProviderItem(Convert.ToInt32(result[0]), result[1], result[2], result[3], result[4], result[5], Convert.ToInt32(result[6]), Convert.ToInt32(result[7]), Convert.ToInt32(result[8]), result[9]);
                                        stock_provider[provider_counter].item.Add(new stockProviderItem(Convert.ToInt32(result[0]), result[1], result[2], result[3], result[4], result[5], Convert.ToInt32(result[6]), Convert.ToInt32(result[7]), Convert.ToInt32(result[8]), result[9]));
                                        stock_provider[provider_counter].itemcount++;
                                    //}
                                }
                            }

                        }
                    }

                }

            }
            catch
            {
                stock_provider.Clear();
                showMessage("Error Loading Network Data (" + provider_counter + ")", Color.Red);
            }

        }


    }


    public class stockProvider
    {

        public int provider_id = 0;

        public string provider_desc = "";
        public string provider_message = "";

        public string[] provider_print;

        //public stockProviderItem[] item = new stockProviderItem[15];
        public List<stockProviderItem> item = new List<stockProviderItem>();
        public int itemcount = 0;

        public stockProvider()
        {
            //
        }

        public stockProvider(int prov_id, string prov_desc, string prov_msg)
        {
            provider_id = prov_id;
            provider_desc = prov_desc;
            provider_message = prov_msg;

            provider_print = Util.str_wrap(prov_msg, 32, false);
        }

    }

    public class stockProviderItem
    {

        public int item_id = 0;
        public int item_type = 0;
        public int item_position = 0;

        public string item_desc = "";
        public string item_btn_desc = "";
        public string item_print_desc = "";
        public string item_quickprint = "";
        public string item_value = "";
        public string item_barcode = "";

        public bool visible_cashier = false;
        public bool visible_admin = false;
        public bool item_show_value = false;

        public stockProviderItem()
        {
            //
        }

        public stockProviderItem(int itm_id, string itm_desc, string itm_btn_desc, string itm_quick_desc, string itm_print_desc, string itm_val, int itm_type, int itm_show_value, int itm_position, string itm_barcode)
        {

            itm_val = itm_val.Replace(".0", ".00");

            item_id = itm_id;
            item_position = itm_position;
            item_type = itm_type;
            item_desc = itm_desc;
            item_quickprint = itm_quick_desc;
            item_btn_desc = itm_btn_desc;
            item_print_desc = itm_print_desc;
            item_value = itm_val;
            item_barcode = itm_barcode;
            visible_cashier = true;
            visible_admin = true;

            if (itm_show_value == 1) item_show_value = true;
        }


    }


}

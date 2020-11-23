using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using System.Threading.Tasks;
using System.Windows.Forms;


using CefSharp;
using CefSharp.WinForms;


namespace TopitUp
{
    public partial class frmWebBrowser : Form
    {


        public ChromiumWebBrowser browser;
        const String URL_BLANK = "about:blank";

        private bool show_kbd = true;

        public frmWebBrowser(bool show_keyboard)
        {

            show_kbd = show_keyboard;
            InitializeComponent();


            try
            {

                //if (!Cef.IsInitialized)
                //{
                //    CefSettings settings = new CefSettings();
                //    settings.BrowserSubprocessPath = @"c:\topitup\CefSharp.BrowserSubprocess.exe";
                //    settings.IgnoreCertificateErrors = true;
                //    settings.CefCommandLineArgs.Add("no-proxy-server", "1");
                //    Cef.Initialize(settings, performDependencyCheck: false, browserProcessHandler: null);
                //    Cef.Initialize(new CefSettings());
                //}

                //String htmlContent = File.ReadAllText("c:\topitup\html\busyWait.htm");
                //browser.Load(URL_BLANK);
                //browser.LoadHtml(HtmlContent, "zart zurt");

                browser = new ChromiumWebBrowser("");

                BrowserSettings browser_setting = new BrowserSettings();
                browser_setting.LocalStorage = CefState.Enabled;
                browser_setting.FileAccessFromFileUrls = CefState.Enabled;
                browser_setting.UniversalAccessFromFileUrls = CefState.Enabled;
                browser_setting.WebSecurity = CefState.Disabled;
                browser.BrowserSettings = browser_setting;

                browser.RenderProcessMessageHandler = new RenderProcessMessageHandler();

                browser.IsBrowserInitializedChanged += (sender, args) =>
                {
                    if (new_url.Length > 0) {
                        browser.Load(new_url);
                        Util.showWait(false);
                    }
                };

                browser.LoadingStateChanged += (sender, args) =>
                {
                    //Wait for the Page to finish loading
                    if (args.IsLoading == false)
                    {
                        Util.showWait(false);
                        //Console.WriteLine("Done loading.");
                        //MessageBox.Show("done");
                        //browser.ExecuteJavaScriptAsync("alert('All Resources Have Loaded');");
                    }
                };

                //Wait for the MainFrame to finish loading
                //browser.FrameLoadEnd += (sender, args) =>
                //{
                //    //Wait for the MainFrame to finish loading
                //    if (args.Frame.IsMain)
                //    {
                //        args.Frame.ExecuteJavaScriptAsync("alert('MainFrame finished loading');");
                //    }
                //};


                this.Controls.Add(browser);
                browser.Dock = DockStyle.Fill;
                browser.BringToFront();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        String new_url = "";

        public void Nav(String url)
        {

            if (!browser.IsBrowserInitialized)
            {
                new_url = url;
                return;
            }

            browser.Load(url);

        }





        private void frmWebBrowser_Load(object sender, EventArgs e)
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

            if (globalSettings.gen_virtual_keyboard == "1" && show_kbd)
            {
                pnlKeyboard.Visible = true;

            }
            else
            {
                pnlKeyboard.Visible = false;
            }

            if (pnlKeyboard.Visible) virtualKeyboard1.changeKeyPadtoLetters();



            //wbInfo.IsWebBrowserContextMenuEnabled = false;
            //wbInfo.AllowWebBrowserDrop = false;

        }

     
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //bool has_loaded = false;
        //private void wbInfo_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        //{

        //    if (has_loaded) return;

        //    Console.WriteLine(e.Url.ToString());
        //    Console.WriteLine("Readystate: " + this.wbInfo2.ReadyState);

        //    if (this.wbInfo.ReadyState == WebBrowserReadyState.Complete)
        //    {
        //        if (this.wbInfo.DocumentTitle.Equals("topitup")) {
        //            //
        //        } else {
        //            has_loaded = true;
        //            this.wbInfo.Url = new Uri("file://c:/topitup/html/noContentImage.htm");
        //        }
        //    }

        //    Util.showWait(false);

        //}


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

    

    
    
    }




}

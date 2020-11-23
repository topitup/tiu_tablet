using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TopitUp
{
    public partial class frmNoPrinter: Form
    {

        Form centerWrapper = new Form();

        private String _reprint_text = "";
        private Boolean hasCashDrawer = false;
        private Boolean isCashDrawer = false;

        System.Timers.Timer _timer = new System.Timers.Timer();

        public frmNoPrinter()
        {

            InitializeComponent();

            _timer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
            _timer.Interval = 1000;
            //aTimer.Enabled = true;

        }


        private void frmNoPrinter_Load(object sender, EventArgs e)
        {

          
            this.Opacity = .95;

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

            if (globalSettings.gen_cashdr.Equals("1"))
            {
                lblCashDrawer.Visible = true;
                hasCashDrawer = true;
            }

            if (hasCashDrawer)
            {
                if (isCashDrawer)
                {
                    this.lblHeader2.Text = "connected cash drawer.";
                    this.picPrinter.BackgroundImage = global::TopitUp.Properties.Resources.printer_offline_cashdrawer;
                }
                else
                {
                    this.lblHeader2.Text = "or out of paper!";
                    this.picPrinter.BackgroundImage = global::TopitUp.Properties.Resources.printer_offline;
                }
            }

        }


        private void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            _timer.Enabled = false;

            if (!Util.isPrinterOffline())
            {

                this.picPrinter.Invoke((MethodInvoker)delegate()
                {
                    this.picPrinter.Image = global::TopitUp.Properties.Resources.printer_offline_ok;
                });

                this.btnReprint.Invoke((MethodInvoker)delegate()
                {
                    this.btnReprint.Enabled = true;
                });

                

                return;
            }

            this.btnReprint.Invoke((MethodInvoker)delegate()
            {
                this.btnReprint.Enabled = false;
            });

            _timer.Enabled = true;
        }


        public bool setIsCashDrawer
        {
            set
            {
                isCashDrawer = value;
            }
        }


        public string setReprintText
        {
            set
            {
                _reprint_text = value;
                if (_reprint_text.Length > 0 )
                {
                    btnReprint.Visible = true;
                }
                else
                {
                    btnReprint.Visible = false;
                }
            }
        }




        private void btnCancel_Click(object sender, EventArgs e)
        {
            _timer.Enabled = false;
            Util.showPrinterProblem(false,"",false);
        }

        private void btnReprint_Click(object sender, EventArgs e)
        {
            
            _timer.Enabled = false;

            if (Util.isPrinterOffline())
            {
                btnReprint.Enabled = false;
                _timer.Enabled = true;
                return;
            }

            btnReprint.Visible = false;

            Util.printText(_reprint_text , false);

        }

        private void frmNoPrinter_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {

                this.WindowState = FormWindowState.Minimized;
                this.Show();
                this.WindowState = FormWindowState.Normal;

                btnReprint.Enabled = false;
                _timer.Enabled = true;
                this.picPrinter.Image = global::TopitUp.Properties.Resources.printer_offline_probem;

                if (hasCashDrawer)
                {
                    if (isCashDrawer)
                    {
                        lblHeader2.Text = "connected cash drawer.";
                        this.picPrinter.BackgroundImage = global::TopitUp.Properties.Resources.printer_offline_cashdrawer;
                    }
                    else
                    {
                        lblHeader2.Text = "or out of paper!";
                        this.picPrinter.BackgroundImage = global::TopitUp.Properties.Resources.printer_offline;
                    }
                }
                
            }
            else
            {
                _timer.Enabled = false;
            }
            

        }





    }

}

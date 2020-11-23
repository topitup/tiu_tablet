using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopitUp
{
    public partial class popupLoading : Form
    {
        
        public bool is_modal = false;

        public popupLoading()
        {

            InitializeComponent();

            try
            {
                this.picIcon.Image = new Bitmap(globalSettings.app_path + @"\images\popup_timer.gif");
            }
            catch
            {
                //
            }

            this.TopMost = true;

        }

        private void PopupWait_Load(object sender, EventArgs e)
        {

            this.Left = 0;
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Top = (Screen.PrimaryScreen.Bounds.Height - 170) / 2;
            this.Height = 170;

        }

        public void setContent(bool set_modal, String main_text)
        {
            is_modal = set_modal;
            btn_popup_close.Visible = false;
            lblCaption.Text = main_text;
        }

        public void setText(String main_text)
        {
            lblCaption.Text = main_text;
        }


        public void setSubText(String sub_text)
        {
            lbl_subtext.Text = sub_text;
            lbl_subtext.Visible = true;
            lbl_subtext.Refresh();
        }

        public void showButton(string button_text, string button_action)
        {
            btn_popup_close.Text = button_text;
            btn_popup_close.Tag = button_action;

            if (btn_popup_close.Tag.Equals("restart"))
            {
                this.BackColor = Color.Firebrick;
                btn_popup_close.ForeColor = Color.Firebrick;

                lblCaption.BackColor = Color.Firebrick;
                lbl_subtext.BackColor = Color.Firebrick;

                try
                {
                    this.picIcon.Image = new Bitmap(globalSettings.app_path + @"\images\popup_power.gif");
                }
                catch
                {
                    //
                }

            }

            btn_popup_close.Visible = true;

        }


        public void change_icon(String icon)
        {

            this.BackColor = Color.Firebrick;
            lblCaption.BackColor = Color.Firebrick;
            lbl_subtext.BackColor = Color.Firebrick;

            try
            {
                this.picIcon.Image = new Bitmap(globalSettings.app_path + @"\images\" + icon + ".gif");
            }
            catch
            {
                //
            }
        }

        private void btn_popup_close_Click(object sender, EventArgs e)
        {

            if (btn_popup_close.Tag.Equals("restart"))
            {
                lblCaption.Text = "Restarting...";
                btn_popup_close.Enabled = false;

                Application.DoEvents();

                //string target = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
                //Util.RunAppAtTime(target, new TimeSpan(0, 0, 5));
                //System.Diagnostics.Process.GetCurrentProcess().Kill();

                try
                {
                    System.Diagnostics.Process.Start("shutdown", "/r /t 0");
                }
                catch
                {
                    //
                }


            }
            else
            {
                Util.hideLoading();
            }

        }



    }
}

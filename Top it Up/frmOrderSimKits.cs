using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TopitUp
{
    public partial class frmOrderSimKits : Form
    {


        public frmOrderSimKits()
        {
            InitializeComponent();
        }

        private void frmOrderSimKits_Load(object sender, EventArgs e)
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

            if (globalSettings.gen_virtual_keyboard == "1")
            {
                pnlKeyboard.Visible = true;
                virtualKeyboard1.setKeyPadOnly(true);
            }
            else
            {
                pnlKeyboard.Visible = false;
            }

            Util.showWait(false);

            this.Activate();

        }



        private void btnClose_Click(object sender, EventArgs e)
        {

            this.Close();

        }



        private void btnOK_Click(object sender, EventArgs e)
        {

          
            Util.showWait("Processing Request...");

            String extra = "";
            if (ordertype.Equals("1"))
            {
                extra = "&p3qty=" + txtProvider3.Text;
                extra += "&p2qty=" + txtProvider2.Text;
                extra += "&p10qty=" + txtProvider10.Text;
                extra += "&p1qty=" + txtProvider1.Text;
            }

            Web WebResponse = new Web(60000, 1, "");
            String htmlResponse = WebResponse.GetURL("/terminal/general/order-simkits?order_type=" + ordertype + extra);
            WebResponse = null;

            Util.showWait(false);

            if (htmlResponse.IndexOf("err>") > -1)
            {

                Util.showMessage(htmlResponse.StripErrorTags(), Color.Red);
                
                btnOK.Enabled = true;
                btnClose.Enabled = true;

            }
            else
            {

                lblComplete.Visible = true;
                pnlWrapper.Visible = false;

                btnOK.Visible = false;
                btnClose.Enabled = true;
                btnClose.Text = "Done!";

            }


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


        private void digitsOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
           
        }

        private String ordertype = "0";

        private void option0_Click(object sender, EventArgs e)
        {

            ordertype = "0";

            option0pic.Image = global::TopitUp.Properties.Resources.option1;
            option1pic.Image = global::TopitUp.Properties.Resources.option0;

            lblOption0.ForeColor = Color.Maroon;
            lblOption1.ForeColor = Color.Gray;

            txtProvider3.Enabled = false;
            txtProvider2.Enabled = false;
            txtProvider10.Enabled = false;
            txtProvider1.Enabled = false;

        }

        private void option1_Click(object sender, EventArgs e)
        {

            ordertype = "1";

            option0pic.Image = global::TopitUp.Properties.Resources.option0;
            option1pic.Image = global::TopitUp.Properties.Resources.option1;

            lblOption0.ForeColor = Color.Gray;
            lblOption1.ForeColor = Color.Maroon;

            txtProvider3.Enabled = true;
            txtProvider2.Enabled = true;
            txtProvider10.Enabled = true;
            txtProvider1.Enabled = true;

        }

       
    

    }
}
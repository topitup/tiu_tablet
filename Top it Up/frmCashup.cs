using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopitUp
{
    public partial class frmCashup : Form
    {

        Form centerWrapper = new Form();

        public frmCashup()
        {
            InitializeComponent();
        }


        private void frmCashup_Load(object sender, EventArgs e)
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

            centerWrapper.StartPosition = FormStartPosition.Manual;
            centerWrapper.FormBorderStyle = FormBorderStyle.None;
            centerWrapper.ShowInTaskbar = false;

            centerWrapper.BackColor = Color.White;

            if (globalSettings.allow_screen_resize == "0")
            {
                centerWrapper.Top = this.pnlMainWrapper.Top;
                centerWrapper.Left = this.pnlMainWrapper.Left;
                centerWrapper.Width = this.pnlMainWrapper.Width;
                centerWrapper.Height = this.pnlMainWrapper.Height;
            }
            else
            {
                centerWrapper.Top = this.Top + this.pnlMainWrapper.Top;
                centerWrapper.Left = this.Left + this.pnlMainWrapper.Left;
                centerWrapper.Width = this.pnlMainWrapper.Width;
                centerWrapper.Height = this.pnlMainWrapper.Height;
            }

            this.AddOwnedForm(centerWrapper);

            this.pnlMainWrapper.Parent = centerWrapper;
            this.pnlMainWrapper.Top = 0;
            this.pnlMainWrapper.Left = 0;

            centerWrapper.Show();

            btnRunX.Visible = false;
            btnZReportCashup.Visible = false;
            btnYReportHistory.Visible = false;

            lblWIntraday.Visible = false;
            lblYShift.Visible = false;

            if (globalSettings.gen_cashier_w == "1")
            {
                btnRunX.Visible = true;
                lblWIntraday.Visible = true;
            }

            if (globalSettings.gen_cashier_y == "1")
            {
                btnZReportCashup.Visible = true;
                lblYShift.Visible = true;
            }

            if (globalSettings.gen_cashier_y_history == "1")
            {
                btnYReportHistory.Visible = true;
            }

            if (globalSettings.gen_cashier_restart == "1")
            {
                btnRestart.Visible = true;
            }

        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            
            this.Close();

        }

        private void btnYReportHistory_Click(object sender, EventArgs e)
        {

            btnZHistoryReprint.Hide();

            grdCashierZHistory.Show();
            lblLastYReports.Show();

            grdCashierZHistory.Rows.Clear();

            String htmlResponse = "";

            Web WebResponse = new Web(45000);
            htmlResponse = WebResponse.GetURL("/terminal/cashup/z-report-history-cashier");
            WebResponse = null;

            if (htmlResponse.IndexOf("<webreqerr>", 0) >= 0)
            {
                Util.showMessage(htmlResponse.GetStrBetweenTags("<webreqerr>", "</webreqerr>"),Color.Red);
            }
            else if (htmlResponse.IndexOf("<err>", 0) >= 0)
            {
                Util.showMessage(htmlResponse.GetStrBetweenTags("<err>", "</err>"), Color.Red);
            }
            else if (htmlResponse == "")
            {
                Util.showMessage("No Previous Y Reports.", Color.Red);
            }
            else if (htmlResponse != "")
            {
                try
                {
                    string[] lines = htmlResponse.Split('\n');

                    for (int i = 0; i < lines.Length - 1; i++)
                    {
                        string[] items = lines[i].Split('^');

                        grdCashierZHistory.Rows.Add();

                        grdCashierZHistory.Rows[i].Tag = items[0];
                        grdCashierZHistory.Rows[i].Cells[0].Value = items[2];
                        grdCashierZHistory.Rows[i].Cells[1].Value = items[3];
                        grdCashierZHistory.Rows[i].Cells[2].Value = String.Format(" R {0:n}", decimal.Parse(items[4], System.Globalization.CultureInfo.InvariantCulture) + decimal.Parse(items[5]), System.Globalization.CultureInfo.InvariantCulture);


                    }

                    btnZHistoryReprint.Show();

                }
                catch (Exception ex)
                {
                    Util.showMessage(ex.Message, Color.Red);
                }
            }
        }

        private void btnZHistoryReprint_Click(object sender, EventArgs e)
        {

            int _customer_report_z_id = 0;

            try
            {
                DataGridViewRow row = grdCashierZHistory.Rows[grdCashierZHistory.CurrentCell.RowIndex];
                _customer_report_z_id = Convert.ToInt32(row.Tag);
            }
            catch
            {
                _customer_report_z_id = 0;
            }

            if (_customer_report_z_id == 0)
            {
                Util.showMessage("Please select Y Report.", Color.Red);
                return;
            }

            string htmlResponse = "";

            Web WebResponse = new Web(60000);
            htmlResponse = WebResponse.GetURL("/terminal/cashup/cashup-single-reprint?q=" + _customer_report_z_id.ToString());
            WebResponse = null;

            if (htmlResponse.IndexOf("<webreqerr>") > -1)
            {
                Util.showMessage(htmlResponse.GetStrBetweenTags("<webreqerr>", "</webreqerr>"), Color.Red);
            }
            else if (htmlResponse.IndexOf("<err>") > -1)
            {
                Util.showMessage(htmlResponse.GetStrBetweenTags("<err>", "</err>"), Color.Red);
            }
            else
            {
                Util.printText(htmlResponse, false);
            }

        }

        private void btnRunX_Click(object sender, EventArgs e)
        {

          
            string htmlResponse = "";

            Web WebResponse = new Web(60000);
            htmlResponse = WebResponse.GetURL("/terminal/cashup/x-single");
            WebResponse = null;

            if (htmlResponse.IndexOf("err>") > -1)
            {
                Util.showMessage(htmlResponse.StripErrorTags(), Color.Red);
            }
            else
            {
                Util.printText(htmlResponse, false);
            }
        }

        private void btnZReportCashup_Click(object sender, EventArgs e)
        {


            string htmlResponse = "";
            bool cashup_complete = false;

            Web WebResponse = new Web(60000);
            htmlResponse = WebResponse.GetURL("/terminal/cashup/cashup-single");
            WebResponse = null;

            if (htmlResponse.IndexOf("<webreqerr>") > -1)
            {
                Util.showMessage(htmlResponse.GetStrBetweenTags("<webreqerr>", "</webreqerr>"), Color.Red);
            }
            else if (htmlResponse.IndexOf("<err>") > -1)
            {
                Util.showMessage(htmlResponse.GetStrBetweenTags("<err>", "</err>"), Color.Red);
            }
            else
            {
                cashup_complete = true;
                Util.printText(htmlResponse, false);
            }

            if (cashup_complete)
            {
                Util.showMessage("Cashup Complete!", Color.White);
            }

        }

        private void btnRestart_Click(object sender, EventArgs e)
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

    }
}

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
    public partial class frmPrintLast : Form
    {


        int _reprint_uid = 0;
        int _filter_type = 0;

        public frmPrintLast()
        {
            InitializeComponent();
        }


        private void frmSettingsPrint_Load(object sender, EventArgs e)
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
            }
            else
            {
                pnlKeyboard.Visible = false;
            }

            rdoFilterType0.Checked = true;
            lblReprintSerialMeter.Visible = false;
            pnlRefInput.Visible = false;

            PopulateLastSales();

            this.Activate();

            Util.showWait(false);
          
        }



        private void btnClose_Click(object sender, EventArgs e)
        {


        }


        private void btnReprint_Click(object sender, EventArgs e)
        {

            try
            {
                DataGridViewRow row = dgLast10.Rows[dgLast10.CurrentCell.RowIndex];
                _reprint_uid = Convert.ToInt32(row.Tag);
            } catch
            {
                _reprint_uid = 0;
            }

            if (_reprint_uid == 0)
            {
                Util.showMessage("No voucher selected.", Color.Red);
                return;
            }

            String ret = webService.getReprint(4, _reprint_uid.ToString());

            if (ret == "OK")
            {
                Util.doReprintLogic();
            }
            else
            {
                Util.showMessage("Could not Re-Printing Voucher.", Color.Red);
            }

        }




        private void PopulateLastSales()
        {


            if (txtReprint.Text.Trim().Length > 0 && txtReprint.Text.Trim().Length < 4)
            {
                Util.showMessage("Ref# or Serial too short!", Color.Red);
                return;
            }

            dgLast10.Rows.Clear();


            String htmlResponse = webService.getLastSales(_filter_type,txtReprint.Text.Trim());

            if (htmlResponse.IndexOf("err>") > 0)
            {
                Util.showMessage(htmlResponse.StripErrorTags(), Color.Red);
            }
            else if (htmlResponse != "")
            {
                try
                {
                    string[] lines = htmlResponse.Split('\n');

                    for (int i = 0; i < lines.Length - 1; i++)
                    {
                        string[] items = lines[i].Split('^');

                        dgLast10.Rows.Add();
                        dgLast10.Rows[i].Tag = Convert.ToInt32(items[0].ToString());
                        dgLast10.Rows[i].Cells[0].Value = items[1].ToString();
                        dgLast10.Rows[i].Cells[1].Value = items[2].ToString();
                        dgLast10.Rows[i].Cells[2].Value = String.Format(" R {0:n}", items[3]).Replace(".0", ".00");
                        dgLast10.Rows[i].Cells[3].Value = items[4].ToString();
                        dgLast10.Rows[i].Cells[4].Value = items[5].ToString();

                    }

                }
                catch (Exception ex)
                {
                    Util.showMessage(ex.Message,Color.Red);
                }
            }
            else
            {
                if (txtReprint.Text.Trim().Equals(""))
                {
                    Util.showMessage("No results found.", Color.Red);
                }
                else
                {
                    Util.showMessage("No results found. Check your reference number.", Color.Red);
                }
            }


        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateLastSales();
        }

        private void rdoFilterType0_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoFilterType0.Checked)
            {
                _filter_type = 0;
                txtReprint.Text = "";
                lblReprintSerialMeter.Visible = false;
                pnlRefInput.Visible = false;
            }
        }

        private void rdoFilterType1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoFilterType1.Checked)
            {
                _filter_type = 1;
                txtReprint.Text = "";
                txtReprint.Focus();
                lblReprintSerialMeter.Text = "Filter By Reference Number:";
                lblReprintSerialMeter.Visible = true;
                pnlRefInput.Visible = true;
            }
        }

        private void rdoFilterType2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoFilterType2.Checked)
            {
                _filter_type = 2;
                txtReprint.Text = "";
                txtReprint.Focus();
                lblReprintSerialMeter.Text = "Filter By Meter Number:";
                lblReprintSerialMeter.Visible = true;
                pnlRefInput.Visible = true;
            }
        }

        private void rdoFilterType3_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoFilterType3.Checked)
            {
                _filter_type = 7;
                txtReprint.Text = "";
                txtReprint.Focus();
                lblReprintSerialMeter.Text = "Filter By Reference Number:";
                lblReprintSerialMeter.Visible = true;
                pnlRefInput.Visible = true;
            }
        }

        private void btnSalesHistory_Click(object sender, EventArgs e)
        {
            frmSalesSearch frmSalesSearch = new frmSalesSearch();
            frmSalesSearch.ShowDialog();
        }

        private void btnMainClose_Click(object sender, EventArgs e)
        {

            this.Close();
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

      

      

    }
}

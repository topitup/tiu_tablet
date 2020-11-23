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
    public partial class frmSalesSearch : Form
    {
        public frmSalesSearch()
        {
            InitializeComponent();
        }



        private void frmSalesSearch_Load(object sender, EventArgs e)
        {

            cboVoucher.Items.Clear();

            ComboboxItem item_all = new ComboboxItem("All","0");
            cboVoucher.Items.Add(item_all);

            item_all = new ComboboxItem("Electricity","51");
            cboVoucher.Items.Add(item_all);

            item_all = null;

            cboVoucher.SelectedIndex = 0;

            int arr_id = -1;
            try
            {
                foreach (stockProvider sp in Util.stock_provider)
                {
                    arr_id++;
                    for (int x = 0; x < Util.stock_provider[arr_id].itemcount; x++)
                    {
                        ComboboxItem item = new ComboboxItem(Util.stock_provider[arr_id].item[x].item_desc, Util.stock_provider[arr_id].item[x].item_id.ToString());
                        cboVoucher.Items.Add(item);
                    }
                }
            }
            catch (Exception qperr)
            {
                MessageBox.Show("Error Loading Provider Items: " + qperr.Message);
            }

            cboStime.Items.Clear();
            cboEtime.Items.Clear();
            for (var time = new DateTime(2000, 1, 1, 0, 0, 0); time <= new DateTime(2000, 1, 1, 23, 0, 0); time = time.AddMinutes(15))
            {
                cboStime.Items.Add(time.ToString("HH:mm"));
                cboEtime.Items.Add(time.ToString("HH:mm"));
            }
            cboStime.Text = "09:00";
            cboEtime.Text = "12:00";

            cboSyear.Text = DateTime.Today.Year.ToString();
            cboEyear.Text = DateTime.Today.Year.ToString();

            cboSmonth.Text = DateTime.Today.ToString("MMMM");
            cboEmonth.Text = DateTime.Today.ToString("MMMM");

            cboSday.Text = DateTime.Today.Day.ToString();
            cboEday.Text = DateTime.Today.Day.ToString();

            for (int loop = DateTime.Today.Year - 1; loop <= DateTime.Today.Year; loop++)
            {
                cboSyear.Items.Add(loop.ToString());
                cboEyear.Items.Add(loop.ToString());
            }
            cboSyear.Text = DateTime.Today.ToString("yyyy");
            cboEyear.Text = DateTime.Today.ToString("yyyy");
        }



        private void btnSRClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSRFilter_Click(object sender, EventArgs e)
        {
            String sDate = cboSyear.Text + "-" + DateTime.ParseExact(cboSmonth.Text, "MMMM", System.Globalization.CultureInfo.CurrentCulture).Month.ToString().PadLeft(2, '0') + "-" + cboSday.Text.ToString().PadLeft(2, '0');
            String eDate = cboEyear.Text + "-" + DateTime.ParseExact(cboEmonth.Text, "MMMM", System.Globalization.CultureInfo.CurrentCulture).Month.ToString().PadLeft(2, '0') + "-" + cboEday.Text.ToString().PadLeft(2, '0');

            String service_provider_item_id = "0";

            try
            {
                service_provider_item_id = ((ComboboxItem)cboVoucher.SelectedItem).Value;
            }
            catch
            {
                service_provider_item_id = "0";
            }

            Util.showMessage("Searching Sales..." + Environment.NewLine + "(100 results max).", Color.White);

            getLastSalesSearch(sDate, cboStime.Text, eDate, cboEtime.Text, service_provider_item_id);

        }

        private void btnSRReprint_Click(object sender, EventArgs e)
        {
         
            int _reprint_uid = 0;

            try
            {
                DataGridViewRow row = grdSR.Rows[grdSR.CurrentCell.RowIndex];
                _reprint_uid = Convert.ToInt32(row.Tag);
            }
            catch
            {
                _reprint_uid = 0;
            }


            if (_reprint_uid == 0)
            {
                Util.showMessage("No voucher selected.", Color.Firebrick);
                return;
            }

            String ret = webService.getReprint(1, _reprint_uid.ToString());

            if (ret == "OK")
            {

                //lblSRMessage.Text = "Re-Printing Voucher.";

                if (globalVoucher.service_provider_item_id == 51)
                {
                    Web WebResponse = new Web(60000);
                    String htmlResponse = "";
                    htmlResponse = WebResponse.GetURL("/itron/electricity/vendGetReprint?lic=" + globalSettings.license_code + "&uid=" + globalVoucher.stock_uid + "&s=1&d=false");
                    WebResponse = null;
                    if (htmlResponse.IndexOf("<webreqerr>") > -1)
                    {
                        Util.showMessage(htmlResponse.GetStrBetweenTags("<webreqerr>", "</webreqerr>"), Color.Firebrick);
                    }
                    else if (htmlResponse.IndexOf("<err>") > -1)
                    {
                        Util.showMessage( htmlResponse.GetStrBetweenTags("<err>", "</err>"), Color.Firebrick);
                    }
                    else
                    {
                        Util.printText(Util.RemoveFirstLine(htmlResponse), false);
                    }
                }
                else
                {
                    globalVoucher.pin_number = Util.str_decrypt_pin(globalVoucher.pin_number_encryped);
                    globalVoucher.getArrayId();
                    Util.printVoucher();
                }
            }
            else
            {
                Util.showMessage("Could not Re-Printing Voucher.", Color.Firebrick);
            }
        }




        private void getLastSalesSearch(string sdate, string stime, string edate, string etime, string service_provider_item_id)
        {

            grdSR.Rows.Clear();

            String htmlResponse = webService.getLastSalesSearch(sdate, stime, edate, etime, service_provider_item_id);

            if (htmlResponse.IndexOf("<webreqerr>", 0) >= 0)
            {
                Util.showMessage(htmlResponse, Color.Firebrick);
            }
            else if (htmlResponse.IndexOf("<err>", 0) >= 0)
            {
                Util.showMessage(htmlResponse, Color.Firebrick);
            }
            else if (htmlResponse != "")
            {
                try
                {
                    string[] lines = htmlResponse.Split('\n');

                    for (int i = 0; i < lines.Length - 1; i++)
                    {
                        string[] items = lines[i].Split('^');

                        grdSR.Rows.Add();

                        grdSR.Rows[i].Tag = Convert.ToInt32(items[0].ToString());

                        grdSR.Rows[i].Cells[0].Value = items[1].ToString();
                        grdSR.Rows[i].Cells[1].Value = items[2].ToString();
                        grdSR.Rows[i].Cells[2].Value = String.Format(" R {0:n}", items[3]).Replace(".0", ".00");
                        grdSR.Rows[i].Cells[3].Value = items[4].ToString();
                        grdSR.Rows[i].Cells[4].Value = items[5].ToString();

                        //Resco.Controls.SmartGrid.Row r = new Resco.Controls.SmartGrid.Row(6);
                        //r.Height = 30;
                        //r[0] = " " + Convert.ToInt32(items[0].ToString());
                        //r[1] = " " + items[1].ToString();
                        //r[2] = " " + items[2].ToString();
                        //r[3] = String.Format(" R {0:n}", items[3]).Replace(".0", ".00");
                        //r[4] = " " + items[4].ToString();
                        //r[5] = " " + items[5].ToString();
                        //grdSR.Rows.Add(r);


                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

       

      


    }

    //public class ComboboxItem
    //{
    //    public string Text { get; set; }
    //    public string Value { get; set; }

    //    public override string ToString()
    //    {
    //        return Text;
    //    }
    //}


}

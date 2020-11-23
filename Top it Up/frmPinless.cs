using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace TopitUp
{
    public partial class frmPinless : Form
    {

        private Button[] btnItem = new Button[8];
        string service_provider_id = "";
        int provider_count = 0;

        public frmPinless()
        {
            InitializeComponent();
        }

        private void digitsOnly(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        //public class ItemInfo
        //{
        //    public string Name;
        //    public string Id;
        //    public bool Enabled;

        //    public override string ToString()
        //    {
        //        return this.Name;
        //    }
        //}





        private void frmPinless_Load(object sender, EventArgs e)
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

            this.txtCellNumber.KeyPress += new KeyPressEventHandler(this.digitsOnly);
            this.txtElecRand.KeyPress += new KeyPressEventHandler(this.digitsOnly);

            txtCellNumber.Focus();

            getProviderList();

            picTick.BringToFront();

            if (provider_count == 1) {
                btnItem[0].PerformClick();
                txtCellNumber.Focus();
            }

        }


        public void getProviderList()
        {

            string htmlResponse = "";

            //cboProvider.Items.Clear();

            try
            {

                Web WebResponse = new Web(10000, 1, "");
                htmlResponse = WebResponse.GetURL("/terminal/pinless/get-providers");
                WebResponse = null;

                if (htmlResponse.IndexOf("err>", 0) >= 0)
                {
                    pnlCapture.Visible = false;
                }
                else if (htmlResponse.Length > 0)
                {

                    JObject json = JObject.Parse(htmlResponse);
                    JArray a = (JArray)json["arr"];

                    int arrItemId = -1;
                    foreach (var item in a.Children())
                    {
                        provider_count++;
                        arrItemId++;
                        SetupNewItemButton(arrItemId, item["service_provider_desc"].ToString(), item["service_provider_id"].ToString());
                    }

                    pnlCapture.Visible = true;

                }

            }
            catch
            {
                //
            }

        }



        private void doItemAction_Click(object sender, EventArgs e)
        {
            Button btnClick = (Button)sender;

            service_provider_id = btnClick.Tag.ToString();

            picTick.Visible = true;
            picTick.Left = btnClick.Left + 135;

            switch (service_provider_id)
            {
                case "1": lblProvider.Text = "Vodacom"; break;
                case "2": lblProvider.Text = "MTN"; break;
                case "3": lblProvider.Text = "Cell C"; break;
                case "4": lblProvider.Text = "Virgin Mobile"; break;
                case "5": lblProvider.Text = "Telkom"; break;
                case "7": lblProvider.Text = "World Call"; break;
                case "10": lblProvider.Text = "Telkom Mobile"; break;
                case "11": lblProvider.Text = "Neotel"; break;
            }

            //voucherPanelShow(btnClick.Tag.ToString(), false);
        }

        private void SetupNewItemButton(int arrItemId, String btnText, String btnId)
        {

            try
            {

                btnItem[arrItemId] = new Button();
                btnItem[arrItemId].Parent = this.flowPnlProvider;

                btnItem[arrItemId].Click += new System.EventHandler(doItemAction_Click);
                btnItem[arrItemId].Bounds = new Rectangle(0, 0, 139, 88);

                btnItem[arrItemId].FlatStyle = FlatStyle.Flat;
                btnItem[arrItemId].FlatAppearance.BorderSize = 0;
                btnItem[arrItemId].FlatAppearance.MouseDownBackColor = Color.Transparent;
                btnItem[arrItemId].FlatAppearance.MouseOverBackColor = Color.Transparent;
                //btnItem[arrItemId].Padding = new Padding(0, 0, 0, 0);

                btnItem[arrItemId].Visible = true;

                btnItem[arrItemId].TabStop = false;
                btnItem[arrItemId].Cursor = Cursors.Hand;

                btnItem[arrItemId].Text = "";
                btnItem[arrItemId].Tag = btnId;

                btnItem[arrItemId].ForeColor = System.Drawing.Color.White;

                switch (btnId)
                {
                    case "1": btnItem[arrItemId].Image = global::TopitUp.Properties.Resources.prov1; break;
                    case "2": btnItem[arrItemId].Image = global::TopitUp.Properties.Resources.prov2; break;
                    case "3": btnItem[arrItemId].Image = global::TopitUp.Properties.Resources.prov3; break;
                    case "4": btnItem[arrItemId].Image = global::TopitUp.Properties.Resources.prov4; break;
                    case "5": btnItem[arrItemId].Image = global::TopitUp.Properties.Resources.prov5; break;
                    case "7": btnItem[arrItemId].Image = global::TopitUp.Properties.Resources.prov7; break;
                    case "10": btnItem[arrItemId].Image = global::TopitUp.Properties.Resources.prov10; break;
                    case "11": btnItem[arrItemId].Image = global::TopitUp.Properties.Resources.prov11; break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }











        private void btnClose_Click(object sender, EventArgs e)
        {

            this.Close();

        }



        private void btnOK_Click(object sender, EventArgs e)
        {

            txtCellNumber.Enabled = false;
            txtElecRand.Enabled = false;
            flowPnlProvider.Enabled = false;


            if (service_provider_id == "")
            {
                lblMessage.ForeColor = Color.Firebrick;
                lblMessage.Text = "Please select a provider.";
                txtCellNumber.Enabled = true;
                txtElecRand.Enabled = true;
                flowPnlProvider.Enabled = true;
                txtCellNumber.Focus();
                return;
            }

            if (txtCellNumber.Text == "" || txtCellNumber.Text.Length < 10)
            {
                lblMessage.ForeColor = Color.Firebrick;
                lblMessage.Text = "Please enter a correct Cell number.";
                txtCellNumber.Enabled = true;
                txtElecRand.Enabled = true;
                flowPnlProvider.Enabled = true;
                txtCellNumber.Focus();
                return;
            }

            if (txtElecRand.Text == "")
            {
                lblMessage.ForeColor = Color.Firebrick;
                lblMessage.Text = "Please enter the pinless top up amount.";
                txtCellNumber.Enabled = true;
                txtElecRand.Enabled = true;
                flowPnlProvider.Enabled = true;
                txtElecRand.Focus();
                return;
            }

            string value = txtElecRand.Text.Replace(".","");
                
            if (Convert.ToInt32(value) > 100000)
            {
                lblMessage.ForeColor = Color.Firebrick;
                lblMessage.Text = "Amount entered is too high.";
                txtCellNumber.Enabled = true;
                txtElecRand.Enabled = true;
                flowPnlProvider.Enabled = true;
                txtElecRand.Focus();
                return;
            }

            
            if (btnOK.Text == "OK")
            {

                lblMessage.Text = "";
                lblMessage.Refresh();

                lblRefundWarning.Visible = true;

                btnOK.Text = "Confirm";

                return;
            }

            if (btnOK.Text == "Confirm")
            {

                lblMessage.Text = "";
                lblMessage.Refresh();

                btnOK.Text = "Requesting...";
                btnOK.Enabled = false;
                btnOK.Refresh();

                btnClose.Enabled = false;
                btnClose.Refresh();

                string htmlResponse = "";

                Web WebResponse = new Web(60000);
                htmlResponse = WebResponse.GetURL("/terminal/pinless/do-topup?cell=" + txtCellNumber.Text + "&v=" + value);
                WebResponse = null;

                lblRefundWarning.Visible = false;

                if (htmlResponse.IndexOf("<webreqerr>") > -1)
                {
                    lblMessage.ForeColor = Color.Firebrick;
                    lblMessage.TextAlign = ContentAlignment.TopCenter;
                    lblMessage.Text = htmlResponse.GetStrBetweenTags("<webreqerr>", "</webreqerr>");
                    btnOK.Enabled = true;
                    btnClose.Enabled = true;

                    txtElecRand.Enabled = true;
                    flowPnlProvider.Enabled = true;
                    txtCellNumber.Enabled = true;

                    btnOK.Text = "OK";
                }
                else if (htmlResponse.IndexOf("<err>") > -1)
                {
                    lblMessage.ForeColor = Color.Firebrick;
                    lblMessage.TextAlign = ContentAlignment.TopCenter;
                    lblMessage.Text = htmlResponse.GetStrBetweenTags("<err>", "</err>");
                    btnOK.Enabled = true;
                    btnClose.Enabled = true;

                    txtElecRand.Enabled = true;
                    flowPnlProvider.Enabled = true;
                    txtCellNumber.Enabled = true;

                    btnOK.Text = "OK";
                }
                else
                {

                    lblMessage.ForeColor = Color.Green;
                    lblMessage.TextAlign = ContentAlignment.TopCenter;
                    lblMessage.Text = "Complete..." + Environment.NewLine +"Cellphone should recieve pinless airtime shortly.";

                    btnOK.Visible = false;
                    btnClose.Enabled = true;

                    if (globalSettings.gen_print_pinless_slip == "1") 
                    {

                        try
                        {
                            Newtonsoft.Json.Linq.JObject json = Newtonsoft.Json.Linq.JObject.Parse(htmlResponse);

                            finBalance.populateBalanceFromJson(json);

                            string print_data = "";
                            if (!String.IsNullOrEmpty((string)json["print_data"]))
                            {
                                byte[] data = Convert.FromBase64String((string)json["print_data"]);
                                print_data = Encoding.UTF8.GetString(data);
                            }

                            Util.printText(print_data, false);

                        }
                        catch (Exception ex)
                        {
                            Util.showMessage(ex.Message, Color.Red);
                        }

                    }

                }


            }


        }


        private void txtElecRand_Leave(object sender, EventArgs e)
        {
            double value;

            if (double.TryParse(txtElecRand.Text, out value))
            {
                txtElecRand.Text = String.Format("{0:0.00}", value);
            }
            else
            {
                // Some code to handle the bad input (not parsable to double)
            }
        }

     
    

    }
}
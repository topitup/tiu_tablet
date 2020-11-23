using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TopitUp
{
    public partial class RICA : Form
    {

        public RICA()
        {
            InitializeComponent();
        }

        private void frmRICA_Load(object sender, EventArgs e)
        {


            this.SuspendLayout();

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

            btnProv3.Visible = false;
            btnProv2.Visible = false;
            btnProv10.Visible = false;
            btnProv1.Visible = false;

         
            this.txtSIM4.KeyPress += new KeyPressEventHandler(this.digitsOnly);

            this.txtTel1.KeyPress += new KeyPressEventHandler(this.digitsOnly);
            this.txtTel2.KeyPress += new KeyPressEventHandler(this.digitsOnly);

            this.txtIDNumber.GotFocus += new System.EventHandler(this.txtBox_GotFocus);
            this.txtIDNumber.KeyPress += new KeyPressEventHandler(this.digitsOnly);

            this.txtCell1.KeyPress += new KeyPressEventHandler(this.digitsOnly);
            this.txtCell2.KeyPress += new KeyPressEventHandler(this.digitsOnly);
            this.txtCell3.KeyPress += new KeyPressEventHandler(this.digitsOnly);
            this.txtCell4.KeyPress += new KeyPressEventHandler(this.digitsOnly);
            this.txtCell5.KeyPress += new KeyPressEventHandler(this.digitsOnly);
            
            this.txtAddrCode.KeyPress += new KeyPressEventHandler(this.digitsOnly);

            this.txtFName.KeyPress += new KeyPressEventHandler(this.alphaOnly);
            this.txtLName.KeyPress += new KeyPressEventHandler(this.alphaOnly);

            this.txtCell1.Focus();

            pnl0.Left = 0; pnl0.Top = 0;
            pnl1.Left = 0; pnl1.Top = 0;
            pnl2.Left = 0; pnl2.Top = 0;
            pnl3.Left = 0; pnl3.Top = 0;
            pnlProcess.Left = 0; pnlProcess.Top = 0;

            pnl0.BringToFront();

            //pnl0.Dock = DockStyle.Fill;
            //wbInfo.Dock = DockStyle.Fill;

            ////String ricaHTML = "";
            ////ricaHTML = globalSettings.app_path;
            ////ricaHTML = ricaHTML.Replace("C:\\", "file:///");
            ////ricaHTML = ricaHTML.Replace("\\", "/");
            ////file:///NandFlash/vs/html/ricaStart.htm

            //this.wbInfo.Url = new Uri(globalSettings.app_path + @"/html/ricaStart.htm");

            //btnClose.BringToFront();

            this.ResumeLayout();

            tmr_delayed_load.Enabled = true;

        }

        private void getRicaProducts()
        {

            string htmlResponse = "";
            string products_rica = "0000";

            try
            {

                Web WebResponse = new Web(30000, 1, "");
                htmlResponse = WebResponse.GetURL("/terminal/general/get-rica-products");
                WebResponse = null;

                if (htmlResponse.IndexOf("err>", 0) >= 0)
                {
                    //
                }
                else if (htmlResponse.Length > 0)
                {

                    Newtonsoft.Json.Linq.JObject json = Newtonsoft.Json.Linq.JObject.Parse(htmlResponse);
                    products_rica = (string)json["products_rica"];

                }

            }
            catch
            {
                //
            }

            if (products_rica[0] == '1') btnProv3.Visible = true;
            if (products_rica[1] == '1') btnProv2.Visible = true;
            if (products_rica[2] == '1') btnProv10.Visible = true;
            if (products_rica[3] == '1') btnProv1.Visible = true;

            Util.showWait(false);

        }



        private void alphaOnly(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

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

        public static bool IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }


        //private void btnClick_Click(object sender, EventArgs e)
        //{
        //    Button btn = (Resco.Controls.OutlookControls.ImageButton)sender;
        //    LoginKeyLogic(btn.TextDefault);
        //}


        //private void LoginKeyLogic(string Key)
        //{
        //    String doText = Key;

        //    if (Key == "Space")
        //    {
        //        doText = " ";
        //    }

            

        //    try
        //    {
        //        if (isText)
        //        {

        //            if (currentTextbox.Name == "txtCell1")
        //            {
        //                if (currentTextbox.Text.Length == 4)
        //                {
        //                    txtCell2.Text = "";
        //                    txtCell2.Focus();
        //                    currentTextbox = txtCell2;
        //                }
        //            }
        //            if (currentTextbox.Name == "txtCell2")
        //            {
        //                if (currentTextbox.Text.Length == 4)
        //                {
        //                    txtCell3.Text = "";
        //                    txtCell3.Focus();
        //                    currentTextbox = txtCell3;
        //                }
        //            }
        //            if (currentTextbox.Name == "txtCell3")
        //            {
        //                if (currentTextbox.Text.Length == 4)
        //                {
        //                    txtCell4.Text = "";
        //                    txtCell4.Focus();
        //                    currentTextbox = txtCell4;
        //                }
        //            }
        //            if (currentTextbox.Name == "txtCell4")
        //            {
        //                if (currentTextbox.Text.Length == 4)
        //                {
        //                    txtCell5.Text = "";
        //                    txtCell5.Focus();
        //                    currentTextbox = txtCell5;
        //                }
        //            }

        //            currentTextbox.Text += doText;
        //            if (currentTextbox.Text.Length > 0)
        //            {
        //                currentTextbox.Select(currentTextbox.Text.Length, currentTextbox.Text.Length);
        //                currentTextbox.ScrollToCaret();
        //            }


                    


        //        }
        //        else
        //        {

        //            if (dropdown_changed)
        //            {
        //                currentCbo.Text = "";
        //                dropdown_changed = false;
        //            }

        //            currentCbo.Text += doText;
        //            //if (currentCbo.Text.Length > 0)
        //            //{
        //            //    currentCbo.Select(currentCbo.Text.Length, currentCbo.Text.Length);
                        
        //            //    currentCbo.ScrollToCaret();
        //            //}
        //        }
        //    }
        //    catch { }
        //}

       
        bool isText = true;
        TextBox currentTextbox;
        private void txtBox_GotFocus(object sender, EventArgs e)
        {
            isText = true;
            currentTextbox = (TextBox)sender;
        }

        ComboBox currentCbo;
        private void cboBox_GotFocus(object sender, EventArgs e)
        {
            dropdown_changed = true;
            isText = false;
            currentCbo = (ComboBox)sender;
        }

        bool dropdown_changed = false;
        private void txtNationality_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropdown_changed = true;
        }

        private void txtCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropdown_changed = true;
        }


        int Step = 0;

        private void btnNext_Click(object sender, EventArgs e)
        {



            /* Do Checks */
            if (Step == 1)
            {

                if (txtSIM4.Text.Trim() == "" || txtSIM4.Text.Trim().Length < 4)
                {
                    label25.Text = "Cellular Information - Please complete all * fields";
                    label5.ForeColor = Color.Red;
                    setTarget(txtSIM4);
                    return;
                }

                String register_number = txtCell1.Text.Trim() + txtCell2.Text.Trim() + txtCell3.Text.Trim() + txtCell4.Text.Trim() + txtCell5.Text.Trim();
                string SubString = register_number.Substring(register_number.Length - 4);

                if (!SubString.Equals(txtSIM4.Text.Trim()))
                {
                    label25.Text = "Cellular Information - Please confirm last 4 digits";
                    label5.ForeColor = Color.Red;
                    setTarget(txtSIM4);
                    return;
                }
            
            }


            if (Step == 2)
            {

                if (txtIDNumber.Text.Trim() == "")
                {
                    label26.Text = "Personal Information - Please complete all * fields";
                    label7.ForeColor = Color.Red;
                    setTarget(txtIDNumber);
                    return;
                }


                if (rdoIDPassport.Checked) {
                    if (!IsNumeric(txtIDNumber.Text.Trim()))
                    {
                        label26.Text = "Personal Information - Incorrect SA ID Number";
                        label7.ForeColor = Color.Red;
                        setTarget(txtIDNumber);
                        return;
                    }

                    if (txtIDNumber.Text.Trim().Length < 13)
                    {
                        label26.Text = "Personal Information - Incorrect SA ID Number";
                        label7.ForeColor = Color.Red;
                        setTarget(txtIDNumber);
                        return;
                    }
                }
                

                if (txtFName.Text.Trim() == "")
                {
                    label26.Text = "Personal Information - Please complete all * fields";
                    label9.ForeColor = Color.Red;
                    setTarget(txtFName);
                    return;
                }
                if (txtLName.Text.Trim() == "")
                {
                    label26.Text = "Personal Information - Please complete all * fields";
                    label10.ForeColor = Color.Red;
                    setTarget(txtLName);
                    return;
                }
                if (txtNationality.Text.Trim() == "")
                {
                    label26.Text = "Personal Information - Please complete all * fields";
                    label8.ForeColor = Color.Red;
                    return;
                }
                
            }
            if (Step == 3)
            {
                if (txtAddr1.Text.Trim() == "")
                {
                    label23.Text = "Residential Street Address (Individual) - Please complete all * fields";
                    label16.ForeColor = Color.Red;
                    setTarget(txtAddr1);
                    return;
                }
                if (txtAddrCity.Text.Trim() == "")
                {
                    label23.Text = "Residential Street Address (Individual) - Please complete all * fields";
                    label20.ForeColor = Color.Red;
                    setTarget(txtAddrCity);
                    return;
                }
                if (txtAddrSuburb.Text.Trim() == "")
                {
                    label23.Text = "Residential Street Address (Individual) - Please complete all * fields";
                    label21.ForeColor = Color.Red;
                    setTarget(txtAddrSuburb);
                    return;
                }
                if (txtAddrCode.Text.Trim() == "")
                {
                    label23.Text = "Residential Street Address (Individual) - Please complete all * fields";
                    label21.ForeColor = Color.Red;
                    setTarget(txtAddrCode);
                    return;
                }
                

                if (txtCountry.Text.Trim() == "")
                {
                    label23.Text = "Residential Street Address (Individual) - Please complete all * fields";
                    label22.ForeColor = Color.Red;
                    return;
                }


                if (!chkConfirm.Checked)
                {
                    label23.Text = "Residential Street Address (Individual) - Please complete all * fields";
                    chkConfirm.ForeColor = Color.Red;
                    return;
                }

            }


            if (btnNext.Text == "Process")
            //if (Step == 3)
            {

                lblProcessingError.Text = "";

                btnNext.Enabled = false;
                btnMainClose.Enabled = false;
                

                lblStep.Visible = false;

                pnlProcess.BringToFront();
                pnlProcess.Show();
                btnBack.Visible = false;

                Application.DoEvents();

                String register_type = "1";
                //if (rdoRegisterWith1.Checked)
                //{
                //    register_type = "2";
                //}
                String register_number = txtCell1.Text.Trim() + txtCell2.Text.Trim() + txtCell3.Text.Trim() + txtCell4.Text.Trim() + txtCell5.Text.Trim();
                String register_digits = txtSIM4.Text.Trim();

                String id_type = "1";
                if (rdoIDPassport2.Checked)
                {
                    register_type = "2";
                }

                String id_number = txtIDNumber.Text.Trim();
                String fname = txtFName.Text.Trim();
                String lname = txtLName.Text.Trim();
                String nationality = txtNationality.Text.Trim();
                String contact_number = txtTel1.Text.Trim() + txtTel2.Text.Trim();
                String addr1 = txtAddr1.Text.Trim();
                String addr2 = txtAddr2.Text.Trim();
                String city = txtAddrCity.Text.Trim();
                String suburb = txtAddrSuburb.Text.Trim();
                String suburd_code = txtAddrCode.Text.Trim();
                String country = txtCountry.Text.Trim();
                
                if (!cboStreetDesc.Text.Trim().Equals(""))
                {
                    addr1 = addr1 + " " + cboStreetDesc.Text.Trim();
                }

                String confirm = "0";
                if (chkConfirm.Checked)
                {
                    confirm = "1";
                }

                String res = webService.saveRICA(service_provider_id, register_type, register_number, register_digits, id_type, id_number, fname, lname, nationality,
                    contact_number, addr1, addr2, city, suburb, suburd_code,country, confirm);

                if (res.IndexOf("err>") == -1)
                {

                    btnNext.Visible = false;
                    lblProcessingError.ForeColor = Color.Black;
                    lblProcessingError.Show();
                    lblProcessingError.Text = "Your RICA registration has been succesfully submitted and is in progress. Please note that a SIM card registration may take between 1 to 24 hours - network dependent.";

                    btnMainClose.Enabled = true;

                    Util.printText(res, false);

                }
                else
                {
                    lblProcessingError.Text = "There was an error submitting your RICA request." + Environment.NewLine + res.GetStrBetweenTags("<err>", "</err>");
                    lblProcessingError.Show();
                    btnNext.Enabled = true;
                    btnMainClose.Enabled = true;
                }

               

                return;
            }

            Step++;
            if (Step == 4)
            {
                Step = 3;
            }

            if (Step > 1)
            {
                btnBack.Visible = true;
            }

            if (Step == 2)
            {
                lblStep.Text = "Step 2 / 3";
                pnl2.BringToFront();
            }

            if (Step == 3)
            {
                lblStep.Text = "Step 3 / 3";
                pnl3.BringToFront();
                btnNext.Text = "Process";
            }


        }


        private void setTarget(TextBox txtField)
        {
            txtField.Focus();
            currentTextbox = txtField;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            btnNext.Text = "Next";

            Step--;
            if (Step == 0)
            {
                lblStep.Text = "Step 1 / 3";
                pnl0.Visible = true;
                pnl0.BringToFront();
                return;
            }

            if (Step == 1)
            {
                lblStep.Text = "Step 1 / 3";
                pnl1.BringToFront();
                btnBack.Visible = false;
            }

            if (Step == 2)
            {
                lblStep.Text = "Step 2 / 3";
                pnl2.BringToFront();
            }

        }

       
        String service_provider_id = ""; 

        private void btnProv3_Click(object sender, EventArgs e)
        {
            service_provider_id = "3";
            picTick.Left = 150;
            picTick.Visible = true;

            txtCell4.Visible = true;
            txtCell5.Visible = true;
            txtCell3.MaxLength = 4;
            txtCell5.MaxLength = 3;

            pnlSimNumber.Visible = true;
            txtCell1.Focus();

        }


        private void btnProv2_Click(object sender, EventArgs e)
        {
            service_provider_id = "2";
            picTick.Left = 340;
            picTick.Visible = true;

            txtCell1.Text = "";
            txtCell2.Text = "";
            txtCell3.Text = "";
            txtCell4.Text = "";
            txtCell5.Text = "";

            txtCell4.Visible = false;
            txtCell5.Visible = false;
            txtCell3.MaxLength = 2;

            pnlSimNumber.Visible = true;
            txtCell1.Focus();

        }

        private void btnProv10_Click(object sender, EventArgs e)
        {
            service_provider_id = "10";
            picTick.Left = 530;
            picTick.Visible = true;

            txtCell4.Visible = true;
            txtCell5.Visible = true;
            txtCell3.MaxLength = 4;
            txtCell5.MaxLength = 4;

            pnlSimNumber.Visible = true;
            txtCell1.Focus();

        }

        private void btnProv1_Click(object sender, EventArgs e)
        {
            service_provider_id = "1";
            picTick.Left = 715;
            picTick.Visible = true;

            txtCell4.Visible = true;
            txtCell5.Visible = true;
            txtCell3.MaxLength = 4;
            txtCell5.MaxLength = 4;

            pnlSimNumber.Visible = true;
            txtCell1.Focus();

        }

        private void rdoIDPassport2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoIDPassport2.Checked) {
                this.txtIDNumber.KeyPress -= new KeyPressEventHandler(this.digitsOnly);
                txtIDNumber.MaxLength = 25;
            }
        }

        private void rdoIDPassport_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoIDPassport.Checked)
            {
                this.txtIDNumber.KeyPress += new KeyPressEventHandler(this.digitsOnly);
                txtIDNumber.MaxLength = 13;
            }

        }




        private void txtCell1_TextChanged(object sender, EventArgs e)
        {

            if (txtCell1.Text.Length == 4)
            {
                txtCell2.Text = "";
                txtCell2.Focus();
                currentTextbox = txtCell2;
            }
        }

        private void txtCell2_TextChanged(object sender, EventArgs e)
        {


            if (txtCell2.Text.Length == 4)
            {
                txtCell3.Text = "";
                txtCell3.Focus();
                currentTextbox = txtCell3;
            }
        }

        private void txtCell3_TextChanged(object sender, EventArgs e)
        {

            if (service_provider_id == "2")
            {
                return;
            }

            if (txtCell3.Text.Length == 4)
            {
                txtCell4.Text = "";
                txtCell4.Focus();
                currentTextbox = txtCell4;
            }
        }

        private void txtCell4_TextChanged(object sender, EventArgs e)
        {
            if (txtCell4.Text.Length == 4)
            {
                txtCell5.Text = "";
                txtCell5.Focus();
                currentTextbox = txtCell5;
            }
        }

        private void btnConfirmReference_Click(object sender, EventArgs e)
        {

            if (service_provider_id == "")
            {
                Util.showMessage("Please select network!", Color.Red);
                return;
            }


            String register_number = txtCell1.Text.Trim() + txtCell2.Text.Trim() + txtCell3.Text.Trim() + txtCell4.Text.Trim() + txtCell5.Text.Trim();

            int min_length = 20;
            if (service_provider_id == "2")
            {
                min_length = 10;
            }
            if (service_provider_id == "3")
            {
                min_length = 19;
            }

            if (register_number.Length < min_length)
            {
                Util.showMessage("SIM/Starter Pack number too short!", Color.Red);
                setTarget(txtCell1);
                return;
            }


            //globalSettings.pos_user_id = "532";

            String res = webService.checkRICA(service_provider_id, register_number);

            if (res.IndexOf("<err>") == -1)
            {

                if (res.GetStrBetweenTags("<res>", "</res>") == "2")
                {
                    Util.showMessage(res.GetStrBetweenTags("<msg>", "</msg>"), Color.White);

                    lblRefNumber.Text = register_number;
                    if (service_provider_id == "2")
                    {
                        picProvider.BackgroundImage = global::TopitUp.Properties.Resources.prov2;
                    }
                    if (service_provider_id == "3")
                    {
                        picProvider.BackgroundImage = global::TopitUp.Properties.Resources.prov3;
                    }
                    if (service_provider_id == "10")
                    {
                        picProvider.BackgroundImage = global::TopitUp.Properties.Resources.prov10;
                    }

                    this.SuspendLayout();
                    Step = 1;
                    pnl1.BringToFront();
                    pnl0.Hide();
                    txtSIM4.Focus();
                    this.ResumeLayout();

                }
                else
                {
                    Util.showMessage(res.GetStrBetweenTags("<msg>", "</msg>"), Color.Red);
                    return;
                }


            }
            else
            {
                Util.showMessage(res.GetStrBetweenTags("<err>", "</err>"), Color.Red);
                return;
            }


        }

        private void btnRicaClear_Click(object sender, EventArgs e)
        {

            txtCell1.Text = "";
            txtCell2.Text = "";
            txtCell3.Text = "";
            txtCell4.Text = "";
            txtCell5.Text = "";
            txtCell1.Focus();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateRICAList();
        }



        private void PopulateRICAList()
        {

            dgRICAList.Rows.Clear();

            String htmlResponse = "";

            Web WebResponse = new Web(45000, 1, "");
            htmlResponse = WebResponse.GetURL("/terminal/rica/get-list");
            WebResponse = null;

            if (htmlResponse.IndexOf("err>") > 0)
            {
                Util.showMessage(htmlResponse, Color.Red);
            }
            else if (htmlResponse != "")
            {
                try
                {
                    string[] lines = htmlResponse.Split('\n');

                    for (int i = 0; i < lines.Length - 1; i++)
                    {
                        string[] items = lines[i].Split('^');

                        dgRICAList.Rows.Add();

                        //dgRICAList.Rows[i].Tag = Convert.ToInt32(items[0].ToString());

                        dgRICAList.Rows[i].Cells[0].Value = items[0].ToString();
                        dgRICAList.Rows[i].Cells[1].Value = items[1].ToString();
                        dgRICAList.Rows[i].Cells[2].Value = items[2].ToString();
                        dgRICAList.Rows[i].Cells[3].Value = items[3].ToString();
                        dgRICAList.Rows[i].Cells[4].Value = items[4].ToString();
                      
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }

        }

      

        private void tabRICA_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabRICA.SelectedIndex == 1)
            {
                PopulateRICAList();
            }

        }



        private void RICA_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Step == 0)
            {

                if (txtCell1.Focused || txtCell2.Focused || txtCell3.Focused || txtCell4.Focused || txtCell5.Focused) return;

                switch (e.KeyChar)
                {
                    case (char)Keys.D1: btnProv3.PerformClick(); break;
                    case (char)Keys.D2: btnProv2.PerformClick(); break;
                    case (char)Keys.D3: btnProv10.PerformClick(); break;
                    case (char)Keys.D4: btnProv1.PerformClick(); break;
                }
                return;

            }

        }

        //private void RICA_KeyUp(object sender, KeyEventArgs e)
        //{

        //    if (e.KeyCode == Keys.Escape)
        //    {

        //        btnMainClose.PerformClick();
        //        return;
        //    }

        //    if (Step == 0)
        //    {
        //        if (e.KeyCode == Keys.Enter)
        //        {
        //            btnConfirmReference.PerformClick();
        //            return;
        //        }
        //    }

        //    if (Step > 0)
        //    {
        //        if (e.KeyCode == Keys.Enter)
        //        {
        //            btnNext.PerformClick();
        //            return;
        //        }
        //    }


        //}

        private void btnMainClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tmr_delayed_load_Tick(object sender, EventArgs e)
        {

            tmr_delayed_load.Enabled = false;
            getRicaProducts();

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
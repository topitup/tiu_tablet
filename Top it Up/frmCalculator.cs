using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopitUp
{
    public partial class frmCalculator : Form
    {

        public frmCalculator()
        {

            Util.SuspendDrawing(this);

            InitializeComponent();
        }

        private void frmCalculator_Load(object sender, EventArgs e)
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

            try
            {
                PrivateFontCollection pfc = new PrivateFontCollection();
                pfc.AddFontFile(@"C:\topitup\fonts\digital-7.ttf");
                txtInput.Font = new Font(pfc.Families[0], 60, FontStyle.Regular, GraphicsUnit.Pixel);

                Console.WriteLine(pfc.Families[0].Name);

            }
            catch 
            {
                //
            }

            this.Activate();

            Util.showWait(false);

            Util.ResumeDrawing(this);

        }

      
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private double resultValue = 0;
        private bool isOperationPerformed = false;
        private string operationPerformed = string.Empty;

        private void digit_Click(object sender, EventArgs e)
        {

            if (isOperationPerformed) txtInput.Text= "";

            isOperationPerformed = false;
            Button btn = (Button)sender;

            if (btn.Text.Equals("."))
            {
                if (!txtInput.Text.Contains(".")) txtInput.Text += btn.Text;
            }
            else
            {
                txtInput.Text += btn.Text;
            }


        }

      

        private void operator_Click(object sender, System.EventArgs e)
        {

            //if (txtInput.Text.Replace("0","").Trim().Length == 0) return;

            Button btn = (Button)sender;

            if (resultValue != 0)
            {
                calculateTotals();
                operationPerformed = btn.Text;
                lblHistory.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = btn.Text;
                resultValue = Double.Parse(txtInput.Text, CultureInfo.InvariantCulture);
                lblHistory.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }

        }

        private void cmdEqual_Click(object sender, System.EventArgs e)
        {

            calculateTotals();

            isOperationPerformed = true;
            resultValue = 0;

        }


        private void cmdClearEntry_Click(object sender, System.EventArgs e)
        {
            txtInput.Text = "0";
        }

        private void cmdClearAll_Click(object sender, System.EventArgs e)
        {
            txtInput.Text = "0";
            resultValue = 0;
            lblHistory.Text = "";
        }

        private void cmdBackspace_Click(object sender, System.EventArgs e)
        {
            int loc;
            String original = txtInput.Text;
            loc = txtInput.Text.Length;

            try
            {
                txtInput.Text = txtInput.Text.Remove(loc - 1, 1);
            }
            catch
            {
                txtInput.Text = original;
            }
            
        }





        private void calculateTotals()
        {

            Double answer = 0;
            if (txtInput.Text.Length == 0) txtInput.Text = "0";

            switch (operationPerformed)
            {
                case "+":
                    answer = resultValue + Double.Parse(txtInput.Text, CultureInfo.InvariantCulture);
                    break;
                case "-":
                    answer = resultValue - Double.Parse(txtInput.Text, CultureInfo.InvariantCulture);
                    break;
                case "/":
                    answer = resultValue / Double.Parse(txtInput.Text, CultureInfo.InvariantCulture);
                    break;
                case "*":
                    answer = resultValue * Double.Parse(txtInput.Text, CultureInfo.InvariantCulture);
                    break;
                case "x^":
                    answer = System.Math.Pow(resultValue, Double.Parse(txtInput.Text, CultureInfo.InvariantCulture));
                    break;
            }

            try
            {
                txtInput.Text = answer.ToString();
                resultValue = Double.Parse(txtInput.Text, CultureInfo.InvariantCulture);
            }
            catch
            {
                Util.showMessage("Error with result.",Color.Red);
                txtInput.Text = "0";
                resultValue = 0;
            }
            
            resultValue = Double.Parse(txtInput.Text, CultureInfo.InvariantCulture);
            lblHistory.Text = "";

        }


        private void txtInput_TextChanged(object sender, EventArgs e)
        {

            String str = txtInput.Text;

            str = str.Replace(",", ".");

            if (str.Equals("-")) str = "0";
            if (str.StartsWith(".")) str = "0" + str;

            if (str.Length > 1 && !str.StartsWith("0.")) str = str.TrimStart('0');
            if (str.Length == 0) str = "0";

            try { 
                txtInput.Text = str;
            } catch { 
                //
            }

        }

        private void btnPercent_Click(object sender, EventArgs e)
        {

            double answer = 0;
            double tmpValue;

            try
            {

                tmpValue = System.Double.Parse(txtInput.Text, CultureInfo.InvariantCulture);

                switch (operationPerformed)
                {
                    case "+":
                        answer = resultValue*((tmpValue/100) + 1);
                        break;
                    case "-":
                        answer = resultValue*(1 - ((tmpValue/100) + 1));
                        break;
                    default:
                        return;
                }
            }
            catch
            {
                //
            }

            try
            {
                txtInput.Text = answer.ToString();
            }
            catch
            {
                txtInput.Text = "0";
            }

            isOperationPerformed = true;
            resultValue = 0;

        }

        private void btnVatAdd_Click(object sender, EventArgs e)
        {
            try
            {
                resultValue = Double.Parse(txtInput.Text, CultureInfo.InvariantCulture)*1.15;
                txtInput.Text = resultValue.ToString();
                isOperationPerformed = true;
            }
            catch
            {
                resultValue = 0;
                txtInput.Text = "0";
                isOperationPerformed = true;
            }

        }

        private void btnVatSubtract_Click(object sender, EventArgs e)
        {
            try
            {
                resultValue = Double.Parse(txtInput.Text, CultureInfo.InvariantCulture)/1.15;
                txtInput.Text = resultValue.ToString();
                isOperationPerformed = true;
            }
            catch
            {
                resultValue = 0;
                txtInput.Text = "0";
                isOperationPerformed = true;
            }
        }



    }
}

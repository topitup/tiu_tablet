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
    public partial class frmPrint : Form
    {


        Form centerWrapper = new Form();

        public frmPrint()
        {
            InitializeComponent();
        }


        public String toPrint = "";

        private void frmPrintSlip_Load(object sender, EventArgs e)
        {


            if (globalSettings.allow_screen_resize == "0")
            {
                this.Left = 0;
                this.Width = Screen.PrimaryScreen.Bounds.Width;
                this.Top = 0;
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
                centerWrapper.Top = this.pnlMainWrap.Top;
                centerWrapper.Left = this.pnlMainWrap.Left;
                centerWrapper.Width = this.pnlMainWrap.Width;
                centerWrapper.Height = this.pnlMainWrap.Height;
            }
            else
            {
                centerWrapper.Top = this.Top + this.pnlMainWrap.Top;
                centerWrapper.Left = this.Left + this.pnlMainWrap.Left;
                centerWrapper.Width = this.pnlMainWrap.Width;
                centerWrapper.Height = this.pnlMainWrap.Height;
            }


            this.AddOwnedForm(centerWrapper);

            this.pnlMainWrap.Parent = centerWrapper;
            this.pnlMainWrap.Top = 0;
            this.pnlMainWrap.Left = 0;

            centerWrapper.Show();

            doDocumentPrint();


        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            Util.printText(toPrint, true);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void doDocumentPrint()
        {


            String html = "<div style=\"font-family:monospace;\">";
            int printSize = 0;

            if (toPrint.Length > 0)
            {

                string[] toPrintX = new string[1];
                try
                {
                    if (toPrint != "")
                    {

                        string[] toPrintArr = toPrint.Split("\n".ToCharArray());
                        foreach (string s in toPrintArr)
                        {
                            if (s.Trim().Length > 1)
                            {
                                printSize = 1;
                                try
                                {
                                    printSize = int.Parse(s[0].ToString());
                                }
                                catch { }
                                toPrintX[0] = s.Remove(0, 1);

                                if (printSize > 1)
                                {
                                    html += "<strong style=\"font-size:1.6em;\">";
                                }

                                html += toPrintX[0].Replace(" ", "&nbsp;") + "<br/>";

                                if (printSize > 1)
                                {
                                    html += "</strong>";
                                }

                            }
                            else
                            {
                                html += "<br/>";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }



            html += "</div>";

            wbSlip.DocumentText = html;
        }


    }
}

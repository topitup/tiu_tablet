using System;
using System.Windows.Forms;

namespace TopitUp
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {

            InitializeComponent();

            if (globalSettings.allow_screen_resize == "1")
            {
                this.WindowState = FormWindowState.Normal;
            }

            rchTopItUpProperty.Rtf = @"{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Tahoma;}{\f1\fnil\fcharset0 Calibri;}}{\colortbl ;\red229\green229\blue229;\red204\green204\blue204;}{\*\generator Riched20 10.0.10586}\viewkind4\uc1 \pard\sa200\sl276\slmult1\qc\cf1\f0\fs36\lang9 This device is, and will remain the sole and exclusive\par property of Top it Up.\cf0\par \par\cf2\f1\fs22 Top it Up holds full ownership rights in terms of the data and/or information contained thereon.\par Any tampering, manipulation or removal of the hardware & software of this device without the\par prior written authorisation of Top it Up is strictly forbidden and will result in immediate legal action.\par}";
        }


        public void doUpdate(String update_text)
        {

            try
            {
                lblStatus.Invoke((MethodInvoker) delegate()
                {
                    lblStatus.Text = update_text;
                    lblStatus.Refresh();
                });
            }
            catch
            {
                //
            }

        }


       
    }
}

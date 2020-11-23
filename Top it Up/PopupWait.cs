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
    public partial class PopupWait : Form
    {
        public PopupWait()
        {
            InitializeComponent();
        }

        private void PopupWait_Load(object sender, EventArgs e)
        {
            this.Left = 0;
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Top = (Screen.PrimaryScreen.Bounds.Height - 170) / 2;
            this.Height = 170;
            this.Opacity = .70;
        }


        public void setColor(Color c)
        {
            lblCaption.ForeColor = c;
        }

        public void setCaption(String caption)
        {
            lblCaption.Text = caption;
        }


    }
}

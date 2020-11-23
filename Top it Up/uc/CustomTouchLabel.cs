using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TopitUp
{
    public class CustomTouchLabel : Label
    {


        bool _isSmallButton = false;

        public CustomTouchLabel()
            : base()
        {

        }

        public bool isSmallButton
        {
            set
            {
                _isSmallButton = value;
            }
            get
            {
                return _isSmallButton;
            }
        }


        protected override bool ShowFocusCues
        {
            get
            {
                return false;
            }
        }


        protected override void WndProc(ref System.Windows.Forms.Message msg)
        {

            switch (msg.Msg)
            {
                case Win32.WM_POINTERDOWN:
                    this.ForeColor = Color.LightGray;
                    //this.BackColor = Color.FromArgb(215, 218, 222);
                    if (_isSmallButton) {
                        this.Image =  global::TopitUp.Properties.Resources.kbd_sml3_over;
                    } else {
                        this.Image = global::TopitUp.Properties.Resources.kbd_over;
                    }
                    //this.Update();
                    break;
                case Win32.WM_POINTERUP:
                    this.ForeColor = Color.Maroon;
                    //this.BackColor = Color.FromArgb(215, 218, 222);
                    if (_isSmallButton)
                    {
                        this.Image = global::TopitUp.Properties.Resources.kbd_sml3;
                    }
                    else
                    {
                        this.Image = global::TopitUp.Properties.Resources.kbd;
                    }
                    
                    break;
            }

            base.WndProc(ref msg);

        }


    }

}

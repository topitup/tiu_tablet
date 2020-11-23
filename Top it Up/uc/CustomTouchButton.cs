using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopitUp
{
    public class CustomTouchButton : Button
    {

        private System.Drawing.Color _foreColor;

        public CustomTouchButton()
            : base()
        {

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
                case Win32.WM_POINTERUP:
                case Win32.WM_POINTERUPDATE:
                case Win32.WM_POINTERCAPTURECHANGED:
                    break;
                default:
                    base.WndProc(ref msg);
                    return;
            }

            switch (msg.Msg)
            {
                case Win32.WM_POINTERDOWN:
                    _foreColor = this.ForeColor;
                    this.ForeColor = this.BackColor;
                    this.BackColor = this.FlatAppearance.MouseDownBackColor;
                    //this.Update();
                    break;
                case Win32.WM_POINTERUP:
                    this.ForeColor = _foreColor;
                    this.BackColor = this.FlatAppearance.MouseOverBackColor;
                    break;
            }

            base.WndProc(ref msg);

        }


    }


}

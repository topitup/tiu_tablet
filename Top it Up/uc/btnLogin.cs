using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TopitUp
{
    class btnLogin  : Button
    {


        public btnLogin(): base()
        {
            // Prevent the button from drawing its own border
            //FlatAppearance.BorderSize = 0;
            //FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            this.SetStyle(ControlStyles.Selectable, false);

        }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);

        //    // Draw Border using color specified in Flat Appearance
        //    Pen pen = new Pen(FlatAppearance.BorderColor, 1);
        //    Rectangle rectangle = new Rectangle(0, 0, Size.Width - 1, Size.Height - 1);
        //    e.Graphics.DrawRectangle(pen, rectangle);
        //}



    }



}

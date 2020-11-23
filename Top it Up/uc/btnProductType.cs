using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TopitUp
{
    public class btnProductType : Button
    {

        public String icon = "";
        public String type = "0";
        public String id_parent = "0";
        public String service_provider_id = "0";
        public String bill_payment_type = "";
        public bool product_enabled = true;

        public btnProductType()
            : base()
        {


            // Prevent the button from drawing its own border
            //FlatAppearance.BorderSize = 0;
            //FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            //this.SetStyle(ControlStyles.Selectable, false);

            this.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BackColor = System.Drawing.Color.White;
            //this.BackgroundImage = ((System.Drawing.Image)(TopitUp.Properties.Resources.GetObject("id_3.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ForeColor = System.Drawing.Color.White;
            //this.Location = new System.Drawing.Point(18, 35);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "";
            this.Size = new System.Drawing.Size(180, 100);
            this.TabStop = false;
            this.UseVisualStyleBackColor = false;
            


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

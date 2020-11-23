using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace TopitUp
{
    public class MyButton : Button
    {

        //private Font btnItemFontLrg = new Font("Arial", 22F, System.Drawing.FontStyle.Bold);
        private Font btnItemFontSml = new Font("Arial", 18F, System.Drawing.FontStyle.Bold);

        //private Image image;
       // private Bitmap m_bmpOffscreen;

        public String button_extra = "";


        //private LinearGradientBrush myBrush = null;


        //public Image BackgroundImage
        //{
        //    get
        //    {
        //        return image;
        //    }
        //    set
        //    {
        //        image = value;
        //    }
        //}

        public MyButton()
        {

            this.Font = new Font("Arial", 30F, System.Drawing.FontStyle.Bold);
            //
        }

        public void checkSize()
        {
            if (this.Text.Length > 7)
            {
                 this.Font = new Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            } else
            {
                this.Font = new Font("Arial", 30F, System.Drawing.FontStyle.Bold);
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {

            base.OnPaint(e);

            //Graphics gxOff;	   //Offscreen graphics

            //if (m_bmpOffscreen == null) //Bitmap for doublebuffering
            //{
            //    m_bmpOffscreen = new Bitmap(ClientSize.Width, ClientSize.Height);
            //}

            //gxOff = Graphics.FromImage(m_bmpOffscreen);

            //if (image != null)
            //{
            //    ImageAttributes imageAttr = new ImageAttributes();
            //    gxOff.DrawImage(image, new Rectangle(0, 0, this.Width, this.Height), 0, 0, this.Width, this.Height, GraphicsUnit.Pixel, imageAttr);
            //}
            //e.Graphics.DrawImage(m_bmpOffscreen, 0, 0);


            if (this.Text.Length > 0)
            {
                if (button_extra.Length > 0)
                {
                    //SizeF size = e.Graphics.MeasureString(this.Text, this.Font);
                    //e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), (this.ClientSize.Width - size.Width) / 2, ((this.ClientSize.Height - size.Height) / 2) - 5 );

                    SizeF size_sml = e.Graphics.MeasureString(this.button_extra, this.btnItemFontSml);
                    //e.Graphics.DrawString(this.button_extra, this.btnItemFontSml, new SolidBrush(Color.FromArgb(88, 88, 88)), (this.ClientSize.Width - size_sml.Width) / 2, ((this.ClientSize.Height - size.Height) / 2) + 43);
                    e.Graphics.DrawString(this.button_extra, this.btnItemFontSml, new SolidBrush(Color.FromArgb(88, 88, 88)), (this.ClientSize.Width - size_sml.Width) / 2, (this.ClientSize.Height / 2) + 23);
                }
                else
                {
                    //SizeF size = e.Graphics.MeasureString(this.Text, this.Font);
                    //e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), (this.ClientSize.Width - size.Width) / 2, (this.ClientSize.Height - size.Height) / 2);
                }

            }

            //base.OnPaint(e);
        }

        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
        {
            //Do nothing
        }


    }
}

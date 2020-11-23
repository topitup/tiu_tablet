using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TopitUp
{
    public partial class virtualKeyboard : UserControl
    {

        public virtualKeyboard()
        {

            InitializeComponent();

            this.SetStyle(ControlStyles.Selectable, false);

            setupBtn(this.btn0);
            setupBtn(this.btn1);
            setupBtn(this.btn2);
            setupBtn(this.btn3);
            setupBtn(this.btn4);
            setupBtn(this.btn5);
            setupBtn(this.btn6);
            setupBtn(this.btn7);
            setupBtn(this.btn8);
            setupBtn(this.btn9);
            setupBtn(this.btnDigitPoint);

            this.btnClear.Click += new System.EventHandler(this.btnButton_Click);

            setupBtnAZ(this.btnA);
            setupBtnAZ(this.btnB);
            setupBtnAZ(this.btnC);
            setupBtnAZ(this.btnD);
            setupBtnAZ(this.btnE);
            setupBtnAZ(this.btnF);
            setupBtnAZ(this.btnG);
            setupBtnAZ(this.btnH);
            setupBtnAZ(this.btnI);
            setupBtnAZ(this.btnJ);
            setupBtnAZ(this.btnK);
            setupBtnAZ(this.btnL);
            setupBtnAZ(this.btnM);
            setupBtnAZ(this.btnN);
            setupBtnAZ(this.btnO);
            setupBtnAZ(this.btnP);
            setupBtnAZ(this.btnQ);
            setupBtnAZ(this.btnR);
            setupBtnAZ(this.btnS);
            setupBtnAZ(this.btnT);
            setupBtnAZ(this.btnU);
            setupBtnAZ(this.btnV);
            setupBtnAZ(this.btnW);
            setupBtnAZ(this.btnX);
            setupBtnAZ(this.btnY);
            setupBtnAZ(this.btnZ);
            setupBtnAZ(this.btnComma);
            setupBtnAZ(this.btnPoint);

            this.btnClear2.Click += new System.EventHandler(this.btnButton_Click);
            this.btnSpace.Click += new System.EventHandler(this.btnButton_Click);

        }

        private void setupBtn(Label btn)
        {
            //btn.Click += new System.EventHandler(this.btnButton_Click);
            //btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMouseDown);
            //btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMouseUp);

            btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnButton_Click);

        }

        private void setupBtnAZ(Label btn)
        {
            //btn.Click += new System.EventHandler(this.btnButton_Click);
            //btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMouseDownAZ);
            //btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMouseUpAZ);

            btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnButton_Click);

        }
        

        public void setKeyPadOnly(Boolean setEnabled)
        {
            btnAZ.Enabled = !setEnabled;
        }
        public void showKeyPadPoint()
        {
            btnDigitPoint.Visible = true;
        }


        public void changeKeyPadtoLetters()
        {
            btnHighlight.Left = 201;
            btnAZ.BackColor = Color.Maroon;
            btn19.BackColor = Color.FromArgb(60, 60, 60);
            tblDigits.Hide();
            tblAZ.Show();
        }


        private void btnButton_Click(object sender, EventArgs e)
        {

            Label btnClick = (Label)sender;

            if (btnClick.Name.Equals("btnClear") || btnClick.Name.Equals("btnClear2"))
            {
                SendKeys.Send("{BACKSPACE}"); 
            }
            else if (btnClick.Name.Equals("btnSpace"))
            {
                SendKeys.Send(" "); 
            }
            else 
            {
                SendKeys.Send(btnClick.Text); 
            }
           

        }



        //private void btnMouseDownAZ(object sender, MouseEventArgs e)
        //{
        //    Label btn = sender as Label;
        //    btn.ForeColor = Color.Gray;
        //    btn.Image = global::TopitUp.Properties.Resources.kbd_sml3_over;
        //}

        //private void btnMouseUpAZ(object sender, MouseEventArgs e)
        //{
        //    Label btn = sender as Label;
        //    btn.ForeColor = Color.FromArgb(128, 0, 0);
        //    btn.Image = global::TopitUp.Properties.Resources.kbd_sml3;
        //}



        //private void btnMouseDown(object sender, MouseEventArgs e)
        //{
        //    Label btn = sender as Label;
        //    btn.ForeColor = Color.Gray;
        //    btn.Image = global::TopitUp.Properties.Resources.kbd_over;
        //}

       // private Label last_btn;
        //private void btnMouseUp(object sender, MouseEventArgs e)
        //{
        //    Label btn = sender as Label;
        //    btn.ForeColor = Color.FromArgb(128,0,0);

        //    //tmrKeyPress.Enabled = true;
        //    //last_btn = btn;
        //    btn.Image = global::TopitUp.Properties.Resources.kbd;
        //}



        private void btn19_Click(object sender, EventArgs e)
        {
            btnHighlight.Left = 1;
            btn19.BackColor = Color.Maroon;
            btnAZ.BackColor = Color.FromArgb(60, 60, 60);
            tblAZ.Hide();
            tblDigits.Show();
        }

        private void btnAZ_Click(object sender, EventArgs e)
        {
            btnHighlight.Left = 201;
            btnAZ.BackColor = Color.Maroon;
            btn19.BackColor = Color.FromArgb(60, 60, 60);
            tblDigits.Hide();
            tblAZ.Show();
        }


        private bool is_upper = false;
        private void btnCase_Click(object sender, EventArgs e)
        {

            is_upper = !is_upper;

            this.btnA.Text = is_upper ? this.btnA.Text.ToLower() : this.btnA.Text.ToUpper();
            this.btnB.Text = is_upper ? this.btnB.Text.ToLower() : this.btnB.Text.ToUpper();
            this.btnC.Text = is_upper ? this.btnC.Text.ToLower() : this.btnC.Text.ToUpper();
            this.btnD.Text = is_upper ? this.btnD.Text.ToLower() : this.btnD.Text.ToUpper();
            this.btnE.Text = is_upper ? this.btnE.Text.ToLower() : this.btnE.Text.ToUpper();
            this.btnF.Text = is_upper ? this.btnF.Text.ToLower() : this.btnF.Text.ToUpper();
            this.btnG.Text = is_upper ? this.btnG.Text.ToLower() : this.btnG.Text.ToUpper();
            this.btnH.Text = is_upper ? this.btnH.Text.ToLower() : this.btnH.Text.ToUpper();
            this.btnI.Text = is_upper ? this.btnI.Text.ToLower() : this.btnI.Text.ToUpper();
            this.btnJ.Text = is_upper ? this.btnJ.Text.ToLower() : this.btnJ.Text.ToUpper();
            this.btnK.Text = is_upper ? this.btnK.Text.ToLower() : this.btnK.Text.ToUpper();
            this.btnL.Text = is_upper ? this.btnL.Text.ToLower() : this.btnL.Text.ToUpper();
            this.btnM.Text = is_upper ? this.btnM.Text.ToLower() : this.btnM.Text.ToUpper();
            this.btnN.Text = is_upper ? this.btnN.Text.ToLower() : this.btnN.Text.ToUpper();
            this.btnO.Text = is_upper ? this.btnO.Text.ToLower() : this.btnO.Text.ToUpper();
            this.btnP.Text = is_upper ? this.btnP.Text.ToLower() : this.btnP.Text.ToUpper();
            this.btnQ.Text = is_upper ? this.btnQ.Text.ToLower() : this.btnQ.Text.ToUpper();
            this.btnR.Text = is_upper ? this.btnR.Text.ToLower() : this.btnR.Text.ToUpper();
            this.btnS.Text = is_upper ? this.btnS.Text.ToLower() : this.btnS.Text.ToUpper();
            this.btnT.Text = is_upper ? this.btnT.Text.ToLower() : this.btnT.Text.ToUpper();
            this.btnU.Text = is_upper ? this.btnU.Text.ToLower() : this.btnU.Text.ToUpper();
            this.btnV.Text = is_upper ? this.btnV.Text.ToLower() : this.btnV.Text.ToUpper();
            this.btnW.Text = is_upper ? this.btnW.Text.ToLower() : this.btnW.Text.ToUpper();
            this.btnX.Text = is_upper ? this.btnX.Text.ToLower() : this.btnX.Text.ToUpper();
            this.btnY.Text = is_upper ? this.btnY.Text.ToLower() : this.btnY.Text.ToUpper();
            this.btnZ.Text = is_upper ? this.btnZ.Text.ToLower() : this.btnZ.Text.ToUpper();

        }

      
     


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopitUp
{

    static class Program
    {

        public static frmSplash splashForm = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            try
            {

                Util.system_uid = Util.getUniqueID();
                //Console.WriteLine("Main : " + Util.getUniqueID());

            }
            catch
            {
                //
            } 

            globalSettings.touch();


            Thread splashThread = new Thread(new ThreadStart(
            delegate
            {
                splashForm = new frmSplash();
                Application.Run(splashForm);
            }
            ));

            splashThread.SetApartmentState(ApartmentState.STA);
            splashThread.Start();

            Thread.Sleep(1000);

            

            if (!globalSettings.app_path.ToLower().Trim().Equals("c:\\topitup"))
            {

                closeSplash();
                MessageBox.Show("Top it Up Not Installed Correctly. Please check path.");
                Application.Exit();

            }
            else {

                frmTopitUp mainForm2 = new frmTopitUp(splashForm);
                mainForm2.Shown += new System.EventHandler(mainForm_Shown);
                Application.Run(mainForm2);

            }
           
         }

        static void mainForm_Shown(object sender, EventArgs e)
        {
            closeSplash();
        }


        //static void mainForm_Load(object sender, EventArgs e)
        //{
        //    closeSplash();
        //}

        static void closeSplash()
        {
            if (splashForm == null)
            {
                return;
            }
            try
            {
                splashForm.Invoke(new Action(splashForm.Close));
                splashForm.Dispose();
                splashForm = null;
            }
            catch
            {
                //
            }
        }

    }
}

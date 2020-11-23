using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Networking.BackgroundTransfer;
using Ionic.Zip;


namespace TopitUp
{
    public partial class frmAppUpdate: Form
    {

        Form centerWrapper = new Form();

        private CancellationTokenSource cts;

        public frmAppUpdate()
        {

            InitializeComponent();

            

        }


        private void frmAppUpdate_Load(object sender, EventArgs e)
        {

            if (globalSettings.allow_screen_resize == "0")
            {
                this.Left = 0;
                this.Width = Screen.PrimaryScreen.Bounds.Width;
                this.Top = 100;
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
                centerWrapper.Top = this.pnlAdmin.Top;
                centerWrapper.Left = this.pnlAdmin.Left;
                centerWrapper.Width = this.pnlAdmin.Width;
                centerWrapper.Height = this.pnlAdmin.Height;
            }
            else
            {
                centerWrapper.Top = this.Top + this.pnlAdmin.Top;
                centerWrapper.Left = this.Left + this.pnlAdmin.Left;
                centerWrapper.Width = this.pnlAdmin.Width;
                centerWrapper.Height = this.pnlAdmin.Height;
            }

            this.AddOwnedForm(centerWrapper);

            this.pnlAdmin.Parent = centerWrapper;
            this.pnlAdmin.Top = 0;
            this.pnlAdmin.Left = 0;

            centerWrapper.Show();
            
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {

            btnClose.Enabled = false;
            btnUpdate.Enabled = false;

            if (btnUpdate.Text.Equals("Restart"))
            {

                globalSettings.app_restart = true;
                Close();

            }
            else
            {

                try
                {
                    using (WebClient wc = new WebClient())
                    {
                        wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                        wc.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                        wc.DownloadFileAsync(new System.Uri("http://www.itopitup.co.za/update/update.zip"),
                            @"c:\topitup\update\update.zip");
                    }



                }
                catch
                {
                    Util.showMessage("Could not download update.", Color.Yellow);
                    btnClose.Enabled = true;
                    btnUpdate.Enabled = true;
                }
            }
        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            prgDownload.Value = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {

            if (!File.Exists(@"c:\topitup\update\update.zip"))
            {

                Util.showMessage("No Update Available.", Color.Yellow);

                prgDownload.Enabled = true;
                btnClose.Enabled = true;
                prgDownload.Visible = true;
                btnClose.Visible = true;
                btnUpdate.Text = "Update";

            }
            else
            {

                Util.showMessage("Update download complete.", Color.White);

                Util.showWait(true);

                try
                {
                    String old_location = @"c:\topitup\Top it Up.old";
                    if (File.Exists(old_location))
                    {
                        File.Delete(old_location);
                    }
                    System.IO.File.Move(@"c:\topitup\Top it Up.exe", old_location);
                }
                catch
                {
                    //
                }

                string path = @"C:\topitup\update";
                DirectoryInfo di = new DirectoryInfo(path);

                if (di != null)
                {

                    FileInfo fi = GetLatestFile(di);
                    string folder = ExtractZip(fi);

                    if (!folder.Equals("-1"))
                    {
                        Util.showWait(false);

                        prgDownload.Visible = false;
                        btnClose.Visible = false;
                        btnUpdate.Text = "Restart";
                        btnUpdate.Enabled = true;

                        lblMessage.Text = "The update file has been processed.";
                    }
                    else
                    {
                        btnClose.Enabled = true;
                        lblMessage.Text = "No update available.";
                    }
                }

                Util.showWait(false);
             
            }
            

        }


        public FileInfo GetLatestFile(DirectoryInfo di)
        {
            FileInfo fi = di.GetFiles()
                .OrderByDescending(d => d.CreationTime)
                .FirstOrDefault();

            return fi;
        }


        private string ExtractZip(FileInfo fi)
        {

            string extractTo = "";

            try
            {
                //extractTo = Path.Combine(fi.DirectoryName, Guid.NewGuid().ToString());
                extractTo = @"c:\topitup\";
                using (ZipFile zip = ZipFile.Read(fi.FullName))
                {
                    foreach (ZipEntry ze in zip)
                    {
                        ze.Extract(extractTo, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
            }
            catch 
            {
                extractTo = "-1";
            }

            return extractTo;
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }







    }

}

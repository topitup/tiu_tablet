using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TopitUp
{
    public partial class frmWifiNetwork : Form
    {

        Form centerWrapper = new Form();

        public String _interface = "";


        public frmWifiNetwork()
        {
            InitializeComponent();
        }



        private void frmWifiNetwork_Load(object sender, EventArgs e)
        {

            centerWrapper.StartPosition = FormStartPosition.Manual;

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

            pnlConnectOver.Hide();

            centerWrapper.Show();

            getWifiList();

            Util.showWait(false);

            txtPassKey.Focus();
            
        }


        private void getWifiList()
        {



            grdNetworks.Rows.Clear();
            int i = -1;

 //if ($_ -match '^SSID (\d+) : (.*)$') {
 //       $current = @{}
 //       $networks += $current
 //       $current.Index = $matches[1].trim()
 //       $current.SSID = $matches[2].trim()
 //   } else {
 //       if ($_ -match '^\s+(.*)\s+:\s+(.*)\s*$') {
 //           $current[$matches[1].trim()] = $matches[2].trim()
 //       }
 //   }

            Regex regex1 = new Regex(@"^SSID (\d+) : (.*)$");
            Regex regex2 = new Regex(@"^\s+(.*)\s+:\s+(.*)\s*$");

            String _mobile_network_name_all = Util.netsh("wlan sh net mode=bssid");
            using (StringReader reader = new StringReader(_mobile_network_name_all))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {

	                Match match1 = regex1.Match(line);
                    if (match1.Success)
                    {

                        i++;
                        Console.WriteLine(match1.Groups[1].Value.Trim() + " --- " + match1.Groups[2].Value.Trim());

                        grdNetworks.Rows.Add();
                        grdNetworks.Rows[i].Tag = match1.Groups[2].Value.Trim();
                        grdNetworks.Rows[i].Cells[0].Value = match1.Groups[2].Value.Trim();

                    }
                    else
                    {

                        Match match2 = regex2.Match(line);
                        if (match2.Success)
                        {
                            if (match2.Groups[1].Value.Trim().Equals("Signal"))
                            {
                                grdNetworks.Rows[i].Cells[1].Value = match2.Groups[2].Value.Trim();
                            }
                            
                            Console.WriteLine(match2.Groups[1].Value.Trim() + " , " + match2.Groups[2].Value.Trim());

                        }

                    }

                    //if (System.Text.RegularExpressions.Regex.IsMatch(line, "^SSID (\d+) : (.*)$",
                    //    System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                    //{
                    //}


                }
            }

        }



     

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }



        private void btnConnect_Click(object sender, EventArgs e)
        {

            String _network_name = "";

            try
            {
                DataGridViewRow row = grdNetworks.Rows[grdNetworks.CurrentCell.RowIndex];
                _network_name = row.Tag.ToString();
            }
            catch
            {
                //
            }

            if (_network_name.Equals(""))
            {
                Util.showMessage("Please select a Wi-Fi network.",Color.Yellow);
                return;
            }

            if (txtPassKey.Text.Trim().Equals(""))
            {
                Util.showMessage("Please enter the Wi-Fi network password.", Color.Red);
                txtPassKey.Focus();
                return;
            }

            try
            {

                /* Store Password */
                globalSettings.SaveWifiPasswords(_network_name, txtPassKey.Text.Trim());

                pnlConnectOver.Show();

                lblConnect.Text = "Busy connecting to wi-fi network:" + Environment.NewLine + Environment.NewLine;
                lblConnect.Text += _network_name + Environment.NewLine + Environment.NewLine;
                lblConnect.Text += "Please wait until the connection has established and the connected icon appears at the top right of the screen." + Environment.NewLine + Environment.NewLine;

                if (!tryConnect(_interface, _network_name))         //No Profile so we have to add one
                {

                    try
                    {
                        createProfile(_interface, _network_name, txtPassKey.Text.Trim());
                    }
                    catch (Exception ex_create)
                    {
                        Util.showMessage(ex_create.Message, Color.Red);
                    }

                    try
                    {
                        addProfile(_interface, _network_name);
                    }
                    catch (Exception ex_add)
                    {
                        Util.showMessage(ex_add.Message, Color.Red);
                    }


                    if (!tryConnect(_interface, _network_name))         //No Profile so we have to add one
                    {
                        lblConnect.ForeColor = Color.Firebrick;
                        lblConnect.Text = "Could not connect to Wi-Fi network!";
                    }
                    else
                    {
                        lblConnect.Text = "Connected!";
                    }

                }
                else
                {
                    lblConnect.Text = "Connected!";
                }


            }
            catch (Exception ex)
            {
                Util.showMessage(ex.Message, Color.Red);
            }

        }

        public static bool addProfile(String networkInterface, String networkName)
        {


            String netsh_reponse = Util.netsh("wlan add profile interface=\"" + networkInterface + "\" filename=\"" + @"c:\topitup\setup\wifi\" + networkName + ".ps1" + "\"");

            Console.WriteLine(netsh_reponse);

            return true;

        }

        public static bool createProfile(String networkInterface, String networkName, String passKey)
        {

            string outStr = "";

            byte[] ba = Encoding.Default.GetBytes(networkName);
            var hexString = BitConverter.ToString(ba);
            //hexString = hexString.Replace("-", "");

            outStr = "<?xml version=\"1.0\"?>" + Environment.NewLine +
                      "<WLANProfile xmlns=\"http://www.microsoft.com/networking/WLAN/profile/v1\">" + Environment.NewLine +
                            "<name>" + networkName + "</name>" + Environment.NewLine +
	                        "<SSIDConfig>" + Environment.NewLine + 
		                        "<SSID>" + Environment.NewLine +
			                        "<hex>" + hexString.Replace("-", "") + "</hex>" + Environment.NewLine +
			                        "<name>"+ networkName +"</name>" + Environment.NewLine +
		                        "</SSID>" + Environment.NewLine +
	                        "</SSIDConfig>" + Environment.NewLine +
	                        "<connectionType>ESS</connectionType>" + Environment.NewLine +
	                        "<connectionMode>auto</connectionMode>" + Environment.NewLine +
	                        "<MSM>" + Environment.NewLine +
		                        "<security>" + Environment.NewLine +
			                        "<authEncryption>" + Environment.NewLine +
				                        "<authentication>WPA2PSK</authentication>" + Environment.NewLine +
				                        "<encryption>AES</encryption>" + Environment.NewLine +
				                        "<useOneX>false</useOneX>" + Environment.NewLine +
			                        "</authEncryption>" + Environment.NewLine +
			                        "<sharedKey>" + Environment.NewLine +
				                        "<keyType>passPhrase</keyType>" + Environment.NewLine +
				                        "<protected>false</protected>" + Environment.NewLine + 
				                        "<keyMaterial>" + passKey + "</keyMaterial>" + Environment.NewLine +
			                        "</sharedKey>" + Environment.NewLine +
		                        "</security>" + Environment.NewLine +
	                        "</MSM>" + Environment.NewLine +
	                        "<MacRandomization xmlns=\"http://www.microsoft.com/networking/WLAN/profile/v3\">" + Environment.NewLine +
		                        "<enableRandomization>false</enableRandomization>" + Environment.NewLine +
	                        "</MacRandomization>" + Environment.NewLine +
                        "</WLANProfile>";

            TextWriter tw = new StreamWriter(@"c:\topitup\setup\wifi\" + networkName + ".ps1", false);
            tw.Write(outStr);
            tw.Close();

            return true;

        }


        private bool tryConnect(String networkInterface, String networkName)
        {

            bool ret = true;

            String netsh_reponse = Util.netsh("wlan connect interface=\"" + networkInterface + "\" name=\"" + networkName + "\"");

            Console.WriteLine(netsh_reponse);

            using (StringReader reader = new StringReader(netsh_reponse))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains("is no profile"))
                    {
                        ret = false;
                    }
                }
            }

            return ret;

        }

        private void btnClose2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chk_show_password_CheckedChanged(object sender, EventArgs e)
        {
            txtPassKey.PasswordChar = chk_show_password.Checked ? '\0' : '*';
        }

        private void grdNetworks_SelectionChanged(object sender, EventArgs e)
        {

            string _network_name = "";

            try
            {
                DataGridViewRow row = grdNetworks.Rows[grdNetworks.CurrentCell.RowIndex];
                _network_name = row.Tag.ToString();
            }
            catch
            {
                //
            }

            if (globalSettings.wifi_passwords.ContainsKey(_network_name))
            {
                txtPassKey.Text = globalSettings.wifi_passwords[_network_name];
            }
            else
            {
                txtPassKey.Text = "";
            }


        }

       
        


    }

}

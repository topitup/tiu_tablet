using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TopitUp
{
    public partial class frmConnectionSettings : Form
    {


        public frmConnectionSettings()
        {
            InitializeComponent();

            if (isAdministrator())
            {
                lblneedadmin.Visible = false;
                ShowAllNetworkAdapters();
            }
            else
            {
                btnRefresh.Visible = false;
                lblneedadmin.Visible = true;
            }
        }

        private void frmConnectionSettings_Load(object sender, EventArgs e)
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
        }


        
        #region Private Properties

        /// <summary>
        /// All Network Adapters in the machine
        /// </summary>
        private List<NetworkAdapter> _allNetworkAdapters = new List<NetworkAdapter>();
        
        /// <summary>
        /// The Current Operation Network Adapter
        /// </summary>
        private NetworkAdapter _currentNetworkAdapter = null;

        #endregion

    
        #region Private Methods

     
        private bool isAdministrator()
        {
            System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
            return principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
        } 


        private void ShowAllNetworkAdapters()
        {
            Util.showWait(true);

            //grpNetworkAdapters.Controls.Clear();
            pnlTest.Controls.Clear();

            _allNetworkAdapters = NetworkAdapter.GetAllNetworkAdapter();
            int i = -1;

            foreach (NetworkAdapter networkAdapter in _allNetworkAdapters)
            {
                i++;
                //UcNetworkAdapter ucNetworkAdapter = new UcNetworkAdapter(networkAdapter, clickCheckEventHandler, new Point(20, (65 * i)+60), grpNetworkAdapters);
                UcNetworkAdapter ucNetworkAdapter = new UcNetworkAdapter(networkAdapter, clickCheckEventHandler, new Point(20, (65 * i) + 60), pnlTest);
            }

            Util.showWait(false);

        }

        #endregion

        #region Event Handler

        public void clickCheckEventHandler(object sender, EventArgs e)
        {

            int result = 0;

            Util.showWait(true);

            if (sender is Button)
            {

                Button btnConnect = (Button)sender;
                String interfaceName = ((String[])btnConnect.Tag)[0];

                if (btnConnect.Name.Equals("btnWifiNetworks"))
                {
                    frmWifiNetwork frmWifi = new frmWifiNetwork();
                    frmWifi._interface = interfaceName;
                    frmWifi.ShowDialog(this);
                }
                else
                {
                    

                    //MessageBox.Show(btnConnect.Text);

                    String _interface_name = interfaceName.Equals("Cellular") ? "Cellular" : "Wi-Fi";
                    String _interface_tyle = interfaceName.Equals("Cellular") ? "mbn" : "wlan";

                    if (interfaceName.Equals("Cellular") || interfaceName.Equals("Wi-Fi")) 
                    {

                        if (btnConnect.Text.Equals("Connect"))
                        {

                            String _mobile_network_name = "";

                            String _mobile_network_name_all = Util.netsh(_interface_tyle + " show profile");
                            using (StringReader reader = new StringReader(_mobile_network_name_all))
                            {
                                string line;
                                while ((line = reader.ReadLine()) != null)
                                {
                                    if (interfaceName.Equals("Wi-Fi"))
                                    {
                                        if (line.Contains("All User Profile")) _mobile_network_name = line.Split(':')[1].Trim();
                                    }
                                    else
                                    {
                                        if (line.Trim().Length > 0 && !line.Contains(":") && !line.Contains("----"))
                                        {
                                            _mobile_network_name = line.Trim();
                                        }
                                    }
                                }
                            }

                            String param = "";

                            if (_mobile_network_name.Length > 0)
                            {


                                if (interfaceName.Equals("Cellular"))
                                {
                                    param = _interface_tyle + " connect interface=\"" + _interface_name + "\" connmode=name name=\"" + _mobile_network_name + "\"";
                                }
                                else
                                {
                                    param = _interface_tyle + " connect interface=\"" + _interface_name + "\" name=\"" + _mobile_network_name + "\"";
                                    //param = _interface_tyle + " disconnect interface=\"" + _interface_name + "\" connmode=name name=\"" + _mobile_network_name + "\"";
                                }

                                String _detail = Util.netsh(param);

                            }

                        }
                        else
                        {
                                String _detail = Util.netsh(_interface_tyle + " disconnect interface=\"" + _interface_name + "\"");
                        }

                        
                        //if (_detail.Trim().Length == 0)
                        //{
                        //    result = 1;
                        //    _result_text = _currentNetworkAdapter.Name + ((_currentNetworkAdapter.NetConnectionStatus == 7) ? " connected." : " disconnected.");
                        //}
                        //else
                        //{
                        //    result = -1;
                        //    _result_text = _currentNetworkAdapter.Name + ((_currentNetworkAdapter.NetConnectionStatus == 7) ? " could not connect!" : " could not disconnected!");
                        //}

                    }

            }

            }
            else if (sender is CheckBox)
            {
                CheckBox chkEnabled = (CheckBox)sender;
                String interfaceName = ((String[])chkEnabled.Tag)[0];

                if (!chkEnabled.Checked) // Disable
                {
                    Util.netsh("interface set interface name=\"" + interfaceName + "\" disable");
                }
                else
                {
                    Util.netsh("interface set interface name=\"" + interfaceName + "\" enable");   
                }
            }




            //Button btnEnableDisableNetworkAdapter = (Button)sender;

            //int result = -1;
            //String deviceName = ((String[])btnEnableDisableNetworkAdapter.Tag)[0];
            //int deviceId = Int32.Parse( ((String[])btnEnableDisableNetworkAdapter.Tag)[1]);
            //String _result_text = "";

            //if (deviceName.Equals("Cellular"))
            //{

            //    _currentNetworkAdapter = new NetworkAdapter(deviceId);

            //    String _mobile_network_name = "";
            //    String _detail = "";

            //    System.Diagnostics.Process p1 = new System.Diagnostics.Process();
            //    p1.StartInfo.FileName = "netsh.exe";
            //    p1.StartInfo.Arguments = "mbn show profile";
            //    p1.StartInfo.UseShellExecute = false;
            //    p1.StartInfo.RedirectStandardOutput = true;
            //    p1.StartInfo.RedirectStandardError = true;
            //    p1.StartInfo.CreateNoWindow = true;
            //    p1.Start();

            //    String _mobile_network_name_all = p1.StandardOutput.ReadToEnd();
            //    using (StringReader reader = new StringReader(_mobile_network_name_all))
            //    {
            //        string line;
            //        while ((line = reader.ReadLine()) != null)
            //        {
            //            if (line.Trim().Length > 0 && !line.Contains(":") && !line.Contains("----"))
            //            {
            //                _mobile_network_name =  line.Trim();
            //            }
            //        }
            //    }

            //    System.Diagnostics.Process p2 = new System.Diagnostics.Process();
            //    p2.StartInfo.FileName = "netsh.exe";
            //    p2.StartInfo.Arguments = (_currentNetworkAdapter.NetConnectionStatus == 7) ? "mbn connect interface=\"Cellular\" connmode=name name=\"" + _mobile_network_name + "\"" : "mbn disconnect interface=\"Cellular\"";
            //    p2.StartInfo.UseShellExecute = false;
            //    p2.StartInfo.RedirectStandardOutput = true;
            //    p2.StartInfo.RedirectStandardError = true;
            //    p2.StartInfo.CreateNoWindow = true;
            //    p2.Start();

            //    _detail = p2.StandardOutput.ReadToEnd();
            //    if (_detail.Trim().Length == 0)
            //    {
            //        result = 1;
            //        _result_text = _currentNetworkAdapter.Name + ((_currentNetworkAdapter.NetConnectionStatus == 7) ? " connected." : " disconnected.");
            //    }
            //    else
            //    {
            //        result = -1;
            //        _result_text = _currentNetworkAdapter.Name + ((_currentNetworkAdapter.NetConnectionStatus == 7) ? " could not connect!" : " could not disconnected!");
            //    }

            //    System.Threading.Thread.Sleep(1000);

            //} else {
                    
            //            _currentNetworkAdapter = new NetworkAdapter(deviceId);

            //            if (Int32.Parse(((String[])btnEnableDisableNetworkAdapter.Tag)[2]) == _currentNetworkAdapter.NetEnabled)
            //            {

            //            if (_currentNetworkAdapter.NetEnabled == -1
            //                    && (_currentNetworkAdapter.NetConnectionStatus >= 4
            //                        && _currentNetworkAdapter.NetConnectionStatus <= 7))
            //                {
            //                    _result_text = "Media Disconnected/Disabled or Hardware not pressent.";
            //                    result = -1;
            //                }
            //                else
            //                {
            //                    result = _currentNetworkAdapter.EnableOrDisableNetworkAdapter( (_currentNetworkAdapter.NetEnabled == 1) ?  "Disable" : "Enable");
            //                    _result_text = _currentNetworkAdapter.Name + " " + ((_currentNetworkAdapter.NetEnabled == 1) ?  "disabled" : "enabled");

            //                }

            //            }
            //            else
            //            {
            //                _result_text = "There was a problem updating " + _currentNetworkAdapter.Name;
            //                result = -1;
            //            }

            //}


            //if (result > 0)
            //{
            //    Util.showMessage(_result_text, Color.White);
            //}
            //else
            //{
            //    Util.showMessage(_result_text, Color.Yellow);
            //}

            ShowAllNetworkAdapters();

        }

        #endregion 

     






        private void btnConnectionTest_Click(object sender, EventArgs e)
        {

            Util.showWait(true);

            btnTestConnection.Enabled = false;
            lblConnDescription.Visible = true;
            lblConnDescription.Refresh();

            string htmlResponse = "";

            try
            {

                Web WebResponse = new Web(25000, 1, "");
                htmlResponse = WebResponse.GetURL("/terminal/general/connection-test");
                WebResponse = null;

                if (htmlResponse.IndexOf("err>", 0) >= 0)
                {
                    lblResponseCode.ForeColor = Color.Red;
                    lblResponseCode.Text = htmlResponse.StripErrorTags();
                }
                else if (htmlResponse.Length > 0)
                {

                    lblResponseCode.ForeColor = Color.Green;
                    lblResponseCode.Text = htmlResponse + Environment.NewLine + "Connection successful." ;

                }

            }
            catch (Exception ex)
            {
                lblResponseCode.ForeColor = Color.Red;
                lblResponseCode.Text = ex.Message;
            }

            btnTestConnection.Enabled = true;

            Util.showWait(false);

        }

        private void btnMainClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void lnkLoadNetworkSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo("NCPA.cpl");
                startInfo.UseShellExecute = true;
                System.Diagnostics.Process.Start(startInfo);
            }
            catch 
            {
                Util.showMessage("Could not open settings.", Color.Red);
                //
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ShowAllNetworkAdapters();
        }

        private void frmConnectionSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Util.showWaitClose();
        }

       
    }
}

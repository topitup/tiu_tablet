using System;
using System.Drawing;
using System.Windows.Forms;
using TopitUp.Properties;

namespace TopitUp
{
    internal partial class UcNetworkAdapter : UserControl
    {

        #region Constuct UCNetworkAdapter

        public UcNetworkAdapter()
        {
            InitializeComponent();
        }

        public UcNetworkAdapter(NetworkAdapter networkAdapter, EventHandler eventHandler, Point point, Control parent)
        {

            InitializeComponent();

            lblDescription.Text = networkAdapter.Description;
            lblDeviceName.Text = networkAdapter.Name;

            lblNetwork.Text = NetworkAdapter.SaNetConnectionStatus[networkAdapter.NetConnectionStatus];

            chkEnabled.Checked = networkAdapter.Enabled;
            chkEnabled.Text = (networkAdapter.Enabled)  ? "Enabled" : "Disabled";
            chkEnabled.ForeColor = (networkAdapter.Enabled) ? Color.Green : Color.Red;
            chkEnabled.CheckStateChanged += eventHandler;
            chkEnabled.Tag = new[] { networkAdapter.Description, networkAdapter.DeviceId.ToString()};

            //&& networkAdapter.Extra.Trim().Length > 0
            if (networkAdapter.Description == "Cellular" || networkAdapter.Description.Contains("Wi-Fi") )
            {
                btnConnect.Visible = true;
                btnConnect.BackColor = (networkAdapter.NetConnectionStatus == 7) ? Color.Green : Color.Maroon;
                btnConnect.Text = (networkAdapter.NetConnectionStatus == 7) ? "Connect" : "Disconnect";
                btnConnect.Tag = new[] { networkAdapter.Description, networkAdapter.DeviceId.ToString() };
                btnConnect.Click += eventHandler;
            }

            lblExtra.Text = networkAdapter.Extra;
            if (networkAdapter.Extra.Length == 0 && networkAdapter.Description.Contains("Wi-Fi"))
            {
                lblExtra.Text = "No Wi-Fi Network Selected.";    
            }
            

            if (networkAdapter.NetConnectionStatus < 1 || networkAdapter.NetConnectionStatus > 2) pctNetworkAdapter.Image = Resources.network_notconnected;

            if (networkAdapter.Description == "Wi-Fi")
            {
                btnWifiNetworks.Visible = true;
                btnWifiNetworks.Tag = new[] { networkAdapter.Description, networkAdapter.DeviceId.ToString() };
                btnWifiNetworks.Click += eventHandler;
                pctNetworkAdapter.BackgroundImage = (networkAdapter.Enabled) ? Resources.network_wireless : Resources.network_wireless_disabled;
            }
            else if (networkAdapter.Description.Contains("Cellular"))
            {
                pctNetworkAdapter.BackgroundImage = (networkAdapter.Enabled) ? Resources.network_cellular : Resources.network_cellular_disabled;
            }
            else if (networkAdapter.Description.Contains("Bluetooth"))
            {
                pctNetworkAdapter.BackgroundImage = (networkAdapter.Enabled) ? Resources.network_bluetooth : Resources.network_disabled;
            }
            else
            {
                pctNetworkAdapter.BackgroundImage = (networkAdapter.Enabled) ? Resources.network_cable : Resources.network_disabled;
            }


            Location = point;
            Width = parent.Width - 40;
            Parent = parent;

        }

        #endregion 

      

    }
}

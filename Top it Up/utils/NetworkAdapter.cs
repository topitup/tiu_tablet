using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Management;
using System.Management.Automation;
using System.Threading;
using TopitUp.Properties;

namespace TopitUp
{
    internal class NetworkAdapter
    {
        #region NetworkAdapter Properties

        public bool Enabled
        {
            get;
            private set;
        }
 
        /// 
        public int DeviceId
        {
            get;
            private set;
        }

        public string Description
        {
            get;
            private set;
        }
        

        /// <summary>
        /// The ProductName of the NetworkAdapter
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        public string Extra
        {
            get;
            private set;
        }

        public string Mobile_network_name
        {
            get;
            private set;
        }

        /// <summary>
        /// The NetEnabled status of the NetworkAdapter
        /// </summary>
        public int NetEnabled
        {
            get;
            private set;
        }

        /// <summary>
        /// The Net Connection Status Value
        /// </summary>
        public int NetConnectionStatus
        {
            get;
            private set;
        }

        /// <summary>
        /// The Net Connection Status Description
        /// </summary>
        public static string[] SaNetConnectionStatus = 
        { 
            "Disconnected",
            "Connecting",
            "Connected",
            "Disconnecting",
            "Hardware not present",
            "Hardware disabled",
            "Hardware malfunction",
            "Media disconnected",
            "Authenticating",
            "Authentication succeeded",
            "Authentication failed",
            "Invalid address",
            "Credentials required"
        };

        /// <summary>
        /// Enum the NetEnabled Status
        /// </summary>
        private enum EnumNetEnabledStatus
        { 
            Disabled = -1,
            Unknow,
            Enabled
        }

        /// <summary>
        /// Enum the Operation result of Enable and Disable  Network Adapter
        /// </summary>
        private enum EnumEnableDisableResult
        {
            Fail = -1,
            Unknow,
            Success
        }

        #endregion

        #region Construct NetworkAdapter

        public NetworkAdapter(
            int deviceId,
            bool enabled,
            string description,
            string name,
            string extra,  
            string mobile_network_name,
            int netEnabled, 
            int netConnectionStatus)
        {
            DeviceId = deviceId;
            Enabled = enabled;
            Description = description;
            Name = name;
            Extra = extra;
            Mobile_network_name = mobile_network_name;
            NetEnabled = netEnabled;
            NetConnectionStatus = netConnectionStatus;
        }


        public NetworkAdapter(int deviceId)
        {

            ManagementObject crtNetworkAdapter = new ManagementObject();
            string strWQuery = string.Format("SELECT DeviceID, ProductName, NetEnabled, NetConnectionStatus FROM Win32_NetworkAdapter WHERE DeviceID = {0}", deviceId);
            try
            {
                
                ManagementObjectCollection networkAdapters = WMIOperation.WMIQuery(strWQuery);
            
                foreach (ManagementObject networkAdapter in networkAdapters)
                {
                    // Expected to be only one ManagementObject instance.
                    crtNetworkAdapter = networkAdapter;
                    break;
                }

                Extra = "";
                DeviceId = deviceId;
                Name = crtNetworkAdapter["ProductName"].ToString();
                NetEnabled = (
                    Convert.ToBoolean(crtNetworkAdapter["NetEnabled"].ToString())) 
                    ? (int)EnumNetEnabledStatus.Enabled 
                    : (int)EnumNetEnabledStatus.Disabled;

                NetConnectionStatus = Convert.ToInt32(crtNetworkAdapter["NetConnectionStatus"].ToString());

            }
            catch(NullReferenceException)
            {
                // If there is no a network adapter which deviceid equates to the argument 
                // "deviceId" just to construct a none exists network adapter
                DeviceId = -1;
                Name = string.Empty;
                Extra = string.Empty;
                NetEnabled = 0;
                NetConnectionStatus = -1;
            }
        }

        #endregion

        #region Get NetEnabled Status Of The NetworkAdapter

        /// <summary>
        /// Get the NetworkAdapter Netenabled Property
        /// </summary>
        /// <returns>Whether the NetworkAdapter is enabled</returns>
        //public int GetNetEnabled()
        //{
        //    int netEnabled = (int)EnumNetEnabledStatus.Unknow;
        //    string strWQuery = string.Format("SELECT NetEnabled FROM Win32_NetworkAdapter WHERE DeviceID = {0}", DeviceId);
        //    try
        //    {
        //        ManagementObjectCollection networkAdapters = 
        //            WMIOperation.WMIQuery(strWQuery);
        //        foreach (ManagementObject networkAdapter in networkAdapters)
        //        {
        //            netEnabled =
        //                (Convert.ToBoolean(networkAdapter["NetEnabled"].ToString()))
        //                             ? (int) EnumNetEnabledStatus.Enabled
        //                             : (int) EnumNetEnabledStatus.Disabled;
        //        }
        //    }
        //    catch(NullReferenceException)
        //    {
        //        // If NullReferenceException return (EnumNetEnabledStatus.Unknow)
        //    }
        //    return netEnabled;
        //}

        #endregion

        #region Get All NetworkAdapters

        /// <summary>
        /// List all the NetworkAdapters
        /// </summary>
        /// <returns>The list of all NetworkAdapter of the machine</returns>
        public static List<NetworkAdapter> GetAllNetworkAdapter()
        {

            PowerShell psh = PowerShell.Create();

            List<NetworkAdapter> allNetworkAdapter = new List<NetworkAdapter>();

            // Manufacturer <> 'Microsoft'to get all none virtual devices.
            // Because the AdapterType property will be null if the NetworkAdapter is 
            // disabled, so we do not use NetworkAdapter = 'Ethernet 802.3' or 
            // NetworkAdapter = 'Wireless’
            
            //string strWQuery = "SELECT DeviceID, NetConnectionID, ProductName, Name, NetEnabled, NetConnectionStatus FROM Win32_NetworkAdapter ";

            string strWQuery = "SELECT DeviceID, NetConnectionID, ProductName, Name, NetEnabled, NetConnectionStatus, ServiceName FROM Win32_NetworkAdapter ";

            ManagementObjectCollection networkAdapters = WMIOperation.WMIQuery(strWQuery);
            foreach (ManagementObject moNetworkAdapter in networkAdapters)
            {
                try
                {

                    String NetConnectionName = moNetworkAdapter["NetConnectionID"].ToString();

                    // Custom Descriptions
                    if (NetConnectionName.Equals("Ethernet"))   NetConnectionName = "Network Cable";
                    if (NetConnectionName.Equals("Mobile broadband"))   NetConnectionName = "Cellular";
                     
                    if (moNetworkAdapter["ProductName"].ToString().Contains("Internet Sharing Device")) NetConnectionName = "Mobile Dongle";

                    String _xtra = "";
                    String _mobile_network_name = "";

                    //Get Enabled/Disabled Status
                    Boolean _enabled = false;
                    psh.AddScript("Get-Service " + moNetworkAdapter["ServiceName"]); //A5AGU
                    Collection<PSObject> result = psh.Invoke();
                    foreach (PSObject msg in result)
                    {
                        _enabled = (msg.Properties["Status"].Value.ToString().Equals("Running")) ? true : false;
                    }
                        

                    if (NetConnectionName == "Cellular" || NetConnectionName == "Wi-Fi")
                    {

                        String _xtra_all = Util.netsh((NetConnectionName == "Cellular") ? "mbn show interfaces" : "wlan show interfaces");

                        using (StringReader reader = new StringReader(_xtra_all))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                if (line.Contains(":"))
                                {
                                    string[] words = line.Split(':');
                                    if (words[0].Trim().Equals("Provider Name"))
                                    {
                                        _xtra += "Network Provider: " + words[1].Trim() + Environment.NewLine;
                                        _mobile_network_name = words[1].Trim();
                                    }
                                    if (words[0].Trim().Equals("SSID"))
                                        _xtra += "Network Name: " + words[1].Trim() + Environment.NewLine;
                                    if (words[0].Trim().Equals("Signal"))
                                        _xtra += "Signal Strength: " + words[1].Trim() + Environment.NewLine;
                                }
                            }
                        }
                    }

                    //if (proc.WaitForExit(timeout) == false)
                    //{
                    //  proc.Kill();
                    //}	


                    allNetworkAdapter.Add(new NetworkAdapter(
                        Convert.ToInt32(moNetworkAdapter["DeviceID"].ToString()),
                        _enabled,
                        NetConnectionName,
                        moNetworkAdapter["Name"].ToString(),
                        _xtra,
                        _mobile_network_name,
                        (Convert.ToBoolean(moNetworkAdapter["NetEnabled"].ToString())) 
                            ? (int)EnumNetEnabledStatus.Enabled 
                            : (int)EnumNetEnabledStatus.Disabled,
                        Convert.ToInt32(moNetworkAdapter["NetConnectionStatus"].ToString()
                        )));

                }
                catch(NullReferenceException)
                {
                    // Ignore some other devices (like the bluetooth), that need user 
                    // interaction to enable or disable.
                }
            }

            return allNetworkAdapter;
        }

        #endregion

        #region Enable Or Disable The Network Adapter

        /// <summary>
        /// Enable Or Disable The NetworkAdapter
        /// </summary>
        /// <returns>
        /// Whether the NetworkAdapter was enabled or disabled successfully
        /// </returns>
        public int EnableOrDisableNetworkAdapter(string strOperation)
        {

            int resultEnableDisableNetworkAdapter = (int)EnumEnableDisableResult.Unknow;
            ManagementObject crtNetworkAdapter = new ManagementObject();

            string strWQuery = string.Format("SELECT DeviceID, ProductName, NetEnabled, NetConnectionStatus FROM Win32_NetworkAdapter " + "WHERE DeviceID = {0}", DeviceId);

            try
            {
                
                ManagementObjectCollection networkAdapters = WMIOperation.WMIQuery(strWQuery);

                foreach (ManagementObject networkAdapter in networkAdapters)
                {
                    crtNetworkAdapter = networkAdapter;
                }

                crtNetworkAdapter.InvokeMethod(strOperation, null);

                Thread.Sleep(500);

                //while (GetNetEnabled() != ((strOperation.Trim() == "Enable") ? (int) EnumNetEnabledStatus.Enabled : (int) EnumNetEnabledStatus.Disabled))
                //{
                //    Thread.Sleep(100);
                //}

                resultEnableDisableNetworkAdapter = (int) EnumEnableDisableResult.Success;

            }
            catch(NullReferenceException)
            {
                // If there is a NullReferenceException, the result of the enable or 
                // disable network adapter operation will be fail
                resultEnableDisableNetworkAdapter = (int)EnumEnableDisableResult.Fail;
            }

            crtNetworkAdapter.Dispose();

            return resultEnableDisableNetworkAdapter;
        }

        #endregion

    }
}

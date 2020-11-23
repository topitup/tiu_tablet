using System;
using Windows.Networking.Connectivity;
using System.IO;

namespace TopitUp
{
    class InternetTools
    {

        public delegate void InternetConnectionChangedHandler(object sender, InternetConnectionChangedEventArgs args);
 
        public static event InternetConnectionChangedHandler InternetConnectionChanged;

        //public static event EventHandler<InternetConnectionChangedEventArgs> InternetConnectionChanged;
 
        static InternetTools()
        {

            NetworkInformation.NetworkStatusChanged += NetworkInformation_NetworkStatusChanged;

            //Observable.FromEvent<NetworkStatusChangedEventHandler, object>(
            //        emit => new NetworkStatusChangedEventHandler((target) => emit(target)),
            //        h => NetworkInformation.NetworkStatusChanged += NetworkInformation_NetworkStatusChanged,
            //        h => NetworkInformation.NetworkStatusChanged -= NetworkInformation_NetworkStatusChanged);

            //NetworkInformation.NetworkStatusChanged += NetworkInformation_NetworkStatusChanged;

            
        }

        private static void NetworkInformation_NetworkStatusChanged(object sender)
        {
            var arg = new InternetConnectionChangedEventArgs { IsConnected = (NetworkInformation.GetInternetConnectionProfile() != null), ConnectionType = InternetConnectionType };

            if (InternetConnectionChanged != null)
                InternetConnectionChanged(null, arg);
        }
 
        public static bool IsConnected { get { return NetworkInformation.GetInternetConnectionProfile() != null; } }

       
 
        public static InternetConnectionType InternetConnectionType
        {
            get
            {
                var currentconnection = NetworkInformation.GetInternetConnectionProfile();
                if (currentconnection == null)
                    return InternetConnectionType.None;

                switch (currentconnection.NetworkAdapter.IanaInterfaceType)
                {
                    case 6:
                        return InternetConnectionType.Cable;
                    case 71:
                        return InternetConnectionType.Wifi;
                    case 243:
                        return InternetConnectionType.Mobile;
                }
           
                return InternetConnectionType.Unknown;
            }
        }
 
    }


 
         
 
    public class InternetConnectionChangedEventArgs : EventArgs
    {
        public bool IsConnected { get; set; }
 
        public InternetConnectionType ConnectionType { get; set; }
    }
 
    public enum InternetConnectionType
    {
        None,
        Cable,
        Wifi,
        Mobile,
        Unknown
    }

}

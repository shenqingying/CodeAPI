using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using Sonluk.Utility;

namespace Sonluk.DataAccess.SAP.Utility
{
    public sealed class Destination
    {
        private Destination() { }

        public static RfcDestination Create(string destinationName)
        {
            return RfcDestinationManager.GetDestination(destinationName);
        }

        public static RfcDestination Create(string destinationName, string secretKey)
        {
            RfcDestination dest = RfcDestinationManager.GetDestination(destinationName);
            RfcCustomDestination custDest = dest.CreateCustomDestination();
            custDest.User = AppConfig.Settings("SAP.User", secretKey);
            custDest.Password = AppConfig.Settings("SAP.Password", secretKey);

            return custDest;
        }

        public static RfcDestination Create(RfcConfigParameters parameters)
        {
            //RfcConfigParameters parameters = new RfcConfigParameters();
            //parameters[RfcConfigParameters.Name] = destinationName;
            //parameters[RfcConfigParameters.User] = AppConfig.Settings("SAP_User", secretKey);
            //parameters[RfcConfigParameters.Password] = AppConfig.Settings("SAP_Password", secretKey);
            //parameters[RfcConfigParameters.Client] = AppConfig.Settings("SAP_Client", secretKey);
            //parameters[RfcConfigParameters.Language] = AppConfig.Settings("SAP_Language", secretKey);
            //parameters[RfcConfigParameters.AppServerHost] = AppConfig.Settings("SAP_AppServerHost", secretKey);
            //parameters[RfcConfigParameters.SystemNumber] = AppConfig.Settings("SAP_SystemNumber", secretKey);
            //parameters[RfcConfigParameters.PoolSize] = AppConfig.Settings("SAP_PoolSize", secretKey);
            //parameters[RfcConfigParameters.PeakConnectionsLimit] = AppConfig.Settings("SAP_PeakConnectionsLimit", secretKey);

            return RfcDestinationManager.GetDestination(parameters);
        }
    }
}

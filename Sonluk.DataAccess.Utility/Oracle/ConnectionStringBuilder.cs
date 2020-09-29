using Oracle.DataAccess.Client;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.Utility.Oracle
{
    public sealed class ConnectionStringBuilder
    {
        public static string Build(string name, string user, string password, string secretKey) 
        {
            OracleConnectionStringBuilder builder = new OracleConnectionStringBuilder(ConfigurationManager.ConnectionStrings[name].ToString());
            builder.UserID = AppConfig.Settings(user, secretKey);
            builder.Password = AppConfig.Settings(password, secretKey);
            return builder.ToString();  
        }
    }
}

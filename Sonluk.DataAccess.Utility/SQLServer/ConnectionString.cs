using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.Utility.SQLServer
{
    public sealed class ConnectionString
    {
        public static string Create(string name,string secretKey)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings[name].ToString());
            builder.UserID = AppConfig.Settings("SQLServerUser", secretKey);
            builder.Password = AppConfig.Settings("SQLServerPassword", secretKey);

            return builder.ToString();
        }
    }
}

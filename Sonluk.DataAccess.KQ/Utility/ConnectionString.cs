using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.KQ.Utility
{
    public sealed class ConnectionString
    {
        public static string Create(string name, string user, string password, string secretKey)
        {
            //获取链接数据库的字符串
            string connectionstring = ConfigurationManager.ConnectionStrings[name].ConnectionString;

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionstring);
            //设置连接超时的时间
            builder.ConnectTimeout = 60;
            //获取或设置连接在被销毁前在连接池中存活的最短时间
            builder.LoadBalanceTimeout = 10000;
            //池中最大的连接数目
            builder.MaxPoolSize = 20;
            //池中最小的连接数目
            builder.MinPoolSize = 10;
            //打开连接池
            builder.Pooling = true;
            //允许异步连接
            builder.AsynchronousProcessing = true;

            builder.UserID = AppConfig.Settings(user, secretKey);

            builder.Password = AppConfig.Settings(password, secretKey);

            return builder.ConnectionString;
        }
    }
}

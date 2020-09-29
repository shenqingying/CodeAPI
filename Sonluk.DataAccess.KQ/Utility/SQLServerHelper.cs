using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Sonluk.DataAccess.KQ.Utility;

namespace Sonluk.DataAccess.KQ
{
    public static class SQLServerHelper
    {
        public static readonly string connectionString = ConnectionString.Create("KQ", "KQ.DB.User", "KQ.DB.Password", "s1wd124q78");

        ///<summary>
        ///执行数据库的增删改操作
        ///</summary>
        ///<remarks>
        ///使用用例
        ///int result=ExecuteNonQuery(commandType.StoredProcedure,"pro_AddUserInfo",new SqlParameter("@Id",12));
        ///</remarks>
        ///<param name="cmdType">SqlCommand命令类型(如存储过程，T-SQL语句等)</param>
        ///<param name="cmdText">存储过程的名字或T-SQL语句</param>
        ///<param name="para">以数组的形式提供SqlCommand命令中用到的参数列表</param>
        ///<returns>返回一个数值表示此SqlCommand命令执行后所影响的行数</returns>
        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] para)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection Connection = new SqlConnection(connectionString))
            {
                SetCommand(cmd, Connection, cmdType, cmdText, para);
                if (Connection.State != ConnectionState.Open)
                {
                    Connection.Open();
                }
                int result = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return result;
            }
        }

        /// <summary>
        /// 执行一条返回结果集的SqlCommand命令
        /// </summary>
        /// <remarks>
        /// 使用示例：
        /// SqlDataReader r = ExecuteReader(CommandType.Text, sql, new SqlParameter("@ISBN", ISBN));
        /// </remarks>
        /// <param name="cmdType">SqlCommand命令类型(如存储过程，T-SQL语句等)</param>
        /// <param name="cmdText">存储过程的名字或T-SQL语句</param>
        /// <param name="para">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个包含结果集的SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(CommandType cmdType, string cmdText, params SqlParameter[] para)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection Connection = new SqlConnection(connectionString);
            SetCommand(cmd, Connection, cmdType, cmdText, para);
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd.Parameters.Clear();
            return reader;
        }

        /// <summary>
        /// 执行一条返回第一条记录第一列的SqlCommand命令
        /// </summary>
        /// <remarks>
        /// 使用示例：
        /// Object obj = ExecuteScalar(CommandType.StoredProcedure, "pro_SelectAllBooksInfo", new SqlParameter("@prodId", 24));
        /// </remarks>
        /// <param name="cmdType">SqlCommand命令类型(如存储过程，T-SQL语句等)</param>
        /// <param name="cmdText">存储过程的名字或T-SQL语句</param>
        /// <param name="para">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个object类型的数据，可以通过 Convert.To{Type}方法转换类型</returns>
        public static object ExecuteScalar(CommandType cmdType, string cmdText, params SqlParameter[] para)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection Connection = new SqlConnection(connectionString))
            {
                SetCommand(cmd, Connection, cmdType, cmdText, para);
                if (Connection.State != ConnectionState.Open)
                {
                    Connection.Open();
                }
                object value = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return value;
            }
        }

        /// <summary>
        /// 对数据表进行操作,返回一个DataTable临时表
        /// </summary>
        /// <remarks>
        /// 使用示例：
        /// DataTable dt = GetDataSet(CommandType.Text, sql , new SqlParameter("@prodId", 24));
        /// </remarks>
        /// <param name="cmdType">SqlCommand命令类型(如存储过程，T-SQL语句等)</param>
        /// <param name="cmdText">存储过程的名字或T-SQL语句</param>
        /// <param name="para">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个DataTable临时数据表</returns>
        public static DataTable GetDataSet(CommandType cmdType, string cmdText, params SqlParameter[] para)
        {
            DataSet ds = new DataSet();
            using (SqlConnection Connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                SetCommand(cmd, Connection, cmdType, cmdText, para);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                cmd.Parameters.Clear();
                return ds.Tables[0];
            }

        }

        ///<summary>
        ///为执行命令准备参数
        ///</summary>
        ///<param name="cmd">SqlCommand 命令</param>
        /// <param name="cmdType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="cmdText">Command text，T-SQL语句 例如 Select * from Products</param>
        /// <param name="para">返回带参数的命令</param>
        private static void SetCommand(SqlCommand cmd, SqlConnection Connection, CommandType cmdType, string cmdText, params SqlParameter[] para)
        {
            cmd.Connection = Connection;
            cmd.CommandText = cmdText;
            cmd.CommandType = cmdType;

            if (para != null)
            {
                foreach (SqlParameter parameter in para)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput) && (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }
    }
}

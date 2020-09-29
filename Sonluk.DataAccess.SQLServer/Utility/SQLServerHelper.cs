using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;


namespace Sonluk.DataAccess.SQLServer.Utility
{
    public abstract class SQLServerHelper
    {
        protected static readonly string connectionString = ConnectionString.Create("","");

        public static SqlDataReader ExecuteProcedure(string spName)
        {
            return ExecuteProcedure(spName, null);
        }

        public static SqlDataReader ExecuteProcedure(string spName, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);       
            try
            {
                PrepareCommand(cmd, conn, null, spName,commandParameters);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
          
        }
            
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,string spName,SqlParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = spName;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = CommandType.StoredProcedure;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
    }
}

using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.CRM
{
    public class SYS_CS : ISYS_CS
    {
        private const string SQL_Update = "UPDATE CRM_SYS_CS SET CSNAME = @CSNAME ,CS = @CS WHERE ID = @ID";
        private const string SQL_Read = "CRM_SYS_CS_READ";//SELECT * FROM CRM_SYS_CS WHERE ID = @ID
        public int Update(CRM_SYS_CS model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@ID",model.ID),
                                       new SqlParameter("@CS",model.CS),
                                       new SqlParameter("@CSNAME",model.CSNAME)
                                   };
            return SQLServerHelper.ExecuteNonQuery(CommandType.Text, SQL_Update, parms);
        }
        public IList<CRM_SYS_CS> Read(int ID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@ID",ID)
                                   };
            IList<CRM_SYS_CS> node = new List<CRM_SYS_CS>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read, parms))
                {
                    while (sdr.Read())
                    {
                        node.Add(ReadDataToObj(sdr));
                    }
                }
            }
            catch (Exception e )
            {
                
                throw new ApplicationException(e.Message);
            }
            return node;
        }
        private CRM_SYS_CS ReadDataToObj(SqlDataReader sdr)
        {
            CRM_SYS_CS node = new CRM_SYS_CS();
            node.ID = Convert.ToInt32(sdr["ID"]);
            node.CS = Convert.ToInt32(sdr["CS"]);
            node.CSNAME = Convert.ToString(sdr["CSNAME"]);
            return node;
        } 


        private int Binning(CommandType type, string sql, SqlParameter[] parms)
        {
            int ID = 0;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(type, sql, parms))
                {
                    if (sdr.Read())
                    {
                        ID = Convert.ToInt32(sdr["ID"]);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return ID;
        }
    }
}

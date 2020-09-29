using Oracle.DataAccess.Client;
using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.DataAccess.Utility.Oracle;
using System.Data;
using Sonluk.DataAccess.OA.Utility;
using Sonluk.IDataAccess.CRM;
using System.Data.SqlClient;

namespace Sonluk.DataAccess.RMS.CRM
{
    public class CRM_OA_FLOW : ICRM_OA_FLOW
    {
        //private const string SQL_ReadFROMMAIN_1801 = "SELECT * FROM FORMMAIN_1801";
        private const string SQL_ReadOA_TRANSMIT = "SELECT * FROM CRM_OA_TRANSMIT WHERE (OAZT = 1 OR OAZT = 3) and isdelete = 0";

        public IList<CRM_OA_TRANSMIT> ReadOA_TRANSMIT()
        {
            IList<CRM_OA_TRANSMIT> nodes = new List<CRM_OA_TRANSMIT>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text,SQL_ReadOA_TRANSMIT,null))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToOBJ(sdr));
                    }
                }
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }
            return nodes;
        }



        private CRM_OA_TRANSMIT ReadDataToOBJ(SqlDataReader sdr)
        {
            CRM_OA_TRANSMIT node = new CRM_OA_TRANSMIT();
            node.ID = Convert.ToInt32(sdr["ID"]);
            node.OAID = Convert.ToString(sdr["OAID"]);
            node.OACSBH = Convert.ToInt32(sdr["OACSBH"]);
            node.OACSLB = Convert.ToInt32(sdr["OACSLB"]);
            node.OAZT = Convert.ToInt32(sdr["OAZT"]);
            node.CJSJ = Convert.ToString(sdr["CJSJ"]);
            node.ISDELETE = Convert.ToBoolean(sdr["ISDELETE"]);
            return node;
        }

        public void OA_FinishUpdate(string table,string idName ,int id,int isactive)
        {

            string sql = "UPDATE " + table + " SET ISACTIVE = @isactive WHERE " + idName + " = @id";
            SqlParameter[] parms = {
                                       new SqlParameter("@id",id),
                                       new SqlParameter("@isactive",isactive)
                                   };
            SQLServerHelper.ExecuteNonQuery(CommandType.Text, sql, parms);
        }




    }
}

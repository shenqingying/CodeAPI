using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.CRM
{
    public class HG_RYKQ : IHG_RYKQ
    {
        private const string SQL_Create = "CRM_HG_RYKQ_Create";
        //private const string SQL_Update = "CRM_KH_GROUP_KH_Update";
        private const string SQL_Delete = "CRM_HG_RYKQ_Delete";
        private const string SQL_ReadBySTAFFID = "CRM_HG_RYKQ_ReadBySTAFFID";//@"SELECT CRM_HG_RYKQ.KQDZID,ISNULL((SELECT KQDZ FROM CRM_HG_KQDZ WHERE KQDZID = CRM_HG_RYKQ.KQDZID),' ') AS KQDZ  FROM CRM_HG_RYKQ INNER JOIN CRM_HG_KQDZ ON  CRM_HG_RYKQ.KQDZID = CRM_HG_KQDZ.KQDZID WHERE CRM_HG_RYKQ = @STAFFID";

        public int Create(int STAFFID, int KQDZID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID),
                                       new SqlParameter("@KQDZID",KQDZID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }
      







        public IList<string[]> ReadBySTAFFID(int STAFFID)
        {
            IList<string[]> nodes = new List<string[]>();

            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };

            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadBySTAFFID, parms))
                {
                    while (sdr.Read())
                    {
                        string[] node = new string[2];
                        node[0] = Convert.ToString(sdr["KQDZID"]);
                        node[1] = Convert.ToString(sdr["KQDZ"]);
                        nodes.Add(node);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;

        }
        public int Delete(int STAFFID, int KQDZID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID),
                                       new SqlParameter("@KQDZID",KQDZID)
                                   };
            return SQLServerHelper.ExecuteNonQuery(CommandType.StoredProcedure, SQL_Delete, parms);
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

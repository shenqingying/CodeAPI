using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.CRM
{
    public class HG_STAFFDUTY : IHG_STAFFDUTY
    {
        private const string SQL_Create = "CRM_HG_STAFFDUTY_Create";
        //private const string SQL_Update = "CRM_HG_STAFFDUTY_Update";
        private const string SQL_ReadBySTAFFID = "CRM_HG_STAFFDUTY_ReadBySTAFFID";//"SELECT CRM_HG_STAFFDUTY.DUTYID ,ISNULL((SELECT DUTYNAME FROM CRM_HG_DUTY WHERE CRM_HG_DUTY.DUTYID = CRM_HG_STAFFDUTY.DUTYID),' ') AS DUTYNAME FROM CRM_HG_STAFFDUTY WHERE CRM_HG_STAFFDUTY.STAFFID = @STAFFID";
        private const string SQL_Delete = "DELETE FROM CRM_HG_STAFFDUTY WHERE STAFFID = @STAFFID AND DUTYID = @DUTYID";
        private const string SQL_DeleteByStaffid = "DELETE FROM CRM_HG_STAFFDUTY where STAFFID = @STAFFID";
        public int Create(int STAFFID, int DUTYID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID),
                                       new SqlParameter("@DUTYID",DUTYID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

       
        
        public IList<string[]> ReadBySTAFFID(int STAFFID)
        {
            IList<string[]> nodes = new List<string[]>();

            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID),
                                      
                                   };

            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadBySTAFFID, parms))
                {
                    while (sdr.Read())
                    {
                        string[] node = new string[2];
                        node[0] = Convert.ToString(sdr["DUTYID"]);
                        node[1] = Convert.ToString(sdr["DUTYNAME"]);
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


        public int Delete(int STAFFID, int DUTYID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID),
                                       new SqlParameter("@DUTYID",DUTYID)
                                   };
            return SQLServerHelper.ExecuteNonQuery(CommandType.StoredProcedure, SQL_Delete, parms);

        }
        public int DeleteByStaffid(int STAFFID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };
            //return Binning(CommandType.Text, SQL_Delete_STAFFROLEByStaffid, parms);
            return SQLServerHelper.ExecuteNonQuery(CommandType.Text, SQL_DeleteByStaffid, parms);
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


                        if (sql == SQL_Delete)
                        {
                            ID = Convert.ToInt32(sdr["Return Value"]);
                        }
                        else
                        {
                            ID = Convert.ToInt32(sdr["ID"]);
                        }


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

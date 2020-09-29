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
    public class COST_LKAEachYEAR : ICOST_LKAEachYEAR
    {
        private const string SQL_Create = "CRM_COST_LKAEachYEAR_Create";
        private const string SQL_UpdateByTTID = "CRM_COST_LKAEachYEAR_UpdateByTTID";
        private const string SQL_ReadByParam = "CRM_COST_LKAEachYEAR_ReadByParam";
        private const string SQL_DeleteByTTID = "CRM_COST_LKAEachYEAR_DeleteByTTID";

        public int Create(CRM_COST_LKAEachYEAR model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKAYEARTTID", model.LKAYEARTTID),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@HTYEAR", model.HTYEAR),
                                        new SqlParameter("@MONTHCOUNT", model.MONTHCOUNT),
                                        new SqlParameter("@FY", model.FY),
                                        new SqlParameter("@CCJ", model.CCJ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int UpdateByTTID(int LKAYEARTTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKAYEARTTID", LKAYEARTTID)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_UpdateByTTID, parms);
        }

        public IList<CRM_COST_LKAEachYEAR> ReadByParam(CRM_COST_LKAEachYEAR model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@EACHID", model.EACHID),
                                        new SqlParameter("@LKAYEARTTID", model.LKAYEARTTID),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@HTYEAR", model.HTYEAR)

                                   };
            IList<CRM_COST_LKAEachYEAR> nodes = new List<CRM_COST_LKAEachYEAR>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByParam, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }
        public int DeleteByTTID(int LKAYEARTTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKAYEARTTID", LKAYEARTTID)
                                       

                                   };
            return Binning(CommandType.StoredProcedure, SQL_DeleteByTTID, parms);
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

        private CRM_COST_LKAEachYEAR ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_LKAEachYEAR node = new CRM_COST_LKAEachYEAR();
            node.EACHID = Convert.ToInt32(sdr["EACHID"]);
            node.LKAYEARTTID = Convert.ToInt32(sdr["LKAYEARTTID"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.HTYEAR = Convert.ToString(sdr["HTYEAR"]);
            node.MONTHCOUNT = Convert.ToInt32(sdr["MONTHCOUNT"]);
            node.FY = Convert.ToDecimal(sdr["FY"]);
            node.CCJ = Convert.ToDecimal(sdr["CCJ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);

            return node;
        }




    }
}

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
    public class COST_LKAHXZLMD : ICOST_LKAHXZLMD
    {
        private const string SQL_Create = "CRM_COST_LKAHXZLMD_Create";
        private const string SQL_Update = "CRM_COST_LKAHXZLMD_Update";
        private const string SQL_ReadByParam = "CRM_COST_LKAHXZLMD_ReadByParam";
        private const string SQL_Delete = "CRM_COST_LKAHXZLMD_Delete";

        public int Create(CRM_COST_LKAHXZLMD model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXZLMXID", model.HXZLMXID),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@BEIZ", model.BEIZ)



                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_LKAHXZLMD model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXZLMDMXID", model.HXZLMDMXID),
                                        new SqlParameter("@BEIZ", model.BEIZ)



                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
        public IList<CRM_COST_LKAHXZLMD> ReadByParam(CRM_COST_LKAHXZLMD model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXZLMDMXID", model.HXZLMDMXID),
                                        new SqlParameter("@HXZLMXID", model.HXZLMXID),
                                        new SqlParameter("@CRMID", model.CRMID),
                                        new SqlParameter("@MC", model.MC)


                                   };
            IList<CRM_COST_LKAHXZLMD> nodes = new List<CRM_COST_LKAHXZLMD>();
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


        public int Delete(int HXZLMDMXID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXZLMDMXID", HXZLMDMXID)
                                       

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
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

        private CRM_COST_LKAHXZLMD ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_LKAHXZLMD node = new CRM_COST_LKAHXZLMD();
            node.HXZLMDMXID = Convert.ToInt32(sdr["HXZLMDMXID"]);
            node.HXZLMXID = Convert.ToInt32(sdr["HXZLMXID"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.MC = Convert.ToString(sdr["MC"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.KHZZSJ = Convert.ToString(sdr["KHZZSJ"]);

            return node;
        }












    }
}

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
    public class COST_LKAHXZLMX_LKAHXDJMX : ICOST_LKAHXZLMX_LKAHXDJMX
    {
        private const string SQL_Create = "CRM_COST_LKAHXZLMX_LKAHXDJMX_Create";
        private const string SQL_Update = "CRM_COST_LKAHXZLMX_LKAHXDJMX_Update";     //没写存储过程
        private const string SQL_ReadByParam = "CRM_COST_LKAHXZLMX_LKAHXDJMX_ReadByParam";
        private const string SQL_Delete = "CRM_COST_LKAHXZLMX_LKAHXDJMX_Delete";
        private const string SQL_DeleteByHXDJMXID = "CRM_COST_LKAHXZLMX_LKAHXDJMX_DeleteByHXDJMXID";

        public int Create(CRM_COST_LKAHXZLMX_LKAHXDJMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXDJMXID", model.HXDJMXID),
                                        new SqlParameter("@HXZLMXID", model.HXZLMXID)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_LKAHXZLMX_LKAHXDJMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXDJMXID", model.HXDJMXID),
                                        new SqlParameter("@HXZLMXID", model.HXZLMXID)



                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
        public IList<CRM_COST_LKAHXZLMX_LKAHXDJMX> ReadByParam(CRM_COST_LKAHXZLMX_LKAHXDJMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXDJMXID", model.HXDJMXID),
                                        new SqlParameter("@HXZLMXID", model.HXZLMXID)


                                   };
            IList<CRM_COST_LKAHXZLMX_LKAHXDJMX> nodes = new List<CRM_COST_LKAHXZLMX_LKAHXDJMX>();
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


        public int Delete(CRM_COST_LKAHXZLMX_LKAHXDJMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXDJMXID", model.HXDJMXID),
                                        new SqlParameter("@HXZLMXID", model.HXZLMXID)
                                       

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }

        public int DeleteByHXDJMXID(int HXDJMXID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXDJMXID", HXDJMXID)
                                       

                                   };
            return Binning(CommandType.StoredProcedure, SQL_DeleteByHXDJMXID, parms);
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

        private CRM_COST_LKAHXZLMX_LKAHXDJMX ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_LKAHXZLMX_LKAHXDJMX node = new CRM_COST_LKAHXZLMX_LKAHXDJMX();
            node.HXDJMXID = Convert.ToInt32(sdr["HXDJMXID"]);
            node.HXZLMXID = Convert.ToInt32(sdr["HXZLMXID"]);



            return node;
        }










    }
}

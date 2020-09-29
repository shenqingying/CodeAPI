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
    public class COST_LKAYEARCOST_LKAHXZLMX : ICOST_LKAYEARCOST_LKAHXZLMX
    {
        private const string SQL_Create = "CRM_COST_LKAYEARCOST_LKAHXZLMX_Create";
        private const string SQL_Update = "CRM_COST_LKAYEARCOST_LKAHXZLMX_Update";
        private const string SQL_ReadByParam = "CRM_COST_LKAYEARCOST_LKAHXZLMX_ReadByParam";
        private const string SQL_Delete = "CRM_COST_LKAYEARCOST_LKAHXZLMX_Delete";
        private const string SQL_DeleteByHXZLMXID = "CRM_COST_LKAYEARCOST_LKAHXZLMX_DeleteByHXZLMXID";
        private const string SQL_ReadByTTID = "CRM_COST_LKAYEARCOST_LKAHXZLMX_ReadByTTID";

        public int Create(CRM_COST_LKAYEARCOST_LKAHXZLMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@COSTID", model.COSTID),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@HXZLMXID", model.HXZLMXID)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_LKAYEARCOST_LKAHXZLMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@COSTID", model.COSTID),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@HXZLMXID", model.HXZLMXID)



                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
        public IList<CRM_COST_LKAYEARCOST_LKAHXZLMX> ReadByParam(CRM_COST_LKAYEARCOST_LKAHXZLMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@COSTID", model.COSTID),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@HXZLMXID", model.HXZLMXID)


                                   };
            IList<CRM_COST_LKAYEARCOST_LKAHXZLMX> nodes = new List<CRM_COST_LKAYEARCOST_LKAHXZLMX>();
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
        public IList<CRM_COST_LKAYEARCOST_LKAHXZLMX> ReadByTTID(CRM_COST_LKAYEARCOST_LKAHXZLMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@COSTID", model.COSTID),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID)
                                   };
            IList<CRM_COST_LKAYEARCOST_LKAHXZLMX> nodes = new List<CRM_COST_LKAYEARCOST_LKAHXZLMX>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByTTID, parms))
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


        public int Delete(CRM_COST_LKAYEARCOST_LKAHXZLMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@COSTID", model.COSTID),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@HXZLMXID", model.HXZLMXID)
                                       

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }

        public int DeleteByHXZLMXID(int HXZLMXID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXZLMXID", HXZLMXID)
                                       

                                   };
            return Binning(CommandType.StoredProcedure, SQL_DeleteByHXZLMXID, parms);
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

        private CRM_COST_LKAYEARCOST_LKAHXZLMX ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_LKAYEARCOST_LKAHXZLMX node = new CRM_COST_LKAYEARCOST_LKAHXZLMX();
            node.COSTID = Convert.ToInt32(sdr["COSTID"]);
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.HXZLMXID = Convert.ToInt32(sdr["HXZLMXID"]);



            return node;
        }





    }
}

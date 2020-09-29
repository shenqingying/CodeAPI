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
    public class COST_JXSHXDJMX_COST : ICOST_JXSHXDJMX_COST
    {
        private const string SQL_Create = "CRM_COST_JXSHXDJMX_COST_Create";
        private const string SQL_Update = "CRM_COST_JXSHXDJMX_COST_Update"; //未实现
        private const string SQL_ReadByParam = "CRM_COST_JXSHXDJMX_COST_ReadByParam";
        private const string SQL_Delete = "CRM_COST_JXSHXDJMX_COST_Delete";
        private const string SQL_DeleteByHXDJMXID = "CRM_COST_JXSHXDJMX_COST_DeleteByHXDJMXID";

        public int Create(CRM_COST_JXSHXDJMX_COST model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@COSTID", model.COSTID),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@HXDJMXID", model.HXDJMXID)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_JXSHXDJMX_COST model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@COSTID", model.COSTID),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@HXDJMXID", model.HXDJMXID)



                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
        public IList<CRM_COST_JXSHXDJMX_COST> ReadByParam(CRM_COST_JXSHXDJMX_COST model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@COSTID", model.COSTID),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@HXDJMXID", model.HXDJMXID)


                                   };
            IList<CRM_COST_JXSHXDJMX_COST> nodes = new List<CRM_COST_JXSHXDJMX_COST>();
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
        //public IList<CRM_COST_JXSHXDJMX_COST> ReadByTTID(CRM_COST_JXSHXDJMX_COST model)
        //{
        //    SqlParameter[] parms = {
        //                                new SqlParameter("@COSTID", model.COSTID),
        //                                new SqlParameter("@COSTITEMID", model.COSTITEMID)
        //                           };
        //    IList<CRM_COST_JXSHXDJMX_COST> nodes = new List<CRM_COST_JXSHXDJMX_COST>();
        //    try
        //    {
        //        using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByTTID, parms))
        //        {
        //            while (sdr.Read())
        //            {
        //                nodes.Add(ReadDataToObj(sdr));
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //        throw new ApplicationException(e.Message);
        //    }
        //    return nodes;
        //}


        public int Delete(CRM_COST_JXSHXDJMX_COST model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@COSTID", model.COSTID),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@HXDJMXID", model.HXDJMXID)
                                       

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

        private CRM_COST_JXSHXDJMX_COST ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_JXSHXDJMX_COST node = new CRM_COST_JXSHXDJMX_COST();
            node.COSTID = Convert.ToInt32(sdr["COSTID"]);
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.HXDJMXID = Convert.ToInt32(sdr["HXDJMXID"]);



            return node;
        }
    }
}

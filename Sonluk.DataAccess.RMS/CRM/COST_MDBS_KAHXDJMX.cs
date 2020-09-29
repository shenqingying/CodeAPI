﻿using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.CRM
{
    public class COST_MDBS_KAHXDJMX : ICOST_MDBS_KAHXDJMX
    {
        private const string SQL_Create = "CRM_COST_MDBS_KAHXDJMX_Create";
        private const string SQL_ReadByParam = "CRM_COST_MDBS_KAHXDJMX_ReadByParam";
        private const string SQL_DeleteByHXDJMXID = "CRM_COST_MDBS_KAHXDJMX_DeleteByHXDJMXID";

        public int Create(CRM_COST_MDBS_KAHXDJMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXDJMXID", model.HXDJMXID),
                                        new SqlParameter("@MDBSHXID", model.MDBSHXID)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }


        public IList<CRM_COST_MDBS_KAHXDJMX> ReadByParam(CRM_COST_MDBS_KAHXDJMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXDJMXID", model.HXDJMXID),
                                        new SqlParameter("@MDBSHXID", model.MDBSHXID)


                                   };
            IList<CRM_COST_MDBS_KAHXDJMX> nodes = new List<CRM_COST_MDBS_KAHXDJMX>();
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

        private CRM_COST_MDBS_KAHXDJMX ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_MDBS_KAHXDJMX node = new CRM_COST_MDBS_KAHXDJMX();
            node.HXDJMXID = Convert.ToInt32(sdr["HXDJMXID"]);
            node.MDBSHXID = Convert.ToInt32(sdr["MDBSHXID"]);

            return node;
        }





    }
}

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
    public class COST_ZZFMX : ICOST_ZZFMX
    {
        private const string SQL_Create = "CRM_COST_ZZFMX_Create";
        private const string SQL_Update = "CRM_COST_ZZFMX_Update";
        private const string SQL_ReadByParam = "CRM_COST_ZZFMX_ReadByParam";
        private const string SQL_Delete = "CRM_COST_ZZFMX_Delete";
        public int Create(CRM_COST_ZZFMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@TTID", model.TTID),
                                        new SqlParameter("@GGXMID", model.GGXMID),
                                        new SqlParameter("@PRICE", model.PRICE),
                                        new SqlParameter("@QUANTITY", model.QUANTITY),
                                        new SqlParameter("@AMOUNT", model.AMOUNT),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                      
                                       

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_ZZFMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@TTID", model.TTID),
                                        new SqlParameter("@GGXMID", model.GGXMID),
                                        new SqlParameter("@PRICE", model.PRICE),
                                        new SqlParameter("@QUANTITY", model.QUANTITY),
                                        new SqlParameter("@AMOUNT", model.AMOUNT),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@MXID", model.MXID),
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_COST_ZZFMX> ReadByParam(CRM_COST_ZZFMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@MXID", model.MXID),
                                        new SqlParameter("@TTID", model.TTID),
                                        new SqlParameter("@GGXMID", model.GGXMID)
                                   };
            IList<CRM_COST_ZZFMX> nodes = new List<CRM_COST_ZZFMX>();
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
        public int Delete(int MXID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@MXID", MXID)
                                       

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

        private CRM_COST_ZZFMX ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_ZZFMX node = new CRM_COST_ZZFMX();
            node.MXID = Convert.ToInt32(sdr["MXID"]);
            node.TTID = Convert.ToInt32(sdr["TTID"]);
            node.GGXMID = Convert.ToInt32(sdr["GGXMID"]);
            node.PRICE = Convert.ToDouble(sdr["PRICE"]);
            node.QUANTITY = Convert.ToDouble(sdr["QUANTITY"]);
            node.AMOUNT = Convert.ToDouble(sdr["AMOUNT"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.GGXMIDDES = Convert.ToString(sdr["GGXMIDDES"]);
            return node;
        }

    }
}

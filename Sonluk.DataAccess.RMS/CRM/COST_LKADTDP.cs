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
    public class COST_LKADTDP : ICOST_LKADTDP
    {
        private const string SQL_Create = "CRM_COST_LKADTDP_Create";
        private const string SQL_Update = "CRM_COST_LKADTDP_Update";
        private const string SQL_ReadByParam = "CRM_COST_LKADTDP_ReadByParam";
        private const string SQL_Delete = "CRM_COST_LKADTDP_Delete";

        public int Create(CRM_COST_LKADTDP model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKAFYTTID", model.LKAFYTTID),
                                        new SqlParameter("@SAPCP", model.SAPCP),
                                        new SqlParameter("@CCJ", model.CCJ),
                                        new SqlParameter("@ZCGJ", model.ZCGJ),
                                        new SqlParameter("@CXGJ", model.CXGJ),
                                        new SqlParameter("@ZCSJ", model.ZCSJ),
                                        new SqlParameter("@CXSJ", model.CXSJ),
                                        new SqlParameter("@JHSL", model.JHSL),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_LKADTDP model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@DPID", model.DPID),
                                        new SqlParameter("@LKAFYTTID", model.LKAFYTTID),
                                        new SqlParameter("@SAPCP", model.SAPCP),
                                        new SqlParameter("@CCJ", model.CCJ),
                                        new SqlParameter("@ZCGJ", model.ZCGJ),
                                        new SqlParameter("@CXGJ", model.CXGJ),
                                        new SqlParameter("@ZCSJ", model.ZCSJ),
                                        new SqlParameter("@CXSJ", model.CXSJ),
                                        new SqlParameter("@JHSL", model.JHSL),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@XGR", model.XGR)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
        public IList<CRM_COST_LKADTDP> ReadByParam(CRM_COST_LKADTDP model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@DPID", model.DPID),
                                        new SqlParameter("@LKAFYTTID", model.LKAFYTTID),
                                        new SqlParameter("@SAPCP", model.SAPCP),
                                        new SqlParameter("@CPMC", model.CPMC)


                                   };
            IList<CRM_COST_LKADTDP> nodes = new List<CRM_COST_LKADTDP>();
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


        public int Delete(int DPID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@DPID", DPID)
                                       

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

        private CRM_COST_LKADTDP ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_LKADTDP node = new CRM_COST_LKADTDP();
            node.DPID = Convert.ToInt32(sdr["DPID"]);
            node.LKAFYTTID = Convert.ToInt32(sdr["LKAFYTTID"]);
            node.SAPCP = Convert.ToString(sdr["SAPCP"]);
            node.CCJ = Convert.ToDecimal(sdr["CCJ"]);
            node.ZCGJ = Convert.ToDecimal(sdr["ZCGJ"]);
            node.CXGJ = Convert.ToDecimal(sdr["CXGJ"]);
            node.ZCSJ = Convert.ToDecimal(sdr["ZCSJ"]);
            node.CXSJ = Convert.ToDecimal(sdr["CXSJ"]);
            node.JHSL = Convert.ToInt32(sdr["JHSL"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");

            node.CPMC = Convert.ToString(sdr["CPMC"]);
            node.ISCXZ = Convert.ToInt32(sdr["ISCXZ"]);
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);

            return node;
        }







    }
}

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
    public class COST_KADTDP : ICOST_KADTDP
    {
        private const string SQL_Create = "CRM_COST_KADTDP_Create";
        private const string SQL_Update = "CRM_COST_KADTDP_Update";
        private const string SQL_ReadByParam = "CRM_COST_KADTDP_ReadByParam";
        private const string SQL_Delete = "CRM_COST_KADTDP_Delete";

        public int Create(CRM_COST_KADTDP model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KADTTTID", model.KADTTTID),
                                        new SqlParameter("@SAPCP", model.SAPCP),
                                        new SqlParameter("@ZCGJ", model.ZCGJ),
                                        new SqlParameter("@CXGJ", model.CXGJ),
                                        new SqlParameter("@ZCSJ", model.ZCSJ),
                                        new SqlParameter("@CXSJ", model.CXSJ),
                                        new SqlParameter("@BHSL", model.BHSL),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_KADTDP model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@DPID", model.DPID),
                                        new SqlParameter("@SAPCP", model.SAPCP),
                                        new SqlParameter("@ZCGJ", model.ZCGJ),
                                        new SqlParameter("@CXGJ", model.CXGJ),
                                        new SqlParameter("@ZCSJ", model.ZCSJ),
                                        new SqlParameter("@CXSJ", model.CXSJ),
                                        new SqlParameter("@BHSL", model.BHSL),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@XGR", model.XGR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_COST_KADTDP> ReadByParam(CRM_COST_KADTDP model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@DPID", model.DPID),
                                        new SqlParameter("@KADTTTID", model.KADTTTID),
                                        new SqlParameter("@SAPCP", model.SAPCP)


                                   };
            IList<CRM_COST_KADTDP> nodes = new List<CRM_COST_KADTDP>();
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

        private CRM_COST_KADTDP ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_KADTDP node = new CRM_COST_KADTDP();
            node.DPID = Convert.ToInt32(sdr["DPID"]);
            node.KADTTTID = Convert.ToInt32(sdr["KADTTTID"]);
            node.SAPCP = Convert.ToString(sdr["SAPCP"]);
            node.ZCGJ = Convert.ToDecimal(sdr["ZCGJ"]);
            node.CXGJ = Convert.ToDecimal(sdr["CXGJ"]);
            node.ZCSJ = Convert.ToDecimal(sdr["ZCSJ"]);
            node.CXSJ = Convert.ToDecimal(sdr["CXSJ"]);
            node.BHSL = Convert.ToInt32(sdr["BHSL"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");

            node.CPMC = Convert.ToString(sdr["CPMC"]);
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
            

            return node;
        }





    }
}

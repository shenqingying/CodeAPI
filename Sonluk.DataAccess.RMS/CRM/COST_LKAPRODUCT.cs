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
    public class COST_LKAPRODUCT : ICOST_LKAPRODUCT
    {
        private const string SQL_Create = "CRM_COST_LKAPRODUCT_Create";
        private const string SQL_Update = "CRM_COST_LKAPRODUCT_Update";
        private const string SQL_ReadByParam = "CRM_COST_LKAPRODUCT_ReadByParam";
        private const string SQL_Delete = "CRM_COST_LKAPRODUCT_Delete";

        public int Create(CRM_COST_LKAPRODUCT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@SAPCP", model.SAPCP),
                                        new SqlParameter("@CPMC", model.CPMC),
                                        new SqlParameter("@CLASS1", model.CLASS1),
                                        new SqlParameter("@CLASS2", model.CLASS2),
                                        new SqlParameter("@CLASS3", model.CLASS3),
                                        new SqlParameter("@CPLXID", model.CPLXID),
                                        new SqlParameter("@BZNUM", model.BZNUM),
                                        new SqlParameter("@PRICE_OUT", model.PRICE_OUT),
                                        new SqlParameter("@PRICE_IN", model.PRICE_IN),
                                        new SqlParameter("@PROMOTION", model.PROMOTION),
                                        new SqlParameter("@PROFIT_OUT", model.PROFIT_OUT),
                                        new SqlParameter("@PROFIT_IN", model.PROFIT_IN),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@XGR", model.XGR),
                                        new SqlParameter("@ZCGJ", model.ZCGJ),
                                        new SqlParameter("@CXGJ", model.CXGJ),
                                        new SqlParameter("@ZCSJ", model.ZCSJ),
                                        new SqlParameter("@CXSJ", model.CXSJ),
                                        new SqlParameter("@ISCXZ", model.ISCXZ)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_LKAPRODUCT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@SAPCP", model.SAPCP),
                                        new SqlParameter("@CPMC", model.CPMC),
                                        new SqlParameter("@CLASS1", model.CLASS1),
                                        new SqlParameter("@CLASS2", model.CLASS2),
                                        new SqlParameter("@CLASS3", model.CLASS3),
                                        new SqlParameter("@CPLXID", model.CPLXID),
                                        new SqlParameter("@BZNUM", model.BZNUM),
                                        new SqlParameter("@PRICE_OUT", model.PRICE_OUT),
                                        new SqlParameter("@PRICE_IN", model.PRICE_IN),
                                        new SqlParameter("@PROMOTION", model.PROMOTION),
                                        new SqlParameter("@PROFIT_OUT", model.PROFIT_OUT),
                                        new SqlParameter("@PROFIT_IN", model.PROFIT_IN),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@XGR", model.XGR),
                                        new SqlParameter("@ZCGJ", model.ZCGJ),
                                        new SqlParameter("@CXGJ", model.CXGJ),
                                        new SqlParameter("@ZCSJ", model.ZCSJ),
                                        new SqlParameter("@CXSJ", model.CXSJ),
                                        new SqlParameter("@ISCXZ", model.ISCXZ)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_COST_LKAPRODUCT> ReadByParam(CRM_COST_LKAPRODUCT model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@SAPCP", model.SAPCP),
                                        new SqlParameter("@CPMC", model.CPMC),
                                        new SqlParameter("@CLASS1", model.CLASS1),
                                        new SqlParameter("@CLASS2", model.CLASS2),
                                        new SqlParameter("@CLASS3", model.CLASS3),
                                        new SqlParameter("@CPLXID", model.CPLXID),
                                        new SqlParameter("@ISCXZ", model.ISCXZ)
                                   };
            IList<CRM_COST_LKAPRODUCT> nodes = new List<CRM_COST_LKAPRODUCT>();
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
        public int Delete(string SAPCP)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@SAPCP", SAPCP)
                                       

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

        private CRM_COST_LKAPRODUCT ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_LKAPRODUCT node = new CRM_COST_LKAPRODUCT();
            node.SAPCP = Convert.ToString(sdr["SAPCP"]);
            node.CPMC = Convert.ToString(sdr["CPMC"]);
            node.CLASS1 = Convert.ToInt32(sdr["CLASS1"]);
            node.CLASS2 = Convert.ToInt32(sdr["CLASS2"]);
            node.CLASS3 = Convert.ToInt32(sdr["CLASS3"]);
            node.CPLXID = Convert.ToInt32(sdr["CPLXID"]);
            node.BZNUM = Convert.ToInt32(sdr["BZNUM"]);
            node.PRICE_OUT = Convert.ToDouble(sdr["PRICE_OUT"]);
            node.PRICE_IN = Convert.ToDouble(sdr["PRICE_IN"]);
            node.PROMOTION = Convert.ToDouble(sdr["PROMOTION"]);
            node.PROFIT_OUT = Convert.ToDouble(sdr["PROFIT_OUT"]);
            node.PROFIT_IN = Convert.ToDouble(sdr["PROFIT_IN"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGRDES = Convert.ToString(sdr["XGRDES"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.ZCGJ = Convert.ToDecimal(sdr["ZCGJ"]);
            node.CXGJ = Convert.ToDecimal(sdr["CXGJ"]);
            node.ZCSJ = Convert.ToDecimal(sdr["ZCSJ"]);
            node.CXSJ = Convert.ToDecimal(sdr["CXSJ"]);
            node.ISCXZ = Convert.ToInt32(sdr["ISCXZ"]);
            return node;
        }








    }
}

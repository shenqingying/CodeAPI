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
    public class COST_CXHDTC : ICOST_CXHDTC
    {

        private const string SQL_Create = "CRM_COST_CXHDTC_Create";
        private const string SQL_Update = "CRM_COST_CXHDTC_Update";
        private const string SQL_ReadByParam = "CRM_COST_CXHDTC_ReadByParam";
        private const string SQL_Delete = "CRM_COST_CXHDTC_Delete";

        public int Create(CRM_COST_CXHDTC model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CXHDID", model.CXHDID),
                                        new SqlParameter("@TCNR", model.TCNR),
                                        new SqlParameter("@TCJE", model.TCJE),
                                        new SqlParameter("@GIFT", model.GIFT),
                                        new SqlParameter("@GIFTPRICE", model.GIFTPRICE),
                                        new SqlParameter("@TCCOUNT", model.TCCOUNT),
                                        new SqlParameter("@YJXS", model.YJXS),
                                        new SqlParameter("@YJLPJE", model.YJLPJE),
                                        new SqlParameter("@FB", model.FB),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_CXHDTC model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@TCID", model.TCID),
                                        new SqlParameter("@TCNR", model.TCNR),
                                        new SqlParameter("@TCJE", model.TCJE),
                                        new SqlParameter("@GIFT", model.GIFT),
                                        new SqlParameter("@GIFTPRICE", model.GIFTPRICE),
                                        new SqlParameter("@TCCOUNT", model.TCCOUNT),
                                        new SqlParameter("@YJXS", model.YJXS),
                                        new SqlParameter("@YJLPJE", model.YJLPJE),
                                        new SqlParameter("@FB", model.FB),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@XGR", model.XGR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_COST_CXHDTC> ReadByParam(CRM_COST_CXHDTC model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@TCID", model.TCID),
                                        new SqlParameter("@CXHDID", model.CXHDID)

                                   };
            IList<CRM_COST_CXHDTC> nodes = new List<CRM_COST_CXHDTC>();
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
        public int Delete(int TCID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@TCID", TCID)
                                       

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

        private CRM_COST_CXHDTC ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_CXHDTC node = new CRM_COST_CXHDTC();
            node.TCID = Convert.ToInt32(sdr["TCID"]);
            node.CXHDID = Convert.ToInt32(sdr["CXHDID"]);
            node.HXM = Convert.ToInt32(sdr["HXM"]);
            node.TCNR = Convert.ToString(sdr["TCNR"]);
            node.TCJE = Convert.ToDecimal(sdr["TCJE"]);
            node.GIFT = Convert.ToString(sdr["GIFT"]);
            node.GIFTPRICE = Convert.ToDecimal(sdr["GIFTPRICE"]);
            node.TCCOUNT = Convert.ToInt32(sdr["TCCOUNT"]);
            node.YJXS = Convert.ToDecimal(sdr["YJXS"]);
            node.YJLPJE = Convert.ToDecimal(sdr["YJLPJE"]);
            node.FB = Convert.ToDecimal(sdr["FB"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");

            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);

            return node;
        }





    }
}

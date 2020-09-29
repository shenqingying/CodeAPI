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
    public class COST_WDTC : ICOST_WDTC
    {
        private const string SQL_Create = "CRM_COST_WDTC_Create";
        private const string SQL_Update = "CRM_COST_WDTC_Update";
        private const string SQL_ReadByParam = "CRM_COST_WDTC_ReadByParam";
        private const string SQL_Delete = "CRM_COST_WDTC_Delete";

        public int Create(CRM_COST_WDTC model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CJHDWDID", model.CJHDWDID),
                                        new SqlParameter("@TCID", model.TCID),
                                        new SqlParameter("@TCSL", model.TCSL),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_WDTC model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@WDTCID", model.WDTCID),
                                        new SqlParameter("@TCSL", model.TCSL),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@XGR", model.XGR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_COST_WDTC> ReadByParam(CRM_COST_WDTC model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@WDTCID", model.WDTCID),
                                        new SqlParameter("@CJHDWDID", model.CJHDWDID),
                                        new SqlParameter("@CXHDID", model.CXHDID)

                                   };
            IList<CRM_COST_WDTC> nodes = new List<CRM_COST_WDTC>();
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
        public int Delete(int WDTCID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@WDTCID", WDTCID)
                                       

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

        private CRM_COST_WDTC ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_WDTC node = new CRM_COST_WDTC();
            node.WDTCID = Convert.ToInt32(sdr["WDTCID"]);
            node.CJHDWDID = Convert.ToInt32(sdr["CJHDWDID"]);
            node.TCID = Convert.ToInt32(sdr["TCID"]);
            node.TCSL = Convert.ToInt32(sdr["TCSL"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToString(sdr["CJSJ"]);
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToString(sdr["XGSJ"]);



            node.HXM = Convert.ToInt32(sdr["HXM"]);
            node.TCNR = Convert.ToString(sdr["TCNR"]);
            node.GIFT = Convert.ToString(sdr["GIFT"]);
            node.GIFTPRICE = Convert.ToDecimal(sdr["GIFTPRICE"]);
            node.YJLPJE = Convert.ToDecimal(sdr["YJLPJE"]);
            node.TCBEIZ = Convert.ToString(sdr["TCBEIZ"]);
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);

            node.MC = Convert.ToString(sdr["MC"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.GSLXR = Convert.ToString(sdr["GSLXR"]);
            node.GSLXDH = Convert.ToString(sdr["GSLXDH"]);
            node.MDDZ = Convert.ToString(sdr["MDDZ"]);
            node.WDLXDES = Convert.ToString(sdr["WDLXDES"]);

            node.SJLPJE = Convert.ToDecimal(sdr["SJLPJE"]);
            return node;
        }




    }
}

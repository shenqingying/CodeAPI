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
    public class PRODUCT_KB : IPRODUCT_KB
    {
        private const string SQL_Create = "CRM_PRODUCT_KB_Create";
        private const string SQL_Update = "CRM_PRODUCT_KB_Update";
        private const string SQL_ReadByParam = "CRM_PRODUCT_KB_ReadByParam";
        private const string SQL_Delete = "CRM_PRODUCT_KB_Delete";

        public int Create(CRM_PRODUCT_KB model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@OrderSrc", model.OrderSrc),
                                        new SqlParameter("@KBMC", model.KBMC),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR),
                                        new SqlParameter("@XGR", model.XGR),
                                      //  new SqlParameter("@CJSJ", model.CJSJ),
                                       

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_PRODUCT_KB model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@OrderSrc", model.OrderSrc),
                                        new SqlParameter("@KBMC", model.KBMC),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@XGR", model.XGR),
                                     //   new SqlParameter("@XGSJ", model.XGSJ),
                                        new SqlParameter("@KBID", model.KBID),

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_PRODUCT_KB> ReadByParam(CRM_PRODUCT_KB model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KBID", model.KBID),
                                        new SqlParameter("@KBMC", model.KBMC),
                                        new SqlParameter("@OrderSrc", model.OrderSrc),
                                        new SqlParameter("@DDDW", model.DDDW),
                                        new SqlParameter("@WLBM", model.WLBM),
                                        new SqlParameter("@CPHH", model.CPHH),
                                   };
            IList<CRM_PRODUCT_KB> nodes = new List<CRM_PRODUCT_KB>();
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
        public int Delete(int KBID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KBID", KBID)
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

        private CRM_PRODUCT_KB ReadDataToObj(SqlDataReader sdr)
        {
            CRM_PRODUCT_KB node = new CRM_PRODUCT_KB();
            node.KBID = Convert.ToInt32(sdr["KBID"]);
            node.OrderSrc = Convert.ToInt32(sdr["OrderSrc"]);
            node.KBMC = Convert.ToString(sdr["KBMC"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.CJRDES = Convert.ToString(sdr["CJRDES"]);
            node.XGRDES = Convert.ToString(sdr["XGRDES"]);
            node.OrderSrcDES = Convert.ToString(sdr["OrderSrcDES"]);
            node.DDDW = Convert.ToString(sdr["DDDW"]);
            node.WLBM = Convert.ToString(sdr["WLBM"]);
            node.CPHH = Convert.ToString(sdr["CPHH"]);
            node.KBMXID = Convert.ToInt32(sdr["KBMXID"]);
            node.WLMS = Convert.ToString(sdr["WLMS"]);

            return node;
        }
    }
}

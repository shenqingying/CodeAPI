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
    public class PRODUCT_KBMX : IPRODUCT_KBMX
    {
        private const string SQL_Create = "CRM_PRODUCT_KBMX_Create";
        private const string SQL_Update = "CRM_PRODUCT_KBMX_Update";
        private const string SQL_ReadByParam = "CRM_PRODUCT_KBMX_ReadByParam";
        private const string SQL_Delete = "CRM_PRODUCT_KBMX_Delete";
        private const string SQL_DeleteByKBID = "CRM_PRODUCT_KBMX_DeleteByKBID";

        public int Create(CRM_PRODUCT_KBMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KBID", model.KBID),
                                        new SqlParameter("@CPHH", model.CPHH),
                                        new SqlParameter("@WLBM", model.WLBM),
                                        new SqlParameter("@DDDW", model.DDDW),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                       

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_PRODUCT_KBMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KBMXID", model.KBMXID),
                                        new SqlParameter("@KBID", model.KBID),
                                        new SqlParameter("@CPHH", model.CPHH),
                                        new SqlParameter("@WLBM", model.WLBM),
                                        new SqlParameter("@DDDW", model.DDDW),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                       


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_PRODUCT_KBMX> ReadByParam(CRM_PRODUCT_KBMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KBMXID", model.KBMXID),
                                        new SqlParameter("@KBID", model.KBID),
                                        new SqlParameter("@CPHH", model.CPHH),
                                        new SqlParameter("@WLBM", model.WLBM),
                                        new SqlParameter("@DDDW", model.DDDW),
                                        new SqlParameter("@OrderSrc", model.OrderSrc),
                                        new SqlParameter("@KBMC", model.KBMC),

                                   };
            IList<CRM_PRODUCT_KBMX> nodes = new List<CRM_PRODUCT_KBMX>();
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
        public int Delete(int KBMXID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KBMXID", KBMXID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }
        public int DeleteByKBID(int KBID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KBID", KBID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_DeleteByKBID, parms);
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

        private CRM_PRODUCT_KBMX ReadDataToObj(SqlDataReader sdr)
        {
            CRM_PRODUCT_KBMX node = new CRM_PRODUCT_KBMX();
            node.KBMXID = Convert.ToInt32(sdr["KBMXID"]);
            node.KBID = Convert.ToInt32(sdr["KBID"]);
            node.CPHH = Convert.ToString(sdr["CPHH"]);
            node.WLBM = Convert.ToString(sdr["WLBM"]);
            node.DDDW = Convert.ToString(sdr["DDDW"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.WLMS = Convert.ToString(sdr["WLMS"]);
            return node;
        }
    }
}

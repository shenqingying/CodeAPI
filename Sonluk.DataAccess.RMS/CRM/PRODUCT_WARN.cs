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
    public class PRODUCT_WARN : IPRODUCT_WARN
    {
        private const string SQL_Create = "CRM_PRODUCT_WARN_Create";
        private const string SQL_Update = "CRM_PRODUCT_WARN_Update";
        private const string SQL_ReadByID = "CRM_PRODUCT_WARN_ReadByID";
        private const string SQL_ReadByParam = "CRM_PRODUCT_WARN_ReadByParam";
        private const string SQL_Delete = "CRM_PRODUCT_WARN_Delete";
        private const string SQL_ReadByKHIDandPRODUCTID = "CRM_PRODUCT_WARN_ReadByKHIDandPRODUCTID";

        public int Create(CRM_PRODUCT_WARN model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@PRODUCTID", model.PRODUCTID),
                                        new SqlParameter("@YJXS", model.YJXS),
                                        new SqlParameter("@YJSL", model.YJSL),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_PRODUCT_WARN model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@PROWARNID", model.PROWARNID),
                                        new SqlParameter("@YJXS", model.YJXS),
                                        new SqlParameter("@YJSL", model.YJSL),
                                        new SqlParameter("@SYSL", model.SYSL),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@XGR", model.XGR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
        public CRM_PRODUCT_WARN ReadByID(int PROWARNID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@PROWARNID",PROWARNID)
                                   };
            CRM_PRODUCT_WARN nodes = new CRM_PRODUCT_WARN();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByID, parms))
                {
                    if (sdr.Read())
                    {
                        nodes = ReadDataToObj(sdr);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_PRODUCT_WARN> ReadByKHIDandPRODUCTID(int KHID, int PRODUCTID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KHID",KHID),
                                       new SqlParameter("@PRODUCTID",PRODUCTID)
                                   };
            IList<CRM_PRODUCT_WARN> nodes = new List<CRM_PRODUCT_WARN>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByKHIDandPRODUCTID, parms))
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

        public IList<CRM_PRODUCT_WARN> ReadByParam(CRM_PRODUCT_WARN model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KHMC",model.KHMC),
                                       new SqlParameter("@CPLX",model.CPLX),
                                       new SqlParameter("@CPXL",model.CPXL),
                                       new SqlParameter("@CPXH",model.CPXH),
                                       new SqlParameter("@CPPH",model.CPPH),
                                       new SqlParameter("@CPMC",model.CPMC)
                                   };
            IList<CRM_PRODUCT_WARN> nodes = new List<CRM_PRODUCT_WARN>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByParam, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataListToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public int Delete(int PROWARNID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@PROWARNID", PROWARNID)
                                       

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

        private CRM_PRODUCT_WARN ReadDataToObj(SqlDataReader sdr)
        {
            CRM_PRODUCT_WARN node = new CRM_PRODUCT_WARN();
            node.PROWARNID = Convert.ToInt32(sdr["PROWARNID"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.PRODUCTID = Convert.ToInt32(sdr["PRODUCTID"]);
            node.JCSJ = Convert.ToInt32(sdr["JCSJ"]);
            node.YJXS = Convert.ToInt32(sdr["YJXS"]);
            node.YJSL = Convert.ToInt32(sdr["YJSL"]);
            node.SYSL = Convert.ToInt32(sdr["SYSL"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.TBSJ = Convert.ToDateTime(sdr["TBSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            return node;
        }

        private CRM_PRODUCT_WARN ReadDataListToObj(SqlDataReader sdr)
        {
            CRM_PRODUCT_WARN node = new CRM_PRODUCT_WARN();
            node.PROWARNID = Convert.ToInt32(sdr["PROWARNID"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.PRODUCTID = Convert.ToInt32(sdr["PRODUCTID"]);
            node.JCSJ = Convert.ToDouble(sdr["JCSJ"]);
            node.YJXS = Convert.ToDouble(sdr["YJXS"]);
            node.YJSL = Convert.ToInt32(sdr["YJSL"]);
            node.SYSL = Convert.ToInt32(sdr["SYSL"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.TBSJ = Convert.ToDateTime(sdr["TBSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.KHMC = Convert.ToString(sdr["KHMC"]);
            node.CPLXDES = Convert.ToString(sdr["CPLXDES"]);
            node.CPXLDES = Convert.ToString(sdr["CPXLDES"]);
            node.CPXHDES = Convert.ToString(sdr["CPXHDES"]);
            node.CPPH = Convert.ToString(sdr["CPPH"]);
            node.CPMC = Convert.ToString(sdr["CPMC"]);
            node.CJRDES = Convert.ToString(sdr["CJRDES"]);
            node.XGRDES = Convert.ToString(sdr["XGRDES"]);
            return node;
        }




    }
}

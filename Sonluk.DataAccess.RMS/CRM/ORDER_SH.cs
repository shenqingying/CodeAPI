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
    public class ORDER_SH : IORDER_SH
    {
        private const string SQL_Create = "CRM_ORDER_SH_Create";
        private const string SQL_Update = "CRM_ORDER_SH_Update";
        private const string SQL_ReadByParam = "CRM_ORDER_SH_ReadByParam";
        private const string SQL_UpdateByParam = "CRM_ORDER_SH_UpdateByParam ";
        private const string SQL_Report = "CRM_ORDER_SH_Report";

        public int Create(CRM_ORDER_SH model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@OrderSrc", model.OrderSrc),
                                        new SqlParameter("@StoreNum", model.StoreNum),
                                        new SqlParameter("@KHNAME", model.KHNAME),
                                        new SqlParameter("@KHPO", model.KHPO),
                                        new SqlParameter("@OrderItem", model.OrderItem),
                                        new SqlParameter("@ProdNum", model.ProdNum),
                                        new SqlParameter("@PRICE", model.PRICE),
                                        new SqlParameter("@OrderDate", model.OrderDate),
                                        new SqlParameter("@DDSL", model.DDSL),
                                        new SqlParameter("@SJSL", model.SJSL),
                                        new SqlParameter("@SHDate", model.SHDate),
                                        new SqlParameter("@SAPORDER", model.SAPORDER),
                                        new SqlParameter("@POSNR", model.POSNR),
                                        new SqlParameter("@JHD", model.JHD),
                                        new SqlParameter("@JHDItem", model.JHDItem),
                                        new SqlParameter("@CPPH", model.CPPH),
                                        new SqlParameter("@CPMC", model.CPMC),
                                        new SqlParameter("@JHSL", model.JHSL),
                                        new SqlParameter("@JHUnit", model.JHUnit),
                                        new SqlParameter("@SJJHSL", model.SJJHSL),
                                        new SqlParameter("@BaseUnit", model.BaseUnit),
                                        new SqlParameter("@SDF", model.SDF),
                                        new SqlParameter("@SDFNAME", model.SDFNAME),
                                        new SqlParameter("@SDF2", model.SDF2),
                                        new SqlParameter("@SDF2NAME", model.SDF2NAME),
                                        new SqlParameter("@DJH", model.DJH),
                                        new SqlParameter("@HSJE", model.HSJE),
                                        new SqlParameter("@ZKL", model.ZKL),
                                        new SqlParameter("@ZKJE", model.ZKJE),
                                        new SqlParameter("@SL", model.SL),
                                        new SqlParameter("@SE", model.SE),
                                        new SqlParameter("@KPJE", model.KPJE),
                                        new SqlParameter("@WSJE", model.WSJE),
                                        new SqlParameter("@CJR", model.CJR),
                                        new SqlParameter("@BEIZ", model.BEIZ),

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_ORDER_SH model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@SHID", model.SHID),
                                        new SqlParameter("@OrderSrc", model.OrderSrc),
                                        new SqlParameter("@StoreNum", model.StoreNum),
                                        new SqlParameter("@KHNAME", model.KHNAME),
                                        new SqlParameter("@KHPO", model.KHPO),
                                        new SqlParameter("@OrderItem", model.OrderItem),
                                        new SqlParameter("@ProdNum", model.ProdNum),
                                        new SqlParameter("@PRICE", model.PRICE),
                                        new SqlParameter("@OrderDate", model.OrderDate),
                                        new SqlParameter("@DDSL", model.DDSL),
                                        new SqlParameter("@SJSL", model.SJSL),
                                        new SqlParameter("@SHDate", model.SHDate),
                                        new SqlParameter("@SAPORDER", model.SAPORDER),
                                        new SqlParameter("@POSNR", model.POSNR),
                                        new SqlParameter("@JHD", model.JHD),
                                        new SqlParameter("@JHDItem", model.JHDItem),
                                        new SqlParameter("@CPPH", model.CPPH),
                                        new SqlParameter("@CPMC", model.CPMC),
                                        new SqlParameter("@JHSL", model.JHSL),
                                        new SqlParameter("@JHUnit", model.JHUnit),
                                        new SqlParameter("@SJJHSL", model.SJJHSL),
                                        new SqlParameter("@BaseUnit", model.BaseUnit),
                                        new SqlParameter("@SDF", model.SDF),
                                        new SqlParameter("@SDFNAME", model.SDFNAME),
                                        new SqlParameter("@SDF2", model.SDF2),
                                        new SqlParameter("@SDF2NAME", model.SDF2NAME),
                                        new SqlParameter("@DJH", model.DJH),
                                        new SqlParameter("@HSJE", model.HSJE),
                                        new SqlParameter("@ZKL", model.ZKL),
                                        new SqlParameter("@ZKJE", model.ZKJE),
                                        new SqlParameter("@SL", model.SL),
                                        new SqlParameter("@SE", model.SE),
                                        new SqlParameter("@KPJE", model.KPJE),
                                        new SqlParameter("@WSJE", model.WSJE),
                                        new SqlParameter("@CJR", model.CJR),
                                        new SqlParameter("@BEIZ", model.BEIZ),

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public int UpdateByParam(CRM_ORDER_SH model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@OrderSrc", model.OrderSrc),
                                        new SqlParameter("@StoreNum", model.StoreNum),
                                        new SqlParameter("@KHNAME", model.KHNAME),
                                        new SqlParameter("@KHPO", model.KHPO),
                                        new SqlParameter("@OrderItem", model.OrderItem),
                                        new SqlParameter("@ProdNum", model.ProdNum),
                                        new SqlParameter("@PRICE", model.PRICE),
                                        new SqlParameter("@OrderDate", model.OrderDate),
                                        new SqlParameter("@DDSL", model.DDSL),
                                        new SqlParameter("@SJSL", model.SJSL),
                                        new SqlParameter("@SHDate", model.SHDate),
                                        new SqlParameter("@SAPORDER", model.SAPORDER),
                                        new SqlParameter("@POSNR", model.POSNR),
                                        new SqlParameter("@JHD", model.JHD),
                                        new SqlParameter("@JHDItem", model.JHDItem),
                                        new SqlParameter("@CPPH", model.CPPH),
                                        new SqlParameter("@CPMC", model.CPMC),
                                        new SqlParameter("@JHSL", model.JHSL),
                                        new SqlParameter("@JHUnit", model.JHUnit),
                                        new SqlParameter("@SJJHSL", model.SJJHSL),
                                        new SqlParameter("@BaseUnit", model.BaseUnit),
                                        new SqlParameter("@SDF", model.SDF),
                                        new SqlParameter("@SDFNAME", model.SDFNAME),
                                        new SqlParameter("@SDF2", model.SDF2),
                                        new SqlParameter("@SDF2NAME", model.SDF2NAME),
                                        new SqlParameter("@DJH", model.DJH),
                                        new SqlParameter("@HSJE", model.HSJE),
                                        new SqlParameter("@ZKL", model.ZKL),
                                        new SqlParameter("@ZKJE", model.ZKJE),
                                        new SqlParameter("@SL", model.SL),
                                        new SqlParameter("@SE", model.SE),
                                        new SqlParameter("@KPJE", model.KPJE),
                                        new SqlParameter("@WSJE", model.WSJE),
                                        new SqlParameter("@CJR", model.CJR),
                                        new SqlParameter("@BEIZ", model.BEIZ),

                                   };
            return Binning(CommandType.StoredProcedure, SQL_UpdateByParam, parms);
        }

        public IList<CRM_ORDER_SH> ReadByParam(CRM_ORDER_SH model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@SHID", model.SHID),
                                        new SqlParameter("@OrderSrc", model.OrderSrc),
                                        new SqlParameter("@StoreNum", model.StoreNum),
                                        new SqlParameter("@KHNAME", model.KHNAME),
                                        new SqlParameter("@MDMCID", model.MDMCID),
                                        new SqlParameter("@KHPO", model.KHPO),
                                        new SqlParameter("@ProdNum", model.ProdNum),
                                        new SqlParameter("@OrderDateBEGIN", model.OrderDateBEGIN),
                                        new SqlParameter("@OrderDateEND", model.OrderDateEND),
                                        new SqlParameter("@SHDateBEGIN", model.SHDateBEGIN),
                                        new SqlParameter("@SHDateEND", model.SHDateEND),
                                        new SqlParameter("@CPPH", model.CPPH),
                                        new SqlParameter("@CPMC", model.CPMC),
                                        new SqlParameter("@CJSJBEGIN", model.CJSJBEGIN),
                                        new SqlParameter("@CJSJEND", model.CJSJEND),
                                        new SqlParameter("@RC", model.RC),

                                   };
            IList<CRM_ORDER_SH> nodes = new List<CRM_ORDER_SH>();
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


        public IList<CRM_ORDER_SH> Report(CRM_ORDER_SH model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@SHID", model.SHID),
                                        new SqlParameter("@OrderSrc", model.OrderSrc),
                                        new SqlParameter("@StoreNum", model.StoreNum),
                                        new SqlParameter("@KHNAME", model.KHNAME),
                                        new SqlParameter("@MDMCID", model.MDMCID),
                                        new SqlParameter("@KHPO", model.KHPO),
                                        new SqlParameter("@ProdNum", model.ProdNum),
                                        new SqlParameter("@OrderDateBEGIN", model.OrderDateBEGIN),
                                        new SqlParameter("@OrderDateEND", model.OrderDateEND),
                                        new SqlParameter("@SHDateBEGIN", model.SHDateBEGIN),
                                        new SqlParameter("@SHDateEND", model.SHDateEND),
                                        new SqlParameter("@CPPH", model.CPPH),
                                        new SqlParameter("@CPMC", model.CPMC),
                                        new SqlParameter("@CJSJBEGIN", model.CJSJBEGIN),
                                        new SqlParameter("@CJSJEND", model.CJSJEND),
                                        new SqlParameter("@RC", model.RC),

                                   };
            IList<CRM_ORDER_SH> nodes = new List<CRM_ORDER_SH>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Report, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadReportToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
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

        private CRM_ORDER_SH ReadDataToObj(SqlDataReader sdr)
        {
            CRM_ORDER_SH node = new CRM_ORDER_SH();
            node.SHID = Convert.ToInt32(sdr["SHID"]);
            node.OrderSrc = Convert.ToInt32(sdr["OrderSrc"]);
            node.StoreNum = Convert.ToString(sdr["StoreNum"]);
            node.KHNAME = Convert.ToString(sdr["KHNAME"]);
            node.KHPO = Convert.ToString(sdr["KHPO"]);
            node.OrderItem = Convert.ToString(sdr["OrderItem"]);
            node.ProdNum = Convert.ToString(sdr["ProdNum"]);
            node.PRICE = Convert.ToDecimal(sdr["PRICE"]);
            node.OrderDate = Convert.ToDateTime(sdr["OrderDate"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.DDSL = Convert.ToInt32(sdr["DDSL"]);
            node.SJSL = Convert.ToInt32(sdr["SJSL"]);
            node.SHDate = Convert.ToDateTime(sdr["SHDate"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.SAPORDER = Convert.ToString(sdr["SAPORDER"]).TrimStart('0');
            node.POSNR = Convert.ToString(sdr["POSNR"]);
            node.JHD = Convert.ToString(sdr["JHD"]);
            node.JHDItem = Convert.ToString(sdr["JHDItem"]);
            node.CPPH = Convert.ToString(sdr["CPPH"]).TrimStart('0');
            node.CPMC = Convert.ToString(sdr["CPMC"]);
            node.JHSL = Convert.ToInt32(sdr["JHSL"]);
            node.JHUnit = Convert.ToString(sdr["JHUnit"]);
            node.SJJHSL = Convert.ToInt32(sdr["SJJHSL"]);
            node.BaseUnit = Convert.ToString(sdr["BaseUnit"]);
            node.SDF = Convert.ToString(sdr["SDF"]).TrimStart('0');
            node.SDFNAME = Convert.ToString(sdr["SDFNAME"]);
            node.SDF2 = Convert.ToString(sdr["SDF2"]).TrimStart('0');
            node.SDF2NAME = Convert.ToString(sdr["SDF2NAME"]);
            node.DJH = Convert.ToString(sdr["DJH"]).TrimStart('0');
            node.HSJE = Convert.ToDecimal(sdr["HSJE"]);
            node.ZKL = Convert.ToDecimal(sdr["ZKL"]);
            node.ZKJE = Convert.ToDecimal(sdr["ZKJE"]);
            node.SL = Convert.ToDecimal(sdr["SL"]);
            node.SE = Convert.ToDecimal(sdr["SE"]);
            node.KPJE = Convert.ToDecimal(sdr["KPJE"]);
            node.WSJE = Convert.ToDecimal(sdr["WSJE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);

            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.DGJE = Convert.ToDecimal(sdr["DGJE"]);
            node.SJJE = Convert.ToDecimal(sdr["SJJE"]);
            node.DIFFERENCE = Convert.ToDecimal(sdr["DIFFERENCE"]);
            node.OrderSrcDES = Convert.ToString(sdr["OrderSrcDES"]);
            node.ProdName = Convert.ToString(sdr["ProdName"]);
            node.ProdSpec = Convert.ToString(sdr["ProdSpec"]);
            node.BarCode = Convert.ToString(sdr["BarCode"]);

            return node;
        }

        private CRM_ORDER_SH ReadReportToObj(SqlDataReader sdr)
        {
            CRM_ORDER_SH node = new CRM_ORDER_SH();
            node.OrderSrc = Convert.ToInt32(sdr["OrderSrc"]);
            node.StoreNum = Convert.ToString(sdr["StoreNum"]);
            node.KHNAME = Convert.ToString(sdr["KHNAME"]);
            node.KHPO = Convert.ToString(sdr["KHPO"]);
            node.ZKJE = Convert.ToDecimal(sdr["ZKJE"]);
            node.KPJE = Convert.ToDecimal(sdr["KPJE"]);
            node.HSJE = Convert.ToDecimal(sdr["HSJE"]);
            node.DGJE = Convert.ToDecimal(sdr["DGJE"]);
            node.SJJE = Convert.ToDecimal(sdr["SJJE"]);
            node.SAPORDERSTR = Convert.ToString(sdr["SAPORDERSTR"]).TrimStart('0');
            node.JHDSTR = Convert.ToString(sdr["JHDSTR"]);
            node.DIFFERENCE = Convert.ToDecimal(sdr["DIFFERENCE"]);
            node.OrderSrcDES = Convert.ToString(sdr["OrderSrcDES"]);
            node.DDSL = Convert.ToInt32(sdr["DDSL"]);
            node.SJSL = Convert.ToInt32(sdr["SJSL"]);
            return node;
        }





    }
}

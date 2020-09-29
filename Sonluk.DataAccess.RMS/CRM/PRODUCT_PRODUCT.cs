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
    public class PRODUCT_PRODUCT : IPRODUCT_PRODUCT
    {
        private const string SQL_Create = "CRM_PRODUCT_PRODUCT_Create";
        private const string SQL_Update = "CRM_PRODUCT_PRODUCT_Update";
        private const string SQL_ReadByParam = "CRM_PRODUCT_PRODUCT_ReadByParam";
        private const string SQL_ReadByID = "CRM_PRODUCT_PRODUCT_ReadByID";
        private const string SQL_Delete = "CRM_PRODUCT_PRODUCT_Delete";

        private const string SQL_ReadCPLXByRight = "CRM_PRODUCT_PRODUCT_ReadCPLXByRight";
        private const string SQL_ReadByRight = "CRM_PRODUCT_PRODUCT_ReadByRight";


        public int Create(CRM_PRODUCT_PRODUCT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CPLX", model.CPLX),
                                        new SqlParameter("@CPXL", model.CPXL),
                                        new SqlParameter("@CPXH", model.CPXH),
                                        new SqlParameter("@CPPH", model.CPPH),
                                        new SqlParameter("@CPMC", model.CPMC),
                                        new SqlParameter("@CODE", model.CODE),
                                        new SqlParameter("@DDDW", model.DDDW),
                                        new SqlParameter("@BZDW", model.BZDW),
                                        new SqlParameter("@RATE", model.RATE),
                                        new SqlParameter("@ML", model.ML),
                                        new SqlParameter("@ML_MOB", model.ML_MOB),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_PRODUCT_PRODUCT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@PRODUCTID", model.PRODUCTID),
                                        new SqlParameter("@CPLX", model.CPLX),
                                        new SqlParameter("@CPXL", model.CPXL),
                                        new SqlParameter("@CPXH", model.CPXH),
                                        new SqlParameter("@CPPH", model.CPPH),
                                        new SqlParameter("@CPMC", model.CPMC),
                                        new SqlParameter("@CODE", model.CODE),
                                        new SqlParameter("@DDDW", model.DDDW),
                                        new SqlParameter("@BZDW", model.BZDW),
                                        new SqlParameter("@RATE", model.RATE),
                                        new SqlParameter("@ML", model.ML),
                                        new SqlParameter("@ML_MOB", model.ML_MOB),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@XGR", model.XGR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
        public IList<CRM_PRODUCT_PRODUCT> ReadByParam(CRM_PRODUCT_PRODUCT model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@CPLX",model.CPLX),
                                       new SqlParameter("@CPXL",model.CPXL),
                                       new SqlParameter("@CPXH",model.CPXH),
                                       new SqlParameter("@CPPH",model.CPPH),
                                       new SqlParameter("@CPMC",model.CPMC),
                                       new SqlParameter("@SAPMC",model.SAPMC)
                                       
                                   };
            IList<CRM_PRODUCT_PRODUCT> nodes = new List<CRM_PRODUCT_PRODUCT>();
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

        public CRM_PRODUCT_PRODUCT ReadByID(int PRODUCTID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@PRODUCTID",PRODUCTID)
                                   };
            CRM_PRODUCT_PRODUCT node = new CRM_PRODUCT_PRODUCT();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByID, parms))
                {
                    if (sdr.Read())
                    {
                        node = ReadDataToObj(sdr);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return node;
        }

        public IList<CRM_PRODUCT_PRODUCT> ReadByRight(int KHID,string SDF, int CPLX, int ORDERTTID,string CPMC)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KHID",KHID),
                                       new SqlParameter("@SDF",SDF),
                                       new SqlParameter("@CPLX",CPLX),
                                       new SqlParameter("@ORDERTTID",ORDERTTID),
                                       new SqlParameter("@CPMC",CPMC)
                                   };
            IList<CRM_PRODUCT_PRODUCT> node = new List<CRM_PRODUCT_PRODUCT>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByRight, parms))
                {
                    while (sdr.Read())
                    {
                        node.Add(ReadDataToObj1(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return node;
        }

        public IList<CRM_PRODUCT_PRODUCT> ReadCPLXByRight(int KHID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KHID",KHID)
                                   };
            IList<CRM_PRODUCT_PRODUCT> node = new List<CRM_PRODUCT_PRODUCT>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadCPLXByRight, parms))
                {
                    while (sdr.Read())
                    {
                        node.Add(ReadCPLXDataToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return node;
        }

        public int Delete(int PRODUCTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@PRODUCTID", PRODUCTID)
                                       

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

        private CRM_PRODUCT_PRODUCT ReadDataToObj(SqlDataReader sdr)
        {
            CRM_PRODUCT_PRODUCT node = new CRM_PRODUCT_PRODUCT();
            node.PRODUCTID = Convert.ToInt32(sdr["PRODUCTID"]);
            node.CPLX = Convert.ToInt32(sdr["CPLX"]);
            node.CPXL = Convert.ToInt32(sdr["CPXL"]);
            node.CPXH = Convert.ToInt32(sdr["CPXH"]);
            node.CPPH = Convert.ToString(sdr["CPPH"]);
            node.CPMC = Convert.ToString(sdr["CPMC"]);
            node.CODE = Convert.ToString(sdr["CODE"]);
            node.DDDW = Convert.ToString(sdr["DDDW"]);
            node.BZDW = Convert.ToString(sdr["BZDW"]);
            node.RATE = Convert.ToInt32(sdr["RATE"]);
            node.ML = Convert.ToString(sdr["ML"]);
            node.ML_MOB = Convert.ToString(sdr["ML_MOB"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            return node;
        }

        private CRM_PRODUCT_PRODUCT ReadDataToObj1(SqlDataReader sdr)
        {
            CRM_PRODUCT_PRODUCT node = new CRM_PRODUCT_PRODUCT();
            node.PRODUCTID = Convert.ToInt32(sdr["PRODUCTID"]);
            node.CPLX = Convert.ToInt32(sdr["CPLX"]);
            node.CPXL = Convert.ToInt32(sdr["CPXL"]);
            node.CPXH = Convert.ToInt32(sdr["CPXH"]);
            node.CPPH = Convert.ToString(sdr["CPPH"]);
            node.CPMC = Convert.ToString(sdr["CPMC"]);
            node.CODE = Convert.ToString(sdr["CODE"]);
            node.DDDW = Convert.ToString(sdr["DDDW"]);
            node.BZDW = Convert.ToString(sdr["BZDW"]);
            node.RATE = Convert.ToInt32(sdr["RATE"]);
            node.ML = Convert.ToString(sdr["ML"]);
            node.ML_MOB = Convert.ToString(sdr["ML_MOB"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.CountInOrder = Convert.ToInt32(sdr["CountInOrder"]);
            return node;
        }

        private CRM_PRODUCT_PRODUCT ReadDataListToObj(SqlDataReader sdr)
        {
            CRM_PRODUCT_PRODUCT node = new CRM_PRODUCT_PRODUCT();
            node.PRODUCTID = Convert.ToInt32(sdr["PRODUCTID"]);
            node.CPLX = Convert.ToInt32(sdr["CPLX"]);
            node.CPXL = Convert.ToInt32(sdr["CPXL"]);
            node.CPXH = Convert.ToInt32(sdr["CPXH"]);
            node.CPPH = Convert.ToString(sdr["CPPH"]);
            node.CPMC = Convert.ToString(sdr["CPMC"]);
            node.CODE = Convert.ToString(sdr["CODE"]);
            node.DDDW = Convert.ToString(sdr["DDDW"]);
            node.BZDW = Convert.ToString(sdr["BZDW"]);
            node.RATE = Convert.ToInt32(sdr["RATE"]);
            node.ML = Convert.ToString(sdr["ML"]);
            node.ML_MOB = Convert.ToString(sdr["ML_MOB"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.CPLXDES = Convert.ToString(sdr["CPLXDES"]);
            node.CPXLDES = Convert.ToString(sdr["CPXLDES"]);
            node.CPXHDES = Convert.ToString(sdr["CPXHDES"]);
            return node;
        }

        private CRM_PRODUCT_PRODUCT ReadCPLXDataToObj(SqlDataReader sdr)
        {
            CRM_PRODUCT_PRODUCT node = new CRM_PRODUCT_PRODUCT();
            node.CPLX = Convert.ToInt32(sdr["CPLX"]);
            node.CPLXDES = Convert.ToString(sdr["CPLXDES"]);
            node.CPLXML = Convert.ToString(sdr["CPLXML"]);
            return node;
        }



    }
}

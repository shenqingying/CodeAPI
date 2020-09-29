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
    public class PRODUCT_HH : IPRODUCT_HH
    {
        private const string SQL_Create = "CRM_PRODUCT_HH_Create";
        private const string SQL_Update = "CRM_PRODUCT_HH_Update";  
        private const string SQL_ReadByParam = "CRM_PRODUCT_HH_ReadByParam";
        private const string SQL_Delete = "CRM_PRODUCT_HH_Delete";



        public int Create(CRM_PRODUCT_HH model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@SY", model.SY),
                                        new SqlParameter("@ProdNum", model.ProdNum),
                                        new SqlParameter("@BarCode", model.BarCode),
                                        new SqlParameter("@ProdName", model.ProdName),
                                        new SqlParameter("@ProdSpec", model.ProdSpec),
                                        new SqlParameter("@DGDW", model.DGDW),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR),
                                      //  new SqlParameter("@CJSJ", model.CJSJ),
                                        new SqlParameter("@XGR", model.XGR),
                                        //new SqlParameter("@XGSJ", model.XGSJ),
                                        
                                       
                                    
                                      
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_PRODUCT_HH model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@SY", model.SY),
                                        new SqlParameter("@ProdNum", model.ProdNum),
                                        new SqlParameter("@BarCode", model.BarCode),
                                        new SqlParameter("@ProdName", model.ProdName),
                                        new SqlParameter("@ProdSpec", model.ProdSpec),
                                        new SqlParameter("@DGDW", model.DGDW),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@XGR", model.XGR),
                                    //    new SqlParameter("@XGSJ", model.XGSJ),
                                        new SqlParameter("@HHID", model.HHID),
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_PRODUCT_HH> ReadByParam(CRM_PRODUCT_HH model, int STAFFID)
        {
            SqlParameter[] parms = {  
                                        new SqlParameter("@SY", model.SY),
                                        new SqlParameter("@ProdNum", model.ProdNum),
                                        //new SqlParameter("@BarCode", model.BarCode),
                                       // new SqlParameter("@ProdName", model.ProdName),
                                        //new SqlParameter("@ProdSpec", model.ProdSpec),
                                        new SqlParameter("@HHXX", model.HHXX),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@HHID", model.HHID),
                                        new SqlParameter("@STAFFID",STAFFID)
                                   };
            IList<CRM_PRODUCT_HH> nodes = new List<CRM_PRODUCT_HH>();
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



        public int Delete(CRM_PRODUCT_HH model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HHID",model.HHID),
                                        new SqlParameter("@XGR",model.XGR),
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


        private CRM_PRODUCT_HH ReadDataToObj(SqlDataReader sdr)
        {
            CRM_PRODUCT_HH node = new CRM_PRODUCT_HH();
            node.HHID = Convert.ToInt32(sdr["HHID"]);
            node.SY = Convert.ToInt32(sdr["SY"]);
            node.ProdNum = Convert.ToString(sdr["ProdNum"]);
            node.BarCode = Convert.ToString(sdr["BarCode"]);
            node.ProdName = Convert.ToString(sdr["ProdName"]);
            node.ProdSpec = Convert.ToString(sdr["ProdSpec"]);
            node.DGDW = Convert.ToString(sdr["DGDW"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.CJRDES = Convert.ToString(sdr["CJRDES"]);
            node.XGRDES = Convert.ToString(sdr["XGRDES"]);
            node.SYDES = Convert.ToString(sdr["SYDES"]);
            node.SAPBM = Convert.ToString(sdr["SAPBM"]);
            if (node.ProdSpec != "")
            {
                node.NameSpec = Convert.ToString(sdr["ProdName"]) + "/" + Convert.ToString(sdr["ProdSpec"]);
            }
            else
            {
                node.NameSpec = Convert.ToString(sdr["ProdName"]);
            }


        //    node.NameSpec = Convert.ToString(sdr["NameSpec"]);
            return node;
        }
    }
}

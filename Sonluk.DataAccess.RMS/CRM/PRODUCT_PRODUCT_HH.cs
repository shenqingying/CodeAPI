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
    public class PRODUCT_PRODUCT_HH : IPRODUCT_PRODUCT_HH
    {
        private const string SQL_Create = "CRM_PRODUCT_PRODUCT_HH_Create";
        private const string SQL_Update = "CRM_PRODUCT_PRODUCT_HH_Update";     
        private const string SQL_ReadByParam = "CRM_PRODUCT_PRODUCT_HH_ReadByParam";
        private const string SQL_ReadByProNum = "CRM_PRODUCT_PRODUCT_HH_ReadByProNum";
        private const string SQL_Delete = "CRM_PRODUCT_PRODUCT_HH_Delete";


        public int Create(CRM_PRODUCT_PRODUCT_HH model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CPPH", model.CPPH),
                                        new SqlParameter("@HHID", model.HHID),
                                        new SqlParameter("@DDDW", model.DDDW),
                                        new SqlParameter("@BEGINDATE", model.BEGINDATE),
                                        new SqlParameter("@ENDDATE", model.ENDDATE),
                                        new SqlParameter("@ISDELETE", model.ISDELETE),

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_PRODUCT_PRODUCT_HH model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CPPH", model.CPPH),
                                        new SqlParameter("@HHID", model.HHID),
                                        new SqlParameter("@DDDW", model.DDDW),
                                        new SqlParameter("@BEGINDATE", model.BEGINDATE),
                                        new SqlParameter("@ENDDATE", model.ENDDATE),
                                        new SqlParameter("@ISDELETE", model.ISDELETE),
                                        new SqlParameter("@ID", model.ID),


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
        public IList<CRM_PRODUCT_PRODUCT_HH> ReadByParam(CRM_PRODUCT_PRODUCT_HH model)
        {
            SqlParameter[] parms = {
                                         new SqlParameter("@CPPH", model.CPPH),
                                         new SqlParameter("@HHID", model.HHID),
                                         new SqlParameter("@DDDW", model.DDDW),
                                         new SqlParameter("@BEGINDATE", model.BEGINDATE),
                                         new SqlParameter("@ENDDATE", model.ENDDATE),
                                         new SqlParameter("@ID", model.ID),
                                         new SqlParameter("@ProdNum", model.ProdNum),
                                         new SqlParameter("@VerifyDate", model.VerifyDate),
                                         new SqlParameter("@SelectDate", model.SelectDate),
                                         new SqlParameter("@ProdName", model.ProdName),

                                   };
            IList<CRM_PRODUCT_PRODUCT_HH> nodes = new List<CRM_PRODUCT_PRODUCT_HH>();
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
        public IList<CRM_PRODUCT_PRODUCT_HH> ReadByProNum(CRM_PRODUCT_PRODUCT_HH model)
        {
            SqlParameter[] parms = {
                                         new SqlParameter("@ProdNum", model.ProdNum),
                                         new SqlParameter("@OrderSrc", model.OrderSrc)
                                   };
            IList<CRM_PRODUCT_PRODUCT_HH> nodes = new List<CRM_PRODUCT_PRODUCT_HH>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByProNum, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObj2(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }


        public int Delete(int ID)
        {
            SqlParameter[] parms = {
                                       
                                        new SqlParameter("@ID", ID),
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

        private CRM_PRODUCT_PRODUCT_HH ReadDataToObj(SqlDataReader sdr)
        {
            CRM_PRODUCT_PRODUCT_HH node = new CRM_PRODUCT_PRODUCT_HH();
            node.CPPH = Convert.ToString(sdr["CPPH"]);
            node.HHID = Convert.ToInt32(sdr["HHID"]);
            node.DDDW = Convert.ToString(sdr["DDDW"]);
            node.BEGINDATE = Convert.ToString(sdr["BEGINDATE"]);
            node.ENDDATE = Convert.ToString(sdr["ENDDATE"]);
            node.SAPBM = Convert.ToString(sdr["SAPBM"]);
            node.SAPMX = Convert.ToString(sdr["SAPMX"]);
            node.ISDELETE = Convert.ToInt32(sdr["ISDELETE"]);
            node.ID = Convert.ToInt32(sdr["ID"]);

            return node;
        }
        private CRM_PRODUCT_PRODUCT_HH ReadDataToObj2(SqlDataReader sdr)
        {
            CRM_PRODUCT_PRODUCT_HH node = new CRM_PRODUCT_PRODUCT_HH();
            node.CPPH = Convert.ToString(sdr["CPPH"]);
            node.DDDW = Convert.ToString(sdr["DDDW"]);
            node.SAPMX = Convert.ToString(sdr["SAPMX"]);
          

            return node;
        }
    }
}

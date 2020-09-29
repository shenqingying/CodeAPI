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
    public class COST_FI : ICOST_FI
    {
        private const string SQL_Create = "CRM_COST_FI_Create";
        private const string SQL_Update = "CRM_COST_FI_Update";
        private const string SQL_ReadByParam = "CRM_COST_FI_ReadByParam";
        private const string SQL_Delete = "CRM_COST_FI_Delete";

        public int Create(CRM_COST_FI model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CWHSBH", model.CWHSBH),
                                        new SqlParameter("@CWHSBHDES", model.CWHSBHDES),
                                        new SqlParameter("@CWHSCLASS1", model.CWHSCLASS1),
                                        new SqlParameter("@CWHSCLASS2", model.CWHSCLASS2),
                                        new SqlParameter("@CWHSCLASS3", model.CWHSCLASS3),
                                        new SqlParameter("@CWHSCLASS4", model.CWHSCLASS4),
                                        new SqlParameter("@CWHSCLASS5", model.CWHSCLASS5),
                                        new SqlParameter("@SORT", model.SORT),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_FI model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CWHSBH", model.CWHSBH),
                                        new SqlParameter("@CWHSBHDES", model.CWHSBHDES),
                                        new SqlParameter("@CWHSCLASS1", model.CWHSCLASS1),
                                        new SqlParameter("@CWHSCLASS2", model.CWHSCLASS2),
                                        new SqlParameter("@CWHSCLASS3", model.CWHSCLASS3),
                                        new SqlParameter("@CWHSCLASS4", model.CWHSCLASS4),
                                        new SqlParameter("@CWHSCLASS5", model.CWHSCLASS5),
                                        new SqlParameter("@SORT", model.SORT),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@XGR", model.XGR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_COST_FI> ReadByParam(CRM_COST_FI model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CWHSBH", model.CWHSBH),
                                        new SqlParameter("@CWHSBHDES", model.CWHSBHDES),
                                        new SqlParameter("@CWHSCLASS1", model.CWHSCLASS1),
                                        new SqlParameter("@CWHSCLASS2", model.CWHSCLASS2),
                                        new SqlParameter("@CWHSCLASS3", model.CWHSCLASS3),
                                        new SqlParameter("@CWHSCLASS4", model.CWHSCLASS4),
                                        new SqlParameter("@CWHSCLASS5", model.CWHSCLASS5)
                                        

                                   };
            IList<CRM_COST_FI> nodes = new List<CRM_COST_FI>();
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
        public int Delete(int CWHSBH)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CWHSBH", CWHSBH)
                                       

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

        private CRM_COST_FI ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_FI node = new CRM_COST_FI();
            node.CWHSBH = Convert.ToString(sdr["CWHSBH"]);
            node.CWHSBHDES = Convert.ToString(sdr["CWHSBHDES"]);
            node.CWHSCLASS1 = Convert.ToInt32(sdr["CWHSCLASS1"]);
            node.CWHSCLASS2 = Convert.ToInt32(sdr["CWHSCLASS2"]);
            node.CWHSCLASS3 = Convert.ToInt32(sdr["CWHSCLASS3"]);
            node.CWHSCLASS4 = Convert.ToInt32(sdr["CWHSCLASS4"]);
            node.CWHSCLASS5 = Convert.ToInt32(sdr["CWHSCLASS5"]);
            node.SORT = Convert.ToInt32(sdr["SORT"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToString(sdr["CJSJ"]);
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToString(sdr["XGSJ"]);

            node.CWHSCLASS1DES = Convert.ToString(sdr["CWHSCLASS1DES"]);
            node.CWHSCLASS2DES = Convert.ToString(sdr["CWHSCLASS2DES"]);
            node.CWHSCLASS3DES = Convert.ToString(sdr["CWHSCLASS3DES"]);
            node.CWHSCLASS4DES = Convert.ToString(sdr["CWHSCLASS4DES"]);
            node.CWHSCLASS5DES = Convert.ToString(sdr["CWHSCLASS5DES"]);
            node.CJRDES = Convert.ToString(sdr["CJRDES"]);
            node.XGRDES = Convert.ToString(sdr["XGRDES"]);
            return node;
        }





    }
}

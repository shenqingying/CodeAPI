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
    public class COST_ITEM : ICOST_ITEM
    {
        private const string SQL_Create = "CRM_COST_ITEM_Create";
        private const string SQL_Update = "CRM_COST_ITEM_Update";
        private const string SQL_ReadByParam = "CRM_COST_ITEM_ReadByParam";
        private const string SQL_Delete = "CRM_COST_ITEM_Delete";

        public int Create(CRM_COST_ITEM model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@COSTITEMMC", model.COSTITEMMC),
                                        new SqlParameter("@COSTCLASS1", model.COSTCLASS1),
                                        new SqlParameter("@COSTCLASS2", model.COSTCLASS2),
                                        new SqlParameter("@COSTCLASS3", model.COSTCLASS3),
                                        new SqlParameter("@COSTCLASS4", model.COSTCLASS4),
                                        new SqlParameter("@COSTFINUM", model.COSTFINUM),
                                        new SqlParameter("@SORT", model.SORT),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_ITEM model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@COSTITEMMC", model.COSTITEMMC),
                                        new SqlParameter("@COSTCLASS1", model.COSTCLASS1),
                                        new SqlParameter("@COSTCLASS2", model.COSTCLASS2),
                                        new SqlParameter("@COSTCLASS3", model.COSTCLASS3),
                                        new SqlParameter("@COSTCLASS4", model.COSTCLASS4),
                                        new SqlParameter("@COSTFINUM", model.COSTFINUM),
                                        new SqlParameter("@SORT", model.SORT),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@XGR", model.XGR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_COST_ITEM> ReadByParam(CRM_COST_ITEM model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@COSTITEMMC", model.COSTITEMMC),
                                        new SqlParameter("@COSTCLASS1", model.COSTCLASS1),
                                        new SqlParameter("@COSTCLASS2", model.COSTCLASS2),
                                        new SqlParameter("@COSTCLASS3", model.COSTCLASS3),
                                        new SqlParameter("@COSTCLASS4", model.COSTCLASS4),
                                        new SqlParameter("@COSTFINUM", model.COSTFINUM)
                                   };
            IList<CRM_COST_ITEM> nodes = new List<CRM_COST_ITEM>();
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
        public int Delete(int COSTITEMID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@COSTITEMID", COSTITEMID)
                                       

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

        private CRM_COST_ITEM ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_ITEM node = new CRM_COST_ITEM();
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.COSTITEMMC = Convert.ToString(sdr["COSTITEMMC"]);
            node.COSTCLASS1 = Convert.ToInt32(sdr["COSTCLASS1"]);
            node.COSTCLASS2 = Convert.ToInt32(sdr["COSTCLASS2"]);
            node.COSTCLASS3 = Convert.ToInt32(sdr["COSTCLASS3"]);
            node.COSTCLASS4 = Convert.ToInt32(sdr["COSTCLASS4"]);
            node.COSTFINUM = Convert.ToInt32(sdr["COSTFINUM"]);
            node.SORT = Convert.ToInt32(sdr["SORT"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJRDES = Convert.ToString(sdr["CJRDES"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGRDES = Convert.ToString(sdr["XGRDES"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.COSTCLASS1DES = Convert.ToString(sdr["COSTCLASS1DES"]);
            node.COSTCLASS2DES = Convert.ToString(sdr["COSTCLASS2DES"]);
            node.COSTCLASS3DES = Convert.ToString(sdr["COSTCLASS3DES"]);
            node.COSTCLASS4DES = Convert.ToString(sdr["COSTCLASS4DES"]);
            node.COSTFINUMDES = Convert.ToString(sdr["COSTFINUMDES"]);
            return node;
        }





    }
}

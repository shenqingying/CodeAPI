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
    public class COST_GGGS : ICOST_GGGS
    {
        private const string SQL_Create = "CRM_COST_GGGS_Create";
        private const string SQL_Update = "CRM_COST_GGGS_Update";
        private const string SQL_ReadByParam = "CRM_COST_GGGS_ReadByParam";
        private const string SQL_Delete = "CRM_COST_GGGS_Delete";

        public int Create(CRM_COST_GGGS model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@GGGSMC", model.GGGSMC),
                                        new SqlParameter("@SF", model.SF),
                                        new SqlParameter("@CS", model.CS),
                                        new SqlParameter("@TEL", model.TEL),
                                        new SqlParameter("@GSADDRESS", model.GSADDRESS),
                                        new SqlParameter("@KHYH", model.KHYH),
                                        new SqlParameter("@KHZH", model.KHZH),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_GGGS model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@GGGSID", model.GGGSID),
                                        new SqlParameter("@GGGSMC", model.GGGSMC),
                                        new SqlParameter("@SF", model.SF),
                                        new SqlParameter("@CS", model.CS),
                                        new SqlParameter("@TEL", model.TEL),
                                        new SqlParameter("@GSADDRESS", model.GSADDRESS),
                                        new SqlParameter("@KHYH", model.KHYH),
                                        new SqlParameter("@KHZH", model.KHZH),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@XGR", model.XGR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_COST_GGGS> ReadByParam(CRM_COST_GGGS model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@GGGSID", model.GGGSID),
                                        new SqlParameter("@GGGSMC", model.GGGSMC),
                                        new SqlParameter("@SF", model.SF),
                                        new SqlParameter("@CS", model.CS),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE)
                                   };
            IList<CRM_COST_GGGS> nodes = new List<CRM_COST_GGGS>();
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
        public int Delete(int GGGSID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@GGGSID", GGGSID)
                                       

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

        private CRM_COST_GGGS ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_GGGS node = new CRM_COST_GGGS();
            node.GGGSID = Convert.ToInt32(sdr["GGGSID"]);
            node.GGGSMC = Convert.ToString(sdr["GGGSMC"]);
            node.SF = Convert.ToInt32(sdr["SF"]);
            node.CS = Convert.ToInt32(sdr["CS"]);
            node.TEL = Convert.ToString(sdr["TEL"]);
            node.GSADDRESS = Convert.ToString(sdr["GSADDRESS"]);
            node.KHYH = Convert.ToString(sdr["KHYH"]);
            node.KHZH = Convert.ToString(sdr["KHZH"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJRDES = Convert.ToString(sdr["CJRDES"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGRDES = Convert.ToString(sdr["XGRDES"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.SFDES = Convert.ToString(sdr["SFDES"]);
            node.CSDES = Convert.ToString(sdr["CSDES"]);
            return node;
        }




    }
}

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
    public class COST_CXHDPGQD : ICOST_CXHDPGQD
    {

        private const string SQL_Create = "CRM_COST_CXHDPGQD_Create";
        private const string SQL_Update = "CRM_COST_CXHDPGQD_Update";
        private const string SQL_ReadByParam = "CRM_COST_CXHDPGQD_ReadByParam";
        private const string SQL_Delete = "CRM_COST_CXHDPGQD_Delete";
        private const string SQL_DeleteByCXHDID = "CRM_COST_CXHDPGQD_DeleteByCXHDID";

        public int Create(CRM_COST_CXHDPGQD model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CXHDID", model.CXHDID),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@SAPCP", model.SAPCP),
                                        new SqlParameter("@CPLXID", model.CPLXID),
                                        new SqlParameter("@SJFHL", model.SJFHL),
                                        new SqlParameter("@HZJE", model.HZJE),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_CXHDPGQD model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@PGQDID", model.PGQDID),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@SAPCP", model.SAPCP),
                                        new SqlParameter("@CPLXID", model.CPLXID),
                                        new SqlParameter("@SJFHL", model.SJFHL),
                                        new SqlParameter("@HZJE", model.HZJE),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@XGR", model.XGR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_COST_CXHDPGQD> ReadByParam(CRM_COST_CXHDPGQD model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@PGQDID", model.PGQDID),
                                        new SqlParameter("@CXHDID", model.CXHDID),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@MC", model.MC),
                                        new SqlParameter("@CRMID", model.CRMID),
                                        new SqlParameter("@SAPCP", model.SAPCP),
                                        new SqlParameter("@CPLXID", model.CPLXID),
                                   };
            IList<CRM_COST_CXHDPGQD> nodes = new List<CRM_COST_CXHDPGQD>();
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
        public int Delete(int PGQDID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@PGQDID", PGQDID)
                                       

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }

        public int DeleteByCXHDID(int CXHDID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CXHDID", CXHDID)
                                       

                                   };
            return Binning(CommandType.StoredProcedure, SQL_DeleteByCXHDID, parms);
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

        private CRM_COST_CXHDPGQD ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_CXHDPGQD node = new CRM_COST_CXHDPGQD();
            node.PGQDID = Convert.ToInt32(sdr["PGQDID"]);
            node.CXHDID = Convert.ToInt32(sdr["CXHDID"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.SAPCP = Convert.ToString(sdr["SAPCP"]);
            node.CPLXID = Convert.ToInt32(sdr["CPLXID"]);
            node.SJFHL = Convert.ToInt32(sdr["SJFHL"]);
            node.HZJE = Convert.ToDecimal(sdr["HZJE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");

            node.MC = Convert.ToString(sdr["MC"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.CPLX = Convert.ToString(sdr["CPLX"]);
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);

            return node;
        }





    }
}

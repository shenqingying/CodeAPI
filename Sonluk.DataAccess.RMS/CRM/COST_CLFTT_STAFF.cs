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
    public class COST_CLFTT_STAFF : ICOST_CLFTT_STAFF
    {
        private const string SQL_Create = "CRM_COST_CLFTT_STAFF_Create";
        private const string SQL_Update = "CRM_COST_CLFTT_STAFF_Update";
        private const string SQL_ReadByParam = "CRM_COST_CLFTT_STAFF_ReadByParam";
        private const string SQL_Delete = "CRM_COST_CLFTT_STAFF_Delete";

        public int Create(CRM_COST_CLFTT_STAFF model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@FGLD", model.FGLD),
                                        new SqlParameter("@SF", model.SF),
                                        new SqlParameter("@CBZX", model.CBZX),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@CJR", model.CJR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_CLFTT_STAFF model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ID", model.ID),
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@FGLD", model.FGLD),
                                        new SqlParameter("@SF", model.SF),
                                        new SqlParameter("@CBZX", model.CBZX),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@XGR", model.XGR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_COST_CLFTT_STAFF> ReadByParam(CRM_COST_CLFTT_STAFF model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ID", model.ID),
                                        new SqlParameter("@STAFFID", model.STAFFID)

                                   };
            IList<CRM_COST_CLFTT_STAFF> nodes = new List<CRM_COST_CLFTT_STAFF>();
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
        public int Delete(int ID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ID", ID)
                                       

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

        private CRM_COST_CLFTT_STAFF ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_CLFTT_STAFF node = new CRM_COST_CLFTT_STAFF();
            node.ID = Convert.ToInt32(sdr["ID"]);
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.FGLD = Convert.ToInt32(sdr["FGLD"]);
            node.SF = Convert.ToInt32(sdr["SF"]);
            node.CBZX = Convert.ToString(sdr["CBZX"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            node.FGLDDES = Convert.ToString(sdr["FGLDDES"]);
            node.SFDES = Convert.ToString(sdr["SFDES"]);
            node.CBZXDES = Convert.ToString(sdr["CBZXDES"]);
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
            return node;
        }





    }
}

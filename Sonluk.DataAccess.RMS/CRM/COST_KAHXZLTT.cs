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
    public class COST_KAHXZLTT : ICOST_KAHXZLTT
    {
        private const string SQL_Create = "CRM_COST_KAHXZLTT_Create";
        private const string SQL_Update = "CRM_COST_KAHXZLTT_Update";
        private const string SQL_ReadByParam = "CRM_COST_KAHXZLTT_ReadByParam";
        private const string SQL_Delete = "CRM_COST_KAHXZLTT_Delete";

        public int Create(CRM_COST_KAHXZLTT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HTYEAR", model.HTYEAR),
                                        new SqlParameter("@FYLB", model.FYLB),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_KAHXZLTT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXZLTTID", model.HXZLTTID),
                                        new SqlParameter("@BEGINDATE", model.BEGINDATE),
                                        new SqlParameter("@ENDDATE", model.ENDDATE),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@XGR", model.XGR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_COST_KAHXZLTT> ReadByParam(CRM_COST_KAHXZLTT model,int STAFFID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXZLTTID", model.HXZLTTID),
                                        new SqlParameter("@HTYEAR", model.HTYEAR),
                                        new SqlParameter("@FYLB", model.FYLB),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@MC", model.MC),
                                        new SqlParameter("@CRMID", model.CRMID),
                                        new SqlParameter("@SAPSN", model.SAPSN),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@ForZZF", model.ForZZF),
                                        new SqlParameter("@STAFFID", STAFFID)

                                   };
            IList<CRM_COST_KAHXZLTT> nodes = new List<CRM_COST_KAHXZLTT>();
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
        public int Delete(int HXZLTTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXZLTTID", HXZLTTID)
                                       

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

        private CRM_COST_KAHXZLTT ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_KAHXZLTT node = new CRM_COST_KAHXZLTT();
            node.HXZLTTID = Convert.ToInt32(sdr["HXZLTTID"]);
            node.HTYEAR = Convert.ToString(sdr["HTYEAR"]);
            node.FYLB = Convert.ToInt32(sdr["FYLB"]);
            node.BEGINDATE = Convert.ToString(sdr["BEGINDATE"]);
            node.ENDDATE = Convert.ToString(sdr["ENDDATE"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");

            node.MC = Convert.ToString(sdr["MC"]);
            node.KHLX = Convert.ToInt32(sdr["KHLX"]);
            node.MCSX = Convert.ToInt32(sdr["MCSX"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.KHLXDES = Convert.ToString(sdr["KHLXDES"]);
            node.SAPSN = Convert.ToString(sdr["SAPSN"]);
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
            return node;
        }





    }
}

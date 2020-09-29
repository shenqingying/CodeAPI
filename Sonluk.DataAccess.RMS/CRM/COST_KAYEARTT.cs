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
    public class COST_KAYEARTT : ICOST_KAYEARTT
    {
        private const string SQL_Create = "CRM_COST_KAYEARTT_Create";
        private const string SQL_Update = "CRM_COST_KAYEARTT_Update";
        private const string SQL_ReadByParam = "CRM_COST_KAYEARTT_ReadByParam";
        private const string SQL_Delete = "CRM_COST_KAYEARTT_Delete";
        private const string SQL_UpdateSubmitCount = "CRM_COST_KAYEARTT_UpdateSubmitCount";
        private const string SQL_Verify = "CRM_COST_KAYEARTT_Verify";

        public int Create(CRM_COST_KAYEARTT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HTYEAR", model.HTYEAR),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@BEGINDATE", model.BEGINDATE),
                                        new SqlParameter("@ENDDATE", model.ENDDATE),
                                        new SqlParameter("@MONTHCOUNT", model.MONTHCOUNT),
                                        new SqlParameter("@YEAR_LAST", model.YEAR_LAST),
                                        new SqlParameter("@ZQ_LAST", model.ZQ_LAST),
                                        new SqlParameter("@MDSL_LAST", model.MDSL_LAST),
                                        new SqlParameter("@POS_LAST", model.POS_LAST),
                                        new SqlParameter("@JH_LAST", model.JH_LAST),
                                        new SqlParameter("@KP_LAST", model.KP_LAST),
                                        new SqlParameter("@YEAR_THIS", model.YEAR_THIS),
                                        new SqlParameter("@ZQ_THIS", model.ZQ_THIS),
                                        new SqlParameter("@MDSL_THIS", model.MDSL_THIS),
                                        new SqlParameter("@POS_THIS", model.POS_THIS),
                                        new SqlParameter("@JH_THIS", model.JH_THIS),
                                        new SqlParameter("@KP_THIS", model.KP_THIS),
                                        new SqlParameter("@ZQ_BEIZ", model.ZQ_BEIZ),
                                        new SqlParameter("@MDSL_BEIZ", model.MDSL_BEIZ),
                                        new SqlParameter("@POS_BEIZ", model.POS_BEIZ),
                                        new SqlParameter("@JH_BEIZ", model.JH_BEIZ),
                                        new SqlParameter("@KP_BEIZ", model.KP_BEIZ),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_KAYEARTT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KAYEARTTID", model.KAYEARTTID),
                                        new SqlParameter("@BEGINDATE", model.BEGINDATE),
                                        new SqlParameter("@ENDDATE", model.ENDDATE),
                                        new SqlParameter("@MONTHCOUNT", model.MONTHCOUNT),
                                        new SqlParameter("@YEAR_LAST", model.YEAR_LAST),
                                        new SqlParameter("@ZQ_LAST", model.ZQ_LAST),
                                        new SqlParameter("@MDSL_LAST", model.MDSL_LAST),
                                        new SqlParameter("@POS_LAST", model.POS_LAST),
                                        new SqlParameter("@JH_LAST", model.JH_LAST),
                                        new SqlParameter("@KP_LAST", model.KP_LAST),
                                        new SqlParameter("@YEAR_THIS", model.YEAR_THIS),
                                        new SqlParameter("@ZQ_THIS", model.ZQ_THIS),
                                        new SqlParameter("@MDSL_THIS", model.MDSL_THIS),
                                        new SqlParameter("@POS_THIS", model.POS_THIS),
                                        new SqlParameter("@JH_THIS", model.JH_THIS),
                                        new SqlParameter("@KP_THIS", model.KP_THIS),
                                        new SqlParameter("@ZQ_BEIZ", model.ZQ_BEIZ),
                                        new SqlParameter("@MDSL_BEIZ", model.MDSL_BEIZ),
                                        new SqlParameter("@POS_BEIZ", model.POS_BEIZ),
                                        new SqlParameter("@JH_BEIZ", model.JH_BEIZ),
                                        new SqlParameter("@KP_BEIZ", model.KP_BEIZ),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@XGR", model.XGR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public int UpdateSubmitCount(int KAYEARTTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KAYEARTTID", KAYEARTTID)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_UpdateSubmitCount, parms);
        }

        public IList<CRM_COST_KAYEARTT> ReadByParam(CRM_COST_KAYEARTT model,int STAFFID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KAYEARTTID", model.KAYEARTTID),
                                        new SqlParameter("@HTYEAR", model.HTYEAR),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@MC", model.MC),
                                        new SqlParameter("@SAPSN", model.SAPSN),
                                        new SqlParameter("@CRMID", model.CRMID),
                                        new SqlParameter("@CJRNAME", model.CJRNAME),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@STAFFID", STAFFID)

                                   };
            IList<CRM_COST_KAYEARTT> nodes = new List<CRM_COST_KAYEARTT>();
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
        public int Delete(int KAYEARTTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KAYEARTTID", KAYEARTTID)
                                       

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }

        public int Verify(CRM_COST_KAYEARTT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@BEGINDATE", model.BEGINDATE),
                                        new SqlParameter("@ENDDATE", model.ENDDATE),
                                        new SqlParameter("@KHID", model.KHID)
                                   };

            return Binning(CommandType.StoredProcedure, SQL_Verify, parms);
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

        private CRM_COST_KAYEARTT ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_KAYEARTT node = new CRM_COST_KAYEARTT();
            node.KAYEARTTID = Convert.ToInt32(sdr["KAYEARTTID"]);
            node.HTYEAR = Convert.ToString(sdr["HTYEAR"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.BEGINDATE = Convert.ToString(sdr["BEGINDATE"]);
            node.ENDDATE = Convert.ToString(sdr["ENDDATE"]);
            node.MONTHCOUNT = Convert.ToInt32(sdr["MONTHCOUNT"]);
            node.YEAR_LAST = Convert.ToString(sdr["YEAR_LAST"]);
            node.ZQ_LAST = Convert.ToString(sdr["ZQ_LAST"]);
            node.MDSL_LAST = Convert.ToInt32(sdr["MDSL_LAST"]);
            node.POS_LAST = Convert.ToDecimal(sdr["POS_LAST"]);
            node.JH_LAST = Convert.ToDecimal(sdr["JH_LAST"]);
            node.KP_LAST = Convert.ToDecimal(sdr["KP_LAST"]);
            node.YEAR_THIS = Convert.ToString(sdr["YEAR_THIS"]);
            node.ZQ_THIS = Convert.ToString(sdr["ZQ_THIS"]);
            node.MDSL_THIS = Convert.ToInt32(sdr["MDSL_THIS"]);
            node.POS_THIS = Convert.ToDecimal(sdr["POS_THIS"]);
            node.JH_THIS = Convert.ToDecimal(sdr["JH_THIS"]);
            node.KP_THIS = Convert.ToDecimal(sdr["KP_THIS"]);
            node.ZQ_BEIZ = Convert.ToString(sdr["ZQ_BEIZ"]);
            node.MDSL_BEIZ = Convert.ToString(sdr["MDSL_BEIZ"]);
            node.POS_BEIZ = Convert.ToString(sdr["POS_BEIZ"]);
            node.JH_BEIZ = Convert.ToString(sdr["JH_BEIZ"]);
            node.KP_BEIZ = Convert.ToString(sdr["KP_BEIZ"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.SUBMITCOUNT = Convert.ToInt32(sdr["SUBMITCOUNT"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");

            node.MC = Convert.ToString(sdr["MC"]);
            node.SAPSN = Convert.ToString(sdr["SAPSN"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);

            return node;
        }




    }
}

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
    public class COST_KAHXDJTT : ICOST_KAHXDJTT
    {
        private const string SQL_Create = "CRM_COST_KAHXDJTT_Create";
        private const string SQL_Update = "CRM_COST_KAHXDJTT_Update";
        private const string SQL_ReadByParam = "CRM_COST_KAHXDJTT_ReadByParam";
        private const string SQL_Delete = "CRM_COST_KAHXDJTT_Delete";

        public int Create(CRM_COST_KAHXDJTT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HTYEAR", model.HTYEAR),
                                        new SqlParameter("@BEGINDATE", model.BEGINDATE),
                                        new SqlParameter("@ENDDATE", model.ENDDATE),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_KAHXDJTT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXDJTTID", model.HXDJTTID),
                                        new SqlParameter("@BEGINDATE", model.BEGINDATE),
                                        new SqlParameter("@ENDDATE", model.ENDDATE),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@XGR", model.XGR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_COST_KAHXDJTT> ReadByParam(CRM_COST_KAHXDJTT model,int STAFFID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXDJTTID", model.HXDJTTID),
                                        new SqlParameter("@HTYEAR", model.HTYEAR),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@MC", model.MC),
                                        new SqlParameter("@CRMID", model.CRMID),
                                        new SqlParameter("@SAPSN", model.SAPSN),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@STAFFID", STAFFID)

                                   };
            IList<CRM_COST_KAHXDJTT> nodes = new List<CRM_COST_KAHXDJTT>();
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
        public int Delete(int HXDJTTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXDJTTID", HXDJTTID)
                                       

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

        private CRM_COST_KAHXDJTT ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_KAHXDJTT node = new CRM_COST_KAHXDJTT();
            node.HXDJTTID = Convert.ToInt32(sdr["HXDJTTID"]);
            node.HTYEAR = Convert.ToString(sdr["HTYEAR"]);
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
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.SAPSN = Convert.ToString(sdr["SAPSN"]);
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
 

            return node;
        }





    }
}

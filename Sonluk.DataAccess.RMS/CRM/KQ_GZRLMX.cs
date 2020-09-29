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
    public class KQ_GZRLMX : IKQ_GZRLMX
    {
        private const string SQL_Create = "CRM_KQ_GZRLMX_Create";
        private const string SQL_Update = "CRM_KQ_GZRLMX_Update";
        private const string SQL_Read = "CRM_KQ_GZRLMX_Read";//"SELECT * FROM CRM_KQ_GZRLMX WHERE ISACTIVE = 1 AND BBID = @BBID";
        private const string SQL_Delete = "CRM_KQ_GZRLMX_Delete";
       
        //private const string SQL_Delete = "CRM_KQ_GZRLMX_Delete";
        private const string SQL_CountDaysByGZRLMX = "CRM_KQ_GZRLMX_CountDays";
        public int Create(CRM_KQ_GZRLMX model)
        {
            SqlParameter[] parms = {
                                        //new SqlParameter("@BBMXID", model.BBMXID),
                                        new SqlParameter("@BBID", model.BBID),
                                        new SqlParameter("@DATE", model.DATE),
                                        new SqlParameter("@SFGZR", model.SFGZR),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@BEIZ", model.BEIZ)
                                    };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }
        public int Update(CRM_KQ_GZRLMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@BBMXID", model.BBMXID),
                                        new SqlParameter("@BBID", model.BBID),
                                        new SqlParameter("@DATE", model.DATE),
                                        new SqlParameter("@SFGZR", model.SFGZR),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@BEIZ", model.BEIZ)
                                    };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_KQ_GZRLMX> Read(int BBID,string Fromdate,string Todate)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@BBID",BBID),
                                       new SqlParameter("@FROMDATE",Fromdate),
                                       new SqlParameter("@TODATE",Todate)
                                   };
            IList<CRM_KQ_GZRLMX> nodes = new List<CRM_KQ_GZRLMX>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObject(sdr));
                    }
                } 
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public double CountDaysByGZRLMX(int BBID, string beginTime, string endTime, bool isfullbegin, bool isfullend)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@beginTime",beginTime),
                                       new SqlParameter("@endTime",endTime),
                                       new SqlParameter("@BBID",BBID),
                                       new SqlParameter("@isfullbegin",isfullbegin),
                                       new SqlParameter("@isfullend",isfullend)
                                   };


            double ID = 0;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_CountDaysByGZRLMX, parms))
                {
                    if (sdr.Read())
                    {
                        ID = Convert.ToDouble(sdr["ID"]);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return ID;
           

        }


        public int Delete(int BBID, string DATE_BEGIN, string DATE_END)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@BBID", BBID),
                                        new SqlParameter("@DATE_BEGIN", DATE_BEGIN),
                                        new SqlParameter("@DATE_END", DATE_END)
                                    };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }


        private CRM_KQ_GZRLMX ReadDataToObject(SqlDataReader sdr)
        {
            CRM_KQ_GZRLMX node = new CRM_KQ_GZRLMX();
            node.BBMXID = Convert.ToInt32(sdr["BBMXID"]);
            node.BBID = Convert.ToInt32(sdr["BBID"]);
            node.DATE = Convert.ToString(sdr["DATE"]);
            node.SFGZR = Convert.ToBoolean(sdr["SFGZR"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);

            return node;
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


    }
}

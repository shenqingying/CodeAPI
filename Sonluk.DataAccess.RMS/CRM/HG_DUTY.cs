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
    public class HG_DUTY : IHG_DUTY
    {
        private const string SQL_Create = "CRM_HG_DUTY_Create";
        private const string SQL_Update = "CRM_HG_DUTY_Update";
        private const string SQL_Read = "CRM_HG_DUTY_Read";//"SELECT * FROM CRM_HG_DUTY WHERE ISACTIVE = 1";
        private const string SQL_Delete = "CRM_HG_DUTY_Delete";

        public int Create(CRM_HG_DUTY model)
        {
            SqlParameter[] parms = {
                                        //new SqlParameter("@DUTYID", model.DUTYID),
                                        new SqlParameter("@DUTYNAME", model.DUTYNAME),
                                        new SqlParameter("@DUTYMEMO", model.DUTYMEMO),
                                        new SqlParameter("@DUTYBASE", model.DUTYBASE),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }



        public int Update(CRM_HG_DUTY model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@DUTYID", model.DUTYID),
                                        new SqlParameter("@DUTYNAME", model.DUTYNAME),
                                        new SqlParameter("@DUTYMEMO", model.DUTYMEMO),
                                        new SqlParameter("@DUTYBASE", model.DUTYBASE),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

      

        public IList<CRM_HG_DUTY> Read()
        {
            IList<CRM_HG_DUTY> nodes = new List<CRM_HG_DUTY>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read, null))
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
        public int Delete(int DUTYID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@DUTYID",DUTYID)
                                   };

            return SQLServerHelper.ExecuteNonQuery(CommandType.StoredProcedure, SQL_Delete, parms);
        }

        private CRM_HG_DUTY ReadDataToObject(SqlDataReader sdr)
        {
            CRM_HG_DUTY node = new CRM_HG_DUTY();
            node.DUTYID = Convert.ToInt32(sdr["DUTYID"]);
            node.DUTYNAME = Convert.ToString(sdr["DUTYNAME"]);
            node.DUTYMEMO = Convert.ToString(sdr["DUTYMEMO"]);
            node.DUTYBASE = Convert.ToString(sdr["DUTYBASE"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);

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

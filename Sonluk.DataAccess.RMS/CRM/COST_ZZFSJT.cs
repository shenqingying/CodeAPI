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
  public  class COST_ZZFSJT : ICOST_ZZFSJT
    {
      private const string SQL_Create = "CRM_COST_ZZFSJT_Create";
      private const string SQL_Update = "CRM_COST_ZZFSJT_Update";
      private const string SQL_ReadByParam = "CRM_COST_ZZFSJT_ReadByParam";
      private const string SQL_Delete = "CRM_COST_ZZFSJT_Delete";

        public int Create(CRM_COST_ZZFSJT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@TTID", model.TTID),
                                        new SqlParameter("@CHANG", model.CHANG),
                                        new SqlParameter("@KUAN", model.KUAN),
                                        new SqlParameter("@GAO", model.GAO),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                       

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_ZZFSJT model)
        {
            SqlParameter[] parms = {
                                         new SqlParameter("@TTID", model.TTID),
                                        new SqlParameter("@CHANG", model.CHANG),
                                        new SqlParameter("@KUAN", model.KUAN),
                                        new SqlParameter("@GAO", model.GAO),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                       new SqlParameter("@SJTID", model.SJTID),
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_COST_ZZFSJT> ReadByParam(CRM_COST_ZZFSJT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@SJTID", model.SJTID),
                                        new SqlParameter("@TTID", model.TTID)
                                      
                                   };
            IList<CRM_COST_ZZFSJT> nodes = new List<CRM_COST_ZZFSJT>();
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

        public int Delete(int SJTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@SJTID", SJTID)
                                       

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

        private CRM_COST_ZZFSJT ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_ZZFSJT node = new CRM_COST_ZZFSJT();
            node.SJTID = Convert.ToInt32(sdr["SJTID"]);
            node.TTID = Convert.ToInt32(sdr["TTID"]);
            node.CHANG = Convert.ToString(sdr["CHANG"]);
            node.KUAN = Convert.ToString(sdr["KUAN"]);
            node.GAO = Convert.ToString(sdr["GAO"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            
            return node;
        }




    }
}
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
    public class KQ_GZRL : IKQ_GZRL
    {
        private const string SQL_Create = "CRM_KQ_GZRL_Create";
        private const string SQL_Update = "CRM_KQ_GZRL_Update";
        private const string SQL_Read = "CRM_KQ_GZRL_Read";//"SELECT * FROM CRM_KQ_GZRL WHERE ISACTIVE = 1";
        private const string SQL_Delete = "CRM_KQ_GZRL_Delete";
        private const string SQL_ReadByMS = "SELECT * FROM CRM_KQ_GZRL WHERE ISACTIVE = 1 AND MS = @MS";
        private const string SQL_ReadByBBID = "SELECT * FROM CRM_KQ_GZRL WHERE ISACTIVE = 1 AND BBID = @BBID";
        public int Create(CRM_KQ_GZRL model)
        {
            SqlParameter[] parms = {
                                       //new SqlParameter("@BBID", model.BBID),
                                       new SqlParameter("@MS", model.MS),
                                       new SqlParameter("@ISACTIVE", model.ISACTIVE)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }
        public int Update(CRM_KQ_GZRL model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@BBID", model.BBID),
                                       new SqlParameter("@MS", model.MS),
                                       new SqlParameter("@ISACTIVE", model.ISACTIVE)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
      
        public IList<CRM_KQ_GZRL> Read(string MS,int BBID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@MS",MS),
                                       new SqlParameter("@BBID",BBID)
                                   };
            IList<CRM_KQ_GZRL> nodes = new List<CRM_KQ_GZRL>();
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
        public CRM_KQ_GZRL ReadByMS(string MS)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@MS",MS)
                                   };
            CRM_KQ_GZRL node = new CRM_KQ_GZRL();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_ReadByMS, parms))
                {
                    if (sdr.Read())
                    {
                        node = ReadDataToObject(sdr);
                    }
                }
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }



            return node;
        }
        public CRM_KQ_GZRL ReadByBBID(int BBID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@BBID",BBID)
                                   };
            CRM_KQ_GZRL node = new CRM_KQ_GZRL();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_ReadByBBID, parms))
                {
                    if (sdr.Read())
                    {
                        node = ReadDataToObject(sdr);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }



            return node;
        }

        public int Delete(int BBID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@BBID",BBID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);


        }


        private CRM_KQ_GZRL ReadDataToObject(SqlDataReader sdr)
        {
            CRM_KQ_GZRL node = new CRM_KQ_GZRL();
            node.BBID = Convert.ToInt32(sdr["BBID"]);
            node.MS = Convert.ToString(sdr["MS"]);
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

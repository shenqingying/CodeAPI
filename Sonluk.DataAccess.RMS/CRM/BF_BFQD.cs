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
    public class BF_BFQD : IBF_BFQD
    {
        private const string SQL_Create = "CRM_BF_BFQD_Create";
        //private const string SQL_Update = "CRM_BF_BFQD_Update";
        private const string SQL_Read = "CRM_BF_BFQD_Read";
        private const string SQL_Delete = "CRM_BF_BFQD_Delete";

        public int Create(CRM_BF_BFQD model)
        {
            SqlParameter[] parms = {
                                       //new SqlParameter("@BFQDID", model.BFQDID),
                                       new SqlParameter("@BFDJID", model.BFDJID),
                                       new SqlParameter("@QDID", model.QDID)
                                    };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }
        //public int Update(CRM_BF_BFQD model)
        //{
        //    SqlParameter[] parms = {
        //                               new SqlParameter("@BFQDID", model.BFQDID),
        //                               new SqlParameter("@BFDJID", model.BFDJID),
        //                               new SqlParameter("@QDID", model.QDID)
        //                            };
        //    return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        //}
        public IList<CRM_BF_BFQDLIST> ReadByBFDJID(int BFDJID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@BFDJID",BFDJID)
                                   };
            IList<CRM_BF_BFQDLIST> node = new List<CRM_BF_BFQDLIST>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure,SQL_Read,parms))
                {
                    while (sdr.Read())
                    {
                        node.Add(ReadDataToObject(sdr));
                    }
                }
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }
            return node;
        }
        public int Delete(int BFQDID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@BFQDID",BFQDID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);

        }

        private CRM_BF_BFQDLIST ReadDataToObject(SqlDataReader sdr)
        {
            CRM_BF_BFQDLIST node = new CRM_BF_BFQDLIST();
            node.BFQDID = Convert.ToInt32(sdr["BFQDID"]);
            node.BFDJID = Convert.ToInt32(sdr["BFDJID"]);
            node.QDID = Convert.ToInt32(sdr["QDID"]);
            node.QDIDDES = Convert.ToString(sdr["QDIDDES"]);
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

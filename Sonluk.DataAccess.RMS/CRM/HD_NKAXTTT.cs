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
    public class HD_NKAXTTT : IHD_NKAXTTT
    {
        private const string SQL_Create = "CRM_HD_NKAXTTT_Create";
        private const string SQL_Update = "CRM_HD_NKAXTTT_Update";
        private const string SQL_Read = "SELECT * FROM CRM_HD_NKAXTTT ";
        private const string SQL_Delete = "CRM_HD_NKAXTTT_Delete";

        public int Create(CRM_HD_NKAXTTT model)
        {
            SqlParameter[] parms = {
                                        //new SqlParameter("@NKAXTID", model.NKAXTID),
                                        new SqlParameter("@SQRID", model.SQRID),
                                        new SqlParameter("@SQRQ", model.SQRQ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }
        public int Update(CRM_HD_NKAXTTT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@NKAXTID", model.NKAXTID),
                                        new SqlParameter("@SQRID", model.SQRID),
                                        new SqlParameter("@SQRQ", model.SQRQ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
        public int Delete(int NKAXTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@NKAXTID", NKAXTID),
                                       
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

        private CRM_HD_NKAXTTT ReadDataToObj(SqlDataReader sdr)
        {
            CRM_HD_NKAXTTT node = new CRM_HD_NKAXTTT();
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.NKAXTID = Convert.ToInt32(sdr["NKAXTID"]);
            node.SQRID = Convert.ToInt32(sdr["SQRID"]);
            node.SQRQ = Convert.ToDateTime(sdr["SQRQ"]).ToString("yyyy-MM-dd HH:mm:ss"); ;
            return node;
        }
    }
}

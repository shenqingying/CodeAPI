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
    public class HD_NKAMDTT : IHD_NKAMDTT
    {
        private const string SQL_Create = "CRM_HD_NKAMDTT_Create";
        private const string SQL_Update = "CRM_HD_NKAMDTT_Update";
        private const string SQL_Read = "SELECT * FROM CRM_HD_NKAMDTT ";
        private const string SQL_Delete = "CRM_HD_NKAMDTT_Delete";


        public int Create(CRM_HD_NKAMDTT model)
        {

            SqlParameter[] parms = {
                                       //new SqlParameter("@NKAMDID", model.NKAMDID),
                                       new SqlParameter("@SQRID", model.SQRID),
                                       new SqlParameter("@SQRQ", model.SQRQ),
                                       new SqlParameter("@ISACTIVE", model.ISACTIVE)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }
        public int Update(CRM_HD_NKAMDTT model)
        {

            SqlParameter[] parms = {
                                       new SqlParameter("@NKAMDID", model.NKAMDID),
                                       new SqlParameter("@SQRID", model.SQRID),
                                       new SqlParameter("@SQRQ", model.SQRQ),
                                       new SqlParameter("@ISACTIVE", model.ISACTIVE)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public int Delete(int NKAMDID)
        {

            SqlParameter[] parms = {
                                       new SqlParameter("@NKAMDID", NKAMDID),
                                    
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

        private CRM_HD_NKAMDTT ReadDataToObj(SqlDataReader sdr)
        {
            CRM_HD_NKAMDTT node = new CRM_HD_NKAMDTT();
            node.NKAMDID = Convert.ToInt32(sdr["NKAMDID"]);
            node.SQRID = Convert.ToInt32(sdr["SQRID"]);
            node.SQRQ = Convert.ToDateTime(sdr["SQRQ"]).ToString("yyyy-MM-dd HH:mm:ss"); ;
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            return node;
        }
    }
}

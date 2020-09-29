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
    public class HD_ZYCXYTT : IHD_ZYCXYTT
    {
        private const string SQL_Create = "CRM_HD_ZYCXYTT_Create";
        private const string SQL_Update = "CRM_HD_ZYCXYTT_Update";
        private const string SQL_Read = "SELECT * FROM CRM_HD_ZYCXYTT ";
        private const string SQL_Delete = "CRM_HD_ZYCXYTT_Delete";

        public int Create(CRM_HD_ZYCXYTT model)
        {
            SqlParameter[] parms = {
                                        //new SqlParameter("@ZYCXYID", model.ZYCXYID),
                                        new SqlParameter("@SQRID", model.SQRID),
                                        new SqlParameter("@SQRRQ", model.SQRRQ),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@XT", model.XT),
                                        new SqlParameter("@KHID2", model.KHID2),
                                        new SqlParameter("@MD", model.MD),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }
        public int Update(CRM_HD_ZYCXYTT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ZYCXYID", model.ZYCXYID),
                                        new SqlParameter("@SQRID", model.SQRID),
                                        new SqlParameter("@SQRRQ", model.SQRRQ),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@XT", model.XT),
                                        new SqlParameter("@KHID2", model.KHID2),
                                        new SqlParameter("@MD", model.MD),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
        public int Delete(int ZYCXYID)
        {
            SqlParameter[] parms = {
                                        
                                        new SqlParameter("@ZYCXYID", ZYCXYID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
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

        private CRM_HD_ZYCXYTT ReadDataToObj(SqlDataReader sdr)
        {
            CRM_HD_ZYCXYTT node = new CRM_HD_ZYCXYTT();
            node.ZYCXYID = Convert.ToInt32(sdr["ZYCXYID"]);
            node.SQRID = Convert.ToInt32(sdr["SQRID"]);
            node.SQRRQ = Convert.ToString(sdr["SQRRQ"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.XT = Convert.ToString(sdr["XT"]);
            node.KHID2 = Convert.ToInt32(sdr["KHID2"]);
            node.MD = Convert.ToString(sdr["MD"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            return node;
        }
    }
}

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
    public class HD_NKAXTMX : IHD_NKAXTMX
    {
        private const string SQL_Create = "CRM_HD_NKAXTMX_Create";
        private const string SQL_Update = "CRM_HD_NKAXTMX_Update";
        private const string SQL_Read = "SELECT * FROM CRM_HD_NKAXTMX ";
        private const string SQL_Delete = "CRM_HD_NKAXTMX_Delete";

        public int Create(CRM_HD_NKAXTMX model)
        {
            SqlParameter[] parms = {
                                        //new SqlParameter("@NKAXTMXID", model.NKAXTMXID),
                                        new SqlParameter("@NKAXTID", model.NKAXTID),
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@XKHKF", model.XKHKF),
                                        new SqlParameter("@ZXXM", model.ZXXM),
                                        new SqlParameter("@ZQCXDQ", model.ZQCXDQ),
                                        new SqlParameter("@KDZCCL", model.KDZCCL),
                                        new SqlParameter("@TSCLXM", model.TSCLXM),
                                        new SqlParameter("@LSZB", model.LSZB),
                                        new SqlParameter("@GGXC", model.GGXC),
                                        new SqlParameter("@QTBH", model.QTBH),
                                        new SqlParameter("@ISACTIVE",model.ISACTIVE)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }
        public int Update(CRM_HD_NKAXTMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@NKAXTMXID", model.NKAXTMXID),
                                        new SqlParameter("@NKAXTID", model.NKAXTID),
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@XKHKF", model.XKHKF),
                                        new SqlParameter("@ZXXM", model.ZXXM),
                                        new SqlParameter("@ZQCXDQ", model.ZQCXDQ),
                                        new SqlParameter("@KDZCCL", model.KDZCCL),
                                        new SqlParameter("@TSCLXM", model.TSCLXM),
                                        new SqlParameter("@LSZB", model.LSZB),
                                        new SqlParameter("@GGXC", model.GGXC),
                                        new SqlParameter("@QTBH", model.QTBH),
                                        new SqlParameter("@ISACTIVE",model.ISACTIVE)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
        public int Delete(int NKAXTMXID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@NKAXTMXID", NKAXTMXID),
                                        
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

        private CRM_HD_NKAXTMX ReadDataToObj(SqlDataReader sdr)
        {
            CRM_HD_NKAXTMX node = new CRM_HD_NKAXTMX();
            node.NKAXTMXID = Convert.ToInt32(sdr["NKAXTMXID"]);
            node.NKAXTID = Convert.ToInt32(sdr["NKAXTID"]);
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.XKHKF = Convert.ToString(sdr["XKHKF"]);
            node.ZXXM = Convert.ToString(sdr["ZXXM"]);
            node.ZQCXDQ = Convert.ToString(sdr["ZQCXDQ"]);
            node.KDZCCL = Convert.ToString(sdr["KDZCCL"]);
            node.TSCLXM = Convert.ToString(sdr["TSCLXM"]);
            node.LSZB = Convert.ToString(sdr["LSZB"]);
            node.GGXC = Convert.ToString(sdr["GGXC"]);
            node.QTBH = Convert.ToString(sdr["QTBH"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            return node;
        }
    }
}

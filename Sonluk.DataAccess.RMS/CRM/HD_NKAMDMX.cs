using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
namespace Sonluk.DataAccess.RMS.CRM
{
    public class HD_NKAMDMX : IHD_NKAMDMX
    {
        private const string SQL_Create = "CRM_HD_NKAMDMX_Create";
        private const string SQL_Update = "CRM_HD_NKAMDMX_Update";
        private const string SQL_Read = "SELECT * FROM CRM_HD_NKAMDMX ";
        private const string SQL_Delete = "CRM_HD_NKAMDMX_Delete";

        public int Create(CRM_HD_NKAMDMX model)
        {
            SqlParameter[] parms = {
                                        //new SqlParameter("@NKAMDMXID", model.NKAMDMXID),
                                        new SqlParameter("@NKAMDID", model.NKAMDID),
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@KDZCCL", model.KDZCCL),
                                        new SqlParameter("@ZDLSMD", model.ZDLSMD),
                                        new SqlParameter("@LSZB", model.LSZB),
                                        new SqlParameter("@ZBFW", model.ZBFW),
                                        new SqlParameter("@CXHDLS", model.CXHDLS),
                                        new SqlParameter("@TSCLLS", model.TSCLLS),
                                        new SqlParameter("@GGXC", model.GGXC),
                                        new SqlParameter("@TG", model.TG),
                                        new SqlParameter("@QTBH", model.QTBH),
                                        new SqlParameter("@ISACTIVE",model.ISACTIVE)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }
        public int Update(CRM_HD_NKAMDMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@NKAMDMXID", model.NKAMDMXID),
                                        new SqlParameter("@NKAMDID", model.NKAMDID),
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@KDZCCL", model.KDZCCL),
                                        new SqlParameter("@ZDLSMD", model.ZDLSMD),
                                        new SqlParameter("@LSZB", model.LSZB),
                                        new SqlParameter("@ZBFW", model.ZBFW),
                                        new SqlParameter("@CXHDLS", model.CXHDLS),
                                        new SqlParameter("@TSCLLS", model.TSCLLS),
                                        new SqlParameter("@GGXC", model.GGXC),
                                        new SqlParameter("@TG", model.TG),
                                        new SqlParameter("@QTBH", model.QTBH),
                                        new SqlParameter("@ISACTIVE",model.ISACTIVE)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
        public int Delete(int NKAMDMXID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@NKAMDMXID", NKAMDMXID),
                                       
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

        private CRM_HD_NKAMDMX ReadDataToObj(SqlDataReader sdr)
        {
            CRM_HD_NKAMDMX node = new CRM_HD_NKAMDMX();
            node.NKAMDMXID = Convert.ToInt32(sdr["NKAMDMXID"]);
            node.NKAMDID = Convert.ToInt32(sdr["NKAMDID"]);
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.KDZCCL = Convert.ToString(sdr["KDZCCL"]);
            node.ZDLSMD = Convert.ToString(sdr["ZDLSMD"]);
            node.LSZB = Convert.ToString(sdr["LSZB"]);
            node.ZBFW = Convert.ToString(sdr["ZBFW"]);
            node.CXHDLS = Convert.ToString(sdr["CXHDLS"]);
            node.TSCLLS = Convert.ToString(sdr["TSCLLS"]);
            node.GGXC = Convert.ToString(sdr["GGXC"]);
            node.TG = Convert.ToString(sdr["TG"]);
            node.QTBH = Convert.ToString(sdr["QTBH"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            return node;
        }
    }
}

using Sonluk.Entities.MSG;
using Sonluk.IDataAccess.MSG;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.MSG
{
    public class SEND_INFO : ISEND_INFO
    {
        private const string SQL_Create = "MSG_SEND_INFO_Create";
        private const string SQL_Update = "MSG_SEND_INFO_Update";
        private const string SQL_ReadByParam = "MSG_SEND_INFO_ReadByParam";
        private const string SQL_Delete = "MSG_SEND_INFO_Delete";




        public int Create(MSG_SEND_INFO model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@SYSID", model.SYSID),
                                        new SqlParameter("@SYSDEC", model.SYSDEC),
                                        new SqlParameter("@SENDWAYSIGN", model.SENDWAYSIGN),
                                        new SqlParameter("@MEDIUM", model.MEDIUM),
                                        new SqlParameter("@MODEL", model.MODEL),
                                        new SqlParameter("@SENDMSG", model.SENDMSG),
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@SUCCESS", model.SUCCESS),
                                        new SqlParameter("@BACKMSG", model.BACKMSG),
                                        new SqlParameter("@CJR", model.CJR)



                                 };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);

        }

        public int Update(MSG_SEND_INFO model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@INFOID", model.INFOID),
                                        new SqlParameter("@SYSID", model.SYSID),
                                        new SqlParameter("@SYSDEC", model.SYSDEC),
                                        new SqlParameter("@SENDWAYSIGN", model.SENDWAYSIGN),
                                        new SqlParameter("@MEDIUM", model.MEDIUM),
                                        new SqlParameter("@MODEL", model.MODEL),
                                        new SqlParameter("@SENDMSG", model.SENDMSG),
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@SUCCESS", model.SUCCESS),
                                        new SqlParameter("@BACKMSG", model.BACKMSG),



                                 };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);

        }

        public IList<MSG_SEND_INFO> ReadByParam(MSG_SEND_INFO model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@INFOID", model.INFOID),
                                        new SqlParameter("@SYSID", model.SYSID),
                                        new SqlParameter("@SYSDEC", model.SYSDEC),
                                        new SqlParameter("@SENDWAYSIGN", model.SENDWAYSIGN),
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@SUCCESS", model.SUCCESS),



                                   };
            IList<MSG_SEND_INFO> nodes = new List<MSG_SEND_INFO>();
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

        public int Delete(int INFOID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@INFOID", INFOID)
                                 };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);

        }


        private MSG_SEND_INFO ReadDataToObj(SqlDataReader sdr)
        {
            MSG_SEND_INFO node = new MSG_SEND_INFO();
            node.INFOID = Convert.ToInt32(sdr["INFOID"]);
            node.SYSID = Convert.ToInt32(sdr["SYSID"]);
            node.SYSDEC = Convert.ToString(sdr["SYSDEC"]);
            node.SENDWAYSIGN = Convert.ToInt32(sdr["SENDWAYSIGN"]);
            node.MEDIUM = Convert.ToInt32(sdr["MEDIUM"]);
            node.MODEL = Convert.ToInt32(sdr["MODEL"]);
            node.SENDMSG = Convert.ToString(sdr["SENDMSG"]);
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.SUCCESS = Convert.ToInt32(sdr["SUCCESS"]);
            node.BACKMSG = Convert.ToString(sdr["BACKMSG"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");

            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            node.SENDWAYSIGNDES = Convert.ToString(sdr["SENDWAYSIGNDES"]);
            node.MEDIUMDES = Convert.ToString(sdr["MEDIUMDES"]);
            node.MODELDES = Convert.ToString(sdr["MODELDES"]);

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

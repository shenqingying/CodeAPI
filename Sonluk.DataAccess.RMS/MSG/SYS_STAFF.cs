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
    public class SYS_STAFF : ISYS_STAFF
    {
        private const string SQL_Create = "MSG_SYS_STAFF_Create";
        private const string SQL_Update = "MSG_SYS_STAFF_Update";
        private const string SQL_ReadByParam = "MSG_SYS_STAFF_ReadByParam";
        private const string SQL_Delete = "MSG_SYS_STAFF_Delete";
        private const string SQL_DeleteBySYSID = "MSG_SYS_STAFF_DeleteBySYSID";




        public int Create(MSG_SYS_STAFF model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@SYSID", model.SYSID),
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@IFSEND", model.IFSEND),
                                        new SqlParameter("@MSGTYPEID", model.MSGTYPEID),
                                        new SqlParameter("@CJR", model.CJR)


                                 };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);

        }

        public int Update(MSG_SYS_STAFF model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ID", model.ID),
                                        new SqlParameter("@SYSID", model.SYSID),
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@IFSEND", model.IFSEND),
                                        new SqlParameter("@MSGTYPEID", model.MSGTYPEID),
                                        new SqlParameter("@XGR", model.XGR)


                                 };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);

        }

        public IList<MSG_SYS_STAFF> ReadByParam(MSG_SYS_STAFF model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ID", model.ID),
                                        new SqlParameter("@SYSID", model.SYSID),
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@STAFFNAME", model.STAFFNAME),
                                        new SqlParameter("@STAFFUSER", model.STAFFUSER),
                                        new SqlParameter("@IFSEND", model.IFSEND),
                                        new SqlParameter("@MSGTYPEID", model.MSGTYPEID),


                                   };
            IList<MSG_SYS_STAFF> nodes = new List<MSG_SYS_STAFF>();
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

        public int Delete(int ID, int XGR)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ID", ID),
                                        new SqlParameter("@XGR", XGR)
                                 };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);

        }

        public int DeleteBySYSID(int SYSID, int XGR)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@SYSID", SYSID),
                                        new SqlParameter("@XGR", XGR)
                                 };
            return Binning(CommandType.StoredProcedure, SQL_DeleteBySYSID, parms);

        }


        private MSG_SYS_STAFF ReadDataToObj(SqlDataReader sdr)
        {
            MSG_SYS_STAFF node = new MSG_SYS_STAFF();
            node.ID = Convert.ToInt32(sdr["ID"]);
            node.SYSID = Convert.ToInt32(sdr["SYSID"]);
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.IFSEND = Convert.ToInt32(sdr["IFSEND"]);
            node.MSGTYPEID = Convert.ToInt32(sdr["MSGTYPEID"]);
            node.ISDELETE = Convert.ToInt32(sdr["ISDELETE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");

            node.TYPENAME = Convert.ToString(sdr["TYPENAME"]);
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
            node.SYSNAME = Convert.ToString(sdr["SYSNAME"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            node.STAFFNO = Convert.ToString(sdr["STAFFNO"]);
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

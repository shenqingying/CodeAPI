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
    public class SYS_SYSINFO : ISYS_SYSINFO
    {
        private const string SQL_Create = "MSG_SYS_SYSINFO_Create";
        private const string SQL_Update = "MSG_SYS_SYSINFO_Update";
        private const string SQL_ReadByParam = "MSG_SYS_SYSINFO_ReadByParam";
        private const string SQL_Delete = "MSG_SYS_SYSINFO_Delete";




        public int Create(MSG_SYS_SYSINFO model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@SYSNAME", model.SYSNAME),
                                        new SqlParameter("@LINKWAY", model.LINKWAY),
                                        new SqlParameter("@DATASOURCE", model.DATASOURCE),
                                        new SqlParameter("@CATALOG", model.CATALOG),
                                        new SqlParameter("@USERID", model.USERID),
                                        new SqlParameter("@PASSWORD", model.PASSWORD),
                                        new SqlParameter("@API", model.API),
                                        new SqlParameter("@SYSCODE", model.SYSCODE),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@MSGTYPEID", model.MSGTYPEID),
                                        new SqlParameter("@MODE", model.MODE),
                                        new SqlParameter("@ISDELETE", model.ISDELETE),
                                        new SqlParameter("@CJR", model.CJR)

                                 };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);

        }

        public int Update(MSG_SYS_SYSINFO model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@SYSID", model.SYSID),
                                        new SqlParameter("@SYSNAME", model.SYSNAME),
                                        new SqlParameter("@LINKWAY", model.LINKWAY),
                                        new SqlParameter("@DATASOURCE", model.DATASOURCE),
                                        new SqlParameter("@CATALOG", model.CATALOG),
                                        new SqlParameter("@USERID", model.USERID),
                                        new SqlParameter("@PASSWORD", model.PASSWORD),
                                        new SqlParameter("@API", model.API),
                                        new SqlParameter("@SYSCODE", model.SYSCODE),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@MSGTYPEID", model.MSGTYPEID),
                                        new SqlParameter("@MODE", model.MODE),
                                        new SqlParameter("@ISDELETE", model.ISDELETE),
                                        new SqlParameter("@XGR", model.XGR)

                                 };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);

        }

        public IList<MSG_SYS_SYSINFO> ReadByParam(MSG_SYS_SYSINFO model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@SYSID", model.SYSID),
                                        new SqlParameter("@SYSNAME", model.SYSNAME),
                                        new SqlParameter("@LINKWAY", model.LINKWAY),
                                        new SqlParameter("@SYSCODE", model.SYSCODE),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@MSGTYPEID", model.MSGTYPEID),

                                   };
            IList<MSG_SYS_SYSINFO> nodes = new List<MSG_SYS_SYSINFO>();
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

        public int Delete(int SYSID, int XGR)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@SYSID", SYSID),
                                        new SqlParameter("@XGR", XGR)
                                 };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);

        }


        private MSG_SYS_SYSINFO ReadDataToObj(SqlDataReader sdr)
        {
            MSG_SYS_SYSINFO node = new MSG_SYS_SYSINFO();
            node.SYSID = Convert.ToInt32(sdr["SYSID"]);
            node.SYSNAME = Convert.ToString(sdr["SYSNAME"]);
            node.LINKWAY = Convert.ToInt32(sdr["LINKWAY"]);
            node.DATASOURCE = Convert.ToString(sdr["DATASOURCE"]);
            node.CATALOG = Convert.ToString(sdr["CATALOG"]);
            node.USERID = Convert.ToString(sdr["USERID"]);
            node.PASSWORD = Convert.ToString(sdr["PASSWORD"]);
            node.API = Convert.ToString(sdr["API"]);
            node.SYSCODE = Convert.ToString(sdr["SYSCODE"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.MSGTYPEID = Convert.ToInt32(sdr["MSGTYPEID"]);
            node.MODE = Convert.ToInt32(sdr["MODE"]);
            node.ISDELETE = Convert.ToInt32(sdr["ISDELETE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");

            node.TYPENAME = Convert.ToString(sdr["TYPENAME"]);
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
            node.MODEDES = Convert.ToString(sdr["MODEDES"]);
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

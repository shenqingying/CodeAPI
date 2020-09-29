using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.MES
{
    public class SY_SYSCS : ISY_SYSCS
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_SELECT = "MES_SY_SYSCS_SELECT";
        const string SQL_UPDATE = "MES_SY_SYSCS_UPDATE";
        public string SELECT(string CSNAME)
        {
            string rst = "";
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@CSNAME",CSNAME)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        rst = Convert.ToString(sdr["CSINFO"]);
                    }
                }
            }
            catch (Exception e)
            {
                SY_EXCEPTIONservice.INSERT(e.ToString(), "MES_SY_SYSCS_SELECT");
            }
            return rst;
        }
        public MES_RETURN UPDATE_SYNC(string CSNAME, string CSINFO)
        {
            MES_RETURN mr = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@CSNAME",CSNAME),
                                       new SqlParameter("@CSINFO",CSINFO)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE, parms)) { }
                mr.TYPE = "S";
                mr.MESSAGE = "";
            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "MES_SY_SYSCS_UPDATE");
            }
            return mr;
        }
    }
}

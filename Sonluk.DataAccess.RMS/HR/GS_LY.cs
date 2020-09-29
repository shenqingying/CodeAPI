using Sonluk.DataAccess.RMS.MES;
using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.HR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.HR
{
    public class GS_LY : IGS_LY
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "HR_GS_LY_INSERT";
        const string SQL_SELECT = "HR_GS_LY_SELECT";
        const string SQL_UPDATE = "HR_GS_LY_UPDATE";
        const string SQL_DELETE = "HR_GS_LY_DELETE";

        public MES_RETURN INSERT(HR_GS_LY model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@LYNAME",model.LYNAME),
                                       new SqlParameter("@ISACTION",model.ISACTION)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_GS_LY_INSERT", "HR");
            }
            return rst;
        }
        public HR_GS_LY_SELECT SELECT(HR_GS_LY model)
        {
            HR_GS_LY_SELECT rst = new HR_GS_LY_SELECT();
            List<HR_GS_LY_LIST> child_HR_GS_LY_LIST = new List<HR_GS_LY_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@LYNAME",model.LYNAME),
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        HR_GS_LY_LIST child = new HR_GS_LY_LIST();
                        child.LYID = Convert.ToInt32(sdr["LYID"]);
                        child.GS = Convert.ToString(sdr["GS"]);
                        child.LYNAME = Convert.ToString(sdr["LYNAME"]);
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.GSNAME = Convert.ToString(sdr["GSNAME"]);
                        child_HR_GS_LY_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_GS_LY_SELECT", "HR");
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            rst.HR_GS_LY_LIST = child_HR_GS_LY_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN UPDATE(HR_GS_LY model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@LYID",model.LYID),
                                       new SqlParameter("@LYNAME",model.LYNAME),
                                       new SqlParameter("@ISACTION",model.ISACTION)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_GS_LY_UPDATE", "HR");
            }
            return rst;
        }
        public MES_RETURN DELETE(int LYID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@LYID",LYID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DELETE, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_GS_LY_DELETE", "HR");
            }
            return rst;
        }
    }
}


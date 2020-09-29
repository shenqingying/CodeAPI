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
    public class XZGL_FLDATZ : IXZGL_FLDATZ
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_AUTOINSERT = "HR_XZGL_FLDATZ_AUTOINSERT";
        const string SQL_SELECT_REPORT = "HR_XZGL_FLDATZ_SELECT_REPORT";
        const string SQL_UPDATE = "HR_XZGL_FLDATZ_UPDATE";
        const string SQL_AUTO_ADD_TO_FFJLMX = "HR_XZGL_FLDATZMX_AUTO_ADD_TO_FFJLMX";
        public MES_RETURN AUTOINSERT(HR_XZGL_FLDATZ model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@TZYEAR",model.TZYEAR),
                                       new SqlParameter("@TZMONTH",model.TZMONTH),
                                       new SqlParameter("@CJR",model.CJR),
                                       new SqlParameter("@MYPW",model.MYPW)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_AUTOINSERT, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FLDATZ_AUTOINSERT", "HR");
            }
            return rst;
        }
        public HR_XZGL_FLDATZ_SELECT SELECT_REPORT(HR_XZGL_FLDATZ model)
        {
            HR_XZGL_FLDATZ_SELECT rst = new HR_XZGL_FLDATZ_SELECT();
            List<HR_XZGL_FLDATZ_LIST> child_HR_XZGL_FLDATZ_LIST = new List<HR_XZGL_FLDATZ_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                       new SqlParameter("@TZYEAR",model.TZYEAR),
                                       new SqlParameter("@TZMONTH",model.TZMONTH),
                                       new SqlParameter("@MYPW",model.MYPW),
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_REPORT, paras))
                {
                    while (sdr.Read())
                    {
                        HR_XZGL_FLDATZ_LIST child = new HR_XZGL_FLDATZ_LIST();
                        child.FLTZID = Convert.ToInt32(sdr["FLTZID"]);
                        child.GS = Convert.ToString(sdr["GS"]);
                        child.GSNAME = Convert.ToString(sdr["GSNAME"]);
                        child.TZYEAR = Convert.ToString(sdr["TZYEAR"]);
                        child.TZMONTH = Convert.ToString(sdr["TZMONTH"]);
                        child.ISUSE = Convert.ToInt32(sdr["ISUSE"]);
                        child.USERQ = Convert.ToString(sdr["USERQ"]);
                        child.XGTIME = Convert.ToDateTime(sdr["XGTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.SBRS = Convert.ToInt32(sdr["SBRS"]);
                        child.GJJRS = Convert.ToInt32(sdr["GJJRS"]);
                        child.SBGR = Convert.ToDecimal(sdr["SBGR"]);
                        child.GJJGR = Convert.ToDecimal(sdr["GJJGR"]);
                        child.ALLGR = child.SBGR + child.GJJGR;
                        child.SBDW = Convert.ToDecimal(sdr["SBDW"]);
                        child.GJJDW = Convert.ToDecimal(sdr["GJJDW"]);
                        child.ALLDW = child.SBDW + child.GJJDW;
                        child.ALL = child.ALLGR + child.ALLDW;
                        child_HR_XZGL_FLDATZ_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FLDATZ_SELECT_REPORT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.HR_XZGL_FLDATZ_LIST = child_HR_XZGL_FLDATZ_LIST;
            return rst;
        }
        public MES_RETURN UPDATE(HR_XZGL_FLDATZ model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@FLTZID",model.FLTZID),
                                       new SqlParameter("@XGR",model.XGR),
                                       new SqlParameter("@LB",LB)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FLDATZ_UPDATE", "HR");
            }
            return rst;
        }
        public MES_RETURN AUTO_ADD_TO_FFJLMX(HR_XZGL_FLDATZ model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@FFJLID",model.FFJLID),
                                       new SqlParameter("@TZYEAR",model.TZYEAR),
                                       new SqlParameter("@TZMONTH",model.TZMONTH),
                                       new SqlParameter("@MYPW",model.MYPW)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_AUTO_ADD_TO_FFJLMX, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FLDATZMX_AUTO_ADD_TO_FFJLMX", "HR");
            }
            return rst;
        }
    }
}

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
    public class XZGL_KKGLMX : IXZGL_KKGLMX
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "HR_XZGL_KKGLMX_INSERT";
        const string SQL_SELECT = "HR_XZGL_KKGLMX_SELECT";
        const string SQL_UPDATE = "HR_XZGL_KKGLMX_UPDATE";
        const string SQL_AUTO_ADD_TO_FFJLMX = "HR_XZGL_KKGLMX_AUTO_ADD_TO_FFJLMX";
        public MES_RETURN INSERT(HR_XZGL_KKGLMX model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@KKID",model.KKID),
                                       new SqlParameter("@KKYEAR",model.KKYEAR),
                                       new SqlParameter("@KKMONTH",model.KKMONTH),
                                       new SqlParameter("@ZDID",model.ZDID),
                                       new SqlParameter("@CLJE",model.CLJE),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@CJR",model.CJR)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_KKGLMX_INSERT", "HR");
            }
            return rst;
        }
        public MES_RETURN AUTO_ADD_TO_FFJLMX(HR_XZGL_KKGLMX model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@JSMONTH",model.JSMONTH),
                                       new SqlParameter("@FFJLID",model.FFJLID),
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_KKGLMX_AUTO_ADD_TO_FFJLMX", "HR");
            }
            return rst;
        }
        public MES_RETURN UPDATE(HR_XZGL_KKGLMX model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@KKMXID",model.KKMXID),
                                       new SqlParameter("@ZDID",model.ZDID),
                                       new SqlParameter("@CLJE",model.CLJE),
                                       new SqlParameter("@CLZT",model.CLZT),
                                       new SqlParameter("@REMARK",model.REMARK),
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_KKGLMX_UPDATE", "HR");
            }
            return rst;
        }
        public HR_XZGL_KKGLMX_SELECT SELECT(HR_XZGL_KKGLMX model)
        {
            HR_XZGL_KKGLMX_SELECT rst = new HR_XZGL_KKGLMX_SELECT();
            List<HR_XZGL_KKGLMX_LIST> child_HR_XZGL_KKGLMX_LIST = new List<HR_XZGL_KKGLMX_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                       new SqlParameter("@KKMXID",model.KKMXID),
                                       new SqlParameter("@KKID",model.KKID),
                                       new SqlParameter("@KKYEAR",model.KKYEAR),
                                       new SqlParameter("@KKMONTH",model.KKMONTH),
                                       new SqlParameter("@CLZT",model.CLZT),
                                       new SqlParameter("@MYPW",model.MYPW)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, paras))
                {
                    while (sdr.Read())
                    {
                        HR_XZGL_KKGLMX_LIST child = new HR_XZGL_KKGLMX_LIST();
                        child.KKMXID = Convert.ToInt32(sdr["KKMXID"]);
                        child.KKID = Convert.ToInt32(sdr["KKID"]);
                        child.KKYEAR = Convert.ToString(sdr["KKYEAR"]);
                        child.KKMONTH = Convert.ToString(sdr["KKMONTH"]);
                        child.ZDID = Convert.ToInt32(sdr["ZDID"]);
                        child.ZDNAME = Convert.ToString(sdr["ZDNAME"]);
                        child.CLJE = Convert.ToDecimal(sdr["CLJE"]);
                        child.CLZT = Convert.ToInt32(sdr["CLZT"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.CJR = Convert.ToInt32(sdr["CJR"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJTIME = Convert.ToDateTime(sdr["CJTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.XGR = Convert.ToInt32(sdr["XGR"]);
                        child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                        child.XGTIME = Convert.ToDateTime(sdr["XGTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.YGNAME = Convert.ToString(sdr["YGNAME"]);
                        child.DEPTNAME = Convert.ToString(sdr["DEPTNAME"]);
                        child.GH = Convert.ToString(sdr["GH"]);
                        child.YGTYPENAME = Convert.ToString(sdr["YGTYPENAME"]);
                        child.RZDATE = Convert.ToString(sdr["RZDATE"]);
                        child_HR_XZGL_KKGLMX_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_ZXFJKC_SELECT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.HR_XZGL_KKGLMX_LIST = child_HR_XZGL_KKGLMX_LIST;
            return rst;
        }
    }
}

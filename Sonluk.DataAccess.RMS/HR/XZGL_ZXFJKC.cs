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
    public class XZGL_ZXFJKC : IXZGL_ZXFJKC
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "HR_XZGL_ZXFJKC_INSERT";
        const string SQL_SELECT = "HR_XZGL_ZXFJKC_SELECT";
        const string SQL_UPDATE = "HR_XZGL_ZXFJKC_UPDATE";
        const string SQL_AUTO_ADD_TO_FFJLMX = "HR_XZGL_ZXFJKC_AUTO_ADD_TO_FFJLMX";
        public MES_RETURN INSERT(HR_XZGL_ZXFJKC model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@LJYEAR",model.LJYEAR),
                                       new SqlParameter("@LJMOUTH",model.LJMOUTH),
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@LJZNJY",model.LJZNJY),
                                       new SqlParameter("@LJFDLX",model.LJFDLX),
                                       new SqlParameter("@LJZFZJ",model.LJZFZJ),
                                       new SqlParameter("@LJSYLR",model.LJSYLR),
                                       new SqlParameter("@LJJXJY",model.LJJXJY),
                                       new SqlParameter("@CJR",model.CJR),
                                       new SqlParameter("@LJQZD",model.LJQZD)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_ZXFJKC_INSERT", "HR");
            }
            return rst;
        }
        public MES_RETURN UPDATE(HR_XZGL_ZXFJKC model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@LJYEAR",model.LJYEAR),
                                       new SqlParameter("@LJMOUTH",model.LJMOUTH),
                                       new SqlParameter("@LJZNJY",model.LJZNJY),
                                       new SqlParameter("@LJFDLX",model.LJFDLX),
                                       new SqlParameter("@LJZFZJ",model.LJZFZJ),
                                       new SqlParameter("@LJSYLR",model.LJSYLR),
                                       new SqlParameter("@LJJXJY",model.LJJXJY),
                                       new SqlParameter("@XGR",model.XGR),
                                       new SqlParameter("@LB",LB),
                                       new SqlParameter("@LJQZD",model.LJQZD),
                                       new SqlParameter("@GS",model.GS)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_ZXFJKC_UPDATE", "HR");
            }
            return rst;
        }
        public HR_XZGL_ZXFJKC_SELECT SELECT(HR_XZGL_ZXFJKC model)
        {
            HR_XZGL_ZXFJKC_SELECT rst = new HR_XZGL_ZXFJKC_SELECT();
            List<HR_XZGL_ZXFJKC_LIST> child_HR_XZGL_ZXFJKC_LIST = new List<HR_XZGL_ZXFJKC_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                       new SqlParameter("@LJYEAR",model.LJYEAR),
                                       new SqlParameter("@LJMOUTH",model.LJMOUTH),
                                       new SqlParameter("@GH",model.GH),
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, paras))
                {
                    while (sdr.Read())
                    {
                        HR_XZGL_ZXFJKC_LIST child = new HR_XZGL_ZXFJKC_LIST();
                        child.RYID = Convert.ToInt32(sdr["RYID"]);
                        child.LJYEAR = Convert.ToString(sdr["LJYEAR"]);
                        child.LJMOUTH = Convert.ToString(sdr["LJMOUTH"]);
                        child.LJZNJY = Convert.ToDecimal(sdr["LJZNJY"]);
                        child.LJFDLX = Convert.ToDecimal(sdr["LJFDLX"]);
                        child.LJZFZJ = Convert.ToDecimal(sdr["LJZFZJ"]);
                        child.LJSYLR = Convert.ToDecimal(sdr["LJSYLR"]);
                        child.LJJXJY = Convert.ToDecimal(sdr["LJJXJY"]);
                        child.LJALL = Convert.ToDecimal(sdr["LJALL"]);
                        child.CJR = Convert.ToInt32(sdr["CJR"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJTIME = Convert.ToDateTime(sdr["CJTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.XGR = Convert.ToInt32(sdr["XGR"]);
                        child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                        child.XGTIME = Convert.ToDateTime(sdr["XGTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.GH = Convert.ToString(sdr["GH"]);
                        child.YGNAME = Convert.ToString(sdr["YGNAME"]);
                        child.DEPTNAME = Convert.ToString(sdr["DEPTNAME"]);
                        child.ZZTYPENAME = Convert.ToString(sdr["ZZTYPENAME"]);
                        child.ZZNO = Convert.ToString(sdr["ZZNO"]);
                        child.YGTYPENAME = Convert.ToString(sdr["YGTYPENAME"]);
                        child.LJQZD = Convert.ToDecimal(sdr["LJQZD"]);
                        child.GS = Convert.ToString(sdr["GS"]);
                        child_HR_XZGL_ZXFJKC_LIST.Add(child);
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
            rst.HR_XZGL_ZXFJKC_LIST = child_HR_XZGL_ZXFJKC_LIST;
            return rst;
        }
        public MES_RETURN AUTO_ADD_TO_FFJLMX(HR_XZGL_ZXFJKC model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@FFJLID",model.FFJLID),
                                       new SqlParameter("@JSMONTH",model.JSMONTH)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_ZXFJKC_AUTO_ADD_TO_FFJLMX", "HR");
            }
            return rst;
        }
    }
}

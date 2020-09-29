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
    public class XZGL_KKGL : IXZGL_KKGL
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "HR_XZGL_KKGL_INSERT";
        const string SQL_SELECT = "HR_XZGL_KKGL_SELECT";
        const string SQL_UPDATE = "HR_XZGL_KKGL_UPDATE";
        public MES_RETURN INSERT(HR_XZGL_KKGL model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@KSYEAR",model.KSYEAR),
                                       new SqlParameter("@KSMOUTH",model.KSMOUTH),
                                       new SqlParameter("@JSYEAR",model.JSYEAR),
                                       new SqlParameter("@JSMOUTH",model.JSMOUTH),
                                       new SqlParameter("@KKLB",model.KKLB),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@CJR",model.CJR),
                                       new SqlParameter("@ISAUTO",model.ISAUTO)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                        rst.TID = Convert.ToInt32(sdr["TID"]);
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_KKGL_INSERT", "HR");
            }
            return rst;
        }
        public MES_RETURN AUTOINSERT(HR_XZGL_KKGL model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@JQGLID",model.JQGLID),
                                       new SqlParameter("@SXMONTH",model.SXMONTH),
                                       new SqlParameter("@CJR",model.CJR)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                        rst.TID = Convert.ToInt32(sdr["TID"]);
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_KKGL_INSERT", "HR");
            }
            return rst;
        }
        public MES_RETURN UPDATE(HR_XZGL_KKGL model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@KKID",model.KKID),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@ISOVER",model.ISOVER),
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_KKGL_UPDATE", "HR");
            }
            return rst;
        }
        public HR_XZGL_KKGL_SELECT SELECT(HR_XZGL_KKGL model)
        {
            HR_XZGL_KKGL_SELECT rst = new HR_XZGL_KKGL_SELECT();
            List<HR_XZGL_KKGL_LIST> child_HR_XZGL_KKGL_LIST = new List<HR_XZGL_KKGL_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@KKLB",model.KKLB),
                                       new SqlParameter("@ISOVER",model.ISOVER),
                                       new SqlParameter("@KKID",model.KKID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, paras))
                {
                    while (sdr.Read())
                    {
                        HR_XZGL_KKGL_LIST child = new HR_XZGL_KKGL_LIST();
                        child.KKID = Convert.ToInt32(sdr["KKID"]);
                        child.GS = Convert.ToString(sdr["GS"]);
                        child.GSNAME = Convert.ToString(sdr["GSNAME"]);
                        child.RYID = Convert.ToInt32(sdr["RYID"]);
                        child.KKLB = Convert.ToInt32(sdr["KKLB"]);
                        child.KKLBNAME = Convert.ToString(sdr["KKLBNAME"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.ISOVER = Convert.ToInt32(sdr["ISOVER"]);
                        child.CJR = Convert.ToInt32(sdr["CJR"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJTIME = Convert.ToDateTime(sdr["CJTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.XGR = Convert.ToInt32(sdr["XGR"]);
                        child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                        child.XGTIME = Convert.ToDateTime(sdr["XGTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.ISAUTO = Convert.ToInt32(sdr["ISAUTO"]);
                        child.YGNAME = Convert.ToString(sdr["YGNAME"]);
                        child.DEPTNAME = Convert.ToString(sdr["DEPTNAME"]);
                        child.GH = Convert.ToString(sdr["GH"]);
                        child.YGTYPENAME = Convert.ToString(sdr["YGTYPENAME"]);
                        child.RZDATE = Convert.ToString(sdr["RZDATE"]);
                        child.KSMONTH = Convert.ToString(sdr["KSMONTH"]);
                        child.JSMONTH = Convert.ToString(sdr["JSMONTH"]);
                        child_HR_XZGL_KKGL_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_KKGL_SELECT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.HR_XZGL_KKGL_LIST = child_HR_XZGL_KKGL_LIST;
            return rst;
        }
    }
}

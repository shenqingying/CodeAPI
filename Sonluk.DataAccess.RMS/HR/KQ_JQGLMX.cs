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
    public class KQ_JQGLMX : IKQ_JQGLMX
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "HR_KQ_JQGLMX_INSERT";
        const string SQL_SELECT = "HR_KQ_JQGLMX_SELECT";
        const string SQL_UPDATE = "HR_KQ_JQGLMX_UPDATE";
        const string SQL_SELECT_REPORT = "HR_KQ_JQGLMX_SELECT_REPORT";
        const string SQL_AUTO_ADD_TO_FFJLMX = "HR_KQ_JQGLMX_AUTO_ADD_TO_FFJLMX";
        public MES_RETURN INSERT(HR_KQ_JQGLMX model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@JQGLID",model.JQGLID),
                                       new SqlParameter("@CHUQ",model.CHUQ),
                                       new SqlParameter("@BINJ",model.BINJ),
                                       new SqlParameter("@SHIJ",model.SHIJ),
                                       new SqlParameter("@CHANJ",model.CHANJ),
                                       new SqlParameter("@HUNJ",model.HUNJ),
                                       new SqlParameter("@SANGJ",model.SANGJ),
                                       new SqlParameter("@GONGSJ",model.GONGSJ),
                                       new SqlParameter("@BURJ",model.BURJ),
                                       new SqlParameter("@HULJ",model.HULJ),
                                       new SqlParameter("@NIANXJ",model.NIANXJ),
                                       new SqlParameter("@GONGC",model.GONGC),
                                       new SqlParameter("@KUANGG",model.KUANGG),
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_KQ_JQGLMX_INSERT", "HR");
            }
            return rst;
        }
        public MES_RETURN UPDATE(HR_KQ_JQGLMX model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@JQGLMXID",model.JQGLMXID),
                                       new SqlParameter("@CHUQ",model.CHUQ),
                                       new SqlParameter("@BINJ",model.BINJ),
                                       new SqlParameter("@SHIJ",model.SHIJ),
                                       new SqlParameter("@CHANJ",model.CHANJ),
                                       new SqlParameter("@HUNJ",model.HUNJ),
                                       new SqlParameter("@SANGJ",model.SANGJ),
                                       new SqlParameter("@GONGSJ",model.GONGSJ),
                                       new SqlParameter("@BURJ",model.BURJ),
                                       new SqlParameter("@HULJ",model.HULJ),
                                       new SqlParameter("@NIANXJ",model.NIANXJ),
                                       new SqlParameter("@GONGC",model.GONGC),
                                       new SqlParameter("@KUANGG",model.KUANGG),
                                       new SqlParameter("@KKID",model.KKID),
                                       new SqlParameter("@LB",LB),
                                       new SqlParameter("@XGR",model.XGR)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_KQ_JQGLMX_UPDATE", "HR");
            }
            return rst;
        }
        public HR_KQ_JQGLMX_SELECT SELECT(HR_KQ_JQGLMX model)
        {
            HR_KQ_JQGLMX_SELECT rst = new HR_KQ_JQGLMX_SELECT();
            List<HR_KQ_JQGLMX_LIST> child_HR_KQ_JQGLMX_LIST = new List<HR_KQ_JQGLMX_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@GH",model.GH),
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@DEPT",model.DEPT),
                                       new SqlParameter("@YGTYPE",model.YGTYPE),
                                       new SqlParameter("@KQYEAR",model.KQYEAR),
                                       new SqlParameter("@KQMONTH",model.KQMONTH),
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@KQKS",model.KQKS),
                                       new SqlParameter("@KQJS",model.KQJS)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, paras))
                {
                    while (sdr.Read())
                    {
                        HR_KQ_JQGLMX_LIST child = new HR_KQ_JQGLMX_LIST();
                        child.JQGLMXID = Convert.ToInt32(sdr["JQGLMXID"]);
                        child.RYID = Convert.ToInt32(sdr["RYID"]);
                        child.JQGLID = Convert.ToInt32(sdr["JQGLID"]);
                        child.CHUQ = Convert.ToDecimal(sdr["CHUQ"]);
                        child.BINJ = Convert.ToDecimal(sdr["BINJ"]);
                        child.SHIJ = Convert.ToDecimal(sdr["SHIJ"]);
                        child.CHANJ = Convert.ToDecimal(sdr["CHANJ"]);
                        child.HUNJ = Convert.ToDecimal(sdr["HUNJ"]);
                        child.SANGJ = Convert.ToDecimal(sdr["SANGJ"]);
                        child.GONGSJ = Convert.ToDecimal(sdr["GONGSJ"]);
                        child.BURJ = Convert.ToDecimal(sdr["BURJ"]);
                        child.HULJ = Convert.ToDecimal(sdr["HULJ"]);
                        child.NIANXJ = Convert.ToDecimal(sdr["NIANXJ"]);
                        child.GONGC = Convert.ToDecimal(sdr["GONGC"]);
                        child.KUANGG = Convert.ToDecimal(sdr["KUANGG"]);
                        child.ISXYCL = Convert.ToInt32(sdr["ISXYCL"]);
                        child.KKID = Convert.ToInt32(sdr["KKID"]);
                        child.KQYEAR = Convert.ToString(sdr["KQYEAR"]);
                        child.KQMONTH = Convert.ToString(sdr["KQMONTH"]);
                        child.ISCL = Convert.ToInt32(sdr["ISCL"]);
                        child.CLRQ = Convert.ToString(sdr["CLRQ"]);
                        child.KQZQKS = Convert.ToString(sdr["KQZQKS"]);
                        child.KQZQJS = Convert.ToString(sdr["KQZQJS"]);
                        child.KQNAME = Convert.ToString(sdr["KQNAME"]);
                        child.GH = Convert.ToString(sdr["GH"]);
                        child.YGNAME = Convert.ToString(sdr["YGNAME"]);
                        child.DEPTNAME = Convert.ToString(sdr["DEPTNAME"]);
                        child.YGTYPENAME = Convert.ToString(sdr["YGTYPENAME"]);
                        child.GS = Convert.ToString(sdr["GS"]);
                        child.GSNAME = Convert.ToString(sdr["GSNAME"]);
                        child_HR_KQ_JQGLMX_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_KQ_JQGLMX_SELECT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.HR_KQ_JQGLMX_LIST = child_HR_KQ_JQGLMX_LIST;
            return rst;
        }
        public HR_KQ_JQGLMX_SELECT SELECT_REPORT(HR_KQ_JQGLMX model, int LB)
        {
            HR_KQ_JQGLMX_SELECT rst = new HR_KQ_JQGLMX_SELECT();
            List<HR_KQ_JQGLMX_LIST> child_HR_KQ_JQGLMX_LIST = new List<HR_KQ_JQGLMX_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                       new SqlParameter("@KSKQYEAR",model.KSKQYEAR),
                                       new SqlParameter("@KSKQMONTH",model.KSKQMONTH),
                                       new SqlParameter("@JSKQYEAR",model.JSKQYEAR),
                                       new SqlParameter("@JSKQMONTH",model.JSKQMONTH),
                                       new SqlParameter("@LB",LB)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_REPORT, paras))
                {
                    while (sdr.Read())
                    {
                        HR_KQ_JQGLMX_LIST child = new HR_KQ_JQGLMX_LIST();
                        if (LB == 1)
                        {
                            child.JQGLMXID = Convert.ToInt32(sdr["JQGLMXID"]);
                            child.RYID = Convert.ToInt32(sdr["RYID"]);
                            child.JQGLID = Convert.ToInt32(sdr["JQGLID"]);
                            child.CHUQ = Convert.ToDecimal(sdr["CHUQ"]);
                            child.BINJ = Convert.ToDecimal(sdr["BINJ"]);
                            child.SHIJ = Convert.ToDecimal(sdr["SHIJ"]);
                            child.CHANJ = Convert.ToDecimal(sdr["CHANJ"]);
                            child.HUNJ = Convert.ToDecimal(sdr["HUNJ"]);
                            child.SANGJ = Convert.ToDecimal(sdr["SANGJ"]);
                            child.GONGSJ = Convert.ToDecimal(sdr["GONGSJ"]);
                            child.BURJ = Convert.ToDecimal(sdr["BURJ"]);
                            child.HULJ = Convert.ToDecimal(sdr["HULJ"]);
                            child.NIANXJ = Convert.ToDecimal(sdr["NIANXJ"]);
                            child.GONGC = Convert.ToDecimal(sdr["GONGC"]);
                            child.KUANGG = Convert.ToDecimal(sdr["KUANGG"]);
                            child.ISXYCL = Convert.ToInt32(sdr["ISXYCL"]);
                            child.KKID = Convert.ToInt32(sdr["KKID"]);
                            child.KQYEAR = Convert.ToString(sdr["KQYEAR"]);
                            child.KQMONTH = Convert.ToString(sdr["KQMONTH"]);
                            child.ISCL = Convert.ToInt32(sdr["ISCL"]);
                            child.CLRQ = Convert.ToString(sdr["CLRQ"]);
                            child.KQZQKS = Convert.ToString(sdr["KQZQKS"]);
                            child.KQZQJS = Convert.ToString(sdr["KQZQJS"]);
                            child.KQNAME = Convert.ToString(sdr["KQNAME"]);
                            child.GH = Convert.ToString(sdr["GH"]);
                            child.YGNAME = Convert.ToString(sdr["YGNAME"]);
                            child.DEPTNAME = Convert.ToString(sdr["DEPTNAME"]);
                            child.YGTYPENAME = Convert.ToString(sdr["YGTYPENAME"]);
                        }
                        else if (LB == 2)
                        {
                            child.RYID = Convert.ToInt32(sdr["RYID"]);
                            child.CHUQ = Convert.ToDecimal(sdr["CHUQ"]);
                            child.BINJ = Convert.ToDecimal(sdr["BINJ"]);
                            child.SHIJ = Convert.ToDecimal(sdr["SHIJ"]);
                            child.CHANJ = Convert.ToDecimal(sdr["CHANJ"]);
                            child.HUNJ = Convert.ToDecimal(sdr["HUNJ"]);
                            child.SANGJ = Convert.ToDecimal(sdr["SANGJ"]);
                            child.GONGSJ = Convert.ToDecimal(sdr["GONGSJ"]);
                            child.BURJ = Convert.ToDecimal(sdr["BURJ"]);
                            child.HULJ = Convert.ToDecimal(sdr["HULJ"]);
                            child.NIANXJ = Convert.ToDecimal(sdr["NIANXJ"]);
                            child.GONGC = Convert.ToDecimal(sdr["GONGC"]);
                            child.KUANGG = Convert.ToDecimal(sdr["KUANGG"]);
                            child.GH = Convert.ToString(sdr["GH"]);
                            child.YGNAME = Convert.ToString(sdr["YGNAME"]);
                            child.DEPTNAME = Convert.ToString(sdr["DEPTNAME"]);
                            child.YGTYPENAME = Convert.ToString(sdr["YGTYPENAME"]);
                        }
                        child_HR_KQ_JQGLMX_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_KQ_JQGLMX_SELECT_REPORT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.HR_KQ_JQGLMX_LIST = child_HR_KQ_JQGLMX_LIST;
            return rst;
        }

        public MES_RETURN AUTO_ADD_TO_FFJLMX(HR_KQ_JQGLMX model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@FFJLID",model.FFJLID),
                                       new SqlParameter("@JSMONTH",model.JSMONTH),
                                       new SqlParameter("@JSMONTHJS",model.JSMONTHJS),
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_KQ_JQGLMX_AUTO_ADD_TO_FFJLMX", "HR");
            }
            return rst;
        }
    }
}

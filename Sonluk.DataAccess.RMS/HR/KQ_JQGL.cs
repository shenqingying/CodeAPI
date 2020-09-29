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
    public class KQ_JQGL : IKQ_JQGL
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "HR_KQ_JQGL_INSERT";
        const string SQL_SELECT = "HR_KQ_JQGL_SELECT";
        const string SQL_UPDATE = "HR_KQ_JQGL_UPDATE";
        public MES_RETURN INSERT(HR_KQ_JQGL model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@KQYEAR",model.KQYEAR),
                                       new SqlParameter("@KQMONTH",model.KQMONTH),
                                       new SqlParameter("@KQZQKS",model.KQZQKS),
                                       new SqlParameter("@KQZQJS",model.KQZQJS),
                                       new SqlParameter("@KQNAME",model.KQNAME),
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@CJR",model.CJR)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                        rst.TID = Convert.ToInt32(sdr["JQGLID"]);
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_KQ_JQGL_INSERT", "HR");
            }
            return rst;
        }
        public MES_RETURN UPDATE(HR_KQ_JQGL model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@JQGLID",model.JQGLID),
                                       new SqlParameter("@ISCL",model.ISCL),
                                       new SqlParameter("@CLRQ",model.CLRQ),
                                       new SqlParameter("@KQZQKS",model.KQZQKS),
                                       new SqlParameter("@KQZQJS",model.KQZQJS),
                                       new SqlParameter("@KQNAME",model.KQNAME),
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_KQ_JQGL_UPDATE", "HR");
            }
            return rst;
        }
        public HR_KQ_JQGL_SELECT SELECT(HR_KQ_JQGL model)
        {
            HR_KQ_JQGL_SELECT rst = new HR_KQ_JQGL_SELECT();
            List<HR_KQ_JQGL_LIST> child_HR_KQ_JQGL_LIST = new List<HR_KQ_JQGL_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                       new SqlParameter("@KQYEAR",model.KQYEAR),
                                       new SqlParameter("@KQMONTH",model.KQMONTH),
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, paras))
                {
                    while (sdr.Read())
                    {
                        HR_KQ_JQGL_LIST child = new HR_KQ_JQGL_LIST();
                        child.JQGLID = Convert.ToInt32(sdr["JQGLID"]);
                        child.KQYEAR = Convert.ToString(sdr["KQYEAR"]);
                        child.KQMONTH = Convert.ToString(sdr["KQMONTH"]);
                        child.ISCL = Convert.ToInt32(sdr["ISCL"]);
                        child.CLRQ = Convert.ToString(sdr["CLRQ"]);
                        child.KQZQKS = Convert.ToString(sdr["KQZQKS"]);
                        child.KQZQJS = Convert.ToString(sdr["KQZQJS"]);
                        child.KQNAME = Convert.ToString(sdr["KQNAME"]);
                        child.GS = Convert.ToString(sdr["GS"]);
                        child.GSNAME = Convert.ToString(sdr["GSNAME"]);
                        child_HR_KQ_JQGL_LIST.Add(child);
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
            rst.HR_KQ_JQGL_LIST = child_HR_KQ_JQGL_LIST;
            return rst;
        }
    }
}

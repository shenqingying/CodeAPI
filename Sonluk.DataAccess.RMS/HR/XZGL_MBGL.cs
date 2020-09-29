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
    public class XZGL_MBGL : IXZGL_MBGL
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "HR_XZGL_MBGL_INSERT";
        const string SQL_SELECT = "HR_XZGL_MBGL_SELECT";
        const string SQL_UPDATE = "HR_XZGL_MBGL_UPDATE";
        const string SQL_SELECT_YYCOUNT = "SELECT COUNT(*) AS MBCOUNT FROM HR_XZGL_FFJL WHERE ISDELETE=0 AND FFLB=@MBID";
        public MES_RETURN INSERT(HR_XZGL_MBGL model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@MBNAME",model.MBNAME),
                                       new SqlParameter("@MBLB",model.MBLB),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@CJR",model.CJR),
                                       new SqlParameter("@JSFS",model.JSFS)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                        rst.TID = Convert.ToInt32(sdr["MBID"]);
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_MBGL_INSERT", "HR");
            }
            return rst;
        }
        public MES_RETURN UPDATE(HR_XZGL_MBGL model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@MBID",model.MBID),
                                       new SqlParameter("@MBNAME",model.MBNAME),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@XGR",model.XGR),
                                       new SqlParameter("@LB",LB),
                                       new SqlParameter("@JSFS",model.JSFS)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_MBGL_UPDATE", "HR");
            }
            return rst;
        }
        public HR_XZGL_MBGL_SELECT SELECT(HR_XZGL_MBGL model)
        {
            HR_XZGL_MBGL_SELECT rst = new HR_XZGL_MBGL_SELECT();
            List<HR_XZGL_MBGL_LIST> child_HR_XZGL_MBGL_LIST = new List<HR_XZGL_MBGL_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@MBLB",model.MBLB),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@MXID",model.MXID),
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@MXIDLIST",model.MXIDLIST),
                                       new SqlParameter("@MBID",model.MBID),
                                       new SqlParameter("@JSFS",model.JSFS)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, paras))
                {
                    while (sdr.Read())
                    {
                        HR_XZGL_MBGL_LIST child = new HR_XZGL_MBGL_LIST();
                        child.MBID = Convert.ToInt32(sdr["MBID"]);
                        child.GS = Convert.ToString(sdr["GS"]);
                        child.GSNAME = Convert.ToString(sdr["GSNAME"]);
                        child.MBNAME = Convert.ToString(sdr["MBNAME"]);
                        child.MBLB = Convert.ToInt32(sdr["MBLB"]);
                        child.MBLBNAME = Convert.ToString(sdr["MBLBNAME"]);
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.CJR = Convert.ToInt32(sdr["CJR"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJTIME = Convert.ToDateTime(sdr["CJTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.XGR = Convert.ToInt32(sdr["XGR"]);
                        child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                        child.XGTIME = Convert.ToDateTime(sdr["XGTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.JSFS = Convert.ToInt32(sdr["JSFS"]);
                        child_HR_XZGL_MBGL_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_MBGL_SELECT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.HR_XZGL_MBGL_LIST = child_HR_XZGL_MBGL_LIST;
            return rst;
        }

        public MES_RETURN SELECT_YYCOUNT(HR_XZGL_MBGL model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@MBID",model.MBID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT_YYCOUNT, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TID = Convert.ToInt32(sdr["MBCOUNT"]);
                    }
                }
                rst.TYPE = "S";
                rst.MESSAGE = "";
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_MBGL_SELECT_YYCOUNT", "HR");
            }
            return rst;
        }
    }
}

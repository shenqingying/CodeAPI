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
    public class XZGL_FFJLMX : IXZGL_FFJLMX
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "HR_XZGL_FFJLMX_INSERT";
        const string SQL_UPDATE = "HR_XZGL_FFJLMX_UPDATE";
        const string SQL_SELECT = "HR_XZGL_FFJLMX_SELECT";
        const string SQL_FORMULA_JS = "HR_XZGL_FFJLMX_FORMULA_JS";
        const string SQL_FORMULA_JS_TZ = "HR_XZGL_FFJLMX_FORMULA_JS_TZ";
        const string SQL_AUTO_ADD_TO_FFJLMX_OTHER = "HR_XZGL_FFJLMX_AUTO_ADD_TO_FFJLMX_OTHER";
        const string SQL_SELECT_GSREPORT = "HR_XZGL_FFJLMX_SELECT_GSREPORT";
        const string SQL_SELECT_FFMXREPORT = "HR_XZGL_FFJLMX_SELECT_FFMXREPORT";
        const string SQL_SELECT_GZXJSDREPORT = "HR_XZGL_FFJLMX_SELECT_GZXJSDREPORT";
        const string SQL_SELECT_FFMXGZDREPORT = "HR_XZGL_FFJLMX_SELECT_FFMXGZDREPORT";
        const string SQL_SELECT_FFMXGZHZREPORT = "HR_XZGL_FFJLMX_SELECT_FFMXGZHZREPORT";
        const string SQL_SELECT_FFMXTXFREPORT = "HR_XZGL_FFJLMX_SELECT_FFMXTXFREPORT";
        const string SQL_SELECT_GUOSHUIREPORT = "HR_XZGL_FFJLMX_SELECT_GUOSHUIREPORT";
        public MES_RETURN INSERT(HR_XZGL_FFJLMX model, DataTable dt)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@FFJLID",model.FFJLID),
                                       new SqlParameter("@MYPW",model.MYPW),
                                       new SqlParameter("@RYLIST",model.RYLIST)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                        rst.TID = Convert.ToInt32(sdr["FFJLMXID"]);
                    }
                    //if (rst.TYPE == "S")
                    //{
                    //    HR_XZGL_FFJLMX model_HR_XZGL_FFJLMX = new HR_XZGL_FFJLMX();
                    //    model_HR_XZGL_FFJLMX.FFJLID = model.FFJLID;
                    //    model_HR_XZGL_FFJLMX.FFJLMXID = rst.TID;
                    //    model_HR_XZGL_FFJLMX.MYPW = model.MYPW;
                    //    FORMULA_JS(model_HR_XZGL_FFJLMX, 2);
                    //}
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FFJLMX_INSERT", "HR");
            }
            return rst;
        }
        public MES_RETURN UPDATE(HR_XZGL_FFJLMX model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@FFJLMXID",model.FFJLMXID),
                                       new SqlParameter("@FFJLZDNAME",model.FFJLZDNAME),
                                       new SqlParameter("@ZDVALUE",model.ZDVALUE),
                                       new SqlParameter("@LB",LB),
                                       new SqlParameter("@MYPW",model.MYPW),
                                       new SqlParameter("@FFJLMXLIST",model.FFJLMXLIST)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FFJLMX_UPDATE", "HR");
            }
            return rst;
        }
        public HR_XZGL_FFJLMX_SELECT SELECT(HR_XZGL_FFJLMX model, int LB)
        {
            HR_XZGL_FFJLMX_SELECT rst = new HR_XZGL_FFJLMX_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                       new SqlParameter("@FFJLID",model.FFJLID),
                                       new SqlParameter("@MYPW",model.MYPW),
                                       new SqlParameter("@LB",LB),
                                       new SqlParameter("@KSMONTH",model.KSMONTH),
                                       new SqlParameter("@JSMONTH",model.JSMONTH),
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@SEARCHINFO",model.SEARCHINFO),
                                       new SqlParameter("@RYID",model.RYID)
                                   };
                rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_SELECT, paras);
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FFJLMX_SELECT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN FORMULA_JS(HR_XZGL_FFJLMX model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@FFJLID",model.FFJLID),
                                       new SqlParameter("@FFJLMXID",model.FFJLMXID),
                                       new SqlParameter("@LB",LB),
                                       new SqlParameter("@MYPW",model.MYPW),
                                       new SqlParameter("@ISJSSE",model.ISJSSE)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_FORMULA_JS, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FFJLMX_FORMULA_JS", "HR");
            }
            return rst;
        }

        public MES_RETURN FORMULA_JS_TZ(HR_XZGL_FFJLMX model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@FFJLID",model.FFJLID),
                                       new SqlParameter("@FFJLMXID",model.FFJLMXID),
                                       new SqlParameter("@LB",LB),
                                       new SqlParameter("@MYPW",model.MYPW)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_FORMULA_JS_TZ, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FFJLMX_FORMULA_JS_TZ", "HR");
            }
            return rst;
        }

        public MES_RETURN AUTO_ADD_TO_FFJLMX_OTHER(HR_XZGL_FFJLMX model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@FFJLID",model.FFJLID),
                                       new SqlParameter("@SXDATE",model.SXDATE),
                                       new SqlParameter("@LB",LB),
                                       new SqlParameter("@MYPW",model.MYPW)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_AUTO_ADD_TO_FFJLMX_OTHER, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FFJLMX_AUTO_ADD_TO_FFJLMX_OTHER", "HR");
            }
            return rst;
        }
        public HR_XZGL_FFJLMX_SELECT SELECT_GSREPORT(HR_XZGL_FFJLMX model)
        {
            HR_XZGL_FFJLMX_SELECT rst = new HR_XZGL_FFJLMX_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                       new SqlParameter("@GH",model.GH),
                                       new SqlParameter("@KSMONTH",model.KSMONTH),
                                       new SqlParameter("@JSMONTH",model.JSMONTH),
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@MYPW",model.MYPW)
                                   };
                rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_SELECT_GSREPORT, paras);
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FFJLMX_SELECT_GSREPORT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public HR_XZGL_FFJLMX_SELECT SELECT_FFMXREPORT(HR_XZGL_FFJLMX model)
        {
            HR_XZGL_FFJLMX_SELECT rst = new HR_XZGL_FFJLMX_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@DEPTNAME",model.DEPTNAME),
                                       new SqlParameter("@KSMONTH",model.KSMONTH),
                                       new SqlParameter("@JSMONTH",model.JSMONTH),
                                       new SqlParameter("@MBID",model.MBID),
                                       new SqlParameter("@GH",model.GH),
                                       new SqlParameter("@YGTYPENAME",model.YGTYPENAME),
                                       new SqlParameter("@FFLY",model.FFLY),
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@MYPW",model.MYPW),
                                       new SqlParameter("@JSFS",model.JSFS),
                                       new SqlParameter("@GSLB",model.GSLB)
                                   };
                rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_SELECT_FFMXREPORT, paras);
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FFJLMX_SELECT_FFMXREPORT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public HR_XZGL_FFJLMX_SELECT SELECT_GZXJSDREPORT(HR_XZGL_FFJLMX model)
        {
            HR_XZGL_FFJLMX_SELECT rst = new HR_XZGL_FFJLMX_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@KSMONTH",model.KSMONTH),
                                       new SqlParameter("@JSMONTH",model.JSMONTH),
                                       new SqlParameter("@GH",model.GH),
                                       new SqlParameter("@FFLY",model.FFLY),
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@MYPW",model.MYPW)
                                   };
                rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_SELECT_GZXJSDREPORT, paras);
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FFJLMX_SELECT_GZXJSDREPORT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public HR_XZGL_FFJLMX_SELECT SELECT_FFMXGZDREPORT(HR_XZGL_FFJLMX model)
        {
            HR_XZGL_FFJLMX_SELECT rst = new HR_XZGL_FFJLMX_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                       new SqlParameter("@FFJLID",model.FFJLID),
                                       new SqlParameter("@ZHLB",model.ZHLB),
                                       new SqlParameter("@MBID",model.MBID),
                                       new SqlParameter("@MYPW",model.MYPW),
                                       new SqlParameter("@PXLB",model.PXLB)
                                   };
                rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_SELECT_FFMXGZDREPORT, paras);
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FFJLMX_SELECT_FFMXGZDREPORT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public HR_XZGL_FFJLMX_SELECT SELECT_FFMXGZHZREPORT(HR_XZGL_FFJLMX model)
        {
            HR_XZGL_FFJLMX_SELECT rst = new HR_XZGL_FFJLMX_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                       new SqlParameter("@FFJLID",model.FFJLID),
                                       new SqlParameter("@MBID",model.MBID),
                                       new SqlParameter("@MYPW",model.MYPW)
                                   };
                rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_SELECT_FFMXGZHZREPORT, paras);
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FFJLMX_SELECT_FFMXGZHZREPORT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public HR_XZGL_FFJLMX_SELECT SELECT_FFMXTXFREPORT(HR_XZGL_FFJLMX model, int LB)
        {
            HR_XZGL_FFJLMX_SELECT rst = new HR_XZGL_FFJLMX_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@KSMONTH",model.KSMONTH),
                                       new SqlParameter("@MYPW",model.MYPW),
                                       new SqlParameter("@LB",LB)
                                   };
                rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_SELECT_FFMXTXFREPORT, paras);
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FFJLMX_SELECT_FFMXTXFREPORT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public HR_XZGL_FFJLMX_SELECT SELECT_GUOSHUIREPORT(HR_XZGL_FFJLMX model)
        {
            HR_XZGL_FFJLMX_SELECT rst = new HR_XZGL_FFJLMX_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@SBMONTH",model.KSMONTH),
                                       new SqlParameter("@GH",model.GH),
                                       new SqlParameter("@GSLB",model.GSLB),
                                       new SqlParameter("@FFLY",model.FFLY),
                                       new SqlParameter("@MYPW",model.MYPW),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };
                rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_SELECT_GUOSHUIREPORT, paras);
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FFJLMX_SELECT_GUOSHUIREPORT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
    }
}

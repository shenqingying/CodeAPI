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
    public class XZGL_FLDATZMX : IXZGL_FLDATZMX
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_SELECT_REPORT = "HR_XZGL_FLDATZMX_SELECT_REPORT";
        const string SQL_SELECT = "HR_XZGL_FLDATZMX_SELECT";
        const string SQL_UPDATE = "HR_XZGL_FLDATZMX_UPDATE";
        public HR_XZGL_FLDATZMX_SELECT_REPORT SELECT_REPORT(HR_XZGL_FLDATZMX model)
        {
            HR_XZGL_FLDATZMX_SELECT_REPORT rst = new HR_XZGL_FLDATZMX_SELECT_REPORT();
            List<HR_XZGL_FLDATZMX_LIST_REPORT> child_HR_XZGL_FLDATZMX_LIST_REPORT = new List<HR_XZGL_FLDATZMX_LIST_REPORT>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                       new SqlParameter("@TZYEAR",model.TZYEAR),
                                       new SqlParameter("@TZMONTH",model.TZMONTH),
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@GH",model.GH),
                                       new SqlParameter("@YGNAME",model.YGNAME),
                                       new SqlParameter("@DEPT",model.DEPT),
                                       new SqlParameter("@ZZTYPE",model.ZZTYPE),
                                       new SqlParameter("@FLFAID",model.FLFAID),
                                       new SqlParameter("@MYPW",model.MYPW),
                                       new SqlParameter("@FLTZID",model.FLTZID),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_REPORT, paras))
                {
                    while (sdr.Read())
                    {
                        HR_XZGL_FLDATZMX_LIST_REPORT child = new HR_XZGL_FLDATZMX_LIST_REPORT();
                        child.RYID = Convert.ToInt32(sdr["RYID"]);
                        child.FLTZID = Convert.ToInt32(sdr["FLTZID"]);
                        child.GS = Convert.ToString(sdr["GS"]);
                        child.GSNAME = Convert.ToString(sdr["GSNAME"]);
                        child.GH = Convert.ToString(sdr["GH"]);
                        child.YGNAME = Convert.ToString(sdr["YGNAME"]);
                        child.DEPTNAME = Convert.ToString(sdr["DEPTNAME"]);
                        child.ZZTYPENAME = Convert.ToString(sdr["ZZTYPENAME"]);
                        child.ZZNO = Convert.ToString(sdr["ZZNO"]);
                        child.YGTYPENAME = Convert.ToString(sdr["YGTYPENAME"]);
                        child.FLFAID = Convert.ToInt32(sdr["FLFAID"]);
                        child.FANAME = Convert.ToString(sdr["FANAME"]);
                        child.SBJS = Convert.ToDecimal(sdr["SBJS"]);
                        child.GJJJS = Convert.ToDecimal(sdr["GJJJS"]);
                        child.GR_SB = Convert.ToDecimal(sdr["GR_SB"]);
                        child.GR_YB = Convert.ToDecimal(sdr["GR_YB"]);
                        child.GR_SY = Convert.ToDecimal(sdr["GR_SY"]);
                        child.GR_SBHJ = Convert.ToDecimal(sdr["GR_SBHJ"]);
                        child.GR_GJJ = Convert.ToDecimal(sdr["GR_GJJ"]);
                        child.GR_ALL = Convert.ToDecimal(sdr["GR_ALL"]);
                        child.DW_SB = Convert.ToDecimal(sdr["DW_SB"]);
                        child.DW_YB = Convert.ToDecimal(sdr["DW_YB"]);
                        child.DW_SY = Convert.ToDecimal(sdr["DW_SY"]);
                        child.DW_SHENGYU = Convert.ToDecimal(sdr["DW_SHENGYU"]);
                        child.DW_GONGSHANG = Convert.ToDecimal(sdr["DW_GONGSHANG"]);
                        child.DW_SBHJ = Convert.ToDecimal(sdr["DW_SBHJ"]);
                        child.DW_GJJ = Convert.ToDecimal(sdr["DW_GJJ"]);
                        child.DW_ALL = Convert.ToDecimal(sdr["DW_ALL"]);
                        child.ALL = child.GR_ALL + child.DW_ALL;
                        child.ISUSE = Convert.ToInt32(sdr["ISUSE"]);
                        child_HR_XZGL_FLDATZMX_LIST_REPORT.Add(child);
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
            rst.HR_XZGL_FLDATZMX_LIST_REPORT = child_HR_XZGL_FLDATZMX_LIST_REPORT;
            return rst;
        }
        public HR_XZGL_FLDATZMX_SELECT SELECT(HR_XZGL_FLDATZMX model)
        {
            HR_XZGL_FLDATZMX_SELECT rst = new HR_XZGL_FLDATZMX_SELECT();
            List<HR_XZGL_FLDATZMX_LIST> child_HR_XZGL_FLDATZMX_LIST = new List<HR_XZGL_FLDATZMX_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                       new SqlParameter("@MYPW",model.MYPW),
                                       new SqlParameter("@FLTZID",model.FLTZID),
                                       new SqlParameter("@RYID",model.RYID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, paras))
                {
                    while (sdr.Read())
                    {
                        HR_XZGL_FLDATZMX_LIST child = new HR_XZGL_FLDATZMX_LIST();
                        child.FLTZMXID = Convert.ToInt32(sdr["FLTZMXID"]);
                        child.FLTZID = Convert.ToInt32(sdr["FLTZID"]);
                        child.RYID = Convert.ToInt32(sdr["RYID"]);
                        child.FLFAMXID = Convert.ToInt32(sdr["FLFAMXID"]);
                        child.FLGRJE = Convert.ToDecimal(sdr["FLGRJE"]);
                        child.FLDWJE = Convert.ToDecimal(sdr["FLDWJE"]);
                        child.FLMXXZNAME = Convert.ToString(sdr["FLMXXZNAME"]);
                        child_HR_XZGL_FLDATZMX_LIST.Add(child);
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
            rst.HR_XZGL_FLDATZMX_LIST = child_HR_XZGL_FLDATZMX_LIST;
            return rst;
        }
        public MES_RETURN UPDATE(HR_XZGL_FLDATZMX model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@FLTZMXID",model.FLTZMXID),
                                       new SqlParameter("@FLGRJE",model.FLGRJE),
                                       new SqlParameter("@FLDWJE",model.FLDWJE),
                                       new SqlParameter("@XGR",model.XGR),
                                       new SqlParameter("@LB",LB),
                                       new SqlParameter("@MYPW",model.MYPW)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FLDATZMX_UPDATE", "HR");
            }
            return rst;
        }
    }
}

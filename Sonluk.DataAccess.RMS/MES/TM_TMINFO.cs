using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.MES
{
    public class TM_TMINFO : ITM_TMINFO
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        SY_TABLE_COLUMN SY_TABLE_COLUMNService = new SY_TABLE_COLUMN();
        string SQL_INSERT = "MES_TM_TMINFO_INSERT";
        string SQL_INSERT_OLD = "MES_TM_TMINFO_INSERT_OLD";
        string SQL_INSERT_FB = "MES_TM_TMINFO_INSERT_FB";
        string SQL_SELECT_BYTM = "MES_TM_TMINFO_SELECT_BYTM";
        string SQL_SELECT_BYID_CHILD = "MES_TM_TMINFO_SELECT_BYID_CHILD";
        const string SQL_SELECT_TL_LAST = "MES_TM_TMINFO_SELECT_TL_LAST";
        const string SQL_SELECT_TM_LASTTIME = "MES_TM_TMINFO_SELECT_TM_LASTTIME";
        const string SQL_SELECT = "MES_TM_TMINFO_SELECT";
        const string SQL_SELECT_LB = "MES_TM_TMINFO_SELECT_LB";
        const string SQL_SELECT_ALL = "MES_TM_TMINFO_SELECT_ALL";
        const string SQL_DELETE_BYTM = "UPDATE MES_TM_TMINFO SET ISDELETE=1 WHERE TM=@TM";
        const string SQL_DELETE = "MES_TM_TMINFO_DELETE";
        const string SQL_SELECT_BY_ROLE = "MES_TM_TMINFO_SELECT_BY_ROLE";
        const string SQL_SELECT_BY_KCDDLimit = "MES_TM_TMINFO_SELECT_BY_KCDDLimit";
        const string SQL_SELECT_BY_TM_GLSELECT = "MES_TM_GLSELECT";
        const string SQL_SELECT_BY_TM_GLSELECT_ALL = "MES_TM_GLSELECT_ALL";
        const string SQL_SELECT_BY_TM_GLSELECT_ALL_ZS_TL = "MES_TM_GLSELECT_ALL_ZS_TL";
        const string SQL_UPDATE = "MES_TM_TMINFO_UPDATE";
        const string SQL_UPDATE_CF = "MES_TM_TMINFO_UPDATE_CF";
        const string SQL_SELECT_TL_GL_CC = "MES_TM_TMINFO_SELECT_TL_GL_CC";
        const string SQL_SELECT_LIST = "MES_TM_TMINFO_SELECT_LIST";
        public MES_RETURN INSERT(MES_TM_TMINFO model)
        {
            if (model.KSTIME == "")
            {
                model.KSTIME = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            if (model.JSTIME == "")
            {
                model.JSTIME = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            MES_RETURN mr = new MES_RETURN();
            try
            {
                DateTime dtime = Convert.ToDateTime(model.KSTIME);
                dtime = Convert.ToDateTime(model.JSTIME);
            }
            catch
            {
                mr.TYPE = "E";
                mr.MESSAGE = "转换日期格式出错！";
                return mr;
            }

            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@TM",model.TM),
                                       new SqlParameter("@TMLB",model.TMLB),
                                       new SqlParameter("@TMSX",model.TMSX),
                                       new SqlParameter("@SCDATE",model.SCDATE),
                                       new SqlParameter("@BC",model.BC),
                                       new SqlParameter("@RWBH",model.RWBH),
                                       new SqlParameter("@PC",model.PC),
                                       new SqlParameter("@JLR",model.JLR),
                                       new SqlParameter("@CLCJ",model.CLCJ),
                                       new SqlParameter("@GYLX",model.GYLX),
                                       new SqlParameter("@GYS",model.GYS),
                                       new SqlParameter("@GYSMS",model.GYSMS),
                                       new SqlParameter("@GYSPC",model.GYSPC),
                                       new SqlParameter("@CPZT",model.CPZT),
                                       new SqlParameter("@CPZTNAME",model.CPZTNAME),
                                       new SqlParameter("@SL",model.SL),
                                       new SqlParameter("@KSTIME",model.KSTIME),
                                       new SqlParameter("@JSTIME",model.JSTIME),
                                       new SqlParameter("@XFWLH",model.XFWLH),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@SBZ",model.SBZ),
                                       new SqlParameter("@SIZE",model.SIZE),
                                       new SqlParameter("@SYSCX",model.SYSCX),
                                       new SqlParameter("@SYCPGG",model.SYCPGG),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@SBHMS",model.SBHMS),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@WLMS",model.WLMS),
                                       new SqlParameter("@WLLB",model.WLLB),
                                       new SqlParameter("@WLLBNAME",model.WLLBNAME),
                                       new SqlParameter("@DCDJ",model.DCDJ),
                                       new SqlParameter("@DCDJMS",model.DCDJMS),
                                       new SqlParameter("@DCXH",model.DCXH),
                                       new SqlParameter("@DCXHMS",model.DCXHMS),
                                       new SqlParameter("@PFDH",model.PFDH),
                                       new SqlParameter("@PLDH",model.PLDH),
                                       new SqlParameter("@TH",model.TH),
                                       new SqlParameter("@WLGROUP",model.WLGROUP),
                                       new SqlParameter("@THGG",model.THGG),
                                       new SqlParameter("@ERPNO",model.ERPNO),
                                       new SqlParameter("@UNITSID",model.UNITSID),
                                       new SqlParameter("@UNITSNAME",model.UNITSNAME),
                                       new SqlParameter("@DCSLBS",model.DCSLBS),
                                       new SqlParameter("@DCSLMBSL",model.DCSLMBSL),
                                       new SqlParameter("@DCSLYS",model.DCSLYS),
                                       new SqlParameter("@SBCD",model.SBCD),
                                       new SqlParameter("@RQM",model.RQM),
                                       new SqlParameter("@TPM",model.TPM),
                                       new SqlParameter("@ZFDCLB",model.ZFDCLB),
                                       new SqlParameter("@KCDDGC",model.KCDDGC),
                                       new SqlParameter("@KCDD",model.KCDD),
                                       new SqlParameter("@KCDDNAME",model.KCDDNAME),
                                       new SqlParameter("@CGBILL",model.CGBILL),
                                       new SqlParameter("@CGBILLMX",model.CGBILLMX),
                                       new SqlParameter("@NOBILL",model.NOBILL),
                                       new SqlParameter("@NOBILLMX",model.NOBILLMX),
                                       new SqlParameter("@CFTS",model.CFTS),
                                       new SqlParameter("@XDGX",model.XDGX),
                                       new SqlParameter("@MAC",model.MAC),
                                       new SqlParameter("@MID",model.MID),
                                       new SqlParameter("@JZ",model.JZ),
                                       new SqlParameter("@CPTYPE",model.CPTYPE),
                                       new SqlParameter("@WQH",model.WQH),
                                       new SqlParameter("@MFQCOLOR",model.MFQCOLOR),
                                       new SqlParameter("@CLPBDM",model.CLPBDM),
                                       new SqlParameter("@GLTMCOUNT",model.GLTMCOUNT)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
                {
                    while (sdr.Read())
                    {
                        mr.TYPE = Convert.ToString(sdr["TYPE"]);
                        mr.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                        mr.GC = Convert.ToString(sdr["GC"]);
                        mr.TM = Convert.ToString(sdr["TM"]);
                    }
                }
                //mr.TYPE = "S";
                //mr.MESSAGE = "";
            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "TM_TMINFO_INSERT");
            }
            return mr;
        }

        public MES_RETURN INSERT_OLD(MES_TM_TMINFO model)
        {
            if (model.KSTIME == "")
            {
                model.KSTIME = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            if (model.JSTIME == "")
            {
                model.JSTIME = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            MES_RETURN mr = new MES_RETURN();
            try
            {
                DateTime dtime = Convert.ToDateTime(model.KSTIME);
                dtime = Convert.ToDateTime(model.JSTIME);
            }
            catch
            {
                mr.TYPE = "E";
                mr.MESSAGE = "转换日期格式出错！";
                return mr;
            }

            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@TM",model.TM),
                                       new SqlParameter("@TMLB",model.TMLB),
                                       new SqlParameter("@TMSX",model.TMSX),
                                       new SqlParameter("@SCDATE",model.SCDATE),
                                       new SqlParameter("@BC",model.BC),
                                       new SqlParameter("@RWBH",model.RWBH),
                                       new SqlParameter("@PC",model.PC),
                                       new SqlParameter("@JLR",model.JLR),
                                       new SqlParameter("@CLCJ",model.CLCJ),
                                       new SqlParameter("@GYLX",model.GYLX),
                                       new SqlParameter("@GYS",model.GYS),
                                       new SqlParameter("@GYSMS",model.GYSMS),
                                       new SqlParameter("@GYSPC",model.GYSPC),
                                       new SqlParameter("@CPZT",model.CPZT),
                                       new SqlParameter("@CPZTNAME",model.CPZTNAME),
                                       new SqlParameter("@SL",model.SL),
                                       new SqlParameter("@KSTIME",model.KSTIME),
                                       new SqlParameter("@JSTIME",model.JSTIME),
                                       new SqlParameter("@XFWLH",model.XFWLH),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@SBZ",model.SBZ),
                                       new SqlParameter("@SIZE",model.SIZE),
                                       new SqlParameter("@SYSCX",model.SYSCX),
                                       new SqlParameter("@SYCPGG",model.SYCPGG),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@SBHMS",model.SBHMS),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@WLMS",model.WLMS),
                                       new SqlParameter("@WLLB",model.WLLB),
                                       new SqlParameter("@WLLBNAME",model.WLLBNAME),
                                       new SqlParameter("@DCDJ",model.DCDJ),
                                       new SqlParameter("@DCDJMS",model.DCDJMS),
                                       new SqlParameter("@DCXH",model.DCXH),
                                       new SqlParameter("@DCXHMS",model.DCXHMS),
                                       new SqlParameter("@PFDH",model.PFDH),
                                       new SqlParameter("@PLDH",model.PLDH),
                                       new SqlParameter("@TH",model.TH),
                                       new SqlParameter("@WLGROUP",model.WLGROUP),
                                       new SqlParameter("@THGG",model.THGG),
                                       new SqlParameter("@ERPNO",model.ERPNO),
                                       new SqlParameter("@UNITSID",model.UNITSID),
                                       new SqlParameter("@UNITSNAME",model.UNITSNAME),
                                       new SqlParameter("@DCSLBS",model.DCSLBS),
                                       new SqlParameter("@DCSLMBSL",model.DCSLMBSL),
                                       new SqlParameter("@DCSLYS",model.DCSLYS),
                                       new SqlParameter("@SBCD",model.SBCD),
                                       new SqlParameter("@RQM",model.RQM),
                                       new SqlParameter("@TPM",model.TPM),
                                       new SqlParameter("@ZFDCLB",model.ZFDCLB),
                                       new SqlParameter("@KCDDGC",model.KCDDGC),
                                       new SqlParameter("@KCDD",model.KCDD),
                                       new SqlParameter("@KCDDNAME",model.KCDDNAME),
                                       new SqlParameter("@CGBILL",model.CGBILL),
                                       new SqlParameter("@CGBILLMX",model.CGBILLMX),
                                       new SqlParameter("@NOBILL",model.NOBILL),
                                       new SqlParameter("@NOBILLMX",model.NOBILLMX),
                                       new SqlParameter("@CFTS",model.CFTS),
                                       new SqlParameter("@XDGX",model.XDGX),
                                       new SqlParameter("@MAC",model.MAC),
                                       new SqlParameter("@MID",model.MID),
                                       new SqlParameter("@JZ",model.JZ),
                                       new SqlParameter("@CPTYPE",model.CPTYPE),
                                       new SqlParameter("@WQH",model.WQH),
                                       new SqlParameter("@MFQCOLOR",model.MFQCOLOR),
                                       new SqlParameter("@GLTMCOUNT",model.GLTMCOUNT)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT_OLD, parms))
                {
                    while (sdr.Read())
                    {
                        mr.GC = Convert.ToString(sdr["GC"]);
                        mr.TM = Convert.ToString(sdr["TM"]);
                    }
                }
                mr.TYPE = "S";
                mr.MESSAGE = "";
            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "TM_TMINFO_INSERT");
            }
            return mr;
        }
        public SELECT_MES_TM_TMINFO_BYTM SELECT_BYTM(MES_TM_TMINFO model, int LB)
        {
            SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
            List<MES_TM_TMINFO_LIST> child_MES_TM_TMINFO_LIST = new List<MES_TM_TMINFO_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            if (model.TM == "")
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "输入条码不能为空！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@TM",model.TM),
                                       new SqlParameter("@WLLB",model.WLLB)
                                   };
                string SQL_SELECT = "";
                if (LB == 1)
                {
                    SQL_SELECT = SQL_SELECT_BYTM;
                }
                else if (LB == 2)
                {
                    SQL_SELECT = SQL_SELECT_BYID_CHILD;
                }
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_TM_TMINFO_LIST child = new MES_TM_TMINFO_LIST();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.GCDYMS = Convert.ToString(sdr["GCDYMS"]);
                        child.TM = Convert.ToString(sdr["TM"]);
                        child.TMLB = Convert.ToInt32(sdr["TMLB"]);
                        child.TMSX = Convert.ToInt32(sdr["TMSX"]);
                        child.SCDATE = Convert.ToString(sdr["SCDATE"]);
                        child.BC = Convert.ToInt32(sdr["BC"]);
                        child.BCMS = Convert.ToString(sdr["BCMS"]);
                        child.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        child.GZZXMS = Convert.ToString(sdr["GZZXMS"]);
                        child.SBBH = Convert.ToString(sdr["SBBH"]);
                        child.SBHMS = Convert.ToString(sdr["SBHMS"]);
                        child.RWBH = Convert.ToString(sdr["RWBH"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.WLMS = Convert.ToString(sdr["WLMS"]);
                        child.PC = Convert.ToString(sdr["PC"]);
                        child.CLCJ = Convert.ToString(sdr["CLCJ"]);
                        child.GYLX = Convert.ToString(sdr["GYLX"]);
                        child.GYS = Convert.ToString(sdr["GYS"]);
                        child.GYSMS = Convert.ToString(sdr["GYSMS"]);
                        child.GYSPC = Convert.ToString(sdr["GYSPC"]);
                        child.CPZT = Convert.ToInt32(sdr["CPZT"]);
                        child.CPZTNAME = Convert.ToString(sdr["CPZTNAME"]);
                        child.PFDH = Convert.ToString(sdr["PFDH"]);
                        child.PLDH = Convert.ToString(sdr["PLDH"]);
                        child.TH = Convert.ToInt32(sdr["TH"]);
                        child.SL = Convert.ToDecimal(sdr["SL"]);
                        child.KSTIME = Convert.ToDateTime(sdr["KSTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.JSTIME = Convert.ToDateTime(sdr["JSTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.XFWLH = Convert.ToString(sdr["XFWLH"]);
                        child.DCDJ = Convert.ToInt32(sdr["DCDJ"]);
                        child.DCDJMS = Convert.ToString(sdr["DCDJMS"]);
                        child.DCXH = Convert.ToInt32(sdr["DCXH"]);
                        child.DCXHMS = Convert.ToString(sdr["DCXHMS"]);
                        child.TPM = Convert.ToString(sdr["TPM"]);
                        child.SBCD = Convert.ToInt32(sdr["SBCD"]);
                        child.SBCDMS = Convert.ToString(sdr["SBCDMS"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.JLR = Convert.ToInt32(sdr["JLR"]);
                        child.JLRMS = Convert.ToString(sdr["JLRMS"]);
                        child.JLTIME = Convert.ToDateTime(sdr["JLTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.NOBILL = Convert.ToString(sdr["NOBILL"]);
                        child.NOBILLMX = Convert.ToString(sdr["NOBILLMX"]);
                        child.WLLB = Convert.ToInt32(sdr["WLLB"]);
                        child.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        child.UNITSNAME = Convert.ToString(sdr["UNITSNAME"]);
                        child.ERPNO = Convert.ToString(sdr["ERPNO"]);
                        child.SBZ = Convert.ToString(sdr["SBZ"]);
                        child.SIZE = Convert.ToInt32(sdr["SIZE"]);
                        child.SIZENAME = Convert.ToString(sdr["SIZENAME"]);
                        child.SYSCX = Convert.ToString(sdr["SYSCX"]);
                        child.SYCPGG = Convert.ToString(sdr["SYCPGG"]);
                        child.THGG = Convert.ToString(sdr["THGG"]);
                        child.DCSLBS = Convert.ToInt32(sdr["DCSLBS"]);
                        child.DCSLMBSL = Convert.ToInt32(sdr["DCSLMBSL"]);
                        child.DCSLYS = Convert.ToInt32(sdr["DCSLYS"]);
                        child.RQM = Convert.ToString(sdr["RQM"]);
                        child.GDSL = Convert.ToDecimal(sdr["GDSL"]);
                        child.ZFDCLB = Convert.ToInt32(sdr["ZFDCLB"]);
                        child.ZFDCLBNAME = Convert.ToString(sdr["ZFDCLBNAME"]);
                        child.KCDDGC = Convert.ToString(sdr["KCDDGC"]);
                        child.KCDD = Convert.ToString(sdr["KCDD"]);
                        child.KCDDNAME = Convert.ToString(sdr["KCDDNAME"]);
                        child.CGBILL = Convert.ToString(sdr["CGBILL"]);
                        child.CGBILLMX = Convert.ToString(sdr["CGBILLMX"]);
                        child.WLPZBH = Convert.ToString(sdr["WLPZBH"]);
                        child.WLPZND = Convert.ToString(sdr["WLPZND"]);
                        child.WLPZH = Convert.ToString(sdr["WLPZH"]);
                        child.CFTS = Convert.ToInt32(sdr["CFTS"]);
                        child.XDGX = Convert.ToInt32(sdr["XDGX"]);
                        child.XDGXNAME = Convert.ToString(sdr["XDGXNAME"]);
                        child.WLPZHXMH = Convert.ToString(sdr["WLPZHXMH"]);
                        child.VDATU = Convert.ToString(sdr["VDATU"]);
                        child.WLGROUP = Convert.ToString(sdr["WLGROUP"]);
                        child.WLGROUPNAME = Convert.ToString(sdr["WLGROUPNAME"]);
                        child.SCDATEP = Convert.ToString(sdr["SCDATEP"]);
                        if (LB == 1)
                        {
                            child.WLLBPX = 0;
                            child.LOTNO = Convert.ToString(sdr["LOTNO"]);
                        }
                        else
                        {
                            child.WLLBPX = Convert.ToInt32(sdr["WLLBPX"]);
                            child.LOTNO = "";
                        }
                        child.MID = Convert.ToString(sdr["MID"]);
                        child.JZ = Convert.ToDecimal(sdr["JZ"]);
                        child.CPTYPE = Convert.ToInt32(sdr["CPTYPE"]);
                        child.CPTYPENAME = Convert.ToString(sdr["CPTYPENAME"]);
                        child.WQH = Convert.ToString(sdr["WQH"]);
                        child.MFQCOLOR = Convert.ToInt32(sdr["MFQCOLOR"]);
                        child.MFQCOLORNAME = Convert.ToString(sdr["MFQCOLORNAME"]);
                        child.MOULD = Convert.ToString(sdr["MOULD"]);
                        child.RESDUESL = Convert.ToDecimal(sdr["RESDUESL"]);
                        child.CLPBDM = Convert.ToString(sdr["CLPBDM"]);
                        child.GLTMCOUNT = Convert.ToInt32(sdr["GLTMCOUNT"]);
                        child_MES_TM_TMINFO_LIST.Add(child);
                        child_MES_RETURN.TYPE = "S";
                        child_MES_RETURN.MESSAGE = "";
                    }
                }
                if (child_MES_RETURN.TYPE == "S")
                {

                }
                else
                {
                    child_MES_RETURN.TYPE = "E";
                    child_MES_RETURN.MESSAGE = "未查询到条码信息！";
                }
                rst.MES_TM_TMINFO_LIST = child_MES_TM_TMINFO_LIST;
                rst.MES_RETURN = child_MES_RETURN;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "TM_TMINFO_SELECT_TL_LAST");
            }
            return rst;
        }
        public MES_RETURN INSERT_FB(MES_TM_TMINFO model)
        {
            if (model.KSTIME == "")
            {
                model.KSTIME = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            if (model.JSTIME == "")
            {
                model.JSTIME = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            MES_RETURN mr = new MES_RETURN();
            try
            {
                DateTime dtime = Convert.ToDateTime(model.KSTIME);
                dtime = Convert.ToDateTime(model.JSTIME);
            }
            catch
            {
                mr.TYPE = "E";
                mr.MESSAGE = "转换日期格式出错！";
                return mr;
            }

            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@TM",model.TM),
                                       new SqlParameter("@TMLB",model.TMLB),
                                       new SqlParameter("@TMSX",model.TMSX),
                                       new SqlParameter("@SCDATE",model.SCDATE),
                                       new SqlParameter("@BC",model.BC),
                                       new SqlParameter("@RWBH",model.RWBH),
                                       new SqlParameter("@PC",model.PC),
                                       new SqlParameter("@JLR",model.JLR),
                                       new SqlParameter("@CLCJ",model.CLCJ),
                                       new SqlParameter("@GYLX",model.GYLX),
                                       new SqlParameter("@GYS",model.GYS),
                                       new SqlParameter("@GYSMS",model.GYSMS),
                                       new SqlParameter("@GYSPC",model.GYSPC),
                                       new SqlParameter("@CPZT",model.CPZT),
                                       new SqlParameter("@CPZTNAME",model.CPZTNAME),
                                       new SqlParameter("@SL",model.SL),
                                       new SqlParameter("@KSTIME",model.KSTIME),
                                       new SqlParameter("@JSTIME",model.JSTIME),
                                       new SqlParameter("@XFWLH",model.XFWLH),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@SBZ",model.SBZ),
                                       new SqlParameter("@SIZE",model.SIZE),
                                       new SqlParameter("@SYSCX",model.SYSCX),
                                       new SqlParameter("@SYCPGG",model.SYCPGG),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@SBHMS",model.SBHMS),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@WLMS",model.WLMS),
                                       new SqlParameter("@WLLB",model.WLLB),
                                       new SqlParameter("@WLLBNAME",model.WLLBNAME),
                                       new SqlParameter("@DCDJ",model.DCDJ),
                                       new SqlParameter("@DCDJMS",model.DCDJMS),
                                       new SqlParameter("@DCXH",model.DCXH),
                                       new SqlParameter("@DCXHMS",model.DCXHMS),
                                       new SqlParameter("@PFDH",model.PFDH),
                                       new SqlParameter("@PLDH",model.PLDH),
                                       new SqlParameter("@TH",model.TH),
                                       new SqlParameter("@WLGROUP",model.WLGROUP),
                                       new SqlParameter("@THGG",model.THGG),
                                       new SqlParameter("@ERPNO",model.ERPNO),
                                       new SqlParameter("@UNITSID",model.UNITSID),
                                       new SqlParameter("@UNITSNAME",model.UNITSNAME),
                                       new SqlParameter("@DCSLBS",model.DCSLBS),
                                       new SqlParameter("@DCSLMBSL",model.DCSLMBSL),
                                       new SqlParameter("@DCSLYS",model.DCSLYS),
                                       new SqlParameter("@SBCD",model.SBCD),
                                       new SqlParameter("@RQM",model.RQM),
                                       new SqlParameter("@TPM",model.TPM),
                                       new SqlParameter("@ZFDCLB",model.ZFDCLB),
                                       new SqlParameter("@KCDDGC",model.KCDDGC),
                                       new SqlParameter("@KCDD",model.KCDD),
                                       new SqlParameter("@KCDDNAME",model.KCDDNAME),
                                       new SqlParameter("@CGBILL",model.CGBILL),
                                       new SqlParameter("@CGBILLMX",model.CGBILLMX),
                                       new SqlParameter("@NOBILL",model.NOBILL),
                                       new SqlParameter("@NOBILLMX",model.NOBILLMX),
                                       new SqlParameter("@CFTS",model.CFTS),
                                       new SqlParameter("@XDGX",model.XDGX),
                                       new SqlParameter("@MAC",model.MAC),
                                       new SqlParameter("@MID",model.MID),
                                       new SqlParameter("@JZ",model.JZ),
                                       new SqlParameter("@CPTYPE",model.CPTYPE),
                                       new SqlParameter("@WQH",model.WQH),
                                       new SqlParameter("@MFQCOLOR",model.MFQCOLOR),
                                       new SqlParameter("@GLTMCOUNT",model.GLTMCOUNT)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT_FB, parms))
                {
                    while (sdr.Read())
                    {
                        mr.TYPE = Convert.ToString(sdr["TYPE"]);
                        mr.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                        mr.GC = Convert.ToString(sdr["GC"]);
                        mr.TM = Convert.ToString(sdr["TM"]);
                    }
                }
                //mr.TYPE = "S";
                //mr.MESSAGE = "";
            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "TM_TMINFO_INSERT");
            }
            return mr;
        }

        public SELECT_MES_TM_TMINFO_BYTM SELECT_TL_LAST(string RWBH)
        {
            SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
            List<MES_TM_TMINFO_LIST> child_MES_TM_TMINFO_LIST = new List<MES_TM_TMINFO_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RWBH",RWBH),
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_TL_LAST, parms))
                {
                    while (sdr.Read())
                    {
                        MES_TM_TMINFO_LIST child = new MES_TM_TMINFO_LIST();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.GCDYMS = Convert.ToString(sdr["GCDYMS"]);
                        child.TM = Convert.ToString(sdr["TM"]);
                        child.TMLB = Convert.ToInt32(sdr["TMLB"]);
                        child.TMSX = Convert.ToInt32(sdr["TMSX"]);
                        child.SCDATE = Convert.ToString(sdr["SCDATE"]);
                        child.BC = Convert.ToInt32(sdr["BC"]);
                        child.BCMS = Convert.ToString(sdr["BCMS"]);
                        child.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        child.GZZXMS = Convert.ToString(sdr["GZZXMS"]);
                        child.SBBH = Convert.ToString(sdr["SBBH"]);
                        child.SBHMS = Convert.ToString(sdr["SBHMS"]);
                        child.RWBH = Convert.ToString(sdr["RWBH"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.WLMS = Convert.ToString(sdr["WLMS"]);
                        child.PC = Convert.ToString(sdr["PC"]);
                        child.CLCJ = Convert.ToString(sdr["CLCJ"]);
                        child.GYLX = Convert.ToString(sdr["GYLX"]);
                        child.GYS = Convert.ToString(sdr["GYS"]);
                        child.GYSMS = Convert.ToString(sdr["GYSMS"]);
                        child.GYSPC = Convert.ToString(sdr["GYSPC"]);
                        child.CPZT = Convert.ToInt32(sdr["CPZT"]);
                        child.CPZTNAME = Convert.ToString(sdr["CPZTNAME"]);
                        child.PFDH = Convert.ToString(sdr["PFDH"]);
                        child.PLDH = Convert.ToString(sdr["PLDH"]);
                        child.TH = Convert.ToInt32(sdr["TH"]);
                        child.SL = Convert.ToDecimal(sdr["SL"]);
                        child.KSTIME = Convert.ToDateTime(sdr["KSTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.JSTIME = Convert.ToDateTime(sdr["JSTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.XFWLH = Convert.ToString(sdr["XFWLH"]);
                        child.DCDJ = Convert.ToInt32(sdr["DCDJ"]);
                        child.DCDJMS = Convert.ToString(sdr["DCDJMS"]);
                        child.DCXH = Convert.ToInt32(sdr["DCXH"]);
                        child.DCXHMS = Convert.ToString(sdr["DCXHMS"]);
                        child.TPM = Convert.ToString(sdr["TPM"]);
                        child.SBCD = Convert.ToInt32(sdr["SBCD"]);
                        child.SBCDMS = Convert.ToString(sdr["SBCDMS"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.JLR = Convert.ToInt32(sdr["JLR"]);
                        child.JLRMS = Convert.ToString(sdr["JLRMS"]);
                        child.JLTIME = Convert.ToString(sdr["JLTIME"]);
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.NOBILL = Convert.ToString(sdr["NOBILL"]);
                        child.NOBILLMX = Convert.ToString(sdr["NOBILLMX"]);
                        child.WLLB = Convert.ToInt32(sdr["WLLB"]);
                        child.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        child.UNITSNAME = Convert.ToString(sdr["UNITSNAME"]);
                        child.ERPNO = Convert.ToString(sdr["ERPNO"]);
                        child.SBZ = Convert.ToString(sdr["SBZ"]);
                        child.SIZE = Convert.ToInt32(sdr["SIZE"]);
                        child.SIZENAME = Convert.ToString(sdr["SIZENAME"]);
                        child.SYSCX = Convert.ToString(sdr["SYSCX"]);
                        child.SYCPGG = Convert.ToString(sdr["SYCPGG"]);
                        child.THGG = Convert.ToString(sdr["THGG"]);
                        child.TLTMID = Convert.ToInt32(sdr["TLTMID"]);
                        child.DCSLBS = Convert.ToInt32(sdr["DCSLBS"]);
                        child.DCSLMBSL = Convert.ToInt32(sdr["DCSLMBSL"]);
                        child.DCSLYS = Convert.ToInt32(sdr["DCSLYS"]);
                        child.RQM = Convert.ToString(sdr["RQM"]);
                        child.ZFDCLB = Convert.ToInt32(sdr["ZFDCLB"]);
                        child.ZFDCLBNAME = Convert.ToString(sdr["ZFDCLBNAME"]);
                        child.KCDDGC = Convert.ToString(sdr["KCDDGC"]);
                        child.KCDD = Convert.ToString(sdr["KCDD"]);
                        child.KCDDNAME = Convert.ToString(sdr["KCDDNAME"]);
                        child.CGBILL = Convert.ToString(sdr["CGBILL"]);
                        child.CGBILLMX = Convert.ToString(sdr["CGBILLMX"]);
                        child.CFTS = Convert.ToInt32(sdr["CFTS"]);
                        child.XDGX = Convert.ToInt32(sdr["XDGX"]);
                        child.XDGXNAME = Convert.ToString(sdr["XDGXNAME"]);
                        child.VDATU = Convert.ToString(sdr["VDATU"]);
                        child.SCDATEP = Convert.ToString(sdr["SCDATEP"]);
                        child.MID = Convert.ToString(sdr["MID"]);
                        child.JZ = Convert.ToDecimal(sdr["JZ"]);
                        child.CPTYPE = Convert.ToInt32(sdr["CPTYPE"]);
                        child.CPTYPENAME = Convert.ToString(sdr["CPTYPENAME"]);
                        child.WQH = Convert.ToString(sdr["WQH"]);
                        child.MFQCOLOR = Convert.ToInt32(sdr["MFQCOLOR"]);
                        child.MFQCOLORNAME = Convert.ToString(sdr["MFQCOLORNAME"]);
                        child.MOULD = Convert.ToString(sdr["MOULD"]);
                        child.RESDUESL = Convert.ToDecimal(sdr["RESDUESL"]);
                        child.CLPBDM = Convert.ToString(sdr["CLPBDM"]);
                        child.GLTMCOUNT = Convert.ToInt32(sdr["GLTMCOUNT"]);
                        child_MES_TM_TMINFO_LIST.Add(child);
                    }
                }
                rst.MES_TM_TMINFO_LIST = child_MES_TM_TMINFO_LIST;
                if (rst.MES_TM_TMINFO_LIST.Count == 0)
                {
                    child_MES_RETURN.TYPE = "E";
                    child_MES_RETURN.MESSAGE = "没有历史投料记录！";
                }
                else
                {
                    child_MES_RETURN.TYPE = "S";
                    child_MES_RETURN.MESSAGE = "";
                }
                rst.MES_RETURN = child_MES_RETURN;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "TM_TMINFO_SELECT_TL_LAST");
            }
            return rst;
        }


        public SELECT_MES_TM_TMINFO_BYTM SELECT(MES_TM_TMINFO model, int CXLB)
        {
            SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
            List<MES_TM_TMINFO_LIST> child_MES_TM_TMINFO_LIST = new List<MES_TM_TMINFO_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@CXLB",CXLB),
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@TM",model.TM),
                                       new SqlParameter("@TMLB",model.TMLB),
                                       new SqlParameter("@TMSX",model.TMSX),
                                       new SqlParameter("@RWBH",model.RWBH),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@SBHMS",model.SBHMS),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@NOBILL",model.NOBILL),
                                       new SqlParameter("@NOBILLMX",model.NOBILLMX),
                                       new SqlParameter("@SCDATE",model.SCDATE),
                                       new SqlParameter("@SCDATES",model.SCDATES),
                                       new SqlParameter("@SCDATEE",model.SCDATEE),
                                       new SqlParameter("@TH",model.TH),
                                       new SqlParameter("@JLKSTIME",model.JLKSTIME),
                                       new SqlParameter("@JLJSTIME",model.JLJSTIME),
                                       new SqlParameter("@BC",model.BC),
                                       new SqlParameter("@PC",model.PC),
                                       new SqlParameter("@CLCJ",model.CLCJ),
                                       new SqlParameter("@GYLX",model.GYLX),
                                       new SqlParameter("@GYS",model.GYS),
                                       new SqlParameter("@GYSMS",model.GYSMS),
                                       new SqlParameter("@GYSPC",model.GYSPC),
                                       new SqlParameter("@CPZT",model.CPZT),
                                       new SqlParameter("@PFDH",model.PFDH),
                                       new SqlParameter("@PLDH",model.PLDH),
                                       new SqlParameter("@XFWLH",model.XFWLH),
                                       new SqlParameter("@DCDJ",model.DCDJ),
                                       new SqlParameter("@DCXH",model.DCXH),
                                       new SqlParameter("@TPM",model.TPM),
                                       new SqlParameter("@SBCD",model.SBCD),
                                       new SqlParameter("@WLLB",model.WLLB),
                                       new SqlParameter("@WLGROUP",model.WLGROUP),
                                       new SqlParameter("@SIZE",model.SIZE),
                                       new SqlParameter("@ERPNO",model.ERPNO),
                                       new SqlParameter("@RQM",model.RQM),
                                       new SqlParameter("@ZFDCLB",model.ZFDCLB),
                                       new SqlParameter("@KCDD",model.KCDD),
                                       new SqlParameter("@CGBILL",model.CGBILL),
                                       new SqlParameter("@MAC",model.MAC),
                                       new SqlParameter("@MOULD",model.MOULD),
                                       new SqlParameter("@CLPBDM",model.CLPBDM)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_TM_TMINFO_LIST child = new MES_TM_TMINFO_LIST();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.GCDYMS = Convert.ToString(sdr["GCDYMS"]);
                        child.TM = Convert.ToString(sdr["TM"]);
                        child.TMLB = Convert.ToInt32(sdr["TMLB"]);
                        child.TMSX = Convert.ToInt32(sdr["TMSX"]);
                        child.SCDATE = Convert.ToString(sdr["SCDATE"]);
                        child.BC = Convert.ToInt32(sdr["BC"]);
                        child.BCMS = Convert.ToString(sdr["BCMS"]);
                        child.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        child.GZZXMS = Convert.ToString(sdr["GZZXMS"]);
                        child.SBBH = Convert.ToString(sdr["SBBH"]);
                        child.SBHMS = Convert.ToString(sdr["SBHMS"]);
                        child.RWBH = Convert.ToString(sdr["RWBH"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.WLMS = Convert.ToString(sdr["WLMS"]);
                        child.PC = Convert.ToString(sdr["PC"]);
                        child.CLCJ = Convert.ToString(sdr["CLCJ"]);
                        child.GYLX = Convert.ToString(sdr["GYLX"]);
                        child.GYS = Convert.ToString(sdr["GYS"]);
                        child.GYSMS = Convert.ToString(sdr["GYSMS"]);
                        child.GYSPC = Convert.ToString(sdr["GYSPC"]);
                        child.CPZT = Convert.ToInt32(sdr["CPZT"]);
                        child.CPZTNAME = Convert.ToString(sdr["CPZTNAME"]);
                        child.PFDH = Convert.ToString(sdr["PFDH"]);
                        child.PLDH = Convert.ToString(sdr["PLDH"]);
                        child.TH = Convert.ToInt32(sdr["TH"]);
                        child.SL = Convert.ToDecimal(sdr["SL"]);
                        child.KSTIME = Convert.ToDateTime(sdr["KSTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.JSTIME = Convert.ToDateTime(sdr["JSTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.XFWLH = Convert.ToString(sdr["XFWLH"]);
                        child.XFCDNAME = Convert.ToString(sdr["XFCDNAME"]);
                        child.DCDJ = Convert.ToInt32(sdr["DCDJ"]);
                        child.DCDJMS = Convert.ToString(sdr["DCDJMS"]);
                        child.DCXH = Convert.ToInt32(sdr["DCXH"]);
                        child.DCXHMS = Convert.ToString(sdr["DCXHMS"]);
                        child.TPM = Convert.ToString(sdr["TPM"]);
                        child.SBCD = Convert.ToInt32(sdr["SBCD"]);
                        child.SBCDMS = Convert.ToString(sdr["SBCDMS"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.JLR = Convert.ToInt32(sdr["JLR"]);
                        child.JLRMS = Convert.ToString(sdr["JLRMS"]);
                        child.JLTIME = Convert.ToDateTime(sdr["JLTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.NOBILL = Convert.ToString(sdr["NOBILL"]);
                        child.NOBILLMX = Convert.ToString(sdr["NOBILLMX"]);
                        child.WLLB = Convert.ToInt32(sdr["WLLB"]);
                        child.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        child.UNITSNAME = Convert.ToString(sdr["UNITSNAME"]);
                        child.ERPNO = Convert.ToString(sdr["ERPNO"]);
                        child.SBZ = Convert.ToString(sdr["SBZ"]);
                        child.SIZE = Convert.ToInt32(sdr["SIZE"]);
                        child.SIZENAME = Convert.ToString(sdr["SIZENAME"]);
                        child.SYSCX = Convert.ToString(sdr["SYSCX"]);
                        child.SYCPGG = Convert.ToString(sdr["SYCPGG"]);
                        child.THGG = Convert.ToString(sdr["THGG"]);
                        child.DCSLBS = Convert.ToInt32(sdr["DCSLBS"]);
                        child.DCSLMBSL = Convert.ToInt32(sdr["DCSLMBSL"]);
                        child.DCSLYS = Convert.ToInt32(sdr["DCSLYS"]);
                        child.RQM = Convert.ToString(sdr["RQM"]);
                        child.GDSL = Convert.ToDecimal(sdr["GDSL"]);
                        child.ZFDCLB = Convert.ToInt32(sdr["ZFDCLB"]);
                        child.ZFDCLBNAME = Convert.ToString(sdr["ZFDCLBNAME"]);
                        child.KCDDGC = Convert.ToString(sdr["KCDDGC"]);
                        child.KCDD = Convert.ToString(sdr["KCDD"]);
                        child.KCDDNAME = Convert.ToString(sdr["KCDDNAME"]);
                        child.CGBILL = Convert.ToString(sdr["CGBILL"]);
                        child.CGBILLMX = Convert.ToString(sdr["CGBILLMX"]);
                        child.CFTS = Convert.ToInt32(sdr["CFTS"]);
                        child.WLGROUP = Convert.ToString(sdr["WLGROUP"]);
                        child.WLGROUPNAME = Convert.ToString(sdr["WLGROUPNAME"]);
                        child.XDGX = Convert.ToInt32(sdr["XDGX"]);
                        child.XDGXNAME = Convert.ToString(sdr["XDGXNAME"]);
                        child.VDATU = Convert.ToString(sdr["VDATU"]);
                        child.SCDATEP = Convert.ToString(sdr["SCDATEP"]);
                        if (child.KSTIME == "1900-01-01 00:00:00")
                        {
                            child.KSTIME = "";
                        }
                        if (child.JSTIME == "1900-01-01 00:00:00")
                        {
                            child.JSTIME = "";
                        }
                        child.MID = Convert.ToString(sdr["MID"]);
                        child.JZ = Convert.ToDecimal(sdr["JZ"]);
                        child.CPTYPE = Convert.ToInt32(sdr["CPTYPE"]);
                        child.CPTYPENAME = Convert.ToString(sdr["CPTYPENAME"]);
                        child.WQH = Convert.ToString(sdr["WQH"]);
                        child.MFQCOLOR = Convert.ToInt32(sdr["MFQCOLOR"]);
                        child.MFQCOLORNAME = Convert.ToString(sdr["MFQCOLORNAME"]);
                        child.MOULD = Convert.ToString(sdr["MOULD"]);
                        child.RESDUESL = Convert.ToDecimal(sdr["RESDUESL"]);
                        child.CLPBDM = Convert.ToString(sdr["CLPBDM"]);
                        child.GLTMCOUNT = Convert.ToInt32(sdr["GLTMCOUNT"]);
                        child_MES_TM_TMINFO_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
                rst.MES_TM_TMINFO_LIST = child_MES_TM_TMINFO_LIST;
                rst.MES_RETURN = child_MES_RETURN;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_PFDH_SELECT");
            }
            return rst;
        }
        public MES_TM_TMINFO_SELECT_TL_GL_CC SELECT_TL_GL_CC(MES_TM_TMINFO model)
        {
            MES_TM_TMINFO_SELECT_TL_GL_CC rst = new MES_TM_TMINFO_SELECT_TL_GL_CC();
            List<MES_TM_TMINFO_SELECT_TL_GL_CC_OUT> child_MES_TM_TMINFO_SELECT_TL_GL_CC_OUT = new List<MES_TM_TMINFO_SELECT_TL_GL_CC_OUT>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@TM",model.TM),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@NOBILL",model.NOBILL),
                                       new SqlParameter("@NOBILLMX",model.NOBILLMX),
                                       new SqlParameter("@SCDATES",model.SCDATES),
                                       new SqlParameter("@SCDATEE",model.SCDATEE),
                                       new SqlParameter("@PC",model.PC),
                                       new SqlParameter("@ERPNO",model.ERPNO),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_TL_GL_CC, parms))
                {
                    while (sdr.Read())
                    {
                        MES_TM_TMINFO_SELECT_TL_GL_CC_OUT child = new MES_TM_TMINFO_SELECT_TL_GL_CC_OUT();
                        child.TM = Convert.ToString(sdr["TM"]);
                        child.SBHMS = Convert.ToString(sdr["SBHMS"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.WLMS = Convert.ToString(sdr["WLMS"]);
                        child.TH = Convert.ToInt32(sdr["TH"]);
                        child.SL = Convert.ToDecimal(sdr["SL"]);
                        child.SBCDMS = Convert.ToString(sdr["SBCDMS"]);
                        child.NOBILL = Convert.ToString(sdr["NOBILL"]);
                        child.NOBILLMX = Convert.ToString(sdr["NOBILLMX"]);
                        child.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        child.ERPNO = Convert.ToString(sdr["ERPNO"]);
                        child.RQM = Convert.ToString(sdr["RQM"]);
                        child.GDSL = Convert.ToDecimal(sdr["GDSL"]);
                        child.XDGXNAME = Convert.ToString(sdr["XDGXNAME"]);
                        child.TLTM = Convert.ToString(sdr["TLTM"]);
                        child.TLWLLBNAME = Convert.ToString(sdr["TLWLLBNAME"]);
                        child.TLWLH = Convert.ToString(sdr["TLWLH"]);
                        child.TLWLMS = Convert.ToString(sdr["TLWLMS"]);
                        child.TLTH = Convert.ToInt32(sdr["TLTH"]);
                        child.TLGZZXMS = Convert.ToString(sdr["TLGZZXMS"]);
                        child.TLSL = Convert.ToDecimal(sdr["TLSL"]);
                        child.SCDATE = Convert.ToString(sdr["SCDATE"]);
                        child.TLSCDATE = Convert.ToString(sdr["TLSCDATE"]);
                        child.TLDCDJMS = Convert.ToString(sdr["TLDCDJMS"]);
                        child_MES_TM_TMINFO_SELECT_TL_GL_CC_OUT.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
                rst.MES_TM_TMINFO_SELECT_TL_GL_CC_OUT = child_MES_TM_TMINFO_SELECT_TL_GL_CC_OUT;
                rst.MES_RETURN = child_MES_RETURN;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_PFDH_SELECT_TL_GL_CC");
            }
            return rst;
        }
        public SELECT_MES_TM_TMINFO_BYTM SELECT_ALL(MES_TM_TMINFO model, int CXLB)
        {
            SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
            List<MES_TM_TMINFO_LIST> child_MES_TM_TMINFO_LIST = new List<MES_TM_TMINFO_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@CXLB",CXLB),
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@TM",model.TM),
                                       new SqlParameter("@TMLB",model.TMLB),
                                       new SqlParameter("@TMSX",model.TMSX),
                                       new SqlParameter("@RWBH",model.RWBH),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@SBHMS",model.SBHMS),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@NOBILL",model.NOBILL),
                                       new SqlParameter("@NOBILLMX",model.NOBILLMX),
                                       new SqlParameter("@SCDATE",model.SCDATE),
                                       new SqlParameter("@SCDATES",model.SCDATES),
                                       new SqlParameter("@SCDATEE",model.SCDATEE),
                                       new SqlParameter("@TH",model.TH),
                                       new SqlParameter("@JLKSTIME",model.JLKSTIME),
                                       new SqlParameter("@JLJSTIME",model.JLJSTIME),
                                       new SqlParameter("@BC",model.BC),
                                       new SqlParameter("@PC",model.PC),
                                       new SqlParameter("@CLCJ",model.CLCJ),
                                       new SqlParameter("@GYLX",model.GYLX),
                                       new SqlParameter("@GYS",model.GYS),
                                       new SqlParameter("@GYSMS",model.GYSMS),
                                       new SqlParameter("@GYSPC",model.GYSPC),
                                       new SqlParameter("@CPZT",model.CPZT),
                                       new SqlParameter("@PFDH",model.PFDH),
                                       new SqlParameter("@PLDH",model.PLDH),
                                       new SqlParameter("@XFWLH",model.XFWLH),
                                       new SqlParameter("@DCDJ",model.DCDJ),
                                       new SqlParameter("@DCXH",model.DCXH),
                                       new SqlParameter("@TPM",model.TPM),
                                       new SqlParameter("@SBCD",model.SBCD),
                                       new SqlParameter("@WLLB",model.WLLB),
                                       new SqlParameter("@WLGROUP",model.WLGROUP),
                                       new SqlParameter("@SIZE",model.SIZE),
                                       new SqlParameter("@ERPNO",model.ERPNO),
                                       new SqlParameter("@RQM",model.RQM),
                                       new SqlParameter("@ZFDCLB",model.ZFDCLB),
                                       new SqlParameter("@KCDD",model.KCDD),
                                       new SqlParameter("@CGBILL",model.CGBILL),
                                       new SqlParameter("@MAC",model.MAC)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_ALL, parms))
                {
                    while (sdr.Read())
                    {
                        MES_TM_TMINFO_LIST child = new MES_TM_TMINFO_LIST();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.GCDYMS = Convert.ToString(sdr["GCDYMS"]);
                        child.TM = Convert.ToString(sdr["TM"]);
                        child.TMLB = Convert.ToInt32(sdr["TMLB"]);
                        child.TMSX = Convert.ToInt32(sdr["TMSX"]);
                        child.SCDATE = Convert.ToString(sdr["SCDATE"]);
                        child.BC = Convert.ToInt32(sdr["BC"]);
                        child.BCMS = Convert.ToString(sdr["BCMS"]);
                        child.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        child.GZZXMS = Convert.ToString(sdr["GZZXMS"]);
                        child.SBBH = Convert.ToString(sdr["SBBH"]);
                        child.SBHMS = Convert.ToString(sdr["SBHMS"]);
                        child.RWBH = Convert.ToString(sdr["RWBH"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.WLMS = Convert.ToString(sdr["WLMS"]);
                        child.PC = Convert.ToString(sdr["PC"]);
                        child.CLCJ = Convert.ToString(sdr["CLCJ"]);
                        child.GYLX = Convert.ToString(sdr["GYLX"]);
                        child.GYS = Convert.ToString(sdr["GYS"]);
                        child.GYSMS = Convert.ToString(sdr["GYSMS"]);
                        child.GYSPC = Convert.ToString(sdr["GYSPC"]);
                        child.CPZT = Convert.ToInt32(sdr["CPZT"]);
                        child.CPZTNAME = Convert.ToString(sdr["CPZTNAME"]);
                        child.PFDH = Convert.ToString(sdr["PFDH"]);
                        child.PLDH = Convert.ToString(sdr["PLDH"]);
                        child.TH = Convert.ToInt32(sdr["TH"]);
                        child.SL = Convert.ToDecimal(sdr["SL"]);
                        child.KSTIME = Convert.ToDateTime(sdr["KSTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.JSTIME = Convert.ToDateTime(sdr["JSTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.XFWLH = Convert.ToString(sdr["XFWLH"]);
                        child.XFCDNAME = Convert.ToString(sdr["XFCDNAME"]);
                        child.DCDJ = Convert.ToInt32(sdr["DCDJ"]);
                        child.DCDJMS = Convert.ToString(sdr["DCDJMS"]);
                        child.DCXH = Convert.ToInt32(sdr["DCXH"]);
                        child.DCXHMS = Convert.ToString(sdr["DCXHMS"]);
                        child.TPM = Convert.ToString(sdr["TPM"]);
                        child.SBCD = Convert.ToInt32(sdr["SBCD"]);
                        child.SBCDMS = Convert.ToString(sdr["SBCDMS"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.JLR = Convert.ToInt32(sdr["JLR"]);
                        child.JLRMS = Convert.ToString(sdr["JLRMS"]);
                        child.JLTIME = Convert.ToDateTime(sdr["JLTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.NOBILL = Convert.ToString(sdr["NOBILL"]);
                        child.NOBILLMX = Convert.ToString(sdr["NOBILLMX"]);
                        child.WLLB = Convert.ToInt32(sdr["WLLB"]);
                        child.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        child.UNITSNAME = Convert.ToString(sdr["UNITSNAME"]);
                        child.ERPNO = Convert.ToString(sdr["ERPNO"]);
                        child.SBZ = Convert.ToString(sdr["SBZ"]);
                        child.SIZE = Convert.ToInt32(sdr["SIZE"]);
                        child.SIZENAME = Convert.ToString(sdr["SIZENAME"]);
                        child.SYSCX = Convert.ToString(sdr["SYSCX"]);
                        child.SYCPGG = Convert.ToString(sdr["SYCPGG"]);
                        child.THGG = Convert.ToString(sdr["THGG"]);
                        child.DCSLBS = Convert.ToInt32(sdr["DCSLBS"]);
                        child.DCSLMBSL = Convert.ToInt32(sdr["DCSLMBSL"]);
                        child.DCSLYS = Convert.ToInt32(sdr["DCSLYS"]);
                        child.RQM = Convert.ToString(sdr["RQM"]);
                        child.GDSL = Convert.ToDecimal(sdr["GDSL"]);
                        child.ZFDCLB = Convert.ToInt32(sdr["ZFDCLB"]);
                        child.ZFDCLBNAME = Convert.ToString(sdr["ZFDCLBNAME"]);
                        child.KCDDGC = Convert.ToString(sdr["KCDDGC"]);
                        child.KCDD = Convert.ToString(sdr["KCDD"]);
                        child.KCDDNAME = Convert.ToString(sdr["KCDDNAME"]);
                        child.CGBILL = Convert.ToString(sdr["CGBILL"]);
                        child.CGBILLMX = Convert.ToString(sdr["CGBILLMX"]);
                        child.CFTS = Convert.ToInt32(sdr["CFTS"]);
                        child.WLGROUP = Convert.ToString(sdr["WLGROUP"]);
                        child.WLGROUPNAME = Convert.ToString(sdr["WLGROUPNAME"]);
                        child.XDGX = Convert.ToInt32(sdr["XDGX"]);
                        child.XDGXNAME = Convert.ToString(sdr["XDGXNAME"]);
                        child.VDATU = Convert.ToString(sdr["VDATU"]);
                        child.SCDATEP = Convert.ToString(sdr["SCDATEP"]);
                        if (child.KSTIME == "1900-01-01 00:00:00")
                        {
                            child.KSTIME = "";
                        }
                        if (child.JSTIME == "1900-01-01 00:00:00")
                        {
                            child.JSTIME = "";
                        }
                        child.MID = Convert.ToString(sdr["MID"]);
                        child.JZ = Convert.ToDecimal(sdr["JZ"]);
                        child.CPTYPE = Convert.ToInt32(sdr["CPTYPE"]);
                        child.CPTYPENAME = Convert.ToString(sdr["CPTYPENAME"]);
                        child.WQH = Convert.ToString(sdr["WQH"]);
                        child.MFQCOLOR = Convert.ToInt32(sdr["MFQCOLOR"]);
                        child.MFQCOLORNAME = Convert.ToString(sdr["MFQCOLORNAME"]);
                        child.MOULD = Convert.ToString(sdr["MOULD"]);
                        child.RESDUESL = Convert.ToDecimal(sdr["RESDUESL"]);
                        child.CLPBDM = Convert.ToString(sdr["CLPBDM"]);
                        child.GLTMCOUNT = Convert.ToInt32(sdr["GLTMCOUNT"]);
                        child_MES_TM_TMINFO_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
                rst.MES_TM_TMINFO_LIST = child_MES_TM_TMINFO_LIST;
                rst.MES_RETURN = child_MES_RETURN;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_PFDH_SELECT");
            }
            return rst;
        }
        public MES_RETURN DELETE(string TM)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@TM",TM)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_DELETE_BYTM, parms))
                {
                }
                rst.TYPE = "S";
                rst.MESSAGE = "";
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "TM_TMINFO_DELETE");
            }
            return rst;
        }

        public MES_RETURN DELETE_LOG(MES_TM_TMINFO_DELETE_IN model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@TM",model.TM),
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@YGH",model.YGH),
                                       new SqlParameter("@YGNAME",model.YGNAME)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "TM_TMINFO_DELETE");
            }
            return rst;
        }

        public SELECT_MES_TM_TMINFO_BYTM SELECT_GLSELECT(DataTable dt)
        {
            SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
            List<MES_TM_TMINFO_LIST> child_MES_TM_TMINFO_LIST = new List<MES_TM_TMINFO_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@TM",dt)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_BY_TM_GLSELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_TM_TMINFO_LIST child = new MES_TM_TMINFO_LIST();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.GCDYMS = Convert.ToString(sdr["GCDYMS"]);
                        child.TM = Convert.ToString(sdr["TM"]);
                        child.TMLB = Convert.ToInt32(sdr["TMLB"]);
                        child.TMSX = Convert.ToInt32(sdr["TMSX"]);
                        child.SCDATE = Convert.ToString(sdr["SCDATE"]);
                        child.BC = Convert.ToInt32(sdr["BC"]);
                        child.BCMS = Convert.ToString(sdr["BCMS"]);
                        child.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        child.GZZXMS = Convert.ToString(sdr["GZZXMS"]);
                        child.SBBH = Convert.ToString(sdr["SBBH"]);
                        child.SBHMS = Convert.ToString(sdr["SBHMS"]);
                        child.RWBH = Convert.ToString(sdr["RWBH"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.WLMS = Convert.ToString(sdr["WLMS"]);
                        child.PC = Convert.ToString(sdr["PC"]);
                        child.CLCJ = Convert.ToString(sdr["CLCJ"]);
                        child.GYLX = Convert.ToString(sdr["GYLX"]);
                        child.GYS = Convert.ToString(sdr["GYS"]);
                        child.GYSMS = Convert.ToString(sdr["GYSMS"]);
                        child.GYSPC = Convert.ToString(sdr["GYSPC"]);
                        child.CPZT = Convert.ToInt32(sdr["CPZT"]);
                        child.CPZTNAME = Convert.ToString(sdr["CPZTNAME"]);
                        child.PFDH = Convert.ToString(sdr["PFDH"]);
                        child.PLDH = Convert.ToString(sdr["PLDH"]);
                        child.TH = Convert.ToInt32(sdr["TH"]);
                        child.SL = Convert.ToDecimal(sdr["SL"]);
                        child.KSTIME = Convert.ToDateTime(sdr["KSTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.JSTIME = Convert.ToDateTime(sdr["JSTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.XFWLH = Convert.ToString(sdr["XFWLH"]);
                        child.DCDJ = Convert.ToInt32(sdr["DCDJ"]);
                        child.DCDJMS = Convert.ToString(sdr["DCDJMS"]);
                        child.DCXH = Convert.ToInt32(sdr["DCXH"]);
                        child.DCXHMS = Convert.ToString(sdr["DCXHMS"]);
                        child.TPM = Convert.ToString(sdr["TPM"]);
                        child.SBCD = Convert.ToInt32(sdr["SBCD"]);
                        child.SBCDMS = Convert.ToString(sdr["SBCDMS"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.JLR = Convert.ToInt32(sdr["JLR"]);
                        child.JLRMS = Convert.ToString(sdr["JLRMS"]);
                        child.JLTIME = Convert.ToDateTime(sdr["JLTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.NOBILL = Convert.ToString(sdr["NOBILL"]);
                        child.NOBILLMX = Convert.ToString(sdr["NOBILLMX"]);
                        child.WLLB = Convert.ToInt32(sdr["WLLB"]);
                        child.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        child.UNITSNAME = Convert.ToString(sdr["UNITSNAME"]);
                        child.ERPNO = Convert.ToString(sdr["ERPNO"]);
                        child.SBZ = Convert.ToString(sdr["SBZ"]);
                        child.SIZE = Convert.ToInt32(sdr["SIZE"]);
                        child.SIZENAME = Convert.ToString(sdr["SIZENAME"]);
                        child.SYSCX = Convert.ToString(sdr["SYSCX"]);
                        child.SYCPGG = Convert.ToString(sdr["SYCPGG"]);
                        child.THGG = Convert.ToString(sdr["THGG"]);
                        child.DCSLBS = Convert.ToInt32(sdr["DCSLBS"]);
                        child.DCSLMBSL = Convert.ToInt32(sdr["DCSLMBSL"]);
                        child.DCSLYS = Convert.ToInt32(sdr["DCSLYS"]);
                        child.RQM = Convert.ToString(sdr["RQM"]);
                        child.ZFDCLB = Convert.ToInt32(sdr["ZFDCLB"]);
                        child.ZFDCLBNAME = Convert.ToString(sdr["ZFDCLBNAME"]);
                        child.KCDDGC = Convert.ToString(sdr["KCDDGC"]);
                        child.KCDD = Convert.ToString(sdr["KCDD"]);
                        child.KCDDNAME = Convert.ToString(sdr["KCDDNAME"]);
                        child.CGBILL = Convert.ToString(sdr["CGBILL"]);
                        child.CGBILLMX = Convert.ToString(sdr["CGBILLMX"]);
                        child.CFTS = Convert.ToInt32(sdr["CFTS"]);
                        child.XDGX = Convert.ToInt32(sdr["XDGX"]);
                        child.XDGXNAME = Convert.ToString(sdr["XDGXNAME"]);
                        child.VDATU = Convert.ToString(sdr["VDATU"]);
                        child.SCDATEP = Convert.ToString(sdr["SCDATEP"]);
                        if (child.KSTIME == "1900-01-01 00:00:00")
                        {
                            child.KSTIME = "";
                        }
                        if (child.JSTIME == "1900-01-01 00:00:00")
                        {
                            child.JSTIME = "";
                        }
                        child.MID = Convert.ToString(sdr["MID"]);
                        child.JZ = Convert.ToDecimal(sdr["JZ"]);
                        child.CPTYPE = Convert.ToInt32(sdr["CPTYPE"]);
                        child.CPTYPENAME = Convert.ToString(sdr["CPTYPENAME"]);
                        child.WQH = Convert.ToString(sdr["WQH"]);
                        child.MFQCOLOR = Convert.ToInt32(sdr["MFQCOLOR"]);
                        child.MFQCOLORNAME = Convert.ToString(sdr["MFQCOLORNAME"]);
                        child.MOULD = Convert.ToString(sdr["MOULD"]);
                        child.RESDUESL = Convert.ToDecimal(sdr["RESDUESL"]);
                        child.CLPBDM = Convert.ToString(sdr["CLPBDM"]);
                        child.GLTMCOUNT = Convert.ToInt32(sdr["GLTMCOUNT"]);
                        child_MES_TM_TMINFO_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "TM_TMINFO_SELECT_GLSELECT");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_TM_TMINFO_LIST = child_MES_TM_TMINFO_LIST;
            return rst;
        }

        public SELECT_MES_TM_TMINFO_BYTM SELECT_GLSELECT_ALL(DataTable dt)
        {
            SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
            List<MES_TM_TMINFO_LIST> child_MES_TM_TMINFO_LIST = new List<MES_TM_TMINFO_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@TM",dt)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_BY_TM_GLSELECT_ALL, parms))
                {
                    while (sdr.Read())
                    {
                        MES_TM_TMINFO_LIST child = new MES_TM_TMINFO_LIST();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.GCDYMS = Convert.ToString(sdr["GCDYMS"]);
                        child.TM = Convert.ToString(sdr["TM"]);
                        child.TMLB = Convert.ToInt32(sdr["TMLB"]);
                        child.TMSX = Convert.ToInt32(sdr["TMSX"]);
                        child.SCDATE = Convert.ToString(sdr["SCDATE"]);
                        child.BC = Convert.ToInt32(sdr["BC"]);
                        child.BCMS = Convert.ToString(sdr["BCMS"]);
                        child.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        child.GZZXMS = Convert.ToString(sdr["GZZXMS"]);
                        child.SBBH = Convert.ToString(sdr["SBBH"]);
                        child.SBHMS = Convert.ToString(sdr["SBHMS"]);
                        child.RWBH = Convert.ToString(sdr["RWBH"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.WLMS = Convert.ToString(sdr["WLMS"]);
                        child.PC = Convert.ToString(sdr["PC"]);
                        child.CLCJ = Convert.ToString(sdr["CLCJ"]);
                        child.GYLX = Convert.ToString(sdr["GYLX"]);
                        child.GYS = Convert.ToString(sdr["GYS"]);
                        child.GYSMS = Convert.ToString(sdr["GYSMS"]);
                        child.GYSPC = Convert.ToString(sdr["GYSPC"]);
                        child.CPZT = Convert.ToInt32(sdr["CPZT"]);
                        child.CPZTNAME = Convert.ToString(sdr["CPZTNAME"]);
                        child.PFDH = Convert.ToString(sdr["PFDH"]);
                        child.PLDH = Convert.ToString(sdr["PLDH"]);
                        child.TH = Convert.ToInt32(sdr["TH"]);
                        child.SL = Convert.ToDecimal(sdr["SL"]);
                        child.KSTIME = Convert.ToDateTime(sdr["KSTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.JSTIME = Convert.ToDateTime(sdr["JSTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.XFWLH = Convert.ToString(sdr["XFWLH"]);
                        child.DCDJ = Convert.ToInt32(sdr["DCDJ"]);
                        child.DCDJMS = Convert.ToString(sdr["DCDJMS"]);
                        child.DCXH = Convert.ToInt32(sdr["DCXH"]);
                        child.DCXHMS = Convert.ToString(sdr["DCXHMS"]);
                        child.TPM = Convert.ToString(sdr["TPM"]);
                        child.SBCD = Convert.ToInt32(sdr["SBCD"]);
                        child.SBCDMS = Convert.ToString(sdr["SBCDMS"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.JLR = Convert.ToInt32(sdr["JLR"]);
                        child.JLRMS = Convert.ToString(sdr["JLRMS"]);
                        child.JLTIME = Convert.ToDateTime(sdr["JLTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.NOBILL = Convert.ToString(sdr["NOBILL"]);
                        child.NOBILLMX = Convert.ToString(sdr["NOBILLMX"]);
                        child.WLLB = Convert.ToInt32(sdr["WLLB"]);
                        child.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        child.UNITSNAME = Convert.ToString(sdr["UNITSNAME"]);
                        child.ERPNO = Convert.ToString(sdr["ERPNO"]);
                        child.SBZ = Convert.ToString(sdr["SBZ"]);
                        child.SIZE = Convert.ToInt32(sdr["SIZE"]);
                        child.SIZENAME = Convert.ToString(sdr["SIZENAME"]);
                        child.SYSCX = Convert.ToString(sdr["SYSCX"]);
                        child.SYCPGG = Convert.ToString(sdr["SYCPGG"]);
                        child.THGG = Convert.ToString(sdr["THGG"]);
                        child.DCSLBS = Convert.ToInt32(sdr["DCSLBS"]);
                        child.DCSLMBSL = Convert.ToInt32(sdr["DCSLMBSL"]);
                        child.DCSLYS = Convert.ToInt32(sdr["DCSLYS"]);
                        child.RQM = Convert.ToString(sdr["RQM"]);
                        child.ZFDCLB = Convert.ToInt32(sdr["ZFDCLB"]);
                        child.ZFDCLBNAME = Convert.ToString(sdr["ZFDCLBNAME"]);
                        child.KCDDGC = Convert.ToString(sdr["KCDDGC"]);
                        child.KCDD = Convert.ToString(sdr["KCDD"]);
                        child.KCDDNAME = Convert.ToString(sdr["KCDDNAME"]);
                        child.CGBILL = Convert.ToString(sdr["CGBILL"]);
                        child.CGBILLMX = Convert.ToString(sdr["CGBILLMX"]);
                        child.CFTS = Convert.ToInt32(sdr["CFTS"]);
                        child.XDGX = Convert.ToInt32(sdr["XDGX"]);
                        child.XDGXNAME = Convert.ToString(sdr["XDGXNAME"]);
                        child.VDATU = Convert.ToString(sdr["VDATU"]);
                        child.SCDATEP = Convert.ToString(sdr["SCDATEP"]);
                        if (child.KSTIME == "1900-01-01 00:00:00")
                        {
                            child.KSTIME = "";
                        }
                        if (child.JSTIME == "1900-01-01 00:00:00")
                        {
                            child.JSTIME = "";
                        }
                        child.MID = Convert.ToString(sdr["MID"]);
                        child.JZ = Convert.ToDecimal(sdr["JZ"]);
                        child.CPTYPE = Convert.ToInt32(sdr["CPTYPE"]);
                        child.CPTYPENAME = Convert.ToString(sdr["CPTYPENAME"]);
                        child.WQH = Convert.ToString(sdr["WQH"]);
                        child.MFQCOLOR = Convert.ToInt32(sdr["MFQCOLOR"]);
                        child.MFQCOLORNAME = Convert.ToString(sdr["MFQCOLORNAME"]);
                        child.MOULD = Convert.ToString(sdr["MOULD"]);
                        child.RESDUESL = Convert.ToDecimal(sdr["RESDUESL"]);
                        child.CLPBDM = Convert.ToString(sdr["CLPBDM"]);
                        child.GLTMCOUNT = Convert.ToInt32(sdr["GLTMCOUNT"]);
                        child_MES_TM_TMINFO_LIST.Add(child);
                    }
                    sdr.NextResult();
                    while (sdr.Read())
                    {
                        MES_TM_TMINFO_LIST child = new MES_TM_TMINFO_LIST();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.GCDYMS = Convert.ToString(sdr["GCDYMS"]);
                        child.TMLB = Convert.ToInt32(sdr["TLID"]);
                        child.PC = Convert.ToString(sdr["TLPC"]);
                        child.KSTIME = Convert.ToDateTime(sdr["TLTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.JSTIME = Convert.ToDateTime(sdr["TLTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.JLR = Convert.ToInt32(sdr["CJR"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.WLMS = Convert.ToString(sdr["WLMS"]);
                        child_MES_TM_TMINFO_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "TM_TMINFO_SELECT_GLSELECT");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_TM_TMINFO_LIST = child_MES_TM_TMINFO_LIST;
            return rst;
        }
        public SELECT_MES_TM_TMINFO_BYTM SELECT_GLSELECT_ALL_ZS_TL(DataTable dt)
        {
            SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
            List<MES_TM_TMINFO_LIST> child_MES_TM_TMINFO_LIST = new List<MES_TM_TMINFO_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@TLIDLIST",dt)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_BY_TM_GLSELECT_ALL_ZS_TL, parms))
                {
                    while (sdr.Read())
                    {
                        MES_TM_TMINFO_LIST child = new MES_TM_TMINFO_LIST();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.GCDYMS = Convert.ToString(sdr["GCDYMS"]);
                        child.TM = Convert.ToString(sdr["TM"]);
                        child.TMLB = Convert.ToInt32(sdr["TMLB"]);
                        child.TMSX = Convert.ToInt32(sdr["TMSX"]);
                        child.SCDATE = Convert.ToString(sdr["SCDATE"]);
                        child.BC = Convert.ToInt32(sdr["BC"]);
                        child.BCMS = Convert.ToString(sdr["BCMS"]);
                        child.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        child.GZZXMS = Convert.ToString(sdr["GZZXMS"]);
                        child.SBBH = Convert.ToString(sdr["SBBH"]);
                        child.SBHMS = Convert.ToString(sdr["SBHMS"]);
                        child.RWBH = Convert.ToString(sdr["RWBH"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.WLMS = Convert.ToString(sdr["WLMS"]);
                        child.PC = Convert.ToString(sdr["PC"]);
                        child.CLCJ = Convert.ToString(sdr["CLCJ"]);
                        child.GYLX = Convert.ToString(sdr["GYLX"]);
                        child.GYS = Convert.ToString(sdr["GYS"]);
                        child.GYSMS = Convert.ToString(sdr["GYSMS"]);
                        child.GYSPC = Convert.ToString(sdr["GYSPC"]);
                        child.CPZT = Convert.ToInt32(sdr["CPZT"]);
                        child.CPZTNAME = Convert.ToString(sdr["CPZTNAME"]);
                        child.PFDH = Convert.ToString(sdr["PFDH"]);
                        child.PLDH = Convert.ToString(sdr["PLDH"]);
                        child.TH = Convert.ToInt32(sdr["TH"]);
                        child.SL = Convert.ToDecimal(sdr["SL"]);
                        child.KSTIME = Convert.ToDateTime(sdr["KSTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.JSTIME = Convert.ToDateTime(sdr["JSTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.XFWLH = Convert.ToString(sdr["XFWLH"]);
                        child.DCDJ = Convert.ToInt32(sdr["DCDJ"]);
                        child.DCDJMS = Convert.ToString(sdr["DCDJMS"]);
                        child.DCXH = Convert.ToInt32(sdr["DCXH"]);
                        child.DCXHMS = Convert.ToString(sdr["DCXHMS"]);
                        child.TPM = Convert.ToString(sdr["TPM"]);
                        child.SBCD = Convert.ToInt32(sdr["SBCD"]);
                        child.SBCDMS = Convert.ToString(sdr["SBCDMS"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.JLR = Convert.ToInt32(sdr["JLR"]);
                        child.JLRMS = Convert.ToString(sdr["JLRMS"]);
                        child.JLTIME = Convert.ToDateTime(sdr["JLTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.NOBILL = Convert.ToString(sdr["NOBILL"]);
                        child.NOBILLMX = Convert.ToString(sdr["NOBILLMX"]);
                        child.WLLB = Convert.ToInt32(sdr["WLLB"]);
                        child.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        child.UNITSNAME = Convert.ToString(sdr["UNITSNAME"]);
                        child.ERPNO = Convert.ToString(sdr["ERPNO"]);
                        child.SBZ = Convert.ToString(sdr["SBZ"]);
                        child.SIZE = Convert.ToInt32(sdr["SIZE"]);
                        child.SIZENAME = Convert.ToString(sdr["SIZENAME"]);
                        child.SYSCX = Convert.ToString(sdr["SYSCX"]);
                        child.SYCPGG = Convert.ToString(sdr["SYCPGG"]);
                        child.THGG = Convert.ToString(sdr["THGG"]);
                        child.DCSLBS = Convert.ToInt32(sdr["DCSLBS"]);
                        child.DCSLMBSL = Convert.ToInt32(sdr["DCSLMBSL"]);
                        child.DCSLYS = Convert.ToInt32(sdr["DCSLYS"]);
                        child.RQM = Convert.ToString(sdr["RQM"]);
                        child.ZFDCLB = Convert.ToInt32(sdr["ZFDCLB"]);
                        child.ZFDCLBNAME = Convert.ToString(sdr["ZFDCLBNAME"]);
                        child.KCDDGC = Convert.ToString(sdr["KCDDGC"]);
                        child.KCDD = Convert.ToString(sdr["KCDD"]);
                        child.KCDDNAME = Convert.ToString(sdr["KCDDNAME"]);
                        child.CGBILL = Convert.ToString(sdr["CGBILL"]);
                        child.CGBILLMX = Convert.ToString(sdr["CGBILLMX"]);
                        child.CFTS = Convert.ToInt32(sdr["CFTS"]);
                        child.XDGX = Convert.ToInt32(sdr["XDGX"]);
                        child.XDGXNAME = Convert.ToString(sdr["XDGXNAME"]);
                        child.VDATU = Convert.ToString(sdr["VDATU"]);
                        child.SCDATEP = Convert.ToString(sdr["SCDATEP"]);
                        if (child.KSTIME == "1900-01-01 00:00:00")
                        {
                            child.KSTIME = "";
                        }
                        if (child.JSTIME == "1900-01-01 00:00:00")
                        {
                            child.JSTIME = "";
                        }
                        child.MID = Convert.ToString(sdr["MID"]);
                        child.JZ = Convert.ToDecimal(sdr["JZ"]);
                        child.CPTYPE = Convert.ToInt32(sdr["CPTYPE"]);
                        child.CPTYPENAME = Convert.ToString(sdr["CPTYPENAME"]);
                        child.WQH = Convert.ToString(sdr["WQH"]);
                        child.MFQCOLOR = Convert.ToInt32(sdr["MFQCOLOR"]);
                        child.MFQCOLORNAME = Convert.ToString(sdr["MFQCOLORNAME"]);
                        child.MOULD = Convert.ToString(sdr["MOULD"]);
                        child.RESDUESL = Convert.ToDecimal(sdr["RESDUESL"]);
                        child.CLPBDM = Convert.ToString(sdr["CLPBDM"]);
                        child.GLTMCOUNT = Convert.ToInt32(sdr["GLTMCOUNT"]);
                        child_MES_TM_TMINFO_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "TM_TMINFO_SELECT_GLSELECT");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_TM_TMINFO_LIST = child_MES_TM_TMINFO_LIST;
            return rst;
        }
        public SELECT_MES_TM_TMINFO_BYTM SELECT_LIST(DataTable dt, MES_TM_TMINFO model, int LB)
        {
            SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
            List<MES_TM_TMINFO_LIST> child_MES_TM_TMINFO_LIST = new List<MES_TM_TMINFO_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@TMLIST",dt),
                                       new SqlParameter("@LB",LB),
                                       new SqlParameter("@WLMS",model.WLMS),
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@MOULD",model.MOULD),
                                       new SqlParameter("@CLPBDM",model.CLPBDM),
                                       new SqlParameter("@SCDATES",model.SCDATES),
                                       new SqlParameter("@SCDATEE",model.SCDATEE),
                                       new SqlParameter("@MID",model.MID),
                                       new SqlParameter("@TM",model.TM),
                                       new SqlParameter("@PC",model.PC)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_LIST, parms))
                {
                    while (sdr.Read())
                    {
                        MES_TM_TMINFO_LIST child = new MES_TM_TMINFO_LIST();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.GCDYMS = Convert.ToString(sdr["GCDYMS"]);
                        child.TM = Convert.ToString(sdr["TM"]);
                        child.TMLB = Convert.ToInt32(sdr["TMLB"]);
                        child.TMSX = Convert.ToInt32(sdr["TMSX"]);
                        child.SCDATE = Convert.ToString(sdr["SCDATE"]);
                        child.BC = Convert.ToInt32(sdr["BC"]);
                        child.BCMS = Convert.ToString(sdr["BCMS"]);
                        child.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        child.GZZXMS = Convert.ToString(sdr["GZZXMS"]);
                        child.SBBH = Convert.ToString(sdr["SBBH"]);
                        child.SBHMS = Convert.ToString(sdr["SBHMS"]);
                        child.RWBH = Convert.ToString(sdr["RWBH"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.WLMS = Convert.ToString(sdr["WLMS"]);
                        child.PC = Convert.ToString(sdr["PC"]);
                        child.CLCJ = Convert.ToString(sdr["CLCJ"]);
                        child.GYLX = Convert.ToString(sdr["GYLX"]);
                        child.GYS = Convert.ToString(sdr["GYS"]);
                        child.GYSMS = Convert.ToString(sdr["GYSMS"]);
                        child.GYSPC = Convert.ToString(sdr["GYSPC"]);
                        child.CPZT = Convert.ToInt32(sdr["CPZT"]);
                        child.CPZTNAME = Convert.ToString(sdr["CPZTNAME"]);
                        child.PFDH = Convert.ToString(sdr["PFDH"]);
                        child.PLDH = Convert.ToString(sdr["PLDH"]);
                        child.TH = Convert.ToInt32(sdr["TH"]);
                        child.SL = Convert.ToDecimal(sdr["SL"]);
                        child.KSTIME = Convert.ToDateTime(sdr["KSTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.JSTIME = Convert.ToDateTime(sdr["JSTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.XFWLH = Convert.ToString(sdr["XFWLH"]);
                        child.DCDJ = Convert.ToInt32(sdr["DCDJ"]);
                        child.DCDJMS = Convert.ToString(sdr["DCDJMS"]);
                        child.DCXH = Convert.ToInt32(sdr["DCXH"]);
                        child.DCXHMS = Convert.ToString(sdr["DCXHMS"]);
                        child.TPM = Convert.ToString(sdr["TPM"]);
                        child.SBCD = Convert.ToInt32(sdr["SBCD"]);
                        child.SBCDMS = Convert.ToString(sdr["SBCDMS"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.JLR = Convert.ToInt32(sdr["JLR"]);
                        child.JLRMS = Convert.ToString(sdr["JLRMS"]);
                        child.JLTIME = Convert.ToDateTime(sdr["JLTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.NOBILL = Convert.ToString(sdr["NOBILL"]);
                        child.NOBILLMX = Convert.ToString(sdr["NOBILLMX"]);
                        child.WLLB = Convert.ToInt32(sdr["WLLB"]);
                        child.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        child.UNITSNAME = Convert.ToString(sdr["UNITSNAME"]);
                        child.ERPNO = Convert.ToString(sdr["ERPNO"]);
                        child.SBZ = Convert.ToString(sdr["SBZ"]);
                        child.SIZE = Convert.ToInt32(sdr["SIZE"]);
                        child.SIZENAME = Convert.ToString(sdr["SIZENAME"]);
                        child.SYSCX = Convert.ToString(sdr["SYSCX"]);
                        child.SYCPGG = Convert.ToString(sdr["SYCPGG"]);
                        child.THGG = Convert.ToString(sdr["THGG"]);
                        child.DCSLBS = Convert.ToInt32(sdr["DCSLBS"]);
                        child.DCSLMBSL = Convert.ToInt32(sdr["DCSLMBSL"]);
                        child.DCSLYS = Convert.ToInt32(sdr["DCSLYS"]);
                        child.RQM = Convert.ToString(sdr["RQM"]);
                        child.ZFDCLB = Convert.ToInt32(sdr["ZFDCLB"]);
                        child.ZFDCLBNAME = Convert.ToString(sdr["ZFDCLBNAME"]);
                        child.KCDDGC = Convert.ToString(sdr["KCDDGC"]);
                        child.KCDD = Convert.ToString(sdr["KCDD"]);
                        child.KCDDNAME = Convert.ToString(sdr["KCDDNAME"]);
                        child.CGBILL = Convert.ToString(sdr["CGBILL"]);
                        child.CGBILLMX = Convert.ToString(sdr["CGBILLMX"]);
                        child.CFTS = Convert.ToInt32(sdr["CFTS"]);
                        child.XDGX = Convert.ToInt32(sdr["XDGX"]);
                        child.XDGXNAME = Convert.ToString(sdr["XDGXNAME"]);
                        child.VDATU = Convert.ToString(sdr["VDATU"]);
                        child.SCDATEP = Convert.ToString(sdr["SCDATEP"]);
                        if (child.KSTIME == "1900-01-01 00:00:00")
                        {
                            child.KSTIME = "";
                        }
                        if (child.JSTIME == "1900-01-01 00:00:00")
                        {
                            child.JSTIME = "";
                        }
                        child.MID = Convert.ToString(sdr["MID"]);
                        child.JZ = Convert.ToDecimal(sdr["JZ"]);
                        child.CPTYPE = Convert.ToInt32(sdr["CPTYPE"]);
                        child.CPTYPENAME = Convert.ToString(sdr["CPTYPENAME"]);
                        child.WQH = Convert.ToString(sdr["WQH"]);
                        child.MFQCOLOR = Convert.ToInt32(sdr["MFQCOLOR"]);
                        child.MFQCOLORNAME = Convert.ToString(sdr["MFQCOLORNAME"]);
                        child.MOULD = Convert.ToString(sdr["MOULD"]);
                        child.RESDUESL = Convert.ToDecimal(sdr["RESDUESL"]);
                        child.CLPBDM = Convert.ToString(sdr["CLPBDM"]);
                        child.GLTMCOUNT = Convert.ToInt32(sdr["GLTMCOUNT"]);
                        if (LB == 1)
                        {
                            child.QJCOUNT = Convert.ToInt32(sdr["QJCOUNT"]);
                            child.FGCOUNT = Convert.ToInt32(sdr["FGCOUNT"]);
                            child.FTM = Convert.ToString(sdr["FTM"]);
                            child.FTMPC = Convert.ToString(sdr["FTMPC"]);
                            child.KHID = Convert.ToInt32(sdr["KHID"]);
                            child.KHMS = Convert.ToString(sdr["KHMS"]);
                            child.KHNO = Convert.ToString(sdr["KHNO"]);
                        }
                        child_MES_TM_TMINFO_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "MES_TM_TMINFO_SELECT_LIST");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_TM_TMINFO_LIST = child_MES_TM_TMINFO_LIST;
            return rst;
        }
        public SELECT_MES_TM_TMINFO_BYTM SELECT_LIST_datatable(DataTable dt, MES_TM_TMINFO model)
        {
            SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
            List<MES_TM_TMINFO_LIST> child_MES_TM_TMINFO_LIST = new List<MES_TM_TMINFO_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@TMLIST",dt),
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@WLMS",model.WLMS),
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@MOULD",model.MOULD),
                                       new SqlParameter("@CLPBDM",model.CLPBDM),
                                       new SqlParameter("@SCDATES",model.SCDATES),
                                       new SqlParameter("@SCDATEE",model.SCDATEE),
                                       new SqlParameter("@MID",model.MID),
                                       new SqlParameter("@TM",model.TM),
                                       new SqlParameter("@PC",model.PC)
                                   };

                //using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_LIST, parms))
                //{
                //    while (sdr.Read())
                //    {
                //    }
                //}
                rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_SELECT_LIST, parms);
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "MES_TM_TMINFO_SELECT_LIST_datatable");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_TM_TMINFO_LIST = child_MES_TM_TMINFO_LIST;
            return rst;
        }
        public MES_RETURN UPDATE(MES_TM_TMINFO model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                DataTable dtold = new DataTable();
                DataTable dtnew = new DataTable();
                MES_SY_TABLE_COLUMN model_MES_SY_TABLE_COLUMN = new MES_SY_TABLE_COLUMN();
                model_MES_SY_TABLE_COLUMN.SY = "MES";
                model_MES_SY_TABLE_COLUMN.SY_TABLE = "MES_TM_TMINFO";
                model_MES_SY_TABLE_COLUMN.ZJVALUES = model.TM;
                model_MES_SY_TABLE_COLUMN.STAFFID = model.JLR;
                MES_SY_TABLE_COLUMN_SELECT rst_MES_SY_TABLE_COLUMN_SELECT = SY_TABLE_COLUMNService.SELECT(model_MES_SY_TABLE_COLUMN);
                if (rst_MES_SY_TABLE_COLUMN_SELECT.MES_RETURN.TYPE == "S")
                {
                    dtold = rst_MES_SY_TABLE_COLUMN_SELECT.DATALIST;
                }
                SqlParameter[] parms = {
                                       new SqlParameter("@LB",LB),
                                       new SqlParameter("@TM",model.TM),
                                       new SqlParameter("@CPZT",model.CPZT),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@TPM",model.TPM),
                                       new SqlParameter("@DCXH",model.DCXH),
                                       new SqlParameter("@DCDJ",model.DCDJ),
                                       new SqlParameter("@KSTIME",model.KSTIME),
                                       new SqlParameter("@JSTIME",model.JSTIME),
                                       new SqlParameter("@SL",model.SL),
                                       new SqlParameter("@ZFDCLB",model.ZFDCLB),
                                       new SqlParameter("@TH",model.TH),
                                       new SqlParameter("@CFTS",model.CFTS),
                                       new SqlParameter("@NOBILL",model.NOBILL),
                                       new SqlParameter("@NOBILLMX",model.NOBILLMX),
                                       new SqlParameter("@JLR",model.JLR),
                                       new SqlParameter("@GYSPC",model.GYSPC),
                                       new SqlParameter("@PC",model.PC),
                                       new SqlParameter("@DCSLYS",model.DCSLYS),
                                       new SqlParameter("@DCSLMBSL",model.DCSLMBSL),
                                       new SqlParameter("@DCSLBS",model.DCSLBS),
                                       new SqlParameter("@XDGX",model.XDGX),
                                       new SqlParameter("@RQM",model.RQM),
                                       new SqlParameter("@SCDATE",model.SCDATE),
                                       new SqlParameter("@SBCD",model.SBCD),
                                       new SqlParameter("@YGH",model.YGH),
                                       new SqlParameter("@YGNAME",model.YGNAME),
                                       new SqlParameter("@BC",model.BC),
                                       new SqlParameter("@KCDDGC",model.KCDDGC),
                                       new SqlParameter("@KCDD",model.KCDD),
                                       new SqlParameter("@KCDDNAME",model.KCDDNAME),
                                       new SqlParameter("@WQH",model.WQH),
                                       new SqlParameter("@MFQCOLOR",model.MFQCOLOR),
                                       new SqlParameter("@CLPBDM",model.CLPBDM),
                                       new SqlParameter("@CPTYPE",model.CPTYPE)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                        rst.TM = Convert.ToString(sdr["TM"]);
                        rst.TMSX = Convert.ToInt32(sdr["TMSX"]);
                        rst.GC = Convert.ToString(sdr["GC"]);
                        if (rst.TYPE == "S")
                        {
                            rst_MES_SY_TABLE_COLUMN_SELECT = SY_TABLE_COLUMNService.SELECT(model_MES_SY_TABLE_COLUMN);
                            if (rst_MES_SY_TABLE_COLUMN_SELECT.MES_RETURN.TYPE == "S")
                            {
                                dtnew = rst_MES_SY_TABLE_COLUMN_SELECT.DATALIST;
                            }
                            if (dtold.Rows.Count > 0 && dtnew.Rows.Count > 0)
                            {
                                SY_TABLE_COLUMNService.INSERT_CHANGEINFO(dtold, dtnew, model_MES_SY_TABLE_COLUMN);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "TM_TMINFO_UPDATE");
            }
            return rst;
        }
        public MES_RETURN UPDATE_CF(MES_TM_TMINFO model, string NTM)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                DataTable dtold = new DataTable();
                DataTable dtnew = new DataTable();
                MES_SY_TABLE_COLUMN model_MES_SY_TABLE_COLUMN = new MES_SY_TABLE_COLUMN();
                model_MES_SY_TABLE_COLUMN.SY = "MES";
                model_MES_SY_TABLE_COLUMN.SY_TABLE = "MES_TM_TMINFO";
                model_MES_SY_TABLE_COLUMN.ZJVALUES = model.TM;
                model_MES_SY_TABLE_COLUMN.STAFFID = model.JLR;
                MES_SY_TABLE_COLUMN_SELECT rst_MES_SY_TABLE_COLUMN_SELECT = SY_TABLE_COLUMNService.SELECT(model_MES_SY_TABLE_COLUMN);
                if (rst_MES_SY_TABLE_COLUMN_SELECT.MES_RETURN.TYPE == "S")
                {
                    dtold = rst_MES_SY_TABLE_COLUMN_SELECT.DATALIST;
                }
                SqlParameter[] parms = {
                                       new SqlParameter("@NTM",NTM),
                                       new SqlParameter("@TM",model.TM),
                                       new SqlParameter("@SL",model.SL),
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@JLR",model.JLR)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE_CF, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                        rst.TM = NTM;
                        if (rst.TYPE == "S")
                        {
                            rst_MES_SY_TABLE_COLUMN_SELECT = SY_TABLE_COLUMNService.SELECT(model_MES_SY_TABLE_COLUMN);
                            if (rst_MES_SY_TABLE_COLUMN_SELECT.MES_RETURN.TYPE == "S")
                            {
                                dtnew = rst_MES_SY_TABLE_COLUMN_SELECT.DATALIST;
                            }
                            if (dtold.Rows.Count > 0 && dtnew.Rows.Count > 0)
                            {
                                SY_TABLE_COLUMNService.INSERT_CHANGEINFO(dtold, dtnew, model_MES_SY_TABLE_COLUMN);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "TM_TMINFO_UPDATE");
            }
            return rst;
        }
        public SELECT_MES_TM_TMINFO_BYTM SELECT_BY_STAFFID(MES_TM_TMINFO model, int CXLB)
        {
            SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
            List<MES_TM_TMINFO_LIST> child_MES_TM_TMINFO_LIST = new List<MES_TM_TMINFO_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@CXLB",CXLB),
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@TM",model.TM),
                                       new SqlParameter("@TMLB",model.TMLB),
                                       new SqlParameter("@TMSX",model.TMSX),
                                       new SqlParameter("@RWBH",model.RWBH),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@SBHMS",model.SBHMS),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@NOBILL",model.NOBILL),
                                       new SqlParameter("@NOBILLMX",model.NOBILLMX),
                                       new SqlParameter("@SCDATE",model.SCDATE),
                                       new SqlParameter("@SCDATES",model.SCDATES),
                                       new SqlParameter("@SCDATEE",model.SCDATEE),
                                       new SqlParameter("@TH",model.TH),
                                       new SqlParameter("@JLKSTIME",model.JLKSTIME),
                                       new SqlParameter("@JLJSTIME",model.JLJSTIME),
                                       new SqlParameter("@BC",model.BC),
                                       new SqlParameter("@PC",model.PC),
                                       new SqlParameter("@CLCJ",model.CLCJ),
                                       new SqlParameter("@GYLX",model.GYLX),
                                       new SqlParameter("@GYS",model.GYS),
                                       new SqlParameter("@GYSMS",model.GYSMS),
                                       new SqlParameter("@GYSPC",model.GYSPC),
                                       new SqlParameter("@CPZT",model.CPZT),
                                       new SqlParameter("@PFDH",model.PFDH),
                                       new SqlParameter("@PLDH",model.PLDH),
                                       new SqlParameter("@XFWLH",model.XFWLH),
                                       new SqlParameter("@DCDJ",model.DCDJ),
                                       new SqlParameter("@DCXH",model.DCXH),
                                       new SqlParameter("@TPM",model.TPM),
                                       new SqlParameter("@SBCD",model.SBCD),
                                       new SqlParameter("@WLLB",model.WLLB),
                                       new SqlParameter("@WLGROUP",model.WLGROUP),
                                       new SqlParameter("@SIZE",model.SIZE),
                                       new SqlParameter("@ERPNO",model.ERPNO),
                                       new SqlParameter("@RQM",model.RQM),
                                       new SqlParameter("@ZFDCLB",model.ZFDCLB),
                                       new SqlParameter("@KCDD",model.KCDD),
                                       new SqlParameter("@CGBILL",model.CGBILL),
                                       new SqlParameter("@MAC",model.MAC),
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@MOULD",model.MOULD),
                                       new SqlParameter("@CLPBDM",model.CLPBDM),
                                       new SqlParameter("@REMARK",model.REMARK)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_BY_ROLE, parms))
                {
                    while (sdr.Read())
                    {
                        MES_TM_TMINFO_LIST child = new MES_TM_TMINFO_LIST();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.GCDYMS = Convert.ToString(sdr["GCDYMS"]);
                        child.TM = Convert.ToString(sdr["TM"]);
                        child.TMLB = Convert.ToInt32(sdr["TMLB"]);
                        child.TMSX = Convert.ToInt32(sdr["TMSX"]);
                        child.SCDATE = Convert.ToString(sdr["SCDATE"]);
                        child.BC = Convert.ToInt32(sdr["BC"]);
                        child.BCMS = Convert.ToString(sdr["BCMS"]);
                        child.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        child.GZZXMS = Convert.ToString(sdr["GZZXMS"]);
                        child.SBBH = Convert.ToString(sdr["SBBH"]);
                        child.SBHMS = Convert.ToString(sdr["SBHMS"]);
                        child.RWBH = Convert.ToString(sdr["RWBH"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.WLMS = Convert.ToString(sdr["WLMS"]);
                        child.PC = Convert.ToString(sdr["PC"]);
                        child.CLCJ = Convert.ToString(sdr["CLCJ"]);
                        child.GYLX = Convert.ToString(sdr["GYLX"]);
                        child.GYS = Convert.ToString(sdr["GYS"]);
                        child.GYSMS = Convert.ToString(sdr["GYSMS"]);
                        child.GYSPC = Convert.ToString(sdr["GYSPC"]);
                        child.CPZT = Convert.ToInt32(sdr["CPZT"]);
                        child.CPZTNAME = Convert.ToString(sdr["CPZTNAME"]);
                        child.PFDH = Convert.ToString(sdr["PFDH"]);
                        child.PLDH = Convert.ToString(sdr["PLDH"]);
                        child.TH = Convert.ToInt32(sdr["TH"]);
                        child.SL = Convert.ToDecimal(sdr["SL"]);
                        child.KSTIME = Convert.ToDateTime(sdr["KSTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.JSTIME = Convert.ToDateTime(sdr["JSTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.XFWLH = Convert.ToString(sdr["XFWLH"]);
                        child.XFCDNAME = Convert.ToString(sdr["XFCDNAME"]);
                        child.DCDJ = Convert.ToInt32(sdr["DCDJ"]);
                        child.DCDJMS = Convert.ToString(sdr["DCDJMS"]);
                        child.DCXH = Convert.ToInt32(sdr["DCXH"]);
                        child.DCXHMS = Convert.ToString(sdr["DCXHMS"]);
                        child.TPM = Convert.ToString(sdr["TPM"]);
                        child.SBCD = Convert.ToInt32(sdr["SBCD"]);
                        child.SBCDMS = Convert.ToString(sdr["SBCDMS"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.JLR = Convert.ToInt32(sdr["JLR"]);
                        child.JLRMS = Convert.ToString(sdr["JLRMS"]);
                        child.JLTIME = Convert.ToDateTime(sdr["JLTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.NOBILL = Convert.ToString(sdr["NOBILL"]);
                        child.NOBILLMX = Convert.ToString(sdr["NOBILLMX"]);
                        child.WLLB = Convert.ToInt32(sdr["WLLB"]);
                        child.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        child.UNITSNAME = Convert.ToString(sdr["UNITSNAME"]);
                        child.ERPNO = Convert.ToString(sdr["ERPNO"]);
                        child.SBZ = Convert.ToString(sdr["SBZ"]);
                        child.SIZE = Convert.ToInt32(sdr["SIZE"]);
                        child.SIZENAME = Convert.ToString(sdr["SIZENAME"]);
                        child.SYSCX = Convert.ToString(sdr["SYSCX"]);
                        child.SYCPGG = Convert.ToString(sdr["SYCPGG"]);
                        child.THGG = Convert.ToString(sdr["THGG"]);
                        child.DCSLBS = Convert.ToInt32(sdr["DCSLBS"]);
                        child.DCSLMBSL = Convert.ToInt32(sdr["DCSLMBSL"]);
                        child.DCSLYS = Convert.ToInt32(sdr["DCSLYS"]);
                        child.RQM = Convert.ToString(sdr["RQM"]);
                        child.GDSL = Convert.ToDecimal(sdr["GDSL"]);
                        child.ZFDCLB = Convert.ToInt32(sdr["ZFDCLB"]);
                        child.ZFDCLBNAME = Convert.ToString(sdr["ZFDCLBNAME"]);
                        child.KCDDGC = Convert.ToString(sdr["KCDDGC"]);
                        child.KCDD = Convert.ToString(sdr["KCDD"]);
                        child.KCDDNAME = Convert.ToString(sdr["KCDDNAME"]);
                        child.CGBILL = Convert.ToString(sdr["CGBILL"]);
                        child.CGBILLMX = Convert.ToString(sdr["CGBILLMX"]);
                        child.CFTS = Convert.ToInt32(sdr["CFTS"]);
                        child.WLGROUP = Convert.ToString(sdr["WLGROUP"]);
                        child.WLGROUPNAME = Convert.ToString(sdr["WLGROUPNAME"]);
                        child.XDGX = Convert.ToInt32(sdr["XDGX"]);
                        child.XDGXNAME = Convert.ToString(sdr["XDGXNAME"]);
                        child.VDATU = Convert.ToString(sdr["VDATU"]);
                        child.SCDATEP = Convert.ToString(sdr["SCDATEP"]);
                        if (child.KSTIME == "1900-01-01 00:00:00")
                        {
                            child.KSTIME = "";
                        }
                        if (child.JSTIME == "1900-01-01 00:00:00")
                        {
                            child.JSTIME = "";
                        }
                        child.MID = Convert.ToString(sdr["MID"]);
                        child.JZ = Convert.ToDecimal(sdr["JZ"]);
                        child.CPTYPE = Convert.ToInt32(sdr["CPTYPE"]);
                        child.CPTYPENAME = Convert.ToString(sdr["CPTYPENAME"]);
                        child.WQH = Convert.ToString(sdr["WQH"]);
                        child.MFQCOLOR = Convert.ToInt32(sdr["MFQCOLOR"]);
                        child.MFQCOLORNAME = Convert.ToString(sdr["MFQCOLORNAME"]);
                        child.MOULD = Convert.ToString(sdr["MOULD"]);
                        child.RESDUESL = Convert.ToDecimal(sdr["RESDUESL"]);
                        child.CLPBDM = Convert.ToString(sdr["CLPBDM"]);
                        child.GLTMCOUNT = Convert.ToInt32(sdr["GLTMCOUNT"]);
                        child_MES_TM_TMINFO_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
                rst.MES_TM_TMINFO_LIST = child_MES_TM_TMINFO_LIST;
                rst.MES_RETURN = child_MES_RETURN;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "TM_TMINFO_SELECT_BY_STAFFID");
            }
            return rst;
        }//SELECT_BY_KCDDLimit
        public SELECT_MES_TM_TMINFO_BYTM SELECT_BY_KCDDLimit(MES_TM_TMINFO model)
        {
            SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
            List<MES_TM_TMINFO_LIST> child_MES_TM_TMINFO_LIST = new List<MES_TM_TMINFO_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                          
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@TM",model.TM),
                                       //new SqlParameter("@TMLB",model.TMLB),
                                       //new SqlParameter("@TMSX",model.TMSX),
                                       //new SqlParameter("@RWBH",model.RWBH),
                                       //new SqlParameter("@GZZXBH",model.GZZXBH),
                                       //new SqlParameter("@SBBH",model.SBBH),
                                       //new SqlParameter("@WLH",model.WLH),
                                       //new SqlParameter("@NOBILL",model.NOBILL),
                                       //new SqlParameter("@SCDATE",model.SCDATE),
                                       //new SqlParameter("@SCDATES",model.SCDATES),
                                       //new SqlParameter("@SCDATEE",model.SCDATEE),
                                       //new SqlParameter("@TH",model.TH),
                                       //new SqlParameter("@JLKSTIME",model.JLKSTIME),
                                       //new SqlParameter("@JLJSTIME",model.JLJSTIME),
                                       //new SqlParameter("@BC",model.BC),
                                       //new SqlParameter("@PC",model.PC),
                                       //new SqlParameter("@CLCJ",model.CLCJ),
                                       //new SqlParameter("@GYLX",model.GYLX),
                                       //new SqlParameter("@GYS",model.GYS),
                                       //new SqlParameter("@GYSMS",model.GYSMS),
                                       //new SqlParameter("@GYSPC",model.GYSPC),
                                       //new SqlParameter("@CPZT",model.CPZT),
                                       //new SqlParameter("@PFDH",model.PFDH),
                                       //new SqlParameter("@PLDH",model.PLDH),
                                       //new SqlParameter("@XFWLH",model.XFWLH),
                                       //new SqlParameter("@DCDJ",model.DCDJ),
                                       //new SqlParameter("@DCXH",model.DCXH),
                                       //new SqlParameter("@TPM",model.TPM),
                                       //new SqlParameter("@SBCD",model.SBCD),
                                       //new SqlParameter("@WLLB",model.WLLB),
                                       //new SqlParameter("@WLGROUP",model.WLGROUP),
                                       //new SqlParameter("@SIZE",model.SIZE),
                                       //new SqlParameter("@ERPNO",model.ERPNO),
                                       //new SqlParameter("@RQM",model.RQM),
                                       //new SqlParameter("@ZFDCLB",model.ZFDCLB),
                                       //new SqlParameter("@KCDD",model.KCDD),
                                       //new SqlParameter("@CGBILL",model.CGBILL),
                                       //new SqlParameter("@MAC",model.MAC),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_BY_KCDDLimit, parms))
                {
                    while (sdr.Read())
                    {
                        MES_TM_TMINFO_LIST child = new MES_TM_TMINFO_LIST();
                        child.GC = Convert.ToString(sdr["GC"]);
                        //child.GCDYMS = Convert.ToString(sdr["GCDYMS"]);
                        child.TM = Convert.ToString(sdr["TM"]);
                        child.TMLB = Convert.ToInt32(sdr["TMLB"]);
                        child.TMSX = Convert.ToInt32(sdr["TMSX"]);
                        child.SCDATE = Convert.ToString(sdr["SCDATE"]);
                        child.BC = Convert.ToInt32(sdr["BC"]);
                        child.BCMS = Convert.ToString(sdr["BCMS"]);
                        child.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        child.GZZXMS = Convert.ToString(sdr["GZZXMS"]);
                        child.SBBH = Convert.ToString(sdr["SBBH"]);
                        child.SBHMS = Convert.ToString(sdr["SBHMS"]);
                        child.RWBH = Convert.ToString(sdr["RWBH"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.WLMS = Convert.ToString(sdr["WLMS"]);
                        child.PC = Convert.ToString(sdr["PC"]);
                        child.CLCJ = Convert.ToString(sdr["CLCJ"]);
                        child.GYLX = Convert.ToString(sdr["GYLX"]);
                        child.GYS = Convert.ToString(sdr["GYS"]);
                        child.GYSMS = Convert.ToString(sdr["GYSMS"]);
                        child.GYSPC = Convert.ToString(sdr["GYSPC"]);
                        child.CPZT = Convert.ToInt32(sdr["CPZT"]);
                        child.CPZTNAME = Convert.ToString(sdr["CPZTNAME"]);
                        child.PFDH = Convert.ToString(sdr["PFDH"]);
                        child.PLDH = Convert.ToString(sdr["PLDH"]);
                        child.TH = Convert.ToInt32(sdr["TH"]);
                        child.SL = Convert.ToDecimal(sdr["SL"]);
                        child.KSTIME = Convert.ToDateTime(sdr["KSTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.JSTIME = Convert.ToDateTime(sdr["JSTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.XFWLH = Convert.ToString(sdr["XFWLH"]);
                        child.XFCDNAME = Convert.ToString(sdr["XFCDNAME"]);
                        child.DCDJ = Convert.ToInt32(sdr["DCDJ"]);
                        child.DCDJMS = Convert.ToString(sdr["DCDJMS"]);
                        child.DCXH = Convert.ToInt32(sdr["DCXH"]);
                        child.DCXHMS = Convert.ToString(sdr["DCXHMS"]);
                        child.TPM = Convert.ToString(sdr["TPM"]);
                        child.SBCD = Convert.ToInt32(sdr["SBCD"]);
                        child.SBCDMS = Convert.ToString(sdr["SBCDMS"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.JLR = Convert.ToInt32(sdr["JLR"]);
                        child.JLRMS = Convert.ToString(sdr["JLRMS"]);
                        child.JLTIME = Convert.ToDateTime(sdr["JLTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.NOBILL = Convert.ToString(sdr["NOBILL"]);
                        child.NOBILLMX = Convert.ToString(sdr["NOBILLMX"]);
                        child.WLLB = Convert.ToInt32(sdr["WLLB"]);
                        child.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        child.UNITSNAME = Convert.ToString(sdr["UNITSNAME"]);
                        child.ERPNO = Convert.ToString(sdr["ERPNO"]);
                        child.SBZ = Convert.ToString(sdr["SBZ"]);
                        child.SIZE = Convert.ToInt32(sdr["SIZE"]);
                        child.SIZENAME = Convert.ToString(sdr["SIZENAME"]);
                        child.SYSCX = Convert.ToString(sdr["SYSCX"]);
                        child.SYCPGG = Convert.ToString(sdr["SYCPGG"]);
                        child.THGG = Convert.ToString(sdr["THGG"]);
                        child.DCSLBS = Convert.ToInt32(sdr["DCSLBS"]);
                        child.DCSLMBSL = Convert.ToInt32(sdr["DCSLMBSL"]);
                        child.DCSLYS = Convert.ToInt32(sdr["DCSLYS"]);
                        child.RQM = Convert.ToString(sdr["RQM"]);
                        //child.GDSL = Convert.ToDecimal(sdr["GDSL"]);
                        child.ZFDCLB = Convert.ToInt32(sdr["ZFDCLB"]);
                        child.ZFDCLBNAME = Convert.ToString(sdr["ZFDCLBNAME"]);
                        child.KCDDGC = Convert.ToString(sdr["KCDDGC"]);
                        child.KCDD = Convert.ToString(sdr["KCDD"]);
                        child.KCDDNAME = Convert.ToString(sdr["KCDDNAME"]);
                        child.CGBILL = Convert.ToString(sdr["CGBILL"]);
                        child.CGBILLMX = Convert.ToString(sdr["CGBILLMX"]);
                        child.CFTS = Convert.ToInt32(sdr["CFTS"]);
                        child.WLGROUP = Convert.ToString(sdr["WLGROUP"]);
                        child.WLGROUPNAME = Convert.ToString(sdr["WLGROUPNAME"]);
                        child.XDGX = Convert.ToInt32(sdr["XDGX"]);
                        child.XDGXNAME = Convert.ToString(sdr["XDGXNAME"]);
                        child.VDATU = Convert.ToString(sdr["VDATU"]);
                        child.SCDATEP = Convert.ToString(sdr["SCDATEP"]);
                        if (child.KSTIME == "1900-01-01 00:00:00")
                        {
                            child.KSTIME = "";
                        }
                        if (child.JSTIME == "1900-01-01 00:00:00")
                        {
                            child.JSTIME = "";
                        }
                        child.MID = Convert.ToString(sdr["MID"]);
                        child.JZ = Convert.ToDecimal(sdr["JZ"]);
                        child.CPTYPE = Convert.ToInt32(sdr["CPTYPE"]);
                        child.CPTYPENAME = Convert.ToString(sdr["CPTYPENAME"]);
                        child.WQH = Convert.ToString(sdr["WQH"]);
                        child.MFQCOLOR = Convert.ToInt32(sdr["MFQCOLOR"]);
                        child.MFQCOLORNAME = Convert.ToString(sdr["MFQCOLORNAME"]);
                        child.MOULD = Convert.ToString(sdr["MOULD"]);
                        child.RESDUESL = Convert.ToDecimal(sdr["RESDUESL"]);
                        child.CLPBDM = Convert.ToString(sdr["CLPBDM"]);
                        child.GLTMCOUNT = Convert.ToInt32(sdr["GLTMCOUNT"]);
                        child_MES_TM_TMINFO_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
                rst.MES_TM_TMINFO_LIST = child_MES_TM_TMINFO_LIST;
                rst.MES_RETURN = child_MES_RETURN;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "TM_TMINFO_SELECT_BY_STAFFID");
            }
            return rst;
        }
        public MES_RETURN SELECT_TM_LASTTIME(MES_TM_TMINFO model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@MID",model.MID),
                                       new SqlParameter("@LB",model.LB)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_TM_LASTTIME, parms))
                {
                    while (sdr.Read())
                    {
                        rst.MESSAGE = Convert.ToDateTime(sdr["JSTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                }
                rst.TYPE = "S";
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "MES_TM_TMINFO_SELECT_TM_LASTTIME");
            }
            return rst;
        }

        public SELECT_MES_TM_TMINFO_BYTM SELECT_KC_TT(MES_TM_TMINFO model)
        {
            SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_TM_TMINFO_KCHZ> child_MES_TM_TMINFO_KCHZ = new List<MES_TM_TMINFO_KCHZ>();
            List<MES_TM_TMINFO_LIST> child_MES_TM_TMINFO_LIST = new List<MES_TM_TMINFO_LIST>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@KCDDGC",model.KCDDGC),
                                       new SqlParameter("@KCDD",model.KCDD),
                                       new SqlParameter("@WLMS",model.WLMS),
                                       new SqlParameter("@PC",model.PC),
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@CPZTNAME",model.CPZTNAME),
                                       new SqlParameter("@MID",model.MID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_LB, parms))
                {
                    while (sdr.Read())
                    {
                        if (model.LB == 1)
                        {
                            MES_TM_TMINFO_KCHZ child = new MES_TM_TMINFO_KCHZ();
                            child.KCDDGC = Convert.ToString(sdr["KCDDGC"]);
                            child.KCDD = Convert.ToString(sdr["KCDD"]);
                            child.KCDDNAME = Convert.ToString(sdr["KCDDNAME"]);
                            child.WLH = Convert.ToString(sdr["WLH"]);
                            child.WLMS = Convert.ToString(sdr["WLMS"]);
                            child.MOULD = Convert.ToString(sdr["MOULD"]);
                            child.PC = Convert.ToString(sdr["PC"]);
                            child.CLPBDM = Convert.ToString(sdr["CLPBDM"]);
                            child.UNITSID = Convert.ToInt32(sdr["UNITSID"]);
                            child.UNITSNAME = Convert.ToString(sdr["UNITSNAME"]);
                            child.HGSL = Convert.ToDecimal(sdr["HGSL"]);
                            child.ZFSL = Convert.ToDecimal(sdr["ZFSL"]);
                            child.NOHGSL = Convert.ToDecimal(sdr["NOHGSL"]);
                            child.JLTIME = Convert.ToString(sdr["JLTIME"]);
                            child.YKDATE = Convert.ToString(sdr["YKDATE"]);
                            child_MES_TM_TMINFO_KCHZ.Add(child);
                        }
                        else if (model.LB == 2)
                        {
                            MES_TM_TMINFO_LIST child = new MES_TM_TMINFO_LIST();
                            child.GC = Convert.ToString(sdr["GC"]);
                            //child.GCDYMS = Convert.ToString(sdr["GCDYMS"]);
                            child.TM = Convert.ToString(sdr["TM"]);
                            child.TMLB = Convert.ToInt32(sdr["TMLB"]);
                            child.TMSX = Convert.ToInt32(sdr["TMSX"]);
                            child.SCDATE = Convert.ToString(sdr["YKDATE"]);
                            child.BC = Convert.ToInt32(sdr["BC"]);
                            child.BCMS = Convert.ToString(sdr["BCMS"]);
                            child.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                            child.GZZXMS = Convert.ToString(sdr["GZZXMS"]);
                            child.SBBH = Convert.ToString(sdr["SBBH"]);
                            child.SBHMS = Convert.ToString(sdr["SBHMS"]);
                            child.RWBH = Convert.ToString(sdr["RWBH"]);
                            child.WLH = Convert.ToString(sdr["WLH"]);
                            child.WLMS = Convert.ToString(sdr["WLMS"]);
                            child.PC = Convert.ToString(sdr["PC"]);
                            child.CLCJ = Convert.ToString(sdr["CLCJ"]);
                            child.GYLX = Convert.ToString(sdr["GYLX"]);
                            child.GYS = Convert.ToString(sdr["GYS"]);
                            child.GYSMS = Convert.ToString(sdr["GYSMS"]);
                            child.GYSPC = Convert.ToString(sdr["GYSPC"]);
                            child.CPZT = Convert.ToInt32(sdr["CPZT"]);
                            child.CPZTNAME = Convert.ToString(sdr["CPZTNAME"]);
                            child.PFDH = Convert.ToString(sdr["PFDH"]);
                            child.PLDH = Convert.ToString(sdr["PLDH"]);
                            child.TH = Convert.ToInt32(sdr["TH"]);
                            child.SL = Convert.ToDecimal(sdr["SL"]);
                            child.KSTIME = Convert.ToDateTime(sdr["KSTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                            child.JSTIME = Convert.ToDateTime(sdr["JSTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                            child.XFWLH = Convert.ToString(sdr["XFWLH"]);
                            child.XFCDNAME = Convert.ToString(sdr["XFCDNAME"]);
                            child.DCDJ = Convert.ToInt32(sdr["DCDJ"]);
                            child.DCDJMS = Convert.ToString(sdr["DCDJMS"]);
                            child.DCXH = Convert.ToInt32(sdr["DCXH"]);
                            child.DCXHMS = Convert.ToString(sdr["DCXHMS"]);
                            child.TPM = Convert.ToString(sdr["TPM"]);
                            child.SBCD = Convert.ToInt32(sdr["SBCD"]);
                            child.SBCDMS = Convert.ToString(sdr["SBCDMS"]);
                            child.REMARK = Convert.ToString(sdr["REMARK"]);
                            child.JLR = Convert.ToInt32(sdr["JLR"]);
                            child.JLRMS = Convert.ToString(sdr["JLRMS"]);
                            child.JLTIME = Convert.ToDateTime(sdr["JLTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                            child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                            child.NOBILL = Convert.ToString(sdr["NOBILL"]);
                            child.NOBILLMX = Convert.ToString(sdr["NOBILLMX"]);
                            child.WLLB = Convert.ToInt32(sdr["WLLB"]);
                            child.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                            child.UNITSNAME = Convert.ToString(sdr["UNITSNAME"]);
                            child.ERPNO = Convert.ToString(sdr["ERPNO"]);
                            child.SBZ = Convert.ToString(sdr["SBZ"]);
                            child.SIZE = Convert.ToInt32(sdr["SIZE"]);
                            child.SIZENAME = Convert.ToString(sdr["SIZENAME"]);
                            child.SYSCX = Convert.ToString(sdr["SYSCX"]);
                            child.SYCPGG = Convert.ToString(sdr["SYCPGG"]);
                            child.THGG = Convert.ToString(sdr["THGG"]);
                            child.DCSLBS = Convert.ToInt32(sdr["DCSLBS"]);
                            child.DCSLMBSL = Convert.ToInt32(sdr["DCSLMBSL"]);
                            child.DCSLYS = Convert.ToInt32(sdr["DCSLYS"]);
                            child.RQM = Convert.ToString(sdr["RQM"]);
                            //child.GDSL = Convert.ToDecimal(sdr["GDSL"]);
                            child.ZFDCLB = Convert.ToInt32(sdr["ZFDCLB"]);
                            child.ZFDCLBNAME = Convert.ToString(sdr["ZFDCLBNAME"]);
                            child.KCDDGC = Convert.ToString(sdr["KCDDGC"]);
                            child.KCDD = Convert.ToString(sdr["KCDD"]);
                            child.KCDDNAME = Convert.ToString(sdr["KCDDNAME"]);
                            child.CGBILL = Convert.ToString(sdr["CGBILL"]);
                            child.CGBILLMX = Convert.ToString(sdr["CGBILLMX"]);
                            child.CFTS = Convert.ToInt32(sdr["CFTS"]);
                            child.WLGROUP = Convert.ToString(sdr["WLGROUP"]);
                            child.WLGROUPNAME = Convert.ToString(sdr["WLGROUPNAME"]);
                            child.XDGX = Convert.ToInt32(sdr["XDGX"]);
                            child.XDGXNAME = Convert.ToString(sdr["XDGXNAME"]);
                            child.VDATU = Convert.ToString(sdr["VDATU"]);
                            child.SCDATEP = Convert.ToString(sdr["SCDATEP"]);
                            if (child.KSTIME == "1900-01-01 00:00:00")
                            {
                                child.KSTIME = "";
                            }
                            if (child.JSTIME == "1900-01-01 00:00:00")
                            {
                                child.JSTIME = "";
                            }
                            child.MID = Convert.ToString(sdr["MID"]);
                            child.JZ = Convert.ToDecimal(sdr["JZ"]);
                            child.CPTYPE = Convert.ToInt32(sdr["CPTYPE"]);
                            child.CPTYPENAME = Convert.ToString(sdr["CPTYPENAME"]);
                            child.WQH = Convert.ToString(sdr["WQH"]);
                            child.MFQCOLOR = Convert.ToInt32(sdr["MFQCOLOR"]);
                            child.MFQCOLORNAME = Convert.ToString(sdr["MFQCOLORNAME"]);
                            child.MOULD = Convert.ToString(sdr["MOULD"]);
                            child.RESDUESL = Convert.ToDecimal(sdr["RESDUESL"]);
                            child.CLPBDM = Convert.ToString(sdr["CLPBDM"]);
                            child.GLTMCOUNT = Convert.ToInt32(sdr["GLTMCOUNT"]);
                            child.FTM = Convert.ToString(sdr["FTM"]);
                            child.FPC = Convert.ToString(sdr["FPC"]);
                            child.JLTIME = Convert.ToString(sdr["JLTIMESTRING"]);
                            child_MES_TM_TMINFO_LIST.Add(child);
                        }
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "MES_TM_TMINFO_SELECT_LB");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_TM_TMINFO_KCHZ = child_MES_TM_TMINFO_KCHZ;
            rst.MES_TM_TMINFO_LIST = child_MES_TM_TMINFO_LIST;
            return rst;
        }
        public SELECT_MES_TM_TMINFO_BYTM SELECT_LB(MES_TM_TMINFO model)
        {
            SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_TM_TMINFO_LIST> child_MES_TM_TMINFO_LIST = new List<MES_TM_TMINFO_LIST>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@KCDDGC",model.KCDDGC),
                                       new SqlParameter("@KCDD",model.KCDD),
                                       new SqlParameter("@WLMS",model.WLMS),
                                       new SqlParameter("@PC",model.PC),
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@CPZTNAME",model.CPZTNAME),
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@MOULD",model.MOULD),
                                       new SqlParameter("@CLPBDM",model.CLPBDM),
                                       new SqlParameter("@SCDATES",model.SCDATES),
                                       new SqlParameter("@SCDATEE",model.SCDATEE),
                                       new SqlParameter("@TM",model.TM)
                                   };
                if (model.LB == 4)
                {
                    rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_SELECT_LB, parms);
                }
                else
                {
                    using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_LB, parms))
                    {
                        while (sdr.Read())
                        {
                            if (model.LB == 3)
                            {
                                MES_TM_TMINFO_LIST child = new MES_TM_TMINFO_LIST();
                                child.GC = Convert.ToString(sdr["GC"]);
                                child.GCDYMS = Convert.ToString(sdr["GCDYMS"]);
                                child.TM = Convert.ToString(sdr["TM"]);
                                child.TMLB = Convert.ToInt32(sdr["TMLB"]);
                                child.TMSX = Convert.ToInt32(sdr["TMSX"]);
                                child.SCDATE = Convert.ToString(sdr["SCDATE"]);
                                child.BC = Convert.ToInt32(sdr["BC"]);
                                child.BCMS = Convert.ToString(sdr["BCMS"]);
                                child.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                                child.GZZXMS = Convert.ToString(sdr["GZZXMS"]);
                                child.SBBH = Convert.ToString(sdr["SBBH"]);
                                child.SBHMS = Convert.ToString(sdr["SBHMS"]);
                                child.RWBH = Convert.ToString(sdr["RWBH"]);
                                child.WLH = Convert.ToString(sdr["WLH"]);
                                child.WLMS = Convert.ToString(sdr["WLMS"]);
                                child.PC = Convert.ToString(sdr["PC"]);
                                child.CLCJ = Convert.ToString(sdr["CLCJ"]);
                                child.GYLX = Convert.ToString(sdr["GYLX"]);
                                child.GYS = Convert.ToString(sdr["GYS"]);
                                child.GYSMS = Convert.ToString(sdr["GYSMS"]);
                                child.GYSPC = Convert.ToString(sdr["GYSPC"]);
                                child.CPZT = Convert.ToInt32(sdr["CPZT"]);
                                child.CPZTNAME = Convert.ToString(sdr["CPZTNAME"]);
                                child.PFDH = Convert.ToString(sdr["PFDH"]);
                                child.PLDH = Convert.ToString(sdr["PLDH"]);
                                child.TH = Convert.ToInt32(sdr["TH"]);
                                child.SL = Convert.ToDecimal(sdr["SL"]);
                                child.KSTIME = Convert.ToDateTime(sdr["KSTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                                child.JSTIME = Convert.ToDateTime(sdr["JSTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                                child.XFWLH = Convert.ToString(sdr["XFWLH"]);
                                child.XFCDNAME = Convert.ToString(sdr["XFCDNAME"]);
                                child.DCDJ = Convert.ToInt32(sdr["DCDJ"]);
                                child.DCDJMS = Convert.ToString(sdr["DCDJMS"]);
                                child.DCXH = Convert.ToInt32(sdr["DCXH"]);
                                child.DCXHMS = Convert.ToString(sdr["DCXHMS"]);
                                child.TPM = Convert.ToString(sdr["TPM"]);
                                child.SBCD = Convert.ToInt32(sdr["SBCD"]);
                                child.SBCDMS = Convert.ToString(sdr["SBCDMS"]);
                                child.REMARK = Convert.ToString(sdr["REMARK"]);
                                child.JLR = Convert.ToInt32(sdr["JLR"]);
                                child.JLRMS = Convert.ToString(sdr["JLRMS"]);
                                child.JLTIME = Convert.ToDateTime(sdr["JLTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                                child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                                child.NOBILL = Convert.ToString(sdr["NOBILL"]);
                                child.NOBILLMX = Convert.ToString(sdr["NOBILLMX"]);
                                child.WLLB = Convert.ToInt32(sdr["WLLB"]);
                                child.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                                child.UNITSNAME = Convert.ToString(sdr["UNITSNAME"]);
                                child.ERPNO = Convert.ToString(sdr["ERPNO"]);
                                child.SBZ = Convert.ToString(sdr["SBZ"]);
                                child.SIZE = Convert.ToInt32(sdr["SIZE"]);
                                child.SIZENAME = Convert.ToString(sdr["SIZENAME"]);
                                child.SYSCX = Convert.ToString(sdr["SYSCX"]);
                                child.SYCPGG = Convert.ToString(sdr["SYCPGG"]);
                                child.THGG = Convert.ToString(sdr["THGG"]);
                                child.DCSLBS = Convert.ToInt32(sdr["DCSLBS"]);
                                child.DCSLMBSL = Convert.ToInt32(sdr["DCSLMBSL"]);
                                child.DCSLYS = Convert.ToInt32(sdr["DCSLYS"]);
                                child.RQM = Convert.ToString(sdr["RQM"]);
                                //child.GDSL = Convert.ToDecimal(sdr["GDSL"]);
                                child.ZFDCLB = Convert.ToInt32(sdr["ZFDCLB"]);
                                child.ZFDCLBNAME = Convert.ToString(sdr["ZFDCLBNAME"]);
                                child.KCDDGC = Convert.ToString(sdr["KCDDGC"]);
                                child.KCDD = Convert.ToString(sdr["KCDD"]);
                                child.KCDDNAME = Convert.ToString(sdr["KCDDNAME"]);
                                child.CGBILL = Convert.ToString(sdr["CGBILL"]);
                                child.CGBILLMX = Convert.ToString(sdr["CGBILLMX"]);
                                child.CFTS = Convert.ToInt32(sdr["CFTS"]);
                                child.WLGROUP = Convert.ToString(sdr["WLGROUP"]);
                                child.WLGROUPNAME = Convert.ToString(sdr["WLGROUPNAME"]);
                                child.XDGX = Convert.ToInt32(sdr["XDGX"]);
                                child.XDGXNAME = Convert.ToString(sdr["XDGXNAME"]);
                                child.VDATU = Convert.ToString(sdr["VDATU"]);
                                child.SCDATEP = Convert.ToString(sdr["SCDATEP"]);
                                if (child.KSTIME == "1900-01-01 00:00:00")
                                {
                                    child.KSTIME = "";
                                }
                                if (child.JSTIME == "1900-01-01 00:00:00")
                                {
                                    child.JSTIME = "";
                                }
                                child.MID = Convert.ToString(sdr["MID"]);
                                child.JZ = Convert.ToDecimal(sdr["JZ"]);
                                child.CPTYPE = Convert.ToInt32(sdr["CPTYPE"]);
                                child.CPTYPENAME = Convert.ToString(sdr["CPTYPENAME"]);
                                child.WQH = Convert.ToString(sdr["WQH"]);
                                child.MFQCOLOR = Convert.ToInt32(sdr["MFQCOLOR"]);
                                child.MFQCOLORNAME = Convert.ToString(sdr["MFQCOLORNAME"]);
                                child.MOULD = Convert.ToString(sdr["MOULD"]);
                                child.RESDUESL = Convert.ToDecimal(sdr["RESDUESL"]);
                                child.CLPBDM = Convert.ToString(sdr["CLPBDM"]);
                                child.GLTMCOUNT = Convert.ToInt32(sdr["GLTMCOUNT"]);
                                child.FTM = Convert.ToString(sdr["FTM"]);
                                child.QJCOUNT = Convert.ToInt32(sdr["QJCOUNT"]);
                                child.FGCOUNT = Convert.ToInt32(sdr["FGCOUNT"]);
                                child_MES_TM_TMINFO_LIST.Add(child);
                            }
                        }
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "MES_TM_TMINFO_SELECT_LB");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_TM_TMINFO_LIST = child_MES_TM_TMINFO_LIST;
            return rst;
        }
    }
}

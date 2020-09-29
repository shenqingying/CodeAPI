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
    public class PD_SCRW : IPD_SCRW
    {
        const string SQL_SELECT = "MES_PD_SCRW_SELECT";
        const string SQL_SELECT_BY_ROLE = "MES_PD_SCRW_SELECT_BY_ROLE";
        const string SQL_SELECT_ZPGD = "MES_PD_SCRW_SELECT_ZPGD";
        const string SQL_DELETE = "MES_PD_SCRW_DELETE";
        const string SQL_INSERT = "MES_PD_SCRW_INSERT";
        const string SQL_SELECT_TMTL_LAST = "MES_PD_SCRW_SELECT_TMTL_LAST";
        const string SQL_UPDATE_RWQD_FJTL = "MES_PD_SCRW_UPDATE_RWQD_FJTL";
        const string SQL_UPDATE_RWQD_FJCC = "MES_PD_SCRW_UPDATE_RWQD_FJCC";
        const string SQL_DELETE_GZZX = "UPDATE MES_PD_SCRW SET ISDELETE=1 WHERE GC=@GC AND GZZXBH=@GZZXBH AND BC=@BC AND GDDH=@GDDH AND ZPRQ=@ZPRQ";
        //const string SQL_DELETE_GZZX = "MES_PD_SCRW_DELETE_GZZX";
        const string SQL_SELECT_BY_ALL = "SELECT COUNT(*) AS TMCOUNT FROM MES_PD_SCRW WHERE GC=@GC AND GZZXBH=@GZZXBH AND SBBH=@SBBH AND ZPRQ=@ZPRQ AND BC=@BC AND GDDH=@GDDH";
        const string SQL_UPDATE_ISDELETE = "UPDATE MES_PD_SCRW SET ISDELETE=0,SL=@SL WHERE GC=@GC AND GZZXBH=@GZZXBH AND SBBH=@SBBH AND ZPRQ=@ZPRQ AND BC=@BC AND GDDH=@GDDH";
        const string SQL_SELECT_ZXCCINFO = "MES_PD_SCRW_SELECT_ZXCCINFO";
        const string SQL_UPDATE_ZX_CC = "MES_PD_SCRW_UPDATE_ZX_CC";
        const string SQL_DELETE_ZXTL = "UPDATE MES_TM_TMINFO SET ISDELETE=1 WHERE TM=@TM";
        //const string SQL_UPDATE_SCRW = "UPDATE MES_PD_SCRW SET SL=@SL WHERE RWBH=@RWBH";
        const string SQL_UPDATE = "MES_PD_SCRW_UPDATE";
        const string SQL_SELECT_COUNT = "MES_PD_SCRW_SELECT_COUNT";
        const string SQL_INSERT_BY_FJPD = "MES_PD_SCRW_INSERT_BY_FJPD";
        const string SQL_SELECT_SUM = "MES_PD_SCRW_SELECT_SUM";
        const string SQL_SELECT_JDKB = "MES_SY_FJ_RWKB";
        const string SQL_UPDATE_ALL = "MES_PD_SCRW_UPDATE_ALL";
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        public SELECT_MES_PD_SCRW SELECT(MES_PD_SCRW model)
        {
            SELECT_MES_PD_SCRW rst = new SELECT_MES_PD_SCRW();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_PD_SCRW_LIST> child_MES_PD_SCRW_LIST = new List<MES_PD_SCRW_LIST>();
            try
            {
                SqlParameter[] parms = { 
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@RWBH",model.RWBH),
                                       new SqlParameter("@GDDH",model.GDDH),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@ZPRQ",model.ZPRQ),
                                       new SqlParameter("@BC",model.BC),
                                       new SqlParameter("@ERPNO",model.ERPNO),
                                       new SqlParameter("@ZPRQKS",model.ZPRQKS),
                                       new SqlParameter("@ZPRQJS",model.ZPRQJS),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@PFDH",model.PFDH),
                                       new SqlParameter("@PLDH",model.PLDH),
                                       new SqlParameter("@TH",model.TH),
                                       new SqlParameter("@RWLB",model.RWLB),
                                       new SqlParameter("@CXLB",model.CXLB)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_PD_SCRW_LIST child = new MES_PD_SCRW_LIST();
                        if (model.CXLB != 0)
                        {
                            child.GC = Convert.ToString(sdr["GC"]);
                            child.GDDH = Convert.ToString(sdr["GDDH"]);
                            child.ERPNO = Convert.ToString(sdr["ERPNO"]);
                            child.WLH = Convert.ToString(sdr["WLH"]);
                            child.WLMS = Convert.ToString(sdr["WLMS"]);
                            child.XFWLH = Convert.ToString(sdr["XFWLH"]);
                            child.XFPC = Convert.ToString(sdr["PC"]);
                            child.SL = Convert.ToDecimal(sdr["SL"]);
                            child.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                            child.XFCDNAME = Convert.ToString(sdr["XFWLMS"]);
                        }
                        else
                        {
                            child.GC = Convert.ToString(sdr["GC"]);
                            child.RWBH = Convert.ToString(sdr["RWBH"]);
                            child.RWLB = Convert.ToInt32(sdr["RWLB"]);
                            child.SBBH = Convert.ToString(sdr["SBBH"]);
                            child.SBH = Convert.ToString(sdr["SBH"]);
                            child.PX = Convert.ToInt32(sdr["PX"]);
                            child.ZPRQ = Convert.ToDateTime(sdr["ZPRQ"]).ToString("yyyy-MM-dd");
                            child.BC = Convert.ToInt32(sdr["BC"]);
                            child.BCMS = Convert.ToString(sdr["BCMS"]);
                            child.XFPC = Convert.ToString(sdr["PC"]);
                            child.PFDH = Convert.ToString(sdr["PFDH"]);
                            child.PLDH = Convert.ToString(sdr["PLDH"]);
                            child.TH = Convert.ToInt32(sdr["TH"]);
                            child.SL = Convert.ToDecimal(sdr["SL"]);
                            child.XFWLH = Convert.ToString(sdr["XFWLH"]);
                            child.XFCDNAME = Convert.ToString(sdr["XFCDNAME"]);
                            child.REMARK = Convert.ToString(sdr["REMARK"]);
                            child.JLR = Convert.ToInt32(sdr["JLR"]);
                            child.JLRMS = Convert.ToString(sdr["JLRMS"]);
                            child.JLTIME = Convert.ToDateTime(sdr["JLTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                            child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                            child.GDLB = Convert.ToInt32(sdr["GDLB"]);
                            child.GDDH = Convert.ToString(sdr["GDDH"]);
                            child.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                            child.GZZXNAME = Convert.ToString(sdr["GZZXNAME"]);
                            child.GC = Convert.ToString(sdr["GC"]);
                            child.WLH = Convert.ToString(sdr["WLH"]);
                            child.WLMS = Convert.ToString(sdr["WLMS"]);
                            child.KSDATE = Convert.ToDateTime(sdr["KSDATE"]).ToString("yyyy-MM-dd HH:mm:ss");
                            child.JSDATE = Convert.ToDateTime(sdr["JSDATE"]).ToString("yyyy-MM-dd HH:mm:ss");
                            child.GDSL = Convert.ToDecimal(sdr["GDSL"]);
                            child.UNITSID = Convert.ToInt32(sdr["UNITSID"]);
                            child.UNITSNAME = Convert.ToString(sdr["UNITSNAME"]);
                            child.ERPNO = Convert.ToString(sdr["ERPNO"]);
                            child.WLLB = Convert.ToInt32(sdr["WLLB"]);
                            child.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                            child.DCXH = Convert.ToInt32(sdr["DCXH"]);
                            child.DCXHNAME = Convert.ToString(sdr["DCXHNAME"]);
                            child.DCDJ = Convert.ToInt32(sdr["DCDJ"]);
                            child.DCDJNAME = Convert.ToString(sdr["DCDJNAME"]);
                            child.XFWLH = Convert.ToString(sdr["XFWLH"]);
                            child.TLSJ = Convert.ToDateTime(sdr["TLSJ"]).ToString("yyyy-MM-dd HH:mm");
                            child.CCSJ = Convert.ToDateTime(sdr["CCSJ"]).ToString("yyyy-MM-dd HH:mm");
                            child.ISOPEN = Convert.ToInt32(sdr["ISOPEN"]);
                            child.XSNOBILL = Convert.ToString(sdr["XSNOBILL"]);
                            child.XSNOBILLMX = Convert.ToString(sdr["XSNOBILLMX"]);
                            child.CHARG = Convert.ToString(sdr["CHARG"]);
                            child.BZCOUNT = Convert.ToInt32(sdr["BZCOUNT"]);
                            child.BZBS = Convert.ToInt32(sdr["BZBS"]);
                            child.GYSPC = Convert.ToString(sdr["GYSPC"]);
                            child.MAXVALUE = GET_NULLTOZERO(Convert.ToString(sdr["MAXVALUE"]));
                            child.MINVALUE = GET_NULLTOZERO(Convert.ToString(sdr["MINVALUE"]));
                            child.RQM = Convert.ToString(sdr["RQM"]);
                            child.XDGX = Convert.ToInt32(sdr["XDGX"]);
                            child.WLGROUP = Convert.ToString(sdr["WLGROUP"]);
                            child.WLGROUPNAME = Convert.ToString(sdr["WLGROUPNAME"]);
                            child.ISLEAVE = Convert.ToInt32(sdr["ISLEAVE"]);
                            if (child.RWLB == 1)
                            {
                                child.TLSJ = "";
                                child.CCSJ = "";
                            }
                            else if (child.RWLB == 2)
                            {
                                if (child.ISACTION == 0)
                                {
                                    child.TLSJ = "";
                                    child.CCSJ = "";
                                }
                                else if (child.ISACTION == 1)
                                {
                                    child.CCSJ = "";
                                }
                            }
                        }
                        child_MES_PD_SCRW_LIST.Add(child);
                    }
                }
                rst.MES_PD_SCRW_LIST = child_MES_PD_SCRW_LIST;
                if (child_MES_PD_SCRW_LIST.Count > 0)
                {
                    child_MES_RETURN.TYPE = "S";
                    child_MES_RETURN.MESSAGE = "";
                }
                else
                {
                    child_MES_RETURN.TYPE = "E";
                    child_MES_RETURN.MESSAGE = "无任务单数据！";
                }
                rst.MES_RETURN = child_MES_RETURN;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_SCRW_SELECT");
            }
            return rst;
        }

        public SELECT_MES_PD_SCRW SELECT_BY_ROLE(MES_PD_SCRW model)
        {
            SELECT_MES_PD_SCRW rst = new SELECT_MES_PD_SCRW();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_PD_SCRW_LIST> child_MES_PD_SCRW_LIST = new List<MES_PD_SCRW_LIST>();
            try
            {
                int tmcount = 0;
                int RWLB = 0;
                SqlParameter[] parms = { 
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@RWBH",model.RWBH),
                                       new SqlParameter("@GDDH",model.GDDH),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@ZPRQ",model.ZPRQ),
                                       new SqlParameter("@BC",model.BC),
                                       new SqlParameter("@ERPNO",model.ERPNO),
                                       new SqlParameter("@ZPRQKS",model.ZPRQKS),
                                       new SqlParameter("@ZPRQJS",model.ZPRQJS),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@PFDH",model.PFDH),
                                       new SqlParameter("@PLDH",model.PLDH),
                                       new SqlParameter("@TH",model.TH),
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@WLLBNAME",model.WLLBNAME),
                                       new SqlParameter("@WLLB",model.WLLB)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_BY_ROLE, parms))
                {
                    while (sdr.Read())
                    {
                        MES_PD_SCRW_LIST child = new MES_PD_SCRW_LIST();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.RWBH = Convert.ToString(sdr["RWBH"]);
                        child.RWLB = Convert.ToInt32(sdr["RWLB"]);
                        child.SBBH = Convert.ToString(sdr["SBBH"]);
                        child.SBH = Convert.ToString(sdr["SBH"]);
                        child.PX = Convert.ToInt32(sdr["PX"]);
                        child.ZPRQ = Convert.ToDateTime(sdr["ZPRQ"]).ToString("yyyy-MM-dd");
                        child.BC = Convert.ToInt32(sdr["BC"]);
                        child.BCMS = Convert.ToString(sdr["BCMS"]);
                        child.XFPC = Convert.ToString(sdr["PC"]);
                        child.PC = Convert.ToString(sdr["PC"]);
                        child.PFDH = Convert.ToString(sdr["PFDH"]);
                        child.PLDH = Convert.ToString(sdr["PLDH"]);
                        child.TH = Convert.ToInt32(sdr["TH"]);
                        child.SL = Convert.ToDecimal(sdr["SL"]);
                        child.XFWLH = Convert.ToString(sdr["XFWLH"]);
                        child.XFCDNAME = Convert.ToString(sdr["XFCDNAME"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.JLR = Convert.ToInt32(sdr["JLR"]);
                        child.JLRMS = Convert.ToString(sdr["JLRMS"]);
                        child.JLTIME = Convert.ToDateTime(sdr["JLTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.GDLB = Convert.ToInt32(sdr["GDLB"]);
                        child.GDDH = Convert.ToString(sdr["GDDH"]);
                        child.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        child.GZZXNAME = Convert.ToString(sdr["GZZXNAME"]);
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.WLMS = Convert.ToString(sdr["WLMS"]);
                        child.KSDATE = Convert.ToDateTime(sdr["KSDATE"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.JSDATE = Convert.ToDateTime(sdr["JSDATE"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.GDSL = Convert.ToDecimal(sdr["GDSL"]);
                        child.UNITSID = Convert.ToInt32(sdr["UNITSID"]);
                        child.UNITSNAME = Convert.ToString(sdr["UNITSNAME"]);
                        child.ERPNO = Convert.ToString(sdr["ERPNO"]);
                        child.WLLB = Convert.ToInt32(sdr["WLLB"]);
                        child.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        child.DCXH = Convert.ToInt32(sdr["DCXH"]);
                        child.DCXHNAME = Convert.ToString(sdr["DCXHNAME"]);
                        child.DCDJ = Convert.ToInt32(sdr["DCDJ"]);
                        child.DCDJNAME = Convert.ToString(sdr["DCDJNAME"]);
                        child.TLSJ = Convert.ToDateTime(sdr["TLSJ"]).ToString("yyyy-MM-dd HH:mm");
                        child.CCSJ = Convert.ToDateTime(sdr["CCSJ"]).ToString("yyyy-MM-dd HH:mm");
                        child.ISOPEN = Convert.ToInt32(sdr["ISOPEN"]);
                        child.XSNOBILL = Convert.ToString(sdr["XSNOBILL"]);
                        child.XSNOBILLMX = Convert.ToString(sdr["XSNOBILLMX"]);
                        child.CHARG = Convert.ToString(sdr["CHARG"]);
                        child.GCDYMS = Convert.ToString(sdr["GCDYMS"]);
                        child.BZCOUNT = Convert.ToInt32(sdr["BZCOUNT"]);
                        child.BZBS = Convert.ToInt32(sdr["BZBS"]);
                        child.GYSPC = Convert.ToString(sdr["GYSPC"]);
                        child.MAXVALUE = GET_NULLTOZERO(Convert.ToString(sdr["MAXVALUE"]));
                        child.MINVALUE = GET_NULLTOZERO(Convert.ToString(sdr["MINVALUE"]));
                        child.RQM = Convert.ToString(sdr["RQM"]);
                        child.XDGX = Convert.ToInt32(sdr["XDGX"]);
                        child.WLGROUP = Convert.ToString(sdr["WLGROUP"]);
                        child.WLGROUPNAME = Convert.ToString(sdr["WLGROUPNAME"]);
                        child.ISLEAVE = Convert.ToInt32(sdr["ISLEAVE"]);
                        if (child.RWLB == 1)
                        {
                            child.TLSJ = "";
                            child.CCSJ = "";
                        }
                        else if (child.RWLB == 2)
                        {
                            if (child.ISACTION == 0)
                            {
                                child.TLSJ = "";
                                child.CCSJ = "";
                            }
                            else if (child.ISACTION == 1)
                            {
                                child.CCSJ = "";
                            }
                        }
                        child_MES_PD_SCRW_LIST.Add(child);
                        if (child.ISACTION < 2)
                        {
                            tmcount = tmcount + 1;
                        }
                        RWLB = child.RWLB;
                    }
                }
                rst.MES_PD_SCRW_LIST = child_MES_PD_SCRW_LIST;
                if (child_MES_PD_SCRW_LIST.Count > 0)
                {
                    child_MES_RETURN.TYPE = "S";
                    child_MES_RETURN.MESSAGE = "";
                }
                else
                {
                    child_MES_RETURN.TYPE = "E";
                    child_MES_RETURN.MESSAGE = "无任务单数据！";
                }
                rst.MES_RETURN = child_MES_RETURN;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_SCRW_SELECT_BY_ROLE");
            }
            return rst;
        }

        public MES_RETURN DELETE(MES_PD_SCRW model)
        {
            MES_RETURN mr = new MES_RETURN();
            try
            {
                SqlParameter[] parms = { 
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@RWBH",model.RWBH)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DELETE, parms))
                {
                    while (sdr.Read())
                    {
                        mr.TYPE = Convert.ToString(sdr["TYPE"]);
                        mr.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_SCRW");
            }
            return mr;
        }

        public MES_RETURN INSERT(MES_PD_SCRW model)
        {
            MES_RETURN mr = new MES_RETURN();
            try
            {
                SqlParameter[] parms = { 
                                           new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GDDH",model.GDDH),
                                       new SqlParameter("@RWBH",model.RWBH),
                                       new SqlParameter("@RWLB",model.RWLB),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@PX",model.PX),
                                       new SqlParameter("@ZPRQ",model.ZPRQ),
                                       new SqlParameter("@BC",model.BC),
                                       new SqlParameter("@PC",model.PC),
                                       new SqlParameter("@PFDH",model.PFDH),
                                       new SqlParameter("@PLDH",model.PLDH),
                                       new SqlParameter("@TH",model.TH),
                                       new SqlParameter("@SL",model.SL),
                                       new SqlParameter("@XFWLH",model.XFWLH),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@JLR",model.JLR),
                                       new SqlParameter("@ISACTION",model.ISACTION)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms)) { }
                mr.TYPE = "S";
                mr.MESSAGE = "";
                mr.BH = model.RWBH;
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_SCRW");
            }
            return mr;
        }


        public SELECT_MES_PD_SCRW SELECT_ZPQD(MES_PD_SCRW model)
        {
            SELECT_MES_PD_SCRW rst = new SELECT_MES_PD_SCRW();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_PD_SCRW_LIST> child_MES_PD_SCRW_LIST = new List<MES_PD_SCRW_LIST>();
            try
            {
                SqlParameter[] parms = { 
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GDDH",model.GDDH),
                                       new SqlParameter("@ZPRQ",model.ZPRQ),
                                       new SqlParameter("@BC",model.BC),
                                       new SqlParameter("@SBFL",model.SBFL)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_ZPGD, parms))
                {
                    while (sdr.Read())
                    {
                        MES_PD_SCRW_LIST child = new MES_PD_SCRW_LIST();
                        child.GC = model.GC;
                        child.GDDH = model.GDDH;
                        child.RWBH = Convert.ToString(sdr["RWBH"]);
                        child.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        child.SBBH = Convert.ToString(sdr["SBBH"]);
                        child.SBH = Convert.ToString(sdr["SBH"]);
                        child.BC = model.BC;
                        child.BCMS = model.BCMS;
                        child.SL = Convert.ToDecimal(sdr["SL"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.WLMS = Convert.ToString(sdr["WLMS"]);
                        child.UNITSID = Convert.ToInt32(sdr["UNITSID"]);
                        child.UNITSNAME = Convert.ToString(sdr["UNITSNAME"]);
                        if (child.RWBH != "")
                        {
                            child.LAY_CHECKED = true;
                        }
                        else
                        {
                            child.LAY_CHECKED = false;
                        }
                        child.SCRWTLCOUNT = Convert.ToInt32(sdr["SCRWTLCOUNT"]);
                        child_MES_PD_SCRW_LIST.Add(child);
                    }
                }
                rst.MES_PD_SCRW_LIST = child_MES_PD_SCRW_LIST;
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
                rst.MES_RETURN = child_MES_RETURN;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_SCRW");
            }
            return rst;
        }


        public SELECT_MES_PD_SCRW SELECT_TM_TL_BYSB_LAST(MES_PD_SCRW model)
        {
            SELECT_MES_PD_SCRW rst = new SELECT_MES_PD_SCRW();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_PD_SCRW_LIST> rst_MES_PD_SCRW_LIST = new List<MES_PD_SCRW_LIST>();
            try
            {
                SqlParameter[] parms = { 
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@ZPRQ",model.ZPRQ),
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_TMTL_LAST, parms))
                {
                    while (sdr.Read())
                    {
                        MES_PD_SCRW_LIST child = new MES_PD_SCRW_LIST();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.GDDH = Convert.ToString(sdr["GDDH"]);
                        child.RWBH = Convert.ToString(sdr["RWBH"]);
                        child.RWLB = Convert.ToInt32(sdr["RWLB"]);
                        child.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        child.GZZXNAME = Convert.ToString(sdr["GZZXNAME"]);
                        child.SBBH = Convert.ToString(sdr["SBBH"]);
                        child.SBH = Convert.ToString(sdr["SBH"]);
                        child.PX = Convert.ToInt32(sdr["PX"]);
                        child.ZPRQ = Convert.ToDateTime(sdr["ZPRQ"]).ToString("yyyy-MM-dd");
                        child.BC = Convert.ToInt32(sdr["BC"]);
                        child.BCMS = Convert.ToString(sdr["BCMS"]);
                        child.PC = Convert.ToString(sdr["PC"]);
                        child.PFDH = Convert.ToString(sdr["PFDH"]);
                        child.PLDH = Convert.ToString(sdr["PLDH"]);
                        child.TH = Convert.ToInt32(sdr["TH"]);
                        child.SL = Convert.ToDecimal(sdr["SL"]);
                        child.XFWLH = Convert.ToString(sdr["XFWLH"]);
                        child.XFCDNAME = Convert.ToString(sdr["XFCDNAME"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.JLR = Convert.ToInt32(sdr["JLR"]);
                        child.JLRMS = Convert.ToString(sdr["JLRMS"]);
                        child.JLTIME = Convert.ToDateTime(sdr["JLTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.GDLB = Convert.ToInt32(sdr["GDLB"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.WLMS = Convert.ToString(sdr["WLMS"]);
                        child.KSDATE = Convert.ToDateTime(sdr["KSDATE"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.JSDATE = Convert.ToDateTime(sdr["JSDATE"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.GDSL = Convert.ToDecimal(sdr["GDSL"]);
                        child.UNITSID = Convert.ToInt32(sdr["UNITSID"]);
                        child.UNITSNAME = Convert.ToString(sdr["UNITSNAME"]);
                        child.ERPNO = Convert.ToString(sdr["ERPNO"]);
                        child.WLLB = Convert.ToInt32(sdr["WLLB"]);
                        child.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        child.DCXH = Convert.ToInt32(sdr["DCXH"]);
                        child.DCXHNAME = Convert.ToString(sdr["DCXHNAME"]);
                        child.DCDJ = Convert.ToInt32(sdr["DCDJ"]);
                        child.DCDJNAME = Convert.ToString(sdr["DCDJNAME"]);
                        child.XFPC = Convert.ToString(sdr["PC"]);
                        child.XFWLH = Convert.ToString(sdr["XFWLH"]);
                        child.TLSJ = Convert.ToDateTime(sdr["TLSJ"]).ToString("yyyy-MM-dd HH:mm");
                        child.CCSJ = Convert.ToDateTime(sdr["CCSJ"]).ToString("yyyy-MM-dd HH:mm");
                        child.ISOPEN = Convert.ToInt32(sdr["ISOPEN"]);
                        child.XSNOBILL = Convert.ToString(sdr["XSNOBILL"]);
                        child.XSNOBILLMX = Convert.ToString(sdr["XSNOBILLMX"]);
                        child.CHARG = Convert.ToString(sdr["CHARG"]);
                        child.BZCOUNT = Convert.ToInt32(sdr["BZCOUNT"]);
                        child.BZBS = Convert.ToInt32(sdr["BZBS"]);
                        child.GYSPC = Convert.ToString(sdr["GYSPC"]);
                        child.MAXVALUE = GET_NULLTOZERO(Convert.ToString(sdr["MAXVALUE"]));
                        child.MINVALUE = GET_NULLTOZERO(Convert.ToString(sdr["MINVALUE"]));
                        child.RQM = Convert.ToString(sdr["RQM"]);
                        child.XDGX = Convert.ToInt32(sdr["XDGX"]);
                        child.WLGROUP = Convert.ToString(sdr["WLGROUP"]);
                        child.WLGROUPNAME = Convert.ToString(sdr["WLGROUPNAME"]);
                        child.ISLEAVE = Convert.ToInt32(sdr["ISLEAVE"]);
                        rst_MES_PD_SCRW_LIST.Add(child);
                        child_MES_RETURN.TYPE = "S";
                        child_MES_RETURN.MESSAGE = "";
                    }
                }
                if (child_MES_RETURN.TYPE != "S")
                {
                    child_MES_RETURN.TYPE = "E";
                }
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_SCRW");
            }
            rst.MES_PD_SCRW_LIST = rst_MES_PD_SCRW_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }


        public MES_RETURN UPDATE_RWQD_FJTL(MES_PD_SCRW model)
        {
            MES_RETURN mr = new MES_RETURN();
            try
            {
                DateTime dt = Convert.ToDateTime(model.TLSJ);
                model.TLSJ = dt.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch
            {
                mr.TYPE = "E";
                mr.MESSAGE = "投料时间格式有误！";
                return mr;
            }
            try
            {
                SqlParameter[] parms = { 
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@RWBH",model.RWBH),
                                       new SqlParameter("@TLSJ",model.TLSJ)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE_RWQD_FJTL, parms))
                {
                    while (sdr.Read())
                    {
                        mr.TYPE = Convert.ToString(sdr["TYPE"]);
                        mr.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_SCRW");
            }
            return mr;
        }

        public MES_RETURN UPDATE_RWQD_FJCC(MES_PD_SCRW model)
        {
            MES_RETURN mr = new MES_RETURN();
            try
            {
                DateTime dt = Convert.ToDateTime(model.CCSJ);
                model.CCSJ = dt.ToString("yyyy-MM-dd HH:mm:ss");
                dt = Convert.ToDateTime(model.TLSJ);
                model.TLSJ = dt.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch
            {
                mr.TYPE = "E";
                mr.MESSAGE = "时间格式有误！";
                return mr;
            }
            try
            {
                SqlParameter[] parms = { 
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@RWBH",model.RWBH),
                                       new SqlParameter("@CCSJ",model.CCSJ),
                                       new SqlParameter("@TLSJ",model.TLSJ)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE_RWQD_FJCC, parms))
                {
                    while (sdr.Read())
                    {
                        mr.TYPE = Convert.ToString(sdr["TYPE"]);
                        mr.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_SCRW");
            }
            return mr;
        }


        public MES_RETURN DELETE_GZZX(string GC, string GZZXBH, int BC, string GDDH, string ZPRQ)
        {
            MES_RETURN mr = new MES_RETURN();
            try
            {
                SqlParameter[] parms = { 
                                       new SqlParameter("@GC",GC),
                                       new SqlParameter("@GZZXBH",GZZXBH),
                                       new SqlParameter("@BC",BC),
                                       new SqlParameter("@GDDH",GDDH),
                                       new SqlParameter("@ZPRQ",ZPRQ)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_DELETE_GZZX, parms)) { }
                mr.TYPE = "S";
                mr.MESSAGE = "";
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_SCRW");
            }
            return mr;
        }


        public MES_RETURN SELECT_BY_ALL(string GC, string GZZXBH, string SBBH, string ZPRQ, int BC, string GDDH)
        {
            MES_RETURN mr = new MES_RETURN();
            try
            {
                SqlParameter[] parms = { 
                                       new SqlParameter("@GC",GC),
                                       new SqlParameter("@GZZXBH",GZZXBH),
                                       new SqlParameter("@SBBH",SBBH),
                                       new SqlParameter("@ZPRQ",ZPRQ),
                                       new SqlParameter("@BC",BC),
                                       new SqlParameter("@GDDH",GDDH)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT_BY_ALL, parms))
                {
                    while (sdr.Read())
                    {
                        mr.TID = Convert.ToInt32(sdr["TMCOUNT"]);
                    }
                }
                mr.TYPE = "S";
                mr.MESSAGE = "";
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_SCRW");
            }
            return mr;
        }


        public MES_RETURN UPDATE_ISDELETE(string GC, string GZZXBH, string SBBH, string ZPRQ, int BC, string GDDH, decimal SL)
        {
            MES_RETURN mr = new MES_RETURN();
            try
            {
                SqlParameter[] parms = { 
                                       new SqlParameter("@GC",GC),
                                       new SqlParameter("@GZZXBH",GZZXBH),
                                       new SqlParameter("@SBBH",SBBH),
                                       new SqlParameter("@ZPRQ",ZPRQ),
                                       new SqlParameter("@BC",BC),
                                       new SqlParameter("@GDDH",GDDH),
                                       new SqlParameter("@SL",SL)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_UPDATE_ISDELETE, parms)) { }
                mr.TYPE = "S";
                mr.MESSAGE = "";
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_SCRW");
            }
            return mr;
        }
        public MES_PD_SCRW_CCTH SELECT_ZXCCINFO(string RWBH, int BC, int LB)
        {
            MES_PD_SCRW_CCTH rst = new MES_PD_SCRW_CCTH();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = { 
                                       new SqlParameter("@RWBH",RWBH),
                                       new SqlParameter("@LB",LB),
                                       new SqlParameter("@BC",BC)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_ZXCCINFO, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TH = Convert.ToInt32(sdr["TH"]);
                        rst.KSTIME = Convert.ToDateTime(sdr["KSTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        rst.JSTIME = Convert.ToDateTime(sdr["JSTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child_MES_RETURN.TYPE = Convert.ToString(sdr["TYPE"]);
                        child_MES_RETURN.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_SCRW");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }

        public MES_RETURN UPDATE_ZX_CC(MES_PD_SCRW_ZXCC_INSERT model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = { 
                                       new SqlParameter("@RWBH",model.RWBH),
                                       new SqlParameter("@TH",model.TH),
                                       new SqlParameter("@TLSJ",model.KSTIME),
                                       new SqlParameter("@CCSJ",model.JSTIME),
                                       new SqlParameter("@BC",model.BC),
                                       new SqlParameter("@LB",LB)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE_ZX_CC, parms))
                {
                }
                rst.TYPE = "S";
                rst.MESSAGE = "";
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_SCRW");
            }
            return rst;
        }

        public MES_RETURN UPDATE_ALL(MES_PD_SCRW_UPDATE_IN model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = { 
                                       new SqlParameter("@RWBH",model.RWBH),
                                       new SqlParameter("@ISLEAVE",model.ISLEAVE),
                                       new SqlParameter("@LB",LB)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE_ALL, parms))
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_SCRW");
            }
            return rst;
        }


        public MES_RETURN DELETE_ZXCC(string TM)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = { 
                                       new SqlParameter("@TM",TM)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_DELETE_ZXTL, parms))
                {
                }
                rst.TYPE = "S";
                rst.MESSAGE = "";
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_SCRW");
            }
            return rst;
        }


        public MES_RETURN UPDATE_SCRW(MES_PD_SCRW model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = { 
                                       new SqlParameter("@RWBH",model.RWBH),
                                       new SqlParameter("@SL",model.SL),
                                       new SqlParameter("@REMARK",model.REMARK)
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
                //throw new ApplicationException(e.Message);
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_SCRW");
            }
            return rst;
        }

        //public MES_RETURN SELECT_COUNT_BY_ERPNO(MES_PD_SCRW_GET_BY_ERPNO model)
        //{
        //    MES_RETURN rst = new MES_RETURN();
        //    try
        //    {
        //        SqlParameter[] parms = { 
        //                               new SqlParameter("@ERPNO",model.ERPNO),
        //                               new SqlParameter("@GC",model.GC),
        //                               new SqlParameter("@GZZXBH",model.GZZXBH),
        //                               new SqlParameter("@SBBH",model.SBBH)
        //                           };

        //        using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_UPDATE_SCRW, parms))
        //        {

        //        }
        //        rst.TYPE = "S";
        //        rst.MESSAGE = "";
        //    }
        //    catch (Exception e)
        //    {
        //        //throw new ApplicationException(e.Message);
        //        rst.TYPE = "E";
        //        rst.MESSAGE = e.Message;
        //        SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_SCRW");
        //    }
        //    return rst;
        //}

        public MES_RETURN SELECT_COUNT(MES_PD_SCRW model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = { 
                                       new SqlParameter("@ERPNO",model.ERPNO),
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@ZPRQ",model.ZPRQ)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_COUNT, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TID = Convert.ToInt32(sdr["RWCOUNT"]);
                    }
                }
                rst.TYPE = "S";
                rst.MESSAGE = "";
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_SCRW");
            }
            return rst;
        }


        public MES_RETURN INSERT_BY_FJPD(MES_PD_SCRW model)
        {
            MES_RETURN mr = new MES_RETURN();
            try
            {
                SqlParameter[] parms = { 
                                           new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GDDH",model.GDDH),
                                       new SqlParameter("@RWBH",model.RWBH),
                                       new SqlParameter("@RWLB",model.RWLB),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@PX",model.PX),
                                       new SqlParameter("@ZPRQ",model.ZPRQ),
                                       new SqlParameter("@BC",model.BC),
                                       new SqlParameter("@PC",model.PC),
                                       new SqlParameter("@PFLB",model.PFLB),
                                       new SqlParameter("@PFDH",model.PFDH),
                                       new SqlParameter("@PLDH",model.PLDH),
                                       new SqlParameter("@TH",model.TH),
                                       new SqlParameter("@SL",model.SL),
                                       new SqlParameter("@XFWLH",model.XFWLH),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@JLR",model.JLR),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@GYSPC",model.GYSPC)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT_BY_FJPD, parms))
                {
                    while (sdr.Read())
                    {
                        mr.TYPE = Convert.ToString(sdr["TYPE"]);
                        mr.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_SCRW");
            }
            return mr;
        }
        public MES_PD_SCRW_SUM_SELECT SELECT_SUM(MES_PD_SCRW_SUM_LIST model)
        {
            MES_PD_SCRW_SUM_SELECT res = new MES_PD_SCRW_SUM_SELECT();
            MES_RETURN mr = new MES_RETURN();
            List<MES_PD_SCRW_SUM_LIST> nodes = new List<MES_PD_SCRW_SUM_LIST>();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@GC",model.GC),
                                           new SqlParameter("@GZZXBH",model.GZZXBH),
                                           new SqlParameter("@ZPRQKS",model.ZPRQKS),
                                           new SqlParameter("@ZPRQJS",model.ZPRQJS)
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_SUM, parms))
                {
                    while (sdr.Read())
                    {
                        MES_PD_SCRW_SUM_LIST node = new MES_PD_SCRW_SUM_LIST();
                        node.PFDH = Convert.ToString(sdr["PFDH"]);
                        node.COUNT = Convert.ToInt32(sdr["COUNT1"]);
                        node.REMARK = Convert.ToString(sdr["REMARK"]);
                        nodes.Add(node);
                    }
                }
                res.MES_PD_SCRW_SUM_LIST = nodes;
                if (nodes.Count == 0)
                {
                    mr.TYPE = "E";
                    mr.MESSAGE = "系统无数据";
                }
                else
                {
                    mr.TYPE = "S";
                    mr.MESSAGE = "";
                }

                res.MES_RETURN = mr;

            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_SCRW");
                res.MES_RETURN = mr;
            }
            return res;
        }

        public MES_SY_FJ_RWKB_SELECT SELECT_JDKB(MES_SY_FJ_RWKB model)
        {
            MES_SY_FJ_RWKB_SELECT rst = new MES_SY_FJ_RWKB_SELECT();
            List<MES_SY_FJ_RWKB> child_MES_SY_FJ_RWKB = new List<MES_SY_FJ_RWKB>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = { 
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@PFDH",model.PFDH),
                                       new SqlParameter("@ZPRQ",model.ZPRQ)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_JDKB, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_FJ_RWKB child = new MES_SY_FJ_RWKB();
                        child.SBBH = Convert.ToString(sdr["SBBH"]);
                        child.SBH = Convert.ToString(sdr["SBH"]);
                        child.PFDH = Convert.ToString(sdr["PFDH"]);
                        child.ALLSL = Convert.ToInt32(sdr["ALLSL"]);
                        child.WCSL = Convert.ToInt32(sdr["WCSL"]);
                        child.ZPRQ = Convert.ToString(sdr["ZPRQ"]);
                        child.TH = Convert.ToInt32(sdr["TH"]);
                        child_MES_SY_FJ_RWKB.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                rst.MES_SY_FJ_RWKB = child_MES_SY_FJ_RWKB;
                rst.MES_RETURN = child_MES_RETURN;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_FJ_RWKB");
            }
            return rst;

        }

        //public SELECT_MES_PD_SCRW SELECT_FJ_USE(MES_PD_SCRW_SELECT_FJ_USE_IN model)
        //{
        //    SELECT_MES_PD_SCRW rst = new SELECT_MES_PD_SCRW();
        //    MES_RETURN child_MES_RETURN = new MES_RETURN();
        //    List<MES_PD_SCRW_LIST> child_MES_PD_SCRW_LIST = new List<MES_PD_SCRW_LIST>();
        //    try
        //    {
        //        SqlParameter[] parms = { 
        //                               new SqlParameter("@GC",model.GC),
        //                               new SqlParameter("@GZZXBH",model.GZZXBH),
        //                               new SqlParameter("@ZPRQ",model.ZPRQ),
        //                               new SqlParameter("@GZZXBH",model.GZZXBH),
        //                               new SqlParameter("@ZPRQS",model.ZPRQS),
        //                               new SqlParameter("@ZPRQ",model.ZPRQ),
        //                               new SqlParameter("@BC",model.BC),
        //                               new SqlParameter("@ERPNO",model.ERPNO),
        //                               new SqlParameter("@ZPRQKS",model.ZPRQKS),
        //                               new SqlParameter("@ZPRQJS",model.ZPRQJS),
        //                               new SqlParameter("@WLH",model.WLH),
        //                               new SqlParameter("@PFDH",model.PFDH),
        //                               new SqlParameter("@PLDH",model.PLDH),
        //                               new SqlParameter("@TH",model.TH),
        //                               new SqlParameter("@RWLB",model.RWLB)
        //                           };
        //        using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
        //        {
        //            while (sdr.Read())
        //            {
        //                MES_PD_SCRW_LIST child = new MES_PD_SCRW_LIST();
        //                child.GC = Convert.ToString(sdr["GC"]);
        //                child.RWBH = Convert.ToString(sdr["RWBH"]);
        //                child.RWLB = Convert.ToInt32(sdr["RWLB"]);
        //                child.SBBH = Convert.ToString(sdr["SBBH"]);
        //                child.SBH = Convert.ToString(sdr["SBH"]);
        //                child.PX = Convert.ToInt32(sdr["PX"]);
        //                child.ZPRQ = Convert.ToDateTime(sdr["ZPRQ"]).ToString("yyyy-MM-dd");
        //                child.BC = Convert.ToInt32(sdr["BC"]);
        //                child.BCMS = Convert.ToString(sdr["BCMS"]);
        //                child.XFPC = Convert.ToString(sdr["PC"]);
        //                child.PFDH = Convert.ToString(sdr["PFDH"]);
        //                child.PLDH = Convert.ToString(sdr["PLDH"]);
        //                child.TH = Convert.ToInt32(sdr["TH"]);
        //                child.SL = Convert.ToDecimal(sdr["SL"]);
        //                child.XFWLH = Convert.ToString(sdr["XFWLH"]);
        //                child.XFCDNAME = Convert.ToString(sdr["XFCDNAME"]);
        //                child.REMARK = Convert.ToString(sdr["REMARK"]);
        //                child.JLR = Convert.ToInt32(sdr["JLR"]);
        //                child.JLRMS = Convert.ToString(sdr["JLRMS"]);
        //                child.JLTIME = Convert.ToDateTime(sdr["JLTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
        //                child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
        //                child.GDLB = Convert.ToInt32(sdr["GDLB"]);
        //                child.GDDH = Convert.ToString(sdr["GDDH"]);
        //                child.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
        //                child.GZZXNAME = Convert.ToString(sdr["GZZXNAME"]);
        //                child.GC = Convert.ToString(sdr["GC"]);
        //                child.WLH = Convert.ToString(sdr["WLH"]);
        //                child.WLMS = Convert.ToString(sdr["WLMS"]);
        //                child.KSDATE = Convert.ToDateTime(sdr["KSDATE"]).ToString("yyyy-MM-dd HH:mm:ss");
        //                child.JSDATE = Convert.ToDateTime(sdr["JSDATE"]).ToString("yyyy-MM-dd HH:mm:ss");
        //                child.GDSL = Convert.ToDecimal(sdr["GDSL"]);
        //                child.UNITSID = Convert.ToInt32(sdr["UNITSID"]);
        //                child.UNITSNAME = Convert.ToString(sdr["UNITSNAME"]);
        //                child.ERPNO = Convert.ToString(sdr["ERPNO"]);
        //                child.WLLB = Convert.ToInt32(sdr["WLLB"]);
        //                child.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
        //                child.DCXH = Convert.ToInt32(sdr["DCXH"]);
        //                child.DCXHNAME = Convert.ToString(sdr["DCXHNAME"]);
        //                child.DCDJ = Convert.ToInt32(sdr["DCDJ"]);
        //                child.DCDJNAME = Convert.ToString(sdr["DCDJNAME"]);
        //                child.XFWLH = Convert.ToString(sdr["XFWLH"]);
        //                child.TLSJ = Convert.ToDateTime(sdr["TLSJ"]).ToString("yyyy-MM-dd HH:mm");
        //                child.CCSJ = Convert.ToDateTime(sdr["CCSJ"]).ToString("yyyy-MM-dd HH:mm");
        //                child.ISOPEN = Convert.ToInt32(sdr["ISOPEN"]);
        //                child.XSNOBILL = Convert.ToString(sdr["XSNOBILL"]);
        //                child.XSNOBILLMX = Convert.ToString(sdr["XSNOBILLMX"]);
        //                child.CHARG = Convert.ToString(sdr["CHARG"]);
        //                child.BZCOUNT = Convert.ToInt32(sdr["BZCOUNT"]);
        //                child.GYSPC = Convert.ToString(sdr["GYSPC"]);
        //                if (child.RWLB == 1)
        //                {
        //                    child.TLSJ = "";
        //                    child.CCSJ = "";
        //                }
        //                else if (child.RWLB == 2)
        //                {
        //                    if (child.ISACTION == 0)
        //                    {
        //                        child.TLSJ = "";
        //                        child.CCSJ = "";
        //                    }
        //                    else if (child.ISACTION == 1)
        //                    {
        //                        child.CCSJ = "";
        //                    }
        //                }
        //                child_MES_PD_SCRW_LIST.Add(child);
        //            }
        //        }
        //        rst.MES_PD_SCRW_LIST = child_MES_PD_SCRW_LIST;
        //        if (child_MES_PD_SCRW_LIST.Count > 0)
        //        {
        //            child_MES_RETURN.TYPE = "S";
        //            child_MES_RETURN.MESSAGE = "";
        //        }
        //        else
        //        {
        //            child_MES_RETURN.TYPE = "E";
        //            child_MES_RETURN.MESSAGE = "没有查询到数据！";
        //        }
        //        rst.MES_RETURN = child_MES_RETURN;
        //    }
        //    catch (Exception e)
        //    {
        //        child_MES_RETURN.TYPE = "E";
        //        child_MES_RETURN.MESSAGE = e.Message;
        //        rst.MES_RETURN = child_MES_RETURN;
        //        SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_SCRW_SELECT");
        //    }
        //    return rst;
        //}
        public string GET_NULLTOZERO(string values)
        {
            if (values == "")
            {
                return "0";
            }
            else
            {
                return values;
            }
        }
    }
}

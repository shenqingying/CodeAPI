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
    public class PD_GD : IPD_GD
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "MES_PD_GD_INSERT";
        const string SQL_SELECT = "MES_PD_GD_SELECT";
        //const string SQL_SELECT_SCRW_ALL = "MES_PD_GD_SELECT_SCRW_ALL";
        const string SQL_UPDATE = "MES_PD_GD_UPDATE";
        const string SQL_UPDATE_ALL = "MES_PD_GD_UPDATE_ALL";
        const string SQL_DELETE = "MES_PD_GD_DELETE";
        const string SQL_DELETE_BY_ERPNO = "UPDATE MES_PD_GD SET ISDELETE =1 WHERE GC=@GC AND ERPNO=@ERPNO";
        const string SQL_SELECT_ERPNO_COUNT = "SELECT GDDH,ISOPEN FROM  MES_PD_GD WHERE GC=@GC AND ERPNO=@ERPNO AND ISDELETE=0";
        const string SQL_SELECT_BY_PFDH = "MES_PD_GD_SELECT_BY_PFDH";
        const string SQL_SELECT_BY_STAFFID = "MES_PD_GD_SELECT_BY_STAFFID";
        const string SQL_DELETE_ALL = "MES_PD_GD_DELETE_ALL";
        const string SQL_SELECT_GDJD = "MES_PD_GD_SELECT_GDJD";

        public const string SQL_BOM_SYNC_INSERT = "MES_PD_GD_BOM_SYNC_INSERT";
        public const string SQL_BOM_SYNC_SELECT = "MES_PD_GD_BOM_SYNC_SELECT";
        public const string SQL_BOM_SYNC_UPDATE = "MES_PD_GD_BOM_SYNC_UPDATE";

        private const string SQL_INSERT_GD_SYNC = "MES_PD_GD_SYNC_INSERT";
        private const string SQL_SELECT_GD_SYNC = "MES_PD_GD_SYNC_SELECT";
        private const string SQL_UPDATE_GD_SYNC = "MES_PD_GD_SYNC_UPDATE";

        private const string SQL_INSERT_GD_GYLX_SYNC = "MES_PD_GD_GYLX_SYNC_INSERT";
        public MES_RETURN INSERT(MES_PD_GD model)
        {
            MES_RETURN mr = new MES_RETURN();
            try
            {
                SqlParameter[] parms = { 
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GDDH",model.GDDH),
                                       new SqlParameter("@GDLB",model.GDLB),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@WLMS",model.WLMS),
                                       new SqlParameter("@KSDATE",model.KSDATE),
                                       new SqlParameter("@JSDATE",model.JSDATE),
                                       new SqlParameter("@SL",model.SL),
                                       new SqlParameter("@UNITSID",model.UNITSID),
                                       new SqlParameter("@UNITSNAME",model.UNITSNAME),
                                       new SqlParameter("@ERPNO",model.ERPNO),
                                       new SqlParameter("@WLGROUP",model.WLGROUP),
                                       new SqlParameter("@WLGROUPNAME",model.WLGROUPNAME),
                                       new SqlParameter("@ISOPEN",model.ISOPEN),
                                       new SqlParameter("@WLLB",model.WLLB),
                                       new SqlParameter("@WLLBNAME",model.WLLBNAME),
                                       new SqlParameter("@DCXH",model.DCXH),
                                       new SqlParameter("@DCXHNAME",model.DCXHNAME),
                                       new SqlParameter("@DCDJ",model.DCDJ),
                                       new SqlParameter("@DCDJNAME",model.DCDJNAME),
                                       new SqlParameter("@XSNOBILL",model.XSNOBILL),
                                       new SqlParameter("@XSNOBILLMX",model.XSNOBILLMX),
                                       new SqlParameter("@JLR",model.JLR),
                                       new SqlParameter("@CHARG",model.CHARG),
                                       new SqlParameter("@VDATU",model.VDATU)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_GD_INSERT");
            }
            return mr;
        }

        public SELECT_MES_PD_GD SELECT(MES_PD_GD model)
        {
            SELECT_MES_PD_GD rst = new SELECT_MES_PD_GD();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_PD_GD_LIST> child_MES_PD_GD_LIST = new List<MES_PD_GD_LIST>();
            try
            {
                SqlParameter[] parms = { 
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GDLB",model.GDLB),
                                       new SqlParameter("@GDDH",model.GDDH),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@KSDATE",model.KSDATE),
                                       new SqlParameter("@JSDATE",model.JSDATE),
                                       new SqlParameter("@ERPNO",model.ERPNO),
                                       new SqlParameter("@WLGROUP",model.WLGROUP),
                                       new SqlParameter("@WLLB",model.WLLB),
                                       new SqlParameter("@WLLBNAME",model.WLLBNAME),
                                       new SqlParameter("@PFLB",model.PFLB),
                                       new SqlParameter("@PFDH",model.PFDH)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_PD_GD_LIST child = new MES_PD_GD_LIST();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.GDLB = Convert.ToInt32(sdr["GDLB"]);
                        child.GDDH = Convert.ToString(sdr["GDDH"]);
                        child.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        child.GZZXNAME = Convert.ToString(sdr["GZZXNAME"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.WLMS = Convert.ToString(sdr["WLMS"]);
                        child.KSDATE = Convert.ToDateTime(sdr["KSDATE"]).ToString("yyyy-MM-dd");
                        child.JSDATE = Convert.ToDateTime(sdr["JSDATE"]).ToString("yyyy-MM-dd");
                        child.ISACTION = Convert.ToBoolean(sdr["ISACTION"]);
                        child.SL = Convert.ToDecimal(sdr["SL"]);
                        child.UNITSID = Convert.ToInt32(sdr["UNITSID"]);
                        child.UNITSNAME = Convert.ToString(sdr["UNITSNAME"]);
                        child.ERPNO = Convert.ToString(sdr["ERPNO"]);
                        child.WLGROUP = Convert.ToString(sdr["WLGROUP"]);
                        child.ISOPEN = Convert.ToInt32(sdr["ISOPEN"]);
                        child.GDPDSL = Convert.ToDecimal(sdr["GDPDSL"]);
                        child.GDWPDSL = child.SL - child.GDPDSL;
                        child.YPRWDH = Convert.ToString(sdr["YPRWDH"]);
                        child.CHARG = Convert.ToString(sdr["CHARG"]);
                        child.WLLB = Convert.ToInt32(sdr["WLLB"]);
                        child.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        if (child.GDWPDSL < 0)
                        {
                            child.GDWPDSL = 0;
                        }
                        if (child.YPRWDH == "")
                        {
                            child.ISPD = "未排单";
                        }
                        else
                        {
                            child.ISPD = "已排单";
                        }
                        child_MES_PD_GD_LIST.Add(child);
                    }
                }
                rst.MES_PD_GD_LIST = child_MES_PD_GD_LIST;
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
                rst.MES_RETURN = child_MES_RETURN;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_GD_SELECT");
            }
            return rst;
        }



        public MES_RETURN UPDATE(MES_PD_GD model)
        {
            MES_RETURN mr = new MES_RETURN();
            try
            {
                SqlParameter[] parms = { 
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GDDH",model.GDDH),
                                       new SqlParameter("@KSDATE",model.KSDATE),
                                       new SqlParameter("@JSDATE",model.JSDATE),
                                       new SqlParameter("@SL",model.SL),
                                       new SqlParameter("@ISOPEN",model.ISOPEN),
                                       new SqlParameter("@JLR",model.JLR),
                                       new SqlParameter("@CHARG",model.CHARG)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE, parms)) { }
                mr.TYPE = "S";
                mr.MESSAGE = "";
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_GD_UPDATE");
            }
            return mr;
        }

        public MES_RETURN UPDATE_ALL(MES_PD_GD model)
        {
            MES_RETURN mr = new MES_RETURN();
            try
            {
                SqlParameter[] parms = { 
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GDDH",model.GDDH),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@WLMS",model.WLMS),
                                       new SqlParameter("@KSDATE",model.KSDATE),
                                       new SqlParameter("@JSDATE",model.JSDATE),
                                       new SqlParameter("@SL",model.SL),
                                       new SqlParameter("@ISOPEN",model.ISOPEN),
                                       new SqlParameter("@UNITSNAME",model.UNITSNAME),
                                       new SqlParameter("@WLGROUP",model.WLGROUP),
                                       new SqlParameter("@WLGROUPNAME",model.WLGROUPNAME),
                                       new SqlParameter("@WLLBNAME",model.WLLBNAME),
                                       new SqlParameter("@DCXHNAME",model.DCXHNAME),
                                       new SqlParameter("@DCDJNAME",model.DCDJNAME),
                                       new SqlParameter("@XSNOBILL",model.XSNOBILL),
                                       new SqlParameter("@XSNOBILLMX",model.XSNOBILLMX),
                                       new SqlParameter("@CHARG",model.CHARG),
                                       new SqlParameter("@JLR",model.JLR),
                                       new SqlParameter("@VDATU",model.VDATU)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE_ALL, parms)) { }
                mr.TYPE = "S";
                mr.MESSAGE = "";
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_GD_UPDATE_ALL");
            }
            return mr;
        }


        public MES_RETURN DELETE(MES_PD_GD model)
        {
            MES_RETURN mr = new MES_RETURN();
            try
            {
                SqlParameter[] parms = { 
                                       new SqlParameter("@GDDH",model.GDDH),
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
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_GD_DELETE");
            }
            return mr;
        }

        public MES_RETURN DELETE_ALL(MES_PD_GD model)
        {
            MES_RETURN mr = new MES_RETURN();
            try
            {
                SqlParameter[] parms = { 
                                        new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GDDH",model.GDDH),
                                       new SqlParameter("@ERPNO",model.ERPNO)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DELETE_ALL, parms)) { }
                mr.TYPE = "S";
                mr.MESSAGE = "";
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_GD_DELETE_ALL");
            }
            return mr;
        }

        public MES_RETURN SELECT_ERPNO_COUNT(string GC, string ERPNO)
        {
            MES_RETURN mr = new MES_RETURN();
            try
            {
                SqlParameter[] parms = { 
                                       new SqlParameter("@GC",GC),
                                       new SqlParameter("@ERPNO",ERPNO)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT_ERPNO_COUNT, parms))
                {
                    while (sdr.Read())
                    {
                        mr.BH = Convert.ToString(sdr["GDDH"]);
                        mr.XH = Convert.ToInt32(sdr["ISOPEN"]);
                        mr.TID = mr.TID + 1;
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_GD_SELECT_ERPNO_COUNT");
            }
            return mr;
        }

        public SELECT_MES_PD_GD SELECT_BY_PFDH(MES_PD_GD_SELECT_BY_PFDH model)
        {
            SELECT_MES_PD_GD rst = new SELECT_MES_PD_GD();
            List<MES_PD_GD_LIST> child_MES_PD_GD_LIST = new List<MES_PD_GD_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = { 
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@PFDH",model.PFDH),
                                       new SqlParameter("@RQ",model.RQ),
                                       new SqlParameter("@GZXXBH",model.GZXXBH)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_BY_PFDH, parms))
                {
                    while (sdr.Read())
                    {
                        MES_PD_GD_LIST child = new MES_PD_GD_LIST();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.GDLB = Convert.ToInt32(sdr["GDLB"]);
                        child.GDDH = Convert.ToString(sdr["GDDH"]);
                        child.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        child.GZZXNAME = Convert.ToString(sdr["GZZXNAME"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.WLMS = Convert.ToString(sdr["WLMS"]);
                        child.KSDATE = Convert.ToDateTime(sdr["KSDATE"]).ToString("yyyy-MM-dd");
                        child.JSDATE = Convert.ToDateTime(sdr["JSDATE"]).ToString("yyyy-MM-dd");
                        child.ISACTION = Convert.ToBoolean(sdr["ISACTION"]);
                        child.SL = Convert.ToDecimal(sdr["SL"]);
                        child.UNITSID = Convert.ToInt32(sdr["UNITSID"]);
                        child.UNITSNAME = Convert.ToString(sdr["UNITSNAME"]);
                        child.ERPNO = Convert.ToString(sdr["ERPNO"]);
                        child.WLGROUP = Convert.ToString(sdr["WLGROUP"]);
                        child.ISOPEN = Convert.ToInt32(sdr["ISOPEN"]);
                        child_MES_PD_GD_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_GD_SELECT_BY_PFDH");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_PD_GD_LIST = child_MES_PD_GD_LIST;
            return rst;
        }
        public MES_PD_GD_GDJD_SELECT SELECT_GDJD(MES_PD_GD_GDJD_IMPORT model)
        {
            MES_PD_GD_GDJD_SELECT rst = new MES_PD_GD_GDJD_SELECT();
            MES_RETURN msg = new MES_RETURN();
            List<MES_PD_GD_GDJD_EXPORT> nodes = new List<MES_PD_GD_GDJD_EXPORT>();
            try
            {
                SqlParameter[] paras = {
                                           new SqlParameter("@GC",model.GC),
                                           new SqlParameter("@GZZXBH",model.GZZXBH),
                                           new SqlParameter("@SCDATE_BEGIN",model.SCDATE_BEGIN),
                                           new SqlParameter("@SCDATE_END",model.SCDATE_END),
                                           new SqlParameter("@WLH",model.WLH),
                                           new SqlParameter("@XSNOBILL",model.XSNOBILL),
                                           new SqlParameter("@XSNOBILLMX",model.XSNOBILLMX),
                                           new SqlParameter("@ERPNO",model.ERPNO),
                                           new SqlParameter("@STAFFID",model.STAFFID),
                                           new SqlParameter("@ISGD",model.ISGD),
                                           new SqlParameter("@GDDATE_BEGIN",model.GDDATE_BEGIN),
                                           new SqlParameter("@GDDATE_END",model.GDDATE_END),
                                           new SqlParameter("@SBBH",model.SBBH),
                                           new SqlParameter("@WLLB",model.WLLB)
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_GDJD, paras))
                {
                    while (sdr.Read())
                    {
                        MES_PD_GD_GDJD_EXPORT node = new MES_PD_GD_GDJD_EXPORT();
                        if (model.ISGD == 0)
                        {
                            node.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                            node.ERPNO = Convert.ToString(sdr["ERPNO"]);
                            node.WLH = Convert.ToString(sdr["WLH"]);
                            node.WLMS = Convert.ToString(sdr["WLMS"]);
                            node.XSNOBILL = Convert.ToString(sdr["XSNOBILL"]);
                            node.XSNOBILLMX = Convert.ToString(sdr["XSNOBILLMX"]);
                            node.GDCOUNT = Convert.ToDecimal(sdr["GDCOUNT"]);
                            node.FINISHCOUNT = Convert.ToDecimal(sdr["FINISHCOUNT"]);
                            node.CYCOUNT = Convert.ToDecimal(sdr["CYCOUNT"]);
                            node.UNITSNAME = Convert.ToString(sdr["UNITSNAME"]);
                            node.SBHMS = Convert.ToString(sdr["SBHMS"]);
                            node.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        }
                        else
                        {
                            node.ERPNO = Convert.ToString(sdr["ERPNO"]);
                            node.FINISHCOUNT = Convert.ToDecimal(sdr["FINISHCOUNT"]);
                            node.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        }

                        nodes.Add(node);
                    }
                }
                msg.TYPE = "S";
                msg.MESSAGE = "";
            }
            catch (Exception e)
            {
                msg.TYPE = "E";
                msg.MESSAGE = e.Message;

                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_GD_SELECT_GDJD");
            }
            rst.MES_RETURN = msg;
            rst.MES_PD_GD_GDJD_EXPORT = nodes;
            return rst;
        }

        public SELECT_MES_PD_GD SELECT_BY_STAFFID(MES_PD_GD model)
        {
            SELECT_MES_PD_GD rst = new SELECT_MES_PD_GD();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_PD_GD_LIST> child_MES_PD_GD_LIST = new List<MES_PD_GD_LIST>();
            try
            {
                SqlParameter[] parms = { 
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GDLB",model.GDLB),
                                       new SqlParameter("@GDDH",model.GDDH),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@KSDATE",model.KSDATE),
                                       new SqlParameter("@JSDATE",model.JSDATE),
                                       new SqlParameter("@ERPNO",model.ERPNO),
                                       new SqlParameter("@WLLB",model.WLLB),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_BY_STAFFID, parms))
                {
                    while (sdr.Read())
                    {
                        MES_PD_GD_LIST child = new MES_PD_GD_LIST();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.GDLB = Convert.ToInt32(sdr["GDLB"]);
                        child.GDDH = Convert.ToString(sdr["GDDH"]);
                        child.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        child.GZZXNAME = Convert.ToString(sdr["GZZXNAME"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.WLMS = Convert.ToString(sdr["WLMS"]);
                        child.KSDATE = Convert.ToDateTime(sdr["KSDATE"]).ToString("yyyy-MM-dd");
                        child.JSDATE = Convert.ToDateTime(sdr["JSDATE"]).ToString("yyyy-MM-dd");
                        child.ISACTION = Convert.ToBoolean(sdr["ISACTION"]);
                        child.SL = Convert.ToDecimal(sdr["SL"]);
                        child.UNITSID = Convert.ToInt32(sdr["UNITSID"]);
                        child.UNITSNAME = Convert.ToString(sdr["UNITSNAME"]);
                        child.ERPNO = Convert.ToString(sdr["ERPNO"]);
                        child.WLGROUP = Convert.ToString(sdr["WLGROUP"]);
                        child.ISOPEN = Convert.ToInt32(sdr["ISOPEN"]);
                        child.GDPDSL = Convert.ToDecimal(sdr["GDPDSL"]);
                        child.GDWPDSL = child.SL - child.GDPDSL;
                        child.YPRWDH = Convert.ToString(sdr["YPRWDH"]);
                        child.CHARG = Convert.ToString(sdr["CHARG"]);
                        if (child.GDWPDSL < 0)
                        {
                            child.GDWPDSL = 0;
                        }
                        if (child.YPRWDH == "")
                        {
                            child.ISPD = "未排单";
                        }
                        else
                        {
                            child.ISPD = "已排单";
                        }
                        child_MES_PD_GD_LIST.Add(child);
                    }
                }
                rst.MES_PD_GD_LIST = child_MES_PD_GD_LIST;
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
                rst.MES_RETURN = child_MES_RETURN;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_GD_SELECT_BY_STAFFID");
            }
            return rst;
        }

        public MES_RETURN BOM_SYNC_INSERT(ZSL_BCS302_B model)
        {
            MES_RETURN mr = new MES_RETURN();
            try
            {
                SqlParameter[] parms = { 
                                       new SqlParameter("@RSNUM",model.RSNUM),
                                       new SqlParameter("@RSPOS",model.RSPOS),
                                       new SqlParameter("@POSTP",model.POSTP),
                                       new SqlParameter("@POSNR",model.POSNR),
                                       new SqlParameter("@STLTY",model.STLTY),
                                       new SqlParameter("@STLNR",model.STLNR),
                                       new SqlParameter("@STLKN",model.STLKN),
                                       new SqlParameter("@STPOZ",model.STPOZ),
                                       new SqlParameter("@IDNRK",model.IDNRK),
                                       new SqlParameter("@MAKTX",model.MAKTX),
                                       new SqlParameter("@WERKS",model.WERKS),
                                       new SqlParameter("@MENGE",model.MENGE),
                                       new SqlParameter("@MEINS",model.MEINS),
                                       new SqlParameter("@MATKL",model.MATKL),
                                       new SqlParameter("@WLDL",model.WLDL),
                                       new SqlParameter("@DCXH",model.DCXH),
                                       new SqlParameter("@DCDJ",model.DCDJ),
                                       new SqlParameter("@ZSBS",model.ZSBS),
                                       new SqlParameter("@SOBKZ",model.SOBKZ),
                                       new SqlParameter("@KDAUF",model.KDAUF),
                                       new SqlParameter("@KDPOS",model.KDPOS),
                                       new SqlParameter("@AUFNR",model.AUFNR),
                                       new SqlParameter("@DEL",model.DEL)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_BOM_SYNC_INSERT, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_PD_GD_BOM_SYNC_INSERT", "MES");
            }
            return mr;
        }
        public MES_PD_GD_BOM_SYNC_SELECT BOM_SYNC_SELECT(ZSL_BCS302_B model, int LB)
        {
            MES_PD_GD_BOM_SYNC_SELECT rst = new MES_PD_GD_BOM_SYNC_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<ZSL_BCS302_B> child_ZSL_BCS302_B = new List<ZSL_BCS302_B>();
            try
            {
                SqlParameter[] parms = { 
                                           new SqlParameter("@WERKS",model.WERKS),
                                       new SqlParameter("@AUFNR",model.AUFNR),
                                       new SqlParameter("@LB",LB)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_BOM_SYNC_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        ZSL_BCS302_B child = new ZSL_BCS302_B();
                        child.RSNUM = Convert.ToString(sdr["RSNUM"]);
                        child.RSPOS = Convert.ToString(sdr["RSPOS"]);
                        child.POSTP = Convert.ToString(sdr["POSTP"]);
                        child.POSNR = Convert.ToString(sdr["POSNR"]);
                        child.STLTY = Convert.ToString(sdr["STLTY"]);
                        child.STLNR = Convert.ToString(sdr["STLNR"]);
                        child.STLKN = Convert.ToString(sdr["STLKN"]);
                        child.STPOZ = Convert.ToString(sdr["STPOZ"]);
                        child.IDNRK = Convert.ToString(sdr["IDNRK"]);
                        child.MAKTX = Convert.ToString(sdr["MAKTX"]);
                        child.WERKS = Convert.ToString(sdr["WERKS"]);
                        child.MENGE = Convert.ToString(sdr["MENGE"]);
                        child.MEINS = Convert.ToString(sdr["MEINS"]);
                        child.MATKL = Convert.ToString(sdr["MATKL"]);
                        child.WLDL = Convert.ToString(sdr["WLLBNAME"]);
                        child.DCXH = Convert.ToString(sdr["DCXHNAME"]);
                        child.DCDJ = Convert.ToString(sdr["DCDJNAME"]);
                        child.ZSBS = Convert.ToString(sdr["ZSBS"]);
                        child.SOBKZ = Convert.ToString(sdr["SOBKZ"]);
                        child.KDAUF = Convert.ToString(sdr["KDAUF"]);
                        child.KDPOS = Convert.ToString(sdr["KDPOS"]);
                        child.AUFNR = Convert.ToString(sdr["AUFNR"]);
                        child.DEL = Convert.ToString(sdr["DEL"]);
                        child_ZSL_BCS302_B.Add(child);
                    }
                }
                rst.ZSL_BCS302_B = child_ZSL_BCS302_B;
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
                rst.MES_RETURN = child_MES_RETURN;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_PD_GD_BOM_SYNC_SELECT", "MES");
            }
            return rst;
        }
        public MES_RETURN BOM_SYNC_UPDATE(ZSL_BCS302_B model, int LB)
        {
            MES_RETURN mr = new MES_RETURN();
            try
            {
                SqlParameter[] parms = { 
                                       new SqlParameter("@WERKS",model.WERKS),
                                       new SqlParameter("@AUFNR",model.AUFNR),
                                       new SqlParameter("@LB",LB)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_BOM_SYNC_UPDATE, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_PD_GD_BOM_SYNC_UPDATE", "MES");
            }
            return mr;
        }
        public MES_RETURN INSERT_GD_SYNC(List<ZSL_BCST024_PO> model)
        {
            MES_RETURN mr = new MES_RETURN();
            for (int a = 0; a < model.Count; a++)
            {
                try
                {
                    SqlParameter[] parms = { 
                                       new SqlParameter("@AUFNR",model[a].AUFNR),
                                       new SqlParameter("@WERKS",model[a].WERKS),
                                       new SqlParameter("@MATNR",model[a].MATNR),
                                       new SqlParameter("@MAKTX",model[a].MAKTX),
                                       new SqlParameter("@MATKL",model[a].MATKL),
                                       new SqlParameter("@WLDL",model[a].WLDL),
                                       new SqlParameter("@DCXH",model[a].DCXH),
                                       new SqlParameter("@DCDJ",model[a].DCDJ),
                                       new SqlParameter("@PSMNG",model[a].PSMNG),
                                       new SqlParameter("@AMEIN",model[a].AMEIN),
                                       new SqlParameter("@WEMNG",model[a].WEMNG),
                                       new SqlParameter("@KDAUF",model[a].KDAUF),
                                       new SqlParameter("@KDPOS",model[a].KDPOS),
                                       new SqlParameter("@GSTRP",model[a].GSTRP),
                                       new SqlParameter("@GLTRP",model[a].GLTRP),
                                       new SqlParameter("@ARBPL",model[a].ARBPL),
                                       new SqlParameter("@LTXA1",model[a].LTXA1),
                                       new SqlParameter("@BSTDK",model[a].BSTDK),
                                       new SqlParameter("@RSNUM",model[a].RSNUM),
                                       new SqlParameter("@AUFPL",model[a].AUFPL),
                                       new SqlParameter("@OBJNR",model[a].OBJNR),
                                       new SqlParameter("@STAT",model[a].STAT),
                                       new SqlParameter("@DEL",model[a].DEL),
                                       new SqlParameter("@CHARG",model[a].CHARG),
                                       new SqlParameter("@WEMPF",model[a].WEMPF),
                                       new SqlParameter("@VDATU",model[a].VDATU),
                                       new SqlParameter("@TMSL",model[a].TMSL),
                                   };

                    using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT_GD_SYNC, parms))
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
                    SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_PD_GD_SYNC_INSERT", "MES");
                }
                if (mr.TYPE != "S")
                {
                    return mr;
                }
            }
            return mr;
        }
        public MES_PD_GD_SYNC_SELECT SELECT_GD_SYNC(MES_PD_GD_SYNC model)
        {
            MES_PD_GD_SYNC_SELECT rst = new MES_PD_GD_SYNC_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            //List<ZSL_BCST024_PO> rst = new List<ZSL_BCST024_PO>();
            try
            {
                SqlParameter[] parms = { 
                                           new SqlParameter("@LB",model.LB),
                                           new SqlParameter("@WERKS",model.WERKS),
                                           new SqlParameter("@ARBPL",model.ARBPL),
                                           new SqlParameter("@WLDL",model.WLDL),
                                           new SqlParameter("@AUFNR",model.AUFNR),
                                           new SqlParameter("@LOW",model.LOW),
                                           new SqlParameter("@HIGH",model.HIGH),
                                           new SqlParameter("@MATNR",model.MATNR)
                                   };
                //using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_GD_SYNC, parms))
                //{
                //    while (sdr.Read())
                //    {
                //        ZSL_BCST024_PO child = new ZSL_BCST024_PO();
                //        child.AUFNR = Convert.ToString(sdr["AUFNR"]);
                //        child.WERKS = Convert.ToString(sdr["WERKS"]);
                //        child.MATNR = Convert.ToString(sdr["MATNR"]);
                //        child.MAKTX = Convert.ToString(sdr["MAKTX"]);
                //        child.MATKL = Convert.ToString(sdr["MATKL"]);
                //        child.WLDL = Convert.ToString(sdr["WLDL"]);
                //        child.DCXH = Convert.ToString(sdr["DCXH"]);
                //        child.DCDJ = Convert.ToString(sdr["DCDJ"]);
                //        child.PSMNG = Convert.ToString(sdr["PSMNG"]);
                //        child.AMEIN = Convert.ToString(sdr["AMEIN"]);
                //        child.WEMNG = Convert.ToString(sdr["WEMNG"]);
                //        child.KDAUF = Convert.ToString(sdr["KDAUF"]);
                //        child.KDPOS = Convert.ToString(sdr["KDPOS"]);
                //        child.GSTRP = Convert.ToString(sdr["GSTRP"]);
                //        child.GLTRP = Convert.ToString(sdr["GLTRP"]);
                //        child.ARBPL = Convert.ToString(sdr["ARBPL"]);
                //        child.LTXA1 = Convert.ToString(sdr["LTXA1"]);
                //        child.BSTDK = Convert.ToString(sdr["BSTDK"]);
                //        child.RSNUM = Convert.ToString(sdr["RSNUM"]);
                //        child.AUFPL = Convert.ToString(sdr["AUFPL"]);
                //        child.OBJNR = Convert.ToString(sdr["OBJNR"]);
                //        child.STAT = Convert.ToString(sdr["STAT"]);
                //        child.DEL = Convert.ToString(sdr["DEL"]);
                //        child.CHARG = Convert.ToString(sdr["CHARG"]);
                //        child.WEMPF = Convert.ToString(sdr["WEMPF"]);
                //        child.VDATU = Convert.ToString(sdr["VDATU"]);
                //        child.TMSL = Convert.ToString(sdr["TMSL"]);
                //        rst.Add(child);
                //    }
                //}
                rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_SELECT_GD_SYNC, parms);
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_PD_GD_SYNC_SELECT", "MES");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }

        public MES_RETURN INSERT_GD_GYLX_SYNC(List<ZSL_BCST302_R> model)
        {
            MES_RETURN mr = new MES_RETURN();
            for (int a = 0; a < model.Count; a++)
            {
                try
                {
                    SqlParameter[] parms = { 
                                       new SqlParameter("@AUFPL",model[a].AUFPL),
                                       new SqlParameter("@VORNR",model[a].VORNR),
                                       new SqlParameter("@ARBPL",model[a].ARBPL),
                                       new SqlParameter("@LTXA1",model[a].LTXA1),
                                       new SqlParameter("@WERKS",model[a].WERKS),
                                       new SqlParameter("@AUFNR",model[a].AUFNR)
                                   };

                    using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT_GD_GYLX_SYNC, parms))
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
                    SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_PD_GD_GYLX_SYNC_INSERT", "MES");
                }
                if (mr.TYPE != "S")
                {
                    return mr;
                }
            }
            return mr;
        }
    }
}

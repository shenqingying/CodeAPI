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
    public class RY_RYINFO : IRY_RYINFO
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        SY_TABLE_COLUMN SY_TABLE_COLUMNService = new SY_TABLE_COLUMN();
        const string SQL_INSERT = "HR_RY_RYINFO_INSERT";
        const string SQL_SELECT = "HR_RY_RYINFO_SELECT";
        const string SQL_UPDATE = "HR_RY_RYINFO_UPDATE";
        const string SQL_UPDATEALL = "HR_RY_RYINFO_UPDATEALL";
        const string SQL_UPDATE_PIC = "HR_RY_RYINFO_PIC_UPDATE";
        const string SQL_UPDATE_CHECK = "HR_RY_RYINFO_CHECK";
        const string SQL_UPDATE_YGTYPE = "HR_RY_RYINFO_YGTYPE";
        const string SQL_UPDATE_DEPT = "HR_RY_RYINFO_DEPT";
        const string SQL_UPDATE_JOBS = "HR_RY_RYINFO_JOBS";
        const string SQL_UPDATE_QUIT = "HR_RY_RYINFO_QUIT";
        const string SQL_UPDATE_CHANGEINFO = "HR_RY_RYINFO_CHANGEINFO";
        const string SQL_RY_CHANGEINFO_SELECT = "HR_RY_CHANGEINFO_SELECT";
        const string SQL_UPDATE_ISINGH = "HR_RY_RYINFO_UPDATE_ISINGH";
        const string SQL_UPDATE_DUTYNAME = "UPDATE HR_RY_RYINFO SET DUTYNAME=@DUTYNAME WHERE RYID=@RYID";
        const string SQL_SELECT_GSGL = "HR_RY_GSGL_SELECT";
        const string SQL_SELECT_WJGL = "HR_RY_WJGL_SELECT";
        const string SQL_SELECT_WBZW = "HR_RY_WBZW_SELECT";
        const string SQL_INSERT_RONGY = "HR_RY_RONGY_INSERT";
        const string SQL_SELECT_RONGY = "HR_RY_RONGY_SELECT";
        const string SQL_UPDATE_RONGY = "HR_RY_RONGY_UPDATE";
        const string SQL_DELETE_RONGY = "HR_RY_RONGY_DELETE";
        const string SQL_INSERT_RONGY_RYID = "INSERT HR_RY_RONGY_RYID(RONGYID,RYID) VALUES (@RONGYID,@RYID)";
        const string SQL_DELETE_RONGY_RYID = "DELETE HR_RY_RONGY_RYID WHERE RONGYID=@RONGYID";
        const string SQL_SELECT_RONGY_RYID = "HR_RY_RONGY_RYID_SELECT";
        const string SQL_INSERT_RONGY_FILE = "HR_RY_RONGY_FILE_INSERT";
        const string SQL_SELECT_RONGY_FILE = "SELECT * FROM HR_RY_RONGY_FILE WHERE RONGYID=@RONGYID AND ISDELETE=0";
        const string SQL_DELETE_RONGY_FILE = "UPDATE HR_RY_RONGY_FILE SET ISDELETE=1 WHERE RYFILEID=@RYFILEID";
        const string SQL_SELECT_LB = "HR_RY_RYINFO_SELECT_LB";
        const string SQL_SELECT_LZINFO = "HR_RY_LZINFO_SELECT";
        const string SQL_UPDATE_LB = "HR_RY_RYINFO_UPDATE_LB";
        public HR_RY_RYINFO_SELECT INSERT(HR_RY_RYINFO model)
        {
            HR_RY_RYINFO_SELECT rst = new HR_RY_RYINFO_SELECT();
            List<HR_RY_RYINFO_LIST> model_HR_RY_RYINFO_LIST = new List<HR_RY_RYINFO_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@YGNAME",model.YGNAME),
                                       new SqlParameter("@DEPT",model.DEPT),
                                       new SqlParameter("@ZZZT",model.ZZZT),
                                       new SqlParameter("@RZDATE",model.RZDATE),
                                       new SqlParameter("@LZRQ",model.LZRQ),
                                       new SqlParameter("@ZZTYPE",model.ZZTYPE),
                                       new SqlParameter("@ZZNO",model.ZZNO),
                                       new SqlParameter("@BIRTHDAT",model.BIRTHDAT),
                                       new SqlParameter("@XB",model.XB),
                                       new SqlParameter("@SFZYXRQ",model.SFZYXRQ),
                                       new SqlParameter("@YGXZ",model.YGXZ),
                                       new SqlParameter("@YGTYPE",model.YGTYPE),
                                       //new SqlParameter("@GLQSR",model.GLQSR),
                                       new SqlParameter("@GHOLD",model.GHOLD),
                                       new SqlParameter("@DUTYNAME",model.DUTYNAME),
                                       new SqlParameter("@JOBS",model.JOBS),
                                       new SqlParameter("@JOBSNAME",model.JOBSNAME),
                                       new SqlParameter("@GJ",model.GJ),
                                       new SqlParameter("@PX",model.PX),
                                       new SqlParameter("@HYZK",model.HYZK),
                                       new SqlParameter("@ZZMM",model.ZZMM),
                                       new SqlParameter("@HJADDRESS",model.HJADDRESS),
                                       new SqlParameter("@JZADDRESS",model.JZADDRESS),
                                       new SqlParameter("@PHONENUMBER",model.PHONENUMBER),
                                       new SqlParameter("@EMAIL",model.EMAIL),
                                       new SqlParameter("@JG",model.JG),
                                       new SqlParameter("@MZ",model.MZ),
                                       new SqlParameter("@NSRSBH",model.NSRSBH),
                                       new SqlParameter("@NSRSF",model.NSRSF),
                                       new SqlParameter("@ZY",model.ZY),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@ISINGH",model.ISINGH),
                                       new SqlParameter("@GHDATE",model.GHDATE),
                                       new SqlParameter("@CJR",model.CJR),
                                       new SqlParameter("@STUDEFS",model.STUDEFS),
                                       new SqlParameter("@EDUCACTION",model.EDUCACTION),
                                       new SqlParameter("@ISCJ",model.ISCJ),
                                       new SqlParameter("@CJNO",model.CJNO),
                                       new SqlParameter("@ISGL",model.ISGL),
                                       new SqlParameter("@ISLS",model.ISLS),
                                       new SqlParameter("@LSNO",model.LSNO),
                                       new SqlParameter("@ISJZZ",model.ISJZZ),
                                       new SqlParameter("@JZZYYQ",model.JZZYYQ),
                                       new SqlParameter("@ISHY",model.ISHY),
                                       new SqlParameter("@HYNO",model.HYNO),
                                       new SqlParameter("@HYYYQ",model.HYYYQ),
                                       new SqlParameter("@BZ",model.BZ),
                                       new SqlParameter("@ISECRZ",model.ISECRZ),
                                       new SqlParameter("@EDUCACTIONSCHOOL",model.EDUCACTIONSCHOOL),
                                       new SqlParameter("@FPDATE",model.FPDATE)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
                {
                    while (sdr.Read())
                    {
                        HR_RY_RYINFO_LIST child = new HR_RY_RYINFO_LIST();
                        child.YGNAME = Convert.ToString(sdr["YGNAME"]);
                        child.GH = Convert.ToString(sdr["GH"]);
                        model_HR_RY_RYINFO_LIST.Add(child);
                    }
                    sdr.NextResult();
                    while (sdr.Read())
                    {
                        child_MES_RETURN.TYPE = Convert.ToString(sdr["TYPE"]);
                        child_MES_RETURN.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_RYINFO_INSERT", "HR");
            }
            rst.HR_RY_RYINFO_LIST = model_HR_RY_RYINFO_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public HR_RY_RYINFO_SELECT SELECT(HR_RY_RYINFO model)
        {
            HR_RY_RYINFO_SELECT rst = new HR_RY_RYINFO_SELECT();
            List<HR_RY_RYINFO_LIST> model_HR_RY_RYINFO_LIST = new List<HR_RY_RYINFO_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@ALLRYID",model.ALLRYID),
                                       new SqlParameter("@ALLGS",model.ALLGS),
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@YGNAME",model.YGNAME),
                                       new SqlParameter("@DEPT",model.DEPT),
                                       new SqlParameter("@GSBM",model.GSBM),
                                       new SqlParameter("@ZZZT",model.ZZZT),
                                       new SqlParameter("@GH",model.GH),
                                       new SqlParameter("@ZZNO",model.ZZNO),
                                       new SqlParameter("@RZRQKS",model.RZRQKS),
                                       new SqlParameter("@RZRQJS",model.RZRQJS),
                                       new SqlParameter("@NOSELECT",model.NOSELECT),
                                       new SqlParameter("@YGTYPE",model.YGTYPE),
                                       new SqlParameter("@YGLB",model.YGLB),
                                       new SqlParameter("@JZDATE",model.JZDATE),
                                       new SqlParameter("@HTSXRQKS",model.HTSXRQKS),
                                       new SqlParameter("@HTSXRQJS",model.HTSXRQJS),
                                       new SqlParameter("@LZRQKS",model.LZRQKS),
                                       new SqlParameter("@LZRQJS",model.LZRQJS),
                                       new SqlParameter("@ISINGHSTRING",model.ISINGHSTRING),
                                       new SqlParameter("@GHDATEKS",model.GHDATEKS),
                                       new SqlParameter("@GHDATEJS",model.GHDATEJS),
                                       new SqlParameter("@BIRTHDAYKS",model.BIRTHDAYKS),
                                       new SqlParameter("@BIRTHDAYJS",model.BIRTHDAYJS),
                                       new SqlParameter("@ZWLEVELLIST",model.ZWLEVELLIST),
                                       new SqlParameter("@XB",model.XB)
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        HR_RY_RYINFO_LIST child = new HR_RY_RYINFO_LIST();
                        child.RYID = Convert.ToInt32(sdr["RYID"]);
                        child.GS = Convert.ToString(sdr["GS"]);
                        child.YGNAME = Convert.ToString(sdr["YGNAME"]);
                        child.DEPT = Convert.ToInt32(sdr["DEPT"]);
                        child.DEPTNAME = Convert.ToString(sdr["DEPTNAME"]);
                        child.GSBM = Convert.ToInt32(sdr["GSBM"]);
                        child.GSBMNAME = Convert.ToString(sdr["GSBMNAME"]);
                        child.ZZZT = Convert.ToInt32(sdr["ZZZT"]);
                        child.ZZZTNAME = Convert.ToString(sdr["ZZZTNAME"]);
                        child.RZDATE = Convert.ToString(sdr["RZDATE"]);
                        child.LZRQ = Convert.ToString(sdr["LZRQ"]);
                        child.GH = Convert.ToString(sdr["GH"]).Substring(5, 5);
                        child.ZZTYPE = Convert.ToInt32(sdr["ZZTYPE"]);
                        child.ZZTYPENAME = Convert.ToString(sdr["ZZTYPENAME"]);
                        child.ZZNO = Convert.ToString(sdr["ZZNO"]);
                        child.BIRTHDAT = Convert.ToString(sdr["BIRTHDAT"]);
                        child.XB = Convert.ToString(sdr["XB"]);
                        child.SFZYXRQ = Convert.ToString(sdr["SFZYXRQ"]);
                        child.YGXZ = Convert.ToInt32(sdr["YGXZ"]);
                        child.YGXZNAME = Convert.ToString(sdr["YGXZNAME"]);
                        child.YGTYPE = Convert.ToInt32(sdr["YGTYPE"]);
                        child.YGTYPENAME = Convert.ToString(sdr["YGTYPENAME"]);
                        child.GLQSR = Convert.ToString(sdr["GLQSR"]);
                        child.GHOLD = Convert.ToString(sdr["GHOLD"]);
                        child.DUTYNAME = Convert.ToString(sdr["DUTYNAME"]);
                        child.JOBS = Convert.ToInt32(sdr["JOBS"]);
                        child.JOBSNAME = Convert.ToString(sdr["JOBSNAME"]);
                        child.GJ = Convert.ToInt32(sdr["GJ"]);
                        child.GJNAME = Convert.ToString(sdr["GJNAME"]);
                        child.PX = Convert.ToInt32(sdr["PX"]);
                        child.HYZK = Convert.ToInt32(sdr["HYZK"]);
                        child.HYZKNAME = Convert.ToString(sdr["HYZKNAME"]);
                        child.ZZMM = Convert.ToInt32(sdr["ZZMM"]);
                        child.ZZMMNAME = Convert.ToString(sdr["ZZMMNAME"]);
                        child.HJADDRESS = Convert.ToString(sdr["HJADDRESS"]);
                        child.JZADDRESS = Convert.ToString(sdr["JZADDRESS"]);
                        child.PHONENUMBER = Convert.ToString(sdr["PHONENUMBER"]);
                        child.EMAIL = Convert.ToString(sdr["EMAIL"]);
                        child.JG = Convert.ToString(sdr["JG"]);
                        child.MZ = Convert.ToInt32(sdr["MZ"]);
                        child.MZNAME = Convert.ToString(sdr["MZNAME"]);
                        child.NSRSBH = Convert.ToString(sdr["NSRSBH"]);
                        child.NSRSF = Convert.ToInt32(sdr["NSRSF"]);
                        child.NSRSFNAME = Convert.ToString(sdr["NSRSFNAME"]);
                        child.ZY = Convert.ToString(sdr["ZY"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.ISINGH = Convert.ToInt32(sdr["ISINGH"]);
                        child.GHDATE = Convert.ToString(sdr["GHDATE"]);
                        child.CJR = Convert.ToInt32(sdr["CJR"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJTIME = Convert.ToString(sdr["CJTIME"]);
                        child.XGR = Convert.ToInt32(sdr["XGR"]);
                        child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                        child.XGTIME = Convert.ToString(sdr["XGTIME"]);
                        child.STUDEFS = Convert.ToInt32(sdr["STUDEFS"]);
                        child.STUDEFSNAME = Convert.ToString(sdr["STUDEFSNAME"]);
                        child.EDUCACTION = Convert.ToInt32(sdr["EDUCACTION"]);
                        child.EDUCACTIONNAME = Convert.ToString(sdr["EDUCACTIONNAME"]);
                        child.GSNAME = Convert.ToString(sdr["GSNAME"]);
                        child.DUTYLEVEL = Convert.ToString(sdr["DUTYLEVEL"]);
                        child.IMAGEURL = Convert.ToString(sdr["IMAGEURL"]);
                        child.ZCNAME = Convert.ToString(sdr["ZCNAME"]);

                        child.ISCJ = Convert.ToInt32(sdr["ISCJ"]);
                        child.CJNO = Convert.ToString(sdr["CJNO"]);
                        child.ISGL = Convert.ToInt32(sdr["ISGL"]);
                        child.ISLS = Convert.ToInt32(sdr["ISLS"]);
                        child.LSNO = Convert.ToString(sdr["LSNO"]);
                        child.ISJZZ = Convert.ToInt32(sdr["ISJZZ"]);
                        child.JZZYYQ = Convert.ToString(sdr["JZZYYQ"]);
                        child.ISHY = Convert.ToInt32(sdr["ISHY"]);
                        child.HYNO = Convert.ToString(sdr["HYNO"]);
                        child.HYYYQ = Convert.ToString(sdr["HYYYQ"]);
                        child.GSBMGSNAME = Convert.ToString(sdr["GSBMGSNAME"]);

                        child.HTQCS = Convert.ToInt32(sdr["HTQCS"]);
                        child.HTID = Convert.ToInt32(sdr["HTID"]);
                        child.HTZT = Convert.ToInt32(sdr["HTZT"]);
                        child.HTZTNAME = Convert.ToString(sdr["HTZTNAME"]);
                        child.HTQXLB = Convert.ToInt32(sdr["HTQXLB"]);
                        child.HTQXLBNAME = Convert.ToString(sdr["HTQXLBNAME"]);
                        child.HTQX = Convert.ToString(sdr["HTQX"]);
                        child.QDRQ = Convert.ToString(sdr["QDRQ"]);
                        child.SXRQ = Convert.ToString(sdr["SXRQ"]);
                        child.DQR = Convert.ToString(sdr["DQR"]);
                        child.SYDATE = Convert.ToString(sdr["SYDATE"]);
                        child.HTREMARK = Convert.ToString(sdr["HTREMARK"]);
                        child.BZ = Convert.ToInt32(sdr["BZ"]);
                        child.BZNAME = Convert.ToString(sdr["BZNAME"]);
                        child.ISECRZ = Convert.ToInt32(sdr["ISECRZ"]);
                        child.ZWLEVEL = Convert.ToInt32(sdr["ZWLEVEL"]);
                        child.ZWLEVELNAME = Convert.ToString(sdr["ZWLEVELNAME"]);
                        child.GSJC = Convert.ToString(sdr["GSJC"]);
                        child.EDUCACTIONSCHOOL = Convert.ToString(sdr["EDUCACTIONSCHOOL"]);
                        child.PHONESHORT = Convert.ToString(sdr["PHONESHORT"]);
                        child.FPDATE = Convert.ToString(sdr["FPDATE"]);
                        model_HR_RY_RYINFO_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_RYINFO_SELECT", "HR");
            }
            rst.HR_RY_RYINFO_LIST = model_HR_RY_RYINFO_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public HR_RY_RYINFO_SELECT SELECT_LB(HR_RY_RYINFO model, int LB)
        {
            HR_RY_RYINFO_SELECT rst = new HR_RY_RYINFO_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                           new SqlParameter("@LB",LB),
                                           new SqlParameter("@GS",model.GS),
                                           new SqlParameter("@GSBM",model.GSBM),
                                           new SqlParameter("@DATEKS",model.DATEKS),
                                           new SqlParameter("@DATEJS",model.DATEJS),
                                           new SqlParameter("@STAFFID",model.STAFFID),
                                           new SqlParameter("@RYINFOLIST",model.RYINFOLIST),
                                           new SqlParameter("@DEPT",model.DEPT)
                                   };
                rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_SELECT_LB, paras);
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_KQ_BD_SELECT_LB", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN UPDATE(HR_RY_RYINFO model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                DataTable dtold = new DataTable();
                DataTable dtnew = new DataTable();
                MES_SY_TABLE_COLUMN model_MES_SY_TABLE_COLUMN = new MES_SY_TABLE_COLUMN();
                model_MES_SY_TABLE_COLUMN.SY = "HR";
                model_MES_SY_TABLE_COLUMN.SY_TABLE = "HR_RY_RYINFO";
                model_MES_SY_TABLE_COLUMN.ZJVALUES = model.RYID.ToString();
                model_MES_SY_TABLE_COLUMN.STAFFID = model.XGR;
                MES_SY_TABLE_COLUMN_SELECT rst_MES_SY_TABLE_COLUMN_SELECT = SY_TABLE_COLUMNService.SELECT(model_MES_SY_TABLE_COLUMN);
                if (rst_MES_SY_TABLE_COLUMN_SELECT.MES_RETURN.TYPE == "S")
                {
                    dtold = rst_MES_SY_TABLE_COLUMN_SELECT.DATALIST;
                }
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@YGNAME",model.YGNAME),
                                       new SqlParameter("@DEPT",model.DEPT),
                                       new SqlParameter("@BIRTHDAT",model.BIRTHDAT),
                                       new SqlParameter("@XB",model.XB),
                                       new SqlParameter("@GJ",model.GJ),
                                       new SqlParameter("@HYZK",model.HYZK),
                                       new SqlParameter("@ZZMM",model.ZZMM),
                                       new SqlParameter("@HJADDRESS",model.HJADDRESS),
                                       new SqlParameter("@JZADDRESS",model.JZADDRESS),
                                       new SqlParameter("@PHONENUMBER",model.PHONENUMBER),
                                       new SqlParameter("@JG",model.JG),
                                       new SqlParameter("@MZ",model.MZ),
                                       new SqlParameter("@RZDATE",model.RZDATE),
                                       new SqlParameter("@XGR",model.XGR),
                                       //new SqlParameter("@STUDEFS",model.STUDEFS),
                                       //new SqlParameter("@EDUCACTION",model.EDUCACTION),
                                       new SqlParameter("@YGXZ",model.YGXZ),
                                       new SqlParameter("@YGTYPE",model.YGTYPE),
                                       new SqlParameter("@ZZZT",model.ZZZT),
                                       new SqlParameter("@ISCJ",model.ISCJ),
                                       new SqlParameter("@CJNO",model.CJNO),
                                       new SqlParameter("@ISGL",model.ISGL),
                                       new SqlParameter("@ISLS",model.ISLS),
                                       new SqlParameter("@LSNO",model.LSNO),
                                       new SqlParameter("@ISJZZ",model.ISJZZ),
                                       new SqlParameter("@JZZYYQ",model.JZZYYQ),
                                       new SqlParameter("@ISHY",model.ISHY),
                                       new SqlParameter("@HYNO",model.HYNO),
                                       new SqlParameter("@HYYYQ",model.HYYYQ),
                                       new SqlParameter("@BZ",model.BZ),
                                       new SqlParameter("@ISECRZ",model.ISECRZ)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_RYINFO_UPDATE", "HR");
            }
            return rst;
        }
        public MES_RETURN UPDATE_ALL(HR_RY_RYINFO model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                DataTable dtold = new DataTable();
                DataTable dtnew = new DataTable();
                MES_SY_TABLE_COLUMN model_MES_SY_TABLE_COLUMN = new MES_SY_TABLE_COLUMN();
                model_MES_SY_TABLE_COLUMN.SY = "HR";
                model_MES_SY_TABLE_COLUMN.SY_TABLE = "HR_RY_RYINFO";
                model_MES_SY_TABLE_COLUMN.ZJVALUES = model.RYID.ToString();
                model_MES_SY_TABLE_COLUMN.STAFFID = model.XGR;
                MES_SY_TABLE_COLUMN_SELECT rst_MES_SY_TABLE_COLUMN_SELECT = SY_TABLE_COLUMNService.SELECT(model_MES_SY_TABLE_COLUMN);
                if (rst_MES_SY_TABLE_COLUMN_SELECT.MES_RETURN.TYPE == "S")
                {
                    dtold = rst_MES_SY_TABLE_COLUMN_SELECT.DATALIST;
                }
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@YGNAME",model.YGNAME),
                                       new SqlParameter("@DEPT",model.DEPT),
                                       new SqlParameter("@GSBM",model.GSBM),
                                       new SqlParameter("@ZZZT",model.ZZZT),
                                       new SqlParameter("@RZDATE",model.RZDATE),
                                       new SqlParameter("@ZZTYPE",model.ZZTYPE),
                                       new SqlParameter("@ZZNO",model.ZZNO),
                                       new SqlParameter("@BIRTHDAT",model.BIRTHDAT),
                                       new SqlParameter("@XB",model.XB),
                                       new SqlParameter("@SFZYXRQ",model.SFZYXRQ),
                                       //new SqlParameter("@YGXZ",model.YGXZ),
                                       new SqlParameter("@YGTYPE",model.YGTYPE),
                                       new SqlParameter("@GLQSR",model.GLQSR),
                                       new SqlParameter("@GHOLD",model.GHOLD),
                                       //new SqlParameter("@DUTYNAME",model.DUTYNAME),
                                       new SqlParameter("@JOBS",model.JOBS),
                                       new SqlParameter("@GJ",model.GJ),
                                       new SqlParameter("@HYZK",model.HYZK),
                                       new SqlParameter("@ZZMM",model.ZZMM),
                                       new SqlParameter("@HJADDRESS",model.HJADDRESS),
                                       new SqlParameter("@JZADDRESS",model.JZADDRESS),
                                       new SqlParameter("@PHONENUMBER",model.PHONENUMBER),
                                       new SqlParameter("@JG",model.JG),
                                       new SqlParameter("@MZ",model.MZ),
                                       //new SqlParameter("@ZY",model.ZY),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@XGR",model.XGR),
                                       new SqlParameter("@NSRSBH",model.NSRSBH),
                                       new SqlParameter("@NSRSF",model.NSRSF),
                                       new SqlParameter("@ISCJ",model.ISCJ),
                                       new SqlParameter("@CJNO",model.CJNO),
                                       new SqlParameter("@ISGL",model.ISGL),
                                       new SqlParameter("@ISLS",model.ISLS),
                                       new SqlParameter("@LSNO",model.LSNO),
                                       new SqlParameter("@ISJZZ",model.ISJZZ),
                                       new SqlParameter("@JZZYYQ",model.JZZYYQ),
                                       new SqlParameter("@ISHY",model.ISHY),
                                       new SqlParameter("@HYNO",model.HYNO),
                                       new SqlParameter("@HYYYQ",model.HYYYQ),
                                       new SqlParameter("@BZ",model.BZ),
                                       new SqlParameter("@ISECRZ",model.ISECRZ),
                                       new SqlParameter("@ZWLEVEL",model.ZWLEVEL),
                                       new SqlParameter("@PHONESHORT",model.PHONESHORT),
                                       new SqlParameter("@EDUCACTIONSCHOOL",model.EDUCACTIONSCHOOL),
                                       new SqlParameter("@FPDATE",model.FPDATE)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATEALL, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_RYINFO_UPDATEALL", "HR");
            }
            return rst;
        }
        public MES_RETURN UPDATE_PIC(HR_RY_RYINFO model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@IMAGEURL",model.IMAGEURL),
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE_PIC, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_RYINFO_PIC_UPDATE", "HR");
            }
            return rst;
        }
        public MES_RETURN UPDATE_CHECK(HR_RY_RYINFO model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                DataTable dtold = new DataTable();
                DataTable dtnew = new DataTable();
                MES_SY_TABLE_COLUMN model_MES_SY_TABLE_COLUMN = new MES_SY_TABLE_COLUMN();
                model_MES_SY_TABLE_COLUMN.SY = "HR";
                model_MES_SY_TABLE_COLUMN.SY_TABLE = "HR_RY_RYINFO";
                model_MES_SY_TABLE_COLUMN.ZJVALUES = model.RYID.ToString();
                model_MES_SY_TABLE_COLUMN.STAFFID = model.XGR;
                MES_SY_TABLE_COLUMN_SELECT rst_MES_SY_TABLE_COLUMN_SELECT = SY_TABLE_COLUMNService.SELECT(model_MES_SY_TABLE_COLUMN);
                if (rst_MES_SY_TABLE_COLUMN_SELECT.MES_RETURN.TYPE == "S")
                {
                    dtold = rst_MES_SY_TABLE_COLUMN_SELECT.DATALIST;
                }
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@RZDATE",model.RZDATE),
                                       new SqlParameter("@GLQSR",model.GLQSR),
                                       new SqlParameter("@PHONENUMBER",model.PHONENUMBER),
                                       new SqlParameter("@HJADDRESS",model.HJADDRESS),
                                       new SqlParameter("@JZADDRESS",model.JZADDRESS),
                                       new SqlParameter("@XGR",model.XGR),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@YGTYPE",model.YGTYPE),
                                       new SqlParameter("@ZZZT",model.ZZZT),
                                       new SqlParameter("@ISCJ",model.ISCJ),
                                       new SqlParameter("@CJNO",model.CJNO),
                                       new SqlParameter("@ISLS",model.ISLS),
                                       new SqlParameter("@LSNO",model.LSNO),
                                       new SqlParameter("@ISGL",model.ISGL),
                                       new SqlParameter("@ISJZZ",model.ISJZZ),
                                       new SqlParameter("@JZZYYQ",model.JZZYYQ),
                                       new SqlParameter("@ISHY",model.ISHY),
                                       new SqlParameter("@HYNO",model.HYNO),
                                       new SqlParameter("@HYYYQ",model.HYYYQ),
                                       new SqlParameter("@BZ",model.BZ),
                                       new SqlParameter("@ISECRZ",model.ISECRZ),
                                       new SqlParameter("@ZWLEVEL",model.ZWLEVEL)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE_CHECK, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_RYINFO_CHECK", "HR");
            }
            return rst;
        }
        public MES_RETURN UPDATE_YGTYPE_model(HR_RY_RYINFO model, int YGTYPE, int ZZZT)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                DataTable dtold = new DataTable();
                DataTable dtnew = new DataTable();
                MES_SY_TABLE_COLUMN model_MES_SY_TABLE_COLUMN = new MES_SY_TABLE_COLUMN();
                model_MES_SY_TABLE_COLUMN.SY = "HR";
                model_MES_SY_TABLE_COLUMN.SY_TABLE = "HR_RY_RYINFO";
                model_MES_SY_TABLE_COLUMN.ZJVALUES = model.RYID.ToString();
                model_MES_SY_TABLE_COLUMN.STAFFID = model.XGR;
                MES_SY_TABLE_COLUMN_SELECT rst_MES_SY_TABLE_COLUMN_SELECT = SY_TABLE_COLUMNService.SELECT(model_MES_SY_TABLE_COLUMN);
                if (rst_MES_SY_TABLE_COLUMN_SELECT.MES_RETURN.TYPE == "S")
                {
                    dtold = rst_MES_SY_TABLE_COLUMN_SELECT.DATALIST;
                }
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@YGTYPE",YGTYPE),
                                       new SqlParameter("@ZZZT",ZZZT),
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE_YGTYPE, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_RYINFO_YGTYPE", "HR");
            }
            return rst;
        }
        public MES_RETURN UPDATE_YGTYPE(List<HR_RY_RYINFO> model, int YGTYPE, int ZZZT)
        {
            MES_RETURN rst = new MES_RETURN();
            if (model.Count > 0)
            {
                for (int i = 0; i < model.Count; i++)
                {
                    try
                    {
                        rst = UPDATE_YGTYPE_model(model[i], YGTYPE, ZZZT);
                    }
                    catch (Exception e)
                    {
                        rst.TYPE = "E";
                        rst.MESSAGE = e.Message;
                        SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_RYINFO_YGTYPE", "HR");
                    }
                }
            }
            return rst;
        }
        public MES_RETURN UPDATE_DEPT(List<HR_RY_RYINFO> model, int DEPT, int GSBM)
        {
            MES_RETURN rst = new MES_RETURN();
            if (model.Count > 0)
            {
                for (int i = 0; i < model.Count; i++)
                {
                    try
                    {
                        SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model[i].RYID),
                                       new SqlParameter("@DEPT",DEPT),
                                       new SqlParameter("@GSBM",GSBM)
                                   };

                        using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE_DEPT, parms))
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
                        SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_RYINFO_DEPT", "HR");
                    }
                }
            }
            return rst;
        }
        public MES_RETURN UPDATE_JOBS(List<HR_RY_RYINFO> model, int JOBS)
        {
            MES_RETURN rst = new MES_RETURN();
            if (model.Count > 0)
            {
                for (int i = 0; i < model.Count; i++)
                {
                    try
                    {
                        SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model[i].RYID),
                                       new SqlParameter("@JOBS",JOBS),

                                   };

                        using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE_JOBS, parms))
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
                        SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_RYINFO_JOBS", "HR");
                    }
                }
            }
            return rst;
        }
        public MES_RETURN UPDATE_QUIT(HR_RY_RYINFO model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@ZZZT",model.ZZZT),
                                       new SqlParameter("@LZRQ",model.LZRQ),
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE_QUIT, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_RYINFO_QUIT", "HR");
            }
            return rst;
        }
        public MES_RETURN UPDATE_CHANGEINFO(HR_RY_RYINFO_CHANGEINFO model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@CHANGERQ",model.CHANGERQ),
                                       new SqlParameter("@CHANGELB",model.CHANGELB),
                                       new SqlParameter("@NEW",model.NEW),
                                       new SqlParameter("@CHANGGEYY",model.CHANGGEYY),
                                       new SqlParameter("@CJR",model.CJR)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE_CHANGEINFO, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_RYINFO_CHANGEINFO", "HR");
            }
            return rst;
        }
        public MES_RETURN UPDATE_ISINGH(HR_RY_RYINFO model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@ISINGH",model.ISINGH),
                                       new SqlParameter("@GHDATE",model.GHDATE),
                                       new SqlParameter("@XGR",model.XGR),
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE_ISINGH, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_RYINFO_ISINGH", "HR");
            }
            return rst;
        }
        public MES_RETURN UPDATE_DUTYNAME(HR_RY_RYINFO model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@DUTYNAME",model.DUTYNAME)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_UPDATE_DUTYNAME, parms))
                {
                    rst.TYPE = "S";
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_RYINFO_DUTYNAME_UPDATE", "HR");
            }
            return rst;
        }
        public MES_RETURN UPDATE_LB(HR_RY_RYINFO model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@DUTYNAME",model.DUTYNAME),
                                       new SqlParameter("@ZWLEVEL",model.ZWLEVEL),
                                       new SqlParameter("@LB",model.LB)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE_LB, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_RYINFO_UPDATE_LB", "HR");
            }
            return rst;
        }
        public HR_RY_RYINFO_SELECT SELECT_GSGL(HR_RY_RYINFO model)
        {
            HR_RY_RYINFO_SELECT rst = new HR_RY_RYINFO_SELECT();
            List<HR_RY_RYINFO_LIST> model_HR_RY_RYINFO_LIST = new List<HR_RY_RYINFO_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@ALLGS",model.ALLGS),
                                       new SqlParameter("@DEPT",model.DEPT),
                                       new SqlParameter("@NOSELECT",model.NOSELECT),
                                       new SqlParameter("@GSDATEKS",model.DATEKS),
                                       new SqlParameter("@GSDATEJS",model.DATEJS)
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_GSGL, parms))
                {
                    while (sdr.Read())
                    {
                        HR_RY_RYINFO_LIST child = new HR_RY_RYINFO_LIST();
                        child.RYID = Convert.ToInt32(sdr["RYID"]);
                        child.GS = Convert.ToString(sdr["GS"]);
                        child.YGNAME = Convert.ToString(sdr["YGNAME"]);
                        child.DEPT = Convert.ToInt32(sdr["DEPT"]);
                        child.DEPTNAME = Convert.ToString(sdr["DEPTNAME"]);
                        child.GSBM = Convert.ToInt32(sdr["GSBM"]);
                        child.GSBMNAME = Convert.ToString(sdr["GSBMNAME"]);
                        child.ZZZT = Convert.ToInt32(sdr["ZZZT"]);
                        child.ZZZTNAME = Convert.ToString(sdr["ZZZTNAME"]);
                        child.RZDATE = Convert.ToString(sdr["RZDATE"]);
                        child.LZRQ = Convert.ToString(sdr["LZRQ"]);
                        child.GH = Convert.ToString(sdr["GH"]).Substring(5, 5);
                        child.ZZTYPE = Convert.ToInt32(sdr["ZZTYPE"]);
                        child.ZZTYPENAME = Convert.ToString(sdr["ZZTYPENAME"]);
                        child.ZZNO = Convert.ToString(sdr["ZZNO"]);
                        child.BIRTHDAT = Convert.ToString(sdr["BIRTHDAT"]);
                        child.YGXZ = Convert.ToInt32(sdr["YGXZ"]);
                        child.YGXZNAME = Convert.ToString(sdr["YGXZNAME"]);
                        child.YGTYPE = Convert.ToInt32(sdr["YGTYPE"]);
                        child.YGTYPENAME = Convert.ToString(sdr["YGTYPENAME"]);
                        child.JOBSNAME = Convert.ToString(sdr["GSJOBSNAME"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.ISINGH = Convert.ToInt32(sdr["ISINGH"]);
                        child.GHDATE = Convert.ToString(sdr["GHDATE"]);
                        child.CJR = Convert.ToInt32(sdr["CJR"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJTIME = Convert.ToString(sdr["CJTIME"]);
                        child.XGR = Convert.ToInt32(sdr["XGR"]);
                        child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                        child.XGTIME = Convert.ToString(sdr["XGTIME"]);
                        child.GSNAME = Convert.ToString(sdr["GSNAME"]);
                        child.IMAGEURL = Convert.ToString(sdr["IMAGEURL"]);
                        child.ZCNAME = Convert.ToString(sdr["ZCNAME"]);

                        child.GSID = Convert.ToInt32(sdr["GSID"]);
                        child.GSDATE = Convert.ToString(sdr["GSDATE"]);
                        child.GSLEVEL = Convert.ToInt32(sdr["GSLEVEL"]);
                        child.GSLEVELNAME = Convert.ToString(sdr["GSLEVELNAME"]);
                        child.YLKSDATE = Convert.ToString(sdr["YLKSDATE"]);
                        child.YLJSDATE = Convert.ToString(sdr["YLJSDATE"]);
                        child.GSREMARK = Convert.ToString(sdr["GSREMARK"]);
                        model_HR_RY_RYINFO_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_GSGL_SELECT", "HR");
            }
            rst.HR_RY_RYINFO_LIST = model_HR_RY_RYINFO_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public HR_RY_RYINFO_SELECT SELECT_WJGL(HR_RY_RYINFO model)
        {
            HR_RY_RYINFO_SELECT rst = new HR_RY_RYINFO_SELECT();
            List<HR_RY_RYINFO_LIST> model_HR_RY_RYINFO_LIST = new List<HR_RY_RYINFO_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@ALLGS",model.ALLGS),
                                       new SqlParameter("@DEPT",model.DEPT),
                                       new SqlParameter("@NOSELECT",model.NOSELECT),
                                       new SqlParameter("@DATEKS",model.DATEKS),
                                       new SqlParameter("@DATEJS",model.DATEJS)
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_WJGL, parms))
                {
                    while (sdr.Read())
                    {
                        HR_RY_RYINFO_LIST child = new HR_RY_RYINFO_LIST();
                        child.RYID = Convert.ToInt32(sdr["RYID"]);
                        child.GS = Convert.ToString(sdr["GS"]);
                        child.YGNAME = Convert.ToString(sdr["YGNAME"]);
                        child.DEPT = Convert.ToInt32(sdr["DEPT"]);
                        child.DEPTNAME = Convert.ToString(sdr["DEPTNAME"]);
                        child.GSBM = Convert.ToInt32(sdr["GSBM"]);
                        child.GSBMNAME = Convert.ToString(sdr["GSBMNAME"]);
                        child.ZZZT = Convert.ToInt32(sdr["ZZZT"]);
                        child.ZZZTNAME = Convert.ToString(sdr["ZZZTNAME"]);
                        child.RZDATE = Convert.ToString(sdr["RZDATE"]);
                        child.LZRQ = Convert.ToString(sdr["LZRQ"]);
                        child.GH = Convert.ToString(sdr["GH"]).Substring(5, 5);
                        child.ZZTYPE = Convert.ToInt32(sdr["ZZTYPE"]);
                        child.ZZTYPENAME = Convert.ToString(sdr["ZZTYPENAME"]);
                        child.ZZNO = Convert.ToString(sdr["ZZNO"]);
                        child.BIRTHDAT = Convert.ToString(sdr["BIRTHDAT"]);
                        child.XB = Convert.ToString(sdr["XB"]);
                        child.SFZYXRQ = Convert.ToString(sdr["SFZYXRQ"]);
                        child.YGXZ = Convert.ToInt32(sdr["YGXZ"]);
                        child.YGXZNAME = Convert.ToString(sdr["YGXZNAME"]);
                        child.YGTYPE = Convert.ToInt32(sdr["YGTYPE"]);
                        child.YGTYPENAME = Convert.ToString(sdr["YGTYPENAME"]);
                        child.GLQSR = Convert.ToString(sdr["GLQSR"]);
                        child.GHOLD = Convert.ToString(sdr["GHOLD"]);
                        child.DUTYNAME = Convert.ToString(sdr["DUTYNAME"]);
                        child.JOBS = Convert.ToInt32(sdr["JOBS"]);
                        child.JOBSNAME = Convert.ToString(sdr["JOBSNAME"]);
                        child.GJ = Convert.ToInt32(sdr["GJ"]);
                        child.GJNAME = Convert.ToString(sdr["GJNAME"]);
                        child.PX = Convert.ToInt32(sdr["PX"]);
                        child.HYZK = Convert.ToInt32(sdr["HYZK"]);
                        child.HYZKNAME = Convert.ToString(sdr["HYZKNAME"]);
                        child.ZZMM = Convert.ToInt32(sdr["ZZMM"]);
                        child.ZZMMNAME = Convert.ToString(sdr["ZZMMNAME"]);
                        child.HJADDRESS = Convert.ToString(sdr["HJADDRESS"]);
                        child.JZADDRESS = Convert.ToString(sdr["JZADDRESS"]);
                        child.PHONENUMBER = Convert.ToString(sdr["PHONENUMBER"]);
                        child.EMAIL = Convert.ToString(sdr["EMAIL"]);
                        child.JG = Convert.ToString(sdr["JG"]);
                        child.MZ = Convert.ToInt32(sdr["MZ"]);
                        child.MZNAME = Convert.ToString(sdr["MZNAME"]);
                        child.NSRSBH = Convert.ToString(sdr["NSRSBH"]);
                        child.NSRSF = Convert.ToInt32(sdr["NSRSF"]);
                        child.NSRSFNAME = Convert.ToString(sdr["NSRSFNAME"]);
                        child.ZY = Convert.ToString(sdr["ZY"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.ISINGH = Convert.ToInt32(sdr["ISINGH"]);
                        child.GHDATE = Convert.ToString(sdr["GHDATE"]);
                        child.CJR = Convert.ToInt32(sdr["CJR"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJTIME = Convert.ToString(sdr["CJTIME"]);
                        child.XGR = Convert.ToInt32(sdr["XGR"]);
                        child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                        child.XGTIME = Convert.ToString(sdr["XGTIME"]);
                        child.STUDEFS = Convert.ToInt32(sdr["STUDEFS"]);
                        child.STUDEFSNAME = Convert.ToString(sdr["STUDEFSNAME"]);
                        child.EDUCACTION = Convert.ToInt32(sdr["EDUCACTION"]);
                        child.EDUCACTIONNAME = Convert.ToString(sdr["EDUCACTIONNAME"]);
                        child.GSNAME = Convert.ToString(sdr["GSNAME"]);
                        child.IMAGEURL = Convert.ToString(sdr["IMAGEURL"]);
                        child.ZCNAME = Convert.ToString(sdr["ZCNAME"]);

                        child.WJID = Convert.ToInt32(sdr["WJID"]);
                        child.FSDATE = Convert.ToString(sdr["FSDATE"]);
                        child.SM = Convert.ToString(sdr["SM"]);
                        model_HR_RY_RYINFO_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_GSGL_SELECT", "HR");
            }
            rst.HR_RY_RYINFO_LIST = model_HR_RY_RYINFO_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public HR_RY_RYINFO_SELECT SELECT_WBZW(HR_RY_RYINFO model)
        {
            HR_RY_RYINFO_SELECT rst = new HR_RY_RYINFO_SELECT();
            List<HR_RY_RYINFO_LIST> model_HR_RY_RYINFO_LIST = new List<HR_RY_RYINFO_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@ALLGS",model.ALLGS),
                                       new SqlParameter("@GSBM",model.GSBM),
                                       new SqlParameter("@NOSELECT",model.NOSELECT)
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_WBZW, parms))
                {
                    while (sdr.Read())
                    {
                        HR_RY_RYINFO_LIST child = new HR_RY_RYINFO_LIST();
                        child.RYID = Convert.ToInt32(sdr["RYID"]);
                        child.GS = Convert.ToString(sdr["GS"]);
                        child.YGNAME = Convert.ToString(sdr["YGNAME"]);
                        child.DEPT = Convert.ToInt32(sdr["DEPT"]);
                        child.DEPTNAME = Convert.ToString(sdr["DEPTNAME"]);
                        child.GSBM = Convert.ToInt32(sdr["GSBM"]);
                        child.GSBMNAME = Convert.ToString(sdr["GSBMNAME"]);
                        child.ZZZT = Convert.ToInt32(sdr["ZZZT"]);
                        child.ZZZTNAME = Convert.ToString(sdr["ZZZTNAME"]);
                        child.RZDATE = Convert.ToString(sdr["RZDATE"]);
                        child.LZRQ = Convert.ToString(sdr["LZRQ"]);
                        child.GH = Convert.ToString(sdr["GH"]).Substring(5, 5);
                        child.ZZTYPE = Convert.ToInt32(sdr["ZZTYPE"]);
                        child.ZZTYPENAME = Convert.ToString(sdr["ZZTYPENAME"]);
                        child.ZZNO = Convert.ToString(sdr["ZZNO"]);
                        child.BIRTHDAT = Convert.ToString(sdr["BIRTHDAT"]);
                        child.XB = Convert.ToString(sdr["XB"]);
                        child.SFZYXRQ = Convert.ToString(sdr["SFZYXRQ"]);
                        child.YGXZ = Convert.ToInt32(sdr["YGXZ"]);
                        child.YGXZNAME = Convert.ToString(sdr["YGXZNAME"]);
                        child.YGTYPE = Convert.ToInt32(sdr["YGTYPE"]);
                        child.YGTYPENAME = Convert.ToString(sdr["YGTYPENAME"]);
                        child.GLQSR = Convert.ToString(sdr["GLQSR"]);
                        child.GHOLD = Convert.ToString(sdr["GHOLD"]);
                        child.DUTYNAME = Convert.ToString(sdr["DUTYNAME"]);
                        child.JOBS = Convert.ToInt32(sdr["JOBS"]);
                        child.JOBSNAME = Convert.ToString(sdr["JOBSNAME"]);
                        child.GJ = Convert.ToInt32(sdr["GJ"]);
                        child.GJNAME = Convert.ToString(sdr["GJNAME"]);
                        child.PX = Convert.ToInt32(sdr["PX"]);
                        child.HYZK = Convert.ToInt32(sdr["HYZK"]);
                        child.HYZKNAME = Convert.ToString(sdr["HYZKNAME"]);
                        child.ZZMM = Convert.ToInt32(sdr["ZZMM"]);
                        child.ZZMMNAME = Convert.ToString(sdr["ZZMMNAME"]);
                        child.HJADDRESS = Convert.ToString(sdr["HJADDRESS"]);
                        child.JZADDRESS = Convert.ToString(sdr["JZADDRESS"]);
                        child.PHONENUMBER = Convert.ToString(sdr["PHONENUMBER"]);
                        child.EMAIL = Convert.ToString(sdr["EMAIL"]);
                        child.JG = Convert.ToString(sdr["JG"]);
                        child.MZ = Convert.ToInt32(sdr["MZ"]);
                        child.MZNAME = Convert.ToString(sdr["MZNAME"]);
                        child.NSRSBH = Convert.ToString(sdr["NSRSBH"]);
                        child.NSRSF = Convert.ToInt32(sdr["NSRSF"]);
                        child.NSRSFNAME = Convert.ToString(sdr["NSRSFNAME"]);
                        child.ZY = Convert.ToString(sdr["ZY"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.ISINGH = Convert.ToInt32(sdr["ISINGH"]);
                        child.GHDATE = Convert.ToString(sdr["GHDATE"]);
                        child.CJR = Convert.ToInt32(sdr["CJR"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJTIME = Convert.ToString(sdr["CJTIME"]);
                        child.XGR = Convert.ToInt32(sdr["XGR"]);
                        child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                        child.XGTIME = Convert.ToString(sdr["XGTIME"]);
                        child.STUDEFS = Convert.ToInt32(sdr["STUDEFS"]);
                        child.STUDEFSNAME = Convert.ToString(sdr["STUDEFSNAME"]);
                        child.EDUCACTION = Convert.ToInt32(sdr["EDUCACTION"]);
                        child.EDUCACTIONNAME = Convert.ToString(sdr["EDUCACTIONNAME"]);
                        child.GSNAME = Convert.ToString(sdr["GSNAME"]);
                        child.IMAGEURL = Convert.ToString(sdr["IMAGEURL"]);
                        child.ZCNAME = Convert.ToString(sdr["ZCNAME"]);

                        child.WBZWID = Convert.ToInt32(sdr["WBZWID"]);
                        child.WBZWNAME = Convert.ToString(sdr["WBZWNAME"]);
                        child.WBZWDW = Convert.ToString(sdr["WBZWDW"]);
                        child.WBPYRQ = Convert.ToString(sdr["WBPYRQ"]);
                        child.WBJZRQ = Convert.ToString(sdr["WBJZRQ"]);
                        child.WBZWREMARK = Convert.ToString(sdr["WBZWREMARK"]);
                        model_HR_RY_RYINFO_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_WBZW_SELECT", "HR");
            }
            rst.HR_RY_RYINFO_LIST = model_HR_RY_RYINFO_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN INSERT_RONGY(HR_RY_RONGY model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RONGYLB",model.RONGYLB),
                                       new SqlParameter("@RONGYNAME",model.RONGYNAME),
                                       new SqlParameter("@BJDW",model.BJDW),
                                       new SqlParameter("@RONGYJB",model.RONGYJB),
                                       new SqlParameter("@HJRQ",model.HJRQ),
                                       new SqlParameter("@YXQKS",model.YXQKS),
                                       new SqlParameter("@YXQJS",model.YXQJS),
                                       new SqlParameter("@ZZJG",model.ZZJG),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@CJR",model.CJR),
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT_RONGY, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                        rst.TID = Convert.ToInt32(sdr["MAXRONGYID"]);
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_RONGY_INSERT", "HR");
            }
            return rst;
        }
        public HR_RY_RONGY_SELECT SELECT_RONGY(HR_RY_RONGY model)
        {
            HR_RY_RONGY_SELECT rst = new HR_RY_RONGY_SELECT();
            List<HR_RY_RONGY_LIST> model_HR_RY_RONGY_LIST = new List<HR_RY_RONGY_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RONGYND",model.RONGYND),
                                       new SqlParameter("@RONGYLB",model.RONGYLB),
                                       new SqlParameter("@RONGYJB",model.RONGYJB),
                                       new SqlParameter("@RONGYNO",model.RONGYNO),
                                       new SqlParameter("@RONGYNAME",model.RONGYNAME),
                                       new SqlParameter("@BJDW",model.BJDW),
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_RONGY, parms))
                {
                    while (sdr.Read())
                    {
                        HR_RY_RONGY_LIST child = new HR_RY_RONGY_LIST();
                        child.RONGYID = Convert.ToInt32(sdr["RONGYID"]);
                        child.RONGYLB = Convert.ToInt32(sdr["RONGYLB"]);
                        child.RONGYLBNAME = Convert.ToString(sdr["RONGYLBNAME"]);
                        child.RONGYJB = Convert.ToInt32(sdr["RONGYJB"]);
                        child.RONGYJBNAME = Convert.ToString(sdr["RONGYJBNAME"]);
                        child.RONGYNAME = Convert.ToString(sdr["RONGYNAME"]);
                        child.BJDW = Convert.ToString(sdr["BJDW"]);
                        child.HJRQ = Convert.ToString(sdr["HJRQ"]);
                        child.YXQKS = Convert.ToString(sdr["YXQKS"]);
                        child.YXQJS = Convert.ToString(sdr["YXQJS"]);
                        child.ZZJG = Convert.ToString(sdr["ZZJG"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.CJR = Convert.ToInt32(sdr["CJR"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJTIME = Convert.ToString(sdr["CJTIME"]);
                        child.XGR = Convert.ToInt32(sdr["XGR"]);
                        child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                        child.XGRTIME = Convert.ToString(sdr["XGRTIME"]);
                        child.YGNAMEALL = Convert.ToString(sdr["YGNAMEALL"]);
                        child.RYIDALL = Convert.ToString(sdr["RYIDALL"]);
                        model_HR_RY_RONGY_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_RONGY_SELECT", "HR");
            }
            rst.HR_RY_RONGY_LIST = model_HR_RY_RONGY_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN UPDATE_RONGY(HR_RY_RONGY model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RONGYID",model.RONGYID),
                                       new SqlParameter("@RONGYLB",model.RONGYLB),
                                       new SqlParameter("@RONGYJB",model.RONGYJB),
                                       new SqlParameter("@RONGYNAME",model.RONGYNAME),
                                       new SqlParameter("@BJDW",model.BJDW),
                                       new SqlParameter("@HJRQ",model.HJRQ),
                                       new SqlParameter("@YXQKS",model.YXQKS),
                                       new SqlParameter("@YXQJS",model.YXQJS),
                                       new SqlParameter("@ZZJG",model.ZZJG),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@XGR",model.XGR),
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE_RONGY, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_RONGY_UPDATE", "HR");
            }
            return rst;
        }
        public MES_RETURN DELETE_RONGY(int RONGYID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RONGYID",RONGYID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DELETE_RONGY, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_RONGY_DELETE", "HR");
            }
            return rst;
        }
        public MES_RETURN INSERT_RONGY_RYID(int RONGYID, int RYID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",RYID),
                                       new SqlParameter("@RONGYID",RONGYID),
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_INSERT_RONGY_RYID, parms))
                {
                    rst.TYPE = "S";
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_RONGY_INSERT_RONGY_RYID", "HR");
            }
            return rst;
        }
        public MES_RETURN DELETE_RONGY_RYID(int RONGYID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RONGYID",RONGYID),
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_DELETE_RONGY_RYID, parms))
                {
                    rst.TYPE = "S";
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_RONGY_DELETE_RONGY_RYID", "HR");
            }
            return rst;
        }
        public HR_RY_RONGY_SELECT SELECT_RONGY_RYID(int RYID)
        {
            HR_RY_RONGY_SELECT rst = new HR_RY_RONGY_SELECT();
            List<HR_RY_RONGY_LIST> model_HR_RY_RONGY_LIST = new List<HR_RY_RONGY_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",RYID),
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_RONGY_RYID, parms))
                {
                    while (sdr.Read())
                    {
                        HR_RY_RONGY_LIST child = new HR_RY_RONGY_LIST();
                        child.RONGYID = Convert.ToInt32(sdr["RONGYID"]);
                        child.RONGYLB = Convert.ToInt32(sdr["RONGYLB"]);
                        child.RONGYLBNAME = Convert.ToString(sdr["RONGYLBNAME"]);
                        child.RONGYJB = Convert.ToInt32(sdr["RONGYJB"]);
                        child.RONGYJBNAME = Convert.ToString(sdr["RONGYJBNAME"]);
                        child.RONGYNAME = Convert.ToString(sdr["RONGYNAME"]);
                        child.BJDW = Convert.ToString(sdr["BJDW"]);
                        child.HJRQ = Convert.ToString(sdr["HJRQ"]);
                        child.YXQKS = Convert.ToString(sdr["YXQKS"]);
                        child.YXQJS = Convert.ToString(sdr["YXQJS"]);
                        child.ZZJG = Convert.ToString(sdr["ZZJG"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.CJR = Convert.ToInt32(sdr["CJR"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJTIME = Convert.ToString(sdr["CJTIME"]);
                        child.XGR = Convert.ToInt32(sdr["XGR"]);
                        child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                        child.XGRTIME = Convert.ToString(sdr["XGRTIME"]);
                        model_HR_RY_RONGY_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_RONGY_RYID_SELECT", "HR");
            }
            rst.HR_RY_RONGY_LIST = model_HR_RY_RONGY_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN INSERT_RONGY_FILE(HR_RY_RONGY model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RONGYID",model.RONGYID),
                                       new SqlParameter("@FILEURL",model.FILEURL),
                                       new SqlParameter("@CJR",model.CJR),
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT_RONGY_FILE, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_RONGY_FILE_INSERT", "HR");
            }
            return rst;
        }
        public HR_RY_RONGY_SELECT SELECT_RONGY_FILE(int RONGYID)
        {
            HR_RY_RONGY_SELECT rst = new HR_RY_RONGY_SELECT();
            List<HR_RY_RONGY_LIST> model_HR_RY_RONGY_LIST = new List<HR_RY_RONGY_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RONGYID",RONGYID)
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT_RONGY_FILE, parms))
                {
                    while (sdr.Read())
                    {
                        HR_RY_RONGY_LIST child = new HR_RY_RONGY_LIST();
                        child.RONGYID = Convert.ToInt32(sdr["RONGYID"]);
                        child.RYFILEID = Convert.ToInt32(sdr["RYFILEID"]);
                        child.FILEURL = Convert.ToString(sdr["FILEURL"]);
                        model_HR_RY_RONGY_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_RONGY_FILE_SELECT", "HR");
            }
            rst.HR_RY_RONGY_LIST = model_HR_RY_RONGY_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN DELETE_RONGY_FILE(int RYFILEID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYFILEID",RYFILEID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_DELETE_RONGY_FILE, parms))
                {
                    rst.TYPE = "S";
                    rst.MESSAGE = "";
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_RONGY_FILE_DELETE", "HR");
            }
            return rst;
        }
        public HR_RY_LZINFO_SELECT SELECT_LZINFO(HR_RY_RYINFO model)
        {
            HR_RY_LZINFO_SELECT rst = new HR_RY_LZINFO_SELECT();
            List<HR_RY_LZINFO_LIST> model_HR_RY_LZINFO_LIST = new List<HR_RY_LZINFO_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@LZRQ",model.LZRQ),
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_LZINFO, parms))
                {
                    while (sdr.Read())
                    {
                        HR_RY_LZINFO_LIST child = new HR_RY_LZINFO_LIST();
                        child.FSDATE = Convert.ToString(sdr["FSDATE"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        model_HR_RY_LZINFO_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_LZINFO_SELECT", "HR");
            }
            rst.HR_RY_LZINFO_LIST = model_HR_RY_LZINFO_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }

        public HR_RY_CHANGEINFO_SELECT SELECT_RY_CHANGEINFO(HR_RY_RYINFO_CHANGEINFO model)
        {
            HR_RY_CHANGEINFO_SELECT rst = new HR_RY_CHANGEINFO_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                           new SqlParameter("@RYID",model.RYID),
                                           new SqlParameter("@CHANGERQ",model.CHANGERQ),
                                           new SqlParameter("@CHANGELB",model.CHANGELB)
                                   };
                rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_RY_CHANGEINFO_SELECT, paras);
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_CHANGEINFO_SELECT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
    }
}

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
    public class RY_RYINFO_RSDA : IRY_RYINFO_RSDA
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_JYJL_INSERT = "HR_RY_JYJL_INSERT";
        const string SQL_JYJL_SELECT = "SELECT * FROM HR_RY_JYJL WHERE RYID=@RYID ORDER BY RYID,ISSHOW DESC";
        const string SQL_JYJL_DELETE = "DELETE FROM HR_RY_JYJL WHERE EDUID=@EDUID";
        const string SQL_JYJL_UPDATE = "HR_RY_JYJL_UPDATE";
        const string SQL_GRJL_INSERT = "HR_RY_GRJL_INSERT";
        const string SQL_GRJL_SELECT = "SELECT A.*,(SELECT GSNAME FROM HR_SY_GS WHERE GS=A.GS) AS GSNAME FROM HR_RY_GRJL AS A WHERE RYID=@RYID";
        const string SQL_GRJL_UPDATE = "HR_RY_GRJL_UPDATE";
        const string SQL_GRJL_DELETE = "DELETE FROM HR_RY_GRJL WHERE GRJLID=@GRJLID";
        const string SQL_HOMEGX_INSERT = "HR_RY_HOMEGX_INSERT";
        const string SQL_HOMEGX_SELECT = "SELECT * FROM HR_RY_HOMEGX WHERE RYID=@RYID";
        const string SQL_HOMEGX_UPDATE = "HR_RY_HOMEGX_UPDATE";
        const string SQL_HOMEGX_DELETE = "DELETE FROM HR_RY_HOMEGX WHERE JTGXID=@JTGXID";
        const string SQL_GSGL_INSERT = "HR_RY_GSGL_INSERT";
        const string SQL_GSGL_SELECT = "SELECT * FROM HR_RY_GSGL WHERE RYID=@RYID";
        const string SQL_GSGL_UPDATE = "HR_RY_GSGL_UPDATE";
        const string SQL_GSGL_DELETE = "DELETE FROM HR_RY_GSGL WHERE GSID=@GSID";
        const string SQL_WJGL_INSERT = "HR_RY_WJGL_INSERT";
        const string SQL_WJGL_SELECT = "SELECT * FROM HR_RY_WJGL WHERE RYID=@RYID";
        const string SQL_WJGL_UPDATE = "HR_RY_WJGL_UPDATE";
        const string SQL_WJGL_DELETE = "DELETE FROM HR_RY_WJGL WHERE WJID=@WJID";
        const string SQL_HT_INSERT = "HR_RY_HT_INSERT";
        const string SQL_HT_SELECT = "SELECT A.*,(SELECT GSNAME FROM HR_SY_GS AS B WHERE B.GS=A.GS) AS GSNAME FROM HR_RY_HT AS A WHERE A.RYID=@RYID AND ISDELETE=0 ORDER BY SXRQ DESC";
        const string SQL_HT_UPDATE = "HR_RY_HT_UPDATE";
        const string SQL_HT_UPDATE_HTQCS = "UPDATE HR_RY_RYINFO SET HTQCS=@HTQCS WHERE RYID=@RYID;";
        const string SQL_HT_DELETE = "UPDATE HR_RY_HT SET ISDELETE=1 WHERE HTID=@HTID";
        const string SQL_ZC_INSERT = "HR_RY_ZC_INSERT";
        const string SQL_ZC_SELECT = "SELECT * FROM HR_RY_ZC WHERE RYID=@RYID ORDER BY RYID,ISBJSHOW DESC";
        const string SQL_RY_ZC_SELECT = "HR_RY_ZC_SELECT";
        const string SQL_ZC_UPDATE = "HR_RY_ZC_UPDATE";
        const string SQL_ZC_DELETE = "DELETE FROM HR_RY_ZC WHERE ZCID=@ZCID";
        const string SQL_WBZW_INSERT = "HR_RY_WBZW_INSERT";
        const string SQL_WBZW_SELECT = "SELECT * FROM HR_RY_WBZW WHERE RYID=@RYID";
        const string SQL_WBZW_UPDATE = "HR_RY_WBZW_UPDATE";
        const string SQL_WBZW_DELETE = "DELETE FROM HR_RY_WBZW WHERE WBZWID=@WBZWID";

        public MES_RETURN JYJL_INSERT(HR_RY_JYJL model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@XL",model.XL),
                                       new SqlParameter("@ZY",model.ZY),
                                       new SqlParameter("@SCHOOL",model.SCHOOL),
                                       new SqlParameter("@KSDATE",model.KSDATE),
                                       new SqlParameter("@JSDATE",model.JSDATE),
                                       new SqlParameter("@ZSNO",model.ZSNO),
                                       new SqlParameter("@XXFS",model.XXFS),
                                       new SqlParameter("@ISSHOW",model.ISSHOW),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@CJR",model.CJR),
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_JYJL_INSERT, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_JYJL_INSERT", "HR");
            }
            return rst;
        }
        public HR_RY_JYJL_SELECT JYJL_SELECT(HR_RY_JYJL model)
        {
            HR_RY_JYJL_SELECT rst = new HR_RY_JYJL_SELECT();
            List<HR_RY_JYJL_LIST> model_HR_RY_JYJL_LIST = new List<HR_RY_JYJL_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID)
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_JYJL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        HR_RY_JYJL_LIST child = new HR_RY_JYJL_LIST();
                        child.RYID = Convert.ToInt32(sdr["RYID"]);
                        child.EDUID = Convert.ToInt32(sdr["EDUID"]);
                        child.XL = Convert.ToInt32(sdr["XL"]);
                        child.XLNAME = Convert.ToString(sdr["XLNAME"]);
                        child.ZY = Convert.ToString(sdr["ZY"]);
                        child.SCHOOL = Convert.ToString(sdr["SCHOOL"]);
                        child.KSDATE = Convert.ToString(sdr["KSDATE"]);
                        child.JSDATE = Convert.ToString(sdr["JSDATE"]);
                        child.ZSNO = Convert.ToString(sdr["ZSNO"]);
                        child.XXFS = Convert.ToInt32(sdr["XXFS"]);
                        child.XXFSNAME = Convert.ToString(sdr["XXFSNAME"]);
                        child.ISSHOW = Convert.ToInt32(sdr["ISSHOW"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.CJR = Convert.ToInt32(sdr["CJR"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJTIME = Convert.ToString(sdr["CJTIME"]);
                        child.XGR = Convert.ToInt32(sdr["XGR"]);
                        child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                        child.XGRTIME = Convert.ToString(sdr["XGRTIME"]);
                        model_HR_RY_JYJL_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_JYJL_SELECT", "HR");
            }
            rst.HR_RY_JYJL_LIST = model_HR_RY_JYJL_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN JYJL_UPDATE(HR_RY_JYJL model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@EDUID",model.EDUID),
                                       new SqlParameter("@XL",model.XL),
                                       new SqlParameter("@ZY",model.ZY),
                                       new SqlParameter("@SCHOOL",model.SCHOOL),
                                       new SqlParameter("@KSDATE",model.KSDATE),
                                       new SqlParameter("@JSDATE",model.JSDATE),
                                       new SqlParameter("@ZSNO",model.ZSNO),
                                       new SqlParameter("@XXFS",model.XXFS),
                                       new SqlParameter("@ISSHOW",model.ISSHOW),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@XGR",model.XGR),
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_JYJL_UPDATE, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_JYJL_UPDATE", "HR");
            }
            return rst;
        }
        public MES_RETURN JYJL_DELETE(int EDUID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@EDUID", EDUID),
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_JYJL_DELETE, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
                rst.TYPE = "S";
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_JYJL_DELETE", "HR");
            }
            return rst;
        }
        public MES_RETURN GRJL_INSERT(HR_RY_GRJL model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@KSDATE",model.KSDATE),
                                       new SqlParameter("@JSDATE",model.JSDATE),
                                       new SqlParameter("@DEPTNAME",model.DEPTNAME),
                                       new SqlParameter("@DUTYNAME",model.DUTYNAME),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@CJR",model.CJR),
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_GRJL_INSERT, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_GRJL_INSERT", "HR");
            }
            return rst;
        }
        public HR_RY_GRJL_SELECT GRJL_SELECT(HR_RY_GRJL model)
        {
            HR_RY_GRJL_SELECT rst = new HR_RY_GRJL_SELECT();
            List<HR_RY_GRJL_LIST> model_HR_RY_GRJL_LIST = new List<HR_RY_GRJL_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID)
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_GRJL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        HR_RY_GRJL_LIST child = new HR_RY_GRJL_LIST();
                        child.RYID = Convert.ToInt32(sdr["RYID"]);
                        child.GRJLID = Convert.ToInt32(sdr["GRJLID"]);
                        child.GS = Convert.ToString(sdr["GS"]);
                        child.GSNAME = Convert.ToString(sdr["GSNAME"]);
                        child.KSDATE = Convert.ToString(sdr["KSDATE"]);
                        child.JSDATE = Convert.ToString(sdr["JSDATE"]);
                        child.DEPT = Convert.ToInt32(sdr["DEPT"]);
                        child.DEPTNAME = Convert.ToString(sdr["DEPTNAME"]);
                        child.DUTY = Convert.ToInt32(sdr["DUTY"]);
                        child.DUTYNAME = Convert.ToString(sdr["DUTYNAME"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.CJR = Convert.ToInt32(sdr["CJR"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJTIME = Convert.ToString(sdr["CJTIME"]);
                        child.XGR = Convert.ToInt32(sdr["XGR"]);
                        child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                        child.XGRTIME = Convert.ToString(sdr["XGRTIME"]);
                        model_HR_RY_GRJL_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_GRJL_SELECT", "HR");
            }
            rst.HR_RY_GRJL_LIST = model_HR_RY_GRJL_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN GRJL_UPDATE(HR_RY_GRJL model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GRJLID",model.GRJLID),
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@KSDATE",model.KSDATE),
                                       new SqlParameter("@JSDATE",model.JSDATE),
                                       new SqlParameter("@DEPTNAME",model.DEPTNAME),
                                       new SqlParameter("@DUTYNAME",model.DUTYNAME),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@XGR",model.XGR)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_GRJL_UPDATE, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_GRJL_UPDATE", "HR");
            }
            return rst;
        }
        public MES_RETURN GRJL_DELETE(int GRJLID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GRJLID", GRJLID),
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_GRJL_DELETE, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
                rst.TYPE = "S";
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_GRJL_DELETE", "HR");
            }
            return rst;
        }
        public MES_RETURN HOMEGX_INSERT(HR_RY_HOMEGX model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@GXLB",model.GXLB),
                                       new SqlParameter("@GXNAME",model.GXNAME),
                                       new SqlParameter("@GXDW",model.GXDW),
                                       new SqlParameter("@GXADDRESS",model.GXADDRESS),
                                       new SqlParameter("@GXPHONE",model.GXPHONE),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@CJR",model.CJR),
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_HOMEGX_INSERT, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_HOMEGX_INSERT", "HR");
            }
            return rst;
        }
        public HR_RY_HOMEGX_SELECT HOMEGX_SELECT(HR_RY_HOMEGX model)
        {
            HR_RY_HOMEGX_SELECT rst = new HR_RY_HOMEGX_SELECT();
            List<HR_RY_HOMEGX_LIST> model_HR_RY_HOMEGX_LIST = new List<HR_RY_HOMEGX_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID)
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_HOMEGX_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        HR_RY_HOMEGX_LIST child = new HR_RY_HOMEGX_LIST();
                        child.RYID = Convert.ToInt32(sdr["RYID"]);
                        child.JTGXID = Convert.ToInt32(sdr["JTGXID"]);
                        child.GXLB = Convert.ToInt32(sdr["GXLB"]);
                        child.GXLBNAME = Convert.ToString(sdr["GXLBNAME"]);
                        child.GXNAME = Convert.ToString(sdr["GXNAME"]);
                        child.GXDW = Convert.ToString(sdr["GXDW"]);
                        child.GXADDRESS = Convert.ToString(sdr["GXADDRESS"]);
                        child.GXPHONE = Convert.ToString(sdr["GXPHONE"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.CJR = Convert.ToInt32(sdr["CJR"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJTIME = Convert.ToString(sdr["CJTIME"]);
                        child.XGR = Convert.ToInt32(sdr["XGR"]);
                        child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                        child.XGTIME = Convert.ToString(sdr["XGTIME"]);
                        model_HR_RY_HOMEGX_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_HOMEGX_SELECT", "HR");
            }
            rst.HR_RY_HOMEGX_LIST = model_HR_RY_HOMEGX_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN HOMEGX_UPDATE(HR_RY_HOMEGX model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@JTGXID",model.JTGXID),
                                       new SqlParameter("@GXLB",model.GXLB),
                                       new SqlParameter("@GXNAME",model.GXNAME),
                                       new SqlParameter("@GXDW",model.GXDW),
                                       new SqlParameter("@GXADDRESS",model.GXADDRESS),
                                       new SqlParameter("@GXPHONE",model.GXPHONE),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@XGR",model.XGR)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_HOMEGX_UPDATE, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_HOMEGX_UPDATE", "HR");
            }
            return rst;
        }
        public MES_RETURN HOMEGX_DELETE(int JTGXID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@JTGXID", JTGXID),
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_HOMEGX_DELETE, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
                rst.TYPE = "S";
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_HOMEGX_DELETE", "HR");
            }
            return rst;
        }
        public MES_RETURN GSGL_INSERT(HR_RY_GSGL model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@JOBSNAME",model.JOBSNAME),
                                       new SqlParameter("@GSDATE",model.GSDATE),
                                       new SqlParameter("@GSLEVEL",model.GSLEVEL),
                                       new SqlParameter("@YLKSDATE",model.YLKSDATE),
                                       new SqlParameter("@YLJSDATE",model.YLJSDATE),
                                       new SqlParameter("@GSREMARK",model.GSREMARK),
                                       new SqlParameter("@CJR",model.CJR),
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_GSGL_INSERT, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_GSGL_INSERT", "HR");
            }
            return rst;
        }
        public HR_RY_GSGL_SELECT GSGL_SELECT(HR_RY_GSGL model)
        {
            HR_RY_GSGL_SELECT rst = new HR_RY_GSGL_SELECT();
            List<HR_RY_GSGL_LIST> model_HR_RY_GSGL_LIST = new List<HR_RY_GSGL_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID)
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_GSGL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        HR_RY_GSGL_LIST child = new HR_RY_GSGL_LIST();
                        child.RYID = Convert.ToInt32(sdr["RYID"]);
                        child.GSID = Convert.ToInt32(sdr["GSID"]);
                        child.JOBS = Convert.ToInt32(sdr["JOBS"]);
                        child.JOBSNAME = Convert.ToString(sdr["JOBSNAME"]);
                        child.GSDATE = Convert.ToString(sdr["GSDATE"]);
                        child.GSLEVEL = Convert.ToInt32(sdr["GSLEVEL"]);
                        child.GSLEVELNAME = Convert.ToString(sdr["GSLEVELNAME"]);
                        child.YLKSDATE = Convert.ToString(sdr["YLKSDATE"]);
                        child.YLJSDATE = Convert.ToString(sdr["YLJSDATE"]);
                        child.GSREMARK = Convert.ToString(sdr["GSREMARK"]);
                        child.CJR = Convert.ToInt32(sdr["CJR"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJTIME = Convert.ToString(sdr["CJTIME"]);
                        child.XGR = Convert.ToInt32(sdr["XGR"]);
                        child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                        child.XGRTIME = Convert.ToString(sdr["XGRTIME"]);
                        model_HR_RY_GSGL_LIST.Add(child);
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
            rst.HR_RY_GSGL_LIST = model_HR_RY_GSGL_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN GSGL_UPDATE(HR_RY_GSGL model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GSID",model.GSID),
                                       new SqlParameter("@JOBSNAME",model.JOBSNAME),
                                       new SqlParameter("@GSDATE",model.GSDATE),
                                       new SqlParameter("@GSLEVEL",model.GSLEVEL),
                                       new SqlParameter("@YLKSDATE",model.YLKSDATE),
                                       new SqlParameter("@YLJSDATE",model.YLJSDATE),
                                       new SqlParameter("@GSREMARK",model.GSREMARK),
                                       new SqlParameter("@XGR",model.XGR)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_GSGL_UPDATE, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_GSGL_UPDATE", "HR");
            }
            return rst;
        }
        public MES_RETURN GSGL_DELETE(int GSID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GSID", GSID),
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_GSGL_DELETE, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
                rst.TYPE = "S";
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_GSGL_DELETE", "HR");
            }
            return rst;
        }
        public MES_RETURN WJGL_INSERT(HR_RY_WJGL model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@FSDATE",model.FSDATE),
                                       new SqlParameter("@SM",model.SM),
                                       new SqlParameter("@CJR",model.CJR),
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_WJGL_INSERT, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_WJGL_INSERT", "HR");
            }
            return rst;
        }
        public HR_RY_WJGL_SELECT WJGL_SELECT(HR_RY_WJGL model)
        {
            HR_RY_WJGL_SELECT rst = new HR_RY_WJGL_SELECT();
            List<HR_RY_WJGL_LIST> model_HR_RY_WJGL_LIST = new List<HR_RY_WJGL_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID)
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_WJGL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        HR_RY_WJGL_LIST child = new HR_RY_WJGL_LIST();
                        child.RYID = Convert.ToInt32(sdr["RYID"]);
                        child.WJID = Convert.ToInt32(sdr["WJID"]);
                        child.FSDATE = Convert.ToString(sdr["FSDATE"]);
                        child.SM = Convert.ToString(sdr["SM"]);
                        child.CJR = Convert.ToInt32(sdr["CJR"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJTIME = Convert.ToString(sdr["CJTIME"]);
                        child.XGR = Convert.ToInt32(sdr["XGR"]);
                        child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                        child.XGRTIME = Convert.ToString(sdr["XGRTIME"]);
                        model_HR_RY_WJGL_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_WJGL_SELECT", "HR");
            }
            rst.HR_RY_WJGL_LIST = model_HR_RY_WJGL_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN WJGL_UPDATE(HR_RY_WJGL model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@WJID",model.WJID),
                                       new SqlParameter("@FSDATE",model.FSDATE),
                                       new SqlParameter("@SM",model.SM),
                                       new SqlParameter("@XGR",model.XGR)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_WJGL_UPDATE, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_WJGL_UPDATE", "HR");
            }
            return rst;
        }
        public MES_RETURN WJGL_DELETE(int WJID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@WJID", WJID),
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_WJGL_DELETE, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
                rst.TYPE = "S";
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_WJGL_DELETE", "HR");
            }
            return rst;
        }
        public MES_RETURN HT_INSERT(HR_RY_HT model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@HTZT",model.HTZT),
                                       new SqlParameter("@HTQXLB",model.HTQXLB),
                                       new SqlParameter("@HTQX",model.HTQX),
                                       new SqlParameter("@SYDATE",model.SYDATE),
                                       new SqlParameter("@QDRQ",model.QDRQ),
                                       new SqlParameter("@SXRQ",model.SXRQ),
                                       new SqlParameter("@DQR",model.DQR),
                                       new SqlParameter("@JCRQ",model.JCRQ),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@CJR",model.CJR),
                                       new SqlParameter("@HTQCS",model.HTQCS)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_HT_INSERT, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_HT_INSERT", "HR");
            }
            return rst;
        }
        public HR_RY_HT_SELECT HT_SELECT(HR_RY_HT model)
        {
            HR_RY_HT_SELECT rst = new HR_RY_HT_SELECT();
            List<HR_RY_HT_LIST> model_HR_RY_HT_LIST = new List<HR_RY_HT_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID)
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_HT_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        HR_RY_HT_LIST child = new HR_RY_HT_LIST();
                        child.RYID = Convert.ToInt32(sdr["RYID"]);
                        child.HTID = Convert.ToInt32(sdr["HTID"]);
                        child.GS = Convert.ToString(sdr["GS"]);
                        child.GSNAME = Convert.ToString(sdr["GSNAME"]);
                        child.HTZT = Convert.ToInt32(sdr["HTZT"]);
                        child.HTZTNAME = Convert.ToString(sdr["HTZTNAME"]);
                        child.HTQXLB = Convert.ToInt32(sdr["HTQXLB"]);
                        child.HTQXLBNAME = Convert.ToString(sdr["HTQXLBNAME"]);
                        child.HTQX = Convert.ToString(sdr["HTQX"]);
                        child.SYDATE = Convert.ToString(sdr["SYDATE"]);
                        child.QDRQ = Convert.ToString(sdr["QDRQ"]);
                        child.SXRQ = Convert.ToString(sdr["SXRQ"]);
                        child.DQR = Convert.ToString(sdr["DQR"]);
                        child.JCRQ = Convert.ToString(sdr["JCRQ"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.CJR = Convert.ToInt32(sdr["CJR"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJTIME = Convert.ToString(sdr["CJTIME"]);
                        child.XGR = Convert.ToInt32(sdr["XGR"]);
                        child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                        child.XGRTIME = Convert.ToString(sdr["XGRTIME"]);
                        model_HR_RY_HT_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_HT_SELECT", "HR");
            }
            rst.HR_RY_HT_LIST = model_HR_RY_HT_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN HT_UPDATE(HR_RY_HT model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@HTID",model.HTID),
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@HTZT",model.HTZT),
                                       new SqlParameter("@HTQXLB",model.HTQXLB),
                                       new SqlParameter("@HTQX",model.HTQX),
                                       new SqlParameter("@SYDATE",model.SYDATE),
                                       new SqlParameter("@QDRQ",model.QDRQ),
                                       new SqlParameter("@SXRQ",model.SXRQ),
                                       new SqlParameter("@DQR",model.DQR),
                                       new SqlParameter("@JCRQ",model.JCRQ),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@XGR",model.XGR),
                                       //new SqlParameter("@HTQCS",model.HTQCS)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_HT_UPDATE, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_HT_UPDATE", "HR");
            }
            return rst;
        }
        public MES_RETURN HT_UPDATE_HTQCS(HR_RY_HT model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID", model.RYID),
                                       new SqlParameter("@HTQCS", model.HTQCS),
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_HT_UPDATE_HTQCS, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
                rst.TYPE = "S";
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_HT_UPDATE_HTQCS", "HR");
            }
            return rst;
        }
        public MES_RETURN HT_DELETE(int HTID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@HTID", HTID),
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_HT_DELETE, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
                rst.TYPE = "S";
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_HT_DELETE", "HR");
            }
            return rst;
        }
        public MES_RETURN ZC_INSERT(HR_RY_ZC model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@ZCNAME",model.ZCNAME),
                                       new SqlParameter("@ZCLB",model.ZCLB),
                                       new SqlParameter("@ZCXL",model.ZCXL),
                                       new SqlParameter("@ZCLEVELNAME",model.ZCLEVELNAME),
                                       new SqlParameter("@ZCDATE",model.ZCDATE),
                                       new SqlParameter("@ZCJGBM",model.ZCJGBM),
                                       new SqlParameter("@ZCNO",model.ZCNO),
                                       new SqlParameter("@FSDATE",model.FSDATE),
                                       new SqlParameter("@ISPY",model.ISPY),
                                       new SqlParameter("@PYRQ",model.PYRQ),
                                       new SqlParameter("@PYXL",model.PYXL),
                                       new SqlParameter("@PYLEVEL",model.PYLEVEL),
                                       new SqlParameter("@ISBJSHOW",model.ISBJSHOW),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@CJR",model.CJR),
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ZC_INSERT, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_ZC_INSERT", "HR");
            }
            return rst;
        }
        public HR_RY_ZC_SELECT ZC_SELECT(HR_RY_ZC model)
        {
            HR_RY_ZC_SELECT rst = new HR_RY_ZC_SELECT();
            List<HR_RY_ZC_LIST> model_HR_RY_ZC_LIST = new List<HR_RY_ZC_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID)
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_ZC_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        HR_RY_ZC_LIST child = new HR_RY_ZC_LIST();
                        child.RYID = Convert.ToInt32(sdr["RYID"]);
                        child.ZCID = Convert.ToInt32(sdr["ZCID"]);
                        child.ZCNAME = Convert.ToString(sdr["ZCNAME"]);
                        child.ZCLB = Convert.ToInt32(sdr["ZCLB"]);
                        child.ZCLBNAME = Convert.ToString(sdr["ZCLBNAME"]);
                        child.ZCXL = Convert.ToInt32(sdr["ZCXL"]);
                        child.ZCXLNAME = Convert.ToString(sdr["ZCXLNAME"]);
                        child.ZCLEVEL = Convert.ToInt32(sdr["ZCLEVEL"]);
                        child.ZCLEVELNAME = Convert.ToString(sdr["ZCLEVELNAME"]);
                        child.ZCDATE = Convert.ToString(sdr["ZCDATE"]);
                        child.ZCJGBM = Convert.ToString(sdr["ZCJGBM"]);
                        child.ZCNO = Convert.ToString(sdr["ZCNO"]);
                        child.FSDATE = Convert.ToString(sdr["FSDATE"]);
                        child.ISPY = Convert.ToInt32(sdr["ISPY"]);
                        child.PYRQ = Convert.ToString(sdr["PYRQ"]);
                        child.PYXL = Convert.ToInt32(sdr["PYXL"]);
                        child.PYXLNAME = Convert.ToString(sdr["PYXLNAME"]);
                        child.PYLEVEL = Convert.ToInt32(sdr["PYLEVEL"]);
                        child.PYLEVELNAME = Convert.ToString(sdr["PYLEVELNAME"]);
                        child.ISBJSHOW = Convert.ToInt32(sdr["ISBJSHOW"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.CJR = Convert.ToInt32(sdr["CJR"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJTIME = Convert.ToString(sdr["CJTIME"]);
                        child.XGR = Convert.ToInt32(sdr["XGR"]);
                        child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                        child.XGTIME = Convert.ToString(sdr["XGTIME"]);
                        model_HR_RY_ZC_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_ZC_SELECT", "HR");
            }
            rst.HR_RY_ZC_LIST = model_HR_RY_ZC_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public HR_RY_ZC_SELECT RY_ZC_SELECT(HR_RY_ZC model)
        {
            HR_RY_ZC_SELECT rst = new HR_RY_ZC_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                           new SqlParameter("@ZCLB",model.ZCLB),
                                           new SqlParameter("@GH",model.GH),
                                           new SqlParameter("@ZCNAME",model.ZCNAME),
                                           new SqlParameter("@DATEKS",model.DATEKS),
                                           new SqlParameter("@DATEJS",model.DATEJS),
                                           new SqlParameter("@LB",model.LB)
                                   };
                rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_RY_ZC_SELECT, paras);
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_ZC_SELECT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN ZC_UPDATE(HR_RY_ZC model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ZCID",model.ZCID),
                                       new SqlParameter("@ZCNAME",model.ZCNAME),
                                       new SqlParameter("@ZCLB",model.ZCLB),
                                       new SqlParameter("@ZCXL",model.ZCXL),
                                       new SqlParameter("@ZCLEVELNAME",model.ZCLEVELNAME),
                                       new SqlParameter("@ZCDATE",model.ZCDATE),
                                       new SqlParameter("@ZCJGBM",model.ZCJGBM),
                                       new SqlParameter("@ZCNO",model.ZCNO),
                                       new SqlParameter("@FSDATE",model.FSDATE),
                                       new SqlParameter("@ISPY",model.ISPY),
                                       new SqlParameter("@PYRQ",model.PYRQ),
                                       new SqlParameter("@PYXL",model.PYXL),
                                       new SqlParameter("@PYLEVEL",model.PYLEVEL),
                                       new SqlParameter("@ISBJSHOW",model.ISBJSHOW),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@XGR",model.XGR),
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ZC_UPDATE, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_ZC_UPDATE", "HR");
            }
            return rst;
        }
        public MES_RETURN ZC_DELETE(int ZCID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ZCID", ZCID),
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_ZC_DELETE, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
                rst.TYPE = "S";
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_ZC_DELETE", "HR");
            }
            return rst;
        }
        public MES_RETURN WBZW_INSERT(HR_RY_WBZW model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@WBZWNAME",model.WBZWNAME),
                                       new SqlParameter("@WBZWDW",model.WBZWDW),
                                       new SqlParameter("@WBPYRQ",model.WBPYRQ),
                                       new SqlParameter("@WBJZRQ",model.WBJZRQ),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@CJR",model.CJR),
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_WBZW_INSERT, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_WBZW_INSERT", "HR");
            }
            return rst;
        }
        public HR_RY_WBZW_SELECT WBZW_SELECT(HR_RY_WBZW model)
        {
            HR_RY_WBZW_SELECT rst = new HR_RY_WBZW_SELECT();
            List<HR_RY_WBZW_LIST> model_HR_RY_WBZW_LIST = new List<HR_RY_WBZW_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID)
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_WBZW_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        HR_RY_WBZW_LIST child = new HR_RY_WBZW_LIST();
                        child.RYID = Convert.ToInt32(sdr["RYID"]);
                        child.WBZWID = Convert.ToInt32(sdr["WBZWID"]);
                        child.WBZWNAME = Convert.ToString(sdr["WBZWNAME"]);
                        child.WBZWDW = Convert.ToString(sdr["WBZWDW"]);
                        child.WBPYRQ = Convert.ToString(sdr["WBPYRQ"]);
                        child.WBJZRQ = Convert.ToString(sdr["WBJZRQ"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.CJR = Convert.ToInt32(sdr["CJR"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJTIME = Convert.ToString(sdr["CJTIME"]);
                        child.XGR = Convert.ToInt32(sdr["XGR"]);
                        child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                        child.XGRTIME = Convert.ToString(sdr["XGRTIME"]);
                        model_HR_RY_WBZW_LIST.Add(child);
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
            rst.HR_RY_WBZW_LIST = model_HR_RY_WBZW_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN WBZW_UPDATE(HR_RY_WBZW model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@WBZWID",model.WBZWID),
                                       new SqlParameter("@WBZWNAME",model.WBZWNAME),
                                       new SqlParameter("@WBZWDW",model.WBZWDW),
                                       new SqlParameter("@WBPYRQ",model.WBPYRQ),
                                       new SqlParameter("@WBJZRQ",model.WBJZRQ),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@XGR",model.XGR),
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_WBZW_UPDATE, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_WBZW_UPDATE", "HR");
            }
            return rst;
        }
        public MES_RETURN WBZW_DELETE(int WBZWID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@WBZWID", WBZWID),
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_WBZW_DELETE, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
                rst.TYPE = "S";
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_WBZW_DELETE", "HR");
            }
            return rst;
        }
    }
}

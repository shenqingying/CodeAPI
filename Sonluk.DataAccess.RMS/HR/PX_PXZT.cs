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
    public class PX_PXZT : IPX_PXZT
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_PXZT_INSERT = "HR_PX_PXZT_INSERT";
        const string SQL_PXZT_SELECT = "HR_PX_PXZT_SELECT";
        const string SQL_PXZT_UPDATE = "HR_PX_PXZT_UPDATE";
        const string SQL_PXZT_FJ_INSERT = "HR_PX_PXZT_FJ_INSERT";
        const string SQL_PXZT_FJ_SELECT = "SELECT * FROM HR_PX_PXZT_FJ WHERE PXZTID = @PXZTID";
        const string SQL_PXZTMX_INSERT = "HR_PX_PXZTMX_INSERT";
        const string SQL_PXZTMX_SELECT = "HR_PX_PXZTMX_SELECT";
        const string SQL_PXZT_DELETE = "HR_PX_PXZT_DELETE";
        const string SQL_PXZT_FJ_DELETE = "DELETE FROM HR_PX_PXZT_FJ WHERE FJID=@FJID";
        const string SQL_PXZTMX_DELETE = "DELETE FROM HR_PX_PXZTMX WHERE PXZTMXID=@PXZTMXID";
        const string SQL_PXZT_RY_SELECT = "HR_PX_PXZT_RY_SELECT";
        const string SQL_PXZT_BMRY_INSERT = "HR_PX_PXZT_BMRY_INSERT";
        const string SQL_PXZT_BMRY_UPDATE = "HR_PX_PXZT_BMRY_UPDATE";
        const string SQL_PXZT_BMRY_SELECT = "HR_PX_PXZT_BMRY_SELECT";

        public MES_RETURN INSERT_PXZT(HR_PX_PXZT model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@PXZTNAME",model.PXZTNAME),
                                       new SqlParameter("@PXKSRQ",model.PXKSRQ),
                                       new SqlParameter("@PXJSRQ",model.PXJSRQ),
                                       new SqlParameter("@PXTEACHER",model.PXTEACHER),
                                       new SqlParameter("@PXLEVELID",model.PXLEVELID),
                                       new SqlParameter("@PXJS",model.PXJS),
                                       new SqlParameter("@PXADDRESS",model.PXADDRESS),
                                       new SqlParameter("@PXRESULT",model.PXRESULT),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@CJR",model.CJR),
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@DEPTID",model.DEPTID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PXZT_INSERT, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                        rst.TID = Convert.ToInt32(sdr["MAXPXZTID"]);
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_PX_PXZT_INSERT", "HR");
            }
            return rst;
        }
        public HR_PX_PXZT_SELECT SELECT_PXZT(HR_PX_PXZT model)
        {
            HR_PX_PXZT_SELECT rst = new HR_PX_PXZT_SELECT();
            List<HR_PX_PXZT_LIST> model_HR_PX_PXZT_LIST = new List<HR_PX_PXZT_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@PXZTNAME",model.PXZTNAME),
                                       new SqlParameter("@PXKSRQ",model.PXKSRQ),
                                       new SqlParameter("@PXJSRQ",model.PXJSRQ),
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PXZT_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        HR_PX_PXZT_LIST child = new HR_PX_PXZT_LIST();
                        child.PXZTID = Convert.ToInt32(sdr["PXZTID"]);
                        child.PXZTNAME = Convert.ToString(sdr["PXZTNAME"]);
                        child.PXKSRQ = Convert.ToString(sdr["PXKSRQ"]);
                        child.PXJSRQ = Convert.ToString(sdr["PXJSRQ"]);
                        child.PXTEACHER = Convert.ToString(sdr["PXTEACHER"]);
                        child.PXLEVELID = Convert.ToInt32(sdr["PXLEVELID"]);
                        child.PXLEVELNAME = Convert.ToString(sdr["PXLEVELNAME"]);
                        child.PXJS = Convert.ToString(sdr["PXJS"]);
                        child.PXADDRESS = Convert.ToString(sdr["PXADDRESS"]);
                        child.PXRESULT = Convert.ToString(sdr["PXRESULT"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.CJR = Convert.ToInt32(sdr["CJR"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJTIME = Convert.ToString(sdr["CJTIME"]);
                        child.XGR = Convert.ToInt32(sdr["XGR"]);
                        child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                        child.XGRTIME = Convert.ToString(sdr["XGRTIME"]);
                        child.GS = Convert.ToString(sdr["GS"]);
                        child.GSNAME = Convert.ToString(sdr["GSNAME"]);
                        child.DEPTID = Convert.ToInt32(sdr["DEPTID"]);
                        child.DEPTNAME = Convert.ToString(sdr["DEPTNAME"]);
                        model_HR_PX_PXZT_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_PX_PXZT_SELECT", "HR");
            }
            rst.HR_PX_PXZT_LIST = model_HR_PX_PXZT_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN UPDATE_PXZT(HR_PX_PXZT model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@PXZTID",model.PXZTID),
                                       new SqlParameter("@PXZTNAME",model.PXZTNAME),
                                       new SqlParameter("@PXKSRQ",model.PXKSRQ),
                                       new SqlParameter("@PXJSRQ",model.PXJSRQ),
                                       new SqlParameter("@PXTEACHER",model.PXTEACHER),
                                       new SqlParameter("@PXLEVELID",model.PXLEVELID),
                                       new SqlParameter("@PXJS",model.PXJS),
                                       new SqlParameter("@PXADDRESS",model.PXADDRESS),
                                       new SqlParameter("@PXRESULT",model.PXRESULT),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@XGR",model.XGR),
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@DEPTID",model.DEPTID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PXZT_UPDATE, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_PX_PXZT_UPDATE", "HR");
            }
            return rst;
        }
        public MES_RETURN INSERT_PXZT_FJ(HR_PX_PXZT model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@PXZTID",model.PXZTID),
                                       new SqlParameter("@FJURL",model.FJURL),
                                       new SqlParameter("@FJREMARK",model.FJREMARK),
                                       new SqlParameter("@CJR",model.CJR),
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PXZT_FJ_INSERT, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_PX_PXZT_FJ_INSERT", "HR");
            }
            return rst;
        }
        public HR_PX_PXZT_SELECT SELECT_PXZT_FJ(int PXZTID)
        {
            HR_PX_PXZT_SELECT rst = new HR_PX_PXZT_SELECT();
            List<HR_PX_PXZT_LIST> model_HR_PX_PXZT_LIST = new List<HR_PX_PXZT_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@PXZTID",PXZTID),
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_PXZT_FJ_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        HR_PX_PXZT_LIST child = new HR_PX_PXZT_LIST();
                        child.FJID = Convert.ToInt32(sdr["FJID"]);
                        child.PXZTID = Convert.ToInt32(sdr["PXZTID"]);
                        child.FJURL = Convert.ToString(sdr["FJURL"]);
                        child.FJREMARK = Convert.ToString(sdr["REMARK"]);
                        child.CJR = Convert.ToInt32(sdr["CJR"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJTIME = Convert.ToString(sdr["CJTIME"]);
                        child.XGR = Convert.ToInt32(sdr["XGR"]);
                        child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                        child.XGRTIME = Convert.ToString(sdr["XGRTIME"]);
                        model_HR_PX_PXZT_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_PX_PXZT_FJ_SELECT", "HR");
            }
            rst.HR_PX_PXZT_LIST = model_HR_PX_PXZT_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN INSERT_PXZTMX(HR_PX_PXZT model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@PXZTID",model.PXZTID),
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@CJR",model.CJR),
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PXZTMX_INSERT, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_PX_PXZTMX_INSERT", "HR");
            }
            return rst;
        }
        public HR_PX_PXZT_SELECT SELECT_PXZTMX(HR_PX_PXZT model)
        {
            HR_PX_PXZT_SELECT rst = new HR_PX_PXZT_SELECT();
            List<HR_PX_PXZT_LIST> model_HR_PX_PXZT_LIST = new List<HR_PX_PXZT_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@PXZTID",model.PXZTID)
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PXZTMX_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        HR_PX_PXZT_LIST child = new HR_PX_PXZT_LIST();
                        child.PXZTMXID = Convert.ToInt32(sdr["PXZTMXID"]);
                        child.PXZTID = Convert.ToInt32(sdr["PXZTID"]);
                        child.RYID = Convert.ToInt32(sdr["RYID"]);
                        child.PXQDTIME = Convert.ToString(sdr["PXQDTIME"]);

                        child.GH = Convert.ToString(sdr["GH"]);
                        child.YGNAME = Convert.ToString(sdr["YGNAME"]);
                        child.GSNAME = Convert.ToString(sdr["GSNAME"]);
                        child.GSBM = Convert.ToString(sdr["GSBM"]);
                        child.GSBMNAME = Convert.ToString(sdr["GSBMNAME"]);
                        model_HR_PX_PXZT_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_PX_PXZTMX_SELECT", "HR");
            }
            rst.HR_PX_PXZT_LIST = model_HR_PX_PXZT_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN DELETE_PXZT(int PXZTID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@PXZTID",PXZTID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PXZT_DELETE, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_PX_PXZT_DELETE", "HR");
            }
            return rst;
        }
        public MES_RETURN DELETE_PXZT_FJ(int FJID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@FJID",FJID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_PXZT_FJ_DELETE, parms))
                {
                    rst.TYPE = "S";
                    rst.MESSAGE = "";
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_PX_PXZT_FJ_DELETE", "HR");
            }
            return rst;
        }
        public MES_RETURN DELETE_PXZTMX(int PXZTMXID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@PXZTMXID",PXZTMXID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_PXZTMX_DELETE, parms))
                {
                    rst.TYPE = "S";
                    rst.MESSAGE = "";
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_PX_PXZTMX_DELETE", "HR");
            }
            return rst;
        }
        public HR_PX_PXZT_SELECT SELECT_PXZT_RY(HR_PX_PXZT model)
        {
            HR_PX_PXZT_SELECT rst = new HR_PX_PXZT_SELECT();
            List<HR_PX_PXZT_LIST> model_HR_PX_PXZT_LIST = new List<HR_PX_PXZT_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ALLGS",model.ALLGS),
                                       new SqlParameter("@GSBM",model.GSBM),
                                       new SqlParameter("@GHSELECT",model.GHSELECT),
                                       new SqlParameter("@PXKSRQ",model.PXKSRQ),
                                       new SqlParameter("@PXJSRQ",model.PXJSRQ),
                                       new SqlParameter("@PXZTNAME",model.PXZTNAME)
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PXZT_RY_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        HR_PX_PXZT_LIST child = new HR_PX_PXZT_LIST();
                        child.GH = Convert.ToString(sdr["GH"]);
                        child.YGNAME = Convert.ToString(sdr["YGNAME"]);
                        child.GSNAME = Convert.ToString(sdr["GSNAME"]);
                        child.DEPTNAME = Convert.ToString(sdr["DEPTNAME"]);
                        child.GSBM = Convert.ToString(sdr["GSBM"]);
                        child.GSBMNAME = Convert.ToString(sdr["GSBMNAME"]);
                        child.PXZTID = Convert.ToInt32(sdr["PXZTID"]);
                        child.PXZTNAME = Convert.ToString(sdr["PXZTNAME"]);
                        child.PXKSRQ = Convert.ToString(sdr["PXKSRQ"]);
                        child.PXJSRQ = Convert.ToString(sdr["PXJSRQ"]);
                        child.PXTEACHER = Convert.ToString(sdr["PXTEACHER"]);
                        child.PXLEVELID = Convert.ToInt32(sdr["PXLEVELID"]);
                        child.PXLEVELNAME = Convert.ToString(sdr["PXLEVELNAME"]);
                        child.PXJS = Convert.ToString(sdr["PXJS"]);
                        child.PXADDRESS = Convert.ToString(sdr["PXADDRESS"]);
                        child.PXRESULT = Convert.ToString(sdr["PXRESULT"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        model_HR_PX_PXZT_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_PX_PXZT_RY_SELECT", "HR");
            }
            rst.HR_PX_PXZT_LIST = model_HR_PX_PXZT_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN PXZT_BMRY_INSERT(HR_PX_PXZT_BMRY model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@PXZTID",model.PXZTID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PXZT_BMRY_INSERT, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "SQL_PXZT_BMRY_INSERT", "HR");
            }
            return rst;
        }
        public MES_RETURN PXZT_BMRY_UPDATE(HR_PX_PXZT_BMRY model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@RYID",model.RYID),
                                           new SqlParameter("@PXZTID",model.PXZTID),
                                           new SqlParameter("@LB",model.LB)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PXZT_BMRY_UPDATE, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "SQL_PXZT_BMRY_UPDATE", "HR");
            }
            return rst;
        }
        public HR_PX_PXZT_BMRY_SELECT PXZT_BMRY_SELECT(HR_PX_PXZT_BMRY model)
        {
            HR_PX_PXZT_BMRY_SELECT rst = new HR_PX_PXZT_BMRY_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                           new SqlParameter("@LB",model.LB),
                                           new SqlParameter("@PXZTID",model.PXZTID)
                                   };
                rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_PXZT_BMRY_SELECT, paras);
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "SQL_PXZT_BMRY_SELECT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
    }
}

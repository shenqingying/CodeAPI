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
    public class SY_DEPT : ISY_DEPT
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "HR_SY_DEPT_INSERT";
        const string SQL_SELECT = "HR_SY_DEPT_SELECT";
        const string SQL_SELECT_LB = "HR_SY_DEPT_SELECT_LB";
        const string SQL_UPDATE = "HR_SY_DEPT_UPDATE";
        const string SQL_DELETE = "HR_SY_DEPT_DELETE";
        const string SQL_ReadByStaffidForFives = "FIVES_SY_DEPT_ReadByStaffidForFives";
        const string SQL_SELECT_BY_ROLE = "HR_SY_DEPT_SELECT_BY_ROLE";
        const string SQL_RYCOUNT = "HR_SY_DEPT_RYCOUNT";
        const string SQL_SELECT_BY_ROLE_LD = "HR_SY_DEPT_SELECT_BY_ROLE_LD";
        const string SQL_UPDATE_FID = "HR_SY_DEPT_UPDATE_FID";
        public MES_RETURN INSERT(HR_SY_DEPT model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@DEPTNO",model.DEPTNO),
                                       new SqlParameter("@DEPTNAME",model.DEPTNAME),
                                       new SqlParameter("@DEPTFZR",model.DEPTFZR),
                                       new SqlParameter("@FID",model.FID),
                                       new SqlParameter("@DEPTBZRS",model.DEPTBZRS),
                                       new SqlParameter("@DEPTBMLB",model.DEPTBMLB),
                                       new SqlParameter("@DEPTCBZX",model.DEPTCBZX),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@DEPTPX",model.DEPTPX),
                                       new SqlParameter("@CJR",model.CJR),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@PBFZ",model.PBFZ),
                                       new SqlParameter("@XZDEPTPX",model.XZDEPTPX)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "SY_GS_INSERT", "HR");
            }
            return rst;
        }
        public MES_RETURN DELETE(HR_SY_DEPT model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@DEPTID",model.DEPTID)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_SY_DEPT_DELETE", "HR");
            }
            return rst;
        }
        public MES_RETURN UPDATE(HR_SY_DEPT model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@DEPTID",model.DEPTID),
                                       new SqlParameter("@DEPTNO",model.DEPTNO),
                                       new SqlParameter("@DEPTNAME",model.DEPTNAME),
                                       new SqlParameter("@DEPTFZR",model.DEPTFZR),
                                       new SqlParameter("@DEPTBZRS",model.DEPTBZRS),
                                       new SqlParameter("@DEPTBMLB",model.DEPTBMLB),
                                       new SqlParameter("@DEPTCBZX",model.DEPTCBZX),
                                       new SqlParameter("@DEPTPX",model.DEPTPX),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@XGR",model.XGR),
                                       new SqlParameter("@PBFZ",model.PBFZ),
                                       new SqlParameter("@XZDEPTPX",model.XZDEPTPX)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_SY_DEPT_UPDATE", "HR");
            }
            return rst;
        }
        public HR_SY_DEPT_SELECT SELECT(HR_SY_DEPT model)
        {
            HR_SY_DEPT_SELECT rst = new HR_SY_DEPT_SELECT();
            List<HR_SY_DEPT_LIST> child_HR_SY_DEPT_LIST = new List<HR_SY_DEPT_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@DEPTID",model.DEPTID),
                                           new SqlParameter("@GS",model.GS)
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        HR_SY_DEPT_LIST child = new HR_SY_DEPT_LIST();
                        child.DEPTID = Convert.ToInt32(sdr["DEPTID"]);
                        child.GS = Convert.ToString(sdr["GS"]);
                        child.DEPTNO = Convert.ToString(sdr["DEPTNO"]);
                        child.DEPTNAME = Convert.ToString(sdr["DEPTNAME"]);
                        child.DEPTFZR = Convert.ToInt32(sdr["DEPTFZR"]);
                        child.DEPTFZRNAME = Convert.ToString(sdr["DEPTFZRNAME"]);
                        child.FID = Convert.ToInt32(sdr["FID"]);
                        child.DEPTBZRS = Convert.ToInt32(sdr["DEPTBZRS"]);
                        child.DEPTBMLB = Convert.ToInt32(sdr["DEPTBMLB"]);
                        child.DEPTBMLBNAME = Convert.ToString(sdr["DEPTBMLBNAME"]);
                        child.DEPTCBZX = Convert.ToString(sdr["DEPTCBZX"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.CJR = Convert.ToInt32(sdr["CJR"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJTIME = Convert.ToDateTime(sdr["CJTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.XGR = Convert.ToInt32(sdr["XGR"]);
                        child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                        child.XGTIME = Convert.ToDateTime(sdr["XGTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.ISDELETE = Convert.ToInt32(sdr["ISDELETE"]);
                        child.DEPTPX = Convert.ToInt32(sdr["DEPTPX"]);
                        child.ZZRS = Convert.ToInt32(sdr["ZZRS"]);
                        child.FDEPTNAME = Convert.ToString(sdr["FDEPTNAME"]);
                        child.GSNAME = Convert.ToString(sdr["GSNAME"]);
                        child.PBFZ = Convert.ToInt32(sdr["PBFZ"]);
                        child.PBFZNAME = Convert.ToString(sdr["PBFZNAME"]);
                        child.XZDEPTPX = Convert.ToInt32(sdr["XZDEPTPX"]);
                        child_HR_SY_DEPT_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_SY_DEPT_SELECT", "HR");
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            rst.HR_SY_DEPT_LIST = child_HR_SY_DEPT_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }

        public HR_SY_DEPT_SELECT SELECT_LB(HR_SY_DEPT model, int LB)
        {
            HR_SY_DEPT_SELECT rst = new HR_SY_DEPT_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                           new SqlParameter("@LB",LB),
                                           new SqlParameter("@GS",model.GS),
                                           new SqlParameter("@DEPTID",model.DEPTIDLIST),
                                           new SqlParameter("@STAFFID",model.STAFFID)
                                   };
                rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_SELECT_LB, paras);
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_SY_DEPT_SELECT_LB", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }

        public HR_SY_DEPT_SELECT ReadByStaffidForFives(int staffid)
        {
            HR_SY_DEPT_SELECT rst = new HR_SY_DEPT_SELECT();
            List<HR_SY_DEPT_LIST> child_HR_SY_DEPT_LIST = new List<HR_SY_DEPT_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@STAFFID",staffid)
                                           
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByStaffidForFives, parms))
                {
                    while (sdr.Read())
                    {
                        HR_SY_DEPT_LIST child = new HR_SY_DEPT_LIST();
                        child.DEPTID = Convert.ToInt32(sdr["DEPTID"]);
                        child.GS = Convert.ToString(sdr["GS"]);
                        child.DEPTNO = Convert.ToString(sdr["DEPTNO"]);
                        child.DEPTNAME = Convert.ToString(sdr["DEPTNAME"]);
                        child.DEPTFZR = Convert.ToInt32(sdr["DEPTFZR"]);
                        child.DEPTFZRNAME = Convert.ToString(sdr["DEPTFZRNAME"]);
                        child.FID = Convert.ToInt32(sdr["FID"]);
                        child.DEPTBZRS = Convert.ToInt32(sdr["DEPTBZRS"]);
                        child.DEPTBMLB = Convert.ToInt32(sdr["DEPTBMLB"]);
                        child.DEPTBMLBNAME = Convert.ToString(sdr["DEPTBMLBNAME"]);
                        child.DEPTCBZX = Convert.ToString(sdr["DEPTCBZX"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.CJR = Convert.ToInt32(sdr["CJR"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJTIME = Convert.ToDateTime(sdr["CJTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.XGR = Convert.ToInt32(sdr["XGR"]);
                        child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                        child.XGTIME = Convert.ToDateTime(sdr["XGTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.ISDELETE = Convert.ToInt32(sdr["ISDELETE"]);
                        child.DEPTPX = Convert.ToInt32(sdr["DEPTPX"]);
                        child_HR_SY_DEPT_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "SQL_ReadByStaffidForFives", "HR");
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            rst.HR_SY_DEPT_LIST = child_HR_SY_DEPT_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public HR_SY_DEPT_SELECT SELECT_BY_ROLE(HR_SY_DEPT model, int LB)
        {
            HR_SY_DEPT_SELECT rst = new HR_SY_DEPT_SELECT();
            List<HR_SY_DEPT_LIST> child_HR_SY_DEPT_LIST = new List<HR_SY_DEPT_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@DEPTID",model.DEPTID),
                                           new SqlParameter("@GS",model.GS),
                                           new SqlParameter("@STAFFID",model.STAFFID),
                                           new SqlParameter("@LB",LB)
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_BY_ROLE, parms))
                {
                    while (sdr.Read())
                    {
                        HR_SY_DEPT_LIST child = new HR_SY_DEPT_LIST();
                        child.DEPTID = Convert.ToInt32(sdr["DEPTID"]);
                        child.GS = Convert.ToString(sdr["GS"]);
                        child.DEPTNO = Convert.ToString(sdr["DEPTNO"]);
                        child.DEPTNAME = Convert.ToString(sdr["DEPTNAME"]);
                        child.DEPTFZR = Convert.ToInt32(sdr["DEPTFZR"]);
                        child.DEPTFZRNAME = Convert.ToString(sdr["DEPTFZRNAME"]);
                        child.FID = Convert.ToInt32(sdr["FID"]);
                        child.DEPTBZRS = Convert.ToInt32(sdr["DEPTBZRS"]);
                        child.DEPTBMLB = Convert.ToInt32(sdr["DEPTBMLB"]);
                        child.DEPTBMLBNAME = Convert.ToString(sdr["DEPTBMLBNAME"]);
                        child.DEPTCBZX = Convert.ToString(sdr["DEPTCBZX"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.CJR = Convert.ToInt32(sdr["CJR"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJTIME = Convert.ToDateTime(sdr["CJTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.XGR = Convert.ToInt32(sdr["XGR"]);
                        child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                        child.XGTIME = Convert.ToDateTime(sdr["XGTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.ISDELETE = Convert.ToInt32(sdr["ISDELETE"]);
                        child.DEPTPX = Convert.ToInt32(sdr["DEPTPX"]);
                        child.PBFZ = Convert.ToInt32(sdr["PBFZ"]);
                        child.PBFZNAME = Convert.ToString(sdr["PBFZNAME"]);
                        child.XZDEPTPX = Convert.ToInt32(sdr["XZDEPTPX"]);
                        child_HR_SY_DEPT_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_SY_DEPT_SELECT", "HR");
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            rst.HR_SY_DEPT_LIST = child_HR_SY_DEPT_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public HR_SY_DEPT_SELECT SELECT_RYCOUNT(int DEPTID)
        {
            HR_SY_DEPT_SELECT rst = new HR_SY_DEPT_SELECT();
            List<HR_SY_DEPT_LIST> child_HR_SY_DEPT_LIST = new List<HR_SY_DEPT_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@DEPTID",DEPTID)
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_RYCOUNT, parms))
                {
                    while (sdr.Read())
                    {
                        HR_SY_DEPT_LIST child = new HR_SY_DEPT_LIST();
                        child.DEPTID = Convert.ToInt32(sdr["DEPTID"]);
                        child.DEPTBZRS = Convert.ToInt32(sdr["DEPTBZRS"]);
                        child.ZZRS = Convert.ToInt32(sdr["ZZRS"]);
                        child_HR_SY_DEPT_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_SY_DEPT_RYCOUNT", "HR");
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            rst.HR_SY_DEPT_LIST = child_HR_SY_DEPT_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public HR_SY_DEPT_SELECT SELECT_BY_ROLE_LD(HR_SY_DEPT model)
        {
            HR_SY_DEPT_SELECT rst = new HR_SY_DEPT_SELECT();
            List<HR_SY_DEPT_LIST> child_HR_SY_DEPT_LIST = new List<HR_SY_DEPT_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@DEPTID",model.DEPTID),
                                           new SqlParameter("@GS",model.GS),
                                           new SqlParameter("@STAFFID",model.STAFFID),
                                           new SqlParameter("@CXLB",model.CXLB)
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_BY_ROLE_LD, parms))
                {
                    while (sdr.Read())
                    {
                        HR_SY_DEPT_LIST child = new HR_SY_DEPT_LIST();
                        child.DEPTID = Convert.ToInt32(sdr["DEPTID"]);
                        child.GS = Convert.ToString(sdr["GS"]);
                        child.DEPTNO = Convert.ToString(sdr["DEPTNO"]);
                        child.DEPTNAME = Convert.ToString(sdr["DEPTNAME"]);
                        child.DEPTFZR = Convert.ToInt32(sdr["DEPTFZR"]);
                        child.DEPTFZRNAME = Convert.ToString(sdr["DEPTFZRNAME"]);
                        child.FID = Convert.ToInt32(sdr["FID"]);
                        child.FDEPTNAME = Convert.ToString(sdr["FDEPTNAME"]);
                        child.DEPTBZRS = Convert.ToInt32(sdr["DEPTBZRS"]);
                        child.DEPTBMLB = Convert.ToInt32(sdr["DEPTBMLB"]);
                        child.DEPTBMLBNAME = Convert.ToString(sdr["DEPTBMLBNAME"]);
                        child.DEPTCBZX = Convert.ToString(sdr["DEPTCBZX"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.CJR = Convert.ToInt32(sdr["CJR"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJTIME = Convert.ToDateTime(sdr["CJTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.XGR = Convert.ToInt32(sdr["XGR"]);
                        child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                        child.XGTIME = Convert.ToDateTime(sdr["XGTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.ISDELETE = Convert.ToInt32(sdr["ISDELETE"]);
                        child.DEPTPX = Convert.ToInt32(sdr["DEPTPX"]);
                        child.PBFZ = Convert.ToInt32(sdr["PBFZ"]);
                        child.PBFZNAME = Convert.ToString(sdr["PBFZNAME"]);
                        child.XZDEPTPX = Convert.ToInt32(sdr["XZDEPTPX"]);
                        if (model.CXLB == 1)
                        {
                            child.ZZRS = Convert.ToInt32(sdr["ZZRS"]);
                        }
                        child_HR_SY_DEPT_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_SY_DEPT_SELECT_BY_ROLE_LD", "HR");
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            rst.HR_SY_DEPT_LIST = child_HR_SY_DEPT_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN UPDATE_FID(int DEPTID, int FID, int STAFFID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@DEPTID",DEPTID),
                                       new SqlParameter("@FID",FID),
                                       new SqlParameter("@XGR",STAFFID)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE_FID, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_SY_DEPT_UPDATE_FID", "HR");
            }
            return rst;
        }
    }
}

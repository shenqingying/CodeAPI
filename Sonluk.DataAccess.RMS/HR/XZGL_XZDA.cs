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
    public class XZGL_XZDA : IXZGL_XZDA
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "HR_XZGL_XZDA_INSERT";
        const string SQL_SELECT = "HR_XZGL_XZDA_SELECT";
        const string SQL_UPDATE = "HR_XZGL_XZDA_UPDATE";
        const string SQL_SELECTALL = "HR_XZGL_XZDA_SELECTALL";
        const string SQL_AUTO_ADD_TO_FFJLMX = "HR_XZGL_XZDA_AUTO_ADD_TO_FFJLMX";
        public MES_RETURN INSERT(HR_XZGL_XZDA model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@GZLBID",model.GZLBID),
                                       new SqlParameter("@TZQ",model.TZQ),
                                       new SqlParameter("@TZH",model.TZH),
                                       new SqlParameter("@TZYY",model.TZYY),
                                       new SqlParameter("@SXDATE",model.SXDATE),
                                       new SqlParameter("@CJR",model.CJR),
                                       new SqlParameter("@MYPW",model.MYPW)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_XZDA_GZLB_INSERT", "HR");
            }
            return rst;
        }
        public MES_RETURN UPDATE(HR_XZGL_XZDA model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@XZDAID",model.XZDAID),
                                       new SqlParameter("@XGR",model.XGR),
                                       new SqlParameter("@LB",LB),
                                       new SqlParameter("@NSRSF",model.NSRSF),
                                       new SqlParameter("@NSRSBH",model.NSRSBH),
                                       new SqlParameter("@RYID",model.RYID)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_XZDA_UPDATE", "HR");
            }
            return rst;
        }
        public HR_XZGL_XZDA_SELECT SELECT(HR_XZGL_XZDA model)
        {
            HR_XZGL_XZDA_SELECT rst = new HR_XZGL_XZDA_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                       new SqlParameter("@DEPT",model.DEPT),
                                       new SqlParameter("@ZZZT",model.ZZZT),
                                       new SqlParameter("@GH",model.GH),
                                       new SqlParameter("@MYPW",model.MYPW),
                                       new SqlParameter("@SXDATE",model.SXDATE),
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@YGTYPE",model.YGTYPE)
                                   };
                rst.DataTable = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_SELECT, paras);
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_XZDA_SELECT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public HR_XZGL_XZDA_SELECT SELECT_ALL(HR_XZGL_XZDA model, int LB)
        {
            HR_XZGL_XZDA_SELECT rst = new HR_XZGL_XZDA_SELECT();
            List<HR_XZGL_XZDA_LIST> child_HR_XZGL_XZDA_LIST = new List<HR_XZGL_XZDA_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                       new SqlParameter("@XZDAID",model.XZDAID),
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@MYPW",model.MYPW),
                                       new SqlParameter("@LB",LB),
                                       new SqlParameter("@SXDATE",model.SXDATE),
                                       new SqlParameter("@GH",model.GH),
                                       new SqlParameter("@DEPT",model.DEPT),
                                       new SqlParameter("@ZZZT",model.ZZZT),
                                       new SqlParameter("@ZHLB",model.ZHLB),
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@YGTYPE",model.YGTYPE)
                                   };
                if (LB == 3 || LB == 4 || LB == 5 || LB == 6)
                {
                    rst.DataTable = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_SELECTALL, paras);
                }
                else
                {
                    using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECTALL, paras))
                    {
                        while (sdr.Read())
                        {
                            HR_XZGL_XZDA_LIST child = new HR_XZGL_XZDA_LIST();
                            child.XZDAID = Convert.ToInt32(sdr["XZDAID"]);
                            child.RYID = Convert.ToInt32(sdr["RYID"]);
                            child.GZLBID = Convert.ToInt32(sdr["GZLBID"]);
                            child.GZLBNAME = Convert.ToString(sdr["GZLBNAME"]);
                            child.TZQ = Convert.ToDecimal(sdr["TZQ"]);
                            child.TZH = Convert.ToDecimal(sdr["TZH"]);
                            child.TZYY = Convert.ToInt32(sdr["TZYY"]);
                            child.TZYYNAME = Convert.ToString(sdr["TZYYNAME"]);
                            child.SXDATE = Convert.ToString(sdr["SXDATE"]);
                            child.CJR = Convert.ToInt32(sdr["CJR"]);
                            child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                            child.CJTIME = Convert.ToDateTime(sdr["CJTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                            child.XGR = Convert.ToInt32(sdr["XGR"]);
                            child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                            child.XGTIME = Convert.ToDateTime(sdr["XGTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                            child_HR_XZGL_XZDA_LIST.Add(child);
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_XZDA_SELECTALL", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.HR_XZGL_XZDA_LIST = child_HR_XZGL_XZDA_LIST;
            return rst;
        }
        public MES_RETURN AUTO_ADD_TO_FFJLMX(HR_XZGL_XZDA model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@FFJLID",model.FFJLID),
                                       new SqlParameter("@GZLBID",model.GZLBID),
                                       new SqlParameter("@SXDATE",model.SXDATE),
                                       new SqlParameter("@MYPW",model.MYPW)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_AUTO_ADD_TO_FFJLMX, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_XZDA_AUTO_ADD_TO_FFJLMX", "HR");
            }
            return rst;
        }
    }
}

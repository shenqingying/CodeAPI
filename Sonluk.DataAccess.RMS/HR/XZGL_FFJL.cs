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
    public class XZGL_FFJL : IXZGL_FFJL
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "HR_XZGL_FFJL_INSERT";
        const string SQL_SELECT = "HR_XZGL_FFJL_SELECT";
        const string SQL_UPDATE = "HR_XZGL_FFJL_UPDATE";
        const string SQL_SELECT_ISFFNOWCOUNT = "SELECT COUNT(*) AS THEISFFNOWCOUNT FROM HR_XZGL_FFJL WHERE ISDELETE=0 AND ISFFNOW>0";
        const string SQL_ZQMONTH_UPDATE = "HR_XZGL_ZQMONTH_UPDATE";
        const string SQL_ZQMONTH_SELECT = "HR_XZGL_ZQMONTH_SELECT";
        const string SQL_ZQMONTH_SELECT_LB = "HR_XZGL_ZQMONTH_SELECT_LB";
        public MES_RETURN INSERT(HR_XZGL_FFJL model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@FFLB",model.FFLB),
                                       new SqlParameter("@FFDATE",model.FFDATE),
                                       new SqlParameter("@FFSM",model.FFSM),
                                       new SqlParameter("@FFYEAR",model.FFYEAR),
                                       new SqlParameter("@FFMOUTH",model.FFMOUTH),
                                       new SqlParameter("@GSLB",model.GSLB),
                                       new SqlParameter("@JSFS",model.JSFS),
                                       new SqlParameter("@CJR",model.CJR),
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@KHZQKS",model.KHZQKS),
                                       new SqlParameter("@KHZQJS",model.KHZQJS),
                                       new SqlParameter("@FFLY",model.FFLY)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                        rst.TID = Convert.ToInt32(sdr["FFJLID"]);
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FFJL_INSERT", "HR");
            }
            return rst;
        }
        public HR_XZGL_FFJL_SELECT SELECT(HR_XZGL_FFJL model, int LB)
        {
            HR_XZGL_FFJL_SELECT rst = new HR_XZGL_FFJL_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                           new SqlParameter("@FFJLID",model.FFJLID),
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@FFLB",model.FFLB),
                                       new SqlParameter("@FFYEARKS",model.FFYEARKS),
                                       new SqlParameter("@FFYEARJS",model.FFYEARJS),
                                       new SqlParameter("@LB",LB),
                                       new SqlParameter("@MYPW",model.MYPW),
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@FFLY",model.FFLY),
                                       new SqlParameter("@ISFF",model.ISFF)
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
        public MES_RETURN UPDATE(HR_XZGL_FFJL model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@FFJLID",model.FFJLID),
                                       new SqlParameter("@LB",LB),
                                       new SqlParameter("@MYPW",model.MYPW),
                                       new SqlParameter("@STAFFID",model.STAFFID)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FFJL_UPDATE", "HR");
            }
            return rst;
        }
        public HR_XZGL_FFJL_SELECT SELECT_ISFFNOWCOUNT()
        {
            HR_XZGL_FFJL_SELECT rst = new HR_XZGL_FFJL_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                   };
                rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.Text, SQL_SELECT_ISFFNOWCOUNT, paras);
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "SELECT_ISFFNOWCOUNT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN ZQMONTH_UPDATE(HR_XZGL_FFJL model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@XGR",model.XGR)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ZQMONTH_UPDATE, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_ZQMONTH_UPDATE", "HR");
            }
            return rst;
        }

        public HR_XZGL_FFJL_SELECT ZQMONTH_SELECT(HR_XZGL_FFJL model)
        {
            HR_XZGL_FFJL_SELECT rst = new HR_XZGL_FFJL_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };
                rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_ZQMONTH_SELECT, paras);
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_ZQMONTH_SELECT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public HR_XZGL_FFJL_SELECT ZQMONTH_SELECT_LB(HR_XZGL_FFJL model)
        {
            DataSet ds = new DataSet();
            HR_XZGL_FFJL_SELECT rst = new HR_XZGL_FFJL_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@LB",model.LB)
                                   };
                ds = SQLServerHelper.GetDataSet_dataset(CommandType.StoredProcedure, SQL_ZQMONTH_SELECT_LB, paras);
                rst.DATALIST = ds.Tables[0];
                child_MES_RETURN.TYPE = ds.Tables[1].Rows[0][0].ToString();
                child_MES_RETURN.MESSAGE = ds.Tables[1].Rows[0][1].ToString();
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_ZQMONTH_SELECT_LB", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
    }
}

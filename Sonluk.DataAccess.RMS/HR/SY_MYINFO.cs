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
    public class SY_MYINFO : ISY_MYINFO
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_JM_ISTRUE = "HR_SY_MYINFO_SELECT_JM_ISTRUE";
        const string SQL_INSERT = "HR_SY_MYINFO_INSERT";
        const string SQL_SELECT_REPORT = "HR_SY_MYINFO_SELECT_REPORT";
        const string SQL_UPDATE = "HR_SY_MYINFO_UPDATE";
        const string SQL_SELECT = "HR_SY_MYINFO_SELECT";
        public MES_RETURN JM_ISTRUE(string MYPW, int STAFFID, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@MYPW",MYPW),
                                       new SqlParameter("@STAFFID",STAFFID),
                                       new SqlParameter("@LB",LB)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_JM_ISTRUE, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_SY_MYINFO_SELECT_JM_ISTRUE", "HR");
            }
            return rst;
        }
        public MES_RETURN INSERT(HR_SY_MYINFO model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@MYNAME",model.MYNAME),
                                       new SqlParameter("@MYLB",model.MYLB),
                                       new SqlParameter("@MYMM",model.MYMM),
                                       new SqlParameter("@MYMMP",model.MYMMP),
                                       new SqlParameter("@STAFFID",model.STAFFID)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_SY_MYINFO_INSERT", "HR");
            }
            return rst;
        }
        public HR_SY_MYINFO_SELECT SELECT_REPORT(HR_SY_MYINFO model)
        {
            HR_SY_MYINFO_SELECT rst = new HR_SY_MYINFO_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                           new SqlParameter("@STAFFID",model.STAFFID),
                                           new SqlParameter("@STAFFUSER",model.STAFFUSER)
                                   };
                rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_SELECT_REPORT, paras);
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_SY_MYINFO_SELECT_REPORT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN UPDATE(HR_SY_MYINFO model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@MYID",model.MYID),
                                       new SqlParameter("@LB",LB),
                                       new SqlParameter("@MYPWOLD",model.MYPWOLD),
                                       new SqlParameter("@MYPWNEW",model.MYPWNEW),
                                       new SqlParameter("@SYPW",model.SYPW),
                                       new SqlParameter("@GYPW",model.GYPW)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_SY_MYINFO_UPDATE", "HR");
            }
            return rst;
        }
        public HR_SY_MYINFO_SELECT SELECT(HR_SY_MYINFO model, int LB)
        {
            HR_SY_MYINFO_SELECT rst = new HR_SY_MYINFO_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                           new SqlParameter("@MYLB",model.MYLB),
                                           new SqlParameter("@STAFFID",model.STAFFID),
                                           new SqlParameter("@MYID",model.MYID),
                                           new SqlParameter("@MYPW",model.MYPW),
                                           new SqlParameter("@LB",LB)
                                   };
                rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_SELECT, paras);
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_SY_MYINFO_SELECT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
    }
}

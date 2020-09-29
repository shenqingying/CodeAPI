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
    public class SY_DUTY : ISY_DUTY
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "HR_SY_DUTY_INSERT";
        const string SQL_SELECT = "HR_SY_DUTY_SELECT";
        const string SQL_UPDATE = "HR_SY_DUTY_UPDATE";
        const string SQL_DELETE = "HR_SY_DUTY_DELETE";
        public MES_RETURN INSERT(HR_SY_DUTY model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ZWMS",model.ZWMS),
                                       new SqlParameter("@ZWFL",model.ZWFL),
                                       new SqlParameter("@DUTYLEVEL",model.DUTYLEVEL),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@CJR",model.CJR),
                                       new SqlParameter("@DUTYPX",model.DUTYPX),
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_SY_DUTY_INSERT", "HR");
            }
            return rst;
        }
        public MES_RETURN UPDATE(HR_SY_DUTY model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ZWMS",model.ZWMS),
                                       new SqlParameter("@ZWFL",model.ZWFL),
                                       new SqlParameter("@DUTYLEVEL",model.DUTYLEVEL),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@XGR",model.XGR),
                                       new SqlParameter("@DUTYPX",model.DUTYPX),
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_SY_DUTY_UPDATE", "HR");
            }
            return rst;
        }
        public MES_RETURN DELETE(HR_SY_DUTY model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@DUTYID",model.DUTYID)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_SY_DUTY_DELETE", "HR");
            }
            return rst;
        }
        public HR_SY_DUTY_SELECT SELECT(HR_SY_DUTY model)
        {
            HR_SY_DUTY_SELECT rst = new HR_SY_DUTY_SELECT();
            List<HR_SY_DUTY_LIST> child_HR_SY_DUTY_LIST = new List<HR_SY_DUTY_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@DUTYID",model.DUTYID),
                                           new SqlParameter("@ZWMS",model.ZWMS)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        HR_SY_DUTY_LIST child = new HR_SY_DUTY_LIST();
                        child.DUTYID = Convert.ToInt32(sdr["DUTYID"]);
                        child.ZWMS = Convert.ToString(sdr["ZWMS"]);
                        child.ZWFL = Convert.ToInt32(sdr["ZWFL"]);
                        child.ZWFLNAME = Convert.ToString(sdr["ZWFLNAME"]);
                        child.DUTYLEVEL = Convert.ToInt32(sdr["DUTYLEVEL"]);
                        child.DUTYLEVELNAME = Convert.ToString(sdr["DUTYLEVELNAME"]);
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.CJR = Convert.ToInt32(sdr["CJR"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJTIME = Convert.ToString(sdr["CJTIME"]);
                        child.XGR = Convert.ToInt32(sdr["XGR"]);
                        child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                        child.XGRTIME = Convert.ToString(sdr["XGRTIME"]);
                        child.DUTYPX = Convert.ToInt32(sdr["DUTYPX"]);
                        child_HR_SY_DUTY_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_SY_DUTY_SELECT", "HR");
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            rst.HR_SY_DUTY_LIST = child_HR_SY_DUTY_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
    }
}

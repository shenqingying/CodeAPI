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
    public class GS_GSSL : IGS_GSSL
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "HR_GS_GSSL_INSERT";
        const string SQL_SELECT = "HR_GS_GSSL_SELECT";
        const string SQL_UPDATE = "HR_GS_GSSL_UPDATE";
        public MES_RETURN INSERT(HR_GS_GSSL model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYLB",model.RYLB),
                                       new SqlParameter("@GSLB",model.GSLB),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@CJR",model.CJR),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@TAXQZD",model.TAXQZD),
                                       new SqlParameter("@JSGS",model.JSGS),
                                       new SqlParameter("@ISGLZXFJ",model.ISGLZXFJ)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                        rst.TID = Convert.ToInt32(sdr["SWLBID"]);
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_SY_GS_INSERT", "HR");
            }
            return rst;
        }
        public MES_RETURN UPDATE(HR_GS_GSSL model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@SWLBID",model.SWLBID),
                                       new SqlParameter("@RYLB",model.RYLB),
                                       new SqlParameter("@GSLB",model.GSLB),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@LB",LB),
                                       new SqlParameter("@XGR",model.XGR),
                                       new SqlParameter("@TAXQZD",model.TAXQZD),
                                       new SqlParameter("@JSGS",model.JSGS),
                                       new SqlParameter("@ISGLZXFJ",model.ISGLZXFJ)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_GS_GSSL_UPDATE", "HR");
            }
            return rst;
        }
        public HR_GS_GSSL_SELECT SELECT(HR_GS_GSSL model)
        {
            HR_GS_GSSL_SELECT rst = new HR_GS_GSSL_SELECT();
            List<HR_GS_GSSL> child_HR_GS_GSSL = new List<HR_GS_GSSL>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        HR_GS_GSSL child = new HR_GS_GSSL();
                        child.SWLBID = Convert.ToInt32(sdr["SWLBID"]);
                        child.RYLB = Convert.ToInt32(sdr["RYLB"]);
                        child.RYLBNAME = Convert.ToString(sdr["RYLBNAME"]);
                        child.GSLB = Convert.ToInt32(sdr["GSLB"]);
                        child.GSLBNAME = Convert.ToString(sdr["GSLBNAME"]);
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.ISDELETE = Convert.ToInt32(sdr["ISDELETE"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.CJR = Convert.ToInt32(sdr["CJR"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJTIME = Convert.ToDateTime(sdr["CJTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.XGR = Convert.ToInt32(sdr["XGR"]);
                        child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                        child.XGTIME = Convert.ToDateTime(sdr["XGTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.ISDELETE = Convert.ToInt32(sdr["ISDELETE"]);
                        child.TAXQZD = Convert.ToInt32(sdr["TAXQZD"]);
                        child.JSGS = Convert.ToString(sdr["JSGS"]);
                        child.ISGLZXFJ = Convert.ToInt32(sdr["ISGLZXFJ"]);
                        child_HR_GS_GSSL.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_GS_GSSL_SELECT", "HR");
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            rst.HR_GS_GSSL = child_HR_GS_GSSL;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
    }
}

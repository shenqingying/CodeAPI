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
    public class XZGL_FLFA : IXZGL_FLFA
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "HR_XZGL_FLFA_INSERT";
        const string SQL_SELECT = "HR_XZGL_FLFA_SELECT";
        const string SQL_UPDATE = "HR_XZGL_FLFA_UPDATE";
        public MES_RETURN INSERT(HR_XZGL_FLFA model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@FANAME",model.FANAME),
                                       new SqlParameter("@FASF",model.FASF),
                                       new SqlParameter("@FACITY",model.FACITY),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@CJR",model.CJR)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                        rst.TID = Convert.ToInt32(sdr["FLFAID"]);
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FLFA_INSERT", "HR");
            }
            return rst;
        }
        public MES_RETURN UPDATE(HR_XZGL_FLFA model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@FLFAID",model.FLFAID),
                                       new SqlParameter("@FANAME",model.FANAME),
                                       new SqlParameter("@FASF",model.FASF),
                                       new SqlParameter("@FACITY",model.FACITY),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@XGR",model.XGR),
                                       new SqlParameter("@LB",LB)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FLFA_UPDATE", "HR");
            }
            return rst;
        }
        public HR_XZGL_FLFA_SELECT SELECT(HR_XZGL_FLFA model)
        {
            HR_XZGL_FLFA_SELECT rst = new HR_XZGL_FLFA_SELECT();
            List<HR_XZGL_FLFA> child_HR_XZGL_FLFA = new List<HR_XZGL_FLFA>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        HR_XZGL_FLFA child = new HR_XZGL_FLFA();
                        child.FLFAID = Convert.ToInt32(sdr["FLFAID"]);
                        child.FANAME = Convert.ToString(sdr["FANAME"]);
                        child.FASF = Convert.ToInt32(sdr["FASF"]);
                        child.FASFNAME = Convert.ToString(sdr["FASFNAME"]);
                        child.FACITY = Convert.ToInt32(sdr["FACITY"]);
                        child.FACITYNAME = Convert.ToString(sdr["FACITYNAME"]);
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.ISDELETE = Convert.ToInt32(sdr["ISDELETE"]);
                        child.CJR = Convert.ToInt32(sdr["CJR"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJTIME = Convert.ToDateTime(sdr["CJTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.XGR = Convert.ToInt32(sdr["XGR"]);
                        child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                        child.XGTIME = Convert.ToDateTime(sdr["XGTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.ISDELETE = Convert.ToInt32(sdr["ISDELETE"]);
                        child.XZALL = Convert.ToString(sdr["XZALL"]);
                        child_HR_XZGL_FLFA.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FLFA_SELECT", "HR");
            }
            rst.HR_XZGL_FLFA = child_HR_XZGL_FLFA;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
    }
}

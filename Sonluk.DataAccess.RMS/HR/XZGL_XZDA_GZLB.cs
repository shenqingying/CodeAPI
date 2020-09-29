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
    public class XZGL_XZDA_GZLB : IXZGL_XZDA_GZLB
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "HR_XZGL_XZDA_GZLB_INSERT";
        const string SQL_SELECT = "HR_XZGL_XZDA_GZLB_SELECT";
        const string SQL_UPDATE = "HR_XZGL_XZDA_GZLB_UPDATE";
        public MES_RETURN INSERT(HR_XZGL_XZDA_GZLB model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GZLBNAME",model.GZLBNAME),
                                       new SqlParameter("@ZDID",model.ZDID)
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
        public MES_RETURN UPDATE(HR_XZGL_XZDA_GZLB model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GZLBID",model.GZLBID),
                                       new SqlParameter("@GZLBNAME",model.GZLBNAME),
                                       new SqlParameter("@ZDID",model.ZDID),
                                       new SqlParameter("@LB",LB),
                                       new SqlParameter("@MYPW",model.MYPW)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_XZDA_GZLB_UPDATE", "HR");
            }
            return rst;
        }
        public HR_XZGL_XZDA_GZLB_SELECT SELECT(HR_XZGL_XZDA_GZLB model)
        {
            HR_XZGL_XZDA_GZLB_SELECT rst = new HR_XZGL_XZDA_GZLB_SELECT();
            List<HR_XZGL_XZDA_GZLB> child_HR_XZGL_XZDA_GZLB = new List<HR_XZGL_XZDA_GZLB>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@GZLBID",model.GZLBID)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        HR_XZGL_XZDA_GZLB child = new HR_XZGL_XZDA_GZLB();
                        child.GZLBID = Convert.ToInt32(sdr["GZLBID"]);
                        child.GZLBNAME = Convert.ToString(sdr["GZLBNAME"]);
                        child.ZDID = Convert.ToInt32(sdr["ZDID"]);
                        child.ZDMS = Convert.ToString(sdr["ZDMS"]);
                        child_HR_XZGL_XZDA_GZLB.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_XZDA_GZLB_SELECT", "HR");
            }
            rst.HR_XZGL_XZDA_GZLB = child_HR_XZGL_XZDA_GZLB;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
    }
}

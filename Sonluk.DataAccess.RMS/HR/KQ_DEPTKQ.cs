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
    public class KQ_DEPTKQ : IKQ_DEPTKQ
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "HR_KQ_DEPTKQ_INSERT";
        const string SQL_SELECT = "HR_KQ_DEPTKQ_SELECT";
        const string SQL_UPDATE = "HR_KQ_DEPTKQ_UPDATE";
        public MES_RETURN INSERT(HR_KQ_DEPTKQ model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYIDNEW",model.RYIDNEW),
                                       new SqlParameter("@KQRQ",model.KQRQ),
                                       new SqlParameter("@KQSBTIME",model.KQSBTIME),
                                       new SqlParameter("@KQXBTIME",model.KQXBTIME),
                                       new SqlParameter("@CJR",model.CJR),
                                       new SqlParameter("@FREETIME",model.FREETIME),
                                       new SqlParameter("@REMARK",model.REMARK)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_KQ_DEPTKQ_INSERT", "HR");
            }
            return rst;
        }
        public MES_RETURN UPDATE(HR_KQ_DEPTKQ model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@DEPTKQID",model.DEPTKQID),
                                       new SqlParameter("@KQSBTIME",model.KQSBTIME),
                                       new SqlParameter("@KQXBTIME",model.KQXBTIME),
                                       new SqlParameter("@XGR",model.XGR),
                                       new SqlParameter("@LB",LB),
                                       new SqlParameter("@FREETIME",model.FREETIME),
                                       new SqlParameter("@REMARK",model.REMARK)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_KQ_DEPTKQ_UPDATE", "HR");
            }
            return rst;
        }
        public HR_KQ_DEPTKQ_SELECT SELECT(HR_KQ_DEPTKQ model, int LB)
        {
            HR_KQ_DEPTKQ_SELECT rst = new HR_KQ_DEPTKQ_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                       new SqlParameter("@GH",model.GH),
                                       new SqlParameter("@KQRQKS",model.KQRQKS),
                                       new SqlParameter("@KQRQJS",model.KQRQJS),
                                       new SqlParameter("@LB",LB),
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@DEPTID",model.DEPTID),
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@KQMONTH",model.KQMONTH)
                                   };
                rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_SELECT, paras);
                if (LB == 1)
                {
                    rst.DATALIST.Columns.Add("WORKTIME", typeof(string));
                    for (int a = 0; a < rst.DATALIST.Rows.Count; a++)
                    {
                        DateTime dt1 = Convert.ToDateTime(rst.DATALIST.Rows[a]["KQSBTIME"].ToString());
                        dt1 = dt1.AddMinutes(Convert.ToInt32(rst.DATALIST.Rows[a]["FREETIME"].ToString()));
                        DateTime dt2 = Convert.ToDateTime(rst.DATALIST.Rows[a]["KQXBTIME"].ToString());
                        TimeSpan dt3 = dt2 - dt1;
                        rst.DATALIST.Rows[a]["WORKTIME"] = dt3.Hours.ToString("00") + ":" + dt3.Minutes.ToString("00");
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_KQ_DEPTKQ_SELECT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
    }
}

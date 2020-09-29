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
    public class KQ_GSKQ : IKQ_GSKQ
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_SELECT = "HR_KQ_GSKQ_SELECT";
        public HR_KQ_GSKQ_SELECT SELECT(HR_KQ_GSKQ model, int LB)
        {
            HR_KQ_GSKQ_SELECT rst = new HR_KQ_GSKQ_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                       new SqlParameter("@GH",model.GH),
                                       new SqlParameter("@DEPTID",model.DEPTID),
                                       new SqlParameter("@KQRQKS",model.KQRQKS),
                                       new SqlParameter("@KQRQJS",model.KQRQJS),
                                       new SqlParameter("@LB",LB),
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };
                rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_SELECT, paras);
                if (LB == 1)
                {
                    rst.DATALIST.Columns.Add("WORKTIME", typeof(string));
                    for (int a = 0; a < rst.DATALIST.Rows.Count; a++)
                    {
                        if (rst.DATALIST.Rows[a]["KQSBTIME"].ToString() == "" || rst.DATALIST.Rows[a]["KQXBTIME"].ToString() == "")
                        {
                            rst.DATALIST.Rows[a]["WORKTIME"] = "";
                        }
                        else
                        {
                            DateTime dt1 = Convert.ToDateTime(rst.DATALIST.Rows[a]["KQSBTIME"].ToString());
                            DateTime dt2 = Convert.ToDateTime(rst.DATALIST.Rows[a]["KQXBTIME"].ToString());
                            TimeSpan dt3 = dt2 - dt1;
                            rst.DATALIST.Rows[a]["WORKTIME"] = dt3.Hours.ToString("00") + ":" + dt3.Minutes.ToString("00") + ":" + dt3.Seconds.ToString("00");
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_KQ_GSKQ_SELECT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
    }
}

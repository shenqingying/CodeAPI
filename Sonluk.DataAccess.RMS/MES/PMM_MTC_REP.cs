using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.MES
{
    class PMM_MTC_REP : IPMM_MTC_REP
    {
        const string SQL_PMM_MTC_REP_SELECT = "MES_PMM_MTC_REP_SELECT";
        const string SQL_PMM_MTC_REP_INSERT = "MES_PMM_MTC_REP_INSERT";
        const string SQL_PMM_MTC_REP_DELETE = "MES_PMM_MTC_REP_DELETE";

        public MES_PMM_MTC_REP_SELECT SELECT(MES_PMM_MTC_REP model)
        {
            MES_PMM_MTC_REP_SELECT rst = new MES_PMM_MTC_REP_SELECT();
            rst.MES_PMM_MTC_REP = new List<MES_PMM_MTC_REP>();
            rst.MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@MTCID",model.MTCID),
                                       new SqlParameter("@RID",model.RID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PMM_MTC_REP_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_PMM_MTC_REP child = new MES_PMM_MTC_REP();
                        child.MTCID = Convert.ToInt32(sdr["MTCID"]);
                        child.RID = Convert.ToInt32(sdr["RID"]);
                        child.RCODE = Convert.ToString(sdr["RCODE"]);
                        child.RNAME = Convert.ToString(sdr["RNAME"]);
                        rst.MES_PMM_MTC_REP.Add(child);
                    }
                }
                rst.MES_RETURN.TYPE = "S";
                rst.MES_RETURN.MESSAGE = "无";
            }
            catch (Exception e)
            {
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = e.Message;
            }
            return rst;
        }

        public MES_RETURN INSERT(MES_PMM_MTC_REP model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@MTCID",model.MTCID),
                                       new SqlParameter("@RID",model.RID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PMM_MTC_REP_INSERT, parms))
                {
                    if (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                    else
                    {
                        rst.TYPE = "E";
                        rst.MESSAGE = "无返回值";
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
            }
            return rst;
        }

        public MES_RETURN DELETE(int MTCID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@MTCID",MTCID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PMM_MTC_REP_DELETE, parms))
                {
                    if (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                    else
                    {
                        rst.TYPE = "E";
                        rst.MESSAGE = "无返回值";
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
            }
            return rst;
        }
    }
}

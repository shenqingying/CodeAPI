using Sonluk.DataAccess.RMS.MES;
using Sonluk.Entities.KQ;
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
    public class KQ_KQINFO : IKQ_KQINFO
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_SELECT = "SELECT ISNULL(MAX(ID),0) as maxid FROM HR_KQ_KQINFO";
        const string SQL_INSERT = "HR_KQ_KQINFO_INSERT";
        const string SQL_SELECT_JL = "HR_KQ_KQINFO_SELECT";
        public int SELECT_MAX()
        {
            int maxid = 0;
            try
            {
                SqlParameter[] paras = {

                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT, paras))
                {
                    while (sdr.Read())
                    {
                        maxid = Convert.ToInt32(sdr["maxid"]);
                    }
                }
            }
            catch (Exception e)
            {
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_ZXFJKC_SELECT", "HR");
            }
            return maxid;
        }
        public MES_RETURN INSERT(HR_KQ_KQINFO model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@Id",model.Id),
                                       new SqlParameter("@Badgenumber",model.Badgenumber),
                                       new SqlParameter("@Name",model.Name),
                                       new SqlParameter("@Code",model.Code),
                                       new SqlParameter("@DeptName",model.DeptName),
                                       new SqlParameter("@Checktime",model.Checktime),
                                       new SqlParameter("@Sn_name",model.Sn_name)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_KQ_KQINFO_INSERT", "HR");
            }
            return rst;
        }
        public HR_KQ_KQINFO_SELECT SELECT(HR_KQ_KQINFO model)
        {
            HR_KQ_KQINFO_SELECT rst = new HR_KQ_KQINFO_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                           new SqlParameter("@KQRQKS",model.KQRQKS),
                                       new SqlParameter("@KQRQJS",model.KQRQJS)
                                   };
                rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_SELECT_JL, paras);
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_KQ_KQINFO_SELECT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
    }
}

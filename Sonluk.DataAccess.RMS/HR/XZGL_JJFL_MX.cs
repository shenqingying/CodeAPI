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
    public class XZGL_JJFL_MX : IXZGL_JJFL_MX
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "HR_XZGL_JJFL_MX_INSERT";
        const string SQL_SELECT = "HR_XZGL_JJFL_MX_SELECT";
        const string SQL_UPDATE = "HR_XZGL_JJFL_MX_UPDATE";
        public MES_RETURN INSERT(HR_XZGL_JJFL_MX model, DataTable RYLIST)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@JJFLID",model.JJFLID),
                                       new SqlParameter("@RYLIST",RYLIST),
                                       new SqlParameter("@CJR",model.CJR)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_JJFL_MX_INSERT", "HR");
            }
            return rst;
        }
        public MES_RETURN UPDATE(HR_XZGL_JJFL_MX model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@JJFLMXID",model.JJFLMXID),
                                           new SqlParameter("@CHUQCOUNT",model.CHUQCOUNT),
                                           new SqlParameter("@JIABCOUNT",model.JIABCOUNT),
                                           new SqlParameter("@JXJJ",model.JXJJ),
                                           new SqlParameter("@JIABGZ",model.JIABGZ),
                                           new SqlParameter("@AIGJYJ",model.AIGJYJ),
                                           new SqlParameter("@JCDEPTNAME",model.JCDEPTNAME),
                                           new SqlParameter("@XGR",model.XGR),
                                           new SqlParameter("@LB",LB),
                                           new SqlParameter("@RYID",model.RYID),
                                           new SqlParameter("@JJFLID",model.JJFLID)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_JJFL_MX_UPDATE", "HR");
            }
            return rst;
        }
        public HR_XZGL_JJFL_MX_SELECT SELECT(HR_XZGL_JJFL_MX model)
        {
            HR_XZGL_JJFL_MX_SELECT rst = new HR_XZGL_JJFL_MX_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                           new SqlParameter("@JJFLID",model.JJFLID),
                                           new SqlParameter("@GH",model.GH),
                                           new SqlParameter("@DEPTIDLIST",model.DEPTIDLIST),
                                           new SqlParameter("@SBMONTHS",model.SBMONTHS),
                                           new SqlParameter("@SBMONTHE",model.SBMONTHE),
                                           new SqlParameter("@DEPTID",model.DEPTID),
                                           new SqlParameter("@LB",model.LB)
                                   };
                rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_SELECT, paras);
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_JJFL_MX_SELECT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
    }
}

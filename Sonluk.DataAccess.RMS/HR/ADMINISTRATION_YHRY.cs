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
    public class ADMINISTRATION_YHRY : IADMINISTRATION_YHRY
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "HR_ADMINISTRATION_YHRY_INSERT";
        const string SQL_UPDATE = "HR_ADMINISTRATION_YHRY_UPDATE";
        const string SQL_SELECT = "HR_ADMINISTRATION_YHRY_SELECT";
        public MES_RETURN INSERT(HR_ADMINISTRATION_YHRY model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@XM",model.XM),
                                       new SqlParameter("@ZWLEVEL",model.ZWLEVEL),
                                       new SqlParameter("@ZZMM",model.ZZMM),
                                       new SqlParameter("@ZWMS",model.ZWMS),
                                       new SqlParameter("@GH",model.GH),
                                       new SqlParameter("@CSRQ",model.CSRQ),
                                       new SqlParameter("@GSNAME",model.GSNAME),
                                       new SqlParameter("@GSBMNAME",model.GSBMNAME),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@CJR",model.CJR),
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@XB",model.XB)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_ADMINISTRATION_YHRY_INSERT", "HR");
            }
            return rst;
        }

        public MES_RETURN UPDATE(HR_ADMINISTRATION_YHRY model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@LB",model.LB),
                                           new SqlParameter("@YHRYID",model.YHRYID),
                                           new SqlParameter("@XGR",model.XGR),
                                           new SqlParameter("@XM",model.XM),
                                           new SqlParameter("@ZWLEVEL",model.ZWLEVEL),
                                           new SqlParameter("@ZZMM",model.ZZMM),
                                           new SqlParameter("@ZWMS",model.ZWMS),
                                           new SqlParameter("@GH",model.GH),
                                           new SqlParameter("@CSRQ",model.CSRQ),
                                           new SqlParameter("@GSNAME",model.GSNAME),
                                           new SqlParameter("@GSBMNAME",model.GSBMNAME),
                                           new SqlParameter("@REMARK",model.REMARK),
                                           new SqlParameter("@XB",model.XB)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_ADMINISTRATION_YHRY_UPDATE", "HR");
            }
            return rst;
        }
        public HR_ADMINISTRATION_YHRY_SELECT SELECT(HR_ADMINISTRATION_YHRY model)
        {
            HR_ADMINISTRATION_YHRY_SELECT rst = new HR_ADMINISTRATION_YHRY_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                           new SqlParameter("@XM",model.XM),
                                           new SqlParameter("@ZZMM",model.ZZMM),
                                           new SqlParameter("@DATEKS",model.DATEKS),
                                           new SqlParameter("@DATEJS",model.DATEJS),
                                           new SqlParameter("@ZWLEVELLIST",model.ZWLEVELLIST),
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_ADMINISTRATION_YHRY_SELECT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
    }
}

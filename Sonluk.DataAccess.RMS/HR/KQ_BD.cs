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
    public class KQ_BD : IKQ_BD
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "HR_KQ_BD_INSERT";
        const string SQL_SELECT = "HR_KQ_BD_SELECT";
        const string SQL_UPDATE = "HR_KQ_BD_UPDATE";
        public MES_RETURN INSERT(HR_KQ_BD model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@BDNAME",model.BDNAME),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@BDSBTIME",model.BDSBTIME),
                                       new SqlParameter("@BDSBTIMEKS",model.BDSBTIMEKS),
                                       new SqlParameter("@BDSBTIMEJS",model.BDSBTIMEJS),
                                       new SqlParameter("@BDXBTIME",model.BDXBTIME),
                                       new SqlParameter("@BDXBTIMEKS",model.BDXBTIMEKS),
                                       new SqlParameter("@BDXBTIMEJS",model.BDXBTIMEJS),
                                       new SqlParameter("@BDSBYH",model.BDSBYH),
                                       new SqlParameter("@BDXBYH",model.BDXBYH),
                                       new SqlParameter("@ISKT",model.ISKT),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@CJR",model.CJR),
                                       new SqlParameter("@FREETIME",model.FREETIME)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_KQ_BD_INSERT", "HR");
            }
            return rst;
        }
        public MES_RETURN UPDATE(HR_KQ_BD model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@BDID",model.BDID),
                                       new SqlParameter("@BDNAME",model.BDNAME),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@BDSBTIME",model.BDSBTIME),
                                       new SqlParameter("@BDSBTIMEKS",model.BDSBTIMEKS),
                                       new SqlParameter("@BDSBTIMEJS",model.BDSBTIMEJS),
                                       new SqlParameter("@BDXBTIME",model.BDXBTIME),
                                       new SqlParameter("@BDXBTIMEKS",model.BDXBTIMEKS),
                                       new SqlParameter("@BDXBTIMEJS",model.BDXBTIMEJS),
                                       new SqlParameter("@BDSBYH",model.BDSBYH),
                                       new SqlParameter("@BDXBYH",model.BDXBYH),
                                       new SqlParameter("@ISKT",model.ISKT),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@XGR",model.XGR),
                                       new SqlParameter("@LB",LB),
                                       new SqlParameter("@FREETIME",model.FREETIME)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_KQ_BD_UPDATE", "HR");
            }
            return rst;
        }
        public HR_KQ_BD_SELECT SELECT(HR_KQ_BD model)
        {
            HR_KQ_BD_SELECT rst = new HR_KQ_BD_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                           new SqlParameter("@BDNAME",model.BDNAME),
                                       new SqlParameter("@ISACTION",model.ISACTION)
                                   };
                rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_SELECT, paras);
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_KQ_BD_SELECT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
    }
}

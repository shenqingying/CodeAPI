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
    public class DA_DAINFO : IDA_DAINFO
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_DADM_INSERT = "HR_DA_DADM_INSERT";
        const string SQL_DADM_SELECT = "HR_DA_DADM_SELECT";
        const string SQL_DADM_UPDATE = "HR_DA_DADM_UPDATE";
        const string SQL_DADM_DELETE = "HR_DA_DADM_DELETE";
        const string SQL_DAINFO_INSERT = "HR_DA_DAINFO_INSERT";
        const string SQL_DAINFO_SELECT = "HR_DA_DAINFO_SELECT";
        const string SQL_DAINFO_UPDATE = "HR_DA_DAINFO_UPDATE";
        const string SQL_DAINFO_DELETE = "UPDATE HR_DA_DAINFO SET ISDELETE=1 WHERE DAID=@DAID";
        const string SQL_DAJYJL_INSERT = "HR_DA_DAJYJL_INSERT";
        const string SQL_DAJYJL_SELECT = "HR_DA_DAJYJL_SELECT";
        const string SQL_DAJYJL_UPDATE = "HR_DA_DAJYJL_UPDATE";

        public MES_RETURN INSERT_DADM(HR_DA_DADM model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@DADM",model.DADM),
                                       new SqlParameter("@DALB",model.DALB),
                                       new SqlParameter("@DADMNAME",model.DADMNAME)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DADM_INSERT, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_DA_DADM_INSERT", "HR");
            }
            return rst;
        }
        public HR_DA_DADM_SELECT SELECT_DADM(HR_DA_DADM model)
        {
            HR_DA_DADM_SELECT rst = new HR_DA_DADM_SELECT();
            List<HR_DA_DADM_LIST> model_HR_DA_DADM_LIST = new List<HR_DA_DADM_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@DALB",model.DALB),
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DADM_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        HR_DA_DADM_LIST child = new HR_DA_DADM_LIST();
                        child.DADMID = Convert.ToInt32(sdr["DADMID"]);
                        child.DADM = Convert.ToString(sdr["DADM"]);
                        child.DALB = Convert.ToInt32(sdr["DALB"]);
                        child.DALBNAME = Convert.ToString(sdr["DALBNAME"]);
                        child.DADMNAME = Convert.ToString(sdr["DADMNAME"]);
                        model_HR_DA_DADM_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_RYINFO_SELECT", "HR");
            }
            rst.HR_DA_DADM_LIST = model_HR_DA_DADM_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN UPDATE_DADM(HR_DA_DADM model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@DADMID",model.DADMID),
                                       new SqlParameter("@DADM",model.DADM),
                                       new SqlParameter("@DALB",model.DALB),
                                       new SqlParameter("@DADMNAME",model.DADMNAME)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DADM_UPDATE, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_DA_DADM_UPDATE", "HR");
            }
            return rst;
        }
        public MES_RETURN DELETE_DADM(int DADMID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@DADMID",DADMID)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DADM_DELETE, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_DA_DADM_DELETE", "HR");
            }
            return rst;
        }
        public MES_RETURN INSERT_DAINFO(HR_DA_DAINFO model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@DADM",model.DADM),
                                       new SqlParameter("@DAJSRQ",model.DAJSRQ),
                                       new SqlParameter("@BGQX",model.BGQX),
                                       new SqlParameter("@AJNAME",model.AJNAME),
                                       new SqlParameter("@DAXS",model.DAXS),
                                       new SqlParameter("@DAMJ",model.DAMJ),
                                       new SqlParameter("@TZCOUNT",model.TZCOUNT),
                                       new SqlParameter("@WJCOUNT",model.WJCOUNT),
                                       new SqlParameter("@ALLCOUNT",model.ALLCOUNT),
                                       new SqlParameter("@LYNAME",model.LYNAME),
                                       new SqlParameter("@TM1",model.TM1),
                                       new SqlParameter("@TM2",model.TM2),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@CJR",model.CJR),
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DAINFO_INSERT, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                        rst.TMSX = Convert.ToInt32(sdr["DANO"]);
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_DA_DAINFO_INSERT", "HR");
            }
            return rst;
        }
        public HR_DA_DAINFO_SELECT SELECT_DAINFO(HR_DA_DAINFO model)
        {
            HR_DA_DAINFO_SELECT rst = new HR_DA_DAINFO_SELECT();
            List<HR_DA_DAINFO_LIST> model_HR_DA_DAINFO_LIST = new List<HR_DA_DAINFO_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@DALB",model.DALB),
                                       new SqlParameter("@DADM",model.DADM),
                                       new SqlParameter("@AJNAME",model.AJNAME),
                                       new SqlParameter("@DAJSRQKS",model.DAJSRQKS),
                                       new SqlParameter("@DAJSRQJS",model.DAJSRQJS),
                                       new SqlParameter("@DAMJ",model.DAMJ),
                                       new SqlParameter("@DAZT",model.DAZT),
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DAINFO_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        HR_DA_DAINFO_LIST child = new HR_DA_DAINFO_LIST();
                        child.DAID = Convert.ToInt32(sdr["DAID"]);
                        child.DANO = Convert.ToInt32(sdr["DANO"]);
                        child.DADMID = Convert.ToInt32(sdr["DADMID"]);
                        child.DAJSRQ = Convert.ToString(sdr["DAJSRQ"]);
                        child.BGQX = Convert.ToInt32(sdr["BGQX"]);
                        child.BGQXNAME = Convert.ToString(sdr["BGQXNAME"]);
                        child.AJNAME = Convert.ToString(sdr["AJNAME"]);

                        child.DAXS = Convert.ToInt32(sdr["DAXS"]);
                        child.DAXSNAME = Convert.ToString(sdr["DAXSNAME"]);
                        child.DAMJ = Convert.ToInt32(sdr["DAMJ"]);
                        child.DAMJNAME = Convert.ToString(sdr["DAMJNAME"]);
                        child.TZCOUNT = Convert.ToInt32(sdr["TZCOUNT"]);
                        child.WJCOUNT = Convert.ToInt32(sdr["WJCOUNT"]);
                        child.ALLCOUNT = Convert.ToInt32(sdr["ALLCOUNT"]);

                        child.LYNAME = Convert.ToString(sdr["LYNAME"]);
                        child.TM1 = Convert.ToString(sdr["TM1"]);
                        child.TM2 = Convert.ToString(sdr["TM2"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.DAZT = Convert.ToInt32(sdr["DAZT"]);
                        child.DADM = Convert.ToString(sdr["DADM"]);
                        child.DALB = Convert.ToInt32(sdr["DALB"]);
                        child.DALBNAME = Convert.ToString(sdr["DALBNAME"]);
                        child.DADMNAME = Convert.ToString(sdr["DADMNAME"]);
                        model_HR_DA_DAINFO_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_DA_DAINFO_SELECT", "HR");
            }
            rst.HR_DA_DAINFO_LIST = model_HR_DA_DAINFO_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN UPDATE_DAINFO(HR_DA_DAINFO model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@DAID",model.DAID),
                                       new SqlParameter("@DADM",model.DADM),
                                       new SqlParameter("@DAJSRQ",model.DAJSRQ),
                                       new SqlParameter("@BGQX",model.BGQX),
                                       new SqlParameter("@AJNAME",model.AJNAME),
                                       new SqlParameter("@DAXS",model.DAXS),
                                       new SqlParameter("@DAMJ",model.DAMJ),
                                       new SqlParameter("@TZCOUNT",model.TZCOUNT),
                                       new SqlParameter("@WJCOUNT",model.WJCOUNT),
                                       new SqlParameter("@ALLCOUNT",model.ALLCOUNT),
                                       new SqlParameter("@LYNAME",model.LYNAME),
                                       new SqlParameter("@TM1",model.TM1),
                                       new SqlParameter("@TM2",model.TM2),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@XGR",model.XGR),
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DAINFO_UPDATE, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_DA_DAINFO_UPDATE", "HR");
            }
            return rst;
        }
        public MES_RETURN DELETE_DAINFO(int DAID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@DAID",DAID)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_DAINFO_DELETE, parms))
                {
                        rst.TYPE = "S";
                        rst.MESSAGE = "";
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_DA_DAINFO_DELETE", "HR");
            }
            return rst;
        }
        public MES_RETURN INSERT_DAJYJL(HR_DA_DAJYJL model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@DAID",model.DAID),
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@JYRQ",model.JYRQ),
                                       new SqlParameter("@GHRQ",model.GHRQ),
                                       new SqlParameter("@JYMD",model.JYMD),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@CJR",model.CJR),
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DAJYJL_INSERT, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_DA_DAJYJL_INSERT", "HR");
            }
            return rst;
        }
        public HR_DA_DAJYJL_SELECT SELECT_DAJYJL(HR_DA_DAJYJL model)
        {
            HR_DA_DAJYJL_SELECT rst = new HR_DA_DAJYJL_SELECT();
            List<HR_DA_DAJYJL_LIST> model_HR_DA_DAJYJL_LIST = new List<HR_DA_DAJYJL_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@DAID",model.DAID),
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@JYZT",model.JYZT),
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DAJYJL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        HR_DA_DAJYJL_LIST child = new HR_DA_DAJYJL_LIST();
                        child.DAJYJL = Convert.ToInt32(sdr["DAJYJL"]);
                        child.DAID = Convert.ToInt32(sdr["DAID"]);
                        child.RYID = Convert.ToInt32(sdr["RYID"]);
                        child.JYRQ = Convert.ToString(sdr["JYRQ"]);
                        child.GHRQ = Convert.ToString(sdr["GHRQ"]);
                        child.JYMD = Convert.ToString(sdr["JYMD"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.JYZT = Convert.ToInt32(sdr["JYZT"]);

                        child.ISDELETE = Convert.ToInt32(sdr["ISDELETE"]);
                        child.SJGHRQ = Convert.ToString(sdr["SJGHRQ"]);
                        child.GH = Convert.ToString(sdr["GH"]);
                        child.YGNAME = Convert.ToString(sdr["YGNAME"]);
                        child.GSNAME = Convert.ToString(sdr["GSNAME"]);
                        child.DEPTNAME = Convert.ToString(sdr["DEPTNAME"]);
                        child.XB = Convert.ToString(sdr["XB"]);
                        child.ZZZTNAME = Convert.ToString(sdr["ZZZTNAME"]);
                        model_HR_DA_DAJYJL_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_DA_DAJYJL_SELECT", "HR");
            }
            rst.HR_DA_DAJYJL_LIST = model_HR_DA_DAJYJL_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN UPDATE_DAJYJL(HR_DA_DAJYJL model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@DAJYJL",model.DAJYJL),
                                       new SqlParameter("@SJGHRQ",model.SJGHRQ),
                                       new SqlParameter("@XGR",model.XGR),
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DAJYJL_UPDATE, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_DA_DAJYJL_UPDATE", "HR");
            }
            return rst;
        }
    }
}

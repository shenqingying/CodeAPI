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
    public class RY_BANKNO : IRY_BANKNO
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "HR_RY_BANKNO_INSERT";
        const string SQL_SELECT = "HR_RY_BANKNO_SELECT";
        const string SQL_UPDATE = "HR_RY_BANKNO_UPDATE";
        public MES_RETURN INSERT(HR_RY_BANKNO model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@ZHLB",model.ZHLB),
                                       new SqlParameter("@BANK",model.BANK),
                                       new SqlParameter("@BANKNO",model.BANKNO),
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_BANKNO_INSERT", "HR");
            }
            return rst;
        }
        public MES_RETURN UPDATE(HR_RY_BANKNO model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@BANKNOID",model.BANKNOID),
                                       new SqlParameter("@ZHLB",model.ZHLB),
                                       new SqlParameter("@BANK",model.BANK),
                                       new SqlParameter("@BANKNO",model.BANKNO),
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_BANKNO_UPDATE", "HR");
            }
            return rst;
        }
        public HR_RY_BANKNO_SELECT SELECT(HR_RY_BANKNO model)
        {
            HR_RY_BANKNO_SELECT rst = new HR_RY_BANKNO_SELECT();
            List<HR_RY_BANKNO_LIST> child_HR_RY_BANKNO_LIST = new List<HR_RY_BANKNO_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                       new SqlParameter("@BANKNOID",model.BANKNOID),
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@ZHLB",model.ZHLB),
                                       new SqlParameter("@BANK",model.BANK),
                                       new SqlParameter("@BANKNO",model.BANKNO),
                                       new SqlParameter("@GH",model.GH),
                                       new SqlParameter("@DEPT",model.DEPT),
                                       new SqlParameter("@ZZZT",model.ZZZT)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, paras))
                {
                    while (sdr.Read())
                    {
                        HR_RY_BANKNO_LIST child = new HR_RY_BANKNO_LIST();
                        child.BANKNOID = Convert.ToInt32(sdr["BANKNOID"]);
                        child.RYID = Convert.ToInt32(sdr["RYID"]);
                        child.ZHLB = Convert.ToInt32(sdr["ZHLB"]);
                        child.ZHLBNAME = Convert.ToString(sdr["ZHLBNAME"]);
                        child.BANK = Convert.ToInt32(sdr["BANK"]);
                        child.BANKNAME = Convert.ToString(sdr["BANKNAME"]);
                        child.BANKNO = Convert.ToString(sdr["BANKNO"]);
                        child.CJR = Convert.ToInt32(sdr["CJR"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJTIME = Convert.ToDateTime(sdr["CJTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.XGR = Convert.ToInt32(sdr["XGR"]);
                        child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                        child.XGTIME = Convert.ToDateTime(sdr["XGTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.GH = Convert.ToString(sdr["GH"]);
                        child.YGNAME = Convert.ToString(sdr["YGNAME"]);
                        child.GSNAME = Convert.ToString(sdr["GSNAME"]);
                        child.DEPTNAME = Convert.ToString(sdr["DEPTNAME"]);
                        child.YGTYPENAME = Convert.ToString(sdr["YGTYPENAME"]);
                        child.ZZTYPENAME = Convert.ToString(sdr["ZZTYPENAME"]);
                        child.ZZNO = Convert.ToString(sdr["ZZNO"]);
                        child.NSRSFNAME = Convert.ToString(sdr["NSRSFNAME"]);
                        child.NSRSBH = Convert.ToString(sdr["NSRSBH"]);
                        child.ZZZTNAME = Convert.ToString(sdr["ZZZTNAME"]);
                        child_HR_RY_BANKNO_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_RY_BANKNO_SELECT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.HR_RY_BANKNO_LIST = child_HR_RY_BANKNO_LIST;
            return rst;
        }
    }
}

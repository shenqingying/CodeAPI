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
    public class ZS_SY_JL : IZS_SY_JL
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "MES_ZS_SY_JL_INSERT";
        const string SQL_UPDATE = "MES_ZS_SY_JL_UPDATE";

        const string SQL_INSERT_MX = "MES_ZS_SY_JLMX_INSERT";
        const string SQL_SELECT_MX = "MES_ZS_SY_JLMX_SELECT";

        const string SQL_INSERT_QJQXJL = "MES_ZS_SY_JL_QJQXJL_INSERT";
        public MES_RETURN INSERT(MES_ZS_SY_JL model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@JLMS",model.JLMS),
                                       new SqlParameter("@CJR",model.CJR),
                                       new SqlParameter("@KCBSTM",model.KCBSTM),
                                       new SqlParameter("@JLLB",model.JLLB),
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@KHID",model.KHID),
                                       new SqlParameter("@CZRGH",model.CZRGH),
                                       new SqlParameter("@CZRNAME",model.CZRNAME),
                                       new SqlParameter("@SBBH",model.SBBH)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_ZS_SY_JL_INSERT", "MES_ZS");
            }
            return rst;
        }
        public MES_RETURN UPDATE(MES_ZS_SY_JL model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@KCBSTM",model.KCBSTM),
                                       new SqlParameter("@XGR",model.XGR),
                                       new SqlParameter("@JLMS",model.JLMS),
                                       new SqlParameter("@JLID",model.JLID)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_ZS_SY_JL_UPDATE", "MES_ZS");
            }
            return rst;
        }
        public MES_RETURN INSERT_MX(MES_ZS_SY_JL_MX model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@JLID",model.JLID),
                                       new SqlParameter("@TM",model.TM),
                                       new SqlParameter("@FTM",model.FTM),
                                       new SqlParameter("@JLMXLB",model.JLMXLB),
                                       new SqlParameter("@JLMXLBNAME",model.JLMXLBNAME),
                                       new SqlParameter("@KCDDGC",model.KCDDGC),
                                       new SqlParameter("@KCDD",model.KCDD),
                                       new SqlParameter("@KCDDNAME",model.KCDDNAME)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT_MX, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_ZS_SY_JLMX_INSERT", "MES_ZS");
            }
            return rst;
        }
        public MES_ZS_SY_JL_MX_SELECT SELECT_MX(MES_ZS_SY_JL_MX model)
        {
            MES_ZS_SY_JL_MX_SELECT rst = new MES_ZS_SY_JL_MX_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_ZS_SY_JL_MX> child_MES_ZS_SY_JL_MX = new List<MES_ZS_SY_JL_MX>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@TM",model.TM),
                                       new SqlParameter("@KCDDGC",model.KCDDGC),
                                       new SqlParameter("@KCDD",model.KCDD),
                                       new SqlParameter("@JLMXLBLIST",model.JLMXLBLIST),
                                       new SqlParameter("@KHMS",model.KHMS),
                                       new SqlParameter("@ISSHOWQX",model.ISSHOWQX),
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@JLID",model.JLID),
                                       new SqlParameter("@KSDATE",model.KSDATE),
                                       new SqlParameter("@JSDATE",model.JSDATE)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_MX, parms))
                {
                    while (sdr.Read())
                    {
                        if (model.LB == 1)
                        {
                            MES_ZS_SY_JL_MX child = new MES_ZS_SY_JL_MX();
                            child.ERRORCOUNT = Convert.ToInt32(sdr["ERRORCOUNT"]);
                            child_MES_ZS_SY_JL_MX.Add(child);
                        }
                        else if (model.LB == 2 || model.LB == 5)
                        {
                            MES_ZS_SY_JL_MX child = new MES_ZS_SY_JL_MX();
                            child.JLID = Convert.ToInt32(sdr["JLID"]);
                            child.JLMXID = Convert.ToInt32(sdr["JLMXID"]);
                            child.JLMS = Convert.ToString(sdr["JLMS"]);
                            child.CJTIME = Convert.ToDateTime(sdr["CJTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                            child.JLMXLB = Convert.ToInt32(sdr["JLMXLB"]);
                            child.JLMXLBNAME = Convert.ToString(sdr["JLMXLBNAME"]);
                            child.KCDDGC = Convert.ToString(sdr["KCDDGC"]);
                            child.KCDD = Convert.ToString(sdr["KCDD"]);
                            child.KCDDNAME = Convert.ToString(sdr["KCDDNAME"]);
                            child.KHNO = Convert.ToString(sdr["KHNO"]);
                            child.KHMS = Convert.ToString(sdr["KHMS"]);
                            child.FTM = Convert.ToString(sdr["FTM"]);
                            child.TM = Convert.ToString(sdr["TM"]);
                            child.WLH = Convert.ToString(sdr["WLH"]);
                            child.WLMS = Convert.ToString(sdr["WLMS"]);
                            child.PC = Convert.ToString(sdr["PC"]);
                            child.MOULD = Convert.ToString(sdr["MOULD"]);
                            child.SL = Convert.ToDecimal(sdr["SL"]);
                            child.UNITSNAME = Convert.ToString(sdr["UNITSNAME"]);
                            child.ISQX = Convert.ToInt32(sdr["ISQX"]);
                            child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                            child.XGTIME = Convert.ToDateTime(sdr["XGTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                            child.FPC = Convert.ToString(sdr["FPC"]);
                            child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                            child.SBMS = Convert.ToString(sdr["SBMS"]);
                            child.GC = Convert.ToString(sdr["GC"]);
                            child.CZRNAME = Convert.ToString(sdr["CZRNAME"]);
                            child.KCDDGCMB = Convert.ToString(sdr["KCDDGCMB"]);
                            child.KCDDMB = Convert.ToString(sdr["KCDDMB"]);
                            child.KCDDNAMEMB = Convert.ToString(sdr["KCDDNAMEMB"]);
                            child_MES_ZS_SY_JL_MX.Add(child);
                        }
                        else if (model.LB == 3)
                        {
                            MES_ZS_SY_JL_MX child = new MES_ZS_SY_JL_MX();
                            child.JLID = Convert.ToInt32(sdr["JLID"]);
                            child.JLMXID = Convert.ToInt32(sdr["JLMXID"]);
                            child.JLMS = Convert.ToString(sdr["JLMS"]);
                            child.ISQX = Convert.ToInt32(sdr["ISQX"]);
                            child.JLLB = Convert.ToInt32(sdr["JLLB"]);
                            child.GC = Convert.ToString(sdr["GC"]);
                            child.KCDDGC = Convert.ToString(sdr["KCDDGC"]);
                            child.KCDD = Convert.ToString(sdr["KCDD"]);
                            child.KCDDNAME = Convert.ToString(sdr["KCDDNAME"]);
                            child_MES_ZS_SY_JL_MX.Add(child);
                        }
                        else if (model.LB == 4)
                        {
                            MES_ZS_SY_JL_MX child = new MES_ZS_SY_JL_MX();
                            child.TM = Convert.ToString(sdr["TM"]);
                            child.MOULD = Convert.ToString(sdr["MOULD"]);
                            child_MES_ZS_SY_JL_MX.Add(child);
                        }
                    }
                    child_MES_RETURN.TYPE = "S";
                    child_MES_RETURN.MESSAGE = "";
                }
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_ZS_SY_TL_SELECT", "MES_ZS");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_ZS_SY_JL_MX = child_MES_ZS_SY_JL_MX;
            return rst;
        }
        public MES_RETURN INSERT_QJQXJL(MES_ZS_SY_JL_QJQXJL model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@QXSL",model.QXSL),
                                       new SqlParameter("@QXNOHGSL",model.QXNOHGSL),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@JLMXID",model.JLMXID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT_QJQXJL, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_ZS_SY_JL_QJQXJL_INSERT", "MES_ZS");
            }
            return rst;
        }
    }
}

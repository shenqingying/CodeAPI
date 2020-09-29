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
    public class SY_SCDATE_TH : ISY_SCDATE_TH
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "MES_SY_SCDATE_TH_INSERT";
        const string SQL_UPDATE = "MES_SY_SCDATE_TH_UPDATE";
        const string SQL_SELECT = "MES_SY_SCDATE_TH_SELECT";
        const string SQL_SELECT_BY_ROLE = "MES_SY_SCDATE_TH_SELECT_BY_ROLE";
        public MES_RETURN INSERT(MES_SY_SCDATE_TH model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@SCDATE",model.SCDATE),
                                       new SqlParameter("@SCDATETH",model.SCDATETH),
                                       new SqlParameter("@CJR",model.CJR),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@MBSCDATE",model.MBSCDATE),
                                       new SqlParameter("@THZF",model.THZF)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_SCDATE_TH_INSERT");
            }
            return rst;
        }

        public MES_RETURN UPDATE(MES_SY_SCDATE_TH model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@SCDATE",model.SCDATE),
                                       new SqlParameter("@SCDATETH",model.SCDATETH),
                                       new SqlParameter("@CJR",model.CJR),
                                       new SqlParameter("@LB",LB),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@MBSCDATE",model.MBSCDATE)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_SCDATE_TH_INSERT");
            }
            return rst;
        }

        public MES_SY_SCDATE_TH_SELECT SELECT(MES_SY_SCDATE_TH_SELECT_IN model, int LB)
        {
            MES_SY_SCDATE_TH_SELECT rst = new MES_SY_SCDATE_TH_SELECT();
            List<MES_SY_SCDATE_TH> child_MES_SY_SCDATE_TH = new List<MES_SY_SCDATE_TH>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@SCDATES",model.SCDATES),
                                       new SqlParameter("@SCDATEE",model.SCDATEE),
                                       new SqlParameter("@LB",LB)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_SCDATE_TH child = new MES_SY_SCDATE_TH();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        child.GZZXNAME = Convert.ToString(sdr["GZZXNAME"]);
                        child.SCDATE = Convert.ToString(sdr["SCDATE"]);
                        child.SCDATETH = Convert.ToString(sdr["SCDATETH"]);
                        child.ISDELETE = Convert.ToInt32(sdr["ISDELETE"]);
                        child.CJR = Convert.ToInt32(sdr["CJR"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child_MES_SY_SCDATE_TH.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_PLDH_PH_SELECT");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_SY_SCDATE_TH = child_MES_SY_SCDATE_TH;
            return rst;
        }

        public MES_SY_SCDATE_TH_SELECT SELECT_BY_ROLE(MES_SY_SCDATE_TH_SELECT_IN model, int LB)
        {
            MES_SY_SCDATE_TH_SELECT rst = new MES_SY_SCDATE_TH_SELECT();
            List<MES_SY_SCDATE_TH> child_MES_SY_SCDATE_TH = new List<MES_SY_SCDATE_TH>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@SCDATES",model.SCDATES),
                                       new SqlParameter("@SCDATEE",model.SCDATEE),
                                       new SqlParameter("@LB",LB),
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@SCDATETH",model.SCDATETH),
                                       new SqlParameter("@MBSCDATE",model.MBSCDATE)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_BY_ROLE, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_SCDATE_TH child = new MES_SY_SCDATE_TH();
                        if (LB == 1)
                        {
                            child.GC = Convert.ToString(sdr["GC"]);
                            child.SCDATE = Convert.ToString(sdr["SCDATE"]);
                            child.SCDATETH = Convert.ToString(sdr["SCDATETH"]);
                            child.MBSCDATE = Convert.ToString(sdr["MBSCDATE"]);
                        }
                        else
                        {
                            child.GC = Convert.ToString(sdr["GC"]);
                            child.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                            child.GZZXNAME = Convert.ToString(sdr["GZZXNAME"]);
                            child.SCDATE = Convert.ToString(sdr["SCDATE"]);
                            child.SCDATETH = Convert.ToString(sdr["SCDATETH"]);
                            child.ISDELETE = Convert.ToInt32(sdr["ISDELETE"]);
                            child.CJR = Convert.ToInt32(sdr["CJR"]);
                            child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                            child.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
                            child.REMARK = Convert.ToString(sdr["REMARK"]);
                            child.MBSCDATE = Convert.ToString(sdr["MBSCDATE"]);
                            child.THZF = Convert.ToInt32(sdr["THZF"]);
                            child.THZFNAME = Convert.ToString(sdr["THZFNAME"]);
                        }
                        child_MES_SY_SCDATE_TH.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_PLDH_PH_SELECT");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_SY_SCDATE_TH = child_MES_SY_SCDATE_TH;
            return rst;
        }
    }
}

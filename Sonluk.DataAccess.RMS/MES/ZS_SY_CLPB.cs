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
    public class ZS_SY_CLPB : IZS_SY_CLPB
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "MES_ZS_SY_CLPB_INSERT";
        const string SQL_SELECT = "MES_ZS_SY_CLPB_SELECT";
        const string SQL_UPDATE = "MES_ZS_SY_CLPB_UPDATE";
        const string SQL_INSERT_WL = "MES_ZS_SY_CLPB_WL_INSERT";
        const string SQL_SELECT_WL = "MES_ZS_SY_CLPB_WL_SELECT";
        const string SQL_UPDATE_WL = "MES_ZS_SY_CLPB_WL_UPDATE";
        public MES_RETURN INSERT(MES_ZS_SY_CLPB model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@YCLDMID",model.YCLDMID),
                                       new SqlParameter("@PBDMID",model.PBDMID),
                                       new SqlParameter("@YCLPBDM",model.YCLPBDM),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@CJR",model.CJR),
                                       new SqlParameter("@ISACTION",model.ISACTION)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_ZS_SY_CLPB_INSERT", "MES_ZS");
            }
            return rst;
        }
        public MES_RETURN UPDATE(MES_ZS_SY_CLPB model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@CLPBID",model.CLPBID),
                                       new SqlParameter("@XGR",model.XGR),
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@YCLDMID",model.YCLDMID),
                                       new SqlParameter("@PBDMID",model.PBDMID),
                                       new SqlParameter("@YCLPBDM",model.YCLPBDM),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@CJR",model.CJR),
                                       new SqlParameter("@ISACTION",model.ISACTION)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_ZS_SY_CLPB_UPDATE", "HR");
            }
            return rst;
        }
        public MES_ZS_SY_CLPB_SELECT SELECT(MES_ZS_SY_CLPB model)
        {
            MES_ZS_SY_CLPB_SELECT rst = new MES_ZS_SY_CLPB_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_ZS_SY_CLPB> child_MES_ZS_SY_CLPB = new List<MES_ZS_SY_CLPB>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@YCLPBDM",model.YCLPBDM),
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_ZS_SY_CLPB child = new MES_ZS_SY_CLPB();
                        child.CLPBID = Convert.ToInt32(sdr["CLPBID"]);
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.YCLDMID = Convert.ToInt32(sdr["YCLDMID"]);
                        child.PBDMID = Convert.ToInt32(sdr["PBDMID"]);
                        child.YCLPBDM = Convert.ToString(sdr["YCLPBDM"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.YCLDMNAME = Convert.ToString(sdr["YCLDMNAME"]);
                        child.YCLDMREMARK = Convert.ToString(sdr["YCLDMREMARK"]);
                        child.PBDMNAME = Convert.ToString(sdr["PBDMNAME"]);
                        child.PBDMREMARK = Convert.ToString(sdr["PBDMREMARK"]);
                        child.TMCOUNT = Convert.ToInt32(sdr["TMCOUNT"]);
                        child_MES_ZS_SY_CLPB.Add(child);
                    }
                    child_MES_RETURN.TYPE = "S";
                    child_MES_RETURN.MESSAGE = "";
                }
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_ZS_SY_CLPB_SELECT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_ZS_SY_CLPB = child_MES_ZS_SY_CLPB;
            return rst;
        }

        public MES_RETURN INSERT_WL(MES_ZS_SY_CLPB_WL model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@CLPBID",model.CLPBID),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@CJR",model.CJR)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT_WL, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_ZS_SY_CLPB_WL_INSERT", "MES_ZS");
            }
            return rst;
        }
        public MES_RETURN UPDATE_WL(MES_ZS_SY_CLPB_WL model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@CLPBMXID",model.CLPBMXID),
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@XGR",model.XGR)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE_WL, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_ZS_SY_CLPB_WL_UPDATE", "HR");
            }
            return rst;
        }
        public MES_ZS_SY_CLPB_WL_SELECT SELECT_WL(MES_ZS_SY_CLPB_WL model)
        {
            MES_ZS_SY_CLPB_WL_SELECT rst = new MES_ZS_SY_CLPB_WL_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_ZS_SY_CLPB_WL> child_MES_ZS_SY_CLPB_WL = new List<MES_ZS_SY_CLPB_WL>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@CLPBID",model.CLPBID),
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@GC",model.GC)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_WL, parms))
                {
                    while (sdr.Read())
                    {
                        MES_ZS_SY_CLPB_WL child = new MES_ZS_SY_CLPB_WL();
                        child.CLPBMXID = Convert.ToInt32(sdr["CLPBMXID"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.WLMS = Convert.ToString(sdr["WLMS"]);
                        child_MES_ZS_SY_CLPB_WL.Add(child);
                    }
                    child_MES_RETURN.TYPE = "S";
                    child_MES_RETURN.MESSAGE = "";
                }
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_ZS_SY_CLPB_WL_SELECT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_ZS_SY_CLPB_WL = child_MES_ZS_SY_CLPB_WL;
            return rst;
        }
    }
}

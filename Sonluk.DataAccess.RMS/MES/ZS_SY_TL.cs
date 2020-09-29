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
    public class ZS_SY_TL : IZS_SY_TL
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "MES_ZS_SY_TL_INSERT";
        const string SQL_SELECT = "MES_ZS_SY_TL_SELECT";
        const string SQL_UPDATE = "MES_ZS_SY_TL_UPDATE";
        public MES_RETURN INSERT(MES_ZS_SY_TL model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@TLPC",model.TLPC),
                                       new SqlParameter("@TLTIME",model.TLTIME),
                                       new SqlParameter("@REMARK",model.REMARK),
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_ZS_SY_TL_INSERT", "MES_ZS");
            }
            return rst;
        }
        public MES_RETURN UPDATE(MES_ZS_SY_TL model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@TLID",model.TLID),
                                       new SqlParameter("@TLPC",model.TLPC),
                                       new SqlParameter("@TLTIME",model.TLTIME),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@XGR",model.XGR)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_ZS_SY_TL_UPDATE", "MES_ZS");
            }
            return rst;
        }
        public MES_ZS_SY_TL_SELECT SELECT(MES_ZS_SY_TL model)
        {
            MES_ZS_SY_TL_SELECT rst = new MES_ZS_SY_TL_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_ZS_SY_TL> child_MES_ZS_SY_TL = new List<MES_ZS_SY_TL>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@WLMS",model.WLMS),
                                       new SqlParameter("@TLPC",model.TLPC),
                                       new SqlParameter("@TLTIMES",model.TLTIMES),
                                       new SqlParameter("@TLTIMEE",model.TLTIMEE),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_ZS_SY_TL child = new MES_ZS_SY_TL();
                        child.TLID = Convert.ToInt32(sdr["TLID"]);
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.TLPC = Convert.ToString(sdr["TLPC"]);
                        child.TLTIME = Convert.ToDateTime(sdr["TLTIME"]).ToString("yyyy-MM-dd HH:mm");
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.WLMS = Convert.ToString(sdr["WLMS"]);
                        child_MES_ZS_SY_TL.Add(child);
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
            rst.MES_ZS_SY_TL = child_MES_ZS_SY_TL;
            return rst;
        }
    }
}

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
    public class TM_WLPZ : ITM_WLPZ
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_SELECT = "MES_TM_WLPZ_SELECT";
        const string SQL_INSERT = "MES_TM_WLPZ_INSERT";
        public MES_TM_WLPZ_SELECT SELECT(MES_TM_WLPZ model)
        {
            MES_TM_WLPZ_SELECT rst = new MES_TM_WLPZ_SELECT();
            List<MES_TM_WLPZ> child_MES_TM_WLPZ = new List<MES_TM_WLPZ>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@TM",model.TM),
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@WLPZND",model.WLPZND),
                                       new SqlParameter("@WLPZBH",model.WLPZBH),
                                       new SqlParameter("@WLPZH",model.WLPZH),
                                       new SqlParameter("@ISKEY",model.ISKEY),
                                       new SqlParameter("@TH",model.TH),
                                       new SqlParameter("@THS",model.THS),
                                       new SqlParameter("@THE",model.THE)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_TM_WLPZ child = new MES_TM_WLPZ();
                        child.TM = Convert.ToString(sdr["TM"]);
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.WLPZND = Convert.ToString(sdr["WLPZND"]);
                        child.WLPZBH = Convert.ToString(sdr["WLPZBH"]);
                        child.WLPZH = Convert.ToString(sdr["WLPZH"]);
                        child.ISKEY = Convert.ToInt32(sdr["ISKEY"]);
                        child.TH = Convert.ToInt32(sdr["TH"]);
                        child.XCZJTM = Convert.ToString(sdr["XCZJTM"]);
                        child.WLPZHXMH = Convert.ToString(sdr["WLPZHXMH"]);
                        child_MES_TM_WLPZ.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "TM_WLPZ");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_TM_WLPZ = child_MES_TM_WLPZ;
            return rst;
        }

        public MES_RETURN INSERT(MES_TM_WLPZ model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@TM",model.TM),
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@WLPZND",model.WLPZND),
                                       new SqlParameter("@WLPZBH",model.WLPZBH),
                                       new SqlParameter("@WLPZH",model.WLPZH),
                                       new SqlParameter("@ISKEY",model.ISKEY),
                                       new SqlParameter("@TH",model.TH),
                                       new SqlParameter("@WLPZHXMH",model.WLPZHXMH)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_TM_WLPZ child = new MES_TM_WLPZ();
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "TM_WLPZ_INSERT");
            }
            return rst;
        }
    }
}

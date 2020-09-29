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
    public class SY_LANGUAGE_YM : ISY_LANGUAGE_YM
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "MES_SY_LANGUAGE_YM_INSERT";
        const string SQL_SELECT = "MES_SY_LANGUAGE_YM_SELECT";
        const string SQL_UPDATE = "MES_SY_LANGUAGE_YM_UPDATE";

        const string SQL_SELECT_TABLEZD = "MES_SY_LANGUAGE_TABLEZD_SELECT";

        const string SQL_SELECT_ZD = "MES_SY_LANGUAGE_ZD_SELECT";
        public MES_RETURN INSERT(MES_SY_LANGUAGE_YM model, int SYLANGUAGEID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@YMAREA",model.YMAREA),
                                       new SqlParameter("@YMCONTROLLER",model.YMCONTROLLER),
                                       new SqlParameter("@YMVIEW",model.YMVIEW),
                                       new SqlParameter("@YMNAME",model.YMNAME),
                                       new SqlParameter("@YMREMARK",model.YMREMARK),
                                       new SqlParameter("@CJRID",model.CJRID),
                                       new SqlParameter("@YMXM",model.YMXM)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_KQ_DEPTKQ_INSERT", "HR");
            }
            return rst;
        }
        public MES_SY_LANGUAGE_TABLEZD_SELECT SELECT_TABLEZD(MES_SY_LANGUAGE_TABLEZD model)
        {
            MES_SY_LANGUAGE_TABLEZD_SELECT rst = new MES_SY_LANGUAGE_TABLEZD_SELECT();
            List<MES_SY_LANGUAGE_TABLEZD> child_MES_SY_LANGUAGE_TABLEZD = new List<MES_SY_LANGUAGE_TABLEZD>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@YMAREA",model.YMAREA),
                                       new SqlParameter("@YMCONTROLLER",model.YMCONTROLLER),
                                       new SqlParameter("@YMVIEW",model.YMVIEW),
                                       new SqlParameter("@TABLEDM",model.TABLEDM),
                                       new SqlParameter("@SYLANGUAGEID",model.SYLANGUAGEID),
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@YMXM",model.YMXM)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_TABLEZD, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_LANGUAGE_TABLEZD child = new MES_SY_LANGUAGE_TABLEZD();
                        child.TABLEZDDM = Convert.ToString(sdr["TABLEZDDM"]);
                        child.TABLEZDNAME = Convert.ToString(sdr["TABLEZDNAME"]);
                        child.TABLENAME = Convert.ToString(sdr["TABLENAME"]);
                        child_MES_SY_LANGUAGE_TABLEZD.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_SY_LANGUAGE_TABLEZD_SELECT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_SY_LANGUAGE_TABLEZD = child_MES_SY_LANGUAGE_TABLEZD;
            return rst;
        }
        public MES_SY_LANGUAGE_ZD_SELECT SELECT_ZD(MES_SY_LANGUAGE_ZD model)
        {
            MES_SY_LANGUAGE_ZD_SELECT rst = new MES_SY_LANGUAGE_ZD_SELECT();
            List<MES_SY_LANGUAGE_ZD> child_MES_SY_LANGUAGE_ZD = new List<MES_SY_LANGUAGE_ZD>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@YMAREA",model.YMAREA),
                                       new SqlParameter("@YMCONTROLLER",model.YMCONTROLLER),
                                       new SqlParameter("@YMVIEW",model.YMVIEW),
                                       new SqlParameter("@SYLANGUAGEID",model.SYLANGUAGEID),
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@YMXM",model.YMXM)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_ZD, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_LANGUAGE_ZD child = new MES_SY_LANGUAGE_ZD();
                        child.ZDID = Convert.ToInt32(sdr["ZDID"]);
                        child.ZDDM = Convert.ToString(sdr["ZDDM"]);
                        child.ZDNAME = Convert.ToString(sdr["ZDNAME"]);
                        child.ZDREMARK = Convert.ToString(sdr["ZDREMARK"]);
                        child_MES_SY_LANGUAGE_ZD.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_SY_LANGUAGE_ZD_SELECT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_SY_LANGUAGE_ZD = child_MES_SY_LANGUAGE_ZD;
            return rst;
        }
    }
}

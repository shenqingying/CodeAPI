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
    class BAT_REPORT : IBAT_REPORT
    {
        const string SQL_MES_DCCYJYBZ_SELECT = "MES_DCCYJYBZ_SELECT";
        const string SQL_MES_TM_TMINFO_SELECT = "MES_TM_GLSELECT_JSREPORT";

        public SELECT_MES_TM_TMINFO_BYTM SELECT_MES_TM_TMINFO(string ERPNO, string XSNOBILL, string XSNOBILLMX)
        {
            SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
            rst.MES_TM_TMINFO_LIST = new List<MES_TM_TMINFO_LIST>();
            rst.MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ERPNO",ERPNO),
                                       new SqlParameter("@NOBILL",XSNOBILL),
                                       new SqlParameter("@NOBILLMX",XSNOBILLMX)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_MES_TM_TMINFO_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_TM_TMINFO_LIST child = new MES_TM_TMINFO_LIST();
                        child.SCDATE = Convert.ToString(sdr["SCDATE"]);
                        child.GZZXMS = Convert.ToString(sdr["GZZXMS"]);
                        child.DCXHMS = Convert.ToString(sdr["DCXHMS"]);
                        child.DCDJMS = Convert.ToString(sdr["DCDJMS"]);
                        child.JSTIME = Convert.ToString(sdr["JSTIME"]);
                        rst.MES_TM_TMINFO_LIST.Add(child);
                    }

                }
                rst.MES_RETURN.TYPE = "S";
                rst.MES_RETURN.MESSAGE = "SELECTED";
            }
            catch (Exception e)
            {
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = e.Message;
                //SY_EXCEPTIONservice.INSERT(e.ToString(), "MM_CK_INSERT");
            }
            return rst;
        }

        public MES_DCCYJYBZ SELECT_DCCYJYBZ(MES_DCCYJYBZ model)
        {
            MES_DCCYJYBZ rst = new MES_DCCYJYBZ();
            rst.MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@SL",model.SL),
                                       new SqlParameter("@BZMC",model.BZMC)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_MES_DCCYJYBZ_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        rst.BZMC = Convert.ToString(sdr["BZMC"]);
                        rst.JYSL = Convert.ToInt32(sdr["JYSL"]);
                        rst.ZXJYS = Convert.ToInt32(sdr["ZXJYS"]);
                    }

                }
                rst.MES_RETURN.TYPE = "S";
                rst.MES_RETURN.MESSAGE = "SELECTED";
            }
            catch (Exception e)
            {
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = e.Message;
                //SY_EXCEPTIONservice.INSERT(e.ToString(), "MM_CK_INSERT");
            }
            return rst;
        }

        public MES_DCCYJYBZ SELECT_DCCYJYBZ_Parms(int SL, string BZMC)
        {
            MES_DCCYJYBZ rst = new MES_DCCYJYBZ();
            rst.MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@SL",SL),
                                       new SqlParameter("@BZMC",BZMC)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_MES_DCCYJYBZ_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        rst.BZMC = Convert.ToString(sdr["BZMC"]);
                        rst.JYSL = Convert.ToInt32(sdr["JYSL"]);
                        rst.ZXJYS = Convert.ToInt32(sdr["ZXJYS"]);
                    }

                }
                rst.MES_RETURN.TYPE = "S";
                rst.MES_RETURN.MESSAGE = "SELECTED";
            }
            catch (Exception e)
            {
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = e.Message;
                //SY_EXCEPTIONservice.INSERT(e.ToString(), "MM_CK_INSERT");
            }
            return rst;
        }
    }
}

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
    public class PD_TL_ERROR : IPD_TL_ERROR
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "MES_PD_TL_ERROR_INSERT";
        const string SQL_SELECT = "MES_PD_TL_ERROR_SELECT";
        public MES_RETURN INSERT(MES_PD_TL_ERROR model)
        {
            MES_RETURN MR = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RWBH",model.RWBH),
                                       new SqlParameter("@TM",model.TM),
                                       new SqlParameter("@JLR",model.JLR),
                                       new SqlParameter("@ERRORINFO",model.ERRORINFO),
                                       new SqlParameter("@TLLB",model.TLLB)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
                {
                }
                MR.TYPE = "S";
                MR.MESSAGE = "";
            }
            catch (Exception e)
            {
                MR.TYPE = "E";
                MR.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_TL_ERROR_INSERT");
            }
            return MR;
        }

        public MES_PD_TL_ERROR_SELECT SELECT(MES_PD_TL_ERROR model)
        {
            MES_PD_TL_ERROR_SELECT rst = new MES_PD_TL_ERROR_SELECT();
            List<MES_PD_TL_ERROR_LIST> child_MES_PD_TL_ERROR_LIST = new List<MES_PD_TL_ERROR_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@SCDATE",model.SCDATE),
                                       new SqlParameter("@WLLB",model.WLLB),
                                       new SqlParameter("@TLLB",model.TLLB),
                                       new SqlParameter("@SCDATES",model.SCDATES),
                                       new SqlParameter("@SCDATEE",model.SCDATEE),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_PD_TL_ERROR_LIST child = new MES_PD_TL_ERROR_LIST();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.GCNAME = Convert.ToString(sdr["GCNAME"]);
                        child.RWBH = Convert.ToString(sdr["RWBH"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.WLMS = Convert.ToString(sdr["WLMS"]);
                        child.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        child.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        child.GZZXNAME = Convert.ToString(sdr["GZZXNAME"]);
                        child.SBNAME = Convert.ToString(sdr["SBNAME"]);
                        child.ZPRQ = Convert.ToString(sdr["ZPRQ"]);
                        child.ERRORTM = Convert.ToString(sdr["ERRORTM"]);
                        child.ERRORWLH = Convert.ToString(sdr["ERRORWLH"]);
                        child.ERRORWLNAME = Convert.ToString(sdr["ERRORWLNAME"]);
                        child.ERRORINFO = Convert.ToString(sdr["ERRORINFO"]);
                        child.ERRORPC = Convert.ToString(sdr["ERRORPC"]);
                        child.ERRORJLSJ = Convert.ToDateTime(sdr["ERRORJLSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.ERRORJLR = Convert.ToString(sdr["ERRORJLR"]);
                        child.TLLB = Convert.ToInt32(sdr["TLLB"]);
                        child_MES_PD_TL_ERROR_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";

            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_TL");
            }
            rst.MES_PD_TL_ERROR_LIST = child_MES_PD_TL_ERROR_LIST;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
    }
}

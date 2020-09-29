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
    public class TM_GL : ITM_GL
    {
        string SQL_INSERT = "MES_TM_GL_INSERT";
        const string SQL_DELETE = "DELETE FROM MES_TM_GL WHERE SCTM=@SCTM";
        const string SQL_SELECT = "MES_TM_GL_SELECT";
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        public MES_RETURN INSERT(List<MES_TM_GL> model)
        {
            MES_RETURN mr = new MES_RETURN();
            try
            {
                if (model.Count > 0)
                {
                    for (int i = 0; i < model.Count; i++)
                    {
                        SqlParameter[] parms = {
                                       new SqlParameter("@SCTMGC",model[i].SCTMGC),
                                       new SqlParameter("@SCTM",model[i].SCTM),
                                       new SqlParameter("@XCTMGC",model[i].XCTMGC),
                                       new SqlParameter("@XCTM",model[i].XCTM),
                                       new SqlParameter("@SDDCQKID",model[i].SDDCQKID),
                                       new SqlParameter("@FZDHLB",model[i].FZDHLB),
                                       new SqlParameter("@FZDH",model[i].FZDH),
                                       new SqlParameter("@SL",model[i].SL),
                                       new SqlParameter("@BZ",model[i].BZ),
                                       new SqlParameter("@GLLB",model[i].GLLB)
                                   };

                        using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms)) { }
                    }
                }
                mr.TYPE = "S";
                mr.MESSAGE = "";
            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "TM_GL_INSERT");
            }
            return mr;
        }

        public MES_RETURN DELETE_BY_SCTM(string SCTM)
        {
            MES_RETURN mr = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@SCTM",SCTM)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_DELETE, parms)) { }

                mr.TYPE = "S";
                mr.MESSAGE = "";
            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "TM_GL_DELETE_BY_SCTM");
            }
            return mr;
        }
        public MES_TM_GL_SELECT SELECT(MES_TM_GL model)
        {
            MES_TM_GL_SELECT rst = new MES_TM_GL_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_TM_GL> child_MES_TM_GL = new List<MES_TM_GL>();
            string czr = "";
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@XCTM",model.XCTM),
                                       new SqlParameter("@SCTM",model.SCTM)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_TM_GL child = new MES_TM_GL();
                        child.ID = Convert.ToInt32(sdr["ID"]);
                        child.SCTMGC = Convert.ToString(sdr["SCTMGC"]);
                        child.SCTM = Convert.ToString(sdr["SCTM"]);
                        child.XCTMGC = Convert.ToString(sdr["XCTMGC"]);
                        child.XCTM = Convert.ToString(sdr["XCTM"]);
                        child.SCTMRESDUESL = Convert.ToDecimal(sdr["SCTMRESDUESL"]);
                        child_MES_TM_GL.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_TM_GL = child_MES_TM_GL;
            return rst;
        }
    }
}

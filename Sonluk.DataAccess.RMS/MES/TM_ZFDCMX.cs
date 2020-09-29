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
    public class TM_ZFDCMX : ITM_ZFDCMX
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "INSERT MES_TM_ZFDCMX(TM,KSTIME,JSTIME,SL) VALUES(@TM,@KSTIME,@JSTIME,@SL)";
        const string SQL_SELECT = "SELECT * FROM MES_TM_ZFDCMX WHERE TM=@TM";
        const string SQL_DELETE = "MES_TM_ZFDCMX_DELETE";
        public MES_RETURN INSERT(MES_TM_ZFDCMX model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@TM",model.TM),
                                       new SqlParameter("@KSTIME",model.KSTIME),
                                       new SqlParameter("@JSTIME",model.JSTIME),
                                       new SqlParameter("@SL",model.SL)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_INSERT, parms))
                {
                }
                rst.TYPE = "S";
                rst.MESSAGE = "";
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "TM_ZFDCMX");
            }
            return rst;
        }

        public MES_TM_ZFDCMX_SELECT SELECT(string TM)
        {
            MES_TM_ZFDCMX_SELECT rst = new MES_TM_ZFDCMX_SELECT();
            List<MES_TM_ZFDCMX> child_MES_TM_ZFDCMX = new List<MES_TM_ZFDCMX>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@TM",TM)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_TM_ZFDCMX child = new MES_TM_ZFDCMX();
                        child.TM = Convert.ToString(sdr["TM"]);
                        child.ID = Convert.ToInt32(sdr["ID"]);
                        child.KSTIME = Convert.ToDateTime(sdr["KSTIME"]).ToString("yyyy-MM-dd");
                        child.JSTIME = Convert.ToDateTime(sdr["JSTIME"]).ToString("yyyy-MM-dd");
                        child.SL = Convert.ToInt32(sdr["SL"]);
                        child_MES_TM_ZFDCMX.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "TM_ZFDCMX");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_TM_ZFDCMX = child_MES_TM_ZFDCMX;
            return rst;
        }

        public MES_RETURN DELETE(MES_TM_ZFDCMX model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@TM",model.TM),
                                       new SqlParameter("@ID",model.ID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DELETE, parms))
                {
                }
                rst.TYPE = "S";
                rst.MESSAGE = "";
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "TM_ZFDCMX");
            }
            return rst;
        }
    }
}

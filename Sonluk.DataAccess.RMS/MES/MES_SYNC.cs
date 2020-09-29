using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.MES
{
    public class MES_SYNC : IMES_SYNC
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        public void HR_KQ_KQINFO_AUTO_SYNC()
        {
            try
            {
                SqlParameter[] parms = {
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, "HR_KQ_KQINFO_AUTO_SYNC", parms)) { }
                //mr.TYPE = "S";
                //mr.MESSAGE = "";
            }
            catch (Exception e)
            {
                SY_EXCEPTIONservice.INSERT(e.ToString(), "HR_KQ_KQINFO_AUTO_SYNC");
            }
        }
        public void HR_KQ_GSKQ_AUTO_INSERT()
        {
            try
            {
                SqlParameter[] parms = {
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, "HR_KQ_GSKQ_AUTO_INSERT", parms)) { }
                //mr.TYPE = "S";
                //mr.MESSAGE = "";
            }
            catch (Exception e)
            {
                SY_EXCEPTIONservice.INSERT(e.ToString(), "HR_KQ_GSKQ_AUTO_INSERT");
            }
        }
        public void HR_KQ_DEPTKQ_AUTO_INSERT()
        {
            try
            {
                SqlParameter[] parms = {
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, "HR_KQ_DEPTKQ_AUTO_INSERT", parms)) { }
                //mr.TYPE = "S";
                //mr.MESSAGE = "";
            }
            catch (Exception e)
            {
                SY_EXCEPTIONservice.INSERT(e.ToString(), "HR_KQ_DEPTKQ_AUTO_INSERT");
            }
        }
    }
}

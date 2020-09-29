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
    public class MES_ROLE : IMES_ROLE
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_SELECT_GYS = "MES_ROLE_GYS_SELECT";

        public MES_ROLE_GYS_SELECT SELECT_GYS(MES_ROLE_GYS model)
        {
            MES_ROLE_GYS_SELECT rst = new MES_ROLE_GYS_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_ROLE_GYS> child_MES_ROLE_GYS = new List<MES_ROLE_GYS>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_GYS, parms))
                {
                    while (sdr.Read())
                    {
                        MES_ROLE_GYS child = new MES_ROLE_GYS();
                        child.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.GYS = Convert.ToString(sdr["GYS"]);
                        child_MES_ROLE_GYS.Add(child);
                    }
                    child_MES_RETURN.TYPE = "S";
                    child_MES_RETURN.MESSAGE = "";
                }
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_ROLE_GYS_SELECT", "MES");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_ROLE_GYS = child_MES_ROLE_GYS;
            return rst;
        }
    }
}

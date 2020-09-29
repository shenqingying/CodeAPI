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
    public class SY_YERACOUNT : ISY_YERACOUNT
    {
        string SQL_SELECT = "MES_SY_YERACOUNT_SELECT";
        static object _object = new object();
        public string SELECT(MES_SY_YERACOUNT model)
        {
            string rst = "";
            SqlParameter[] parms = { 
                                       new SqlParameter("@TMLB",model.TMLB),
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@YEAR",model.TMYEAR)
                                   };
            try
            {
                lock (_object)
                {
                    using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                    {
                        while (sdr.Read())
                        {
                            rst = Convert.ToString(sdr["MNUMBER"]);
                        }
                    }
                    return rst;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }
    }
}

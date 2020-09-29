using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.MES
{
    public class PUBLIC_FUNC : IPUBLIC_FUNC
    {
        const string SQL_SELECT_TIME = "SELECT GETDATE() AS TIME";
        public string GET_TIME()
        {
            string rst = "";
            try
            {
                SqlParameter[] parms = {
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT_TIME, parms))
                {
                    while (sdr.Read())
                    {
                        rst = (Convert.ToDateTime(sdr["TIME"])).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                }
                return rst;

            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }
        public DateTime GET_DateTime()
        {
            DateTime dtime = new DateTime();
            try
            {
                SqlParameter[] parms = {
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT_TIME, parms))
                {
                    while (sdr.Read())
                    {
                        dtime = Convert.ToDateTime(sdr["TIME"]);
                    }
                }
            }
            catch (Exception e)
            {
                dtime = DateTime.Now;
            }
            return dtime;
        }
    }
}

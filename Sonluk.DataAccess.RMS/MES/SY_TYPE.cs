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
    public class SY_TYPE : ISY_TYPE
    {
        string SQL_SELECT = "MES_SY_TYPE_SELECT";
        public IList<MES_SY_TYPE> SELECT()
        {
            IList<MES_SY_TYPE> rst = new List<MES_SY_TYPE>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT))
                {
                    while (sdr.Read())
                    {
                        MES_SY_TYPE child = new MES_SY_TYPE();
                        child.TYPEID = Convert.ToInt32(sdr["TYPEID"]);
                        child.TYPENAME = Convert.ToString(sdr["TYPENAME"]);
                        child.TYPEMS = Convert.ToString(sdr["TYPEMS"]);
                        child.ISDELETE = Convert.ToBoolean(sdr["ISDELETE"]);
                        child.ISYXWH = Convert.ToBoolean(sdr["ISYXWH"]);
                        rst.Add(child);
                    }
                }
                return rst;
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }
    }
}

using Sonluk.DataAccess.RMS.MES;
using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.HR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.HR
{
    public class SY_TYPE : ISY_TYPE
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_SELECT = "SELECT * FROM HR_SY_TYPE";
        public HR_SY_TYPE_SELECT SELECT()
        {
            HR_SY_TYPE_SELECT rst = new HR_SY_TYPE_SELECT();
            List<HR_SY_TYPE> child_HR_SY_TYPE = new List<HR_SY_TYPE>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        HR_SY_TYPE child = new HR_SY_TYPE();
                        child.TYPEID = Convert.ToInt32(sdr["TYPEID"]);
                        child.TYPENAME = Convert.ToString(sdr["TYPENAME"]);
                        child.TYPEMS = Convert.ToString(sdr["TYPEMS"]);
                        child.ISDELETE = Convert.ToInt32(sdr["ISDELETE"]);
                        child.ISYXWH = Convert.ToInt32(sdr["ISYXWH"]);
                        child.ISALL = Convert.ToInt32(sdr["ISALL"]);
                        child_HR_SY_TYPE.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_SY_TYPE_SELECT", "HR");
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            rst.HR_SY_TYPE = child_HR_SY_TYPE;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
    }
}

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
    public class SY_CHANGEINFO : ISY_CHANGEINFO
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_SELECT = "HR_SY_CHANGEINFO_SELECT";
        public HR_SY_CHANGEINFO_SELECT SELECT(HR_SY_CHANGEINFO model)
        {
            HR_SY_CHANGEINFO_SELECT rst = new HR_SY_CHANGEINFO_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                           new SqlParameter("@CHANGETIMEKS",model.CHANGETIMEKS),
                                           new SqlParameter("@CHANGETIMEJS",model.CHANGETIMEJS),
                                           new SqlParameter("@CHANGESY",model.CHANGESY),
                                           new SqlParameter("@CHANGETABLE",model.CHANGETABLE)
                                   };
                rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_SELECT, paras);
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_SY_CHANGEINFO_SELECT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
    }
}

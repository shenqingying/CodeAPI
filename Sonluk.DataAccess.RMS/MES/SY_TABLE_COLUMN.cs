using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.MES
{
    public class SY_TABLE_COLUMN
    {
        SY_EXCEPTION SY_EXCEPTIONService = new SY_EXCEPTION();
        SY_CHANGEINFO SY_CHANGEINFOService = new SY_CHANGEINFO();
        const string SQL_SELECT = "MES_SY_TABLE_COLUMN_SELECT";
        public MES_SY_TABLE_COLUMN_SELECT SELECT(MES_SY_TABLE_COLUMN model)
        {
            MES_SY_TABLE_COLUMN_SELECT rst = new MES_SY_TABLE_COLUMN_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                           new SqlParameter("@SY",model.SY),
                                           new SqlParameter("@SY_TABLE",model.SY_TABLE),
                                           new SqlParameter("@ZJVALUES",model.ZJVALUES)
                                   };
                rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_SELECT, paras);
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONService.INSERT_SY(e.ToString(), "MES_SY_TABLE_COLUMN_SELECT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN INSERT_CHANGEINFO(DataTable dtold, DataTable dtnew, MES_SY_TABLE_COLUMN model)
        {
            MES_RETURN rst = new MES_RETURN();
            if (dtold.Columns.Count == dtnew.Columns.Count)
            {
                for (int a = 0; a < dtold.Columns.Count; a++)
                {
                    if (dtold.Rows[0][a].ToString() != dtnew.Rows[0][a].ToString())
                    {
                        MES_SY_CHANGEINFO model_MES_SY_CHANGEINFO = new MES_SY_CHANGEINFO();
                        model_MES_SY_CHANGEINFO.CHANGGELB = 0;
                        model_MES_SY_CHANGEINFO.CHANGGEDJ = model.ZJVALUES;
                        model_MES_SY_CHANGEINFO.CHANGETABLE = model.SY_TABLE;
                        model_MES_SY_CHANGEINFO.CHANGEZD = dtold.Columns[a].ColumnName;
                        model_MES_SY_CHANGEINFO.OLDINFO = dtold.Rows[0][a].ToString();
                        model_MES_SY_CHANGEINFO.NEWINFO = dtnew.Rows[0][a].ToString();
                        model_MES_SY_CHANGEINFO.CHANGEPEOPLE = model.STAFFID;
                        model_MES_SY_CHANGEINFO.CHANGESY = model.SY;
                        rst = SY_CHANGEINFOService.INSERT(model_MES_SY_CHANGEINFO);
                        if (rst.TYPE == "E")
                        {
                            return rst;
                        }
                    }
                }
            }
            else
            {
                rst.TYPE = "E";
                rst.MESSAGE = "字段异常请重新更改尝试！";
            }
            return rst;
        }
    }
}

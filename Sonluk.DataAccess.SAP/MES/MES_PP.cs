using SAP.Middleware.Connector;
using Sonluk.DataAccess.SAP.Utility;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.SAP.MES
{
    public class MES_PP : IMES_PP
    {
        public SELECT_MES_PD_SCRW GET_ZBCFUN_GDBGS_READ(List<MES_PD_SCRW_LIST> model)
        {
            SELECT_MES_PD_SCRW rst = new SELECT_MES_PD_SCRW();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_PD_SCRW_LIST> child_MES_PD_SCRW_LIST = new List<MES_PD_SCRW_LIST>();
            IRfcFunction func = RFC.Function("ZBCFUN_GDBGS_READ");
            IRfcTable table_IT_GDXX = func.GetTable("IT_GDXX");
            for (int i = 0; i < model.Count; i++)
            {
                table_IT_GDXX.Insert();
                table_IT_GDXX.CurrentRow.SetValue("AUFNR", model[i].ERPNO);
                table_IT_GDXX.CurrentRow.SetValue("MATNR", model[i].XFWLH);
                table_IT_GDXX.CurrentRow.SetValue("CHARG", model[i].XFPC);
            }
            func.SetValue("IT_GDXX", table_IT_GDXX);
            try
            {
                RFC.Invoke(func, false);

                IRfcTable table_CT_RETURN = func.GetTable("CT_RETURN");
                if (table_CT_RETURN.RowCount > 0)
                {
                    table_CT_RETURN.CurrentIndex = 0;
                    child_MES_RETURN.TYPE = table_CT_RETURN.GetString("TYPE");
                    child_MES_RETURN.MESSAGE = table_CT_RETURN.GetString("MESSAGE");
                }
                IRfcTable table_ET_GDXX = func.GetTable("ET_GDXX");
                for (int i = 0; i < table_ET_GDXX.RowCount; i++)
                {
                    table_ET_GDXX.CurrentIndex = i;
                    for (int j = 0; j < model.Count; j++)
                    {
                        if (ZHMUN(table_ET_GDXX.GetString("AUFNR")) == model[j].ERPNO && ZHMUN(table_ET_GDXX.GetString("MATNR")) == model[j].XFWLH && table_ET_GDXX.GetString("CHARG") == model[j].XFPC)
                        {
                            model[j].BGSL = Convert.ToInt32(Convert.ToDouble(table_ET_GDXX.GetString("PSMNG")));
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_PD_SCRW_LIST = model;
            return rst;
        }

        public string ZHMUN(string str)
        {
            if (str != "")
            {
                str = Convert.ToInt64(Convert.ToDouble(str)).ToString();
                if (str == "0")
                {
                    str = "";
                }
            }
            return str;
        }
    }
}

using SAP.Middleware.Connector;
using Sonluk.DataAccess.SAP.Utility;
using Sonluk.Entities.BC;
using Sonluk.Entities.MES;
using Sonluk.Entities.SD;
using Sonluk.IDataAccess.SD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.SAP.SD
{
    public class CLIENTINFO : ICLIENTINFO
    {
        public ZBCFUN_KHXX_READ_RETURN ZBCFUN_KHXX_READ(ZSL_BCS111 IS_HEADDATA)
        {
            ZBCFUN_KHXX_READ_RETURN rst = new ZBCFUN_KHXX_READ_RETURN();
            List<ZSL_BCS111> child_ET_CUSTDATA = new List<ZSL_BCS111>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                IRfcFunction func = RFC.Function("ZBCFUN_KHXX_READ");

                IRfcStructure irfcstruc_IS_CUSTDATA = func.GetStructure("IS_CUSTDATA");
                irfcstruc_IS_CUSTDATA.SetValue("KUNNR", IS_HEADDATA.KUNNR);
                func.SetValue("IS_CUSTDATA", irfcstruc_IS_CUSTDATA);

                RFC.Invoke(func, true);

                IRfcTable tb_ET_CUSTDATA = func.GetTable("ET_CUSTDATA");
                for (int i = 0; i < tb_ET_CUSTDATA.RowCount; i++)
                {
                    tb_ET_CUSTDATA.CurrentIndex = i;
                    ZSL_BCS111 child = new ZSL_BCS111();
                    child.KUNNR = tb_ET_CUSTDATA.GetString("KUNNR");
                    child.NAME1 = tb_ET_CUSTDATA.GetString("NAME1");
                    child_ET_CUSTDATA.Add(child);
                }

                IRfcTable tb_CT_RETURN = func.GetTable("CT_RETURN");
                tb_CT_RETURN.CurrentIndex = 0;
                child_MES_RETURN.TYPE = tb_CT_RETURN.GetString("TYPE");
                child_MES_RETURN.MESSAGE = tb_CT_RETURN.GetString("MESSAGE");

                rst.MES_RETURN = child_MES_RETURN;
                rst.ET_CUSTDATA = child_ET_CUSTDATA;

            }
            catch (Exception e)
            {

                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
            }
            return rst;
        }
    }
}

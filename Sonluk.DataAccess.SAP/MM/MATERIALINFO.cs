using SAP.Middleware.Connector;
using Sonluk.DataAccess.SAP.Utility;
using Sonluk.Entities.BC;
using Sonluk.Entities.MES;
using Sonluk.Entities.MM;
using Sonluk.IDataAccess.MM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.SAP.MM
{
    public class MATERIALINFO : IMATERIALINFO
    {
        public ZBCFUN_MMINFO_READ_RETURN ZBCFUN_MMINFO_READ(ZSL_BCS112 IS_MATDATA)
        {
            ZBCFUN_MMINFO_READ_RETURN rst = new ZBCFUN_MMINFO_READ_RETURN();
            List<ZSL_BCS112> child_ET_MATDATA_H = new List<ZSL_BCS112>();
            List<ZSL_BCS112> child_ET_MATDATA_I = new List<ZSL_BCS112>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                IRfcFunction func = RFC.Function("ZBCFUN_MMINFO_READ");

                IRfcStructure irfcstruc_IS_MATDATA = func.GetStructure("IS_MATDATA");
                irfcstruc_IS_MATDATA.SetValue("MATNR", IS_MATDATA.MATNR);
                func.SetValue("IS_MATDATA", irfcstruc_IS_MATDATA);

                RFC.Invoke(func, true);

                IRfcTable tb_ET_MATDATA_H = func.GetTable("ET_MATDATA_H");
                for (int i = 0; i < tb_ET_MATDATA_H.RowCount; i++)
                {
                    tb_ET_MATDATA_H.CurrentIndex = i;
                    ZSL_BCS112 child = new ZSL_BCS112();
                    child.MATNR = tb_ET_MATDATA_H.GetString("MATNR");
                    child.MAKTX = tb_ET_MATDATA_H.GetString("MAKTX");
                    child_ET_MATDATA_H.Add(child);
                }

                IRfcTable tb_ET_MATDATA_I = func.GetTable("ET_MATDATA_I");
                for (int i = 0; i < tb_ET_MATDATA_I.RowCount; i++)
                {
                    tb_ET_MATDATA_I.CurrentIndex = i;
                    ZSL_BCS112 child = new ZSL_BCS112();
                    child.MATNR = tb_ET_MATDATA_I.GetString("MATNR");
                    child.MAKTX = tb_ET_MATDATA_I.GetString("MAKTX");
                    child_ET_MATDATA_I.Add(child);
                }

                IRfcTable tb_CT_RETURN = func.GetTable("CT_RETURN");
                tb_CT_RETURN.CurrentIndex = 0;
                child_MES_RETURN.TYPE = tb_CT_RETURN.GetString("TYPE");
                child_MES_RETURN.MESSAGE = tb_CT_RETURN.GetString("MESSAGE");

                rst.MES_RETURN = child_MES_RETURN;
                rst.ET_MATDATA_H = child_ET_MATDATA_H;
                rst.ET_MATDATA_I = child_ET_MATDATA_I;

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

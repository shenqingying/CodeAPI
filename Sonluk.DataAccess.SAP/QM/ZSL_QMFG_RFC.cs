using SAP.Middleware.Connector;
using Sonluk.DataAccess.SAP.Utility;
using Sonluk.Entities.MES;
using Sonluk.Entities.QM;
using Sonluk.Entities.SAP;
using Sonluk.IDataAccess.QM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.SAP.QM
{
    public class ZSL_QMFG_RFC : IZSL_QMFG_RFC
    {
        public ZSL_QMFM_012_SELECT ZSL_QMFM_012(ZSL_QMFM_012_SELECT model)
        {
            model.IS_DATE_LOW = model.IS_DATE_LOW.Replace("-", "");
            model.IS_DATE_HIGH = model.IS_DATE_HIGH.Replace("-", "");
            model.IS_TJDATE_LOW = model.IS_TJDATE_LOW.Replace("-", "");
            model.IS_TJDATE_HIGH = model.IS_TJDATE_HIGH.Replace("-", "");
            ZSL_QMFM_012_SELECT rst = new ZSL_QMFM_012_SELECT();
            List<ZSL_QMS012> child_ET_YHINFO = new List<ZSL_QMS012>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            IRfcFunction func = RFC.Function("ZSL_QMFM_012");
            func.SetValue("IV_YHNO", model.IV_YHNO);
            func.SetValue("IV_VBELN", model.IV_VBELN);
            func.SetValue("IV_BOX", model.IV_BOX);
            if (model.IS_DATE_LOW != "" && model.IS_DATE_HIGH != "")
            {
                IRfcStructure irfcstruc = func.GetStructure("IS_DATE");
                irfcstruc.SetValue("SIGN", "I");
                irfcstruc.SetValue("OPTION", "BT");
                irfcstruc.SetValue("LOW", model.IS_DATE_LOW);
                irfcstruc.SetValue("HIGH", model.IS_DATE_HIGH);
                func.SetValue("IS_DATE", irfcstruc);
            }
            else
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "验货日期不允许为空！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
            if (model.IS_TJDATE_LOW != "" && model.IS_TJDATE_HIGH != "")
            {
                IRfcStructure irfcstruc = func.GetStructure("IS_TJDATE");
                irfcstruc.SetValue("SIGN", "I");
                irfcstruc.SetValue("OPTION", "BT");
                irfcstruc.SetValue("LOW", model.IS_TJDATE_LOW);
                irfcstruc.SetValue("HIGH", model.IS_TJDATE_HIGH);
                func.SetValue("IS_TJDATE", irfcstruc);
            }
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("ET_YHINFO");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    ZSL_QMS012 child = new ZSL_QMS012();
                    child.STATUS = table.GetString("STATUS");
                    child.YHNO = table.GetString("YHNO");
                    child.ZFYDAT = table.GetString("ZFYDAT");
                    child.ZLYDAT = table.GetString("ZLYDAT");
                    child.ZNAME = table.GetString("ZNAME");
                    child.FLAG = table.GetString("FLAG");
                    child.NAME = table.GetString("NAME");
                    child.ZTEXT = table.GetString("ZTEXT");
                    child.ERDAT1 = table.GetString("ERDAT1");
                    child.ERNAM = table.GetString("ERNAM");
                    child.KUNNR = table.GetString("KUNNR");
                    child.ERZET1 = table.GetString("ERZET1");
                    child.ZTEXT3 = table.GetString("ZTEXT3");
                    child.ZTEXT4 = table.GetString("ZTEXT4");
                    child.FLAG2 = table.GetString("FLAG2");
                    child.ITEM = table.GetString("ITEM");
                    child.VBELN = table.GetString("VBELN");
                    child.POSNR = table.GetString("POSNR");
                    child.CYNO = table.GetString("CYNO");
                    child.MATNR = table.GetString("MATNR");
                    child.KWMENG = table.GetString("KWMENG");
                    child.VRKME = table.GetString("VRKME");
                    child.ZZCAT = table.GetString("ZZCAT");
                    child.ZZUNT = table.GetString("ZZUNT");
                    child.ZBQTY = table.GetString("ZBQTY");
                    child.ZZUNT1 = table.GetString("ZZUNT1");
                    child.ZTEXT1 = table.GetString("ZTEXT1");
                    child.ZTEXT2 = table.GetString("ZTEXT2");
                    child.BSTKD = table.GetString("BSTKD");
                    child.LABOR = table.GetString("LABOR");
                    child.MVGR4 = table.GetString("MVGR4");
                    child.MVGR1 = table.GetString("MVGR1");
                    child.MVGR2 = table.GetString("MVGR2");
                    child.LBTXT = table.GetString("LBTXT");
                    child.ZWG = table.GetString("ZWG");
                    child.ZSEC = table.GetString("ZSEC");
                    child.ZDL = table.GetString("ZDL");
                    child.ZDUANL = table.GetString("ZDUANL");
                    child.ZSZYF = table.GetString("ZSZYF");
                    child.ZDXN = table.GetString("ZDXN");
                    child.MAKTX = table.GetString("MAKTX");
                    child.MVGR1T = table.GetString("MVGR1T");
                    child.MVGR2T = table.GetString("MVGR2T");
                    child.MVGR4T = table.GetString("MVGR4T");
                    child.NAME1 = table.GetString("NAME1");
                    child.NAME2 = table.GetString("NAME2");
                    child.AUFNR = table.GetString("AUFNR");
                    child.KTEXT = table.GetString("KTEXT");
                    child.GLTRP = table.GetString("GLTRP");
                    child.KALAB = table.GetString("KALAB");
                    child.WERKS = table.GetString("WERKS");
                    child.LIFNR_PO = table.GetString("LIFNR_PO");
                    child.I1 = table.GetString("I1");
                    child.I2 = table.GetString("I2");
                    child.LGPLA = table.GetString("LGPLA");
                    child.GESME = table.GetString("GESME");
                    child.SONUM = table.GetString("SONUM");
                    child.LGPLA2 = table.GetString("LGPLA2");
                    child.GESME2 = table.GetString("GESME2");
                    child.I3 = table.GetString("I3");
                    child.ARKTX = table.GetString("ARKTX");
                    child.ARBPL = table.GetString("ARBPL");
                    child_ET_YHINFO.Add(child);
                }

                rst.ET_YHINFO = child_ET_YHINFO;
                IRfcTable table_MES_RETURN = func.GetTable("CT_RETURN");
                table_MES_RETURN.CurrentIndex = 0;
                child_MES_RETURN.TYPE = table_MES_RETURN.GetString("TYPE");
                child_MES_RETURN.MESSAGE = table_MES_RETURN.GetString("MESSAGE");
                rst.MES_RETURN = child_MES_RETURN;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
    }
}

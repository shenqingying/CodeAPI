using SAP.Middleware.Connector;
using Sonluk.DataAccess.SAP.Utility;
using Sonluk.Entities.BC;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.BC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.SAP.BC
{
    public class DRF : IDRF
    {
        public ZBCFUN_DRFDD_CRT_RETURN ZBCFUN_DRFDD_CRT(ZSL_BCS111 IS_HEADDATA, List<ZSL_BCS112> IT_ITEMDATA)
        {
            ZBCFUN_DRFDD_CRT_RETURN rst = new ZBCFUN_DRFDD_CRT_RETURN();
            ZSL_BCS113 child_ES_ORDERDATA = new ZSL_BCS113();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                IRfcFunction func = RFC.Function("ZBCFUN_DRFDD_CRT");

                IRfcStructure irfcstruc_IS_HEADDATA = func.GetStructure("IS_HEADDATA");
                irfcstruc_IS_HEADDATA.SetValue("AUART", IS_HEADDATA.AUART);
                irfcstruc_IS_HEADDATA.SetValue("KUNAG", IS_HEADDATA.KUNAG);
                irfcstruc_IS_HEADDATA.SetValue("KUNNR", IS_HEADDATA.KUNNR);
                irfcstruc_IS_HEADDATA.SetValue("BSTNK", IS_HEADDATA.BSTNK);
                irfcstruc_IS_HEADDATA.SetValue("BSTDK", IS_HEADDATA.BSTDK);
                irfcstruc_IS_HEADDATA.SetValue("VKORG", IS_HEADDATA.VKORG);
                irfcstruc_IS_HEADDATA.SetValue("VTWEG", IS_HEADDATA.VTWEG);
                irfcstruc_IS_HEADDATA.SetValue("SPART", IS_HEADDATA.SPART);
                irfcstruc_IS_HEADDATA.SetValue("ORDERST", IS_HEADDATA.ORDERST);
                irfcstruc_IS_HEADDATA.SetValue("PO_METHOD", IS_HEADDATA.PO_METHOD);
                irfcstruc_IS_HEADDATA.SetValue("VBTYP", IS_HEADDATA.VBTYP);
                func.SetValue("IS_HEADDATA", irfcstruc_IS_HEADDATA);

                IRfcTable i_table_IT_ITEMDATA = func.GetTable("IT_ITEMDATA");
                for (int i = 0; i < IT_ITEMDATA.Count; i++)
                {
                    i_table_IT_ITEMDATA.Append();
                    i_table_IT_ITEMDATA.SetValue("POSNR", IT_ITEMDATA[i].POSNR);
                    i_table_IT_ITEMDATA.SetValue("MATNR", IT_ITEMDATA[i].MATNR);
                    i_table_IT_ITEMDATA.SetValue("KWMENG", IT_ITEMDATA[i].KWMENG);
                    i_table_IT_ITEMDATA.SetValue("VRKME", IT_ITEMDATA[i].VRKME);
                    i_table_IT_ITEMDATA.SetValue("PSTYV", IT_ITEMDATA[i].PSTYV);
                    i_table_IT_ITEMDATA.SetValue("LGORT", IT_ITEMDATA[i].LGORT);
                    i_table_IT_ITEMDATA.SetValue("FOC", IT_ITEMDATA[i].FOC);
                }
                func.SetValue("IT_ITEMDATA", i_table_IT_ITEMDATA);

                RFC.Invoke(func, true);

                IRfcStructure irfcstruc_ES_ORDERDATA = func.GetStructure("ES_ORDERDATA");
                child_ES_ORDERDATA.VBELN = irfcstruc_ES_ORDERDATA.GetString("VBELN");
                child_ES_ORDERDATA.VBELN_VL = irfcstruc_ES_ORDERDATA.GetString("VBELN_VL");
                child_ES_ORDERDATA.ERDAT = irfcstruc_ES_ORDERDATA.GetString("ERDAT") + " " + irfcstruc_ES_ORDERDATA.GetString("ERZET");

                IRfcTable tb_CT_RETURN = func.GetTable("CT_RETURN");
                tb_CT_RETURN.CurrentIndex = 0;
                child_MES_RETURN.TYPE = tb_CT_RETURN.GetString("TYPE");
                child_MES_RETURN.MESSAGE = tb_CT_RETURN.GetString("MESSAGE");

                rst.MES_RETURN = child_MES_RETURN;
                rst.ES_ORDERDATA = child_ES_ORDERDATA;

            }
            catch (Exception e)
            {

                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
            }
            return rst;
        }
        public MES_RETURN ZBCFUN_DRFDD_CHK(ZSL_BCS111 IS_HEADDATA)
        {
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                IRfcFunction func = RFC.Function("ZBCFUN_DRFDD_CHK");

                IRfcStructure irfcstruc_IS_HEADDATA = func.GetStructure("IS_HEADDATA");
                irfcstruc_IS_HEADDATA.SetValue("KUNAG", IS_HEADDATA.KUNAG);
                irfcstruc_IS_HEADDATA.SetValue("BSTNK", IS_HEADDATA.BSTNK);
                func.SetValue("IS_HEADDATA", irfcstruc_IS_HEADDATA);

                RFC.Invoke(func, true);

                IRfcTable tb_CT_RETURN = func.GetTable("CT_RETURN");
                tb_CT_RETURN.CurrentIndex = 0;
                child_MES_RETURN.TYPE = tb_CT_RETURN.GetString("TYPE");
                child_MES_RETURN.MESSAGE = tb_CT_RETURN.GetString("MESSAGE");
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            return child_MES_RETURN;
        }
        public ZBCFUN_DRFDD_DT_RETURN ZBCFUN_DRFDD_DT(List<ZSL_BCS113> IT_ORDERDATA)
        {
            ZBCFUN_DRFDD_DT_RETURN rst = new ZBCFUN_DRFDD_DT_RETURN();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<ZSL_BCS113> child_ET_ORDERDATA = new List<ZSL_BCS113>();
            try
            {
                IRfcFunction func = RFC.Function("ZBCFUN_DRFDD_DT");

                IRfcTable table_IT_ORDERDATA = func.GetTable("IT_ORDERDATA");
                for (int i = 0; i < IT_ORDERDATA.Count; i++)
                {
                    table_IT_ORDERDATA.Append();
                    table_IT_ORDERDATA.SetValue("VBELN", IT_ORDERDATA[i].VBELN);
                }
                func.SetValue("IT_ORDERDATA", table_IT_ORDERDATA);

                RFC.Invoke(func, true);

                IRfcTable tb_CT_RETURN = func.GetTable("CT_RETURN");
                tb_CT_RETURN.CurrentIndex = 0;
                child_MES_RETURN.TYPE = tb_CT_RETURN.GetString("TYPE");
                child_MES_RETURN.MESSAGE = tb_CT_RETURN.GetString("MESSAGE");

                IRfcTable table_ET_ORDERDATA = func.GetTable("ET_ORDERDATA");
                for (int i = 0; i < table_ET_ORDERDATA.RowCount; i++)
                {
                    table_ET_ORDERDATA.CurrentIndex = i;
                    ZSL_BCS113 child = new ZSL_BCS113();
                    child.VBELN = table_ET_ORDERDATA.GetString("VBELN");
                    child.POSNR = table_ET_ORDERDATA.GetString("POSNR");
                    child.VBELN_VL = table_ET_ORDERDATA.GetString("VBELN_VL");
                    child.POSNR_VL = table_ET_ORDERDATA.GetString("POSNR_VL");
                    child.MATNR = table_ET_ORDERDATA.GetString("MATNR");
                    child.ARKTX = table_ET_ORDERDATA.GetString("ARKTX");
                    child.LFIMG = table_ET_ORDERDATA.GetString("LFIMG");
                    child.VRKME = table_ET_ORDERDATA.GetString("VRKME");
                    child.LGMNG = table_ET_ORDERDATA.GetString("LGMNG");
                    child.MEINS = table_ET_ORDERDATA.GetString("MEINS");
                    child.KUNAG = table_ET_ORDERDATA.GetString("KUNAG");
                    child.NAMEG = table_ET_ORDERDATA.GetString("NAMEG");
                    child.KUNNR = table_ET_ORDERDATA.GetString("KUNNR");
                    child.NAMER = table_ET_ORDERDATA.GetString("NAMER");
                    child.KNUMV = table_ET_ORDERDATA.GetString("KNUMV");
                    child.HSJE = table_ET_ORDERDATA.GetString("HSJE");
                    child.ZKRATE = table_ET_ORDERDATA.GetString("ZKRATE");
                    child.ZKJE = table_ET_ORDERDATA.GetString("ZKJE");
                    child.TAXRATE = table_ET_ORDERDATA.GetString("TAXRATE");
                    child.TAXJE = table_ET_ORDERDATA.GetString("TAXJE");
                    child.KPJE = table_ET_ORDERDATA.GetString("KPJE");
                    child.HWJE = table_ET_ORDERDATA.GetString("HWJE");
                    child.JHD = table_ET_ORDERDATA.GetString("JHD");
                    child_ET_ORDERDATA.Add(child);
                }
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.ET_ORDERDATA = child_ET_ORDERDATA;
            return rst;
        }
    }
}

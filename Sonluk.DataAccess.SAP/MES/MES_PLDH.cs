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
    public class MES_PLDH : IMES_PLDH
    {
        public ZBCFUN_ZJLOT_PRT GET_ZJINFO(ZSL_BCT304_CT model, string IV_FCODE)
        {
            ZBCFUN_ZJLOT_PRT rst = new ZBCFUN_ZJLOT_PRT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                ZSL_BCT304_LOT child_ZSL_BCT304_LOT = new ZSL_BCT304_LOT();
                List<ZSL_BCT304_LOT> child_ET_PLDH = new List<ZSL_BCT304_LOT>();
                List<ZSL_BCST024_PO> child_ET_POLIST = new List<ZSL_BCST024_PO>();
                IRfcFunction func = RFC.Function("ZBCFUN_ZJLOT_PRT");
                IRfcStructure irfcstruc = func.GetStructure("IS_LOT");
                irfcstruc.SetValue("PLDH", model.PLDH);
                irfcstruc.SetValue("YYCH", model.YYCH);
                irfcstruc.SetValue("SCBZ", model.SCBZ);
                irfcstruc.SetValue("MTSL", model.MTSL);
                irfcstruc.SetValue("PFDH", model.PFDH);
                irfcstruc.SetValue("TH", model.TH);
                irfcstruc.SetValue("WERKS", model.WERKS);
                irfcstruc.SetValue("ARBPL", model.ARBPL);
                func.SetValue("IS_LOT", irfcstruc);
                func.SetValue("IV_FCODE", IV_FCODE);

                RFC.Invoke(func, false);

                IRfcTable tb_CT_RETURN = func.GetTable("CT_RETURN");
                tb_CT_RETURN.CurrentIndex = 0;
                child_MES_RETURN.TYPE = tb_CT_RETURN.GetString("TYPE");
                child_MES_RETURN.MESSAGE = tb_CT_RETURN.GetString("MESSAGE");
                if (child_MES_RETURN.TYPE == "S")
                {
                    IRfcStructure stru_ES_LOT = func.GetStructure("ES_LOT");
                    child_ZSL_BCT304_LOT.YYCH = stru_ES_LOT.GetString("YYCH");
                    child_ZSL_BCT304_LOT.PFDH = stru_ES_LOT.GetString("PFDH");
                    child_ZSL_BCT304_LOT.PLDH = stru_ES_LOT.GetString("PLDH");
                    child_ZSL_BCT304_LOT.SCBZ = stru_ES_LOT.GetString("SCBZ");
                    child_ZSL_BCT304_LOT.TH = Convert.ToInt32(stru_ES_LOT.GetString("TH"));
                    child_ZSL_BCT304_LOT.MTSL = stru_ES_LOT.GetString("MTSL");
                    child_ZSL_BCT304_LOT.TLJTS = Convert.ToInt32(stru_ES_LOT.GetString("TLJTS"));
                    child_ZSL_BCT304_LOT.PFLJTS = Convert.ToInt32(stru_ES_LOT.GetString("PFLJTS"));
                    child_ZSL_BCT304_LOT.PLLJTS = Convert.ToInt32(stru_ES_LOT.GetString("PLLJTS"));
                    child_ZSL_BCT304_LOT.RQ = stru_ES_LOT.GetString("RQ");
                    child_ZSL_BCT304_LOT.QYRQ = stru_ES_LOT.GetString("QYRQ");
                    child_ZSL_BCT304_LOT.JSRQ = stru_ES_LOT.GetString("JSRQ");
                    child_ZSL_BCT304_LOT.SYSCX = stru_ES_LOT.GetString("SYSCX");
                    child_ZSL_BCT304_LOT.SYCPGG = stru_ES_LOT.GetString("SYCPGG");


                    IRfcTable tb_ET_PLDH = func.GetTable("ET_PLDH");
                    for (int i = 0; i < tb_ET_PLDH.RowCount; i++)
                    {
                        tb_ET_PLDH.CurrentIndex = i;
                        ZSL_BCT304_LOT child = new ZSL_BCT304_LOT();
                        child.YYCH = tb_ET_PLDH.GetString("YYCH");
                        child.PFDH = tb_ET_PLDH.GetString("PFDH");
                        child.PLDH = tb_ET_PLDH.GetString("PLDH");
                        child.SCBZ = tb_ET_PLDH.GetString("SCBZ");
                        child.TH = Convert.ToInt32(tb_ET_PLDH.GetString("TH"));
                        child.MTSL = tb_ET_PLDH.GetString("MTSL");
                        child.TLJTS = Convert.ToInt32(tb_ET_PLDH.GetString("TLJTS"));
                        child.PFLJTS = Convert.ToInt32(tb_ET_PLDH.GetString("PFLJTS"));
                        child.PLLJTS = Convert.ToInt32(tb_ET_PLDH.GetString("PLLJTS"));
                        child.RQ = tb_ET_PLDH.GetString("RQ");
                        child.QYRQ = tb_ET_PLDH.GetString("QYRQ");
                        child.JSRQ = tb_ET_PLDH.GetString("JSRQ");
                        child.SYSCX = tb_ET_PLDH.GetString("SYSCX");
                        child.SYCPGG = tb_ET_PLDH.GetString("SYCPGG");
                        child_ET_PLDH.Add(child);
                    }

                    IRfcTable tb_ET_POLIST = func.GetTable("ET_POLIST");
                    for (int i = 0; i < tb_ET_POLIST.RowCount; i++)
                    {
                        tb_ET_POLIST.CurrentIndex = i;
                        ZSL_BCST024_PO child = new ZSL_BCST024_PO();
                        child.AUFNR = Convert.ToInt64(tb_ET_POLIST.GetString("AUFNR")).ToString();
                        child.WERKS = tb_ET_POLIST.GetString("WERKS");
                        child.MATNR = Convert.ToInt64(tb_ET_POLIST.GetString("MATNR")).ToString();
                        child.MAKTX = tb_ET_POLIST.GetString("MAKTX");
                        child.MATKL = tb_ET_POLIST.GetString("MATKL");
                        child.WLDL = tb_ET_POLIST.GetString("WLDL");
                        child.DCXH = tb_ET_POLIST.GetString("DCXH");
                        child.DCDJ = tb_ET_POLIST.GetString("DCDJ");
                        child.PSMNG = tb_ET_POLIST.GetString("PSMNG");
                        child.AMEIN = tb_ET_POLIST.GetString("AMEIN");
                        child.WEMNG = tb_ET_POLIST.GetString("WEMNG");
                        child.KDAUF = tb_ET_POLIST.GetString("KDAUF");
                        child.KDPOS = Convert.ToInt64(tb_ET_POLIST.GetString("KDPOS")).ToString();
                        child.GSTRP = tb_ET_POLIST.GetString("GSTRP");
                        child.GLTRP = tb_ET_POLIST.GetString("GLTRP");
                        child.ARBPL = tb_ET_POLIST.GetString("ARBPL");
                        child.LTXA1 = tb_ET_POLIST.GetString("LTXA1");
                        child.BSTDK = tb_ET_POLIST.GetString("BSTDK");
                        child.RSNUM = tb_ET_POLIST.GetString("RSNUM");
                        child.AUFPL = tb_ET_POLIST.GetString("AUFPL");
                        child.OBJNR = tb_ET_POLIST.GetString("OBJNR");
                        child.STAT = tb_ET_POLIST.GetString("STAT");
                        child.DEL = tb_ET_POLIST.GetString("DEL");
                        child.CHARG = tb_ET_POLIST.GetString("CHARG");
                        child_ET_POLIST.Add(child);
                    }
                }
                rst.ES_LOT = child_ZSL_BCT304_LOT;
                rst.ET_PLDH = child_ET_PLDH;
                rst.ET_POLIST = child_ET_POLIST;
                rst.MES_RETURN = child_MES_RETURN;
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
            }

            return rst;
        }

        public ZBCFUN_GDRKS_READ GET_GDINFO(List<ZSL_BCST024_PO> IT_GDXX)
        {
            ZBCFUN_GDRKS_READ rst = new ZBCFUN_GDRKS_READ();
            List<ZSL_BCST024_PO> nodes = new List<ZSL_BCST024_PO>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                IRfcFunction func = RFC.Function("ZBCFUN_GDRKS_READ");
                IRfcTable i_table = func.GetTable("IT_GDXX");
                for (int i = 0; i < IT_GDXX.Count; i++)
                {
                    i_table.Append();
                    i_table.SetValue("AUFNR", IT_GDXX[i].AUFNR);
                    i_table.SetValue("TMSL", IT_GDXX[i].TMSL);                   
                }
                RFC.Invoke(func, true);
                IRfcTable tb_ET_GDXX = func.GetTable("ET_GDXX");
                for (int i = 0; i < tb_ET_GDXX.RowCount; i++)
                {
                    tb_ET_GDXX.CurrentIndex = i;
                    ZSL_BCST024_PO child = new ZSL_BCST024_PO();
                    child.AUFNR = Convert.ToInt64(tb_ET_GDXX.GetString("AUFNR")).ToString();
                    child.WERKS = tb_ET_GDXX.GetString("WERKS");
                    child.MATNR = Convert.ToInt64(tb_ET_GDXX.GetString("MATNR")).ToString();
                    child.MAKTX = tb_ET_GDXX.GetString("MAKTX");
                    child.MATKL = tb_ET_GDXX.GetString("MATKL");
                    child.WLDL = tb_ET_GDXX.GetString("WLDL");
                    child.DCXH = tb_ET_GDXX.GetString("DCXH");
                    child.DCDJ = tb_ET_GDXX.GetString("DCDJ");
                    child.PSMNG = tb_ET_GDXX.GetString("PSMNG");
                    child.AMEIN = tb_ET_GDXX.GetString("AMEIN");
                    child.WEMNG = tb_ET_GDXX.GetString("WEMNG");
                    child.KDAUF = tb_ET_GDXX.GetString("KDAUF");
                    child.KDPOS = tb_ET_GDXX.GetString("KDPOS");
                    child.GSTRP = tb_ET_GDXX.GetString("GSTRP");
                    child.GLTRP = tb_ET_GDXX.GetString("GLTRP");
                    child.ARBPL = tb_ET_GDXX.GetString("ARBPL");
                    child.LTXA1 = tb_ET_GDXX.GetString("LTXA1");
                    child.BSTDK = tb_ET_GDXX.GetString("BSTDK");
                    child.RSNUM = tb_ET_GDXX.GetString("RSNUM");
                    child.AUFPL = tb_ET_GDXX.GetString("AUFPL");
                    child.OBJNR = tb_ET_GDXX.GetString("OBJNR");
                    child.STAT = tb_ET_GDXX.GetString("STAT");
                    child.DEL = tb_ET_GDXX.GetString("DEL");
                    child.CHARG = tb_ET_GDXX.GetString("CHARG");
                    child.TMSL = tb_ET_GDXX.GetString("TMSL");
                    nodes.Add(child);
                }
                IRfcTable tb_CT_RETURN = func.GetTable("CT_RETURN");
                tb_CT_RETURN.CurrentIndex = 0;
                child_MES_RETURN.TYPE = tb_CT_RETURN.GetString("TYPE");
                child_MES_RETURN.MESSAGE = tb_CT_RETURN.GetString("MESSAGE");
                rst.MES_RETURN = child_MES_RETURN;
                rst.ET_POLIST = nodes;
                
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

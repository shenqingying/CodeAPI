using SAP.Middleware.Connector;
using Sonluk.DataAccess.SAP.Utility;
using Sonluk.Entities.BC;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.SAP.MES
{
    public class MES_MM : IMES_MM
    {
        public ZBCFUN_KCDD_READ GET_KCDD(string IV_WERKS)
        {
            ZBCFUN_KCDD_READ rst = new ZBCFUN_KCDD_READ();
            List<ZSL_BCST008> child_CT_KCDD = new List<ZSL_BCST008>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            IRfcFunction func = RFC.Function("ZBCFUN_KCDD_READ");
            func.SetValue("IV_WERKS", IV_WERKS);
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table_CT_RETURN = func.GetTable("CT_RETURN");
                table_CT_RETURN.CurrentIndex = 0;
                child_MES_RETURN.TYPE = table_CT_RETURN.GetString("TYPE");
                child_MES_RETURN.MESSAGE = table_CT_RETURN.GetString("MESSAGE");
                IRfcTable table = func.GetTable("CT_KCDD");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    ZSL_BCST008 child = new ZSL_BCST008();
                    child.WERKS = table.GetString("WERKS");
                    child.LGORT = table.GetString("LGORT");
                    child.LGOBE = table.GetString("LGOBE");
                    child_CT_KCDD.Add(child);
                }
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            rst.CT_KCDD = child_CT_KCDD;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }


        public IList<ZSL_BCST300> GET_GZZX(string IV_WERKS)
        {
            IList<ZSL_BCST300> rst_gzzx = new List<ZSL_BCST300>();
            IRfcFunction func = RFC.Function("ZBCFUN_GZZX_READ");
            func.SetValue("IV_WERKS", IV_WERKS);
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("CT_GZZX");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    ZSL_BCST300 child = new ZSL_BCST300();
                    child.WERKS = table.GetString("WERKS");
                    child.ARBPL = table.GetString("ARBPL");
                    child.KTEXT = table.GetString("KTEXT");
                    rst_gzzx.Add(child);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return rst_gzzx;
        }


        public IList<ZSL_BCST301> GET_PFDH()
        {
            IList<ZSL_BCST301> rst_pfdh = new List<ZSL_BCST301>();
            IRfcFunction func = RFC.Function("ZBCFUN_PFDH_READ");
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("CT_PFDH");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    ZSL_BCST301 child = new ZSL_BCST301();
                    child.PFDH = table.GetString("PFDH");
                    child.ZT = table.GetString("ZT");
                    child.BZSM = table.GetString("BZSM");
                    child.YXBS = table.GetString("YXBS");
                    child.CJRQ = table.GetString("CJRQ");
                    child.CJSJ = table.GetString("CJSJ");
                    child.CJR = table.GetString("CJR");
                    child.XGRQ = table.GetString("XGRQ");
                    child.XGSJ = table.GetString("XGSJ");
                    child.XGR = table.GetString("XGR");
                    rst_pfdh.Add(child);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return rst_pfdh;
        }


        public MES_SY_PFDH_LIST GET_PFDH_ACTION_SAP(string GC)
        {
            MES_SY_PFDH_LIST rst = new MES_SY_PFDH_LIST();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_SY_PFDH> child_MES_SY_PFDH = new List<MES_SY_PFDH>();
            IRfcFunction func = RFC.Function("ZBCFUN_PFDH_READ");
            try
            {
                RFC.Invoke(func, false);
                IRfcTable tb_CT_RETURN = func.GetTable("CT_RETURN");
                tb_CT_RETURN.CurrentIndex = 0;
                child_MES_RETURN.TYPE = tb_CT_RETURN.GetString("TYPE");
                child_MES_RETURN.MESSAGE = tb_CT_RETURN.GetString("MESSAGE");

                if (child_MES_RETURN.TYPE == "S")
                {
                    IRfcTable table = func.GetTable("CT_PFDH");
                    for (int i = 0; i < table.RowCount; i++)
                    {
                        table.CurrentIndex = i;
                        MES_SY_PFDH child = new MES_SY_PFDH();
                        child.GC = GC;
                        child.LB = 1;
                        child.PFDH = table.GetString("PFDH");
                        child.REMARK = table.GetString("BZSM");
                        if (table.GetString("YXBS") == "Y")
                        {
                            child.ISACTION = 1;
                            child_MES_SY_PFDH.Add(child);
                        }
                    }
                }
                rst.MES_RETURN = child_MES_RETURN;
                rst.MES_SY_PFDH = child_MES_SY_PFDH;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            return rst;
        }


        public MES_SY_MATERIAL_GROUP_SELECT GET_WLGROUP()
        {
            MES_SY_MATERIAL_GROUP_SELECT rst = new MES_SY_MATERIAL_GROUP_SELECT();
            List<MES_SY_MATERIAL_GROUP> child_MES_SY_MATERIAL_GROUP = new List<MES_SY_MATERIAL_GROUP>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            IRfcFunction func = RFC.Function("ZBCFUN_WLZXX_READ");
            try
            {
                RFC.Invoke(func, false);
                IRfcTable tb_CT_RETURN = func.GetTable("CT_RETURN");
                tb_CT_RETURN.CurrentIndex = 0;
                child_MES_RETURN.TYPE = tb_CT_RETURN.GetString("TYPE");
                child_MES_RETURN.MESSAGE = tb_CT_RETURN.GetString("MESSAGE");

                IRfcTable table = func.GetTable("ET_WLZ");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    MES_SY_MATERIAL_GROUP child = new MES_SY_MATERIAL_GROUP();
                    child.WLGROUP = table.GetString("MATKL");
                    child.WLGROUPNAME = table.GetString("WGBEZ");
                    child.WLLBNAME = table.GetString("WLDL");
                    child.CJR = table.GetString("CJR");
                    child.XGR = table.GetString("XGR");
                    child_MES_SY_MATERIAL_GROUP.Add(child);
                }
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                //throw new ApplicationException(e.Message);
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_SY_MATERIAL_GROUP = child_MES_SY_MATERIAL_GROUP;
            return rst;
        }


        public MES_SY_MATERIAL_INSERT_LIST GET_WLXXBYGROUP(string IV_WERKS, string WLGROUP, string MATNR, string FCODE)
        {
            MES_SY_MATERIAL_INSERT_LIST rst = new MES_SY_MATERIAL_INSERT_LIST();
            List<MES_SY_MATERIAL> child_MES_SY_MATERIAL = new List<MES_SY_MATERIAL>();
            List<ZSL_BCS112> child_ET_HSGX = new List<ZSL_BCS112>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            IRfcFunction func = RFC.Function("ZBCFUN_WLZSJ_READ");
            IRfcTable struc1 = func.GetTable("IT_WLXX");
            //for (int i = 0; i < model.Count; i++)
            //{
            struc1.Insert();
            struc1.CurrentRow.SetValue("MATNR", MATNR);
            struc1.CurrentRow.SetValue("MATKL", WLGROUP);
            struc1.CurrentRow.SetValue("FCODE", FCODE);
            //}
            func.SetValue("IT_WLXX", struc1);
            func.SetValue("IV_WERKS", IV_WERKS);
            try
            {
                RFC.Invoke(func, false);

                IRfcTable tb_CT_RETURN = func.GetTable("CT_RETURN");
                tb_CT_RETURN.CurrentIndex = 0;
                child_MES_RETURN.TYPE = tb_CT_RETURN.GetString("TYPE");
                child_MES_RETURN.MESSAGE = tb_CT_RETURN.GetString("MESSAGE");


                IRfcTable table = func.GetTable("ET_WLXX");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    MES_SY_MATERIAL child = new MES_SY_MATERIAL();
                    child.GC = IV_WERKS;
                    child.WLH = Convert.ToInt64(table.GetString("MATNR")).ToString();
                    child.WLMS = table.GetString("MAKTX");
                    child.UNITSNAME = table.GetString("MEINS");
                    child.WLGROUP = table.GetString("MATKL");
                    child.DCXHNAME = table.GetString("DCXH");
                    child.DCDJNAME = table.GetString("DCDJ");
                    child.DJBS = table.GetString("DJBS");
                    string ZSBS = table.GetString("ZSBS");
                    if (ZSBS == "Y")
                    {
                        child.ISTRACE = 1;
                    }
                    else
                    {
                        child.ISTRACE = 0;
                    }
                    child_MES_SY_MATERIAL.Add(child);
                }
                IRfcTable table_ET_HSGX = func.GetTable("ET_HSGX");
                for (int i = 0; i < table_ET_HSGX.RowCount; i++)
                {
                    table_ET_HSGX.CurrentIndex = i;
                    ZSL_BCS112 child = new ZSL_BCS112();
                    child.WERKS = IV_WERKS;
                    child.MATNR = Convert.ToInt64(table_ET_HSGX.GetString("MATNR")).ToString();
                    child.MEINH = table_ET_HSGX.GetString("MEINH");
                    child.UMREZ = Convert.ToInt32(table_ET_HSGX.GetString("UMREZ"));
                    child.UMREN = Convert.ToInt32(table_ET_HSGX.GetString("UMREN"));
                    child_ET_HSGX.Add(child);
                }
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_SY_MATERIAL = child_MES_SY_MATERIAL;
            rst.ET_HSGX = child_ET_HSGX;
            return rst;
        }


        public ZBCFUN_GDJGXX_READ get_GDJGXX(string IV_AUFNR)
        {
            ZBCFUN_GDJGXX_READ rst = new ZBCFUN_GDJGXX_READ();
            ES_HEADER child_header = new ES_HEADER();
            List<ET_BOM> child_ET_BOM = new List<ET_BOM>();
            List<ZSL_BCST302_R> child_ET_RT = new List<ZSL_BCST302_R>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            IRfcFunction func = RFC.Function("ZBCFUN_GDJGXX_READ");
            func.SetValue("IV_AUFNR", IV_AUFNR);
            try
            {
                RFC.Invoke(func, false);

                IRfcTable tb_CT_RETURN = func.GetTable("CT_RETURN");
                tb_CT_RETURN.CurrentIndex = 0;
                child_MES_RETURN.TYPE = tb_CT_RETURN.GetString("TYPE");
                child_MES_RETURN.MESSAGE = tb_CT_RETURN.GetString("MESSAGE");

                if (child_MES_RETURN.TYPE != "E")
                {
                    IRfcStructure istruc = func.GetStructure("ES_HEADER");
                    child_header.AUFNR = Convert.ToInt64(istruc.GetString("AUFNR")).ToString();
                    child_header.WERKS = istruc.GetString("WERKS");
                    child_header.MATNR = Convert.ToInt64(istruc.GetString("MATNR")).ToString();
                    child_header.MAKTX = istruc.GetString("MAKTX");
                    child_header.MATKL = istruc.GetString("MATKL");
                    child_header.WLDL = istruc.GetString("WLDL");
                    child_header.DCXH = istruc.GetString("DCXH");
                    child_header.DCDJ = istruc.GetString("DCDJ");
                    child_header.PSMNG = istruc.GetString("PSMNG");
                    child_header.AMEIN = istruc.GetString("AMEIN");
                    child_header.WEMNG = istruc.GetString("WEMNG");
                    child_header.KDAUF = istruc.GetString("KDAUF");
                    child_header.KDPOS = istruc.GetString("KDPOS");
                    child_header.GSTRP = istruc.GetString("GSTRP");
                    child_header.GLTRP = istruc.GetString("GLTRP");
                    child_header.ARBPL = istruc.GetString("ARBPL");
                    child_header.LTXA1 = istruc.GetString("LTXA1");
                    child_header.BSTDK = istruc.GetString("BSTDK");
                    child_header.RSNUM = istruc.GetString("RSNUM");
                    child_header.AUFPL = istruc.GetString("AUFPL");
                    child_header.OBJNR = istruc.GetString("OBJNR");
                    child_header.STAT = istruc.GetString("STAT");
                    child_header.DEL = istruc.GetString("DEL");
                    child_header.CHARG = istruc.GetString("CHARG");
                    child_header.WEMPF = istruc.GetString("WEMPF");
                    child_header.VDATU = istruc.GetString("VDATU");
                    child_header.TMSL = istruc.GetString("TMSL");
                    if (child_header.VDATU == "0000-00-00")
                    {
                        child_header.VDATU = "";
                    }
                    if (child_header.KDAUF != "")
                    {
                        child_header.KDAUF = Convert.ToInt32(child_header.KDAUF).ToString();
                    }
                    if (child_header.KDPOS != "")
                    {
                        child_header.KDPOS = Convert.ToInt32(child_header.KDPOS).ToString();
                        if (child_header.KDPOS == "0")
                        {
                            child_header.KDPOS = "";
                        }
                    }
                    if (child_header.KDAUF == "")
                    {
                        string xxnobill = istruc.GetString("WEMPF");
                        if (xxnobill != "")
                        {
                            string[] xxnobilllist = xxnobill.Split('-');
                            if (xxnobilllist.Length > 1)
                            {
                                child_header.KDAUF = xxnobilllist[0];
                                child_header.KDPOS = xxnobilllist[1];
                            }
                        }
                    }
                    rst.ES_HEADER = child_header;
                    IRfcTable tb_ET_BOM = func.GetTable("ET_BOM");
                    for (int i = 0; i < tb_ET_BOM.RowCount; i++)
                    {
                        tb_ET_BOM.CurrentIndex = i;
                        ET_BOM child = new ET_BOM();
                        child.RSNUM = tb_ET_BOM.GetString("RSNUM");
                        child.RSPOS = tb_ET_BOM.GetString("RSPOS");
                        child.POSTP = tb_ET_BOM.GetString("POSTP");
                        child.POSNR = tb_ET_BOM.GetString("POSNR");
                        child.STLTY = tb_ET_BOM.GetString("STLTY");
                        child.STLNR = tb_ET_BOM.GetString("STLNR");
                        child.STLKN = tb_ET_BOM.GetString("STLKN");
                        child.STPOZ = tb_ET_BOM.GetString("STPOZ");
                        child.IDNRK = tb_ET_BOM.GetString("IDNRK").TrimStart('0');
                        child.MAKTX = tb_ET_BOM.GetString("MAKTX");
                        child.WERKS = tb_ET_BOM.GetString("WERKS");
                        child.MENGE = tb_ET_BOM.GetString("MENGE");
                        child.MEINS = tb_ET_BOM.GetString("MEINS");
                        child.MATKL = tb_ET_BOM.GetString("MATKL");
                        child.WLLBNAME = tb_ET_BOM.GetString("WLDL");
                        child.DCXHNAME = tb_ET_BOM.GetString("DCXH");
                        child.DCDJNAME = tb_ET_BOM.GetString("DCDJ");
                        child.ZSBS = tb_ET_BOM.GetString("ZSBS");
                        child.SOBKZ = tb_ET_BOM.GetString("SOBKZ");
                        child.KDAUF = ZHMUN(tb_ET_BOM.GetString("KDAUF"));
                        child.KDPOS = ZHMUN(tb_ET_BOM.GetString("KDPOS"));
                        child.AUFNR = tb_ET_BOM.GetString("AUFNR").TrimStart('0');
                        child.DEL = tb_ET_BOM.GetString("DEL");
                        child_ET_BOM.Add(child);
                    }
                    rst.ET_BOM = child_ET_BOM;
                    IRfcTable tb_ET_RT = func.GetTable("ET_RT");
                    for (int i = 0; i < tb_ET_RT.RowCount; i++)
                    {
                        tb_ET_RT.CurrentIndex = i;
                        ZSL_BCST302_R child = new ZSL_BCST302_R();
                        child.AUFPL = tb_ET_RT.GetString("AUFPL");
                        child.VORNR = tb_ET_RT.GetString("VORNR");
                        child.ARBPL = tb_ET_RT.GetString("ARBPL");
                        child.LTXA1 = tb_ET_RT.GetString("LTXA1");
                        child.WERKS = tb_ET_RT.GetString("WERKS");
                        child.AUFNR = tb_ET_RT.GetString("AUFNR").TrimStart('0');
                        child_ET_RT.Add(child);
                    }
                    rst.ET_RT = child_ET_RT;
                    child_MES_RETURN.TYPE = "S";
                    child_MES_RETURN.MESSAGE = "";
                    rst.MES_RETURN = child_MES_RETURN;
                }
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.ES_HEADER = child_header;
            rst.ET_BOM = child_ET_BOM;
            rst.ET_RT = child_ET_RT;
            return rst;
        }

        public ZBCFUN_GDLIST_READ GET_GDLIST(string IV_WERKS, string IV_GZZX, string IV_WLDL, string IV_AUFNR, string LOW, string HIGH)
        {
            LOW = LOW.Replace("-", "");
            HIGH = HIGH.Replace("-", "");
            ZBCFUN_GDLIST_READ rst = new ZBCFUN_GDLIST_READ();
            List<ZSL_BCST024_PO> child_ET_POLIST = new List<ZSL_BCST024_PO>();
            List<ZSL_BCS302_B> child_ET_BOM = new List<ZSL_BCS302_B>();
            List<ZSL_BCST302_R> child_ET_RT = new List<ZSL_BCST302_R>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            IRfcFunction func = RFC.Function("ZBCFUN_GDLIST_READ");
            func.SetValue("IV_WERKS", IV_WERKS);
            func.SetValue("IV_GZZX", IV_GZZX);
            func.SetValue("IV_WLDL", IV_WLDL);
            func.SetValue("IV_AUFNR", IV_AUFNR);
            IRfcStructure irfcstruc = func.GetStructure("IS_DATE");
            irfcstruc.SetValue("SIGN", "I");
            irfcstruc.SetValue("OPTION", "BT");
            irfcstruc.SetValue("LOW", LOW);
            irfcstruc.SetValue("HIGH", HIGH);
            func.SetValue("IS_DATE", irfcstruc);

            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("ET_POLIST");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    ZSL_BCST024_PO child = new ZSL_BCST024_PO();
                    child.AUFNR = Convert.ToInt64(table.GetString("AUFNR")).ToString();
                    child.WERKS = table.GetString("WERKS");
                    child.MATNR = Convert.ToInt64(table.GetString("MATNR")).ToString();
                    child.MAKTX = table.GetString("MAKTX");
                    child.MATKL = table.GetString("MATKL");
                    child.WLDL = table.GetString("WLDL");
                    child.DCXH = table.GetString("DCXH");
                    child.DCDJ = table.GetString("DCDJ");
                    child.PSMNG = table.GetString("PSMNG");
                    child.AMEIN = table.GetString("AMEIN");
                    child.WEMNG = table.GetString("WEMNG");
                    child.KDAUF = table.GetString("KDAUF");
                    child.KDPOS = table.GetString("KDPOS");
                    child.GSTRP = table.GetString("GSTRP");
                    child.GLTRP = table.GetString("GLTRP");
                    child.ARBPL = table.GetString("ARBPL");
                    child.LTXA1 = table.GetString("LTXA1");
                    child.BSTDK = table.GetString("BSTDK");
                    child.RSNUM = table.GetString("RSNUM");
                    child.AUFPL = table.GetString("AUFPL");
                    child.OBJNR = table.GetString("OBJNR");
                    child.STAT = table.GetString("STAT");
                    child.DEL = table.GetString("DEL");
                    child.CHARG = table.GetString("CHARG");
                    child.WEMPF = table.GetString("WEMPF");
                    child.VDATU = table.GetString("VDATU");
                    child.TMSL = table.GetString("TMSL");
                    if (child.VDATU == "0000-00-00")
                    {
                        child.VDATU = "";
                    }
                    if (child.KDAUF != "")
                    {
                        child.KDAUF = Convert.ToInt32(child.KDAUF).ToString();
                    }
                    if (child.KDPOS != "")
                    {
                        child.KDPOS = Convert.ToInt32(child.KDPOS).ToString();
                        if (child.KDPOS == "0")
                        {
                            child.KDPOS = "";
                        }
                    }
                    if (child.KDAUF == "")
                    {
                        string xxnobill = table.GetString("WEMPF");
                        if (xxnobill != "")
                        {
                            string[] xxnobilllist = xxnobill.Split('-');
                            if (xxnobilllist.Length > 1)
                            {
                                child.KDAUF = xxnobilllist[0];
                                child.KDPOS = xxnobilllist[1];
                            }
                        }
                    }
                    child_ET_POLIST.Add(child);
                }
                rst.ET_POLIST = child_ET_POLIST;


                IRfcTable tb_ET_BOM = func.GetTable("ET_BOM");
                for (int i = 0; i < tb_ET_BOM.RowCount; i++)
                {
                    tb_ET_BOM.CurrentIndex = i;
                    ZSL_BCS302_B child = new ZSL_BCS302_B();
                    child.RSNUM = tb_ET_BOM.GetString("RSNUM");
                    child.RSPOS = tb_ET_BOM.GetString("RSPOS");
                    child.POSTP = tb_ET_BOM.GetString("POSTP");
                    child.POSNR = tb_ET_BOM.GetString("POSNR");
                    child.STLTY = tb_ET_BOM.GetString("STLTY");
                    child.STLNR = tb_ET_BOM.GetString("STLNR");
                    child.STLKN = tb_ET_BOM.GetString("STLKN");
                    child.STPOZ = tb_ET_BOM.GetString("STPOZ");
                    string IDNRK = tb_ET_BOM.GetString("IDNRK");
                    if (IDNRK == "")
                    {
                        child.IDNRK = "";
                    }
                    else
                    {
                        child.IDNRK = Convert.ToInt64(IDNRK).ToString();
                    }
                    child.MAKTX = tb_ET_BOM.GetString("MAKTX");
                    child.WERKS = tb_ET_BOM.GetString("WERKS");
                    child.MENGE = tb_ET_BOM.GetString("MENGE");
                    child.MEINS = tb_ET_BOM.GetString("MEINS");
                    child.MATKL = tb_ET_BOM.GetString("MATKL");
                    child.WLDL = tb_ET_BOM.GetString("WLDL");
                    child.DCXH = tb_ET_BOM.GetString("DCXH");
                    child.DCDJ = tb_ET_BOM.GetString("DCDJ");
                    child.ZSBS = tb_ET_BOM.GetString("ZSBS");
                    child.SOBKZ = tb_ET_BOM.GetString("SOBKZ");
                    child.KDAUF = ZHMUN(tb_ET_BOM.GetString("KDAUF"));
                    child.KDPOS = ZHMUN(tb_ET_BOM.GetString("KDPOS"));
                    child.AUFNR = tb_ET_BOM.GetString("AUFNR").TrimStart('0');
                    child.DEL = tb_ET_BOM.GetString("DEL");
                    child_ET_BOM.Add(child);
                }

                rst.ET_BOM = child_ET_BOM;


                IRfcTable tb_ET_RT = func.GetTable("ET_RT");
                for (int i = 0; i < tb_ET_RT.RowCount; i++)
                {
                    tb_ET_RT.CurrentIndex = i;
                    ZSL_BCST302_R child = new ZSL_BCST302_R();
                    child.AUFPL = tb_ET_RT.GetString("AUFPL");
                    child.VORNR = tb_ET_RT.GetString("VORNR");
                    child.ARBPL = tb_ET_RT.GetString("ARBPL");
                    child.LTXA1 = tb_ET_RT.GetString("LTXA1");
                    child.WERKS = tb_ET_RT.GetString("WERKS");
                    child.AUFNR = tb_ET_RT.GetString("AUFNR").TrimStart('0');
                    child_ET_RT.Add(child);
                }
                rst.ET_RT = child_ET_RT;



                IRfcTable table_MES_RETURN = func.GetTable("CT_RETURN");
                table_MES_RETURN.CurrentIndex = 0;
                child_MES_RETURN.TYPE = table_MES_RETURN.GetString("TYPE");
                child_MES_RETURN.MESSAGE = table_MES_RETURN.GetString("MESSAGE");
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
        public ZBCFUN_GDLIST_READ GET_GDLIST_IV_MATNR(string IV_WERKS, string IV_GZZX, string IV_WLDL, string IV_AUFNR, string LOW, string HIGH, string IV_MATNR)
        {
            LOW = LOW.Replace("-", "");
            HIGH = HIGH.Replace("-", "");
            ZBCFUN_GDLIST_READ rst = new ZBCFUN_GDLIST_READ();
            List<ZSL_BCST024_PO> child_ET_POLIST = new List<ZSL_BCST024_PO>();
            List<ZSL_BCS302_B> child_ET_BOM = new List<ZSL_BCS302_B>();
            List<ZSL_BCST302_R> child_ET_RT = new List<ZSL_BCST302_R>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            IRfcFunction func = RFC.Function("ZBCFUN_GDLIST_READ");
            func.SetValue("IV_WERKS", IV_WERKS);
            func.SetValue("IV_GZZX", IV_GZZX);
            func.SetValue("IV_WLDL", IV_WLDL);
            func.SetValue("IV_AUFNR", IV_AUFNR);
            func.SetValue("IV_MATNR", IV_MATNR);
            IRfcStructure irfcstruc = func.GetStructure("IS_DATE");
            irfcstruc.SetValue("SIGN", "I");
            irfcstruc.SetValue("OPTION", "BT");
            irfcstruc.SetValue("LOW", LOW);
            irfcstruc.SetValue("HIGH", HIGH);
            func.SetValue("IS_DATE", irfcstruc);

            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("ET_POLIST");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    ZSL_BCST024_PO child = new ZSL_BCST024_PO();
                    child.AUFNR = Convert.ToInt64(table.GetString("AUFNR")).ToString();
                    child.WERKS = table.GetString("WERKS");
                    child.MATNR = Convert.ToInt64(table.GetString("MATNR")).ToString();
                    child.MAKTX = table.GetString("MAKTX");
                    child.MATKL = table.GetString("MATKL");
                    child.WLDL = table.GetString("WLDL");
                    child.DCXH = table.GetString("DCXH");
                    child.DCDJ = table.GetString("DCDJ");
                    child.PSMNG = table.GetString("PSMNG");
                    child.AMEIN = table.GetString("AMEIN");
                    child.WEMNG = table.GetString("WEMNG");
                    child.KDAUF = table.GetString("KDAUF");
                    child.KDPOS = table.GetString("KDPOS");
                    child.GSTRP = table.GetString("GSTRP");
                    child.GLTRP = table.GetString("GLTRP");
                    child.ARBPL = table.GetString("ARBPL");
                    child.LTXA1 = table.GetString("LTXA1");
                    child.BSTDK = table.GetString("BSTDK");
                    child.RSNUM = table.GetString("RSNUM");
                    child.AUFPL = table.GetString("AUFPL");
                    child.OBJNR = table.GetString("OBJNR");
                    child.STAT = table.GetString("STAT");
                    child.DEL = table.GetString("DEL");
                    child.CHARG = table.GetString("CHARG");
                    child.WEMPF = table.GetString("WEMPF");
                    child.VDATU = table.GetString("VDATU");
                    child.TMSL = table.GetString("TMSL");
                    if (child.VDATU == "0000-00-00")
                    {
                        child.VDATU = "";
                    }
                    if (child.KDAUF != "")
                    {
                        child.KDAUF = Convert.ToInt32(child.KDAUF).ToString();
                    }
                    if (child.KDPOS != "")
                    {
                        child.KDPOS = Convert.ToInt32(child.KDPOS).ToString();
                        if (child.KDPOS == "0")
                        {
                            child.KDPOS = "";
                        }
                    }
                    if (child.KDAUF == "")
                    {
                        string xxnobill = table.GetString("WEMPF");
                        if (xxnobill != "")
                        {
                            string[] xxnobilllist = xxnobill.Split('-');
                            if (xxnobilllist.Length > 1)
                            {
                                child.KDAUF = xxnobilllist[0];
                                child.KDPOS = xxnobilllist[1];
                            }
                        }
                    }
                    child_ET_POLIST.Add(child);
                }
                rst.ET_POLIST = child_ET_POLIST;


                IRfcTable tb_ET_BOM = func.GetTable("ET_BOM");
                for (int i = 0; i < tb_ET_BOM.RowCount; i++)
                {
                    tb_ET_BOM.CurrentIndex = i;
                    ZSL_BCS302_B child = new ZSL_BCS302_B();
                    child.RSNUM = tb_ET_BOM.GetString("RSNUM");
                    child.RSPOS = tb_ET_BOM.GetString("RSPOS");
                    child.POSTP = tb_ET_BOM.GetString("POSTP");
                    child.POSNR = tb_ET_BOM.GetString("POSNR");
                    child.STLTY = tb_ET_BOM.GetString("STLTY");
                    child.STLNR = tb_ET_BOM.GetString("STLNR");
                    child.STLKN = tb_ET_BOM.GetString("STLKN");
                    child.STPOZ = tb_ET_BOM.GetString("STPOZ");
                    string IDNRK = tb_ET_BOM.GetString("IDNRK");
                    if (IDNRK == "")
                    {
                        child.IDNRK = "";
                    }
                    else
                    {
                        child.IDNRK = Convert.ToInt64(IDNRK).ToString();
                    }
                    child.MAKTX = tb_ET_BOM.GetString("MAKTX");
                    child.WERKS = tb_ET_BOM.GetString("WERKS");
                    child.MENGE = tb_ET_BOM.GetString("MENGE");
                    child.MEINS = tb_ET_BOM.GetString("MEINS");
                    child.MATKL = tb_ET_BOM.GetString("MATKL");
                    child.WLDL = tb_ET_BOM.GetString("WLDL");
                    child.DCXH = tb_ET_BOM.GetString("DCXH");
                    child.DCDJ = tb_ET_BOM.GetString("DCDJ");
                    child.ZSBS = tb_ET_BOM.GetString("ZSBS");
                    child.SOBKZ = tb_ET_BOM.GetString("SOBKZ");
                    child.KDAUF = ZHMUN(tb_ET_BOM.GetString("KDAUF"));
                    child.KDPOS = ZHMUN(tb_ET_BOM.GetString("KDPOS"));
                    child.AUFNR = tb_ET_BOM.GetString("AUFNR").TrimStart('0');
                    child.DEL = tb_ET_BOM.GetString("DEL");
                    child_ET_BOM.Add(child);
                }

                rst.ET_BOM = child_ET_BOM;


                IRfcTable tb_ET_RT = func.GetTable("ET_RT");
                for (int i = 0; i < tb_ET_RT.RowCount; i++)
                {
                    tb_ET_RT.CurrentIndex = i;
                    ZSL_BCST302_R child = new ZSL_BCST302_R();
                    child.AUFPL = tb_ET_RT.GetString("AUFPL");
                    child.VORNR = tb_ET_RT.GetString("VORNR");
                    child.ARBPL = tb_ET_RT.GetString("ARBPL");
                    child.LTXA1 = tb_ET_RT.GetString("LTXA1");
                    child.WERKS = tb_ET_RT.GetString("WERKS");
                    child.AUFNR = tb_ET_RT.GetString("AUFNR").TrimStart('0');
                    child_ET_RT.Add(child);
                }
                rst.ET_RT = child_ET_RT;



                IRfcTable table_MES_RETURN = func.GetTable("CT_RETURN");
                table_MES_RETURN.CurrentIndex = 0;
                child_MES_RETURN.TYPE = table_MES_RETURN.GetString("TYPE");
                child_MES_RETURN.MESSAGE = table_MES_RETURN.GetString("MESSAGE");
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
        public ZBCFUN_GDLIST_READ GET_GDLIST_IV_MATNR_NODELETE(string IV_WERKS, string IV_GZZX, string IV_WLDL, string IV_AUFNR, string LOW, string HIGH, string IV_MATNR)
        {
            LOW = LOW.Replace("-", "");
            HIGH = HIGH.Replace("-", "");
            ZBCFUN_GDLIST_READ rst = new ZBCFUN_GDLIST_READ();
            List<ZSL_BCST024_PO> child_ET_POLIST = new List<ZSL_BCST024_PO>();
            List<ZSL_BCS302_B> child_ET_BOM = new List<ZSL_BCS302_B>();
            List<ZSL_BCST302_R> child_ET_RT = new List<ZSL_BCST302_R>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            IRfcFunction func = RFC.Function("ZBCFUN_GDLIST_READ");
            func.SetValue("IV_WERKS", IV_WERKS);
            func.SetValue("IV_GZZX", IV_GZZX);
            func.SetValue("IV_WLDL", IV_WLDL);
            func.SetValue("IV_AUFNR", IV_AUFNR);
            func.SetValue("IV_MATNR", IV_MATNR);
            IRfcStructure irfcstruc = func.GetStructure("IS_DATE");
            irfcstruc.SetValue("SIGN", "I");
            irfcstruc.SetValue("OPTION", "BT");
            irfcstruc.SetValue("LOW", LOW);
            irfcstruc.SetValue("HIGH", HIGH);
            func.SetValue("IS_DATE", irfcstruc);

            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("ET_POLIST");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    if (table.GetString("DEL") != "X")
                    {
                        ZSL_BCST024_PO child = new ZSL_BCST024_PO();
                        child.AUFNR = Convert.ToInt64(table.GetString("AUFNR")).ToString();
                        child.WERKS = table.GetString("WERKS");
                        child.MATNR = Convert.ToInt64(table.GetString("MATNR")).ToString();
                        child.MAKTX = table.GetString("MAKTX");
                        child.MATKL = table.GetString("MATKL");
                        child.WLDL = table.GetString("WLDL");
                        child.DCXH = table.GetString("DCXH");
                        child.DCDJ = table.GetString("DCDJ");
                        child.PSMNG = table.GetString("PSMNG");
                        child.AMEIN = table.GetString("AMEIN");
                        child.WEMNG = table.GetString("WEMNG");
                        child.KDAUF = table.GetString("KDAUF");
                        child.KDPOS = table.GetString("KDPOS");
                        child.GSTRP = table.GetString("GSTRP");
                        child.GLTRP = table.GetString("GLTRP");
                        child.ARBPL = table.GetString("ARBPL");
                        child.LTXA1 = table.GetString("LTXA1");
                        child.BSTDK = table.GetString("BSTDK");
                        child.RSNUM = table.GetString("RSNUM");
                        child.AUFPL = table.GetString("AUFPL");
                        child.OBJNR = table.GetString("OBJNR");
                        child.STAT = table.GetString("STAT");
                        child.DEL = table.GetString("DEL");
                        child.CHARG = table.GetString("CHARG");
                        child.WEMPF = table.GetString("WEMPF");
                        child.VDATU = table.GetString("VDATU");
                        child.TMSL = table.GetString("TMSL");
                        if (child.VDATU == "0000-00-00")
                        {
                            child.VDATU = "";
                        }
                        if (child.KDAUF != "")
                        {
                            child.KDAUF = Convert.ToInt32(child.KDAUF).ToString();
                        }
                        if (child.KDPOS != "")
                        {
                            child.KDPOS = Convert.ToInt32(child.KDPOS).ToString();
                            if (child.KDPOS == "0")
                            {
                                child.KDPOS = "";
                            }
                        }
                        if (child.KDAUF == "")
                        {
                            string xxnobill = table.GetString("WEMPF");
                            if (xxnobill != "")
                            {
                                string[] xxnobilllist = xxnobill.Split('-');
                                if (xxnobilllist.Length > 1)
                                {
                                    child.KDAUF = xxnobilllist[0];
                                    child.KDPOS = xxnobilllist[1];
                                }
                            }
                        }
                        child_ET_POLIST.Add(child);
                    }
                }
                rst.ET_POLIST = child_ET_POLIST;


                IRfcTable tb_ET_BOM = func.GetTable("ET_BOM");
                for (int i = 0; i < tb_ET_BOM.RowCount; i++)
                {
                    tb_ET_BOM.CurrentIndex = i;
                    ZSL_BCS302_B child = new ZSL_BCS302_B();
                    child.RSNUM = tb_ET_BOM.GetString("RSNUM");
                    child.RSPOS = tb_ET_BOM.GetString("RSPOS");
                    child.POSTP = tb_ET_BOM.GetString("POSTP");
                    child.POSNR = tb_ET_BOM.GetString("POSNR");
                    child.STLTY = tb_ET_BOM.GetString("STLTY");
                    child.STLNR = tb_ET_BOM.GetString("STLNR");
                    child.STLKN = tb_ET_BOM.GetString("STLKN");
                    child.STPOZ = tb_ET_BOM.GetString("STPOZ");
                    string IDNRK = tb_ET_BOM.GetString("IDNRK");
                    if (IDNRK == "")
                    {
                        child.IDNRK = "";
                    }
                    else
                    {
                        child.IDNRK = Convert.ToInt64(IDNRK).ToString();
                    }
                    child.MAKTX = tb_ET_BOM.GetString("MAKTX");
                    child.WERKS = tb_ET_BOM.GetString("WERKS");
                    child.MENGE = tb_ET_BOM.GetString("MENGE");
                    child.MEINS = tb_ET_BOM.GetString("MEINS");
                    child.MATKL = tb_ET_BOM.GetString("MATKL");
                    child.WLDL = tb_ET_BOM.GetString("WLDL");
                    child.DCXH = tb_ET_BOM.GetString("DCXH");
                    child.DCDJ = tb_ET_BOM.GetString("DCDJ");
                    child.ZSBS = tb_ET_BOM.GetString("ZSBS");
                    child.SOBKZ = tb_ET_BOM.GetString("SOBKZ");
                    child.KDAUF = ZHMUN(tb_ET_BOM.GetString("KDAUF"));
                    child.KDPOS = ZHMUN(tb_ET_BOM.GetString("KDPOS"));
                    child.AUFNR = tb_ET_BOM.GetString("AUFNR").TrimStart('0');
                    child.DEL = tb_ET_BOM.GetString("DEL");
                    child_ET_BOM.Add(child);
                }

                rst.ET_BOM = child_ET_BOM;


                IRfcTable tb_ET_RT = func.GetTable("ET_RT");
                for (int i = 0; i < tb_ET_RT.RowCount; i++)
                {
                    tb_ET_RT.CurrentIndex = i;
                    ZSL_BCST302_R child = new ZSL_BCST302_R();
                    child.AUFPL = tb_ET_RT.GetString("AUFPL");
                    child.VORNR = tb_ET_RT.GetString("VORNR");
                    child.ARBPL = tb_ET_RT.GetString("ARBPL");
                    child.LTXA1 = tb_ET_RT.GetString("LTXA1");
                    child.WERKS = tb_ET_RT.GetString("WERKS");
                    child.AUFNR = tb_ET_RT.GetString("AUFNR").TrimStart('0');
                    child_ET_RT.Add(child);
                }
                rst.ET_RT = child_ET_RT;



                IRfcTable table_MES_RETURN = func.GetTable("CT_RETURN");
                table_MES_RETURN.CurrentIndex = 0;
                child_MES_RETURN.TYPE = table_MES_RETURN.GetString("TYPE");
                child_MES_RETURN.MESSAGE = table_MES_RETURN.GetString("MESSAGE");
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

        public ZBCFUN_GDLIST_READ GET_GDLIST_1(string IV_WERKS, string IV_GZZX, string IV_WLDL, string IV_AUFNR, string LOW, string HIGH)
        {
            ZBCFUN_GDLIST_READ rst = new ZBCFUN_GDLIST_READ();
            List<ZSL_BCST024_PO> child_ET_POLIST = new List<ZSL_BCST024_PO>();
            List<ZSL_BCS302_B> child_ET_BOM = new List<ZSL_BCS302_B>();
            List<ZSL_BCST302_R> child_ET_RT = new List<ZSL_BCST302_R>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            IRfcFunction func = RFC.Function("ZBCFUN_GDLIST_READ_1");
            func.SetValue("IV_WERKS", IV_WERKS);
            func.SetValue("IV_GZZX", IV_GZZX);
            func.SetValue("IV_WLDL", IV_WLDL);
            func.SetValue("IV_AUFNR", IV_AUFNR);
            IRfcStructure irfcstruc = func.GetStructure("IS_DATE");
            irfcstruc.SetValue("SIGN", "I");
            irfcstruc.SetValue("OPTION", "BT");
            irfcstruc.SetValue("LOW", LOW);
            irfcstruc.SetValue("HIGH", HIGH);
            func.SetValue("IS_DATE", irfcstruc);

            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("ET_POLIST");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    ZSL_BCST024_PO child = new ZSL_BCST024_PO();
                    child.AUFNR = Convert.ToInt64(table.GetString("AUFNR")).ToString();
                    child.WERKS = table.GetString("WERKS");
                    child.MATNR = Convert.ToInt64(table.GetString("MATNR")).ToString();
                    child.MAKTX = table.GetString("MAKTX");
                    child.MATKL = table.GetString("MATKL");
                    child.WLDL = table.GetString("WLDL");
                    child.DCXH = table.GetString("DCXH");
                    child.DCDJ = table.GetString("DCDJ");
                    child.PSMNG = table.GetString("PSMNG");
                    child.AMEIN = table.GetString("AMEIN");
                    child.WEMNG = table.GetString("WEMNG");
                    child.KDAUF = table.GetString("KDAUF");
                    child.KDPOS = table.GetString("KDPOS");
                    child.GSTRP = table.GetString("GSTRP");
                    child.GLTRP = table.GetString("GLTRP");
                    child.ARBPL = table.GetString("ARBPL");
                    child.LTXA1 = table.GetString("LTXA1");
                    child.BSTDK = table.GetString("BSTDK");
                    child.RSNUM = table.GetString("RSNUM");
                    child.AUFPL = table.GetString("AUFPL");
                    child.OBJNR = table.GetString("OBJNR");
                    child.STAT = table.GetString("STAT");
                    child.DEL = table.GetString("DEL");
                    child.CHARG = table.GetString("CHARG");
                    if (child.KDAUF != "")
                    {
                        child.KDAUF = Convert.ToInt32(child.KDAUF).ToString();
                    }
                    if (child.KDPOS != "")
                    {
                        child.KDPOS = Convert.ToInt32(child.KDPOS).ToString();
                        if (child.KDPOS == "0")
                        {
                            child.KDPOS = "";
                        }
                    }
                    if (child.KDAUF == "")
                    {
                        string xxnobill = table.GetString("WEMPF");
                        if (xxnobill != "")
                        {
                            string[] xxnobilllist = xxnobill.Split('-');
                            if (xxnobilllist.Length > 1)
                            {
                                child.KDAUF = xxnobilllist[0];
                                child.KDPOS = xxnobilllist[1];
                            }
                        }
                    }
                    child_ET_POLIST.Add(child);
                }
                rst.ET_POLIST = child_ET_POLIST;


                IRfcTable tb_ET_BOM = func.GetTable("ET_BOM");
                for (int i = 0; i < tb_ET_BOM.RowCount; i++)
                {
                    tb_ET_BOM.CurrentIndex = i;
                    ZSL_BCS302_B child = new ZSL_BCS302_B();
                    child.RSNUM = tb_ET_BOM.GetString("RSNUM");
                    child.RSPOS = tb_ET_BOM.GetString("RSPOS");
                    child.POSTP = tb_ET_BOM.GetString("POSTP");
                    child.POSNR = tb_ET_BOM.GetString("POSNR");
                    child.STLTY = tb_ET_BOM.GetString("STLTY");
                    child.STLNR = tb_ET_BOM.GetString("STLNR");
                    child.STLKN = tb_ET_BOM.GetString("STLKN");
                    child.STPOZ = tb_ET_BOM.GetString("STPOZ");
                    string IDNRK = tb_ET_BOM.GetString("IDNRK");
                    if (IDNRK == "")
                    {
                        child.IDNRK = "";
                    }
                    else
                    {
                        child.IDNRK = Convert.ToInt64(IDNRK).ToString();
                    }
                    child.MAKTX = tb_ET_BOM.GetString("MAKTX");
                    child.WERKS = tb_ET_BOM.GetString("WERKS");
                    child.MENGE = tb_ET_BOM.GetString("MENGE");
                    child.MEINS = tb_ET_BOM.GetString("MEINS");
                    child.MATKL = tb_ET_BOM.GetString("MATKL");
                    child.WLDL = tb_ET_BOM.GetString("WLDL");
                    child.DCXH = tb_ET_BOM.GetString("DCXH");
                    child.DCDJ = tb_ET_BOM.GetString("DCDJ");
                    child.ZSBS = tb_ET_BOM.GetString("ZSBS");
                    child.SOBKZ = tb_ET_BOM.GetString("SOBKZ");
                    child.KDAUF = ZHMUN(tb_ET_BOM.GetString("KDAUF"));
                    child.KDPOS = ZHMUN(tb_ET_BOM.GetString("KDPOS"));
                    child.AUFNR = tb_ET_BOM.GetString("AUFNR").TrimStart('0');
                    child.DEL = tb_ET_BOM.GetString("DEL");
                    child_ET_BOM.Add(child);
                }

                rst.ET_BOM = child_ET_BOM;

                IRfcTable tb_ET_RT = func.GetTable("ET_RT");
                for (int i = 0; i < tb_ET_RT.RowCount; i++)
                {
                    tb_ET_RT.CurrentIndex = i;
                    ZSL_BCST302_R child = new ZSL_BCST302_R();
                    child.AUFPL = tb_ET_RT.GetString("AUFPL");
                    child.VORNR = tb_ET_RT.GetString("VORNR");
                    child.ARBPL = tb_ET_RT.GetString("ARBPL");
                    child.LTXA1 = tb_ET_RT.GetString("LTXA1");
                    child.WERKS = tb_ET_RT.GetString("WERKS");
                    child.AUFNR = tb_ET_RT.GetString("AUFNR").TrimStart('0');
                    child_ET_RT.Add(child);
                }
                rst.ET_RT = child_ET_RT;

                IRfcTable table_MES_RETURN = func.GetTable("CT_RETURN");
                table_MES_RETURN.CurrentIndex = 0;
                child_MES_RETURN.TYPE = table_MES_RETURN.GetString("TYPE");
                child_MES_RETURN.MESSAGE = table_MES_RETURN.GetString("MESSAGE");
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
        public ZBCFUN_CPBZ_READ get_CPBZ_READ(string IV_TPM)
        {
            ZBCFUN_CPBZ_READ rst = new ZBCFUN_CPBZ_READ();
            ZSL_BCS003 child_ES_HEADER = new ZSL_BCS003();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<ZSL_BCS302_B> child_ET_BOM = new List<ZSL_BCS302_B>();
            List<ZSL_BCST302_R> child_ET_RT = new List<ZSL_BCST302_R>();
            IRfcFunction func = RFC.Function("ZBCFUN_CPBZ_READ");
            func.SetValue("IV_TPM", IV_TPM);
            try
            {
                RFC.Invoke(func, false);

                IRfcTable tb_CT_RETURN = func.GetTable("CT_RETURN");
                tb_CT_RETURN.CurrentIndex = 0;
                child_MES_RETURN.TYPE = tb_CT_RETURN.GetString("TYPE");
                child_MES_RETURN.MESSAGE = tb_CT_RETURN.GetString("MESSAGE");

                if (child_MES_RETURN.TYPE != "E")
                {
                    IRfcStructure istruc = func.GetStructure("ES_HEADER");
                    child_ES_HEADER.TPM = istruc.GetString("TPM");
                    child_ES_HEADER.MATNR = ZHMUN(istruc.GetString("MATNR"));
                    child_ES_HEADER.CHARG = istruc.GetString("CHARG");
                    child_ES_HEADER.WERKS = istruc.GetString("WERKS");
                    child_ES_HEADER.LGORT = istruc.GetString("LGORT");
                    child_ES_HEADER.LGPLA = istruc.GetString("LGPLA");
                    child_ES_HEADER.SL = istruc.GetString("SL");
                    child_ES_HEADER.MEINS = istruc.GetString("MEINS");
                    child_ES_HEADER.ZL = istruc.GetString("ZL");
                    child_ES_HEADER.ERFME = istruc.GetString("ERFME");
                    child_ES_HEADER.CKDJH = istruc.GetString("CKDJH");
                    child_ES_HEADER.TMZT = istruc.GetString("TMZT");
                    child_ES_HEADER.MVT_IND = istruc.GetString("MVT_IND");
                    child_ES_HEADER.MOVE_TYPE = istruc.GetString("MOVE_TYPE");
                    child_ES_HEADER.FCODE = istruc.GetString("FCODE");
                    child_ES_HEADER.NLPLA = istruc.GetString("NLPLA");
                    child_ES_HEADER.TANUM = istruc.GetString("TANUM");
                    child_ES_HEADER.WLM = istruc.GetString("WLM");
                    child_ES_HEADER.SONUM = istruc.GetString("SONUM");
                    child_ES_HEADER.SOBKZ = istruc.GetString("SOBKZ");
                    child_ES_HEADER.BESTQ = istruc.GetString("BESTQ");
                    child_ES_HEADER.USERNAME = istruc.GetString("USERNAME");
                    child_ES_HEADER.LGNUM = istruc.GetString("LGNUM");
                    child_ES_HEADER.JHZ = istruc.GetString("JHZ");
                    child_ES_HEADER.MAKTX = istruc.GetString("MAKTX");
                    child_ES_HEADER.KDAUF = istruc.GetString("KDAUF");
                    child_ES_HEADER.KDPOS = istruc.GetString("KDPOS");
                    child_ES_HEADER.WLDL = istruc.GetString("WLDL");
                    if (child_ES_HEADER.CKDJH != "")
                    {
                        child_ES_HEADER.CKDJH = Convert.ToInt64(child_ES_HEADER.CKDJH).ToString();
                    }

                    IRfcTable tb_ET_RT = func.GetTable("ET_RT");
                    for (int i = 0; i < tb_ET_RT.RowCount; i++)
                    {
                        tb_ET_RT.CurrentIndex = i;
                        ZSL_BCST302_R child = new ZSL_BCST302_R();
                        child.AUFPL = tb_ET_RT.GetString("AUFPL");
                        child.VORNR = tb_ET_RT.GetString("VORNR");
                        child.ARBPL = tb_ET_RT.GetString("ARBPL");
                        child.LTXA1 = tb_ET_RT.GetString("LTXA1");
                        child_ET_RT.Add(child);
                    }

                    IRfcTable tb_ET_BOM = func.GetTable("ET_BOM");
                    for (int i = 0; i < tb_ET_BOM.RowCount; i++)
                    {
                        tb_ET_BOM.CurrentIndex = i;
                        ZSL_BCS302_B child = new ZSL_BCS302_B();
                        child.RSNUM = tb_ET_BOM.GetString("RSNUM");
                        child.RSPOS = tb_ET_BOM.GetString("RSPOS");
                        child.POSTP = tb_ET_BOM.GetString("POSTP");
                        child.POSNR = tb_ET_BOM.GetString("POSNR");
                        child.STLTY = tb_ET_BOM.GetString("STLTY");
                        child.STLNR = tb_ET_BOM.GetString("STLNR");
                        child.STLKN = tb_ET_BOM.GetString("STLKN");
                        child.STPOZ = tb_ET_BOM.GetString("STPOZ");
                        string IDNRK = tb_ET_BOM.GetString("IDNRK");
                        if (IDNRK == "")
                        {
                            child.IDNRK = "";
                        }
                        else
                        {
                            child.IDNRK = Convert.ToInt64(IDNRK).ToString();
                        }
                        //child.IDNRK = Convert.ToInt64(tb_ET_BOM.GetString("IDNRK")).ToString();
                        child.MAKTX = tb_ET_BOM.GetString("MAKTX");
                        child.WERKS = tb_ET_BOM.GetString("WERKS");
                        child.MENGE = tb_ET_BOM.GetString("MENGE");
                        child.MEINS = tb_ET_BOM.GetString("MEINS");
                        child.MATKL = tb_ET_BOM.GetString("MATKL");
                        child.WLDL = tb_ET_BOM.GetString("WLDL");
                        child.DCXH = tb_ET_BOM.GetString("DCXH");
                        child.DCDJ = tb_ET_BOM.GetString("DCDJ");
                        child.ZSBS = tb_ET_BOM.GetString("ZSBS");
                        child.SOBKZ = tb_ET_BOM.GetString("SOBKZ");
                        child.KDAUF = ZHMUN(tb_ET_BOM.GetString("KDAUF"));
                        child.KDPOS = ZHMUN(tb_ET_BOM.GetString("KDPOS"));
                        child_ET_BOM.Add(child);
                    }
                }
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.ES_HEADER = child_ES_HEADER;
            rst.ET_RT = child_ET_RT;
            rst.ET_BOM = child_ET_BOM;
            return rst;
        }


        public ZBCFUN_PURBS_READ GET_PURBS_READ(string IV_FCODE, ZSL_BCS303_CT IS_PURCT, ZSL_BCS303_BS IS_PURBS)
        {
            ZBCFUN_PURBS_READ rst = new ZBCFUN_PURBS_READ();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<ZSL_BCS303_BS> child_ET_PURBS = new List<ZSL_BCS303_BS>();
            IRfcFunction func = RFC.Function("ZBCFUN_PURBS_READ");
            func.SetValue("IV_FCODE", IV_FCODE);
            if (IV_FCODE == "C01")
            {
                IRfcStructure irfcstruc = func.GetStructure("IS_PURCT");
                irfcstruc.SetValue("WERKS", IS_PURCT.WERKS);
                irfcstruc.SetValue("LGORT", IS_PURCT.LGORT);
                irfcstruc.SetValue("MBLNR", IS_PURCT.MBLNR);
                irfcstruc.SetValue("MJAHR", IS_PURCT.MJAHR);
                irfcstruc.SetValue("ZEILE", IS_PURCT.ZEILE);
                irfcstruc.SetValue("EBELN", IS_PURCT.EBELN);
                irfcstruc.SetValue("EBELP", IS_PURCT.EBELP);
                irfcstruc.SetValue("MATNR", IS_PURCT.MATNR);
                irfcstruc.SetValue("CHARG", IS_PURCT.CHARG);
                irfcstruc.SetValue("LIFNR", IS_PURCT.LIFNR);
                irfcstruc.SetValue("BUDAT_ST", IS_PURCT.BUDAT_ST);
                irfcstruc.SetValue("BUDAT_ED", IS_PURCT.BUDAT_ED);
                irfcstruc.SetValue("CPUDT_ST", IS_PURCT.CPUDT_ST);
                irfcstruc.SetValue("CPUDT_ED", IS_PURCT.CPUDT_ED);
                irfcstruc.SetValue("CPUTM_ST", IS_PURCT.CPUTM_ST);
                irfcstruc.SetValue("CPUTM_ED", IS_PURCT.CPUTM_ED);
                irfcstruc.SetValue("DBBS", IS_PURCT.DBBS);
                func.SetValue("IS_PURCT", irfcstruc);
            }
            if (IV_FCODE == "C02")
            {
                IRfcStructure irfcstruc_IS_PURBS = func.GetStructure("IS_PURBS");
                irfcstruc_IS_PURBS.SetValue("MBLNR", IS_PURBS.MBLNR);
                irfcstruc_IS_PURBS.SetValue("MJAHR", IS_PURBS.MJAHR);
                irfcstruc_IS_PURBS.SetValue("LINE_ID", IS_PURBS.LINE_ID);
                irfcstruc_IS_PURBS.SetValue("LIFNR", IS_PURBS.LIFNR);
                irfcstruc_IS_PURBS.SetValue("XCBS", IS_PURBS.XCBS);
                irfcstruc_IS_PURBS.SetValue("DBBS", IS_PURBS.DBBS);
                func.SetValue("IS_PURBS", irfcstruc_IS_PURBS);
            }

            try
            {
                RFC.Invoke(func, false);

                IRfcTable tb_CT_RETURN = func.GetTable("CT_RETURN");
                tb_CT_RETURN.CurrentIndex = 0;
                child_MES_RETURN.TYPE = tb_CT_RETURN.GetString("TYPE");
                child_MES_RETURN.MESSAGE = tb_CT_RETURN.GetString("MESSAGE");

                if (child_MES_RETURN.TYPE != "E")
                {
                    IRfcTable table_ET_PURBS = func.GetTable("ET_PURBS");
                    for (int i = 0; i < table_ET_PURBS.RowCount; i++)
                    {
                        table_ET_PURBS.CurrentIndex = i;
                        ZSL_BCS303_BS child = new ZSL_BCS303_BS();
                        child.MBLNR = table_ET_PURBS.GetString("MBLNR");
                        child.MJAHR = table_ET_PURBS.GetString("MJAHR");
                        child.ZEILE = table_ET_PURBS.GetString("ZEILE");
                        child.LINE_ID = ZHMUN(table_ET_PURBS.GetString("LINE_ID"));
                        child.MATNR = table_ET_PURBS.GetString("MATNR").TrimStart('0');
                        child.MAKTX = table_ET_PURBS.GetString("MAKTX");
                        child.MATKL = table_ET_PURBS.GetString("MATKL");
                        child.WLDL = table_ET_PURBS.GetString("WLDL");
                        child.MTART = table_ET_PURBS.GetString("MTART");
                        child.DCXH = table_ET_PURBS.GetString("DCXH");
                        child.DCDJ = table_ET_PURBS.GetString("DCDJ");
                        child.WERKS = table_ET_PURBS.GetString("WERKS");
                        child.LGORT = table_ET_PURBS.GetString("LGORT");
                        child.LGOBE = table_ET_PURBS.GetString("LGOBE");
                        child.EBELN = table_ET_PURBS.GetString("EBELN");
                        child.EBELP = table_ET_PURBS.GetString("EBELP");
                        if (child.EBELP != "")
                        {
                            child.EBELP = Convert.ToInt32(child.EBELP).ToString();
                            if (child.EBELP == "0")
                            {
                                child.EBELP = "";
                            }
                        }
                        child.CHARG = table_ET_PURBS.GetString("CHARG");
                        child.LICHA = table_ET_PURBS.GetString("LICHA");
                        child.LIFNR = ZHMUN(table_ET_PURBS.GetString("LIFNR"));
                        child.SORTL = table_ET_PURBS.GetString("SORTL");
                        child.BUDAT = table_ET_PURBS.GetString("BUDAT");
                        child.WWBS = table_ET_PURBS.GetString("WWBS");
                        child.ZSBS = table_ET_PURBS.GetString("ZSBS");
                        child.XCBS = table_ET_PURBS.GetString("XCBS");
                        child.GY = table_ET_PURBS.GetString("GY");
                        child.SBH = table_ET_PURBS.GetString("SBH");
                        child.CLCJ = table_ET_PURBS.GetString("CLCJ");
                        child.XS = Convert.ToInt32(Convert.ToDouble(table_ET_PURBS.GetString("XS")));
                        child.MENGE = Convert.ToDecimal(table_ET_PURBS.GetString("MENGE")).ToString();
                        child.MEINS = table_ET_PURBS.GetString("MEINS");
                        child.MAT_KDAUF = ZHMUN(table_ET_PURBS.GetString("MAT_KDAUF"));
                        child.MAT_KDPOS = ZHMUN(table_ET_PURBS.GetString("MAT_KDPOS"));
                        child.WEMPF = table_ET_PURBS.GetString("WEMPF");
                        child.QSTH = "1";
                        child.TS = 1;
                        child_ET_PURBS.Add(child);
                    }
                }
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.ET_PURBS = child_ET_PURBS;
            return rst;
        }







        public ZBCFUN_XFPC_READ GET_XFPC_READ(string IV_WERKS, string IV_MATNR)
        {
            ZBCFUN_XFPC_READ rst = new ZBCFUN_XFPC_READ();
            List<ZSL_BCS304> child_ET_CHARG = new List<ZSL_BCS304>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            IRfcFunction func = RFC.Function("ZBCFUN_XFPC_READ");
            func.SetValue("IV_WERKS", IV_WERKS);
            func.SetValue("IV_MATNR", IV_MATNR);
            try
            {
                RFC.Invoke(func, false);

                IRfcTable tb_CT_RETURN = func.GetTable("CT_RETURN");
                tb_CT_RETURN.CurrentIndex = 0;
                child_MES_RETURN.TYPE = tb_CT_RETURN.GetString("TYPE");
                child_MES_RETURN.MESSAGE = tb_CT_RETURN.GetString("MESSAGE");

                if (child_MES_RETURN.TYPE != "E")
                {
                    IRfcTable table_ET_CHARG = func.GetTable("ET_CHARG");
                    for (int i = 0; i < table_ET_CHARG.RowCount; i++)
                    {
                        table_ET_CHARG.CurrentIndex = i;
                        ZSL_BCS304 child = new ZSL_BCS304();
                        child.CHARG = table_ET_CHARG.GetString("CHARG");
                        child.LICHA = table_ET_CHARG.GetString("LICHA");
                        child.LIFNR = table_ET_CHARG.GetString("LIFNR");
                        child.SORTL = table_ET_CHARG.GetString("SORTL");
                        child.ERSDA = table_ET_CHARG.GetString("ERSDA");
                        child.CLABS = table_ET_CHARG.GetString("CLABS");
                        child.QPLOS = table_ET_CHARG.GetString("QPLOS");
                        child.MATNR = table_ET_CHARG.GetString("MATNR").TrimStart('0');
                        child.WERKS = table_ET_CHARG.GetString("WERKS");
                        child.LGORT = table_ET_CHARG.GetString("LGORT");
                        child_ET_CHARG.Add(child);
                    }
                }
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.ET_CHARG = child_ET_CHARG;
            return rst;
        }




        public string ZHMUN(string str)
        {
            if (str != "")
            {
                str = Convert.ToInt64(str).ToString();
                if (str == "0")
                {
                    str = "";
                }
            }
            return str;
        }
    }
}

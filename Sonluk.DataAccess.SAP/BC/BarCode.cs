using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using Sonluk.DataAccess.SAP.Utility;
using Sonluk.IDataAccess.BC;
using Sonluk.Entities.BC;
using Sonluk.Entities.CRM;
using Sonluk.Entities.MES;

namespace Sonluk.DataAccess.SAP.BC
{
    public class BarCode : IBarCode
    {
        public string ZBCFUN_TBM_ZFTH(string srwlm, string tgwlm, string fcode)
        {
            IRfcFunction func = RFC.Function("ZBCFUN_TBM_ZFTH");
            func.SetValue("IV_SRWLM", srwlm);
            func.SetValue("IV_TGWLM", tgwlm);
            func.SetValue("IV_FCODE", fcode);

            string code = "";
            try
            {
                RFC.Invoke(func, true);
                //IRfcStructure struc = func.GetStructure("ET_RETURN");
                //code = struc.GetString("MESSAGE");
                IRfcTable table = func.GetTable("ET_RETURN");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    code = table.GetString("MESSAGE");
                }
            }
            catch (Exception e)
            {
                code = e.Message;
                throw new ApplicationException(e.Message);
            }

            return code;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IV_MATNR"></param>
        /// <param name="IV_MTART"></param>
        /// <param name="IV_DATUM"></param>
        /// <returns></returns>
        public ZSL_BCS007 ZBCFUN_MAT_GET(string IV_MATNR, string IV_MTART, string IV_DATUM)
        {
            IRfcFunction func = RFC.Function("ZBCFUN_MAT_GET");

            IV_MATNR = IV_MATNR.Trim();
            IV_MATNR = IV_MATNR.PadLeft(18, '0');

            func.SetValue("IV_MATNR", IV_MATNR);
            if (IV_MTART.Trim() != "")
            {
                func.SetValue("IV_MTART", IV_MTART);
            }
            if (IV_DATUM.Trim() != "")
            {
                func.SetValue("IV_DATUM", IV_DATUM);
            }
            func.SetValue("IV_ZSBS", "");

            ZSL_BCS007 rtn = new ZSL_BCS007();
            try
            {
                RFC.Invoke(func, true);
                //IRfcStructure struc = func.GetStructure("ET_RETURN");
                //code = struc.GetString("MESSAGE");
                IRfcTable table = func.GetTable("ET_MATS");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    rtn.Matnr = table.GetString("MATNR");
                    rtn.Maktx = table.GetString("MAKTX");
                    rtn.Mtart = table.GetString("MTART");
                    rtn.Zpar = table.GetInt("ZPAR");
                    rtn.Zbon = table.GetInt("ZBON");
                    rtn.Zpks = table.GetInt("ZPKS");
                    rtn.Zpcs = table.GetInt("ZPCS");
                    rtn.Zzsbs = table.GetString("ZZSBS");
                    rtn.Zltbs = table.GetString("ZLTBS");
                }
            }
            catch (Exception e)
            {
                rtn.Maktx = e.Message;
                throw new ApplicationException(e.Message);
            }

            return rtn;
        }

        public PickingtaskInfo ZBCFUN_CKGDP_DISPLAY(string IV_CJRQ, string IV_LGNUM)
        {
            IRfcFunction func = RFC.Function("ZBCFUN_CKGDP_DISPLAY");

            if (IV_CJRQ.Trim() != "")
            {
                func.SetValue("IV_CJRQ", IV_CJRQ);
            }

            if (IV_LGNUM.Trim() != "")
            {
                func.SetValue("IV_LGNUM", IV_LGNUM);
            }

            PickingtaskInfo rtn = new PickingtaskInfo();
            List<ZSL_BCST106> children = new List<ZSL_BCST106>();
            try
            {
                RFC.Invoke(func, true);

                rtn.Ev_ljs = func.GetInt("EV_LJS");
                rtn.Ev_ywcs = func.GetInt("EV_YWCS");

                IRfcTable table = func.GetTable("ET_T106");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;

                    ZSL_BCST106 node = new ZSL_BCST106();
                    node.Lgnum = table.GetString("LGNUM");
                    node.Jpd = table.GetString("JPD");
                    node.Yzf = table.GetString("YZF");
                    node.Jjbz = table.GetString("JJBZ");
                    node.Sdfdz = table.GetString("SDFDZ");
                    node.Lxr = table.GetString("LXR");
                    node.Slhj = table.GetString("SLHJ");
                    node.Jdzs = table.GetString("JDZS");
                    node.Ywc = table.GetString("YWC");
                    node.Ztzs = table.GetString("ZTZS");
                    node.Xgr = table.GetString("XGR");
                    children.Add(node);
                }

                rtn.Zsl_bcs106 = children;
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return rtn;
        }

        public IList<ZSL_BCS107> ZBCFUN_LTPM_READ(string IV_LGNUM, string IV_JPD, string IV_CJRQ_S, string IV_CJRQ_E, string IV_VBELN)
        {
            IRfcFunction func = RFC.Function("ZBCFUN_LTPM_READ");

            if (IV_LGNUM.Trim() != "")
            {
                func.SetValue("IV_LGNUM", IV_LGNUM);
            }

            if (IV_JPD.Trim() != "")
            {
                func.SetValue("IV_JPD", IV_JPD);
            }

            if (IV_CJRQ_S.Trim() != "")
            {
                func.SetValue("IV_CJRQ_S", IV_CJRQ_S);
            }

            if (IV_CJRQ_E.Trim() != "")
            {
                func.SetValue("IV_CJRQ_E", IV_CJRQ_E);
            }

            if (IV_VBELN.Trim() != "")
            {
                func.SetValue("IV_VBELN", IV_VBELN);
            }

            List<ZSL_BCS107> children = new List<ZSL_BCS107>();
            try
            {
                RFC.Invoke(func, true);

                IRfcTable table = func.GetTable("ET_LTPM");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;

                    ZSL_BCS107 node = new ZSL_BCS107();
                    node.Lgnum = table.GetString("LGNUM");
                    node.Jpd = table.GetLong("JPD").ToString();
                    node.Ywc = table.GetString("YWC");
                    node.Ltbs = table.GetString("LTBS");
                    node.Vbeln = table.GetString("VBELN");
                    node.Lxr = table.GetString("LXR");
                    node.Jjbz = table.GetString("JJBZ");
                    node.Lnumt = table.GetString("LNUMT");
                    node.Kunnr = table.GetString("KUNNR");
                    node.Sdfmc = table.GetString("SDFMC");
                    node.Sdfdz = table.GetString("SDFDZ");
                    node.Lxr = table.GetString("LXR");
                    node.Lxfs = table.GetString("LXFS");
                    children.Add(node);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return children;
        }

        public TrackInfo ZBCFUN_WLZS_READ(string IV_WLM)
        {
            IRfcFunction func = RFC.Function("ZBCFUN_WLZS_READ");

            IV_WLM = IV_WLM.Trim();

            func.SetValue("IV_WLM", IV_WLM);

            TrackInfo rtn = new TrackInfo();

            try
            {
                RFC.Invoke(func, true);
                //IRfcStructure struc = func.GetStructure("ET_RETURN");
                //code = struc.GetString("MESSAGE");
                IRfcStructure struc = func.GetStructure("ES_109");
                ZSL_BCS109 rtn_es109 = new ZSL_BCS109();

                rtn_es109.Wlm = struc.GetString("WLM");
                rtn_es109.Matnr = struc.GetString("MATNR");
                rtn_es109.Maktx = struc.GetString("MAKTX");
                rtn_es109.Sdfmc = struc.GetString("SDFMC");
                rtn_es109.Sdfdz = struc.GetString("SDFDZ");
                rtn_es109.Lgnum = struc.GetString("LGNUM");

                rtn_es109.Jpd = struc.GetString("JPD");
                rtn_es109.Jpdxm = struc.GetString("JPDXM");
                rtn_es109.Phy = struc.GetString("PHY");
                rtn_es109.Phrq = struc.GetString("PHRQ");
                rtn_es109.Phsj = struc.GetString("PHSJ");

                rtn.ES_109 = rtn_es109;

                IRfcTable table = func.GetTable("ET_RETURN");
                List<ZSL_BCST100> children = new List<ZSL_BCST100>();
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    ZSL_BCST100 node = new ZSL_BCST100();
                    node.Type = table.GetString("TYPE");
                    node.Id = table.GetString("ID");
                    node.Number = table.GetString("NUMBER");
                    node.Message = table.GetString("MESSAGE");
                    node.Log_no = table.GetString("LOG_NO");
                    node.Log_msg_no = table.GetString("LOG_MSG_NO");
                    node.Message_v1 = table.GetString("MESSAGE_V1");
                    node.Message_v2 = table.GetString("MESSAGE_V2");
                    node.Message_v3 = table.GetString("MESSAGE_V3");
                    node.Message_v4 = table.GetString("MESSAGE_V4");
                    node.Parameter = table.GetString("PARAMETER");
                    node.Row = table.GetString("ROW");
                    node.Field = table.GetString("FIELD");
                    node.System = table.GetString("SYSTEM");

                    children.Add(node);
                }

                rtn.ET_RETURN = children;
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return rtn;
        }

        public RktjInfo ZBCFUN_RKTJ_READ(string IV_START, string IV_END)
        {
            IRfcFunction func = RFC.Function("ZBCFUN_RKTJ_READ");

            if (IV_START.Trim() != "")
            {
                func.SetValue("IV_START", IV_START);
            }

            if (IV_END.Trim() != "")
            {
                func.SetValue("IV_END", IV_END);
            }

            RktjInfo rtn = new RktjInfo();




            List<ZSL_BCST108> children = new List<ZSL_BCST108>();
            try
            {
                RFC.Invoke(func, true);

                IRfcTable table1 = func.GetTable("ET_TTXX");
                List<ZSL_BCST108> children1 = new List<ZSL_BCST108>();
                for (int i = 0; i < table1.RowCount; i++)
                {
                    table1.CurrentIndex = i;
                    ZSL_BCST108 node = new ZSL_BCST108();
                    node.Ywlx = table1.GetString("YWLX");
                    node.Tgf = table1.GetString("TGF");
                    node.Msxx = table1.GetString("MSXX");
                    node.Lgnum = table1.GetString("LGNUM");
                    node.Lnumt = table1.GetString("LNUMT");
                    node.Jdbz = table1.GetString("JDBZ");
                    node.Rksl = table1.GetString("RKSL");
                    node.Rkts = table1.GetString("RKTS");
                    node.Tpm = table1.GetString("TPM");
                    node.Zhm = table1.GetString("ZHM");
                    node.Ckdjh = table1.GetString("CKDJH");
                    node.Zj = table1.GetString("ZJ");
                    children1.Add(node);
                }

                rtn.ET_TTXX = children1;

                IRfcTable table = func.GetTable("ET_MXXX");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;

                    ZSL_BCST108 node = new ZSL_BCST108();
                    node.Ywlx = table.GetString("YWLX");
                    node.Tgf = table.GetString("TGF");
                    node.Msxx = table.GetString("MSXX");
                    node.Lgnum = table.GetString("LGNUM");
                    node.Lnumt = table.GetString("LNUMT");
                    node.Jdbz = table.GetString("JDBZ");
                    node.Rksl = table.GetString("RKSL");
                    node.Rkts = table.GetString("RKTS");
                    node.Tpm = table.GetString("TPM");
                    node.Zhm = table.GetString("ZHM");
                    node.Ckdjh = table.GetString("CKDJH");
                    node.Zj = table.GetString("ZJ");
                    children.Add(node);
                }

                rtn.ET_MXXX = children;
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return rtn;
        }

        /// <summary>
        /// 交货单查询
        /// </summary>
        /// <param name="I_VBELN"></param>
        /// <returns></returns>
        public DeliveryNoteInfo ZSD_JH_READ(string I_VBELN, string I_UNAME)
        {
            IRfcFunction func = RFC.Function("ZSD_JH_READ");

            I_VBELN = I_VBELN.Trim();

            func.SetValue("I_VBELN", I_VBELN);
            func.SetValue("I_UNAME", I_UNAME);

            DeliveryNoteInfo rtn = new DeliveryNoteInfo();

            try
            {
                RFC.Invoke(func, true);
                //IRfcStructure struc = func.GetStructure("ET_RETURN");
                //code = struc.GetString("MESSAGE");
                rtn.O_MESSAGE = func.GetString("O_MESSAGE");
                IRfcStructure struc = func.GetStructure("O_JH");
                ZSL_SDS011 o_jh = new ZSL_SDS011();

                o_jh.Kunag = struc.GetString("KUNAG");
                o_jh.Kunnr = struc.GetString("KUNNR");
                o_jh.Lgobe = struc.GetString("LGOBE");
                o_jh.Lgort = struc.GetString("LGORT");
                o_jh.Name1 = struc.GetString("NAME1");
                o_jh.Name2 = struc.GetString("NAME2");
                o_jh.Street_d = struc.GetString("STREET_D");
                o_jh.Vbeln = struc.GetString("VBELN");
                o_jh.Vgbel = struc.GetString("VGBEL");
                o_jh.Werks = struc.GetString("WERKS");
                o_jh.Zzecom_p = struc.GetString("ZZECOM_P");
                o_jh.Zzht = struc.GetString("ZZHT");

                rtn.O_jh = o_jh;

                IRfcTable table = func.GetTable("T_JH");
                List<ZSL_SDS012> children = new List<ZSL_SDS012>();
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    ZSL_SDS012 node = new ZSL_SDS012();
                    node.Arktx = table.GetString("ARKTX");
                    node.D_kwert = table.GetString("D_KWERT");
                    node.Hsje = table.GetString("HSJE");
                    node.Klmeng = table.GetString("KLMENG");
                    node.Lgmng = table.GetString("LGMNG");
                    node.Lgmng_c_je = table.GetString("LGMNG_C_JE");
                    node.Matnr = table.GetString("MATNR");
                    node.Meins = table.GetString("MEINS");
                    node.Mwsbp = table.GetString("MWSBP");
                    node.Netwr = table.GetString("NETWR");
                    node.Vgbel = table.GetString("VGBEL");
                    node.Vgpos = table.GetString("VGPOS");

                    children.Add(node);
                }

                rtn.T_jh = children;
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return rtn;
        }

        public SalesOrderInfo ZSD_DD_READ(string I_VBELN, string I_UNAME)
        {
            IRfcFunction func = RFC.Function("ZSD_DD_READ");

            I_VBELN = I_VBELN.Trim();

            func.SetValue("I_VBELN", I_VBELN);
            func.SetValue("I_UNAME", I_UNAME);

            SalesOrderInfo rtn = new SalesOrderInfo();

            try
            {
                RFC.Invoke(func, true);

                ZSL_SDS013 t_dd = new ZSL_SDS013();
                IRfcTable table1 = func.GetTable("T_DD");

                List<ZSL_SDS013> children1 = new List<ZSL_SDS013>();

                for (int i = 0; i < table1.RowCount; i++)
                {
                    table1.CurrentIndex = i;
                    ZSL_SDS013 node = new ZSL_SDS013();

                    node.Fklmg = table1.GetString("FKLMG");
                    node.Hsje = table1.GetString("HSJE");
                    node.Kalab = table1.GetString("KALAB");
                    node.Klmeng = table1.GetString("KLMENG");
                    node.Lgmng_c = table1.GetString("LGMNG_C");
                    node.Lgmng_c_je = table1.GetString("LGMNG_C_JE");
                    node.Posnr = table1.GetString("POSNR");
                    node.Vbeln = table1.GetString("VBELN");
                    node.Ykpje = table1.GetString("YKPJE");
                    node.Ztxt1 = table1.GetString("ZTXT1");
                    node.Meins = table1.GetString("MEINS");
                    node.Waerk = table1.GetString("WAERK");

                    children1.Add(node);
                }

                rtn.T_dd = children1;

                IRfcTable table2 = func.GetTable("T_DD_1");
                List<ZSL_SDS015> children2 = new List<ZSL_SDS015>();
                for (int i = 0; i < table2.RowCount; i++)
                {
                    table2.CurrentIndex = i;
                    ZSL_SDS015 node = new ZSL_SDS015();
                    node.Erdat = table2.GetString("ERDAT");
                    node.Posnr = table2.GetString("POSNR");
                    node.Vbeln = table2.GetString("VBELN");
                    node.Znum = table2.GetString("ZNUM");
                    node.Ztxt1 = table2.GetString("ZTXT1");

                    children2.Add(node);
                }

                rtn.T_dd_1 = children2;
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return rtn;
        }

        /// <summary>
        /// 销售出库统计
        /// </summary>
        /// <param name="I_VBELN"></param>
        /// <returns></returns>
        public CKInfo ZSD_CK_READ(string I_START, string I_END, string I_UNAME)
        {
            IRfcFunction func = RFC.Function("ZSD_CK_READ");

            I_START = I_START.Trim();
            I_END = I_END.Trim();

            func.SetValue("I_START", I_START);
            func.SetValue("I_END", I_END);
            func.SetValue("I_UNAME", I_UNAME);

            CKInfo rtn = new CKInfo();

            try
            {
                RFC.Invoke(func, true);

                IRfcTable table1 = func.GetTable("T_CK");
                List<ZSL_SDS014> children1 = new List<ZSL_SDS014>();
                for (int i = 0; i < table1.RowCount; i++)
                {
                    table1.CurrentIndex = i;
                    ZSL_SDS014 node = new ZSL_SDS014();
                    node.Arktx = table1.GetString("ARKTX");
                    node.Hsje = table1.GetString("HSJE");
                    node.Klmeng = table1.GetString("KLMENG");
                    node.Kwert = table1.GetString("KWERT");
                    node.Lgmng = table1.GetString("LGMNG");
                    node.Lgmng_c_je = table1.GetString("LGMNG_C_JE");
                    node.Matnr = table1.GetString("MATNR");
                    node.Meins = table1.GetString("MEINS");
                    node.Mwsbp = table1.GetString("MWSBP");
                    node.Netwr = table1.GetString("NETWR");
                    node.Posnr = table1.GetString("POSNR");
                    node.Shkzg = table1.GetString("SHKZG");
                    node.Vbeln = table1.GetString("VBELN");
                    node.Vgbel = table1.GetString("VGBEL");
                    node.Vgpos = table1.GetString("VGPOS");
                    node.Vkbur = table1.GetString("VKBUR");
                    node.Bezei = table1.GetString("BEZEI");
                    node.Vkgrp = table1.GetString("VKGRP");
                    node.Vkorg = table1.GetString("VKORG");
                    node.Bezei2 = table1.GetString("BEZEI2");
                    node.Vtweg = table1.GetString("VTWEG");
                    children1.Add(node);
                }

                rtn.T_ck = children1;

                IRfcTable table2 = func.GetTable("T_CK_Z");
                List<ZSL_SDS014> children2 = new List<ZSL_SDS014>();
                for (int i = 0; i < table2.RowCount; i++)
                {
                    table2.CurrentIndex = i;
                    ZSL_SDS014 node = new ZSL_SDS014();
                    node.Arktx = table2.GetString("ARKTX");
                    node.Hsje = table2.GetString("HSJE");
                    node.Klmeng = table2.GetString("KLMENG");
                    node.Kwert = table2.GetString("KWERT");
                    node.Lgmng = table2.GetString("LGMNG");
                    node.Lgmng_c_je = table2.GetString("LGMNG_C_JE");
                    node.Matnr = table2.GetString("MATNR");
                    node.Meins = table2.GetString("MEINS");
                    node.Mwsbp = table2.GetString("MWSBP");
                    node.Netwr = table2.GetString("NETWR");
                    node.Posnr = table2.GetString("POSNR");
                    node.Shkzg = table2.GetString("SHKZG");
                    node.Vbeln = table2.GetString("VBELN");
                    node.Vgbel = table2.GetString("VGBEL");
                    node.Vgpos = table2.GetString("VGPOS");
                    node.Vkbur = table2.GetString("VKBUR");
                    node.Bezei = table2.GetString("BEZEI");
                    node.Vkgrp = table2.GetString("VKGRP");
                    node.Vkorg = table2.GetString("VKORG");
                    node.Bezei2 = table2.GetString("BEZEI2");
                    node.Vtweg = table2.GetString("VTWEG");
                    children2.Add(node);
                }

                rtn.T_ck_z = children2;
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return rtn;
        }


        public TpmInfo ZBCFUN_TPM_READ(string IV_TPM)
        {
            IRfcFunction func = RFC.Function("ZBCFUN_TPM_READ");

            if (IV_TPM.Trim() != "")
            {
                func.SetValue("IV_TPM", IV_TPM);
            }

            TpmInfo rtn = new TpmInfo();
            List<ZSL_BCS205> children = new List<ZSL_BCS205>();
            try
            {
                RFC.Invoke(func, true);
                rtn.O_MESSAGE = func.GetString("O_MESSAGE");
                IRfcTable table = func.GetTable("ET_TPM");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;

                    ZSL_BCS205 node = new ZSL_BCS205();
                    node.Arbpl = table.GetString("ARBPL");
                    node.Charg = table.GetString("CHARG");
                    node.Ckdjh = table.GetString("CKDJH");
                    node.Ktext = table.GetString("KTEXT");
                    node.Lgort = table.GetString("LGORT");
                    node.Lgpla = table.GetString("LGPLA");
                    node.Maktx = table.GetString("MAKTX");
                    node.Matnr = table.GetString("MATNR");
                    node.Rklx = table.GetString("RKLX");
                    node.Sl = table.GetString("SL");
                    node.Sonum = table.GetString("SONUM");
                    node.Tmzt = table.GetString("TMZT");
                    node.Tpm = table.GetString("TPM");
                    node.Werks = table.GetString("WERKS");
                    children.Add(node);
                }

                rtn.Et_tpm = children;
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return rtn;
        }

        public GdInfo ZBCFUN_GD_READ(string IV_GD)
        {
            IRfcFunction func = RFC.Function("ZBCFUN_GD_READ");

            if (IV_GD.Trim() != "")
            {
                func.SetValue("IV_GD", IV_GD);
            }

            GdInfo rtn = new GdInfo();
            List<ZSL_BCS206> children = new List<ZSL_BCS206>();
            try
            {
                RFC.Invoke(func, true);
                rtn.O_MESSAGE = func.GetString("O_MESSAGE");
                IRfcTable table = func.GetTable("ET_GD");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;

                    ZSL_BCS206 node = new ZSL_BCS206();
                    node.Arbpl = table.GetString("ARBPL");
                    node.Aufnr = table.GetString("AUFNR");
                    node.Charg = table.GetString("CHARG");
                    node.Dwerk = table.GetString("DWERK");
                    node.Gdzt = table.GetString("GDZT");
                    node.Kdauf = table.GetString("KDAUF");
                    node.Kdpos = table.GetString("KDPOS");
                    node.Ktext = table.GetString("KTEXT");
                    node.Lgort = table.GetString("LGORT");
                    node.Ltrmi = table.GetString("LTRMI");
                    node.Maktx = table.GetString("MAKTX");
                    node.Matnr = table.GetString("MATNR");
                    node.Psmng = table.GetString("PSMNG");
                    node.Wemng = table.GetString("WEMNG");
                    children.Add(node);
                }

                rtn.Et_gd = children;
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return rtn;
        }

        public MODEL_ZBCFUN_CUS_GET GET_ZBCFUN_CUS_GET()
        {
            IRfcFunction func = RFC.Function("ZBCFUN_CUS_GET");
            MODEL_ZBCFUN_CUS_GET rtn = new MODEL_ZBCFUN_CUS_GET();
            List<ZSL_BCS009> children = new List<ZSL_BCS009>();
            List<ZSL_BCST100> child_ET_RETURN = new List<ZSL_BCST100>();
            try
            {
                RFC.Invoke(func, true);
                IRfcTable table = func.GetTable("ET_CUSS");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    ZSL_BCS009 node = new ZSL_BCS009();
                    node.KUNNR = table.GetString("KUNNR");
                    node.NAME1 = table.GetString("NAME1");
                    node.BEZEI = table.GetString("BEZEI");
                    node.ORT01 = table.GetString("ORT01");
                    children.Add(node);
                }
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                //child_ET_RETURN.TYPE = "E";
                //child_ET_RETURN.MESSAGE = e.Message;
                ZSL_BCST100 child = new ZSL_BCST100();
                child.Message = e.Message;
            }
            rtn.ET_CUSS = children;
            rtn.ET_RETURN = child_ET_RETURN;
            return rtn;
        }

        public MODEL_ZBCFUN_DLV_GET GET_ZBCFUN_DLV_GET(string IV_DATE, string IV_SYS)
        {
            IRfcFunction func = RFC.Function("ZBCFUN_DLV_GET");
            MODEL_ZBCFUN_DLV_GET rtn = new MODEL_ZBCFUN_DLV_GET();
            List<ZSL_BCST100> child_ET_RETURN = new List<ZSL_BCST100>();
            List<ZSL_BCS010> child_ET_TTXX = new List<ZSL_BCS010>();
            List<ZSL_BCS011> child_ET_HXMXX = new List<ZSL_BCS011>();
            func.SetValue("IV_DATE", IV_DATE.Trim());
            if (!string.IsNullOrWhiteSpace(IV_SYS))
            {
                func.SetValue("IV_SYS", IV_SYS.Trim());
            }
            try
            {
                RFC.Invoke(func, true);
                IRfcTable table_ET_RETURN = func.GetTable("ET_RETURN");
                for (int i = 0; i < table_ET_RETURN.RowCount; i++)
                {
                    table_ET_RETURN.CurrentIndex = i;
                    ZSL_BCST100 child = new ZSL_BCST100();
                    child.Message = table_ET_RETURN.GetString("MESSAGE");
                    child_ET_RETURN.Add(child);
                }
                IRfcTable table_ET_TTXX = func.GetTable("ET_TTXX");
                for (int i = 0; i < table_ET_TTXX.RowCount; i++)
                {
                    table_ET_TTXX.CurrentIndex = i;
                    ZSL_BCS010 node = new ZSL_BCS010();
                    node.VBELN = table_ET_TTXX.GetString("VBELN");
                    node.WERKS = table_ET_TTXX.GetString("WERKS");
                    node.POSNR = table_ET_TTXX.GetString("POSNR");
                    node.MATNR = table_ET_TTXX.GetString("MATNR");
                    node.KUNAG = table_ET_TTXX.GetString("KUNAG");
                    node.LGORT = table_ET_TTXX.GetString("LGORT");
                    node.WADAT_IST = table_ET_TTXX.GetString("WADAT_IST");
                    node.XGR = table_ET_TTXX.GetString("XGR");
                    child_ET_TTXX.Add(node);
                }
                IRfcTable table_ET_HXMXX = func.GetTable("ET_HXMXX");
                for (int i = 0; i < table_ET_HXMXX.RowCount; i++)
                {
                    table_ET_HXMXX.CurrentIndex = i;
                    ZSL_BCS011 node = new ZSL_BCS011();
                    node.VBELN = table_ET_HXMXX.GetString("VBELN");
                    node.POSNR = table_ET_HXMXX.GetString("POSNR");
                    node.TPM = table_ET_HXMXX.GetString("TPM");
                    node.DXM = table_ET_HXMXX.GetString("DXM");
                    node.NHM = table_ET_HXMXX.GetString("NHM");
                    node.CHARG = table_ET_HXMXX.GetString("CHARG");
                    node.LWEDT = table_ET_HXMXX.GetString("LWEDT");
                    node.QXBS = table_ET_HXMXX.GetString("QXBS");
                    child_ET_HXMXX.Add(node);
                }
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                ZSL_BCST100 child = new ZSL_BCST100();
                child.Message = e.Message;
                child_ET_RETURN.Add(child);
            }
            rtn.ET_RETURN = child_ET_RETURN;
            rtn.ET_TTXX = child_ET_TTXX;
            rtn.ET_HXMXX = child_ET_HXMXX;
            return rtn;
        }

        public MODEL_ZBCFUN_MAT_GET GET_ZBCFUN_MAT_GET(string IV_DATUM, string IV_MTART, string IV_MATNR, string IV_ZSBS)
        {
            MODEL_ZBCFUN_MAT_GET rtn = new MODEL_ZBCFUN_MAT_GET();
            List<ZSL_BCS007> child_ET_MATS = new List<ZSL_BCS007>();
            List<ZSL_BCST100> child_ET_RETURN = new List<ZSL_BCST100>();
            try
            {
                IRfcFunction func = RFC.Function("ZBCFUN_MAT_GET");
                if (IV_DATUM.Trim() != "")
                {
                    func.SetValue("IV_DATUM", IV_DATUM.Trim());
                }
                if (IV_MTART.Trim() != "")
                {
                    func.SetValue("IV_MTART", IV_MTART.Trim());
                }
                func.SetValue("IV_MATNR", IV_MATNR.Trim());
                if (IV_ZSBS.Trim() != "")
                {
                    func.SetValue("IV_ZSBS", IV_ZSBS.Trim());
                }
                RFC.Invoke(func, true);
                IRfcTable table_ET_MATS = func.GetTable("ET_MATS");
                for (int i = 0; i < table_ET_MATS.RowCount; i++)
                {
                    table_ET_MATS.CurrentIndex = i;
                    ZSL_BCS007 child = new ZSL_BCS007();
                    child.Matnr = table_ET_MATS.GetString("MATNR");
                    child.Maktx = table_ET_MATS.GetString("MAKTX");
                    child.Mtart = table_ET_MATS.GetString("MTART");
                    child.Zpar = table_ET_MATS.GetInt("ZPAR");
                    child.Zbon = table_ET_MATS.GetInt("ZBON");
                    child.Zpks = table_ET_MATS.GetInt("ZPKS");
                    child.Zpcs = table_ET_MATS.GetInt("ZPCS");
                    child.Zzsbs = table_ET_MATS.GetString("ZZSBS");
                    child.Zltbs = table_ET_MATS.GetString("ZLTBS");
                    child_ET_MATS.Add(child);
                }
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                ZSL_BCST100 child = new ZSL_BCST100();
                child.Message = e.Message;
                child_ET_RETURN.Add(child);
            }
            rtn.ET_MATS = child_ET_MATS;
            rtn.ET_RETURN = child_ET_RETURN;
            return rtn;
        }

        public MODEL_ZBCFUN_ORT_GET GET_ZBCFUN_ORT_GET()
        {
            IRfcFunction func = RFC.Function("ZBCFUN_ORT_GET");

            MODEL_ZBCFUN_ORT_GET rtn = new MODEL_ZBCFUN_ORT_GET();
            List<ZSL_BCS008> child_ET_ORTS = new List<ZSL_BCS008>();
            List<ZSL_BCST100> child_ET_RETURN = new List<ZSL_BCST100>();
            try
            {
                RFC.Invoke(func, true);
                IRfcTable table_ET_ORTS = func.GetTable("ET_ORTS");
                for (int i = 0; i < table_ET_ORTS.RowCount; i++)
                {
                    table_ET_ORTS.CurrentIndex = i;
                    ZSL_BCS008 child = new ZSL_BCS008();
                    child.WERKS = table_ET_ORTS.GetString("WERKS");
                    child.LGORT = table_ET_ORTS.GetString("LGORT");
                    child.LGOBE = table_ET_ORTS.GetString("LGOBE");
                    child_ET_ORTS.Add(child);
                }
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                ZSL_BCST100 child = new ZSL_BCST100();
                child.Message = e.Message;
                child_ET_RETURN.Add(child);
            }
            rtn.ET_ORTS = child_ET_ORTS;
            rtn.ET_RETURN = child_ET_RETURN;
            return rtn;
        }

        public MODEL_ZBCFUN_TM_READ GET_ZBCFUN_TM_READ(string IV_AUFNR, string IV_KZBEW)
        {
            MODEL_ZBCFUN_TM_READ rst = new MODEL_ZBCFUN_TM_READ();
            List<ZSL_BCT100> child_ZSL_BCT100 = new List<ZSL_BCT100>();
            RETURN_MSG child_RETURN_MSG = new RETURN_MSG();
            IRfcFunction func = RFC.Function("ZBCFUN_TM_READ");
            func.SetValue("IV_AUFNR", IV_AUFNR.Trim());
            if (!string.IsNullOrWhiteSpace(IV_KZBEW))
            {
                func.SetValue("IV_KZBEW", IV_KZBEW.Trim());
            }
            try
            {
                RFC.Invoke(func, true);
                IRfcTable tb_CT_RETURN = func.GetTable("CT_RETURN");
                tb_CT_RETURN.CurrentIndex = 0;
                child_RETURN_MSG.TYPE = tb_CT_RETURN.GetString("TYPE");
                child_RETURN_MSG.MESSAGE = tb_CT_RETURN.GetString("MESSAGE");

                IRfcTable table_ET_TM = func.GetTable("ET_TM");
                if (child_RETURN_MSG.TYPE == "S")
                {
                    for (int i = 0; i < table_ET_TM.RowCount; i++)
                    {
                        table_ET_TM.CurrentIndex = i;
                        ZSL_BCT100 child = new ZSL_BCT100();
                        child.NHM = table_ET_TM.GetString("NHM");
                        child.DXM = table_ET_TM.GetString("DXM");
                        child.TPM = table_ET_TM.GetString("TPM");
                        child.YZF = table_ET_TM.GetString("YZF");
                        child.CJRQ = table_ET_TM.GetString("CJRQ");
                        child.CJSJ = table_ET_TM.GetString("CJSJ");
                        child.CJR = table_ET_TM.GetString("CJR");
                        child.XGRQ = table_ET_TM.GetString("XGRQ");
                        child.XGSJ = table_ET_TM.GetString("XGSJ");
                        child.XGR = table_ET_TM.GetString("XGR");
                        child_ZSL_BCT100.Add(child);
                    }
                }
            }
            catch (Exception e)
            {
                child_RETURN_MSG.TYPE = "E";
                child_RETURN_MSG.MESSAGE = e.Message;
            }
            rst.ET_TM = child_ZSL_BCT100;
            rst.RETURN_MSG = child_RETURN_MSG;
            return rst;
        }

        public MODEL_ZBCFUN_THLOG_READ GET_ZBCFUN_THLOG_READ()
        {
            MODEL_ZBCFUN_THLOG_READ rst = new MODEL_ZBCFUN_THLOG_READ();
            List<ZSL_BCT108> child_ET_THLOG = new List<ZSL_BCT108>();
            RETURN_MSG child_RETURN_MSG = new RETURN_MSG();
            IRfcFunction func = RFC.Function("ZBCFUN_THLOG_READ");
            try
            {
                RFC.Invoke(func, true);
                IRfcTable tb_CT_RETURN = func.GetTable("CT_RETURN");
                tb_CT_RETURN.CurrentIndex = 0;
                child_RETURN_MSG.TYPE = tb_CT_RETURN.GetString("TYPE");
                child_RETURN_MSG.MESSAGE = tb_CT_RETURN.GetString("MESSAGE");

                IRfcTable table_ET_THLOG = func.GetTable("ET_THLOG");
                if (child_RETURN_MSG.TYPE == "S")
                {
                    for (int i = 0; i < table_ET_THLOG.RowCount; i++)
                    {
                        table_ET_THLOG.CurrentIndex = i;
                        ZSL_BCT108 child = new ZSL_BCT108();
                        child.TGWLM = table_ET_THLOG.GetString("TGWLM");
                        child.SRWLM = table_ET_THLOG.GetString("SRWLM");
                        child.CJRQ = table_ET_THLOG.GetString("CJRQ");
                        child.CJSJ = table_ET_THLOG.GetString("CJSJ");
                        child.CJR = table_ET_THLOG.GetString("CJR");
                        child.XGRQ = table_ET_THLOG.GetString("XGRQ");
                        child.XGSJ = table_ET_THLOG.GetString("XGSJ");
                        child.XGR = table_ET_THLOG.GetString("XGR");
                        child_ET_THLOG.Add(child);
                    }
                }
            }
            catch (Exception e)
            {
                child_RETURN_MSG.TYPE = "E";
                child_RETURN_MSG.MESSAGE = e.Message;
            }
            rst.ET_THLOG = child_ET_THLOG;
            rst.RETURN_MSG = child_RETURN_MSG;
            return rst;
        }


        public MODEL_ZBCFUN_DLV_GET GET_ZBCFUN_DLV_GET2(string KHmodeldata)
        {
            IRfcFunction func = RFC.Function("ZBCFUN_DLV_GET2");
            MODEL_ZBCFUN_DLV_GET rtn = new MODEL_ZBCFUN_DLV_GET();
            List<ZSL_BCST100> child_ET_RETURN = new List<ZSL_BCST100>();
            List<ZSL_BCS010> child_ET_TTXX = new List<ZSL_BCS010>();
            List<ZSL_BCS011> child_ET_HXMXX = new List<ZSL_BCS011>();
            IRfcTable struc1 = func.GetTable("ET_KH");
            CRM_KH_KH[] KHmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_KH[]>(KHmodeldata);
            for (int i = 0; i < KHmodel.Length; i++)
            {
                struc1.Insert();
                struc1.CurrentRow.SetValue("KUNNR", KHmodel[i].SAPSN);
            }
            func.SetValue("ET_KH", struc1);

            try
            {
                RFC.Invoke(func, true);
                IRfcTable table_ET_RETURN = func.GetTable("ET_RETURN");
                for (int i = 0; i < table_ET_RETURN.RowCount; i++)
                {
                    table_ET_RETURN.CurrentIndex = i;
                    ZSL_BCST100 child = new ZSL_BCST100();
                    child.Message = table_ET_RETURN.GetString("MESSAGE");
                    child_ET_RETURN.Add(child);
                }
                IRfcTable table_ET_TTXX = func.GetTable("ET_TTXX");
                for (int i = 0; i < table_ET_TTXX.RowCount; i++)
                {
                    table_ET_TTXX.CurrentIndex = i;
                    ZSL_BCS010 node = new ZSL_BCS010();
                    node.VBELN = table_ET_TTXX.GetString("VBELN");
                    node.WERKS = table_ET_TTXX.GetString("WERKS");
                    node.POSNR = table_ET_TTXX.GetString("POSNR");
                    node.MATNR = table_ET_TTXX.GetString("MATNR");
                    node.KUNAG = table_ET_TTXX.GetString("KUNAG");
                    node.LGORT = table_ET_TTXX.GetString("LGORT");
                    node.WADAT_IST = table_ET_TTXX.GetString("WADAT_IST");
                    node.XGR = table_ET_TTXX.GetString("XGR");
                    child_ET_TTXX.Add(node);
                }
                IRfcTable table_ET_HXMXX = func.GetTable("ET_HXMXX");
                for (int i = 0; i < table_ET_HXMXX.RowCount; i++)
                {
                    table_ET_HXMXX.CurrentIndex = i;
                    ZSL_BCS011 node = new ZSL_BCS011();
                    node.VBELN = table_ET_HXMXX.GetString("VBELN");
                    node.POSNR = table_ET_HXMXX.GetString("POSNR");
                    node.TPM = table_ET_HXMXX.GetString("TPM");
                    node.DXM = table_ET_HXMXX.GetString("DXM");
                    node.NHM = table_ET_HXMXX.GetString("NHM");
                    node.CHARG = table_ET_HXMXX.GetString("CHARG");
                    node.LWEDT = table_ET_HXMXX.GetString("LWEDT");
                    node.QXBS = table_ET_HXMXX.GetString("QXBS");
                    child_ET_HXMXX.Add(node);
                }
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                ZSL_BCST100 child = new ZSL_BCST100();
                child.Message = e.Message;
                child_ET_RETURN.Add(child);
            }
            rtn.ET_RETURN = child_ET_RETURN;
            rtn.ET_TTXX = child_ET_TTXX;
            rtn.ET_HXMXX = child_ET_HXMXX;
            return rtn;
        }



        public MODEL_ZBCFUN_POITEM_READ GET_ZBCFUN_POITEM_READ(string IV_EBELN, string IV_EBELP)
        {
            MODEL_ZBCFUN_POITEM_READ rst = new MODEL_ZBCFUN_POITEM_READ();
            List<ZSL_BCST100> child_ET_RETURN = new List<ZSL_BCST100>();
            ZSL_BCS002 child_ES_POITEM = new ZSL_BCS002();
            IRfcFunction func = RFC.Function("ZBCFUN_POITEM_READ");
            func.SetValue("IV_EBELN", IV_EBELN.Trim());
            func.SetValue("IV_EBELP", IV_EBELP.Trim());
            try
            {
                RFC.Invoke(func, true);
                IRfcTable tb_ET_RETURN = func.GetTable("ET_RETURN");
                for (int i = 0; i < tb_ET_RETURN.RowCount; i++)
                {
                    ZSL_BCST100 child = new ZSL_BCST100();
                    tb_ET_RETURN.CurrentIndex = i;
                    child.Type = tb_ET_RETURN.GetString("TYPE");
                    child.Message = tb_ET_RETURN.GetString("MESSAGE");
                    child_ET_RETURN.Add(child);
                }
                IRfcStructure table_ES_POITEM = func.GetStructure("ES_POITEM");
                child_ES_POITEM.EBELN = table_ES_POITEM.GetString("EBELN");
                child_ES_POITEM.EBELP = table_ES_POITEM.GetString("EBELP");
                child_ES_POITEM.LIFNR = table_ES_POITEM.GetString("LIFNR");
                child_ES_POITEM.LNAME = table_ES_POITEM.GetString("LNAME");
                child_ES_POITEM.EKGRP = table_ES_POITEM.GetString("EKGRP");
                child_ES_POITEM.EKNAM = table_ES_POITEM.GetString("EKNAM");
                child_ES_POITEM.MATNR = table_ES_POITEM.GetString("MATNR");
                child_ES_POITEM.MAKTX = table_ES_POITEM.GetString("MAKTX");
                child_ES_POITEM.EINDT = table_ES_POITEM.GetString("EINDT");
                child_ES_POITEM.MENGE = table_ES_POITEM.GetString("MENGE");
                child_ES_POITEM.MEINS = table_ES_POITEM.GetString("MEINS");
                child_ES_POITEM.OBMNG = table_ES_POITEM.GetString("OBMNG");
                child_ES_POITEM.WERKS = table_ES_POITEM.GetString("WERKS");
                child_ES_POITEM.LGORT = table_ES_POITEM.GetString("LGORT");
                child_ES_POITEM.LGOBE = table_ES_POITEM.GetString("LGOBE");
                child_ES_POITEM.CHARG = table_ES_POITEM.GetString("CHARG");
                child_ES_POITEM.WEMPF = table_ES_POITEM.GetString("WEMPF");
                child_ES_POITEM.ABLAD = table_ES_POITEM.GetString("ABLAD");
                child_ES_POITEM.SOBKZ = table_ES_POITEM.GetString("SOBKZ");
                child_ES_POITEM.VBELN = table_ES_POITEM.GetString("VBELN");
                child_ES_POITEM.VBELP = table_ES_POITEM.GetString("VBELP");
                child_ES_POITEM.RETPO = table_ES_POITEM.GetString("RETPO");
                child_ES_POITEM.BSART = table_ES_POITEM.GetString("BSART");
                child_ES_POITEM.RESWK = table_ES_POITEM.GetString("RESWK");
                child_ES_POITEM.INSMK = table_ES_POITEM.GetString("INSMK");
                child_ES_POITEM.MATKL = table_ES_POITEM.GetString("MATKL");
                child_ES_POITEM.WGBEZ = table_ES_POITEM.GetString("WGBEZ");
            }
            catch (Exception e)
            {
                ZSL_BCST100 child = new ZSL_BCST100();
                child.Type = "E";
                child.Message = e.Message;
                child_ET_RETURN.Add(child);
            }
            rst.ET_RETURN = child_ET_RETURN;
            rst.ES_POITEM = child_ES_POITEM;
            return rst;
        }

        public ZSL_BCST100 GET_ZBCFUN_PO_RECEIPT(string IV_CKDJH, string IV_KZBEW)
        {
            ZSL_BCST100 child_ET_RETURN = new ZSL_BCST100();
            IRfcFunction func = RFC.Function("ZBCFUN_PO_RECEIPT");
            func.SetValue("IV_CKDJH", IV_CKDJH.Trim());
            func.SetValue("IV_KZBEW", IV_KZBEW.Trim());
            try
            {
                RFC.Invoke(func, true);
                IRfcTable tb_ET_RETURN = func.GetTable("CT_RETURN");
                tb_ET_RETURN.CurrentIndex = 0;
                child_ET_RETURN.Type = tb_ET_RETURN.GetString("TYPE");
                child_ET_RETURN.Message = tb_ET_RETURN.GetString("MESSAGE");

                return child_ET_RETURN;


            }
            catch (Exception e)
            {
                child_ET_RETURN.Type = "E";
                child_ET_RETURN.Message = e.Message;
                return child_ET_RETURN;
            }

        }



        public MODEL_ZBCFUN_JHD_READ JHD_READ(string VBELN)
        {
            IRfcFunction func = RFC.Function("ZBCFUN_JHD_READ");
            //func.SetValue("I_KUNNR", customer);
            IRfcStructure i_table_IT_ITEMDATA = func.GetStructure("IS_DATA");

           
            i_table_IT_ITEMDATA.SetValue("VBELN", VBELN);

            //func.SetValue("IS_Data", i_table_IT_ITEMDATA);

            MODEL_ZBCFUN_JHD_READ result = new MODEL_ZBCFUN_JHD_READ();
            result.ES_HeadData = new ZSL_BCS013();
            result.ET_ItemData = new List<ZSL_BCST014>();
            result.MES_RETURN = new MES_RETURN();
            try
            {
                RFC.Invoke(func, true);
                //result.ES_HeadData = func.GetTable("ES_HeadData");
                //result.ET_ItemData = func.GetTable("ET_ItemData");
                IRfcStructure ES_HeadData = func.GetStructure("ES_HEADDATA");
                IRfcTable ET_ItemData = func.GetTable("ET_ITEMDATA");
                IRfcTable CT_RETURN = func.GetTable("CT_RETURN");

                
                result.ES_HeadData.VBELN = ES_HeadData.GetString("VBELN");
                result.ES_HeadData.KUNAG = ES_HeadData.GetString("KUNAG");
                result.ES_HeadData.NAMEG = ES_HeadData.GetString("NAMEG");
                result.ES_HeadData.ZZKGGKH = ES_HeadData.GetString("ZZKGGKH");

                for (int i = 0; i < ET_ItemData.RowCount; i++)
                {
                    ET_ItemData.CurrentIndex = i;
                    ZSL_BCST014 node = new ZSL_BCST014();
                    node.VBELN = ET_ItemData.GetString("VBELN").TrimStart('0');
                    node.POSNR = ET_ItemData.GetString("POSNR").TrimStart('0');
                    node.MATNR = ET_ItemData.GetString("MATNR").TrimStart('0');
                    node.MAKTX = ET_ItemData.GetString("MAKTX");
                    node.LGMNG = ET_ItemData.GetDecimal("LGMNG");
                    node.MEINS = ET_ItemData.GetString("MEINS");
                    node.SONUM = ET_ItemData.GetString("SONUM");
                    node.SOBKZ = ET_ItemData.GetString("SOBKZ");
                    node.CHARG = ET_ItemData.GetString("CHARG");
                    node.UECHA = ET_ItemData.GetString("UECHA");
                    node.WERKS = ET_ItemData.GetString("WERKS");
                    node.LGORT = ET_ItemData.GetString("LGORT");
                    node.ZPAR = ET_ItemData.GetInt("ZPAR");
                    node.ZBON = ET_ItemData.GetInt("ZBON");
                    node.ZPKS = ET_ItemData.GetInt("ZPKS");
                    node.ZPCS = ET_ItemData.GetInt("ZPCS");
                    node.ZLTBS = ET_ItemData.GetString("ZLTBS");
                    node.DXS = ET_ItemData.GetInt("DXS");
                    node.NHS = ET_ItemData.GetInt("NHS");
                    node.ZS = ET_ItemData.GetInt("ZS");
                    node.JHZ = ET_ItemData.GetString("JHZ");
                    node.ZZKGGKH = ET_ItemData.GetString("ZZKGGKH");

                    result.ET_ItemData.Add(node);
                }

                CT_RETURN.CurrentIndex = 0;
                result.MES_RETURN.TYPE = CT_RETURN.GetString("TYPE");
                result.MES_RETURN.MESSAGE = CT_RETURN.GetString("MESSAGE");





            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return result;
        }


        public MES_RETURN JHD_UPDATE(List<ZSL_BCT110> model)
        {
            IRfcFunction func = RFC.Function("ZBCFUN_JHD_UPDATE");

            IRfcTable i_table = func.GetTable("IT_DATA");
            for (int i = 0; i < model.Count; i++)
            {
                i_table.Append();
                i_table.SetValue("VBELN", model[i].VBELN);
                i_table.SetValue("POSNR", model[i].POSNR);
                i_table.SetValue("NHM", model[i].NHM);
                i_table.SetValue("DXM", model[i].DXM);
                i_table.SetValue("TPM", model[i].TPM);
                i_table.SetValue("VBELNN", model[i].VBELNN);
                i_table.SetValue("POSNRN", model[i].POSNRN);
                i_table.SetValue("MATNR", model[i].MATNR);
                i_table.SetValue("KUNAG", model[i].KUNAG);
                i_table.SetValue("LGORT", model[i].LGORT);
                i_table.SetValue("WERKS", model[i].WERKS);


            }

            MES_RETURN result = new MES_RETURN();
            try
            {
                RFC.Invoke(func, false);
                IRfcTable CT_RETURN = func.GetTable("CT_RETURN");


                CT_RETURN.CurrentIndex = 0;
                result.TYPE = CT_RETURN.GetString("TYPE");
                result.MESSAGE = CT_RETURN.GetString("MESSAGE");





            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return result;
        }


        public MODEL_ZBCFUN_JHZ_READ JHZ_READ(MODEL_ZBCFUN_JHZ_READ model)
        {
            IRfcFunction func = RFC.Function("ZBCFUN_JHZ_READ");

            func.SetValue("IV_MATNR", model.IV_MATNR);
            func.SetValue("IV_SL", model.IV_SL);

            MODEL_ZBCFUN_JHZ_READ result = new MODEL_ZBCFUN_JHZ_READ();
            try
            {
                RFC.Invoke(func, false);
                result.EV_DXS = func.GetInt("EV_DXS");
                result.EV_NHS = func.GetInt("EV_NHS");
                result.EV_ZS = func.GetInt("EV_ZS");
                result.EV_JHZ = func.GetString("EV_JHZ");

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return result;
        }




    }
}

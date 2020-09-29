using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class MES_WLKCBS
    {
        private static readonly IMES_MM IMES_MMdate = MESDataAccess.CreateMES_MM();
        private static readonly ITM_WLPZ ITM_WLPZdata = MESDataAccess.CreateTM_WLPZ();
        private static readonly ITM_TMINFO ITM_TMINFOdata = MESDataAccess.CreateTM_TMINFO();
        private static readonly ISY_YERACOUNT ISY_YERACOUNTdata = MESDataAccess.CreateSY_YERACOUNT();
        private static readonly ITM_GL ITM_GLdata = MESDataAccess.CreateTM_GL();
        private static readonly IMM_CK IMM_CKdata = MESDataAccess.CreateMM_CK();
        public ZBCFUN_PURBS_READ GET_WLPZ(ZSL_BCS303_CT IS_PURCT)
        {
            ZBCFUN_PURBS_READ rst = new ZBCFUN_PURBS_READ();
            ZSL_BCS303_BS model_ZSL_BCS303_BS = new ZSL_BCS303_BS();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            string IV_FCODE = "C01";
            if (IS_PURCT.TM != "" && IS_PURCT.TM != null)
            {
                MES_TM_WLPZ model_MES_TM_WLPZ = new MES_TM_WLPZ();
                model_MES_TM_WLPZ.TM = IS_PURCT.TM;
                model_MES_TM_WLPZ.ISKEY = 1;
                MES_TM_WLPZ_SELECT rst_MES_TM_WLPZ_SELECT = ITM_WLPZdata.SELECT(model_MES_TM_WLPZ);
                if (rst_MES_TM_WLPZ_SELECT.MES_RETURN.TYPE == "S")
                {
                    if (rst_MES_TM_WLPZ_SELECT.MES_TM_WLPZ.Count > 0)
                    {
                        IS_PURCT.MBLNR = rst_MES_TM_WLPZ_SELECT.MES_TM_WLPZ[0].WLPZBH;
                        IS_PURCT.MJAHR = rst_MES_TM_WLPZ_SELECT.MES_TM_WLPZ[0].WLPZND;
                    }
                    else
                    {
                        List<ZSL_BCS303_BS> model_ZSL_BCS303_BS_list = new List<ZSL_BCS303_BS>();
                        child_MES_RETURN.TYPE = "S";
                        child_MES_RETURN.MESSAGE = "";
                        rst.MES_RETURN = child_MES_RETURN;
                        rst.ET_PURBS = model_ZSL_BCS303_BS_list;
                        return rst;
                    }
                }
            }
            rst = IMES_MMdate.GET_PURBS_READ(IV_FCODE, IS_PURCT, model_ZSL_BCS303_BS);

            if (rst.MES_RETURN.TYPE == "S")
            {
                for (int i = 0; i < rst.ET_PURBS.Count; i++)
                {
                    MES_TM_WLPZ model_MES_TM_WLPZ = new MES_TM_WLPZ();
                    model_MES_TM_WLPZ.GC = rst.ET_PURBS[i].WERKS;
                    model_MES_TM_WLPZ.WLPZBH = rst.ET_PURBS[i].MBLNR;
                    model_MES_TM_WLPZ.WLPZND = rst.ET_PURBS[i].MJAHR;
                    model_MES_TM_WLPZ.WLPZH = rst.ET_PURBS[i].LINE_ID;
                    model_MES_TM_WLPZ.ISKEY = 1;
                    MES_TM_WLPZ_SELECT rst_MES_TM_WLPZ_SELECT = ITM_WLPZdata.SELECT(model_MES_TM_WLPZ);
                    if (rst_MES_TM_WLPZ_SELECT.MES_RETURN.TYPE == "S" && rst_MES_TM_WLPZ_SELECT.MES_TM_WLPZ.Count > 0)
                    {
                        rst.ET_PURBS[i].TM = rst_MES_TM_WLPZ_SELECT.MES_TM_WLPZ[0].TM;
                        rst.ET_PURBS[i].XCZJTM = rst_MES_TM_WLPZ_SELECT.MES_TM_WLPZ[0].XCZJTM;
                    }
                    else
                    {
                        rst.ET_PURBS[i].TM = "";
                        rst.ET_PURBS[i].XCZJTM = "";
                    }
                }
            }
            else
            {
                for (int i = 0; i < rst.ET_PURBS.Count; i++)
                {
                    rst.ET_PURBS[i].TM = "";
                    rst.ET_PURBS[i].XCZJTM = "";
                }
            }

            if (IS_PURCT.TM != "" && IS_PURCT.TM != null)
            {
                if (IS_PURCT.TM.Length == 12)
                {
                    List<ZSL_BCS303_BS> rst_ZSL_BCS303_BS = rst.ET_PURBS;
                    for (int i = rst.ET_PURBS.Count - 1; i >= 0; i--)
                    {
                        if (rst.ET_PURBS[i].TM != IS_PURCT.TM)
                        {
                            rst_ZSL_BCS303_BS.Remove(rst.ET_PURBS[i]);
                        }
                    }
                    rst.ET_PURBS = rst_ZSL_BCS303_BS;
                }
                else
                {
                    child_MES_RETURN.TYPE = "E";
                    child_MES_RETURN.MESSAGE = "请检查输入的条码号！";
                    rst.MES_RETURN = child_MES_RETURN;
                    return rst;
                }
            }

            if (IS_PURCT.ISNOTPRINT == true && rst.MES_RETURN.TYPE == "S")
            {
                List<ZSL_BCS303_BS> rst_ZSL_BCS303_BS = rst.ET_PURBS;
                for (int i = rst.ET_PURBS.Count - 1; i >= 0; i--)
                {
                    if (rst.ET_PURBS[i].TM.Trim() != "")
                    {
                        rst_ZSL_BCS303_BS.Remove(rst.ET_PURBS[i]);
                    }
                }
                rst.ET_PURBS = rst_ZSL_BCS303_BS;
            }
            if (rst.MES_RETURN.TYPE == "S" && string.IsNullOrEmpty(IS_PURCT.LGORT))
            {
                MES_MM_CK model_MES_MM_CK = new MES_MM_CK();
                model_MES_MM_CK.STAFFID = IS_PURCT.STAFFID;
                MES_MM_CK_SELECT rst_MES_MM_CK_SELECT = IMM_CKdata.SELECT_BY_STAFFID(model_MES_MM_CK);
                if (rst_MES_MM_CK_SELECT.MES_RETURN.TYPE == "S")
                {
                    if (rst_MES_MM_CK_SELECT.MES_MM_CK.Count > 0)
                    {
                        List<ZSL_BCS303_BS> rst_ZSL_BCS303_BS = rst.ET_PURBS;
                        for (int i = rst.ET_PURBS.Count - 1; i >= 0; i--)
                        {
                            int okcount = 0;
                            for (int a = 0; a < rst_MES_MM_CK_SELECT.MES_MM_CK.Count; a++)
                            {
                                if (rst_MES_MM_CK_SELECT.MES_MM_CK[a].GC == rst.ET_PURBS[i].WERKS && rst_MES_MM_CK_SELECT.MES_MM_CK[a].CKDM == rst.ET_PURBS[i].LGORT)
                                {
                                    okcount = 1;
                                    break;
                                }
                            }
                            if (okcount == 0)
                            {
                                rst_ZSL_BCS303_BS.Remove(rst.ET_PURBS[i]);
                            }
                            okcount = 0;
                        }
                        rst.ET_PURBS = rst_ZSL_BCS303_BS;
                    }
                    else
                    {
                        rst.MES_RETURN = rst_MES_MM_CK_SELECT.MES_RETURN;
                        List<ZSL_BCS303_BS> rst_ZSL_BCS303_BS = new List<ZSL_BCS303_BS>();
                        rst.ET_PURBS = rst_ZSL_BCS303_BS;
                        return rst;
                    }
                }
                else
                {
                    rst.MES_RETURN = rst_MES_MM_CK_SELECT.MES_RETURN;
                    return rst;
                }
            }

            return rst;
        }
        public ZBCFUN_PURBS_READ GET_WLPZ_ZJ(ZSL_BCS303_BS IS_PURBS)
        {
            ZBCFUN_PURBS_READ rst = new ZBCFUN_PURBS_READ();
            ZSL_BCS303_CT model_ZSL_BCS303_CT = new ZSL_BCS303_CT();
            string IV_FCODE = "C02";
            rst = IMES_MMdate.GET_PURBS_READ(IV_FCODE, model_ZSL_BCS303_CT, IS_PURBS);
            //if (IS_PURBS.TM != "")
            //{
            //    MES_TM_TMINFO model_MES_TM_TMINFO = new MES_TM_TMINFO();
            //    model_MES_TM_TMINFO.TM = IS_PURBS.TM;
            //    SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM = ITM_TMINFOdata.SELECT_BYTM(model_MES_TM_TMINFO, 2);
            //}
            return rst;
        }


        public ZBCFUN_PURBS_READ INSERT_TM_WLPZ(List<ZSL_BCS303_BS> model)
        {
            ZBCFUN_PURBS_READ rst = new ZBCFUN_PURBS_READ();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            if (model.Count > 0)
            {
                for (int i = 0; i < model.Count; i++)
                {
                    if (model[i].TM == "")
                    {
                        MES_TM_WLPZ model_MES_TM_WLPZ = new MES_TM_WLPZ();
                        model_MES_TM_WLPZ.GC = model[i].WERKS;
                        model_MES_TM_WLPZ.WLPZBH = model[i].MBLNR;
                        model_MES_TM_WLPZ.WLPZND = model[i].MJAHR;
                        model_MES_TM_WLPZ.WLPZH = model[i].LINE_ID;
                        model_MES_TM_WLPZ.ISKEY = 1;
                        MES_TM_WLPZ_SELECT rst_MES_TM_WLPZ_SELECT = ITM_WLPZdata.SELECT(model_MES_TM_WLPZ);
                        if (rst_MES_TM_WLPZ_SELECT.MES_RETURN.TYPE == "S")
                        {
                            if (rst_MES_TM_WLPZ_SELECT.MES_TM_WLPZ.Count > 0)
                            {
                                model[i].TM = rst_MES_TM_WLPZ_SELECT.MES_TM_WLPZ[0].TM;
                                ITM_GLdata.DELETE_BY_SCTM(model[i].TM);
                                if (model[i].XCZJTM.Trim() != "")
                                {
                                    string[] xctmzj = model[i].XCZJTM.Split(',');
                                    if (xctmzj.Length > 0)
                                    {
                                        List<MES_TM_GL> model_MES_TM_GL = new List<MES_TM_GL>();
                                        for (int j = 0; j < xctmzj.Length; j++)
                                        {
                                            MES_TM_GL child_MES_TM_GL = new MES_TM_GL();
                                            child_MES_TM_GL.SCTM = model[i].TM;
                                            child_MES_TM_GL.XCTM = xctmzj[j];
                                            child_MES_TM_GL.GLLB = 1;
                                            model_MES_TM_GL.Add(child_MES_TM_GL);
                                        }
                                        ITM_GLdata.INSERT(model_MES_TM_GL);
                                    }
                                }
                            }
                            else
                            {
                                MES_TM_TMINFO model_MES_TM_TMINFO = new MES_TM_TMINFO();
                                MES_SY_YERACOUNT model_MES_SY_YERACOUNT = new MES_SY_YERACOUNT();
                                model_MES_SY_YERACOUNT.TMLB = 1;
                                model_MES_SY_YERACOUNT.GC = model[i].WERKS;
                                model_MES_TM_TMINFO.TM = ISY_YERACOUNTdata.SELECT(model_MES_SY_YERACOUNT);
                                model_MES_TM_TMINFO.GC = model[i].WERKS;
                                model_MES_TM_TMINFO.TMLB = model[i].TMLB;
                                model_MES_TM_TMINFO.TMSX = model[i].TMSX;
                                model_MES_TM_TMINFO.SCDATE = model[i].BUDAT;
                                model_MES_TM_TMINFO.BC = 0;
                                model_MES_TM_TMINFO.RWBH = "";
                                model_MES_TM_TMINFO.PC = model[i].CHARG;
                                model_MES_TM_TMINFO.JLR = model[i].JLR;
                                model_MES_TM_TMINFO.CLCJ = model[i].CLCJ;
                                model_MES_TM_TMINFO.GYLX = model[i].GY;
                                model_MES_TM_TMINFO.GYS = model[i].LIFNR;
                                model_MES_TM_TMINFO.GYSMS = model[i].SORTL;
                                model_MES_TM_TMINFO.GYSPC = model[i].LICHA;
                                model_MES_TM_TMINFO.CPZT = 0;
                                model_MES_TM_TMINFO.SL = Convert.ToDecimal(model[i].MENGE);
                                model_MES_TM_TMINFO.SBHMS = model[i].SBH;
                                model_MES_TM_TMINFO.WLH = model[i].MATNR;
                                model_MES_TM_TMINFO.WLMS = model[i].MAKTX;
                                model_MES_TM_TMINFO.WLLB = 0;
                                model_MES_TM_TMINFO.WLLBNAME = model[i].WLDL;
                                model_MES_TM_TMINFO.DCDJ = 0;
                                model_MES_TM_TMINFO.DCDJMS = model[i].DCDJ;
                                model_MES_TM_TMINFO.DCXH = 0;
                                model_MES_TM_TMINFO.DCXHMS = model[i].DCXH;
                                model_MES_TM_TMINFO.WLGROUP = model[i].MATKL;
                                model_MES_TM_TMINFO.UNITSNAME = model[i].MEINS;
                                model_MES_TM_TMINFO.KCDD = model[i].LGORT;
                                model_MES_TM_TMINFO.KCDDNAME = model[i].LGOBE;
                                model_MES_TM_TMINFO.CGBILL = model[i].EBELN;
                                model_MES_TM_TMINFO.CGBILLMX = model[i].EBELP;
                                model_MES_TM_TMINFO.NOBILL = model[i].MAT_KDAUF;
                                model_MES_TM_TMINFO.NOBILLMX = model[i].MAT_KDPOS;
                                model_MES_TM_TMINFO.REMARK = model[i].WEMPF;
                                model_MES_TM_TMINFO.MAC = model[i].MAC;
                                child_MES_RETURN = ITM_TMINFOdata.INSERT(model_MES_TM_TMINFO);
                                if (child_MES_RETURN.TYPE == "S")
                                {
                                    model_MES_TM_WLPZ = new MES_TM_WLPZ();
                                    model_MES_TM_WLPZ.GC = model[i].WERKS;
                                    model_MES_TM_WLPZ.WLPZBH = model[i].MBLNR;
                                    model_MES_TM_WLPZ.WLPZND = model[i].MJAHR;
                                    model_MES_TM_WLPZ.WLPZH = model[i].LINE_ID;
                                    model_MES_TM_WLPZ.TM = model_MES_TM_TMINFO.TM;
                                    model_MES_TM_WLPZ.ISKEY = 1;
                                    model_MES_TM_WLPZ.TH = 0;
                                    model_MES_TM_WLPZ.WLPZHXMH = model[i].ZEILE;
                                    child_MES_RETURN = ITM_WLPZdata.INSERT(model_MES_TM_WLPZ);
                                    child_MES_RETURN.GC = model_MES_TM_TMINFO.GC;
                                    child_MES_RETURN.TM = model_MES_TM_TMINFO.TM;
                                }
                                else
                                {
                                    return rst;
                                }
                                model[i].TM = child_MES_RETURN.TM;
                                ITM_GLdata.DELETE_BY_SCTM(model[i].TM);
                                if (model[i].XCZJTM.Trim() != "")
                                {
                                    string[] xctmzj = model[i].XCZJTM.Split(',');
                                    if (xctmzj.Length > 0)
                                    {
                                        List<MES_TM_GL> model_MES_TM_GL = new List<MES_TM_GL>();
                                        for (int j = 0; j < xctmzj.Length; j++)
                                        {
                                            MES_TM_GL child_MES_TM_GL = new MES_TM_GL();
                                            child_MES_TM_GL.SCTM = model[i].TM;
                                            child_MES_TM_GL.XCTM = xctmzj[j];
                                            child_MES_TM_GL.GLLB = 1;
                                            model_MES_TM_GL.Add(child_MES_TM_GL);
                                        }
                                        ITM_GLdata.INSERT(model_MES_TM_GL);
                                    }
                                }
                            }
                        }
                        else
                        {
                            rst.MES_RETURN = rst_MES_TM_WLPZ_SELECT.MES_RETURN;
                            return rst;
                        }
                    }
                    else
                    {
                        ITM_GLdata.DELETE_BY_SCTM(model[i].TM);
                        if (model[i].XCZJTM.Trim() != "")
                        {
                            string[] xctmzj = model[i].XCZJTM.Split(',');
                            if (xctmzj.Length > 0)
                            {
                                List<MES_TM_GL> model_MES_TM_GL = new List<MES_TM_GL>();
                                for (int j = 0; j < xctmzj.Length; j++)
                                {
                                    MES_TM_GL child_MES_TM_GL = new MES_TM_GL();
                                    child_MES_TM_GL.SCTM = model[i].TM;
                                    child_MES_TM_GL.XCTM = xctmzj[j];
                                    child_MES_TM_GL.GLLB = 1;
                                    model_MES_TM_GL.Add(child_MES_TM_GL);
                                }
                                ITM_GLdata.INSERT(model_MES_TM_GL);
                            }
                        }
                    }
                }
            }
            rst.ET_PURBS = model;
            child_MES_RETURN = new MES_RETURN();
            child_MES_RETURN.TYPE = "S";
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }

        public ZBCFUN_PURBS_READ INSERT_TM_WLPZ_CHILD(List<ZSL_BCS303_BS> model)
        {
            ZBCFUN_PURBS_READ rst = new ZBCFUN_PURBS_READ();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            if (model.Count > 0)
            {
                for (int i = 0; i < model.Count; i++)
                {
                    if (model[i].TS <= 0)
                    {
                        child_MES_RETURN.TYPE = "E";
                        child_MES_RETURN.MESSAGE = string.Format("{0}/{1}/{2}的托数需要大于0，请检查！", model[i].MJAHR, model[i].MBLNR, model[i].LINE_ID);
                        rst.MES_RETURN = child_MES_RETURN;
                        return rst;
                    }
                    if (ZH_STRING_TO_INT(model[i].QSTH) <= 0)
                    {
                        child_MES_RETURN.TYPE = "E";
                        child_MES_RETURN.MESSAGE = string.Format("{0}/{1}/{2}的起始托号需要大于0的整数，请检查！", model[i].MJAHR, model[i].MBLNR, model[i].LINE_ID);
                        rst.MES_RETURN = child_MES_RETURN;
                        return rst;
                    }
                    MES_TM_WLPZ model_MES_TM_WLPZ = new MES_TM_WLPZ();
                    model_MES_TM_WLPZ.GC = model[i].WERKS;
                    model_MES_TM_WLPZ.WLPZBH = model[i].MBLNR;
                    model_MES_TM_WLPZ.WLPZND = model[i].MJAHR;
                    model_MES_TM_WLPZ.WLPZH = model[i].LINE_ID;
                    model_MES_TM_WLPZ.ISKEY = 0;
                    model_MES_TM_WLPZ.THS = ZH_STRING_TO_INT(model[i].QSTH);
                    model_MES_TM_WLPZ.THE = ZH_STRING_TO_INT(model[i].QSTH) + model[i].TS;
                    MES_TM_WLPZ_SELECT rst_MES_TM_WLPZ_SELECT = ITM_WLPZdata.SELECT(model_MES_TM_WLPZ);
                    if (rst_MES_TM_WLPZ_SELECT.MES_RETURN.TYPE == "S")
                    {
                        if (rst_MES_TM_WLPZ_SELECT.MES_TM_WLPZ.Count > 0)
                        {
                            child_MES_RETURN.TYPE = "E";
                            child_MES_RETURN.MESSAGE = string.Format("{0}/{1}/{2}的托号{3}已存在，请检查！", model[i].MJAHR, model[i].MBLNR, model[i].LINE_ID, rst_MES_TM_WLPZ_SELECT.MES_TM_WLPZ[0].TH);
                            rst.MES_RETURN = child_MES_RETURN;
                            return rst;
                        }
                    }
                    else
                    {
                        rst.MES_RETURN = rst_MES_TM_WLPZ_SELECT.MES_RETURN;
                        return rst;
                    }
                }
                List<ZSL_BCS303_BS> child_ZSL_BCS303_BS = new List<ZSL_BCS303_BS>();
                for (int i = 0; i < model.Count; i++)
                {
                    for (int j = 0; j < model[i].TS; j++)
                    {
                        MES_TM_TMINFO model_MES_TM_TMINFO = new MES_TM_TMINFO();
                        MES_SY_YERACOUNT model_MES_SY_YERACOUNT = new MES_SY_YERACOUNT();
                        model_MES_SY_YERACOUNT.TMLB = 1;
                        model_MES_SY_YERACOUNT.GC = model[i].WERKS;
                        model_MES_TM_TMINFO.TM = ISY_YERACOUNTdata.SELECT(model_MES_SY_YERACOUNT);
                        model_MES_TM_TMINFO.GC = model[i].WERKS;
                        model_MES_TM_TMINFO.TMLB = model[i].TMLB;
                        model_MES_TM_TMINFO.TMSX = model[i].TMSX;
                        model_MES_TM_TMINFO.SCDATE = model[i].BUDAT;
                        model_MES_TM_TMINFO.BC = 0;
                        model_MES_TM_TMINFO.RWBH = "";
                        model_MES_TM_TMINFO.PC = model[i].CHARG;
                        model_MES_TM_TMINFO.JLR = model[i].JLR;
                        model_MES_TM_TMINFO.CLCJ = model[i].CLCJ;
                        model_MES_TM_TMINFO.GYLX = model[i].GY;
                        model_MES_TM_TMINFO.GYS = model[i].LIFNR;
                        model_MES_TM_TMINFO.GYSMS = model[i].SORTL;
                        model_MES_TM_TMINFO.GYSPC = model[i].LICHA;
                        model_MES_TM_TMINFO.CPZT = 0;
                        model_MES_TM_TMINFO.SL = Convert.ToDecimal(ZH_STRING_TO_INT(model[i].MTSL));
                        model_MES_TM_TMINFO.SBHMS = model[i].SBH;
                        model_MES_TM_TMINFO.WLH = model[i].MATNR;
                        model_MES_TM_TMINFO.WLMS = model[i].MAKTX;
                        model_MES_TM_TMINFO.WLLB = 0;
                        model_MES_TM_TMINFO.WLLBNAME = model[i].WLDL;
                        model_MES_TM_TMINFO.DCDJ = 0;
                        model_MES_TM_TMINFO.DCDJMS = model[i].DCDJ;
                        model_MES_TM_TMINFO.DCXH = 0;
                        model_MES_TM_TMINFO.DCXHMS = model[i].DCXH;
                        model_MES_TM_TMINFO.WLGROUP = model[i].MATKL;
                        model_MES_TM_TMINFO.UNITSNAME = model[i].MEINS;
                        model_MES_TM_TMINFO.KCDD = model[i].LGORT;
                        model_MES_TM_TMINFO.KCDDNAME = model[i].LGOBE;
                        model_MES_TM_TMINFO.CGBILL = model[i].EBELN;
                        model_MES_TM_TMINFO.CGBILLMX = model[i].EBELP;
                        model_MES_TM_TMINFO.NOBILL = model[i].MAT_KDAUF;
                        model_MES_TM_TMINFO.NOBILLMX = model[i].MAT_KDPOS;
                        model_MES_TM_TMINFO.REMARK = model[i].WEMPF;
                        model_MES_TM_TMINFO.MAC = model[i].MAC;
                        model_MES_TM_TMINFO.TH = ZH_STRING_TO_INT(model[i].QSTH) + j;
                        child_MES_RETURN = ITM_TMINFOdata.INSERT(model_MES_TM_TMINFO);
                        if (child_MES_RETURN.TYPE == "S")
                        {
                            MES_TM_WLPZ model_MES_TM_WLPZ = new MES_TM_WLPZ();
                            model_MES_TM_WLPZ.GC = model[i].WERKS;
                            model_MES_TM_WLPZ.WLPZBH = model[i].MBLNR;
                            model_MES_TM_WLPZ.WLPZND = model[i].MJAHR;
                            model_MES_TM_WLPZ.WLPZH = model[i].LINE_ID;
                            model_MES_TM_WLPZ.TM = model_MES_TM_TMINFO.TM;
                            model_MES_TM_WLPZ.ISKEY = 0;
                            model_MES_TM_WLPZ.TH = ZH_STRING_TO_INT(model[i].QSTH) + j;
                            model_MES_TM_WLPZ.WLPZHXMH = model[i].ZEILE;
                            ITM_WLPZdata.INSERT(model_MES_TM_WLPZ);
                            child_MES_RETURN.GC = model_MES_TM_TMINFO.GC;
                            child_MES_RETURN.TM = model_MES_TM_TMINFO.TM;
                            model[i].TM = child_MES_RETURN.TM;
                            string zh = Newtonsoft.Json.JsonConvert.SerializeObject(model[i]);
                            child_ZSL_BCS303_BS.Add(Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_BCS303_BS>(zh));
                            ITM_GLdata.DELETE_BY_SCTM(model[i].TM);
                            if (model[i].XCZJTM.Trim() != "")
                            {
                                string[] xctmzj = model[i].XCZJTM.Split(',');
                                if (xctmzj.Length > 0)
                                {
                                    List<MES_TM_GL> model_MES_TM_GL = new List<MES_TM_GL>();
                                    for (int a = 0; a < xctmzj.Length; a++)
                                    {
                                        MES_TM_GL child_MES_TM_GL = new MES_TM_GL();
                                        child_MES_TM_GL.SCTM = model[i].TM;
                                        child_MES_TM_GL.XCTM = xctmzj[a];
                                        child_MES_TM_GL.GLLB = 1;
                                        model_MES_TM_GL.Add(child_MES_TM_GL);
                                    }
                                    ITM_GLdata.INSERT(model_MES_TM_GL);
                                }
                            }
                        }

                    }
                }
                rst.ET_PURBS = child_ZSL_BCS303_BS;
                child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "S";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
            else
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }

        public int ZH_STRING_TO_INT(string ZH)
        {
            if (ZH == "")
            {
                return 0;
            }
            else
            {
                try
                {
                    int zhint = Convert.ToInt32(ZH);
                    return zhint;
                }
                catch
                {
                    return 0;
                }
            }
        }
    }
}

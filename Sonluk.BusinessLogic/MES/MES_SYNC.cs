using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using Sonluk.IDataAccess.SAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Sonluk.BusinessLogic.MES
{
    public class MES_SYNC
    {
        SY_GC gcservice = new SY_GC();
        MES_MM mmservice = new MES_MM();
        MM_CK ckservice = new MM_CK();
        SY_GZZX gzzxservice = new SY_GZZX();
        SY_TYPEMX typemxservice = new SY_TYPEMX();
        SY_PFDH pfdhservice = new SY_PFDH();
        SY_MATERIAL_GROUP wlgroupservice = new SY_MATERIAL_GROUP();
        SY_MATERIAL wlservice = new SY_MATERIAL();
        private static readonly ISY_MATERIAL_GROUP ISY_MATERIAL_GROUPdata = MESDataAccess.CreateSY_MATERIAL_GROUP();
        private static readonly ISY_PFDH_WL data_ISY_PFDH_WL = MESDataAccess.CreateSY_PFDH_WL();
        private static readonly ISY_TPM_SYNC data_ISY_TPM_SYNC = MESDataAccess.CreateISY_TPM_SYNC();
        private static readonly IZBCFUN data_IZBCFUN = SAPDataAccess.CreateIZBCFUN();
        private static readonly ISY_GZZX data_ISY_GZZX = MESDataAccess.CreateSY_GZZX();
        private static readonly ISY_SYSCS data_ISY_SYSCS = MESDataAccess.CreateISY_SYSCS();
        private static readonly IMES_MM IMES_MMdata = MESDataAccess.CreateMES_MM();
        private static readonly IPD_GD data_IPD_GD = MESDataAccess.CreatePD_GD();
        private static readonly ISY_EXCEPTION data_ISY_EXCEPTION = MESDataAccess.CreateISY_EXCEPTION();
        private static readonly IMES_SYNC data_IMES_SYNC = MESDataAccess.CreateIMES_SYNC();

        public MES_RETURN MES_SYNC_GZZX(string GC)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                if (GC != "")
                {
                    string mes_werks_pdly = data_ISY_SYSCS.SELECT("MES_" + GC + "_GDLY");
                    if (mes_werks_pdly == "0")
                    {
                        List<ZSL_BCST300> sapgzzx = mmservice.GET_GZZX(GC).ToList();
                        for (int j = 0; j < sapgzzx.Count; j++)
                        {
                            MES_SY_GZZX mm_gzzx = new MES_SY_GZZX();
                            mm_gzzx.GC = GC;
                            mm_gzzx.GZZXBH = sapgzzx[j].ARBPL;
                            mm_gzzx.GZZXMS = sapgzzx[j].KTEXT;
                            mm_gzzx.ISACTION = 1;
                            int count = gzzxservice.SELECT_COUNT(sapgzzx[j].ARBPL, GC);
                            if (count == 0)
                            {
                                gzzxservice.INSERT(mm_gzzx, 1);
                            }
                            else
                            {
                                gzzxservice.UPDATE(mm_gzzx, 1);
                            }
                        }
                    }
                }
                rst.TYPE = "S";
                rst.MESSAGE = "";
            }
            catch (Exception e)
            {
                rst.TYPE = "S";
                rst.MESSAGE = e.Message;
            }
            return rst;
        }

        public bool MES_PFDH_SYNC()
        {
            List<MES_SY_GC> lgc = new List<MES_SY_GC>();
            MES_SY_GC gc = new MES_SY_GC();
            try
            {
                lgc = gcservice.read(gc).ToList();
                for (int i = 0; i < lgc.Count; i++)
                {
                    if (lgc[i].GC == "1000" || lgc[i].GC == "4000" || lgc[i].GC == "5000")
                    {
                        List<ZSL_BCST301> sappfdh = mmservice.GET_PFDH().ToList();
                        for (int j = 0; j < sappfdh.Count; j++)
                        {
                            MES_SY_PFDH mm_pfdh = new MES_SY_PFDH();
                            mm_pfdh.GC = lgc[i].GC;
                            mm_pfdh.PFDH = sappfdh[j].PFDH;
                            if (sappfdh[j].YXBS == "Y")
                            {
                                mm_pfdh.ISACTION = 1;
                            }
                            else
                            {
                                mm_pfdh.ISACTION = 0;
                            }
                            mm_pfdh.REMARK = sappfdh[j].BZSM;
                            //MES_SY_TYPEMX modeltypemx = new MES_SY_TYPEMX();
                            //List<MES_SY_TYPEMXLIST> typemx = new List<MES_SY_TYPEMXLIST>();
                            //modeltypemx.TYPEID = 3;
                            //modeltypemx.MXNAME = "正极粉";
                            //modeltypemx.GC = lgc[i].GC;
                            //typemx = typemxservice.SELECT(modeltypemx).ToList();
                            mm_pfdh.LB = 1;
                            mm_pfdh.CJRID = 0;
                            mm_pfdh.CJR = sappfdh[j].CJR;
                            int count = pfdhservice.SELECT_COUNT(mm_pfdh);
                            if (count == 0)
                            {
                                pfdhservice.INSERT(mm_pfdh);
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        public MES_RETURN MES_WLGROUP_SYNC()
        {
            MES_RETURN rst = new MES_RETURN();
            List<MES_SY_GC> lgc = new List<MES_SY_GC>();
            MES_SY_GC gc = new MES_SY_GC();
            try
            {
                lgc = gcservice.read(gc).ToList();
                for (int i = 0; i < lgc.Count; i++)
                {
                    if (lgc[i].ISAUTOWORKSPACE == true)
                    {
                        if (lgc[i].GC == "1000" || lgc[i].GC == "4000" || lgc[i].GC == "5000")
                        {
                            MES_SY_MATERIAL_GROUP_SELECT sapwlgroup = mmservice.GET_WLGROUP();
                            if (sapwlgroup.MES_RETURN.TYPE == "S")
                            {
                                for (int j = 0; j < sapwlgroup.MES_SY_MATERIAL_GROUP.Count; j++)
                                {
                                    MES_SY_MATERIAL_GROUP mm_wlgroup = new MES_SY_MATERIAL_GROUP();
                                    mm_wlgroup = sapwlgroup.MES_SY_MATERIAL_GROUP[j];
                                    mm_wlgroup.GC = lgc[i].GC;
                                    mm_wlgroup.ISACTION = 1;
                                    int count = wlgroupservice.SELECT_COUNT(mm_wlgroup);
                                    if (count == 0)
                                    {
                                        wlgroupservice.INSERT(mm_wlgroup, 1);
                                    }
                                    else
                                    {
                                        wlgroupservice.UPDATE(mm_wlgroup);
                                    }
                                }
                            }
                        }
                    }
                }
                rst.TYPE = "S";
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
            }
            return rst;
        }


        public MES_RETURN MES_SYNC_WL(string GC, string WLGROUP, string WLH, int JLR)
        {
            MES_RETURN rst = new MES_RETURN();
            if (GC == "")
            {
                rst.TYPE = "E";
                rst.MESSAGE = "工厂不能为空！";
                return rst;
            }
            if (WLGROUP == "")
            {
                rst.TYPE = "E";
                rst.MESSAGE = "物料组不能为空！";
                return rst;
            }
            string FCODE = "";
            if (WLH != "")
            {
                FCODE = "F02";
            }
            else
            {
                FCODE = "F01";
            }
            MES_SY_MATERIAL_INSERT_LIST rst_MES_SY_MATERIAL_INSERT_LIST = mmservice.GET_WLXXBYGROUP(GC, WLGROUP, WLH, FCODE);
            if (rst_MES_SY_MATERIAL_INSERT_LIST.MES_RETURN.TYPE == "S")
            {
                if (rst_MES_SY_MATERIAL_INSERT_LIST.MES_SY_MATERIAL.Count > 0)
                {
                    for (int i = 0; i < rst_MES_SY_MATERIAL_INSERT_LIST.MES_SY_MATERIAL.Count; i++)
                    {
                        MES_SY_MATERIAL model_wl = rst_MES_SY_MATERIAL_INSERT_LIST.MES_SY_MATERIAL[i];
                        model_wl.JLR = JLR;
                        if (model_wl.DJBS == "Y")
                        {
                            model_wl.ISACTION = 0;
                        }
                        else
                        {
                            model_wl.ISACTION = 1;
                        }
                        int count = wlservice.SELECT_COUNT(model_wl);
                        if (count == 0)
                        {
                            wlservice.INSERT(model_wl, 1);
                        }
                        else
                        {
                            wlservice.UPDATE(model_wl, 1);
                        }
                    }
                }
                if (rst_MES_SY_MATERIAL_INSERT_LIST.ET_HSGX.Count > 0)
                {
                    string WLHupdate = "";
                    for (int a = 0; a < rst_MES_SY_MATERIAL_INSERT_LIST.ET_HSGX.Count; a++)
                    {
                        if (WLHupdate != rst_MES_SY_MATERIAL_INSERT_LIST.ET_HSGX[a].MATNR)
                        {
                            MES_SY_MATERIAL_DW model_MES_SY_MATERIAL_DW = new MES_SY_MATERIAL_DW();
                            model_MES_SY_MATERIAL_DW.WLH = rst_MES_SY_MATERIAL_INSERT_LIST.ET_HSGX[a].MATNR;
                            model_MES_SY_MATERIAL_DW.LB = 1;
                            wlservice.DW_UPDATE(model_MES_SY_MATERIAL_DW);
                            WLHupdate = rst_MES_SY_MATERIAL_INSERT_LIST.ET_HSGX[a].MATNR;
                        }
                    }
                    for (int a = 0; a < rst_MES_SY_MATERIAL_INSERT_LIST.ET_HSGX.Count; a++)
                    {
                        MES_SY_MATERIAL_DW model_MES_SY_MATERIAL_DW = new MES_SY_MATERIAL_DW();
                        model_MES_SY_MATERIAL_DW.WLH = rst_MES_SY_MATERIAL_INSERT_LIST.ET_HSGX[a].MATNR;
                        model_MES_SY_MATERIAL_DW.MEINH = rst_MES_SY_MATERIAL_INSERT_LIST.ET_HSGX[a].MEINH;
                        model_MES_SY_MATERIAL_DW.UMREZ = rst_MES_SY_MATERIAL_INSERT_LIST.ET_HSGX[a].UMREZ;
                        model_MES_SY_MATERIAL_DW.UMREN = rst_MES_SY_MATERIAL_INSERT_LIST.ET_HSGX[a].UMREN;
                        wlservice.INSERT_DW(model_MES_SY_MATERIAL_DW);
                    }
                }
                rst.TYPE = "S";
            }
            else
            {
                return rst_MES_SY_MATERIAL_INSERT_LIST.MES_RETURN;
            }
            return rst;
        }

        public MES_RETURN MES_SYNC_KCDD(string GC)
        {
            MES_RETURN rst = new MES_RETURN();
            List<MES_SY_GC> lgc = new List<MES_SY_GC>();
            MES_SY_GC gc = new MES_SY_GC();
            gc.GC = GC;
            try
            {
                lgc = gcservice.read(gc).ToList();
                if (lgc.Count != 1 || GC == "")
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "工厂输入有误！";
                    return rst;
                }
                if (lgc[0].ISAUTOWORKSPACE == false)
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "该工厂设置的属性为手工创建！";
                    return rst;
                }
                ZBCFUN_KCDD_READ sapkcdd = mmservice.GET_KCDD(GC);
                if (sapkcdd.MES_RETURN.TYPE == "E")
                {
                    return sapkcdd.MES_RETURN;
                }
                for (int j = 0; j < sapkcdd.CT_KCDD.Count; j++)
                {
                    MES_MM_CK mm_ck = new MES_MM_CK();
                    mm_ck.GC = GC;
                    mm_ck.CKDM = sapkcdd.CT_KCDD[j].LGORT;
                    mm_ck.CKMS = sapkcdd.CT_KCDD[j].LGOBE;
                    mm_ck.ISACTION = 1;
                    int count = ckservice.SELECT_COUNT(mm_ck);
                    if (count == 0)
                    {
                        ckservice.INSERT(mm_ck);
                    }
                    else
                    {
                        ckservice.UPDATE_SYNC(mm_ck);
                    }
                }
                rst.TYPE = "S";
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
            }
            return rst;
        }

        public MES_RETURN MES_SYNC_ALL()
        {
            List<MES_SY_GC> lgc = new List<MES_SY_GC>();
            MES_SY_GC gc = new MES_SY_GC();
            MES_WLGROUP_SYNC();
            lgc = gcservice.read(gc).ToList();
            for (int i = 0; i < lgc.Count; i++)
            {
                if (lgc[i].ISAUTOWORKSPACE == true)
                {
                    MES_SYNC_GZZX(lgc[i].GC);
                    MES_SYNC_KCDD(lgc[i].GC);
                    MES_SY_MATERIAL_GROUP model_MES_SY_MATERIAL_GROUP = new MES_SY_MATERIAL_GROUP();
                    model_MES_SY_MATERIAL_GROUP.GC = lgc[i].GC;
                    MES_SY_MATERIAL_GROUP_SELECT rst_MES_SY_MATERIAL_GROUP_SELECT = ISY_MATERIAL_GROUPdata.SELECT(model_MES_SY_MATERIAL_GROUP);
                    if (rst_MES_SY_MATERIAL_GROUP_SELECT.MES_RETURN.TYPE == "S")
                    {
                        for (int j = 0; j < rst_MES_SY_MATERIAL_GROUP_SELECT.MES_SY_MATERIAL_GROUP.Count; j++)
                        {
                            MES_SYNC_WL(lgc[i].GC, rst_MES_SY_MATERIAL_GROUP_SELECT.MES_SY_MATERIAL_GROUP[j].WLGROUP, "", 0);
                        }
                    }
                }
            }
            MES_RETURN mr = new MES_RETURN();
            mr.TYPE = "S";
            mr.MESSAGE = "";
            return mr;
        }
        public MES_RETURN MES_PFDH_XFPC_SYNC()
        {
            MES_RETURN mr = new MES_RETURN();
            List<MES_SY_GC> lgc = new List<MES_SY_GC>();
            MES_SY_GC gc = new MES_SY_GC();
            lgc = gcservice.read(gc).ToList();
            for (int i = 0; i < lgc.Count; i++)
            {
                string mes_werks_pdly = data_ISY_SYSCS.SELECT("MES_" + lgc[i].GC + "_GDLY");
                if (mes_werks_pdly == "0")
                {
                    ZBCFUN_XFPC_READ rst = mmservice.GET_XFPC_READ(lgc[i].GC, "");
                    if (rst.MES_RETURN.TYPE == "S")
                    {
                        ZSL_BCS304 model_ZSL_BCS304 = new ZSL_BCS304();
                        model_ZSL_BCS304.WERKS = lgc[i].GC;
                        mr = data_ISY_PFDH_WL.XFPC_SYNC_UPDATE(model_ZSL_BCS304, 1);
                        for (int a = 0; a < rst.ET_CHARG.Count; a++)
                        {
                            MES_RETURN rst_MES_RETURN = data_ISY_PFDH_WL.XFPC_SYNC_INSERT(rst.ET_CHARG[a]);
                            if (rst_MES_RETURN.TYPE != "S")
                            {
                                return rst_MES_RETURN;
                            }
                        }
                    }
                    else
                    {
                        return rst.MES_RETURN;
                    }
                }
            }
            mr.TYPE = "S";
            mr.MESSAGE = "";
            return mr;
        }
        public MES_RETURN MES_SY_TPM_SYNC_AUTO(string IV_DATEST, string IV_DATEED)
        {
            MES_RETURN mr = new MES_RETURN();
            try
            {
                if (string.IsNullOrEmpty(IV_DATEST))
                {
                    IV_DATEST = DateTime.Now.AddDays(-2).ToString("yyyyMMdd");
                }
                else
                {
                    IV_DATEST = IV_DATEST.Replace("-", "");
                }
                if (string.IsNullOrEmpty(IV_DATEED))
                {
                    IV_DATEED = DateTime.Now.ToString("yyyyMMdd");
                }
                else
                {
                    IV_DATEED = IV_DATEED.Replace("-", "");
                }
                string mes_werks_pdly = "";
                mes_werks_pdly = data_ISY_SYSCS.SELECT("MES_TPM");
                if (mes_werks_pdly == "0")
                {
                    MES_SY_TPM_SYNC_SELECT rst_MES_SY_TPM_SYNC_SELECT = data_IZBCFUN.ZBCFUN_TPZSJ_READ(IV_DATEST, IV_DATEED);
                    if (rst_MES_SY_TPM_SYNC_SELECT.MES_RETURN.TYPE == "S")
                    {
                        for (int a = 0; a < rst_MES_SY_TPM_SYNC_SELECT.MES_SY_TPM_SYNC.Count; a++)
                        {
                            mr = data_ISY_TPM_SYNC.INSERT(rst_MES_SY_TPM_SYNC_SELECT.MES_SY_TPM_SYNC[a]);
                            if (mr.TYPE != "S")
                            {
                                return mr;
                            }
                        }
                        for (int a = 0; a < rst_MES_SY_TPM_SYNC_SELECT.MES_SY_TPM_SYNC_DELETE.Count; a++)
                        {
                            MES_SY_TPM_SYNC model_MES_SY_TPM_SYNC = new MES_SY_TPM_SYNC();
                            model_MES_SY_TPM_SYNC.TPM = rst_MES_SY_TPM_SYNC_SELECT.MES_SY_TPM_SYNC_DELETE[a].TPM;
                            model_MES_SY_TPM_SYNC.LB = 1;
                            mr = data_ISY_TPM_SYNC.UPDATE(model_MES_SY_TPM_SYNC);
                            if (mr.TYPE != "S")
                            {
                                return mr;
                            }
                        }
                    }
                    else
                    {
                        return rst_MES_SY_TPM_SYNC_SELECT.MES_RETURN;
                    }
                }
                mr.TYPE = "S";
                mr.MESSAGE = "";
                return mr;
            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.ToString();
                return mr;
            }
        }
        public MES_RETURN MES_PD_GD_SYNC_AUTO(string LOW, string HIGH)
        {
            LOW = LOW.Replace("-", "");
            HIGH = HIGH.Replace("-", "");
            if (LOW == "")
            {
                LOW = DateTime.Now.AddDays(-7).ToString("yyyyMMdd");
            }
            if (HIGH == "")
            {
                HIGH = DateTime.Now.AddDays(7).ToString("yyyyMMdd");
            }
            MES_RETURN mr = new MES_RETURN();
            List<MES_SY_GC> lgc = new List<MES_SY_GC>();
            MES_SY_GC gc = new MES_SY_GC();
            lgc = gcservice.read(gc).ToList();
            for (int i = 0; i < lgc.Count; i++)
            {
                string mes_werks_pdly = data_ISY_SYSCS.SELECT("MES_" + lgc[i].GC + "_GDLY");
                if (mes_werks_pdly == "0")
                {
                    MES_SY_GZZX model_MES_SY_GZZX = new MES_SY_GZZX();
                    model_MES_SY_GZZX.GC = lgc[i].GC;
                    List<MES_SY_GZZX> rst_MES_SY_GZZX = data_ISY_GZZX.SELECT(model_MES_SY_GZZX).ToList();
                    //for (int a = 0; a < rst_MES_SY_GZZX.Count; a++)
                    //{
                    ZBCFUN_GDLIST_READ rst_ZBCFUN_GDLIST_READ = new ZBCFUN_GDLIST_READ();
                    LOW = LOW.Replace("-", "");
                    HIGH = HIGH.Replace("-", "");
                    rst_ZBCFUN_GDLIST_READ = IMES_MMdata.GET_GDLIST_1(lgc[i].GC, "", "", "", LOW, HIGH);
                    List<ZSL_BCST024_PO> ET_POLIST = new List<ZSL_BCST024_PO>();
                    List<ZSL_BCS302_B> ET_BOM = new List<ZSL_BCS302_B>();
                    List<ZSL_BCST302_R> ET_RT = new List<ZSL_BCST302_R>();
                    for (int j = 0; j < rst_ZBCFUN_GDLIST_READ.ET_POLIST.Count; j++)
                    {
                        ET_POLIST.Add(rst_ZBCFUN_GDLIST_READ.ET_POLIST[j]);
                    }
                    for (int j = 0; j < rst_ZBCFUN_GDLIST_READ.ET_BOM.Count; j++)
                    {
                        ET_BOM.Add(rst_ZBCFUN_GDLIST_READ.ET_BOM[j]);
                    }
                    for (int j = 0; j < rst_ZBCFUN_GDLIST_READ.ET_RT.Count; j++)
                    {
                        ET_RT.Add(rst_ZBCFUN_GDLIST_READ.ET_RT[j]);
                    }

                    if (ET_POLIST.Count > 0)
                    {
                        data_IPD_GD.INSERT_GD_SYNC(ET_POLIST);
                    }
                    if (ET_BOM.Count > 0)
                    {
                        for (int b = 0; b < ET_BOM.Count; b++)
                        {
                            data_IPD_GD.BOM_SYNC_INSERT(ET_BOM[b]);
                        }
                    }
                    if (ET_RT.Count > 0)
                    {
                        data_IPD_GD.INSERT_GD_GYLX_SYNC(ET_RT);
                    }
                    //}
                }
            }
            mr.TYPE = "S";
            mr.MESSAGE = "";
            return mr;
        }
        public void HR_KQ_KQINFO_AUTO_SYNC()
        {
            data_IMES_SYNC.HR_KQ_KQINFO_AUTO_SYNC();
        }
        public void HR_KQ_GSKQ_AUTO_INSERT()
        {
            data_IMES_SYNC.HR_KQ_GSKQ_AUTO_INSERT();
        }
        public void HR_KQ_DEPTKQ_AUTO_INSERT()
        {
            data_IMES_SYNC.HR_KQ_DEPTKQ_AUTO_INSERT();
        }
    }
}

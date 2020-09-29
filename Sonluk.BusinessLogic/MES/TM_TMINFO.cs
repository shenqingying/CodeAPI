using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class TM_TMINFO
    {
        private static readonly ITM_TMINFO mesdetaAccess = MESDataAccess.CreateTM_TMINFO();
        private static readonly IPD_SCRW IPD_SCRWdate = MESDataAccess.CreatePD_SCRW();
        private static readonly IMES_MM IMES_MMdate = MESDataAccess.CreateMES_MM();
        private static readonly ITM_ZFDCMX ITM_ZFDCMXdata = MESDataAccess.CreateTM_ZFDCMX();
        private static readonly IPD_TL_ERROR IPD_TL_ERRORdata = MESDataAccess.CreatePD_TL_ERROR();
        private static readonly IPD_GD_BOM dataPD_GD_BOM = MESDataAccess.CreatePD_GD_BOM();
        private static readonly ISY_TYPEMX_CHILD ISY_TYPEMX_CHILDdata = MESDataAccess.CreateSY_TYPEMX_CHILD();
        private static readonly IROLE_GZZX IROLE_GZZXdata = MESDataAccess.CreateROLE_GZZX();
        private static readonly IROLE_CK IROLE_CKdata = MESDataAccess.CreateROLE_CK();
        private static readonly ISY_SYSCS ISY_SYSCSdata = MESDataAccess.CreateISY_SYSCS();
        private static readonly IPD_GD data_IPD_GD = MESDataAccess.CreatePD_GD();
        private static readonly ISY_TPM_SYNC data_ISY_TPM_SYNC = MESDataAccess.CreateISY_TPM_SYNC();
        private static readonly ITM_GL data_ITM_GL = MESDataAccess.CreateTM_GL();
        private static readonly IZS_SY_JL data_IZS_SY_JL = MESDataAccess.CreateIZS_SY_JL();
        TM_CZR TM_CZRService = new TM_CZR();
        PD_TL PD_TLservice = new PD_TL();
        TM_GL TM_GLservice = new TM_GL();
        SY_YERACOUNT SY_YERACOUNTservice = new SY_YERACOUNT();

        public SELECT_MES_TM_TMINFO_BYTM SELECT_BYTM(MES_TM_TMINFO model, int ISINSERT, int LB, int TLLB)
        {
            SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            rst = mesdetaAccess.SELECT_BYTM(model, LB);
            if (rst.MES_RETURN.TYPE == "S" && rst.MES_TM_TMINFO_LIST.Count == 1 && (model.RWBH != "" && model.RWBH != null))
            {
                if (rst.MES_TM_TMINFO_LIST[0].TMLB != 2)
                {
                    if (rst.MES_TM_TMINFO_LIST[0].CPZTNAME == "合格" || rst.MES_TM_TMINFO_LIST[0].CPZTNAME == "")
                    {
                        MES_PD_SCRW model_MES_PD_SCRW = new MES_PD_SCRW();
                        model_MES_PD_SCRW.RWBH = model.RWBH;
                        SELECT_MES_PD_SCRW rst_SELECT_MES_PD_SCRW = IPD_SCRWdate.SELECT(model_MES_PD_SCRW);
                        if (rst_SELECT_MES_PD_SCRW.MES_RETURN.TYPE == "S")
                        {
                            if (rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST.Count == 1)
                            {
                                if (rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].GDLB == 1)
                                {
                                    //ZBCFUN_GDJGXX_READ rst_ZBCFUN_GDJGXX_READ = IMES_MMdate.get_GDJGXX(rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].ERPNO);
                                    ZBCFUN_GDJGXX_READ rst_ZBCFUN_GDJGXX_READ = GET_GDJGXX_NEW1(rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].GC, rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].ERPNO);
                                    if (rst_ZBCFUN_GDJGXX_READ.MES_RETURN.TYPE == "S")
                                    {
                                        if (rst_ZBCFUN_GDJGXX_READ.ET_BOM.Count > 0)
                                        {
                                            if (rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].ISOPEN == 0)
                                            {
                                                int tmcount = 0;
                                                for (int i = 0; i < rst_ZBCFUN_GDJGXX_READ.ET_BOM.Count; i++)
                                                {
                                                    if (rst_ZBCFUN_GDJGXX_READ.ET_BOM[i].IDNRK == "")
                                                    {
                                                        if (rst_ZBCFUN_GDJGXX_READ.ET_BOM[i].WLLBNAME == rst.MES_TM_TMINFO_LIST[0].WLLBNAME)
                                                        {
                                                            tmcount = tmcount + 1;
                                                        }
                                                    }
                                                    else if (rst_ZBCFUN_GDJGXX_READ.ET_BOM[i].IDNRK == rst.MES_TM_TMINFO_LIST[0].WLH)
                                                    {
                                                        if (rst_ZBCFUN_GDJGXX_READ.ET_BOM[i].SOBKZ == "E")
                                                        {
                                                            if (rst_ZBCFUN_GDJGXX_READ.ET_BOM[i].KDAUF == rst.MES_TM_TMINFO_LIST[0].NOBILL && rst_ZBCFUN_GDJGXX_READ.ET_BOM[i].KDPOS == rst.MES_TM_TMINFO_LIST[0].NOBILLMX)
                                                            {
                                                                tmcount = tmcount + 1;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            tmcount = tmcount + 1;
                                                        }
                                                    }
                                                }
                                                if (tmcount == 0)
                                                {
                                                    child_MES_RETURN.TYPE = "E";
                                                    child_MES_RETURN.MESSAGE = "投料物料号与工单不匹配！";
                                                    rst.MES_RETURN = child_MES_RETURN;
                                                    MES_PD_TL_ERROR model_MES_PD_TL_ERROR = new MES_PD_TL_ERROR();
                                                    model_MES_PD_TL_ERROR.RWBH = model.RWBH;
                                                    model_MES_PD_TL_ERROR.TM = model.TM;
                                                    model_MES_PD_TL_ERROR.JLR = model.JLR;
                                                    model_MES_PD_TL_ERROR.ERRORINFO = "工单未开放校验，校验物料号无法通过！";
                                                    model_MES_PD_TL_ERROR.TLLB = TLLB;
                                                    IPD_TL_ERRORdata.INSERT(model_MES_PD_TL_ERROR);
                                                }
                                                else
                                                {
                                                    if (ISINSERT == 0)
                                                    {
                                                        child_MES_RETURN.TYPE = "S";
                                                        child_MES_RETURN.MESSAGE = "";
                                                        rst.MES_RETURN = child_MES_RETURN;
                                                    }
                                                    else
                                                    {
                                                        MES_RETURN mr = new MES_RETURN();
                                                        MES_PD_TL model_MES_PD_TL = new MES_PD_TL();
                                                        model_MES_PD_TL.GC = model.GC;
                                                        model_MES_PD_TL.RWBH = model.RWBH;
                                                        model_MES_PD_TL.TM = model.TM;
                                                        model_MES_PD_TL.JLR = model.JLR;
                                                        model_MES_PD_TL.TLLB = TLLB;
                                                        model_MES_PD_TL.REMARK = model.TLREMARK;
                                                        mr = PD_TLservice.INSERT(model_MES_PD_TL);
                                                        rst.MES_RETURN = mr;
                                                        rst.MES_TM_TMINFO_LIST[0].TLTMID = mr.TID;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                int tmcount = 0;
                                                for (int i = 0; i < rst_ZBCFUN_GDJGXX_READ.ET_BOM.Count; i++)
                                                {
                                                    if (rst_ZBCFUN_GDJGXX_READ.ET_BOM[i].WLLBNAME == rst.MES_TM_TMINFO_LIST[0].WLLBNAME)
                                                    {
                                                        tmcount = tmcount + 1;
                                                    }
                                                }
                                                if (tmcount == 0)
                                                {
                                                    child_MES_RETURN.TYPE = "E";
                                                    child_MES_RETURN.MESSAGE = "投料物料号与工单不匹配！";
                                                    rst.MES_RETURN = child_MES_RETURN;
                                                    MES_PD_TL_ERROR model_MES_PD_TL_ERROR = new MES_PD_TL_ERROR();
                                                    model_MES_PD_TL_ERROR.RWBH = model.RWBH;
                                                    model_MES_PD_TL_ERROR.TM = model.TM;
                                                    model_MES_PD_TL_ERROR.JLR = model.JLR;
                                                    model_MES_PD_TL_ERROR.ERRORINFO = "工单已开放校验，校验物料类别无法通过！";
                                                    model_MES_PD_TL_ERROR.TLLB = TLLB;
                                                    IPD_TL_ERRORdata.INSERT(model_MES_PD_TL_ERROR);
                                                }
                                                else
                                                {
                                                    if (ISINSERT == 0)
                                                    {
                                                        child_MES_RETURN.TYPE = "S";
                                                        child_MES_RETURN.MESSAGE = "";
                                                        rst.MES_RETURN = child_MES_RETURN;
                                                    }
                                                    else
                                                    {
                                                        MES_RETURN mr = new MES_RETURN();
                                                        MES_PD_TL model_MES_PD_TL = new MES_PD_TL();
                                                        model_MES_PD_TL.GC = model.GC;
                                                        model_MES_PD_TL.RWBH = model.RWBH;
                                                        model_MES_PD_TL.TM = model.TM;
                                                        model_MES_PD_TL.JLR = model.JLR;
                                                        model_MES_PD_TL.TLLB = TLLB;
                                                        model_MES_PD_TL.REMARK = model.TLREMARK;
                                                        mr = PD_TLservice.INSERT(model_MES_PD_TL);
                                                        rst.MES_RETURN = mr;
                                                        rst.MES_TM_TMINFO_LIST[0].TLTMID = mr.TID;
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            child_MES_RETURN.TYPE = "E";
                                            child_MES_RETURN.MESSAGE = "该任务没有BOM,无法进行校验！";
                                            rst.MES_RETURN = child_MES_RETURN;
                                        }
                                    }
                                    else
                                    {
                                        rst.MES_RETURN = rst_ZBCFUN_GDJGXX_READ.MES_RETURN;
                                    }
                                }
                                else if (rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].GDLB == 2)
                                {
                                    if (rst.MES_TM_TMINFO_LIST[0].WLLBNAME != "密封圈" || rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].WLH != rst.MES_TM_TMINFO_LIST[0].WLH)
                                    {
                                        child_MES_RETURN.TYPE = "E";
                                        child_MES_RETURN.MESSAGE = "投料物料号与工单不匹配！";
                                        rst.MES_RETURN = child_MES_RETURN;
                                        MES_PD_TL_ERROR model_MES_PD_TL_ERROR = new MES_PD_TL_ERROR();
                                        model_MES_PD_TL_ERROR.RWBH = model.RWBH;
                                        model_MES_PD_TL_ERROR.TM = model.TM;
                                        model_MES_PD_TL_ERROR.JLR = model.JLR;
                                        model_MES_PD_TL_ERROR.ERRORINFO = "密封圈校验无法通过！";
                                        model_MES_PD_TL_ERROR.TLLB = TLLB;
                                        IPD_TL_ERRORdata.INSERT(model_MES_PD_TL_ERROR);
                                    }
                                    else
                                    {
                                        if (ISINSERT == 0)
                                        {
                                            child_MES_RETURN.TYPE = "S";
                                            child_MES_RETURN.MESSAGE = "";
                                            rst.MES_RETURN = child_MES_RETURN;
                                        }
                                        else
                                        {
                                            MES_RETURN mr = new MES_RETURN();
                                            MES_PD_TL model_MES_PD_TL = new MES_PD_TL();
                                            model_MES_PD_TL.GC = model.GC;
                                            model_MES_PD_TL.RWBH = model.RWBH;
                                            model_MES_PD_TL.TM = model.TM;
                                            model_MES_PD_TL.JLR = model.JLR;
                                            model_MES_PD_TL.TLLB = TLLB;
                                            model_MES_PD_TL.REMARK = model.TLREMARK;
                                            mr = PD_TLservice.INSERT(model_MES_PD_TL);
                                            rst.MES_RETURN = mr;
                                            rst.MES_TM_TMINFO_LIST[0].TLTMID = mr.TID;
                                        }
                                    }
                                }
                                if (rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].GDLB == 3)
                                {
                                    MES_PD_GD_BOM model_MES_PD_GD_BOM = new MES_PD_GD_BOM();
                                    model_MES_PD_GD_BOM.GDDH = rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].GDDH;
                                    MES_PD_GD_BOM_SELECT rst_MES_PD_GD_BOM_SELECT = dataPD_GD_BOM.SELECT(model_MES_PD_GD_BOM);
                                    if (rst_MES_PD_GD_BOM_SELECT.MES_PD_GD_BOM.Count > 0)
                                    {
                                        if (rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].ISOPEN == 0)
                                        {
                                            int tmcount = 0;
                                            for (int i = 0; i < rst_MES_PD_GD_BOM_SELECT.MES_PD_GD_BOM.Count; i++)
                                            {
                                                if (rst_MES_PD_GD_BOM_SELECT.MES_PD_GD_BOM[i].WLH == rst.MES_TM_TMINFO_LIST[0].WLH)
                                                {
                                                    tmcount = tmcount + 1;
                                                }
                                            }
                                            if (tmcount == 0)
                                            {
                                                child_MES_RETURN.TYPE = "E";
                                                child_MES_RETURN.MESSAGE = "投料物料号与工单不匹配！";
                                                rst.MES_RETURN = child_MES_RETURN;
                                                MES_PD_TL_ERROR model_MES_PD_TL_ERROR = new MES_PD_TL_ERROR();
                                                model_MES_PD_TL_ERROR.RWBH = model.RWBH;
                                                model_MES_PD_TL_ERROR.TM = model.TM;
                                                model_MES_PD_TL_ERROR.JLR = model.JLR;
                                                model_MES_PD_TL_ERROR.ERRORINFO = "工单未开放校验，校验物料号无法通过！";
                                                model_MES_PD_TL_ERROR.TLLB = TLLB;
                                                IPD_TL_ERRORdata.INSERT(model_MES_PD_TL_ERROR);
                                            }
                                            else
                                            {
                                                if (ISINSERT == 0)
                                                {
                                                    child_MES_RETURN.TYPE = "S";
                                                    child_MES_RETURN.MESSAGE = "";
                                                    rst.MES_RETURN = child_MES_RETURN;
                                                }
                                                else
                                                {
                                                    MES_RETURN mr = new MES_RETURN();
                                                    MES_PD_TL model_MES_PD_TL = new MES_PD_TL();
                                                    model_MES_PD_TL.GC = model.GC;
                                                    model_MES_PD_TL.RWBH = model.RWBH;
                                                    model_MES_PD_TL.TM = model.TM;
                                                    model_MES_PD_TL.JLR = model.JLR;
                                                    model_MES_PD_TL.TLLB = TLLB;
                                                    model_MES_PD_TL.REMARK = model.TLREMARK;
                                                    mr = PD_TLservice.INSERT(model_MES_PD_TL);
                                                    rst.MES_RETURN = mr;
                                                    rst.MES_TM_TMINFO_LIST[0].TLTMID = mr.TID;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            int tmcount = 0;
                                            for (int i = 0; i < rst_MES_PD_GD_BOM_SELECT.MES_PD_GD_BOM.Count; i++)
                                            {
                                                if (rst_MES_PD_GD_BOM_SELECT.MES_PD_GD_BOM[i].WLLBNAME == rst.MES_TM_TMINFO_LIST[0].WLLBNAME)
                                                {
                                                    tmcount = tmcount + 1;
                                                }
                                            }
                                            if (tmcount == 0)
                                            {
                                                child_MES_RETURN.TYPE = "E";
                                                child_MES_RETURN.MESSAGE = "投料物料号与工单不匹配！";
                                                rst.MES_RETURN = child_MES_RETURN;
                                                MES_PD_TL_ERROR model_MES_PD_TL_ERROR = new MES_PD_TL_ERROR();
                                                model_MES_PD_TL_ERROR.RWBH = model.RWBH;
                                                model_MES_PD_TL_ERROR.TM = model.TM;
                                                model_MES_PD_TL_ERROR.JLR = model.JLR;
                                                model_MES_PD_TL_ERROR.ERRORINFO = "工单已开放校验，校验物料类别无法通过！";
                                                model_MES_PD_TL_ERROR.TLLB = TLLB;
                                                IPD_TL_ERRORdata.INSERT(model_MES_PD_TL_ERROR);
                                            }
                                            else
                                            {
                                                if (ISINSERT == 0)
                                                {
                                                    child_MES_RETURN.TYPE = "S";
                                                    child_MES_RETURN.MESSAGE = "";
                                                    rst.MES_RETURN = child_MES_RETURN;
                                                }
                                                else
                                                {
                                                    MES_RETURN mr = new MES_RETURN();
                                                    MES_PD_TL model_MES_PD_TL = new MES_PD_TL();
                                                    model_MES_PD_TL.GC = model.GC;
                                                    model_MES_PD_TL.RWBH = model.RWBH;
                                                    model_MES_PD_TL.TM = model.TM;
                                                    model_MES_PD_TL.JLR = model.JLR;
                                                    model_MES_PD_TL.TLLB = TLLB;
                                                    model_MES_PD_TL.REMARK = model.TLREMARK;
                                                    mr = PD_TLservice.INSERT(model_MES_PD_TL);
                                                    rst.MES_RETURN = mr;
                                                    rst.MES_TM_TMINFO_LIST[0].TLTMID = mr.TID;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        child_MES_RETURN.TYPE = "E";
                                        child_MES_RETURN.MESSAGE = "该任务没有BOM,无法进行校验！";
                                        rst.MES_RETURN = child_MES_RETURN;
                                    }
                                }
                            }
                        }
                        else
                        {
                            rst.MES_RETURN = rst_SELECT_MES_PD_SCRW.MES_RETURN;
                        }
                    }
                    else
                    {
                        child_MES_RETURN.TYPE = "E";
                        child_MES_RETURN.MESSAGE = "条码不是合格状态，请检查！";
                        rst.MES_RETURN = child_MES_RETURN;
                    }
                }
                else
                {
                    child_MES_RETURN.TYPE = "E";
                    child_MES_RETURN.MESSAGE = "领用表无法参与投料！";
                    rst.MES_RETURN = child_MES_RETURN;
                }
            }
            return rst;
        }

        public MES_TM_TMINFO_INSERT_RETURN INSERT(MES_TM_TMINFO_INSERT_GL model, string YEAR, int ISAUTOADD)
        {

            MES_TM_TMINFO_INSERT_RETURN rst_MES_TM_TMINFO_INSERT_RETURN = new MES_TM_TMINFO_INSERT_RETURN();
            List<SELECT_MES_TM_TMINFO_PRINT> rst = new List<SELECT_MES_TM_TMINFO_PRINT>();
            MES_RETURN mr_rst = new MES_RETURN();
            if (model.MES_TM_TMINFO.UPPERTM != "" && model.MES_TM_TMINFO.UPPERTM != null)
            {
                SELECT_MES_TM_TMINFO_PRINT rst_SELECT_MES_TM_TMINFO_PRINT = SELECT_BYID_CHILD(model.MES_TM_TMINFO.GC, model.MES_TM_TMINFO.UPPERTM);
                if (rst_SELECT_MES_TM_TMINFO_PRINT.MES_RETURN.TYPE == "S")
                {
                    if (rst_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST.TMLB == 2)
                    {
                        if (model.MES_TM_TMINFO.RWBH == rst_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST.RWBH)
                        {
                            if (model.MES_TM_GL.Count == rst_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST_CHILD.Count)
                            {
                                if (model.MES_TM_GL.Count > 0)
                                {
                                    int nocount = 0;
                                    for (int i = 0; i < model.MES_TM_GL.Count; i++)
                                    {
                                        int sum = 0;
                                        for (int j = 0; j < rst_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST_CHILD.Count; j++)
                                        {
                                            if (model.MES_TM_GL[i].XCTM == rst_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST_CHILD[j].TM && model.MES_TM_GL[i].XCTMGC == rst_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST_CHILD[j].GC)
                                            {
                                                sum = 1;
                                                break;
                                            }
                                        }
                                        if (sum == 0)
                                        {
                                            nocount = nocount + 1;
                                        }
                                    }
                                    if (nocount > 0)
                                    {
                                        mr_rst.TYPE = "E";
                                        mr_rst.MESSAGE = "下层条码条码信息不匹配！";
                                    }
                                    else
                                    {
                                        mr_rst.TYPE = "S";
                                        mr_rst.MESSAGE = "";
                                    }
                                }
                            }
                            else
                            {
                                mr_rst.TYPE = "E";
                                mr_rst.MESSAGE = "下层条码组件数量不匹配！";
                            }
                        }
                        else
                        {
                            mr_rst.TYPE = "E";
                            mr_rst.MESSAGE = "上级条码任务单号不匹配！";
                        }
                    }
                    else
                    {
                        mr_rst.TYPE = "E";
                        mr_rst.MESSAGE = "上层条码不是领用表！";
                    }
                }
                else
                {
                    mr_rst.TYPE = "E";
                    mr_rst.MESSAGE = rst_SELECT_MES_TM_TMINFO_PRINT.MES_RETURN.MESSAGE;
                }
                rst_MES_TM_TMINFO_INSERT_RETURN.MES_RETURN = mr_rst;
            }
            else
            {
                mr_rst.TYPE = "S";
                mr_rst.MESSAGE = "";
            }
            if (mr_rst.TYPE == "S")
            {
                bool istpm = false;
                MES_RETURN mr = new MES_RETURN();
                if (model.MES_TM_TMINFO.TMCOUNT > 0)
                {
                    int TH = model.MES_TM_TMINFO.TH;
                    //if (model.MES_TM_TMINFO.TH == 0)
                    //{
                    //    TH = 0;
                    //}
                    //else
                    //{
                    //    TH = model.MES_TM_TMINFO.TH;
                    //}
                    for (int i = 0; i < model.MES_TM_TMINFO.TMCOUNT; i++)
                    {
                        if (model.MES_TM_TMINFO.GC != "")
                        {
                            if (TH > 0 && ISAUTOADD == 1)
                            {
                                model.MES_TM_TMINFO.TH = TH + i;
                            }
                            if (model.MES_TM_TMINFO.TPM != "" && model.MES_TM_TMINFO.TPM != null)
                            {
                                istpm = true;
                                MES_TM_TMINFO model_TPM = new MES_TM_TMINFO();
                                model_TPM.TPM = model.MES_TM_TMINFO.TPM;
                                SELECT_MES_TM_TMINFO_BYTM rst_TM_BY_TPM = SELECT(model_TPM, 0);
                                if (rst_TM_BY_TPM.MES_RETURN.TYPE == "S")
                                {
                                    if (rst_TM_BY_TPM.MES_TM_TMINFO_LIST.Count > 0)
                                    {
                                        model.MES_TM_TMINFO.TM = rst_TM_BY_TPM.MES_TM_TMINFO_LIST[0].TM;
                                        TM_GLservice.DELETE_BY_SCTM(rst_TM_BY_TPM.MES_TM_TMINFO_LIST[0].TM);
                                        DELETE(rst_TM_BY_TPM.MES_TM_TMINFO_LIST[0].TM);
                                        MES_SY_YERACOUNT model_MES_SY_YERACOUNT = new MES_SY_YERACOUNT();
                                        model_MES_SY_YERACOUNT.TMLB = 1;
                                        model_MES_SY_YERACOUNT.GC = model.MES_TM_TMINFO.GC;
                                        model_MES_SY_YERACOUNT.TMYEAR = YEAR;
                                        model.MES_TM_TMINFO.TM = SY_YERACOUNTservice.SELECT(model_MES_SY_YERACOUNT);
                                        mr = mesdetaAccess.INSERT(model.MES_TM_TMINFO);
                                    }
                                    else
                                    {
                                        MES_SY_YERACOUNT model_MES_SY_YERACOUNT = new MES_SY_YERACOUNT();
                                        model_MES_SY_YERACOUNT.TMLB = 1;
                                        model_MES_SY_YERACOUNT.GC = model.MES_TM_TMINFO.GC;
                                        model_MES_SY_YERACOUNT.TMYEAR = YEAR;
                                        model.MES_TM_TMINFO.TM = SY_YERACOUNTservice.SELECT(model_MES_SY_YERACOUNT);
                                        mr = mesdetaAccess.INSERT(model.MES_TM_TMINFO);
                                    }
                                }
                                else
                                {
                                    MES_SY_YERACOUNT model_MES_SY_YERACOUNT = new MES_SY_YERACOUNT();
                                    model_MES_SY_YERACOUNT.TMLB = 1;
                                    model_MES_SY_YERACOUNT.GC = model.MES_TM_TMINFO.GC;
                                    model_MES_SY_YERACOUNT.TMYEAR = YEAR;
                                    model.MES_TM_TMINFO.TM = SY_YERACOUNTservice.SELECT(model_MES_SY_YERACOUNT);
                                    mr = mesdetaAccess.INSERT(model.MES_TM_TMINFO);
                                }
                            }
                            else
                            {
                                istpm = false;
                                MES_SY_YERACOUNT model_MES_SY_YERACOUNT = new MES_SY_YERACOUNT();
                                model_MES_SY_YERACOUNT.TMLB = 1;
                                model_MES_SY_YERACOUNT.GC = model.MES_TM_TMINFO.GC;
                                model_MES_SY_YERACOUNT.TMYEAR = YEAR;
                                model.MES_TM_TMINFO.TM = SY_YERACOUNTservice.SELECT(model_MES_SY_YERACOUNT);
                                mr = mesdetaAccess.INSERT(model.MES_TM_TMINFO);
                            }
                            if (mr.TYPE == "S")
                            {
                                if (model.MES_TM_GL.Count > 0)
                                {
                                    for (int j = 0; j < model.MES_TM_GL.Count; j++)
                                    {
                                        model.MES_TM_GL[j].SCTMGC = model.MES_TM_TMINFO.GC;
                                        model.MES_TM_GL[j].SCTM = model.MES_TM_TMINFO.TM;
                                        model.MES_TM_GL[j].GLLB = 1;
                                    }
                                    if (model.MES_TM_TMINFO.UPPERTM != "" && model.MES_TM_TMINFO.UPPERTM != null)
                                    {
                                        MES_TM_GL model_MES_TM_GL = new MES_TM_GL();
                                        model_MES_TM_GL.SCTMGC = model.MES_TM_TMINFO.GC;
                                        model_MES_TM_GL.SCTM = model.MES_TM_TMINFO.UPPERTM;
                                        model_MES_TM_GL.XCTMGC = model.MES_TM_TMINFO.GC;
                                        model_MES_TM_GL.XCTM = model.MES_TM_TMINFO.TM;
                                        model_MES_TM_GL.GLLB = 2;
                                        List<MES_TM_GL> model_MES_TM_GL_list = new List<MES_TM_GL>();
                                        model_MES_TM_GL_list.Add(model_MES_TM_GL);
                                        TM_GLservice.INSERT(model_MES_TM_GL_list, 0);
                                    }
                                }
                                TM_GLservice.INSERT(model.MES_TM_GL, mr.TID);
                            }
                            if (mr.TYPE == "S" && istpm == false)
                            {
                                SELECT_MES_TM_TMINFO_PRINT child_SELECT_MES_TM_TMINFO_PRINT = SELECT_BYID_CHILD(mr.GC, mr.TM);
                                rst.Add(child_SELECT_MES_TM_TMINFO_PRINT);
                                MES_PD_SCRW_ZXCC_INSERT model_MES_PD_SCRW_ZXCC_INSERT = new MES_PD_SCRW_ZXCC_INSERT();
                                model_MES_PD_SCRW_ZXCC_INSERT.RWBH = child_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST.RWBH;
                                model_MES_PD_SCRW_ZXCC_INSERT.TH = child_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST.TH;
                                model_MES_PD_SCRW_ZXCC_INSERT.KSTIME = child_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST.KSTIME;
                                model_MES_PD_SCRW_ZXCC_INSERT.JSTIME = child_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST.JSTIME;
                                model_MES_PD_SCRW_ZXCC_INSERT.BC = child_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST.BC;
                                if (child_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST.ZFDCLB > 0)
                                {
                                    IPD_SCRWdate.UPDATE_ZX_CC(model_MES_PD_SCRW_ZXCC_INSERT, 1);
                                }
                                else
                                {
                                    IPD_SCRWdate.UPDATE_ZX_CC(model_MES_PD_SCRW_ZXCC_INSERT, 0);
                                }
                            }
                        }
                        else
                        {
                            mr.TYPE = "E";
                            mr.MESSAGE = "工厂不能为空！";
                        }
                    }
                }
                else
                {
                    mr.TYPE = "E";
                    mr.MESSAGE = "生成条码数量不能为0！";
                }

                rst_MES_TM_TMINFO_INSERT_RETURN.MES_RETURN = mr;
            }
            rst_MES_TM_TMINFO_INSERT_RETURN.SELECT_MES_TM_TMINFO_PRINT = rst;
            return rst_MES_TM_TMINFO_INSERT_RETURN;
        }

        public SELECT_MES_TM_TMINFO_PRINT SELECT_BYID_CHILD(string GC, string TM)
        {
            MES_RETURN mr = new MES_RETURN();
            MES_TM_TMINFO model_MES_TM_TMINFO = new MES_TM_TMINFO();
            model_MES_TM_TMINFO.GC = GC;
            model_MES_TM_TMINFO.TM = TM;
            SELECT_MES_TM_TMINFO_PRINT rst = new SELECT_MES_TM_TMINFO_PRINT();
            SELECT_MES_TM_TMINFO_BYTM child_SELECT_MES_TM_TMINFO_BYTM = mesdetaAccess.SELECT_BYTM(model_MES_TM_TMINFO, 1);
            if (child_SELECT_MES_TM_TMINFO_BYTM.MES_RETURN.TYPE == "S")
            {
                if (child_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST.Count == 1)
                {
                    model_MES_TM_TMINFO.WLLB = child_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0].WLLB;
                    rst.MES_TM_TMINFO_LIST = child_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0];
                    mr.TYPE = "S";
                    mr.MESSAGE = "";
                    string czr = "";
                    MES_TM_CZR model_MES_TM_CZR = new MES_TM_CZR();
                    model_MES_TM_CZR.GC = rst.MES_TM_TMINFO_LIST.GC;
                    model_MES_TM_CZR.RWBH = rst.MES_TM_TMINFO_LIST.RWBH;
                    model_MES_TM_CZR.SBBH = rst.MES_TM_TMINFO_LIST.SBBH;
                    if (rst.MES_TM_TMINFO_LIST.WLLBNAME == "锌膏")
                    {
                        model_MES_TM_CZR.CZLB = 2;
                    }
                    else if (rst.MES_TM_TMINFO_LIST.MID != "")
                    {
                        model_MES_TM_CZR.CZLB = 3;
                    }
                    else
                    {
                        model_MES_TM_CZR.CZLB = 1;
                    }
                    model_MES_TM_CZR.CZSJ = rst.MES_TM_TMINFO_LIST.JLTIME;
                    List<MES_TM_CZR> child_czr = TM_CZRService.SELECT_CZR_NOW(model_MES_TM_CZR).MES_TM_CZR;
                    if (child_czr.Count > 0)
                    {
                        for (int i = 0; i < child_czr.Count; i++)
                        {
                            if (i != 0)
                            {
                                czr = czr + ",";
                            }
                            czr = czr + child_czr[i].CZRNAME;
                        }
                    }
                    rst.CZR = czr;

                    child_SELECT_MES_TM_TMINFO_BYTM = mesdetaAccess.SELECT_BYTM(model_MES_TM_TMINFO, 2);
                    if (child_SELECT_MES_TM_TMINFO_BYTM.MES_RETURN.TYPE == "S")
                    {
                        rst.MES_TM_TMINFO_LIST_CHILD = child_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST;
                    }
                    else
                    {
                        List<MES_TM_TMINFO_LIST> model_MES_TM_TMINFO_LIST = new List<MES_TM_TMINFO_LIST>();
                        rst.MES_TM_TMINFO_LIST_CHILD = model_MES_TM_TMINFO_LIST;
                        //mr = child_SELECT_MES_TM_TMINFO_BYTM.MES_RETURN;
                    }

                    MES_TM_ZFDCMX_SELECT rst_MES_TM_ZFDCMX_SELECT = ITM_ZFDCMXdata.SELECT(rst.MES_TM_TMINFO_LIST.TM);
                    if (rst_MES_TM_ZFDCMX_SELECT.MES_RETURN.TYPE == "S")
                    {
                        rst.MES_TM_ZFDCMX = rst_MES_TM_ZFDCMX_SELECT.MES_TM_ZFDCMX;
                    }
                    else
                    {
                        List<MES_TM_ZFDCMX> model_MES_TM_ZFDCMX = new List<MES_TM_ZFDCMX>();
                        rst.MES_TM_ZFDCMX = model_MES_TM_ZFDCMX;
                    }
                }
                else
                {
                    if (TM == "")
                    {
                        mr.TYPE = "E";
                        mr.MESSAGE = "该ID没有数据";
                    }
                    else
                    {
                        mr.TYPE = "E";
                        mr.MESSAGE = TM + "没有数据";
                    }
                }
            }
            else
            {
                if (TM == "")
                {
                    mr.TYPE = "E";
                    mr.MESSAGE = "该ID没有数据";
                }
                else
                {
                    mr.TYPE = "E";
                    mr.MESSAGE = TM + "没有数据";
                }
            }
            if (mr.TYPE == "E")
            {

                List<MES_TM_TMINFO_LIST> model_MES_TM_TMINFO_LIST = new List<MES_TM_TMINFO_LIST>();
                MES_TM_TMINFO_LIST child_MES_TM_TMINFO_LIST = new MES_TM_TMINFO_LIST();
                rst.MES_TM_TMINFO_LIST = child_MES_TM_TMINFO_LIST;
                rst.MES_TM_TMINFO_LIST_CHILD = model_MES_TM_TMINFO_LIST;
                List<MES_TM_ZFDCMX> model_MES_TM_ZFDCMX = new List<MES_TM_ZFDCMX>();
                rst.MES_TM_ZFDCMX = model_MES_TM_ZFDCMX;
                rst.MES_RETURN = mr;
                return rst;
            }
            rst.MES_RETURN = mr;
            if (rst.MES_RETURN.TYPE == "S" && rst.MES_TM_TMINFO_LIST_CHILD.Count > 0)
            {
                List<MES_TM_TMINFO_LIST> rst_MES_TM_TMINFO_LIST = rst.MES_TM_TMINFO_LIST_CHILD;
                for (int i = 0; i < rst_MES_TM_TMINFO_LIST.Count; i++)
                {
                    if (rst.MES_TM_TMINFO_LIST_CHILD[i].WLLBNAME == "电镀铜钉" || rst.MES_TM_TMINFO_LIST_CHILD[i].WLLBNAME == "密封圈")
                    {
                        model_MES_TM_TMINFO = new MES_TM_TMINFO();
                        model_MES_TM_TMINFO.GC = rst_MES_TM_TMINFO_LIST[i].GC;
                        model_MES_TM_TMINFO.TM = rst_MES_TM_TMINFO_LIST[i].TM;
                        model_MES_TM_TMINFO.WLLB = rst.MES_TM_TMINFO_LIST.WLLB;
                        child_SELECT_MES_TM_TMINFO_BYTM = mesdetaAccess.SELECT_BYTM(model_MES_TM_TMINFO, 2);
                        if (child_SELECT_MES_TM_TMINFO_BYTM.MES_RETURN.TYPE == "S")
                        {
                            if (child_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST.Count > 0)
                            {
                                for (int j = 0; j < child_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST.Count; j++)
                                {
                                    rst.MES_TM_TMINFO_LIST_CHILD.Add(child_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[j]);
                                }
                            }
                        }
                    }
                }
                rst.MES_TM_TMINFO_LIST_CHILD = rst.MES_TM_TMINFO_LIST_CHILD.OrderBy(u => u.WLLBPX).ToList();
                MES_SY_TYPEMX_CHILD model_MES_SY_TYPEMX_CHILD = new MES_SY_TYPEMX_CHILD();
                model_MES_SY_TYPEMX_CHILD.ID = rst.MES_TM_TMINFO_LIST.WLLB;
                model_MES_SY_TYPEMX_CHILD.ISSHOW = 1;
                MES_SY_TYPEMX_CHILD_SELECT rst_MES_SY_TYPEMX_CHILD_SELECT = ISY_TYPEMX_CHILDdata.SELECT(model_MES_SY_TYPEMX_CHILD);
                model_MES_SY_TYPEMX_CHILD = new MES_SY_TYPEMX_CHILD();
                model_MES_SY_TYPEMX_CHILD.ID = rst.MES_TM_TMINFO_LIST.WLLB;
                model_MES_SY_TYPEMX_CHILD.ISSHOW = 0;
                MES_SY_TYPEMX_CHILD_SELECT rst_MES_SY_TYPEMX_CHILD_SELECT_NOSHOW = ISY_TYPEMX_CHILDdata.SELECT(model_MES_SY_TYPEMX_CHILD);
                if (rst_MES_SY_TYPEMX_CHILD_SELECT.MES_RETURN.TYPE == "S")
                {
                    if (rst_MES_SY_TYPEMX_CHILD_SELECT.MES_SY_TYPEMX_CHILD.Count > 0)
                    {
                        List<MES_TM_TMINFO_LIST> model_MES_TM_TMINFO_LIST_px = new List<MES_TM_TMINFO_LIST>();
                        for (int i = 0; i < rst.MES_TM_TMINFO_LIST_CHILD.Count; i++)
                        {
                            int isshow = 0;
                            for (int j = 0; j < rst_MES_SY_TYPEMX_CHILD_SELECT.MES_SY_TYPEMX_CHILD.Count; j++)
                            {
                                if (rst.MES_TM_TMINFO_LIST_CHILD[i].WLLB == rst_MES_SY_TYPEMX_CHILD_SELECT.MES_SY_TYPEMX_CHILD[j].ZTYPEID)
                                {
                                    isshow = rst_MES_SY_TYPEMX_CHILD_SELECT.MES_SY_TYPEMX_CHILD[j].ISSHOW;
                                }
                            }
                            if (rst.MES_TM_TMINFO_LIST.WLLBNAME == "集电体")
                            {
                                if (rst.MES_TM_TMINFO_LIST_CHILD[i].WLLBNAME == "密封圈" && rst.MES_TM_TMINFO_LIST_CHILD[i].GZZXBH != "")
                                {
                                    isshow = 0;
                                }
                                if (rst.MES_TM_TMINFO_LIST_CHILD[i].WLLBNAME == "电镀铜钉")
                                {
                                    for (int j = 0; j < rst.MES_TM_TMINFO_LIST_CHILD.Count; j++)
                                    {
                                        if (rst.MES_TM_TMINFO_LIST_CHILD[j].WLLBNAME == "黄铜钉")
                                        {
                                            rst.MES_TM_TMINFO_LIST_CHILD[i].GYSMS = rst.MES_TM_TMINFO_LIST_CHILD[j].GYSMS + "/" + rst.MES_TM_TMINFO_LIST_CHILD[i].GYSMS;
                                        }
                                    }
                                }
                            }
                            if (isshow == 1)
                            {
                                model_MES_TM_TMINFO_LIST_px.Add(rst.MES_TM_TMINFO_LIST_CHILD[i]);
                            }
                        }
                        rst.MES_TM_TMINFO_LIST_CHILD = model_MES_TM_TMINFO_LIST_px;
                    }
                    else if (rst_MES_SY_TYPEMX_CHILD_SELECT_NOSHOW.MES_SY_TYPEMX_CHILD.Count > 0)
                    {
                        List<MES_TM_TMINFO_LIST> model_MES_TM_TMINFO_LIST_px = new List<MES_TM_TMINFO_LIST>();
                        for (int i = 0; i < rst.MES_TM_TMINFO_LIST_CHILD.Count; i++)
                        {
                            int isshow = 1;
                            for (int j = 0; j < rst_MES_SY_TYPEMX_CHILD_SELECT.MES_SY_TYPEMX_CHILD.Count; i++)
                            {
                                if (rst.MES_TM_TMINFO_LIST_CHILD[i].WLLB == rst_MES_SY_TYPEMX_CHILD_SELECT.MES_SY_TYPEMX_CHILD[j].ZTYPEID)
                                {
                                    isshow = rst_MES_SY_TYPEMX_CHILD_SELECT.MES_SY_TYPEMX_CHILD[j].ISSHOW;
                                }
                            }
                            if (isshow == 1)
                            {
                                model_MES_TM_TMINFO_LIST_px.Add(rst.MES_TM_TMINFO_LIST_CHILD[i]);
                            }
                        }
                        rst.MES_TM_TMINFO_LIST_CHILD = model_MES_TM_TMINFO_LIST_px;
                    }
                }
                else
                {
                    List<MES_TM_TMINFO_LIST> model_MES_TM_TMINFO_LIST = new List<MES_TM_TMINFO_LIST>();
                    MES_TM_TMINFO_LIST child_MES_TM_TMINFO_LIST = new MES_TM_TMINFO_LIST();
                    rst.MES_TM_TMINFO_LIST = child_MES_TM_TMINFO_LIST;
                    rst.MES_TM_TMINFO_LIST_CHILD = model_MES_TM_TMINFO_LIST;
                    List<MES_TM_ZFDCMX> model_MES_TM_ZFDCMX = new List<MES_TM_ZFDCMX>();
                    rst.MES_TM_ZFDCMX = model_MES_TM_ZFDCMX;
                    rst.MES_RETURN = rst_MES_SY_TYPEMX_CHILD_SELECT.MES_RETURN;
                    return rst;
                }
            }
            return rst;
        }

        public MES_RETURN INSERT_ONLY(MES_TM_TMINFO model)
        {
            MES_SY_YERACOUNT model_MES_SY_YERACOUNT = new MES_SY_YERACOUNT();
            model_MES_SY_YERACOUNT.TMLB = 1;
            model_MES_SY_YERACOUNT.GC = model.GC;
            model.TM = SY_YERACOUNTservice.SELECT(model_MES_SY_YERACOUNT);

            return mesdetaAccess.INSERT(model);
        }


        public SELECT_MES_TM_TMINFO_BYTM SELECT_TL_LAST(string RWBH)
        {
            return mesdetaAccess.SELECT_TL_LAST(RWBH);
        }

        public SELECT_MES_TM_TMINFO_BYTM SELECT(MES_TM_TMINFO model, int CXLB)
        {
            return mesdetaAccess.SELECT(model, CXLB);
        }
        public SELECT_MES_TM_TMINFO_BYTM SELECT_ALL(MES_TM_TMINFO model, int CXLB)
        {
            return mesdetaAccess.SELECT_ALL(model, CXLB);
        }
        public MES_TM_TMINFO_SELECT_TL_GL_CC SELECT_TL_GL_CC(MES_TM_TMINFO model)
        {
            return mesdetaAccess.SELECT_TL_GL_CC(model);
        }

        public MES_RETURN DELETE(string TM)
        {
            return mesdetaAccess.DELETE(TM);
        }

        public MES_RETURN DELETE_LOG(MES_TM_TMINFO_DELETE_IN model)
        {
            return mesdetaAccess.DELETE_LOG(model);
        }

        public SELECT_MES_TM_TMINFO_BYTM SELECT_WLKCBS(MES_WLKCBS_GETWLZJ_IN model)
        {
            SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_TM_TMINFO_LIST> child_MES_TM_TMINFO_LIST = new List<MES_TM_TMINFO_LIST>();
            if (model.TM == "")
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "请输入条码！";
            }
            else if (model.XCBS != "Y")
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "组件标识不是Y，无需进行校验！";
            }
            else
            {
                ZSL_BCS303_BS model_ZSL_BCS303_BS = new ZSL_BCS303_BS();
                model_ZSL_BCS303_BS.MBLNR = model.MBLNR;
                model_ZSL_BCS303_BS.MJAHR = model.MJAHR;
                model_ZSL_BCS303_BS.LINE_ID = model.LINE_ID;
                model_ZSL_BCS303_BS.LIFNR = model.LIFNR;
                model_ZSL_BCS303_BS.XCBS = model.XCBS;
                ZSL_BCS303_CT model_ZSL_BCS303_CT = new ZSL_BCS303_CT();
                ZBCFUN_PURBS_READ rst_ZBCFUN_PURBS_READ = IMES_MMdate.GET_PURBS_READ("C02", model_ZSL_BCS303_CT, model_ZSL_BCS303_BS);
                if (rst_ZBCFUN_PURBS_READ.MES_RETURN.TYPE == "S")
                {
                    if (rst_ZBCFUN_PURBS_READ.ET_PURBS.Count > 0)
                    {
                        MES_TM_TMINFO model_MES_TM_TMINFO = new MES_TM_TMINFO();
                        model_MES_TM_TMINFO.TM = model.TM;
                        SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM = mesdetaAccess.SELECT_BYTM(model_MES_TM_TMINFO, 1);
                        if (rst_SELECT_MES_TM_TMINFO_BYTM.MES_RETURN.TYPE == "S")
                        {
                            if (rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST.Count == 1)
                            {
                                rst.MES_TM_TMINFO_LIST = rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST;
                                int tmcount = 0;
                                for (int i = 0; i < rst_ZBCFUN_PURBS_READ.ET_PURBS.Count; i++)
                                {
                                    if (rst_ZBCFUN_PURBS_READ.ET_PURBS[i].WERKS == rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0].GC && rst_ZBCFUN_PURBS_READ.ET_PURBS[i].MATNR == rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0].WLH && rst_ZBCFUN_PURBS_READ.ET_PURBS[i].CHARG == rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0].PC)
                                    {
                                        tmcount = tmcount + 1;
                                        break;
                                    }
                                }
                                if (tmcount > 0)
                                {
                                    child_MES_RETURN.TYPE = "S";
                                    child_MES_RETURN.MESSAGE = "";
                                    rst.MES_RETURN = child_MES_RETURN;
                                }
                                else
                                {
                                    child_MES_RETURN.TYPE = "E";
                                    child_MES_RETURN.MESSAGE = "组件信息不匹配！";
                                    rst.MES_RETURN = child_MES_RETURN;
                                    return rst;
                                }
                            }
                            else
                            {
                                child_MES_RETURN.TYPE = "E";
                                child_MES_RETURN.MESSAGE = "未查询到条码信息！";
                                rst.MES_RETURN = child_MES_RETURN;
                                return rst;
                            }
                        }
                        else
                        {
                            rst.MES_RETURN = rst_SELECT_MES_TM_TMINFO_BYTM.MES_RETURN;
                            return rst;
                        }
                    }
                    else
                    {
                        child_MES_RETURN.TYPE = "E";
                        child_MES_RETURN.MESSAGE = "查询到的组件为空，无法进行校验！";
                        rst.MES_RETURN = child_MES_RETURN;
                        return rst;
                    }
                }
                else
                {
                    rst.MES_RETURN = rst_ZBCFUN_PURBS_READ.MES_RETURN;
                    return rst;
                }
            }
            rst.MES_RETURN = child_MES_RETURN;
            if (child_MES_RETURN.TYPE == "E")
            {
                rst.MES_TM_TMINFO_LIST = child_MES_TM_TMINFO_LIST;
            }
            return rst;
        }


        public SELECT_MES_TM_TMINFO_BYTM SELECT_GLSELECT(List<MES_TM_TMINFO_LIST> model)
        {
            SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            DataTable dt = new DataTable();
            dt.Columns.Add("TM", typeof(string));
            if (model.Count == 0)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "传入查询数据为空！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
            for (int i = 0; i < model.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = model[i].TM;
                dt.Rows.Add(dr);
            }
            rst = mesdetaAccess.SELECT_GLSELECT(dt);
            return rst;
        }

        public SELECT_MES_TM_TMINFO_BYTM SELECT_GLSELECT_ALL(List<MES_TM_TMINFO_LIST> model)
        {
            SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
            SELECT_MES_TM_TMINFO_BYTM rst1 = new SELECT_MES_TM_TMINFO_BYTM();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            DataTable dt = new DataTable();
            dt.Columns.Add("TM", typeof(string));
            DataTable dttlid = new DataTable();
            dttlid.Columns.Add("TLID", typeof(int));
            if (model.Count == 0)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "传入查询数据为空！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
            for (int i = 0; i < model.Count; i++)
            {
                if (model[i].TM != "")
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = model[i].TM;
                    dt.Rows.Add(dr);
                }
                else
                {
                    DataRow dr = dttlid.NewRow();
                    dr[0] = model[i].TMLB;
                    dttlid.Rows.Add(dr);
                }
            }
            rst = mesdetaAccess.SELECT_GLSELECT_ALL(dt);
            rst1 = mesdetaAccess.SELECT_GLSELECT_ALL_ZS_TL(dttlid);
            if (rst1.MES_RETURN.TYPE != "S")
            {
                return rst1;
            }
            for (int a = 0; a < rst1.MES_TM_TMINFO_LIST.Count; a++)
            {
                rst.MES_TM_TMINFO_LIST.Add(rst1.MES_TM_TMINFO_LIST[a]);
            }
            return rst;
        }

        public MES_RETURN UPDATE(MES_TM_TMINFO model, int LB)
        {
            return mesdetaAccess.UPDATE(model, LB);
        }

        public MES_RETURN UPDATE_CF(MES_TM_TMINFO model)
        {
            if (model.SL > 0)
            {
                MES_SY_YERACOUNT model_MES_SY_YERACOUNT = new MES_SY_YERACOUNT();
                model_MES_SY_YERACOUNT.TMLB = 1;
                model_MES_SY_YERACOUNT.GC = model.GC;
                string NTM = SY_YERACOUNTservice.SELECT(model_MES_SY_YERACOUNT);
                return mesdetaAccess.UPDATE_CF(model, NTM);
            }
            else
            {
                return mesdetaAccess.UPDATE_CF(model, "");
            }
        }
        public MES_RETURN UPDATE_CPZT(List<MES_TM_TMINFO> model)
        {
            MES_RETURN rst_MES_RETURN = new MES_RETURN();
            if (model.Count > 0)
            {
                for (int i = 0; i < model.Count; i++)
                {
                    rst_MES_RETURN = mesdetaAccess.UPDATE(model[i], 4);
                }
            }
            return rst_MES_RETURN;
        }
        public MES_RETURN VERIFY_TPMTH(string OLDTPM, string NEWTPM)
        {
            MES_RETURN rst = new MES_RETURN();
            MES_TM_TMINFO model_MES_TM_TMINFO = new MES_TM_TMINFO();
            model_MES_TM_TMINFO.TPM = OLDTPM;
            SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM = SELECT(model_MES_TM_TMINFO, 0);
            if (rst_SELECT_MES_TM_TMINFO_BYTM.MES_RETURN.TYPE == "S")
            {
                if (rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST.Count == 0)
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "托盘码数据在条码中不存在，请检查托盘码！";
                    return rst;
                }
                else
                {
                    if (rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0].GC == "1000" || rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0].GC == "4000" || rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0].GC == "5000")
                    {
                        ZBCFUN_CPBZ_READ rst_ZBCFUN_CPBZ_READ = new ZBCFUN_CPBZ_READ();
                        string mes_werks_pdly = "";
                        mes_werks_pdly = ISY_SYSCSdata.SELECT("MES_TPM");
                        if (mes_werks_pdly == "0")
                        {
                            rst_ZBCFUN_CPBZ_READ = IMES_MMdate.get_CPBZ_READ(NEWTPM);
                        }
                        else if (mes_werks_pdly == "1")
                        {
                            rst_ZBCFUN_CPBZ_READ = data_ISY_TPM_SYNC.GET_CPBZ_READ_NEW1(NEWTPM);
                        }
                        if (rst_ZBCFUN_CPBZ_READ.MES_RETURN.TYPE == "S")
                        {
                            if (rst_ZBCFUN_CPBZ_READ.ES_HEADER.TPM != "")
                            {
                                if (rst_ZBCFUN_CPBZ_READ.ES_HEADER.MATNR == rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0].WLH)
                                {
                                    model_MES_TM_TMINFO = new MES_TM_TMINFO();
                                    model_MES_TM_TMINFO.TM = rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0].TM;
                                    model_MES_TM_TMINFO.TPM = NEWTPM;
                                    rst = UPDATE(model_MES_TM_TMINFO, 2);
                                }
                                else
                                {
                                    rst.TYPE = "E";
                                    rst.MESSAGE = "物料信息不一致，无法替换！" + rst_ZBCFUN_CPBZ_READ.ES_HEADER.MATNR + rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0].WLH;
                                    return rst;
                                }
                            }
                            else
                            {
                                rst.TYPE = "E";
                                rst.MESSAGE = "新托盘码没有查询到数据！";
                                return rst;
                            }
                        }
                        else
                        {
                            return rst_ZBCFUN_CPBZ_READ.MES_RETURN;
                        }
                    }
                    else
                    {
                        rst.TYPE = "E";
                        rst.MESSAGE = rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0].GC + "工厂没有定义托盘码读取配置！";
                        return rst;
                    }
                }
            }
            else
            {
                return rst_SELECT_MES_TM_TMINFO_BYTM.MES_RETURN;
            }
            return rst;
        }
        public SELECT_MES_TM_TMINFO_BYTM SELECT_BY_STAFFID(MES_TM_TMINFO model, int CXLB)
        {
            return mesdetaAccess.SELECT_BY_STAFFID(model, CXLB);
        }
        public SELECT_MES_TM_TMINFO_BYTM SELECT_BY_KCDDLimit(MES_TM_TMINFO model)
        {
            return mesdetaAccess.SELECT_BY_KCDDLimit(model);
        }

        public SELECT_MES_TM_TMINFO_BYTM SELECT_BY_UPDATEROLE(MES_TM_TMINFO_SELECT_BY_UPDATEROLE_IN model)
        {
            SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM = new SELECT_MES_TM_TMINFO_BYTM();
            MES_TM_TMINFO model_MES_TM_TMINFO = new MES_TM_TMINFO();
            model_MES_TM_TMINFO.TM = model.TM;
            rst_SELECT_MES_TM_TMINFO_BYTM = mesdetaAccess.SELECT_BYTM(model_MES_TM_TMINFO, 1);
            if (rst_SELECT_MES_TM_TMINFO_BYTM.MES_RETURN.TYPE == "S")
            {
                string gc = rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0].GC;
                string gzzxbh = rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0].GZZXBH;
                string kcdd = rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0].KCDD;
                if (gzzxbh != "")
                {
                    int rstcount = IROLE_GZZXdata.SELECT_COUNT_BY_STAFFID(gc, gzzxbh, model.STAFFID);
                    if (rstcount == 0)
                    {
                        MES_RETURN child_MES_RETURN = new MES_RETURN();
                        child_MES_RETURN.TYPE = "E";
                        child_MES_RETURN.MESSAGE = "无该工作中心权限！";
                        rst_SELECT_MES_TM_TMINFO_BYTM.MES_RETURN = child_MES_RETURN;
                        return rst_SELECT_MES_TM_TMINFO_BYTM;
                    }
                }
                else
                {
                    int rstcount = IROLE_CKdata.SELECT_COUNT_BY_STAFFID(gc, kcdd, model.STAFFID);
                    if (rstcount == 0)
                    {
                        MES_RETURN child_MES_RETURN = new MES_RETURN();
                        child_MES_RETURN.TYPE = "E";
                        child_MES_RETURN.MESSAGE = "无该仓库地点权限！";
                        rst_SELECT_MES_TM_TMINFO_BYTM.MES_RETURN = child_MES_RETURN;
                        return rst_SELECT_MES_TM_TMINFO_BYTM;
                    }
                }
            }
            return rst_SELECT_MES_TM_TMINFO_BYTM;
        }
        public MES_TM_TMINFO_INSERT_RETURN INSERT_OLD(MES_TM_TMINFO_INSERT_GL model, string YEAR, int ISAUTOADD)
        {

            MES_TM_TMINFO_INSERT_RETURN rst_MES_TM_TMINFO_INSERT_RETURN = new MES_TM_TMINFO_INSERT_RETURN();
            List<SELECT_MES_TM_TMINFO_PRINT> rst = new List<SELECT_MES_TM_TMINFO_PRINT>();
            MES_RETURN mr_rst = new MES_RETURN();
            bool istpm = false;
            MES_RETURN mr = new MES_RETURN();
            for (int i = 0; i < model.MES_TM_TMINFO.TMCOUNT; i++)
            {
                if (model.MES_TM_TMINFO.GC != "")
                {
                    istpm = false;
                    MES_SY_YERACOUNT model_MES_SY_YERACOUNT = new MES_SY_YERACOUNT();
                    model_MES_SY_YERACOUNT.TMLB = 1;
                    model_MES_SY_YERACOUNT.GC = model.MES_TM_TMINFO.GC;
                    model_MES_SY_YERACOUNT.TMYEAR = YEAR;
                    model.MES_TM_TMINFO.TM = SY_YERACOUNTservice.SELECT(model_MES_SY_YERACOUNT);
                    mr = mesdetaAccess.INSERT_OLD(model.MES_TM_TMINFO);
                    if (mr.TYPE == "S")
                    {
                        if (model.MES_TM_GL.Count > 0)
                        {
                            for (int j = 0; j < model.MES_TM_GL.Count; j++)
                            {
                                model.MES_TM_GL[j].SCTMGC = model.MES_TM_TMINFO.GC;
                                model.MES_TM_GL[j].SCTM = model.MES_TM_TMINFO.TM;
                                model.MES_TM_GL[j].GLLB = 1;
                            }
                            if (model.MES_TM_TMINFO.UPPERTM != "" && model.MES_TM_TMINFO.UPPERTM != null)
                            {
                                MES_TM_GL model_MES_TM_GL = new MES_TM_GL();
                                model_MES_TM_GL.SCTMGC = model.MES_TM_TMINFO.GC;
                                model_MES_TM_GL.SCTM = model.MES_TM_TMINFO.UPPERTM;
                                model_MES_TM_GL.XCTMGC = model.MES_TM_TMINFO.GC;
                                model_MES_TM_GL.XCTM = model.MES_TM_TMINFO.TM;
                                model_MES_TM_GL.GLLB = 2;
                                List<MES_TM_GL> model_MES_TM_GL_list = new List<MES_TM_GL>();
                                model_MES_TM_GL_list.Add(model_MES_TM_GL);
                                TM_GLservice.INSERT(model_MES_TM_GL_list, 0);
                            }
                        }
                        TM_GLservice.INSERT(model.MES_TM_GL, mr.TID);
                    }
                    if (mr.TYPE == "S" && istpm == false)
                    {
                        SELECT_MES_TM_TMINFO_PRINT child_SELECT_MES_TM_TMINFO_PRINT = SELECT_BYID_CHILD(mr.GC, mr.TM);
                        rst.Add(child_SELECT_MES_TM_TMINFO_PRINT);
                        MES_PD_SCRW_ZXCC_INSERT model_MES_PD_SCRW_ZXCC_INSERT = new MES_PD_SCRW_ZXCC_INSERT();
                    }
                }
                else
                {
                    mr.TYPE = "E";
                    mr.MESSAGE = "工厂不能为空！";
                }
            }
            rst_MES_TM_TMINFO_INSERT_RETURN.MES_RETURN = mr;
            rst_MES_TM_TMINFO_INSERT_RETURN.SELECT_MES_TM_TMINFO_PRINT = rst;
            return rst_MES_TM_TMINFO_INSERT_RETURN;
        }
        public MES_TM_TMINFO_XCTMINFO GET_XCTMINFO_BY_TMLIST(List<MES_PD_TL_SELECT_REPORT_LIST> model)
        {
            MES_TM_TMINFO_XCTMINFO rst_MES_TM_TMINFO_XCTMINFO = new MES_TM_TMINFO_XCTMINFO();
            List<MES_TM_TMINFO_XCTMINFO_BY_TMLIST> rst = new List<MES_TM_TMINFO_XCTMINFO_BY_TMLIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            for (int i = 0; i < model.Count; i++)
            {
                SELECT_MES_TM_TMINFO_PRINT rst_SELECT_MES_TM_TMINFO_PRINT = SELECT_BYID_CHILD("", model[i].TLTM);
                if (rst_SELECT_MES_TM_TMINFO_PRINT.MES_RETURN.TYPE == "S")
                {
                    child_MES_RETURN = rst_SELECT_MES_TM_TMINFO_PRINT.MES_RETURN;
                    if (rst_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST_CHILD.Count > 0)
                    {
                        for (int a = 0; a < rst_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST_CHILD.Count; a++)
                        {
                            MES_TM_TMINFO_XCTMINFO_BY_TMLIST child = new MES_TM_TMINFO_XCTMINFO_BY_TMLIST();
                            child.GZZXMS = model[i].GZZXNAME;
                            child.WLMS = model[i].WLMS;
                            child.WLLBNAME = model[i].WLLBNAME;
                            child.TLSJ = model[i].TLRQ;
                            child.TLWLLBNAME = rst_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST.WLLBNAME;
                            child.TLWLMS = rst_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST.WLMS;
                            child.SCDATE = rst_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST.SCDATE;
                            child.BCNAME = rst_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST.BCMS;
                            child.SBNAME = rst_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST.SBHMS;
                            child.TH = rst_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST.TH;
                            child.PFDH = rst_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST.PFDH;
                            child.PLDH = rst_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST.PLDH;
                            child.XCWLLBNAME = rst_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST_CHILD[a].WLLBNAME;
                            child.XCWLNAME = rst_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST_CHILD[a].WLMS;
                            child.GYSJC = rst_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST_CHILD[a].GYSMS;
                            child.XCSBNAME = rst_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST_CHILD[a].SBHMS;
                            child.PC = rst_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST_CHILD[a].PC;
                            child.GYSPC = rst_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST_CHILD[a].GYSPC;
                            rst.Add(child);
                        }
                    }
                    else
                    {
                        MES_TM_TMINFO_XCTMINFO_BY_TMLIST child = new MES_TM_TMINFO_XCTMINFO_BY_TMLIST();
                        child.GZZXMS = model[i].GZZXNAME;
                        child.WLMS = model[i].WLMS;
                        child.WLLBNAME = model[i].WLLBNAME;
                        child.TLSJ = model[i].TLRQ;
                        child.TLWLLBNAME = rst_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST.WLLBNAME;
                        child.TLWLMS = rst_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST.WLMS;
                        child.SCDATE = rst_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST.SCDATE;
                        child.BCNAME = rst_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST.BCMS;
                        child.SBNAME = rst_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST.SBHMS;
                        child.TH = rst_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST.TH;
                        child.PFDH = rst_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST.PFDH;
                        child.PLDH = rst_SELECT_MES_TM_TMINFO_PRINT.MES_TM_TMINFO_LIST.PLDH;
                        child.XCWLLBNAME = "";
                        child.XCWLNAME = "";
                        child.GYSJC = "";
                        child.XCSBNAME = "";
                        child.PC = "";
                        child.GYSPC = "";
                        rst.Add(child);
                    }
                }
            }
            rst_MES_TM_TMINFO_XCTMINFO.MES_TM_TMINFO_XCTMINFO_BY_TMLIST = rst;
            rst_MES_TM_TMINFO_XCTMINFO.MES_RETURN = child_MES_RETURN;
            return rst_MES_TM_TMINFO_XCTMINFO;
        }
        public ZBCFUN_GDJGXX_READ GET_GDJGXX_NEW1(string IV_WERKS, string IV_AUFNR)
        {
            string mes_werks_pdly = "";
            if (IV_WERKS == "")
            {
                mes_werks_pdly = "0";
            }
            else
            {
                mes_werks_pdly = ISY_SYSCSdata.SELECT("MES_" + IV_WERKS + "_GDLY");
            }

            MES_RETURN mr = new MES_RETURN();
            ZBCFUN_GDJGXX_READ rst = new ZBCFUN_GDJGXX_READ();
            if (mes_werks_pdly == "0")
            {
                rst = IMES_MMdate.get_GDJGXX(IV_AUFNR);
            }
            else if (mes_werks_pdly == "1")
            {
                MES_PD_GD_SYNC model_MES_PD_GD_SYNC = new MES_PD_GD_SYNC();
                model_MES_PD_GD_SYNC.WERKS = IV_WERKS;
                model_MES_PD_GD_SYNC.AUFNR = IV_AUFNR;
                model_MES_PD_GD_SYNC.LB = 1;
                MES_PD_GD_SYNC_SELECT rst_MES_PD_GD_SYNC_SELECT = data_IPD_GD.SELECT_GD_SYNC(model_MES_PD_GD_SYNC);
                if (rst_MES_PD_GD_SYNC_SELECT.MES_RETURN.TYPE != "S")
                {
                    rst.MES_RETURN = rst_MES_PD_GD_SYNC_SELECT.MES_RETURN;
                    return rst;
                }
                List<ES_HEADER> model_ZSL_BCST024_POlist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ES_HEADER>>(Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_PD_GD_SYNC_SELECT.DATALIST));
                if (model_ZSL_BCST024_POlist.Count > 0)
                {
                    rst.ES_HEADER = model_ZSL_BCST024_POlist[0];
                }
                else
                {
                    mr.TYPE = "E";
                    mr.MESSAGE = "无数据！";
                    rst.MES_RETURN = mr;
                    return rst;
                }
                model_MES_PD_GD_SYNC.LB = 2;
                rst_MES_PD_GD_SYNC_SELECT = data_IPD_GD.SELECT_GD_SYNC(model_MES_PD_GD_SYNC);
                if (rst_MES_PD_GD_SYNC_SELECT.MES_RETURN.TYPE != "S")
                {
                    rst.MES_RETURN = rst_MES_PD_GD_SYNC_SELECT.MES_RETURN;
                    return rst;
                }
                List<ET_BOM> model_ZSL_BCS302_B_LIST = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ET_BOM>>(Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_PD_GD_SYNC_SELECT.DATALIST));
                rst.ET_BOM = model_ZSL_BCS302_B_LIST;

                model_MES_PD_GD_SYNC.LB = 3;
                rst_MES_PD_GD_SYNC_SELECT = data_IPD_GD.SELECT_GD_SYNC(model_MES_PD_GD_SYNC);
                if (rst_MES_PD_GD_SYNC_SELECT.MES_RETURN.TYPE != "S")
                {
                    rst.MES_RETURN = rst_MES_PD_GD_SYNC_SELECT.MES_RETURN;
                    return rst;
                }
                List<ZSL_BCST302_R> model_ZSL_BCST302_R = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ZSL_BCST302_R>>(Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_PD_GD_SYNC_SELECT.DATALIST));
                rst.ET_RT = model_ZSL_BCST302_R;
                mr.TYPE = "S";
                mr.MESSAGE = "";
                rst.MES_RETURN = mr;
            }
            return rst;
        }
        public MES_RETURN SELECT_TM_LASTTIME(MES_TM_TMINFO model)
        {
            return mesdetaAccess.SELECT_TM_LASTTIME(model);
        }

        public MES_RETURN INSERT_ZS_WLKCBS(MES_TM_TMINFO_INSERT_GL model)
        {
            MES_RETURN rst = new MES_RETURN();
            if (model.MES_TM_GL.Count == 0)
            {
                rst.TYPE = "E";
                rst.MESSAGE = "LOT表不能为空";
                return rst;
            }
            MES_TM_TMINFO model_MES_TM_TMINFO = new MES_TM_TMINFO();
            model_MES_TM_TMINFO.TM = model.MES_TM_GL[0].XCTM;
            SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM = mesdetaAccess.SELECT(model_MES_TM_TMINFO, 0);
            if (rst_SELECT_MES_TM_TMINFO_BYTM.MES_RETURN.TYPE != "S")
            {
                return rst_SELECT_MES_TM_TMINFO_BYTM.MES_RETURN;
            }
            if (rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST.Count == 0)
            {
                rst.TYPE = "E";
                rst.MESSAGE = "条码：" + model.MES_TM_GL[0].XCTM + "不存在";
                return rst;
            }

            DataTable dtxctm = new DataTable();
            dtxctm.Columns.Add("BCMS", typeof(string));
            dtxctm.Columns.Add("KSTIME", typeof(string));
            dtxctm.Columns.Add("JSTIME", typeof(string));
            dtxctm.Columns.Add("SCDATE", typeof(string));
            dtxctm.Columns.Add("BC", typeof(int));
            dtxctm.Columns.Add("WQH", typeof(string));
            string MID = "";
            string WLH = "";
            string CLPBDM = "";
            string CPZTNAME = "";
            string CPTYPENAME = "";
            for (int a = 0; a < model.MES_TM_GL.Count; a++)
            {
                model_MES_TM_TMINFO = new MES_TM_TMINFO();
                model_MES_TM_TMINFO.TM = model.MES_TM_GL[a].XCTM;
                SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM_all = mesdetaAccess.SELECT(model_MES_TM_TMINFO, 0);
                if (rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_RETURN.TYPE != "S")
                {
                    return rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_RETURN;
                }
                if (rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST.Count == 0)
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "条码：" + model.MES_TM_GL[0].XCTM + "不存在";
                    return rst;
                }
                if (rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].KCDDGC != "" && rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].KCDD != "")
                {
                    if (rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].KCDDGC != model.MES_TM_TMINFO.KCDDGC || rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].KCDD != model.MES_TM_TMINFO.KCDD)
                    {
                        rst.TYPE = "E";
                        rst.MESSAGE = "条码：" + model.MES_TM_GL[0].XCTM + "物料lot库存地点跟关联的库存地点不一致";
                        return rst;
                    }
                }
                MES_TM_GL model_MES_TM_GL = new MES_TM_GL();
                model_MES_TM_GL.XCTM = model.MES_TM_GL[a].XCTM;
                model_MES_TM_GL.LB = 1;
                MES_TM_GL_SELECT rst_MES_TM_GL_SELECT = data_ITM_GL.SELECT(model_MES_TM_GL);
                if (rst_MES_TM_GL_SELECT.MES_RETURN.TYPE != "S")
                {
                    return rst_MES_TM_GL_SELECT.MES_RETURN;
                }
                if (rst_MES_TM_GL_SELECT.MES_TM_GL.Count > 0)
                {
                    if (rst_MES_TM_GL_SELECT.MES_TM_GL[0].SCTMRESDUESL > 0)
                    {
                        rst.TYPE = "E";
                        rst.MESSAGE = "条码：" + model.MES_TM_GL[0].XCTM + "已关联";
                        return rst;
                    }
                }
                if (a == 0)
                {
                    MID = rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].MID;
                    WLH = rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].WLH;
                    CLPBDM = rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].CLPBDM;
                    CPZTNAME = rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].CPZTNAME;
                    CPTYPENAME = rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].CPTYPENAME;
                }
                else
                {
                    if (MID != rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].MID)
                    {
                        rst.TYPE = "E";
                        rst.MESSAGE = "条码：" + model.MES_TM_GL[0].XCTM + "与已扫描的模具号不相同";
                        return rst;
                    }
                    if (WLH != rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].WLH)
                    {
                        rst.TYPE = "E";
                        rst.MESSAGE = "条码：" + model.MES_TM_GL[0].XCTM + "与已扫描的物料号不相同";
                        return rst;
                    }
                    if (CLPBDM != rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].CLPBDM)
                    {
                        rst.TYPE = "E";
                        rst.MESSAGE = "条码：" + model.MES_TM_GL[0].XCTM + "与已扫描的材料配比代码不相同";
                        return rst;
                    }
                    if (CPZTNAME != rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].CPZTNAME)
                    {
                        rst.TYPE = "E";
                        rst.MESSAGE = "条码：" + model.MES_TM_GL[0].XCTM + "与已扫描的产品状态不相同";
                        return rst;
                    }
                    if (CPTYPENAME != rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].CPTYPENAME)
                    {
                        rst.TYPE = "E";
                        rst.MESSAGE = "条码：" + model.MES_TM_GL[0].XCTM + "与已扫描的产品类型不相同";
                        return rst;
                    }
                }
                DataRow dr = dtxctm.NewRow();
                dr[0] = rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].BCMS;
                dr[1] = rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].KSTIME;
                dr[2] = rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].JSTIME;
                dr[3] = rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].SCDATE;
                dr[4] = rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].BC;
                dr[5] = rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].WQH;
                dtxctm.Rows.Add(dr);
            }
            DataRow[] dr1 = dtxctm.Select("", "JSTIME");
            string pc = "";
            pc = Convert.ToDateTime(dr1[0][3].ToString()).ToString("yyMMdd");
            if (dr1[0][0].ToString() == "日班")
            {
                pc = pc + "1";
            }
            else
            {
                pc = pc + "2";
            }
            pc = pc + Convert.ToDateTime(dr1[dtxctm.Rows.Count - 1][3].ToString()).ToString("MMdd");
            if (dr1[dtxctm.Rows.Count - 1][0].ToString() == "日班")
            {
                pc = pc + "1";
            }
            else
            {
                pc = pc + "2";
            }
            DataRow[] dr2 = dtxctm.Select("", "KSTIME");
            for (int a = 0; a < dr2.Count(); a++)
            {
                if (dr2[a][1].ToString() != "")
                {
                    dr2[a][1] = Convert.ToDateTime(dr2[a][1].ToString()).ToString("yyyy-MM-dd HH:mm");
                }
                if (dr2[a][2].ToString() != "")
                {
                    dr2[a][2] = Convert.ToDateTime(dr2[a][2].ToString()).ToString("yyyy-MM-dd HH:mm");
                }
            }
            model_MES_TM_TMINFO = new MES_TM_TMINFO();
            model_MES_TM_TMINFO.GC = rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0].GC;
            MES_SY_YERACOUNT model_MES_SY_YERACOUNT = new MES_SY_YERACOUNT();
            model_MES_SY_YERACOUNT.TMLB = 1;
            model_MES_SY_YERACOUNT.GC = model_MES_TM_TMINFO.GC;
            model_MES_TM_TMINFO.TM = SY_YERACOUNTservice.SELECT(model_MES_SY_YERACOUNT);
            model_MES_TM_TMINFO.TMLB = 2;
            model_MES_TM_TMINFO.TMSX = 622;
            model_MES_TM_TMINFO.SCDATE = dr1[dtxctm.Rows.Count - 1][3].ToString(); ;
            model_MES_TM_TMINFO.BC = Convert.ToInt32(dr1[dtxctm.Rows.Count - 1][4].ToString());
            model_MES_TM_TMINFO.PC = pc;
            model_MES_TM_TMINFO.JLR = model.MES_TM_TMINFO.JLR;
            model_MES_TM_TMINFO.CPZT = rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0].CPZT;
            model_MES_TM_TMINFO.SL = model.MES_TM_TMINFO.SL;
            model_MES_TM_TMINFO.KSTIME = dr2[0][1].ToString();
            model_MES_TM_TMINFO.JSTIME = dr1[dtxctm.Rows.Count - 1][2].ToString();
            model_MES_TM_TMINFO.REMARK = "";
            model_MES_TM_TMINFO.MAC = "";
            model_MES_TM_TMINFO.MID = rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0].MID;
            model_MES_TM_TMINFO.JZ = 0;
            model_MES_TM_TMINFO.CPTYPE = rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0].CPTYPE;
            model_MES_TM_TMINFO.CLPBDM = rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0].CLPBDM;
            model_MES_TM_TMINFO.KCDDGC = model.MES_TM_TMINFO.KCDDGC;
            model_MES_TM_TMINFO.KCDD = model.MES_TM_TMINFO.KCDD;
            model_MES_TM_TMINFO.KCDDNAME = model.MES_TM_TMINFO.KCDDNAME;
            model_MES_TM_TMINFO.GLTMCOUNT = model.MES_TM_GL.Count;


            string kstime = "";
            string jstime = "";
            string wqh = "";
            for (int a = 0; a < dr2.Count(); a++)
            {
                if (dr2[a][5].ToString() != "")
                {
                    if (jstime == "")
                    {
                        kstime = dr2[a][1].ToString();
                        jstime = dr2[a][2].ToString();
                        wqh = dr2[a][5].ToString();
                    }
                    else
                    {
                        if (jstime != dr2[a][1].ToString())
                        {

                            model_MES_TM_TMINFO.REMARK = model_MES_TM_TMINFO.REMARK + Convert.ToDateTime(kstime).ToString("yy.MM.dd HH:mm") + "-" + Convert.ToDateTime(jstime).ToString("yy.MM.dd HH:mm") + "无" + wqh + " / ";
                            kstime = dr2[a][1].ToString();
                            jstime = dr2[a][2].ToString();
                            wqh = dr2[a][5].ToString();
                        }
                        else
                        {
                            if (wqh != dr2[a][5].ToString())
                            {
                                model_MES_TM_TMINFO.REMARK = model_MES_TM_TMINFO.REMARK + Convert.ToDateTime(kstime).ToString("yy.MM.dd HH:mm") + "-" + Convert.ToDateTime(jstime).ToString("yy.MM.dd HH:mm") + "无" + wqh + " / ";
                                kstime = dr2[a][1].ToString();
                                jstime = dr2[a][2].ToString();
                                wqh = dr2[a][5].ToString();
                            }
                            else
                            {
                                jstime = dr2[a][2].ToString();
                            }
                        }
                    }
                }
            }
            if (kstime != "")
            {
                model_MES_TM_TMINFO.REMARK = model_MES_TM_TMINFO.REMARK + Convert.ToDateTime(kstime).ToString("yy.MM.dd HH:mm") + "-" + Convert.ToDateTime(jstime).ToString("yy.MM.dd HH:mm") + "无" + wqh + " / ";
            }

            rst = mesdetaAccess.INSERT(model_MES_TM_TMINFO);
            string TM = "";
            if (rst.TYPE != "S")
            {
                return rst;
            }
            TM = rst.TM;
            if (model.MES_TM_GL.Count > 0)
            {
                for (int j = 0; j < model.MES_TM_GL.Count; j++)
                {
                    model.MES_TM_GL[j].SCTMGC = rst.GC;
                    model.MES_TM_GL[j].SCTM = rst.TM;
                    model.MES_TM_GL[j].GLLB = 1;
                }
                List<MES_TM_GL> model_MES_TM_GL_list = new List<MES_TM_GL>();
                for (int j = 0; j < model.MES_TM_GL.Count; j++)
                {
                    MES_TM_GL model_MES_TM_GL = new MES_TM_GL();
                    model_MES_TM_GL.SCTM = rst.TM;
                    model_MES_TM_GL.XCTM = model.MES_TM_GL[j].XCTM;
                    model_MES_TM_GL.GLLB = 2;
                    model_MES_TM_GL_list.Add(model_MES_TM_GL);
                }
                TM_GLservice.INSERT(model_MES_TM_GL_list, 0);
                for (int j = 0; j < model.MES_TM_GL.Count; j++)
                {
                    model_MES_TM_TMINFO = new MES_TM_TMINFO();
                    model_MES_TM_TMINFO.TM = model.MES_TM_GL[j].XCTM;
                    model_MES_TM_TMINFO.KCDDGC = model.MES_TM_TMINFO.KCDDGC;
                    model_MES_TM_TMINFO.KCDD = model.MES_TM_TMINFO.KCDD;
                    model_MES_TM_TMINFO.KCDDNAME = model.MES_TM_TMINFO.KCDDNAME;
                    model_MES_TM_TMINFO.LB = 5;
                    mesdetaAccess.UPDATE(model_MES_TM_TMINFO, 5);
                }
            }
            TM_GLservice.INSERT(model.MES_TM_GL, 0);
            MES_ZS_SY_JL model_MES_ZS_SY_JL = new MES_ZS_SY_JL();
            model_MES_ZS_SY_JL.LB = 1;
            model_MES_ZS_SY_JL.JLMS = "";
            model_MES_ZS_SY_JL.CJR = model.MES_TM_TMINFO.JLR;
            model_MES_ZS_SY_JL.KCBSTM = TM;
            model_MES_ZS_SY_JL.JLLB = 2;
            model_MES_ZS_SY_JL.GC = model.MES_TM_TMINFO.KCDDGC;
            rst = data_IZS_SY_JL.INSERT(model_MES_ZS_SY_JL);
            if (rst.TYPE != "S")
            {
                return rst;
            }
            int JLID = Convert.ToInt32(rst.MESSAGE);
            for (int j = 0; j < model.MES_TM_GL.Count; j++)
            {
                MES_ZS_SY_JL_MX model_MES_ZS_SY_JL_MX = new MES_ZS_SY_JL_MX();
                model_MES_ZS_SY_JL_MX.LB = 6;
                model_MES_ZS_SY_JL_MX.JLID = JLID;
                model_MES_ZS_SY_JL_MX.FTM = TM;
                model_MES_ZS_SY_JL_MX.TM = model.MES_TM_GL[j].XCTM;
                model_MES_ZS_SY_JL_MX.JLMXLB = 2;
                model_MES_ZS_SY_JL_MX.JLMXLBNAME = "关联";
                rst = data_IZS_SY_JL.INSERT_MX(model_MES_ZS_SY_JL_MX);
                if (rst.TYPE != "S")
                {
                    return rst;
                }
            }
            rst.TM = TM;
            return rst;
        }
        public MES_RETURN DELETE_ZS_WLKCBS(List<MES_TM_TMINFO> model)
        {
            MES_RETURN rst = new MES_RETURN();
            if (model.Count == 0)
            {
                rst.TYPE = "E";
                rst.MESSAGE = "无条码数据";
                return rst;
            }
            for (int a = 0; a < model.Count; a++)
            {
                MES_TM_TMINFO model_MES_TM_TMINFO = new MES_TM_TMINFO();
                model_MES_TM_TMINFO.TM = model[a].TM;
                SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM_all = mesdetaAccess.SELECT(model_MES_TM_TMINFO, 0);
                if (rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_RETURN.TYPE != "S")
                {
                    return rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_RETURN;
                }
                if (rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST.Count == 0)
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "条码：" + model[a].TM + "不存在";
                    return rst;
                }
                if (rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].RESDUESL < rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].SL)
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "条码：" + model[a].TM + "已经发货不允许取消";
                    return rst;
                }
            }
            for (int a = 0; a < model.Count; a++)
            {
                rst = data_ITM_GL.DELETE_BY_SCTM(model[a].TM);
                if (rst.TYPE != "S")
                {
                    return rst;
                }
                rst = mesdetaAccess.DELETE(model[a].TM);
                if (rst.TYPE != "S")
                {
                    return rst;
                }
                MES_ZS_SY_JL model_MES_ZS_SY_JL = new MES_ZS_SY_JL();
                model_MES_ZS_SY_JL.LB = 1;
                model_MES_ZS_SY_JL.KCBSTM = model[a].TM;
                model_MES_ZS_SY_JL.XGR = model[a].JLR;
                model_MES_ZS_SY_JL.JLMS = model[a].REMARK;
                rst = data_IZS_SY_JL.UPDATE(model_MES_ZS_SY_JL);
            }
            return rst;
        }
        public MES_RETURN ZS_WLKCBS_MOVE(List<MES_TM_TMINFO> model, string RKTEXT)
        {
            MES_RETURN rst = new MES_RETURN();
            if (model.Count == 0)
            {
                rst.TYPE = "E";
                rst.MESSAGE = "无条码数据";
                return rst;
            }
            for (int a = 0; a < model.Count; a++)
            {
                MES_TM_TMINFO model_MES_TM_TMINFO = new MES_TM_TMINFO();
                model_MES_TM_TMINFO.TM = model[a].TM;
                SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM_all = mesdetaAccess.SELECT(model_MES_TM_TMINFO, 0);
                if (rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_RETURN.TYPE != "S")
                {
                    return rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_RETURN;
                }
                if (rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST.Count == 0)
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "条码：" + model[a].TM + "不存在";
                    return rst;
                }
                if (rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].KCDDGC == model[a].KCDDGC && rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].KCDD == model[a].KCDD)
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "条码：" + model[a].TM + "不允许重复入库";
                    return rst;
                }
                if (rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].SL > rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].RESDUESL)
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "条码：" + model[a].TM + "数量为0";
                    return rst;
                }
                if (model[a].KCDDGC == "8020" && model[a].KCDD == "0093")
                {
                    MES_ZS_SY_JL_MX model_MES_ZS_SY_JL_MX = new MES_ZS_SY_JL_MX();
                    model_MES_ZS_SY_JL_MX.LB = 1;
                    model_MES_ZS_SY_JL_MX.TM = model[a].TM;
                    MES_ZS_SY_JL_MX_SELECT rst_MES_ZS_SY_JL_MX_SELECT = data_IZS_SY_JL.SELECT_MX(model_MES_ZS_SY_JL_MX);
                    if (rst_MES_ZS_SY_JL_MX_SELECT.MES_RETURN.TYPE != "S")
                    {
                        return rst_MES_ZS_SY_JL_MX_SELECT.MES_RETURN;
                    }
                    if (rst_MES_ZS_SY_JL_MX_SELECT.MES_ZS_SY_JL_MX[0].ERRORCOUNT != 0)
                    {
                        rst.TYPE = "E";
                        rst.MESSAGE = "条码：" + model[a].TM + "下属存在未过全检的条码";
                        return rst;
                    }
                }
            }
            MES_ZS_SY_JL model_MES_ZS_SY_JL = new MES_ZS_SY_JL();
            model_MES_ZS_SY_JL.LB = 1;
            model_MES_ZS_SY_JL.JLMS = RKTEXT;
            model_MES_ZS_SY_JL.CJR = model[0].JLR;
            model_MES_ZS_SY_JL.KCBSTM = "";
            model_MES_ZS_SY_JL.JLLB = 3;
            model_MES_ZS_SY_JL.GC = model[0].KCDDGC;
            rst = data_IZS_SY_JL.INSERT(model_MES_ZS_SY_JL);
            if (rst.TYPE != "S")
            {
                return rst;
            }
            int JLID = Convert.ToInt32(rst.MESSAGE);
            for (int a = 0; a < model.Count; a++)
            {
                MES_TM_GL model_MES_TM_GL = new MES_TM_GL();
                model_MES_TM_GL.LB = 2;
                model_MES_TM_GL.SCTM = model[a].TM;
                MES_TM_GL_SELECT rst_MES_TM_GL_SELECT = data_ITM_GL.SELECT(model_MES_TM_GL);
                if (rst_MES_TM_GL_SELECT.MES_RETURN.TYPE != "S")
                {
                    return rst_MES_TM_GL_SELECT.MES_RETURN;
                }
                for (int b = 0; b < rst_MES_TM_GL_SELECT.MES_TM_GL.Count; b++)
                {
                    MES_ZS_SY_JL_MX model_MES_ZS_SY_JL_MX = new MES_ZS_SY_JL_MX();
                    model_MES_ZS_SY_JL_MX.LB = 2;
                    model_MES_ZS_SY_JL_MX.JLID = JLID;
                    model_MES_ZS_SY_JL_MX.FTM = model[a].TM;
                    model_MES_ZS_SY_JL_MX.TM = rst_MES_TM_GL_SELECT.MES_TM_GL[b].XCTM;
                    //model_MES_ZS_SY_JL_MX.JLMXLB = 3;
                    //model_MES_ZS_SY_JL_MX.JLMXLBNAME = "关联"
                    model_MES_ZS_SY_JL_MX.KCDDGC = model[a].KCDDGC;
                    model_MES_ZS_SY_JL_MX.KCDD = model[a].KCDD;
                    rst = data_IZS_SY_JL.INSERT_MX(model_MES_ZS_SY_JL_MX);
                    if (rst.TYPE != "S")
                    {
                        return rst;
                    }
                }
            }
            return rst;
        }

        public MES_RETURN ZS_WLKCBS_CK(List<MES_TM_TMINFO> model, int KHID, string JLMS)
        {
            MES_RETURN rst = new MES_RETURN();
            for (int a = 0; a < model.Count; a++)
            {
                MES_TM_TMINFO model_MES_TM_TMINFO = new MES_TM_TMINFO();
                model_MES_TM_TMINFO.TM = model[a].TM;
                SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM_all = mesdetaAccess.SELECT(model_MES_TM_TMINFO, 0);
                if (rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_RETURN.TYPE != "S")
                {
                    return rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_RETURN;
                }
                if (rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST.Count == 0)
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "条码" + model[a].TM + "不存在";
                    return rst;
                }
                if (rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].RESDUESL < rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].SL)
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "条码" + model[a].TM + "数量为0";
                    return rst;
                }
                if (rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].TMLB != 2)
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "条码" + model[a].TM + "不是库存标识";
                    return rst;
                }
                if (rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].CPZTNAME != "合格")
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "条码" + model[a].TM + "非合格状态不能出库";
                    return rst;
                }
            }
            MES_ZS_SY_JL model_MES_ZS_SY_JL = new MES_ZS_SY_JL();
            model_MES_ZS_SY_JL.LB = 1;
            model_MES_ZS_SY_JL.JLMS = JLMS;
            model_MES_ZS_SY_JL.CJR = model[0].JLR;
            model_MES_ZS_SY_JL.KCBSTM = "";
            model_MES_ZS_SY_JL.JLLB = 4;
            model_MES_ZS_SY_JL.KHID = KHID;
            rst = data_IZS_SY_JL.INSERT(model_MES_ZS_SY_JL);
            if (rst.TYPE != "S")
            {
                return rst;
            }
            int JLID = Convert.ToInt32(rst.MESSAGE);
            for (int a = 0; a < model.Count; a++)
            {
                MES_TM_GL model_MES_TM_GL = new MES_TM_GL();
                model_MES_TM_GL.LB = 2;
                model_MES_TM_GL.SCTM = model[a].TM;
                MES_TM_GL_SELECT rst_MES_TM_GL_SELECT = data_ITM_GL.SELECT(model_MES_TM_GL);
                if (rst_MES_TM_GL_SELECT.MES_RETURN.TYPE != "S")
                {
                    return rst_MES_TM_GL_SELECT.MES_RETURN;
                }
                if (rst_MES_TM_GL_SELECT.MES_TM_GL.Count > 0)
                {
                    for (int b = 0; b < rst_MES_TM_GL_SELECT.MES_TM_GL.Count; b++)
                    {
                        MES_ZS_SY_JL_MX model_MES_ZS_SY_JL_MX = new MES_ZS_SY_JL_MX();
                        model_MES_ZS_SY_JL_MX.LB = 3;
                        model_MES_ZS_SY_JL_MX.JLID = JLID;
                        model_MES_ZS_SY_JL_MX.FTM = model[a].TM;
                        model_MES_ZS_SY_JL_MX.TM = rst_MES_TM_GL_SELECT.MES_TM_GL[b].XCTM;
                        rst = data_IZS_SY_JL.INSERT_MX(model_MES_ZS_SY_JL_MX);
                        if (rst.TYPE != "S")
                        {
                            return rst;
                        }
                    }
                }
                MES_TM_TMINFO model_MES_TM_TMINFO = new MES_TM_TMINFO();
                model_MES_TM_TMINFO.TM = model[a].TM;
                rst = mesdetaAccess.UPDATE(model_MES_TM_TMINFO, 6);
                if (rst.TYPE != "S")
                {
                    return rst;
                }
            }
            return rst;
        }
        public MES_RETURN ZS_FGDJ(List<MES_TM_TMINFO> model, string JLMS)
        {
            MES_RETURN rst = new MES_RETURN();
            for (int a = 0; a < model.Count; a++)
            {
                MES_TM_TMINFO model_MES_TM_TMINFO = new MES_TM_TMINFO();
                model_MES_TM_TMINFO.TM = model[a].TM;
                SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM_all = mesdetaAccess.SELECT(model_MES_TM_TMINFO, 0);
                if (rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_RETURN.TYPE != "S")
                {
                    return rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_RETURN;
                }
                if (rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST.Count == 0)
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "条码" + model[a].TM + "失效或不存在";
                    return rst;
                }
                if (rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].TMLB == 2)
                {
                    if (rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].RESDUESL < rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].SL)
                    {
                        rst.TYPE = "E";
                        rst.MESSAGE = "条码" + model[a].TM + "数量为0";
                        return rst;
                    }
                }
                else
                {
                    MES_TM_GL model_MES_TM_GL = new MES_TM_GL();
                    model_MES_TM_GL.XCTM = model[a].TM;
                    model_MES_TM_GL.LB = 1; ;
                    MES_TM_GL_SELECT rst_MES_TM_GL_SELECT = data_ITM_GL.SELECT(model_MES_TM_GL);
                    if (rst_MES_TM_GL_SELECT.MES_RETURN.TYPE != "S")
                    {
                        return rst_MES_TM_GL_SELECT.MES_RETURN;
                    }
                    if (rst_MES_TM_GL_SELECT.MES_TM_GL.Count > 0)
                    {
                        rst.TYPE = "E";
                        rst.MESSAGE = "条码" + model[a].TM + "已关联物料标识卡，不允许单独扫描";
                        return rst;
                    }
                }
            }
            MES_ZS_SY_JL model_MES_ZS_SY_JL = new MES_ZS_SY_JL();
            model_MES_ZS_SY_JL.LB = 1;
            model_MES_ZS_SY_JL.JLMS = JLMS;
            model_MES_ZS_SY_JL.CJR = model[0].JLR;
            model_MES_ZS_SY_JL.KCBSTM = "";
            model_MES_ZS_SY_JL.JLLB = 5;
            rst = data_IZS_SY_JL.INSERT(model_MES_ZS_SY_JL);
            if (rst.TYPE != "S")
            {
                return rst;
            }
            int JLID = Convert.ToInt32(rst.MESSAGE);
            for (int a = 0; a < model.Count; a++)
            {
                MES_ZS_SY_JL_MX model_MES_ZS_SY_JL_MX = new MES_ZS_SY_JL_MX();
                model_MES_ZS_SY_JL_MX.LB = 4;
                model_MES_ZS_SY_JL_MX.JLID = JLID;
                model_MES_ZS_SY_JL_MX.TM = model[a].TM;
                rst = data_IZS_SY_JL.INSERT_MX(model_MES_ZS_SY_JL_MX);
                if (rst.TYPE != "S")
                {
                    return rst;
                }
            }
            return rst;
        }
        public MES_RETURN ZS_THDJ(List<MES_TM_TMINFO> model, int KHID, string JLMS)
        {
            MES_RETURN rst = new MES_RETURN();
            for (int a = 0; a < model.Count; a++)
            {
                MES_TM_TMINFO model_MES_TM_TMINFO = new MES_TM_TMINFO();
                model_MES_TM_TMINFO.TM = model[a].TM;
                SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM_all = mesdetaAccess.SELECT(model_MES_TM_TMINFO, 0);
                if (rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_RETURN.TYPE != "S")
                {
                    return rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_RETURN;
                }
                if (rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST.Count == 0)
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "条码" + model[a].TM + "失效或不存在";
                    return rst;
                }
                if (rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].TMLB != 2)
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "条码" + model[a].TM + "不是库存标识";
                    return rst;
                }
                //if (rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].RESDUESL >= rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].SL)
                //{
                //    rst.TYPE = "E";
                //    rst.MESSAGE = "条码" + model[a].TM + "数量不为0无法退货登记";
                //    return rst;
                //}
            }
            MES_ZS_SY_JL model_MES_ZS_SY_JL = new MES_ZS_SY_JL();
            model_MES_ZS_SY_JL.LB = 1;
            model_MES_ZS_SY_JL.JLMS = JLMS;
            model_MES_ZS_SY_JL.CJR = model[0].JLR;
            model_MES_ZS_SY_JL.KCBSTM = "";
            model_MES_ZS_SY_JL.JLLB = 6;
            model_MES_ZS_SY_JL.KHID = KHID;
            rst = data_IZS_SY_JL.INSERT(model_MES_ZS_SY_JL);
            if (rst.TYPE != "S")
            {
                return rst;
            }
            int JLID = Convert.ToInt32(rst.MESSAGE);
            for (int a = 0; a < model.Count; a++)
            {
                MES_ZS_SY_JL_MX model_MES_ZS_SY_JL_MX = new MES_ZS_SY_JL_MX();
                model_MES_ZS_SY_JL_MX.LB = 5;
                model_MES_ZS_SY_JL_MX.JLID = JLID;
                model_MES_ZS_SY_JL_MX.TM = model[a].TM;
                model_MES_ZS_SY_JL_MX.KCDDGC = model[a].KCDDGC;
                model_MES_ZS_SY_JL_MX.KCDD = model[a].KCDD;
                model_MES_ZS_SY_JL_MX.KCDDNAME = model[a].KCDDNAME;
                rst = data_IZS_SY_JL.INSERT_MX(model_MES_ZS_SY_JL_MX);
                if (rst.TYPE != "S")
                {
                    return rst;
                }
            }
            return rst;
        }
        public SELECT_MES_TM_TMINFO_BYTM SELECT_KC_TT(MES_TM_TMINFO model)
        {
            return mesdetaAccess.SELECT_KC_TT(model);
        }
        public SELECT_MES_TM_TMINFO_BYTM SELECT_LIST(List<MES_TM_TMINFO_LIST> model, MES_TM_TMINFO model1)
        {
            SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            DataTable dt = new DataTable();
            dt.Columns.Add("TM", typeof(string));
            //if (model.Count == 0)
            //{
            //    child_MES_RETURN.TYPE = "E";
            //    child_MES_RETURN.MESSAGE = "传入查询数据为空！";
            //    rst.MES_RETURN = child_MES_RETURN;
            //    return rst;
            //}
            for (int i = 0; i < model.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = model[i].TM;
                dt.Rows.Add(dr);
            }
            rst = mesdetaAccess.SELECT_LIST(dt, model1, 1);
            return rst;
        }

        public SELECT_MES_TM_TMINFO_BYTM SELECT_LIST_datatable(List<MES_TM_TMINFO_LIST> model, MES_TM_TMINFO model1)
        {
            SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            DataTable dt = new DataTable();
            dt.Columns.Add("TM", typeof(string));
            for (int i = 0; i < model.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = model[i].TM;
                dt.Rows.Add(dr);
            }
            rst = mesdetaAccess.SELECT_LIST_datatable(dt, model1);
            return rst;
        }

        public SELECT_MES_TM_TMINFO_BYTM SELECT_LB(MES_TM_TMINFO model)
        {
            return mesdetaAccess.SELECT_LB(model);
        }
    }
}

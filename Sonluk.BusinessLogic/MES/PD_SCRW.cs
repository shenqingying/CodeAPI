using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class PD_SCRW
    {
        private static readonly IPD_SCRW mesdetaAccess = MESDataAccess.CreatePD_SCRW();
        private static readonly ISY_YERACOUNT ISY_YERACOUNTdate = MESDataAccess.CreateSY_YERACOUNT();
        private static readonly ISY_TYPEMX ISY_TYPEMXdate = MESDataAccess.CreateSY_TYPEMX();
        private static readonly IMES_MM IMES_MMdate = MESDataAccess.CreateMES_MM();
        private static readonly ISY_DCXH_COUNT ISY_DCXH_COUNTdate = MESDataAccess.CreateSY_DCXH_COUNT();
        private static readonly ITM_ZFDCMX ITM_ZFDCMXdata = MESDataAccess.CreateTM_ZFDCMX();
        private static readonly ISY_PLDH ISY_PLDHdata = MESDataAccess.CreateSY_PLDH();
        private static readonly ISY_PLDH_PH ISY_PLDH_PHdata = MESDataAccess.CreateSY_PLDH_PH();
        private static readonly IPD_TL_ERROR IPD_TL_ERRORdata = MESDataAccess.CreatePD_TL_ERROR();
        private static readonly ISY_MATERIAL_BZCOUNT ISY_MATERIAL_BZCOUNTdata = MESDataAccess.CreateSY_MATERIAL_BZCOUNT();
        private static readonly ISY_GZZX_SBH ISY_GZZX_SBHdata = MESDataAccess.CreateSY_GZZX_SBH();
        private static readonly IMES_PP IMES_PPdate = MESDataAccess.CreateMES_PP();
        private static readonly IPUBLIC_FUNC IPUBLIC_FUNCdata = MESDataAccess.CreatePUBLIC_FUNC();
        private static readonly ISY_SYSCS ISY_SYSCSdata = MESDataAccess.CreateISY_SYSCS();
        private static readonly IPD_GD data_IPD_GD = MESDataAccess.CreatePD_GD();
        private static readonly ISY_TPM_SYNC data_ISY_TPM_SYNC = MESDataAccess.CreateISY_TPM_SYNC();
        SY_GZZX SY_GZZXService = new SY_GZZX();
        PD_GD PD_GDService = new PD_GD();
        TM_TMINFO TM_TMINFOService = new TM_TMINFO();
        PD_TL PD_TLService = new PD_TL();
        TM_CZR TM_CZRService = new TM_CZR();
        public SELECT_MES_PD_SCRW SELECT(MES_PD_SCRW model)
        {
            SELECT_MES_PD_SCRW rst = mesdetaAccess.SELECT(model);
            if (model.CXLB > 0)
            {
                SELECT_MES_PD_SCRW rst_SELECT_MES_PD_SCRW = IMES_PPdate.GET_ZBCFUN_GDBGS_READ(rst.MES_PD_SCRW_LIST);
                rst.MES_PD_SCRW_LIST = rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST;
            }
            if (rst.MES_RETURN.TYPE == "S")
            {
                if (model.CXLB == 0)
                {
                    if (rst.MES_PD_SCRW_LIST.Count > 0)
                    {
                        string PC = "";
                        MES_SY_GZZX model_MES_SY_GZZX = new MES_SY_GZZX();
                        model_MES_SY_GZZX.GC = rst.MES_PD_SCRW_LIST[0].GC;
                        model_MES_SY_GZZX.GZZXBH = rst.MES_PD_SCRW_LIST[0].GZZXBH;
                        List<MES_SY_GZZX> rst_MES_SY_GZZX = SY_GZZXService.SELECT(model_MES_SY_GZZX).ToList();
                        if (rst_MES_SY_GZZX.Count == 1)
                        {
                            PC = (rst.MES_PD_SCRW_LIST[0].ZPRQ.Replace("-", "")).Substring(2, 6) + rst_MES_SY_GZZX[0].CX;
                        }
                        for (int i = 0; i < rst.MES_PD_SCRW_LIST.Count; i++)
                        {
                            rst.MES_PD_SCRW_LIST[i].PC = GET_PC(rst.MES_PD_SCRW_LIST[i], PC);
                            //rst.MES_PD_SCRW_LIST[i] = GET_BZCOUNT(rst.MES_PD_SCRW_LIST[i]);
                            if (rst.MES_PD_SCRW_LIST[i].DCXH == 0)
                            {
                                rst.MES_PD_SCRW_LIST[i].MPSL = 0;
                            }
                            else
                            {
                                MES_SY_DCXH_COUNT model_MES_SY_DCXH_COUNT = new MES_SY_DCXH_COUNT();
                                model_MES_SY_DCXH_COUNT.DCXHID = rst.MES_PD_SCRW_LIST[i].DCXH;
                                MES_SY_DCXH_COUNT_SELECT rst_MES_SY_DCXH_COUNT_SELECT = ISY_DCXH_COUNTdate.SELECT(model_MES_SY_DCXH_COUNT);
                                if (rst_MES_SY_DCXH_COUNT_SELECT.MES_RETURN.TYPE == "S" && rst_MES_SY_DCXH_COUNT_SELECT.MES_SY_DCXH_COUNT.Count == 1)
                                {
                                    rst.MES_PD_SCRW_LIST[i].MPSL = rst_MES_SY_DCXH_COUNT_SELECT.MES_SY_DCXH_COUNT[0].SL;
                                }
                            }
                        }
                    }
                }
            }
            return rst;
        }

        public MES_PD_SCRWANDPD_LIST_SELECT SELECT_SCRW_GD(MES_PD_SCRW model)
        {
            MES_PD_SCRWANDPD_LIST_SELECT rst = new MES_PD_SCRWANDPD_LIST_SELECT();
            try
            {
                List<MES_PD_SCRWANDPD_LIST> child_MES_PD_SCRWANDPD_LIST = new List<MES_PD_SCRWANDPD_LIST>();
                //SELECT_MES_PD_SCRW rst_SELECT_MES_PD_SCRW = SELECT(model);
                //if (rst_SELECT_MES_PD_SCRW.MES_RETURN.TYPE == "S")
                //{
                //    for (int i = 0; i < rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST.Count; i++)
                //    {
                //        MES_PD_SCRW_LIST child_MES_PD_SCRW_LIST = rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[i];
                //        MES_PD_SCRWANDPD_LIST child = new MES_PD_SCRWANDPD_LIST();
                //        child.GC = child_MES_PD_SCRW_LIST.GC;
                //        child.GDDH = child_MES_PD_SCRW_LIST.GDDH;
                //        child.WLH = child_MES_PD_SCRW_LIST.WLH;
                //        child.WLMS = child_MES_PD_SCRW_LIST.WLMS;
                //        child.SL = child_MES_PD_SCRW_LIST.SL;
                //        child.UNITSID = child_MES_PD_SCRW_LIST.UNITSID;
                //        child.UNITSNAME = child_MES_PD_SCRW_LIST.UNITSNAME;
                //        child.ERPNO = child_MES_PD_SCRW_LIST.ERPNO;
                //        child.GZZXBH = child_MES_PD_SCRW_LIST.GZZXBH;
                //        child.SBBH = child_MES_PD_SCRW_LIST.SBBH;
                //        child.SBH = child_MES_PD_SCRW_LIST.SBH;
                //        child.BC = child_MES_PD_SCRW_LIST.BC;
                //        child.BCMS = child_MES_PD_SCRW_LIST.BCMS;
                //        child.RWBH = child_MES_PD_SCRW_LIST.RWBH;
                //        child_MES_PD_SCRWANDPD_LIST.Add(child);
                //    }
                //}
                //else
                //{
                //    rst.MES_RETURN = rst_SELECT_MES_PD_SCRW.MES_RETURN;
                //}
                MES_PD_GD model_MES_PD_GD = new MES_PD_GD();
                model_MES_PD_GD.GC = model.GC;
                model_MES_PD_GD.GZZXBH = model.GZZXBH;
                model_MES_PD_GD.KSDATE = model.ZPRQ;
                model_MES_PD_GD.JSDATE = model.ZPRQ;
                SELECT_MES_PD_GD rst_SELECT_MES_PD_GD = PD_GDService.SELECT(model_MES_PD_GD);
                if (rst_SELECT_MES_PD_GD.MES_RETURN.TYPE == "S")
                {
                    for (int i = 0; i < rst_SELECT_MES_PD_GD.MES_PD_GD_LIST.Count; i++)
                    {
                        MES_PD_GD_LIST child_MES_PD_GD_LIST = rst_SELECT_MES_PD_GD.MES_PD_GD_LIST[i];
                        MES_PD_SCRWANDPD_LIST child = new MES_PD_SCRWANDPD_LIST();
                        child.GC = child_MES_PD_GD_LIST.GC;
                        child.GDDH = child_MES_PD_GD_LIST.GDDH;
                        child.WLH = child_MES_PD_GD_LIST.WLH;
                        child.WLMS = child_MES_PD_GD_LIST.WLMS;
                        child.SL = Convert.ToInt32(child_MES_PD_GD_LIST.SL);
                        child.UNITSID = child_MES_PD_GD_LIST.UNITSID;
                        child.UNITSNAME = child_MES_PD_GD_LIST.UNITSNAME;
                        child.ERPNO = child_MES_PD_GD_LIST.ERPNO;
                        child.GZZXBH = child_MES_PD_GD_LIST.GZZXBH;
                        child.SBBH = "";
                        child.SBH = "";
                        child.BC = 0;
                        child.BCMS = "";
                        child.RWBH = "";
                        child_MES_PD_SCRWANDPD_LIST.Add(child);
                    }
                }
                else
                {
                    rst.MES_RETURN = rst_SELECT_MES_PD_GD.MES_RETURN;
                }
                rst.MES_PD_SCRWANDPD_LIST = child_MES_PD_SCRWANDPD_LIST;
                if (rst.MES_RETURN == null)
                {
                    MES_RETURN mr = new MES_RETURN();
                    mr.TYPE = "S";
                    mr.MESSAGE = "";
                    rst.MES_RETURN = mr;
                }
            }
            catch (Exception e)
            {
                MES_RETURN mr = new MES_RETURN();
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                rst.MES_RETURN = mr;
            }
            return rst;
        }


        public MES_RETURN DELETE(MES_PD_SCRW model)
        {
            return mesdetaAccess.DELETE(model);
        }

        public MES_RETURN INSERT_LIST(List<MES_PD_SCRW_LIST> model)
        {
            MES_RETURN rst_MES_RETURN = new MES_RETURN();
            MES_PD_SCRW model_MES_PD_SCRW = new MES_PD_SCRW();
            if (model.Count > 0)
            {
                DELETE_GZZX(model[0].GC, model[0].GZZXBH, model[0].BC, model[0].GDDH, model[0].ZPRQ);
            }
            for (int i = 0; i < model.Count; i++)
            {
                int count = SELECT_BY_ALL(model[i].GC, model[i].GZZXBH, model[i].SBBH, model[i].ZPRQ, model[i].BC, model[i].GDDH).TID;
                if (count == 0)
                {
                    MES_SY_YERACOUNT model_MES_SY_YERACOUNT = new MES_SY_YERACOUNT();
                    model_MES_SY_YERACOUNT.TMLB = 3;
                    model_MES_SY_YERACOUNT.GC = model[i].GC;
                    model_MES_PD_SCRW = new MES_PD_SCRW();
                    model_MES_PD_SCRW.RWBH = ISY_YERACOUNTdate.SELECT(model_MES_SY_YERACOUNT);
                    model_MES_PD_SCRW.GC = model[i].GC;
                    model_MES_PD_SCRW.RWLB = 1;
                    model_MES_PD_SCRW.GDDH = model[i].GDDH;
                    model_MES_PD_SCRW.GZZXBH = model[i].GZZXBH;
                    model_MES_PD_SCRW.SBBH = model[i].SBBH;
                    model_MES_PD_SCRW.PX = model[i].PX;
                    model_MES_PD_SCRW.ZPRQ = model[i].ZPRQ;
                    model_MES_PD_SCRW.BC = model[i].BC;
                    model_MES_PD_SCRW.SL = model[i].SL;
                    model_MES_PD_SCRW.REMARK = model[i].REMARK;
                    model_MES_PD_SCRW.JLR = model[i].JLR;
                    model_MES_PD_SCRW.ISACTION = model[i].ISACTION;
                    rst_MES_RETURN = mesdetaAccess.INSERT(model_MES_PD_SCRW);
                }
                else
                {
                    rst_MES_RETURN = UPDATE_ISDELETE(model[i].GC, model[i].GZZXBH, model[i].SBBH, model[i].ZPRQ, model[i].BC, model[i].GDDH, model[i].SL);
                }
            }
            return rst_MES_RETURN;
        }

        public SELECT_MES_PD_SCRW SELECT_ZPQD(MES_PD_SCRW model)
        {
            if (model.BC != 0)
            {
                MES_SY_TYPEMX model_MES_SY_TYPEMX = new MES_SY_TYPEMX();
                model_MES_SY_TYPEMX.ID = model.BC;
                List<MES_SY_TYPEMXLIST> rst_MES_SY_TYPEMXLIST = new List<MES_SY_TYPEMXLIST>();
                rst_MES_SY_TYPEMXLIST = ISY_TYPEMXdate.SELECT(model_MES_SY_TYPEMX).ToList();
                if (rst_MES_SY_TYPEMXLIST.Count == 1)
                {
                    model.BCMS = rst_MES_SY_TYPEMXLIST[0].MXNAME;
                }
            }
            MES_PD_GD model_MES_PD_GD = new MES_PD_GD();
            model_MES_PD_GD.GDDH = model.GDDH;
            SELECT_MES_PD_GD rst_SELECT_MES_PD_GD = PD_GDService.SELECT(model_MES_PD_GD);
            if (rst_SELECT_MES_PD_GD.MES_RETURN.TYPE == "S" && rst_SELECT_MES_PD_GD.MES_PD_GD_LIST.Count > 0)
            {
                model.GC = rst_SELECT_MES_PD_GD.MES_PD_GD_LIST[0].GC;
            }
            return mesdetaAccess.SELECT_ZPQD(model);
        }


        public SELECT_MES_PD_SCRW SELECT_TM_TL_BYSB_LAST(MES_PD_SCRW model)
        {
            return mesdetaAccess.SELECT_TM_TL_BYSB_LAST(model);
        }



        public SELECT_MES_PD_SCRW SELECT_LAST(MES_PD_SCRW model)
        {
            SELECT_MES_PD_SCRW rst = new SELECT_MES_PD_SCRW();
            rst = SELECT_TM_TL_BYSB_LAST(model);
            if (rst.MES_RETURN.TYPE == "S")
            {
                //rst.MES_PD_SCRW_LIST = rst.MES_PD_SCRW_LIST;
            }
            else
            {
                SELECT_MES_PD_SCRW rst_SELECT_MES_PD_SCRW = SELECT(model);
                if (rst_SELECT_MES_PD_SCRW.MES_RETURN.TYPE == "S")
                {
                    List<MES_PD_SCRW_LIST> rst_MES_PD_SCRW_LIST = new List<MES_PD_SCRW_LIST>();
                    rst_MES_PD_SCRW_LIST.Add(rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0]);
                    rst.MES_PD_SCRW_LIST = rst_MES_PD_SCRW_LIST;
                }
                else
                {
                    rst.MES_RETURN = rst_SELECT_MES_PD_SCRW.MES_RETURN;
                }
            }
            if (rst.MES_PD_SCRW_LIST.Count > 0)
            {
                string PC = "";
                MES_SY_GZZX model_MES_SY_GZZX = new MES_SY_GZZX();
                model_MES_SY_GZZX.GC = rst.MES_PD_SCRW_LIST[0].GC;
                model_MES_SY_GZZX.GZZXBH = rst.MES_PD_SCRW_LIST[0].GZZXBH;
                List<MES_SY_GZZX> rst_MES_SY_GZZX = SY_GZZXService.SELECT(model_MES_SY_GZZX).ToList();
                if (rst_MES_SY_GZZX.Count == 1)
                {
                    PC = (rst.MES_PD_SCRW_LIST[0].ZPRQ.Replace("-", "")).Substring(2, 6) + rst_MES_SY_GZZX[0].CX;
                    MES_RETURN child_MES_RETURN = new MES_RETURN();
                    child_MES_RETURN.TYPE = "S";
                    child_MES_RETURN.MESSAGE = "";
                    rst.MES_RETURN = child_MES_RETURN;
                }
                else
                {
                    MES_RETURN child_MES_RETURN = new MES_RETURN();
                    child_MES_RETURN.TYPE = "E";
                    child_MES_RETURN.MESSAGE = "没有对应数据！";
                    rst.MES_RETURN = child_MES_RETURN;
                }
                for (int i = 0; i < rst.MES_PD_SCRW_LIST.Count; i++)
                {
                    rst.MES_PD_SCRW_LIST[i].PC = GET_PC(rst.MES_PD_SCRW_LIST[i], PC);
                    //rst.MES_PD_SCRW_LIST[i] = GET_BZCOUNT(rst.MES_PD_SCRW_LIST[i]);
                    if (rst.MES_PD_SCRW_LIST[i].DCXH == 0)
                    {
                        rst.MES_PD_SCRW_LIST[i].MPSL = 0;
                    }
                    else
                    {
                        MES_SY_DCXH_COUNT model_MES_SY_DCXH_COUNT = new MES_SY_DCXH_COUNT();
                        model_MES_SY_DCXH_COUNT.DCXHID = rst.MES_PD_SCRW_LIST[i].DCXH;
                        MES_SY_DCXH_COUNT_SELECT rst_MES_SY_DCXH_COUNT_SELECT = ISY_DCXH_COUNTdate.SELECT(model_MES_SY_DCXH_COUNT);
                        if (rst_MES_SY_DCXH_COUNT_SELECT.MES_RETURN.TYPE == "S" && rst_MES_SY_DCXH_COUNT_SELECT.MES_SY_DCXH_COUNT.Count == 1)
                        {
                            rst.MES_PD_SCRW_LIST[i].MPSL = rst_MES_SY_DCXH_COUNT_SELECT.MES_SY_DCXH_COUNT[0].SL;
                        }
                    }
                }
            }
            return rst;
        }

        public MES_RETURN UPDATE_RWQD_FJTL(MES_PD_SCRW model)
        {
            return mesdetaAccess.UPDATE_RWQD_FJTL(model);
        }

        public SELECT_MES_PD_SCRW UPDATE_FJTL(MES_PD_SCRW model)
        {
            SELECT_MES_PD_SCRW rst = new SELECT_MES_PD_SCRW();
            MES_RETURN child_MES_RETURN = UPDATE_RWQD_FJTL(model);
            if (child_MES_RETURN.TYPE == "E")
            {
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
            MES_PD_SCRW model_MES_PD_SCRW = new MES_PD_SCRW();
            model_MES_PD_SCRW.RWBH = model.RWBH;
            SELECT_MES_PD_SCRW rst_SELECT_MES_PD_SCRW = SELECT(model_MES_PD_SCRW);
            model_MES_PD_SCRW = new MES_PD_SCRW();
            model_MES_PD_SCRW.GC = rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].GC;
            model_MES_PD_SCRW.GZZXBH = rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].GZZXBH;
            model_MES_PD_SCRW.SBBH = rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].SBBH;
            model_MES_PD_SCRW.ZPRQ = rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].ZPRQ;
            rst = SELECT(model_MES_PD_SCRW);
            return rst;
        }

        public MES_RETURN UPDATE_RWQD_FJCC(MES_PD_SCRW model)
        {
            return mesdetaAccess.UPDATE_RWQD_FJCC(model);
        }

        public SELECT_MES_PD_SCRW UPDATE_FJCC(MES_PD_SCRW model)
        {
            SELECT_MES_PD_SCRW rst = new SELECT_MES_PD_SCRW();
            MES_RETURN child_MES_RETURN = UPDATE_RWQD_FJCC(model);
            if (child_MES_RETURN.TYPE == "E")
            {
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }



            MES_PD_SCRW model_MES_PD_SCRW = new MES_PD_SCRW();
            model_MES_PD_SCRW.RWBH = model.RWBH;
            SELECT_MES_PD_SCRW rst_SELECT_MES_PD_SCRW = SELECT(model_MES_PD_SCRW);
            MES_TM_CZR model_MES_TM_CZR = new MES_TM_CZR();
            model_MES_TM_CZR.GC = rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].GC;
            model_MES_TM_CZR.RWBH = rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].RWBH;
            model_MES_TM_CZR.CZLB = 1;
            model_MES_TM_CZR.CZRGH = model.CZRGH;
            model_MES_TM_CZR.GZZXBH = rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].GZZXBH;
            model_MES_TM_CZR.SBBH = rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].SBBH;
            TM_CZRService.INSERT(model_MES_TM_CZR);

            MES_TM_TMINFO_INSERT_GL model_MES_TM_TMINFO_INSERT_GL = new MES_TM_TMINFO_INSERT_GL();
            MES_TM_TMINFO modle_MES_TM_TMINFO = new MES_TM_TMINFO();
            modle_MES_TM_TMINFO.GC = rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].GC;
            modle_MES_TM_TMINFO.TMLB = model.TMLB;
            modle_MES_TM_TMINFO.TMSX = model.TMSX;
            modle_MES_TM_TMINFO.SCDATE = rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].ZPRQ;
            modle_MES_TM_TMINFO.BC = rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].BC;
            modle_MES_TM_TMINFO.RWBH = rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].RWBH;
            modle_MES_TM_TMINFO.PC = rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].PC;
            modle_MES_TM_TMINFO.JLR = model.JLR;
            modle_MES_TM_TMINFO.CPZT = model.CPZT;
            modle_MES_TM_TMINFO.SL = rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].SL;
            modle_MES_TM_TMINFO.KSTIME = rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].TLSJ;
            modle_MES_TM_TMINFO.JSTIME = rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].CCSJ;
            modle_MES_TM_TMINFO.REMARK = model.REMARK;
            modle_MES_TM_TMINFO.TMCOUNT = model.TMCOUNT;
            modle_MES_TM_TMINFO.SBZ = model.SBZ;
            modle_MES_TM_TMINFO.SIZE = model.SIZE;
            modle_MES_TM_TMINFO.MAC = model.MAC;
            List<MES_TM_GL> model_MES_TM_GL = new List<MES_TM_GL>();
            MES_PD_TL rst_MES_PD_TL = PD_TLService.SELECT_FJTL(model.RWBH);
            MES_TM_GL child_MES_TM_GL = new MES_TM_GL();
            child_MES_TM_GL.XCTM = rst_MES_PD_TL.TM;
            child_MES_TM_GL.XCTMGC = rst_MES_PD_TL.GC;
            model_MES_TM_GL.Add(child_MES_TM_GL);
            model_MES_TM_TMINFO_INSERT_GL.MES_TM_GL = model_MES_TM_GL;
            model_MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO = modle_MES_TM_TMINFO;
            MES_TM_TMINFO_INSERT_RETURN rst_MES_TM_TMINFO_INSERT_RETURN = TM_TMINFOService.INSERT(model_MES_TM_TMINFO_INSERT_GL, "", 0);


            model_MES_PD_SCRW = new MES_PD_SCRW();
            model_MES_PD_SCRW.GC = rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].GC;
            model_MES_PD_SCRW.GZZXBH = rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].GZZXBH;
            model_MES_PD_SCRW.SBBH = rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].SBBH;
            model_MES_PD_SCRW.ZPRQ = rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].ZPRQ;
            rst = SELECT(model_MES_PD_SCRW);

            rst.TMINFO = rst_MES_TM_TMINFO_INSERT_RETURN;
            return rst;
        }

        public MES_RETURN FJTL_VERIFY(MES_PD_TL model)
        {
            MES_RETURN mr = new MES_RETURN();
            MES_PD_SCRW model_MES_PD_SCRW = new MES_PD_SCRW();
            model_MES_PD_SCRW.RWBH = model.RWBH;
            SELECT_MES_PD_SCRW rst_SELECT_MES_PD_SCRW = SELECT(model_MES_PD_SCRW);
            if (rst_SELECT_MES_PD_SCRW.MES_RETURN.TYPE == "S")
            {
                if (rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST.Count == 1)
                {
                    MES_TM_TMINFO model_MES_TM_TMINFO = new MES_TM_TMINFO();
                    model_MES_TM_TMINFO.TM = model.TM;
                    SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM = TM_TMINFOService.SELECT_BYTM(model_MES_TM_TMINFO, 0, 1, 1);
                    if (rst_SELECT_MES_TM_TMINFO_BYTM.MES_RETURN.TYPE == "S")
                    {
                        if (rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST.Count == 1)
                        {
                            if (rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0].CPZTNAME == "合格" || rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0].CPZTNAME == "")
                            {
                                if (rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].XFWLH == rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0].WLH && rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].XFPC == rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0].PC)
                                {
                                    mr.TYPE = "S";
                                    mr.MESSAGE = "";
                                    mr = PD_TLService.INSERT(model);
                                }
                                else
                                {
                                    mr.TYPE = "E";
                                    mr.MESSAGE = "条码物料号或批次不匹配！";
                                    MES_PD_TL_ERROR model_MES_PD_TL_ERROR = new MES_PD_TL_ERROR();
                                    model_MES_PD_TL_ERROR.RWBH = model.RWBH;
                                    model_MES_PD_TL_ERROR.TM = model.TM;
                                    model_MES_PD_TL_ERROR.JLR = model.JLR;
                                    model_MES_PD_TL_ERROR.ERRORINFO = "负极投料条码物料号或批次不匹配！";
                                    model_MES_PD_TL_ERROR.TLLB = model.TLLB;
                                    IPD_TL_ERRORdata.INSERT(model_MES_PD_TL_ERROR);
                                }
                            }
                            else
                            {
                                mr.TYPE = "E";
                                mr.MESSAGE = "条码不是合格状态，请检查！";
                            }
                        }
                        else
                        {
                            mr.TYPE = "E";
                            mr.MESSAGE = "输入的条码号有误！";
                        }
                    }
                    else
                    {
                        mr = rst_SELECT_MES_TM_TMINFO_BYTM.MES_RETURN;
                    }
                }
                else
                {
                    mr.TYPE = "E";
                    mr.MESSAGE = "输入的任务编号有误！";
                }
            }
            else
            {
                mr = rst_SELECT_MES_PD_SCRW.MES_RETURN;
            }
            return mr;
        }


        public MES_RETURN DELETE_GZZX(string GC, string GZZXBH, int BC, string GDDH, string ZPRQ)
        {
            return mesdetaAccess.DELETE_GZZX(GC, GZZXBH, BC, GDDH, ZPRQ);
        }

        public MES_RETURN SELECT_BY_ALL(string GC, string GZZXBH, string SBBH, string ZPRQ, int BC, string GDDH)
        {
            return mesdetaAccess.SELECT_BY_ALL(GC, GZZXBH, SBBH, ZPRQ, BC, GDDH);
        }

        public MES_RETURN UPDATE_ISDELETE(string GC, string GZZXBH, string SBBH, string ZPRQ, int BC, string GDDH, decimal SL)
        {
            return mesdetaAccess.UPDATE_ISDELETE(GC, GZZXBH, SBBH, ZPRQ, BC, GDDH, SL);
        }

        public MES_PD_SCRW_CCTH SELECT_ZXCCINFO(string RWBH, int BC, int LB)
        {
            MES_PD_SCRW_CCTH model_MES_PD_SCRW_CCTH = new MES_PD_SCRW_CCTH();
            model_MES_PD_SCRW_CCTH = mesdetaAccess.SELECT_ZXCCINFO(RWBH, BC, LB);
            if (model_MES_PD_SCRW_CCTH.MES_RETURN.TYPE == "S")
            {
                if (model_MES_PD_SCRW_CCTH.KSTIME == "1900-01-01 00:00:00")
                {
                    model_MES_PD_SCRW_CCTH.KSTIME = model_MES_PD_SCRW_CCTH.JSTIME;
                }
            }
            return model_MES_PD_SCRW_CCTH;
        }

        public MES_RETURN ZX_CC(MES_PD_SCRW_ZXCC_INSERT model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            MES_TM_TMINFO modle_MES_TM_TMINFO = new MES_TM_TMINFO();
            modle_MES_TM_TMINFO.GC = model.GC;
            modle_MES_TM_TMINFO.RWBH = model.RWBH;
            modle_MES_TM_TMINFO.TH = model.TH;
            modle_MES_TM_TMINFO.KSTIME = model.KSTIME;
            modle_MES_TM_TMINFO.JSTIME = model.JSTIME;
            modle_MES_TM_TMINFO.TMCOUNT = 1;
            modle_MES_TM_TMINFO.TMLB = model.TMLB;
            modle_MES_TM_TMINFO.TMSX = model.TMSX;
            modle_MES_TM_TMINFO.JLR = model.JLR;
            modle_MES_TM_TMINFO.CPZT = model.CPZT;
            modle_MES_TM_TMINFO.REMARK = model.REMARK;
            modle_MES_TM_TMINFO.PC = model.PC;
            modle_MES_TM_TMINFO.SL = model.SL;
            modle_MES_TM_TMINFO.DCSLBS = model.DCSLBS;
            modle_MES_TM_TMINFO.DCSLMBSL = model.DCSLMBSL;
            modle_MES_TM_TMINFO.DCSLYS = model.DCSLYS;
            modle_MES_TM_TMINFO.ZFDCLB = model.ZFDCLB;
            modle_MES_TM_TMINFO.CFTS = model.CFTS;
            modle_MES_TM_TMINFO.MAC = model.MAC;
            if (LB == 1)
            {
                if (modle_MES_TM_TMINFO.ZFDCLB > 0)
                {
                    modle_MES_TM_TMINFO.CPZTNAME = "暂放";
                }
            }
            List<MES_TM_GL> model_MES_TM_GL = new List<MES_TM_GL>();
            MES_TM_TMINFO_INSERT_GL model_MES_TM_TMINFO_INSERT_GL = new MES_TM_TMINFO_INSERT_GL();
            model_MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO = modle_MES_TM_TMINFO;
            model_MES_TM_TMINFO_INSERT_GL.MES_TM_GL = model_MES_TM_GL;
            MES_TM_TMINFO_INSERT_RETURN rst_MES_TM_TMINFO_INSERT_RETURN = TM_TMINFOService.INSERT(model_MES_TM_TMINFO_INSERT_GL, "", 0);
            if (rst_MES_TM_TMINFO_INSERT_RETURN.MES_RETURN.TYPE == "S")
            {
                rst = rst_MES_TM_TMINFO_INSERT_RETURN.MES_RETURN;
                //if (modle_MES_TM_TMINFO.ZFDCLB > 0)
                //{
                //    UPDATE_ZX_CC(model, 1);
                //}
                //else
                //{
                //    UPDATE_ZX_CC(model, 0);
                //}
                UPDATE_ZX_CC(model, LB);
                if (model.ZFDCLB > 0 && model.MES_TM_ZFDCMX.Count > 0)
                {
                    for (int i = 0; i < model.MES_TM_ZFDCMX.Count; i++)
                    {
                        model.MES_TM_ZFDCMX[i].TM = rst_MES_TM_TMINFO_INSERT_RETURN.MES_RETURN.TM;
                        ITM_ZFDCMXdata.INSERT(model.MES_TM_ZFDCMX[i]);
                    }
                }
            }
            else
            {
                rst = rst_MES_TM_TMINFO_INSERT_RETURN.MES_RETURN;
            }
            return rst;
        }
        public MES_RETURN ZX_CC_OLD(MES_PD_SCRW_ZXCC_INSERT model, string YEAR)
        {
            MES_RETURN rst = new MES_RETURN();
            MES_TM_TMINFO modle_MES_TM_TMINFO = new MES_TM_TMINFO();
            modle_MES_TM_TMINFO.GC = model.GC;
            modle_MES_TM_TMINFO.RWBH = model.RWBH;
            modle_MES_TM_TMINFO.TH = model.TH;
            modle_MES_TM_TMINFO.KSTIME = model.KSTIME;
            modle_MES_TM_TMINFO.JSTIME = model.JSTIME;
            modle_MES_TM_TMINFO.TMCOUNT = 1;
            modle_MES_TM_TMINFO.TMLB = model.TMLB;
            modle_MES_TM_TMINFO.TMSX = model.TMSX;
            modle_MES_TM_TMINFO.JLR = model.JLR;
            modle_MES_TM_TMINFO.CPZT = model.CPZT;
            modle_MES_TM_TMINFO.REMARK = model.REMARK;
            modle_MES_TM_TMINFO.PC = model.PC;
            modle_MES_TM_TMINFO.SL = model.SL;
            modle_MES_TM_TMINFO.DCSLBS = model.DCSLBS;
            modle_MES_TM_TMINFO.DCSLMBSL = model.DCSLMBSL;
            modle_MES_TM_TMINFO.DCSLYS = model.DCSLYS;
            modle_MES_TM_TMINFO.ZFDCLB = model.ZFDCLB;
            modle_MES_TM_TMINFO.CFTS = model.CFTS;
            modle_MES_TM_TMINFO.MAC = model.MAC;
            if (modle_MES_TM_TMINFO.ZFDCLB > 0)
            {
                modle_MES_TM_TMINFO.CPZTNAME = "暂放";
            }
            List<MES_TM_GL> model_MES_TM_GL = new List<MES_TM_GL>();
            MES_TM_TMINFO_INSERT_GL model_MES_TM_TMINFO_INSERT_GL = new MES_TM_TMINFO_INSERT_GL();
            model_MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO = modle_MES_TM_TMINFO;
            model_MES_TM_TMINFO_INSERT_GL.MES_TM_GL = model_MES_TM_GL;
            MES_TM_TMINFO_INSERT_RETURN rst_MES_TM_TMINFO_INSERT_RETURN = TM_TMINFOService.INSERT(model_MES_TM_TMINFO_INSERT_GL, YEAR, 0);
            if (rst_MES_TM_TMINFO_INSERT_RETURN.MES_RETURN.TYPE == "S")
            {
                rst = rst_MES_TM_TMINFO_INSERT_RETURN.MES_RETURN;
                if (modle_MES_TM_TMINFO.ZFDCLB > 0)
                {
                    UPDATE_ZX_CC(model, 1);
                }
                else
                {
                    UPDATE_ZX_CC(model, 0);
                }
                if (model.ZFDCLB > 0 && model.MES_TM_ZFDCMX.Count > 0)
                {
                    for (int i = 0; i < model.MES_TM_ZFDCMX.Count; i++)
                    {
                        model.MES_TM_ZFDCMX[i].TM = rst_MES_TM_TMINFO_INSERT_RETURN.MES_RETURN.TM;
                        ITM_ZFDCMXdata.INSERT(model.MES_TM_ZFDCMX[i]);
                    }
                }
            }
            else
            {
                rst = rst_MES_TM_TMINFO_INSERT_RETURN.MES_RETURN;
            }
            return rst;
        }

        public MES_RETURN UPDATE_ZX_CC(MES_PD_SCRW_ZXCC_INSERT model, int LB)
        {
            return mesdetaAccess.UPDATE_ZX_CC(model, LB);
        }

        public SELECT_MES_PD_SCRW_ZX_LIST SELECT_ZX_LIST(string RWBH)
        {
            SELECT_MES_PD_SCRW_ZX_LIST rst = new SELECT_MES_PD_SCRW_ZX_LIST();
            MES_TM_TMINFO model_MES_TM_TMINFO = new MES_TM_TMINFO();
            model_MES_TM_TMINFO.RWBH = RWBH;
            SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM = TM_TMINFOService.SELECT(model_MES_TM_TMINFO, 0);
            rst.MES_RETURN = rst_SELECT_MES_TM_TMINFO_BYTM.MES_RETURN;
            rst.MES_TM_TMINFO_LIST = rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST;
            return rst;
        }

        public MES_RETURN DELETE_ZXCC(string TM)
        {
            return mesdetaAccess.DELETE_ZXCC(TM);
        }

        public MES_RETURN UPDATE_SCRW(MES_PD_SCRW model)
        {
            return mesdetaAccess.UPDATE_SCRW(model);
        }


        public SELECT_MES_PD_SCRW GET_RWBH_BY_ERPNO(MES_PD_SCRW_GET_BY_ERPNO model)
        {
            if (string.IsNullOrEmpty(model.GC))
            {
                MES_SY_GZZX_SBH model_MES_SY_GZZX_SBH = new MES_SY_GZZX_SBH();
                model_MES_SY_GZZX_SBH.SBBH = model.SBBH;
                List<MES_SY_GZZX_SBH> rst_MES_SY_GZZX_SBH = ISY_GZZX_SBHdata.SELECT(model_MES_SY_GZZX_SBH).ToList();
                if (rst_MES_SY_GZZX_SBH.Count == 1)
                {
                    model.GC = rst_MES_SY_GZZX_SBH[0].GC;
                    model.GZZXBH = rst_MES_SY_GZZX_SBH[0].GZZXBH;
                }
            }
            MES_RETURN rst_MES_RETURN = new MES_RETURN();
            SELECT_MES_PD_SCRW rst = new SELECT_MES_PD_SCRW();
            if ((model.GC == "1000" || model.GC == "4000" || model.GC == "5000") && model.ERPNO != "")
            {
                MES_PD_SCRW model_MES_PD_SCRW = new MES_PD_SCRW();
                model_MES_PD_SCRW.GC = model.GC;
                model_MES_PD_SCRW.GZZXBH = model.GZZXBH;
                model_MES_PD_SCRW.SBBH = model.SBBH;
                model_MES_PD_SCRW.ERPNO = model.ERPNO;
                if (string.IsNullOrEmpty(model.ZPRQ))
                {
                    model_MES_PD_SCRW.ZPRQ = IPUBLIC_FUNCdata.GET_DateTime().ToString("yyyy-MM-dd");
                }
                else
                {
                    model_MES_PD_SCRW.ZPRQ = model.ZPRQ;
                }
                rst_MES_RETURN = SELECT_COUNT(model_MES_PD_SCRW);
                if (rst_MES_RETURN.TYPE == "S" && rst_MES_RETURN.TID == 0)
                {
                    rst_MES_RETURN = PD_GDService.SELECT_ERPNO_COUNT(model.GC, model.ERPNO);
                    SELECT_MES_PD_GD rst_SELECT_MES_PD_GD = new SELECT_MES_PD_GD();
                    if (rst_MES_RETURN.TYPE == "S" && rst_MES_RETURN.TID > 0)
                    {
                        MES_PD_GD model_MES_PD_GD = new MES_PD_GD();
                        model_MES_PD_GD.GC = model.GC;
                        model_MES_PD_GD.ERPNO = model.ERPNO;
                        rst_SELECT_MES_PD_GD = PD_GDService.SELECT(model_MES_PD_GD);
                        if (rst_SELECT_MES_PD_GD.MES_PD_GD_LIST[0].GC != model.GC || rst_SELECT_MES_PD_GD.MES_PD_GD_LIST[0].GZZXBH != model.GZZXBH)
                        {
                            rst_MES_RETURN.TYPE = "E";
                            rst_MES_RETURN.MESSAGE = "工单的工厂工作中心与当前选择的不匹配！";
                            rst.MES_RETURN = rst_MES_RETURN;
                            return rst;
                        }
                    }
                    else
                    {
                        //ZBCFUN_GDJGXX_READ rst_ZBCFUN_GDJGXX_READ = IMES_MMdate.get_GDJGXX(model.ERPNO);
                        ZBCFUN_GDJGXX_READ rst_ZBCFUN_GDJGXX_READ = GET_GDJGXX_NEW1(model.GC, model.ERPNO);
                        if (rst_ZBCFUN_GDJGXX_READ.ES_HEADER.WERKS == model.GC && rst_ZBCFUN_GDJGXX_READ.ES_HEADER.ARBPL == model.GZZXBH)
                        {
                            if (rst_ZBCFUN_GDJGXX_READ.ET_BOM.Count == 0 && rst_ZBCFUN_GDJGXX_READ.ES_HEADER.WLDL == "成品")
                            {
                                rst_MES_RETURN.TYPE = "E";
                                rst_MES_RETURN.MESSAGE = "此条码无需关联！";
                                rst.MES_RETURN = rst_MES_RETURN;
                                return rst;
                            }
                            string zh = Newtonsoft.Json.JsonConvert.SerializeObject(rst_ZBCFUN_GDJGXX_READ.ES_HEADER);
                            ZSL_BCST024_PO model_ZSL_BCST024_PO = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_BCST024_PO>(zh);
                            model_ZSL_BCST024_PO.JRL = model.JLR;
                            List<ZSL_BCST024_PO> model_ZSL_BCST024_PO_list = new List<ZSL_BCST024_PO>();
                            model_ZSL_BCST024_PO_list.Add(model_ZSL_BCST024_PO);
                            rst_MES_RETURN = PD_GDService.INSERT_FROM_SAP_GD(model_ZSL_BCST024_PO_list, "");
                            if (rst_MES_RETURN.TYPE == "S" && rst_MES_RETURN.BH != "")
                            {
                                MES_PD_GD model_MES_PD_GD = new MES_PD_GD();
                                model_MES_PD_GD.GDDH = rst_MES_RETURN.BH;
                                rst_SELECT_MES_PD_GD = PD_GDService.SELECT(model_MES_PD_GD);
                            }
                            else
                            {
                                rst.MES_RETURN = rst_MES_RETURN;
                                return rst;
                            }
                        }
                        else
                        {
                            rst_MES_RETURN.TYPE = "E";
                            rst_MES_RETURN.MESSAGE = "工单的工厂工作中心与当前选择的不匹配！";
                            rst.MES_RETURN = rst_MES_RETURN;
                            return rst;
                        }
                    }

                    MES_SY_YERACOUNT model_MES_SY_YERACOUNT = new MES_SY_YERACOUNT();
                    model_MES_SY_YERACOUNT.TMLB = 3;
                    model_MES_SY_YERACOUNT.GC = model.GC;
                    model_MES_PD_SCRW = new MES_PD_SCRW();
                    model_MES_PD_SCRW.RWBH = ISY_YERACOUNTdate.SELECT(model_MES_SY_YERACOUNT);
                    model_MES_PD_SCRW.GC = model.GC;
                    model_MES_PD_SCRW.RWLB = 1;
                    model_MES_PD_SCRW.GDDH = rst_SELECT_MES_PD_GD.MES_PD_GD_LIST[0].GDDH;
                    model_MES_PD_SCRW.GZZXBH = model.GZZXBH;
                    model_MES_PD_SCRW.SBBH = model.SBBH;
                    model_MES_PD_SCRW.PX = 0;
                    model_MES_PD_SCRW.ZPRQ = DateTime.Now.ToString("yyyy-MM-dd");
                    model_MES_PD_SCRW.BC = 0;
                    model_MES_PD_SCRW.SL = Convert.ToInt32(rst_SELECT_MES_PD_GD.MES_PD_GD_LIST[0].SL);
                    model_MES_PD_SCRW.REMARK = "";
                    model_MES_PD_SCRW.JLR = model.JLR;
                    model_MES_PD_SCRW.ISACTION = 2;
                    if (string.IsNullOrEmpty(model.ZPRQ))
                    {
                        model_MES_PD_SCRW.ZPRQ = IPUBLIC_FUNCdata.GET_DateTime().ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        model_MES_PD_SCRW.ZPRQ = model.ZPRQ;
                    }
                    rst_MES_RETURN = mesdetaAccess.INSERT(model_MES_PD_SCRW);
                    if (rst_MES_RETURN.TYPE == "S")
                    {
                        string RWBH = model_MES_PD_SCRW.RWBH;
                        model_MES_PD_SCRW = new MES_PD_SCRW();
                        model_MES_PD_SCRW.RWBH = RWBH;
                        rst = SELECT(model_MES_PD_SCRW);
                    }
                    else
                    {
                        rst.MES_RETURN = rst_MES_RETURN;
                        return rst;
                    }
                }
                else if (rst_MES_RETURN.TYPE == "S" && rst_MES_RETURN.TID > 0)
                {
                    SELECT_MES_PD_SCRW model_SELECT_MES_PD_SCRW = new SELECT_MES_PD_SCRW();
                    model_SELECT_MES_PD_SCRW = SELECT(model_MES_PD_SCRW);
                    if (model_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].GC == model.GC && model_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].GZZXBH == model.GZZXBH)
                    {
                        rst = model_SELECT_MES_PD_SCRW;
                    }
                    else
                    {
                        rst_MES_RETURN.TYPE = "E";
                        rst_MES_RETURN.MESSAGE = "工单的工厂工作中心与当前选择的不匹配！";
                        rst.MES_RETURN = rst_MES_RETURN;
                        return rst;
                    }
                }
                else
                {
                    rst.MES_RETURN = rst_MES_RETURN;
                }
            }
            else
            {
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "无任务单号";
                rst.MES_RETURN = child_MES_RETURN;
            }
            return rst;
        }
        public SELECT_MES_PD_SCRW GET_RWBH_BY_ERPNO_OLD(MES_PD_SCRW_GET_BY_ERPNO model, string YEAR)
        {
            if (model.GC == "" || model.GC == null)
            {
                MES_SY_GZZX_SBH model_MES_SY_GZZX_SBH = new MES_SY_GZZX_SBH();
                model_MES_SY_GZZX_SBH.SBBH = model.SBBH;
                List<MES_SY_GZZX_SBH> rst_MES_SY_GZZX_SBH = ISY_GZZX_SBHdata.SELECT(model_MES_SY_GZZX_SBH).ToList();
                if (rst_MES_SY_GZZX_SBH.Count == 1)
                {
                    model.GC = rst_MES_SY_GZZX_SBH[0].GC;
                    model.GZZXBH = rst_MES_SY_GZZX_SBH[0].GZZXBH;
                }
            }
            MES_RETURN rst_MES_RETURN = new MES_RETURN();
            SELECT_MES_PD_SCRW rst = new SELECT_MES_PD_SCRW();
            if ((model.GC == "1000" || model.GC == "4000" || model.GC == "5000") && model.ERPNO != "")
            {
                MES_PD_SCRW model_MES_PD_SCRW = new MES_PD_SCRW();
                model_MES_PD_SCRW.GC = model.GC;
                model_MES_PD_SCRW.GZZXBH = model.GZZXBH;
                model_MES_PD_SCRW.SBBH = model.SBBH;
                model_MES_PD_SCRW.ERPNO = model.ERPNO;
                if (string.IsNullOrEmpty(model.ZPRQ))
                {
                    model_MES_PD_SCRW.ZPRQ = IPUBLIC_FUNCdata.GET_DateTime().ToString("yyyy-MM-dd");
                }
                else
                {
                    model_MES_PD_SCRW.ZPRQ = model.ZPRQ;
                }
                rst_MES_RETURN = SELECT_COUNT(model_MES_PD_SCRW);
                if (rst_MES_RETURN.TYPE == "S" && rst_MES_RETURN.TID == 0)
                {
                    rst_MES_RETURN = PD_GDService.SELECT_ERPNO_COUNT(model.GC, model.ERPNO);
                    SELECT_MES_PD_GD rst_SELECT_MES_PD_GD = new SELECT_MES_PD_GD();
                    if (rst_MES_RETURN.TYPE == "S" && rst_MES_RETURN.TID > 0)
                    {
                        MES_PD_GD model_MES_PD_GD = new MES_PD_GD();
                        model_MES_PD_GD.GC = model.GC;
                        model_MES_PD_GD.ERPNO = model.ERPNO;
                        rst_SELECT_MES_PD_GD = PD_GDService.SELECT(model_MES_PD_GD);
                        if (rst_SELECT_MES_PD_GD.MES_PD_GD_LIST[0].GC != model.GC || rst_SELECT_MES_PD_GD.MES_PD_GD_LIST[0].GZZXBH != model.GZZXBH)
                        {
                            rst_MES_RETURN.TYPE = "E";
                            rst_MES_RETURN.MESSAGE = "工单的工厂工作中心与当前选择的不匹配！";
                            rst.MES_RETURN = rst_MES_RETURN;
                            return rst;
                        }
                    }
                    else
                    {
                        //ZBCFUN_GDJGXX_READ rst_ZBCFUN_GDJGXX_READ = IMES_MMdate.get_GDJGXX(model.ERPNO);
                        ZBCFUN_GDJGXX_READ rst_ZBCFUN_GDJGXX_READ = GET_GDJGXX_NEW1(model.GC, model.ERPNO);
                        if (rst_ZBCFUN_GDJGXX_READ.ES_HEADER.WERKS == model.GC && rst_ZBCFUN_GDJGXX_READ.ES_HEADER.ARBPL == model.GZZXBH)
                        {
                            if (rst_ZBCFUN_GDJGXX_READ.ET_BOM.Count == 0 && rst_ZBCFUN_GDJGXX_READ.ES_HEADER.WLDL == "成品")
                            {
                                rst_MES_RETURN.TYPE = "E";
                                rst_MES_RETURN.MESSAGE = "此条码无需关联！";
                                rst.MES_RETURN = rst_MES_RETURN;
                                return rst;
                            }
                            string zh = Newtonsoft.Json.JsonConvert.SerializeObject(rst_ZBCFUN_GDJGXX_READ.ES_HEADER);
                            ZSL_BCST024_PO model_ZSL_BCST024_PO = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_BCST024_PO>(zh);
                            model_ZSL_BCST024_PO.JRL = model.JLR;
                            List<ZSL_BCST024_PO> model_ZSL_BCST024_PO_list = new List<ZSL_BCST024_PO>();
                            model_ZSL_BCST024_PO_list.Add(model_ZSL_BCST024_PO);
                            rst_MES_RETURN = PD_GDService.INSERT_FROM_SAP_GD(model_ZSL_BCST024_PO_list, YEAR);
                            if (rst_MES_RETURN.TYPE == "S" && rst_MES_RETURN.BH != "")
                            {
                                MES_PD_GD model_MES_PD_GD = new MES_PD_GD();
                                model_MES_PD_GD.GDDH = rst_MES_RETURN.BH;
                                rst_SELECT_MES_PD_GD = PD_GDService.SELECT(model_MES_PD_GD);
                            }
                            else
                            {
                                rst.MES_RETURN = rst_MES_RETURN;
                                return rst;
                            }
                        }
                        else
                        {
                            rst_MES_RETURN.TYPE = "E";
                            rst_MES_RETURN.MESSAGE = "工单的工厂工作中心与当前选择的不匹配！";
                            rst.MES_RETURN = rst_MES_RETURN;
                            return rst;
                        }
                    }

                    MES_SY_YERACOUNT model_MES_SY_YERACOUNT = new MES_SY_YERACOUNT();
                    model_MES_SY_YERACOUNT.TMLB = 3;
                    model_MES_SY_YERACOUNT.GC = model.GC;
                    model_MES_SY_YERACOUNT.TMYEAR = YEAR;
                    model_MES_PD_SCRW = new MES_PD_SCRW();
                    model_MES_PD_SCRW.RWBH = ISY_YERACOUNTdate.SELECT(model_MES_SY_YERACOUNT);
                    model_MES_PD_SCRW.GC = model.GC;
                    model_MES_PD_SCRW.RWLB = 1;
                    model_MES_PD_SCRW.GDDH = rst_SELECT_MES_PD_GD.MES_PD_GD_LIST[0].GDDH;
                    model_MES_PD_SCRW.GZZXBH = model.GZZXBH;
                    model_MES_PD_SCRW.SBBH = model.SBBH;
                    model_MES_PD_SCRW.PX = 0;
                    model_MES_PD_SCRW.ZPRQ = DateTime.Now.ToString("yyyy-MM-dd");
                    model_MES_PD_SCRW.BC = 0;
                    model_MES_PD_SCRW.SL = Convert.ToInt32(rst_SELECT_MES_PD_GD.MES_PD_GD_LIST[0].SL);
                    model_MES_PD_SCRW.REMARK = "";
                    model_MES_PD_SCRW.JLR = model.JLR;
                    model_MES_PD_SCRW.ISACTION = 2;
                    if (string.IsNullOrEmpty(model.ZPRQ))
                    {
                        model_MES_PD_SCRW.ZPRQ = IPUBLIC_FUNCdata.GET_DateTime().ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        model_MES_PD_SCRW.ZPRQ = model.ZPRQ;
                    }
                    rst_MES_RETURN = mesdetaAccess.INSERT(model_MES_PD_SCRW);
                    if (rst_MES_RETURN.TYPE == "S")
                    {
                        string RWBH = model_MES_PD_SCRW.RWBH;
                        model_MES_PD_SCRW = new MES_PD_SCRW();
                        model_MES_PD_SCRW.RWBH = RWBH;
                        rst = SELECT(model_MES_PD_SCRW);
                    }
                    else
                    {
                        rst.MES_RETURN = rst_MES_RETURN;
                        return rst;
                    }
                }
                else if (rst_MES_RETURN.TYPE == "S" && rst_MES_RETURN.TID > 0)
                {
                    SELECT_MES_PD_SCRW model_SELECT_MES_PD_SCRW = new SELECT_MES_PD_SCRW();
                    model_SELECT_MES_PD_SCRW = SELECT(model_MES_PD_SCRW);
                    if (model_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].GC == model.GC && model_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].GZZXBH == model.GZZXBH)
                    {
                        rst = model_SELECT_MES_PD_SCRW;
                    }
                    else
                    {
                        rst_MES_RETURN.TYPE = "E";
                        rst_MES_RETURN.MESSAGE = "工单的工厂工作中心与当前选择的不匹配！";
                        rst.MES_RETURN = rst_MES_RETURN;
                        return rst;
                    }
                }
                else
                {
                    rst.MES_RETURN = rst_MES_RETURN;
                }
            }
            else
            {
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "无任务单号";
                rst.MES_RETURN = child_MES_RETURN;
            }
            return rst;
        }
        public MES_RETURN SELECT_COUNT(MES_PD_SCRW model)
        {
            return mesdetaAccess.SELECT_COUNT(model);
        }

        public MES_RETURN INSERT(MES_PD_SCRW model)
        {
            return mesdetaAccess.INSERT(model);
        }

        public SELECT_MES_PD_SCRW GET_RWBH_BY_TPM(MES_PD_SCRW_GET_BY_TPM model)
        {
            SELECT_MES_PD_SCRW rst = new SELECT_MES_PD_SCRW();
            ZBCFUN_CPBZ_READ rst_ZBCFUN_CPBZ_READ = new ZBCFUN_CPBZ_READ();
            string mes_werks_pdly = "";
            mes_werks_pdly = ISY_SYSCSdata.SELECT("MES_TPM");
            if (mes_werks_pdly == "0")
            {
                rst_ZBCFUN_CPBZ_READ = IMES_MMdate.get_CPBZ_READ(model.TPM);
            }
            else if (mes_werks_pdly == "1")
            {
                rst_ZBCFUN_CPBZ_READ = data_ISY_TPM_SYNC.GET_CPBZ_READ_NEW1(model.TPM);
            }
            if (rst_ZBCFUN_CPBZ_READ.MES_RETURN.TYPE == "S")
            {
                MES_PD_SCRW_GET_BY_ERPNO model_MES_PD_SCRW_GET_BY_ERPNO = new MES_PD_SCRW_GET_BY_ERPNO();
                if (rst_ZBCFUN_CPBZ_READ.ES_HEADER.WERKS != model.GC)
                {
                    MES_SY_GZZX_SBH model_MES_SY_GZZX_SBH = new MES_SY_GZZX_SBH();
                    model_MES_SY_GZZX_SBH.GC = model.GC;
                    model_MES_SY_GZZX_SBH.SBBH = model.SBBH;
                    List<MES_SY_GZZX_SBH> rst_MES_SY_GZZX_SBH = ISY_GZZX_SBHdata.SELECT(model_MES_SY_GZZX_SBH).ToList();
                    if (rst_MES_SY_GZZX_SBH.Count == 0)
                    {
                        MES_RETURN rst_MES_RETURN = new MES_RETURN();
                        rst_MES_RETURN.TYPE = "E";
                        rst_MES_RETURN.MESSAGE = "设备号不存在";
                        rst.MES_RETURN = rst_MES_RETURN;
                        return rst;
                    }
                    model_MES_SY_GZZX_SBH = new MES_SY_GZZX_SBH();
                    model_MES_SY_GZZX_SBH.GC = rst_ZBCFUN_CPBZ_READ.ES_HEADER.WERKS;
                    model_MES_SY_GZZX_SBH.SBNO = rst_MES_SY_GZZX_SBH[0].SBNO;
                    rst_MES_SY_GZZX_SBH = ISY_GZZX_SBHdata.SELECT(model_MES_SY_GZZX_SBH).ToList();
                    if (rst_MES_SY_GZZX_SBH.Count == 0)
                    {
                        MES_RETURN rst_MES_RETURN = new MES_RETURN();
                        rst_MES_RETURN.TYPE = "E";
                        rst_MES_RETURN.MESSAGE = "设备号不存在";
                        rst.MES_RETURN = rst_MES_RETURN;
                        return rst;
                    }
                    model.GC = rst_MES_SY_GZZX_SBH[0].GC;
                    model.GZZXBH = rst_MES_SY_GZZX_SBH[0].GZZXBH;
                    model.SBBH = rst_MES_SY_GZZX_SBH[0].SBBH;
                }
                model_MES_PD_SCRW_GET_BY_ERPNO.ERPNO = rst_ZBCFUN_CPBZ_READ.ES_HEADER.CKDJH;
                model_MES_PD_SCRW_GET_BY_ERPNO.GC = model.GC;
                model_MES_PD_SCRW_GET_BY_ERPNO.GZZXBH = model.GZZXBH;
                model_MES_PD_SCRW_GET_BY_ERPNO.JLR = model.JLR;
                model_MES_PD_SCRW_GET_BY_ERPNO.SBBH = model.SBBH;
                rst = GET_RWBH_BY_ERPNO(model_MES_PD_SCRW_GET_BY_ERPNO);
                rst.MES_RETURN.GC = rst_ZBCFUN_CPBZ_READ.ES_HEADER.WERKS;
                try
                {

                    decimal sl = Convert.ToDecimal(rst_ZBCFUN_CPBZ_READ.ES_HEADER.SL);
                    for (int i = 0; i < rst.MES_PD_SCRW_LIST.Count; i++)
                    {
                        rst.MES_PD_SCRW_LIST[i].SL = sl;
                    }
                }
                catch
                {

                }
            }
            else
            {
                rst.MES_RETURN = rst_ZBCFUN_CPBZ_READ.MES_RETURN;
            }
            return rst;
        }

        public MES_RETURN INSERT_BY_FJPD(MES_PD_SCRW model)
        {
            MES_RETURN rst = new MES_RETURN();
            MES_SY_YERACOUNT model_MES_SY_YERACOUNT = new MES_SY_YERACOUNT();
            MES_SY_PLDH_PH model_MES_SY_PLDH_PH = new MES_SY_PLDH_PH();
            model_MES_SY_PLDH_PH.GC = model.GC;
            model_MES_SY_PLDH_PH.WLH = model.XFWLH;
            model_MES_SY_PLDH_PH.PH = model.PC;
            model_MES_SY_PLDH_PH.PFDH = model.PFDH;
            model_MES_SY_PLDH_PH.PFLB = model.PFLB;
            MES_SY_PLDH_PH_SELECT rst_MES_SY_PLDH_PH_SELECT = ISY_PLDH_PHdata.SELECT(model_MES_SY_PLDH_PH);
            if (rst_MES_SY_PLDH_PH_SELECT.MES_RETURN.TYPE != "S")
            {
                return rst_MES_SY_PLDH_PH_SELECT.MES_RETURN;
            }
            if (rst_MES_SY_PLDH_PH_SELECT.MES_SY_PLDH_PH.Count > 0)
            {
                model.PLDH = rst_MES_SY_PLDH_PH_SELECT.MES_SY_PLDH_PH[0].PLDH;
            }
            else
            {
                MES_SY_PLDH model_MES_SY_PLDH = new MES_SY_PLDH();
                model_MES_SY_YERACOUNT = new MES_SY_YERACOUNT();
                model_MES_SY_YERACOUNT.TMLB = 4;
                model_MES_SY_YERACOUNT.GC = model.GC;
                model_MES_SY_PLDH.GC = model.GC;
                model_MES_SY_PLDH.PFDH = model.PFDH;
                model_MES_SY_PLDH.PFLB = model.PFLB;
                model_MES_SY_PLDH.PLDH = ISY_YERACOUNTdate.SELECT(model_MES_SY_YERACOUNT);
                model_MES_SY_PLDH.JLRID = model.JLR;
                model_MES_SY_PLDH.ISACTION = 1;
                rst = ISY_PLDHdata.INSERT(model_MES_SY_PLDH);
                if (rst.TYPE != "S")
                {
                    return rst;
                }
                model.PLDH = model_MES_SY_PLDH.PLDH;
                model_MES_SY_PLDH_PH = new MES_SY_PLDH_PH();
                model_MES_SY_PLDH_PH.PLDH = model_MES_SY_PLDH.PLDH;
                model_MES_SY_PLDH_PH.GC = model.GC;
                model_MES_SY_PLDH_PH.WLH = model.XFWLH;
                model_MES_SY_PLDH_PH.PH = model.PC;
                model_MES_SY_PLDH_PH.PFDH = model.PFDH;
                model_MES_SY_PLDH_PH.PFLB = model.PFLB;
                ISY_PLDH_PHdata.INSERT(model_MES_SY_PLDH_PH);
            }
            model_MES_SY_YERACOUNT = new MES_SY_YERACOUNT();
            model_MES_SY_YERACOUNT.TMLB = 3;
            model_MES_SY_YERACOUNT.GC = model.GC;
            model.RWBH = ISY_YERACOUNTdate.SELECT(model_MES_SY_YERACOUNT);
            rst = mesdetaAccess.INSERT_BY_FJPD(model);
            return rst;
        }
        public SELECT_MES_PD_SCRW SELECT_BY_ROLE(MES_PD_SCRW model)
        {
            SELECT_MES_PD_SCRW rst = mesdetaAccess.SELECT_BY_ROLE(model);
            if (rst.MES_PD_SCRW_LIST.Count > 0)
            {
                string PC = "";
                MES_SY_GZZX model_MES_SY_GZZX = new MES_SY_GZZX();
                model_MES_SY_GZZX.GC = rst.MES_PD_SCRW_LIST[0].GC;
                model_MES_SY_GZZX.GZZXBH = rst.MES_PD_SCRW_LIST[0].GZZXBH;
                List<MES_SY_GZZX> rst_MES_SY_GZZX = SY_GZZXService.SELECT(model_MES_SY_GZZX).ToList();
                if (rst_MES_SY_GZZX.Count == 1)
                {
                    PC = (rst.MES_PD_SCRW_LIST[0].ZPRQ.Replace("-", "")).Substring(2, 6) + rst_MES_SY_GZZX[0].CX;
                }
                for (int i = 0; i < rst.MES_PD_SCRW_LIST.Count; i++)
                {
                    rst.MES_PD_SCRW_LIST[i].PC = GET_PC(rst.MES_PD_SCRW_LIST[i], PC);
                    //rst.MES_PD_SCRW_LIST[i] = GET_BZCOUNT(rst.MES_PD_SCRW_LIST[i]);
                    if (rst.MES_PD_SCRW_LIST[i].DCXH == 0)
                    {
                        rst.MES_PD_SCRW_LIST[i].MPSL = 0;
                    }
                    else
                    {
                        MES_SY_DCXH_COUNT model_MES_SY_DCXH_COUNT = new MES_SY_DCXH_COUNT();
                        model_MES_SY_DCXH_COUNT.DCXHID = rst.MES_PD_SCRW_LIST[i].DCXH;
                        MES_SY_DCXH_COUNT_SELECT rst_MES_SY_DCXH_COUNT_SELECT = ISY_DCXH_COUNTdate.SELECT(model_MES_SY_DCXH_COUNT);
                        if (rst_MES_SY_DCXH_COUNT_SELECT.MES_RETURN.TYPE == "S" && rst_MES_SY_DCXH_COUNT_SELECT.MES_SY_DCXH_COUNT.Count == 1)
                        {
                            rst.MES_PD_SCRW_LIST[i].MPSL = rst_MES_SY_DCXH_COUNT_SELECT.MES_SY_DCXH_COUNT[0].SL;
                        }
                    }
                }
            }
            return rst;
        }


        public string GET_PC(MES_PD_SCRW_LIST model, string GZZXPC)
        {
            string PC = "";
            if (model.CHARG == "")
            {
                if (model.WLLBNAME == "包标电池")
                {
                    if (model.XSNOBILL != "")
                    {
                        string xsnobillfirst = model.XSNOBILL.Substring(0, 1);
                        try
                        {
                            Convert.ToInt32(xsnobillfirst);
                            PC = "9";
                        }
                        catch
                        {
                            PC = Convert.ToDateTime(model.ZPRQ).ToString("yyyyMM");
                        }
                    }
                    else
                    {
                        PC = Convert.ToDateTime(model.ZPRQ).ToString("yyyyMM");
                    }
                }
                else if (model.WLLBNAME == "负极封口剂")
                {
                    PC = Convert.ToDateTime(model.ZPRQ).ToString("yyyyMM");
                }
                else if (model.WLLBNAME == "正极封口剂")
                {
                    PC = Convert.ToDateTime(model.ZPRQ).ToString("yyyyMM");
                }
                else if (model.WLLBNAME == "成品")
                {
                    PC = "";
                }
                else if (model.WLLBNAME == "密封圈")
                {
                    PC = "";
                }
                else
                {
                    PC = GZZXPC;
                }
            }
            else
            {
                PC = model.CHARG;
            }
            return PC;
        }

        //public MES_PD_SCRW_LIST GET_BZCOUNT(MES_PD_SCRW_LIST model)
        //{
        //    MES_SY_MATERIAL_BZCOUNT model_MES_SY_MATERIAL_BZCOUNT = new MES_SY_MATERIAL_BZCOUNT();
        //    model_MES_SY_MATERIAL_BZCOUNT.GC = model.GC;
        //    model_MES_SY_MATERIAL_BZCOUNT.GZZXBH = model.GZZXBH;
        //    model_MES_SY_MATERIAL_BZCOUNT.WLH = model.WLH;
        //    MES_SY_MATERIAL_BZCOUNT_SELECT rst = ISY_MATERIAL_BZCOUNTdata.SELECT(model_MES_SY_MATERIAL_BZCOUNT);
        //    if (rst.MES_RETURN.TYPE == "S")
        //    {
        //        if (rst.MES_SY_MATERIAL_BZCOUNT.Count == 1)
        //        {
        //            model.BZCOUNT = rst.MES_SY_MATERIAL_BZCOUNT[0].BZCOUNT;
        //            model.BZBS = rst.MES_SY_MATERIAL_BZCOUNT[0].BZBS;
        //        }
        //    }
        //    return model;
        //}

        public SELECT_MES_PD_SCRW SELECT_BY_TM(MES_PD_SCRW_SELECT_BY_TM model)
        {
            SELECT_MES_PD_SCRW rst = new SELECT_MES_PD_SCRW();
            MES_TM_TMINFO model_MES_TM_TMINFO = new MES_TM_TMINFO();
            model_MES_TM_TMINFO.TM = model.TM;
            SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM = TM_TMINFOService.SELECT(model_MES_TM_TMINFO, 0);
            if (rst_SELECT_MES_TM_TMINFO_BYTM.MES_RETURN.TYPE == "S")
            {
                if (rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST.Count > 0)
                {
                    MES_PD_SCRW model_MES_PD_SCRW = new MES_PD_SCRW();
                    model_MES_PD_SCRW.SBBH = model.SBBH;
                    model_MES_PD_SCRW.ZPRQ = model.ZPRQ;
                    model_MES_PD_SCRW.WLH = rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0].WLH;
                    rst = SELECT(model_MES_PD_SCRW);
                }
                else
                {
                    MES_RETURN model_MES_RETURN = new MES_RETURN();
                    model_MES_RETURN.TYPE = "E";
                    model_MES_RETURN.MESSAGE = "无条码数据！";
                    rst.MES_RETURN = model_MES_RETURN;
                }
            }
            else
            {
                rst.MES_RETURN = rst_SELECT_MES_TM_TMINFO_BYTM.MES_RETURN;
                return rst;
            }
            return rst;
        }
        public MES_SY_FJ_RWKB_SELECT SELECT_JDKB(MES_SY_FJ_RWKB model)
        {
            return mesdetaAccess.SELECT_JDKB(model);
        }
        public MES_PD_SCRW_SUM_SELECT SELECT_SUM(MES_PD_SCRW_SUM_LIST model)
        {
            return mesdetaAccess.SELECT_SUM(model);
        }
        public MES_RETURN INSERT_YEAR(MES_PD_SCRW model, string YEAR)
        {
            MES_SY_YERACOUNT model_MES_SY_YERACOUNT = new MES_SY_YERACOUNT();
            model_MES_SY_YERACOUNT.TMLB = 3;
            model_MES_SY_YERACOUNT.GC = model.GC;
            model_MES_SY_YERACOUNT.TMYEAR = YEAR;
            model.RWBH = ISY_YERACOUNTdate.SELECT(model_MES_SY_YERACOUNT);
            return mesdetaAccess.INSERT(model);
        }
        public MES_RETURN UPDATE_ALL(MES_PD_SCRW_UPDATE_IN model, int LB)
        {
            return mesdetaAccess.UPDATE_ALL(model, LB);
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
    }
}

using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class MES_MM
    {
        PD_SCRW PD_SCRWservice = new PD_SCRW();
        SY_TYPEMX SY_TYPEMXService = new SY_TYPEMX();
        private static readonly IMES_MM mesdetaAccess = MESDataAccess.CreateMES_MM();
        private static readonly IPD_GD_BOM dataPD_GD_BOM = MESDataAccess.CreatePD_GD_BOM();
        private static readonly ISY_SYSCS ISY_SYSCSdata = MESDataAccess.CreateISY_SYSCS();
        private static readonly IPD_GD data_IPD_GD = MESDataAccess.CreatePD_GD();
        private static readonly ISY_PFDH_WL ISY_PFDH_WLdata = MESDataAccess.CreateSY_PFDH_WL();
        private static readonly ISY_TPM_SYNC data_ISY_TPM_SYNC = MESDataAccess.CreateISY_TPM_SYNC();
        public ZBCFUN_KCDD_READ GET_KCDD(string IV_WERKS)
        {
            return mesdetaAccess.GET_KCDD(IV_WERKS);
        }

        public IList<ZSL_BCST300> GET_GZZX(string IV_WERKS)
        {
            return mesdetaAccess.GET_GZZX(IV_WERKS);
        }

        public IList<ZSL_BCST301> GET_PFDH()
        {
            return mesdetaAccess.GET_PFDH();
        }

        public MES_SY_MATERIAL_GROUP_SELECT GET_WLGROUP()
        {
            return mesdetaAccess.GET_WLGROUP();
        }

        public MES_SY_MATERIAL_INSERT_LIST GET_WLXXBYGROUP(string IV_WERKS, string WLGROUP, string MATNR, string FCODE)
        {
            return mesdetaAccess.GET_WLXXBYGROUP(IV_WERKS, WLGROUP, MATNR, FCODE);
        }


        public ZBCFUN_GDJGXX_READ get_GDJGXX(string RWBH, string ZPRQ, string GC)
        {
            SELECT_MES_PD_SCRW model_SELECT_MES_PD_SCRW = new SELECT_MES_PD_SCRW();
            MES_PD_SCRW model_MES_PD_SCRW = new MES_PD_SCRW();
            model_MES_PD_SCRW.RWBH = RWBH;
            model_MES_PD_SCRW.ZPRQ = ZPRQ;
            model_MES_PD_SCRW.GC = GC;
            model_SELECT_MES_PD_SCRW = PD_SCRWservice.SELECT(model_MES_PD_SCRW);
            if (model_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST.Count == 1)
            {
                //if (model_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].GC == "1000" && model_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].GDLB == 1)
                if (model_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].GDLB == 1)
                {
                    ZBCFUN_GDJGXX_READ rst = new ZBCFUN_GDJGXX_READ();
                    rst = GET_GDJGXX_NEW1(model_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].GC, model_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].ERPNO);
                    if (rst.ET_BOM.Count > 0)
                    {
                        for (int i = 0; i < rst.ET_BOM.Count; i++)
                        {
                            MES_SY_TYPEMX model_SY_TYPEMX = new MES_SY_TYPEMX();
                            List<MES_SY_TYPEMXLIST> model_MES_SY_TYPEMXLIST = new List<MES_SY_TYPEMXLIST>();
                            if (rst.ET_BOM[i].WLLBNAME != "")
                            {
                                model_SY_TYPEMX.MXNAME = rst.ET_BOM[i].WLLBNAME;
                                model_SY_TYPEMX.TYPEID = 4;
                                model_SY_TYPEMX.GC = model_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].GC;
                                model_MES_SY_TYPEMXLIST = SY_TYPEMXService.SELECT(model_SY_TYPEMX).ToList();
                                if (model_MES_SY_TYPEMXLIST.Count == 1)
                                {
                                    rst.ET_BOM[i].WLLB = model_MES_SY_TYPEMXLIST[0].ID;
                                }
                            }
                            else
                            {
                                rst.ET_BOM[i].WLLB = 0;
                            }
                            if (rst.ET_BOM[i].DCXHNAME != "")
                            {
                                model_SY_TYPEMX.MXNAME = rst.ET_BOM[i].DCXHNAME;
                                model_SY_TYPEMX.TYPEID = 6;
                                model_SY_TYPEMX.GC = model_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].GC;
                                model_MES_SY_TYPEMXLIST = SY_TYPEMXService.SELECT(model_SY_TYPEMX).ToList();
                                if (model_MES_SY_TYPEMXLIST.Count == 1)
                                {
                                    rst.ET_BOM[i].DCXH = model_MES_SY_TYPEMXLIST[0].ID;
                                }
                            }
                            else
                            {
                                rst.ET_BOM[i].DCXH = 0;
                            }
                            if (rst.ET_BOM[i].DCDJNAME != "")
                            {
                                model_SY_TYPEMX.MXNAME = rst.ET_BOM[i].DCDJNAME;
                                model_SY_TYPEMX.TYPEID = 7;
                                model_SY_TYPEMX.GC = model_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].GC;
                                model_MES_SY_TYPEMXLIST = SY_TYPEMXService.SELECT(model_SY_TYPEMX).ToList();
                                if (model_MES_SY_TYPEMXLIST.Count == 1)
                                {
                                    rst.ET_BOM[i].DCDJ = model_MES_SY_TYPEMXLIST[0].ID;
                                }
                            }
                            else
                            {
                                rst.ET_BOM[i].DCDJ = 0;
                            }
                        }
                    }
                    return rst;
                }
                else if (model_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].GDLB == 2)
                {
                    ZBCFUN_GDJGXX_READ rst = new ZBCFUN_GDJGXX_READ();
                    MES_RETURN child_MES_RETURN = new MES_RETURN();
                    List<ET_BOM> child_ET_BOM = new List<ET_BOM>();
                    List<ZSL_BCST302_R> child_ZSL_BCST302_R = new List<ZSL_BCST302_R>();
                    ET_BOM child = new ET_BOM();
                    child.WERKS = "1000";
                    child.POSNR = "0010";
                    child.IDNRK = model_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].WLH;
                    child.MAKTX = model_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].WLMS;
                    child.WLLB = model_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].WLLB;
                    child.WLLBNAME = model_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].WLLBNAME;
                    child.ZSBS = "Y";
                    child_ET_BOM.Add(child);
                    child_MES_RETURN.TYPE = "S";
                    child_MES_RETURN.MESSAGE = "";
                    rst.MES_RETURN = child_MES_RETURN;
                    rst.ET_BOM = child_ET_BOM;
                    rst.ET_RT = child_ZSL_BCST302_R;
                    return rst;
                }
                else if (model_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].GDLB == 3)
                {
                    ZBCFUN_GDJGXX_READ rst = new ZBCFUN_GDJGXX_READ();
                    MES_RETURN child_MES_RETURN = new MES_RETURN();
                    List<ET_BOM> child_ET_BOM = new List<ET_BOM>();
                    List<ZSL_BCST302_R> child_ZSL_BCST302_R = new List<ZSL_BCST302_R>();
                    MES_PD_GD_BOM model_MES_PD_GD_BOM = new MES_PD_GD_BOM();
                    model_MES_PD_GD_BOM.GDDH = model_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].GDDH;
                    MES_PD_GD_BOM_SELECT rst_MES_PD_GD_BOM_SELECT = dataPD_GD_BOM.SELECT(model_MES_PD_GD_BOM);
                    if (rst_MES_PD_GD_BOM_SELECT.MES_RETURN.TYPE == "S")
                    {
                        for (int i = 0; i < rst_MES_PD_GD_BOM_SELECT.MES_PD_GD_BOM.Count; i++)
                        {
                            ET_BOM child = new ET_BOM();
                            child.WERKS = rst_MES_PD_GD_BOM_SELECT.MES_PD_GD_BOM[i].GC;
                            child.POSNR = ((i + 1) * 10).ToString().PadLeft(4, '0');
                            child.IDNRK = rst_MES_PD_GD_BOM_SELECT.MES_PD_GD_BOM[i].WLH;
                            child.MAKTX = rst_MES_PD_GD_BOM_SELECT.MES_PD_GD_BOM[i].WLMS;
                            child.WLLB = rst_MES_PD_GD_BOM_SELECT.MES_PD_GD_BOM[i].WLLB;
                            child.WLLBNAME = rst_MES_PD_GD_BOM_SELECT.MES_PD_GD_BOM[i].WLLBNAME;
                            if (rst_MES_PD_GD_BOM_SELECT.MES_PD_GD_BOM[i].ISTRACE == 0)
                            {
                                child.ZSBS = "";
                            }
                            else
                            {
                                child.ZSBS = "Y";
                            }
                            child_ET_BOM.Add(child);
                        }
                    }
                    child_MES_RETURN.TYPE = "S";
                    child_MES_RETURN.MESSAGE = "";
                    rst.MES_RETURN = child_MES_RETURN;
                    rst.ET_BOM = child_ET_BOM;
                    rst.ET_RT = child_ZSL_BCST302_R;
                    return rst;
                }
                else
                {
                    ZBCFUN_GDJGXX_READ rst = new ZBCFUN_GDJGXX_READ();
                    MES_RETURN child_MES_RETURN = new MES_RETURN();
                    child_MES_RETURN.TYPE = "E";
                    child_MES_RETURN.MESSAGE = "无对应工厂，请检查对应工厂是否正确";
                    rst.MES_RETURN = child_MES_RETURN;
                    return rst;
                }
            }
            else
            {
                ZBCFUN_GDJGXX_READ rst = new ZBCFUN_GDJGXX_READ();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "找不到对应生产任务单";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }

        public ZBCFUN_GDLIST_READ GET_GDLIST(string IV_WERKS, string IV_GZZX, string IV_WLDL, string IV_AUFNR, string LOW, string HIGH)
        {
            string mes_werks_pdly = ISY_SYSCSdata.SELECT("MES_" + IV_WERKS + "_GDLY");
            ZBCFUN_GDLIST_READ rst = new ZBCFUN_GDLIST_READ();
            if (mes_werks_pdly == "0")
            {
                LOW = LOW.Replace("-", "");
                HIGH = HIGH.Replace("-", "");
                rst = mesdetaAccess.GET_GDLIST(IV_WERKS, IV_GZZX, IV_WLDL, IV_AUFNR, LOW, HIGH);
            }
            else if (mes_werks_pdly == "1")
            {
                rst = GET_GDLIST_NEW1(IV_WERKS, IV_GZZX, IV_WLDL, IV_AUFNR, LOW, HIGH);
            }
            return rst;
        }
        public ZBCFUN_GDLIST_READ GET_GDLIST_1(string IV_WERKS, string IV_GZZX, string IV_WLDL, string IV_AUFNR, string LOW, string HIGH)
        {
            string mes_werks_pdly = ISY_SYSCSdata.SELECT("MES_" + IV_WERKS + "_GDLY");
            ZBCFUN_GDLIST_READ rst = new ZBCFUN_GDLIST_READ();
            if (mes_werks_pdly == "0")
            {
                LOW = LOW.Replace("-", "");
                HIGH = HIGH.Replace("-", "");
                rst = mesdetaAccess.GET_GDLIST_1(IV_WERKS, IV_GZZX, IV_WLDL, IV_AUFNR, LOW, HIGH);
            }
            else if (mes_werks_pdly == "1")
            {
                rst = GET_GDLIST_NEW1(IV_WERKS, IV_GZZX, IV_WLDL, IV_AUFNR, LOW, HIGH);
            }
            return rst;
        }

        public MES_SY_PFDH_LIST GET_PFDH_ACTION_SAP(string GC)
        {
            return mesdetaAccess.GET_PFDH_ACTION_SAP(GC);
        }


        public ZBCFUN_GDJGXX_READ get_GDJGXX_BYGD(string GD, string GC)
        {
            if (GC == "1000" || GC == "4000" || GC == "5000")
            {
                //return mesdetaAccess.get_GDJGXX(GD);
                return GET_GDJGXX_NEW1(GC, GD);
            }
            else
            {
                ZBCFUN_GDJGXX_READ rst = new ZBCFUN_GDJGXX_READ();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "没有对应工单！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }

        public ZBCFUN_GDJGXX_READ get_GDJGXX(string IV_AUFNR)
        {
            //ZBCFUN_GDJGXX_READ rst = mesdetaAccess.get_GDJGXX(IV_AUFNR);
            ZBCFUN_GDJGXX_READ rst = GET_GDJGXX_NEW_ONLYAUFNR(IV_AUFNR);
            if (rst.MES_RETURN.TYPE == "S")
            {
                if (rst.ES_HEADER.WLDL != "")
                {
                    MES_SY_TYPEMX model_SY_TYPEMX = new MES_SY_TYPEMX();
                    List<MES_SY_TYPEMXLIST> model_MES_SY_TYPEMXLIST = new List<MES_SY_TYPEMXLIST>();
                    model_SY_TYPEMX.MXNAME = rst.ES_HEADER.WLDL;
                    model_SY_TYPEMX.TYPEID = 4;
                    model_SY_TYPEMX.GC = rst.ES_HEADER.WERKS;
                    model_MES_SY_TYPEMXLIST = SY_TYPEMXService.SELECT(model_SY_TYPEMX).ToList();
                    if (model_MES_SY_TYPEMXLIST.Count == 1)
                    {
                        rst.ES_HEADER.WLLB = model_MES_SY_TYPEMXLIST[0].ID;
                    }
                }
            }
            return rst;
        }

        public ZBCFUN_GDJGXX_READ get_GDJGXX_GC(string IV_WERKS, string IV_AUFNR)
        {
            //ZBCFUN_GDJGXX_READ rst = mesdetaAccess.get_GDJGXX(IV_AUFNR);
            ZBCFUN_GDJGXX_READ rst = GET_GDJGXX_NEW1(IV_WERKS, IV_AUFNR);
            if (rst.MES_RETURN.TYPE == "S")
            {
                if (rst.ES_HEADER.WLDL != "")
                {
                    MES_SY_TYPEMX model_SY_TYPEMX = new MES_SY_TYPEMX();
                    List<MES_SY_TYPEMXLIST> model_MES_SY_TYPEMXLIST = new List<MES_SY_TYPEMXLIST>();
                    model_SY_TYPEMX.MXNAME = rst.ES_HEADER.WLDL;
                    model_SY_TYPEMX.TYPEID = 4;
                    model_SY_TYPEMX.GC = rst.ES_HEADER.WERKS;
                    model_MES_SY_TYPEMXLIST = SY_TYPEMXService.SELECT(model_SY_TYPEMX).ToList();
                    if (model_MES_SY_TYPEMXLIST.Count == 1)
                    {
                        rst.ES_HEADER.WLLB = model_MES_SY_TYPEMXLIST[0].ID;
                    }
                }
            }
            return rst;
        }

        public ZBCFUN_CPBZ_READ get_CPBZ_READ(string IV_TPM)
        {
            ZBCFUN_CPBZ_READ rst = new ZBCFUN_CPBZ_READ();
            string mes_werks_pdly = "";
            mes_werks_pdly = ISY_SYSCSdata.SELECT("MES_TPM");
            if (mes_werks_pdly == "0")
            {
                rst = mesdetaAccess.get_CPBZ_READ(IV_TPM);
                if (rst.MES_RETURN.TYPE == "S")
                {
                    if (rst.ES_HEADER.WLDL != "")
                    {
                        MES_SY_TYPEMX model_SY_TYPEMX = new MES_SY_TYPEMX();
                        List<MES_SY_TYPEMXLIST> model_MES_SY_TYPEMXLIST = new List<MES_SY_TYPEMXLIST>();
                        model_SY_TYPEMX.MXNAME = rst.ES_HEADER.WLDL;
                        model_SY_TYPEMX.TYPEID = 4;
                        model_SY_TYPEMX.GC = rst.ES_HEADER.WERKS;
                        model_MES_SY_TYPEMXLIST = SY_TYPEMXService.SELECT(model_SY_TYPEMX).ToList();
                        if (model_MES_SY_TYPEMXLIST.Count == 1)
                        {
                            rst.ES_HEADER.WLLB = model_MES_SY_TYPEMXLIST[0].ID;
                        }
                    }
                }
            }
            else if (mes_werks_pdly == "1")
            {
                rst = data_ISY_TPM_SYNC.GET_CPBZ_READ_NEW1(IV_TPM);
            }
            return rst;
        }

        public ZBCFUN_PURBS_READ GET_PURBS_READ(string IV_FCODE, ZSL_BCS303_CT IS_PURCT, ZSL_BCS303_BS IS_PURBS)
        {
            return mesdetaAccess.GET_PURBS_READ(IV_FCODE, IS_PURCT, IS_PURBS);
        }
        public ZBCFUN_XFPC_READ GET_XFPC_READ(string IV_WERKS, string IV_MATNR)
        {
            return GET_XFPC_READ_NEW1(IV_WERKS, IV_MATNR);
        }
        public ZBCFUN_GDLIST_READ GET_GDLIST_NEW1(string IV_WERKS, string IV_GZZX, string IV_WLDL, string IV_AUFNR, string LOW, string HIGH)
        {
            ZBCFUN_GDLIST_READ rst = new ZBCFUN_GDLIST_READ();
            MES_PD_GD_SYNC model_MES_PD_GD_SYNC = new MES_PD_GD_SYNC();
            model_MES_PD_GD_SYNC.WERKS = IV_WERKS;
            model_MES_PD_GD_SYNC.ARBPL = IV_GZZX;
            model_MES_PD_GD_SYNC.WLDL = IV_WLDL;
            model_MES_PD_GD_SYNC.AUFNR = IV_AUFNR;
            model_MES_PD_GD_SYNC.LOW = LOW;
            model_MES_PD_GD_SYNC.HIGH = HIGH;
            model_MES_PD_GD_SYNC.LB = 1;
            MES_PD_GD_SYNC_SELECT rst_MES_PD_GD_SYNC_SELECT = data_IPD_GD.SELECT_GD_SYNC(model_MES_PD_GD_SYNC);
            if (rst_MES_PD_GD_SYNC_SELECT.MES_RETURN.TYPE != "S")
            {
                rst.MES_RETURN = rst_MES_PD_GD_SYNC_SELECT.MES_RETURN;
                return rst;
            }
            List<ZSL_BCST024_PO> model_ZSL_BCST024_POlist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ZSL_BCST024_PO>>(Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_PD_GD_SYNC_SELECT.DATALIST));
            rst.ET_POLIST = model_ZSL_BCST024_POlist;

            model_MES_PD_GD_SYNC.LB = 2;
            rst_MES_PD_GD_SYNC_SELECT = data_IPD_GD.SELECT_GD_SYNC(model_MES_PD_GD_SYNC);
            if (rst_MES_PD_GD_SYNC_SELECT.MES_RETURN.TYPE != "S")
            {
                rst.MES_RETURN = rst_MES_PD_GD_SYNC_SELECT.MES_RETURN;
                return rst;
            }
            List<ZSL_BCS302_B> model_ZSL_BCS302_B_LIST = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ZSL_BCS302_B>>(Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_PD_GD_SYNC_SELECT.DATALIST));
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
            MES_RETURN mr = new MES_RETURN();
            mr.TYPE = "S";
            mr.MESSAGE = "";
            rst.MES_RETURN = mr;
            return rst;
        }

        public ZBCFUN_GDJGXX_READ GET_GDJGXX_NEW1(string IV_WERKS, string IV_AUFNR)
        {
            ZBCFUN_GDJGXX_READ rst = new ZBCFUN_GDJGXX_READ();
            string mes_werks_pdly = "";
            if (IV_WERKS == "")
            {
                rst = mesdetaAccess.get_GDJGXX(IV_AUFNR);
                return rst;
            }
            mes_werks_pdly = ISY_SYSCSdata.SELECT("MES_" + IV_WERKS + "_GDLY");
            MES_RETURN mr = new MES_RETURN();
            
            if (mes_werks_pdly == "0")
            {
                rst = mesdetaAccess.get_GDJGXX(IV_AUFNR);
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
        public ZBCFUN_GDJGXX_READ GET_GDJGXX_NEW_ONLYAUFNR(string IV_AUFNR)
        {
            ZBCFUN_GDJGXX_READ rst = new ZBCFUN_GDJGXX_READ();
            string mes_werks_pdly = "";
            mes_werks_pdly = ISY_SYSCSdata.SELECT("MES_GDLYALL");
            MES_RETURN mr = new MES_RETURN();

            if (mes_werks_pdly == "0")
            {
                rst = mesdetaAccess.get_GDJGXX(IV_AUFNR);
            }
            else if (mes_werks_pdly == "1")
            {
                MES_PD_GD_SYNC model_MES_PD_GD_SYNC = new MES_PD_GD_SYNC();
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
        public ZBCFUN_XFPC_READ GET_XFPC_READ_NEW1(string WERKS, string MATNR)
        {
            string mes_werks_pdly = "";
            if (WERKS == "")
            {
                mes_werks_pdly = "0";
            }
            else
            {
                mes_werks_pdly = ISY_SYSCSdata.SELECT("MES_" + WERKS + "_GDLY");
            }

            MES_RETURN mr = new MES_RETURN();
            ZBCFUN_XFPC_READ rst = new ZBCFUN_XFPC_READ();
            if (mes_werks_pdly == "0")
            {
                rst = mesdetaAccess.GET_XFPC_READ(WERKS, MATNR);
            }
            else if (mes_werks_pdly == "1")
            {
                ZSL_BCS304 model_ZSL_BCS304 = new ZSL_BCS304();
                model_ZSL_BCS304.WERKS = WERKS;
                model_ZSL_BCS304.MATNR = MATNR;
                MES_SY_XFPC_SYNC_SELECT rst_MES_SY_XFPC_SYNC_SELECT = ISY_PFDH_WLdata.XFPC_SYNC_SELECT(model_ZSL_BCS304, 1);
                if (rst_MES_SY_XFPC_SYNC_SELECT.MES_RETURN.TYPE != "S")
                {
                    rst.MES_RETURN = rst_MES_SY_XFPC_SYNC_SELECT.MES_RETURN;
                    return rst;
                }
                List<ZSL_BCS304> rst_ZSL_BCS304 = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ZSL_BCS304>>(Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_SY_XFPC_SYNC_SELECT.ZSL_BCS304));
                rst.ET_CHARG = rst_ZSL_BCS304;
                mr.TYPE = "S";
                mr.MESSAGE = "";
                rst.MES_RETURN = mr;
            }
            return rst;
        }
    }
}

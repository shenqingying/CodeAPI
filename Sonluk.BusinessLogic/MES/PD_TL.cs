using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class PD_TL
    {
        private static readonly IPD_TL mesdetaAccess = MESDataAccess.CreatePD_TL();
        private static readonly IPD_SCRW IPD_SCRWdate = MESDataAccess.CreatePD_SCRW();
        private static readonly IMES_MM IMES_MMdate = MESDataAccess.CreateMES_MM();
        private static readonly ITM_TMINFO ITM_TMINFOdate = MESDataAccess.CreateTM_TMINFO();
        private static readonly ISY_CHANGEINFO ISY_CHANGEINFOdata = MESDataAccess.CreateSY_CHANGEINFO();
        private static readonly ISY_SYSCS ISY_SYSCSdata = MESDataAccess.CreateISY_SYSCS();
        private static readonly IPD_GD data_IPD_GD = MESDataAccess.CreatePD_GD();
        public MES_RETURN INSERT(MES_PD_TL model)
        {
            return mesdetaAccess.INSERT(model);
        }

        public MES_RETURN DELETE(MES_PD_TL_DELETE_IN model)
        {
            return mesdetaAccess.DELETE(model);
        }

        public MES_PD_TL SELECT_FJTL(string RWBH)
        {
            return mesdetaAccess.SELECT_FJTL(RWBH);
        }

        public MES_PD_TL_SELECT SELECT(MES_PD_TL model)
        {
            return mesdetaAccess.SELECT(model);
        }

        public MES_RETURN UPDATE_TLTMTH(MES_PD_TL_UPDATE_TLTMTH_IN model)
        {
            MES_RETURN rst = new MES_RETURN();
            //return mesdetaAccess.UPDATE_TLTMTH(TMTLID, TM);
            MES_PD_TL model_MES_PD_TL = new MES_PD_TL();
            model_MES_PD_TL.ID = model.TMTLID;
            MES_PD_TL_SELECT rst_MES_PD_TL_SELECT = SELECT(model_MES_PD_TL);
            MES_TM_TMINFO model_MES_TM_TMINFO = new MES_TM_TMINFO();
            model_MES_TM_TMINFO.TM = model.TM;
            SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM = ITM_TMINFOdate.SELECT_BYTM(model_MES_TM_TMINFO, 1);
            if (rst_SELECT_MES_TM_TMINFO_BYTM.MES_RETURN.TYPE == "S")
            {
                if (rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST.Count == 1)
                {
                    if (rst_MES_PD_TL_SELECT.MES_RETURN.TYPE == "S")
                    {
                        if (rst_MES_PD_TL_SELECT.MES_PD_TL_LIST.Count == 1)
                        {
                            MES_PD_SCRW model_MES_PD_SCRW = new MES_PD_SCRW();
                            model_MES_PD_SCRW.RWBH = rst_MES_PD_TL_SELECT.MES_PD_TL_LIST[0].RWBH;
                            SELECT_MES_PD_SCRW rst_SELECT_MES_PD_SCRW = IPD_SCRWdate.SELECT(model_MES_PD_SCRW);
                            if (rst_SELECT_MES_PD_SCRW.MES_RETURN.TYPE == "S")
                            {
                                if (rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST.Count == 1)
                                {
                                    //ZBCFUN_GDJGXX_READ rst_ZBCFUN_GDJGXX_READ = IMES_MMdate.get_GDJGXX(rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].ERPNO);
                                    ZBCFUN_GDJGXX_READ rst_ZBCFUN_GDJGXX_READ = GET_GDJGXX_NEW1(rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].GC, rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].ERPNO);
                                    if (rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[0].ISOPEN == 0)
                                    {
                                        int tmcount = 0;
                                        for (int i = 0; i < rst_ZBCFUN_GDJGXX_READ.ET_BOM.Count; i++)
                                        {
                                            if (rst_ZBCFUN_GDJGXX_READ.ET_BOM[i].IDNRK == rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0].WLH)
                                            {
                                                tmcount = tmcount + 1;
                                            }
                                        }
                                        if (tmcount == 0)
                                        {
                                            rst.TYPE = "E";
                                            rst.MESSAGE = "投料物料号与工单不匹配！";
                                        }
                                        else
                                        {
                                            rst = mesdetaAccess.UPDATE_TLTMTH(model);
                                            return rst;
                                        }
                                    }
                                    else
                                    {
                                        int tmcount = 0;
                                        for (int i = 0; i < rst_ZBCFUN_GDJGXX_READ.ET_BOM.Count; i++)
                                        {
                                            if (rst_ZBCFUN_GDJGXX_READ.ET_BOM[i].WLLB == rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0].WLLB)
                                            {
                                                tmcount = tmcount + 1;
                                            }
                                        }
                                        if (tmcount == 0)
                                        {
                                            rst.TYPE = "E";
                                            rst.MESSAGE = "投料物料号与工单不匹配！";
                                        }
                                        else
                                        {
                                            return mesdetaAccess.UPDATE_TLTMTH(model);
                                        }
                                    }
                                }
                                else
                                {
                                    rst.TYPE = "E";
                                    rst.MESSAGE = "请检查任务单号";
                                }
                            }
                        }
                        else
                        {
                            rst.TYPE = "E";
                            rst.MESSAGE = "请检查对应的条码投料ID！";
                        }
                    }
                    else
                    {
                        rst = rst_MES_PD_TL_SELECT.MES_RETURN;
                    }
                }
                else
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "请检查对应的投料条码！";
                }
            }
            else
            {
                rst = rst_SELECT_MES_TM_TMINFO_BYTM.MES_RETURN;
            }
            return rst;
        }

        public MES_PD_TL_SELECT_REPORT SELECT_REPORT(MES_PD_TL_IN_SELECT_REPORT model)
        {
            return mesdetaAccess.SELECT_REPORT(model);
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

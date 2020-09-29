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
    public class PD_GD
    {
        private static readonly IPD_GD mesdetaAccess = MESDataAccess.CreatePD_GD();
        private static readonly ISY_MATERIAL ISY_MATERIALdata = MESDataAccess.CreateSY_MATERIAL();
        private static readonly IMES_MM IMES_MMdata = MESDataAccess.CreateMES_MM();
        private static readonly ISY_GZZX ISY_GZZXdata = MESDataAccess.CreateSY_GZZX();
        private static readonly IMES_PLDH MES_SAPGDINFO = MESDataAccess.CreateMES_PLDH();
        private static readonly ISY_SYSCS ISY_SYSCSdata = MESDataAccess.CreateISY_SYSCS();
        SY_YERACOUNT SY_YERACOUNTservice = new SY_YERACOUNT();
        public MES_RETURN INSERT(MES_PD_GD model, string YEAR)
        {
            MES_RETURN rst = new MES_RETURN();
            MES_SY_YERACOUNT sy_yearcount = new MES_SY_YERACOUNT();
            sy_yearcount.GC = model.GC;
            sy_yearcount.TMLB = 2;
            sy_yearcount.TMYEAR = YEAR;
            model.GDDH = SY_YERACOUNTservice.SELECT(sy_yearcount);
            rst = mesdetaAccess.INSERT(model);
            if (rst.TYPE == "S")
            {
                rst.BH = model.GDDH;
            }
            return rst;
        }
        public MES_RETURN INSERT_OLD(MES_PD_GD model, string YEAR)
        {
            MES_RETURN rst = new MES_RETURN();
            MES_SY_YERACOUNT sy_yearcount = new MES_SY_YERACOUNT();
            sy_yearcount.GC = model.GC;
            sy_yearcount.TMLB = 2;
            sy_yearcount.TMYEAR = YEAR;
            model.GDDH = SY_YERACOUNTservice.SELECT(sy_yearcount);
            rst = mesdetaAccess.INSERT(model);
            if (rst.TYPE == "S")
            {
                rst.BH = model.GDDH;
            }
            return rst;
        }

        public SELECT_MES_PD_GD SELECT(MES_PD_GD model)
        {
            return mesdetaAccess.SELECT(model);
        }

        public MES_RETURN INSERT_FROM_SAP_GD(List<ZSL_BCST024_PO> model, string YEAR)
        {
            MES_RETURN mr = new MES_RETURN();
            for (int i = 0; i < model.Count; i++)
            {
                MES_RETURN mr1 = new MES_RETURN();
                mr1 = SELECT_ERPNO_COUNT(model[i].WERKS, model[i].AUFNR);
                MES_PD_GD model_MES_PD_GD = new MES_PD_GD();
                model_MES_PD_GD.GDLB = 1;
                model_MES_PD_GD.GC = model[i].WERKS;
                model_MES_PD_GD.GZZXBH = model[i].ARBPL;
                model_MES_PD_GD.WLH = model[i].MATNR;
                model_MES_PD_GD.WLMS = model[i].MAKTX;
                model_MES_PD_GD.KSDATE = model[i].GSTRP;
                model_MES_PD_GD.JSDATE = model[i].GLTRP;
                model_MES_PD_GD.ISACTION = 1;
                model_MES_PD_GD.SL = Convert.ToDecimal(model[i].PSMNG);
                model_MES_PD_GD.UNITSNAME = model[i].AMEIN;
                model_MES_PD_GD.ERPNO = model[i].AUFNR;
                model_MES_PD_GD.WLGROUP = model[i].MATKL;
                model_MES_PD_GD.WLLBNAME = model[i].WLDL;
                model_MES_PD_GD.DCXHNAME = model[i].DCXH;
                model_MES_PD_GD.DCDJNAME = model[i].DCDJ;
                model_MES_PD_GD.XSNOBILL = model[i].KDAUF;
                model_MES_PD_GD.XSNOBILLMX = model[i].KDPOS;
                model_MES_PD_GD.CHARG = model[i].CHARG;
                model_MES_PD_GD.VDATU = model[i].VDATU;
                model_MES_PD_GD.JLR = model[i].JRL;

                if (mr1.TID == 0 && model[i].DEL != "X")
                {
                    mr1 = INSERT(model_MES_PD_GD, YEAR);
                    mr.TYPE = mr1.TYPE;
                    mr.MESSAGE = mr1.MESSAGE;
                    mr.BH = mr1.BH;
                }
                else if (mr1.TID > 0 && model[i].DEL == "X")
                {
                    model_MES_PD_GD = new MES_PD_GD();
                    model_MES_PD_GD.GC = model[i].WERKS;
                    model_MES_PD_GD.ERPNO = model[i].AUFNR;
                    DELETE(model_MES_PD_GD);
                }
                else if (mr1.TID > 0 && model[i].DEL != "X")
                {
                    model_MES_PD_GD.GDDH = mr1.BH;
                    model_MES_PD_GD.ISOPEN = mr1.XH;
                    UPDATE_ALL(model_MES_PD_GD);
                }
            }
            if (mr.TYPE != "E")
            {
                mr.TYPE = "S";
            }
            return mr;
        }

        public MES_RETURN UPDATE(MES_PD_GD model)
        {
            return mesdetaAccess.UPDATE(model);
        }

        public MES_RETURN UPDATE_ALL(MES_PD_GD model)
        {
            return mesdetaAccess.UPDATE_ALL(model);
        }

        public MES_RETURN DELETE(MES_PD_GD model)
        {
            return mesdetaAccess.DELETE(model);
        }

        public MES_RETURN DELETE_ALL(MES_PD_GD model)
        {
            return mesdetaAccess.DELETE_ALL(model);
        }

        public MES_RETURN SELECT_ERPNO_COUNT(string GC, string ERPNO)
        {
            return mesdetaAccess.SELECT_ERPNO_COUNT(GC, ERPNO);
        }

        public MES_RETURN INSERT_BY_MES(MES_PD_GD model)
        {
            MES_RETURN rst = new MES_RETURN();
            MES_SY_MATERIAL model_MES_SY_MATERIAL = new MES_SY_MATERIAL();
            model_MES_SY_MATERIAL.GC = model.GC;
            model_MES_SY_MATERIAL.WLH = model.WLH;
            MES_SY_MATERIAL_SELECT rst_MES_SY_MATERIAL_SELECT = ISY_MATERIALdata.SELECT(model_MES_SY_MATERIAL);
            if (rst_MES_SY_MATERIAL_SELECT.MES_RETURN.TYPE == "S")
            {
                if (rst_MES_SY_MATERIAL_SELECT.MES_SY_MATERIAL.Count > 0)
                {
                    //model.GDLB = 2;
                    model.WLMS = rst_MES_SY_MATERIAL_SELECT.MES_SY_MATERIAL[0].WLMS;
                    model.ISACTION = 1;
                    model.UNITSID = rst_MES_SY_MATERIAL_SELECT.MES_SY_MATERIAL[0].UNITSID;
                    model.ERPNO = "";
                    model.WLGROUP = rst_MES_SY_MATERIAL_SELECT.MES_SY_MATERIAL[0].WLGROUP;
                    model.WLLB = rst_MES_SY_MATERIAL_SELECT.MES_SY_MATERIAL[0].WLLB;
                    model.DCXH = rst_MES_SY_MATERIAL_SELECT.MES_SY_MATERIAL[0].DCXH;
                    model.DCDJ = rst_MES_SY_MATERIAL_SELECT.MES_SY_MATERIAL[0].DCDJ;
                    model.XSNOBILL = "";
                    model.XSNOBILLMX = "";
                    rst = INSERT(model, "");
                }
                else
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "没有找到物料信息！";
                }
            }
            else
            {
                return rst_MES_SY_MATERIAL_SELECT.MES_RETURN;
            }
            return rst;
        }
        public MES_RETURN INSERT_BY_MES_OLD(MES_PD_GD model, string YEAR)
        {
            MES_RETURN rst = new MES_RETURN();
            MES_SY_MATERIAL model_MES_SY_MATERIAL = new MES_SY_MATERIAL();
            model_MES_SY_MATERIAL.GC = model.GC;
            model_MES_SY_MATERIAL.WLH = model.WLH;
            MES_SY_MATERIAL_SELECT rst_MES_SY_MATERIAL_SELECT = ISY_MATERIALdata.SELECT(model_MES_SY_MATERIAL);
            if (rst_MES_SY_MATERIAL_SELECT.MES_RETURN.TYPE == "S")
            {
                if (rst_MES_SY_MATERIAL_SELECT.MES_SY_MATERIAL.Count > 0)
                {
                    //model.GDLB = 2;
                    model.WLMS = rst_MES_SY_MATERIAL_SELECT.MES_SY_MATERIAL[0].WLMS;
                    model.ISACTION = 1;
                    model.UNITSID = rst_MES_SY_MATERIAL_SELECT.MES_SY_MATERIAL[0].UNITSID;
                    model.ERPNO = "";
                    model.WLGROUP = rst_MES_SY_MATERIAL_SELECT.MES_SY_MATERIAL[0].WLGROUP;
                    model.WLLB = rst_MES_SY_MATERIAL_SELECT.MES_SY_MATERIAL[0].WLLB;
                    model.DCXH = rst_MES_SY_MATERIAL_SELECT.MES_SY_MATERIAL[0].DCXH;
                    model.DCDJ = rst_MES_SY_MATERIAL_SELECT.MES_SY_MATERIAL[0].DCDJ;
                    model.XSNOBILL = "";
                    model.XSNOBILLMX = "";
                    rst = INSERT_OLD(model, YEAR);
                }
                else
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "没有找到物料信息！";
                }
            }
            else
            {
                return rst_MES_SY_MATERIAL_SELECT.MES_RETURN;
            }
            return rst;
        }

        public MES_RETURN INSERT_BY_SAPGDLIST(string IV_WERKS, string IV_GZZX, string IV_AUFNR, string LOW, string HIGH, int JRL)
        {
            MES_RETURN rst = new MES_RETURN();

            ZBCFUN_GDLIST_READ rst_ZBCFUN_GDLIST_READ_ALL = new ZBCFUN_GDLIST_READ();
            List<ZSL_BCST024_PO> ET_POLIST = new List<ZSL_BCST024_PO>();
            List<ZSL_BCS302_B> ET_BOM = new List<ZSL_BCS302_B>();
            List<ZSL_BCST302_R> ET_RT = new List<ZSL_BCST302_R>();
            if (IV_GZZX == "")
            {
                MES_SY_GZZX model_MES_SY_GZZX = new MES_SY_GZZX();
                model_MES_SY_GZZX.GC = IV_WERKS;
                model_MES_SY_GZZX.STAFFID = JRL;
                List<MES_SY_GZZX> rst_MES_SY_GZZX = ISY_GZZXdata.SELECT_BY_ROLE(model_MES_SY_GZZX).ToList();
                for (int i = 0; i < rst_MES_SY_GZZX.Count; i++)
                {

                    IV_GZZX = rst_MES_SY_GZZX[i].GZZXBH;
                    string mes_werks_pdly = ISY_SYSCSdata.SELECT("MES_" + IV_WERKS + "_GDLY");
                    ZBCFUN_GDLIST_READ rst_ZBCFUN_GDLIST_READ = new ZBCFUN_GDLIST_READ();
                    if (mes_werks_pdly == "0")
                    {
                        LOW = LOW.Replace("-", "");
                        HIGH = HIGH.Replace("-", "");
                        rst_ZBCFUN_GDLIST_READ = IMES_MMdata.GET_GDLIST(IV_WERKS, IV_GZZX, "", IV_AUFNR, LOW, HIGH);
                    }
                    else if (mes_werks_pdly == "1")
                    {
                        rst_ZBCFUN_GDLIST_READ = GET_GDLIST_NEW1(IV_WERKS, IV_GZZX, "", IV_AUFNR, LOW, HIGH);
                    }

                    if (rst_ZBCFUN_GDLIST_READ.MES_RETURN.TYPE != "S")
                    {
                        return rst_ZBCFUN_GDLIST_READ.MES_RETURN;
                    }
                    else
                    {
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
                    }
                }
            }
            else
            {
                string mes_werks_pdly = ISY_SYSCSdata.SELECT("MES_" + IV_WERKS + "_GDLY");
                if (mes_werks_pdly == "0")
                {
                    LOW = LOW.Replace("-", "");
                    HIGH = HIGH.Replace("-", "");
                    rst_ZBCFUN_GDLIST_READ_ALL = IMES_MMdata.GET_GDLIST(IV_WERKS, IV_GZZX, "", IV_AUFNR, LOW, HIGH);
                }
                else
                {
                    rst_ZBCFUN_GDLIST_READ_ALL = GET_GDLIST_NEW1(IV_WERKS, IV_GZZX, "", IV_AUFNR, LOW, HIGH);
                }

                if (rst_ZBCFUN_GDLIST_READ_ALL.MES_RETURN.TYPE != "S")
                {
                    return rst_ZBCFUN_GDLIST_READ_ALL.MES_RETURN;
                }
                else
                {
                    ET_POLIST = rst_ZBCFUN_GDLIST_READ_ALL.ET_POLIST;
                    ET_BOM = rst_ZBCFUN_GDLIST_READ_ALL.ET_BOM;
                    ET_RT = rst_ZBCFUN_GDLIST_READ_ALL.ET_RT;
                }
            }
            if (ET_POLIST.Count > 0)
            {
                for (int i = 0; i < ET_POLIST.Count; i++)
                {
                    ET_POLIST[i].JRL = JRL;
                }
                rst = INSERT_FROM_SAP_GD(ET_POLIST, "");
                mesdetaAccess.INSERT_GD_SYNC(ET_POLIST);
                rst.TYPE = "S";
            }
            else
            {
                rst.TYPE = "E";
                rst.MESSAGE = "无同步数据！";
            }
            if (ET_BOM.Count > 0)
            {
                for (int a = 0; a < ET_BOM.Count; a++)
                {
                    mesdetaAccess.BOM_SYNC_INSERT(ET_BOM[a]);
                }
            }
            if (ET_RT.Count > 0)
            {
                mesdetaAccess.INSERT_GD_GYLX_SYNC(ET_RT);
            }
            return rst;
        }
        public MES_RETURN INSERT_BY_SAPGDLIST_1(string IV_WERKS, string IV_GZZX, string LOW, string HIGH, int JRL, string IV_AUFNR, string YEAR)
        {
            MES_RETURN rst = new MES_RETURN();
            LOW = LOW.Replace("-", "");
            HIGH = HIGH.Replace("-", "");
            ZBCFUN_GDLIST_READ rst_ZBCFUN_GDLIST_READ_ALL = new ZBCFUN_GDLIST_READ();
            List<ZSL_BCST024_PO> ET_POLIST = new List<ZSL_BCST024_PO>();
            if (IV_GZZX == "")
            {
                MES_SY_GZZX model_MES_SY_GZZX = new MES_SY_GZZX();
                model_MES_SY_GZZX.GC = IV_WERKS;
                model_MES_SY_GZZX.STAFFID = JRL;
                List<MES_SY_GZZX> rst_MES_SY_GZZX = ISY_GZZXdata.SELECT_BY_ROLE(model_MES_SY_GZZX).ToList();
                for (int i = 0; i < rst_MES_SY_GZZX.Count; i++)
                {
                    IV_GZZX = rst_MES_SY_GZZX[i].GZZXBH;
                    ZBCFUN_GDLIST_READ rst_ZBCFUN_GDLIST_READ = IMES_MMdata.GET_GDLIST_1(IV_WERKS, IV_GZZX, "", IV_AUFNR, LOW, HIGH);
                    if (rst_ZBCFUN_GDLIST_READ.MES_RETURN.TYPE != "S")
                    {
                        return rst_ZBCFUN_GDLIST_READ.MES_RETURN;
                    }
                    else
                    {
                        for (int j = 0; j < rst_ZBCFUN_GDLIST_READ.ET_POLIST.Count; j++)
                        {
                            ET_POLIST.Add(rst_ZBCFUN_GDLIST_READ.ET_POLIST[j]);
                        }
                    }
                }
            }
            else
            {
                rst_ZBCFUN_GDLIST_READ_ALL = IMES_MMdata.GET_GDLIST_1(IV_WERKS, IV_GZZX, "", IV_AUFNR, LOW, HIGH);
                if (rst_ZBCFUN_GDLIST_READ_ALL.MES_RETURN.TYPE != "S")
                {
                    return rst_ZBCFUN_GDLIST_READ_ALL.MES_RETURN;
                }
                else
                {
                    ET_POLIST = rst_ZBCFUN_GDLIST_READ_ALL.ET_POLIST;
                }
            }
            if (ET_POLIST.Count > 0)
            {
                for (int i = 0; i < ET_POLIST.Count; i++)
                {
                    ET_POLIST[i].JRL = JRL;
                }
                rst = INSERT_FROM_SAP_GD(ET_POLIST, YEAR);
                rst.TYPE = "S";
            }
            else
            {
                rst.TYPE = "E";
                rst.MESSAGE = "无同步数据！";
            }
            return rst;
        }
        public SELECT_MES_PD_GD SELECT_BY_PFDH(MES_PD_GD_SELECT_BY_PFDH model)
        {
            return mesdetaAccess.SELECT_BY_PFDH(model);
        }
        public SELECT_MES_PD_GD SELECT_BY_STAFFID(MES_PD_GD model)
        {
            return mesdetaAccess.SELECT_BY_STAFFID(model);
        }
        public MES_PD_GD_GDJD_SELECT SELECT_GDJD(MES_PD_GD_GDJD_IMPORT model)
        {
            if (model.ISGD == 1)
            {
                List<ZSL_BCST024_PO> nodes = new List<ZSL_BCST024_PO>();
                MES_PD_GD_GDJD_SELECT rst = mesdetaAccess.SELECT_GDJD(model);
                if (rst.MES_RETURN.TYPE.Equals("E"))
                {
                    return rst;
                }
                else
                {
                    List<MES_PD_GD_GDJD_EXPORT> exportList = rst.MES_PD_GD_GDJD_EXPORT;
                    for (int i = 0; i < exportList.Count; i++)
                    {
                        ZSL_BCST024_PO node = new ZSL_BCST024_PO();
                        node.TMSL = exportList[i].FINISHCOUNT.ToString();
                        node.AUFNR = exportList[i].ERPNO;
                        nodes.Add(node);
                    }
                    rst.ZBCFUN_GDRKS_READ = MES_SAPGDINFO.GET_GDINFO(nodes);
                    return rst;
                }

            }
            else
            {
                return mesdetaAccess.SELECT_GDJD(model);
            }

        }
        public SELECT_MES_PD_GD SELECT_BY_ERPNO_SYNC(MES_PD_GD model)
        {
            MES_RETURN rst_MES_RETURN = new MES_RETURN();
            SELECT_MES_PD_GD rst_SELECT_MES_PD_GD = mesdetaAccess.SELECT(model);
            if (rst_SELECT_MES_PD_GD.MES_RETURN.TYPE == "S")
            {
                if (rst_SELECT_MES_PD_GD.MES_PD_GD_LIST.Count > 0)
                {
                    return rst_SELECT_MES_PD_GD;
                }
                else
                {
                    //ZBCFUN_GDJGXX_READ rst_ZBCFUN_GDJGXX_READ = IMES_MMdata.get_GDJGXX(model.ERPNO);
                    ZBCFUN_GDJGXX_READ rst_ZBCFUN_GDJGXX_READ = GET_GDJGXX_NEW1(model.GC, model.ERPNO);
                    if (rst_ZBCFUN_GDJGXX_READ.MES_RETURN.TYPE == "S")
                    {
                        string zh = Newtonsoft.Json.JsonConvert.SerializeObject(rst_ZBCFUN_GDJGXX_READ.ES_HEADER);
                        ZSL_BCST024_PO model_ZSL_BCST024_PO = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_BCST024_PO>(zh);
                        model_ZSL_BCST024_PO.JRL = model.JLR;
                        List<ZSL_BCST024_PO> model_ZSL_BCST024_PO_list = new List<ZSL_BCST024_PO>();
                        model_ZSL_BCST024_PO_list.Add(model_ZSL_BCST024_PO);
                        rst_MES_RETURN = INSERT_FROM_SAP_GD(model_ZSL_BCST024_PO_list, "");
                        if (rst_MES_RETURN.TYPE == "S" && rst_MES_RETURN.BH != "")
                        {
                            MES_PD_GD model_MES_PD_GD = new MES_PD_GD();
                            model_MES_PD_GD.GDDH = rst_MES_RETURN.BH;
                            rst_SELECT_MES_PD_GD = SELECT(model_MES_PD_GD);
                            return rst_SELECT_MES_PD_GD;
                        }
                        else
                        {
                            rst_SELECT_MES_PD_GD.MES_RETURN = rst_MES_RETURN;
                            return rst_SELECT_MES_PD_GD;
                        }

                    }
                    else
                    {
                        rst_SELECT_MES_PD_GD.MES_RETURN = rst_ZBCFUN_GDJGXX_READ.MES_RETURN;
                        return rst_SELECT_MES_PD_GD;
                    }
                }
            }
            else
            {
                return rst_SELECT_MES_PD_GD;
            }
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
            MES_PD_GD_SYNC_SELECT rst_MES_PD_GD_SYNC_SELECT = mesdetaAccess.SELECT_GD_SYNC(model_MES_PD_GD_SYNC);
            if (rst_MES_PD_GD_SYNC_SELECT.MES_RETURN.TYPE != "S")
            {
                rst.MES_RETURN = rst_MES_PD_GD_SYNC_SELECT.MES_RETURN;
                return rst;
            }
            List<ZSL_BCST024_PO> model_ZSL_BCST024_POlist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ZSL_BCST024_PO>>(Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_PD_GD_SYNC_SELECT.DATALIST));
            rst.ET_POLIST = model_ZSL_BCST024_POlist;

            model_MES_PD_GD_SYNC.LB = 2;
            rst_MES_PD_GD_SYNC_SELECT = mesdetaAccess.SELECT_GD_SYNC(model_MES_PD_GD_SYNC);
            if (rst_MES_PD_GD_SYNC_SELECT.MES_RETURN.TYPE != "S")
            {
                rst.MES_RETURN = rst_MES_PD_GD_SYNC_SELECT.MES_RETURN;
                return rst;
            }
            List<ZSL_BCS302_B> model_ZSL_BCS302_B_LIST = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ZSL_BCS302_B>>(Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_PD_GD_SYNC_SELECT.DATALIST));
            rst.ET_BOM = model_ZSL_BCS302_B_LIST;

            model_MES_PD_GD_SYNC.LB = 3;
            rst_MES_PD_GD_SYNC_SELECT = mesdetaAccess.SELECT_GD_SYNC(model_MES_PD_GD_SYNC);
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
                rst = IMES_MMdata.get_GDJGXX(IV_AUFNR);
            }
            else if (mes_werks_pdly == "1")
            {
                MES_PD_GD_SYNC model_MES_PD_GD_SYNC = new MES_PD_GD_SYNC();
                model_MES_PD_GD_SYNC.WERKS = IV_WERKS;
                model_MES_PD_GD_SYNC.AUFNR = IV_AUFNR;
                model_MES_PD_GD_SYNC.LB = 1;
                MES_PD_GD_SYNC_SELECT rst_MES_PD_GD_SYNC_SELECT = mesdetaAccess.SELECT_GD_SYNC(model_MES_PD_GD_SYNC);
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
                rst_MES_PD_GD_SYNC_SELECT = mesdetaAccess.SELECT_GD_SYNC(model_MES_PD_GD_SYNC);
                if (rst_MES_PD_GD_SYNC_SELECT.MES_RETURN.TYPE != "S")
                {
                    rst.MES_RETURN = rst_MES_PD_GD_SYNC_SELECT.MES_RETURN;
                    return rst;
                }
                List<ET_BOM> model_ZSL_BCS302_B_LIST = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ET_BOM>>(Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_PD_GD_SYNC_SELECT.DATALIST));
                rst.ET_BOM = model_ZSL_BCS302_B_LIST;

                model_MES_PD_GD_SYNC.LB = 3;
                rst_MES_PD_GD_SYNC_SELECT = mesdetaAccess.SELECT_GD_SYNC(model_MES_PD_GD_SYNC);
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

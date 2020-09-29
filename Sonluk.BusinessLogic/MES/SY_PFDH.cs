using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class SY_PFDH
    {
        private static readonly ISY_PFDH mesdetaAccess = MESDataAccess.CreateSY_PFDH();
        private static readonly IMES_PLDH MES_PLDHdate = MESDataAccess.CreateMES_PLDH();
        private static readonly ISY_PLDH data_ISY_PLDH = MESDataAccess.CreateSY_PLDH();
        private static readonly IMES_MM data_IMES_MM = MESDataAccess.CreateMES_MM();
        private static readonly ISY_PFDH_WL data_ISY_PFDH_WL = MESDataAccess.CreateSY_PFDH_WL();
        private static readonly ISY_SYSCS ISY_SYSCSdata = MESDataAccess.CreateISY_SYSCS();
        private static readonly IPD_GD data_IPD_GD = MESDataAccess.CreatePD_GD();
        SY_GZZX_SBH SY_GZZX_SBHService = new SY_GZZX_SBH();
        MES_MM MES_MMService = new MES_MM();
        SY_TYPEMX SY_TYPEMXService = new SY_TYPEMX();
        SY_GZZX SY_GZZXService = new SY_GZZX();
        SY_MATERIAL_GROUP SY_MATERIAL_GROUPService = new SY_MATERIAL_GROUP();
        TM_TMINFO TM_TMINFOService = new TM_TMINFO();
        public MES_RETURN INSERT(MES_SY_PFDH model)
        {
            return mesdetaAccess.INSERT(model);
        }

        public int SELECT_COUNT(MES_SY_PFDH model)
        {
            return mesdetaAccess.SELECT_COUNT(model);
        }

        public MES_SY_PFDH_LIST GET_PFDH_ACTION_SAP(string GC)
        {
            MES_SY_PFDH_LIST rst = new MES_SY_PFDH_LIST();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            if (GC == "1000" || GC == "4000" || GC == "5000")
            {
                rst = MES_MMService.GET_PFDH_ACTION_SAP(GC);
            }
            else
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "没有对应数据！";
                rst.MES_RETURN = child_MES_RETURN;
            }
            return rst;
        }

        public MES_SY_PFDH_LIST SELECT(MES_SY_PFDH model)
        {
            return mesdetaAccess.SELECT(model);
        }

        public ZBCFUN_ZJLOT_PRT GET_ZJINFO_INIT(ZSL_BCT304_CT model, string IV_FCODE)
        {
            ZBCFUN_ZJLOT_PRT rst = new ZBCFUN_ZJLOT_PRT();
            //string IV_FCODE = "C01";
            MES_SY_GZZX_SBH model_MES_SY_GZZX_SBH = new MES_SY_GZZX_SBH();
            model_MES_SY_GZZX_SBH.SBBH = model.SBBH;
            List<MES_SY_GZZX_SBH> rst_MES_SY_GZZX_SBH = SY_GZZX_SBHService.SELECT(model_MES_SY_GZZX_SBH).ToList();
            if (rst_MES_SY_GZZX_SBH.Count == 1)
            {
                model.YYCH = rst_MES_SY_GZZX_SBH[0].SBMS.Substring(1, rst_MES_SY_GZZX_SBH[0].SBMS.Length - 1);
                if (model.YYCH.Length == 1)
                {
                    model.YYCH = "0" + model.YYCH;
                }
                model.WERKS = rst_MES_SY_GZZX_SBH[0].GC;
                model.ARBPL = rst_MES_SY_GZZX_SBH[0].GZZXBH;
                rst = GET_ZJINFO_NEW(model, IV_FCODE);
                //rst = MES_PLDHdate.GET_ZJINFO(model, IV_FCODE);
                //if (rst.MES_RETURN.TYPE == "S")
                //{
                //    //if (rst.ES_LOT.SCBZ.Trim() != "")
                //    //{
                //    //    MES_SY_TYPEMX model_MES_SY_TYPEMX = new MES_SY_TYPEMX();
                //    //    model_MES_SY_TYPEMX.GC = model.WERKS;
                //    //    model_MES_SY_TYPEMX.MXNAME = rst.ES_LOT.SCBZ.Trim();
                //    //    model_MES_SY_TYPEMX.TYPEID = 12;
                //    //    MES_RETURN rst_MES_RETURN = SY_TYPEMXService.SELECT_ZJDATE(model_MES_SY_TYPEMX);
                //    //    if (rst_MES_RETURN.TYPE == "S")
                //    //    {
                //    //        rst.ES_LOT.SCBZID = rst_MES_RETURN.TID;
                //    //    }
                //    //    else
                //    //    {
                //    //        rst.ES_LOT.SCBZID = 0;
                //    //    }
                //    //}
                //    //if (rst.ES_LOT.MTSL.Trim() != "")
                //    //{
                //    //    MES_SY_TYPEMX model_MES_SY_TYPEMX = new MES_SY_TYPEMX();
                //    //    model_MES_SY_TYPEMX.GC = model.WERKS;
                //    //    model_MES_SY_TYPEMX.MXNAME = rst.ES_LOT.MTSL.Trim();
                //    //    model_MES_SY_TYPEMX.TYPEID = 13;
                //    //    MES_RETURN rst_MES_RETURN = SY_TYPEMXService.SELECT_ZJDATE(model_MES_SY_TYPEMX);
                //    //    if (rst_MES_RETURN.TYPE == "S")
                //    //    {
                //    //        rst.ES_LOT.MTSLID = rst_MES_RETURN.TID;
                //    //    }
                //    //    else
                //    //    {
                //    //        rst.ES_LOT.MTSLID = 0;
                //    //    }
                //    //}
                //}
            }
            else
            {
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "设备号读取失败！";
                rst.MES_RETURN = child_MES_RETURN;
            }
            return rst;
        }

        public MES_RETURN ZJ_CC(ZSL_BCT304_CT model)
        {
            MES_RETURN rst = new MES_RETURN();
            if (model.SCBZID > 0)
            {
                MES_SY_TYPEMX model_MES_SY_TYPEMX = new MES_SY_TYPEMX();
                model_MES_SY_TYPEMX.ID = model.SCBZID;
                List<MES_SY_TYPEMXLIST> rst_MES_SY_TYPEMXLIST = SY_TYPEMXService.SELECT(model_MES_SY_TYPEMX).ToList();
                if (rst_MES_SY_TYPEMXLIST.Count == 1)
                {
                    model.SCBZ = rst_MES_SY_TYPEMXLIST[0].MXNAME;
                }
            }
            if (model.MTSLID > 0)
            {
                MES_SY_TYPEMX model_MES_SY_TYPEMX = new MES_SY_TYPEMX();
                model_MES_SY_TYPEMX.ID = model.MTSLID;
                List<MES_SY_TYPEMXLIST> rst_MES_SY_TYPEMXLIST = SY_TYPEMXService.SELECT(model_MES_SY_TYPEMX).ToList();
                if (rst_MES_SY_TYPEMXLIST.Count == 1)
                {
                    model.MTSL = rst_MES_SY_TYPEMXLIST[0].MXNAME;
                }
            }

            ZBCFUN_ZJLOT_PRT rst_ZBCFUN_ZJLOT_PRT = GET_ZJINFO_INIT(model, "C03");
            if (rst_ZBCFUN_ZJLOT_PRT.MES_RETURN.TYPE == "S")
            {
                MES_SY_GZZX_SBH model_MES_SY_GZZX_SBH = new MES_SY_GZZX_SBH();
                model_MES_SY_GZZX_SBH.SBBH = model.SBBH;
                List<MES_SY_GZZX_SBH> rst_MES_SY_GZZX_SBH = SY_GZZX_SBHService.SELECT(model_MES_SY_GZZX_SBH).ToList();

                MES_TM_TMINFO model_MES_TM_TMINFO = new MES_TM_TMINFO();
                model_MES_TM_TMINFO.GC = rst_MES_SY_GZZX_SBH[0].GC;
                model_MES_TM_TMINFO.TMLB = model.TMLB;
                model_MES_TM_TMINFO.TMSX = model.TMSX;
                model_MES_TM_TMINFO.SCDATE = "";
                model_MES_TM_TMINFO.BC = model.SCBZID;
                model_MES_TM_TMINFO.RWBH = "";
                model_MES_TM_TMINFO.WLLBNAME = model.WLLBNAME;
                model_MES_TM_TMINFO.JLR = model.JLR;
                model_MES_TM_TMINFO.CPZT = model.CPZT;
                model_MES_TM_TMINFO.SL = Convert.ToInt32(model.MTSL);
                model_MES_TM_TMINFO.REMARK = model.REMARK;
                model_MES_TM_TMINFO.SYSCX = rst_ZBCFUN_ZJLOT_PRT.ES_LOT.SYSCX;
                model_MES_TM_TMINFO.SYCPGG = rst_ZBCFUN_ZJLOT_PRT.ES_LOT.SYCPGG;
                model_MES_TM_TMINFO.GZZXBH = rst_MES_SY_GZZX_SBH[0].GZZXBH;
                model_MES_TM_TMINFO.SBBH = model.SBBH;

                ZBCFUN_GDJGXX_READ rst_ZBCFUN_GDJGXX_READ = MES_MMService.get_GDJGXX_BYGD(model.ERPNO, rst_MES_SY_GZZX_SBH[0].GC);
                model_MES_TM_TMINFO.WLH = rst_ZBCFUN_GDJGXX_READ.ES_HEADER.MATNR;
                model_MES_TM_TMINFO.WLMS = rst_ZBCFUN_GDJGXX_READ.ES_HEADER.MAKTX;
                model_MES_TM_TMINFO.WLLB = GET_TYPEMX(4, rst_ZBCFUN_GDJGXX_READ.ES_HEADER.WLDL);
                model_MES_TM_TMINFO.DCDJ = GET_TYPEMX(7, rst_ZBCFUN_GDJGXX_READ.ES_HEADER.DCDJ);
                model_MES_TM_TMINFO.DCXH = GET_TYPEMX(6, rst_ZBCFUN_GDJGXX_READ.ES_HEADER.DCXH);
                model_MES_TM_TMINFO.PFDH = model.PFDH;
                model_MES_TM_TMINFO.PLDH = model.PLDH;
                model_MES_TM_TMINFO.TH = model.TH;
                model_MES_TM_TMINFO.WLGROUP = rst_ZBCFUN_GDJGXX_READ.ES_HEADER.MATKL;
                model_MES_TM_TMINFO.THGG = model.THGG;
                model_MES_TM_TMINFO.ERPNO = model.ERPNO;
                model_MES_TM_TMINFO.UNITSNAME = rst_ZBCFUN_GDJGXX_READ.ES_HEADER.AMEIN;
                model_MES_TM_TMINFO.PC = rst_ZBCFUN_GDJGXX_READ.ES_HEADER.CHARG;
                model_MES_TM_TMINFO.MAC = model.MAC;
                if (model_MES_TM_TMINFO.PC == "" || model_MES_TM_TMINFO.PC == null)
                {
                    MES_SY_GZZX model_MES_SY_GZZX = new MES_SY_GZZX();
                    model_MES_SY_GZZX.GC = rst_MES_SY_GZZX_SBH[0].GC;
                    model_MES_SY_GZZX.GZZXBH = rst_MES_SY_GZZX_SBH[0].GZZXBH;
                    List<MES_SY_GZZX> rst_MES_SY_GZZX = SY_GZZXService.SELECT(model_MES_SY_GZZX).ToList();
                    if (rst_MES_SY_GZZX.Count == 1)
                    {
                        if (model_MES_TM_TMINFO.SCDATE == "")
                        {
                            model_MES_TM_TMINFO.SCDATE = DateTime.Now.ToString("yyyy-MM-dd");
                        }
                        model_MES_TM_TMINFO.PC = (model_MES_TM_TMINFO.SCDATE.Replace("-", "")).Substring(2, 6) + rst_MES_SY_GZZX[0].CX;
                    }
                }
                if (model_MES_TM_TMINFO.TH == 0)
                {
                    rst.TYPE = "S";
                }
                else
                {
                    rst = TM_TMINFOService.INSERT_ONLY(model_MES_TM_TMINFO);
                }

            }
            else
            {
                rst = rst_ZBCFUN_ZJLOT_PRT.MES_RETURN;
            }
            return rst;
        }


        public int GET_TYPEMX(int TYPEID, string MXNAME)
        {
            MES_SY_TYPEMX model_MES_SY_TYPEMX = new MES_SY_TYPEMX();
            model_MES_SY_TYPEMX.TYPEID = TYPEID;
            model_MES_SY_TYPEMX.MXNAME = MXNAME;
            List<MES_SY_TYPEMXLIST> rst_MES_SY_TYPEMXLIST = SY_TYPEMXService.SELECT(model_MES_SY_TYPEMX).ToList();
            if (rst_MES_SY_TYPEMXLIST.Count == 1)
            {
                return rst_MES_SY_TYPEMXLIST[0].ID;
            }
            else
            {
                return 0;
            }
        }

        public string GET_WLGROUP(string GC, string WLGROUPNAME)
        {
            MES_SY_MATERIAL_GROUP model = new MES_SY_MATERIAL_GROUP();
            model.GC = GC;
            model.WLGROUPNAME = WLGROUPNAME;
            MES_SY_MATERIAL_GROUP_SELECT rst = SY_MATERIAL_GROUPService.SELECT(model);
            if (rst.MES_SY_MATERIAL_GROUP.Count == 1)
            {
                return rst.MES_SY_MATERIAL_GROUP[0].WLGROUP;
            }
            else
            {
                return "";
            }
        }

        public MES_RETURN UPDATE(MES_SY_PFDH model)
        {
            return mesdetaAccess.UPDATE(model);
        }

        public MES_RETURN DELETE(MES_SY_PFDH model)
        {
            return mesdetaAccess.DELETE(model);
        }

        public ZBCFUN_ZJLOT_PRT GET_ZJINFO_NEW(ZSL_BCT304_CT model, string IV_FCODE)
        {
            ZBCFUN_ZJLOT_PRT rst = new ZBCFUN_ZJLOT_PRT();
            MES_RETURN model_MES_RETURN = new MES_RETURN();
            MES_SY_GZZX_SBH model_MES_SY_GZZX_SBH = new MES_SY_GZZX_SBH();
            model_MES_SY_GZZX_SBH.SBBH = model.SBBH;
            List<MES_SY_GZZX_SBH> rst_MES_SY_GZZX_SBH = SY_GZZX_SBHService.SELECT(model_MES_SY_GZZX_SBH).ToList();
            if (rst_MES_SY_GZZX_SBH.Count == 0)
            {
                model_MES_RETURN.TYPE = "E";
                model_MES_RETURN.MESSAGE = "车号数据异常";
                rst.MES_RETURN = model_MES_RETURN;
                return rst;
            }
            if (IV_FCODE == "C01")
            {
                MES_SY_PLDH_ZJINFO model_MES_SY_PLDH_ZJINFO = new MES_SY_PLDH_ZJINFO();
                model_MES_SY_PLDH_ZJINFO.LB = 1;
                model_MES_SY_PLDH_ZJINFO.GC = model.WERKS;
                model_MES_SY_PLDH_ZJINFO.SBBH = model.SBBH;
                MES_SY_PLDH_ZJINFO_SELECT rst_MES_SY_PLDH_ZJINFO = data_ISY_PLDH.SELECT_ZJINFO(model_MES_SY_PLDH_ZJINFO);
                if (rst_MES_SY_PLDH_ZJINFO.MES_RETURN.TYPE != "S")
                {
                    rst.MES_RETURN = rst_MES_SY_PLDH_ZJINFO.MES_RETURN;
                    return rst;
                }
                if (rst_MES_SY_PLDH_ZJINFO.MES_SY_PLDH_ZJINFO.Count == 0)
                {
                    model_MES_RETURN.TYPE = "E";
                    model_MES_RETURN.MESSAGE = "车号数据异常";
                    rst.MES_RETURN = model_MES_RETURN;
                    return rst;
                }
                ZSL_BCT304_LOT ES_LOT = new ZSL_BCT304_LOT();
                ES_LOT.YYCH = rst_MES_SY_PLDH_ZJINFO.MES_SY_PLDH_ZJINFO[0].SBMS.Substring(1, rst_MES_SY_PLDH_ZJINFO.MES_SY_PLDH_ZJINFO[0].SBMS.Length - 1).PadLeft(2, '0');
                ES_LOT.PFDH = rst_MES_SY_PLDH_ZJINFO.MES_SY_PLDH_ZJINFO[0].PFDH;
                ES_LOT.PLDH = rst_MES_SY_PLDH_ZJINFO.MES_SY_PLDH_ZJINFO[0].PLDH;
                ES_LOT.RQ = rst_MES_SY_PLDH_ZJINFO.MES_SY_PLDH_ZJINFO[0].SCDATE;
                ES_LOT.MTSLID = rst_MES_SY_PLDH_ZJINFO.MES_SY_PLDH_ZJINFO[0].SCSLID;
                ES_LOT.MTSL = rst_MES_SY_PLDH_ZJINFO.MES_SY_PLDH_ZJINFO[0].SCSLNAME;
                ES_LOT.SCBZID = rst_MES_SY_PLDH_ZJINFO.MES_SY_PLDH_ZJINFO[0].SCBZID;
                ES_LOT.SCBZ = rst_MES_SY_PLDH_ZJINFO.MES_SY_PLDH_ZJINFO[0].SCBZNAME;
                if (rst_MES_SY_PLDH_ZJINFO.MES_SY_PLDH_ZJINFO[0].SCDATE == DateTime.Now.ToString("yyyy-MM-dd"))
                {
                    ES_LOT.TH = rst_MES_SY_PLDH_ZJINFO.MES_SY_PLDH_ZJINFO[0].SCTH + 1;
                }
                else
                {
                    ES_LOT.TH = 1;
                }
                model_MES_SY_PLDH_ZJINFO.LB = 2;
                rst_MES_SY_PLDH_ZJINFO = data_ISY_PLDH.SELECT_ZJINFO(model_MES_SY_PLDH_ZJINFO);
                if (rst_MES_SY_PLDH_ZJINFO.MES_RETURN.TYPE != "S")
                {
                    rst.MES_RETURN = rst_MES_SY_PLDH_ZJINFO.MES_RETURN;
                    return rst;
                }
                if (rst_MES_SY_PLDH_ZJINFO.DATALIST.Rows.Count == 0)
                {
                    model_MES_RETURN.TYPE = "E";
                    model_MES_RETURN.MESSAGE = "车号数据异常";
                    rst.MES_RETURN = model_MES_RETURN;
                    return rst;
                }
                ES_LOT.TLJTS = Convert.ToInt32(rst_MES_SY_PLDH_ZJINFO.DATALIST.Rows[0][0].ToString());

                model_MES_SY_PLDH_ZJINFO.LB = 3;
                model_MES_SY_PLDH_ZJINFO.PFDH = ES_LOT.PFDH;
                rst_MES_SY_PLDH_ZJINFO = data_ISY_PLDH.SELECT_ZJINFO(model_MES_SY_PLDH_ZJINFO);
                if (rst_MES_SY_PLDH_ZJINFO.MES_RETURN.TYPE != "S")
                {
                    rst.MES_RETURN = rst_MES_SY_PLDH_ZJINFO.MES_RETURN;
                    return rst;
                }
                if (rst_MES_SY_PLDH_ZJINFO.DATALIST.Rows.Count == 0)
                {
                    model_MES_RETURN.TYPE = "E";
                    model_MES_RETURN.MESSAGE = "车号数据异常";
                    rst.MES_RETURN = model_MES_RETURN;
                    return rst;
                }
                ES_LOT.PFLJTS = Convert.ToInt32(rst_MES_SY_PLDH_ZJINFO.DATALIST.Rows[0][0].ToString());

                model_MES_SY_PLDH_ZJINFO.LB = 4;
                model_MES_SY_PLDH_ZJINFO.PLDH = ES_LOT.PLDH;
                rst_MES_SY_PLDH_ZJINFO = data_ISY_PLDH.SELECT_ZJINFO(model_MES_SY_PLDH_ZJINFO);
                if (rst_MES_SY_PLDH_ZJINFO.MES_RETURN.TYPE != "S")
                {
                    rst.MES_RETURN = rst_MES_SY_PLDH_ZJINFO.MES_RETURN;
                    return rst;
                }
                if (rst_MES_SY_PLDH_ZJINFO.DATALIST.Rows.Count == 0)
                {
                    model_MES_RETURN.TYPE = "E";
                    model_MES_RETURN.MESSAGE = "车号数据异常";
                    rst.MES_RETURN = model_MES_RETURN;
                    return rst;
                }
                ES_LOT.PLLJTS = Convert.ToInt32(rst_MES_SY_PLDH_ZJINFO.DATALIST.Rows[0][0].ToString());
                rst.ES_LOT = ES_LOT;

                List<ZSL_BCT304_LOT> ET_PLDH = new List<ZSL_BCT304_LOT>();
                model_MES_SY_PLDH_ZJINFO.LB = 5;
                rst_MES_SY_PLDH_ZJINFO = data_ISY_PLDH.SELECT_ZJINFO(model_MES_SY_PLDH_ZJINFO);
                if (rst_MES_SY_PLDH_ZJINFO.MES_RETURN.TYPE != "S")
                {
                    rst.MES_RETURN = rst_MES_SY_PLDH_ZJINFO.MES_RETURN;
                    return rst;
                }
                if (rst_MES_SY_PLDH_ZJINFO.DATALIST.Rows.Count > 0)
                {
                    for (int a = 0; a < rst_MES_SY_PLDH_ZJINFO.DATALIST.Rows.Count; a++)
                    {
                        ZSL_BCT304_LOT child_ZSL_BCT304_LOT = new ZSL_BCT304_LOT();
                        child_ZSL_BCT304_LOT.PLDH = rst_MES_SY_PLDH_ZJINFO.DATALIST.Rows[a]["PLDH"].ToString();
                        child_ZSL_BCT304_LOT.QYRQ = rst_MES_SY_PLDH_ZJINFO.DATALIST.Rows[a]["USERDATES"].ToString();
                        child_ZSL_BCT304_LOT.JSRQ = rst_MES_SY_PLDH_ZJINFO.DATALIST.Rows[a]["USERDATEE"].ToString();
                        child_ZSL_BCT304_LOT.PFDH = rst_MES_SY_PLDH_ZJINFO.DATALIST.Rows[a]["PFDH"].ToString();
                        child_ZSL_BCT304_LOT.YYCH = rst_MES_SY_PLDH_ZJINFO.DATALIST.Rows[a]["SBMS"].ToString().Substring(1, rst_MES_SY_PLDH_ZJINFO.DATALIST.Rows[a]["SBMS"].ToString().Length - 1).PadLeft(2, '0');
                        ET_PLDH.Add(child_ZSL_BCT304_LOT);
                    }
                }
                rst.ET_PLDH = ET_PLDH;
                if (rst_MES_SY_GZZX_SBH.Count == 1)
                {
                    MES_SY_PFDH_WL model_MES_SY_PFDH_WL = new MES_SY_PFDH_WL();
                    model_MES_SY_PFDH_WL.GC = model.WERKS;
                    model_MES_SY_PFDH_WL.PFDH = ES_LOT.PFDH;
                    model_MES_SY_PFDH_WL.PFLB = 364;
                    MES_SY_PFDH_WL_SELECT rst_MES_SY_PFDH_WL_SELECT = data_ISY_PFDH_WL.SELECT(model_MES_SY_PFDH_WL);
                    if (rst_MES_SY_PFDH_WL_SELECT.MES_RETURN.TYPE != "S")
                    {
                        rst.MES_RETURN = rst_MES_SY_PFDH_WL_SELECT.MES_RETURN;
                        return rst;
                    }
                    List<ZSL_BCST024_PO> ET_POLIST = new List<ZSL_BCST024_PO>();
                    if (rst_MES_SY_PFDH_WL_SELECT.MES_SY_PFDH_WL.Count == 0)
                    {
                        model_MES_RETURN.TYPE = "E";
                        model_MES_RETURN.MESSAGE = "配方单号物料关系缺失";
                        rst.MES_RETURN = model_MES_RETURN;
                        return rst;
                    }
                    else
                    {
                        ZBCFUN_GDLIST_READ rst_ZBCFUN_GDLIST_READ = new ZBCFUN_GDLIST_READ();
                        string mes_werks_pdly = ISY_SYSCSdata.SELECT("MES_" + model.WERKS + "_GDLY");
                        for (int b = 0; b < rst_MES_SY_PFDH_WL_SELECT.MES_SY_PFDH_WL.Count; b++)
                        {
                            if (mes_werks_pdly == "0")
                            {
                                rst_ZBCFUN_GDLIST_READ = data_IMES_MM.GET_GDLIST_IV_MATNR_NODELETE(model.WERKS, rst_MES_SY_GZZX_SBH[0].GZZXBH, "", "", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"), rst_MES_SY_PFDH_WL_SELECT.MES_SY_PFDH_WL[b].WLH);
                            }
                            else if (mes_werks_pdly == "1")
                            {
                                rst_ZBCFUN_GDLIST_READ = GET_GDLIST_NEW1(model.WERKS, rst_MES_SY_GZZX_SBH[0].GZZXBH, "", "", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"), rst_MES_SY_PFDH_WL_SELECT.MES_SY_PFDH_WL[b].WLH);
                            }
                            if (rst_ZBCFUN_GDLIST_READ.MES_RETURN.TYPE != "S")
                            {
                                rst.MES_RETURN = rst_ZBCFUN_GDLIST_READ.MES_RETURN;
                                return rst;
                            }
                            for (int a = 0; a < rst_ZBCFUN_GDLIST_READ.ET_POLIST.Count; a++)
                            {
                                ET_POLIST.Add(rst_ZBCFUN_GDLIST_READ.ET_POLIST[a]);
                            }
                        }
                    }
                    rst.ET_POLIST = ET_POLIST;
                }
                model_MES_RETURN.TYPE = "S";
                model_MES_RETURN.MESSAGE = "";
                rst.MES_RETURN = model_MES_RETURN;
            }
            else if (IV_FCODE == "C02")
            {
                if (model.SBBH == "")
                {
                    model_MES_RETURN.TYPE = "E";
                    model_MES_RETURN.MESSAGE = "车号数据不为空";
                    rst.MES_RETURN = model_MES_RETURN;
                    return rst;
                }
                if (model.PLDH == "")
                {
                    model_MES_RETURN.TYPE = "E";
                    model_MES_RETURN.MESSAGE = "配料单号不为空";
                    rst.MES_RETURN = model_MES_RETURN;
                    return rst;
                }
                if (model.PFDH == "")
                {
                    model_MES_RETURN.TYPE = "E";
                    model_MES_RETURN.MESSAGE = "配方单号不为空";
                    rst.MES_RETURN = model_MES_RETURN;
                    return rst;
                }
                ZSL_BCT304_LOT ES_LOT = new ZSL_BCT304_LOT();
                if (rst_MES_SY_GZZX_SBH.Count == 1)
                {
                    ES_LOT.YYCH = rst_MES_SY_GZZX_SBH[0].SBMS.Substring(1, rst_MES_SY_GZZX_SBH[0].SBMS.Length - 1).PadLeft(2, '0');
                }
                ES_LOT.PLDH = model.PLDH;
                ES_LOT.PFDH = model.PFDH;

                MES_SY_PLDH_ZJINFO model_MES_SY_PLDH_ZJINFO = new MES_SY_PLDH_ZJINFO();
                model_MES_SY_PLDH_ZJINFO.LB = 6;
                model_MES_SY_PLDH_ZJINFO.GC = model.WERKS;
                model_MES_SY_PLDH_ZJINFO.SBBH = model.SBBH;
                model_MES_SY_PLDH_ZJINFO.PFDH = model.PFDH;
                MES_SY_PLDH_ZJINFO_SELECT rst_MES_SY_PLDH_ZJINFO = data_ISY_PLDH.SELECT_ZJINFO(model_MES_SY_PLDH_ZJINFO);
                if (rst_MES_SY_PLDH_ZJINFO.MES_RETURN.TYPE != "S")
                {
                    rst.MES_RETURN = rst_MES_SY_PLDH_ZJINFO.MES_RETURN;
                    return rst;
                }
                if (rst_MES_SY_PLDH_ZJINFO.MES_SY_PLDH_ZJINFO.Count > 0)
                {
                    ES_LOT.MTSLID = rst_MES_SY_PLDH_ZJINFO.MES_SY_PLDH_ZJINFO[0].SCSLID;
                    ES_LOT.MTSL = rst_MES_SY_PLDH_ZJINFO.MES_SY_PLDH_ZJINFO[0].SCSLNAME;
                    ES_LOT.SCBZID = rst_MES_SY_PLDH_ZJINFO.MES_SY_PLDH_ZJINFO[0].SCBZID;
                    ES_LOT.SCBZ = rst_MES_SY_PLDH_ZJINFO.MES_SY_PLDH_ZJINFO[0].SCBZNAME;
                    ES_LOT.TH = rst_MES_SY_PLDH_ZJINFO.MES_SY_PLDH_ZJINFO[0].SCTH + 1;
                }
                else
                {
                    ES_LOT.TH = 1;
                }

                model_MES_SY_PLDH_ZJINFO.LB = 2;
                rst_MES_SY_PLDH_ZJINFO = data_ISY_PLDH.SELECT_ZJINFO(model_MES_SY_PLDH_ZJINFO);
                if (rst_MES_SY_PLDH_ZJINFO.MES_RETURN.TYPE != "S")
                {
                    rst.MES_RETURN = rst_MES_SY_PLDH_ZJINFO.MES_RETURN;
                    return rst;
                }
                if (rst_MES_SY_PLDH_ZJINFO.DATALIST.Rows.Count == 0)
                {
                    model_MES_RETURN.TYPE = "E";
                    model_MES_RETURN.MESSAGE = "车号数据异常";
                    rst.MES_RETURN = model_MES_RETURN;
                    return rst;
                }
                ES_LOT.TLJTS = Convert.ToInt32(rst_MES_SY_PLDH_ZJINFO.DATALIST.Rows[0][0].ToString());

                model_MES_SY_PLDH_ZJINFO.LB = 3;
                model_MES_SY_PLDH_ZJINFO.PFDH = ES_LOT.PFDH;
                rst_MES_SY_PLDH_ZJINFO = data_ISY_PLDH.SELECT_ZJINFO(model_MES_SY_PLDH_ZJINFO);
                if (rst_MES_SY_PLDH_ZJINFO.MES_RETURN.TYPE != "S")
                {
                    rst.MES_RETURN = rst_MES_SY_PLDH_ZJINFO.MES_RETURN;
                    return rst;
                }
                if (rst_MES_SY_PLDH_ZJINFO.DATALIST.Rows.Count == 0)
                {
                    model_MES_RETURN.TYPE = "E";
                    model_MES_RETURN.MESSAGE = "车号数据异常";
                    rst.MES_RETURN = model_MES_RETURN;
                    return rst;
                }
                ES_LOT.PFLJTS = Convert.ToInt32(rst_MES_SY_PLDH_ZJINFO.DATALIST.Rows[0][0].ToString());

                model_MES_SY_PLDH_ZJINFO.LB = 4;
                model_MES_SY_PLDH_ZJINFO.PLDH = ES_LOT.PLDH;
                rst_MES_SY_PLDH_ZJINFO = data_ISY_PLDH.SELECT_ZJINFO(model_MES_SY_PLDH_ZJINFO);
                if (rst_MES_SY_PLDH_ZJINFO.MES_RETURN.TYPE != "S")
                {
                    rst.MES_RETURN = rst_MES_SY_PLDH_ZJINFO.MES_RETURN;
                    return rst;
                }
                if (rst_MES_SY_PLDH_ZJINFO.DATALIST.Rows.Count == 0)
                {
                    model_MES_RETURN.TYPE = "E";
                    model_MES_RETURN.MESSAGE = "车号数据异常";
                    rst.MES_RETURN = model_MES_RETURN;
                    return rst;
                }
                ES_LOT.PLLJTS = Convert.ToInt32(rst_MES_SY_PLDH_ZJINFO.DATALIST.Rows[0][0].ToString());
                rst.ES_LOT = ES_LOT;

                List<ZSL_BCT304_LOT> ET_PLDH = new List<ZSL_BCT304_LOT>();
                model_MES_SY_PLDH_ZJINFO.LB = 5;
                rst_MES_SY_PLDH_ZJINFO = data_ISY_PLDH.SELECT_ZJINFO(model_MES_SY_PLDH_ZJINFO);
                if (rst_MES_SY_PLDH_ZJINFO.MES_RETURN.TYPE != "S")
                {
                    rst.MES_RETURN = rst_MES_SY_PLDH_ZJINFO.MES_RETURN;
                    return rst;
                }
                if (rst_MES_SY_PLDH_ZJINFO.DATALIST.Rows.Count > 0)
                {
                    for (int a = 0; a < rst_MES_SY_PLDH_ZJINFO.DATALIST.Rows.Count; a++)
                    {
                        ZSL_BCT304_LOT child_ZSL_BCT304_LOT = new ZSL_BCT304_LOT();
                        child_ZSL_BCT304_LOT.PLDH = rst_MES_SY_PLDH_ZJINFO.DATALIST.Rows[a]["PLDH"].ToString();
                        child_ZSL_BCT304_LOT.QYRQ = rst_MES_SY_PLDH_ZJINFO.DATALIST.Rows[a]["USERDATES"].ToString();
                        child_ZSL_BCT304_LOT.JSRQ = rst_MES_SY_PLDH_ZJINFO.DATALIST.Rows[a]["USERDATEE"].ToString();
                        child_ZSL_BCT304_LOT.PFDH = rst_MES_SY_PLDH_ZJINFO.DATALIST.Rows[a]["PFDH"].ToString();
                        child_ZSL_BCT304_LOT.YYCH = rst_MES_SY_PLDH_ZJINFO.DATALIST.Rows[a]["SBMS"].ToString().Substring(1, rst_MES_SY_PLDH_ZJINFO.DATALIST.Rows[a]["SBMS"].ToString().Length - 1).PadLeft(2, '0');
                        ET_PLDH.Add(child_ZSL_BCT304_LOT);
                    }
                }
                rst.ET_PLDH = ET_PLDH;
                if (rst_MES_SY_GZZX_SBH.Count == 1)
                {
                    MES_SY_PFDH_WL model_MES_SY_PFDH_WL = new MES_SY_PFDH_WL();
                    model_MES_SY_PFDH_WL.GC = model.WERKS;
                    model_MES_SY_PFDH_WL.PFDH = ES_LOT.PFDH;
                    model_MES_SY_PFDH_WL.PFLB = 364;
                    MES_SY_PFDH_WL_SELECT rst_MES_SY_PFDH_WL_SELECT = data_ISY_PFDH_WL.SELECT(model_MES_SY_PFDH_WL);
                    if (rst_MES_SY_PFDH_WL_SELECT.MES_RETURN.TYPE != "S")
                    {
                        rst.MES_RETURN = rst_MES_SY_PFDH_WL_SELECT.MES_RETURN;
                        return rst;
                    }
                    List<ZSL_BCST024_PO> ET_POLIST = new List<ZSL_BCST024_PO>();
                    if (rst_MES_SY_PFDH_WL_SELECT.MES_SY_PFDH_WL.Count == 0)
                    {
                        model_MES_RETURN.TYPE = "E";
                        model_MES_RETURN.MESSAGE = "配方单号物料关系缺失";
                        rst.MES_RETURN = model_MES_RETURN;
                        return rst;
                    }
                    else
                    {
                        ZBCFUN_GDLIST_READ rst_ZBCFUN_GDLIST_READ = new ZBCFUN_GDLIST_READ();
                        string mes_werks_pdly = ISY_SYSCSdata.SELECT("MES_" + model.WERKS + "_GDLY");
                        for (int b = 0; b < rst_MES_SY_PFDH_WL_SELECT.MES_SY_PFDH_WL.Count; b++)
                        {
                            if (mes_werks_pdly == "0")
                            {
                                rst_ZBCFUN_GDLIST_READ = data_IMES_MM.GET_GDLIST_IV_MATNR_NODELETE(model.WERKS, rst_MES_SY_GZZX_SBH[0].GZZXBH, "", "", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"), rst_MES_SY_PFDH_WL_SELECT.MES_SY_PFDH_WL[b].WLH);
                            }
                            else if (mes_werks_pdly == "1")
                            {
                                rst_ZBCFUN_GDLIST_READ = GET_GDLIST_NEW1(model.WERKS, rst_MES_SY_GZZX_SBH[0].GZZXBH, "", "", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"), rst_MES_SY_PFDH_WL_SELECT.MES_SY_PFDH_WL[b].WLH);
                            }

                            if (rst_ZBCFUN_GDLIST_READ.MES_RETURN.TYPE != "S")
                            {
                                rst.MES_RETURN = rst_ZBCFUN_GDLIST_READ.MES_RETURN;
                                return rst;
                            }
                            for (int a = 0; a < rst_ZBCFUN_GDLIST_READ.ET_POLIST.Count; a++)
                            {
                                ET_POLIST.Add(rst_ZBCFUN_GDLIST_READ.ET_POLIST[a]);
                            }
                        }
                    }
                    rst.ET_POLIST = ET_POLIST;
                }
                model_MES_RETURN.TYPE = "S";
                model_MES_RETURN.MESSAGE = "";
                rst.MES_RETURN = model_MES_RETURN;
            }
            else if (IV_FCODE == "C03")
            {
                if (model.SBBH == "")
                {
                    model_MES_RETURN.TYPE = "E";
                    model_MES_RETURN.MESSAGE = "车号数据不为空";
                    rst.MES_RETURN = model_MES_RETURN;
                    return rst;
                }
                if (model.PLDH == "")
                {
                    model_MES_RETURN.TYPE = "E";
                    model_MES_RETURN.MESSAGE = "配料单号不为空";
                    rst.MES_RETURN = model_MES_RETURN;
                    return rst;
                }
                if (model.PFDH == "")
                {
                    model_MES_RETURN.TYPE = "E";
                    model_MES_RETURN.MESSAGE = "配方单号不为空";
                    rst.MES_RETURN = model_MES_RETURN;
                    return rst;
                }
                if (model.SCBZID == 0)
                {
                    model_MES_RETURN.TYPE = "E";
                    model_MES_RETURN.MESSAGE = "生产班组不为空";
                    rst.MES_RETURN = model_MES_RETURN;
                    return rst;
                }
                if (model.MTSLID == 0)
                {
                    model_MES_RETURN.TYPE = "E";
                    model_MES_RETURN.MESSAGE = "数量不为空";
                    rst.MES_RETURN = model_MES_RETURN;
                    return rst;
                }
                if (model.WERKS == "")
                {
                    model_MES_RETURN.TYPE = "E";
                    model_MES_RETURN.MESSAGE = "工厂不为空";
                    rst.MES_RETURN = model_MES_RETURN;
                    return rst;
                }
                MES_SY_PLDH_ZJINFO model_MES_SY_PLDH_ZJINFO = new MES_SY_PLDH_ZJINFO();
                model_MES_SY_PLDH_ZJINFO.LB = 7;
                model_MES_SY_PLDH_ZJINFO.GC = rst_MES_SY_GZZX_SBH[0].GC;
                model_MES_SY_PLDH_ZJINFO.SBBH = model.SBBH;
                model_MES_SY_PLDH_ZJINFO.PFDH = model.PFDH;
                MES_SY_PLDH_ZJINFO_SELECT rst_MES_SY_PLDH_ZJINFO = data_ISY_PLDH.SELECT_ZJINFO(model_MES_SY_PLDH_ZJINFO);
                if (rst_MES_SY_PLDH_ZJINFO.MES_RETURN.TYPE != "S")
                {
                    rst.MES_RETURN = rst_MES_SY_PLDH_ZJINFO.MES_RETURN;
                    return rst;
                }
                if (Convert.ToInt32(rst_MES_SY_PLDH_ZJINFO.DATALIST.Rows[0][0].ToString()) == 0)
                {
                    model_MES_RETURN.TYPE = "E";
                    model_MES_RETURN.MESSAGE = "配方单号失效";
                    rst.MES_RETURN = model_MES_RETURN;
                    return rst;
                }
                model_MES_SY_PLDH_ZJINFO = new MES_SY_PLDH_ZJINFO();
                model_MES_SY_PLDH_ZJINFO.LB = 1;
                model_MES_SY_PLDH_ZJINFO.PLDH = model.PLDH;
                model_MES_SY_PLDH_ZJINFO.SBBH = model.SBBH;
                model_MES_SY_PLDH_ZJINFO.SCSLID = model.MTSLID;
                model_MES_SY_PLDH_ZJINFO.SCBZID = model.SCBZID;
                model_MES_SY_PLDH_ZJINFO.SCTH = model.TH;
                model_MES_SY_PLDH_ZJINFO.PFDH = model.PFDH;
                model_MES_RETURN = data_ISY_PLDH.UPDATE_ZJINFO(model_MES_SY_PLDH_ZJINFO);
                rst.MES_RETURN = model_MES_RETURN;

                ZSL_BCT304_LOT ES_LOT = new ZSL_BCT304_LOT();
                ES_LOT.SYCPGG = "";
                ES_LOT.SYSCX = "";
                rst.ES_LOT = ES_LOT;
            }
            return rst;
        }
        public ZBCFUN_GDLIST_READ GET_GDLIST_NEW1(string IV_WERKS, string IV_GZZX, string IV_WLDL, string IV_AUFNR, string LOW, string HIGH, string WLH)
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
            model_MES_PD_GD_SYNC.MATNR = WLH;
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
    }
}

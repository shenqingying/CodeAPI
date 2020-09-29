using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.Entities.QM;
using Sonluk.IDataAccess.MES;
using Sonluk.IDataAccess.QM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class BAT_REPORT
    {
        private static readonly IBAT_PACKAGE DA_BAT_PACKAGE = MESDataAccess.CreateBAT_PACKAGE();
        private static readonly IBAT_SPECS DA_BAT_SPECS = MESDataAccess.CreateBAT_SPECS();
        private static readonly IBAT_SPECS_PERFOR DA_BAT_SPECS_PERFOR = MESDataAccess.CreateBAT_SPECS_PERFOR();
        private static readonly IBAT_SPECS_SAMP DA_BAT_SPECS_SAMP = MESDataAccess.CreateBAT_SPECS_SAMP();
        private static readonly IBAT_REPORT DA_BAT_REPORT = MESDataAccess.CreateBAT_REPORT();
        private static readonly ISY_MATERIAL DA_SY_MATERIAL = MESDataAccess.CreateSY_MATERIAL();
        private static readonly IIngredient DA_Ingredient = QMDataAccess.CreateIngredient();

        private static readonly BAT_SPECS BL_BAT_SPECS = new BAT_SPECS();
        private static readonly BAT_PACKAGE BL_BAT_REPORT = new BAT_PACKAGE();

        public MES_BAT_REPORT SEARCH(MES_BAT_REPORT_SEARCH model, int STAFFID)
        {
            MES_BAT_REPORT rst = new MES_BAT_REPORT();
            rst.MES_RETURN = new MES_RETURN();
            rst.MES_RETURN.MESSAGE = "";

            //获取生产订单信息
            MES_PD_GD_PACKINFO_SEARCH search_MES_PD_GD_PACKINFO_SEARCH = new MES_PD_GD_PACKINFO_SEARCH();
            search_MES_PD_GD_PACKINFO_SEARCH.ERPNO = model.ERPNO;
            search_MES_PD_GD_PACKINFO_SEARCH.XSNOBILL = model.XSNOBILL;
            search_MES_PD_GD_PACKINFO_SEARCH.XSNOBILLMX = model.XSNOBILLMX;
            MES_PD_GD_PACKINFO_SELECT rst_MES_PD_GD_PACKINFO_SELECT = DA_BAT_PACKAGE.SELECT_ERPINFO(search_MES_PD_GD_PACKINFO_SEARCH, "成品");
            if (rst_MES_PD_GD_PACKINFO_SELECT.MES_RETURN.TYPE == "E")
            {
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = rst_MES_PD_GD_PACKINFO_SELECT.MES_RETURN.MESSAGE + "【未查询到生产订单信息】";
                return rst;
            }
            for (int i = 0; i < rst_MES_PD_GD_PACKINFO_SELECT.MES_PD_GD_PACKINFO.Count; i++)
            {
                if (!BL_BAT_REPORT.FTY_AUZ_Verify(rst_MES_PD_GD_PACKINFO_SELECT.MES_PD_GD_PACKINFO[i].GC, STAFFID))
                {
                    rst_MES_PD_GD_PACKINFO_SELECT.MES_PD_GD_PACKINFO.Remove(rst_MES_PD_GD_PACKINFO_SELECT.MES_PD_GD_PACKINFO[i]);
                }
            }
            if (rst_MES_PD_GD_PACKINFO_SELECT.MES_PD_GD_PACKINFO.Count != 1)
            {
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = "未查询到或查询到多个订单，请确认查询条件！";
                return rst;
            }
            rst.ERPNO = rst_MES_PD_GD_PACKINFO_SELECT.MES_PD_GD_PACKINFO[0].ERPNO;
            rst.XSNOBILL = rst_MES_PD_GD_PACKINFO_SELECT.MES_PD_GD_PACKINFO[0].XSNOBILL;
            rst.XSNOBILLMX = rst_MES_PD_GD_PACKINFO_SELECT.MES_PD_GD_PACKINFO[0].XSNOBILLMX;
            rst.WLH = rst_MES_PD_GD_PACKINFO_SELECT.MES_PD_GD_PACKINFO[0].WLH;
            rst.WLMS = rst_MES_PD_GD_PACKINFO_SELECT.MES_PD_GD_PACKINFO[0].WLMS;
            rst.GDDH = rst_MES_PD_GD_PACKINFO_SELECT.MES_PD_GD_PACKINFO[0].GDDH;
            rst.GC = rst_MES_PD_GD_PACKINFO_SELECT.MES_PD_GD_PACKINFO[0].GC;
            rst.COUNTZ = rst_MES_PD_GD_PACKINFO_SELECT.MES_PD_GD_PACKINFO[0].SL;
            rst.JSDATE = rst_MES_PD_GD_PACKINFO_SELECT.MES_PD_GD_PACKINFO[0].JSDATE;

            //获取生产线和电池信息
            SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM = new SELECT_MES_TM_TMINFO_BYTM();
            rst_SELECT_MES_TM_TMINFO_BYTM = DA_BAT_REPORT.SELECT_MES_TM_TMINFO(model.ERPNO, model.XSNOBILL, model.XSNOBILLMX);
            if (rst_SELECT_MES_TM_TMINFO_BYTM.MES_RETURN.TYPE == "E")
            {
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = rst_SELECT_MES_TM_TMINFO_BYTM.MES_RETURN.MESSAGE + "【未查询到生产线和电池信息】";
                return rst;
            }
            else
            {
                if (rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST.Count > 0)
                {
                    rst.SCX = rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0].GZZXMS;
                    rst.DATE = rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0].SCDATE;
                    rst.DCXH = rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0].DCXHMS;
                    rst.SDLX = rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0].DCDJMS;
                }
                else
                {
                    rst.MES_RETURN.TYPE = "E";
                    rst.MES_RETURN.MESSAGE = "未查询到电池信息，请确认查询条件！";
                    return rst;
                }
            }

            //获取日期唛
            IList<JSJYBBInfo> rst_JSJYBBInfo = DA_Ingredient.JSJYBBREAD(model.XSNOBILL,model.XSNOBILLMX);
            if (rst_JSJYBBInfo.Count > 0) rst.CODOWORD = rst_JSJYBBInfo[0].TDLINE;
            else rst.MES_RETURN.MESSAGE = rst.MES_RETURN.MESSAGE + "【未查询到日期唛信息】";

            //获取箱数
            MES_SY_MATERIAL_DW search_MES_SY_MATERIAL_DW = new MES_SY_MATERIAL_DW();
            search_MES_SY_MATERIAL_DW.WLH = rst.WLH;
            search_MES_SY_MATERIAL_DW.MEINH = "CTN";
            MES_SY_MATERIAL_DW_SELECT rst_MES_SY_MATERIAL_DW_SELECT = DA_SY_MATERIAL.DW_SELECT(search_MES_SY_MATERIAL_DW);
            string rst_MES_SY_MATERIAL_DW_SELECT_MESSAGE = "【未查询到每箱的数量信息】";
            if (rst_MES_SY_MATERIAL_DW_SELECT.MES_SY_MATERIAL_DW.Count > 0) 
            {
                for (int i = 0; i < rst_MES_SY_MATERIAL_DW_SELECT.MES_SY_MATERIAL_DW.Count; i++)
                {
                    if (rst_MES_SY_MATERIAL_DW_SELECT.MES_SY_MATERIAL_DW[i].UNITSNAME == "PCS")
                    {
                        if (rst_MES_SY_MATERIAL_DW_SELECT.MES_SY_MATERIAL_DW[0].UMREZ == 0) rst.COUNTX = "1";
                        else rst.COUNTX = Math.Ceiling(rst.COUNTZ / Convert.ToDouble(rst_MES_SY_MATERIAL_DW_SELECT.MES_SY_MATERIAL_DW[0].UMREZ)).ToString();
                        rst_MES_SY_MATERIAL_DW_SELECT_MESSAGE = "";
                        break;
                    }
                }
            }
            else rst.MES_RETURN.MESSAGE = rst.MES_RETURN.MESSAGE + "【未查询到箱数信息】";
            rst.MES_RETURN.MESSAGE = rst.MES_RETURN.MESSAGE + rst_MES_SY_MATERIAL_DW_SELECT_MESSAGE;

            //获取包装与外观信息
            //MES_PD_GD_PACKINFO rst_MES_PD_GD_PACKINFO = DA_BAT_PACKAGE.SELECT_SINGLE(rst.GDDH);
            //if (rst_MES_PD_GD_PACKINFO.MES_RETURN.TYPE == "E")
            //{
            //    rst.MES_RETURN = rst_MES_PD_GD_PACKINFO.MES_RETURN;
            //    return rst;
            //}
            //rst.COUNTX = rst_MES_PD_GD_PACKINFO.COUNTX;
            //rst.SNINFO = rst_MES_PD_GD_PACKINFO.SNINFO;
            //rst.CXS = rst_MES_PD_GD_PACKINFO.CXS;
            //rst.WG = rst_MES_PD_GD_PACKINFO.WG;
            //rst.CODOWORD = rst_MES_PD_GD_PACKINFO.CODOWORD;
            //rst.WORDSPACE = rst_MES_PD_GD_PACKINFO.WORDSPACE;
            //rst.KPRQM = rst_MES_PD_GD_PACKINFO.KPRQM;

            //获取电池规格信息
            MES_DCBZ search_MES_DCBZ = new MES_DCBZ();
            search_MES_DCBZ.DCXH = rst.DCXH;
            MES_DCBZ_SELECT rst_BAT_SPECS = BL_BAT_SPECS.SELECT_SPECS_FULL(search_MES_DCBZ);
            if (rst_BAT_SPECS.MES_RETURN.TYPE == "E")
            {
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = rst_BAT_SPECS.MES_RETURN.MESSAGE + "【未查询到电池规格信息】";
                return rst;
            }
            if (rst_BAT_SPECS.MES_DCBZ[0].MES_DCCCBZ.Count == 4)
            {
                rst.DCBZA = rst_BAT_SPECS.MES_DCBZ[0].MES_DCCCBZ[1].DCBZ;
                if (rst_BAT_SPECS.MES_DCBZ[0].MES_DCCCBZ[1].DCMIN == "") rst.DCMINA = "/";
                else rst.DCMINA = rst_BAT_SPECS.MES_DCBZ[0].MES_DCCCBZ[1].DCMIN;
                if (rst_BAT_SPECS.MES_DCBZ[0].MES_DCCCBZ[1].DCMAX == "") rst.DCMAXA = "/";
                else rst.DCMAXA = rst_BAT_SPECS.MES_DCBZ[0].MES_DCCCBZ[1].DCMAX;

                rst.DCBZB = rst_BAT_SPECS.MES_DCBZ[0].MES_DCCCBZ[2].DCBZ;
                if (rst_BAT_SPECS.MES_DCBZ[0].MES_DCCCBZ[2].DCMIN == "") rst.DCMINB = "/";
                else rst.DCMINB = rst_BAT_SPECS.MES_DCBZ[0].MES_DCCCBZ[2].DCMIN;
                if (rst_BAT_SPECS.MES_DCBZ[0].MES_DCCCBZ[2].DCMAX == "") rst.DCMAXB = "/";
                else rst.DCMAXB = rst_BAT_SPECS.MES_DCBZ[0].MES_DCCCBZ[2].DCMAX;

                rst.DCBZC = rst_BAT_SPECS.MES_DCBZ[0].MES_DCCCBZ[3].DCBZ;
                if (rst_BAT_SPECS.MES_DCBZ[0].MES_DCCCBZ[3].DCMIN == "") rst.DCMINC = "/";
                else rst.DCMINC = rst_BAT_SPECS.MES_DCBZ[0].MES_DCCCBZ[3].DCMIN;
                if (rst_BAT_SPECS.MES_DCBZ[0].MES_DCCCBZ[3].DCMAX == "") rst.DCMAXC = "/";
                else rst.DCMAXC = rst_BAT_SPECS.MES_DCBZ[0].MES_DCCCBZ[3].DCMAX;

                rst.DCBZK = rst_BAT_SPECS.MES_DCBZ[0].MES_DCCCBZ[0].DCBZ;
                if (rst_BAT_SPECS.MES_DCBZ[0].MES_DCCCBZ[0].DCMIN == "") rst.DCMINK = "/";
                else rst.DCMINK = rst_BAT_SPECS.MES_DCBZ[0].MES_DCCCBZ[0].DCMIN;
                if (rst_BAT_SPECS.MES_DCBZ[0].MES_DCCCBZ[0].DCMAX == "") rst.DCMAXK = "/";
                else rst.DCMAXK = rst_BAT_SPECS.MES_DCBZ[0].MES_DCCCBZ[0].DCMAX;

                for (int i = 0; i < rst_BAT_SPECS.MES_DCBZ[0].MES_DCDXN.Count; i++)
                {
                    if (rst_BAT_SPECS.MES_DCBZ[0].MES_DCDXN[i].SDLX == rst.SDLX)
                    {
                        rst.DCFDFS = rst_BAT_SPECS.MES_DCBZ[0].MES_DCDXN[i].DCFDFS;
                        rst.DCMAD = rst_BAT_SPECS.MES_DCBZ[0].MES_DCDXN[i].DCMAD;
                    }
                }
            }
            else
            {
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = "未查询到电池规格信息或电池信息错误，请排查原因（未录入电池信息，订单电池信息错误，网络错误）！";
                return rst;
            }

            //获取电池规格抽样信息
            double MAX = 0;
            double MIN = 0;
            int COUNT = 20;
            Random random = new Random();
            MES_DCCCCYSJ search_MES_DCCCCYSJ = new MES_DCCCCYSJ();
            MES_DCCCCYSJ_SELECT rst_MES_DCCCCYSJ = new MES_DCCCCYSJ_SELECT();

            search_MES_DCCCCYSJ.DCXH = rst.DCXH;
            search_MES_DCCCCYSJ.DCBZ = rst.DCBZA;
            rst_MES_DCCCCYSJ = DA_BAT_SPECS_SAMP.SELECT(search_MES_DCCCCYSJ);
            if (rst_MES_DCCCCYSJ.MES_DCCCCYSJ.Count > 0)
            {
                for (int i = 0; i < COUNT; i++)
                {
                    int j = random.Next(0, rst_MES_DCCCCYSJ.MES_DCCCCYSJ.Count);
                    if (i == 0)
                    {
                        MAX = Convert.ToDouble(rst_MES_DCCCCYSJ.MES_DCCCCYSJ[j].SZ);
                        MIN = Convert.ToDouble(rst_MES_DCCCCYSJ.MES_DCCCCYSJ[j].SZ);
                    }
                    if (Convert.ToDouble(rst_MES_DCCCCYSJ.MES_DCCCCYSJ[j].SZ) < MIN)
                    {
                        MIN = Convert.ToDouble(rst_MES_DCCCCYSJ.MES_DCCCCYSJ[j].SZ);
                    }
                    if (Convert.ToDouble(rst_MES_DCCCCYSJ.MES_DCCCCYSJ[j].SZ) > MAX)
                    {
                        MAX = Convert.ToDouble(rst_MES_DCCCCYSJ.MES_DCCCCYSJ[j].SZ);
                    }
                }
                rst.SZA = Convert.ToString(MIN) + "~" + Convert.ToString(MAX);
            }
            else rst.SZA = "/";

            search_MES_DCCCCYSJ.DCXH = rst.DCXH;
            search_MES_DCCCCYSJ.DCBZ = rst.DCBZB;
            rst_MES_DCCCCYSJ = DA_BAT_SPECS_SAMP.SELECT(search_MES_DCCCCYSJ);
            if (rst_MES_DCCCCYSJ.MES_DCCCCYSJ.Count > 0)
            {
                for (int i = 0; i < COUNT; i++)
                {
                    int j = random.Next(0, rst_MES_DCCCCYSJ.MES_DCCCCYSJ.Count);
                    if (i == 0)
                    {
                        MAX = Convert.ToDouble(rst_MES_DCCCCYSJ.MES_DCCCCYSJ[j].SZ);
                        MIN = Convert.ToDouble(rst_MES_DCCCCYSJ.MES_DCCCCYSJ[j].SZ);
                    }
                    if (Convert.ToDouble(rst_MES_DCCCCYSJ.MES_DCCCCYSJ[j].SZ) < MIN)
                    {
                        MIN = Convert.ToDouble(rst_MES_DCCCCYSJ.MES_DCCCCYSJ[j].SZ);
                    }
                    if (Convert.ToDouble(rst_MES_DCCCCYSJ.MES_DCCCCYSJ[j].SZ) > MAX)
                    {
                        MAX = Convert.ToDouble(rst_MES_DCCCCYSJ.MES_DCCCCYSJ[j].SZ);
                    }
                }
                rst.SZB = Convert.ToString(MIN) + "~" + Convert.ToString(MAX);
            }
            else rst.SZB = "/";

            search_MES_DCCCCYSJ.DCXH = rst.DCXH;
            search_MES_DCCCCYSJ.DCBZ = rst.DCBZC;
            rst_MES_DCCCCYSJ = DA_BAT_SPECS_SAMP.SELECT(search_MES_DCCCCYSJ);
            if (rst_MES_DCCCCYSJ.MES_DCCCCYSJ.Count > 0)
            {
                for (int i = 0; i < COUNT; i++)
                {
                    int j = random.Next(0, rst_MES_DCCCCYSJ.MES_DCCCCYSJ.Count);
                    if (i == 0)
                    {
                        MAX = Convert.ToDouble(rst_MES_DCCCCYSJ.MES_DCCCCYSJ[j].SZ);
                        MIN = Convert.ToDouble(rst_MES_DCCCCYSJ.MES_DCCCCYSJ[j].SZ);
                    }
                    if (Convert.ToDouble(rst_MES_DCCCCYSJ.MES_DCCCCYSJ[j].SZ) < MIN)
                    {
                        MIN = Convert.ToDouble(rst_MES_DCCCCYSJ.MES_DCCCCYSJ[j].SZ);
                    }
                    if (Convert.ToDouble(rst_MES_DCCCCYSJ.MES_DCCCCYSJ[j].SZ) > MAX)
                    {
                        MAX = Convert.ToDouble(rst_MES_DCCCCYSJ.MES_DCCCCYSJ[j].SZ);
                    }
                }
                rst.SZC = Convert.ToString(MIN) + "~" + Convert.ToString(MAX);
            }
            else rst.SZC = "/";

            search_MES_DCCCCYSJ.DCXH = rst.DCXH;
            search_MES_DCCCCYSJ.DCBZ = rst.DCBZK;
            rst_MES_DCCCCYSJ = DA_BAT_SPECS_SAMP.SELECT(search_MES_DCCCCYSJ);
            if (rst_MES_DCCCCYSJ.MES_DCCCCYSJ.Count > 0)
            {
                for (int i = 0; i < COUNT; i++)
                {
                    int j = random.Next(0, rst_MES_DCCCCYSJ.MES_DCCCCYSJ.Count);
                    if (i == 0)
                    {
                        MAX = Convert.ToDouble(rst_MES_DCCCCYSJ.MES_DCCCCYSJ[j].SZ);
                        MIN = Convert.ToDouble(rst_MES_DCCCCYSJ.MES_DCCCCYSJ[j].SZ);
                    }
                    if (Convert.ToDouble(rst_MES_DCCCCYSJ.MES_DCCCCYSJ[j].SZ) < MIN)
                    {
                        MIN = Convert.ToDouble(rst_MES_DCCCCYSJ.MES_DCCCCYSJ[j].SZ);
                    }
                    if (Convert.ToDouble(rst_MES_DCCCCYSJ.MES_DCCCCYSJ[j].SZ) > MAX)
                    {
                        MAX = Convert.ToDouble(rst_MES_DCCCCYSJ.MES_DCCCCYSJ[j].SZ);
                    }
                }
                rst.SZK = Convert.ToString(MIN) + "~" + Convert.ToString(MAX);
            }
            else rst.SZK = "/";

            //获取电性能抽样信息
            MES_DCDXNSZ_SEARCH search_MES_DCDXNSZ_SEARCH = new MES_DCDXNSZ_SEARCH();
            search_MES_DCDXNSZ_SEARCH.DCXH = rst.DCXH;
            search_MES_DCDXNSZ_SEARCH.SCX = rst.SCX;
            search_MES_DCDXNSZ_SEARCH.SDDJ = rst.SDLX;
            search_MES_DCDXNSZ_SEARCH.DATES = rst.DATE;
            MES_DCDXNSZ_SELECT rst_MES_DCDXNSZ_SELECT = DA_BAT_SPECS_PERFOR.SELECT(search_MES_DCDXNSZ_SEARCH);
            if (rst_MES_DCDXNSZ_SELECT.MES_DCDXNSZ.Count > 0)
            {
                rst.SZDXN = rst_MES_DCDXNSZ_SELECT.MES_DCDXNSZ[0].SZ;
            }
            else rst.SZDXN = "/";

            //获取抽样数信息
            MES_DCCYJYBZ rst_MES_DCCYJYBZ = new MES_DCCYJYBZ();

            rst_MES_DCCYJYBZ = DA_BAT_REPORT.SELECT_DCCYJYBZ_Parms(Convert.ToInt32(rst.COUNTX), "抽样包装");
            if (rst_MES_DCCYJYBZ.MES_RETURN.TYPE == "E")
            {
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = rst_MES_DCCYJYBZ.MES_RETURN.MESSAGE + "【未查询到抽样数信息（抽样包装）】";
                return rst;
            }
            else rst.PACKOPEN = rst_MES_DCCYJYBZ.JYSL;

            rst_MES_DCCYJYBZ = DA_BAT_REPORT.SELECT_DCCYJYBZ_Parms(rst.COUNTZ, "AQL=0.1%");
            if (rst_MES_DCCYJYBZ.MES_RETURN.TYPE == "E")
            {
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = rst_MES_DCCYJYBZ.MES_RETURN.MESSAGE + "【未查询到抽样数信息（抽样包装）】";
                return rst;
            }
            if (rst_MES_DCCYJYBZ.ZXJYS > rst.COUNTZ) rst.SAMP1 = rst.COUNTZ;
            else rst.SAMP1 = rst_MES_DCCYJYBZ.JYSL;

            rst_MES_DCCYJYBZ = DA_BAT_REPORT.SELECT_DCCYJYBZ_Parms(rst.COUNTZ, "AQL=0.25%");
            if (rst_MES_DCCYJYBZ.MES_RETURN.TYPE == "E")
            {
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = rst_MES_DCCYJYBZ.MES_RETURN.MESSAGE + "【未查询到抽样数信息（AQL=0.25%）】";
                return rst;
            }
            if (rst_MES_DCCYJYBZ.ZXJYS > rst.COUNTZ) rst.SAMP2 = rst.COUNTZ;
            else rst.SAMP2 = rst_MES_DCCYJYBZ.JYSL;

            rst_MES_DCCYJYBZ = DA_BAT_REPORT.SELECT_DCCYJYBZ_Parms(rst.COUNTZ, "AQL=0.25%");
            if (rst_MES_DCCYJYBZ.MES_RETURN.TYPE == "E")
            {
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = rst_MES_DCCYJYBZ.MES_RETURN.MESSAGE + "【未查询到抽样数信息（AQL=0.25%）】";
                return rst;
            }
            if (rst_MES_DCCYJYBZ.ZXJYS > rst.COUNTZ) rst.SAMP3 = rst.COUNTZ;
            else rst.SAMP3 = rst_MES_DCCYJYBZ.JYSL;

            rst_MES_DCCYJYBZ = DA_BAT_REPORT.SELECT_DCCYJYBZ_Parms(rst.COUNTZ, "AQL=2.5%");
            if (rst_MES_DCCYJYBZ.MES_RETURN.TYPE == "E")
            {
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = rst_MES_DCCYJYBZ.MES_RETURN.MESSAGE + "【未查询到抽样数信息（AQL=2.5%）】";
                return rst;
            }
            if (rst_MES_DCCYJYBZ.ZXJYS > rst.COUNTZ) rst.SAMP4 = rst.COUNTZ;
            else rst.SAMP4 = rst_MES_DCCYJYBZ.JYSL;

            //完成
            if (rst.MES_RETURN.MESSAGE == "") 
            {
                rst.MES_RETURN.TYPE = "S";
                rst.MES_RETURN.MESSAGE = "查询成功！";
            }
            else 
            {
                rst.MES_RETURN.TYPE = "W";
                rst.MES_RETURN.MESSAGE = "部分数据未查到：" + rst.MES_RETURN.MESSAGE; 
            }
            return rst;
        }
    }
}

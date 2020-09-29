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
    public class FB_QMP
    {
        private static readonly IFB_QMP data_FB_QMP = MESDataAccess.CreateIFB_QMP();
        private static readonly ISY_YERACOUNT data_ISY_YERACOUNT = MESDataAccess.CreateSY_YERACOUNT();
        private static readonly ITM_TMINFO data_ITM_TMINFO = MESDataAccess.CreateTM_TMINFO();
        private static readonly ITM_GL data_ITM_GL = MESDataAccess.CreateTM_GL();
        private static readonly ISY_EXCEPTION data_ISY_EXCEPTION = MESDataAccess.CreateISY_EXCEPTION();
        public MES_RETURN INSERT_ALL(DataSet ds)
        {
            MES_SY_CCGCRETRUN model_MES_SY_CCGCRETRUN = new MES_SY_CCGCRETRUN();
            model_MES_SY_CCGCRETRUN.LB = 6;
            model_MES_SY_CCGCRETRUN.CCGC = "WS_MES_FB_QMP_INSERT_ALL";
            model_MES_SY_CCGCRETRUN.TYPE = "S";
            model_MES_SY_CCGCRETRUN.MESSAGE = "SYNCSTART";
            data_ISY_EXCEPTION.INSERT_CCGC(model_MES_SY_CCGCRETRUN);

            MES_RETURN rst = new MES_RETURN();
            rst = data_FB_QMP.INSERT(ds.Tables[0], 1);
            if (rst.TYPE != "S")
            {
                return rst;
            }
            rst = data_FB_QMP.INSERT_D(ds.Tables[1]);
            if (rst.TYPE != "S")
            {
                return rst;
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                for (int a = 0; a < ds.Tables[2].Rows.Count; a++)
                {
                    MES_FB_QMP model_MES_FB_QMP = new MES_FB_QMP();
                    model_MES_FB_QMP.ExcelServerRCID = ds.Tables[2].Rows[a]["RtId"].ToString();
                    data_FB_QMP.UPDATE(model_MES_FB_QMP, 2);
                }
            }
            rst = data_FB_QMP.INSERT(ds.Tables[3], 2);
            if (rst.TYPE != "S")
            {
                return rst;
            }
            rst = data_FB_QMP.INSERT_D(ds.Tables[4]);
            if (rst.TYPE != "S")
            {
                return rst;
            }
            return rst;
        }

        public MES_RETURN SYNC_AUTO_CL()
        {
            MES_RETURN rst = new MES_RETURN();
            MES_FB_QMP model_MES_FB_QMP = new MES_FB_QMP();
            MES_FB_QMP_SELECT rst_MES_FB_QMP_SELECT = data_FB_QMP.SELECT(model_MES_FB_QMP, 1);
            if (rst_MES_FB_QMP_SELECT.MES_RETURN.TYPE != "S")
            {
                return rst_MES_FB_QMP_SELECT.MES_RETURN;
            }
            if (rst_MES_FB_QMP_SELECT.DATALIST.Rows.Count == 0)
            {
                rst.TYPE = "S";
                rst.MESSAGE = "无处理数据";
                return rst;
            }
            for (int a = 0; a < rst_MES_FB_QMP_SELECT.DATALIST.Rows.Count; a++)
            {
                string plot = rst_MES_FB_QMP_SELECT.DATALIST.Rows[a]["plot"].ToString();
                if (plot.Length > 0)
                {
                    string[] plotlist = plot.Split('/');
                    if (plotlist.Length > 0)
                    {
                        if (plotlist[0].Length == 8)
                        {
                            char[] ch = new char[plotlist[0].Length];
                            ch = plotlist[0].ToCharArray();
                            if (ch[0] >= 48 || ch[0] <= 57)
                            {
                                MES_FB_QMP_D model_MES_FB_QMP_D = new MES_FB_QMP_D();
                                model_MES_FB_QMP_D.ExcelServerRCID = rst_MES_FB_QMP_SELECT.DATALIST.Rows[a]["ExcelServerRCID"].ToString();
                                MES_FB_QMP_D_SELECT rst_MES_FB_QMP_D_SELECT = data_FB_QMP.SELECT_D(model_MES_FB_QMP_D, 1);
                                List<MES_TM_TMINFO> model_MES_TM_TMINFO_addLIST = new List<MES_TM_TMINFO>();
                                if (rst_MES_FB_QMP_D_SELECT.MES_RETURN.TYPE != "S")
                                {
                                    return rst_MES_FB_QMP_D_SELECT.MES_RETURN;
                                }
                                if (rst_MES_FB_QMP_D_SELECT.DATALIST.Rows.Count > 0)
                                {
                                    for (int b = 0; b < rst_MES_FB_QMP_D_SELECT.DATALIST.Rows.Count; b++)
                                    {
                                        if (rst_MES_FB_QMP_D_SELECT.DATALIST.Rows[b]["mid"].ToString().Trim() != "")
                                        {
                                            if (!string.IsNullOrEmpty(rst_MES_FB_QMP_D_SELECT.DATALIST.Rows[b]["mDate"].ToString().Trim()))
                                            {
                                                MES_TM_TMINFO model_MES_TM_TMINFO = new MES_TM_TMINFO();
                                                MES_SY_YERACOUNT model_MES_SY_YERACOUNT = new MES_SY_YERACOUNT();
                                                model_MES_SY_YERACOUNT.TMLB = 1;
                                                model_MES_SY_YERACOUNT.GC = "1000";
                                                model_MES_SY_YERACOUNT.TMYEAR = "";
                                                model_MES_TM_TMINFO.TM = data_ISY_YERACOUNT.SELECT(model_MES_SY_YERACOUNT);
                                                model_MES_TM_TMINFO.GC = "1000";
                                                model_MES_TM_TMINFO.TMLB = 1;
                                                model_MES_TM_TMINFO.TMSX = 378;
                                                try
                                                {
                                                    model_MES_TM_TMINFO.SCDATE = Convert.ToDateTime(rst_MES_FB_QMP_D_SELECT.DATALIST.Rows[b]["mDate"].ToString()).ToString("yyyy-MM-dd");
                                                }
                                                catch
                                                {
                                                }

                                                model_MES_TM_TMINFO.BC = 0;
                                                model_MES_TM_TMINFO.BCMS = "";
                                                model_MES_TM_TMINFO.GZZXBH = "Z3014";
                                                model_MES_TM_TMINFO.GZZXMS = "FBW";
                                                model_MES_TM_TMINFO.SBBH = "";
                                                model_MES_TM_TMINFO.SBHMS = rst_MES_FB_QMP_D_SELECT.DATALIST.Rows[b]["mCode"].ToString();
                                                model_MES_TM_TMINFO.RWBH = "";
                                                model_MES_TM_TMINFO.WLH = rst_MES_FB_QMP_D_SELECT.DATALIST.Rows[b]["mid"].ToString();
                                                model_MES_TM_TMINFO.WLMS = rst_MES_FB_QMP_D_SELECT.DATALIST.Rows[b]["mDesc"].ToString();
                                                model_MES_TM_TMINFO.PC = Convert.ToDateTime(rst_MES_FB_QMP_D_SELECT.DATALIST.Rows[b]["mDate"].ToString()).ToString("yyMMdd") + rst_MES_FB_QMP_D_SELECT.DATALIST.Rows[b]["mCode"].ToString();
                                                model_MES_TM_TMINFO.CPZT = 80;
                                                model_MES_TM_TMINFO.CPZTNAME = "合格";
                                                model_MES_TM_TMINFO.TH = 0;
                                                if (rst_MES_FB_QMP_D_SELECT.DATALIST.Rows[b]["幢号"].ToString().Trim() != "")
                                                {
                                                    try
                                                    {
                                                        model_MES_TM_TMINFO.TH = Convert.ToInt32(rst_MES_FB_QMP_D_SELECT.DATALIST.Rows[b]["幢号"].ToString().Trim().Split('-')[0]);
                                                    }
                                                    catch
                                                    {
                                                        model_MES_TM_TMINFO.TH = 0;
                                                    }
                                                }
                                                model_MES_TM_TMINFO.SL = Convert.ToDecimal(rst_MES_FB_QMP_D_SELECT.DATALIST.Rows[b]["mQTY"].ToString());
                                                if (rst_MES_FB_QMP_D_SELECT.DATALIST.Rows[b]["时间编码"].ToString() != "" && rst_MES_FB_QMP_D_SELECT.DATALIST.Rows[b]["时间编码"].ToString().Length == 9)
                                                {
                                                    try
                                                    {
                                                        Convert.ToInt32(rst_MES_FB_QMP_D_SELECT.DATALIST.Rows[b]["时间编码"].ToString());
                                                        if (Convert.ToInt32(rst_MES_FB_QMP_D_SELECT.DATALIST.Rows[b]["时间编码"].ToString().Substring(0, 2)) <= 24 && Convert.ToInt32(rst_MES_FB_QMP_D_SELECT.DATALIST.Rows[b]["时间编码"].ToString().Substring(2, 2)) < 60
                                                            && Convert.ToInt32(rst_MES_FB_QMP_D_SELECT.DATALIST.Rows[b]["时间编码"].ToString().Substring(5, 2)) < 24 && Convert.ToInt32(rst_MES_FB_QMP_D_SELECT.DATALIST.Rows[b]["时间编码"].ToString().Substring(7, 2)) < 60)
                                                        {
                                                            if (Convert.ToInt32(rst_MES_FB_QMP_D_SELECT.DATALIST.Rows[b]["时间编码"].ToString().Substring(0, 2)) == 24)
                                                            {
                                                                model_MES_TM_TMINFO.KSTIME = Convert.ToDateTime(rst_MES_FB_QMP_D_SELECT.DATALIST.Rows[b]["mDate"].ToString()).ToString("yyyy-MM-dd") + " 23:59:00.000";
                                                                model_MES_TM_TMINFO.JSTIME = Convert.ToDateTime(rst_MES_FB_QMP_D_SELECT.DATALIST.Rows[b]["mDate"].ToString()).ToString("yyyy-MM-dd") + " " + rst_MES_FB_QMP_D_SELECT.DATALIST.Rows[b]["时间编码"].ToString().Substring(5, 2) + ":" + rst_MES_FB_QMP_D_SELECT.DATALIST.Rows[b]["时间编码"].ToString().Substring(7, 2) + ":00.000";
                                                            }
                                                            else
                                                            {
                                                                model_MES_TM_TMINFO.KSTIME = Convert.ToDateTime(rst_MES_FB_QMP_D_SELECT.DATALIST.Rows[b]["mDate"].ToString()).ToString("yyyy-MM-dd") + " " + rst_MES_FB_QMP_D_SELECT.DATALIST.Rows[b]["时间编码"].ToString().Substring(0, 2) + ":" + rst_MES_FB_QMP_D_SELECT.DATALIST.Rows[b]["时间编码"].ToString().Substring(2, 2) + ":00.000";
                                                                model_MES_TM_TMINFO.JSTIME = Convert.ToDateTime(rst_MES_FB_QMP_D_SELECT.DATALIST.Rows[b]["mDate"].ToString()).ToString("yyyy-MM-dd") + " " + rst_MES_FB_QMP_D_SELECT.DATALIST.Rows[b]["时间编码"].ToString().Substring(5, 2) + ":" + rst_MES_FB_QMP_D_SELECT.DATALIST.Rows[b]["时间编码"].ToString().Substring(7, 2) + ":00.000";
                                                            }
                                                        }
                                                    }
                                                    catch (Exception)
                                                    {
                                                        model_MES_TM_TMINFO.KSTIME = "";
                                                        model_MES_TM_TMINFO.JSTIME = "";
                                                    }
                                                }
                                                else
                                                {
                                                    model_MES_TM_TMINFO.KSTIME = "";
                                                    model_MES_TM_TMINFO.JSTIME = "";
                                                }
                                                model_MES_TM_TMINFO.DCDJMS = rst_MES_FB_QMP_D_SELECT.DATALIST.Rows[b]["type"].ToString();
                                                model_MES_TM_TMINFO.NOBILL = plotlist[0];
                                                model_MES_TM_TMINFO.NOBILLMX = plotlist[1];
                                                model_MES_TM_TMINFO.WLLBNAME = "素电";
                                                model_MES_TM_TMINFO.REMARK = rst_MES_FB_QMP_D_SELECT.DATALIST.Rows[b]["mlot"].ToString() + rst_MES_FB_QMP_D_SELECT.DATALIST.Rows[b]["mRem"].ToString();
                                                rst = data_ITM_TMINFO.INSERT_FB(model_MES_TM_TMINFO);
                                                if (rst.TYPE != "S")
                                                {
                                                    return rst;
                                                }
                                                MES_TM_TMINFO child_MES_TM_TMINFO = new MES_TM_TMINFO();
                                                child_MES_TM_TMINFO.TM = rst.TM;
                                                model_MES_TM_TMINFO_addLIST.Add(child_MES_TM_TMINFO);
                                            }
                                        }
                                    }
                                }
                                MES_TM_TMINFO model_MES_TM_TMINFO_bb = new MES_TM_TMINFO();
                                MES_SY_YERACOUNT model_MES_SY_YERACOUNT_bb = new MES_SY_YERACOUNT();
                                model_MES_SY_YERACOUNT_bb.TMLB = 1;
                                model_MES_SY_YERACOUNT_bb.GC = "1000";
                                model_MES_SY_YERACOUNT_bb.TMYEAR = "";
                                model_MES_TM_TMINFO_bb.TM = data_ISY_YERACOUNT.SELECT(model_MES_SY_YERACOUNT_bb);
                                model_MES_TM_TMINFO_bb.GC = "1000";
                                model_MES_TM_TMINFO_bb.TMLB = 1;
                                model_MES_TM_TMINFO_bb.TMSX = 411;
                                try
                                {
                                    model_MES_TM_TMINFO_bb.SCDATE = Convert.ToDateTime(rst_MES_FB_QMP_SELECT.DATALIST.Rows[a]["pDate"].ToString()).ToString("yyyy-MM-dd");
                                }
                                catch
                                {
                                }

                                model_MES_TM_TMINFO_bb.BC = 0;
                                model_MES_TM_TMINFO_bb.BCMS = "";
                                model_MES_TM_TMINFO_bb.GZZXBH = "Z3014";
                                model_MES_TM_TMINFO_bb.GZZXMS = "FBW";
                                model_MES_TM_TMINFO_bb.SBBH = "";
                                model_MES_TM_TMINFO_bb.SBHMS = rst_MES_FB_QMP_SELECT.DATALIST.Rows[a]["pCode"].ToString();
                                model_MES_TM_TMINFO_bb.RWBH = "";
                                model_MES_TM_TMINFO_bb.WLH = rst_MES_FB_QMP_SELECT.DATALIST.Rows[a]["pid"].ToString();
                                model_MES_TM_TMINFO_bb.WLMS = rst_MES_FB_QMP_SELECT.DATALIST.Rows[a]["pDesc"].ToString();
                                model_MES_TM_TMINFO_bb.PC = rst_MES_FB_QMP_SELECT.DATALIST.Rows[a]["ID"].ToString();
                                model_MES_TM_TMINFO_bb.CPZT = 80;
                                model_MES_TM_TMINFO_bb.CPZTNAME = "合格";
                                model_MES_TM_TMINFO_bb.TH = 0;
                                model_MES_TM_TMINFO_bb.SL = Convert.ToDecimal(rst_MES_FB_QMP_SELECT.DATALIST.Rows[a]["pQTY"].ToString());
                                model_MES_TM_TMINFO_bb.NOBILL = plotlist[0];
                                model_MES_TM_TMINFO_bb.NOBILLMX = plotlist[1];
                                model_MES_TM_TMINFO_bb.DCXHMS = rst_MES_FB_QMP_SELECT.DATALIST.Rows[a]["type"].ToString();
                                model_MES_TM_TMINFO_bb.REMARK = rst_MES_FB_QMP_SELECT.DATALIST.Rows[a]["pRem"].ToString() + rst_MES_FB_QMP_SELECT.DATALIST.Rows[a]["dMark"].ToString();
                                rst = data_ITM_TMINFO.INSERT_FB(model_MES_TM_TMINFO_bb);
                                if (rst.TYPE != "S")
                                {
                                    return rst;
                                }
                                List<MES_TM_GL> model_MES_TM_GL = new List<MES_TM_GL>();
                                for (int b = 0; b < model_MES_TM_TMINFO_addLIST.Count; b++)
                                {
                                    MES_TM_GL child_MES_TM_GL = new MES_TM_GL();
                                    child_MES_TM_GL.SCTM = rst.TM;
                                    child_MES_TM_GL.XCTM = model_MES_TM_TMINFO_addLIST[b].TM;
                                    child_MES_TM_GL.GLLB = 1;
                                    model_MES_TM_GL.Add(child_MES_TM_GL);
                                    MES_FB_QMP_TM model_MES_FB_QMP_TM = new MES_FB_QMP_TM();
                                    model_MES_FB_QMP_TM.ExcelServerRCID = rst_MES_FB_QMP_SELECT.DATALIST.Rows[a]["ExcelServerRCID"].ToString();
                                    model_MES_FB_QMP_TM.TM = model_MES_TM_TMINFO_addLIST[b].TM;
                                    data_FB_QMP.INSERT_TM(model_MES_FB_QMP_TM);
                                }
                                data_ITM_GL.INSERT(model_MES_TM_GL);
                                model_MES_FB_QMP = new MES_FB_QMP();
                                model_MES_FB_QMP.ExcelServerRCID = rst_MES_FB_QMP_SELECT.DATALIST.Rows[a]["ExcelServerRCID"].ToString();
                            }
                        }
                        model_MES_FB_QMP = new MES_FB_QMP();
                        model_MES_FB_QMP.ExcelServerRCID = rst_MES_FB_QMP_SELECT.DATALIST.Rows[a]["ExcelServerRCID"].ToString();
                        rst = data_FB_QMP.UPDATE(model_MES_FB_QMP, 1);
                        if (rst.TYPE != "S")
                        {
                            return rst;
                        }
                    }
                }
            }
            MES_SY_CCGCRETRUN model_MES_SY_CCGCRETRUN = new MES_SY_CCGCRETRUN();
            model_MES_SY_CCGCRETRUN.LB = 5;
            model_MES_SY_CCGCRETRUN.CCGC = "WS_MES_FB_QMP_SYNC_AUTO_CL";
            model_MES_SY_CCGCRETRUN.TYPE = rst.TYPE;
            model_MES_SY_CCGCRETRUN.MESSAGE = rst.MESSAGE;
            data_ISY_EXCEPTION.INSERT_CCGC(model_MES_SY_CCGCRETRUN);
            return rst;
        }
    }
}

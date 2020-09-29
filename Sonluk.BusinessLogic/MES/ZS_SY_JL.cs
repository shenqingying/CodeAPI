using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class ZS_SY_JL
    {
        private static readonly IZS_SY_JL data_IZS_SY_JL = MESDataAccess.CreateIZS_SY_JL();
        private static readonly ITM_TMINFO data_ITM_TMINFO = MESDataAccess.CreateTM_TMINFO();
        private static readonly ITM_GL data_ITM_GL = MESDataAccess.CreateTM_GL();

        public MES_RETURN INSERT(MES_ZS_SY_JL model)
        {
            return data_IZS_SY_JL.INSERT(model);
        }
        public MES_RETURN INSERT_MX(MES_ZS_SY_JL_MX model)
        {
            return data_IZS_SY_JL.INSERT_MX(model);
        }
        private MES_RETURN ZS_SY_JL_CK(List<MES_ZS_SY_JL> model, int KHID, string JLMS)
        {
            MES_RETURN rst = new MES_RETURN();
            for (int a = 0; a < model.Count; a++)
            {
                MES_TM_TMINFO model_MES_TM_TMINFO = new MES_TM_TMINFO();
                model_MES_TM_TMINFO.TM = model[a].KCBSTM;
                SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM_all = data_ITM_TMINFO.SELECT(model_MES_TM_TMINFO, 0);
                if (rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_RETURN.TYPE != "S")
                {
                    return rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_RETURN;
                }
                if (rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST.Count == 0)
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "条码" + model[a].KCBSTM + "失效或不存在";
                    return rst;
                }
                if (rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].RESDUESL < rst_SELECT_MES_TM_TMINFO_BYTM_all.MES_TM_TMINFO_LIST[0].SL)
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "条码" + model[a].KCBSTM + "已发货";
                    return rst;
                }
            }
            MES_ZS_SY_JL model_MES_ZS_SY_JL = new MES_ZS_SY_JL();
            model_MES_ZS_SY_JL.LB = 1;
            model_MES_ZS_SY_JL.JLMS = JLMS;
            model_MES_ZS_SY_JL.CJR = model[0].CJR;
            model_MES_ZS_SY_JL.KCBSTM = "";
            model_MES_ZS_SY_JL.JLLB = 4;
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
                model_MES_TM_GL.SCTM = model[a].KCBSTM;
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
                        model_MES_ZS_SY_JL_MX.FTM = model[a].KCBSTM;
                        model_MES_ZS_SY_JL_MX.TM = rst_MES_TM_GL_SELECT.MES_TM_GL[b].XCTM;
                        //model_MES_ZS_SY_JL_MX.JLMXLB = 3;
                        //model_MES_ZS_SY_JL_MX.JLMXLBNAME = "关联"
                        //model_MES_ZS_SY_JL_MX.GC = model[a].GC;
                        //model_MES_ZS_SY_JL_MX.KCDD = model[a].KCDD;
                        model_MES_ZS_SY_JL_MX.KHID = KHID;
                        rst = data_IZS_SY_JL.INSERT_MX(model_MES_ZS_SY_JL_MX);
                        if (rst.TYPE != "S")
                        {
                            return rst;
                        }
                    }
                }
            }
            return rst;
        }
        public MES_ZS_SY_JL_MX_SELECT SELECT_MX(MES_ZS_SY_JL_MX model)
        {
            return data_IZS_SY_JL.SELECT_MX(model);
        }
        public MES_RETURN UPDATE(MES_ZS_SY_JL model)
        {
            return data_IZS_SY_JL.UPDATE(model);
        }
        public MES_RETURN INSERT_QJQXJL(MES_ZS_SY_JL_QJQXJL model)
        {
            return data_IZS_SY_JL.INSERT_QJQXJL(model);
        }
    }
}

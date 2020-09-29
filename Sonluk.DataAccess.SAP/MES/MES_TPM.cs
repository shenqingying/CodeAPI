using SAP.Middleware.Connector;
using Sonluk.DataAccess.SAP.Utility;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.SAP.MES
{
    public class MES_TPM : IMES_TPM
    {
        public ZBCFUN_TPINFO_INSERT INSERT_TPM(ZSL_BCS025 model, string IV_COUNT)
        {
            ZBCFUN_TPINFO_INSERT rst = new ZBCFUN_TPINFO_INSERT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            IRfcFunction func = RFC.Function("ZBCFUN_TPINFO_INSERT");
            func.SetValue("IV_COUNT", IV_COUNT);
            IRfcStructure irfcstruc = func.GetStructure("IS_TPINFO");
            irfcstruc.SetValue("TPGG", model.TPGG);
            irfcstruc.SetValue("TPGGNAME", model.TPGGNAME);
            irfcstruc.SetValue("WERKS", model.WERKS);
            irfcstruc.SetValue("LGORT", model.LGORT);
            irfcstruc.SetValue("TPLY", model.TPLY);
            irfcstruc.SetValue("TPLYNAME", model.TPLYNAME);
            irfcstruc.SetValue("CJR", model.CJR);
            irfcstruc.SetValue("CJRNAME", model.CJRNAME);
            irfcstruc.SetValue("TPTYPE", model.TPTYPE);
            func.SetValue("IS_TPINFO", irfcstruc);
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table_MES_RETURN = func.GetTable("CT_RETURN");
                table_MES_RETURN.CurrentIndex = 0;
                child_MES_RETURN.TYPE = table_MES_RETURN.GetString("TYPE");
                child_MES_RETURN.MESSAGE = table_MES_RETURN.GetString("MESSAGE");
                rst.MES_RETURN = child_MES_RETURN;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
            }
            return rst;
        }
        public ZBCFUN_TPINFO_INSERT DELETE_TPM(string IV_TPNO)
        {
            ZBCFUN_TPINFO_INSERT rst = new ZBCFUN_TPINFO_INSERT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            IRfcFunction func = RFC.Function("ZBCFUN_TPINFO_DELETE");
            func.SetValue("IV_TPNO", IV_TPNO);
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table_MES_RETURN = func.GetTable("CT_RETURN");
                table_MES_RETURN.CurrentIndex = 0;
                child_MES_RETURN.TYPE = table_MES_RETURN.GetString("TYPE");
                child_MES_RETURN.MESSAGE = table_MES_RETURN.GetString("MESSAGE");
                rst.MES_RETURN = child_MES_RETURN;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
            }
            return rst;
        }
        public ZBCFUN_TPINFO_INSERT UPDATE_TPM(ZSL_BCS025 model, List<ZSL_BCT012> model_IT_TPYD, string IV_FCODE, string IV_LGORT, string IV_WERKS)
        {
            ZBCFUN_TPINFO_INSERT rst = new ZBCFUN_TPINFO_INSERT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            IRfcFunction func = RFC.Function("ZBCFUN_TPINFO_UPDATE");
            func.SetValue("IV_FCODE", IV_FCODE);
            if (IV_FCODE == "1")
            {
                IRfcStructure irfcstruc = func.GetStructure("IS_TPINFO");
                irfcstruc.SetValue("TPNO", model.TPNO);
                irfcstruc.SetValue("TPGG", model.TPGG);
                irfcstruc.SetValue("TPGGNAME", model.TPGGNAME);
                irfcstruc.SetValue("WERKS", model.WERKS);
                irfcstruc.SetValue("LGORT", model.LGORT);
                irfcstruc.SetValue("TPLY", model.TPLY);
                irfcstruc.SetValue("TPLYNAME", model.TPLYNAME);
                irfcstruc.SetValue("CJR", model.CJR);
                irfcstruc.SetValue("CJRNAME", model.CJRNAME);
                irfcstruc.SetValue("TPTYPE", model.TPTYPE);
                func.SetValue("IS_TPINFO", irfcstruc);
            }
            if (IV_FCODE == "2")
            {
                IRfcTable irfctable = func.GetTable("IT_TPYD");
                for (int i = 0; i < model_IT_TPYD.Count; i++)
                {
                    irfctable.Append();
                    irfctable.SetValue("TPNO", model_IT_TPYD[i].TPNO);
                    irfctable.SetValue("TPZHNO", model_IT_TPYD[i].TPZHNO);
                }
                func.SetValue("IT_TPYD", irfctable);
                func.SetValue("IV_LGORT", IV_LGORT);
                func.SetValue("IV_WERKS", IV_WERKS);
            }
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table_MES_RETURN = func.GetTable("CT_RETURN");
                table_MES_RETURN.CurrentIndex = 0;
                child_MES_RETURN.TYPE = table_MES_RETURN.GetString("TYPE");
                child_MES_RETURN.MESSAGE = table_MES_RETURN.GetString("MESSAGE");
                rst.MES_RETURN = child_MES_RETURN;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
            }
            return rst;
        }
        public ZBCFUN_TPINFO_SELECT SELECT_TPM(ZSL_BCS025 model)
        {
            ZBCFUN_TPINFO_SELECT rst = new ZBCFUN_TPINFO_SELECT();
            List<ZSL_BCT009> child_ET_TPINFO = new List<ZSL_BCT009>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            IRfcFunction func = RFC.Function("ZBCFUN_TPINFO_SELECT");
            IRfcStructure irfcstruc = func.GetStructure("IS_TPINFO");
            irfcstruc.SetValue("TPNO", model.TPNO);
            irfcstruc.SetValue("TPGG", model.TPGG);
            irfcstruc.SetValue("TPGGNAME", model.TPGGNAME);
            irfcstruc.SetValue("WERKS", model.WERKS);
            irfcstruc.SetValue("LGORT", model.LGORT);
            irfcstruc.SetValue("ISFREE", model.ISFREE);
            irfcstruc.SetValue("TPLY", model.TPLY);
            irfcstruc.SetValue("TPLYNAME", model.TPLYNAME);
            irfcstruc.SetValue("CJR", model.CJR);
            irfcstruc.SetValue("CJRNAME", model.CJRNAME);
            irfcstruc.SetValue("CJRQ", model.CJRQ);
            irfcstruc.SetValue("CJSJ", model.CJSJ);
            irfcstruc.SetValue("TPTYPE", model.TPTYPE);
            func.SetValue("IS_TPINFO", irfcstruc);
            try
            {
                RFC.Invoke(func, false);

                IRfcTable tb_CT_RETURN = func.GetTable("CT_RETURN");
                tb_CT_RETURN.CurrentIndex = 0;
                child_MES_RETURN.TYPE = tb_CT_RETURN.GetString("TYPE");
                child_MES_RETURN.MESSAGE = tb_CT_RETURN.GetString("MESSAGE");

                if (child_MES_RETURN.TYPE != "E")
                {
                    IRfcTable table = func.GetTable("ET_TPINFO");
                    for (int i = 0; i < table.RowCount; i++)
                    {
                        table.CurrentIndex = i;
                        ZSL_BCT009 child = new ZSL_BCT009();
                        //child.MANDT = table.GetString("MANDT");
                        child.TPNO = table.GetString("TPNO");
                        child.TPGG = Convert.ToInt32(Convert.ToDouble(table.GetString("TPGG")));
                        child.TPGGNAME = table.GetString("TPGGNAME");
                        child.WERKS = table.GetString("WERKS");
                        child.LGORT = table.GetString("LGORT");
                        child.ISFREE = Convert.ToInt32(Convert.ToDouble(table.GetString("ISFREE")));
                        child.TPLY = Convert.ToInt32(Convert.ToDouble(table.GetString("TPLY")));
                        child.TPLYNAME = table.GetString("TPLYNAME");
                        child.CJR = Convert.ToInt32(Convert.ToDouble(table.GetString("CJR")));
                        child.CJRNAME = table.GetString("CJRNAME");
                        child.CJRQ = table.GetString("CJRQ");
                        child.CJSJ = table.GetString("CJSJ");
                        child.LGOBE = table.GetString("LGOBE");
                        child.TPTYPE = Convert.ToInt32(table.GetString("TPTYPE"));
                        if (child.TPTYPE == 1)
                        {
                            child.TPTYPENAME = "租赁";
                        }
                        else if (child.TPTYPE == 2)
                        {
                            child.TPTYPENAME = "自购";
                        }
                        child.ZHYDRQ = table.GetString("ZHYDRQ");
                        if (child.ZHYDRQ == "0000-00-00")
                        {
                            child.ZHYDRQ = "";
                        }
                        child_ET_TPINFO.Add(child);
                    }
                }
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.ET_TPINFO = child_ET_TPINFO;
            return rst;
        }
        public ZBCFUN_TP_ZHM_GL INSERT_TP_ZHM(string IV_FCODE, ZSL_BCT011 IT_TPZHNO, List<ZSL_BCT012> IT_TPZHNO_GL)
        {
            ZBCFUN_TP_ZHM_GL rst = new ZBCFUN_TP_ZHM_GL();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<ZSL_BCT012> child_ET_ZHM = new List<ZSL_BCT012>();
            IRfcFunction func = RFC.Function("ZBCFUN_TP_ZHM_GL_INSERT");
            func.SetValue("IV_FCODE", IV_FCODE);
            if (IV_FCODE == "1")
            {
                IRfcTable irfctable = func.GetTable("IT_TPZHNO_GL");
                for (int i = 0; i < IT_TPZHNO_GL.Count; i++)
                {
                    irfctable.Append();
                    irfctable.SetValue("TPNO", IT_TPZHNO_GL[i].TPNO);
                }
                func.SetValue("IT_TPZHNO_GL", irfctable);
                IRfcStructure irfcstruc_IT_TPZHNO = func.GetStructure("IS_TPZHNO");
                irfcstruc_IT_TPZHNO.SetValue("CJR", IT_TPZHNO.CJR);
                irfcstruc_IT_TPZHNO.SetValue("CJRNAME", IT_TPZHNO.CJRNAME);
                func.SetValue("IS_TPZHNO", irfcstruc_IT_TPZHNO);
            }
            if (IV_FCODE == "2")
            {
                IRfcTable irfctable = func.GetTable("IT_TPZHNO_GL");
                for (int i = 0; i < IT_TPZHNO_GL.Count; i++)
                {
                    irfctable.Append();
                    irfctable.SetValue("TPNO", IT_TPZHNO_GL[i].TPNO);
                    irfctable.SetValue("TPZHNO", IT_TPZHNO_GL[i].TPZHNO);
                }
                func.SetValue("IT_TPZHNO_GL", irfctable);
                IRfcStructure irfcstruc_IT_TPZHNO = func.GetStructure("IS_TPZHNO");
                irfcstruc_IT_TPZHNO.SetValue("TPZHNO", IT_TPZHNO.TPZHNO);
                irfcstruc_IT_TPZHNO.SetValue("CJR", IT_TPZHNO.CJR);
                irfcstruc_IT_TPZHNO.SetValue("CJRNAME", IT_TPZHNO.CJRNAME);
                func.SetValue("IS_TPZHNO", irfcstruc_IT_TPZHNO);
            }
            try
            {
                RFC.Invoke(func, false);
                IRfcTable tb_CT_RETURN = func.GetTable("CT_RETURN");
                tb_CT_RETURN.CurrentIndex = 0;
                child_MES_RETURN.TYPE = tb_CT_RETURN.GetString("TYPE");
                child_MES_RETURN.MESSAGE = tb_CT_RETURN.GetString("MESSAGE");
                if (child_MES_RETURN.TYPE != "E")
                {
                    IRfcTable table_IT_TPZHNO_GL = func.GetTable("IT_TPZHNO_GL");
                    for (int i = 0; i < table_IT_TPZHNO_GL.RowCount; i++)
                    {
                        table_IT_TPZHNO_GL.CurrentIndex = i;
                        ZSL_BCT012 child = new ZSL_BCT012();
                        child.MANDT = table_IT_TPZHNO_GL.GetString("MANDT");
                        child.TPNO = table_IT_TPZHNO_GL.GetString("TPNO");
                        child.TPZHNO = table_IT_TPZHNO_GL.GetString("TPZHNO");
                        child_ET_ZHM.Add(child);
                    }
                }
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.IT_TPZHNO_GL = child_ET_ZHM;
            return rst;
        }
        public ZBCFUN_TP_ZHM_GL SELECT_TP_ZHM(string IV_FCODE, string IV_TPZHNO, string IV_CJRQKS, string IV_CJRQJS, string IV_CJRNAME)
        {
            ZBCFUN_TP_ZHM_GL rst = new ZBCFUN_TP_ZHM_GL();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<ZSL_BCT012> child_ET_TPNO = new List<ZSL_BCT012>();
            List<ZSL_BCT011> child_ET_TPZHNO = new List<ZSL_BCT011>();
            IRfcFunction func = RFC.Function("ZBCFUN_TP_ZHM_GL_SELECT");
            func.SetValue("IV_FCODE", IV_FCODE);
            func.SetValue("IV_TPZHNO", IV_TPZHNO);
            func.SetValue("IV_CJRQKS", IV_CJRQKS);
            func.SetValue("IV_CJRQJS", IV_CJRQJS);
            func.SetValue("IV_CJRNAME", IV_CJRNAME);
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table_MES_RETURN = func.GetTable("CT_RETURN");
                table_MES_RETURN.CurrentIndex = 0;
                child_MES_RETURN.TYPE = table_MES_RETURN.GetString("TYPE");
                child_MES_RETURN.MESSAGE = table_MES_RETURN.GetString("MESSAGE");
                if (child_MES_RETURN.TYPE != "E")
                {
                    if (IV_FCODE == "1")
                    {
                        IRfcTable table_ET_TPZHNO = func.GetTable("ET_TPZHNO");
                        for (int i = 0; i < table_ET_TPZHNO.RowCount; i++)
                        {
                            table_ET_TPZHNO.CurrentIndex = i;
                            ZSL_BCT011 child = new ZSL_BCT011();
                            child.MANDT = table_ET_TPZHNO.GetString("MANDT");
                            child.TPZHNO = table_ET_TPZHNO.GetString("TPZHNO");
                            child.ISDELETE = Convert.ToInt32(Convert.ToDouble(table_ET_TPZHNO.GetString("ISDELETE")));
                            child.CJR = Convert.ToInt32(Convert.ToDouble(table_ET_TPZHNO.GetString("CJR")));
                            child.CJRNAME = table_ET_TPZHNO.GetString("CJRNAME");
                            child.CJRQ = table_ET_TPZHNO.GetString("CJRQ");
                            child.CJSJ = table_ET_TPZHNO.GetString("CJSJ");
                            child_ET_TPZHNO.Add(child);
                        }
                    }
                    if (IV_FCODE == "2")
                    {
                        IRfcTable table_ET_TPNO = func.GetTable("ET_TPNO");
                        for (int i = 0; i < table_ET_TPNO.RowCount; i++)
                        {
                            table_ET_TPNO.CurrentIndex = i;
                            ZSL_BCT012 child = new ZSL_BCT012();
                            child.MANDT = table_ET_TPNO.GetString("MANDT");
                            child.TPZHNO = table_ET_TPNO.GetString("TPZHNO");
                            child.TPNO = table_ET_TPNO.GetString("TPNO");
                            child_ET_TPNO.Add(child);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.ET_TPZHNO = child_ET_TPZHNO;
            rst.IT_TPZHNO_GL = child_ET_TPNO;
            return rst;
        }
        public ZBCFUN_TP_ZHM_GL DELETE_TP_ZHM(ZSL_BCT012 model_IS_TPZHNO_GL, string IV_FCODE, string IV_TPZHNO)
        {
            ZBCFUN_TP_ZHM_GL rst = new ZBCFUN_TP_ZHM_GL();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            IRfcFunction func = RFC.Function("ZBCFUN_TP_ZHM_GL_DELETE");
            func.SetValue("IV_FCODE", IV_FCODE);
            if (IV_FCODE == "1")
            {
                func.SetValue("IV_TPZHNO", IV_TPZHNO);
            }
            if (IV_FCODE == "2")
            {
                IRfcStructure irfcstruc = func.GetStructure("IS_TPZHNO_GL");
                irfcstruc.SetValue("TPNO", model_IS_TPZHNO_GL.TPNO);
                irfcstruc.SetValue("TPZHNO", model_IS_TPZHNO_GL.TPZHNO);
                func.SetValue("IS_TPZHNO_GL", irfcstruc);
            }
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table_MES_RETURN = func.GetTable("CT_RETURN");
                table_MES_RETURN.CurrentIndex = 0;
                child_MES_RETURN.TYPE = table_MES_RETURN.GetString("TYPE");
                child_MES_RETURN.MESSAGE = table_MES_RETURN.GetString("MESSAGE");
                rst.MES_RETURN = child_MES_RETURN;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
            }
            return rst;
        }
        public ZBCFUN_TP_RKBS_GL INSERT_TP_RKBS(List<ZSL_BCT010> IT_TPNO_GL)
        {
            ZBCFUN_TP_RKBS_GL rst = new ZBCFUN_TP_RKBS_GL();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<ZSL_BCT010> child_IT_TPNO_GL = new List<ZSL_BCT010>();
            IRfcFunction func = RFC.Function("ZBCFUN_TP_RKBS_GL_INSERT");
            IRfcTable irfctable = func.GetTable("IT_TPNO_GL");
            for (int i = 0; i < IT_TPNO_GL.Count; i++)
            {
                irfctable.Append();
                irfctable.SetValue("TPNO", IT_TPNO_GL[i].TPNO);
                irfctable.SetValue("TPM", IT_TPNO_GL[i].TPM);
            }
            func.SetValue("IT_TPNO_GL", irfctable);
            try
            {
                RFC.Invoke(func, false);
                IRfcTable tb_CT_RETURN = func.GetTable("CT_RETURN");
                tb_CT_RETURN.CurrentIndex = 0;
                child_MES_RETURN.TYPE = tb_CT_RETURN.GetString("TYPE");
                child_MES_RETURN.MESSAGE = tb_CT_RETURN.GetString("MESSAGE");
                if (child_MES_RETURN.TYPE != "E")
                {
                    IRfcTable table_IT_TPNO_GL = func.GetTable("IT_TPNO_GL");
                    for (int i = 0; i < table_IT_TPNO_GL.RowCount; i++)
                    {
                        table_IT_TPNO_GL.CurrentIndex = i;
                        ZSL_BCT010 child = new ZSL_BCT010();
                        child.MANDT = table_IT_TPNO_GL.GetString("MANDT");
                        child.TPNO = table_IT_TPNO_GL.GetString("TPNO");
                        child.TPM = table_IT_TPNO_GL.GetString("TPM");
                        child_IT_TPNO_GL.Add(child);
                    }
                }
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.IT_TPNO_GL = child_IT_TPNO_GL;
            return rst;
        }
        public ZBCFUN_TP_RKBS_GL SELECT_TP_RKBS(string IV_TPNO)
        {
            ZBCFUN_TP_RKBS_GL rst = new ZBCFUN_TP_RKBS_GL();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<ZSL_BCT010> child_ET_TPNO_GL = new List<ZSL_BCT010>();
            IRfcFunction func = RFC.Function("ZBCFUN_TP_RKBS_GL_SELECT");
            func.SetValue("IV_TPNO", IV_TPNO);
            try
            {
                RFC.Invoke(func, false);
                IRfcTable tb_CT_RETURN = func.GetTable("CT_RETURN");
                tb_CT_RETURN.CurrentIndex = 0;
                child_MES_RETURN.TYPE = tb_CT_RETURN.GetString("TYPE");
                child_MES_RETURN.MESSAGE = tb_CT_RETURN.GetString("MESSAGE");
                if (child_MES_RETURN.TYPE != "E")
                {
                    IRfcTable table_ET_TPNO_GL = func.GetTable("ET_TPNO_GL");
                    for (int i = 0; i < table_ET_TPNO_GL.RowCount; i++)
                    {
                        table_ET_TPNO_GL.CurrentIndex = i;
                        ZSL_BCT010 child = new ZSL_BCT010();
                        child.MANDT = table_ET_TPNO_GL.GetString("MANDT");
                        child.TPNO = table_ET_TPNO_GL.GetString("TPNO");
                        child.TPM = table_ET_TPNO_GL.GetString("TPM");
                        child_ET_TPNO_GL.Add(child);
                    }
                }
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.IT_TPNO_GL = child_ET_TPNO_GL;
            return rst;
        }
        public ZBCFUN_TP_RKBS_GL DELETE_TP_RKBS(ZSL_BCT010 IS_TPNO_GL)
        {
            ZBCFUN_TP_RKBS_GL rst = new ZBCFUN_TP_RKBS_GL();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            IRfcFunction func = RFC.Function("ZBCFUN_TP_RKBS_GL_DELETE");
            IRfcStructure irfcstruc = func.GetStructure("IS_TPNO_GL");
            irfcstruc.SetValue("TPNO", IS_TPNO_GL.TPNO);
            irfcstruc.SetValue("TPM", IS_TPNO_GL.TPM);
            func.SetValue("IS_TPNO_GL", irfcstruc);
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table_MES_RETURN = func.GetTable("CT_RETURN");
                table_MES_RETURN.CurrentIndex = 0;
                child_MES_RETURN.TYPE = table_MES_RETURN.GetString("TYPE");
                child_MES_RETURN.MESSAGE = table_MES_RETURN.GetString("MESSAGE");
                rst.MES_RETURN = child_MES_RETURN;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
            }
            return rst;
        }
    }
}

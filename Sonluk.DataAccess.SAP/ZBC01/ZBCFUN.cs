using SAP.Middleware.Connector;
using Sonluk.DataAccess.SAP.Utility;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.SAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.SAP.ZBC01
{
    public class ZBCFUN : IZBCFUN
    {
        public MES_SY_TPM_SYNC_SELECT ZBCFUN_TPZSJ_READ(string IV_DATEST, string IV_DATEED)
        {
            MES_SY_TPM_SYNC_SELECT rst = new MES_SY_TPM_SYNC_SELECT();
            List<MES_SY_TPM_SYNC> child_MES_SY_TPM_SYNC = new List<MES_SY_TPM_SYNC>();
            List<MES_SY_TPM_SYNC> child_MES_SY_TPM_SYNC_DELETE = new List<MES_SY_TPM_SYNC>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            IRfcFunction func = RFC.Function("ZBCFUN_TPZSJ_READ");
            if (!string.IsNullOrEmpty(IV_DATEST))
            {
                func.SetValue("IV_DATEST", IV_DATEST);
            }
            if (!string.IsNullOrEmpty(IV_DATEED))
            {
                func.SetValue("IV_DATEED", IV_DATEED);
            }
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table_CT_RETURN = func.GetTable("CT_RETURN");
                table_CT_RETURN.CurrentIndex = 0;
                child_MES_RETURN.TYPE = table_CT_RETURN.GetString("TYPE");
                child_MES_RETURN.MESSAGE = table_CT_RETURN.GetString("MESSAGE");

                IRfcTable table_ET_TPZSJ = func.GetTable("ET_TPZSJ");
                for (int i = 0; i < table_ET_TPZSJ.RowCount; i++)
                {
                    table_ET_TPZSJ.CurrentIndex = i;
                    MES_SY_TPM_SYNC child = new MES_SY_TPM_SYNC();
                    child.TPM = table_ET_TPZSJ.GetString("TPM");
                    child.MATNR = table_ET_TPZSJ.GetString("MATNR");
                    child.CHARG = table_ET_TPZSJ.GetString("CHARG");
                    child.WERKS = table_ET_TPZSJ.GetString("WERKS");
                    child.LGORT = table_ET_TPZSJ.GetString("LGORT");
                    child.LGPLA = table_ET_TPZSJ.GetString("LGPLA");
                    child.SL = table_ET_TPZSJ.GetString("SL");
                    child.YSSL = table_ET_TPZSJ.GetString("YSSL");
                    child.ZL = table_ET_TPZSJ.GetString("ZL");
                    child.CKDJH = table_ET_TPZSJ.GetString("CKDJH");
                    child.TMZT = table_ET_TPZSJ.GetString("TMZT");
                    child.SOBKZ = table_ET_TPZSJ.GetString("SOBKZ");
                    child.SONUM = table_ET_TPZSJ.GetString("SONUM");
                    child.CJTIME = table_ET_TPZSJ.GetString("CJRQ") + " " + table_ET_TPZSJ.GetString("CJSJ");
                    child.CJR = table_ET_TPZSJ.GetString("CJR");
                    child.XGTIME = table_ET_TPZSJ.GetString("XGRQ") + " " + table_ET_TPZSJ.GetString("XGSJ");
                    child.XGR = table_ET_TPZSJ.GetString("XGR");
                    child_MES_SY_TPM_SYNC.Add(child);
                }
                IRfcTable table_ET_TPZFB = func.GetTable("ET_TPZFB");
                for (int i = 0; i < table_ET_TPZFB.RowCount; i++)
                {
                    table_ET_TPZFB.CurrentIndex = i;
                    MES_SY_TPM_SYNC child = new MES_SY_TPM_SYNC();
                    child.TPM = table_ET_TPZFB.GetString("TPM");
                    child_MES_SY_TPM_SYNC_DELETE.Add(child);
                }

            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            rst.MES_SY_TPM_SYNC = child_MES_SY_TPM_SYNC;
            rst.MES_SY_TPM_SYNC_DELETE = child_MES_SY_TPM_SYNC_DELETE;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
    }
}

using Sonluk.DAFactory;
using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.HR
{
    public class GS_GSSL
    {
        private static readonly IGS_GSSL IGS_GSSLdata = HRDataAccess.CreateGS_GSSL();
        private static readonly IXZGL_TAX_TAXSLMX IXZGL_TAX_TAXSLMXdata = HRDataAccess.CreateXZGL_TAX_TAXSLMX();
        public MES_RETURN INSERT(HR_GS_GSSL model)
        {
            MES_RETURN rst = IGS_GSSLdata.INSERT(model);
            if (rst.TYPE == "S")
            {
                for (int a = 0; a < model.HR_XZGL_TAX_TAXSLMX.Count; a++)
                {
                    model.HR_XZGL_TAX_TAXSLMX[a].SWLBID = rst.TID;
                    IXZGL_TAX_TAXSLMXdata.INSERT(model.HR_XZGL_TAX_TAXSLMX[a]);
                }
            }
            return rst;
        }
        public HR_GS_GSSL_SELECT SELECT(HR_GS_GSSL model)
        {
            HR_GS_GSSL_SELECT rst = IGS_GSSLdata.SELECT(model);
            for (int a = 0; a < rst.HR_GS_GSSL.Count; a++)
            {
                HR_XZGL_TAX_TAXSLMX model_HR_XZGL_TAX_TAXSLMX = new HR_XZGL_TAX_TAXSLMX();
                model_HR_XZGL_TAX_TAXSLMX.SWLBID = rst.HR_GS_GSSL[a].SWLBID;
                HR_XZGL_TAX_TAXSLMX_SELECT rst_HR_XZGL_TAX_TAXSLMX_SELECT = IXZGL_TAX_TAXSLMXdata.SELECT(model_HR_XZGL_TAX_TAXSLMX);
                if (rst_HR_XZGL_TAX_TAXSLMX_SELECT.MES_RETURN.TYPE == "S")
                {
                    rst.HR_GS_GSSL[a].HR_XZGL_TAX_TAXSLMX = rst_HR_XZGL_TAX_TAXSLMX_SELECT.HR_XZGL_TAX_TAXSLMX;
                }
            }
            return rst;
        }
        public MES_RETURN UPDATE(HR_GS_GSSL model, int LB)
        {
            MES_RETURN rst = IGS_GSSLdata.UPDATE(model, LB);
            if (LB == 2)
            {
                HR_XZGL_TAX_TAXSLMX model_HR_XZGL_TAX_TAXSLMX = new HR_XZGL_TAX_TAXSLMX();
                model_HR_XZGL_TAX_TAXSLMX.SWLBID = model.SWLBID;
                MES_RETURN rst_MES_RETURN = IXZGL_TAX_TAXSLMXdata.UPDATE(model_HR_XZGL_TAX_TAXSLMX, 1);
                if (rst_MES_RETURN.TYPE == "S")
                {
                    for (int a = 0; a < model.HR_XZGL_TAX_TAXSLMX.Count; a++)
                    {
                        model.HR_XZGL_TAX_TAXSLMX[a].SWLBID = model.SWLBID;
                        IXZGL_TAX_TAXSLMXdata.INSERT(model.HR_XZGL_TAX_TAXSLMX[a]);
                    }
                }
            }
            return rst;
        }
    }
}

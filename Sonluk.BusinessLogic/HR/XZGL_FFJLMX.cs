using Sonluk.DAFactory;
using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.HR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.HR
{
    public class XZGL_FFJLMX
    {
        private static readonly IXZGL_FFJLMX IXZGL_FFJLMXdata = HRDataAccess.CreateXZGL_FFJLMX();
        public MES_RETURN INSERT(HR_XZGL_FFJLMX model, DataTable dt)
        {
            return IXZGL_FFJLMXdata.INSERT(model, dt);
        }
        public MES_RETURN UPDATE(HR_XZGL_FFJLMX model, int LB)
        {
            return IXZGL_FFJLMXdata.UPDATE(model, LB);
        }
        public HR_XZGL_FFJLMX_SELECT SELECT(HR_XZGL_FFJLMX model, int LB)
        {
            return IXZGL_FFJLMXdata.SELECT(model, LB);
        }
        public MES_RETURN FORMULA_JS(HR_XZGL_FFJLMX model, int LB)
        {
            return IXZGL_FFJLMXdata.FORMULA_JS(model, LB);
        }
        public MES_RETURN FORMULA_JS_TZ(HR_XZGL_FFJLMX model, int LB)
        {
            return IXZGL_FFJLMXdata.FORMULA_JS_TZ(model, LB);
        }
        public MES_RETURN AUTO_ADD_TO_FFJLMX_OTHER(HR_XZGL_FFJLMX model, int LB)
        {
            return IXZGL_FFJLMXdata.AUTO_ADD_TO_FFJLMX_OTHER(model, LB);
        }
        public HR_XZGL_FFJLMX_SELECT SELECT_GSREPORT(HR_XZGL_FFJLMX model)
        {
            return IXZGL_FFJLMXdata.SELECT_GSREPORT(model);
        }
        public HR_XZGL_FFJLMX_SELECT SELECT_FFMXREPORT(HR_XZGL_FFJLMX model)
        {
            return IXZGL_FFJLMXdata.SELECT_FFMXREPORT(model);
        }
        public HR_XZGL_FFJLMX_SELECT SELECT_GZXJSDREPORT(HR_XZGL_FFJLMX model)
        {
            return IXZGL_FFJLMXdata.SELECT_GZXJSDREPORT(model);
        }
        public HR_XZGL_FFJLMX_SELECT SELECT_FFMXGZDREPORT(HR_XZGL_FFJLMX model)
        {
            return IXZGL_FFJLMXdata.SELECT_FFMXGZDREPORT(model);
        }
        public HR_XZGL_FFJLMX_SELECT SELECT_FFMXGZHZREPORT(HR_XZGL_FFJLMX model)
        {
            return IXZGL_FFJLMXdata.SELECT_FFMXGZHZREPORT(model);
        }
        public HR_XZGL_FFJLMX_SELECT SELECT_FFMXTXFREPORT(HR_XZGL_FFJLMX model, int LB)
        {
            return IXZGL_FFJLMXdata.SELECT_FFMXTXFREPORT(model, LB);
        }
        public HR_XZGL_FFJLMX_SELECT SELECT_GUOSHUIREPORT(HR_XZGL_FFJLMX model)
        {
            return IXZGL_FFJLMXdata.SELECT_GUOSHUIREPORT(model);
        }
    }
}

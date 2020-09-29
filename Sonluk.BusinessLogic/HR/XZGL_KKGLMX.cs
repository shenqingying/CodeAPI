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
    public class XZGL_KKGLMX
    {
        private static readonly IXZGL_KKGLMX IXZGL_KKGLMXdata = HRDataAccess.CreateXZGL_KKGLMX();
        private static readonly IXZGL_KKGL IXZGL_KKGLdata = HRDataAccess.CreateXZGL_KKGL();
        public MES_RETURN INSERT(HR_XZGL_KKGLMX model)
        {
            MES_RETURN rst = IXZGL_KKGLMXdata.INSERT(model);
            if (rst.TYPE == "S")
            {
                HR_XZGL_KKGL model_HR_XZGL_KKGL = new HR_XZGL_KKGL();
                model_HR_XZGL_KKGL.KKID = model.KKID;
                IXZGL_KKGLdata.UPDATE(model_HR_XZGL_KKGL, 3);
            }
            return rst;
        }
        public MES_RETURN UPDATE(HR_XZGL_KKGLMX model, int LB)
        {
            MES_RETURN rst = IXZGL_KKGLMXdata.UPDATE(model, LB);
            if (rst.TYPE == "S")
            {
                HR_XZGL_KKGL model_HR_XZGL_KKGL = new HR_XZGL_KKGL();
                model_HR_XZGL_KKGL.KKID = model.KKID;
                IXZGL_KKGLdata.UPDATE(model_HR_XZGL_KKGL, 3);
            }
            return rst;
        }
        public HR_XZGL_KKGLMX_SELECT SELECT(HR_XZGL_KKGLMX model)
        {
            return IXZGL_KKGLMXdata.SELECT(model);
        }
        public MES_RETURN AUTO_ADD_TO_FFJLMX(HR_XZGL_KKGLMX model)
        {
            MES_RETURN rst = IXZGL_KKGLMXdata.AUTO_ADD_TO_FFJLMX(model);
            if (rst.TYPE == "S")
            {
                HR_XZGL_KKGL model_HR_XZGL_KKGL = new HR_XZGL_KKGL();
                IXZGL_KKGLdata.UPDATE(model_HR_XZGL_KKGL, 3);
            }
            return rst;
        }
    }
}

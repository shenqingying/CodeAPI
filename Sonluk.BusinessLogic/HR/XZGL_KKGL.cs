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
    public class XZGL_KKGL
    {
        private static readonly IXZGL_KKGL IXZGL_KKGLdata = HRDataAccess.CreateXZGL_KKGL();
        private static readonly IXZGL_KKGLMX IXZGL_KKGLMXdata = HRDataAccess.CreateXZGL_KKGLMX();
        public MES_RETURN INSERT(HR_XZGL_KKGL model)
        {
            MES_RETURN rst = IXZGL_KKGLdata.INSERT(model);
            if (rst.TYPE == "S")
            {
                int ksmonth = Convert.ToInt32(model.KSYEAR + model.KSMOUTH);
                int jsmonth = Convert.ToInt32(model.JSYEAR + model.JSMOUTH);
                int qj = jsmonth - ksmonth + 1;
                if (qj > 0)
                {
                    for (int a = 0; a < qj; a++)
                    {
                        //for (int b = 0; b < 2; b++)
                        //{
                        ksmonth = ksmonth + a;
                        HR_XZGL_KKGLMX model_HR_XZGL_KKGLMX = new HR_XZGL_KKGLMX();
                        model_HR_XZGL_KKGLMX.KKID = rst.TID;
                        model_HR_XZGL_KKGLMX.KKYEAR = ksmonth.ToString().Substring(0, 4);
                        model_HR_XZGL_KKGLMX.KKMONTH = ksmonth.ToString().Substring(4, 2);
                        model_HR_XZGL_KKGLMX.ZDID = model.ZDID;
                        model_HR_XZGL_KKGLMX.CLJE = 0;
                        model_HR_XZGL_KKGLMX.REMARK = "";
                        model_HR_XZGL_KKGLMX.CJR = model.CJR;
                        IXZGL_KKGLMXdata.INSERT(model_HR_XZGL_KKGLMX);
                        //}
                    }
                }
            }
            return rst;
        }
        public MES_RETURN AUTOINSERT(HR_XZGL_KKGL model)
        {
            return IXZGL_KKGLdata.AUTOINSERT(model);
        }
        public MES_RETURN UPDATE(HR_XZGL_KKGL model, int LB)
        {
            return IXZGL_KKGLdata.UPDATE(model, LB);
        }
        public HR_XZGL_KKGL_SELECT SELECT(HR_XZGL_KKGL model)
        {
            return IXZGL_KKGLdata.SELECT(model);
        }
    }
}

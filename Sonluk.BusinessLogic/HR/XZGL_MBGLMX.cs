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
    public class XZGL_MBGLMX
    {
        private static readonly IXZGL_MBGLMX IXZGL_MBGLMXdata = HRDataAccess.CreateXZGL_MBGLMX();
        public MES_RETURN INSERT(HR_XZGL_MBGLMX model)
        {
            return IXZGL_MBGLMXdata.INSERT(model);
        }
        public MES_RETURN UPDATE(HR_XZGL_MBGLMX model, int LB)
        {
            return IXZGL_MBGLMXdata.UPDATE(model, LB);
        }
        public HR_XZGL_MBGLMX_SELECT SELECT(HR_XZGL_MBGLMX model)
        {
            return IXZGL_MBGLMXdata.SELECT(model);
        }
        public HR_XZGL_MBGLMX_SELECT SELECT_LAY(HR_XZGL_MBGLMX model)
        {
            return IXZGL_MBGLMXdata.SELECT_LAY(model);
        }
    }
}

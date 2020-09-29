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
    public class XZGL_MBGL
    {
        private static readonly IXZGL_MBGL IXZGL_MBGLdata = HRDataAccess.CreateXZGL_MBGL();
        public MES_RETURN INSERT(HR_XZGL_MBGL model)
        {
            return IXZGL_MBGLdata.INSERT(model);
        }
        public MES_RETURN UPDATE(HR_XZGL_MBGL model, int LB)
        {
            return IXZGL_MBGLdata.UPDATE(model, LB);
        }
        public HR_XZGL_MBGL_SELECT SELECT(HR_XZGL_MBGL model)
        {
            return IXZGL_MBGLdata.SELECT(model);
        }
        public MES_RETURN SELECT_YYCOUNT(HR_XZGL_MBGL model)
        {
            return IXZGL_MBGLdata.SELECT_YYCOUNT(model);
        }
    }
}

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
    public class XZGL_ZDGLGL
    {
        private static readonly IXZGL_ZDGLGL IXZGL_ZDGLGLdata = HRDataAccess.CreateXZGL_ZDGLGL();
        public MES_RETURN INSERT(HR_XZGL_ZDGLGL model)
        {
            return IXZGL_ZDGLGLdata.INSERT(model);
        }
        public MES_RETURN UPDATE(HR_XZGL_ZDGLGL model, int LB)
        {
            return IXZGL_ZDGLGLdata.UPDATE(model, LB);
        }
        public HR_XZGL_ZDGLGL_SELECT SELECT(HR_XZGL_ZDGLGL model)
        {
            return IXZGL_ZDGLGLdata.SELECT(model);
        }
        public MES_RETURN FORMULA_VERIFY_GLZD(string FORMULA, int LB)
        {
            return IXZGL_ZDGLGLdata.FORMULA_VERIFY_GLZD(FORMULA, LB);
        }
    }
}

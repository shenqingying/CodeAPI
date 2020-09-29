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
    public class XZGL_FLDATZ
    {
        private static readonly IXZGL_FLDATZ IXZGL_FLDATZdata = HRDataAccess.CreateXZGL_FLDATZ();
        public MES_RETURN AUTOINSERT(HR_XZGL_FLDATZ model)
        {
            return IXZGL_FLDATZdata.AUTOINSERT(model);
        }
        public HR_XZGL_FLDATZ_SELECT SELECT_REPORT(HR_XZGL_FLDATZ model)
        {
            return IXZGL_FLDATZdata.SELECT_REPORT(model);
        }
        public MES_RETURN UPDATE(HR_XZGL_FLDATZ model, int LB)
        {
            return IXZGL_FLDATZdata.UPDATE(model, LB);
        }
        public MES_RETURN AUTO_ADD_TO_FFJLMX(HR_XZGL_FLDATZ model)
        {
            return IXZGL_FLDATZdata.AUTO_ADD_TO_FFJLMX(model);
        }
    }
}

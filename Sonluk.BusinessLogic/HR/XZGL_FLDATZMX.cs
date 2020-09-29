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
    public class XZGL_FLDATZMX
    {
        private static readonly IXZGL_FLDATZMX IXZGL_FLDATZMXdata = HRDataAccess.CreateXZGL_FLDATZMX();
        public HR_XZGL_FLDATZMX_SELECT_REPORT SELECT_REPORT(HR_XZGL_FLDATZMX model)
        {
            return IXZGL_FLDATZMXdata.SELECT_REPORT(model);
        }
        public HR_XZGL_FLDATZMX_SELECT SELECT(HR_XZGL_FLDATZMX model)
        {
            return IXZGL_FLDATZMXdata.SELECT(model);
        }
        public MES_RETURN UPDATE(HR_XZGL_FLDATZMX model, int LB)
        {
            return IXZGL_FLDATZMXdata.UPDATE(model, LB);
        }
    }
}

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
    public class XZGL_FLFAMX
    {
        private static readonly IXZGL_FLFAMX IXZGL_FLFAMXdata = HRDataAccess.CreateXZGL_FLFAMX();
        public MES_RETURN INSERT(HR_XZGL_FLFAMX model)
        {
            return IXZGL_FLFAMXdata.INSERT(model);
        }
        public MES_RETURN UPDATE(HR_XZGL_FLFAMX model, int LB)
        {
            return IXZGL_FLFAMXdata.UPDATE(model, LB);
        }
        public HR_XZGL_FLFAMX_SELECT SELECT(HR_XZGL_FLFAMX model)
        {
            return IXZGL_FLFAMXdata.SELECT(model);
        }
    }
}

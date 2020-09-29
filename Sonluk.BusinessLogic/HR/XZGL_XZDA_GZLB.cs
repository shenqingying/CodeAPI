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
    public class XZGL_XZDA_GZLB
    {
        private static readonly IXZGL_XZDA_GZLB IXZGL_XZDA_GZLBdata = HRDataAccess.CreateXZGL_XZDA_GZLB();
        public MES_RETURN INSERT(HR_XZGL_XZDA_GZLB model)
        {
            return IXZGL_XZDA_GZLBdata.INSERT(model);
        }
        public MES_RETURN UPDATE(HR_XZGL_XZDA_GZLB model, int LB)
        {
            return IXZGL_XZDA_GZLBdata.UPDATE(model, LB);
        }
        public HR_XZGL_XZDA_GZLB_SELECT SELECT(HR_XZGL_XZDA_GZLB model)
        {
            return IXZGL_XZDA_GZLBdata.SELECT(model);
        }
    }
}

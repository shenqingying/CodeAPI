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
    public class XZGL_FLDA
    {
        private static readonly IXZGL_FLDA IXZGL_FLDAdata = HRDataAccess.CreateXZGL_FLDA();
        public MES_RETURN INSERT(HR_XZGL_FLDA model)
        {
            return IXZGL_FLDAdata.INSERT(model);
        }
        public MES_RETURN UPDATE(HR_XZGL_FLDA model, int LB)
        {
            return IXZGL_FLDAdata.UPDATE(model, LB);
        }
        public HR_XZGL_FLDA_SELECT SELECT(HR_XZGL_FLDA model)
        {
            return IXZGL_FLDAdata.SELECT(model);
        }
    }
}

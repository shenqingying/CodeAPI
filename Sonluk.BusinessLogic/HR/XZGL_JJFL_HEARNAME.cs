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
    public class XZGL_JJFL_HEARNAME
    {
        private static readonly IXZGL_JJFL_HEARNAME IXZGL_JJFL_HEARNAMEdata = HRDataAccess.CreateIXZGL_JJFL_HEARNAME();
        public MES_RETURN INSERT(HR_XZGL_JJFL_HEARNAME model)
        {
            return IXZGL_JJFL_HEARNAMEdata.INSERT(model);
        }
        public MES_RETURN UPDATE(HR_XZGL_JJFL_HEARNAME model, int LB)
        {
            return IXZGL_JJFL_HEARNAMEdata.UPDATE(model, LB);
        }
        public HR_XZGL_JJFL_HEARNAME_SELECT SELECT(HR_XZGL_JJFL_HEARNAME model)
        {
            return IXZGL_JJFL_HEARNAMEdata.SELECT(model);
        }
    }
}

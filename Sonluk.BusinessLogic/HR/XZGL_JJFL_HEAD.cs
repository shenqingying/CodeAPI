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
    public class XZGL_JJFL_HEAD
    {
        private static readonly IXZGL_JJFL_HEAD IXZGL_JJFL_HEADdata = HRDataAccess.CreateIXZGL_JJFL_HEAD();
        public MES_RETURN INSERT(HR_XZGL_JJFL_HEAD model)
        {
            return IXZGL_JJFL_HEADdata.INSERT(model);
        }
        public MES_RETURN UPDATE(HR_XZGL_JJFL_HEAD model, int LB)
        {
            return IXZGL_JJFL_HEADdata.UPDATE(model, LB);
        }
        public HR_XZGL_JJFL_HEAD_SELECT SELECT(HR_XZGL_JJFL_HEAD model)
        {
            return IXZGL_JJFL_HEADdata.SELECT(model);
        }
    }
}

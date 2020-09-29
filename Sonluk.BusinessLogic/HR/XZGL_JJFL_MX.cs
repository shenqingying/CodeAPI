using Sonluk.DAFactory;
using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.HR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.HR
{
    public class XZGL_JJFL_MX
    {
        private static readonly IXZGL_JJFL_MX IXZGL_JJFL_MXdata = HRDataAccess.CreateIXZGL_JJFL_MX();
        public MES_RETURN INSERT(HR_XZGL_JJFL_MX model, DataTable RYLIST)
        {
            return IXZGL_JJFL_MXdata.INSERT(model, RYLIST);
        }
        public MES_RETURN UPDATE(HR_XZGL_JJFL_MX model, int LB)
        {
            return IXZGL_JJFL_MXdata.UPDATE(model, LB);
        }
        public HR_XZGL_JJFL_MX_SELECT SELECT(HR_XZGL_JJFL_MX model)
        {
            return IXZGL_JJFL_MXdata.SELECT(model);
        }
    }
}

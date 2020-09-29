using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface IXZGL_FLDATZMX
    {
        HR_XZGL_FLDATZMX_SELECT_REPORT SELECT_REPORT(HR_XZGL_FLDATZMX model);
        HR_XZGL_FLDATZMX_SELECT SELECT(HR_XZGL_FLDATZMX model);
        MES_RETURN UPDATE(HR_XZGL_FLDATZMX model, int LB);
    }
}

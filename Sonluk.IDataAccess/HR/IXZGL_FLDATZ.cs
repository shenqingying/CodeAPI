using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface IXZGL_FLDATZ
    {
        MES_RETURN AUTOINSERT(HR_XZGL_FLDATZ model);
        HR_XZGL_FLDATZ_SELECT SELECT_REPORT(HR_XZGL_FLDATZ model);
        MES_RETURN UPDATE(HR_XZGL_FLDATZ model, int LB);
        MES_RETURN AUTO_ADD_TO_FFJLMX(HR_XZGL_FLDATZ model);
    }
}

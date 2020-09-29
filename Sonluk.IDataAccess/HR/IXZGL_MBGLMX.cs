using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface IXZGL_MBGLMX
    {
        MES_RETURN INSERT(HR_XZGL_MBGLMX model);
        MES_RETURN UPDATE(HR_XZGL_MBGLMX model, int LB);
        HR_XZGL_MBGLMX_SELECT SELECT(HR_XZGL_MBGLMX model);
        HR_XZGL_MBGLMX_SELECT SELECT_LAY(HR_XZGL_MBGLMX model);
    }
}

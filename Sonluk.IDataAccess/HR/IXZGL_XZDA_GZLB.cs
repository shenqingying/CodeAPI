using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface IXZGL_XZDA_GZLB
    {
        MES_RETURN INSERT(HR_XZGL_XZDA_GZLB model);
        MES_RETURN UPDATE(HR_XZGL_XZDA_GZLB model, int LB);
        HR_XZGL_XZDA_GZLB_SELECT SELECT(HR_XZGL_XZDA_GZLB model);
    }
}

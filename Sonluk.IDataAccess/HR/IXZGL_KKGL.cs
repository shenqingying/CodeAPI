using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface IXZGL_KKGL
    {
        MES_RETURN INSERT(HR_XZGL_KKGL model);
        MES_RETURN AUTOINSERT(HR_XZGL_KKGL model);
        MES_RETURN UPDATE(HR_XZGL_KKGL model, int LB);
        HR_XZGL_KKGL_SELECT SELECT(HR_XZGL_KKGL model);
    }
}

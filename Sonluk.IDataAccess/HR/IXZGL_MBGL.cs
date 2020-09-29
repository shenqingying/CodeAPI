using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface IXZGL_MBGL
    {
        MES_RETURN INSERT(HR_XZGL_MBGL model);
        MES_RETURN UPDATE(HR_XZGL_MBGL model, int LB);
        HR_XZGL_MBGL_SELECT SELECT(HR_XZGL_MBGL model);
        MES_RETURN SELECT_YYCOUNT(HR_XZGL_MBGL model);
    }
}

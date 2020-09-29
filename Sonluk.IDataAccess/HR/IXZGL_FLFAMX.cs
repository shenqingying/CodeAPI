using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface IXZGL_FLFAMX
    {
        MES_RETURN INSERT(HR_XZGL_FLFAMX model);
        MES_RETURN UPDATE(HR_XZGL_FLFAMX model, int LB);
        HR_XZGL_FLFAMX_SELECT SELECT(HR_XZGL_FLFAMX model);
    }
}

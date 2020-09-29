using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface IXZGL_KKGLMX
    {
        MES_RETURN INSERT(HR_XZGL_KKGLMX model);
        MES_RETURN UPDATE(HR_XZGL_KKGLMX model, int LB);
        HR_XZGL_KKGLMX_SELECT SELECT(HR_XZGL_KKGLMX model);
        MES_RETURN AUTO_ADD_TO_FFJLMX(HR_XZGL_KKGLMX model);
    }
}

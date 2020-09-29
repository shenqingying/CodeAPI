using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface IXZGL_XZDA
    {
        MES_RETURN INSERT(HR_XZGL_XZDA model);
        MES_RETURN UPDATE(HR_XZGL_XZDA model, int LB);
        HR_XZGL_XZDA_SELECT SELECT(HR_XZGL_XZDA model);
        HR_XZGL_XZDA_SELECT SELECT_ALL(HR_XZGL_XZDA model, int LB);
        MES_RETURN AUTO_ADD_TO_FFJLMX(HR_XZGL_XZDA model);
    }
}

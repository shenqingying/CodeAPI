using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface IXZGL_FFJL
    {
        MES_RETURN INSERT(HR_XZGL_FFJL model);
        HR_XZGL_FFJL_SELECT SELECT(HR_XZGL_FFJL model, int LB);
        MES_RETURN UPDATE(HR_XZGL_FFJL model, int LB);
        HR_XZGL_FFJL_SELECT SELECT_ISFFNOWCOUNT();
        MES_RETURN ZQMONTH_UPDATE(HR_XZGL_FFJL model);
        HR_XZGL_FFJL_SELECT ZQMONTH_SELECT(HR_XZGL_FFJL model);
        HR_XZGL_FFJL_SELECT ZQMONTH_SELECT_LB(HR_XZGL_FFJL model);
    }
}

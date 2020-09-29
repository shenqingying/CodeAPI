using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface ISY_MYINFO
    {
        MES_RETURN JM_ISTRUE(string MYPW, int STAFFID, int LB);
        MES_RETURN INSERT(HR_SY_MYINFO model);
        HR_SY_MYINFO_SELECT SELECT_REPORT(HR_SY_MYINFO model);
        MES_RETURN UPDATE(HR_SY_MYINFO model, int LB);
        HR_SY_MYINFO_SELECT SELECT(HR_SY_MYINFO model, int LB);
    }
}

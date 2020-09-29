using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface IRY_BANKNO
    {
        MES_RETURN INSERT(HR_RY_BANKNO model);
        MES_RETURN UPDATE(HR_RY_BANKNO model, int LB);
        HR_RY_BANKNO_SELECT SELECT(HR_RY_BANKNO model);
    }
}

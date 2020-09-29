using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface IROLE_DEPT
    {
        MES_RETURN INSERT(HR_ROLE_DEPT model);
        MES_RETURN UPDATE(HR_ROLE_DEPT model, int LB);
        HR_ROLE_DEPT_SELECT SELECT(HR_ROLE_DEPT model);
    }
}

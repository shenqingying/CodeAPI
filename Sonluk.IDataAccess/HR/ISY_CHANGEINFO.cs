using Sonluk.Entities.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface ISY_CHANGEINFO
    {
        HR_SY_CHANGEINFO_SELECT SELECT(HR_SY_CHANGEINFO model);
    }
}

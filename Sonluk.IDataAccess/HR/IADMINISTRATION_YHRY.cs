using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface IADMINISTRATION_YHRY
    {
        MES_RETURN INSERT(HR_ADMINISTRATION_YHRY model);
        MES_RETURN UPDATE(HR_ADMINISTRATION_YHRY model);
        HR_ADMINISTRATION_YHRY_SELECT SELECT(HR_ADMINISTRATION_YHRY model);
    }
}

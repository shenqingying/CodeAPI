using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface ISY_DUTY
    {
        MES_RETURN INSERT(HR_SY_DUTY model);
        MES_RETURN DELETE(HR_SY_DUTY model);
        MES_RETURN UPDATE(HR_SY_DUTY model);
        HR_SY_DUTY_SELECT SELECT(HR_SY_DUTY model);
    }
}

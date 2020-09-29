using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface ISY_GS
    {
        MES_RETURN INSERT(HR_SY_GS model);
        MES_RETURN DELETE(HR_SY_GS model);
        MES_RETURN UPDATE(HR_SY_GS model);
        HR_SY_GS_SELECT SELECT(HR_SY_GS model);
        MES_RETURN UPDATE_YYZZ(HR_SY_GS model);
        HR_SY_GS_LAY_SELECT SELECT_GS_ROLE_LAY(int STAFFID);
        MES_RETURN DELETE_GS_ROLE_LAY(int STAFFID);
        MES_RETURN INSERT_GS_ROLE_LAY(HR_SY_GS_LAY model);
        HR_SY_GS_SELECT SELECT_BY_ROLE(int STAFFID);
    }
}

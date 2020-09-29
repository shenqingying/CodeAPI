using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface ISY_ZJH
    {
        MES_RETURN INSERT(HR_SY_ZJH model);
        HR_SY_ZJH_SELECT SELECT(HR_SY_ZJH model);
        MES_RETURN UPDATE(HR_SY_ZJH model);
        MES_RETURN DELETE(int ZJHID);
        HR_SY_ZJH_LAY_SELECT SELECT_ZJH_LAY(int ZJHID, string GS);
        MES_RETURN DELETE_ZJH_LAY(int ZJHID);
        MES_RETURN INSERT_ZJH_LAY(HR_SY_ZJH_LAY model);
        HR_SY_ZJH_LAY_SELECT SELECT_ZJH_ROLE_LAY(int STAFFID);
        MES_RETURN DELETE_ZJH_ROLE_LAY(int STAFFID);
        MES_RETURN INSERT_ZJH_ROLE_LAY(HR_SY_ZJH_LAY model);
        HR_SY_ZJH_LAY_SELECT SELECT_BY_ROLE(int STAFFID, string GS);
    }
}

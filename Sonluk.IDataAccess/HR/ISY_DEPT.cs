using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface ISY_DEPT
    {
        MES_RETURN INSERT(HR_SY_DEPT model);
        MES_RETURN DELETE(HR_SY_DEPT model);
        MES_RETURN UPDATE(HR_SY_DEPT model);
        HR_SY_DEPT_SELECT SELECT(HR_SY_DEPT model);
        HR_SY_DEPT_SELECT SELECT_LB(HR_SY_DEPT model, int LB);
        HR_SY_DEPT_SELECT ReadByStaffidForFives(int staffid);
        HR_SY_DEPT_SELECT SELECT_BY_ROLE(HR_SY_DEPT model, int LB);
        HR_SY_DEPT_SELECT SELECT_RYCOUNT(int DEPTID);
        HR_SY_DEPT_SELECT SELECT_BY_ROLE_LD(HR_SY_DEPT model);
        MES_RETURN UPDATE_FID(int DEPTID, int FID, int STAFFID);
    }
}

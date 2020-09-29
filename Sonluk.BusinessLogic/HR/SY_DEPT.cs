using Sonluk.DAFactory;
using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.HR
{
    public class SY_DEPT
    {
        private static readonly ISY_DEPT ISY_DEPTdata = HRDataAccess.CreateSY_DEPT();
        public MES_RETURN INSERT(HR_SY_DEPT model)
        {
            return ISY_DEPTdata.INSERT(model);
        }
        public HR_SY_DEPT_SELECT SELECT(HR_SY_DEPT model)
        {
            return ISY_DEPTdata.SELECT(model);
        }
        public HR_SY_DEPT_SELECT SELECT_LB(HR_SY_DEPT model, int LB)
        {
            return ISY_DEPTdata.SELECT_LB(model, LB);
        }
        public MES_RETURN UPDATE(HR_SY_DEPT model)
        {
            return ISY_DEPTdata.UPDATE(model);
        }
        public MES_RETURN DELETE(HR_SY_DEPT model)
        {
            return ISY_DEPTdata.DELETE(model);
        }
        public HR_SY_DEPT_SELECT SELECT_BY_ROLE(HR_SY_DEPT model, int LB)
        {
            return ISY_DEPTdata.SELECT_BY_ROLE(model, LB);
        }
        public HR_SY_DEPT_SELECT SELECT_RYCOUNT(int DEPTID)
        {
            return ISY_DEPTdata.SELECT_RYCOUNT(DEPTID);
        }
        public HR_SY_DEPT_SELECT SELECT_BY_ROLE_LD(HR_SY_DEPT model)
        {
            return ISY_DEPTdata.SELECT_BY_ROLE_LD(model);
        }
        public MES_RETURN UPDATE_FID(int DEPTID, int FID, int STAFFID)
        {
            return ISY_DEPTdata.UPDATE_FID(DEPTID, FID, STAFFID);
        }
    }
}

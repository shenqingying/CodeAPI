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
    public class ROLE_DEPT
    {
        private static readonly IROLE_DEPT IROLE_DEPTdata = HRDataAccess.CreateROLE_DEPT();
        public MES_RETURN INSERT(HR_ROLE_DEPT model)
        {
            return IROLE_DEPTdata.INSERT(model);
        }
        public MES_RETURN UPDATE(HR_ROLE_DEPT model, int LB)
        {
            return IROLE_DEPTdata.UPDATE(model, LB);
        }
        public HR_ROLE_DEPT_SELECT SELECT(HR_ROLE_DEPT model)
        {
            return IROLE_DEPTdata.SELECT(model);
        }
    }
}

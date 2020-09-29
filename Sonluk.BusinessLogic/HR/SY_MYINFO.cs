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
    public class SY_MYINFO
    {
        private static readonly ISY_MYINFO ISY_MYINFOdata = HRDataAccess.CreateSY_MYINFO();
        public MES_RETURN JM_ISTRUE(string MYPW, int STAFFID, int LB)
        {
            return ISY_MYINFOdata.JM_ISTRUE(MYPW, STAFFID, LB);
        }
        public MES_RETURN INSERT(HR_SY_MYINFO model)
        {
            return ISY_MYINFOdata.INSERT(model);
        }
        public HR_SY_MYINFO_SELECT SELECT_REPORT(HR_SY_MYINFO model)
        {
            return ISY_MYINFOdata.SELECT_REPORT(model);
        }
        public MES_RETURN UPDATE(HR_SY_MYINFO model, int LB)
        {
            return ISY_MYINFOdata.UPDATE(model, LB);
        }
        public HR_SY_MYINFO_SELECT SELECT(HR_SY_MYINFO model, int LB)
        {
            return ISY_MYINFOdata.SELECT(model, LB);
        }
    }
}

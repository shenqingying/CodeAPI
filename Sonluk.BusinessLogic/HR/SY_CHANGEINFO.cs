using Sonluk.DAFactory;
using Sonluk.Entities.HR;
using Sonluk.IDataAccess.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.HR
{
    public class SY_CHANGEINFO
    {
        private static readonly ISY_CHANGEINFO ISY_CHANGEINFOdata = HRDataAccess.CreateISY_CHANGEINFO();
        public HR_SY_CHANGEINFO_SELECT SELECT(HR_SY_CHANGEINFO model)
        {
            return ISY_CHANGEINFOdata.SELECT(model);
        }
    }
}

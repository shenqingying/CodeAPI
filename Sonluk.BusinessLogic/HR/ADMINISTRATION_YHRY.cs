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
    public class ADMINISTRATION_YHRY
    {
        private static readonly IADMINISTRATION_YHRY IADMINISTRATION_YHRYdata = HRDataAccess.CreateIADMINISTRATION_YHRY();
        public MES_RETURN INSERT(HR_ADMINISTRATION_YHRY model)
        {
            return IADMINISTRATION_YHRYdata.INSERT(model);
        }
        public MES_RETURN UPDATE(HR_ADMINISTRATION_YHRY model)
        {
            return IADMINISTRATION_YHRYdata.UPDATE(model);
        }
        public HR_ADMINISTRATION_YHRY_SELECT SELECT(HR_ADMINISTRATION_YHRY model)
        {
            return IADMINISTRATION_YHRYdata.SELECT(model);
        }
    }
}

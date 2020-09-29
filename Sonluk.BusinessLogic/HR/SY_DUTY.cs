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
    public class SY_DUTY
    {
        private static readonly ISY_DUTY ISY_DUTYdata = HRDataAccess.CreateSY_DUTY();
        public MES_RETURN INSERT(HR_SY_DUTY model)
        {
            return ISY_DUTYdata.INSERT(model);
        }
        public HR_SY_DUTY_SELECT SELECT(HR_SY_DUTY model)
        {
            return ISY_DUTYdata.SELECT(model);
        }
        public MES_RETURN UPDATE(HR_SY_DUTY model)
        {
            return ISY_DUTYdata.UPDATE(model);
        }
        public MES_RETURN DELETE(HR_SY_DUTY model)
        {
            return ISY_DUTYdata.DELETE(model);
        }
    }
}

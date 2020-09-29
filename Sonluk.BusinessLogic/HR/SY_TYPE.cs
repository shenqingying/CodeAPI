using Sonluk.DAFactory;
using Sonluk.Entities.HR;
using Sonluk.IDataAccess.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.HR
{
    public class SY_TYPE
    {
        private static readonly ISY_TYPE ISY_TYPEdata = HRDataAccess.CreateSY_TYPE();
        public HR_SY_TYPE_SELECT SELECT()
        {
            return ISY_TYPEdata.SELECT();
        }
    }
}

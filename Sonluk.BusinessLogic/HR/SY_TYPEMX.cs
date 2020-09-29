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
    public class SY_TYPEMX
    {
        private static readonly ISY_TYPEMX ISY_TYPEMXdata = HRDataAccess.CreateSY_TYPEMX();
        public MES_RETURN INSERT(HR_SY_TYPEMX model)
        {
            return ISY_TYPEMXdata.INSERT(model);
        }
        public MES_RETURN DELETE(HR_SY_TYPEMX model)
        {
            return ISY_TYPEMXdata.DELETE(model);
        }
        public MES_RETURN UPDATE(HR_SY_TYPEMX model)
        {
            return ISY_TYPEMXdata.UPDATE(model);
        }
        public HR_SY_TYPEMX_SELECT SELECT(HR_SY_TYPEMX model)
        {
            return ISY_TYPEMXdata.SELECT(model);
        }
    }
}

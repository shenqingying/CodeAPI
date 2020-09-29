using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface ISY_TYPEMX
    {
        MES_RETURN INSERT(HR_SY_TYPEMX model);
        MES_RETURN DELETE(HR_SY_TYPEMX model);
        MES_RETURN UPDATE(HR_SY_TYPEMX model);
        HR_SY_TYPEMX_SELECT SELECT(HR_SY_TYPEMX model);
    }
}

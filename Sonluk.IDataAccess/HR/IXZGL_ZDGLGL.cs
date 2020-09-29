using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface IXZGL_ZDGLGL
    {
        MES_RETURN INSERT(HR_XZGL_ZDGLGL model);
        MES_RETURN UPDATE(HR_XZGL_ZDGLGL model, int LB);
        HR_XZGL_ZDGLGL_SELECT SELECT(HR_XZGL_ZDGLGL model);
        MES_RETURN FORMULA_VERIFY_GLZD(string FORMULA, int LB);
    }
}

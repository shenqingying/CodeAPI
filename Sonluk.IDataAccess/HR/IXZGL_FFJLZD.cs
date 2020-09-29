using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface IXZGL_FFJLZD
    {
        MES_RETURN INSERT(HR_XZGL_FFJLZD model);
        HR_XZGL_FFJLZD_SELECT SELECT(HR_XZGL_FFJLZD model);
        MES_RETURN GS_FORMULA_VERIFY(string FORMULA);
        HR_XZGL_FFJLZD_YYTABLE_SELECT SELECT_YYTABLE(HR_XZGL_FFJLZD_YYTABLE model);
        HR_XZGL_FFJLZD_YYTABLEZD_SELECT SELECT_YYTABLEZD(HR_XZGL_FFJLZD_YYTABLEZD model);
        MES_RETURN UPDATE(HR_XZGL_FFJLZD model, int LB);
        MES_RETURN INSERT_YYTABLEZD(HR_XZGL_FFJLZD_YYTABLEZD model);
        MES_RETURN UPDATE_YYTABLEZD(HR_XZGL_FFJLZD_YYTABLEZD model, int LB);
    }
}

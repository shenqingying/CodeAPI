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
    public class XZGL_FFJLZD
    {
        private static readonly IXZGL_FFJLZD IXZGL_FFJLZDdata = HRDataAccess.CreateXZGL_FFJLZD();
        public MES_RETURN INSERT(HR_XZGL_FFJLZD model)
        {
            return IXZGL_FFJLZDdata.INSERT(model);
        }
        public HR_XZGL_FFJLZD_SELECT SELECT(HR_XZGL_FFJLZD model)
        {
            return IXZGL_FFJLZDdata.SELECT(model);
        }
        public MES_RETURN GS_FORMULA_VERIFY(string FORMULA)
        {
            return IXZGL_FFJLZDdata.GS_FORMULA_VERIFY(FORMULA);
        }
        public HR_XZGL_FFJLZD_YYTABLE_SELECT SELECT_YYTABLE(HR_XZGL_FFJLZD_YYTABLE model)
        {
            return IXZGL_FFJLZDdata.SELECT_YYTABLE(model);
        }
        public HR_XZGL_FFJLZD_YYTABLEZD_SELECT SELECT_YYTABLEZD(HR_XZGL_FFJLZD_YYTABLEZD model)
        {
            return IXZGL_FFJLZDdata.SELECT_YYTABLEZD(model);
        }
        public MES_RETURN UPDATE(HR_XZGL_FFJLZD model, int LB)
        {
            return IXZGL_FFJLZDdata.UPDATE(model, LB);
        }
        public MES_RETURN INSERT_YYTABLEZD(HR_XZGL_FFJLZD_YYTABLEZD model)
        {
            return IXZGL_FFJLZDdata.INSERT_YYTABLEZD(model);
        }
        public MES_RETURN UPDATE_YYTABLEZD(HR_XZGL_FFJLZD_YYTABLEZD model, int LB)
        {
            return IXZGL_FFJLZDdata.UPDATE_YYTABLEZD(model, LB);
        }
    }
}

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
    public class XZGL_ZXFJKC
    {
        private static readonly IXZGL_ZXFJKC IXZGL_ZXFJKCdata = HRDataAccess.CreateXZGL_ZXFJKC();
        public MES_RETURN INSERT(HR_XZGL_ZXFJKC model)
        {
            return IXZGL_ZXFJKCdata.INSERT(model);
        }
        public MES_RETURN UPDATE(HR_XZGL_ZXFJKC model, int LB)
        {
            return IXZGL_ZXFJKCdata.UPDATE(model, LB);
        }
        public HR_XZGL_ZXFJKC_SELECT SELECT(HR_XZGL_ZXFJKC model)
        {
            return IXZGL_ZXFJKCdata.SELECT(model);
        }
        public MES_RETURN AUTO_ADD_TO_FFJLMX(HR_XZGL_ZXFJKC model)
        {
            return IXZGL_ZXFJKCdata.AUTO_ADD_TO_FFJLMX(model);
        }
    }
}

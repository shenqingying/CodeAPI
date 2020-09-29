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
    public class BOOK_BOOKINFO
    {
        private static readonly IBOOK_BOOKINFO IBOOK_BOOKINFOdata = HRDataAccess.CreateIBOOK_BOOKINFO();
        public MES_RETURN INSERT_BOOKINFO(HR_BOOK_BOOKINFO model)
        {
            return IBOOK_BOOKINFOdata.INSERT_BOOKINFO(model);
        }
        public HR_BOOK_BOOKINFO_SELECT SELECT_BOOKINFO(HR_BOOK_BOOKINFO model)
        {
            return IBOOK_BOOKINFOdata.SELECT_BOOKINFO(model);
        }
        public MES_RETURN UPDATE_BOOKINFO(HR_BOOK_BOOKINFO model)
        {
            return IBOOK_BOOKINFOdata.UPDATE_BOOKINFO(model);
        }
        public MES_RETURN LOGOUT_BOOKINFO(HR_BOOK_BOOKINFO model)
        {
            return IBOOK_BOOKINFOdata.LOGOUT_BOOKINFO(model);
        }
        public MES_RETURN JY_BOOK(HR_BOOK_BOOKINFO model)
        {
            return IBOOK_BOOKINFOdata.JY_BOOK(model);
        }
        public MES_RETURN GH_BOOK(HR_BOOK_BOOKINFO model)
        {
            return IBOOK_BOOKINFOdata.GH_BOOK(model);
        }
        public HR_BOOK_BOOKINFO_SELECT SELECT_BOOK_LOOK(HR_BOOK_BOOKINFO model)
        {
            return IBOOK_BOOKINFOdata.SELECT_BOOK_LOOK(model);
        }
        public HR_BOOK_BOOKINFO_SELECT SELECT_BOOK_LOOK_JY(HR_BOOK_BOOKINFO model)
        {
            return IBOOK_BOOKINFOdata.SELECT_BOOK_LOOK_JY(model);
        }
    }
}

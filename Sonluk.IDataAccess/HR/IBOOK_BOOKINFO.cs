using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.HR
{
    public interface IBOOK_BOOKINFO
    {
        MES_RETURN INSERT_BOOKINFO(HR_BOOK_BOOKINFO model);
        HR_BOOK_BOOKINFO_SELECT SELECT_BOOKINFO(HR_BOOK_BOOKINFO model);
        MES_RETURN UPDATE_BOOKINFO(HR_BOOK_BOOKINFO model);
        MES_RETURN LOGOUT_BOOKINFO(HR_BOOK_BOOKINFO model);
        MES_RETURN JY_BOOK(HR_BOOK_BOOKINFO model);
        MES_RETURN GH_BOOK(HR_BOOK_BOOKINFO model);
        HR_BOOK_BOOKINFO_SELECT SELECT_BOOK_LOOK(HR_BOOK_BOOKINFO model);
        HR_BOOK_BOOKINFO_SELECT SELECT_BOOK_LOOK_JY(HR_BOOK_BOOKINFO model);
    }
}

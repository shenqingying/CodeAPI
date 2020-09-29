using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IBAT_QLTY
    {
        MES_ZLRBB_SELECT SELECT(MES_ZLRBB_SEARCH model);
        MES_ZLRBB_SELECT SELECT_SUM(MES_ZLRBB_SEARCH model);
        MES_RETURN COVER(MES_ZLRBB model);
        MES_RETURN COVER_TMARK(MES_ZLRBB model);
        MES_RETURN ACTION(int RI);
        MES_RETURN DELETE(int RI, int STAFFID);
        MES_RETURN DELETE_TMARK(int RI);
    }
}

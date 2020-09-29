using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IBAT_QLTY_TMARK
    {
        MES_ZLRBB_SELECT SELECT_SUM(MES_ZLRBB_SEARCH model);
        MES_RETURN COVER(MES_ZLRBB model);
    }
}

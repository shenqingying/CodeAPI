using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IBAT_QLTY_STAFF
    {
        MES_SELECT<MES_ZLRBB_STAFF> SELECT(MES_ZLRBB_STAFF model);
        MES_RETURN COVER(MES_ZLRBB_STAFF model);
        MES_RETURN DELETE(int ID);
    }
}

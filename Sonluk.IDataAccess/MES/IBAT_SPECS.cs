using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IBAT_SPECS
    {
        MES_DCBZ_SELECT SELECT_SPECS(MES_DCBZ model);
        MES_DCBZ_SELECT SELECT_PERFOR(MES_DCBZ model);
        MES_DCBZ_SELECT SELECT_LIST(MES_DCBZ model);
        MES_DCBZ_SELECT SELECT_LIST_LEFT(string DCXH);
        MES_RETURN INSERT_SPECS(MES_DCBZ model);
        MES_RETURN INSERT_PERFOR(MES_DCBZ model);
        MES_RETURN DELETE(string DCXH);
        MES_RETURN DELETE_WITH_CHECK(string DCXH);
        MES_RETURN UPDATE_SPECS_CHECK(MES_DCBZ model);
    }
}

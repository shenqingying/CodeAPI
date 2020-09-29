using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IBAT_PACKAGE
    {
        MES_PD_GD_PACKINFO_SELECT SELECT_ERPINFO(MES_PD_GD_PACKINFO_SEARCH model, string WLLBNAME = "");
        MES_PD_GD_PACKINFO SELECT_SINGLE(string GDDH);
        MES_RETURN COVER(MES_PD_GD_PACKINFO model);
        MES_RETURN DELETE(string GDDH);
    }
}

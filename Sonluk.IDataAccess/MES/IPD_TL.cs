using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IPD_TL
    {
        MES_RETURN INSERT(MES_PD_TL model);
        MES_RETURN DELETE(MES_PD_TL_DELETE_IN model);
        MES_PD_TL SELECT_FJTL(string RWBH);
        MES_PD_TL_SELECT SELECT(MES_PD_TL model);
        MES_RETURN UPDATE_TLTMTH(MES_PD_TL_UPDATE_TLTMTH_IN model);
        MES_PD_TL_SELECT_REPORT SELECT_REPORT(MES_PD_TL_IN_SELECT_REPORT model);
    }
}

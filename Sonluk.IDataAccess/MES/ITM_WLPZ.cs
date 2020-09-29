using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface ITM_WLPZ
    {
        MES_TM_WLPZ_SELECT SELECT(MES_TM_WLPZ model);
        MES_RETURN INSERT(MES_TM_WLPZ model);
    }
}

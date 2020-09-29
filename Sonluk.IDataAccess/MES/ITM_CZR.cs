using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface ITM_CZR
    {
        MES_RETURN INSERT(MES_TM_CZR model);
        MES_TM_CZR_SELECT_CZR_NOW SELECT_CZR_NOW(MES_TM_CZR model);
        MES_RETURN UPDATE_LEAVE(int ID);
        MES_RETURN UPDATE_GW(MES_TM_CZR model);
    }
}

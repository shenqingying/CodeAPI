using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface ISY_PLDH_PH
    {
        MES_RETURN INSERT(MES_SY_PLDH_PH model);
        MES_SY_PLDH_PH_SELECT SELECT(MES_SY_PLDH_PH model);
        MES_SY_PLDH_PH_SELECT SELECT_LB(MES_SY_PLDH_PH model);
    }
}

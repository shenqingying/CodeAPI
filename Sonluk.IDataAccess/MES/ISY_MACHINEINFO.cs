using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface ISY_MACHINEINFO
    {
        MES_SY_MACHINEINFO insert(MES_SY_MACHINEINFO model);
        MES_SY_MACHINEINFO_SELECT SELECT(MES_SY_MACHINEINFO model);
        MES_SY_MACHINEINFO_SELECTBBXX SELECT_BBXX(MES_SY_MACHINEINFO_BBXX model);
    }
}

using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class SY_MACHINEINFO
    {
        private static readonly ISY_MACHINEINFO mesdetaAccess = MESDataAccess.CreateSY_MACHINEINFO();

        public MES_SY_MACHINEINFO insert(MES_SY_MACHINEINFO model)
        {
            return mesdetaAccess.insert(model);
        }

        public MES_SY_MACHINEINFO_SELECT SELECT(MES_SY_MACHINEINFO model)
        {
            return mesdetaAccess.SELECT(model);
        }

        public MES_SY_MACHINEINFO_SELECTBBXX SELECT_BBXX(MES_SY_MACHINEINFO_BBXX model)
        {
            return mesdetaAccess.SELECT_BBXX(model);
        }
    }
}

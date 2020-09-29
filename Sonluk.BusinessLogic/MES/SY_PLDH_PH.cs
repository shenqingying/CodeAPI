using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class SY_PLDH_PH
    {
        private static readonly ISY_PLDH_PH mesdetaAccess = MESDataAccess.CreateSY_PLDH_PH();
        public MES_RETURN INSERT(MES_SY_PLDH_PH model)
        {
            return mesdetaAccess.INSERT(model);
        }
        public MES_SY_PLDH_PH_SELECT SELECT(MES_SY_PLDH_PH model)
        {
            return mesdetaAccess.SELECT(model);
        }
        public MES_SY_PLDH_PH_SELECT SELECT_LB(MES_SY_PLDH_PH model)
        {
            return mesdetaAccess.SELECT_LB(model);
        }
    }
}

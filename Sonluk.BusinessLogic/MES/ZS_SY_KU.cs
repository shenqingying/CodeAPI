using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class ZS_SY_KU
    {
        private static readonly IZS_SY_KU data_IZS_SY_KU = MESDataAccess.CreateIZS_SY_KU();
        public MES_RETURN INSERT(MES_ZS_SY_KU model)
        {
            return data_IZS_SY_KU.INSERT(model);
        }
        public MES_RETURN UPDATE(MES_ZS_SY_KU model)
        {
            return data_IZS_SY_KU.UPDATE(model);
        }
        public MES_ZS_SY_KU_SELECT SELECT(MES_ZS_SY_KU model)
        {
            return data_IZS_SY_KU.SELECT(model);
        }
    }
}

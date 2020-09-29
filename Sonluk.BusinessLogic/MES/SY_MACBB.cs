using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class SY_MACBB
    {
        private static readonly ISY_MACBB mesdetaAccess = MESDataAccess.CreateSY_MACBB();
        public MES_RETURN INSERT(MES_SY_MACBB model)
        {
            return mesdetaAccess.INSERT(model);
        }
    }
}

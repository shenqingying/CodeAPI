using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class SY_YERACOUNT
    {
        private static readonly ISY_YERACOUNT mesdetaAccess = MESDataAccess.CreateSY_YERACOUNT();
        public string SELECT(MES_SY_YERACOUNT model)
        {
            return mesdetaAccess.SELECT(model);
        }
    }
}

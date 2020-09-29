using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class SY_TYPE
    {
        private static readonly ISY_TYPE mesdetaAccess = MESDataAccess.CreateSY_TYPE();
        public IList<MES_SY_TYPE> SELECT()
        {
            return mesdetaAccess.SELECT();
        }
    }
}

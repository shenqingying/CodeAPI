using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class SY_CHANGEINFO
    {
        private static readonly ISY_CHANGEINFO mesdetaAccess = MESDataAccess.CreateSY_CHANGEINFO();
        public MES_SY_CHANGEINFO_SELECT SELECT(MES_SY_CHANGEINFOLIST model)
        {
            return mesdetaAccess.SELECT(model);
        }

    }
}

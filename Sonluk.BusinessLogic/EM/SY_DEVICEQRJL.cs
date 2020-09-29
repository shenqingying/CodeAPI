using Sonluk.DAFactory;
using Sonluk.Entities.EM;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.EM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.EM
{
    public class SY_DEVICEQRJL
    {
        private static readonly ISY_DEVICEQRJL _DataAccess = RMSDataAccess.CreateEMSY_DEVICEQRJL();
        public MES_RETURN Create(EM_SY_DEVICEQRJL model)
        {
            return _DataAccess.Create(model);
        }

        public IList<EM_SY_DEVICEQRJL> Read(EM_SY_DEVICEQRJL model)
        {
            return _DataAccess.Read(model);
        }
    }
}

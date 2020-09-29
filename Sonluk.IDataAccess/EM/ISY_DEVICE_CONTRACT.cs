using Sonluk.Entities.EM;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.EM
{
    public interface ISY_DEVICE_CONTRACT
    {
        MES_RETURN Create(EM_SY_DEVICE_CONTRACT model);
        IList<EM_SY_DEVICE_CONTRACT> Read(EM_SY_DEVICE_CONTRACT model);
        MES_RETURN Delete(EM_SY_DEVICE_CONTRACT model);
    }
}

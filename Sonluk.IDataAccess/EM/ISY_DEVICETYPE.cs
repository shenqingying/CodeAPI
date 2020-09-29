using Sonluk.Entities.EM;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.EM
{
    public interface ISY_DEVICETYPE
    {
        MES_RETURN Create(EM_SY_DEVICETYPE model);
        MES_RETURN Update(EM_SY_DEVICETYPE model);
        IList<EM_SY_DEVICETYPE> Read(EM_SY_DEVICETYPE model);
        MES_RETURN Delete(int MANUALID);
    }
}

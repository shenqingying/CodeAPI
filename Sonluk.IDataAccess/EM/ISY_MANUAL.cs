using Sonluk.Entities.EM;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.EM
{
    public interface ISY_MANUAL
    {
        MES_RETURN Create(EM_SY_MANUAL model);
        MES_RETURN Update(EM_SY_MANUAL model);
        IList<EM_SY_MANUAL> Read(EM_SY_MANUAL model);
        MES_RETURN Delete(int MANUALID);
    }
}

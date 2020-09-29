using Sonluk.Entities.EM;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.EM
{
    public interface ISY_SBBHDEVICETYPE
    {
        MES_RETURN Create(EM_SY_SBBHDEVICETYPE model);

        IList<EM_SY_SBBHDEVICETYPELIST> Read(EM_SY_SBBHDEVICETYPE model);
        MES_RETURN Delete(EM_SY_SBBHDEVICETYPE model);
    }
}

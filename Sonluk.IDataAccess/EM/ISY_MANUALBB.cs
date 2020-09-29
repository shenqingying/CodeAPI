using Sonluk.Entities.EM;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.EM
{
    public interface ISY_MANUALBB
    {
        MES_RETURN Create(EM_SY_MANUALBB model);
        MES_RETURN Update(EM_SY_MANUALBB model);
        IList<EM_SY_MANUALBB> Read(EM_SY_MANUALBB model);
        MES_RETURN Delete(int BBID);
    }
}

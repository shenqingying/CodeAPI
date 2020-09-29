using Sonluk.Entities.EM;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.EM
{
    public interface ISY_MANUALPATH
    {
        MES_RETURN Create(EM_SY_MANUALPATH model);
        MES_RETURN Update(EM_SY_MANUALPATH model);
        IList<EM_SY_MANUALPATH> Read(EM_SY_MANUALPATH model);
        MES_RETURN Delete(int ID);
    }
}

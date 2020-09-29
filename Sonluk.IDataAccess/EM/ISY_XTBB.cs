using Sonluk.Entities.EM;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.EM
{
    public interface ISY_XTBB
    {
        MES_RETURN Create(EM_SY_XTBB model);
        MES_RETURN Update(EM_SY_XTBB model);
        IList<EM_SY_XTBB> Read(EM_SY_XTBB model);
        MES_RETURN Delete(int BBID);
    }
}

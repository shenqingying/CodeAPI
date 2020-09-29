using Sonluk.Entities.EM;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.EM
{
    public interface ISY_PB
    {
        MES_RETURN Create(EM_SY_PB model);
        MES_RETURN Update(EM_SY_PB model);
        IList<EM_SY_PB> Read(EM_SY_PB model);
        MES_RETURN Delete(int PBID);
    }
}

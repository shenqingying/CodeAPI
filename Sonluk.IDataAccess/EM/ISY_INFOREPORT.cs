using Sonluk.Entities.EM;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.EM
{
    public interface ISY_INFOREPORT
    {
        MES_RETURN Create(EM_SY_INFOREPORT model);
        //MES_RETURN Update(EM_SY_INFOREPORTList model);
        IList<EM_SY_INFOREPORT> Read(EM_SY_INFOREPORTList model);
        MES_RETURN Delete(int id);
    }
}

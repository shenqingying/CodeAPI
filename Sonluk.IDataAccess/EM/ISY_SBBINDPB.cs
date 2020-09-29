using Sonluk.Entities.EM;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.EM
{
    public interface ISY_SBBINDPB
    {
        MES_RETURN Create(EM_SY_SBBINDPB model);
        MES_RETURN Update(EM_SY_SBBINDPB model);
        IList<EM_SY_SBBINDPB> Read(EM_SY_SBBINDPB model);
        MES_RETURN Delete(EM_SY_SBBINDPB model);
    }
}

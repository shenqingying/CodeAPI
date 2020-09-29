using Sonluk.Entities.EM;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.EM
{
    public interface ISY_STAFFIDBINDPB
    {
        MES_RETURN Create(EM_SY_STAFFIDBINDPB model);
        MES_RETURN Update(EM_SY_STAFFIDBINDPB model);
        IList<EM_SY_STAFFIDBINDPB> Read(EM_SY_STAFFIDBINDPB model);
        MES_RETURN Delete(EM_SY_STAFFIDBINDPB model);
    }
}

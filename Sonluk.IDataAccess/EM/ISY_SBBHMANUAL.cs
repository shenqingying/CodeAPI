using Sonluk.Entities.EM;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.EM
{
    public interface ISY_SBBHMANUAL
    {
        MES_RETURN Create(EM_SY_SBBHMANUAL model);
        MES_RETURN Update(EM_SY_SBBHMANUAL model);
        IList<EM_SY_SBBHMANUAL> Read(EM_SY_SBBHMANUAL model);
        MES_RETURN Delete(EM_SY_SBBHMANUAL model);
    }
}

using Sonluk.Entities.EM;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.EM
{
    public interface ISY_DEVICEQRJL
    {
        MES_RETURN Create(EM_SY_DEVICEQRJL model);

        IList<EM_SY_DEVICEQRJL> Read(EM_SY_DEVICEQRJL model);
    }
}

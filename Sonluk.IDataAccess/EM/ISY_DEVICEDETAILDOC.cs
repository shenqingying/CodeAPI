using Sonluk.Entities.EM;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.EM
{
    public interface ISY_DEVICEDETAILDOC
    {
        MES_RETURN Create(EM_SY_DEVICEDETAILDOC model);
        MES_RETURN Update(EM_SY_DEVICEDETAILDOC model);
        IList<EM_SY_DEVICEDETAILDOC> Read(EM_SY_DEVICEDETAILDOC model);
        MES_RETURN Delete(int MANUALID);
    }
}

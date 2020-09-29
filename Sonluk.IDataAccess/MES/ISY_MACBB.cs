using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface ISY_MACBB
    {
        MES_RETURN INSERT(MES_SY_MACBB model);
    }
}

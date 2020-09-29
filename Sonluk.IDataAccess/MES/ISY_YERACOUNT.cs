using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface ISY_YERACOUNT
    {
        string SELECT(MES_SY_YERACOUNT model);
    }
}

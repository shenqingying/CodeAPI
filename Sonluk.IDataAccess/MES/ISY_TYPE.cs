using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface ISY_TYPE
    {
        IList<MES_SY_TYPE> SELECT();
    }
}

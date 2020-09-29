using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface ISY_CHANGEINFO
    {
        MES_RETURN INSERT(MES_SY_CHANGEINFO model);
        MES_SY_CHANGEINFO_SELECT SELECT(MES_SY_CHANGEINFOLIST model);
    }
}

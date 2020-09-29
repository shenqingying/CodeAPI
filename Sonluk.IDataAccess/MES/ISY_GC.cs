using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface ISY_GC
    {
        IList<MES_SY_GC> read(MES_SY_GC model);
        MES_RETURN delete(string GC);
        MES_RETURN UPDATE(MES_SY_GC model);
        MES_RETURN insert(MES_SY_GC model);
        int SELECT_COUNT(MES_SY_GC model);
        IList<MES_SY_GC> SELECT_BY_ROLE(MES_SY_GC model);
        MES_SY_GC_LAY_SELECT SELECT_LAY(int STAFFID);
    }
}

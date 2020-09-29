using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface ISY_RYGH
    {
        MES_RETURN INSERT_GS(MES_SY_RYGH_GS model);
        MES_SY_RYGH_GS_SELECT SELECT_GS(MES_SY_RYGH_GS model);
        MES_RETURN INSERT(MES_SY_RYGH model);
        MES_SY_RYGH_SELECT SELECT(MES_SY_RYGH model);
        MES_RETURN UPDATE(MES_SY_RYGH model);
    }
}

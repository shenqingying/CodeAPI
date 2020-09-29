using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface ISY_LANGUAGE_RETURN
    {
        MES_RETURN INSERT(MES_SY_LANGUAGE_RETURN model);
        MES_SY_LANGUAGE_RETURN_SELECT SELECT(MES_SY_LANGUAGE_RETURN model);
        MES_RETURN RETURNMX_INSERT(MES_SY_LANGUAGE_RETURNMX model);
        MES_SY_LANGUAGE_RETURNMX_SELECT RETURNMX_SELECT(MES_SY_LANGUAGE_RETURNMX model);
        MES_RETURN RETURNMX_UPDATE(MES_SY_LANGUAGE_RETURNMX model);
        MES_RETURN UPDATE(MES_SY_LANGUAGE_RETURN model);
    }
}

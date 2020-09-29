using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface ISY_PFDH
    {
        MES_RETURN INSERT(MES_SY_PFDH model);
        int SELECT_COUNT(MES_SY_PFDH model);
        MES_SY_PFDH_LIST SELECT(MES_SY_PFDH model);
        MES_RETURN UPDATE(MES_SY_PFDH model);
        MES_RETURN DELETE(MES_SY_PFDH model);
    }
}

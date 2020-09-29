using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface ISY_XTBB
    {
        MES_RETURN INSERT(MES_SY_XTBB model);
        MES_RETURN DELETE(int ID);
        MES_SY_XTBB_SELECT SELECT(MES_SY_XTBB model);
        MES_RETURN UPDATE(MES_SY_XTBB model);
    }
}

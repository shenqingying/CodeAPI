using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IMM_CK
    {
        MES_RETURN INSERT(MES_MM_CK model);
        int SELECT_COUNT(MES_MM_CK model);
        MES_RETURN UPDATE_SYNC(MES_MM_CK model);
        MES_MM_CK_SELECT SELECT(MES_MM_CK model);
        MES_MM_CK_SELECT SELECT_BY_STAFFID(MES_MM_CK model);
        MES_MM_CK_SELECT SELECT_BY_ROLE_ASSEMBLE(MES_MM_CK model);
    }
}

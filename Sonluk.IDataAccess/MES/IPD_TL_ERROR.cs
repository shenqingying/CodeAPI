using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IPD_TL_ERROR
    {
        MES_RETURN INSERT(MES_PD_TL_ERROR model);
        MES_PD_TL_ERROR_SELECT SELECT(MES_PD_TL_ERROR model);
    }
}

using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IPMM_SYS
    {
        MES_PMM_SYS SELECT(MES_PMM_SYS model);
        MES_RETURN UPDATE(MES_PMM_SYS model);
    }
}

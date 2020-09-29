using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IMES_PP
    {
        SELECT_MES_PD_SCRW GET_ZBCFUN_GDBGS_READ(List<MES_PD_SCRW_LIST> model);
    }
}

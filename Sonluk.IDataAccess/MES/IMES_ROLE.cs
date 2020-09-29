using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IMES_ROLE
    {
        MES_ROLE_GYS_SELECT SELECT_GYS(MES_ROLE_GYS model);
    }
}

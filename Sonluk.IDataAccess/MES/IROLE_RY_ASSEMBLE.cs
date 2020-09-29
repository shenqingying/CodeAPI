using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IROLE_RY_ASSEMBLE
    {
        MES_RETURN INSERT(List<MES_ROLE_RY_ASSEMBLE> model);
        MES_RETURN DELETE(int STAFFID);
    }
}

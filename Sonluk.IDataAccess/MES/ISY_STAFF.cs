using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface ISY_STAFF
    {
        MES_SY_STAFF_SELECT SELECT(MES_SY_STAFF model);
        MES_RETURN UPDATE_STAFFPW(int STAFFID, string OLDPW, string NEWPW);
    }
}

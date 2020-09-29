using Sonluk.Entities.FIVES;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.FIVES
{
    public interface ISY_DEPTPUSHRY
    {
        MES_RETURN Create(FIVES_SY_DEPTPUSHRY model);

        IList<FIVES_SY_DEPTPUSHRY> Read(FIVES_SY_DEPTPUSHRY model);
        MES_RETURN Delete(FIVES_SY_DEPTPUSHRY model);
    }
}

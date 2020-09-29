using Sonluk.Entities.FIVES;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.FIVES
{
    public interface ISY_STAFF_DEP
    {
        MES_RETURN Create(FIVES_SY_STAFF_DEP model); 
        MES_RETURN Update(FIVES_SY_STAFF_DEP model);
        IList<FIVES_SY_STAFF_DEPList> Read(FIVES_SY_STAFF_DEP model);
        MES_RETURN Delete(FIVES_SY_STAFF_DEP model);

    }
}

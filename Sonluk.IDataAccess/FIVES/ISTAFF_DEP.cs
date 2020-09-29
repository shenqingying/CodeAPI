using Sonluk.Entities.FIVES;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.FIVES
{
    public interface ISTAFF_DEP
    {
        MES_RETURN Create(FIVES_STAFF_DEP model);
        MES_RETURN Update(FIVES_STAFF_DEP model);
        IList<FIVES_STAFF_DEP> Read(FIVES_STAFF_DEP model);
        MES_RETURN Delete(FIVES_STAFF_DEP model);
    }
}

using Sonluk.Entities.FIVES;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.FIVES
{
    public interface ISY_RELATIONSHIPBIND
    {
        MES_RETURN Create(FIVES_SY_RELATIONSHIPBIND model);
        MES_RETURN Update(FIVES_SY_RELATIONSHIPBIND model);
        IList<FIVES_SY_RELATIONSHIPBINDList> Read(FIVES_SY_RELATIONSHIPBIND model);
        MES_RETURN Delete(FIVES_SY_RELATIONSHIPBIND model);
        MES_RETURN Delete_OJB1(FIVES_SY_RELATIONSHIPBIND model);
        MES_RETURN Delete_OJB2(FIVES_SY_RELATIONSHIPBIND model);
        IList<FIVES_SY_RELATIONSHIPBINDList> ReadbyPoint(FIVES_SY_RELATIONSHIPBIND model);
        

    }
}

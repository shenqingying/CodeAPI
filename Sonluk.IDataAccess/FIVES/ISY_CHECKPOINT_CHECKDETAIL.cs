using Sonluk.Entities.FIVES;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.FIVES
{
    public interface ISY_CHECKPOINT_CHECKDETAIL
    {
        MES_RETURN Create(FIVES_SY_CHECKPOINT_CHECKDETAIL model); 
        MES_RETURN Update(FIVES_SY_CHECKPOINT_CHECKDETAIL model);
        IList<FIVES_SY_CHECKPOINT_CHECKDETAILLIST> Read(FIVES_SY_CHECKPOINT_CHECKDETAIL model);
        MES_RETURN Delete(FIVES_SY_CHECKPOINT_CHECKDETAIL model);

    }
}

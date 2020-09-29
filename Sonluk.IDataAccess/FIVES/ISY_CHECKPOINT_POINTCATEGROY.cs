using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.Entities.FIVES;
using Sonluk.Entities.MES;
namespace Sonluk.IDataAccess.FIVES
{
    public interface ISY_CHECKPOINT_POINTCATEGROY
    {
        MES_RETURN Create(FIVES_SY_CHECKPOINT_POINTCATEGROY model); 
        MES_RETURN Update(FIVES_SY_CHECKPOINT_POINTCATEGROY model);
        IList<FIVES_SY_CHECKPOINT_POINTCATEGROYList> Read(FIVES_SY_CHECKPOINT_POINTCATEGROY model);
        MES_RETURN Delete(FIVES_SY_CHECKPOINT_POINTCATEGROY model);

    }
}

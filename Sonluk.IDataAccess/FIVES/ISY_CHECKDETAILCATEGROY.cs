using Sonluk.Entities.FIVES;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.FIVES
{
    public interface ISY_CHECKDETAILCATEGROY
    {
        MES_RETURN Create(FIVES_SY_CHECKDETAILCATEGROY model);
        MES_RETURN Update(FIVES_SY_CHECKDETAILCATEGROY model); 
        IList<FIVES_SY_CHECKDETAILCATEGROY> Read(FIVES_SY_CHECKDETAILCATEGROY model); 
        MES_RETURN Delete(int ID);

    }
}

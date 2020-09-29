using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.Entities.FIVES;
using Sonluk.Entities.MES;
namespace Sonluk.IDataAccess.FIVES
{
    public interface ISY_POINTCATEGROYDETAIL
    {
        MES_RETURN Create(FIVES_SY_POINTCATEGROY_DETAIL model);
        MES_RETURN Update(FIVES_SY_POINTCATEGROY_DETAIL model);
        IList<FIVES_SY_POINTCATEGROY_DETAILList> Read(FIVES_SY_POINTCATEGROY_DETAIL model);
        MES_RETURN Delete(FIVES_SY_POINTCATEGROY_DETAIL model);

    }
}

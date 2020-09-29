using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.Entities.FIVES;
using Sonluk.Entities.MES;
namespace Sonluk.IDataAccess.FIVES
{
    public interface ISY_CHECKGROUP_DEPARTMENT
    {
        MES_RETURN Create(FIVES_SY_CHECKGROUP_DEPARTMENT model); 
        MES_RETURN Update(FIVES_SY_CHECKGROUP_DEPARTMENT model);
        IList<FIVES_SY_CHECKGROUP_DEPARTMENT> Read(FIVES_SY_CHECKGROUP_DEPARTMENT model);
        MES_RETURN Delete(FIVES_SY_CHECKGROUP_DEPARTMENT model);

    }
}

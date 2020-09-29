using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.Entities.FIVES;
using Sonluk.Entities.MES;
namespace Sonluk.IDataAccess.FIVES
{
    public interface ISY_CHECKGROUP
    {
        MES_RETURN Create(FIVES_SY_CHECKGROUP model); 
        MES_RETURN Update(FIVES_SY_CHECKGROUP model); 
        IList<FIVES_SY_CHECKGROUP> Read(FIVES_SY_CHECKGROUP model);
        MES_RETURN Delete(int ID);

    }
}

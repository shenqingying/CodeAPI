using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.Entities.FIVES;
using Sonluk.Entities.MES;
namespace Sonluk.IDataAccess.FIVES
{
    public interface ISY_CHECKPOINT
    {
        MES_RETURN Create(FIVES_SY_CHECKPOINT model); 
        MES_RETURN Update(FIVES_SY_CHECKPOINT model); 
        IList<FIVES_SY_CHECKPOINT> Read(FIVES_SY_CHECKPOINT model); 
        MES_RETURN Delete(int ID);
        IList<FIVES_SY_CHECKPOINTList> ReadaddDepName(FIVES_SY_CHECKPOINT model);

        IList<FIVES_SY_CHECKPOINT> Compare(FIVES_SY_CHECKPOINT model); //未检验地点报表
    }
}

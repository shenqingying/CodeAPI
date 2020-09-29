using Sonluk.Entities.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.LE.TRA
{
    public interface IUnit
    {
        IList<UnitInfo> Read(bool available);

        UnitInfo Read(int ID);

        int Create(UnitInfo node);

        int Update(GoodsInfo node);

        int Delete(int ID);

    }
}

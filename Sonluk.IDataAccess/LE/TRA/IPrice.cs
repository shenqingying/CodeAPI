using Sonluk.Entities.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.LE.TRA
{
    public interface IPrice
    {
        IList<PriceInfo> Read(int routeID);

        int Create(PriceInfo node);

        int Delete(int routeID);
    }
}

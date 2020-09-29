using Sonluk.Entities.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.LE.TRA
{
    public interface IRoute
    {
        RouteInfo Read(int source, int destination, decimal weight);

        string Read(int SXID, decimal weight);

        RouteInfo Read(int cityID);

        int Create(RouteInfo node);

        int Update(RouteInfo node);

        int Delete(int cityID);

        string ReadZSF(int BZDID, int EZDID);
    }
}

using Sonluk.Entities.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.LE.TRA
{
    public interface IDestination
    {
        IList<DestinationInfo> Read(int parentID);

        DestinationInfo ReadSingle(int ID);

        int Create(DestinationInfo node);

        int Update(DestinationInfo node);

        int Delete(int ID);
    }
}

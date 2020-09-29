using Sonluk.Entities.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.LE.TRA
{
    public interface IPackage
    {
        IList<PackageInfo> Type(bool available);

        PackageInfo Type(int ID);
    }
}

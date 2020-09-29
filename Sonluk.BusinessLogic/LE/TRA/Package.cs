using Sonluk.DAFactory;
using Sonluk.Entities.LE;
using Sonluk.IDataAccess.LE.TRA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.LE.TRA
{
    public class Package
    {
        private static readonly IPackage _DetaAccess = LETRADataAccess.CreatePackage();

        public IList<PackageInfo> Type()
        {
            return _DetaAccess.Type(true);
        }

        public PackageInfo Type(int ID)
        {
            return _DetaAccess.Type(ID);
        }
    }
}

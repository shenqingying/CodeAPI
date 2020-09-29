using Sonluk.IDataAccess.SAP;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sonluk.DAFactory
{
    public class SAPDataAccess
    {
        private static readonly string SAPAssembly = AppConfig.Settings("SAP");
        private SAPDataAccess() { }
        public static IZBCFUN CreateIZBCFUN()
        {
            return (IZBCFUN)Assembly.Load(SAPAssembly).CreateInstance(SAPAssembly + ".ZBC01.ZBCFUN");
        }
        public static IZPSFUG CreateIZPSFUG()
        {
            return (IZPSFUG)Assembly.Load(SAPAssembly).CreateInstance(SAPAssembly + ".PS.ZPSFUG");
        }
    }
}

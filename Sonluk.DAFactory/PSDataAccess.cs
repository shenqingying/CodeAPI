using Sonluk.IDataAccess.PS;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sonluk.DAFactory
{
    public sealed class PSDataAccess
    {
        private static readonly string SAPAssembly = AppConfig.Settings("SAP");

        private PSDataAccess() { }

        public static INetWork CreateNetWork()
        {
            return (INetWork)Assembly.Load(SAPAssembly).CreateInstance(SAPAssembly + ".PS.NetWork");
        }

        public static IComponentMove CreateComponentMove()
        {
            return (IComponentMove)Assembly.Load(SAPAssembly).CreateInstance(SAPAssembly + ".PS.ComponentMove");
        }
        public static ICNFH CreateCNFH()
        {
            return (ICNFH)Assembly.Load(SAPAssembly).CreateInstance(SAPAssembly + ".PS.CNFH");
        }

    }


}

using Sonluk.IDataAccess.EM;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sonluk.DAFactory
{
    public class EMDataAccess
    {
        private static readonly string SAPAssembly = AppConfig.Settings("SAP");

        public static IEM_MISSION CreateIMISSION()
        {
            return (IEM_MISSION)Assembly.Load(SAPAssembly).CreateInstance(SAPAssembly + ".EM.EM_MISSION");
        }
      
    }
}

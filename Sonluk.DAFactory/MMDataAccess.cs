using Sonluk.IDataAccess.MM;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sonluk.DAFactory
{
    public sealed class MMDataAccess
    {
        private static readonly string SAPAssembly = AppConfig.Settings("SAP");
        public static IMATERIALINFO CreateIMATERIALINFO()
        {
            return (IMATERIALINFO)Assembly.Load(SAPAssembly).CreateInstance(SAPAssembly + ".MM.MATERIALINFO");
        }
    }
}

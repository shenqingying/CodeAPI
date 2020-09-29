using Sonluk.IDataAccess.KQ;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sonluk.DAFactory
{
    public class KQDataAccess
    {
        private static readonly string assembly = AppConfig.Settings("KQ.DataAccess");

        private KQDataAccess() { }

        public static IKQinfo CreateKQinfo()
        {
            return (IKQinfo)Assembly.Load(assembly).CreateInstance(assembly + ".KQinfo");
        }
    }
}

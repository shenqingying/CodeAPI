using Sonluk.IDataAccess.DEV;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sonluk.DAFactory
{
    public class DEVDataAccess
    {
        private static readonly string SAPAssembly = AppConfig.Settings("SAP");

        /// <summary>
        /// 反射“表”数据操作类
        /// </summary>
        /// <returns></returns>
        public static ITable CreateTable()
        {
            return (ITable)Assembly.Load(SAPAssembly).CreateInstance(SAPAssembly + ".DEV.Table");
        }
    }
}

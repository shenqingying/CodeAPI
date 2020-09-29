using Sonluk.IDataAccess.LE;
using Sonluk.IDataAccess.LE.TRA;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sonluk.DAFactory
{
    public sealed class LEDataAccess
    {
        private static readonly string SAPAssembly = AppConfig.Settings("SAP");

        /// <summary>
        /// 反射“对外交货”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IOutboundDelivery CreateOutboundDelivery()
        {
            return (IOutboundDelivery)Assembly.Load(SAPAssembly).CreateInstance(SAPAssembly + ".LE.OutboundDelivery");
        }
      
    }
}

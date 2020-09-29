using Sonluk.IDataAccess.BC;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sonluk.DAFactory
{
    public class BCDataAccess
    {
        private static readonly string SAPAssembly = AppConfig.Settings("SAP");

        /// <summary>
        /// 反射“队列锁”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IEnqueue CreateEnqueue()
        {
            return (IEnqueue)Assembly.Load(SAPAssembly).CreateInstance(SAPAssembly + ".BC.Enqueue");
        }

        /// <summary>
        /// 反射“用户”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IUser CreateUser()
        {
            return (IUser)Assembly.Load(SAPAssembly).CreateInstance(SAPAssembly + ".BC.User");
        }

        /// <summary>
        /// 反射“条码”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IBarCode CreateBarCode()
        {
            return (IBarCode)Assembly.Load(SAPAssembly).CreateInstance(SAPAssembly + ".BC.BarCode");
        }
        public static IDRF CreateIDRF()
        {
            return (IDRF)Assembly.Load(SAPAssembly).CreateInstance(SAPAssembly + ".BC.DRF");
        }
    }
}

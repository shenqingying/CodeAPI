using System.Configuration;
using System.Reflection;
using Sonluk.IDataAccess.Account;
using Sonluk.IDataAccess.LE;
using Sonluk.IDataAccess.MM;
using Sonluk.IDataAccess.SD;
using Sonluk.Utility;
using Sonluk.IDataAccess.BC;
using Sonluk.IDataAccess.FI;

namespace Sonluk.DAFactory
{
    public sealed class AccountDataAccess
    {
        private static readonly string _Assembly = AppConfig.Settings("SAP");

        private AccountDataAccess() { }

        /// <summary>
        /// 反射“访问权限”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IAccess CreateAccess()
        {
            return (IAccess)Assembly.Load(_Assembly).CreateInstance(_Assembly + ".Account.Access");
        }

        /// <summary>
        /// 反射“权限”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IAuthorization CreateAuthorization()
        {
            return (IAuthorization)Assembly.Load(_Assembly).CreateInstance(_Assembly + ".Account.Authorization");
        }

        /// <summary>
        /// 反射“采购员”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IPurchaser CreatePurchaser()
        {
            return (IPurchaser)Assembly.Load(_Assembly).CreateInstance(_Assembly + ".Account.Purchaser");
        }

        /// <summary>
        /// 反射“供应商”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IVendor CreateVendor()
        {
            return (IVendor)Assembly.Load(_Assembly).CreateInstance(_Assembly + ".Account.Vendor");
        }

     
    }

}


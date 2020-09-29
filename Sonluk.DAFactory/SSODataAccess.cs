using Sonluk.IDataAccess.SSO;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sonluk.DAFactory
{
    public sealed class SSODataAccess
    {

            private static readonly string OracleAssembly = AppConfig.Settings("Oracle");
            private static readonly string assembly = AppConfig.Settings("RMS.DataAccess");

            private SSODataAccess() { }

            /// <summary>
            /// 反射“用户”数据操作类
            /// </summary>
            /// <returns></returns>
            public static IUser CreateUser()
            {
                return (IUser)Assembly.Load(OracleAssembly).CreateInstance(OracleAssembly + ".SSO.User");
            }

            /// <summary>
            /// 反射“权限”数据操作类
            /// </summary>
            /// <returns></returns>
            public static IAuthorization CreateAuthorization()
            {
                return (IAuthorization)Assembly.Load(OracleAssembly).CreateInstance(OracleAssembly + ".SSO.Authorization");
            }
            public static ITOKEN_TOKENIDINFO CreateITOKEN_TOKENIDINFO()
            {
                return (ITOKEN_TOKENIDINFO)Assembly.Load(assembly).CreateInstance(assembly + ".SSO.TOKEN_TOKENIDINFO");
            }
    

    }
}

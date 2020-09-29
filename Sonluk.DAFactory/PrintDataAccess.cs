using Sonluk.IDataAccess.Print;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sonluk.DAFactory
{
    public sealed class PrintDataAccess
    {
        private static readonly string OracleAssembly = AppConfig.Settings("Oracle");

        private PrintDataAccess() { }

        /// <summary>
        /// 反射“打印布局”数据操作类
        /// </summary>
        /// <returns></returns>
        public static ILayout CreateLayout()
        {
            return (ILayout)Assembly.Load(OracleAssembly).CreateInstance(OracleAssembly + ".Print.Layout");
        }

        /// <summary>
        /// 反射“打印布局控件”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IControl CreateControl()
        {
            return (IControl)Assembly.Load(OracleAssembly).CreateInstance(OracleAssembly + ".Print.Control");
        }
    }
}

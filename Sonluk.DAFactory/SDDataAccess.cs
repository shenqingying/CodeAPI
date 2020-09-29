using Sonluk.IDataAccess.SD;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sonluk.DAFactory
{
    public sealed class SDDataAccess
    {
        private static readonly string SAPAssembly = AppConfig.Settings("SAP");
        private static readonly string OracleAssembly = AppConfig.Settings("Oracle");
        private static readonly string SQLServerAssembly = AppConfig.Settings("SQLServer");

        /// <summary>
        /// 反射“销售订单”数据操作类
        /// </summary>
        /// <returns></returns>
        public static ISalesOrder CreateSalesOrder()
        {
            return (ISalesOrder)Assembly.Load(SAPAssembly).CreateInstance(SAPAssembly + ".SD.SalesOrder");
        }

        /// <summary>
        /// 反射“销售报表”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IReport CreateReport()
        {
            return (IReport)Assembly.Load(SAPAssembly).CreateInstance(SAPAssembly + ".SD.Report");
        }
        public static ICLIENTINFO CreateICLIENTINFO()
        {
            return (ICLIENTINFO)Assembly.Load(SAPAssembly).CreateInstance(SAPAssembly + ".SD.CLIENTINFO");
        }
    }
}

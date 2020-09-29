using Sonluk.IDataAccess.BC;
using Sonluk.IDataAccess.FI;
using Sonluk.IDataAccess.LE;
using Sonluk.IDataAccess.Master;
using Sonluk.IDataAccess.MM;
using Sonluk.IDataAccess.SD;
using Sonluk.Utility;
using System.Configuration;
using System.Reflection;

namespace Sonluk.DAFactory
{
    public sealed class DataAccess
    {
        private static readonly string SAPAssembly = AppConfig.Settings("SAP");
        private static readonly string OracleAssembly = AppConfig.Settings("Oracle");
        private static readonly string SQLServerAssembly = AppConfig.Settings("SQLServer");

        private DataAccess() { }


        /// <summary>
        /// 反射“采购订单”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IPurchaseOrder CreatePurchaseOrder()
        {
            return (IPurchaseOrder)Assembly.Load(SAPAssembly).CreateInstance(SAPAssembly + ".MM.PurchaseOrder");
        }

        /// <summary>
        /// 反射“采购组”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IPurchasingGroup CreatePurchasingGroup()
        {
            return (IPurchasingGroup)Assembly.Load(SAPAssembly).CreateInstance(SAPAssembly + ".MM.PurchasingGroup");
        }

        /// <summary>
        /// 反射“采购订单交货计划请求”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IScheduleRequisition CreateScheduleRequisition()
        {
            return (IScheduleRequisition)Assembly.Load(SAPAssembly).CreateInstance(SAPAssembly + ".MM.ScheduleRequisition");
        }



        /// <summary>
        /// 反射“税”数据操作类
        /// </summary>
        /// <returns></returns>
        public static ITax CreateTax()
        {
            return (ITax)Assembly.Load(SAPAssembly).CreateInstance(SAPAssembly + ".FI.Tax");
        }

        /// <summary>
        /// 反射“公司”数据操作类
        /// </summary>
        /// <returns></returns>
        public static ICompany CreateCompany()
        {
            return (ICompany)Assembly.Load(SAPAssembly).CreateInstance(SAPAssembly + ".FI.Company");
        }

        /// <summary>
        /// 反射“物料”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IMaterial CreateMaterial()
        {
            return (IMaterial)Assembly.Load(SAPAssembly).CreateInstance(SAPAssembly + ".Master.Material");
        }

        /// <summary>
        /// 反射“客户”数据操作类
        /// </summary>
        /// <returns></returns>
        public static ICustomer CreateCustomer()
        {
            return (ICustomer)Assembly.Load(SAPAssembly).CreateInstance(SAPAssembly + ".Master.Customer");
        }

        /// <summary>
        /// 反射“供应商”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IVendor CreateVendor()
        {
            return (IVendor)Assembly.Load(SAPAssembly).CreateInstance(SAPAssembly + ".Master.Vendor");
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="assemblyType"></param>
        /// <returns></returns>
        public static string AssemblyName(string assemblyType)
        {
            string assemblyString = "";
            switch (assemblyType)
            {
                case "SAP": assemblyString = SAPAssembly; break;
                case "Oracle": assemblyString = OracleAssembly; break;
                case "SQLServer": assemblyString = SQLServerAssembly; break;
            }

            return assemblyString;
        }



    }

}

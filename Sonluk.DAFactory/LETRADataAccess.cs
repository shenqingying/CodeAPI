using Sonluk.IDataAccess.LE.TRA;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sonluk.DAFactory
{
    public sealed class LETRADataAccess
    {
        private static readonly string LETRAAssembly = AppConfig.Settings("LE.TRA");

        /// <summary>
        /// 反射“承运公司”数据操作类
        /// </summary>
        /// <returns></returns>
        public static ICarrier CreateCarrier()
        {
            return (ICarrier)Assembly.Load(LETRAAssembly).CreateInstance(LETRAAssembly + ".Carrier");
        }

        /// <summary>
        /// 反射“发货人”数据操作类
        /// </summary>
        /// <returns></returns>
        public static ISender CreateSender()
        {
            return (ISender)Assembly.Load(LETRAAssembly).CreateInstance(LETRAAssembly + ".Sender");
        }

        /// <summary>
        /// 反射“城市”数据操作类
        /// </summary>
        /// <returns></returns>
        public static ICity CreateCity()
        {
            return (ICity)Assembly.Load(LETRAAssembly).CreateInstance(LETRAAssembly + ".City");
        }

        /// <summary>
        /// 反射“路由”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IRoute CreateRoute()
        {
            return (IRoute)Assembly.Load(LETRAAssembly).CreateInstance(LETRAAssembly + ".Route");
        }

        /// <summary>
        /// 反射“价格”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IPrice CreatePrice()
        {
            return (IPrice)Assembly.Load(LETRAAssembly).CreateInstance(LETRAAssembly + ".Price");
        }

        /// <summary>
        /// 反射“收货人”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IReceiver CreateReceiver()
        {
            return (IReceiver)Assembly.Load(LETRAAssembly).CreateInstance(LETRAAssembly + ".Receiver");
        }

        /// <summary>
        /// 反射“收货人-地址”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IDestination CreateDestination()
        {
            return (IDestination)Assembly.Load(LETRAAssembly).CreateInstance(LETRAAssembly + ".Destination");
        }

        /// <summary>
        /// 反射“货物”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IGoods CreateGoods()
        {
            return (IGoods)Assembly.Load(LETRAAssembly).CreateInstance(LETRAAssembly + ".Goods");
        }

        /// <summary>
        /// 反射“单位”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IUnit CreateUnit()
        {
            return (IUnit)Assembly.Load(LETRAAssembly).CreateInstance(LETRAAssembly + ".Unit");
        }

        /// <summary>
        /// 反射“包装”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IPackage CreatePackage()
        {
            return (IPackage)Assembly.Load(LETRAAssembly).CreateInstance(LETRAAssembly + ".Package");
        }

        /// <summary>
        /// 反射“托运单”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IConsignmentNote CreateConsignmentNote()
        {
            return (IConsignmentNote)Assembly.Load(LETRAAssembly).CreateInstance(LETRAAssembly + ".ConsignmentNote");
        }

        /// <summary>
        /// 反射“托运单-行项目”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IConsignmentNoteItem CreateConsignmentNoteItem()
        {
            return (IConsignmentNoteItem)Assembly.Load(LETRAAssembly).CreateInstance(LETRAAssembly + ".ConsignmentNoteItem");
        }

        /// <summary>
        /// 反射“托运单-反馈”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IFeedback CreateFeedback()
        {
            return (IFeedback)Assembly.Load(LETRAAssembly).CreateInstance(LETRAAssembly + ".Feedback");
        }

        /// <summary>
        /// 反射“托运单-反馈-行项目”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IFeedbackItem CreateFeedbackItem()
        {
            return (IFeedbackItem)Assembly.Load(LETRAAssembly).CreateInstance(LETRAAssembly + ".FeedbackItem");
        }

        /// <summary>
        /// 反射“托运单-投诉”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IComplaint CreateComplaint()
        {
            return (IComplaint)Assembly.Load(LETRAAssembly).CreateInstance(LETRAAssembly + ".Complaint");
        }

        /// <summary>
        /// 反射“托运单-投诉-行项目”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IComplaintItem CreateComplaintItem()
        {
            return (IComplaintItem)Assembly.Load(LETRAAssembly).CreateInstance(LETRAAssembly + ".ComplaintItem");
        }

        public static IScreen CreateScreen()
        {
            return (IScreen)Assembly.Load(LETRAAssembly).CreateInstance(LETRAAssembly + ".Screen");
        }
    }
}

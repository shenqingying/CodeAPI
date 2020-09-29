using Sonluk.IDataAccess.CRM;
using Sonluk.IDataAccess.OA;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sonluk.DAFactory
{
    public class OADataAccess
    {
        private static readonly string _Assembly = AppConfig.Settings("OA.DataAccess");

        private OADataAccess() { }

        /// <summary>
        /// 反射“权限”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IAuthority CreateAuthority()
        {
            return (IAuthority)Assembly.Load(_Assembly).CreateInstance(_Assembly + ".Authority");
        }

        /// <summary>
        /// 反射“事务”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IAffair CreateAffair()
        {
            return (IAffair)Assembly.Load(_Assembly).CreateInstance(_Assembly + ".Affair");
        }

        /// <summary>
        /// 反射“消息”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IMessage CreateMessage()
        {
            return (IMessage)Assembly.Load(_Assembly).CreateInstance(_Assembly + ".Message");
        }

        /// <summary>
        /// 反射“流程”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IFlow CreateFlow()
        {
            return (IFlow)Assembly.Load(_Assembly).CreateInstance(_Assembly + ".Flow");
        }

        /// <summary>
        /// 反射“协同”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IBPM CreateBPM()
        {
            return (IBPM)Assembly.Load(_Assembly).CreateInstance(_Assembly + ".BPM");
        }


      

    }
}

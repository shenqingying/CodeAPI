using Sonluk.IDataAccess.QM;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sonluk.DAFactory
{
    public class QMDataAccess
    {
        private static readonly string _SAPAssembly = AppConfig.Settings("SAP");

        private QMDataAccess() { }

        /// <summary>
        /// 反射“质量通知单”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IQualityNotification CreateQualityNotification()
        {
            return (IQualityNotification)Assembly.Load(_SAPAssembly).CreateInstance(_SAPAssembly + ".QM.QualityNotification");
        }

        /// <summary>
        /// 反射“配料单”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IIngredient CreateIngredient()
        {
            return (IIngredient)Assembly.Load(_SAPAssembly).CreateInstance(_SAPAssembly + ".QM.Ingredient");
        }
        public static IZSL_QMFG_RFC CreateIZSL_QMFG_RFC()
        {
            return (IZSL_QMFG_RFC)Assembly.Load(_SAPAssembly).CreateInstance(_SAPAssembly + ".QM.ZSL_QMFG_RFC");
        }
    }
}

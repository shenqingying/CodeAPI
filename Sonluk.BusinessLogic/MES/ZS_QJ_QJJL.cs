using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class ZS_QJ_QJJL
    {
        private static readonly IZS_QJ_QJJL data_IZS_QJ_QJJL = MESDataAccess.CreateIZS_QJ_QJJL();
        public MES_RETURN INSERT(MES_ZS_QJ_QJJL model)
        {
            return data_IZS_QJ_QJJL.INSERT(model);
        }
        public MES_RETURN INSERT_QJSB(MES_ZS_QJ_QJSB model)
        {
            return data_IZS_QJ_QJJL.INSERT_QJSB(model);
        }
        public MES_ZS_QJ_QJSB_SELECT SELECT_QJSB(MES_ZS_QJ_QJSB model)
        {
            return data_IZS_QJ_QJJL.SELECT_QJSB(model);
        }
        public MES_RETURN INSERT_ERRORJL(MES_ZS_QJ_ERRORJL model)
        {
            return data_IZS_QJ_QJJL.INSERT_ERRORJL(model);
        }
        public MES_ZS_QJ_ERRORJL_SELECT SELECT_ERRORJL(MES_ZS_QJ_ERRORJL model)
        {
            return data_IZS_QJ_QJJL.SELECT_ERRORJL(model);
        }
    }
}

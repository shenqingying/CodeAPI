using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class TM_ZFDCMX
    {
        private static readonly ITM_ZFDCMX ITM_ZFDCMXdata = MESDataAccess.CreateTM_ZFDCMX();

        public MES_RETURN INSERT(MES_TM_ZFDCMX model)
        {
            return ITM_ZFDCMXdata.INSERT(model);
        }

        public MES_TM_ZFDCMX_SELECT SELECT(string TM)
        {
            return ITM_ZFDCMXdata.SELECT(TM);
        }
        public MES_RETURN DELETE(MES_TM_ZFDCMX model)
        {
            return ITM_ZFDCMXdata.DELETE(model);
        }
    }
}

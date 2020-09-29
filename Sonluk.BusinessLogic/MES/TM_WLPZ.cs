using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class TM_WLPZ
    {
        private static readonly ITM_WLPZ ITM_WLPZdata = MESDataAccess.CreateTM_WLPZ();
        public MES_TM_WLPZ_SELECT SELECT(MES_TM_WLPZ model)
        {
            return ITM_WLPZdata.SELECT(model);
        }

        public MES_RETURN INSERT(MES_TM_WLPZ model)
        {
            return ITM_WLPZdata.INSERT(model);
        }
    }
}

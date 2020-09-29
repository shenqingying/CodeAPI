using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class PD_TL_ERROR
    {
        private static readonly IPD_TL_ERROR mesdetaAccess = MESDataAccess.CreatePD_TL_ERROR();
        public MES_RETURN INSERT(MES_PD_TL_ERROR model)
        {
            return mesdetaAccess.INSERT(model);
        }
        public MES_PD_TL_ERROR_SELECT SELECT(MES_PD_TL_ERROR model)
        {
            return mesdetaAccess.SELECT(model);
        }
    }
}

using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class ZS_SY_TL
    {
        private static readonly IZS_SY_TL data_IZS_SY_TL = MESDataAccess.CreateIZS_SY_TL();
        public MES_RETURN INSERT(MES_ZS_SY_TL model)
        {
            return data_IZS_SY_TL.INSERT(model);
        }
        public MES_RETURN UPDATE(MES_ZS_SY_TL model)
        {
            return data_IZS_SY_TL.UPDATE(model);
        }
        public MES_ZS_SY_TL_SELECT SELECT(MES_ZS_SY_TL model)
        {
            return data_IZS_SY_TL.SELECT(model);
        }
    }
}

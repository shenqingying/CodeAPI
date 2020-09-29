using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class SY_GZZX_SBH_WLLB
    {
        private static readonly ISY_GZZX_SBH_WLLB mesdetaAccess = MESDataAccess.CreateSY_GZZX_SBH_WLLB();
        public MES_RETURN INSERT(MES_SY_GZZX_SBH_WLLB model)
        {
            return mesdetaAccess.INSERT(model);
        }

        public MES_RETURN INSERT_LIST(List<MES_SY_GZZX_SBH_WLLB> model)
        {
            return mesdetaAccess.INSERT_LIST(model);
        }

        public MES_RETURN DELETE(MES_SY_GZZX_SBH_WLLB model)
        {
            return mesdetaAccess.DELETE(model);
        }

        public MES_SY_GZZX_SBH_WLLB_SELECT SELECT(MES_SY_GZZX_SBH_WLLB model)
        {
            return mesdetaAccess.SELECT(model);
        }
        public MES_SY_GZZX_SBH_WLLB_SELECT SELECT_LAY(string SBBH)
        {
            return mesdetaAccess.SELECT_LAY(SBBH);
        }
    }
}

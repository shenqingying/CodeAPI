using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class SY_PFDH_WL
    {
        private static readonly ISY_PFDH_WL mesdetaAccess = MESDataAccess.CreateSY_PFDH_WL();
        public MES_RETURN INSERT(List<MES_SY_PFDH_WL> model)
        {
            return mesdetaAccess.INSERT(model);
        }

        public MES_RETURN DELETE(MES_SY_PFDH_WL model)
        {
            return mesdetaAccess.DELETE(model);
        }

        public MES_SY_PFDH_WL_SELECT_LAY SELECT_LAY(MES_SY_PFDH_WL model)
        {
            return mesdetaAccess.SELECT_LAY(model);
        }

        public MES_SY_PFDH_WL_SELECT SELECT(MES_SY_PFDH_WL model)
        {
            return mesdetaAccess.SELECT(model);
        }
    }
}

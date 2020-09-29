using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class SY_DCXH_COUNT
    {
        private static readonly ISY_DCXH_COUNT mesdetaAccess = MESDataAccess.CreateSY_DCXH_COUNT();
        public MES_SY_DCXH_COUNT_SELECT SELECT(MES_SY_DCXH_COUNT model)
        {
            return mesdetaAccess.SELECT(model);
        }
        public MES_RETURN INSERT(MES_SY_DCXH_COUNT model)
        {
            return mesdetaAccess.INSERT(model);
        }
        public MES_RETURN UPDATE(MES_SY_DCXH_COUNT model)
        {
            return mesdetaAccess.UPDATE(model);
        }
        public MES_RETURN DELETE(MES_SY_DCXH_COUNT model)
        {
            return mesdetaAccess.DELETE(model);
        }
        public MES_SY_DCXH_COUNT_SELECT SELECT_LB(MES_SY_DCXH_COUNT model)
        {
            return mesdetaAccess.SELECT_LB(model);
        }
    }
}

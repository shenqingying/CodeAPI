using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class SY_GZZX_SBH
    {
        private static readonly ISY_GZZX_SBH mesdetaAccess = MESDataAccess.CreateSY_GZZX_SBH();
        private static readonly ISY_YERACOUNT ISY_YERACOUNTdate = MESDataAccess.CreateSY_YERACOUNT();
        public MES_RETURN INSERT(MES_SY_GZZX_SBH model)
        {
            return mesdetaAccess.INSERT(model);
        }

        public MES_RETURN DELETE(string SBBH)
        {
            return mesdetaAccess.DELETE(SBBH);
        }

        public MES_RETURN UPDATE(MES_SY_GZZX_SBH model)
        {
            return mesdetaAccess.UPDATE(model);
        }

        public IList<MES_SY_GZZX_SBH> SELECT(MES_SY_GZZX_SBH model)
        {
            return mesdetaAccess.SELECT(model);
        }

        public IList<MES_SY_GZZX_SBH> SELECT_BY_STAFFID(MES_SY_GZZX_SBH model)
        {
            return mesdetaAccess.SELECT_BY_STAFFID(model);
        }
        public MES_PD_TL_TD_SELECT SELECT_BY_TDNO(MES_PD_TL_TD model)
        {
            return mesdetaAccess.SELECT_BY_TDNO(model);
        }
        public MES_RETURN INSERT_BY_TDNO(MES_PD_TL_TD model)
        {
            return mesdetaAccess.INSERT_BY_TDNO(model);
        }
        public MES_RETURN DELETE_BY_TDNO(string TDNO)
        {
            return mesdetaAccess.DELETE_BY_TDNO(TDNO);
        }
        public MES_RETURN UPDATE_BY_TDNO(MES_PD_TL_TD model)
        {
            return mesdetaAccess.UPDATE_BY_TDNO(model);
        }
        public MES_SY_GZZX_SBH_SELECT SELECT_LB(MES_SY_GZZX_SBH model)
        {
            return mesdetaAccess.SELECT_LB(model);
        }
    }
}

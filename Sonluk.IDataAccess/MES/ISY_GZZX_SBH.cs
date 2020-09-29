using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface ISY_GZZX_SBH
    {
        MES_RETURN INSERT(MES_SY_GZZX_SBH model);
        MES_RETURN DELETE(string SBBH);
        MES_RETURN UPDATE(MES_SY_GZZX_SBH model);
        IList<MES_SY_GZZX_SBH> SELECT(MES_SY_GZZX_SBH model);
        IList<MES_SY_GZZX_SBH> SELECT_BY_STAFFID(MES_SY_GZZX_SBH model);
        MES_PD_TL_TD_SELECT SELECT_BY_TDNO(MES_PD_TL_TD model);
        MES_RETURN INSERT_BY_TDNO(MES_PD_TL_TD model);
        MES_RETURN DELETE_BY_TDNO(string TDNO);
        MES_RETURN UPDATE_BY_TDNO(MES_PD_TL_TD model);
        MES_SY_GZZX_SBH_SELECT SELECT_LB(MES_SY_GZZX_SBH model);
    }
}

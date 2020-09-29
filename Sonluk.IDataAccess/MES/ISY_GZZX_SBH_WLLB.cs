using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface ISY_GZZX_SBH_WLLB
    {
        MES_RETURN INSERT(MES_SY_GZZX_SBH_WLLB model);
        MES_RETURN INSERT_LIST(List<MES_SY_GZZX_SBH_WLLB> model);
        MES_RETURN DELETE(MES_SY_GZZX_SBH_WLLB model);
        MES_SY_GZZX_SBH_WLLB_SELECT SELECT(MES_SY_GZZX_SBH_WLLB model);
        MES_SY_GZZX_SBH_WLLB_SELECT SELECT_LAY(string SBBH);

    }
}

using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface ISY_GZZX_WLLB
    {
        MES_RETURN INSERT(MES_SY_GZZX_WLLB model);
        MES_RETURN DELETE(MES_SY_GZZX_WLLB model);
        MES_SY_GZZX_WLLB_SELECT SELECT(MES_SY_GZZX_WLLB model);
        MES_RETURN INSERT_LIST(List<MES_SY_GZZX_WLLB> model);
        MES_SY_GZZX_WLLB_SELECT_LAY SELECT_LAY(MES_SY_GZZX_WLLB model);
    }
}

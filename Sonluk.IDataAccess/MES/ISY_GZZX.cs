using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface ISY_GZZX
    {
        MES_RETURN INSERT(MES_SY_GZZX model, int ISAUTO);
        MES_RETURN DELETE(MES_SY_GZZX model);
        MES_RETURN UPDATE(MES_SY_GZZX model, int ISAUTO);
        IList<MES_SY_GZZX> SELECT(MES_SY_GZZX model);
        int SELECT_COUNT(string GZZXBH, string GC);
        IList<MES_SY_GZZX> SELECT_BY_ROLE(MES_SY_GZZX model);
        MES_SY_GZZX_GW_LIST SELECT_GZZX_GW(MES_SY_GZZX GZZXID);
        List<MES_SY_GZZX> SELECT_LB(MES_SY_GZZX model);
    }
}

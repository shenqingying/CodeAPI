using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface ISY_PFDH_WL
    {
        MES_RETURN INSERT(List<MES_SY_PFDH_WL> model);
        MES_RETURN DELETE(MES_SY_PFDH_WL model);
        MES_SY_PFDH_WL_SELECT_LAY SELECT_LAY(MES_SY_PFDH_WL model);
        MES_SY_PFDH_WL_SELECT SELECT(MES_SY_PFDH_WL model);
        MES_RETURN XFPC_SYNC_INSERT(ZSL_BCS304 model);
        MES_SY_XFPC_SYNC_SELECT XFPC_SYNC_SELECT(ZSL_BCS304 model, int LB);
        MES_RETURN XFPC_SYNC_UPDATE(ZSL_BCS304 model, int LB);
    }
}

using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IPD_GD
    {
        MES_RETURN INSERT(MES_PD_GD model);
        SELECT_MES_PD_GD SELECT(MES_PD_GD model);
        MES_RETURN UPDATE(MES_PD_GD model);
        MES_RETURN DELETE(MES_PD_GD model);
        MES_RETURN SELECT_ERPNO_COUNT(string GC, string ERPNO);
        SELECT_MES_PD_GD SELECT_BY_PFDH(MES_PD_GD_SELECT_BY_PFDH model);
        MES_RETURN UPDATE_ALL(MES_PD_GD model);
        MES_RETURN DELETE_ALL(MES_PD_GD model);
        SELECT_MES_PD_GD SELECT_BY_STAFFID(MES_PD_GD model);
        MES_PD_GD_GDJD_SELECT SELECT_GDJD(MES_PD_GD_GDJD_IMPORT model);
        MES_RETURN BOM_SYNC_INSERT(ZSL_BCS302_B model);
        MES_PD_GD_BOM_SYNC_SELECT BOM_SYNC_SELECT(ZSL_BCS302_B model, int LB);
        MES_RETURN BOM_SYNC_UPDATE(ZSL_BCS302_B model, int LB);
        MES_RETURN INSERT_GD_SYNC(List<ZSL_BCST024_PO> model);
        MES_PD_GD_SYNC_SELECT SELECT_GD_SYNC(MES_PD_GD_SYNC model);
        MES_RETURN INSERT_GD_GYLX_SYNC(List<ZSL_BCST302_R> model);
    }
}

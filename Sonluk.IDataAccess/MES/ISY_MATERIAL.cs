using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface ISY_MATERIAL
    {
        MES_RETURN INSERT(MES_SY_MATERIAL model, int ISAUTO);
        int SELECT_COUNT(MES_SY_MATERIAL model);
        MES_RETURN DELETE(MES_SY_MATERIAL model);
        MES_RETURN UPDATE(MES_SY_MATERIAL model, int ISAUTO);
        MES_SY_MATERIAL_SELECT SELECT(MES_SY_MATERIAL model);
        MES_SY_MATERIAL_SELECT SELECT_BY_GZZX(MES_SY_MATERIAL model);
        MES_RETURN INSERT_DW(MES_SY_MATERIAL_DW model);
        MES_SY_MATERIAL_DW_SELECT DW_SELECT(MES_SY_MATERIAL_DW model);
        MES_RETURN DW_UPDATE(MES_SY_MATERIAL_DW model);
        MES_SY_MATERIAL_SELECT SELECT_LB(MES_SY_MATERIAL model);
    }
}

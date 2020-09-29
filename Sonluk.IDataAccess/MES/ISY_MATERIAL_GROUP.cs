using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface ISY_MATERIAL_GROUP
    {
        MES_RETURN INSERT(MES_SY_MATERIAL_GROUP model, int ISAUTO);
        int SELECT_COUNT(MES_SY_MATERIAL_GROUP model);
        MES_SY_MATERIAL_GROUP_SELECT SELECT(MES_SY_MATERIAL_GROUP model);
        MES_RETURN DELETE(MES_SY_MATERIAL_GROUP model);
        MES_RETURN UPDATE(MES_SY_MATERIAL_GROUP model);
        MES_SY_MATERIAL_GROUP_SELECT SELECT_LB(MES_SY_MATERIAL_GROUP model);
    }
}

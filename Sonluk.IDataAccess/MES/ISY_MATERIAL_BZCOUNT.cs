using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface ISY_MATERIAL_BZCOUNT
    {
        MES_RETURN INSERT(MES_SY_MATERIAL_BZCOUNT model);
        MES_RETURN DELETE(MES_SY_MATERIAL_BZCOUNT model);
        MES_RETURN UPDATE(MES_SY_MATERIAL_BZCOUNT model);
        MES_SY_MATERIAL_BZCOUNT_SELECT SELECT(MES_SY_MATERIAL_BZCOUNT model);
        MES_SY_MATERIAL_BZCOUNT_SELECT SELECT_LB(MES_SY_MATERIAL_BZCOUNT model);
    }
}

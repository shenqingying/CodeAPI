using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IPD_GD_BOM
    {
        MES_RETURN INSERT(MES_PD_GD_BOM model);
        MES_RETURN DELETE(MES_PD_GD_BOM model, int DELETELB);
        MES_PD_GD_BOM_SELECT SELECT(MES_PD_GD_BOM model);
    }
}

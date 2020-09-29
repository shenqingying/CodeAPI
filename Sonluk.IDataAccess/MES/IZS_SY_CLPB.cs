using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IZS_SY_CLPB
    {
        MES_RETURN INSERT(MES_ZS_SY_CLPB model);
        MES_RETURN UPDATE(MES_ZS_SY_CLPB model);
        MES_ZS_SY_CLPB_SELECT SELECT(MES_ZS_SY_CLPB model);
        MES_RETURN INSERT_WL(MES_ZS_SY_CLPB_WL model);
        MES_RETURN UPDATE_WL(MES_ZS_SY_CLPB_WL model);
        MES_ZS_SY_CLPB_WL_SELECT SELECT_WL(MES_ZS_SY_CLPB_WL model);
    }
}

using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface ISY_SCDATE_TH
    {
        MES_RETURN INSERT(MES_SY_SCDATE_TH model);
        MES_RETURN UPDATE(MES_SY_SCDATE_TH model, int LB);
        MES_SY_SCDATE_TH_SELECT SELECT(MES_SY_SCDATE_TH_SELECT_IN model, int LB);
        MES_SY_SCDATE_TH_SELECT SELECT_BY_ROLE(MES_SY_SCDATE_TH_SELECT_IN model, int LB);
    }
}

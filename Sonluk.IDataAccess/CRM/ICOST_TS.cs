using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_TS
    {
        int Create(CRM_COST_TS model);
        int Update(CRM_COST_TS model);
        IList<CRM_COST_TS> ReadByParam(CRM_COST_TS model, int CURRENTID);
        int Delete(int TSID);
    }
}

using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface  ICOST_ZZFSJT
    {
         int Create(CRM_COST_ZZFSJT model);
         int Update(CRM_COST_ZZFSJT model);
         IList<CRM_COST_ZZFSJT> ReadByParam(CRM_COST_ZZFSJT model);
         int Delete(int SJTID);

    }
}

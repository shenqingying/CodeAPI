using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_LKAHXDJTT
    {
        int Create(CRM_COST_LKAHXDJTT model);
        int Update(CRM_COST_LKAHXDJTT model);
        IList<CRM_COST_LKAHXDJTT> ReadByParam(CRM_COST_LKAHXDJTT model, int STAFFID);
        int Delete(int HXDJMXID);

    }
}

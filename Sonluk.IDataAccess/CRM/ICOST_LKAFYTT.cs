using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_LKAFYTT
    {
        int Create(CRM_COST_LKAFYTT model);
        int Update(CRM_COST_LKAFYTT model);
        IList<CRM_COST_LKAFYTT> ReadByParam(CRM_COST_LKAFYTT model, int STAFFID);
        int Delete(int LKAFYTTID);
        int UpdateCost(int LKAFYTTID);

       

    }
}

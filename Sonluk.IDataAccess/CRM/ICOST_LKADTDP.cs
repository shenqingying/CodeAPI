using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_LKADTDP
    {
        int Create(CRM_COST_LKADTDP model);
        int Update(CRM_COST_LKADTDP model);
        IList<CRM_COST_LKADTDP> ReadByParam(CRM_COST_LKADTDP model);
        int Delete(int DPID);


    }
}

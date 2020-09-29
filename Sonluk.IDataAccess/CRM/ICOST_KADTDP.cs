using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_KADTDP
    {
        int Create(CRM_COST_KADTDP model);
        int Update(CRM_COST_KADTDP model);
        IList<CRM_COST_KADTDP> ReadByParam(CRM_COST_KADTDP model);
        int Delete(int DPID);


    }
}

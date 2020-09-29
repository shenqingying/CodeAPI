using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_LKAFYMXDT
    {

        int Create(CRM_COST_LKAFYMXDT model);
        int Update(CRM_COST_LKAFYMXDT model);
        IList<CRM_COST_LKAFYMXDT> ReadByParam(CRM_COST_LKAFYMXDT model);
        int Delete(int LKADTMXID);
        IList<CRM_COST_LKAFYMXDT> Read_Unconnected(CRM_COST_LKAFYMXDT model);



    }
}

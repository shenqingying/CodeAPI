using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_KAYEARCOST
    {
        int Create(CRM_COST_KAYEARCOST model);
        int Update(CRM_COST_KAYEARCOST model);
        int UpdateSPJE(int KAYEARTTID);
        IList<CRM_COST_KAYEARCOST> ReadByParam(CRM_COST_KAYEARCOST model);
        IList<CRM_COST_KAYEARCOST> Read_Unconnected(CRM_COST_KAYEARCOST model);
        int Delete(int COSTID);




    }
}

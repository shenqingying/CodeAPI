using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_LKAYEARCOST
    {
        int Create(CRM_COST_LKAYEARCOST model);
        int Update(CRM_COST_LKAYEARCOST model);
        int UpdateSPJE(CRM_COST_LKAYEARCOST model);
        IList<CRM_COST_LKAYEARCOST> ReadByParam(CRM_COST_LKAYEARCOST model);
        int Delete(int COSTID);
        IList<CRM_COST_LKAYEARCOST> ReadCOSTByKHID(int KHID, string YEAR);
        CRM_COST_GETCOST GetCost(int LKAID, string HTYEAR);

    }
}

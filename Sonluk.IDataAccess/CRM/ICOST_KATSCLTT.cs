using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_KATSCLTT
    {
        int Create(CRM_COST_KATSCLTT model);
        int Update(CRM_COST_KATSCLTT model);
        int UpdateCost(int KATSCLTTID);
        IList<CRM_COST_KATSCLTT> ReadByParam(CRM_COST_KATSCLTT model, int STAFFID);
        int Delete(int KATSCLTTID);



    }
}

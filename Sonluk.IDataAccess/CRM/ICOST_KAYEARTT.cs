using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_KAYEARTT
    {
        int Create(CRM_COST_KAYEARTT model);
        int Update(CRM_COST_KAYEARTT model);
        int UpdateSubmitCount(int KAYEARTTID);
        IList<CRM_COST_KAYEARTT> ReadByParam(CRM_COST_KAYEARTT model, int STAFFID);
        int Delete(int KAYEARTTID);
        int Verify(CRM_COST_KAYEARTT model);



    }
}

using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_KAHXZLTT
    {
        int Create(CRM_COST_KAHXZLTT model);
        int Update(CRM_COST_KAHXZLTT model);
        IList<CRM_COST_KAHXZLTT> ReadByParam(CRM_COST_KAHXZLTT model, int STAFFID);
        int Delete(int HXZLTTID);



    }
}

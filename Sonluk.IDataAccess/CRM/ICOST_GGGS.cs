using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_GGGS
    {
        int Create(CRM_COST_GGGS model);
        int Update(CRM_COST_GGGS model);
        IList<CRM_COST_GGGS> ReadByParam(CRM_COST_GGGS model);
        int Delete(int GGGSID);


    }
}

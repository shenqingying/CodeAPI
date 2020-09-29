using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_CJHDWD
    {
        int Create(CRM_COST_CJHDWD model);
        int Update(CRM_COST_CJHDWD model);
        IList<CRM_COST_CJHDWD> ReadByParam(CRM_COST_CJHDWD model);
        int Delete(int CJHDWDID);




    }
}

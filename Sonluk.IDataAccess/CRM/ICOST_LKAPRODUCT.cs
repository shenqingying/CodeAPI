using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_LKAPRODUCT
    {
        int Create(CRM_COST_LKAPRODUCT model);
        int Update(CRM_COST_LKAPRODUCT model);
        IList<CRM_COST_LKAPRODUCT> ReadByParam(CRM_COST_LKAPRODUCT model);
        int Delete(string SAPCP);




    }
}

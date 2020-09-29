using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_CXHDTC
    {

        int Create(CRM_COST_CXHDTC model);
        int Update(CRM_COST_CXHDTC model);
        IList<CRM_COST_CXHDTC> ReadByParam(CRM_COST_CXHDTC model);
        int Delete(int TCID);



    }
}

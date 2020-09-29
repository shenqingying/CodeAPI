using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_CXYGZ
    {
        int Create(CRM_COST_CXYGZ model);
        int Update(CRM_COST_CXYGZ model);
        int AddPrintCount(int CXYGZID);
        IList<CRM_COST_CXYGZ> ReadByParam(CRM_COST_CXYGZ model);

        int Delete(int CXYGZID);
    }
}

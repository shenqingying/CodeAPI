using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_KAHXDJMX
    {
        int Create(CRM_COST_KAHXDJMX model);
        int Update(CRM_COST_KAHXDJMX model);
        IList<CRM_COST_KAHXDJMX> ReadByParam(CRM_COST_KAHXDJMX model);
        IList<CRM_COST_KAHXDJMX> ReadForPrint(CRM_COST_KAHXDJMX model);
        int Delete(int HXDJMXID);
        int AddPrintCount(int HXDJMXID);

    }
}

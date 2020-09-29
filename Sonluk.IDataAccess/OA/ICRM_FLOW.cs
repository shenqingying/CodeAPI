using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.OA
{
    public interface ICRM_FLOW
    {
        IList<OA_QJ_INFO> ReadFROMMAIN_1801();
    }
}

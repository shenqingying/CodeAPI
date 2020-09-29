using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICRM_OA_FLOW
    {
       IList<CRM_OA_TRANSMIT> ReadOA_TRANSMIT();
       void OA_FinishUpdate(string table, string idName, int id, int isactive);
    }
}

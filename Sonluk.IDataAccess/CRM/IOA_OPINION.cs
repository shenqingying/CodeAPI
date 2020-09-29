using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IOA_OPINION
    {

        int Create(CRM_OA_OPINION model);
        IList<CRM_OA_OPINION> ReadByParam(CRM_OA_OPINION model);
        int Update(CRM_OA_OPINION model);

    }
}

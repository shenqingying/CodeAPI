using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IORDER_SH
    {
        int Create(CRM_ORDER_SH model);
        int Update(CRM_ORDER_SH model);
        int UpdateByParam(CRM_ORDER_SH model);
        IList<CRM_ORDER_SH> ReadByParam(CRM_ORDER_SH model);
        IList<CRM_ORDER_SH> Report(CRM_ORDER_SH model);

    }
}

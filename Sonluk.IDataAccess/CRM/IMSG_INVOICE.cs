using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IMSG_INVOICE
    {
        int Create(CRM_MSG_INVOICE model);
        int Update(CRM_MSG_INVOICE model);
        IList<CRM_MSG_INVOICEList> ReadByParam(CRM_MSG_INVOICEParam model);
        int Delete(int INVOICEID);
        IList<CRM_MSG_INVOICEList> ReadByKHID(int KHID);
        int AddCount(int INVOICEID);


    }
}

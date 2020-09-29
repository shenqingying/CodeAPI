using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class MSG_INVOICE
    {
        private static readonly IMSG_INVOICE _DataAccess = RMSDataAccess.CreateIMSG_INVOICE();
        public int Create(CRM_MSG_INVOICE model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_MSG_INVOICE model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_MSG_INVOICEList> ReadByParam(CRM_MSG_INVOICEParam model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(int INVOICEID)
        {
            return _DataAccess.Delete(INVOICEID);
        }
        public IList<CRM_MSG_INVOICEList> ReadByKHID(int KHID)
        {
            return _DataAccess.ReadByKHID(KHID);
        }
        public int AddCount(int INVOICEID)
        {
            return _DataAccess.AddCount(INVOICEID);
        }



    }
}

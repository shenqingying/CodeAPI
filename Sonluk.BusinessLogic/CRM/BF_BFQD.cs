using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class BF_BFQD
    {
        private static readonly IBF_BFQD _DataAccess_BFDJ = RMSDataAccess.CreateBF_BFQD();
        public int Create(CRM_BF_BFQD model)
        {
            return _DataAccess_BFDJ.Create(model);
        }
        public IList<CRM_BF_BFQDLIST> ReadByBFDJID(int BFDJID)
        {
            return _DataAccess_BFDJ.ReadByBFDJID(BFDJID);
        }
        public int Delete(int BFQDID)
        {
            return _DataAccess_BFDJ.Delete(BFQDID);
        }
    }
}

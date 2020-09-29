using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IBF_BFQD
    {
       int Create(CRM_BF_BFQD model);
       IList<CRM_BF_BFQDLIST> ReadByBFDJID(int BFDJID);
       int Delete(int BFQDID);
    }
}

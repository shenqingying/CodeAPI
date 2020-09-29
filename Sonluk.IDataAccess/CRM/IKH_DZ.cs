using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IKH_DZ
    {
        int Create(CRM_KH_DZ model);
        int Update(CRM_KH_DZ model);
        int Delete(int DZID);
        IList<CRM_KH_DZList> ReadByKHID(int KHID);
    }
}

using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IKH_HD
    {
        int Create(CRM_KH_HD model);
        int Update(CRM_KH_HD model);
        int Delete(int HDID);
        IList<CRM_KH_HDList> ReadByKHID(int KHID);
        CRM_KH_HD ReadByID(int HDID);

    }
}

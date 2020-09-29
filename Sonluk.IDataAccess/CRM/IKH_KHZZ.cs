using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IKH_KHZZ
    {
        int Create(CRM_KH_KHZZ model);
        int Update(CRM_KH_KHZZ model);
        int Delete(int ZZID);
        int DeleteByKHID(int KHID);
        IList<CRM_KH_KHZZList> ReadByKHID(int KHID);
        IList<CRM_KH_KHZZ> ReadByParam(CRM_KH_KHZZ model);
        CRM_KH_KHZZ ReadByID(int ZZID);

    }
}

using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IKH_KHQTXX
    {
        int Create(CRM_KH_KHQTXX model);
        int Update(CRM_KH_KHQTXX model);
        int Delete(int XXID);
        IList<CRM_KH_KHQTXXList> Read(int KHID, int XXLB);
        int DeleteByKHID_XXLB(int KHID, int XXLB);
    }
}

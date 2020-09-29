using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IKH_LXR
    {
        int Create(CRM_KH_LXR model);
        int Update(CRM_KH_LXR model);
        int Delete(int KHLXRID);
        IList<CRM_KH_LXRList> Read(int KHID,int LB);
        int DeleteByKHID(int KHID);
    }
}

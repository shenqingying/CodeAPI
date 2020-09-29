using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IKH_GXQY
    {
        int Create(CRM_KH_GXQY model);
        int Update(CRM_KH_GXQY model);
        IList<CRM_KH_GXQYList> Read(int KHID);
        int Delete(int GXQYID);
        int DeleteByKHID(int KHID);

    }
}

using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IKH_XSYWJZ
    {
        int Create(CRM_KH_XSYWJZ model);
        int Update(CRM_KH_XSYWJZ model);
        int Delete(int XSYWJZID);
        IList<CRM_KH_XSYWJZList> ReadByKHID(int KHID);
        CRM_KH_XSYWJZ ReadByID(int XSYWJZID);


    }
}

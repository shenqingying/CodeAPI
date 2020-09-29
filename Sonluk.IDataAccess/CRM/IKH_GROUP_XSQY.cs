using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IKH_GROUP_XSQY
    {
        int Create(CRM_KH_GROUP_XSQY model);
        int Update(CRM_KH_GROUP_XSQY model);
        int Delete(int XSQYID);
        IList<CRM_KH_GROUP_XSQY> Read();
    }
}

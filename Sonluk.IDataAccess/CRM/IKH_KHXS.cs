using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IKH_KHXS
    {
        int Create(CRM_KH_KHXS model);
        int Update(CRM_KH_KHXS model);
        int Delete(CRM_KH_KHXS model);
        IList<CRM_KH_KHXSList> Read(CRM_KH_KHXS model);
        IList<CRM_KH_KHXS_DZSreportList> DZSreport(CRM_KH_KHXS_DZSreport model, int STAFFID);
    }
}

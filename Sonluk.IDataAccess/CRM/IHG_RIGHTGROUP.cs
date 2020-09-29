using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IHG_RIGHTGROUP
    {
        int Create(CRM_HG_RIGHTGROUP model);
        int Update(CRM_HG_RIGHTGROUP model);
        int Delete(int RGROUPID);
        IList<CRM_HG_RIGHTGROUP> Read();
    }
}

using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IHG_DUTY
    {
        int Create(CRM_HG_DUTY model);
        int Update(CRM_HG_DUTY model);
        int Delete(int DUTYID);
        IList<CRM_HG_DUTY> Read();
    }
}

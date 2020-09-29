using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IHG_DEPT
    {
        int Create(CRM_HG_DEPT model);
        int Update(CRM_HG_DEPT model);
        int Delete(int DEPID);
        IList<CRM_HG_DEPT> Read();
        CRM_HG_DEPTList ReadByDEPID(int DEPID);
        CRM_HG_DEPT ReadByName(string DEPNAME);
        IList<CRM_HG_DEPT> ReadByStaffid(int STAFFID);
    }
}

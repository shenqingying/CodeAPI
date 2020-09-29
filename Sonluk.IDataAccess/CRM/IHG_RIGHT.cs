using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IHG_RIGHT
    {
        int Create(CRM_HG_RIGHT model);
        int Update(CRM_HG_RIGHT model);
        int Delete(int RIGHTID);
        IList<CRM_HG_RIGHT> ReadByRGROUPID(int RGROUPID);
        IList<CRM_HG_RIGHTList> Read();

    }
}

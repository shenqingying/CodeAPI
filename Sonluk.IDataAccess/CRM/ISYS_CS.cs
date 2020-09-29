using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ISYS_CS
    {
        int Update(CRM_SYS_CS model);
        //CRM_SYS_CS Read(int ID);
        IList<CRM_SYS_CS> Read(int ID);
    }
}

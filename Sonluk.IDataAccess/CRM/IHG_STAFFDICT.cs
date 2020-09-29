using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IHG_STAFFDICT
    {
        int Create(CRM_HG_STAFFDICT model);
        IList<CRM_HG_STAFFDICT> ReadByParam(CRM_HG_STAFFDICT model);
        int Delete(int STAFFID, int DICID);


    }
}

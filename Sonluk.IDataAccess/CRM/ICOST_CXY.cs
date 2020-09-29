using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
  public  interface ICOST_CXY
    {
        int Create(CRM_COST_CXY model);
        int Update(CRM_COST_CXY model);
        IList<CRM_COST_CXY> ReadByParam(CRM_COST_CXY model,int STAFFID);
        IList<CRM_COST_CXY> ReadByGZ(CRM_COST_CXY model);

        int Delete(int CXYID);
    }
}

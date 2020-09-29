using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
  public  interface ICOST_TSMX
    {
      int Create(CRM_COST_TSMX model);
      int Update(CRM_COST_TSMX model);
      IList<CRM_COST_TSMX> ReadByParam(CRM_COST_TSMX model);
      int Delete(int TSMXID);
    }
}

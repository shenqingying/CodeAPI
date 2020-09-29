using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
  public  interface ICOST_CLFTT
    {
      int Create(CRM_COST_CLFTT model);
      int Update(CRM_COST_CLFTT model);
      IList<CRM_COST_CLFTT> ReadByParam(CRM_COST_CLFTT model);
      IList<CRM_COST_CLFTT> ReadByAll(CRM_COST_CLFTT model, int CURRENTID);
      int Delete(int CLFTTID);
    }
}

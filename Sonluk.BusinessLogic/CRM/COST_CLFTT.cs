using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
  public  class COST_CLFTT
    {
      private static readonly ICOST_CLFTT _DataAccess = RMSDataAccess.CreateCOST_CLFTT();

      public int Create(CRM_COST_CLFTT model)
        {
            return _DataAccess.Create(model);
        }
      public int Update(CRM_COST_CLFTT model)
        {
            return _DataAccess.Update(model);
        }
      public IList<CRM_COST_CLFTT> ReadByParam(CRM_COST_CLFTT model)
        {
            return _DataAccess.ReadByParam(model);
        }
      public IList<CRM_COST_CLFTT> ReadByAll(CRM_COST_CLFTT model, int CURRENTID)
      {
          return _DataAccess.ReadByAll(model,CURRENTID);
      }
      public int Delete(int CLFTTID)
        {
            return _DataAccess.Delete(CLFTTID);
        }
    }
}

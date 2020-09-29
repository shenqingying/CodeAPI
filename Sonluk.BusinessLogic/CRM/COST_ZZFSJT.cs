using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
 public   class COST_ZZFSJT
    {
     private static readonly ICOST_ZZFSJT _DataAccess = RMSDataAccess.CreateCOST_ZZFSJT();

     public int Create(CRM_COST_ZZFSJT model)
        {
            return _DataAccess.Create(model);
        }
     public int Update(CRM_COST_ZZFSJT model)
        {
            return _DataAccess.Update(model);
        }
     public IList<CRM_COST_ZZFSJT> ReadByParam(CRM_COST_ZZFSJT model)
        {
            return _DataAccess.ReadByParam(model);
        }
     public int Delete(int SJTID)
        {
            return _DataAccess.Delete(SJTID);
        }

    }
}

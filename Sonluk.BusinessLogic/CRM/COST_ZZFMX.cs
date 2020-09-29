using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
  public  class COST_ZZFMX
    {
        private static readonly ICOST_ZZFMX _DataAccess = RMSDataAccess.CreateCOST_ZZFMX();

     public int Create(CRM_COST_ZZFMX model)
        {
            return _DataAccess.Create(model);
        }
     public int Update(CRM_COST_ZZFMX model)
        {
            return _DataAccess.Update(model);
        }
     public IList<CRM_COST_ZZFMX> ReadByParam(CRM_COST_ZZFMX model)
        {
            return _DataAccess.ReadByParam(model);
        }
     public int Delete(int MXID)
        {
            return _DataAccess.Delete(MXID);
        }

    }
 }


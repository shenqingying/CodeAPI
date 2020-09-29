using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
   public class HG_RIGHT
    {
       private static readonly IHG_RIGHT _DataAccess = RMSDataAccess.CreateHG_RIGHT();
       public int Create(CRM_HG_RIGHT model)
       {
           return _DataAccess.Create(model);
       }
       public int Update(CRM_HG_RIGHT model)
       {
           return _DataAccess.Update(model);
       }
       public int Delete(int RIGHTID)
       {
           return _DataAccess.Delete(RIGHTID);
       }
       public IList<CRM_HG_RIGHT> ReadByRGROUPID(int RGROUPID)
       {
           return _DataAccess.ReadByRGROUPID(RGROUPID);
       }
       public IList<CRM_HG_RIGHTList> Read()
       {
           return _DataAccess.Read();
       }
    }
}

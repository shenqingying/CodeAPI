using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
   public class SYS_CS
    {
       private static readonly ISYS_CS _DataAccess = RMSDataAccess.CreateSYS_CS();
       public int Update(CRM_SYS_CS model)
       {
           return _DataAccess.Update(model);
       }
       public IList<CRM_SYS_CS> Read(int ID)
       {
           return _DataAccess.Read(ID);
       }
    }
}

using Sonluk.DAFactory;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
   public class HG_RYKQ
    {
       private static readonly IHG_RYKQ _DataAccess = RMSDataAccess.CreateHG_RYKQ();
       public int Create(int STAFFID, int KQDZID)
       {
           return _DataAccess.Create(STAFFID, KQDZID);
       }
       public int Delete(int STAFFID, int KQDZID)
       {
           return _DataAccess.Delete(STAFFID, KQDZID);
       }
       public IList<string[]> ReadBySTAFFID(int STAFFID)
       {
           return _DataAccess.ReadBySTAFFID(STAFFID);
       }
    }
}

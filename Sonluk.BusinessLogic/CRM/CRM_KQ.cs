using Sonluk.DAFactory;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class CRM_KQ
    {
        private static readonly ICRM_KQ _DetaAccess = RMSDataAccess.CreateCRM_KQ();
    }
}

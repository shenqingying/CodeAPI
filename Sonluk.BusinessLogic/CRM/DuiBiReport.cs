using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class DuiBiReport
    {
        private static readonly IDuiBiReport _DataAccess = RMSDataAccess.CreateDuiBiReport();
        public DataTable RuK_DuiBiReport(RuK_DuiBiReport model)
        {
            return _DataAccess.RuK_DuiBiReport(model);
        }
    }
}

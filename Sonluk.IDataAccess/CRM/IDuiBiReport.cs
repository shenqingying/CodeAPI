using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
  public  interface IDuiBiReport
    {
      DataTable RuK_DuiBiReport(RuK_DuiBiReport model);
    }
}

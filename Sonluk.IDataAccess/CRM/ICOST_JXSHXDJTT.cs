using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
   public interface ICOST_JXSHXDJTT
    {
       int Create(CRM_COST_JXSHXDJTT model);
       int Update(CRM_COST_JXSHXDJTT model);
       IList<CRM_COST_JXSHXDJTT> ReadByParam(CRM_COST_JXSHXDJTT model, int STAFFID);

       int Delete(int HXDJTTID);
    }
}

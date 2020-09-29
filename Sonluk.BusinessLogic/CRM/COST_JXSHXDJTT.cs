using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_JXSHXDJTT
    {
        private static readonly ICOST_JXSHXDJTT _DataAccess = RMSDataAccess.CreateCOST_JXSHXDJTT();

        public int Create(CRM_COST_JXSHXDJTT model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_JXSHXDJTT model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_JXSHXDJTT> ReadByParam(CRM_COST_JXSHXDJTT model, int STAFFID)
        {
            return _DataAccess.ReadByParam(model, STAFFID);
        }

        public int Delete(int HXDJTTID)
        {
            return _DataAccess.Delete(HXDJTTID);
        }
    }
}

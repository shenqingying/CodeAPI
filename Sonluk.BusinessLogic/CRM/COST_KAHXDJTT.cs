using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_KAHXDJTT
    {
        private static readonly ICOST_KAHXDJTT _DataAccess = RMSDataAccess.CreateCOST_KAHXDJTT();


        public int Create(CRM_COST_KAHXDJTT model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_KAHXDJTT model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_KAHXDJTT> ReadByParam(CRM_COST_KAHXDJTT model, int STAFFID)
        {
            return _DataAccess.ReadByParam(model, STAFFID);
        }
        public int Delete(int HXDJTTID)
        {
            return _DataAccess.Delete(HXDJTTID);
        }




    }
}

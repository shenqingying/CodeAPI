using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_KAHXZLTT
    {
        private static readonly ICOST_KAHXZLTT _DataAccess = RMSDataAccess.CreateCOST_KAHXZLTT();


        public int Create(CRM_COST_KAHXZLTT model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_KAHXZLTT model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_KAHXZLTT> ReadByParam(CRM_COST_KAHXZLTT model, int STAFFID)
        {
            return _DataAccess.ReadByParam(model, STAFFID);
        }
        public int Delete(int HXZLTTID)
        {
            return _DataAccess.Delete(HXZLTTID);
        }





    }
}

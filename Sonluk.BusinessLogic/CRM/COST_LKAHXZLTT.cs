using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_LKAHXZLTT
    {
        private static readonly ICOST_LKAHXZLTT _DataAccess = RMSDataAccess.CreateCOST_LKAHXZLTT();

        public int Create(CRM_COST_LKAHXZLTT model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_LKAHXZLTT model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_LKAHXZLTT> ReadByParam(CRM_COST_LKAHXZLTT model, int STAFFID)
        {
            return _DataAccess.ReadByParam(model, STAFFID);
        }
        public int Delete(int HXZLTTID)
        {
            return _DataAccess.Delete(HXZLTTID);
        }
        public CRM_COST_LKAHXZLTT ReadTTGLinfo(CRM_COST_LKAHXZLTT model)
        {
            return _DataAccess.ReadTTGLinfo(model);
        }
        public IList<CRM_COST_HXZLTT> ReadByPublic(CRM_COST_HXZLTT model, int STAFFID)
        {
            return _DataAccess.ReadByPublic(model, STAFFID);
        }




    }
}

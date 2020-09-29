using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class KH_KHXS
    {
        private static readonly IKH_KHXS _DataAccess = RMSDataAccess.CreateKH_KHXS();
        public int Create(CRM_KH_KHXS model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_KH_KHXS model)
        {
            return _DataAccess.Update(model);
        }
        public int Delete(CRM_KH_KHXS model)
        {
            return _DataAccess.Delete(model);
        }
        public IList<CRM_KH_KHXSList> Read(CRM_KH_KHXS model)
        {
            return _DataAccess.Read(model);
        }
        public IList<CRM_KH_KHXS_DZSreportList> DZSreport(CRM_KH_KHXS_DZSreport model, int STAFFID)
        {
            return _DataAccess.DZSreport(model,STAFFID);
        }
    }
}

using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class KH_GROUP_XSQY
    {
        private static readonly IKH_GROUP_XSQY _DataAccess = RMSDataAccess.CreateKH_GROUP_XSQY();
        public int Create(CRM_KH_GROUP_XSQY model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_KH_GROUP_XSQY model)
        {
            return _DataAccess.Update(model);
        }
        public int Delete(int XSQYID)
        {
            return _DataAccess.Delete(XSQYID);
        }
        public IList<CRM_KH_GROUP_XSQY> Read()
        {
            return _DataAccess.Read();
        }
    }
}

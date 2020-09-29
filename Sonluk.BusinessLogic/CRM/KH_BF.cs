using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class KH_BF
    {
        private static readonly IKH_BF _DataAccess = RMSDataAccess.CreateKH_BF();
        public int Create(CRM_KH_BF model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_KH_BF model)
        {
            return _DataAccess.Update(model);
        }
        public int Delete(int BFID)
        {
            return _DataAccess.Delete(BFID);

        }
        public IList<CRM_KH_BFList> Read(CRM_KH_BF model)
        {
            return _DataAccess.Read(model);
        }
    }
}

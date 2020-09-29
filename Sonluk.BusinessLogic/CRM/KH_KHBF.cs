using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class KH_KHBF
    {
        private static readonly IKH_KHBF _DataAccess = RMSDataAccess.CreateKH_KHBF();
        public int Create(CRM_KH_KHBFList model)
        {
            return _DataAccess.Create(model);
        }

        public int Delete(CRM_KH_KHBFList model)
        {
            return _DataAccess.Delete(model);
        }
        public IList<CRM_KH_KHBFList> Read(int BFID, int KHID)
        {
            return _DataAccess.Read(BFID, KHID);
        }
        public IList<CRM_KH_KHBFList> ReadByParms(CRM_KH_KHBF_Parms model)
        {
            return _DataAccess.ReadByParms(model);
        }
    }
}

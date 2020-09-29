using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class KH_GROUP
    {
        private static readonly IKH_GROUP _DataAccess = RMSDataAccess.CreateKH_GROUP();
        public int Create(CRM_KH_GROUP model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_KH_GROUP model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_KH_GROUPList> Read()
        {
            return _DataAccess.Read();
        }
        public IList<CRM_KH_GROUPList> ReadByParam(CRM_KH_GROUPList model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delect(int GID)
        {
            return _DataAccess.Delect(GID);
        }
        public CRM_KH_GROUPList ReadbyGId(int GID)
        {
            return _DataAccess.ReadbyGId(GID);
        }
        public IList<CRM_KH_GROUPList> ReadBySTAFFID(int STAFFID)
        {
            return _DataAccess.ReadBySTAFFID(STAFFID);
        }
        public int ReadGidByGNAME(string gname)
        {
            return _DataAccess.ReadGidByGNAME(gname);
        }
       
    }
}

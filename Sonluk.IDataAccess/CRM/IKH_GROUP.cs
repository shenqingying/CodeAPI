using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IKH_GROUP
    {
        int Create(CRM_KH_GROUP model);
        int Update(CRM_KH_GROUP model);
        IList<CRM_KH_GROUPList> Read();
        IList<CRM_KH_GROUPList> ReadByParam(CRM_KH_GROUPList model);
        int Delect(int GID);
        CRM_KH_GROUPList ReadbyGId(int GID);
        IList<CRM_KH_GROUPList> ReadBySTAFFID(int STAFFID);
        int ReadGidByGNAME(string gname);
       
    }
}

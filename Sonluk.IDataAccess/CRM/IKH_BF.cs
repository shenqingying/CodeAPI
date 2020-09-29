using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IKH_BF
    {
         int Create(CRM_KH_BF model);
         int Update(CRM_KH_BF model);
         int Delete(int BFID);
         IList<CRM_KH_BFList> Read(CRM_KH_BF model);
    }
}

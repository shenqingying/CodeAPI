using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IKH_KHBF
    {
        int Create(CRM_KH_KHBFList model);
        //int Update(CRM_KH_KHBFList model);
        int Delete(CRM_KH_KHBFList model);
        IList<CRM_KH_KHBFList> Read(int BFID, int KHID);
        IList<CRM_KH_KHBFList> ReadByParms(CRM_KH_KHBF_Parms model);
    }
}

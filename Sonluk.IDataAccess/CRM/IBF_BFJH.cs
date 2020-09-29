using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IBF_BFJH
    {
        int Create(CRM_BF_BFJH model);
        int Update(CRM_BF_BFJH model);
        int Delete(int BFJHID);

        //IList<CRM_BF_BFJHList> Report(CRM_BF_BFJH model);

        IList<CRM_BF_STAFFList> Report_STAFF(CRM_BF_STAFFList model);
        IList<CRM_BF_KHList> Report_KH(CRM_BF_KHList model);
        IList<CRM_BF_BFJHList> ReadByParams(int BFLX, string BFJHMC, string FROMDATE, string TODATE, int STAFFID);
        CRM_BF_BFJH ReadByID(int BFJHID);
    }
}

using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IHG_KQDZ
    {
        int Create(CRM_HG_KQDZ model);
        int Update(CRM_HG_KQDZ model);
        int Delete(int KQDZID);
        IList<CRM_HG_KQDZ> Read(int KQDZID);
        IList<CRM_HG_KQDZ> ReadBySTAFFID(int STAFFID);
        IList<CRM_HG_KQDZ> ReadBylikeKQDZ(string KQDZ);

        IList<CRM_HG_KQDZList> Report(CRM_HG_KQDZList model);
    }
}

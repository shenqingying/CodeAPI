using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IKH_GROUP_STAFF
    {
        int Create(int STAFFID, int GID);
        int Delete(int STAFFID, int GID);
        IList<string[]> ReadByStaffID(int StaffID);
        IList<string[]> Read();
        CRM_KH_GROUP_STAFFList ReadStruct(int STAFFID, int GID);
        int Update(int STAFFID, int oGID, int nGid);
        IList<CRM_KH_GROUP_STAFFList> Report(string STAFFNAME, int GID);

    }
}

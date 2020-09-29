using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IHG_ROLE
    {
        int Create(CRM_HG_ROLE model);
        int Update(CRM_HG_ROLE model);
        int Delete(int ROLEID);
        IList<CRM_HG_ROLE> Read();
        int Create_STAFFROLE(int STAFFID, int ROLEID);
        IList<string[]> Read_STAFFROLEbyROLEID(int ROLEID);
        int Delete_STAFFROLE(int STAFFID, int ROLEID);
        int Create_ROLERIGHT(int ROLEID, int RIGHTID);
        IList<string[]> Read_ROLERIGHTByRIGHTID(int RIGHTID);
        int Delete_ROLERIGHT(int ROLEID, int RIGHTID);
        IList<CRM_HG_STAFFROLEList> Read_STAFFROLEbySTAFFID(int STAFFID);
        int Delete_STAFFROLEByStaffid(int STAFFID);
        IList<int> Read_ROLERIGHTByROLEID(int ROLEID);

    }
}

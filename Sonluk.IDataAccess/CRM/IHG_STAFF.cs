using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IHG_STAFF
    {
        int Create(CRM_HG_STAFF model);
        int Update(CRM_HG_STAFF model);
        int Delete(int STAFFID);
        IList<CRM_HG_STAFFList> Report(CRM_Report_STAFFModel model, string TYPE);
        CRM_HG_STAFF RaedBySTAFFID(int STAFFID);
        CRM_HG_STAFF ReadBySTAFFNO(string STAFFNO);
        CRM_HG_STAFF ReadByROLEID(int ROLEID);
        IList<CRM_HG_STAFF> ReadByDUTYID(int DUTYID);
        IList<CRM_HG_STAFFList> ReadByParam(CRM_HG_STAFF model);
        IList<CRM_HG_STAFFList> ReadUser();
        IList<STAFFDUTY_KH> ReadSTAFFBYKHIDANDDUTY(int KHID, int DUTYID);
        IList<CRM_HG_STAFF> ReadSTAFF_KHGOURPBYSTAFFID(int STAFFID);
        IList<CRM_HG_STAFF> ReadSTAFF_KHGroupByStaffidAndDuty(int STAFFID, int DUTYID);
        IList<CRM_HG_STAFF> ReadStaff_BYDEPID(int STAFFID);
        IList<CRM_HG_STAFFList> ReadUser_STAFF(CRM_Report_STAFFModel model);
    }
}

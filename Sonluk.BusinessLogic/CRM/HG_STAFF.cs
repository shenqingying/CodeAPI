using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class HG_STAFF
    {
        private static readonly IHG_STAFF _DataAccess = RMSDataAccess.CreateHG_STAFF();

        public int Create(CRM_HG_STAFF model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_HG_STAFF model)
        {
            return _DataAccess.Update(model);
        }
        public int Delete(int STAFFID)
        {
            return _DataAccess.Delete(STAFFID);
        }
        public IList<CRM_HG_STAFFList> Report(CRM_Report_STAFFModel model, string TYPE)
        {
            return _DataAccess.Report(model, TYPE);
        }
        public CRM_HG_STAFF RaedBySTAFFID(int STAFFID)
        {
            return _DataAccess.RaedBySTAFFID(STAFFID);
        }
        public CRM_HG_STAFF ReadBySTAFFNO(string STAFFNO)
        {
            return _DataAccess.ReadBySTAFFNO(STAFFNO);
        }
        public CRM_HG_STAFF ReadByROLEID(int ROLEID)
        {
            return _DataAccess.ReadByROLEID(ROLEID);
        }
        public IList<CRM_HG_STAFF> ReadByDUTYID(int DUTYID)
        {
            return _DataAccess.ReadByDUTYID(DUTYID);
        }
        public IList<CRM_HG_STAFFList> ReadByParam(CRM_HG_STAFF model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public IList<CRM_HG_STAFFList> ReadUser()
        {
            return _DataAccess.ReadUser();
        }
        public IList<STAFFDUTY_KH> ReadSTAFFBYKHIDANDDUTY(int KHID, int DUTYID)
        {
            return _DataAccess.ReadSTAFFBYKHIDANDDUTY(KHID, DUTYID);
        }
        public IList<CRM_HG_STAFF> ReadSTAFF_KHGOURPBYSTAFFID(int STAFFID)
        {
            return _DataAccess.ReadSTAFF_KHGOURPBYSTAFFID(STAFFID);
        }
        public IList<CRM_HG_STAFF> ReadSTAFF_KHGroupByStaffidAndDuty(int STAFFID, int DUTYID)
        {
            return _DataAccess.ReadSTAFF_KHGroupByStaffidAndDuty(STAFFID, DUTYID);
        }
        public IList<CRM_HG_STAFF> ReadStaff_BYDEPID(int STAFFID)
        {
            return _DataAccess.ReadStaff_BYDEPID(STAFFID);
        }
        public IList<CRM_HG_STAFFList> ReadUser_STAFF(CRM_Report_STAFFModel model)
        {
            return _DataAccess.ReadUser_STAFF(model);
        }
    }
}

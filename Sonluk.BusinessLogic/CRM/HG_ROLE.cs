using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class HG_ROLE
    {
        private static readonly IHG_ROLE _DataAccess = RMSDataAccess.CreateHG_ROLE();
        public int Create(CRM_HG_ROLE model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_HG_ROLE model)
        {
            return _DataAccess.Update(model);
        }

        public int Delete(int ROLEID)
        {
            return _DataAccess.Delete(ROLEID);
        }
        public IList<CRM_HG_ROLE> Read()
        {
            return _DataAccess.Read();
        }

        public int Create_STAFFROLE(int STAFFID, int ROLEID)
        {
            return _DataAccess.Create_STAFFROLE(STAFFID, ROLEID);
        }
        public IList<string[]> Read_STAFFROLEbyROLEID(int ROLEID)
        {
            return _DataAccess.Read_STAFFROLEbyROLEID(ROLEID);
        }
        public int Delete_STAFFROLE(int STAFFID, int ROLEID)
        {
            return _DataAccess.Delete_STAFFROLE(STAFFID, ROLEID);
        }
        public int Create_ROLERIGHT(int ROLEID, int RIGHTID)
        {
            return _DataAccess.Create_ROLERIGHT(ROLEID, RIGHTID);
        }
        public IList<string[]> Read_ROLERIGHTByRIGHTID(int RIGHTID)
        {
            return _DataAccess.Read_ROLERIGHTByRIGHTID(RIGHTID);
        }
        public int Delete_ROLERIGHT(int ROLEID, int RIGHTID)
        {
            return _DataAccess.Delete_ROLERIGHT(ROLEID, RIGHTID);
        }
        public IList<CRM_HG_STAFFROLEList> Read_STAFFROLEbySTAFFID(int STAFFID)
        {
            return _DataAccess.Read_STAFFROLEbySTAFFID(STAFFID);
        }
        public int Delete_STAFFROLEByStaffid(int STAFFID)
        {
            return _DataAccess.Delete_STAFFROLEByStaffid(STAFFID);
        }
        public IList<int> Read_ROLERIGHTByROLEID(int ROLEID)
        {
            return _DataAccess.Read_ROLERIGHTByROLEID(ROLEID);
        }
    }
}

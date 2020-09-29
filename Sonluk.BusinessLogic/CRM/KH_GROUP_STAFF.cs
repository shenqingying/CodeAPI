using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public  class KH_GROUP_STAFF
    {
        private static readonly IKH_GROUP_STAFF _DataAccess = RMSDataAccess.CreateKH_GROUP_STAFF();
        public int Create(int STAFFID, int GID)
        {
          return  _DataAccess.Create(STAFFID, GID);
        }
        public int Delete(int STAFFID, int GID)
        {
            return _DataAccess.Delete(STAFFID, GID);
        }
        public IList<string[]> ReadByStaffID(int StaffID)
        {
            return _DataAccess.ReadByStaffID(StaffID);
        }
        public IList<string[]> Read()
        {
            return _DataAccess.Read();
        }
        public CRM_KH_GROUP_STAFFList ReadStruct(int STAFFID, int GID)
        {
            return _DataAccess.ReadStruct(STAFFID, GID);
        }
        public int Update(int STAFFID, int oGID, int nGid)
        {
            return _DataAccess.Update(STAFFID, oGID, nGid);
        }
        public IList<CRM_KH_GROUP_STAFFList> Report(string STAFFNAME, int GID)
        {
            return _DataAccess.Report(STAFFNAME, GID);
        }
    }
}

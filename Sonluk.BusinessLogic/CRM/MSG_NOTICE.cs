using Sonluk.Entities.CRM;
using Sonluk.DAFactory;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class MSG_NOTICE
    {
        private static readonly IMSG_NOTICE _DataAccess = RMSDataAccess.CreateIMSG_NOTICE();
        public int CreateTT(CRM_MSG_NOTICETT model)
        {
            return _DataAccess.CreateTT(model);
        }
        public int CreateMX(CRM_MSG_NOTICEMX model)
        {
            return _DataAccess.CreateMX(model);
        }
        public IList<CRM_MSG_NOTICETTList> ReadTT(CRM_MSG_NOTICETTParam model)
        {
            return _DataAccess.ReadTT(model);
        }
        public CRM_MSG_NOTICETTList ReadTTbyTTID(int NOTICETTID)
        {
            return _DataAccess.ReadTTbyTTID(NOTICETTID);
        }
        public IList<CRM_MSG_NOTICEMXList_KH> ReadMXbyTTID_KH(int NOTICETTID)
        {
            return _DataAccess.ReadMXbyTTID_KH(NOTICETTID);
        }
        public IList<CRM_MSG_NOTICEMXList_STAFF> ReadMXbyTTID_STAFF(int NOTICETTID)
        {
            return _DataAccess.ReadMXbyTTID_STAFF(NOTICETTID);
        }
        public int UpdateTT(CRM_MSG_NOTICETT model)
        {
            return _DataAccess.UpdateTT(model);
        }
        public int UpdateIsactive(int NOTICETTID, int ISACTIVE)
        {
            return _DataAccess.UpdateIsactive(NOTICETTID, ISACTIVE);
        }
        public int UpdateMX(CRM_MSG_NOTICEMX model)
        {
            return _DataAccess.UpdateMX(model);
        }
        public int DeleteTT(int NOTICETTID)
        {
            return _DataAccess.DeleteTT(NOTICETTID);
        }
        public int DeleteMX(int NOTICEMXID)
        {
            return _DataAccess.DeleteMX(NOTICEMXID);
        }
        public IList<CRM_MSG_NOTICETTList> ReadBySTAFFID(int STAFFID, int USERLX)
        {
            return _DataAccess.ReadBySTAFFID(STAFFID, USERLX);
        }
        public int AddCount(int NOTICETTID, int USERID)
        {
            return _DataAccess.AddCount(NOTICETTID, USERID);
        }
        public IList<CRM_MSG_NOTICEMX> ReadMXbyParam(CRM_MSG_NOTICEMX model)
        {
            return _DataAccess.ReadMXbyParam(model);
        }




    }
}

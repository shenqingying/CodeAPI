using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IMSG_NOTICE
    {
        int CreateTT(CRM_MSG_NOTICETT model);
        int CreateMX(CRM_MSG_NOTICEMX model);
        IList<CRM_MSG_NOTICETTList> ReadTT(CRM_MSG_NOTICETTParam model);
        CRM_MSG_NOTICETTList ReadTTbyTTID(int NOTICETTID);
        IList<CRM_MSG_NOTICEMXList_KH> ReadMXbyTTID_KH(int NOTICETTID);
        IList<CRM_MSG_NOTICEMXList_STAFF> ReadMXbyTTID_STAFF(int NOTICETTID);
        int UpdateTT(CRM_MSG_NOTICETT model);
        int UpdateIsactive(int NOTICETTID, int ISACTIVE);
        int UpdateMX(CRM_MSG_NOTICEMX model);
        int DeleteTT(int NOTICETTID);
        int DeleteMX(int NOTICEMXID);
        IList<CRM_MSG_NOTICETTList> ReadBySTAFFID(int STAFFID, int USERLX);
        int AddCount(int NOTICETTID, int USERID);
        IList<CRM_MSG_NOTICEMX> ReadMXbyParam(CRM_MSG_NOTICEMX model);

    }
}

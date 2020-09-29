
using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICRM_KH
    {
        DataTable GetJL_MeasureTypedes();
        IList<UserModel> GetCheckUser();
        int InsertKH_KH(CRM_KH_KH KH_S);

        DataTable SelectKH_KHForKHLXandMC(int KHLX, string mc, int MCLC);
        int ModifyKH_KH(CRM_KH_KH KH_S);

        DataTable SelectKHReportWithReportModel(CRM_Report_KHModel model);

        int InsertCRM_KH_GXQY(CRM_KH_GXQY model);

        int InsertCRM_KH_LXR(CRM_KH_LXR model);

        int InsertKH_KHQTXX(CRM_KH_KHQTXX model);
        DataTable SelectKH_KHForKHID(int KHID);
        int InsertClXX(CRM_KH_KHQTXX model, int GSDX, string ml);

        DataTable SelectKH_KHQTXX(int KHID, int XXLB, int ISACTIVE);

    }
}

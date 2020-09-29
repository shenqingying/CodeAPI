using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IKQ_CC
    {
        int Create_MX(CRM_KQ_CCMX model);
        int Update_MX(CRM_KQ_CCMX model);
        int Delete_MX(int ID);
        IList<CRM_KQ_CCMX> Read_MXbyCCID(int CCID);
        IList<CRM_KQ_CCMXList> Read_MXQDbyCCID(int CCID);
        int Create_TT(CRM_KQ_CCTT model);
        int Update_TT(CRM_KQ_CCTT model);
        int Delete_TT(int CCID);
        IList<CRM_KQ_CCTTList> Read_TTbySTAFFID(int STAFFID, int Status);
        CRM_KQ_CCTT Read_TTbyCCID(int CCID);
        IList<CRM_KQ_CCTTList> Read_TTbyParam(CRM_KQ_CCTT model, int STATUS);
    }
}

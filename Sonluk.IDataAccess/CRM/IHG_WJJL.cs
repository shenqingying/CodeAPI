using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IHG_WJJL
    {
        int Create(CRM_HG_WJmodel model);
        int Delete(int JLID);
        IList<CRM_HG_WJJL> Read(int GSDX, int GSDXID);
        IList<CRM_HG_WJJL> ReadByParam(CRM_HG_WJJL model);
        IList<CRM_HG_WJJL> ReadLocation(int GSDX, int GSDXID);
        int Update_SP(CRM_HG_WJJL model);
        IList<CRM_HG_WJJL> DisplayImgReport(CRM_HG_WJJL_KHModel model, int STAFFID);
    }
}

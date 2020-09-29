using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IQYJS_MENU
    {
        int Create(CRM_QYJS_MENU model);
        int Update(CRM_QYJS_MENU model);
        int Delete(int CATALOGID);
        CRM_QYJS_MENU ReadbyID(int CATALOGID);
        IList<CRM_QYJS_MENU> ReadTTbyParam(CRM_QYJS_MENU model);


    }
}

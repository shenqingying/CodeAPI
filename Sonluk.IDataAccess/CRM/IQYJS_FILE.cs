using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IQYJS_FILE
    {
        int Create(CRM_QYJS_FILE model);
        int Update(CRM_QYJS_FILE model);
        IList<CRM_QYJS_FILE> ReadByParam(CRM_QYJS_FILE model);
        int Delete(int ID);



    }
}

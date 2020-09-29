using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IHD_ZDF
    {
        int Create(CRM_HD_ZDF model);
        int Update(CRM_HD_ZDF model);
        int Delete(int ZDFID);
        IList<CRM_HD_ZDFList> Read(CRM_HD_ZDF_PARAMS model);
        CRM_HD_ZDF ReadByZDFID(int ZDFID);
        IList<CRM_HD_ZDFList> ReadBySTAFFID(CRM_HD_ZDF_PARAMS model);

    }
}

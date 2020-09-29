using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_CXHDPGHZ
    {

        int Create(CRM_COST_CXHDPGHZ model);
        int Update(CRM_COST_CXHDPGHZ model);
        IList<CRM_COST_CXHDPGHZ> ReadByParam(CRM_COST_CXHDPGHZ model);
        int Delete(int PGHZID);
        int DeleteByCXHDID(int CXHDID);
        IList<CRM_COST_CXHDPGHZ> GetReport(CRM_COST_CXHDPGHZ model);




    }
}

using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_CBZX
    {

        int Create(CRM_COST_CBZX model);
        int Update(CRM_COST_CBZX model);
        IList<CRM_COST_CBZX> ReadByParam(CRM_COST_CBZX model);
        int Delete(string CBZXBH);






    }
}

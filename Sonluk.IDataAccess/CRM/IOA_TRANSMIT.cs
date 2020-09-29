using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IOA_TRANSMIT
    {
        int Create(CRM_OA_TRANSMIT model);
        int Update(CRM_OA_TRANSMIT model);
        int Delete(int ID);
        IList<CRM_OA_TRANSMIT> Read(int Status);
        IList<CRM_OA_TRANSMIT> ReadByParam(CRM_OA_TRANSMIT model);
    }
}

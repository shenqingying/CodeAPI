using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IHG_TYPE
    {
        int Create(CRM_HG_TYPE model);
        int Update(CRM_HG_TYPE model);
        IList<CRM_HG_TYPE> Read();
        int Delete(int TYPEID);
    }
}

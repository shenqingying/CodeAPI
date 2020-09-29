using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IKH_HZHB
    {
        int Create(CRM_KH_HZHB model);
        int Delete(string SAPSN);
        IList<CRM_KH_HZHBLIST> Read(string SAPSN);
        
    }
}

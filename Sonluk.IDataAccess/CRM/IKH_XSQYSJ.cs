using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IKH_XSQYSJ
    {
        int Create(CRM_KH_XSQYSJ model);
        int Delete(string SAPSN);
        CRM_KH_XSQYSJ ReadBySAPSN(string SAPSN);
    }
}

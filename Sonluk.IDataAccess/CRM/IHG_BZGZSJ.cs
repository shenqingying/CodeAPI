using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IHG_BZGZSJ
    {
        int Create(CRM_HG_BZGZSJ model);
        int Update(CRM_HG_BZGZSJ model);
        int Delete(int BZID);
        IList<CRM_HG_BZGZSJ> Read(int STAFFID);
        CRM_HG_BZGZSJ ReadByBZNAME(string BZNAME);
        CRM_HG_BZGZSJ ReadByBZID(int BZID);

    }
}

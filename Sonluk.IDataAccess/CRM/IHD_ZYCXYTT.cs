using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IHD_ZYCXYTT
    {
        int Create(CRM_HD_ZYCXYTT model);
        int Update(CRM_HD_ZYCXYTT model);
        int Delete(int ZYCXYID);
    }
}

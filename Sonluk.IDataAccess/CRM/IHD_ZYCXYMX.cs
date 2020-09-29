using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IHD_ZYCXYMX
    {
        int Create(CRM_HD_ZYCXYMX model);
        int Update(CRM_HD_ZYCXYMX model);
        int Delete(int ZYCXYMXID);
    }
}

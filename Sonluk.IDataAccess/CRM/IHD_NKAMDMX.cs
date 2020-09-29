using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IHD_NKAMDMX
    {
        int Create(CRM_HD_NKAMDMX model);
        int Update(CRM_HD_NKAMDMX model);
        int Delete(int NKAMDMXID);
    }
}

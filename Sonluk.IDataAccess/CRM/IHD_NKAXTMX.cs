using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IHD_NKAXTMX
    {
        int Create(CRM_HD_NKAXTMX model);
        int Update(CRM_HD_NKAXTMX model);
        int Delete(int NKAXTMXID);
    }
}

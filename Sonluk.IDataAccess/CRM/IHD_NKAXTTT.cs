using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IHD_NKAXTTT
    {
        int Create(CRM_HD_NKAXTTT model);
        int Update(CRM_HD_NKAXTTT model);
        int Delete(int NKAXTID);
    }
}

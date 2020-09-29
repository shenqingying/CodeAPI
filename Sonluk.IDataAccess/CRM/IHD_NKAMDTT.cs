using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IHD_NKAMDTT
    {
         int Create(CRM_HD_NKAMDTT model);
         int Update(CRM_HD_NKAMDTT model);
         int Delete(int NKAMDID);
    }
}

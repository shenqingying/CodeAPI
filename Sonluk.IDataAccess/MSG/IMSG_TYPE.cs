using Sonluk.Entities.MSG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MSG
{
    public interface IMSG_TYPE
    {
        int Create(MSG_MSG_TYPE model);
        int Update(MSG_MSG_TYPE model);
        IList<MSG_MSG_TYPE> ReadByParam(MSG_MSG_TYPE model);
        int Delete(int MSGTYPEID);

    }
}

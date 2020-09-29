using Sonluk.Entities.MSG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MSG
{
    public interface ISEND_INFO
    {
        int Create(MSG_SEND_INFO model);
        int Update(MSG_SEND_INFO model);
        IList<MSG_SEND_INFO> ReadByParam(MSG_SEND_INFO model);
        int Delete(int INFOID);

    }
}

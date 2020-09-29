using Sonluk.Entities.MSG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MSG
{
    public interface IMSG_SENDWAY
    {
        int Create(MSG_MSG_SENDWAY model);
        int Update(MSG_MSG_SENDWAY model);
        IList<MSG_MSG_SENDWAY> ReadByParam(MSG_MSG_SENDWAY model);
        int Delete(int SENDWAYID, int XGR);



    }
}

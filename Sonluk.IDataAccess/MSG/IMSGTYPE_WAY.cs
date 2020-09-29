using Sonluk.Entities.MSG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MSG
{
    public interface IMSGTYPE_WAY
    {
        int Create(MSG_MSGTYPE_WAY model);
        IList<MSG_MSGTYPE_WAY> ReadByParam(MSG_MSGTYPE_WAY model);
        int Delete(MSG_MSGTYPE_WAY model);
        int DeleteByTYPEID(int TYPEID);


    }
}

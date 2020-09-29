using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IRIGHT_ROLE
    {
        MES_RIGHT_ROLE SELECT(int STAFFID, int RGROUPID, int LANGUAGEID);
        MES_RIGHT_ROLE SELECT_ALL(int STAFFID, int RGROUPID, int LANGUAGEID);
        MES_RIGHT_ROLE SELECT_Android(int STAFFID);
    }
}

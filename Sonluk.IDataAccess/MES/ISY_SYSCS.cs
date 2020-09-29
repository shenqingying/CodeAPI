using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface ISY_SYSCS
    {
        string SELECT(string CSNAME);
        MES_RETURN UPDATE_SYNC(string CSNAME, string CSINFO);
    }
}

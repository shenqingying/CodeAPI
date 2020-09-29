using Sonluk.Entities.EM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.EM
{
    public interface IEM_MISSION
    {
        ZSD_XBZ_CHANGEINFORESULT ZSD_XBZ_CHANGEINFO(string FUNTYPE, string MISSION);
        ZSD_XBZ_MAINRESULT ZSD_XBZ_MAIN(ZSD_XBZ_MAINRESULT importList);
    }
}

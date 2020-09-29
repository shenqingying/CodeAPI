using Sonluk.DAFactory;
using Sonluk.Entities.EM;
using Sonluk.IDataAccess.EM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.EM
{
    public class EM_MISSION
    {
        private static readonly IEM_MISSION _DataAccess = EMDataAccess.CreateIMISSION();
        public ZSD_XBZ_CHANGEINFORESULT ZSD_XBZ_CHANGEINFO_Read( string MISSION)
        {
            
            return _DataAccess.ZSD_XBZ_CHANGEINFO("R",MISSION);
        }
        public ZSD_XBZ_MAINRESULT ZSD_XBZ_MAIN_Read(ZSD_XBZ_MAINRESULT importList)
        {
            importList.EM_MISSION_IMPORT.FUNTYPE = "R";
            return _DataAccess.ZSD_XBZ_MAIN(importList); 
        }
        public ZSD_XBZ_MAINRESULT ZSD_XBZ_MAIN_UPDATE(ZSD_XBZ_MAINRESULT importList)
        {
            importList.EM_MISSION_IMPORT.FUNTYPE = "U";
            return _DataAccess.ZSD_XBZ_MAIN(importList);
        }

    }
}

using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class RIGHT_ROLE
    {
        private static readonly IRIGHT_ROLE mesdetaAccess = MESDataAccess.CreateRIGHT_ROLE();
        public MES_RIGHT_ROLE SELECT(int STAFFID, int RGROUPID, int LANGUAGEID)
        {
            return mesdetaAccess.SELECT(STAFFID, RGROUPID, LANGUAGEID);
        }
        public MES_RIGHT_ROLE SELECT_ALL(int STAFFID, int RGROUPID, int LANGUAGEID)
        {
            return mesdetaAccess.SELECT_ALL(STAFFID, RGROUPID, LANGUAGEID);
        }
        public MES_RIGHT_ROLE SELECT_Android(int STAFFID)
        {
            return mesdetaAccess.SELECT_Android(STAFFID);
        }
    }
}

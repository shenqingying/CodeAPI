using Sonluk.DAFactory;
using Sonluk.Entities.BC;
using Sonluk.Entities.MM;
using Sonluk.IDataAccess.MM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MM
{
    public class MATERIALINFO
    {
        private static readonly IMATERIALINFO data_IMATERIALINFO = MMDataAccess.CreateIMATERIALINFO();
        public ZBCFUN_MMINFO_READ_RETURN ZBCFUN_MMINFO_READ(ZSL_BCS112 IS_MATDATA)
        {
            return data_IMATERIALINFO.ZBCFUN_MMINFO_READ(IS_MATDATA);
        }
    }
}

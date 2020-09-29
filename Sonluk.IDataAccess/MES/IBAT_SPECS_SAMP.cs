using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IBAT_SPECS_SAMP
    {
        MES_DCCCCYSJ_SELECT SELECT(MES_DCCCCYSJ model);
        MES_RETURN UPDATE(MES_DCCCCYSJ model);
        MES_RETURN INSERT(MES_DCCCCYSJ model);
        MES_RETURN DELETE(int RI);
    }
}

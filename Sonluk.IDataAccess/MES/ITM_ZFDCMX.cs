using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface ITM_ZFDCMX
    {
        MES_RETURN INSERT(MES_TM_ZFDCMX model);
        MES_TM_ZFDCMX_SELECT SELECT(string TM);
        MES_RETURN DELETE(MES_TM_ZFDCMX model);
    }
}

using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IZS_QJ_QJJL
    {
        MES_RETURN INSERT(MES_ZS_QJ_QJJL model);
        MES_RETURN INSERT_QJSB(MES_ZS_QJ_QJSB model);
        MES_ZS_QJ_QJSB_SELECT SELECT_QJSB(MES_ZS_QJ_QJSB model);
        MES_RETURN INSERT_ERRORJL(MES_ZS_QJ_ERRORJL model);
        MES_ZS_QJ_ERRORJL_SELECT SELECT_ERRORJL(MES_ZS_QJ_ERRORJL model);
    }
}

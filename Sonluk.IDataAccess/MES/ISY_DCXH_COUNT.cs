using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface ISY_DCXH_COUNT
    {
        MES_SY_DCXH_COUNT_SELECT SELECT(MES_SY_DCXH_COUNT model);
        MES_RETURN INSERT(MES_SY_DCXH_COUNT model);
        MES_RETURN UPDATE(MES_SY_DCXH_COUNT model);
        MES_RETURN DELETE(MES_SY_DCXH_COUNT model);
        MES_SY_DCXH_COUNT_SELECT SELECT_LB(MES_SY_DCXH_COUNT model);
    }
}

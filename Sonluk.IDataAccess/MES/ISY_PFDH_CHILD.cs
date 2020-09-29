using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface ISY_PFDH_CHILD
    {
        MES_RETURN INSERT(MES_SY_PFDH_CHILD model);
        MES_RETURN DELETE(MES_SY_PFDH_CHILD model, int LB);
        MES_SY_PFDH_CHILD_SELECT SELECT(MES_SY_PFDH_CHILD model);
    }
}

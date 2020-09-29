using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface ISY_TYPEMX_CHILD
    {
        MES_SY_TYPEMX_CHILD_SELECT SELECT(MES_SY_TYPEMX_CHILD model);
        MES_RETURN INSERT(MES_SY_TYPEMX_CHILD model);
        MES_RETURN UPDATE(MES_SY_TYPEMX_CHILD model);
        MES_RETURN DELETE(MES_SY_TYPEMX_CHILD model);
    }
}

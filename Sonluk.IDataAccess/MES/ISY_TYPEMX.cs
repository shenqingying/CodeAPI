using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface ISY_TYPEMX
    {
        IList<MES_SY_TYPEMXLIST> SELECT(MES_SY_TYPEMX model);
        MES_RETURN INSERT(MES_SY_TYPEMX model);
        MES_RETURN UPDATE(MES_SY_TYPEMX model);
        MES_RETURN DELETE(int ID);
        MES_RETURN SELECT_ZJDATE(MES_SY_TYPEMX model);
        IList<MES_SY_TYPEMXLIST> SELECT_SBFL_BY_GZZX(string GC, string GZZXBH);
    }
}

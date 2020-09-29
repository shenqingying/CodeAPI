using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface ISY_EXCEPTION
    {
        MES_RETURN INSERT_ALL(string EXCEPTIONINFO, string EXCEPTIONMK, string EXCEPTIONIN, string EXCEPTIONSY);
        MES_RETURN INSERT_CCGC(MES_SY_CCGCRETRUN model);
    }
}

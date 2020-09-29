using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.DEV
{
    public interface ITable
    {
        string Read(string name, string language);
    }
}

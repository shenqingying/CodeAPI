using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.Account
{
    public interface IAccess
    {
        int SignIn(string name, string passwordHash);
    }
}

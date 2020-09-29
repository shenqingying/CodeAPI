using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.OA
{
    public interface IAuthority
    {
        string Authenticate(string name, string password);
    }
}

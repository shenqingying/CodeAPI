using Sonluk.Entities.BC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.BC
{
    public interface IUser
    {
        UserInfo Read(string signInName);

    }
}

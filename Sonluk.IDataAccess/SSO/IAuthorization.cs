using Sonluk.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.SSO
{
    public interface IAuthorization
    {
        IList<string> Read(int UID);

        IList<MenuInfo> Menu(int UID, int parent);
    }
}

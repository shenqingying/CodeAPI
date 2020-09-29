using Sonluk.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.Account
{
    public interface IAuthorization
    {
        AuthorizationInfo Read(string accountName);
    }
}

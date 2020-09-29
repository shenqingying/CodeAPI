using Sonluk.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.Account
{
    public interface IPurchaser
    {
        AccountInfo SignIn(string name, string password);

        bool ChangePassword(string account, string password, string newPassword);
    }
}

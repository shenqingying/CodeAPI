using Sonluk.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.Account
{
    public interface IVendor
    {
        AccountInfo SignIn(string vendor, string password);

        bool ChangePassword(string vendor, string password, string newPassword);
    }
}

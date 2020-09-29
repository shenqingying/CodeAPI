using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.DAFactory;
using Sonluk.IDataAccess.Account;
using Sonluk.Entities.Account;

namespace Sonluk.BusinessLogic.Account
{
    public class Vendor
    {
        private static readonly IVendor detaAccess = AccountDataAccess.CreateVendor();
        public AccountInfo SignIn(string vendor, string password)
        {
            return detaAccess.SignIn(vendor.Trim(), password.Trim());
        }

        public bool ChangePassword(string vendor, string password, string newPassword)
        {
            return detaAccess.ChangePassword(vendor.Trim(), password.Trim(), newPassword.Trim());
        }
    }
}

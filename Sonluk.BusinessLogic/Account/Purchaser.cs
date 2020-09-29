using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.DAFactory;
using Sonluk.IDataAccess.Account;
using Sonluk.Entities.Account;

namespace Sonluk.BusinessLogic.Account
{
    public class Purchaser
    {
        private static readonly IPurchaser detaAccess = AccountDataAccess.CreatePurchaser();
        public AccountInfo SignIn(string account, string password)
        {
            return detaAccess.SignIn(account.Trim(), password.Trim());
        }

        public bool ChangePassword(string account, string password, string newPassword)
        {
            return detaAccess.ChangePassword(account.Trim(), password.Trim(), newPassword.Trim());
        }
    }
}

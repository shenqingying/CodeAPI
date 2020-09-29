using Sonluk.DAFactory;
using Sonluk.Entities.Account;
using Sonluk.IDataAccess.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.Account
{
    public class Authorization
    {
        private static readonly IAuthorization detaAccess = AccountDataAccess.CreateAuthorization();

        public AuthorizationInfo Read(string accountName)
        {
            return detaAccess.Read(accountName);   
        }
    }
}

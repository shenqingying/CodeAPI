using Newtonsoft.Json;
using Sonluk.DAFactory;
using Sonluk.Entities.Account;
using Sonluk.IDataAccess.SSO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Sonluk.BusinessLogic.SSO
{
    public class User
    {

        private static readonly IUser detaAccess = SSODataAccess.CreateUser();

        public AccountInfo SignIn(string name, string passwordHash)
        {
            AccountInfo account = null;
            bool signIn = false;

            if (name != null && name.Length > 0 && passwordHash != null && passwordHash.Length > 0)
            {
                int UID = detaAccess.SignIn(name, passwordHash);

                if (UID > 0)
                {
                    signIn = true;
                    account = Read(UID);
                }
            }

            if (account == null)
                account = new AccountInfo();

            account.SignIn = signIn;
           
            return account;
        }
        public AccountInfo SignIn_OnlyName(string name)
        {
            AccountInfo account = null;
            bool signIn = false;

            if (name != null && name.Length > 0)
            {
                int UID = detaAccess.SignIn_OnlyName(name);

                if (UID > 0)
                {
                    signIn = true;
                    account = Read(UID);
                }
            }

            if (account == null)
                account = new AccountInfo();

            account.SignIn = signIn;

            return account;
        }

        private RouteInfo Route(int type)
        {
            RouteInfo route = new RouteInfo();
            return route;
        }

        public bool ChangePassword(int ID, string passwordHash, string newPasswordHash)
        {
            return detaAccess.ChangePassword(ID, passwordHash, newPasswordHash);
        }

        public AccountInfo Read(int ID)
        {
            AccountInfo account = detaAccess.Read(ID);

            if (account != null)
            {
                Authorization authorization = new Authorization();
                account.Authorization = authorization.Read(ID).ToList();
                account.Menu = authorization.Menu(ID, true);
            }
            return account;
        }

        public TokenInfo Token(string name, string password)
        {
            return detaAccess.Token(name, password);
        }
        public AccountInfo AcceptToken(string ptoken)
        {
            return detaAccess.AcceptToken(ptoken);
        }
        
        public Boolean ValidateToken(string ptoken)
        {
            return detaAccess.ValidateToken(ptoken);
        }

    }
}

using Sonluk.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.SSO
{
    public interface IUser
    {
        int SignIn(string name, string password);
        int SignIn_OnlyName(string name);

        AccountInfo Read(int SN);

        bool ChangePassword(int SN, string passwordHash, string newPasswordHash);

        TokenInfo Token(string name, string password);
        AccountInfo AcceptToken(string ptoken);
        Boolean ValidateToken(string ptoken);
    }
}

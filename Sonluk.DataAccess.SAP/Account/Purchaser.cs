using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using Sonluk.IDataAccess.Account;
using Sonluk.Entities.Account;
using Sonluk.DataAccess.SAP.Utility;

namespace Sonluk.DataAccess.SAP.Account
{
    public class Purchaser : IPurchaser 
    {
        public AccountInfo SignIn(string id, string password)
        {
            IRfcFunction func = RFC.Function("ZMM_ACCESS");
            func.SetValue("ILUSER", id);
            func.SetValue("IPASSWD", password);
            AccountInfo account = new AccountInfo();
            try
            {
                RFC.Invoke(func, false);
                if (func.GetString("OKCODE").Equals("1") && func.GetString("RIGHTSTR").Equals("1"))
                {
                    account.Name = func.GetString("USERNAME");
                    account.Group = Convert.ToInt32(func.GetString("USER_GROUP"));
                }
                else
                {
                    account.Name = "";
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return account;
        }

        public bool ChangePassword(string account, string password, string newPassword)
        {
            IRfcFunction func = RFC.Function("ZMMUPDATEPWD");
            func.SetValue("ILUSER", account);
            func.SetValue("IPASSWD", password);
            func.SetValue("NPASSWD", newPassword);
            bool access = false;

            try
            {
                RFC.Invoke(func, false);
                if (func.GetString("OKCODE").Equals("1"))
                {
                    access = true;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return access;
        }

    }
}

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
    public class Vendor : IVendor
    {
        public AccountInfo SignIn(string vendor, string password)
        {
            IRfcFunction func = RFC.Function("ZMM_VENDOR_ACCESS");
            func.SetValue("LIFNR", vendor);
            func.SetValue("PWD", password);
            AccountInfo account = new AccountInfo();
            try
            {
                RFC.Invoke(func, false);
                if (func.GetString("OKCODE").Equals("1"))
                {
                    account.Name = func.GetString("VNAME");
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

        public bool ChangePassword(string vendor, string password, string newPassword)
        {
            IRfcFunction func = RFC.Function("ZVDPUPDATE");
            func.SetValue("LIFNR", vendor);
            func.SetValue("PWD", password);
            func.SetValue("NPWD", newPassword);
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

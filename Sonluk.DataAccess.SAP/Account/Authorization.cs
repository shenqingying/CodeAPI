using SAP.Middleware.Connector;
using Sonluk.DataAccess.SAP.Utility;
using Sonluk.Entities.Account;
using Sonluk.IDataAccess.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.SAP.Account
{
    public class Authorization : IAuthorization
    {

        public AuthorizationInfo Read(string user)
        {
            IRfcFunction func = RFC.Function("ZUSER_AUTHORIZATION_READ");
            func.SetValue("USER", user);
            AuthorizationInfo node = new AuthorizationInfo();
            try
            {
                RFC.Invoke(func, false);
                IRfcStructure struc = func.GetStructure("AUTH");
                node.PurchasingGroup = struc.GetString("PUR_GROUP");
                node.ReleaseGroup = struc.GetString("REL_GROUP");
                node.ReleaseCode = struc.GetString("REL_CODE");

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return node;
        }
    }
}

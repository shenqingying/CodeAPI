using SAP.Middleware.Connector;
using Sonluk.DataAccess.SAP.Utility;
using Sonluk.Entities.BC;
using Sonluk.IDataAccess.BC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.SAP.BC
{
    public class User : IUser
    {
        public UserInfo Read(string signInName)
        {
            IRfcFunction func = RFC.Function("BAPI_USER_GET_DETAIL");
            func.SetValue("USERNAME", signInName);
            func.SetValue("CACHE_RESULTS", "X");
            UserInfo node = new UserInfo();
            try
            {
                RFC.Invoke(func, false);
                IRfcStructure addressStruc = func.GetStructure("ADDRESS");
                node.Address = new AddressInfo();
                node.Address.FullName = addressStruc.GetString("FULLNAME");

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return node;
        }
    }
}

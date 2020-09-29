using Sonluk.DAFactory;
using Sonluk.IDataAccess.OA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.OA
{
    public class Authority
    {
        private static readonly IAuthority _DetaAccess = OADataAccess.CreateAuthority();

        public string Authenticate()
        {
            return _DetaAccess.Authenticate("service-admin", "123456");
        }
    }
}

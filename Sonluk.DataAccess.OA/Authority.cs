using Sonluk.DataAccess.OA.Seeyon.AuthorityAPI;
using Sonluk.IDataAccess.OA;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.OA
{
    public class Authority : IAuthority
    {
        private authorityServicePortTypeClient _Client = new authorityServicePortTypeClient("authorityServiceHttpSoap12Endpoint", AppConfig.Settings("OA") + "seeyon/services/authorityService.authorityServiceHttpSoap12Endpoint/");

        public string Authenticate(string name, string password)
        {
            UserToken token = _Client.authenticate(name, password);
            return token.id.ToString();
        }
    }
}

using Sonluk.Entities.MES;
using Sonluk.Entities.SSO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.SSO
{
    public interface ITOKEN_TOKENIDINFO
    {
        MES_RETURN INSERT(string TOKEN);
        MES_RETURN UPDATE(string TOKENID, int LB);
        MES_RETURN SELECT(string TOKENID);
        MES_RETURN USERNAMEDY_INSERT(SSO_TOKEN_USERNAMEDY model);
        SSO_TOKEN_USERNAMEDY_SELECT USERNAMEDY_SELECT(SSO_TOKEN_USERNAMEDY model);
        MES_RETURN USERNAMEDY_UPDATE(SSO_TOKEN_USERNAMEDY model);
    }
}

using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.Entities.SSO;
using Sonluk.IDataAccess.SSO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.SSO
{
    public class TOKEN_TOKENIDINFO
    {
        private static readonly ITOKEN_TOKENIDINFO data_ITOKEN_TOKENIDINFO = SSODataAccess.CreateITOKEN_TOKENIDINFO();
        public MES_RETURN INSERT(string TOKEN)
        {
            return data_ITOKEN_TOKENIDINFO.INSERT(TOKEN);
        }
        public MES_RETURN UPDATE(string TOKENID, int LB)
        {
            return data_ITOKEN_TOKENIDINFO.UPDATE(TOKENID, LB);
        }
        public MES_RETURN SELECT(string TOKENID)
        {
            return data_ITOKEN_TOKENIDINFO.SELECT(TOKENID);
        }
        public MES_RETURN USERNAMEDY_INSERT(SSO_TOKEN_USERNAMEDY model)
        {
            return data_ITOKEN_TOKENIDINFO.USERNAMEDY_INSERT(model);
        }
        public SSO_TOKEN_USERNAMEDY_SELECT USERNAMEDY_SELECT(SSO_TOKEN_USERNAMEDY model)
        {
            return data_ITOKEN_TOKENIDINFO.USERNAMEDY_SELECT(model);
        }
        public MES_RETURN USERNAMEDY_UPDATE(SSO_TOKEN_USERNAMEDY model)
        {
            return data_ITOKEN_TOKENIDINFO.USERNAMEDY_UPDATE(model);
        }
    }
}

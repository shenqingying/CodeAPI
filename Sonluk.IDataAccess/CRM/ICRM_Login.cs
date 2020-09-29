using Sonluk.Entities.Account;
using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICRM_Login
    {
         CRM_LoginInfo Login(string name, string password, string OPENID, string WXDLCS,int PC,int WX);
         CRM_LoginInfo Login_language(string name, string password, string OPENID, string WXDLCS, int PC, int WX, int language);
         int WX_SYS_Update(CRM_WX_SYS model);
         CRM_WX_SYS WX_SYS_ReadByWXAPPID(string WXAPPID);
         Boolean ValidateToken(string ptoken);
         TokenInfo Login_SSO(string name, string password, string OPENID, string WXDLCS);
         TokenInfo Login_SSO_LANGUAGE(string name, string password, string OPENID, string WXDLCS, int SYLANGUAGEID);
         CRM_LoginInfo Login_SSO_TOKEN(string ptoken, int PC, int WX);
         CRM_LoginInfo Login_SSO_TOKEN_LANGUAGE(string ptoken, int PC, int WX);
         FullTokenInfo ReadToken(string ptoken);
         TokenInfo get_ptokeninfo_language(string ptoken);
    }
}

using Sonluk.DAFactory;
using Sonluk.Entities.Account;
using Sonluk.Entities.CRM;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.CRM;
using Sonluk.IDataAccess.SSO;
using Sonluk.Utility.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class CRM_Login
    {
        private const string secretKey = "Sonluk@19542014";
        private static readonly ICRM_Login _DataAccess = RMSDataAccess.CreateCRM_Login();
        private static readonly ITOKEN_TOKENIDINFO data_ITOKEN_TOKENIDINFO = SSODataAccess.CreateITOKEN_TOKENIDINFO();
        public CRM_LoginInfo Login(string name, string password, string OPENID, string WXDLCS, int PC, int WX)
        {
            return _DataAccess.Login(name, password, OPENID, WXDLCS, PC, WX);
        }
        public CRM_LoginInfo Login_language(string name, string password, string OPENID, string WXDLCS, int PC, int WX, int language)
        {
            return _DataAccess.Login_language(name, password, OPENID, WXDLCS, PC, WX, language);
        }
        public int WX_SYS_Update(CRM_WX_SYS model)
        {
            return _DataAccess.WX_SYS_Update(model);
        }
        public CRM_WX_SYS WX_SYS_ReadByWXAPPID(string WXAPPID)
        {
            return _DataAccess.WX_SYS_ReadByWXAPPID(WXAPPID);
        }
        public Boolean ValidateToken(string ptoken)
        {
            return _DataAccess.ValidateToken(ptoken);
        }
        public TokenInfo Login_SSO(string name, string password, string OPENID, string WXDLCS)
        {
            TokenInfo rst = _DataAccess.Login_SSO(name, password, OPENID, WXDLCS);
            if (!string.IsNullOrEmpty(rst.access_token))
            {
                MES_RETURN rst_MES_RETURN = data_ITOKEN_TOKENIDINFO.INSERT(rst.access_token);
                rst.TOKENID = "";
                rst.TOKENID = DESE.Encrypt(rst_MES_RETURN.TID.ToString(), secretKey);
            }
            return rst;
        }
        public TokenInfo Login_SSO_LANGUAGE(string name, string password, string OPENID, string WXDLCS, int SYLANGUAGEID)
        {
            TokenInfo rst = _DataAccess.Login_SSO_LANGUAGE(name, password, OPENID, WXDLCS, SYLANGUAGEID);
            if (!string.IsNullOrEmpty(rst.access_token))
            {
                MES_RETURN rst_MES_RETURN = data_ITOKEN_TOKENIDINFO.INSERT(rst.access_token);
                rst.TOKENID = "";
                rst.TOKENID = DESE.Encrypt(rst_MES_RETURN.TID.ToString(), secretKey);
            }
            return rst;
        }
        public CRM_LoginInfo Login_SSO_TOKEN(string TOKENID, int PC, int WX)
        {
            CRM_LoginInfo rst = new CRM_LoginInfo();
            TokenInfo child_TokenInfo = new TokenInfo();
            MES_RETURN rst_MES_RETURN = data_ITOKEN_TOKENIDINFO.SELECT(TOKENID);
            if (rst_MES_RETURN.TYPE == "S")
            {
                rst = _DataAccess.Login_SSO_TOKEN(rst_MES_RETURN.MESSAGE, PC, WX);
            }
            else
            {
                child_TokenInfo.MSG = "E";
                child_TokenInfo.MESSAGE = "读取失败！";
                child_TokenInfo.access_token = "";
                rst.TokenInfo = child_TokenInfo;
            }
            return rst;
        }
        public CRM_LoginInfo Login_SSO_TOKEN_LANGUAGE(string TOKENID, int PC, int WX)
        {
            CRM_LoginInfo rst = new CRM_LoginInfo();
            TokenInfo child_TokenInfo = new TokenInfo();
            MES_RETURN rst_MES_RETURN = data_ITOKEN_TOKENIDINFO.SELECT(TOKENID);
            if (rst_MES_RETURN.TYPE == "S")
            {
                rst = _DataAccess.Login_SSO_TOKEN_LANGUAGE(rst_MES_RETURN.MESSAGE, PC, WX);
            }
            else
            {
                child_TokenInfo.MSG = "E";
                child_TokenInfo.MESSAGE = "读取失败！";
                child_TokenInfo.access_token = "";
                rst.TokenInfo = child_TokenInfo;
            }
            return rst;
        }

        public FullTokenInfo ReadFullToken(string ptoken)
        {
            return _DataAccess.ReadToken(ptoken);
        }

        public int ReadSTAFFIDByToken(string ptoken)
        {
            FullTokenInfo token = _DataAccess.ReadToken(ptoken);
            if (token.Valid) return token.StaffID;
            else return 0;
        }
        public TokenInfo get_ptokeninfo_language(string ptoken)
        {
            return _DataAccess.get_ptokeninfo_language(ptoken);
        }
    }
}

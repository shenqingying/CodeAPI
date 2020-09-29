using Oracle.DataAccess.Client;
using Sonluk.Entities.Account;
using Sonluk.Entities.Common;
using Sonluk.IDataAccess.SSO;
using Sonluk.DataAccess.Utility.Oracle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Sonluk.Utility.Security;
using System.Text.RegularExpressions;

namespace Sonluk.DataAccess.Oracle.SSO
{
    public class User : IUser
    {
        private const string SQL_SIGNIN = "SONLUK_ACCOUNT_SIGNIN";
        private const string SQL_SIGNIN_ONLYNAME = "SONLUK_ACCOUNT_SIGNIN_ONLYNAME";
        private const string SQL_SignInToken = "SONLUK_ACCOUNT_SIGNIN2";
        private const string SQL_SELECT = "SELECT * FROM HG_Staff WHERE StaffID=:SN";
        private const string SQL_CHANGEPASSWORD = "SONLUK_ACCOUNT_CHANGEPASSWORD";
        private const string secretKey = "Sonluk@19542014";

        public int SignIn(string name, string password)
        {
            OracleParameter[] parms = {	
                new OracleParameter("v_Name_Confirm", OracleDbType.Varchar2),
                new OracleParameter("v_PasswordHash_Confirm", OracleDbType.Varchar2),
                new OracleParameter("v_SN", OracleDbType.Int32)};

            parms[0].Value = name;
            parms[1].Value = password;
            parms[2].Direction = ParameterDirection.Output;

            int SN = 0;
            try
            {
                OracleHelper.ExecuteNonQuery(OracleHelper.connectionString, CommandType.StoredProcedure, SQL_SIGNIN, parms);
                SN = Convert.ToInt32(parms[2].Value.ToString());

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return SN;

        }

        public int SignIn_OnlyName(string name)
        {
            OracleParameter[] parms = {	
                new OracleParameter("v_Name_Confirm", OracleDbType.Varchar2),
                new OracleParameter("v_SN", OracleDbType.Int32)};

            parms[0].Value = name;
            parms[1].Direction = ParameterDirection.Output;

            int SN = 0;
            try
            {
                OracleHelper.ExecuteNonQuery(OracleHelper.connectionString, CommandType.StoredProcedure, SQL_SIGNIN_ONLYNAME, parms);
                SN = Convert.ToInt32(parms[1].Value.ToString());
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return SN;

        }

        public int[] SignInToken(string name, string password)
        {
            OracleParameter[] parms = {	
                new OracleParameter("v_Name_Confirm", OracleDbType.Varchar2),
                new OracleParameter("v_PasswordHash_Confirm", OracleDbType.Varchar2),
                new OracleParameter("v_SN", OracleDbType.Int32),
                new OracleParameter("v_e_count", OracleDbType.Int32),
                new OracleParameter("v_sislock", OracleDbType.Int32)};

            parms[0].Value = name;
            parms[1].Value = password;
            parms[2].Direction = ParameterDirection.Output;
            parms[3].Direction = ParameterDirection.Output;
            parms[4].Direction = ParameterDirection.Output;

            int[] SN = new int[3] { 0, 0, 0 };
            try
            {
                OracleHelper.ExecuteNonQuery(OracleHelper.connectionString, CommandType.StoredProcedure, SQL_SignInToken, parms);
                SN[0] = Convert.ToInt32(parms[2].Value.ToString());
                SN[1] = Convert.ToInt32(parms[3].Value.ToString());
                SN[2] = Convert.ToInt32(parms[4].Value.ToString());

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return SN;

        }

        public AccountInfo Read(int SN)
        {
            OracleParameter param = new OracleParameter(":SN", OracleDbType.Int32);
            param.Value = SN;

            AccountInfo node = null;

            try
            {
                using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.connectionString, CommandType.Text, SQL_SELECT, param))
                {
                    if (odr.Read())
                    {
                        node = new AccountInfo();
                        node.SN = SN;
                        node.ID = Convert.ToString(odr["STAFFUSER"]);
                        node.Name = Convert.ToString(odr["STAFFNAME"]);
                        node.EMail = Convert.ToString(odr["STAFFEMAIL"]);
                        node.Telphone = Convert.ToString(odr["STAFFTEL"]);
                        node.ExternalSignIn = Convert.ToInt32(odr["ISSUPER"]);
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            param.Dispose();
            return node;
        }

        public bool ChangePassword(int SN, string passwordHash, string newPasswordHash)
        {
            OracleParameter[] parms = {	
                new OracleParameter("v_SN", OracleDbType.Varchar2),
                new OracleParameter("v_PasswordHash_Confirm", OracleDbType.Varchar2),
                new OracleParameter("v_New_PasswordHash", OracleDbType.Varchar2),
                new OracleParameter("v_Success", OracleDbType.Int32)};

            parms[0].Value = SN;
            parms[1].Value = passwordHash;
            parms[2].Value = newPasswordHash;
            parms[3].Direction = ParameterDirection.Output;

            bool success = false;
            try
            {
                OracleHelper.ExecuteNonQuery(OracleHelper.connectionString, CommandType.StoredProcedure, SQL_CHANGEPASSWORD, parms);
                if (Convert.ToInt16(parms[3].Value.ToString()) == 1)
                    success = true;

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return success;
        }

        public TokenInfo Token(string name, string password)
        {
            TokenInfo token = new TokenInfo();
            int[] signinint = new int[] { 0, 0, 0 };
            int SN = 0;
            try
            {
                string pwdhash = MD5Hash.GetMd5Hash(password).ToUpper();
                signinint = SignInToken(name, pwdhash);
                string pattern = @"(?=.*[a-zA-Z])(?=.*[0-9])";
                bool result = false;
                result = Regex.IsMatch(password, pattern);
                int e_count = signinint[1];
                int sislock = signinint[2];
                SN = signinint[0];
                if (sislock == 1)
                {
                    token.MSG = "E";
                    token.MESSAGE = "帐号已被锁定";
                }
                else if (e_count > 0)
                {
                    if (e_count == 5)
                    {
                        token.MSG = "E";
                        token.MESSAGE = "帐号已被锁定";
                    }
                    else
                    {
                        token.MSG = "E";
                        token.MESSAGE = "剩余尝试次数" + (5 - e_count);
                    }
                }
                else if (SN == 0)
                {
                    token.MSG = "E";
                    token.MESSAGE = "用户名或密码错误";
                }
                else if (password.Length < 8)
                {
                    token.MSG = "E";
                    token.MESSAGE = "密码长度必须大于8位";
                }
                else if (result == false)
                {
                    token.MSG = "E";
                    token.MESSAGE = "密码必须含有字母与数字";
                }
                else
                {
                    token.MSG = "S";
                }

                if (SN > 0)
                {
                    //生成Token
                    string stoken = "";
                    token.expires_in = "999999";
                    stoken += name.Length.ToString().PadLeft(3, '0');
                    stoken += name;
                    stoken += password.Length.ToString().PadLeft(3, '0');
                    stoken += password;
                    stoken += System.DateTime.Now.ToString("yyyyMMddHHmmss");
                    stoken += token.expires_in;
                    //token.expires_in = stoken;
                    token.access_token = DESE.Encrypt(stoken, secretKey);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return token;
        }

        public AccountInfo AcceptToken(string ptoken)
        {
            AccountInfo user = new AccountInfo();
            TokenInfo token = new TokenInfo();
            //string rtn="";

            int SN = 0;
            try
            {
                //生成Token
                string stoken = DESE.Decrypt(ptoken, secretKey);

                //取name
                int len = Convert.ToInt32(stoken.Substring(0, 3));
                string name = stoken.Substring(3, len);
                stoken = stoken.Remove(0, len + 3);

                //取password
                len = Convert.ToInt32(stoken.Substring(0, 3));
                string password = stoken.Substring(3, len);
                string pwdhash = MD5Hash.GetMd5Hash(password).ToUpper();
                stoken = stoken.Remove(0, len + 3);

                //取日期
                len = 14;
                //DateTime sj = Convert.ToDateTime(stoken.Substring(0, len), "yyyyMMddHHmmss");
                DateTime sj = DateTime.ParseExact(stoken.Substring(0, len), "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
                stoken = stoken.Remove(0, len);

                //取expires_in
                len = 6;
                Int32 expires_in = Convert.ToInt32(stoken);

                //rtn += "name:" + name;
                //rtn += "password:" + password;
                //rtn += "sj:" + sj.ToString();
                //rtn += "pwdhash:" + pwdhash;

                //判断是否在有效期内
                TimeSpan ts = DateTime.Now - sj;
                if (ts.TotalSeconds < expires_in)
                {
                    SN = SignIn(name, pwdhash);
                    if (SN > 0)
                    {
                        user = Read(SN);
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            //user.Message = rtn;
            return user;
        }

        public Boolean ValidateToken(string ptoken)
        {
            Boolean rtn = false;
            TokenInfo token = new TokenInfo();

            int SN = 0;
            try
            {
                //生成Token
                string stoken = DESE.Decrypt(ptoken, secretKey);

                //取name
                int len = Convert.ToInt32(stoken.Substring(0, 3));
                string name = stoken.Substring(3, len);
                stoken = stoken.Remove(0, len + 3);

                //取password
                len = Convert.ToInt32(stoken.Substring(0, 3));
                string password = stoken.Substring(3, len);
                string pwdhash = MD5Hash.GetMd5Hash(password).ToUpper();
                stoken = stoken.Remove(0, len + 3);

                //取日期
                len = 14;
                //DateTime sj = Convert.ToDateTime(stoken.Substring(0, len), "yyyyMMddHHmmss");
                DateTime sj = DateTime.ParseExact(stoken.Substring(0, len), "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
                stoken = stoken.Remove(0, len);

                //取expires_in
                len = 6;
                Int32 expires_in = Convert.ToInt32(stoken);

                //判断是否在有效期内
                TimeSpan ts = DateTime.Now - sj;
                if (ts.TotalSeconds < expires_in)
                {
                    SN = SignIn(name, pwdhash);
                    if (SN > 0)
                    {
                        rtn = true;
                    }
                }


            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return rtn;
        }
    }
}

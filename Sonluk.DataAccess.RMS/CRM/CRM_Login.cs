using Sonluk.Entities.Account;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using Sonluk.Utility.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Sonluk.DataAccess.RMS.CRM
{
    public class CRM_Login : ICRM_Login
    {
        private const string SQL_SignInToken = "CRM_SignInToken";
        private const string SQL_Login_Role = "CRM_Login_Role";
        private const string SQL_Login_Right = "CRM_Login_Right";
        private const string SQL_Login_Right_LANGUAGE = "CRM_Login_Right_LANGUAGE";
        private const string SQL_Login_GetAccountInfo = "CRM_Login_GetAccountInfo";
        private const string SQL_Login_UpdateCRM_WX_OPENID = "CRM_Login_WX_OPENID_Verify";
        private const string SQL_Login_RightGroup = "CRM_Login_RightGroup";
        private const string SQL_Login_RightGroup_LANGUAGE = "CRM_Login_RightGroup_LANGUAGE";
        private const string secretKey = "Sonluk@19542014";
        private const string SQL_WX_SYS_Update = "CRM_WX_SYS_UPDATE";
        private const string SQL_WX_SYS_ReadByWXAPPID = "CRM_WY_SYS_ReadByWXAPPID";//"SELECT * FROM CRM_WX_SYS WHERE WXAPPID = @WXAPPID";
        private const string SQL_SignIn = "CRM_SignIn_Verify";
        private const string SQL_Login_GetSTAFFID = "CRM_Login_GetSTAFFID";//"SELECT STAFFID FROM CRM_HG_STAFF WHERE STAFFUSER = @STAFFUSER AND STAFFPW = @STAFFPW AND SCANCEL = 0";
        //CRM_LoginInfo
        public CRM_LoginInfo Login(string name, string password, string OPENID, string WXDLCS, int PC, int WX)
        {
            CRM_LoginInfo info = new CRM_LoginInfo();
            string md5_pwd = MD5Hash.GetMd5Hash(password).ToUpper();
            if (string.IsNullOrEmpty(OPENID) == true && string.IsNullOrEmpty(name) == false)//帐号密码进来的时候
            {

                info.JURISDICTION_GROUP = Jurisdiction(name, md5_pwd, PC, WX).ToList();
                info.TokenInfo = Token(name, password);


            }
            else if (string.IsNullOrEmpty(name) == true && string.IsNullOrEmpty(OPENID) == false)//openid进来的时候
            {
                info.TokenInfo = Token(OPENID, WXDLCS, true);
                if (info.TokenInfo.MESSAGE != "自动登录失败")
                {
                    info.JURISDICTION_GROUP = Jurisdiction(OPENID, WXDLCS, true, PC, WX).ToList();
                }

            }
            else if (string.IsNullOrEmpty(name) == false && string.IsNullOrEmpty(OPENID) == false)//帐号密码  openid 绑定进来的时候
            {
                info.JURISDICTION_GROUP = Jurisdiction(name, md5_pwd, PC, WX).ToList();
                info.TokenInfo = Token(name, password);
            }

            return info;
        }
        public CRM_LoginInfo Login_language(string name, string password, string OPENID, string WXDLCS, int PC, int WX, int language)
        {
            CRM_LoginInfo info = new CRM_LoginInfo();
            string md5_pwd = MD5Hash.GetMd5Hash(password).ToUpper();
            if (string.IsNullOrEmpty(OPENID) == true && string.IsNullOrEmpty(name) == false)//帐号密码进来的时候
            {

                info.JURISDICTION_GROUP = Jurisdiction_LANGUAGE(name, md5_pwd, PC, WX, language).ToList();
                info.TokenInfo = Token_LANGUAGE(name, password, language);


            }
            else if (string.IsNullOrEmpty(name) == true && string.IsNullOrEmpty(OPENID) == false)//openid进来的时候
            {
                info.TokenInfo = Token_LANGUAGE(OPENID, WXDLCS, true, language);
                if (info.TokenInfo.MESSAGE != "自动登录失败")
                {
                    info.JURISDICTION_GROUP = Jurisdiction_language(OPENID, WXDLCS, true, PC, WX, language).ToList();
                }

            }
            else if (string.IsNullOrEmpty(name) == false && string.IsNullOrEmpty(OPENID) == false)//帐号密码  openid 绑定进来的时候
            {
                info.JURISDICTION_GROUP = Jurisdiction_LANGUAGE(name, md5_pwd, PC, WX, language).ToList();
                info.TokenInfo = Token(name, password);
            }

            return info;
        }
        public TokenInfo Login_SSO(string name, string password, string OPENID, string WXDLCS)
        {
            TokenInfo rst = new TokenInfo();
            if (string.IsNullOrEmpty(name) == false)
            {
                rst = Token(name, password);
            }
            else if (string.IsNullOrEmpty(name) == true && string.IsNullOrEmpty(OPENID) == false)
            {
                rst = Token(OPENID, WXDLCS, true);
            }
            else
            {
                rst.MSG = "E";
                rst.MESSAGE = "用户名或OPENID都不存在！";
            }
            return rst;
        }
        public TokenInfo Login_SSO_LANGUAGE(string name, string password, string OPENID, string WXDLCS, int SYLANGUAGEID)
        {
            TokenInfo rst = new TokenInfo();
            if (string.IsNullOrEmpty(name) == false)
            {
                rst = Token_LANGUAGE(name, password, SYLANGUAGEID);
            }
            else if (string.IsNullOrEmpty(name) == true && string.IsNullOrEmpty(OPENID) == false)
            {
                rst = Token_LANGUAGE(OPENID, WXDLCS, true, SYLANGUAGEID);
            }
            else
            {
                rst.MSG = "E";
                rst.MESSAGE = "用户名或OPENID都不存在！";
            }
            return rst;
        }


        public int Login_GETSTAFFID(string name, string password)
        {
            SqlParameter[] parms_role = {
                                       new SqlParameter("@STAFFUSER",name),
                                       new SqlParameter("@STAFFPW",password)
                                   };
            int STAFFID = 0;
            try
            {
                object obj = SQLServerHelper.ExecuteScalar(CommandType.StoredProcedure, SQL_Login_GetSTAFFID, parms_role);
                STAFFID = Convert.ToInt32(obj);

            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return STAFFID;

        }

        public CRM_LoginInfo Login_SSO_TOKEN(string ptoken, int PC, int WX)
        {
            CRM_LoginInfo rst = new CRM_LoginInfo();
            TokenInfo child_TokenInfo = new TokenInfo();

            TokenInfo token = new TokenInfo();
            if (string.IsNullOrEmpty(ptoken))
            {
                child_TokenInfo.access_token = "";
                child_TokenInfo.MSG = "E";
                child_TokenInfo.MESSAGE = "ptoken为空";
            }
            int SN = 0;
            try
            {
                if (string.IsNullOrEmpty(DESE.Decrypt(ptoken, secretKey)))
                {
                    child_TokenInfo.access_token = "";
                    child_TokenInfo.MSG = "E";
                    child_TokenInfo.MESSAGE = "ptoken解析失败";
                }

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

                Int32 expires_in = Convert.ToInt32(stoken.Substring(0, len));
                stoken = stoken.Remove(0, len);

                //判断是否在有效期内
                TimeSpan ts = DateTime.Now - sj;
                if (ts.TotalSeconds < expires_in)
                {
                    SN = SignIn(name, password);
                    if (SN > 0)
                    {
                        rst.JURISDICTION_GROUP = Jurisdiction(name, password, PC, WX).ToList();
                        child_TokenInfo = Token_MD5(name, password);
                    }
                    else
                    {
                        child_TokenInfo.access_token = "";
                        child_TokenInfo.MSG = "E";
                        child_TokenInfo.MESSAGE = "ptoken过期失效";
                    }
                }
            }
            catch (Exception e)
            {
                child_TokenInfo.access_token = "";
                child_TokenInfo.MSG = "E";
                child_TokenInfo.MESSAGE = e.Message;
            }
            rst.TokenInfo = child_TokenInfo;
            return rst;
        }
        public TokenInfo get_ptokeninfo_language(string ptoken)
        {
            TokenInfo rst_TokenInfo = new TokenInfo();
            string stoken = DESE.Decrypt(ptoken, secretKey);
            int len = Convert.ToInt32(stoken.Substring(0, 3));
            string name = stoken.Substring(3, len);
            stoken = stoken.Remove(0, len + 3);

            //取password
            len = Convert.ToInt32(stoken.Substring(0, 3));
            string password = stoken.Substring(3, len);
            stoken = stoken.Remove(0, len + 3);

            //取日期
            len = 14;
            //DateTime sj = Convert.ToDateTime(stoken.Substring(0, len), "yyyyMMddHHmmss");
            DateTime sj = DateTime.ParseExact(stoken.Substring(0, len), "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
            stoken = stoken.Remove(0, len);

            //取expires_in
            len = 6;
            Int32 expires_in = Convert.ToInt32(stoken.Substring(0, len));
            stoken = stoken.Remove(0, len);

            int language = 0;
            len = 4;
            if (stoken.Length >= 4)
            {
                language = Convert.ToInt32(stoken.Substring(0, len));
            }

            rst_TokenInfo.STAFFID = Login_GETSTAFFID(name, password);
            rst_TokenInfo.LANGUAGEID = language;



            stoken = "";
            rst_TokenInfo.expires_in = "999999";
            stoken += name.Length.ToString().PadLeft(3, '0');
            stoken += name;
            stoken += password.Length.ToString().PadLeft(3, '0');
            stoken += password;
            stoken += System.DateTime.Now.ToString("yyyyMMddHHmmss");
            stoken += rst_TokenInfo.expires_in;
            stoken += language.ToString().PadLeft(4, '0');
            //token.expires_in = stoken;

            rst_TokenInfo.access_token = DESE.Encrypt(stoken, secretKey);
            return rst_TokenInfo;

        }
        public CRM_LoginInfo Login_SSO_TOKEN_LANGUAGE(string ptoken, int PC, int WX)
        {
            CRM_LoginInfo rst = new CRM_LoginInfo();
            TokenInfo child_TokenInfo = new TokenInfo();

            TokenInfo token = new TokenInfo();
            if (string.IsNullOrEmpty(ptoken))
            {
                child_TokenInfo.access_token = "";
                child_TokenInfo.MSG = "E";
                child_TokenInfo.MESSAGE = "ptoken为空";
            }
            int SN = 0;
            try
            {
                if (string.IsNullOrEmpty(DESE.Decrypt(ptoken, secretKey)))
                {
                    child_TokenInfo.access_token = "";
                    child_TokenInfo.MSG = "E";
                    child_TokenInfo.MESSAGE = "ptoken解析失败";
                }

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
                Int32 expires_in = Convert.ToInt32(stoken.Substring(0, len));
                stoken = stoken.Remove(0, len);

                int language = 0;
                len = 4;
                if (stoken.Length >= 4)
                {
                    language = Convert.ToInt32(stoken.Substring(0, len));
                }

                //判断是否在有效期内
                TimeSpan ts = DateTime.Now - sj;
                if (ts.TotalSeconds < expires_in)
                {
                    SN = SignIn(name, password);
                    if (SN > 0)
                    {
                        rst.JURISDICTION_GROUP = Jurisdiction_LANGUAGE(name, password, PC, WX, language).ToList();
                        child_TokenInfo = Token_MD5_LANGUAGE(name, password, language);
                    }
                    else
                    {
                        child_TokenInfo.access_token = "";
                        child_TokenInfo.MSG = "E";
                        child_TokenInfo.MESSAGE = "ptoken过期失效";
                    }
                }
            }
            catch (Exception e)
            {
                child_TokenInfo.access_token = "";
                child_TokenInfo.MSG = "E";
                child_TokenInfo.MESSAGE = e.Message;
            }
            rst.TokenInfo = child_TokenInfo;
            return rst;
        }

        public IList<CRM_JURISDICTION_GROUP> Jurisdiction(string name, string password, int PC, int WX)
        {
            SqlParameter[] parms_role = {
                                       new SqlParameter("@STAFFUSER",name),
                                       new SqlParameter("@STAFFPW",password)
                                   };
            SqlParameter[] parms_right = {
                                             new SqlParameter("@ROLEID",SqlDbType.Int),
                                             new SqlParameter("@PC",PC),
                                             new SqlParameter("@WX",WX)
                                         };
            SqlParameter[] parms_right_group = {
                                             new SqlParameter("@RGROUPID",SqlDbType.Int)
                                         };
            IList<CRM_HG_RIGHT> nodes_right = new List<CRM_HG_RIGHT>();
            IList<CRM_HG_RIGHTGROUP> nodes_group = new List<CRM_HG_RIGHTGROUP>();
            IList<CRM_JURISDICTION_GROUP> nodes = new List<CRM_JURISDICTION_GROUP>();
            IList<int> gounpList = new List<int>();


            try
            {
                using (SqlDataReader sdr_role = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Login_Role, parms_role))
                {
                    while (sdr_role.Read())
                    {
                        //int roleID = Convert.ToInt32(sdr["ROLEID"]);
                        parms_right[0].Value = Convert.ToInt32(sdr_role["ROLEID"]);
                        using (SqlDataReader sdr_right = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Login_Right, parms_right))
                        {
                            while (sdr_right.Read())
                            {

                                parms_right_group[0].Value = Convert.ToInt32(sdr_right["RGROUPID"]);
                                nodes_right.Add(ReadRightToObject(sdr_right));
                                gounpList.Add(Convert.ToInt32(sdr_right["RGROUPID"]));
                                //using (SqlDataReader sdr_group = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure,SQL_Login_RightGroup,parms_right_group))
                                //{
                                //    while (sdr_group.Read())
                                //    {
                                //        nodes_group.Add(ReadGroupToObject(sdr_group));
                                //    }
                                //}
                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }

            List<int> node = gounpList.Distinct().ToList();
            for (int i = 0; i < node.Count; i++)
            {
                parms_right_group[0].Value = node[i];
                using (SqlDataReader sdr_group = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Login_RightGroup, parms_right_group))
                {
                    while (sdr_group.Read())
                    {
                        nodes_group.Add(ReadGroupToObject(sdr_group));
                    }
                }
            }


            nodes_right = nodes_right.Distinct(new CRM_HG_RIGHT.TravelTrafficInfoComparer()).ToList();
            nodes_right = (from o in nodes_right orderby o.RGROUPID, o.RIGHTNO select o).ToList();
            nodes_group = (from x in nodes_group orderby x.PRIGHTNO, x.RGROUPID select x).ToList();


            for (int i = 0; i < nodes_group.Count; i++)
            {
                CRM_JURISDICTION_GROUP model = new CRM_JURISDICTION_GROUP();
                model.CRM_HG_RIGHTGROUP = nodes_group[i];
                model.CRM_HG_RIGHTList = new List<CRM_HG_RIGHT>();

                for (int j = 0; j < nodes_right.Count; j++)
                {
                    if (nodes_right[j].RGROUPID == nodes_group[i].RGROUPID)
                    {
                        model.CRM_HG_RIGHTList.Add(nodes_right[j]);
                    }
                }
                nodes.Add(model);
            }


            return nodes;
        }
        public IList<CRM_JURISDICTION_GROUP> Jurisdiction_LANGUAGE(string name, string password, int PC, int WX, int LANGUAGEID)
        {
            SqlParameter[] parms_role = {
                                       new SqlParameter("@STAFFUSER",name),
                                       new SqlParameter("@STAFFPW",password)
                                   };
            SqlParameter[] parms_right = {
                                             new SqlParameter("@ROLEID",SqlDbType.Int),
                                             new SqlParameter("@PC",PC),
                                             new SqlParameter("@WX",WX),
                                             new SqlParameter("@LANGUAGEID",LANGUAGEID)
                                         };
            SqlParameter[] parms_right_group = {
                                             new SqlParameter("@RGROUPID",SqlDbType.Int),
                                             new SqlParameter("@LANGUAGEID",LANGUAGEID)
                                         };
            IList<CRM_HG_RIGHT> nodes_right = new List<CRM_HG_RIGHT>();
            IList<CRM_HG_RIGHTGROUP> nodes_group = new List<CRM_HG_RIGHTGROUP>();
            IList<CRM_JURISDICTION_GROUP> nodes = new List<CRM_JURISDICTION_GROUP>();
            IList<int> gounpList = new List<int>();


            try
            {
                using (SqlDataReader sdr_role = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Login_Role, parms_role))
                {
                    while (sdr_role.Read())
                    {
                        //int roleID = Convert.ToInt32(sdr["ROLEID"]);
                        parms_right[0].Value = Convert.ToInt32(sdr_role["ROLEID"]);
                        using (SqlDataReader sdr_right = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Login_Right_LANGUAGE, parms_right))
                        {
                            while (sdr_right.Read())
                            {

                                parms_right_group[0].Value = Convert.ToInt32(sdr_right["RGROUPID"]);
                                nodes_right.Add(ReadRightToObject(sdr_right));
                                gounpList.Add(Convert.ToInt32(sdr_right["RGROUPID"]));
                                //using (SqlDataReader sdr_group = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure,SQL_Login_RightGroup,parms_right_group))
                                //{
                                //    while (sdr_group.Read())
                                //    {
                                //        nodes_group.Add(ReadGroupToObject(sdr_group));
                                //    }
                                //}
                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }

            List<int> node = gounpList.Distinct().ToList();
            for (int i = 0; i < node.Count; i++)
            {
                parms_right_group[0].Value = node[i];
                using (SqlDataReader sdr_group = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Login_RightGroup_LANGUAGE, parms_right_group))
                {
                    while (sdr_group.Read())
                    {
                        nodes_group.Add(ReadGroupToObject(sdr_group));
                    }
                }
            }


            nodes_right = nodes_right.Distinct(new CRM_HG_RIGHT.TravelTrafficInfoComparer()).ToList();
            nodes_right = (from o in nodes_right orderby o.RGROUPID, o.RIGHTNO select o).ToList();
            nodes_group = (from x in nodes_group orderby x.PRIGHTNO, x.RGROUPID select x).ToList();


            for (int i = 0; i < nodes_group.Count; i++)
            {
                CRM_JURISDICTION_GROUP model = new CRM_JURISDICTION_GROUP();
                model.CRM_HG_RIGHTGROUP = nodes_group[i];
                model.CRM_HG_RIGHTList = new List<CRM_HG_RIGHT>();

                for (int j = 0; j < nodes_right.Count; j++)
                {
                    if (nodes_right[j].RGROUPID == nodes_group[i].RGROUPID)
                    {
                        model.CRM_HG_RIGHTList.Add(nodes_right[j]);
                    }
                }
                nodes.Add(model);
            }


            return nodes;
        }
        public IList<CRM_JURISDICTION_GROUP> Jurisdiction(string OPENID, string WXDLCS, bool isAuto, int PC, int WX)
        {
            SqlParameter[] parms_role = {
                                       new SqlParameter("@WXDLCS",WXDLCS),
                                       new SqlParameter("@OPENID",OPENID)
                                   };
            SqlParameter[] parms_right = {
                                             new SqlParameter("@ROLEID",SqlDbType.Int),
                                             new SqlParameter("@PC",PC),
                                             new SqlParameter("@WX",WX)
                                         };
            SqlParameter[] parms_right_group = {
                                             new SqlParameter("@RGROUPID",SqlDbType.Int)
                                         };
            IList<CRM_HG_RIGHT> nodes_right = new List<CRM_HG_RIGHT>();
            IList<CRM_HG_RIGHTGROUP> nodes_group = new List<CRM_HG_RIGHTGROUP>();
            IList<CRM_JURISDICTION_GROUP> nodes = new List<CRM_JURISDICTION_GROUP>();
            IList<int> gounpList = new List<int>();
            try
            {
                using (SqlDataReader sdr_role = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Login_Role, parms_role))
                {
                    while (sdr_role.Read())
                    {
                        //int roleID = Convert.ToInt32(sdr["ROLEID"]);
                        parms_right[0].Value = Convert.ToInt32(sdr_role["ROLEID"]);
                        using (SqlDataReader sdr_right = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Login_Right, parms_right))
                        {
                            while (sdr_right.Read())
                            {

                                parms_right_group[0].Value = Convert.ToInt32(sdr_right["RGROUPID"]);
                                nodes_right.Add(ReadRightToObject(sdr_right));
                                gounpList.Add(Convert.ToInt32(sdr_right["RGROUPID"]));

                                //using (SqlDataReader sdr_group = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Login_RightGroup, parms_right_group))
                                //{
                                //    while (sdr_group.Read())
                                //    {
                                //        nodes_group.Add(ReadGroupToObject(sdr_group));
                                //    }
                                //}
                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            List<int> node = gounpList.Distinct().ToList();
            for (int i = 0; i < node.Count; i++)
            {
                parms_right_group[0].Value = node[i];
                using (SqlDataReader sdr_group = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Login_RightGroup, parms_right_group))
                {
                    while (sdr_group.Read())
                    {
                        nodes_group.Add(ReadGroupToObject(sdr_group));
                    }
                }
            }
            nodes_right = nodes_right.Distinct(new CRM_HG_RIGHT.TravelTrafficInfoComparer()).ToList();
            nodes_right = (from o in nodes_right orderby o.RGROUPID, o.RIGHTNO select o).ToList();
            nodes_group = (from x in nodes_group orderby x.PRIGHTNO, x.RGROUPID select x).ToList();

            for (int i = 0; i < nodes_group.Count; i++)
            {
                CRM_JURISDICTION_GROUP model = new CRM_JURISDICTION_GROUP();
                model.CRM_HG_RIGHTGROUP = nodes_group[i];
                model.CRM_HG_RIGHTList = new List<CRM_HG_RIGHT>();
                for (int j = 0; j < nodes_right.Count; j++)
                {
                    if (nodes_right[j].RGROUPID == nodes_group[i].RGROUPID)
                    {
                        model.CRM_HG_RIGHTList.Add(nodes_right[j]);
                    }
                }
                nodes.Add(model);
            }


            return nodes;
        }

        public IList<CRM_JURISDICTION_GROUP> Jurisdiction_language(string OPENID, string WXDLCS, bool isAuto, int PC, int WX, int LANGUAGEID)
        {
            SqlParameter[] parms_role = {
                                       new SqlParameter("@WXDLCS",WXDLCS),
                                       new SqlParameter("@OPENID",OPENID)
                                   };
            SqlParameter[] parms_right = {
                                             new SqlParameter("@ROLEID",SqlDbType.Int),
                                             new SqlParameter("@PC",PC),
                                             new SqlParameter("@WX",WX),
                                             new SqlParameter("@LANGUAGEID",LANGUAGEID)
                                         };
            SqlParameter[] parms_right_group = {
                                             new SqlParameter("@RGROUPID",SqlDbType.Int),
                                             new SqlParameter("@LANGUAGEID",LANGUAGEID)
                                         };
            IList<CRM_HG_RIGHT> nodes_right = new List<CRM_HG_RIGHT>();
            IList<CRM_HG_RIGHTGROUP> nodes_group = new List<CRM_HG_RIGHTGROUP>();
            IList<CRM_JURISDICTION_GROUP> nodes = new List<CRM_JURISDICTION_GROUP>();
            IList<int> gounpList = new List<int>();
            try
            {
                using (SqlDataReader sdr_role = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Login_Role, parms_role))
                {
                    while (sdr_role.Read())
                    {
                        //int roleID = Convert.ToInt32(sdr["ROLEID"]);
                        parms_right[0].Value = Convert.ToInt32(sdr_role["ROLEID"]);
                        using (SqlDataReader sdr_right = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Login_Right_LANGUAGE, parms_right))
                        {
                            while (sdr_right.Read())
                            {

                                parms_right_group[0].Value = Convert.ToInt32(sdr_right["RGROUPID"]);
                                nodes_right.Add(ReadRightToObject(sdr_right));
                                gounpList.Add(Convert.ToInt32(sdr_right["RGROUPID"]));

                                //using (SqlDataReader sdr_group = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Login_RightGroup, parms_right_group))
                                //{
                                //    while (sdr_group.Read())
                                //    {
                                //        nodes_group.Add(ReadGroupToObject(sdr_group));
                                //    }
                                //}
                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            List<int> node = gounpList.Distinct().ToList();
            for (int i = 0; i < node.Count; i++)
            {
                parms_right_group[0].Value = node[i];
                using (SqlDataReader sdr_group = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Login_RightGroup_LANGUAGE, parms_right_group))
                {
                    while (sdr_group.Read())
                    {
                        nodes_group.Add(ReadGroupToObject(sdr_group));
                    }
                }
            }
            nodes_right = nodes_right.Distinct(new CRM_HG_RIGHT.TravelTrafficInfoComparer()).ToList();
            nodes_right = (from o in nodes_right orderby o.RGROUPID, o.RIGHTNO select o).ToList();
            nodes_group = (from x in nodes_group orderby x.PRIGHTNO, x.RGROUPID select x).ToList();

            for (int i = 0; i < nodes_group.Count; i++)
            {
                CRM_JURISDICTION_GROUP model = new CRM_JURISDICTION_GROUP();
                model.CRM_HG_RIGHTGROUP = nodes_group[i];
                model.CRM_HG_RIGHTList = new List<CRM_HG_RIGHT>();
                for (int j = 0; j < nodes_right.Count; j++)
                {
                    if (nodes_right[j].RGROUPID == nodes_group[i].RGROUPID)
                    {
                        model.CRM_HG_RIGHTList.Add(nodes_right[j]);
                    }
                }
                nodes.Add(model);
            }


            return nodes;
        }
        public TokenInfo Token(string name, string password, string OPENID, string WXDLCS)
        {
            TokenInfo token = new TokenInfo();
            int[] signinint = new int[] { 0, 0, 0 };
            int SN = 0;

            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFUSER",name),
                                       new SqlParameter("@STAFFPW",password),
                                       new SqlParameter("@OPENID",OPENID),
                                       new SqlParameter("@WXDLCS",WXDLCS),
                                   };
            try
            {
                SQLServerHelper.ExecuteNonQuery(CommandType.StoredProcedure, SQL_Login_UpdateCRM_WX_OPENID);

            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }


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
                    stoken += pwdhash.Length.ToString().PadLeft(3, '0');
                    stoken += pwdhash;
                    stoken += System.DateTime.Now.ToString("yyyyMMddHHmmss");
                    stoken += token.expires_in;
                    //token.expires_in = stoken;
                    token.access_token = DESE.Encrypt(stoken, secretKey);
                    token.STAFFID = Login_GETSTAFFID(name, pwdhash);
                }

            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }

            return token;
        }




        public TokenInfo Token(string OPENID, string WXDLCS, bool isAuto)
        {
            TokenInfo token = new TokenInfo();
            int[] signinint = new int[] { 0, 0, 0 };
            int SN = 0;
            string name = "";
            string password = "";
            SqlParameter[] parms = {
                                       new SqlParameter("@OPENID",OPENID),
                                       new SqlParameter("@WXDLCS",WXDLCS)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Login_GetAccountInfo, parms))
                {
                    if (sdr.Read())
                    {
                        name = string.IsNullOrEmpty(Convert.ToString(sdr["STAFFUSER"])) ? "" : Convert.ToString(sdr["STAFFUSER"]);
                        password = string.IsNullOrEmpty(Convert.ToString(sdr["STAFFPW"])) ? "" : Convert.ToString(sdr["STAFFPW"]);
                    }


                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            if (string.IsNullOrEmpty(name) == true && string.IsNullOrEmpty(password) == true && isAuto == true)
            {
                token.MSG = "E";
                token.MESSAGE = "自动登录失败";
                return token;
            }
            try
            {
                string pwdhash = "";
                if (isAuto == true)
                {

                    pwdhash = password;
                }
                else
                {
                    pwdhash = MD5Hash.GetMd5Hash(password).ToUpper();
                }

                signinint = SignInToken(name, pwdhash);
                string pattern = @"(?=.*[a-zA-Z])(?=.*[0-9])";
                bool result = false;
                result = Regex.IsMatch(password, pattern);
                int e_count = signinint[1];
                int sislock = signinint[2];
                SN = signinint[0];
                if (sislock == 1)//当帐号密码被锁定（帐号正确,密码正确,但是被锁定）
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
                    token.STAFFID = Login_GETSTAFFID(name, pwdhash);
                }

            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }

            return token;
        }
        public TokenInfo Token_LANGUAGE(string OPENID, string WXDLCS, bool isAuto, int SYLANGUAGEID)
        {
            TokenInfo token = new TokenInfo();
            int[] signinint = new int[] { 0, 0, 0 };
            int SN = 0;
            string name = "";
            string password = "";
            SqlParameter[] parms = {
                                       new SqlParameter("@OPENID",OPENID),
                                       new SqlParameter("@WXDLCS",WXDLCS)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Login_GetAccountInfo, parms))
                {
                    if (sdr.Read())
                    {
                        name = string.IsNullOrEmpty(Convert.ToString(sdr["STAFFUSER"])) ? "" : Convert.ToString(sdr["STAFFUSER"]);
                        password = string.IsNullOrEmpty(Convert.ToString(sdr["STAFFPW"])) ? "" : Convert.ToString(sdr["STAFFPW"]);
                    }


                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            if (string.IsNullOrEmpty(name) == true && string.IsNullOrEmpty(password) == true && isAuto == true)
            {
                token.MSG = "E";
                token.MESSAGE = "自动登录失败";
                return token;
            }
            try
            {
                string pwdhash = "";
                if (isAuto == true)
                {

                    pwdhash = password;
                }
                else
                {
                    pwdhash = MD5Hash.GetMd5Hash(password).ToUpper();
                }

                signinint = SignInToken(name, pwdhash);
                string pattern = @"(?=.*[a-zA-Z])(?=.*[0-9])";
                bool result = false;
                result = Regex.IsMatch(password, pattern);
                int e_count = signinint[1];
                int sislock = signinint[2];
                SN = signinint[0];
                if (sislock == 1)//当帐号密码被锁定（帐号正确,密码正确,但是被锁定）
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
                    stoken += SYLANGUAGEID.ToString().PadLeft(4, '0');
                    //token.expires_in = stoken;
                    token.access_token = DESE.Encrypt(stoken, secretKey);
                    token.STAFFID = Login_GETSTAFFID(name, pwdhash);
                }

            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }

            return token;
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
                if (SN == -1)
                {
                    token.MSG = "E";
                    //token.MESSAGE = "帐号错误";
                    token.MESSAGE = "帐号密码错误";
                }
                else if (SN == -2)
                {
                    token.MSG = "E";
                    if (sislock == 1)
                    {
                        token.MESSAGE = "该帐号已经被锁定";
                    }
                    else
                    {
                        token.MESSAGE = "密码输入错误,剩余尝试次数" + (5 - e_count);
                    }
                }
                else if (SN == 0)
                {
                    token.MSG = "E";
                    token.MESSAGE = "该帐号已经被锁定";
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
                else if (SN == 1)
                {
                    token.MSG = "S";
                    token.MESSAGE = "登录成功";

                }
                else
                {
                    token.MSG = "E";
                    token.MESSAGE = "异常BUG,逻辑不完整的锅";
                }
                if (SN > 0)
                {
                    string stoken = "";
                    token.expires_in = "999999";
                    stoken += name.Length.ToString().PadLeft(3, '0');
                    stoken += name;
                    stoken += pwdhash.Length.ToString().PadLeft(3, '0');
                    stoken += pwdhash;
                    stoken += System.DateTime.Now.ToString("yyyyMMddHHmmss");
                    stoken += token.expires_in;
                    //token.expires_in = stoken;
                    token.access_token = DESE.Encrypt(stoken, secretKey);
                    token.STAFFID = Login_GETSTAFFID(name, pwdhash);

                }


            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }

            return token;
        }

        public TokenInfo Token_LANGUAGE(string name, string password, int SYLANGUAGEID)
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
                if (SN == -1)
                {
                    token.MSG = "E";
                    //token.MESSAGE = "帐号错误";
                    token.MESSAGE = "帐号密码错误";
                }
                else if (SN == -2)
                {
                    token.MSG = "E";
                    if (sislock == 1)
                    {
                        token.MESSAGE = "该帐号已经被锁定";
                    }
                    else
                    {
                        token.MESSAGE = "密码输入错误,剩余尝试次数" + (5 - e_count);
                    }
                }
                else if (SN == 0)
                {
                    token.MSG = "E";
                    token.MESSAGE = "该帐号已经被锁定";
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
                else if (SN == 1)
                {
                    token.MSG = "S";
                    token.MESSAGE = "登录成功";

                }
                else
                {
                    token.MSG = "E";
                    token.MESSAGE = "异常BUG,逻辑不完整的锅";
                }
                if (SN > 0)
                {
                    string stoken = "";
                    token.expires_in = "999999";
                    stoken += name.Length.ToString().PadLeft(3, '0');
                    stoken += name;
                    stoken += pwdhash.Length.ToString().PadLeft(3, '0');
                    stoken += pwdhash;
                    stoken += System.DateTime.Now.ToString("yyyyMMddHHmmss");
                    stoken += token.expires_in;
                    stoken += SYLANGUAGEID.ToString().PadLeft(4, '0');
                    //token.expires_in = stoken;
                    token.access_token = DESE.Encrypt(stoken, secretKey);
                    token.STAFFID = Login_GETSTAFFID(name, pwdhash);
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }

            return token;
        }

        public TokenInfo Token_MD5(string name, string pwdhash)
        {
            TokenInfo token = new TokenInfo();
            int[] signinint = new int[] { 0, 0, 0 };
            int SN = 0;

            try
            {
                //string pwdhash = MD5Hash.GetMd5Hash(password).ToUpper();

                signinint = SignInToken(name, pwdhash);
                int e_count = signinint[1];
                int sislock = signinint[2];
                SN = signinint[0];
                if (SN == -1)
                {
                    token.MSG = "E";
                    //token.MESSAGE = "帐号错误";
                    token.MESSAGE = "帐号密码错误";
                }
                else if (SN == -2)
                {
                    token.MSG = "E";
                    if (sislock == 1)
                    {
                        token.MESSAGE = "该帐号已经被锁定";
                    }
                    else
                    {
                        token.MESSAGE = "密码输入错误,剩余尝试次数" + (5 - e_count);
                    }
                }
                else if (SN == 0)
                {
                    token.MSG = "E";
                    token.MESSAGE = "该帐号已经被锁定";
                }
                else if (SN == 1)
                {
                    token.MSG = "S";
                    token.MESSAGE = "登录成功";

                }
                else
                {
                    token.MSG = "E";
                    token.MESSAGE = "异常BUG,逻辑不完整的锅";
                }
                if (SN > 0)
                {
                    string stoken = "";
                    token.expires_in = "999999";
                    stoken += name.Length.ToString().PadLeft(3, '0');
                    stoken += name;
                    stoken += pwdhash.Length.ToString().PadLeft(3, '0');
                    stoken += pwdhash;
                    stoken += System.DateTime.Now.ToString("yyyyMMddHHmmss");
                    stoken += token.expires_in;
                    //token.expires_in = stoken;

                    token.access_token = DESE.Encrypt(stoken, secretKey);
                    token.STAFFID = Login_GETSTAFFID(name, pwdhash);

                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return token;
        }

        public TokenInfo Token_MD5_LANGUAGE(string name, string pwdhash, int language)
        {
            TokenInfo token = new TokenInfo();
            int[] signinint = new int[] { 0, 0, 0 };
            int SN = 0;

            try
            {
                //string pwdhash = MD5Hash.GetMd5Hash(password).ToUpper();

                signinint = SignInToken(name, pwdhash);
                int e_count = signinint[1];
                int sislock = signinint[2];
                SN = signinint[0];
                if (SN == -1)
                {
                    token.MSG = "E";
                    //token.MESSAGE = "帐号错误";
                    token.MESSAGE = "帐号密码错误";
                }
                else if (SN == -2)
                {
                    token.MSG = "E";
                    if (sislock == 1)
                    {
                        token.MESSAGE = "该帐号已经被锁定";
                    }
                    else
                    {
                        token.MESSAGE = "密码输入错误,剩余尝试次数" + (5 - e_count);
                    }
                }
                else if (SN == 0)
                {
                    token.MSG = "E";
                    token.MESSAGE = "该帐号已经被锁定";
                }
                else if (SN == 1)
                {
                    token.MSG = "S";
                    token.MESSAGE = "登录成功";

                }
                else
                {
                    token.MSG = "E";
                    token.MESSAGE = "异常BUG,逻辑不完整的锅";
                }
                if (SN > 0)
                {
                    string stoken = "";
                    token.expires_in = "999999";
                    stoken += name.Length.ToString().PadLeft(3, '0');
                    stoken += name;
                    stoken += pwdhash.Length.ToString().PadLeft(3, '0');
                    stoken += pwdhash;
                    stoken += System.DateTime.Now.ToString("yyyyMMddHHmmss");
                    stoken += token.expires_in;
                    stoken += language.ToString().PadLeft(4, '0');
                    //token.expires_in = stoken;

                    token.access_token = DESE.Encrypt(stoken, secretKey);
                    token.STAFFID = Login_GETSTAFFID(name, pwdhash);
                    token.LANGUAGEID = language;
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return token;
        }


        public int[] SignInToken(string name, string password)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@NAME",SqlDbType.VarChar),
                                       new SqlParameter("@PASSWORD",SqlDbType.VarChar),
                                       new SqlParameter("@SN",SqlDbType.Int),
                                       new SqlParameter("@e_count",SqlDbType.Int),
                                       new SqlParameter("@sislock",SqlDbType.Int)
                                   };
            parms[0].Value = name;
            parms[1].Value = password;
            parms[2].Direction = ParameterDirection.Output;
            parms[3].Direction = ParameterDirection.Output;
            parms[4].Direction = ParameterDirection.Output;


            int[] SN = new int[3] { 0, 0, 0 };
            try
            {
                SQLServerHelper.ExecuteNonQuery(CommandType.StoredProcedure, SQL_SignInToken, parms);
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

        public int WX_SYS_Update(CRM_WX_SYS model)
        {
            SqlParameter[] parms = {
                                      new SqlParameter("@WX_SYSID", model.WX_SYSID),
                                      new SqlParameter("@WXAPPID", model.WXAPPID),
                                      new SqlParameter("@ACCESS_TOKEN", model.ACCESS_TOKEN),
                                      new SqlParameter("@TICKET", model.TICKET),
                                      new SqlParameter("@JLTIME", model.JLTIME),
                                      new SqlParameter("@EXPIRES_IN",model.EXPIRES_IN)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_WX_SYS_Update, parms);


        }
        public CRM_WX_SYS WX_SYS_ReadByWXAPPID(string WXAPPID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@WXAPPID",WXAPPID)
                                   };
            CRM_WX_SYS node = new CRM_WX_SYS();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_WX_SYS_ReadByWXAPPID, parms))
                {
                    if (sdr.Read())
                    {
                        node.WX_SYSID = Convert.ToInt32(sdr["WX_SYSID"]);
                        node.WXAPPID = Convert.ToString(sdr["WXAPPID"]);
                        node.ACCESS_TOKEN = Convert.ToString(sdr["ACCESS_TOKEN"]);
                        node.TICKET = Convert.ToString(sdr["TICKET"]);
                        node.JLTIME = Convert.ToString(sdr["JLTIME"]);
                        node.EXPIRES_IN = Convert.ToInt32(sdr["EXPIRES_IN"]);

                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return node;
        }


        public Boolean ValidateToken(string ptoken)
        {
            Boolean rtn = false;
            TokenInfo token = new TokenInfo();
            if (string.IsNullOrEmpty(ptoken))
            {
                return false;
            }
            int SN = 0;
            try
            {
                //生成Token


                if (string.IsNullOrEmpty(DESE.Decrypt(ptoken, secretKey)))
                {
                    return false;
                }

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
                Int32 expires_in = Convert.ToInt32(stoken.Substring(0, len));

                //判断是否在有效期内
                TimeSpan ts = DateTime.Now - sj;
                if (ts.TotalSeconds < expires_in)
                {
                    SN = SignIn(name, password);
                    if (SN > 0)
                    {
                        rtn = true;
                    }
                }
            }
            catch (Exception)
            {
                //throw new ApplicationException(e.Message);
                return false;
            }

            return rtn;
        }
        public int SignIn(string name, string pwd)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFUSER",name),
                                       new SqlParameter("@STAFFPW",pwd)
                                   };

            return Binning(CommandType.StoredProcedure, SQL_SignIn, parms);
        }




        private CRM_HG_RIGHT ReadRightToObject(SqlDataReader sdr)
        {
            CRM_HG_RIGHT node = new CRM_HG_RIGHT();
            node.RIGHTID = Convert.ToInt32(sdr["RIGHTID"]);
            node.RGROUPID = Convert.ToInt32(sdr["RGROUPID"]);
            node.RIGHTNAME = Convert.ToString(sdr["RIGHTNAME"]);
            node.RIGHTNO = Convert.ToInt32(sdr["RIGHTNO"]);
            node.RIGHTADD = Convert.ToString(sdr["RIGHTADD"]);
            node.RIGHTMEMO = Convert.ToString(sdr["RIGHTMEMO"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.IMAGELJ = Convert.ToString(sdr["IMAGELJ"]);
            node.PC = Convert.ToInt32(sdr["PC"]);
            node.WX = Convert.ToInt32(sdr["WX"]);
            return node;
        }

        private CRM_HG_ROLE ReadRoleToObject(SqlDataReader sdr)
        {
            CRM_HG_ROLE node = new CRM_HG_ROLE();
            node.ROLEID = Convert.ToInt32(sdr["ROLEID"]);
            node.ROLENAME = Convert.ToString(sdr["ROLENAME"]);
            node.ROLEMEMO = Convert.ToString(sdr["ROLEMEMO"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);

            return node;
        }
        private CRM_HG_RIGHTGROUP ReadGroupToObject(SqlDataReader sdr)
        {
            CRM_HG_RIGHTGROUP node = new CRM_HG_RIGHTGROUP();
            node.RGROUPID = Convert.ToInt32(sdr["RGROUPID"]);
            node.RGROUPNAME = Convert.ToString(sdr["RGROUPNAME"]);
            node.PRGROUPID = Convert.ToInt32(sdr["PRGROUPID"]);
            node.PRIGHTNO = Convert.ToInt32(sdr["PRIGHTNO"]);
            node.RGROUPMEMO = Convert.ToString(sdr["RGROUPMEMO"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.IMAGELJ = Convert.ToString(sdr["IMAGELJ"]);
            return node;
        }

        private int Binning(CommandType type, string sql, SqlParameter[] parms)
        {
            int ID = 0;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(type, sql, parms))
                {
                    if (sdr.Read())
                    {
                        ID = Convert.ToInt32(sdr["ID"]);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return ID;
        }


        public FullTokenInfo ReadToken(string ptoken)
        {
            FullTokenInfo token = new FullTokenInfo();
            token.PublicToken = ptoken;
            token.Valid = false;
            if (string.IsNullOrEmpty(token.PublicToken)) return token;
            try
            {
                //解密Token
                if (string.IsNullOrEmpty(DESE.Decrypt(token.PublicToken, secretKey))) return token;
                token.SecretToken = DESE.Decrypt(token.PublicToken, secretKey);
                string stoken = token.SecretToken;

                //取用户名
                int len = Convert.ToInt32(stoken.Substring(0, 3));
                token.Name = stoken.Substring(3, len);
                stoken = token.SecretToken.Remove(0, len + 3);

                //取密码
                len = Convert.ToInt32(stoken.Substring(0, 3));
                token.PasswordHash = stoken.Substring(3, len);
                stoken = stoken.Remove(0, len + 3);

                //取日期
                len = 14;
                token.CreateTime = DateTime.ParseExact(stoken.Substring(0, len), "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
                stoken = stoken.Remove(0, len);

                //取过期时间
                len = 6;
                token.ExpireTime = Convert.ToInt32(stoken.Substring(0, len));
                stoken = stoken.Remove(0, len);

                //取语言ID
                len = 4;
                if (stoken.Length >= 4)
                {
                    token.LanguageID = Convert.ToInt32(stoken.Substring(0, len));
                    stoken = stoken.Remove(0, len);
                }
                else
                {
                    token.LanguageID = 0;
                }

                //验证有效期和密码，并获取STAFFID
                TimeSpan ts = DateTime.Now - token.CreateTime;
                if (ts.TotalSeconds < token.ExpireTime)
                {
                    if (SignIn(token.Name, token.PasswordHash) > 0)
                    {
                        token.StaffID = Login_GETSTAFFID(token.Name, token.PasswordHash);
                        if (token.StaffID > 0)
                        {
                            token.Valid = true;
                            token.Message = "用户名和密码正确，并在有效期内";
                        }
                        else
                        {
                            token.Valid = false;
                            token.Message = "未找到STAFFID";
                        }
                    }
                    else
                    {
                        token.Valid = false;
                        token.Message = "用户名或密码错误";
                    }
                }
                else
                {
                    token.Valid = false;
                    token.Message = "不在有效期内";
                }
            }
            catch (Exception e)
            {
                token.Valid = false;
                token.Message = e.Message;
            }
            return token;
        }
    }
}

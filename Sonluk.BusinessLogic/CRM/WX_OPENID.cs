using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.Entities.MSG;
using Sonluk.Entities.WX;
using Sonluk.IDataAccess.CRM;
using Sonluk.IDataAccess.MSG;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class WX_OPENID
    {
        private static readonly IWX_OPENID _DataAccess = RMSDataAccess.CreateWX_OPENID();
        private static readonly ICRM_Login _loginDataAccess = RMSDataAccess.CreateCRM_Login();
        private static readonly ISEND_INFO _SendINFODataAccess = RMSDataAccess.CreateSEND_INFO();

        public int Create(CRM_WX_OPENID model, string USE)
        {
            return _DataAccess.Create(model, USE);
        }
        public int Update(CRM_WX_OPENID model)
        {
            return _DataAccess.Update(model);
        }
        public int DeleteByID(int ID)
        {
            return _DataAccess.DeleteByID(ID);
        }
        public int Delete(CRM_WX_OPENID model)
        {
            return _DataAccess.Delete(model);
        }
        public IList<CRM_WX_OPENID> ReadByParam(CRM_WX_OPENID model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public IList<CRM_WX_OPENIDList> ReadBySTAFFParam(CRM_WX_OPENIDList model)
        {
            return _DataAccess.ReadBySTAFFParam(model);
        }
        public IList<CRM_WX_OPENIDList> ReadByORDERTTID(int ORDERTTID)
        {
            return _DataAccess.ReadByORDERTTID(ORDERTTID);
        }
        public string code2session(string APPID, string SECRET, string JSCODE)
        {
            string jsondata = "https://api.weixin.qq.com/sns/jscode2session?appid=" + APPID + "&secret=" + SECRET + "&js_code=" + JSCODE + "&grant_type=authorization_code";


            return GetJson(jsondata);
        }
        public WX_MSG_RETURN SendMSG(int STAFFID, WX_MSG wxmsg, string SYS, string AppID, string AppSecret, int Agentid, string Type)
        {
            //IList<CRM_WX_OPENIDList> OPENID = _DataAccess.ReadBySTAFFParam(model);
            //string WXres = "SendMSG default";
            WX_MSG_RETURN MSG_RETURN = new WX_MSG_RETURN();

            if (SYS == "AppID")   //中银微信公众号
            {
                //WX_MSG wxmsg = new WX_MSG();
                wxmsg.template_id = System.Configuration.ConfigurationManager.AppSettings[Type]; ;//"CHmfeZ_ye3UBnl0sf5eoE7G-MWrntwFDTmljjIuYn-0";
                //wxmsg.data = new WX_MSG.Data();
                //wxmsg.data.first.value = "Warning！！！";
                //wxmsg.data.keyword1.value = MSG;
                //wxmsg.data.keyword2.value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //wxmsg.data.remark.value = "";
                //wxmsg.url = "www.baidu.com";

                MSG_RETURN = SendMSGtoWX(STAFFID, wxmsg, AppID, AppSecret);
            }
            else if (SYS == "CorpID")    //中银企业微信
            {
                //WX_MSG wxmsg = new WX_MSG();
                //wxmsg.toparty = "";
                //wxmsg.totag = "";
                wxmsg.msgtype = "text";
                wxmsg.agentid = Agentid;// Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Agentid"]);
                //wxmsg.text = new WX_MSG.TEXT();
                //wxmsg.text.content = MSG;
                wxmsg.safe = 0;


                MSG_RETURN = SendMSGtoQY(STAFFID, wxmsg, AppID, AppSecret);
            }

            return MSG_RETURN;
        }

        public WX_MSG_RETURN SendMSGtoWX(int STAFFID, WX_MSG wxmsg, string AppID, string AppSecret)
        {
            CRM_WX_OPENIDList model = new CRM_WX_OPENIDList();
            model.STAFFID = STAFFID;
            model.WXDLCS = AppID;
            IList<CRM_WX_OPENIDList> OPENID = new List<CRM_WX_OPENIDList>();
            try
            {
                OPENID = _DataAccess.ReadBySTAFFParam(model);
            }
            catch
            {
                string[] openid = System.Configuration.ConfigurationManager.AppSettings["OPENID"].Split(',');
                for (int i = 0; i < openid.Length; i++)
                {
                    CRM_WX_OPENIDList temp = new CRM_WX_OPENIDList();
                    temp.OPENID = openid[i];
                    OPENID.Add(temp);
                }

            }
            WX_MSG_RETURN MSG_RETURN = new WX_MSG_RETURN();
            if (OPENID.Count == 0)
            {
                MSG_RETURN.errcode = "-1";
                MSG_RETURN.errmsg = "找不到对应的OPENID";
            }
            for (int i = 0; i < OPENID.Count; i++)
            {
                wxmsg.touser = OPENID[i].OPENID;
                string url = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=";
                string WXres = MSGBase_WX(wxmsg, AppID, AppSecret, url);
                //{"errcode":0,"errmsg":"ok","msgid":1157035093320400898}
                try
                {
                    MSG_RETURN = Newtonsoft.Json.JsonConvert.DeserializeObject<WX_MSG_RETURN>(WXres);
                    if (MSG_RETURN.errcode == "0")
                    {
                        //发送成功，要把发送记录写进缓存表

                    }
                    else
                    {
                        //发送失败，把数据写进缓存表，下次定时任务的时候再发

                    }
                }
                catch (Exception e)
                {
                    //有报错，还是写进缓存表，但数据要与发送失败的区分开来

                }
            }
            return MSG_RETURN;
        }

        public WX_MSG_RETURN SendMSGtoQY(int STAFFID, WX_MSG wxmsg, string CorpID, string Secret)
        {
            CRM_WX_OPENIDList model = new CRM_WX_OPENIDList();
            model.STAFFID = STAFFID;
            model.WXDLCS = CorpID;
            IList<CRM_WX_OPENIDList> OPENID = _DataAccess.ReadBySTAFFParam(model);
            WX_MSG_RETURN MSG_RETURN = new WX_MSG_RETURN();
            if (OPENID.Count == 0)
            {
                MSG_RETURN.errcode = "-1";
                MSG_RETURN.errmsg = "找不到对应的OPENID";
            }
            for (int i = 0; i < OPENID.Count; i++)
            {
                wxmsg.touser = OPENID[i].OPENID;
                string url = "https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token=";
                string WXres = MSGBase_QY(wxmsg, CorpID, Secret, url);
                //{"errcode":0,"errmsg":"ok","invaliduser":""}
                try
                {
                    MSG_RETURN = Newtonsoft.Json.JsonConvert.DeserializeObject<WX_MSG_RETURN>(WXres);
                    if (MSG_RETURN.errcode == "0")
                    {
                        //发送成功，要把发送记录写进缓存表

                    }
                    else
                    {
                        //发送失败，把数据写进缓存表，下次定时任务的时候再发

                    }
                }
                catch (Exception e)
                {
                    //有报错，还是写进缓存表，但数据要与发送失败的区分开来

                }
            }
            return MSG_RETURN;
        }

        public string MSGBase_WX(WX_MSG wxmsg, string CorpID, string secret, string url)
        {
            string[] result = GetWXtoken(CorpID, secret);
            string serviceAddress = url + result[0];   //微信API地址
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);

            request.Method = "POST";
            request.ContentType = "application/json";                          //otKEk1FYKxWN_RQEmMhwNBbnOpKQ


            using (StreamWriter dataStream = new StreamWriter(request.GetRequestStream()))
            {
                dataStream.Write(Newtonsoft.Json.JsonConvert.SerializeObject(wxmsg));
                dataStream.Close();
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string encoding = response.ContentEncoding;
            if (encoding == null || encoding.Length < 1)
            {
                encoding = "UTF-8"; //默认编码  
            }
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
            string retString = reader.ReadToEnd();
            //解析josn
            JObject jo = JObject.Parse(retString);
            //Response.Write(jo["message"]["mmmm"].ToString());
            return Newtonsoft.Json.JsonConvert.SerializeObject(jo);
        }

        public string MSGBase_QY(WX_MSG wxmsg, string CorpID, string secret, string url)
        {
            string[] result = GetQYtoken(CorpID, secret);
            string serviceAddress = url + result[0];   //微信API地址
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);

            request.Method = "POST";
            request.ContentType = "application/json";                          //otKEk1FYKxWN_RQEmMhwNBbnOpKQ


            using (StreamWriter dataStream = new StreamWriter(request.GetRequestStream()))
            {
                dataStream.Write(Newtonsoft.Json.JsonConvert.SerializeObject(wxmsg));
                dataStream.Close();
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string encoding = response.ContentEncoding;
            if (encoding == null || encoding.Length < 1)
            {
                encoding = "UTF-8"; //默认编码  
            }
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
            string retString = reader.ReadToEnd();
            //解析josn
            JObject jo = JObject.Parse(retString);
            //Response.Write(jo["message"]["mmmm"].ToString());
            return Newtonsoft.Json.JsonConvert.SerializeObject(jo);
        }

        public string[] GetWXtoken(string appid, string AppSecret)         //获取公众号token
        {
            CRM_WX_SYS model = new CRM_WX_SYS();

            try   //正常情况
            {
                model = _loginDataAccess.WX_SYS_ReadByWXAPPID(appid);

                DateTime nowtime = DateTime.Now;
                DateTime effective_time = Convert.ToDateTime(model.JLTIME).AddSeconds(model.EXPIRES_IN);
                if (effective_time <= nowtime)         //token过期的情况
                {
                    string[] data = ReGetWXtoken(model.WX_SYSID, appid, AppSecret);
                    model.ACCESS_TOKEN = data[0];
                    model.TICKET = data[1];
                }
            }
            catch   //数据库爆掉的情况
            {
                string[] data = ReGetWXtoken(model.WX_SYSID, appid, AppSecret);
                model.ACCESS_TOKEN = data[0];
                model.TICKET = data[1];
            }

            string[] s = new string[2];
            s[0] = model.ACCESS_TOKEN;
            s[1] = model.TICKET;
            return s;
        }

        public string[] ReGetWXtoken(int SYSID, string AppID, string AppSecret)                 //重新刷新公众号token
        {
            //string appid = System.Configuration.ConfigurationManager.AppSettings["AppID"]; //微信公众号appid
            //string secret = System.Configuration.ConfigurationManager.AppSettings["AppSecret"];  //微信公众号appsecret
            string TokenUrl = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + AppID + "&secret=" + AppSecret;
            string TokenJson = GetJson(TokenUrl);
            Access_token token_modle = JsonConvert.DeserializeObject<Access_token>(TokenJson);



            string TicketUrl = "https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token=" + token_modle.access_token + "&type=jsapi";
            string TicketJson = GetJson(TicketUrl);
            JSApi_Ticket Ticket_model = JsonConvert.DeserializeObject<JSApi_Ticket>(TicketJson);
            string ticket = Ticket_model.ticket;

            try  //正常情况
            {
                CRM_WX_SYS model = new CRM_WX_SYS();
                model.WX_SYSID = SYSID;
                model.WXAPPID = AppID;
                model.ACCESS_TOKEN = token_modle.access_token;
                model.TICKET = ticket;
                model.EXPIRES_IN = Convert.ToInt32(token_modle.expires_in) / 4;// -200;
                _loginDataAccess.WX_SYS_Update(model);
            }
            catch   //数据库爆掉的情况
            {

            }


            string[] s = new string[2];
            s[0] = token_modle.access_token;
            s[1] = ticket;
            return s;
        }

        public string[] GetQYtoken(string corpid, string secret)             //获取企业微信token
        {
            CRM_WX_SYS model = _loginDataAccess.WX_SYS_ReadByWXAPPID(corpid);

            DateTime nowtime = DateTime.Now;
            DateTime effective_time = Convert.ToDateTime(model.JLTIME).AddSeconds(model.EXPIRES_IN);
            if (effective_time <= nowtime)         //token过期的情况
            {
                string[] data = ReGetQYtoken(model.WX_SYSID, corpid, secret);
                model.ACCESS_TOKEN = data[0];
                model.TICKET = data[1];
            }
            string[] s = new string[2];
            s[0] = model.ACCESS_TOKEN;
            s[1] = model.TICKET;
            return s;


        }

        public string[] ReGetQYtoken(int SYSID, string corpid, string secret)                 //重新刷新企业微信token
        {
            //string corpid = System.Configuration.ConfigurationManager.AppSettings["CorpID"]; //企业微信id
            //string secret = System.Configuration.ConfigurationManager.AppSettings["Secret"];  //企业微信号appsecret
            string TokenUrl = "https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid=" + corpid + "&corpsecret=" + secret;
            string TokenJson = GetJson(TokenUrl);
            QY_Access_Token token_modle = JsonConvert.DeserializeObject<QY_Access_Token>(TokenJson);



            string TicketUrl = "https://qyapi.weixin.qq.com/cgi-bin/get_jsapi_ticket?access_token=" + token_modle.access_token;
            string TicketJson = GetJson(TicketUrl);
            QY_Ticket Ticket_model = JsonConvert.DeserializeObject<QY_Ticket>(TicketJson);
            string ticket = Ticket_model.ticket;

            CRM_WX_SYS model = new CRM_WX_SYS();
            model.WX_SYSID = SYSID;
            model.WXAPPID = corpid;
            model.ACCESS_TOKEN = token_modle.access_token;
            model.TICKET = ticket;
            model.EXPIRES_IN = Convert.ToInt32(token_modle.expires_in) - 200;
            _loginDataAccess.WX_SYS_Update(model);

            string[] s = new string[2];
            s[0] = token_modle.access_token;
            s[1] = ticket;
            return s;
        }

        public string GetJson(string url)               //获得htp get返回的值
        {
            //访问http  
            WebClient wc = new WebClient();
            wc.Credentials = CredentialCache.DefaultCredentials;
            wc.Encoding = Encoding.UTF8;
            string returnText = wc.DownloadString(url);
            if (returnText.Contains("errcode"))
            {
                //可能发生错误  
            }
            //Response.Write(returnText);  
            return returnText;
        }

        public WX_MSG_RETURN SendMSGFromTemp(MSG_SEND_INFO data, string AppID, string AppSecret)
        {




            WX_MSG_RETURN temp = new WX_MSG_RETURN();

            if (data.SENDWAYSIGN == 2374)   //中银微信公众号
            {
                WX_MSG wxmsg = Newtonsoft.Json.JsonConvert.DeserializeObject<WX_MSG>(data.SENDMSG);
                temp = SendMSGtoWX(data.STAFFID, wxmsg, AppID, AppSecret);
            }
            else if (data.SENDWAYSIGN == 2375)    //中银企业微信
            {
                WX_MSG wxmsg = Newtonsoft.Json.JsonConvert.DeserializeObject<WX_MSG>(data.SENDMSG);
                temp = SendMSGtoQY(data.STAFFID, wxmsg, AppID, AppSecret);
            }









            return temp;
        }










    }
}

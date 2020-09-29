using MSXML2;
using Sonluk.API.Models;
using Sonluk.Entities.CRM;
using Sonluk.Entities.MSG;
using Sonluk.Entities.WX;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Services;
using Oracle.DataAccess.Client;
using Sonluk.DataAccess.OA.Utility;
using Sonluk.DataAccess.Utility.Oracle;
using System.Configuration;
using Sonluk.Utility;

namespace Sonluk.API.MSG
{
    /// <summary>
    /// SEND_INFO 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class SEND_INFO : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        MSGModels MSGmodels = new MSGModels();

        string AppID = System.Configuration.ConfigurationManager.AppSettings["AppID"]; //微信id
        string AppSecret = System.Configuration.ConfigurationManager.AppSettings["AppSecret"];  //微信secret
        int Agentid = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Agentid"]);
        string CorpID = System.Configuration.ConfigurationManager.AppSettings["CorpID"]; //企业微信id
        string secret = System.Configuration.ConfigurationManager.AppSettings["Secret"];  //企业微信号appsecret

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Create(MSG_SEND_INFO model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return MSGmodels.SEND_INFO.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update(MSG_SEND_INFO model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return MSGmodels.SEND_INFO.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public List<MSG_SEND_INFO> ReadByParam(MSG_SEND_INFO model, string ptoken)
        {
            List<MSG_SEND_INFO> node = new List<MSG_SEND_INFO>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return MSGmodels.SEND_INFO.ReadByParam(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public int Delete(int INFOID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return MSGmodels.SEND_INFO.Delete(INFOID);
            }
            return -100;

        }
        [WebMethod]
        public string AutoCheck()
        {
            MSG_SYS_SYSINFO cx_sys = new MSG_SYS_SYSINFO();
            cx_sys.ISACTIVE = 1;
            IList<MSG_SYS_SYSINFO> SYSdata = new List<MSG_SYS_SYSINFO>();

            try
            {
                SYSdata = MSGmodels.SYS_SYSINFO.ReadByParam(cx_sys);
            }
            catch (Exception e)
            {

                #region 集成数据库查询失败，通知固定人员
                WX_MSG WXMSG = new WX_MSG();
                WXMSG.data = new Sonluk.Entities.WX.WX_MSG.Data();
                WXMSG.miniprogram = new Sonluk.Entities.WX.WX_MSG.MiniProgram();
                WXMSG.text = new Sonluk.Entities.WX.WX_MSG.TEXT();

                WXMSG.data.first = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                WXMSG.data.first.value = "系统异常";

                WXMSG.data.keyword1 = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                WXMSG.data.keyword1.value = "预警系统数据库";

                WXMSG.data.keyword2 = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                WXMSG.data.keyword2.value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                WXMSG.data.keyword3 = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                WXMSG.data.keyword3.value = "数据库查询数据失败";

                WXMSG.data.keyword4 = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                WXMSG.data.keyword4.value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                WXMSG.data.remark = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                WXMSG.data.remark.value = e.Message;


                models.WX_OPENID.SendMSG(0, WXMSG, "AppID", AppID, AppSecret, 0, "系统异常通知");
                #endregion
            }
            for (int i = 0; i < SYSdata.Count; i++)
            {
                MSG_MSGTYPE_WAY cx_sendway = new MSG_MSGTYPE_WAY();
                cx_sendway.TYPEID = SYSdata[i].MSGTYPEID;
                IList<MSG_MSGTYPE_WAY> SendWay = MSGmodels.MSGTYPE_WAY.ReadByParam(cx_sendway);

                MSG_SYS_STAFF cx_staff = new MSG_SYS_STAFF();
                cx_staff.SYSID = SYSdata[i].SYSID;
                cx_staff.IFSEND = 1;
                IList<MSG_SYS_STAFF> STAFF = MSGmodels.SYS_STAFF.ReadByParam(cx_staff);

                WX_MSG_RETURN MSG_RETURN = new WX_MSG_RETURN();



                if (SYSdata[i].LINKWAY == 2)
                {
                    #region 是独立系统，需要根据连接字符串去连接数据库判断

                    string CONNSTR = "Data Source=" + SYSdata[i].DATASOURCE + ";Initial Catalog=" + SYSdata[i].CATALOG + ";Persist Security Info=True;User ID=" + SYSdata[i].USERID + ";Password=" + SYSdata[i].PASSWORD;
                    SqlConnection conn = null;
                    try
                    {
                        conn = new SqlConnection(CONNSTR);
                        conn.Open();
                        conn.Close();
                        //数据库连接成功


                        //正常返回
                        if (SYSdata[i].MODE == 2373)      //假日模式，正常也要发送信息
                        {
                            //发
                            #region 填入文本
                            WX_MSG WXMSG = new WX_MSG();
                            WXMSG.data = new Sonluk.Entities.WX.WX_MSG.Data();
                            WXMSG.miniprogram = new Sonluk.Entities.WX.WX_MSG.MiniProgram();
                            WXMSG.text = new Sonluk.Entities.WX.WX_MSG.TEXT();

                            WXMSG.data.first = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                            WXMSG.data.first.value = "系统正常";

                            WXMSG.data.keyword1 = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                            WXMSG.data.keyword1.value = SYSdata[i].SYSNAME;

                            WXMSG.data.keyword2 = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                            WXMSG.data.keyword2.value = "数据库连接";

                            WXMSG.data.keyword3 = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                            WXMSG.data.keyword3.value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                            WXMSG.data.remark = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                            WXMSG.data.remark.value = "";



                            WXMSG.text = new WX_MSG.TEXT();
                            WXMSG.text.content = SYSdata[i].SYSNAME + "系统运行正常";
                            #endregion

                            SendToSTAFF(SYSdata[i], WXMSG,1);
                        }

                    }
                    catch (Exception e)
                    {
                        #region 填入文本
                        WX_MSG WXMSG = new WX_MSG();
                        WXMSG.data = new Sonluk.Entities.WX.WX_MSG.Data();
                        WXMSG.miniprogram = new Sonluk.Entities.WX.WX_MSG.MiniProgram();
                        WXMSG.text = new Sonluk.Entities.WX.WX_MSG.TEXT();

                        WXMSG.data.first = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                        WXMSG.data.first.value = "系统异常";

                        WXMSG.data.keyword1 = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                        WXMSG.data.keyword1.value = SYSdata[i].SYSNAME;

                        WXMSG.data.keyword2 = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                        WXMSG.data.keyword2.value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                        WXMSG.data.keyword3 = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                        WXMSG.data.keyword3.value = "数据库连接失败";

                        WXMSG.data.keyword4 = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                        WXMSG.data.keyword4.value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                        WXMSG.data.remark = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                        WXMSG.data.remark.value = e.Message;




                        WXMSG.text = new WX_MSG.TEXT();
                        WXMSG.text.content = SYSdata[i].SYSNAME + "数据库连接失败";


                        #endregion

                        SendToSTAFF(SYSdata[i], WXMSG,0);


                        continue;
                    }


                    #endregion

                }
                else if (SYSdata[i].LINKWAY == 1)
                {
                    #region 是集成系统，直接根据各个系统去调用API判断即可

                    try
                    {
                        string Url = SYSdata[i].API + "?name=" + "123" + "&password=" + "123";
                        string JSON = GetJson(Url);


                        //正常返回
                        if (SYSdata[i].MODE == 2373)      //假日模式，正常也要发送信息
                        {
                            //发
                            #region 填入文本
                            WX_MSG WXMSG = new WX_MSG();
                            WXMSG.data = new Sonluk.Entities.WX.WX_MSG.Data();
                            WXMSG.miniprogram = new Sonluk.Entities.WX.WX_MSG.MiniProgram();
                            WXMSG.text = new Sonluk.Entities.WX.WX_MSG.TEXT();

                            WXMSG.data.first = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                            WXMSG.data.first.value = "系统正常";

                            WXMSG.data.keyword1 = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                            WXMSG.data.keyword1.value = SYSdata[i].SYSNAME;

                            WXMSG.data.keyword2 = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                            WXMSG.data.keyword2.value = "API调用";

                            WXMSG.data.keyword3 = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                            WXMSG.data.keyword3.value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                            WXMSG.data.remark = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                            WXMSG.data.remark.value = "系统运行正常";


                            WXMSG.text = new WX_MSG.TEXT();
                            WXMSG.text.content = SYSdata[i].SYSNAME + "系统运行正常";

                            #endregion

                            SendToSTAFF(SYSdata[i], WXMSG,1);


                        }




                    }
                    catch (Exception e)
                    {
                        #region 填入文本
                        WX_MSG WXMSG = new WX_MSG();
                        WXMSG.data = new Sonluk.Entities.WX.WX_MSG.Data();
                        WXMSG.miniprogram = new Sonluk.Entities.WX.WX_MSG.MiniProgram();
                        WXMSG.text = new Sonluk.Entities.WX.WX_MSG.TEXT();

                        WXMSG.data.first = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                        WXMSG.data.first.value = "系统异常";

                        WXMSG.data.keyword1 = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                        WXMSG.data.keyword1.value = SYSdata[i].SYSNAME;

                        WXMSG.data.keyword2 = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                        WXMSG.data.keyword2.value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                        WXMSG.data.keyword3 = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                        WXMSG.data.keyword3.value = "API调用失败";

                        WXMSG.data.keyword4 = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                        WXMSG.data.keyword4.value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                        WXMSG.data.remark = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                        WXMSG.data.remark.value = e.Message;



                        WXMSG.text = new WX_MSG.TEXT();
                        WXMSG.text.content = "系统异常! API调用失败";
                        #endregion

                        SendToSTAFF(SYSdata[i], WXMSG,0);

                        continue;
                    }




                    #endregion




                }
                else if (SYSdata[i].LINKWAY == 3)
                {
                    #region 是SAP系统，调用一个SAP接口即可

                    try
                    {
                        IList<SAP_KH> SAP_KH_nodes = new List<SAP_KH>();
                        SAP_KH SAP_KH_node = new SAP_KH();
                        SAP_KH_node.KUNNR = "100016";
                        SAP_KH_nodes.Add(SAP_KH_node);
                        SAP_HZHBList KH = models.KH_HZHB.SyncSapRead(SAP_KH_nodes, 0);

                        //正常返回
                        if (SYSdata[i].MODE == 2373)      //假日模式，正常也要发送信息
                        {
                            #region 填入文本
                            WX_MSG WXMSG = new WX_MSG();
                            WXMSG.data = new Sonluk.Entities.WX.WX_MSG.Data();
                            WXMSG.miniprogram = new Sonluk.Entities.WX.WX_MSG.MiniProgram();
                            WXMSG.text = new Sonluk.Entities.WX.WX_MSG.TEXT();

                            WXMSG.data.first = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                            WXMSG.data.first.value = "系统正常";

                            WXMSG.data.keyword1 = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                            WXMSG.data.keyword1.value = SYSdata[i].SYSNAME;

                            WXMSG.data.keyword2 = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                            WXMSG.data.keyword2.value = "接口调用";

                            WXMSG.data.keyword3 = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                            WXMSG.data.keyword3.value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                            WXMSG.data.remark = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                            WXMSG.data.remark.value = "系统运行正常";


                            WXMSG.text = new WX_MSG.TEXT();
                            WXMSG.text.content = SYSdata[i].SYSNAME + "系统运行正常";

                            #endregion

                            SendToSTAFF(SYSdata[i], WXMSG,1);

                        }

                    }
                    catch (Exception e)
                    {
                        #region 填入文本
                        WX_MSG WXMSG = new WX_MSG();
                        WXMSG.data = new Sonluk.Entities.WX.WX_MSG.Data();
                        WXMSG.miniprogram = new Sonluk.Entities.WX.WX_MSG.MiniProgram();
                        WXMSG.text = new Sonluk.Entities.WX.WX_MSG.TEXT();

                        WXMSG.data.first = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                        WXMSG.data.first.value = "系统异常";

                        WXMSG.data.keyword1 = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                        WXMSG.data.keyword1.value = SYSdata[i].SYSNAME;

                        WXMSG.data.keyword2 = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                        WXMSG.data.keyword2.value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                        WXMSG.data.keyword3 = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                        WXMSG.data.keyword3.value = "接口调用失败";

                        WXMSG.data.keyword4 = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                        WXMSG.data.keyword4.value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                        WXMSG.data.remark = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                        WXMSG.data.remark.value = e.Message;



                        WXMSG.text = new WX_MSG.TEXT();
                        WXMSG.text.content = "系统异常! 接口调用失败";
                        #endregion

                        SendToSTAFF(SYSdata[i], WXMSG,0);

                        continue;
                    }






                    #endregion
                }
                else if (SYSdata[i].LINKWAY == 4)
                {
                    #region 是Oracle数据库，需要根据连接字符串去连接数据库判断
                    
                    //string CONNSTR = "Data Source=" + SYSdata[i].DATASOURCE + ";Initial Catalog=" + SYSdata[i].CATALOG + ";Persist Security Info=True;User ID=" + SYSdata[i].USERID + ";Password=" + SYSdata[i].PASSWORD;
                    OracleConnection conn = null;
                    try
                    {
                        string connstring = Build("OA", "OA.DB.User", "OA.DB.Password", "sMrqqC}+");
                        //return connstring;
                        //conn = new OracleConnection("USER ID=v3xuser;DATA SOURCE='(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.0.168)(PORT = 1521))(CONNECT_DATA = (SID = orcl)))';PASSWORD=123456");
                        conn = new OracleConnection(connstring);
                        conn.Open();
                        conn.Close();
                        //数据库连接成功
                        return Newtonsoft.Json.JsonConvert.SerializeObject(conn);

                        //正常返回
                        if (SYSdata[i].MODE == 2373)      //假日模式，正常也要发送信息
                        {
                            //发
                            #region 填入文本
                            WX_MSG WXMSG = new WX_MSG();
                            WXMSG.data = new Sonluk.Entities.WX.WX_MSG.Data();
                            WXMSG.miniprogram = new Sonluk.Entities.WX.WX_MSG.MiniProgram();
                            WXMSG.text = new Sonluk.Entities.WX.WX_MSG.TEXT();

                            WXMSG.data.first = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                            WXMSG.data.first.value = "系统正常";

                            WXMSG.data.keyword1 = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                            WXMSG.data.keyword1.value = SYSdata[i].SYSNAME;

                            WXMSG.data.keyword2 = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                            WXMSG.data.keyword2.value = "数据库连接";

                            WXMSG.data.keyword3 = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                            WXMSG.data.keyword3.value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                            WXMSG.data.remark = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                            WXMSG.data.remark.value = "";



                            WXMSG.text = new WX_MSG.TEXT();
                            WXMSG.text.content = SYSdata[i].SYSNAME + "系统运行正常";
                            #endregion

                            SendToSTAFF(SYSdata[i], WXMSG, 1);
                        }

                    }
                    catch (Exception e)
                    {
                        #region 填入文本
                        WX_MSG WXMSG = new WX_MSG();
                        WXMSG.data = new Sonluk.Entities.WX.WX_MSG.Data();
                        WXMSG.miniprogram = new Sonluk.Entities.WX.WX_MSG.MiniProgram();
                        WXMSG.text = new Sonluk.Entities.WX.WX_MSG.TEXT();

                        WXMSG.data.first = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                        WXMSG.data.first.value = "系统异常";

                        WXMSG.data.keyword1 = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                        WXMSG.data.keyword1.value = SYSdata[i].SYSNAME;

                        WXMSG.data.keyword2 = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                        WXMSG.data.keyword2.value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                        WXMSG.data.keyword3 = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                        WXMSG.data.keyword3.value = "数据库连接失败";

                        WXMSG.data.keyword4 = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                        WXMSG.data.keyword4.value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                        WXMSG.data.remark = new Sonluk.Entities.WX.WX_MSG.KeyWord();
                        WXMSG.data.remark.value = e.Message;




                        WXMSG.text = new WX_MSG.TEXT();
                        WXMSG.text.content = SYSdata[i].SYSNAME + "数据库连接失败";


                        #endregion

                        SendToSTAFF(SYSdata[i], WXMSG, 0);


                        continue;
                    }


                    #endregion
                }

            }





            return "";
        }


        /// <summary>
        /// 不管发送是否成功，都存到表里，对于发送失败的下一次发
        /// </summary>
        /// <param name="SYSdata"></param>
        /// <param name="SendWay"></param>
        /// <param name="WXMSG"></param>
        /// <param name="STAFFID"></param>
        /// <param name="MSG_RETURN"></param>
        void InsertTemp(MSG_SYS_SYSINFO SYSdata, MSG_MSGTYPE_WAY SendWay, WX_MSG WXMSG, int STAFFID, WX_MSG_RETURN MSG_RETURN)
        {
            MSG_SEND_INFO temp = new MSG_SEND_INFO();
            temp.SYSID = SYSdata.SYSID;
            temp.SYSDEC = SYSdata.SYSNAME;
            temp.SENDWAYSIGN = SendWay.SENDWAYSIGN;
            temp.MEDIUM = SendWay.MEDIUM;
            temp.MODEL = SendWay.MODEL;
            temp.SENDMSG = Newtonsoft.Json.JsonConvert.SerializeObject(WXMSG);
            temp.STAFFID = STAFFID;
            temp.ISACTIVE = 1;
            temp.BACKMSG = Newtonsoft.Json.JsonConvert.SerializeObject(MSG_RETURN);

            if (MSG_RETURN.errcode == "0")
            {
                temp.SUCCESS = 1;
            }
            else
            {
                temp.SUCCESS = 0;
            }

            MSGmodels.SEND_INFO.Create(temp);
        }


        void SendToSTAFF(MSG_SYS_SYSINFO SYSdata, WX_MSG WXMSG,int AllClear)
        {
            MSG_SYS_STAFF cx_staff = new MSG_SYS_STAFF();
            cx_staff.SYSID = SYSdata.SYSID;
            cx_staff.IFSEND = 1;
            IList<MSG_SYS_STAFF> STAFF = MSGmodels.SYS_STAFF.ReadByParam(cx_staff);

            for (int i = 0; i < STAFF.Count; i++)
            {
                MSG_MSGTYPE_WAY cx_sendway = new MSG_MSGTYPE_WAY();
                if (STAFF[i].MSGTYPEID == 0)  //人员没有单独设置消息类型，就以整个系统的消息类型为准
                {
                    cx_sendway.TYPEID = SYSdata.MSGTYPEID;
                }
                else
                {
                    cx_sendway.TYPEID = STAFF[i].MSGTYPEID;
                }
                IList<MSG_MSGTYPE_WAY> SendWay = MSGmodels.MSGTYPE_WAY.ReadByParam(cx_sendway);

                for (int j = 0; j < SendWay.Count; j++)
                {

                    if (SendWay[j].SENDWAYSIGN == 2374)
                    {
                        string MODEL = "检查结果通知";
                        if (AllClear == 0)
                        {
                            MODEL = SendWay[j].MODELDES;
                        }
                        WX_MSG_RETURN MSG_RETURN = models.WX_OPENID.SendMSG(STAFF[i].STAFFID, WXMSG, "AppID", AppID, AppSecret, 0, MODEL);
                        InsertTemp(SYSdata, SendWay[j], WXMSG, STAFF[i].STAFFID, MSG_RETURN);


                    }
                    else if (SendWay[j].SENDWAYSIGN == 2375)
                    {
                        WX_MSG_RETURN MSG_RETURN = models.WX_OPENID.SendMSG(STAFF[i].STAFFID, WXMSG, "CorpID", CorpID, secret, Agentid, "");
                        InsertTemp(SYSdata, SendWay[j], WXMSG, STAFF[i].STAFFID, MSG_RETURN);

                    }

                }

            }

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

        public static string Build(string name, string user, string password, string secretKey)
        {
            OracleConnectionStringBuilder builder = new OracleConnectionStringBuilder(ConfigurationManager.ConnectionStrings[name].ToString());
            builder.UserID = AppConfig.Settings(user, secretKey);
            builder.Password = AppConfig.Settings(password, secretKey);
            return builder.ToString();
        }











    }
}
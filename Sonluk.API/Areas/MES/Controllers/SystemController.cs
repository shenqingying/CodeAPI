using Sonluk.API.Models;
using Sonluk.Entities.CRM;
using Sonluk.Entities.EM;
using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using Sonluk.Utility.Security;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using System.Web.Security;

namespace Sonluk.API.Areas.MES.Controllers
{
    public class SystemController : ApiController
    {
        MESModels mesmodel = new MESModels();
        RMSModels rmsmodel = new RMSModels();
        PublicModel publicmodel = new PublicModel();
        /// <summary>
        /// 登录目的是为了获取token，然后在通过权限
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet]
        public MES_LoginINFO Login(string name, string password)
        {
            //return mesmodel.MES_Login.Login(name, password, OPENID, WXDLCS, PC, WX, GCID);
            //MES_RIGHT_ROLE menuinfo = models.RIGHT_ROLE.SELECT_ALL(STAFFID, 15, token);
            return mesmodel.MES_Login.Login(name, password, "", "", 0, 1, 0);
        }
        /// <summary>
        /// 通过STAFFID获取
        /// </summary>
        /// <param name="data">data.staffid 人员ID</param>
        ///  <param name="data">data.token  </param>
        /// <returns></returns>
        [HttpPost]
        public MES_RIGHT_ROLE RIGHT_ROLEByStaffid(dynamic data)
        {
            int staffid = data.staffid;
            string token = data.token;
            if (rmsmodel.CRM_Login.ValidateToken(token))
            {
                return mesmodel.RIGHT_ROLE.SELECT_ALL(staffid, 15,0);
            }
            else
            {
                MES_RIGHT_ROLE rst = new MES_RIGHT_ROLE();
                MES_RETURN mr = new MES_RETURN();
                mr.TYPE = "E";
                mr.MESSAGE = "token不正确，请重新登录！";
                rst.MES_RETURN = mr;
                return rst;
            }
           
        }
        /// <summary>
        /// 平板端通过帐号密码获取登录的token、功能权限、获取对应人员的信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet]
        public MES_Mobile_Login Mobile_Login(string name, string password)
        {
            MES_Mobile_Login rst = new MES_Mobile_Login();
            rst.MES_RIGHT_ROLE = new MES_RIGHT_ROLE();
            rst.MES_LoginINFO = new MES_LoginINFO();
            rst.CRM_HG_STAFF = new CRM_HG_STAFF();

            //获取人员ID和token
            MES_LoginINFO loginInfo = mesmodel.MES_Login.Login(name, password, "", "", 0, 1, 0);
            rst.MES_LoginINFO = loginInfo;
            if (!loginInfo.MES_RETURN.TYPE.Equals("S"))
            {
                return rst;
            }
            //获取角色功能权限
            int staffid = loginInfo.TokenInfo.STAFFID;
            //int[] groupArr = new int[] { 39, 40 };
            MES_RIGHT_ROLE rightrole = mesmodel.RIGHT_ROLE.SELECT_Android(staffid);

            rst.MES_RIGHT_ROLE = rightrole;
            
            //获取人员ID对应的人员信息
            CRM_HG_STAFF hg_staff = rmsmodel.HG_STAFF.RaedBySTAFFID(staffid);
            rst.CRM_HG_STAFF = hg_staff;
            return rst;
        }
        /// <summary>
        /// 平板端密码修改，传入参数STAFFID、旧密码(oldpassword)、新密码(newpassword)、token
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpPost]
        public MES_RETURN UpdatePassword(dynamic parms)//
        {
            MES_RETURN mr = new MES_RETURN();
            int STAFFID = parms.staffid;
            string oldpassword = parms.oldpassword;
            string newpassword = parms.newpassword;
            string token = parms.token;
            if (!rmsmodel.CRM_Login.ValidateToken(token))
            {               
                mr.TYPE = "E";
                mr.MESSAGE = "token不正确，请重新登录！";
                return mr;
            }
            CRM_HG_STAFF staffmodel = rmsmodel.HG_STAFF.RaedBySTAFFID(STAFFID);
            string md5_pwd = MD5Hash.GetMd5Hash(oldpassword).ToUpper();
            string oldpass = FormsAuthentication.HashPasswordForStoringInConfigFile(oldpassword, "MD5").ToLower();
            if (!oldpass.Equals(staffmodel.STAFFPW))
            {
                mr.TYPE = "E";
                mr.MESSAGE = "原密码不对,请核对旧密码！" ;
                return mr;           //原密码不对
            }
            staffmodel.STAFFPW = FormsAuthentication.HashPasswordForStoringInConfigFile(newpassword, "MD5").ToLower();
            int i = rmsmodel.HG_STAFF.Update(staffmodel);
            if (i <= 0)
            {
                mr.TYPE = "E";
                mr.MESSAGE = "密码更新失败,请联系管理员！";
                return mr;           //原密码不对
            }
            mr.TYPE = "S";
            mr.MESSAGE = "密码更新成功！";
            return mr;
        }
        [HttpPost]
        public MES_SY_XTBB_SELECT SelectXTZXBB(dynamic parms)
        {
            //string token = parms.token;
            string syid = parms.syid;
            //if (rmsmodel.CRM_Login.ValidateToken(token))
            //{
                //E:\电子指导书\包装作业指导书\apk\app-release.apk
                MES_SY_XTBB model = new MES_SY_XTBB();
                model.SYID = syid;
                model.ISZXBB = 1;
                //ServiceModel serviceModel = new ServiceModel();
                MES_SY_XTBB_SELECT res = mesmodel.SY_XTBB.SELECT(model);
                return res;
            //}
            //else
            //{
            //    MES_SY_XTBB_SELECT res = new MES_SY_XTBB_SELECT();
            //    MES_RETURN rst = new MES_RETURN();
            //    rst.TYPE = "E";
            //    rst.MESSAGE = "ptoken不正确，请重新登录！";
            //    res.MES_RETURN = rst;
            //    return res;
            //}
        }
        [HttpPost]
        public object SelectRYINFObySBH(dynamic parms)
        {
            //HR_RY_RYINFO_SELECT node = new HR_RY_RYINFO_SELECT();
            //MES_RETURN mr = new MES_RETURN();
            string sbbh = parms.SBBH;
            string token = parms.token;
            if (!rmsmodel.CRM_Login.ValidateToken(token))
            {
                //mr.TYPE = "E";
                //mr.MESSAGE = "token不正确，请重新登录！";
                //node.MES_RETURN = mr;
                return new List<HR_RY_RYINFO_LIST>();
            }
            return rmsmodel.SY_DEVICE_CONTRACT.SelectRYINFObySBH(sbbh);
            //IList<HR_RY_RYINFO_LIST> res = rmsmodel.SY_DEVICE_CONTRACT.SelectRYINFObySBH(sbbh);
            //mr.TYPE = "S";
            //node.HR_RY_RYINFO_LIST = res.ToList();
            //node.MES_RETURN = mr;
            //return node;
        }
        [HttpPost]
        public HttpResponseMessage GetfileStreambyUrl(dynamic parms)
        {
            string url = parms.url;
            Uri httpURL = new Uri(url);
            ///HttpWebRequest类继承于WebRequest，并没有自己的构造函数，需通过WebRequest的Creat方法 建立，并进行强制的类型转换   
            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(httpURL);
            ///通过HttpWebRequest的GetResponse()方法建立HttpWebResponse,强制类型转换   
            HttpWebResponse httpResp = (HttpWebResponse)httpReq.GetResponse();
            ///GetResponseStream()方法获取HTTP响应的数据流,并尝试取得URL中所指定的网页内容   
            ///若成功取得网页的内容，则以System.IO.Stream形式返回，若失败则产生ProtoclViolationException错 误。在此正确的做法应将以下的代码放到一个try块中处理。这里简单处理   
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(httpResp.GetResponseStream());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            return response;
        }
        [HttpPost]
        public HttpResponseMessage Testurl()
        {
            string url = "http://192.168.8.244/HR/upload/img/PIC/hr/02732.jpg";
            Uri httpURL = new Uri(url);
            ///HttpWebRequest类继承于WebRequest，并没有自己的构造函数，需通过WebRequest的Creat方法 建立，并进行强制的类型转换   
            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(httpURL);
            ///通过HttpWebRequest的GetResponse()方法建立HttpWebResponse,强制类型转换   
            HttpWebResponse httpResp = (HttpWebResponse)httpReq.GetResponse();
            ///GetResponseStream()方法获取HTTP响应的数据流,并尝试取得URL中所指定的网页内容   
            ///若成功取得网页的内容，则以System.IO.Stream形式返回，若失败则产生ProtoclViolationException错 误。在此正确的做法应将以下的代码放到一个try块中处理。这里简单处理   
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(httpResp.GetResponseStream());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            return response;
        }


        /// <summary>
        /// 查询工厂信息
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpPost]
        public List<MES_SY_GC> SelectGC(dynamic parms)
        {
            string token = parms.token;
            if (!rmsmodel.CRM_Login.ValidateToken(token))
            {

                return new List<MES_SY_GC>();
            }
            int staffid = Convert.ToInt32(parms.staffid);
            MES_SY_GC gcmodel = new MES_SY_GC();
            gcmodel.STAFFID = staffid;
            List<MES_SY_GC> nodes = mesmodel.SY_GC.SELECT_BY_ROLE(gcmodel).ToList();
            //.SY_GC.SELECT_BY_ROLE(gcmodel
            return nodes;
        }
        /// <summary>
        /// 查询工作中心信息
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpPost]
        public List<MES_SY_GZZX> SelectGZZX(dynamic parms)
        {
            string token = parms.token;
            if (!rmsmodel.CRM_Login.ValidateToken(token))
            {

                return new List<MES_SY_GZZX>();
            }
            MES_SY_GZZX gzzxmodel = new MES_SY_GZZX();
            gzzxmodel.GC = Convert.ToString(parms.gc);
            gzzxmodel.STAFFID = Convert.ToInt32(parms.staffid);
            //gzzxmodel.WLLB = Gzzxlb; 
            //gzzxmodel.WLLBNAME = Wllb;
            List<MES_SY_GZZX> nodes = mesmodel.SY_GZZX.SELECT_BY_ROLE(gzzxmodel).ToList();
            return nodes;
        }
        /// <summary>
        /// 查询设备号信息
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        [HttpPost]
        public List<MES_SY_GZZX_SBH> SelectSBH(dynamic parms)
        {
            string token = parms.token;
            if (!rmsmodel.CRM_Login.ValidateToken(token))
            {

                return new List<MES_SY_GZZX_SBH>();
            }


            MES_SY_GZZX_SBH model = new MES_SY_GZZX_SBH();
            //model.GZZXBH = Convert.ToString(parms.gzzxbh);
            //model.GC = Convert.ToString(parms.gc);
            //model.WLLB = Gzzxlb;
            //model.WLLBNAME = Wllb;
            model.SBBH = Convert.ToString(parms.sbbh);
            List<MES_SY_GZZX_SBH> nodes = mesmodel.SY_GZZX_SBH.SELECT(model).ToList();
            return nodes;
        }
        
        /// <summary>
        /// 扫描条码获取信息 暂时有 工单、EM_MANUAL tm 、EM_ManualBB tm   
        /// </summary>
        /// <param name="tm"></param>
        /// <param name="token"></param>
        /// <param name="staffid"></param>
        /// <returns></returns>
        [HttpPost]
        public EM_SY_MANUALPATH_SELECT ReadBYTM(dynamic parms)
        {

            string tm = parms.tm;
            string token = parms.token;
            string langums = parms.langums;
            int staffid = parms.staffid;
            EM_SY_MANUALPATH_SELECT node = new EM_SY_MANUALPATH_SELECT();
            if (rmsmodel.CRM_Login.ValidateToken(token))
            {
                node = rmsmodel.SY_MANUALPATH.ReadBYTM(tm, staffid);
                //node = rmsmodel.SY_MANUALPATH.ReadByTMLangu(tm, staffid, langums);
                node.URLLIST = new List<MES_RETURN>();
                if (node.MES_RETURN.TYPE.Equals("S"))
                {
                    for (int i = 0; i < node.EM_SY_MANUALPATH.Count; i++)
                    {
                        MES_RETURN mr = rmsmodel.FILE_PATH.GetURLByReadID(node.EM_SY_MANUALPATH[i].ID);
                        mr.TID = node.EM_SY_MANUALPATH[i].ID;
                        node.URLLIST.Add(mr);
                    }
                    return node;
                }
                else
                {
                    return node;
                }
            }
            else
            {
                MES_RETURN rst = new MES_RETURN();
                rst.TYPE = "E";
                rst.MESSAGE = "ptoken不正确，请重新登录！";
                node.MES_RETURN = rst;
                return node;
            }

        }
        [HttpPost]
        public EM_SY_MANUALPATH_SELECT ReadBYTMlangu(dynamic parms)
        {

            string tm = parms.tm;
            string token = parms.token;
            string langums = parms.langums;
            int staffid = parms.staffid;
            EM_SY_MANUALPATH_SELECT node = new EM_SY_MANUALPATH_SELECT();
            if (rmsmodel.CRM_Login.ValidateToken(token))
            {
                //node = rmsmodel.SY_MANUALPATH.ReadBYTM(tm, staffid);
                node = rmsmodel.SY_MANUALPATH.ReadByTMLangu(tm, staffid, langums);
                node.URLLIST = new List<MES_RETURN>();
                if (node.MES_RETURN.TYPE.Equals("S"))
                {
                    for (int i = 0; i < node.EM_SY_MANUALPATH.Count; i++)
                    {
                        MES_RETURN mr = rmsmodel.FILE_PATH.GetURLByReadID(node.EM_SY_MANUALPATH[i].ID);
                        mr.TID = node.EM_SY_MANUALPATH[i].ID;
                        mr.BH = node.EM_SY_MANUALPATH[i].CJRNAME;
                        mr.TMSX = node.EM_SY_MANUALPATH[i].BBID;
                        mr.GC = node.EM_SY_MANUALPATH[i].JLTIME;
                        node.URLLIST.Add(mr);
                    }
                    return node;
                }
                else
                {
                    return node;
                }
            }
            else
            {
                MES_RETURN rst = new MES_RETURN();
                rst.TYPE = "E";
                rst.MESSAGE = "ptoken不正确，请重新登录！";
                node.MES_RETURN = rst;
                return node;
            }

        }
        [HttpPost]
        public EM_SY_SBBHDEVICETYPESELECT ReadSopFronSBBH(dynamic parms)
        {
            string token = parms.token;
            string sbbh = parms.sbbh;
            string langu = parms.langu;
            EM_SY_SBBHDEVICETYPESELECT res = new EM_SY_SBBHDEVICETYPESELECT();
            if (!rmsmodel.CRM_Login.ValidateToken(token))
            {

                MES_RETURN rst = new MES_RETURN();
                rst.TYPE = "E";
                rst.MESSAGE = "ptoken不正确，请重新登录！";
                res.MES_RETURN = rst;
                return res;
            }
            return rmsmodel.SY_SBBHDEVICETYPE.ReadSopFronSBBH(sbbh, langu);
        }
        [HttpPost]
        public List<MES_RETURN> TEST(List<MES_RETURN> LIST)
        {
            return LIST;
        }
        [HttpPost]
        public object CreateDEVICEQRJL(dynamic dy)
        {
            string token = dy.token;
            string sbbh = dy.sbbh;
            string macaddress = dy.macaddress;
            int staffid = dy.staffid;
            if (!rmsmodel.CRM_Login.ValidateToken(token))
            {

                MES_RETURN rst = new MES_RETURN();
                rst.TYPE = "E";
                rst.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
            else
            {
                EM_SY_DEVICEQRJL node = new EM_SY_DEVICEQRJL();
                node.SBBH = sbbh;
                node.CJR = staffid;
                node.MACADRESS = macaddress;
                return rmsmodel.SY_DEVICEQRJL.Create(node);
            }
        }
        [HttpPost]
        public List<MES_SY_TYPEMXLIST> ReadMXBYTYPE(dynamic dy)
        {
            string token = dy.token;
            int typeid = dy.typeid;
            //if (!rmsmodel.CRM_Login.ValidateToken(token))
            //{

            //    MES_RETURN rst = new MES_RETURN();
            //    rst.TYPE = "E";
            //    rst.MESSAGE = "ptoken不正确，请重新登录！";
            //    return new List<MES_SY_TYPEMXLIST>();
            //}
            MES_SY_TYPEMX node = new MES_SY_TYPEMX();
            node.TYPEID = typeid;
            return mesmodel.SY_TYPEMX.SELECT(node).ToList();
        }
        [HttpPost]
        public object ReadDeviceInfoByPB(dynamic dy)
        {
            string token = dy.token;
            int staffid = dy.staffid;
            EM_SY_PB node = Newtonsoft.Json.JsonConvert.DeserializeObject<EM_SY_PB>(Convert.ToString(dy.node));
            if (!rmsmodel.CRM_Login.ValidateToken(token))
            {

                MES_RETURN rst = new MES_RETURN();
                rst.TYPE = "E";
                rst.MESSAGE = "ptoken不正确，请重新登录！";
                return new List<EM_SY_SBBINDPB>();
            }
            MES_SY_TYPEMX sjnode = new MES_SY_TYPEMX();
            sjnode.TYPEID = 27;
            sjnode.MXNAME = "预览操作规程定时";
            MES_SY_TYPEMXLIST sjres = mesmodel.SY_TYPEMX.SELECT(sjnode)[0];
            int sj = string.IsNullOrEmpty(sjres.MXNO) ? 60 :Convert.ToInt32(sjres.MXNO);

            List<EM_SY_PB> nodes = rmsmodel.SY_PB.Read(node).ToList();
            if (nodes.Count == 1)
            {
                int pbid = nodes[0].PBID;
                EM_SY_STAFFIDBINDPB pbstaffnode = new EM_SY_STAFFIDBINDPB();
                pbstaffnode.STAFFID = staffid;
                pbstaffnode.PBID = pbid;
                List<EM_SY_STAFFIDBINDPB> pbstaffres = rmsmodel.SY_STAFFIDBINDPB.Read(pbstaffnode).ToList();
                if (pbstaffres.Count == 0)
                {
                    return new List<EM_SY_SBBINDPB>();
                }
                EM_SY_SBBINDPB node_pb = new EM_SY_SBBINDPB();
                node_pb.PBID = pbid;
                List<EM_SY_SBBINDPB> res = rmsmodel.SY_SBBINDPB.Read(node_pb).ToList();
                for (int i = 0; i < res.Count; i++)
                {
                    EM_SY_DEVICEQRJL node_qrjl = new EM_SY_DEVICEQRJL();
                    node_qrjl.SBBH = res[i].SBBH;
                    node_qrjl.JSTIME = DateTime.Now.ToString("yyyy-MM-dd").ToString();
                    node_qrjl.KSTIME = DateTime.Now.ToString("yyyy-MM-dd").ToString();
                    res[i].SJ = sj;
                    if (rmsmodel.SY_DEVICEQRJL.Read(node_qrjl).Count > 0)
                    {
                        res[i].PBID = 1;
                    }
                    else
                    {
                        res[i].PBID = -1;
                    } 
                }
                return res;
            }
            else
            {
                return new List<EM_SY_SBBINDPB>();
            }
        }
       
        [HttpPost]
        public string TESTTWO(dynamic DD)
        {
            //List<MES_RETURN> nodes = DD.List;
            MES_RETURN[] nodes = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_RETURN[]>(Convert.ToString(DD.List));
            string token = DD.token;
            return token + nodes.Length;
        }
        [HttpPost]
        public MES_RETURN ModifyBindInfo(dynamic dy)
        {
            string token = dy.token;
            EM_SY_BINDINGDEVICE nodes = Newtonsoft.Json.JsonConvert.DeserializeObject<EM_SY_BINDINGDEVICE>(Convert.ToString(dy.node));

            if (!rmsmodel.CRM_Login.ValidateToken(token))
            {

                MES_RETURN rst = new MES_RETURN();
                rst.TYPE = "E";
                rst.MESSAGE = "ptoken不正确，请重新登录！";

                return rst;
            }
            MES_SY_GZZX_SBH node = new MES_SY_GZZX_SBH();
            node.SBBH = nodes.SBBH;
            List<MES_SY_GZZX_SBH> sbbhnodes = mesmodel.SY_GZZX_SBH.SELECT(node).ToList();
            if (sbbhnodes.Count == 1)
            {
                return rmsmodel.SY_BINDINGDEVICE.Create(nodes);
            }
            else
            {
                MES_RETURN rst = new MES_RETURN();
                rst.TYPE = "E";
                rst.MESSAGE = "不是有效的设备编号，请确认";

                return rst;
            }
            
        }
        [HttpPost]
        public List<EM_SY_BINDINGDEVICE> ReadBindInfoByMacadress(dynamic dy)
        {
            string token = dy.token;
            string macadress = dy.macadress;
            
            if (!rmsmodel.CRM_Login.ValidateToken(token))
            {

                return new List<EM_SY_BINDINGDEVICE>();
            }
            return rmsmodel.SY_BINDINGDEVICE.Read(macadress).ToList();
        }
        [HttpPost]
        public List<EM_SY_DEVICEQRJL> ReadDeviceQRJL(dynamic dy)
        {
            //EM_SY_DEVICEQRJL model, string ptoken
            string ptoken = dy.token;
            EM_SY_DEVICEQRJL node = dy.node;
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_DEVICEQRJL.Read(node).ToList();
            }
            else
            {
                List<EM_SY_DEVICEQRJL> rst = new List<EM_SY_DEVICEQRJL>();
                return rst;
            }
        }


        [HttpGet]       
        public HttpResponseMessage DownloadAPK(string SYID)
        {

            try
            {
                //E:\电子指导书\包装作业指导书\apk\app-release.apk
                MES_SY_XTBB model = new MES_SY_XTBB();
                model.SYID = SYID;
                model.ISZXBB = 1;
                string name = "";
                switch (SYID)
                {
                    case "2": name = "IDoc_setup.apk";
                        break;
                    default:
                        //throw new HttpResponseException(HttpStatusCode.NotFound);
                        break;
                }
                //ServiceModel serviceModel = new ServiceModel();
                MES_SY_XTBB_SELECT res = mesmodel.SY_XTBB.SELECT(model);
                string filename = res.MES_SY_XTBB[0].CFLJ;
                if (!File.Exists(filename))
                    throw new HttpResponseException(HttpStatusCode.NotFound);

                FileStream fileStream = new FileStream(filename, FileMode.Open,FileAccess.Read,FileShare.ReadWrite);
                HttpResponseMessage fullResponse = Request.CreateResponse(HttpStatusCode.OK);
                fullResponse.Content = new StreamContent(fileStream);
                MediaTypeHeaderValue _mediaType = MediaTypeHeaderValue.Parse("application/octet-stream");//指定文件类型
                ContentDispositionHeaderValue _disposition = ContentDispositionHeaderValue.Parse("attachment;filename=" + System.Web.HttpUtility.UrlEncode(name));//指定文件名称（编码中文）
                fullResponse.Content.Headers.ContentType = _mediaType;
                fullResponse.Content.Headers.ContentDisposition = _disposition;
                return fullResponse;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPost]
        public object StreamByUrl()
        {
            string url = "http://192.168.8.244/HR/upload/img/PIC/2019-6-10/PIC_03058.JPG";
            return GetInfo(url);
            //return webres.GetResponseStream();
        }
        [HttpPost]
        public string Print()
        {
            return publicmodel.PrintService.Print();
        }

        public string GetInfo(string url)
        {
            string strBuff = "";
            Uri httpURL = new Uri(url);
            ///HttpWebRequest类继承于WebRequest，并没有自己的构造函数，需通过WebRequest的Creat方法 建立，并进行强制的类型转换   
            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(httpURL);
            ///通过HttpWebRequest的GetResponse()方法建立HttpWebResponse,强制类型转换   
            HttpWebResponse httpResp = (HttpWebResponse)httpReq.GetResponse();
            ///GetResponseStream()方法获取HTTP响应的数据流,并尝试取得URL中所指定的网页内容   
            ///若成功取得网页的内容，则以System.IO.Stream形式返回，若失败则产生ProtoclViolationException错 误。在此正确的做法应将以下的代码放到一个try块中处理。这里简单处理   
            Stream respStream = httpResp.GetResponseStream();
            ///返回的内容是Stream形式的，所以可以利用StreamReader类获取GetResponseStream的内容，并以   
            //StreamReader类的Read方法依次读取网页源程序代码每一行的内容，直至行尾（读取的编码格式：UTF8）   
            StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
            strBuff = respStreamReader.ReadToEnd();
            return strBuff;
        }
       
       

    }
}

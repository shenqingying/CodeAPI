using Sonluk.DAFactory;
using Sonluk.Entities.EM;
using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.EM;
using Sonluk.IDataAccess.HR;
using Sonluk.IDataAccess.MES;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Sonluk.BusinessLogic.EM
{
    public class SY_DEVICE_CONTRACT
    {
        private static readonly ISY_DEVICE_CONTRACT _DataAccess = RMSDataAccess.CreateSY_DEVICE_CONTRACT();
        private static readonly ISY_GZZX_SBH mesdetaAccess = MESDataAccess.CreateSY_GZZX_SBH();
        private static readonly IRY_RYINFO IRY_RYINFOdata = HRDataAccess.CreateRY_RYINFO();
        
        public MES_RETURN Create(EM_SY_DEVICE_CONTRACT model)
        {
            return _DataAccess.Create(model);
        }

        public IList<EM_SY_DEVICE_CONTRACT> Read(EM_SY_DEVICE_CONTRACT model)
        {
            return _DataAccess.Read(model);
        }
        public MES_RETURN Delete(EM_SY_DEVICE_CONTRACT model)
        {
            return _DataAccess.Delete(model);
        }
        public List<HR_RY_RYINFO_LIST> SelectRYINFObySBH(string SBBH)
        {
            List<HR_RY_RYINFO_LIST> nodes = new List<HR_RY_RYINFO_LIST>();
            MES_RETURN mr = new MES_RETURN();
            MES_SY_GZZX_SBH model = new MES_SY_GZZX_SBH();
            model.SBBH = SBBH;
            IList<MES_SY_GZZX_SBH> sbhlist = mesdetaAccess.SELECT(model);
            if (sbhlist.Count == 0)
            {
                return nodes;
            }
            MES_SY_GZZX_SBH sbhnode = sbhlist[0];
            
            EM_SY_DEVICE_CONTRACT contactmodel = new EM_SY_DEVICE_CONTRACT();
            contactmodel.GC = sbhnode.GC;
            contactmodel.GZZXBH = sbhnode.GZZXBH;

            List<EM_SY_DEVICE_CONTRACT> contactArr = Read(contactmodel).ToList();
            if (contactArr.Count == 0)
            {
                return nodes;
            }
            string allryid = Convert.ToString(contactArr[0].RYID);
            for (int i = 1; i < contactArr.Count ; i++)
            {
                //HR_RY_RYINFO rymodel = new HR_RY_RYINFO();
                //rymodel.ALLRYID = contactArr[i].RYID;
                allryid += "," + Convert.ToString(contactArr[i].RYID);
                //HR_RY_RYINFO_SELECT node = IRY_RYINFOdata.SELECT(rymodel);
                //if (node.MES_RETURN.TYPE.Equals("S"))
                //{
                //    nodes.AddRange(node.HR_RY_RYINFO_LIST);
                //}

            }
           
            HR_RY_RYINFO rymodel = new HR_RY_RYINFO();
            rymodel.ALLRYID = allryid;
            nodes = IRY_RYINFOdata.SELECT(rymodel).HR_RY_RYINFO_LIST;
            //return nodes;
           
            for (int i = 0; i < nodes.Count; i++)
            {
                string url = nodes[i].IMAGEURL;
                string prefix = AppConfig.Settings("RyImageAdress");
                if (!string.IsNullOrEmpty(url))
                {
                    string[] urlArr = url.Split('\\');
                    for (int j = 2; j < urlArr.Length; j++)
                    {

                        prefix = prefix + "/" +  urlArr[j];
                        //WebRequest webreq = WebRequest.Create(lasturl);
                        //WebResponse webres = webreq.GetResponse();
                        //nodes[i].IMAGEFILE = GetInfo(lasturl);
                        
                    }
                    nodes[i].IMAGEFILE = prefix;//url
                    //nodes[i].IMAGEFILE = GetInfo(prefix);
                }
                
            }

            return nodes;



        }
        /// 将 Stream 转成 byte[]

        public byte[] StreamToBytes(Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // 设置当前流的位置为流的开始 
            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }
        private string GetInfo(string url)
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
            //return StreamToBytes(respStream);
            //返回的内容是Stream形式的，所以可以利用StreamReader类获取GetResponseStream的内容，并以   
            //StreamReader类的Read方法依次读取网页源程序代码每一行的内容，直至行尾（读取的编码格式：UTF8）   
            StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
            strBuff = respStreamReader.ReadToEnd();
            return strBuff;
        }


        
    }
}

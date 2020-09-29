using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using Sonluk.BusinessLogic.Helper;
using Sonluk.DAFactory;
using Sonluk.Entities.API;
using Sonluk.Entities.CRM;
using Sonluk.Entities.System;
using Sonluk.IDataAccess.CRM;
using Sonluk.Utility;
using Sonluk.Utility.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;

namespace Sonluk.BusinessLogic.CRM
{
    public enum ExcelType
    {
        QJ = 1
    }
    public class CRM_OA
    {

        private static readonly ICRM_OA _DataAccess = RMSDataAccess.CreateCRM_OA();
        private static readonly XMLHelper xmlHelper = new XMLHelper();
        private const string Defineurl = "http://192.168.0.168:80/seeyon/uploadService.do?method=processUploadService&senderLoginName=OA&token=";
        /// <summary>
        /// 得到OA tokenid
        /// </summary>
        /// <returns></returns>
        public string GetAuthority()
        {
            return _DataAccess.GetAuthority("service-admin", "123456");
        }
        /// <summary>
        /// OA流程统一入口 ********************************************************************************
        /// </summary>
        /// <param name="basic"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageInfo Launch(CRM_OA_BASIC basic, object model)
        {
            if (model is CRM_OA_QJList)
            {
                return Launch_QJ(basic, (CRM_OA_QJList)model);
            }
            else if (model is CRM_OA_CC)
            {
                return Launch_CC(basic, (CRM_OA_CC)model);
            }
            else if (model is CRM_OA_KH)
            {
                return Launch_KH(basic, (CRM_OA_KH)model);
            }
            else if (model is CRM_OA_YCKQSM)
            {
                return Launch_YCKQSM(basic, (CRM_OA_YCKQSM)model);
            }
            else if (model is CRM_OA_ZDF)
            {
                return Launch_ZDF(basic, (CRM_OA_ZDF)model);
            }
            else if (model is CRM_OA_LKAYEAR)
            {
                return Launch_LKAYEAR(basic, (CRM_OA_LKAYEAR)model);
            }
            else if (model is CRM_OA_HaiBao)
            {
                return Launch_HaiBao(basic, (CRM_OA_HaiBao)model);
            }
            else if (model is CRM_OA_TSCL)
            {
                return Launch_TSCL(basic, (CRM_OA_TSCL)model);
            }
            else if (model is CRM_OA_ZZF)
            {
                return Launch_ZZF(basic, (CRM_OA_ZZF)model);
            }
            else if (model is CRM_OA_KHTS)
            {
                return Launch_KHTS(basic, (CRM_OA_KHTS)model);
            }
            else if (model is CRM_OA_MDBS)
            {
                return Launch_MDBS(basic, (CRM_OA_MDBS)model);
            }
            else if (model is CRM_OA_KAYEAR)
            {
                return Launch_KAYEAR(basic, (CRM_OA_KAYEAR)model);
            }
            else if (model is CRM_OA_KADT)
            {
                return Launch_KADT(basic, (CRM_OA_KADT)model);
            }
            else if (model is CRM_OA_KATSCL)
            {
                return Launch_KATSCL(basic, (CRM_OA_KATSCL)model);
            }
            else if (model is CRM_OA_KACXY)
            {
                return Launch_KACXY(basic, (CRM_OA_KACXY)model);
            }
            else if (model is CRM_OA_CXHD)
            {
                return Launch_CXHD(basic, (CRM_OA_CXHD)model);
            }
            return new MessageInfo();
        }
        //public MessageInfo Launch_Test(CRM_OA_BASIC basic, object model)
        //{
        //    if (model is CRM_OA_QJList)
        //    {
        //        return Launch_QJ_Test(basic, (CRM_OA_QJList)model);
        //    }
        //    else if (model is CRM_OA_CC)
        //    {
        //        return Launch_CC(basic, (CRM_OA_CC)model);
        //    }
        //    else if (model is CRM_OA_KH)
        //    {
        //        return Launch_KH(basic, (CRM_OA_KH)model);
        //    }
        //    else if (model is CRM_OA_YCKQSM)
        //    {
        //        return Launch_YCKQSM(basic, (CRM_OA_YCKQSM)model);
        //    }
        //    else if (model is CRM_OA_ZDF)
        //    {
        //        return Launch_ZDF(basic, (CRM_OA_ZDF)model);
        //    }
        //    return new MessageInfo();
        //}

        /// <summary>
        /// 得到OA流程状态
        /// </summary>
        /// <param name="ID">OA ID对应的是col_summary表的id</param>
        /// <returns></returns>
        public int GetFlowState(string ID)
        {
            return _DataAccess.GetFlowState(GetAuthority(), ID);
        }



        #region 待办跟踪OA相关信息

        /// <summary>
        /// 代办事项具体返回一个XML结构体
        /// </summary>
        /// <param name="ticketId"></param>
        /// <param name="firstNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public IList<CRM_OA_INFO> Pending(string ticketId, int firstNum, int pageSize, string address)
        {
            OA_SSO sso = new OA_SSO();
            sso.Login(ticketId);
            IList<CRM_OA_INFO> node = new List<CRM_OA_INFO>();
            string xml = _DataAccess.Pending(GetAuthority(), ticketId, firstNum, pageSize);
            if (!xml.Equals(""))
            {
                return ReadDataToTrack(xml, address);
            }
            return node;
        }

        /// <summary>
        /// 跟踪事项具体返回一个XML结构体
        /// </summary>
        /// <param name="ticketId"></param>
        /// <param name="firstNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public IList<CRM_OA_INFO> Track(string ticketId, int firstNum, int pageSize, string address)
        {
            OA_SSO sso = new OA_SSO();
            sso.Login(ticketId);
            IList<CRM_OA_INFO> node = new List<CRM_OA_INFO>();
            string xml = _DataAccess.Track(GetAuthority(), ticketId, firstNum, pageSize);
            if (!xml.Equals(""))
            {
                return ReadDataToTrack(xml, address);
            }
            return node;

            //return xml;
        }

        /// <summary>
        /// 帐号退出,暂时没用,得到pengding和track的数据必须先登录帐号才可以发起查看具体的内容
        /// </summary>
        /// <param name="ticketID"></param>
        /// <returns></returns>
        public Boolean Logout(string ticketID)
        {
            OA_SSO sso = new OA_SSO();
            return sso.Login(ticketID);

        }
        /// <summary>
        /// 代办和跟踪返回的xml解析成结构体
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="address">传入客户端的ip地址,如果IP地址为外网,使用映射的域名</param>
        /// <returns></returns>
        private IList<CRM_OA_INFO> ReadDataToTrack(string xml, string address)
        {
            IList<CRM_OA_INFO> nodes = new List<CRM_OA_INFO>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            XmlNode root = xmlDoc.SelectSingleNode("/B/P/L");
            XmlNodeList nodeList = root.ChildNodes;
            string oaAddress = AppConfig.Settings("OA");
            string oaInternetAddress = AppConfig.Settings("OA.Internet");
            Address addressBL = new Address();
            int addressType = addressBL.Type(address);       //判断内网外网


            foreach (XmlNode xmlNode in nodeList)
            {
                CRM_OA_INFO node = new CRM_OA_INFO();
                node.SUBJECT = xmlNode.ChildNodes[0].InnerText;//SUBJECT

                node.ADDRESS = xmlNode.ChildNodes[1].InnerText;//ADD

                if (addressType == 2)
                {
                    node.ADDRESS = node.ADDRESS.Replace(oaAddress, oaInternetAddress);
                }



                node.SENDNAME = xmlNode.ChildNodes[3].InnerText;
                nodes.Add(node);
            }
            return nodes;
        }
        #endregion

        #region EXCEL赋值
        /// <summary>
        /// 得到excel对应的路径
        /// </summary>
        /// <param name="type"></param>
        /// <param name="QJ_model"></param>
        /// <returns></returns>
        private string Excel_Path(ExcelType type, CRM_OA_QJList QJ_model)
        {
            string templetPath = AppDomain.CurrentDomain.BaseDirectory;
            string templetPath1 = "";

            HSSFWorkbook hssfworkbook;
            switch (type)
            {
                case ExcelType.QJ:
                    templetPath = templetPath + "Templet\\book10.xls";
                    break;
                default:
                    break;
            }

            using (FileStream file = new FileStream(templetPath, FileMode.Open, FileAccess.Read))
            {
                //将文件流中模板加载到工作簿对象中
                hssfworkbook = new HSSFWorkbook(file);
            }

            if (type == ExcelType.QJ)
            {
                ISheet sheet1 = hssfworkbook.GetSheet("Sheet1");

                NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(1);
                row1.CreateCell(0).SetCellValue("工号");
                row1.CreateCell(1).SetCellValue(QJ_model.STAFFNO);
                row1.CreateCell(2).SetCellValue("姓名");
                row1.CreateCell(3).SetCellValue(QJ_model.STAFFNAME);
                row1.CreateCell(4).SetCellValue("性别");
                row1.CreateCell(5).SetCellValue(QJ_model.SEX);
                row1.CreateCell(6).SetCellValue("部门");
                row1.CreateCell(7).SetCellValue(QJ_model.DEP);

                NPOI.SS.UserModel.IRow row2 = sheet1.CreateRow(2);
                row2.CreateCell(0).SetCellValue("请假类型");
                row2.CreateCell(1).SetCellValue(QJ_model.QJLB);
                row2.CreateCell(2).SetCellValue("去往何处");
                row2.CreateCell(3).SetCellValue(QJ_model.GO);
                NPOI.SS.UserModel.IRow row3 = sheet1.CreateRow(3);
                row3.CreateCell(0).SetCellValue("开始日期");
                row3.CreateCell(1).SetCellValue(QJ_model.BEGINDATE);
                row3.CreateCell(2).SetCellValue("时间");
                row3.CreateCell(3).SetCellValue(QJ_model.BEGINTIME);
                row3.CreateCell(4).SetCellValue("结束日期");
                row3.CreateCell(5).SetCellValue(QJ_model.ENDDATE);
                row3.CreateCell(6).SetCellValue("时间");
                row3.CreateCell(7).SetCellValue(QJ_model.ENDTIME);
                row3.CreateCell(8).SetCellValue("共计天数");
                row3.CreateCell(9).SetCellValue(QJ_model.DAYS);
                NPOI.SS.UserModel.IRow row4 = sheet1.CreateRow(4);
                row4.CreateCell(0).SetCellValue("备注");
                row4.CreateCell(1).SetCellValue(QJ_model.BZ);






                //return templetPath;
                //sheet1.GetRow(1).GetCell(1).SetCellValue("");
                //sheet1.GetRow(1).GetCell(3).SetCellValue("");
                //sheet1.GetRow(1).GetCell(5).SetCellValue("");
                //sheet1.GetRow(1).GetCell(7).SetCellValue("");
                //sheet1.GetRow(2).GetCell(1).SetCellValue("");
                //sheet1.GetRow(2).GetCell(3).SetCellValue("");
                //sheet1.GetRow(3).GetCell(1).SetCellValue("");
                //sheet1.GetRow(3).GetCell(3).SetCellValue("");
                //sheet1.GetRow(3).GetCell(5).SetCellValue("");
                //sheet1.GetRow(4).GetCell(1).SetCellValue("");


                //sheet1.GetRow(1).GetCell(1).SetCellValue(QJ_model.STAFFNO);
                //sheet1.GetRow(1).GetCell(3).SetCellValue(QJ_model.STAFFNAME);
                //sheet1.GetRow(1).GetCell(5).SetCellValue(QJ_model.SEX);
                //sheet1.GetRow(1).GetCell(7).SetCellValue(QJ_model.DEP);
                //sheet1.GetRow(2).GetCell(1).SetCellValue(QJ_model.QJLB);
                //sheet1.GetRow(2).GetCell(3).SetCellValue(QJ_model.GO);
                //sheet1.GetRow(3).GetCell(1).SetCellValue(QJ_model.BEGINDATE);
                //sheet1.GetRow(3).GetCell(3).SetCellValue(QJ_model.ENDDATE);
                //sheet1.GetRow(3).GetCell(5).SetCellValue(QJ_model.DAYS);
                //sheet1.GetRow(4).GetCell(1).SetCellValue(QJ_model.BZ);

                //FileStream file1 = new FileStream(templetPath, FileMode.OpenOrCreate);
                templetPath1 = AppDomain.CurrentDomain.BaseDirectory;


                string fi = DateTime.Now.ToString("yyyyMMddhhmmss");
                fi = fi + QJ_model.STAFFNAME + ".xls";
                templetPath1 = templetPath1 + "Templet\\请假附件.xls";
                //templetPath1 = templetPath1 + "/Templet/" + fi + "";
                FileStream file1 = new FileStream(templetPath1, FileMode.OpenOrCreate);

                hssfworkbook.Write(file1);

                file1.Close();

            }





            return templetPath1;
        }
        #endregion

        #region 通过HTTP上传附件
        /// <summary>
        /// Http上传文件
        /// </summary>
        public string HttpUploadFile(string url, string path, string fileName)
        {
            string token = GetAuthority();
            url = Defineurl + token;
            //string templetPath = AppDomain.CurrentDomain.BaseDirectory;
            //return templetPath;
            // 设置参数
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            CookieContainer cookieContainer = new CookieContainer();
            request.CookieContainer = cookieContainer;
            request.AllowAutoRedirect = true;
            request.Method = "POST";
            string boundary = DateTime.Now.Ticks.ToString("X"); // 随机分隔线
            request.ContentType = "multipart/form-data;charset=utf-8;boundary=" + boundary;
            byte[] itemBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
            byte[] endBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");
            int pos = path.LastIndexOf("\\");
            //string fileName = path.Substring(pos + 1);
            fileName = fileName + path.Substring(pos + 1);

            //请求头部信息 
            StringBuilder sbHeader = new StringBuilder(string.Format("Content-Disposition:form-data;name=\"file\";filename=\"{0}\"\r\nContent-Type:application/octet-stream\r\n\r\n", fileName));
            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(sbHeader.ToString());
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] bArr = new byte[fs.Length];
            fs.Read(bArr, 0, bArr.Length);
            fs.Close();
            Stream postStream = request.GetRequestStream();
            postStream.Write(itemBoundaryBytes, 0, itemBoundaryBytes.Length);
            postStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
            postStream.Write(bArr, 0, bArr.Length);
            postStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
            postStream.Close();
            //发送请求并获取相应回应数据
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //直到request.GetResponse()程序才开始向目标网页发送Post请求
            Stream instream = response.GetResponseStream();
            StreamReader sr = new StreamReader(instream, Encoding.UTF8);
            //返回结果网页（html）代码
            string content = sr.ReadToEnd();
            return content;
        }
        #endregion

        #region   所有给OA的XML赋值
        public string sendoa()
        {
            string xml = "";
            xml = xml + @"<formExport version=""2.0"">";
            xml = xml + @"<summary id="""" name=""formmain_1412""/>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0001"" type=""0"" name=""新增公司名称"" length=""255""/>";
            xml = xml + @"<column id=""field0002"" type=""0"" name=""开票性质"" length=""255""/>";
            xml = xml + @"<column id=""field0003"" type=""0"" name=""公司联系人"" length=""255""/>";
            xml = xml + @"<column id=""field0004"" type=""0"" name=""公司联系电话"" length=""255""/>";
            xml = xml + @"<column id=""field0005"" type=""0"" name=""开票地址"" length=""255""/>";
            xml = xml + @"<column id=""field0006"" type=""0"" name=""公司法人"" length=""255""/>";
            xml = xml + @"<column id=""field0007"" type=""0"" name=""公司联系人与法人关系"" length=""255""/>";
            xml = xml + @"<column id=""field0008"" type=""0"" name=""开票电话"" length=""255""/>";
            xml = xml + @"<column id=""field0009"" type=""0"" name=""快递寄送地址"" length=""255""/>";
            xml = xml + @"<column id=""field0010"" type=""0"" name=""联系人-电话"" length=""255""/>";
            xml = xml + @"<column id=""field0011"" type=""0"" name=""纳税人识别号"" length=""255""/>";
            xml = xml + @"<column id=""field0012"" type=""0"" name=""合同销售任务"" length=""255""/>";
            xml = xml + @"<column id=""field0013"" type=""0"" name=""合同碱性销售任务"" length=""255""/>";
            xml = xml + @"<column id=""field0014"" type=""0"" name=""银行账号"" length=""255""/>";
            xml = xml + @"<column id=""field0015"" type=""0"" name=""销售数据说明"" length=""255""/>";//
            xml = xml + @"<column id=""field0016"" type=""0"" name=""是否出厂价"" length=""255""/>";
            xml = xml + @"<column id=""field0017"" type=""0"" name=""银行名称"" length=""255""/>";
            xml = xml + @"<column id=""field0018"" type=""0"" name=""管辖区域"" length=""255""/>";
            xml = xml + @"<column id=""field0019"" type=""0"" name=""客户收货地址"" length=""255""/>";
            xml = xml + @"<column id=""field0020"" type=""0"" name=""联系人及电话"" length=""255""/>";
            xml = xml + @"<column id=""field0021"" type=""0"" name=""特殊情况说明"" length=""255""/>";
            xml = xml + @"<column id=""field0022"" type=""0"" name=""批发"" length=""5""/>";
            xml = xml + @"<column id=""field0023"" type=""0"" name=""LKA"" length=""5""/>";
            xml = xml + @"<column id=""field0024"" type=""0"" name=""直销"" length=""5""/>";
            xml = xml + @"<column id=""field0025"" type=""0"" name=""其他"" length=""255""/>";
            xml = xml + @"<column id=""field0029"" type=""0"" name=""说明"" length=""255""/>";
            xml = xml + @"<column id=""field0030"" type=""0"" name=""负责业务员"" length=""255""/>";
            xml = xml + @"<column id=""field0031"" type=""0"" name=""管辖区域2"" length=""255""/>";
            xml = xml + @"<column id=""field0032"" type=""0"" name=""分管领导意见"" length=""4000""/>";
            xml = xml + @"<column id=""field0033"" type=""0"" name=""销售总监意见"" length=""4000""/>";
            xml = xml + @"<column id=""field0028"" type=""0"" name=""域28-f"" length=""255""/>";
            xml = xml + @"<column id=""field0027"" type=""0"" name=""渠道不同-f"" length=""5""/>";
            xml = xml + @"<column id=""field0026"" type=""0"" name=""区域冲突-f"" length=""5""/>";
            xml = xml + @"<column id=""field0034"" type=""0"" name=""是否"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            xml = xml + @"<column name=""新增公司名称"">";
            xml = xml + @"<value><![CDATA[""1""]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""开票性质"">";
            xml = xml + @"<value><![CDATA[""2""]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""公司联系人"">";
            xml = xml + @"<value><![CDATA[""公司联系人test""]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""公司联系电话"">";
            xml = xml + @"<value><![CDATA[""公司联系电话test""]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""开票地址"">";
            xml = xml + @"<value><![CDATA[""开票地址test""]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""公司法人"">";
            xml = xml + @"<value><![CDATA[""公司法人test""]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""公司联系人与法人关系"">";
            xml = xml + @"<value><![CDATA[""公司联系人与法人关系test""]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""开票电话"">";
            xml = xml + @"<value><![CDATA[""开票电话test""]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""快递寄送地址"">";
            xml = xml + @"<value><![CDATA[""快递寄送地址test""]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""联系人-电话"">";
            xml = xml + @"<value><![CDATA[""联系人-电话test""]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""纳税人识别号"">";
            xml = xml + @"<value><![CDATA[""纳税人识别号test""]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""合同销售任务"">";
            xml = xml + @"<value><![CDATA[""合同销售任务test""]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""合同碱性销售任务"">";
            xml = xml + @"<value><![CDATA[""合同碱性销售任务test""]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""银行账号"">";
            xml = xml + @"<value><![CDATA[""银行账号test""]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""销售数据说明"">";
            xml = xml + @"<value><![CDATA[""销售数据说明test""]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""是否出厂价"">";
            xml = xml + @"<value><![CDATA[""是否出厂价test""]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""银行名称"">";
            xml = xml + @"<value><![CDATA[""银行名称test""]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""管辖区域"">";
            xml = xml + @"<value><![CDATA[""管辖区域test""]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""客户收货地址"">";
            xml = xml + @"<value><![CDATA[""客户收货地址test""]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""联系人及电话"">";
            xml = xml + @"<value><![CDATA[""联系人及电话test""]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""特殊情况说明"">";
            xml = xml + @"<value><![CDATA[""特殊情况说明test""]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""批发"">";
            xml = xml + @"<value><![CDATA[1]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""LKA"">";
            xml = xml + @"<value><![CDATA[0]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""直销"">";
            xml = xml + @"<value><![CDATA[1]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""其他"">";
            xml = xml + @"<value><![CDATA[""其他test""]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""说明"">";
            xml = xml + @"<value><![CDATA[""说明test""]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""负责业务员"">";
            xml = xml + @"<value><![CDATA[""负责业务员test""]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""管辖区域2"">";
            xml = xml + @"<value><![CDATA[""管辖区域2test""]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""分管领导意见"">";
            xml = xml + @"<value><![CDATA[""分管领导意见test""]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""销售总监意见"">";
            xml = xml + @"<value><![CDATA[""销售总监意见test""]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""域28-f"">";
            xml = xml + @"<value><![CDATA[""域28-ftest""]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""渠道不同-f"">";
            xml = xml + @"<value><![CDATA[""渠""]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""区域冲突-f"">";
            xml = xml + @"<value><![CDATA[""区""]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""是否"">";
            xml = xml + @"<value><![CDATA[8066609701022222490]]></value>";//8066609701022222490是  5974567596037984157否
            xml = xml + @"</column>";
            xml = xml + @"</values>";
            xml = xml + @"<subForms/>";
            xml = xml + @"</formExport>";

            return xml;
        }

        public string XMLData_QJ(string QJLB, string days)
        {
            string xml = "";
            xml = xml + @"<formExport version=""2.0"">";
            xml = xml + @"<summary id="""" name=""formmain_1412""/>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0001"" type=""0"" name=""请假类别"" length=""255""/>";
            xml = xml + @"<column id=""field0002"" type=""4"" name=""天数"" length=""20""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            xml = xml + @"<column name=""请假类别"">";
            xml = xml + @"<value><![CDATA[" + QJLB + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""天数"">";
            xml = xml + @"<value><![CDATA[" + days + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"</values>";
            xml = xml + @"<subForms/>";
            xml = xml + @"</formExport>";

            return xml;
        }

        public string XML_QJ(CRM_OA_QJList model)
        {
            string kaishi = model.BEGINDATE + " " + model.BEGINTIME;
            string jieshu = model.ENDDATE + " " + model.ENDTIME;
            string xml = "";
            xml = xml + @" <formExport version=""2.0"">";
            xml = xml + @" <summary id=""-8463110852357109001"" name=""formmain_1827""/>";
            xml = xml + @" <definitions>";
            xml = xml + @" <column id=""field0001"" type=""0"" name=""工号1"" length=""255""/>";
            xml = xml + @" <column id=""field0002"" type=""0"" name=""姓名1"" length=""255""/>";
            xml = xml + @" <column id=""field0003"" type=""0"" name=""性别1"" length=""255""/>";
            xml = xml + @" <column id=""field0004"" type=""0"" name=""工作部门1"" length=""255""/>";
            xml = xml + @" <column id=""field0005"" type=""0"" name=""请假类别1"" length=""255""/>";
            xml = xml + @" <column id=""field0006"" type=""0"" name=""往何处去1"" length=""255""/>";
            xml = xml + @" <column id=""field0007"" type=""0"" name=""请假日期起始1"" length=""255""/>";
            xml = xml + @" <column id=""field0008"" type=""0"" name=""请假日期截止1"" length=""255""/>";
            xml = xml + @" <column id=""field0009"" type=""0"" name=""共计天1"" length=""255""/>";
            xml = xml + @" <column id=""field0010"" type=""0"" name=""日期1"" length=""255""/>";
            xml = xml + @" <column id=""field0011"" type=""0"" name=""工号2"" length=""255""/>";
            xml = xml + @" <column id=""field0012"" type=""0"" name=""姓名2"" length=""255""/>";
            xml = xml + @" <column id=""field0013"" type=""0"" name=""性别2"" length=""255""/>";
            xml = xml + @" <column id=""field0014"" type=""0"" name=""工作部门2"" length=""255""/>";
            xml = xml + @" <column id=""field0015"" type=""0"" name=""请假类别2"" length=""255""/>";
            xml = xml + @" <column id=""field0016"" type=""0"" name=""往何处去2"" length=""255""/>";
            xml = xml + @" <column id=""field0017"" type=""0"" name=""请假日期起始2"" length=""255""/>";
            xml = xml + @" <column id=""field0018"" type=""0"" name=""请假日期截止2"" length=""255""/>";
            xml = xml + @" <column id=""field0019"" type=""4"" name=""共计天2"" length=""21""/>";
            xml = xml + @" <column id=""field0020"" type=""0"" name=""组长2"" length=""255""/>";
            xml = xml + @" <column id=""field0021"" type=""0"" name=""部门领导2"" length=""255""/>";
            xml = xml + @" <column id=""field0022"" type=""0"" name=""主管领导2"" length=""255""/>";
            xml = xml + @" <column id=""field0023"" type=""0"" name=""总经办2"" length=""255""/>";
            xml = xml + @" <column id=""field0024"" type=""0"" name=""销假日期2"" length=""255""/>";
            xml = xml + @" <column id=""field0025"" type=""0"" name=""销假组长2"" length=""255""/>";
            xml = xml + @" <column id=""field0026"" type=""0"" name=""日期2"" length=""255""/>";
            xml = xml + @" <column id=""field0027"" type=""0"" name=""请假人2"" length=""255""/>";
            xml = xml + @" <column id=""field0028"" type=""0"" name=""是否"" length=""255""/>";
            xml = xml + @" <column id=""field0029"" type=""0"" name=""流水号"" length=""255""/>";
            xml = xml + @" <column id=""field0030"" type=""0"" name=""数据来源"" length=""255""/>";
            xml = xml + @" </definitions>";
            xml = xml + @" <values>";
            xml = xml + @" <column name=""工号1"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""姓名1"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""性别1"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""工作部门1"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""请假类别1"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""往何处去1"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""请假日期起始1"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""请假日期截止1"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""共计天1"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""日期1"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""工号2"">";
            xml = xml + @" <value><![CDATA[" + model.STAFFNO + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""姓名2"">";
            xml = xml + @" <value><![CDATA[" + model.STAFFNAME + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""性别2"">";
            xml = xml + @" <value><![CDATA[" + model.SEX + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""工作部门2"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""请假类别2"">";
            xml = xml + @" <value><![CDATA[" + model.QJLB + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""往何处去2"">";
            xml = xml + @" <value><![CDATA[" + model.GO + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""请假日期起始2"">";
            xml = xml + @" <value><![CDATA[" + kaishi + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""请假日期截止2"">";
            xml = xml + @" <value><![CDATA[" + jieshu + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""共计天2"">";
            xml = xml + @" <value><![CDATA[" + model.DAYS + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""组长2"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""部门领导2"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""主管领导2"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""总经办2"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""销假日期2"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""销假组长2"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""日期2"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""请假人2"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""是否"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""流水号"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""数据来源"">";
            xml = xml + @" <value><![CDATA[CRM]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" </values>";
            xml = xml + @" <subForms/>";
            xml = xml + @" </formExport>";

            return xml;
        }

        public string XML_QJ_Test(CRM_OA_QJList model)
        {
            string kaishi = model.BEGINDATE + " " + model.BEGINTIME;
            string jieshu = model.ENDDATE + " " + model.ENDTIME;
            string xml = "";
            xml = xml + @" <formExport version=""2.0"">";
            xml = xml + @" <summary id=""-8463110852357109001"" name=""formmain_2132""/>";
            xml = xml + @" <definitions>";
            xml = xml + @" <column id=""field0001"" type=""0"" name=""工号1"" length=""255""/>";
            xml = xml + @" <column id=""field0002"" type=""0"" name=""姓名1"" length=""255""/>";
            xml = xml + @" <column id=""field0003"" type=""0"" name=""性别1"" length=""255""/>";
            xml = xml + @" <column id=""field0004"" type=""0"" name=""工作部门1"" length=""255""/>";
            xml = xml + @" <column id=""field0005"" type=""0"" name=""请假类别1"" length=""255""/>";
            xml = xml + @" <column id=""field0006"" type=""0"" name=""往何处去1"" length=""255""/>";
            xml = xml + @" <column id=""field0007"" type=""0"" name=""请假日期起始1"" length=""255""/>";
            xml = xml + @" <column id=""field0008"" type=""0"" name=""请假日期截止1"" length=""255""/>";
            xml = xml + @" <column id=""field0009"" type=""0"" name=""共计天1"" length=""255""/>";
            xml = xml + @" <column id=""field0010"" type=""0"" name=""日期1"" length=""255""/>";
            xml = xml + @" <column id=""field0011"" type=""0"" name=""工号2"" length=""255""/>";
            xml = xml + @" <column id=""field0012"" type=""0"" name=""姓名2"" length=""255""/>";
            xml = xml + @" <column id=""field0013"" type=""0"" name=""性别2"" length=""255""/>";
            xml = xml + @" <column id=""field0014"" type=""0"" name=""工作部门2"" length=""255""/>";
            xml = xml + @" <column id=""field0015"" type=""0"" name=""请假类别2"" length=""255""/>";
            xml = xml + @" <column id=""field0016"" type=""0"" name=""往何处去2"" length=""255""/>";
            xml = xml + @" <column id=""field0017"" type=""0"" name=""请假日期起始2"" length=""255""/>";
            xml = xml + @" <column id=""field0018"" type=""0"" name=""请假日期截止2"" length=""255""/>";
            xml = xml + @" <column id=""field0019"" type=""4"" name=""共计天2"" length=""21""/>";
            xml = xml + @" <column id=""field0020"" type=""0"" name=""组长2"" length=""255""/>";
            xml = xml + @" <column id=""field0021"" type=""0"" name=""部门领导2"" length=""255""/>";
            xml = xml + @" <column id=""field0022"" type=""0"" name=""主管领导2"" length=""255""/>";
            xml = xml + @" <column id=""field0023"" type=""0"" name=""总经办2"" length=""255""/>";
            xml = xml + @" <column id=""field0024"" type=""0"" name=""销假日期2"" length=""255""/>";
            xml = xml + @" <column id=""field0025"" type=""0"" name=""销假组长2"" length=""255""/>";
            xml = xml + @" <column id=""field0026"" type=""0"" name=""日期2"" length=""255""/>";
            xml = xml + @" <column id=""field0027"" type=""0"" name=""请假人2"" length=""255""/>";
            xml = xml + @" <column id=""field0028"" type=""0"" name=""是否"" length=""255""/>";
            xml = xml + @" <column id=""field0029"" type=""0"" name=""流水号"" length=""255""/>";
            xml = xml + @" <column id=""field0030"" type=""0"" name=""数据来源"" length=""255""/>";
            xml = xml + @" </definitions>";
            xml = xml + @" <values>";
            xml = xml + @" <column name=""工号1"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""姓名1"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""性别1"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""工作部门1"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""请假类别1"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""往何处去1"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""请假日期起始1"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""请假日期截止1"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""共计天1"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""日期1"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""工号2"">";
            xml = xml + @" <value><![CDATA[" + model.STAFFNO + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""姓名2"">";
            xml = xml + @" <value><![CDATA[" + model.STAFFNAME + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""性别2"">";
            xml = xml + @" <value><![CDATA[" + model.SEX + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""工作部门2"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""请假类别2"">";
            xml = xml + @" <value><![CDATA[" + model.QJLB + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""往何处去2"">";
            xml = xml + @" <value><![CDATA[" + model.GO + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""请假日期起始2"">";
            xml = xml + @" <value><![CDATA[" + kaishi + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""请假日期截止2"">";
            xml = xml + @" <value><![CDATA[" + jieshu + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""共计天2"">";
            xml = xml + @" <value><![CDATA[" + model.DAYS + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""组长2"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""部门领导2"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""主管领导2"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""总经办2"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""销假日期2"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""销假组长2"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""日期2"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""请假人2"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""是否"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""流水号"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""数据来源"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" </values>";
            xml = xml + @" <subForms/>";
            xml = xml + @" </formExport>";

            return xml;
        }

        public string XML_CC(CRM_OA_CC model)
        {
            //1843     1846
            string xml = "";
            xml = xml + @" <formExport version=""2.0"">";
            xml = xml + @"<summary id=""2936157623508880843"" name=""formmain_1843""/>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0001"" type=""0"" name=""申请日期"" length=""255""/>";
            xml = xml + @"<column id=""field0002"" type=""0"" name=""出差人"" length=""255""/>";
            xml = xml + @"<column id=""field0003"" type=""0"" name=""所在部门"" length=""255""/>";
            xml = xml + @"<column id=""field0004"" type=""0"" name=""出差地点"" length=""255""/>";
            xml = xml + @"<column id=""field0005"" type=""0"" name=""开始时间"" length=""255""/>";
            xml = xml + @"<column id=""field0006"" type=""0"" name=""结束时间"" length=""255""/>";
            xml = xml + @"<column id=""field0007"" type=""0"" name=""出行方式"" length=""255""/>";
            xml = xml + @"<column id=""field0008"" type=""0"" name=""预计金额"" length=""255""/>";
            xml = xml + @"<column id=""field0009"" type=""1"" name=""工作内容与目标"" length=""255""/>";
            xml = xml + @"<column id=""field0010"" type=""1"" name=""目标完成情况"" length=""255""/>";
            xml = xml + @"<column id=""field0011"" type=""1"" name=""区域经理审批"" length=""255""/>";
            xml = xml + @"<column id=""field0013"" type=""0"" name=""是否正常业务出差"" length=""255""/>";
            xml = xml + @"<column id=""field0014"" type=""0"" name=""出差签到"" length=""20""/>";
            xml = xml + @"<column id=""field0015"" type=""0"" name=""经销客户卖场现场检查表"" length=""255""/>";
            xml = xml + @"<column id=""field0016"" type=""0"" name=""经销商库存分析表"" length=""255""/>";
            xml = xml + @"<column id=""field0017"" type=""0"" name=""经销客户批发网点现场检查表"" length=""255""/>";
            xml = xml + @"<column id=""field0018"" type=""0"" name=""经销客户拜访记录表"" length=""255""/>";
            xml = xml + @"<column id=""field0019"" type=""0"" name=""区域经理审批人"" length=""255""/>";
            xml = xml + @"<column id=""field0020"" type=""3"" name=""区域经理审批日期"" length=""255""/>";
            xml = xml + @"<column id=""field0021"" type=""0"" name=""大区经理审批"" length=""4000""/>";
            xml = xml + @"<column id=""field0022"" type=""0"" name=""大区经理审批人"" length=""255""/>";
            xml = xml + @"<column id=""field0023"" type=""3"" name=""大区经理审批时间"" length=""255""/>";
            xml = xml + @"<column id=""field0024"" type=""1"" name=""分管领导审批"" length=""255""/>";
            xml = xml + @"<column id=""field0025"" type=""0"" name=""分管领导审批人"" length=""255""/>";
            xml = xml + @"<column id=""field0026"" type=""3"" name=""分管领导审批日期"" length=""255""/>";
            xml = xml + @"<column id=""field0027"" type=""1"" name=""部门总经理审批"" length=""255""/>";
            xml = xml + @"<column id=""field0028"" type=""0"" name=""部门总经理审批人"" length=""255""/>";
            xml = xml + @"<column id=""field0029"" type=""3"" name=""部门总经理审批日期"" length=""255""/>";
            xml = xml + @"<column id=""field0030"" type=""3"" name=""主管副总审批日期"" length=""255""/>";
            xml = xml + @"<column id=""field0031"" type=""0"" name=""主管副总审批"" length=""4000""/>";
            xml = xml + @"<column id=""field0032"" type=""0"" name=""主管副总审批人"" length=""255""/>";
            xml = xml + @"<column id=""field0048"" type=""0"" name=""流水号"" length=""255""/>";
            xml = xml + @"<column id=""field0012"" type=""0"" name=""是否本区域出差"" length=""255""/>";
            xml = xml + @"<column id=""field0051"" type=""4"" name=""其他出行方式费用"" length=""20""/>";
            xml = xml + @"<column id=""field0050"" type=""0"" name=""其他出行方式"" length=""255""/>";
            xml = xml + @"<column id=""field0049"" type=""4"" name=""实际出差费用"" length=""20""/>";
            xml = xml + @"<column id=""field0052"" type=""0"" name=""完成情况评估"" length=""255""/>";
            xml = xml + @"<column id=""field0054"" type=""0"" name=""实际出差天数"" length=""255""/>";
            xml = xml + @"<column id=""field0055"" type=""0"" name=""出差类型"" length=""255""/>";
            xml = xml + @"<column id=""field0056"" type=""0"" name=""标题"" length=""255""/>";
            xml = xml + @"<column id=""field0057"" type=""0"" name=""备注"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            xml = xml + @"<column name=""申请日期"">";
            xml = xml + @"<value><![CDATA[" + model.CCSQSJ + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""出差人"">";
            xml = xml + @"<value/>";
            //xml = xml + @"<value><![CDATA[" + model.STAFFNAME + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""所在部门"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""出差地点"">";
            xml = xml + @"<value><![CDATA[" + model.CCDD + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""开始时间"">";
            xml = xml + @"<value><![CDATA[" + model.JHCCKSSJ + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""结束时间"">";
            xml = xml + @"<value><![CDATA[" + model.JHCCJSSJ + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""出行方式"">";
            xml = xml + @"<value><![CDATA[" + model.CXFS + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""预计金额"">";
            xml = xml + @"<value><![CDATA[" + model.YJJE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""工作内容与目标"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""目标完成情况"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""区域经理审批"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""是否正常业务出差"">";
            xml = xml + @"<value><![CDATA[" + model.ZCYWCCDES + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""出差签到"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""经销客户卖场现场检查表"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""经销商库存分析表"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""经销客户批发网点现场检查表"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""经销客户拜访记录表"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""区域经理审批人"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""区域经理审批日期"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""大区经理审批"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""大区经理审批人"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""大区经理审批时间"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""分管领导审批"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""分管领导审批人"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""分管领导审批日期"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""部门总经理审批"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""部门总经理审批人"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""部门总经理审批日期"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""主管副总审批日期"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""主管副总审批"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""主管副总审批人"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""流水号"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""是否本区域出差"">";
            xml = xml + @"<value><![CDATA[" + model.BQYCCDES + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""其他出行方式费用"">";
            xml = xml + @"<value><![CDATA[" + model.QTCXFSJE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""其他出行方式"">";
            xml = xml + @"<value><![CDATA[" + model.QTCXFSDES + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""实际出差费用"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""完成情况评估"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""实际出差天数"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""出差类型"">";
            xml = xml + @"<value><![CDATA[" + model.CCLXDES + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""标题"">";
            xml = xml + @"<value><![CDATA[" + model.TITLE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""备注"">";
            xml = xml + @"<value><![CDATA[" + model.BEIZ + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"</values>";
            xml = xml + @"<subForms>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0033"" type=""0"" name=""field1"" length=""255""/>";
            xml = xml + @"<column id=""field0034"" type=""0"" name=""field2"" length=""255""/>";
            xml = xml + @"<column id=""field0035"" type=""0"" name=""field3"" length=""255""/>";
            xml = xml + @"<column id=""field0036"" type=""0"" name=""field4"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            xml = xml + @"<row>";
            xml = xml + @"<column name=""field1"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""field2"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""field3"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""field4"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"</row>";
            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0037"" type=""0"" name=""field5"" length=""255""/>";
            xml = xml + @"<column id=""field0038"" type=""0"" name=""field6"" length=""255""/>";
            xml = xml + @"<column id=""field0039"" type=""0"" name=""field7"" length=""255""/>";
            xml = xml + @"<column id=""field0040"" type=""0"" name=""field8"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            xml = xml + @"<row>";
            xml = xml + @"<column name=""field5"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""field6"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""field7"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""field8"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"</row>";
            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0041"" type=""3"" name=""日期"" length=""255""/>";
            xml = xml + @"<column id=""field0042"" type=""0"" name=""地点"" length=""255""/>";
            xml = xml + @"<column id=""field0043"" type=""0"" name=""工作内容和目标"" length=""1000""/>";
            xml = xml + @"<column id=""field0044"" type=""0"" name=""工作总结"" length=""4000""/>";
            xml = xml + @"<column id=""field0045"" type=""0"" name=""上下午"" length=""255""/>";
            xml = xml + @"<column id=""field0046"" type=""0"" name=""field9"" length=""255""/>";
            xml = xml + @"<column id=""field0047"" type=""0"" name=""出差签到1"" length=""20""/>";
            xml = xml + @"<column id=""field0053"" type=""0"" name=""分管领导评估"" length=""255""/>";
            xml = xml + @"<column id=""field0041"" type=""3"" name=""日期"" length=""255""/>";
            xml = xml + @"<column id=""field0042"" type=""0"" name=""地点"" length=""255""/>";
            xml = xml + @"<column id=""field0043"" type=""0"" name=""工作内容和目标"" length=""1000""/>";
            xml = xml + @"<column id=""field0044"" type=""0"" name=""工作总结"" length=""4000""/>";
            xml = xml + @"<column id=""field0045"" type=""0"" name=""上下午"" length=""255""/>";
            xml = xml + @"<column id=""field0046"" type=""0"" name=""field9"" length=""255""/>";
            xml = xml + @"<column id=""field0047"" type=""0"" name=""出差签到1"" length=""20""/>";
            xml = xml + @"<column id=""field0053"" type=""0"" name=""分管领导评估"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            foreach (CRM_OA_CC_SUB item in model.CRM_OA_CC_SUBList)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""日期"">";
                xml = xml + @"<value><![CDATA[" + item.DATE + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""地点"">";
                xml = xml + @"<value><![CDATA[" + item.DD + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""工作内容和目标"">";
                xml = xml + @"<value><![CDATA[" + item.GZMB + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""工作总结"">";
                xml = xml + @"<value/>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""上下午"">";
                xml = xml + @"<value><![CDATA[" + item.CCSJLXDES + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""field9"">";
                xml = xml + @"<value/>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""出差签到1"">";
                xml = xml + @"<value/>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""分管领导评估"">";
                xml = xml + @"<value/>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";

            }
            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"</subForms>";
            xml = xml + @"</formExport>";

            //xml = xml + @"<formExport version=""2.0"">";
            //xml = xml + @"<summary id="""" name=""formmain_1843""/>";
            //xml = xml + @"<definitions>";
            //xml = xml + @"<column id=""field0001"" type=""0"" name=""申请日期"" length=""255""/>";
            //xml = xml + @"<column id=""field0002"" type=""0"" name=""出差人"" length=""255""/>";
            //xml = xml + @"<column id=""field0003"" type=""0"" name=""所在部门"" length=""255""/>";
            //xml = xml + @"<column id=""field0004"" type=""0"" name=""出差地点"" length=""255""/>";
            //xml = xml + @"<column id=""field0005"" type=""0"" name=""开始时间"" length=""255""/>";
            //xml = xml + @"<column id=""field0006"" type=""0"" name=""结束时间"" length=""255""/>";
            //xml = xml + @"<column id=""field0007"" type=""0"" name=""出行方式"" length=""255""/>";
            //xml = xml + @"<column id=""field0008"" type=""0"" name=""预计金额"" length=""255""/>";
            //xml = xml + @"<column id=""field0009"" type=""1"" name=""工作内容与目标"" length=""255""/>";
            //xml = xml + @"<column id=""field0010"" type=""1"" name=""目标完成情况"" length=""255""/>";
            //xml = xml + @"<column id=""field0011"" type=""1"" name=""区域经理审批"" length=""255""/>";
            //xml = xml + @"<column id=""field0013"" type=""0"" name=""是否正常业务出差"" length=""255""/>";
            //xml = xml + @"<column id=""field0014"" type=""0"" name=""出差签到"" length=""20""/>";
            //xml = xml + @"<column id=""field0015"" type=""0"" name=""经销客户卖场现场检查表"" length=""255""/>";
            //xml = xml + @"<column id=""field0016"" type=""0"" name=""经销商库存分析表"" length=""255""/>";
            //xml = xml + @"<column id=""field0017"" type=""0"" name=""经销客户批发网点现场检查表"" length=""255""/>";
            //xml = xml + @"<column id=""field0018"" type=""0"" name=""经销客户拜访记录表"" length=""255""/>";
            //xml = xml + @"<column id=""field0019"" type=""0"" name=""区域经理审批人"" length=""255""/>";
            //xml = xml + @"<column id=""field0020"" type=""3"" name=""区域经理审批日期"" length=""255""/>";
            //xml = xml + @"<column id=""field0021"" type=""0"" name=""大区经理审批"" length=""4000""/>";
            //xml = xml + @"<column id=""field0022"" type=""0"" name=""大区经理审批人"" length=""255""/>";
            //xml = xml + @"<column id=""field0023"" type=""3"" name=""大区经理审批时间"" length=""255""/>";
            //xml = xml + @"<column id=""field0024"" type=""1"" name=""分管领导审批"" length=""255""/>";
            //xml = xml + @"<column id=""field0025"" type=""0"" name=""分管领导审批人"" length=""255""/>";
            //xml = xml + @"<column id=""field0026"" type=""3"" name=""分管领导审批日期"" length=""255""/>";
            //xml = xml + @"<column id=""field0027"" type=""1"" name=""部门总经理审批"" length=""255""/>";
            //xml = xml + @"<column id=""field0028"" type=""0"" name=""部门总经理审批人"" length=""255""/>";
            //xml = xml + @"<column id=""field0029"" type=""3"" name=""部门总经理审批日期"" length=""255""/>";
            //xml = xml + @"<column id=""field0030"" type=""3"" name=""主管副总审批日期"" length=""255""/>";
            //xml = xml + @"<column id=""field0031"" type=""0"" name=""主管副总审批"" length=""4000""/>";
            //xml = xml + @"<column id=""field0032"" type=""0"" name=""主管副总审批人"" length=""255""/>";
            //xml = xml + @"<column id=""field0048"" type=""0"" name=""流水号"" length=""255""/>";
            //xml = xml + @"<column id=""field0012"" type=""0"" name=""是否本区域出差"" length=""255""/>";
            //xml = xml + @"<column id=""field0051"" type=""4"" name=""其他出行方式费用"" length=""20""/>";
            //xml = xml + @"<column id=""field0050"" type=""0"" name=""其他出行方式"" length=""255""/>";
            //xml = xml + @"<column id=""field0049"" type=""4"" name=""实际出差费用"" length=""20""/>";
            //xml = xml + @"<column id=""field0052"" type=""0"" name=""完成情况评估"" length=""255""/>";
            //xml = xml + @"<column id=""field0054"" type=""0"" name=""实际出差天数"" length=""255""/>";
            //xml = xml + @"<column id=""field0055"" type=""0"" name=""出差类型"" length=""255""/>";
            //xml = xml + @"</definitions>";
            //xml = xml + @"<values>";
            //xml = xml + @"<column name=""申请日期"">";
            //xml = xml + @"<value><![CDATA["+model.CCSQSJ+"]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""出差人"">";
            //xml = xml + @"<value><![CDATA["+model.STAFFNAME+"]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""所在部门"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""出差地点"">";
            //xml = xml + @"<value><![CDATA["+model.CCDD+"]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""开始时间"">";
            //xml = xml + @"<value><![CDATA["+model.JHCCKSSJ+"]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""结束时间"">";
            //xml = xml + @"<value><![CDATA["+model.JHCCJSSJ+"]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""出行方式"">";
            //xml = xml + @"<value><![CDATA["+model.CXFS+"]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""预计金额"">";
            //xml = xml + @"<value><![CDATA["+model.YJJE+"]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""工作内容与目标"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""目标完成情况"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""区域经理审批"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""是否正常业务出差"">";
            //xml = xml + @"<value><![CDATA["+model.ZCYWCCDES+"]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""出差签到"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""经销客户卖场现场检查表"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""经销商库存分析表"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""经销客户批发网点现场检查表"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""经销客户拜访记录表"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""区域经理审批人"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""区域经理审批日期"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""大区经理审批"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""大区经理审批人"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""大区经理审批时间"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""分管领导审批"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""分管领导审批人"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""分管领导审批日期"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""部门总经理审批"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""部门总经理审批人"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""部门总经理审批日期"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""主管副总审批日期"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""主管副总审批"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""主管副总审批人"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""流水号"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""是否本区域出差"">";
            //xml = xml + @"<value><![CDATA["+model.BQYCCDES+"]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""其他出行方式费用"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""其他出行方式"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""实际出差费用"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""完成情况评估"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""实际出差天数"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""出差类型"">";
            //xml = xml + @"<value><![CDATA["+model.CCLXDES+"]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"</values>";
            //xml = xml + @"<subForms>";
            //xml = xml + @"<subForm>";
            //xml = xml + @"<definitions>";
            //xml = xml + @"<column id=""field0033"" type=""0"" name=""field1"" length=""255""/>";
            //xml = xml + @"<column id=""field0034"" type=""0"" name=""field2"" length=""255""/>";
            //xml = xml + @"<column id=""field0035"" type=""0"" name=""field3"" length=""255""/>";
            //xml = xml + @"<column id=""field0036"" type=""0"" name=""field4"" length=""255""/>";
            //xml = xml + @"</definitions>";
            //xml = xml + @"<values>";
            //xml = xml + @"<row>";
            //xml = xml + @"<column name=""field1"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""field2"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""field3"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""field4"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"</row>";
            //xml = xml + @"</values>";
            //xml = xml + @"</subForm>";
            //xml = xml + @"<subForm>";
            //xml = xml + @"<definitions>";
            //xml = xml + @"<column id=""field0037"" type=""0"" name=""field5"" length=""255""/>";
            //xml = xml + @"<column id=""field0038"" type=""0"" name=""field6"" length=""255""/>";
            //xml = xml + @"<column id=""field0039"" type=""0"" name=""field7"" length=""255""/>";
            //xml = xml + @"<column id=""field0040"" type=""0"" name=""field8"" length=""255""/>";
            //xml = xml + @"</definitions>";
            //xml = xml + @"<values>";
            //xml = xml + @"<row>";
            //xml = xml + @"<column name=""field5"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""field6"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""field7"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""field8"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"</row>";
            //xml = xml + @"</values>";
            //xml = xml + @"</subForm>";
            //xml = xml + @"<subForm>";
            //xml = xml + @"<definitions>";
            //xml = xml + @"<column id=""field0041"" type=""3"" name=""日期"" length=""255""/>";
            //xml = xml + @"<column id=""field0042"" type=""0"" name=""地点"" length=""255""/>";
            //xml = xml + @"<column id=""field0043"" type=""0"" name=""工作内容和目标"" length=""1000""/>";
            //xml = xml + @"<column id=""field0044"" type=""0"" name=""工作总结"" length=""4000""/>";
            //xml = xml + @"<column id=""field0045"" type=""0"" name=""上下午"" length=""255""/>";
            //xml = xml + @"<column id=""field0046"" type=""0"" name=""field9"" length=""255""/>";
            //xml = xml + @"<column id=""field0047"" type=""0"" name=""出差签到1"" length=""20""/>";
            //xml = xml + @"<column id=""field0053"" type=""0"" name=""分管领导评估"" length=""255""/>";
            //xml = xml + @"<column id=""field0041"" type=""3"" name=""日期"" length=""255""/>";
            //xml = xml + @"<column id=""field0042"" type=""0"" name=""地点"" length=""255""/>";
            //xml = xml + @"<column id=""field0043"" type=""0"" name=""工作内容和目标"" length=""1000""/>";
            //xml = xml + @"<column id=""field0044"" type=""0"" name=""工作总结"" length=""4000""/>";
            //xml = xml + @"<column id=""field0045"" type=""0"" name=""上下午"" length=""255""/>";
            //xml = xml + @"<column id=""field0046"" type=""0"" name=""field9"" length=""255""/>";
            //xml = xml + @"<column id=""field0047"" type=""0"" name=""出差签到1"" length=""20""/>";
            //xml = xml + @"<column id=""field0053"" type=""0"" name=""分管领导评估"" length=""255""/>";
            //xml = xml + @"</definitions>";
            //xml = xml + @"<values>";
            //foreach (CRM_OA_CC_SUB item in model.CRM_OA_CC_SUBList)
            //{
            //    xml = xml + @"<row>";
            //    xml = xml + @"<column name=""日期"">";
            //    xml = xml + @"<value><![CDATA["+item.DATE+"]]></value>";
            //    xml = xml + @"</column>";
            //    xml = xml + @"<column name=""地点"">";
            //    xml = xml + @"<value><![CDATA["+item.DD+"]]></value>";
            //    xml = xml + @"</column>";
            //    xml = xml + @"<column name=""工作内容和目标"">";
            //    xml = xml + @"<value><![CDATA["+item.GZMB+"]]></value>";
            //    xml = xml + @"</column>";
            //    xml = xml + @"<column name=""工作总结"">";
            //    xml = xml + @"<value/>";
            //    xml = xml + @"</column>";
            //    xml = xml + @"<column name=""上下午"">";
            //    xml = xml + @"<value><![CDATA["+item.CCSJLXDES+"]]></value>";
            //    xml = xml + @"</column>";
            //    xml = xml + @"<column name=""field9"">";
            //    xml = xml + @"<value/>";
            //    xml = xml + @"</column>";
            //    xml = xml + @"<column name=""出差签到1"">";
            //    xml = xml + @"<value/>";
            //    xml = xml + @"</column>";
            //    xml = xml + @"<column name=""分管领导评估"">";
            //    xml = xml + @"<value/>";
            //    xml = xml + @"</column>";
            //    xml = xml + @"</row>";
            //}          
            //xml = xml + @"</values>";
            //xml = xml + @"</subForm>";
            //xml = xml + @"</subForms>";
            //xml = xml + @"</formExport>";

            return xml;
        }

        public string XML_CC_HX(CRM_OA_CC model)
        {
            string xml = "";
            xml = xml + @"<formExport version=""2.0"">";
            xml = xml + @" <summary id="""" name=""formmain_1857""/>";
            xml = xml + @" <definitions>";
            xml = xml + @" <column id=""field0001"" type=""0"" name=""申请日期"" length=""255""/>";
            xml = xml + @" <column id=""field0002"" type=""0"" name=""出差人"" length=""255""/>";
            xml = xml + @" <column id=""field0003"" type=""0"" name=""所在部门"" length=""255""/>";
            xml = xml + @" <column id=""field0004"" type=""0"" name=""出差地点"" length=""255""/>";
            xml = xml + @" <column id=""field0005"" type=""0"" name=""开始时间"" length=""255""/>";
            xml = xml + @" <column id=""field0006"" type=""0"" name=""结束时间"" length=""255""/>";
            xml = xml + @" <column id=""field0007"" type=""0"" name=""出行方式"" length=""255""/>";
            xml = xml + @" <column id=""field0008"" type=""0"" name=""预计金额"" length=""255""/>";
            xml = xml + @" <column id=""field0009"" type=""1"" name=""工作内容与目标"" length=""255""/>";
            xml = xml + @" <column id=""field0010"" type=""1"" name=""目标完成情况"" length=""255""/>";
            xml = xml + @" <column id=""field0011"" type=""1"" name=""区域经理审批"" length=""255""/>";
            xml = xml + @" <column id=""field0013"" type=""0"" name=""是否正常业务出差"" length=""255""/>";
            xml = xml + @" <column id=""field0014"" type=""0"" name=""出差签到"" length=""20""/>";
            xml = xml + @" <column id=""field0015"" type=""0"" name=""经销客户卖场现场检查表"" length=""255""/>";
            xml = xml + @" <column id=""field0016"" type=""0"" name=""经销商库存分析表"" length=""255""/>";
            xml = xml + @" <column id=""field0017"" type=""0"" name=""经销客户批发网点现场检查表"" length=""255""/>";
            xml = xml + @" <column id=""field0018"" type=""0"" name=""经销客户拜访记录表"" length=""255""/>";
            xml = xml + @" <column id=""field0019"" type=""0"" name=""区域经理审批人"" length=""255""/>";
            xml = xml + @" <column id=""field0020"" type=""3"" name=""区域经理审批日期"" length=""255""/>";
            xml = xml + @" <column id=""field0021"" type=""0"" name=""大区经理审批"" length=""4000""/>";
            xml = xml + @" <column id=""field0022"" type=""0"" name=""大区经理审批人"" length=""255""/>";
            xml = xml + @" <column id=""field0023"" type=""3"" name=""大区经理审批时间"" length=""255""/>";
            xml = xml + @" <column id=""field0024"" type=""1"" name=""分管领导审批"" length=""255""/>";
            xml = xml + @" <column id=""field0025"" type=""0"" name=""分管领导审批人"" length=""255""/>";
            xml = xml + @" <column id=""field0026"" type=""3"" name=""分管领导审批日期"" length=""255""/>";
            xml = xml + @" <column id=""field0027"" type=""1"" name=""部门总经理审批"" length=""255""/>";
            xml = xml + @" <column id=""field0028"" type=""0"" name=""部门总经理审批人"" length=""255""/>";
            xml = xml + @" <column id=""field0029"" type=""3"" name=""部门总经理审批日期"" length=""255""/>";
            xml = xml + @" <column id=""field0030"" type=""3"" name=""主管副总审批日期"" length=""255""/>";
            xml = xml + @" <column id=""field0031"" type=""0"" name=""主管副总审批"" length=""4000""/>";
            xml = xml + @" <column id=""field0032"" type=""0"" name=""主管副总审批人"" length=""255""/>";
            xml = xml + @" <column id=""field0048"" type=""0"" name=""流水号"" length=""255""/>";
            xml = xml + @" <column id=""field0012"" type=""0"" name=""是否本区域出差"" length=""255""/>";
            xml = xml + @" <column id=""field0051"" type=""4"" name=""其他出行方式费用"" length=""20""/>";
            xml = xml + @" <column id=""field0050"" type=""0"" name=""其他出行方式"" length=""255""/>";
            xml = xml + @" <column id=""field0049"" type=""4"" name=""实际出差费用"" length=""20""/>";
            xml = xml + @" <column id=""field0052"" type=""0"" name=""完成情况评估"" length=""255""/>";
            xml = xml + @" <column id=""field0054"" type=""0"" name=""实际出差天数"" length=""255""/>";
            xml = xml + @" <column id=""field0055"" type=""0"" name=""出差类型"" length=""255""/>";
            xml = xml + @" <column id=""field0056"" type=""0"" name=""备注"" length=""255""/>";
            xml = xml + @" </definitions>";
            xml = xml + @" <values>";
            xml = xml + @" <column name=""申请日期"">";
            xml = xml + @" <value><![CDATA[" + model.CCSQSJ + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""出差人"">";
            xml = xml + @" <value/>";
            //xml = xml + @" <value><![CDATA[" + model.STAFFNAME + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""所在部门"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""出差地点"">";
            xml = xml + @" <value><![CDATA[" + model.CCDD + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""开始时间"">";
            xml = xml + @" <value><![CDATA[" + model.JHCCKSSJ + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""结束时间"">";
            xml = xml + @" <value><![CDATA[" + model.JHCCJSSJ + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""出行方式"">";
            xml = xml + @" <value><![CDATA[" + model.CXFS + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""预计金额"">";
            xml = xml + @" <value><![CDATA[" + model.YJJE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""工作内容与目标"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""目标完成情况"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""区域经理审批"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""是否正常业务出差"">";
            xml = xml + @" <value><![CDATA[" + model.ZCYWCCDES + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""出差签到"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""经销客户卖场现场检查表"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""经销商库存分析表"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""经销客户批发网点现场检查表"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""经销客户拜访记录表"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""区域经理审批人"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""区域经理审批日期"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""大区经理审批"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""大区经理审批人"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""大区经理审批时间"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""分管领导审批"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""分管领导审批人"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""分管领导审批日期"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""部门总经理审批"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""部门总经理审批人"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""部门总经理审批日期"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""主管副总审批日期"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""主管副总审批"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""主管副总审批人"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""流水号"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""是否本区域出差"">";
            xml = xml + @" <value><![CDATA[" + model.BQYCCDES + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""其他出行方式费用"">";
            xml = xml + @" <value><![CDATA[" + model.QTCXFSJE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""其他出行方式"">";
            xml = xml + @" <value><![CDATA[" + model.QTCXFSDES + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""实际出差费用"">";
            xml = xml + @" <value><![CDATA[" + model.SJJE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""完成情况评估"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""实际出差天数"">";
            xml = xml + @" <value><![CDATA[" + model.SJCCTS + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""出差类型"">";
            xml = xml + @" <value><![CDATA[" + model.CCLXDES + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""备注"">";
            xml = xml + @" <value><![CDATA[" + model.BEIZ + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" </values>";
            xml = xml + @" <subForms>";
            xml = xml + @" <subForm>";
            xml = xml + @" <definitions>";
            xml = xml + @" <column id=""field0033"" type=""0"" name=""field1"" length=""255""/>";
            xml = xml + @" <column id=""field0034"" type=""0"" name=""field2"" length=""255""/>";
            xml = xml + @" <column id=""field0035"" type=""0"" name=""field3"" length=""255""/>";
            xml = xml + @" <column id=""field0036"" type=""0"" name=""field4"" length=""255""/>";
            xml = xml + @" </definitions>";
            xml = xml + @" <values>";
            xml = xml + @" <row>";
            xml = xml + @" <column name=""field1"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""field2"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""field3"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""field4"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" </row>";
            xml = xml + @" </values>";
            xml = xml + @" </subForm>";
            xml = xml + @" <subForm>";
            xml = xml + @" <definitions>";
            xml = xml + @" <column id=""field0037"" type=""0"" name=""field5"" length=""255""/>";
            xml = xml + @" <column id=""field0038"" type=""0"" name=""field6"" length=""255""/>";
            xml = xml + @" <column id=""field0039"" type=""0"" name=""field7"" length=""255""/>";
            xml = xml + @" <column id=""field0040"" type=""0"" name=""field8"" length=""255""/>";
            xml = xml + @" </definitions>";
            xml = xml + @" <values>";
            xml = xml + @" <row>";
            xml = xml + @" <column name=""field5"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""field6"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""field7"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""field8"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" </row>";
            xml = xml + @" </values>";
            xml = xml + @" </subForm>";
            xml = xml + @" <subForm>";
            xml = xml + @" <definitions>";
            xml = xml + @" <column id=""field0041"" type=""3"" name=""日期"" length=""255""/>";
            xml = xml + @" <column id=""field0042"" type=""0"" name=""地点"" length=""255""/>";
            xml = xml + @" <column id=""field0043"" type=""0"" name=""工作内容和目标"" length=""1000""/>";
            xml = xml + @" <column id=""field0044"" type=""0"" name=""工作总结"" length=""4000""/>";
            xml = xml + @" <column id=""field0045"" type=""0"" name=""上下午"" length=""255""/>";
            xml = xml + @" <column id=""field0046"" type=""0"" name=""field9"" length=""255""/>";
            xml = xml + @" <column id=""field0047"" type=""0"" name=""出差签到1"" length=""20""/>";
            xml = xml + @" <column id=""field0053"" type=""0"" name=""分管领导评估"" length=""255""/>";
            xml = xml + @" <column id=""field0041"" type=""3"" name=""日期"" length=""255""/>";
            xml = xml + @" <column id=""field0042"" type=""0"" name=""地点"" length=""255""/>";
            xml = xml + @" <column id=""field0043"" type=""0"" name=""工作内容和目标"" length=""1000""/>";
            xml = xml + @" <column id=""field0044"" type=""0"" name=""工作总结"" length=""4000""/>";
            xml = xml + @" <column id=""field0045"" type=""0"" name=""上下午"" length=""255""/>";
            xml = xml + @" <column id=""field0046"" type=""0"" name=""field9"" length=""255""/>";
            xml = xml + @" <column id=""field0047"" type=""0"" name=""出差签到1"" length=""20""/>";
            xml = xml + @" <column id=""field0053"" type=""0"" name=""分管领导评估"" length=""255""/>";
            xml = xml + @" </definitions>";
            xml = xml + @" <values>";
            foreach (CRM_OA_CC_SUB item in model.CRM_OA_CC_SUBList)
            {
                xml = xml + @" <row>";
                xml = xml + @" <column name=""日期"">";
                xml = xml + @" <value><![CDATA[" + item.DATE + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""地点"">";
                xml = xml + @" <value><![CDATA[" + item.DD + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""工作内容和目标"">";
                xml = xml + @" <value><![CDATA[" + item.GZMB + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""工作总结"">";
                xml = xml + @" <value><![CDATA[" + item.MBWCQK + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""上下午"">";
                xml = xml + @" <value><![CDATA[" + item.CCSJLXDES + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""field9"">";
                xml = xml + @" <value/>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""出差签到1"">";
                xml = xml + @" <value><![CDATA[" + item.QDWZ + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""分管领导评估"">";
                xml = xml + @" <value/>";
                xml = xml + @" </column>";
                xml = xml + @" </row>";

            }

            xml = xml + @" </values>";
            xml = xml + @" </subForm>";
            xml = xml + @" </subForms>";
            xml = xml + @" </formExport>";
            return xml;
        }

        public string XML_KH_JXS(CRM_OA_KH model)
        {
            CRM_OA_KH_ZXS ZXSmodel = model.CRM_OA_KH_ZXS;
            string xml = "";


            xml = xml + @"<formExport version=""2.0"">";
            xml = xml + @"<summary id="""" name=""formmain_1882""/>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0001"" type=""0"" name=""新增公司名称"" length=""255""/>";
            xml = xml + @"<column id=""field0002"" type=""0"" name=""开票性质"" length=""255""/>";
            xml = xml + @"<column id=""field0003"" type=""0"" name=""公司联系人"" length=""255""/>";
            xml = xml + @"<column id=""field0004"" type=""0"" name=""公司联系电话"" length=""255""/>";
            xml = xml + @"<column id=""field0005"" type=""0"" name=""开票地址"" length=""255""/>";
            xml = xml + @"<column id=""field0006"" type=""0"" name=""公司法人"" length=""255""/>";
            xml = xml + @"<column id=""field0007"" type=""0"" name=""公司联系人与法人关系"" length=""255""/>";
            xml = xml + @"<column id=""field0008"" type=""0"" name=""开票电话"" length=""255""/>";
            xml = xml + @"<column id=""field0009"" type=""0"" name=""快递寄送地址"" length=""255""/>";
            xml = xml + @"<column id=""field0010"" type=""0"" name=""联系人-电话"" length=""255""/>";
            xml = xml + @"<column id=""field0011"" type=""0"" name=""纳税人识别号"" length=""255""/>";
            xml = xml + @"<column id=""field0012"" type=""0"" name=""合同销售任务"" length=""255""/>";
            xml = xml + @"<column id=""field0013"" type=""0"" name=""合同碱性销售任务"" length=""255""/>";
            xml = xml + @"<column id=""field0014"" type=""0"" name=""银行账号"" length=""255""/>";
            xml = xml + @"<column id=""field0016"" type=""0"" name=""是否出厂价"" length=""255""/>";
            xml = xml + @"<column id=""field0017"" type=""0"" name=""银行名称"" length=""255""/>";
            xml = xml + @"<column id=""field0018"" type=""0"" name=""管辖区域"" length=""255""/>";
            xml = xml + @"<column id=""field0019"" type=""0"" name=""客户收货地址"" length=""255""/>";
            xml = xml + @"<column id=""field0020"" type=""0"" name=""联系人及电话"" length=""255""/>";
            xml = xml + @"<column id=""field0021"" type=""0"" name=""特殊情况说明"" length=""255""/>";
            xml = xml + @"<column id=""field0022"" type=""0"" name=""批发"" length=""255""/>";
            xml = xml + @"<column id=""field0024"" type=""0"" name=""直销"" length=""255""/>";
            xml = xml + @"<column id=""field0025"" type=""0"" name=""其他"" length=""255""/>";
            xml = xml + @"<column id=""field0029"" type=""0"" name=""说明"" length=""255""/>";
            xml = xml + @"<column id=""field0030"" type=""0"" name=""负责业务员"" length=""255""/>";
            xml = xml + @"<column id=""field0031"" type=""0"" name=""管辖区域2"" length=""255""/>";
            xml = xml + @"<column id=""field0032"" type=""0"" name=""分管领导意见"" length=""4000""/>";
            xml = xml + @"<column id=""field0033"" type=""0"" name=""销售总监意见"" length=""4000""/>";
            xml = xml + @"<column id=""field0028"" type=""0"" name=""域28-f"" length=""255""/>";
            xml = xml + @"<column id=""field0027"" type=""0"" name=""渠道不同-f"" length=""5""/>";
            xml = xml + @"<column id=""field0026"" type=""0"" name=""区域冲突-f"" length=""5""/>";
            xml = xml + @"<column id=""field0034"" type=""0"" name=""是否"" length=""255""/>";
            xml = xml + @"<column id=""field0023"" type=""0"" name=""渠道介绍-f"" length=""255""/>";
            xml = xml + @"<column id=""field0035"" type=""0"" name=""渠道介绍-新"" length=""255""/>";
            xml = xml + @"<column id=""field0036"" type=""0"" name=""域29"" length=""255""/>";
            xml = xml + @"<column id=""field0015"" type=""0"" name=""销售归属"" length=""255""/>";
            xml = xml + @"<column id=""field0037"" type=""0"" name=""返利归属"" length=""255""/>";
            xml = xml + @"<column id=""field0038"" type=""0"" name=""客户编号"" length=""255""/>";
            xml = xml + @"<column id=""field0045"" type=""0"" name=""经销商来源"" length=""255""/>";
            xml = xml + @"<column id=""field0046"" type=""0"" name=""客户介绍"" length=""1000""/>";
            xml = xml + @"<column id=""field0047"" type=""0"" name=""首批订单A类产品订货金额"" length=""255""/>";
            xml = xml + @"<column id=""field0048"" type=""0"" name=""客户类型"" length=""255""/>";
            xml = xml + @"<column id=""field0049"" type=""0"" name=""是否参加A类产品满送活动"" length=""255""/>";
            xml = xml + @"<column id=""field0050"" type=""0"" name=""数据来源"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            xml = xml + @"<column name=""新增公司名称"">";
            xml = xml + @"<value><![CDATA[" + model.MC + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""开票性质"">";
            xml = xml + @"<value><![CDATA[" + model.JPXZ + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""公司联系人"">";
            xml = xml + @"<value><![CDATA[" + model.GSLXR + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""公司联系电话"">";
            xml = xml + @"<value><![CDATA[" + model.GSLXDH + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""开票地址"">";
            xml = xml + @"<value><![CDATA[" + model.KPDZ + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""公司法人"">";
            xml = xml + @"<value><![CDATA[" + model.FR + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""公司联系人与法人关系"">";
            xml = xml + @"<value><![CDATA[" + model.GSFRGX + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""开票电话"">";
            xml = xml + @"<value><![CDATA[" + model.KPDH + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""快递寄送地址"">";
            xml = xml + @"<value><![CDATA[" + model.KDJSDZ + "]]></value>";
            xml = xml + @"</column>";
            string lxd_dh = model.KDLXR + "-" + model.KDLXDH;
            xml = xml + @"<column name=""联系人-电话"">";
            xml = xml + @"<value><![CDATA[" + lxd_dh + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""纳税人识别号"">";
            xml = xml + @"<value><![CDATA[" + model.NSRSBH + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""合同销售任务"">";
            xml = xml + @"<value><![CDATA[" + model.HTXSRW + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""合同碱性销售任务"">";
            xml = xml + @"<value><![CDATA[" + model.HTXSRW + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""银行账号"">";
            xml = xml + @"<value><![CDATA[" + model.YHZH + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""是否出厂价"">";
            xml = xml + @"<value><![CDATA[" + model.SFCCJ + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""银行名称"">";
            xml = xml + @"<value><![CDATA[" + model.YHMC + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""管辖区域"">";
            xml = xml + @"<value><![CDATA[" + model.GXQY + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""客户收货地址"">";
            xml = xml + @"<value><![CDATA[" + model.KHSHDZ + "]]></value>";
            xml = xml + @"</column>";
            string lxr2 = model.KHSHLXR + "-" + model.KHSHLXDH;
            xml = xml + @"<column name=""联系人及电话"">";
            xml = xml + @"<value><![CDATA[" + lxr2 + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""特殊情况说明"">";
            xml = xml + @"<value><![CDATA[" + model.TSQKSM + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""批发"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""直销"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""其他"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""说明"">";
            xml = xml + @"<value><![CDATA[" + model.YXSM + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""负责业务员"">";
            xml = xml + @"<value><![CDATA[" + model.STAFFNAME + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""管辖区域2"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""分管领导意见"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""销售总监意见"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""域28-f"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""渠道不同-f"">";
            xml = xml + @"<value><![CDATA[0]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""区域冲突-f"">";
            xml = xml + @"<value><![CDATA[0]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""是否"">";
            xml = xml + @"<value><![CDATA[" + model.JXSYX + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""渠道介绍-f"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""渠道介绍-新"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""域29"">";
            xml = xml + @"<value><![CDATA[" + model.QD + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""销售归属"">";
            xml = xml + @"<value><![CDATA[" + model.XSSJSM + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""返利归属"">";
            xml = xml + @"<value><![CDATA[" + model.FLSJSM + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""客户编号"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""经销商来源"">";
            xml = xml + @"<value><![CDATA[" + model.KHSOURCE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""客户介绍"">";
            xml = xml + @"<value><![CDATA[" + model.KHJS + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""首批订单A类产品订货金额"">";
            xml = xml + @"<value><![CDATA[" + model.FIRSTAMOUNT + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""客户类型"">";
            xml = xml + @"<value><![CDATA[" + model.TITLE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""是否参加A类产品满送活动"">";
            xml = xml + @"<value><![CDATA[" + model.JOINACTIVITY + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""数据来源"">";
            xml = xml + @" <value><![CDATA[CRM]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"</values>";
            xml = xml + @"<subForms>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0018"" type=""0"" name=""车牌"" length=""255""/>";
            xml = xml + @"<column id=""field0019"" type=""0"" name=""是否有双鹿字样的车体广告"" length=""255""/>";
            xml = xml + @"<column id=""field0020"" type=""0"" name=""照片"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            foreach (var item in ZXSmodel.TABLE1List)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""车牌"">";
                xml = xml + @"<value><![CDATA[" + item.CHEPAI + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""是否有双鹿字样的车体广告"">";
                xml = xml + @"<value><![CDATA[" + item.AD + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""照片"">";
                xml = xml + @"<value><![CDATA[" + item.ZP + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }
            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0021"" type=""0"" name=""人员姓名"" length=""255""/>";
            xml = xml + @"<column id=""field0022"" type=""4"" name=""联系方式"" length=""20""/>";
            xml = xml + @"<column id=""field0023"" type=""0"" name=""工作内容"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            foreach (var item in ZXSmodel.TABLE2List)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""人员姓名"">";
                xml = xml + @"<value><![CDATA[" + item.KHSTAFF + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""联系方式"">";
                xml = xml + @"<value><![CDATA[" + item.TEL + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""工作内容"">";
                xml = xml + @"<value><![CDATA[" + item.GZNR + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }
            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"</subForms>";


            xml = xml + @"</formExport>";




            //xml = xml + @"<formExport version=""2.0"">";
            //xml = xml + @"<summary id="""" name=""formmain_1882""/>";
            //xml = xml + @"<definitions>";
            //xml = xml + @"<column id=""field0001"" type=""0"" name=""新增公司名称"" length=""255""/>";
            //xml = xml + @"<column id=""field0002"" type=""0"" name=""开票性质"" length=""255""/>";
            //xml = xml + @"<column id=""field0003"" type=""0"" name=""公司联系人"" length=""255""/>";
            //xml = xml + @"<column id=""field0004"" type=""0"" name=""公司联系电话"" length=""255""/>";
            //xml = xml + @"<column id=""field0005"" type=""0"" name=""开票地址"" length=""255""/>";
            //xml = xml + @"<column id=""field0006"" type=""0"" name=""公司法人"" length=""255""/>";
            //xml = xml + @"<column id=""field0007"" type=""0"" name=""公司联系人与法人关系"" length=""255""/>";
            //xml = xml + @"<column id=""field0008"" type=""0"" name=""开票电话"" length=""255""/>";
            //xml = xml + @"<column id=""field0009"" type=""0"" name=""快递寄送地址"" length=""255""/>";
            //xml = xml + @"<column id=""field0010"" type=""0"" name=""联系人-电话"" length=""255""/>";
            //xml = xml + @"<column id=""field0011"" type=""0"" name=""纳税人识别号"" length=""255""/>";
            //xml = xml + @"<column id=""field0012"" type=""0"" name=""合同销售任务"" length=""255""/>";
            //xml = xml + @"<column id=""field0013"" type=""0"" name=""合同碱性销售任务"" length=""255""/>";
            //xml = xml + @"<column id=""field0014"" type=""0"" name=""银行账号"" length=""255""/>";
            //xml = xml + @"<column id=""field0015"" type=""0"" name=""销售数据说明"" length=""255""/>";
            //xml = xml + @"<column id=""field0016"" type=""0"" name=""是否出厂价"" length=""255""/>";
            //xml = xml + @"<column id=""field0017"" type=""0"" name=""银行名称"" length=""255""/>";
            //xml = xml + @"<column id=""field0018"" type=""0"" name=""管辖区域"" length=""255""/>";
            //xml = xml + @"<column id=""field0019"" type=""0"" name=""客户收货地址"" length=""255""/>";
            //xml = xml + @"<column id=""field0020"" type=""0"" name=""联系人及电话"" length=""255""/>";
            //xml = xml + @"<column id=""field0021"" type=""0"" name=""特殊情况说明"" length=""255""/>";
            //xml = xml + @"<column id=""field0022"" type=""0"" name=""批发"" length=""255""/>";
            //xml = xml + @"<column id=""field0024"" type=""0"" name=""直销"" length=""255""/>";
            //xml = xml + @"<column id=""field0025"" type=""0"" name=""其他"" length=""255""/>";
            //xml = xml + @"<column id=""field0029"" type=""0"" name=""说明"" length=""255""/>";
            //xml = xml + @"<column id=""field0030"" type=""0"" name=""负责业务员"" length=""255""/>";
            //xml = xml + @"<column id=""field0031"" type=""0"" name=""管辖区域2"" length=""255""/>";
            //xml = xml + @"<column id=""field0032"" type=""0"" name=""分管领导意见"" length=""4000""/>";
            //xml = xml + @"<column id=""field0033"" type=""0"" name=""销售总监意见"" length=""4000""/>";
            //xml = xml + @"<column id=""field0028"" type=""0"" name=""域28-f"" length=""255""/>";
            //xml = xml + @"<column id=""field0027"" type=""0"" name=""渠道不同-f"" length=""5""/>";
            //xml = xml + @"<column id=""field0026"" type=""0"" name=""区域冲突-f"" length=""5""/>";
            //xml = xml + @"<column id=""field0034"" type=""0"" name=""是否"" length=""255""/>";
            //xml = xml + @"<column id=""field0023"" type=""0"" name=""渠道介绍-f"" length=""255""/>";
            //xml = xml + @"<column id=""field0035"" type=""0"" name=""渠道介绍-新"" length=""255""/>";
            //xml = xml + @"<column id=""field0036"" type=""0"" name=""域29"" length=""255""/>";
            //xml = xml + @"</definitions>";
            //xml = xml + @"<values>";
            //xml = xml + @"<column name=""新增公司名称"">";
            //xml = xml + @"<value><![CDATA[" + model.MC + "]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""开票性质"">";
            //xml = xml + @"<value><![CDATA[" + model.JPXZ + "]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""公司联系人"">";
            //xml = xml + @"<value><![CDATA[" + model.GSLXR + "]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""公司联系电话"">";
            //xml = xml + @"<value><![CDATA[" + model.GSLXDH + "]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""开票地址"">";
            //xml = xml + @"<value><![CDATA[" + model.KPDZ + "]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""公司法人"">";
            //xml = xml + @"<value><![CDATA[" + model.FR + "]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""公司联系人与法人关系"">";
            //xml = xml + @"<value><![CDATA[" + model.GSFRGX + "]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""开票电话"">";
            //xml = xml + @"<value><![CDATA[" + model.KPDH + "]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""快递寄送地址"">";
            //xml = xml + @"<value><![CDATA[" + model.KDJSDZ + "]]></value>";
            //xml = xml + @"</column>";
            // lxd_dh = model.KDLXR + "-" + model.KDLXDH;
            //xml = xml + @"<column name=""联系人-电话"">";
            //xml = xml + @"<value><![CDATA[" + lxd_dh + "]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""纳税人识别号"">";
            //xml = xml + @"<value><![CDATA[" + model.NSRSBH + "]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""合同销售任务"">";
            //xml = xml + @"<value><![CDATA[" + model.HTXSRW + "]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""合同碱性销售任务"">";
            //xml = xml + @"<value><![CDATA[" + model.HTXSRW + "]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""银行账号"">";
            //xml = xml + @"<value><![CDATA[" + model.YHZH + "]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""销售数据说明"">";
            //xml = xml + @"<value><![CDATA[" + model.XSSJSM + "]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""是否出厂价"">";
            //xml = xml + @"<value><![CDATA[" + model.SFCCJ + "]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""银行名称"">";
            //xml = xml + @"<value><![CDATA[" + model.YHMC + "]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""管辖区域"">";
            //xml = xml + @"<value><![CDATA[" + model.GXQY + "]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""客户收货地址"">";
            //xml = xml + @"<value><![CDATA[" + model.KHSHDZ + "]]></value>";
            //xml = xml + @"</column>";
            // lxr2 = model.KHSHLXR + "-" + model.KHSHLXDH;
            //xml = xml + @"<column name=""联系人及电话"">";
            //xml = xml + @"<value><![CDATA[" + lxr2 + "]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""特殊情况说明"">";
            //xml = xml + @"<value><![CDATA[" + model.TSQKSM + "]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""批发"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""直销"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""其他"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""说明"">";
            //xml = xml + @"<value><![CDATA[" + model.YXSM + "]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""负责业务员"">";
            //xml = xml + @"<value><![CDATA[" + model.STAFFNAME + "]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""管辖区域2"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""分管领导意见"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""销售总监意见"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""域28-f"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""渠道不同-f"">";
            //xml = xml + @"<value><![CDATA[0]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""区域冲突-f"">";
            //xml = xml + @"<value><![CDATA[0]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""是否"">";
            //xml = xml + @"<value><![CDATA[" + model.JXSYX + "]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""渠道介绍-f"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""渠道介绍-新"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""域29"">";
            //xml = xml + @"<value><![CDATA[" + model.QD + "]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"</values>";
            //xml = xml + @"<subForms/>";
            //xml = xml + @"</formExport>";

            return xml;
        }

        public string XML_KH_ZDWD(CRM_OA_KH model)
        {
            string xml = "";
            xml = xml + @" <formExport version=""2.0"">";
            xml = xml + @"<summary id="""" name=""formmain_1861""/>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0001"" type=""0"" name=""分管领导"" length=""255""/>";
            xml = xml + @"<column id=""field0002"" type=""3"" name=""日期"" length=""255""/>";
            xml = xml + @"<column id=""field0020"" type=""3"" name=""填写日期"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            xml = xml + @"<column name=""分管领导"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""日期"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""填写日期"">";
            xml = xml + @"<value><![CDATA[" + model.TXRQ + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"</values>";
            xml = xml + @"<subForms>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0003"" type=""0"" name=""业务员"" length=""255""/>";
            xml = xml + @"<column id=""field0004"" type=""0"" name=""省份"" length=""255""/>";
            xml = xml + @"<column id=""field0005"" type=""0"" name=""城市"" length=""255""/>";
            xml = xml + @"<column id=""field0006"" type=""0"" name=""主控网点名称"" length=""255""/>";
            xml = xml + @"<column id=""field0007"" type=""0"" name=""地址"" length=""255""/>";
            xml = xml + @"<column id=""field0008"" type=""0"" name=""联系人"" length=""255""/>";
            xml = xml + @"<column id=""field0009"" type=""0"" name=""联系电话"" length=""255""/>";
            xml = xml + @"<column id=""field0010"" type=""0"" name=""网点类型"" length=""255""/>";
            xml = xml + @"<column id=""field0011"" type=""0"" name=""直销商"" length=""255""/>";
            xml = xml + @"<column id=""field0012"" type=""0"" name=""碱性5号"" length=""5""/>";
            xml = xml + @"<column id=""field0013"" type=""0"" name=""碱性7号"" length=""5""/>";
            xml = xml + @"<column id=""field0015"" type=""0"" name=""其它"" length=""5""/>";
            xml = xml + @"<column id=""field0017"" type=""0"" name=""是否标准网点"" length=""255""/>";
            xml = xml + @"<column id=""field0018"" type=""0"" name=""备注"" length=""255""/>";
            xml = xml + @"<column id=""field0019"" type=""0"" name=""竞品名称"" length=""255""/>";
            xml = xml + @"<column id=""field0021"" type=""0"" name=""经销商编号"" length=""255""/>";
            xml = xml + @"<column id=""field0022"" type=""0"" name=""经销商名称"" length=""255""/>";
            xml = xml + @"<column id=""field0023"" type=""0"" name=""门头照片"" length=""255""/>";
            xml = xml + @"<column id=""field0024"" type=""0"" name=""陈列照片"" length=""255""/>";
            xml = xml + @"<column id=""field0025"" type=""0"" name=""部门"" length=""255""/>";
            xml = xml + @"<column id=""field0016"" type=""0"" name=""陈列-旧"" length=""255""/>";
            xml = xml + @"<column id=""field0026"" type=""0"" name=""黑骑士5-7号"" length=""5""/>";
            xml = xml + @"<column id=""field0027"" type=""0"" name=""大号S型"" length=""5""/>";
            xml = xml + @"<column id=""field0028"" type=""0"" name=""陈列-新"" length=""255""/>";
            xml = xml + @"<column id=""field0014"" type=""0"" name=""P型-聚能"" length=""5""/>";
            xml = xml + @"<column id=""field0029"" type=""0"" name=""销售品种"" length=""255""/>";
            xml = xml + @"<column id=""field0030"" type=""0"" name=""产品类型"" length=""255""/>";
            xml = xml + @"<column id=""field0031"" type=""0"" name=""销量"" length=""255""/>";
            xml = xml + @"<column id=""field0032"" type=""0"" name=""说明"" length=""255""/>";
            xml = xml + @"<column id=""field0033"" type=""0"" name=""客户开发时间"" length=""255""/>";
            xml = xml + @"<column id=""field0034"" type=""0"" name=""现有品牌数量"" length=""255""/>";
            xml = xml + @"<column id=""field0035"" type=""0"" name=""活动名称"" length=""255""/>";
            xml = xml + @"<column id=""field0036"" type=""0"" name=""是否"" length=""255""/>";
            xml = xml + @"<column id=""field0037"" type=""0"" name=""是否电子锁"" length=""255""/>";
            xml = xml + @"<column id=""field0038"" type=""0"" name=""首次送货数量"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            foreach (CRM_OA_KH_WD item in model.CRM_OA_KH_subWDList)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""业务员"">";
                xml = xml + @"<value><![CDATA[" + item.STAFFNAME + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""省份"">";
                xml = xml + @"<value><![CDATA[" + item.SF + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""城市"">";
                xml = xml + @"<value><![CDATA[" + item.CS + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""主控网点名称"">";
                xml = xml + @"<value><![CDATA[" + item.MC + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""地址"">";
                xml = xml + @"<value><![CDATA[" + item.MDDZ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""联系人"">";
                xml = xml + @"<value><![CDATA[" + item.GSLXR + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""联系电话"">";
                xml = xml + @"<value><![CDATA[" + item.GSLXDH + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""网点类型"">";
                xml = xml + @"<value><![CDATA[" + item.WDLX + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""直销商"">";
                xml = xml + @"<value><![CDATA[" + item.ZXS + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""碱性5号"">";
                xml = xml + @"<value/>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""碱性7号"">";
                xml = xml + @"<value/>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""其它"">";
                xml = xml + @"<value/>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""是否标准网点"">";
                xml = xml + @"<value><![CDATA[" + item.SFBZWD + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""备注"">";
                xml = xml + @"<value><![CDATA[" + item.BEIZ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""竞品名称"">";
                xml = xml + @"<value><![CDATA[" + item.JPMC + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""经销商编号"">";
                xml = xml + @"<value><![CDATA[" + item.JXSID + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""经销商名称"">";
                xml = xml + @"<value><![CDATA[" + item.JXSMC + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""门头照片"">";
                xml = xml + @"<value><![CDATA[]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""陈列照片"">";
                xml = xml + @"<value/>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""部门"">";
                xml = xml + @"<value/>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""陈列-旧"">";
                xml = xml + @"<value/>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""黑骑士5-7号"">";
                xml = xml + @"<value/>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""大号S型"">";
                xml = xml + @"<value/>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""陈列-新"">";
                xml = xml + @"<value><![CDATA[" + item.CL + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""P型-聚能"">";
                xml = xml + @"<value/>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""销售品种"">";
                xml = xml + @"<value><![CDATA[" + item.XSPZ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""产品类型"">";
                xml = xml + @"<value><![CDATA[" + item.CPLX + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""销量"">";
                xml = xml + @"<value><![CDATA[" + item.XL + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""说明"">";
                xml = xml + @"<value><![CDATA[" + item.SM + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""客户开发时间"">";
                xml = xml + @"<value><![CDATA[" + item.KHZZSJ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""现有品牌数量"">";
                xml = xml + @"<value><![CDATA[" + item.XYPP + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""活动名称"">";
                xml = xml + @"<value><![CDATA[" + item.HDMC + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""是否"">";
                xml = xml + @"<value><![CDATA[" + item.YOUXIAO + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""是否电子锁"">";
                xml = xml + @"<value><![CDATA[" + item.ISDZS + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""首次送货数量"">";
                xml = xml + @"<value><![CDATA[" + item.SHSL + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }
            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"</subForms>";
            xml = xml + @"</formExport>";

            return xml;
        }

        public string XML_KH_LKA(CRM_OA_KH model)
        {
            string xml = "";
            xml = xml + @"<formExport version=""2.0"">";
            xml = xml + @"<summary id="""" name=""formmain_1865""/>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0001"" type=""3"" name=""填写时间"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            xml = xml + @"<column name=""填写时间"">";
            xml = xml + @"<value><![CDATA[" + model.TXRQ + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"</values>";
            xml = xml + @"<subForms>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0002"" type=""0"" name=""业务员"" length=""255""/>";
            xml = xml + @"<column id=""field0003"" type=""0"" name=""经销商编号"" length=""255""/>";
            xml = xml + @"<column id=""field0004"" type=""0"" name=""经销商名称"" length=""255""/>";
            xml = xml + @"<column id=""field0005"" type=""0"" name=""卖场名称"" length=""255""/>";
            xml = xml + @"<column id=""field0006"" type=""4"" name=""门店进场数量"" length=""20""/>";
            xml = xml + @"<column id=""field0007"" type=""0"" name=""卖场总部地址"" length=""255""/>";
            xml = xml + @"<column id=""field0008"" type=""0"" name=""门店名称"" length=""255""/>";
            xml = xml + @"<column id=""field0011"" type=""0"" name=""门店地址"" length=""255""/>";
            xml = xml + @"<column id=""field0012"" type=""4"" name=""进场单品数量"" length=""20""/>";
            xml = xml + @"<column id=""field0013"" type=""0"" name=""双鹿销售主要品种"" length=""255""/>";
            xml = xml + @"<column id=""field0014"" type=""0"" name=""竞品"" length=""255""/>";
            xml = xml + @"<column id=""field0015"" type=""0"" name=""主陈列方式"" length=""255""/>";
            xml = xml + @"<column id=""field0016"" type=""0"" name=""陈列照片"" length=""255""/>";
            xml = xml + @"<column id=""field0017"" type=""0"" name=""备注"" length=""255""/>";
            xml = xml + @"<column id=""field0018"" type=""0"" name=""二次陈列方式"" length=""255""/>";
            xml = xml + @"<column id=""field0019"" type=""0"" name=""卖场归属年份"" length=""255""/>";
            xml = xml + @"<column id=""field0020"" type=""3"" name=""登记时间"" length=""255""/>";
            xml = xml + @"<column id=""field0021"" type=""0"" name=""城市"" length=""255""/>";
            xml = xml + @"<column id=""field0022"" type=""0"" name=""省份"" length=""255""/>";
            xml = xml + @"<column id=""field0023"" type=""0"" name=""分管领导"" length=""255""/>";
            xml = xml + @"<column id=""field0024"" type=""0"" name=""抽查人员"" length=""255""/>";
            xml = xml + @"<column id=""field0025"" type=""0"" name=""抽查情况"" length=""255""/>";
            xml = xml + @"<column id=""field0026"" type=""3"" name=""抽查时间"" length=""255""/>";
            xml = xml + @"<column id=""field0027"" type=""0"" name=""备注二"" length=""255""/>";
            xml = xml + @"<column id=""field0010"" type=""0"" name=""xxx"" length=""255""/>";
            xml = xml + @"<column id=""field0028"" type=""0"" name=""部门"" length=""255""/>";
            xml = xml + @"<column id=""field0009"" type=""0"" name=""门店类型"" length=""255""/>";
            xml = xml + @"<column id=""field0029"" type=""0"" name=""销量"" length=""255""/>";
            xml = xml + @"<column id=""field0030"" type=""0"" name=""说明"" length=""255""/>";
            xml = xml + @"<column id=""field0031"" type=""0"" name=""客户开发时间"" length=""255""/>";
            xml = xml + @"<column id=""field0032"" type=""0"" name=""是否"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            foreach (CRM_OA_KH_LKA item in model.CRM_OA_KH_LKAList)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""业务员"">";
                xml = xml + @"<value><![CDATA[" + item.STAFFNAME + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""经销商编号"">";
                xml = xml + @"<value><![CDATA[" + item.JXSID + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""经销商名称"">";
                xml = xml + @"<value><![CDATA[" + item.JXSMC + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""卖场名称"">";
                xml = xml + @"<value><![CDATA[" + item.PKHMC + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""门店进场数量"">";
                xml = xml + @"<value><![CDATA[" + item.MDJCSL + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""卖场总部地址"">";
                xml = xml + @"<value><![CDATA[" + item.ZBDZ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""门店名称"">";
                xml = xml + @"<value><![CDATA[" + item.MC + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""门店地址"">";
                xml = xml + @"<value><![CDATA[" + item.MDDZ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""进场单品数量"">";
                xml = xml + @"<value><![CDATA[" + item.JCDPSL + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""双鹿销售主要品种"">";
                xml = xml + @"<value><![CDATA[" + item.XSSJSM + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""竞品"">";
                xml = xml + @"<value><![CDATA[" + item.JP + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""主陈列方式"">";
                xml = xml + @"<value><![CDATA[" + item.ZCL + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""陈列照片"">";
                xml = xml + @"<value><![CDATA[7204318734045560412]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""备注"">";
                xml = xml + @"<value><![CDATA[" + item.BEIZ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""二次陈列方式"">";
                xml = xml + @"<value><![CDATA[" + item.ECCL + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""卖场归属年份"">";
                xml = xml + @"<value/>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""登记时间"">";
                xml = xml + @"<value/>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""城市"">";
                xml = xml + @"<value/>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""省份"">";
                xml = xml + @"<value/>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""分管领导"">";
                xml = xml + @"<value/>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""抽查人员"">";
                xml = xml + @"<value/>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""抽查情况"">";
                xml = xml + @"<value/>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""抽查时间"">";
                xml = xml + @"<value/>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""备注二"">";
                xml = xml + @"<value/>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""xxx"">";
                xml = xml + @"<value/>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""部门"">";
                xml = xml + @"<value/>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""门店类型"">";
                xml = xml + @"<value><![CDATA[" + item.MCLC + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""销量"">";
                xml = xml + @"<value><![CDATA[" + item.XL + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""说明"">";
                xml = xml + @"<value><![CDATA[" + item.SM + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @" <column name=""客户开发时间"">";
                xml = xml + @"<value><![CDATA[" + item.KHZZSJ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""是否"">";
                xml = xml + @"<value><![CDATA[" + item.YOUXIAO + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }
            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"</subForms>";
            xml = xml + @"</formExport>";

            return xml;
        }

        public string XML_KH_ZXS(CRM_OA_KH KH_model)
        {
            CRM_OA_KH_ZXS model = KH_model.CRM_OA_KH_ZXS;
            string xml = "";
            xml = xml + @"<formExport version=""2.0"">";
            xml = xml + @"<summary id="""" name=""formmain_1874""/>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0001"" type=""0"" name=""省份"" length=""255""/>";
            xml = xml + @"<column id=""field0006"" type=""0"" name=""直销区域"" length=""255""/>";
            xml = xml + @"<column id=""field0007"" type=""0"" name=""联系人"" length=""255""/>";
            xml = xml + @"<column id=""field0008"" type=""4"" name=""联系电话"" length=""20""/>";
            xml = xml + @"<column id=""field0010"" type=""4"" name=""上年度网点数量"" length=""20""/>";
            xml = xml + @"<column id=""field0011"" type=""4"" name=""本年度目标网点数量"" length=""20""/>";
            xml = xml + @"<column id=""field0012"" type=""0"" name=""备案"" length=""255""/>";
            xml = xml + @"<column id=""field0013"" type=""0"" name=""客户编号"" length=""255""/>";
            xml = xml + @"<column id=""field0014"" type=""0"" name=""经销商名称"" length=""255""/>";
            xml = xml + @"<column id=""field0015"" type=""4"" name=""经销商-上年度销售"" length=""20""/>";
            xml = xml + @"<column id=""field0016"" type=""4"" name=""经销商-上年度A类销售"" length=""20""/>";
            xml = xml + @"<column id=""field0017"" type=""4"" name=""经销商-本年度销售任务"" length=""20""/>";
            xml = xml + @"<column id=""field0026"" type=""0"" name=""中间商类型"" length=""255""/>";
            xml = xml + @"<column id=""field0005"" type=""4"" name=""中间-上年度A类销售"" length=""20""/>";
            xml = xml + @"<column id=""field0004"" type=""4"" name=""中间-上年度碱性销售"" length=""20""/>";
            xml = xml + @"<column id=""field0002"" type=""0"" name=""中间商名称"" length=""255""/>";
            xml = xml + @"<column id=""field0009"" type=""0"" name=""中间商办公地址"" length=""255""/>";
            xml = xml + @"<column id=""field0003"" type=""4"" name=""中间-上年度销售"" length=""20""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            xml = xml + @"<column name=""省份"">";
            xml = xml + @"<value><![CDATA[" + model.SF + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""直销区域"">";
            xml = xml + @"<value><![CDATA[" + model.AREA + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""联系人"">";
            xml = xml + @"<value><![CDATA[" + model.GSLXR + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""联系电话"">";
            xml = xml + @"<value><![CDATA[" + model.GSLXDH + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""上年度网点数量"">";
            xml = xml + @"<value><![CDATA[" + model.WDSL + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""本年度目标网点数量"">";
            xml = xml + @"<value><![CDATA[" + model.MBWDSL + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""备案"">";
            xml = xml + @"<value><![CDATA[" + model.BEIZ + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""客户编号"">";
            xml = xml + @"<value><![CDATA[" + model.JXSID + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""经销商名称"">";
            xml = xml + @"<value><![CDATA[" + model.JXSMC + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""经销商-上年度销售"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""经销商-上年度A类销售"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""经销商-本年度销售任务"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""中间商类型"">";
            xml = xml + @"<value><![CDATA[" + KH_model.KHLX2 + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""中间-上年度A类销售"">";
            xml = xml + @"<value><![CDATA[" + model.AXS + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""中间-上年度碱性销售"">";
            xml = xml + @"<value><![CDATA[" + model.JXXS + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""中间商名称"">";
            xml = xml + @"<value><![CDATA[" + model.MC + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""中间商办公地址"">";
            xml = xml + @"<value><![CDATA[" + model.MDDZ + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""中间-上年度销售"">";
            xml = xml + @"<value><![CDATA[" + model.XS + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"</values>";
            xml = xml + @"<subForms>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0018"" type=""0"" name=""车牌"" length=""255""/>";
            xml = xml + @"<column id=""field0019"" type=""0"" name=""是否有双鹿字样的车体广告"" length=""255""/>";
            xml = xml + @"<column id=""field0020"" type=""0"" name=""照片"" length=""255""/>";
            xml = xml + @"<column id=""field0027"" type=""0"" name=""照片-新"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            foreach (var item in model.TABLE1List)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""车牌"">";
                xml = xml + @"<value><![CDATA[" + item.CHEPAI + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""是否有双鹿字样的车体广告"">";
                xml = xml + @"<value><![CDATA[" + item.AD + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""照片"">";
                xml = xml + @"<value><![CDATA[" + item.ZP + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""照片-新"">";
                xml = xml + @"<value><![CDATA[" + item.ZP + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }
            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0021"" type=""0"" name=""人员姓名"" length=""255""/>";
            xml = xml + @"<column id=""field0022"" type=""4"" name=""联系方式"" length=""20""/>";
            xml = xml + @"<column id=""field0023"" type=""0"" name=""工作内容"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            foreach (var item in model.TABLE2List)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""人员姓名"">";
                xml = xml + @"<value><![CDATA[" + item.KHSTAFF + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""联系方式"">";
                xml = xml + @"<value><![CDATA[" + item.TEL + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""工作内容"">";
                xml = xml + @"<value><![CDATA[" + item.GZNR + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }
            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0024"" type=""0"" name=""单品名称"" length=""255""/>";
            xml = xml + @"<column id=""field0025"" type=""0"" name=""是否与LKA渠道重叠"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            foreach (var item in model.TABLE3List)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""单品名称"">";
                xml = xml + @"<value><![CDATA[" + item.DPMC + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""是否与LKA渠道重叠"">";
                xml = xml + @"<value><![CDATA[" + item.CD + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }
            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"</subForms>";
            xml = xml + @"</formExport>";

            return xml;
        }

        public string XML_YCKQSM(CRM_OA_YCKQSM model)
        {
            string xml = "";
            xml = xml + @"<formExport version=""2.0"">";
            xml = xml + @"<summary id="""" name=""formmain_1879""/>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0001"" type=""0"" name=""人员"" length=""255""/>";
            xml = xml + @"<column id=""field0002"" type=""0"" name=""部门"" length=""255""/>";
            xml = xml + @"<column id=""field0006"" type=""0"" name=""实际签到时间"" length=""255""/>";
            xml = xml + @"<column id=""field0007"" type=""0"" name=""实际签到地址"" length=""255""/>";
            xml = xml + @"<column id=""field0008"" type=""0"" name=""距离"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            xml = xml + @"<column name=""人员"">";
            xml = xml + @"<value><![CDATA[" + model.STAFFNAME + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""部门"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""实际签到时间"">";
            xml = xml + @"<value><![CDATA[" + model.QDSJ + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""实际签到地址"">";
            xml = xml + @"<value><![CDATA[" + model.QDWZ + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""距离"">";
            xml = xml + @"<value><![CDATA[" + model.KQJL + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"</values>";
            xml = xml + @"<subForms>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0003"" type=""0"" name=""说明日期"" length=""255""/>";
            xml = xml + @"<column id=""field0004"" type=""0"" name=""上下班"" length=""255""/>";
            xml = xml + @"<column id=""field0005"" type=""0"" name=""情况说明"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            foreach (SMTABLE item in model.SMTABLEList)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""说明日期"">";
                xml = xml + @"<value><![CDATA[" + item.SMRQ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""上下班"">";
                xml = xml + @"<value><![CDATA[" + item.SMSXB + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""情况说明"">";
                xml = xml + @"<value><![CDATA[" + item.SMSX + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }
            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"</subForms>";
            xml = xml + @"</formExport>";
            return xml;
        }

        public string XML_ZDF(CRM_OA_ZDF model)
        {
            string xml = "";
            xml = xml + @"<formExport version=""2.0"">";
            xml = xml + @"<summary id="""" name=""formmain_1915""/>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0001"" type=""0"" name=""申请时间"" length=""255""/>";
            xml = xml + @"<column id=""field0002"" type=""0"" name=""申请人"" length=""255""/>";
            xml = xml + @"<column id=""field0003"" type=""0"" name=""申请部门"" length=""255""/>";
            xml = xml + @"<column id=""field0004"" type=""0"" name=""招待日期"" length=""255""/>";
            xml = xml + @"<column id=""field0005"" type=""0"" name=""客户名称"" length=""255""/>";
            xml = xml + @"<column id=""field0006"" type=""0"" name=""客户姓名"" length=""255""/>";
            xml = xml + @"<column id=""field0007"" type=""4"" name=""接待人数"" length=""20""/>";
            xml = xml + @"<column id=""field0008"" type=""4"" name=""陪客人数"" length=""20""/>";
            xml = xml + @"<column id=""field0009"" type=""1"" name=""招待事由"" length=""255""/>";
            xml = xml + @"<column id=""field0010"" type=""0"" name=""金额小写"" length=""255""/>";
            xml = xml + @"<column id=""field0011"" type=""0"" name=""金额大写"" length=""255""/>";
            xml = xml + @"<column id=""field0012"" type=""1"" name=""审批意见"" length=""255""/>";
            xml = xml + @"<column id=""field0013"" type=""0"" name=""流程编号"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            xml = xml + @"<column name=""申请时间"">";
            xml = xml + @"<value><![CDATA[" + model.SQSJ + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""申请人"">";
            xml = xml + @"<value><![CDATA[" + model.STAFFNAME + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""申请部门"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""招待日期"">";
            xml = xml + @"<value><![CDATA[" + model.ZDRQ + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""客户名称"">";
            xml = xml + @"<value><![CDATA[" + model.KHNAME + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""客户姓名"">";
            xml = xml + @"<value><![CDATA[" + model.KHMX + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""接待人数"">";
            xml = xml + @"<value><![CDATA[" + model.JDRS + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""陪客人数"">";
            xml = xml + @"<value><![CDATA[" + model.PKRS + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""招待事由"">";
            xml = xml + @"<value><![CDATA[" + model.ZDLY + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""金额小写"">";
            xml = xml + @"<value><![CDATA[" + model.YJJE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""金额大写"">";
            xml = xml + @"<value><![CDATA[" + model.YJJE_CN + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""审批意见"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""流程编号"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"</values>";
            xml = xml + @"<subForms/>";
            xml = xml + @"</formExport>";
            return xml;
        }

        public string XML_LKAYEAR(CRM_OA_LKAYEAR model)
        {
            string xml = "";
            xml = xml + @"<formExport version=""2.0"">";
            xml = xml + @"<summary id="""" name=""formmain_2482""/>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0001"" type=""0"" name=""归属年份"" length=""255""/>";
            xml = xml + @"<column id=""field0002"" type=""0"" name=""申请人"" length=""255""/>";
            xml = xml + @"<column id=""field0003"" type=""0"" name=""申请日期"" length=""255""/>";
            xml = xml + @"<column id=""field0004"" type=""0"" name=""最后修改日期"" length=""255""/>";
            xml = xml + @"<column id=""field0005"" type=""0"" name=""经销客户名称"" length=""255""/>";
            xml = xml + @"<column id=""field0006"" type=""0"" name=""经销客户编号"" length=""255""/>";
            xml = xml + @"<column id=""field0007"" type=""0"" name=""LKA系统CRM编号"" length=""255""/>";
            xml = xml + @"<column id=""field0008"" type=""4"" name=""合计1"" length=""20""/>";
            xml = xml + @"<column id=""field0009"" type=""4"" name=""合计2"" length=""20""/>";
            xml = xml + @"<column id=""field0010"" type=""0"" name=""合计3"" length=""255""/>";
            xml = xml + @"<column id=""field0011"" type=""0"" name=""提交次数"" length=""255""/>";
            xml = xml + @"<column id=""field0012"" type=""0"" name=""卖场名称"" length=""255""/>";
            xml = xml + @"<column id=""field0013"" type=""0"" name=""合同起止日期-起"" length=""255""/>";
            xml = xml + @"<column id=""field0014"" type=""0"" name=""合同起止日期-止"" length=""255""/>";
            xml = xml + @"<column id=""field0015"" type=""0"" name=""归属年度月份总数"" length=""255""/>";
            xml = xml + @"<column id=""field0016"" type=""0"" name=""首次进场时间"" length=""255""/>";
            xml = xml + @"<column id=""field0017"" type=""0"" name=""配送情况"" length=""255""/>";
            xml = xml + @"<column id=""field0018"" type=""0"" name=""辐射范围"" length=""255""/>";
            xml = xml + @"<column id=""field0019"" type=""0"" name=""经营方式"" length=""255""/>";
            xml = xml + @"<column id=""field0020"" type=""0"" name=""结款方式"" length=""255""/>";
            xml = xml + @"<column id=""field0021"" type=""0"" name=""竞争品牌名称"" length=""255""/>";
            xml = xml + @"<column id=""field0022"" type=""0"" name=""南孚供货商"" length=""255""/>";
            xml = xml + @"<column id=""field0023"" type=""0"" name=""南孚陈列方式"" length=""255""/>";
            xml = xml + @"<column id=""field0024"" type=""0"" name=""南孚陈列占比"" length=""255""/>";
            xml = xml + @"<column id=""field0025"" type=""0"" name=""卖场接洽人名称"" length=""255""/>";
            xml = xml + @"<column id=""field0026"" type=""0"" name=""接洽人职务"" length=""255""/>";
            xml = xml + @"<column id=""field0027"" type=""0"" name=""接洽人电话"" length=""255""/>";
            xml = xml + @"<column id=""field0028"" type=""0"" name=""经销商除供双鹿外是否供其他产品"" length=""255""/>";
            xml = xml + @"<column id=""field0029"" type=""0"" name=""是否新进卖场"" length=""255""/>";
            xml = xml + @"<column id=""field0030"" type=""0"" name=""是否直接与公司签订合同"" length=""255""/>";
            xml = xml + @"<column id=""field0031"" type=""0"" name=""KA管辖的LKA"" length=""255""/>";
            xml = xml + @"<column id=""field0032"" type=""0"" name=""销售变化原因说明"" length=""255""/>";
            xml = xml + @"<column id=""field0033"" type=""0"" name=""卖场销售数据来源"" length=""255""/>";
            xml = xml + @"<column id=""field0034"" type=""0"" name=""卖场费用扣款来源"" length=""255""/>";
            xml = xml + @"<column id=""field0035"" type=""0"" name=""卖场网址"" length=""255""/>";
            xml = xml + @"<column id=""field0036"" type=""0"" name=""账号密码"" length=""255""/>";
            xml = xml + @"<column id=""field0037"" type=""4"" name=""合计4"" length=""20""/>";
            xml = xml + @"<column id=""field0038"" type=""4"" name=""合计5"" length=""20""/>";
            xml = xml + @"<column id=""field0039"" type=""0"" name=""合计6"" length=""255""/>";
            xml = xml + @"<column id=""field0040"" type=""0"" name=""上年度实际费用-返利-合同条款内容"" length=""255""/>";
            xml = xml + @"<column id=""field0041"" type=""4"" name=""上年度实际费用-返利-实际费用金额"" length=""20""/>";
            xml = xml + @"<column id=""field0042"" type=""0"" name=""本年度预估费用-返利-合同条款内容"" length=""255""/>";
            xml = xml + @"<column id=""field0043"" type=""4"" name=""本年度预估费用-返利-费用预估额"" length=""20""/>";
            xml = xml + @"<column id=""field0044"" type=""4"" name=""返利-历史数据"" length=""20""/>";
            xml = xml + @"<column id=""field0045"" type=""0"" name=""返利-同比增减"" length=""255""/>";
            xml = xml + @"<column id=""field0046"" type=""0"" name=""返利-费用增加原因"" length=""255""/>";
            xml = xml + @"<column id=""field0047"" type=""0"" name=""返利-费用是否体现在合同条款内"" length=""255""/>";
            xml = xml + @"<column id=""field0048"" type=""0"" name=""上年度实际费用-信息服务费-合同条款内容"" length=""255""/>";
            xml = xml + @"<column id=""field0049"" type=""4"" name=""上年度实际费用-信息服务费-实际费用金额"" length=""20""/>";
            xml = xml + @"<column id=""field0050"" type=""0"" name=""本年度预估费用-信息服务费-合同条款内容"" length=""255""/>";
            xml = xml + @"<column id=""field0051"" type=""4"" name=""本年度预估费用-信息服务费-费用预估额"" length=""20""/>";
            xml = xml + @"<column id=""field0052"" type=""4"" name=""信息服务费-历史数据"" length=""20""/>";
            xml = xml + @"<column id=""field0053"" type=""0"" name=""信息服务费-同比增减"" length=""255""/>";
            xml = xml + @"<column id=""field0054"" type=""0"" name=""信息服务费-费用增加原因"" length=""255""/>";
            xml = xml + @"<column id=""field0055"" type=""0"" name=""信息服务费-费用是否提现在合同条款内"" length=""255""/>";
            xml = xml + @"<column id=""field0056"" type=""0"" name=""上年度实际费用-其他-合同条款内容"" length=""255""/>";
            xml = xml + @"<column id=""field0057"" type=""4"" name=""上年度实际费用-其他-实际费用金额"" length=""20""/>";
            xml = xml + @"<column id=""field0058"" type=""0"" name=""本年度预估费用-其他-合同条款内容"" length=""255""/>";
            xml = xml + @"<column id=""field0059"" type=""4"" name=""本年度预估费用-其他-费用预估额"" length=""20""/>";
            xml = xml + @"<column id=""field0060"" type=""4"" name=""其他-历史数据"" length=""20""/>";
            xml = xml + @"<column id=""field0061"" type=""0"" name=""其他-同比增减"" length=""255""/>";
            xml = xml + @"<column id=""field0062"" type=""0"" name=""其他-费用增加原因"" length=""255""/>";
            xml = xml + @"<column id=""field0063"" type=""0"" name=""其他-费用是否体现在合同条款内"" length=""255""/>";
            xml = xml + @"<column id=""field0064"" type=""0"" name=""费用小计A1"" length=""255""/>";
            xml = xml + @"<column id=""field0065"" type=""4"" name=""费用小计A2"" length=""20""/>";
            xml = xml + @"<column id=""field0066"" type=""0"" name=""费用小计A3"" length=""255""/>";
            xml = xml + @"<column id=""field0067"" type=""4"" name=""费用小计A4"" length=""20""/>";
            xml = xml + @"<column id=""field0068"" type=""4"" name=""费用小计A5"" length=""20""/>";
            xml = xml + @"<column id=""field0069"" type=""0"" name=""费用小计A6"" length=""255""/>";
            xml = xml + @"<column id=""field0070"" type=""0"" name=""费用小计A7"" length=""255""/>";
            xml = xml + @"<column id=""field0071"" type=""0"" name=""费用小计A8"" length=""255""/>";
            xml = xml + @"<column id=""field0072"" type=""0"" name=""上年度实际费用-进场费-合同条款内容"" length=""255""/>";
            xml = xml + @"<column id=""field0073"" type=""4"" name=""上年度实际费用-进场费-实际费用金额"" length=""20""/>";
            xml = xml + @"<column id=""field0074"" type=""0"" name=""本年度预估费用-进场费-合同条款内容"" length=""255""/>";
            xml = xml + @"<column id=""field0075"" type=""4"" name=""本年度预估费用-进场费-费用预估额"" length=""20""/>";
            xml = xml + @"<column id=""field0076"" type=""4"" name=""进场费-历史数据"" length=""20""/>";
            xml = xml + @"<column id=""field0077"" type=""0"" name=""进场费-同比增减"" length=""255""/>";
            xml = xml + @"<column id=""field0078"" type=""0"" name=""进场费-费用增加原因"" length=""255""/>";
            xml = xml + @"<column id=""field0079"" type=""0"" name=""进场费-费用是否体现在合同条款内"" length=""255""/>";
            xml = xml + @"<column id=""field0080"" type=""0"" name=""上年度实际费用-新品费-合同条款内容"" length=""255""/>";
            xml = xml + @"<column id=""field0081"" type=""4"" name=""上年度实际费用-新品费-实际费用金额"" length=""20""/>";
            xml = xml + @"<column id=""field0082"" type=""0"" name=""本年度预估费用-新品费-合同条款内容"" length=""255""/>";
            xml = xml + @"<column id=""field0083"" type=""4"" name=""本年度预估费用-新品费-费用预估额"" length=""20""/>";
            xml = xml + @"<column id=""field0084"" type=""4"" name=""新品费-历史数据"" length=""20""/>";
            xml = xml + @"<column id=""field0085"" type=""0"" name=""新品费-同比增减"" length=""255""/>";
            xml = xml + @"<column id=""field0086"" type=""0"" name=""新品费-费用增加原因"" length=""255""/>";
            xml = xml + @"<column id=""field0087"" type=""0"" name=""新品费-费用是否体现在合同条款内"" length=""255""/>";
            xml = xml + @"<column id=""field0088"" type=""0"" name=""上年度实际费用-合同续签费-合同条款内容"" length=""255""/>";
            xml = xml + @"<column id=""field0089"" type=""4"" name=""上年度实际费用-合同续签费-实际费用金额"" length=""20""/>";
            xml = xml + @"<column id=""field0090"" type=""0"" name=""本年度预估费用-合同续签费-合同条款内容"" length=""255""/>";
            xml = xml + @"<column id=""field0091"" type=""4"" name=""本年度预估费用-合同续签费-费用预估额"" length=""20""/>";
            xml = xml + @"<column id=""field0092"" type=""4"" name=""合同续签费-历史数据"" length=""20""/>";
            xml = xml + @"<column id=""field0093"" type=""0"" name=""合同续签费-同比增减"" length=""255""/>";
            xml = xml + @"<column id=""field0094"" type=""0"" name=""合同续签费-费用增加原因"" length=""255""/>";
            xml = xml + @"<column id=""field0095"" type=""0"" name=""合同续签费-费用是否体现在合同条款内"" length=""255""/>";
            xml = xml + @"<column id=""field0096"" type=""0"" name=""上年度实际费用-店节庆周年庆-合同条款内容"" length=""255""/>";
            xml = xml + @"<column id=""field0097"" type=""4"" name=""上年度实际费用-店节庆周年庆-实际费用金额"" length=""20""/>";
            xml = xml + @"<column id=""field0098"" type=""0"" name=""本年度预估费用-店节庆周年庆-合同条款内容"" length=""255""/>";
            xml = xml + @"<column id=""field0099"" type=""4"" name=""本年度预估费用-店节庆周年庆-费用预估额"" length=""20""/>";
            xml = xml + @"<column id=""field0100"" type=""4"" name=""店节庆周年庆-历史数据"" length=""20""/>";
            xml = xml + @"<column id=""field0101"" type=""0"" name=""店节庆周年庆-同比增减"" length=""255""/>";
            xml = xml + @"<column id=""field0102"" type=""0"" name=""店节庆周年庆-费用增加原因"" length=""255""/>";
            xml = xml + @"<column id=""field0103"" type=""0"" name=""店节庆周年庆-费用是否体现在合同条款内"" length=""255""/>";
            xml = xml + @"<column id=""field0104"" type=""0"" name=""上年度实际费用-新店开业费-合同条款内容"" length=""255""/>";
            xml = xml + @"<column id=""field0105"" type=""4"" name=""上年度实际费用-新店开业费-实际费用金额"" length=""20""/>";
            xml = xml + @"<column id=""field0106"" type=""0"" name=""本年度预估费用-新店开业费-合同条款内容"" length=""255""/>";
            xml = xml + @"<column id=""field0107"" type=""4"" name=""本年度预估费用-新店开业费-费用预估额"" length=""20""/>";
            xml = xml + @"<column id=""field0108"" type=""4"" name=""新店开业费-历史数据"" length=""20""/>";
            xml = xml + @"<column id=""field0109"" type=""0"" name=""新店开业费-同比增减"" length=""255""/>";
            xml = xml + @"<column id=""field0110"" type=""0"" name=""新店开业费-费用增加原因"" length=""255""/>";
            xml = xml + @"<column id=""field0111"" type=""0"" name=""新店开业费-费用是否体现在合同条款内"" length=""255""/>";
            xml = xml + @"<column id=""field0112"" type=""0"" name=""上年度实际费用-陈列费-合同条款内容"" length=""255""/>";
            xml = xml + @"<column id=""field0113"" type=""4"" name=""上年度实际费用-陈列费-实际费用金额"" length=""20""/>";
            xml = xml + @"<column id=""field0114"" type=""0"" name=""本年度预估费用-陈列费-合同条款内容"" length=""255""/>";
            xml = xml + @"<column id=""field0115"" type=""4"" name=""本年度预估费用-陈列费-费用预估额"" length=""20""/>";
            xml = xml + @"<column id=""field0116"" type=""4"" name=""陈列费-历史数据"" length=""20""/>";
            xml = xml + @"<column id=""field0117"" type=""0"" name=""陈列费-同比增减"" length=""255""/>";
            xml = xml + @"<column id=""field0118"" type=""0"" name=""陈列费-费用增加原因"" length=""255""/>";
            xml = xml + @"<column id=""field0119"" type=""0"" name=""陈列费-费用是否体现在合同条款内"" length=""255""/>";
            xml = xml + @"<column id=""field0120"" type=""0"" name=""费用小计B1"" length=""255""/>";
            xml = xml + @"<column id=""field0121"" type=""4"" name=""费用小计B2"" length=""20""/>";
            xml = xml + @"<column id=""field0122"" type=""0"" name=""费用小计B3"" length=""255""/>";
            xml = xml + @"<column id=""field0123"" type=""4"" name=""费用小计B4"" length=""20""/>";
            xml = xml + @"<column id=""field0124"" type=""4"" name=""费用小计B5"" length=""20""/>";
            xml = xml + @"<column id=""field0125"" type=""0"" name=""费用小计B6"" length=""255""/>";
            xml = xml + @"<column id=""field0126"" type=""0"" name=""费用小计B7"" length=""255""/>";
            xml = xml + @"<column id=""field0127"" type=""0"" name=""费用小计B8"" length=""255""/>";
            xml = xml + @"<column id=""field0128"" type=""0"" name=""合同费用合计AB1"" length=""255""/>";
            xml = xml + @"<column id=""field0129"" type=""4"" name=""合同费用合计AB2"" length=""20""/>";
            xml = xml + @"<column id=""field0130"" type=""0"" name=""合同费用合计AB3"" length=""255""/>";
            xml = xml + @"<column id=""field0131"" type=""4"" name=""合同费用合计AB4"" length=""20""/>";
            xml = xml + @"<column id=""field0132"" type=""4"" name=""合同费用合计AB5"" length=""20""/>";
            xml = xml + @"<column id=""field0133"" type=""0"" name=""合同费用合计AB6"" length=""255""/>";
            xml = xml + @"<column id=""field0134"" type=""0"" name=""合同费用合计AB7"" length=""255""/>";
            xml = xml + @"<column id=""field0135"" type=""0"" name=""合同费用合计AB8"" length=""255""/>";
            xml = xml + @"<column id=""field0136"" type=""0"" name=""上年度实际费用-特殊陈列费-合同条款内容"" length=""255""/>";
            xml = xml + @"<column id=""field0137"" type=""4"" name=""上年度实际费用-特殊陈列费-实际费用金额"" length=""20""/>";
            xml = xml + @"<column id=""field0138"" type=""0"" name=""本年度预估费用-特殊陈列费-合同条款内容"" length=""255""/>";
            xml = xml + @"<column id=""field0139"" type=""4"" name=""本年度预估费用-特殊陈列费-费用预估额"" length=""20""/>";
            xml = xml + @"<column id=""field0140"" type=""4"" name=""特殊陈列费-历史数据"" length=""20""/>";
            xml = xml + @"<column id=""field0141"" type=""0"" name=""特殊陈列费-同比增减"" length=""255""/>";
            xml = xml + @"<column id=""field0142"" type=""0"" name=""特殊陈列费-费用增加原因"" length=""255""/>";
            xml = xml + @"<column id=""field0143"" type=""0"" name=""特殊陈列费-费用是否体现在合同条款内"" length=""255""/>";
            xml = xml + @"<column id=""field0144"" type=""0"" name=""上年度实际费用-海报费-合同条款内容"" length=""255""/>";
            xml = xml + @"<column id=""field0145"" type=""4"" name=""上年度实际费用-海报费-实际费用金额"" length=""20""/>";
            xml = xml + @"<column id=""field0146"" type=""0"" name=""本年度预估费用-海报费-合同条款内容"" length=""255""/>";
            xml = xml + @"<column id=""field0147"" type=""4"" name=""本年度预估费用-海报费-费用预估额"" length=""20""/>";
            xml = xml + @"<column id=""field0148"" type=""4"" name=""海报费-历史数据"" length=""20""/>";
            xml = xml + @"<column id=""field0149"" type=""0"" name=""海报费-同比增减"" length=""255""/>";
            xml = xml + @"<column id=""field0150"" type=""0"" name=""海报费-费用增加原因"" length=""255""/>";
            xml = xml + @"<column id=""field0151"" type=""0"" name=""海报费-费用是否体现在合同条款内"" length=""255""/>";
            xml = xml + @"<column id=""field0152"" type=""0"" name=""上年度实际费用-堆头促销费-合同条款内容"" length=""255""/>";
            xml = xml + @"<column id=""field0153"" type=""4"" name=""上年度实际费用-堆头促销费-实际费用金额"" length=""20""/>";
            xml = xml + @"<column id=""field0154"" type=""0"" name=""本年度预估费用-堆头促销费-合同条款内容"" length=""255""/>";
            xml = xml + @"<column id=""field0155"" type=""4"" name=""本年度预估费用-堆头促销费-费用预估额"" length=""20""/>";
            xml = xml + @"<column id=""field0156"" type=""4"" name=""堆头促销费-历史数据"" length=""20""/>";
            xml = xml + @"<column id=""field0157"" type=""0"" name=""堆头促销费-同比增减"" length=""255""/>";
            xml = xml + @"<column id=""field0158"" type=""0"" name=""堆头促销费-费用增加原因"" length=""255""/>";
            xml = xml + @"<column id=""field0159"" type=""0"" name=""堆头促销费-费用是否体现在合同条款内"" length=""255""/>";
            xml = xml + @"<column id=""field0160"" type=""0"" name=""上年度实际费用-其他费用-合同条款内容"" length=""255""/>";
            xml = xml + @"<column id=""field0161"" type=""4"" name=""上年度实际费用-其他费用-实际费用金额"" length=""20""/>";
            xml = xml + @"<column id=""field0162"" type=""0"" name=""本年度预估费用-其他费用-合同条款内容"" length=""255""/>";
            xml = xml + @"<column id=""field0163"" type=""4"" name=""本年度预估费用-其他费用-费用预估额"" length=""20""/>";
            xml = xml + @"<column id=""field0164"" type=""4"" name=""其他费用-历史数据"" length=""20""/>";
            xml = xml + @"<column id=""field0165"" type=""0"" name=""其他费用-同比增减"" length=""255""/>";
            xml = xml + @"<column id=""field0166"" type=""0"" name=""其他费用-费用增加原因"" length=""255""/>";
            xml = xml + @"<column id=""field0167"" type=""0"" name=""其他费用-费用是否体现在合同条款内"" length=""255""/>";
            xml = xml + @"<column id=""field0168"" type=""0"" name=""上年度实际费用-制作费-合同条款内容"" length=""255""/>";
            xml = xml + @"<column id=""field0169"" type=""4"" name=""上年度实际费用-制作费-实际费用金额"" length=""20""/>";
            xml = xml + @"<column id=""field0170"" type=""0"" name=""本年度预估费用-制作费-合同条款内容"" length=""255""/>";
            xml = xml + @"<column id=""field0171"" type=""4"" name=""本年度预估费用-制作费-费用预估额"" length=""20""/>";
            xml = xml + @"<column id=""field0172"" type=""4"" name=""制作费-历史数据"" length=""20""/>";
            xml = xml + @"<column id=""field0173"" type=""0"" name=""制作费-同比增减"" length=""255""/>";
            xml = xml + @"<column id=""field0174"" type=""0"" name=""制作费-费用增加原因"" length=""255""/>";
            xml = xml + @"<column id=""field0175"" type=""0"" name=""制作费-费用是否体现在合同条款内"" length=""255""/>";
            xml = xml + @"<column id=""field0176"" type=""4"" name=""费用小计C1"" length=""20""/>";
            xml = xml + @"<column id=""field0177"" type=""4"" name=""费用小计C2"" length=""20""/>";
            xml = xml + @"<column id=""field0178"" type=""4"" name=""费用小计C3"" length=""20""/>";
            xml = xml + @"<column id=""field0179"" type=""4"" name=""费用小计C4"" length=""20""/>";
            xml = xml + @"<column id=""field0180"" type=""4"" name=""费用小计C5"" length=""20""/>";
            xml = xml + @"<column id=""field0181"" type=""0"" name=""费用小计C6"" length=""255""/>";
            xml = xml + @"<column id=""field0182"" type=""0"" name=""费用小计C7"" length=""255""/>";
            xml = xml + @"<column id=""field0183"" type=""0"" name=""费用小计C8"" length=""255""/>";
            xml = xml + @"<column id=""field0184"" type=""4"" name=""公司支持费用总计CB1"" length=""20""/>";
            xml = xml + @"<column id=""field0185"" type=""4"" name=""公司支持费用总计CB2"" length=""20""/>";
            xml = xml + @"<column id=""field0186"" type=""4"" name=""公司支持费用总计CB3"" length=""20""/>";
            xml = xml + @"<column id=""field0187"" type=""4"" name=""公司支持费用总计CB4"" length=""20""/>";
            xml = xml + @"<column id=""field0188"" type=""4"" name=""公司支持费用总计CB5"" length=""20""/>";
            xml = xml + @"<column id=""field0189"" type=""0"" name=""公司支持费用总计CB6"" length=""255""/>";
            xml = xml + @"<column id=""field0190"" type=""0"" name=""公司支持费用总计CB7"" length=""255""/>";
            xml = xml + @"<column id=""field0191"" type=""0"" name=""公司支持费用总计CB8"" length=""255""/>";
            xml = xml + @"<column id=""field0192"" type=""4"" name=""费用总计T1"" length=""20""/>";
            xml = xml + @"<column id=""field0193"" type=""4"" name=""费用总计T2"" length=""20""/>";
            xml = xml + @"<column id=""field0194"" type=""4"" name=""费用总计T3"" length=""20""/>";
            xml = xml + @"<column id=""field0195"" type=""4"" name=""费用总计T4"" length=""20""/>";
            xml = xml + @"<column id=""field0196"" type=""4"" name=""费用总计T5"" length=""20""/>";
            xml = xml + @"<column id=""field0197"" type=""0"" name=""费用总计T6"" length=""255""/>";
            xml = xml + @"<column id=""field0198"" type=""0"" name=""费用总计T7"" length=""255""/>";
            xml = xml + @"<column id=""field0199"" type=""0"" name=""费用总计T8"" length=""255""/>";
            xml = xml + @"<column id=""field0200"" type=""4"" name=""合计7"" length=""20""/>";
            xml = xml + @"<column id=""field0201"" type=""4"" name=""合计8"" length=""20""/>";
            xml = xml + @"<column id=""field0202"" type=""4"" name=""合计9"" length=""20""/>";
            xml = xml + @"<column id=""field0203"" type=""4"" name=""合计10"" length=""20""/>";
            xml = xml + @"<column id=""field0204"" type=""4"" name=""合计11"" length=""20""/>";
            xml = xml + @"<column id=""field0205"" type=""4"" name=""合计12"" length=""20""/>";
            xml = xml + @"<column id=""field0206"" type=""0"" name=""A类产品出厂价销售合计"" length=""255""/>";
            xml = xml + @"<column id=""field0207"" type=""0"" name=""A类占比"" length=""255""/>";
            xml = xml + @"<column id=""field0208"" type=""0"" name=""B类产品出厂价销售合计"" length=""255""/>";
            xml = xml + @"<column id=""field0209"" type=""0"" name=""B类占比"" length=""255""/>";
            xml = xml + @"<column id=""field0210"" type=""0"" name=""C类产品出厂价销售合计"" length=""255""/>";
            xml = xml + @"<column id=""field0211"" type=""0"" name=""C类占比"" length=""255""/>";
            xml = xml + @"<column id=""field0212"" type=""0"" name=""卖场销售-零售"" length=""255""/>";
            xml = xml + @"<column id=""field0213"" type=""0"" name=""卖场销售-供价"" length=""255""/>";
            xml = xml + @"<column id=""field0214"" type=""0"" name=""毛利总计"" length=""255""/>";
            xml = xml + @"<column id=""field0215"" type=""0"" name=""毛利率"" length=""255""/>";
            xml = xml + @"<column id=""field0216"" type=""0"" name=""公司实际利润"" length=""255""/>";
            xml = xml + @"<column id=""field0217"" type=""0"" name=""促销装费用"" length=""255""/>";
            xml = xml + @"<column id=""field0218"" type=""0"" name=""出厂价销售-合同年度"" length=""255""/>";
            xml = xml + @"<column id=""field0219"" type=""0"" name=""出厂价销售-归属年度"" length=""255""/>";
            xml = xml + @"<column id=""field0220"" type=""0"" name=""公司支持费用-合同年度"" length=""255""/>";
            xml = xml + @"<column id=""field0221"" type=""0"" name=""公司支持费用-归属年度"" length=""255""/>";
            xml = xml + @"<column id=""field0222"" type=""0"" name=""经销商销售任务"" length=""255""/>";
            xml = xml + @"<column id=""field0223"" type=""0"" name=""销售进度"" length=""255""/>";
            xml = xml + @"<column id=""field0224"" type=""0"" name=""经销商A类销售任务"" length=""255""/>";
            xml = xml + @"<column id=""field0225"" type=""0"" name=""A类销售进度"" length=""255""/>";
            xml = xml + @"<column id=""field0227"" type=""0"" name=""最终审批金额"" length=""255""/>";
            xml = xml + @"<column id=""field0228"" type=""0"" name=""修改的条款"" length=""255""/>";
            xml = xml + @"<column id=""field0229"" type=""4"" name=""合计13"" length=""20""/>";
            xml = xml + @"<column id=""field0230"" type=""4"" name=""合计14"" length=""20""/>";
            xml = xml + @"<column id=""field0231"" type=""4"" name=""合计15"" length=""20""/>";
            xml = xml + @"<column id=""field0232"" type=""4"" name=""合计16"" length=""20""/>";
            xml = xml + @"<column id=""field0233"" type=""4"" name=""合计17"" length=""20""/>";
            xml = xml + @"<column id=""field0234"" type=""4"" name=""合计18"" length=""20""/>";
            xml = xml + @"<column id=""field0226"" type=""0"" name=""当前审批意见"" length=""4000""/>";
            xml = xml + @"<column id=""field0276"" type=""0"" name=""数据来源"" length=""255""/>";
            xml = xml + @"<column id=""field0279"" type=""4"" name=""双鹿上年度实际销售"" length=""20""/>";
            xml = xml + @"<column id=""field0280"" type=""4"" name=""双鹿本年度预计销售"" length=""20""/>";
            xml = xml + @"<column id=""field0281"" type=""0"" name=""卖场情况说明"" length=""255""/>";
            xml = xml + @"<column id=""field0285"" type=""4"" name=""上年度双鹿销售"" length=""20""/>";
            xml = xml + @"<column id=""field0286"" type=""4"" name=""本年度双鹿销售"" length=""20""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            xml = xml + @" <column name=""归属年份"">";
            xml = xml + @" <value><![CDATA[" + model.HTYEAR + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""申请人"">";
            xml = xml + @" <value/>";
            //xml = xml + @" <value><![CDATA[" + model.SQR + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""申请日期"">";
            xml = xml + @" <value><![CDATA[" + model.SQSJ + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""最后修改日期"">";
            xml = xml + @" <value><![CDATA[" + model.XGSJ + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""经销客户名称"">";
            xml = xml + @" <value><![CDATA[" + model.JXSMC + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""经销客户编号"">";
            xml = xml + @" <value><![CDATA[" + model.JXSSAPSN + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""LKA系统CRM编号"">";
            xml = xml + @" <value><![CDATA[" + model.LKACRMID + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""合计1"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""合计2"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""合计3"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <value/>";
            xml = xml + @" <column name=""提交次数"">";
            xml = xml + @" <value><![CDATA[" + model.SUBMITCOUNT + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""卖场名称"">";
            xml = xml + @" <value><![CDATA[" + model.LKAMC + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""合同起止日期-起"">";
            xml = xml + @" <value><![CDATA[" + model.BEGINDATE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""合同起止日期-止"">";
            xml = xml + @" <value><![CDATA[" + model.ENDDATE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""归属年度月份总数"">";
            xml = xml + @" <value><![CDATA[" + model.MONTHCOUNT + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""首次进场时间"">";
            xml = xml + @" <value><![CDATA[" + model.FIRSTTIME + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""配送情况"">";
            xml = xml + @" <value><![CDATA[" + model.PSQK + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""辐射范围"">";
            xml = xml + @" <value><![CDATA[" + model.FSFW + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""经营方式"">";
            xml = xml + @" <value><![CDATA[" + model.MANAGEWAY + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""结款方式"">";
            xml = xml + @" <value><![CDATA[" + model.PAYWAY + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""竞争品牌名称"">";
            xml = xml + @" <value><![CDATA[" + model.JZPP + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""南孚供货商"">";
            xml = xml + @" <value><![CDATA[" + model.NFGHS + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""南孚陈列方式"">";
            xml = xml + @" <value><![CDATA[" + model.NFCLFS + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""南孚陈列占比"">";
            xml = xml + @" <value><![CDATA[" + model.NFCLZB + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""卖场接洽人名称"">";
            xml = xml + @" <value><![CDATA[" + model.GSLXR + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""接洽人职务"">";
            xml = xml + @" <value><![CDATA[" + model.GSLXRZW + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""接洽人电话"">";
            xml = xml + @" <value><![CDATA[" + model.GSLXRDH + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""经销商除供双鹿外是否供其他产品"">";
            xml = xml + @" <value><![CDATA[" + model.SUPPORTOTHER + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""是否新进卖场"">";
            xml = xml + @" <value><![CDATA[" + model.ISNEW + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""是否直接与公司签订合同"">";
            xml = xml + @" <value><![CDATA[" + model.PACT + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""KA管辖的LKA"">";
            xml = xml + @" <value><![CDATA[" + model.BELONGKA + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""销售变化原因说明"">";
            xml = xml + @" <value><![CDATA[" + model.CHANGEREASON + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""卖场销售数据来源"">";
            xml = xml + @" <value><![CDATA[" + model.MCXSSOURCE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""卖场费用扣款来源"">";
            xml = xml + @" <value><![CDATA[" + model.MCFYSOURCE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""卖场网址"">";
            xml = xml + @" <value><![CDATA[" + model.WEBSITE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""账号密码"">";
            xml = xml + @" <value><![CDATA[" + model.ACCOUNT + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""合计4"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""合计5"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""合计6"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""上年度实际费用-返利-合同条款内容"">";
            xml = xml + @" <value><![CDATA[" + model.FL_LAST_NR + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""上年度实际费用-返利-实际费用金额"">";
            xml = xml + @" <value><![CDATA[" + model.FL_LAST_JE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""本年度预估费用-返利-合同条款内容"">";
            xml = xml + @" <value><![CDATA[" + model.FL_THIS_NR + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""本年度预估费用-返利-费用预估额"">";
            xml = xml + @" <value><![CDATA[" + model.FL_THIS_JE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""返利-历史数据"">";
            xml = xml + @" <value><![CDATA[" + model.FL_HISTORY + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""返利-同比增减"">";
            xml = xml + @" <value><![CDATA[" + model.FL_TBZJ + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""返利-费用增加原因"">";
            xml = xml + @" <value><![CDATA[" + model.FL_REASON + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""返利-费用是否体现在合同条款内"">";
            xml = xml + @" <value><![CDATA[" + model.FL_SHOW + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""上年度实际费用-信息服务费-合同条款内容"">";
            xml = xml + @" <value><![CDATA[" + model.XX_LAST_NR + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""上年度实际费用-信息服务费-实际费用金额"">";
            xml = xml + @" <value><![CDATA[" + model.XX_LAST_JE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""本年度预估费用-信息服务费-合同条款内容"">";
            xml = xml + @" <value><![CDATA[" + model.XX_THIS_NR + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""本年度预估费用-信息服务费-费用预估额"">";
            xml = xml + @" <value><![CDATA[" + model.XX_THIS_JE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""信息服务费-历史数据"">";
            xml = xml + @" <value><![CDATA[" + model.XX_HISTORY + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""信息服务费-同比增减"">";
            xml = xml + @" <value><![CDATA[" + model.XX_TBZJ + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""信息服务费-费用增加原因"">";
            xml = xml + @" <value><![CDATA[" + model.XX_REASON + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""信息服务费-费用是否提现在合同条款内"">";
            xml = xml + @" <value><![CDATA[" + model.XX_SHOW + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""上年度实际费用-其他-合同条款内容"">";
            xml = xml + @" <value><![CDATA[" + model.OTHER_LAST_NR + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""上年度实际费用-其他-实际费用金额"">";
            xml = xml + @" <value><![CDATA[" + model.OTHER_LAST_JE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""本年度预估费用-其他-合同条款内容"">";
            xml = xml + @" <value><![CDATA[" + model.OTHER_THIS_NR + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""本年度预估费用-其他-费用预估额"">";
            xml = xml + @" <value><![CDATA[" + model.OTHER_THIS_JE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""其他-历史数据"">";
            xml = xml + @" <value><![CDATA[" + model.OTHER_HISTORY + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""其他-同比增减"">";
            xml = xml + @" <value><![CDATA[" + model.OTHER_TBZJ + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""其他-费用增加原因"">";
            xml = xml + @" <value><![CDATA[" + model.OTHER_REASON + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""其他-费用是否体现在合同条款内"">";
            xml = xml + @" <value><![CDATA[" + model.OTHER_SHOW + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""费用小计A1"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""费用小计A2"">";
            xml = xml + @" <value><![CDATA[55]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""费用小计A3"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""费用小计A4"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""费用小计A5"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""费用小计A6"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""费用小计A7"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""费用小计A8"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""上年度实际费用-进场费-合同条款内容"">";
            xml = xml + @" <value><![CDATA[" + model.JC_LAST_NR + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""上年度实际费用-进场费-实际费用金额"">";
            xml = xml + @" <value><![CDATA[" + model.JC_LAST_JE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""本年度预估费用-进场费-合同条款内容"">";
            xml = xml + @" <value><![CDATA[" + model.JC_THIS_NR + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""本年度预估费用-进场费-费用预估额"">";
            xml = xml + @" <value><![CDATA[" + model.JC_THIS_JE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""进场费-历史数据"">";
            xml = xml + @" <value><![CDATA[" + model.JC_HISTORY + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""进场费-同比增减"">";
            xml = xml + @" <value><![CDATA[" + model.JC_TBZJ + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""进场费-费用增加原因"">";
            xml = xml + @" <value><![CDATA[" + model.JC_REASON + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""进场费-费用是否体现在合同条款内"">";
            xml = xml + @" <value><![CDATA[" + model.JC_SHOW + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""上年度实际费用-新品费-合同条款内容"">";
            xml = xml + @" <value><![CDATA[" + model.XP_LAST_NR + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""上年度实际费用-新品费-实际费用金额"">";
            xml = xml + @" <value><![CDATA[" + model.XP_LAST_JE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""本年度预估费用-新品费-合同条款内容"">";
            xml = xml + @" <value><![CDATA[" + model.XP_THIS_NR + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""本年度预估费用-新品费-费用预估额"">";
            xml = xml + @" <value><![CDATA[" + model.XP_THIS_JE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""新品费-历史数据"">";
            xml = xml + @" <value><![CDATA[" + model.XP_HISTORY + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""新品费-同比增减"">";
            xml = xml + @" <value><![CDATA[" + model.XP_TBZJ + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""新品费-费用增加原因"">";
            xml = xml + @" <value><![CDATA[" + model.XP_REASON + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""新品费-费用是否体现在合同条款内"">";
            xml = xml + @" <value><![CDATA[" + model.XP_SHOW + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""上年度实际费用-合同续签费-合同条款内容"">";
            xml = xml + @" <value><![CDATA[" + model.HTXQ_LAST_NR + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""上年度实际费用-合同续签费-实际费用金额"">";
            xml = xml + @" <value><![CDATA[" + model.HTXQ_LAST_JE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""本年度预估费用-合同续签费-合同条款内容"">";
            xml = xml + @" <value><![CDATA[" + model.HTXQ_THIS_NR + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""本年度预估费用-合同续签费-费用预估额"">";
            xml = xml + @" <value><![CDATA[" + model.HTXQ_THIS_JE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""合同续签费-历史数据"">";
            xml = xml + @" <value><![CDATA[" + model.HTXQ_HISTORY + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""合同续签费-同比增减"">";
            xml = xml + @" <value><![CDATA[" + model.HTXQ_TBZJ + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""合同续签费-费用增加原因"">";
            xml = xml + @" <value><![CDATA[" + model.HTXQ_REASON + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""合同续签费-费用是否体现在合同条款内"">";
            xml = xml + @" <value><![CDATA[" + model.HTXQ_SHOW + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""上年度实际费用-店节庆周年庆-合同条款内容"">";
            xml = xml + @" <value><![CDATA[" + model.DJQ_LAST_NR + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""上年度实际费用-店节庆周年庆-实际费用金额"">";
            xml = xml + @" <value><![CDATA[" + model.DJQ_LAST_JE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""本年度预估费用-店节庆周年庆-合同条款内容"">";
            xml = xml + @" <value><![CDATA[" + model.DJQ_THIS_NR + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""本年度预估费用-店节庆周年庆-费用预估额"">";
            xml = xml + @" <value><![CDATA[" + model.DJQ_THIS_JE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""店节庆周年庆-历史数据"">";
            xml = xml + @" <value><![CDATA[" + model.DJQ_HISTORY + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""店节庆周年庆-同比增减"">";
            xml = xml + @" <value><![CDATA[" + model.DJQ_TBZJ + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""店节庆周年庆-费用增加原因"">";
            xml = xml + @" <value><![CDATA[" + model.DJQ_REASON + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""店节庆周年庆-费用是否体现在合同条款内"">";
            xml = xml + @" <value><![CDATA[" + model.DJQ_SHOW + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""上年度实际费用-新店开业费-合同条款内容"">";
            xml = xml + @" <value><![CDATA[" + model.XDKY_LAST_NR + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""上年度实际费用-新店开业费-实际费用金额"">";
            xml = xml + @" <value><![CDATA[" + model.XDKY_LAST_JE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""本年度预估费用-新店开业费-合同条款内容"">";
            xml = xml + @" <value><![CDATA[" + model.XDKY_THIS_NR + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""本年度预估费用-新店开业费-费用预估额"">";
            xml = xml + @" <value><![CDATA[" + model.XDKY_THIS_JE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""新店开业费-历史数据"">";
            xml = xml + @" <value><![CDATA[" + model.XDKY_HISTORY + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""新店开业费-同比增减"">";
            xml = xml + @" <value><![CDATA[" + model.XDKY_TBZJ + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""新店开业费-费用增加原因"">";
            xml = xml + @" <value><![CDATA[" + model.XDKY_REASON + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""新店开业费-费用是否体现在合同条款内"">";
            xml = xml + @" <value><![CDATA[" + model.XDKY_SHOW + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""上年度实际费用-陈列费-合同条款内容"">";
            xml = xml + @" <value><![CDATA[" + model.DISPLAY_LAST_NR + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""上年度实际费用-陈列费-实际费用金额"">";
            xml = xml + @" <value><![CDATA[" + model.DISPLAY_LAST_JE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""本年度预估费用-陈列费-合同条款内容"">";
            xml = xml + @" <value><![CDATA[" + model.DISPLAY_THIS_NR + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""本年度预估费用-陈列费-费用预估额"">";
            xml = xml + @" <value><![CDATA[" + model.DISPLAY_THIS_JE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""陈列费-历史数据"">";
            xml = xml + @" <value><![CDATA[" + model.DISPLAY_HISTORY + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""陈列费-同比增减"">";
            xml = xml + @" <value><![CDATA[" + model.DISPLAY_TBZJ + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""陈列费-费用增加原因"">";
            xml = xml + @" <value><![CDATA[" + model.DISPLAY_REASON + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""陈列费-费用是否体现在合同条款内"">";
            xml = xml + @" <value><![CDATA[" + model.DISPLAY_SHOW + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""费用小计B1"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""费用小计B2"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""费用小计B3"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""费用小计B4"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""费用小计B5"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""费用小计B6"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""费用小计B7"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""费用小计B8"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""合同费用合计AB1"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""合同费用合计AB2"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""合同费用合计AB3"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""合同费用合计AB4"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""合同费用合计AB5"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""合同费用合计AB6"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""合同费用合计AB7"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""合同费用合计AB8"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""上年度实际费用-特殊陈列费-合同条款内容"">";
            xml = xml + @" <value><![CDATA[" + model.SpecialDISPLAY_LAST_NR + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""上年度实际费用-特殊陈列费-实际费用金额"">";
            xml = xml + @" <value><![CDATA[" + model.SpecialDISPLAY_LAST_JE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""本年度预估费用-特殊陈列费-合同条款内容"">";
            xml = xml + @" <value><![CDATA[" + model.SpecialDISPLAY_THIS_NR + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""本年度预估费用-特殊陈列费-费用预估额"">";
            xml = xml + @" <value><![CDATA[" + model.SpecialDISPLAY_THIS_JE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""特殊陈列费-历史数据"">";
            xml = xml + @" <value><![CDATA[" + model.SpecialDISPLAY_HISTORY + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""特殊陈列费-同比增减"">";
            xml = xml + @" <value><![CDATA[" + model.SpecialDISPLAY_TBZJ + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""特殊陈列费-费用增加原因"">";
            xml = xml + @" <value><![CDATA[" + model.SpecialDISPLAY_REASON + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""特殊陈列费-费用是否体现在合同条款内"">";
            xml = xml + @" <value><![CDATA[" + model.SpecialDISPLAY_SHOW + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""上年度实际费用-海报费-合同条款内容"">";
            xml = xml + @" <value><![CDATA[" + model.HaiBao_LAST_NR + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""上年度实际费用-海报费-实际费用金额"">";
            xml = xml + @" <value><![CDATA[" + model.HaiBao_LAST_JE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""本年度预估费用-海报费-合同条款内容"">";
            xml = xml + @" <value><![CDATA[" + model.HaiBao_THIS_NR + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""本年度预估费用-海报费-费用预估额"">";
            xml = xml + @" <value><![CDATA[" + model.HaiBao_THIS_JE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""海报费-历史数据"">";
            xml = xml + @" <value><![CDATA[" + model.HaiBao_HISTORY + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""海报费-同比增减"">";
            xml = xml + @" <value><![CDATA[" + model.HaiBao_TBZJ + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""海报费-费用增加原因"">";
            xml = xml + @" <value><![CDATA[" + model.HaiBao_REASON + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""海报费-费用是否体现在合同条款内"">";
            xml = xml + @" <value><![CDATA[" + model.HaiBao_SHOW + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""上年度实际费用-堆头促销费-合同条款内容"">";
            xml = xml + @" <value><![CDATA[" + model.DuiTou_LAST_NR + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""上年度实际费用-堆头促销费-实际费用金额"">";
            xml = xml + @" <value><![CDATA[" + model.DuiTou_LAST_JE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""本年度预估费用-堆头促销费-合同条款内容"">";
            xml = xml + @" <value><![CDATA[" + model.DuiTou_THIS_NR + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""本年度预估费用-堆头促销费-费用预估额"">";
            xml = xml + @" <value><![CDATA[" + model.DuiTou_THIS_JE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""堆头促销费-历史数据"">";
            xml = xml + @" <value><![CDATA[" + model.DuiTou_HISTORY + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""堆头促销费-同比增减"">";
            xml = xml + @" <value><![CDATA[" + model.DuiTou_TBZJ + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""堆头促销费-费用增加原因"">";
            xml = xml + @" <value><![CDATA[" + model.DuiTou_REASON + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""堆头促销费-费用是否体现在合同条款内"">";
            xml = xml + @" <value><![CDATA[" + model.DuiTou_SHOW + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""上年度实际费用-其他费用-合同条款内容"">";
            xml = xml + @" <value><![CDATA[" + model.OTHER2_LAST_NR + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""上年度实际费用-其他费用-实际费用金额"">";
            xml = xml + @" <value><![CDATA[" + model.OTHER2_LAST_JE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""本年度预估费用-其他费用-合同条款内容"">";
            xml = xml + @" <value><![CDATA[" + model.OTHER2_THIS_NR + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""本年度预估费用-其他费用-费用预估额"">";
            xml = xml + @" <value><![CDATA[" + model.OTHER2_THIS_JE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""其他费用-历史数据"">";
            xml = xml + @" <value><![CDATA[" + model.OTHER2_HISTORY + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""其他费用-同比增减"">";
            xml = xml + @" <value><![CDATA[" + model.OTHER2_TBZJ + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""其他费用-费用增加原因"">";
            xml = xml + @" <value><![CDATA[" + model.OTHER2_REASON + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""其他费用-费用是否体现在合同条款内"">";
            xml = xml + @" <value><![CDATA[" + model.OTHER2_SHOW + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""上年度实际费用-制作费-合同条款内容"">";
            xml = xml + @" <value><![CDATA[" + model.ZZF_LAST_NR + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""上年度实际费用-制作费-实际费用金额"">";
            xml = xml + @" <value><![CDATA[" + model.ZZF_LAST_JE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""本年度预估费用-制作费-合同条款内容"">";
            xml = xml + @" <value><![CDATA[" + model.ZZF_THIS_NR + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""本年度预估费用-制作费-费用预估额"">";
            xml = xml + @" <value><![CDATA[" + model.ZZF_THIS_JE + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""制作费-历史数据"">";
            xml = xml + @" <value><![CDATA[" + model.ZZF_HISTORY + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""制作费-同比增减"">";
            xml = xml + @" <value><![CDATA[" + model.ZZF_TBZJ + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""制作费-费用增加原因"">";
            xml = xml + @" <value><![CDATA[" + model.ZZF_REASON + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""制作费-费用是否体现在合同条款内"">";
            xml = xml + @" <value><![CDATA[" + model.ZZF_SHOW + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""费用小计C1"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""费用小计C2"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""费用小计C3"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""费用小计C4"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""费用小计C5"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""费用小计C6"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""费用小计C7"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""费用小计C8"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""公司支持费用总计CB1"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""公司支持费用总计CB2"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""公司支持费用总计CB3"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""公司支持费用总计CB4"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""公司支持费用总计CB5"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""公司支持费用总计CB6"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""公司支持费用总计CB7"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""公司支持费用总计CB8"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""费用总计T1"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""费用总计T2"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""费用总计T3"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""费用总计T4"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""费用总计T5"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""费用总计T6"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""费用总计T7"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""费用总计T8"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""合计7"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""合计8"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""合计9"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""合计10"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""合计11"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""合计12"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""A类产品出厂价销售合计"">";
            xml = xml + @" <value><![CDATA[" + model.A_XS + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""A类占比"">";
            xml = xml + @" <value><![CDATA[" + model.A_ZB + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""B类产品出厂价销售合计"">";
            xml = xml + @" <value><![CDATA[" + model.B_XS + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""B类占比"">";
            xml = xml + @" <value><![CDATA[" + model.B_ZB + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""C类产品出厂价销售合计"">";
            xml = xml + @" <value><![CDATA[" + model.C_XS + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""C类占比"">";
            xml = xml + @" <value><![CDATA[" + model.C_ZB + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""卖场销售-零售"">";
            xml = xml + @" <value><![CDATA[" + model.MCXS_LS + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""卖场销售-供价"">";
            xml = xml + @" <value><![CDATA[" + model.MCXS_GJ + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""毛利总计"">";
            xml = xml + @" <value><![CDATA[" + model.MLZJ + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""毛利率"">";
            xml = xml + @" <value><![CDATA[" + model.MLL + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""公司实际利润"">";
            xml = xml + @" <value><![CDATA[" + model.GSSJLR + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""促销装费用"">";
            xml = xml + @" <value><![CDATA[" + model.CXZFY + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""出厂价销售-合同年度"">";
            xml = xml + @" <value><![CDATA[" + model.CCJ_HT + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""出厂价销售-归属年度"">";
            xml = xml + @" <value><![CDATA[" + model.CCJ_GS + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""公司支持费用-合同年度"">";
            xml = xml + @" <value><![CDATA[" + model.GSZC_HT + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""公司支持费用-归属年度"">";
            xml = xml + @" <value><![CDATA[" + model.GSZC_GS + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""经销商销售任务"">";
            xml = xml + @" <value><![CDATA[" + model.JXS_RW + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""销售进度"">";
            xml = xml + @" <value><![CDATA[" + model.JXS_JD + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""经销商A类销售任务"">";
            xml = xml + @" <value><![CDATA[" + model.A_JXS_RW + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""A类销售进度"">";
            xml = xml + @" <value><![CDATA[" + model.A_JXS_JD + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""最终审批金额"">";
            xml = xml + @" <value><![CDATA[" + model.FINALCOST + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""修改的条款"">";
            xml = xml + @" <value><![CDATA[" + model.XGNR + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""合计13"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""合计14"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""合计15"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""合计16"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""合计17"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""合计18"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""当前审批意见"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""数据来源"">";
            xml = xml + @" <value><![CDATA[CRM]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""双鹿上年度实际销售"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""双鹿本年度预计销售"">";
            xml = xml + @" <value/>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""卖场情况说明"">";
            xml = xml + @" <value><![CDATA[" + model.BEIZ + "]]></value>";
            xml = xml + @" </column>";

            xml = xml + @" <column name=""上年度双鹿销售"">";
            if (Convert.ToInt32(Convert.ToDouble(model.MCXS[0].LAST)) == 0)
                xml = xml + @" <value/>";
            else
                xml = xml + @" <value><![CDATA[" + model.MCXS[0].LAST + "]]></value>";
            xml = xml + @" </column>";
            xml = xml + @" <column name=""本年度双鹿销售"">";
            if (Convert.ToInt32(Convert.ToDouble(model.MCXS[0].THIS)) == 0)
                xml = xml + @" <value/>";
            else
                xml = xml + @" <value><![CDATA[" + model.MCXS[0].THIS + "]]></value>";
            xml = xml + @" </column>";

            xml = xml + @"</values>";
            xml = xml + @"<subForms>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0235"" type=""0"" name=""门店类型"" length=""255""/>";
            xml = xml + @"<column id=""field0236"" type=""4"" name=""现有门店数量"" length=""20""/>";
            xml = xml + @"<column id=""field0237"" type=""4"" name=""已进场门店数量"" length=""20""/>";
            xml = xml + @"<column id=""field0238"" type=""0"" name=""单品进场数量"" length=""255""/>";
            xml = xml + @"<column id=""field0239"" type=""0"" name=""登记备案的CRM门店数量"" length=""255""/>";
            xml = xml + @"<column id=""field0240"" type=""0"" name=""主要陈列方式"" length=""255""/>";
            xml = xml + @"<column id=""field0241"" type=""0"" name=""双鹿陈列面积占比"" length=""255""/>";
            xml = xml + @"<column id=""field0242"" type=""0"" name=""备注"" length=""255""/>";
            xml = xml + @"<column id=""field0287"" type=""4"" name=""预计本年新增门店数量"" length=""20""/>";
            xml = xml + @"<column id=""field0235"" type=""0"" name=""门店类型"" length=""255""/>";
            xml = xml + @"<column id=""field0236"" type=""4"" name=""现有门店数量"" length=""20""/>";
            xml = xml + @"<column id=""field0237"" type=""4"" name=""已进场门店数量"" length=""20""/>";
            xml = xml + @"<column id=""field0238"" type=""0"" name=""单品进场数量"" length=""255""/>";
            xml = xml + @"<column id=""field0239"" type=""0"" name=""登记备案的CRM门店数量"" length=""255""/>";
            xml = xml + @"<column id=""field0240"" type=""0"" name=""主要陈列方式"" length=""255""/>";
            xml = xml + @"<column id=""field0241"" type=""0"" name=""双鹿陈列面积占比"" length=""255""/>";
            xml = xml + @"<column id=""field0242"" type=""0"" name=""备注"" length=""255""/>";
            xml = xml + @"<column id=""field0287"" type=""4"" name=""预计本年新增门店数量"" length=""20""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            for (int i = 0; i < model.MDQK.Count; i++)
            {
                xml = xml + @" <row>";
                xml = xml + @" <column name=""门店类型"">";
                xml = xml + @" <value><![CDATA[" + model.MDQK[i].MDLX + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""现有门店数量"">";
                xml = xml + @" <value><![CDATA[" + model.MDQK[i].XYMDSL + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""已进场门店数量"">";
                xml = xml + @" <value><![CDATA[" + model.MDQK[i].YJCMDSL + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""单品进场数量"">";
                xml = xml + @" <value><![CDATA[" + model.MDQK[i].DPJCSL + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""登记备案的CRM门店数量"">";
                xml = xml + @" <value><![CDATA[" + model.MDQK[i].BASL + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""主要陈列方式"">";
                xml = xml + @" <value><![CDATA[" + model.MDQK[i].DISPLAY + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""双鹿陈列面积占比"">";
                xml = xml + @" <value><![CDATA[" + model.MDQK[i].DISPLAY_ZB + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""备注"">";
                xml = xml + @" <value><![CDATA[" + model.MDQK[i].BEIZ + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""预计本年新增门店数量"">";
                xml = xml + @" <value><![CDATA[" + model.MDQK[i].BNYJXZMDSL + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" </row>";
            }

            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0243"" type=""0"" name=""产品描述"" length=""255""/>";
            xml = xml + @"<column id=""field0244"" type=""0"" name=""产品分类"" length=""255""/>";
            xml = xml + @"<column id=""field0245"" type=""4"" name=""卖场实际供价-元卡"" length=""20""/>";
            xml = xml + @"<column id=""field0246"" type=""4"" name=""卖场实际售价-元卡"" length=""20""/>";
            xml = xml + @"<column id=""field0247"" type=""4"" name=""上年度实际销量-卡"" length=""20""/>";
            xml = xml + @"<column id=""field0248"" type=""4"" name=""本年度销量预估-卡"" length=""20""/>";
            xml = xml + @"<column id=""field0249"" type=""4"" name=""上年度销售实际-供价销量"" length=""20""/>";
            xml = xml + @"<column id=""field0250"" type=""4"" name=""本年度销售预估-供价销量"" length=""20""/>";
            xml = xml + @"<column id=""field0251"" type=""4"" name=""按出厂价计算销售"" length=""20""/>";
            xml = xml + @"<column id=""field0252"" type=""4"" name=""毛利小计"" length=""20""/>";
            xml = xml + @"<column id=""field0243"" type=""0"" name=""产品描述"" length=""255""/>";
            xml = xml + @"<column id=""field0244"" type=""0"" name=""产品分类"" length=""255""/>";
            xml = xml + @"<column id=""field0245"" type=""4"" name=""卖场实际供价-元卡"" length=""20""/>";
            xml = xml + @"<column id=""field0246"" type=""4"" name=""卖场实际售价-元卡"" length=""20""/>";
            xml = xml + @"<column id=""field0247"" type=""4"" name=""上年度实际销量-卡"" length=""20""/>";
            xml = xml + @"<column id=""field0248"" type=""4"" name=""本年度销量预估-卡"" length=""20""/>";
            xml = xml + @"<column id=""field0249"" type=""4"" name=""上年度销售实际-供价销量"" length=""20""/>";
            xml = xml + @"<column id=""field0250"" type=""4"" name=""本年度销售预估-供价销量"" length=""20""/>";
            xml = xml + @"<column id=""field0251"" type=""4"" name=""按出厂价计算销售"" length=""20""/>";
            xml = xml + @"<column id=""field0252"" type=""4"" name=""毛利小计"" length=""20""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            for (int i = 0; i < model.CPLR.Count; i++)
            {
                xml = xml + @" <row>";
                xml = xml + @" <column name=""产品描述"">";
                xml = xml + @" <value><![CDATA[" + model.CPLR[i].CPMS + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""产品分类"">";
                xml = xml + @" <value><![CDATA[" + model.CPLR[i].CPLX + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""卖场实际供价-元卡"">";
                xml = xml + @" <value><![CDATA[" + model.CPLR[i].MCGJ + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""卖场实际售价-元卡"">";
                xml = xml + @" <value><![CDATA[" + model.CPLR[i].MCSJ + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""上年度实际销量-卡"">";
                xml = xml + @" <value><![CDATA[" + model.CPLR[i].XL_LAST + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""本年度销量预估-卡"">";
                xml = xml + @" <value><![CDATA[" + model.CPLR[i].XL_THIS + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""上年度销售实际-供价销量"">";
                xml = xml + @" <value><![CDATA[" + model.CPLR[i].XS_LAST + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""本年度销售预估-供价销量"">";
                xml = xml + @" <value><![CDATA[" + model.CPLR[i].XS_THIS + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""按出厂价计算销售"">";
                xml = xml + @" <value><![CDATA[" + model.CPLR[i].CCJ + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""毛利小计"">";
                xml = xml + @" <value><![CDATA[" + model.CPLR[i].ML + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" </row>";
            }

            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0253"" type=""4"" name=""序号"" length=""20""/>";
            xml = xml + @"<column id=""field0254"" type=""0"" name=""CRM编号"" length=""255""/>";
            xml = xml + @"<column id=""field0255"" type=""0"" name=""卖场名称-已审批"" length=""255""/>";
            xml = xml + @"<column id=""field0256"" type=""4"" name=""上年度费用-合同年度"" length=""20""/>";
            xml = xml + @"<column id=""field0257"" type=""4"" name=""上年度费用-归属年度"" length=""20""/>";
            xml = xml + @"<column id=""field0258"" type=""4"" name=""本年度费用-合同年度"" length=""20""/>";
            xml = xml + @"<column id=""field0259"" type=""4"" name=""本年度费用-归属年度"" length=""20""/>";
            xml = xml + @"<column id=""field0260"" type=""4"" name=""出厂价销售-合同年度2"" length=""20""/>";
            xml = xml + @"<column id=""field0261"" type=""4"" name=""出厂价销售-归属年度2"" length=""20""/>";
            xml = xml + @"<column id=""field0253"" type=""4"" name=""序号"" length=""20""/>";
            xml = xml + @"<column id=""field0254"" type=""0"" name=""CRM编号"" length=""255""/>";
            xml = xml + @"<column id=""field0255"" type=""0"" name=""卖场名称-已审批"" length=""255""/>";
            xml = xml + @"<column id=""field0256"" type=""4"" name=""上年度费用-合同年度"" length=""20""/>";
            xml = xml + @"<column id=""field0257"" type=""4"" name=""上年度费用-归属年度"" length=""20""/>";
            xml = xml + @"<column id=""field0258"" type=""4"" name=""本年度费用-合同年度"" length=""20""/>";
            xml = xml + @"<column id=""field0259"" type=""4"" name=""本年度费用-归属年度"" length=""20""/>";
            xml = xml + @"<column id=""field0260"" type=""4"" name=""出厂价销售-合同年度2"" length=""20""/>";
            xml = xml + @"<column id=""field0261"" type=""4"" name=""出厂价销售-归属年度2"" length=""20""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            for (int i = 0; i < model.LKALIST.Count; i++)
            {
                xml = xml + @" <row>";
                xml = xml + @" <column name=""序号"">";
                xml = xml + @" <value/>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""CRM编号"">";
                xml = xml + @" <value><![CDATA[" + model.LKALIST[i].CRMID + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""卖场名称-已审批"">";
                xml = xml + @" <value><![CDATA[" + model.LKALIST[i].MC + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""上年度费用-合同年度"">";
                xml = xml + @" <value><![CDATA[" + model.LKALIST[i].LAST_HT + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""上年度费用-归属年度"">";
                xml = xml + @" <value><![CDATA[" + model.LKALIST[i].LAST_GS + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""本年度费用-合同年度"">";
                xml = xml + @" <value><![CDATA[" + model.LKALIST[i].THIS_HT + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""本年度费用-归属年度"">";
                xml = xml + @" <value><![CDATA[" + model.LKALIST[i].THIS_GS + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""出厂价销售-合同年度2"">";
                xml = xml + @" <value><![CDATA[" + model.LKALIST[i].CCJ_HT + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""出厂价销售-归属年度2"">";
                xml = xml + @" <value><![CDATA[" + model.LKALIST[i].CCJ_GS + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" </row>";
            }

            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0262"" type=""0"" name=""年份"" length=""255""/>";
            xml = xml + @"<column id=""field0263"" type=""4"" name=""实际销售-元"" length=""20""/>";
            xml = xml + @"<column id=""field0264"" type=""0"" name=""B类销售-元"" length=""255""/>";
            xml = xml + @"<column id=""field0265"" type=""0"" name=""LKA费用-合同年度"" length=""255""/>";
            xml = xml + @"<column id=""field0266"" type=""4"" name=""LKA费用-归属年度"" length=""20""/>";
            xml = xml + @"<column id=""field0267"" type=""4"" name=""LKA费比-归属年度"" length=""20""/>";
            xml = xml + @"<column id=""field0268"" type=""0"" name=""卖场已审批数量-家"" length=""255""/>";
            xml = xml + @"<column id=""field0269"" type=""4"" name=""总费用"" length=""20""/>";
            xml = xml + @"<column id=""field0270"" type=""4"" name=""总费比"" length=""20""/>";
            xml = xml + @"<column id=""field0277"" type=""0"" name=""LKA单品销量-元"" length=""255""/>";
            xml = xml + @"<column id=""field0278"" type=""0"" name=""测算费用"" length=""255""/>";
            xml = xml + @"<column id=""field0289"" type=""0"" name=""LKA费用-归属年度中已核销部分"" length=""255""/>";
            xml = xml + @"<column id=""field0290"" type=""4"" name=""总销售任务-元"" length=""20""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            for (int i = 0; i < model.JXS.Count; i++)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""年份"">";
                xml = xml + @"<value><![CDATA[" + model.JXS[i].YEAR + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""实际销售-元"">";
                xml = xml + @"<value><![CDATA[" + model.JXS[i].SJXS + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""B类销售-元"">";
                xml = xml + @"<value><![CDATA[" + model.JXS[i].SJXS_JX + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""LKA费用-合同年度"">";
                xml = xml + @"<value><![CDATA[" + model.JXS[i].LKA_HT + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""LKA费用-归属年度"">";
                xml = xml + @"<value><![CDATA[" + model.JXS[i].LKA_GS + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""LKA费比-归属年度"">";
                xml = xml + @"<value><![CDATA[" + model.JXS[i].FB_GS + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""卖场已审批数量-家"">";
                xml = xml + @"<value><![CDATA[" + model.JXS[i].SPSL + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""总费用"">";
                xml = xml + @"<value><![CDATA[" + model.JXS[i].ZFY + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""总费比"">";
                xml = xml + @"<value><![CDATA[" + model.JXS[i].ZFB + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""LKA单品销量-元"">";
                xml = xml + @"<value/>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""测算费用"">";
                xml = xml + @"<value/>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""LKA费用-归属年度中已核销部分"">";
                xml = xml + @"<value><![CDATA[" + model.JXS[i].YHX_GS + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""总销售任务-元"">";
                xml = xml + @"<value><![CDATA[" + model.JXS[i].XSRW + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }

            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0271"" type=""0"" name=""品牌"" length=""255""/>";
            xml = xml + @"<column id=""field0272"" type=""4"" name=""上年度实际销售"" length=""20""/>";
            xml = xml + @"<column id=""field0273"" type=""4"" name=""本年度预计销售"" length=""20""/>";
            xml = xml + @"<column id=""field0274"" type=""0"" name=""同比增减"" length=""255""/>";
            xml = xml + @"<column id=""field0271"" type=""0"" name=""品牌"" length=""255""/>";
            xml = xml + @"<column id=""field0272"" type=""4"" name=""上年度实际销售"" length=""20""/>";
            xml = xml + @"<column id=""field0273"" type=""4"" name=""本年度预计销售"" length=""20""/>";
            xml = xml + @"<column id=""field0274"" type=""0"" name=""同比增减"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            for (int i = 0; i < model.MCXS.Count; i++)
            {
                xml = xml + @" <row>";
                xml = xml + @" <column name=""品牌"">";
                xml = xml + @" <value><![CDATA[" + model.MCXS[i].PP + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""上年度实际销售"">";
                xml = xml + @" <value><![CDATA[" + model.MCXS[i].LAST + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""本年度预计销售"">";
                xml = xml + @" <value><![CDATA[" + model.MCXS[i].THIS + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""同比增减"">";
                xml = xml + @" <value><![CDATA[" + model.MCXS[i].TBZJ + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" </row>";
            }

            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0275"" type=""0"" name=""历史审批意见"" length=""255""/>";
            xml = xml + @"<column id=""field0282"" type=""1"" name=""历史审批意见2"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            for (int i = 0; i < model.OPINION.Count; i++)
            {
                xml = xml + @" <row>";
                xml = xml + @" <column name=""历史审批意见"">";
                xml = xml + @" <value><![CDATA[" + model.OPINION[i].OPINION + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" <column name=""历史审批意见2"">";
                xml = xml + @" <value><![CDATA[" + model.OPINION[i].HFNR + "]]></value>";
                xml = xml + @" </column>";
                xml = xml + @" </row>";
            }

            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"</subForms>";
            xml = xml + @"</formExport>";




            return xml;
        }

        public string XML_HaiBao(CRM_OA_HaiBao model)
        {
            string xml = "";
            xml = xml + @"<formExport version=""2.0"">";
            xml = xml + @"<summary id="""" name=""formmain_2465""/>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0001"" type=""0"" name=""合同年份"" length=""255""/>";
            xml = xml + @"<column id=""field0002"" type=""0"" name=""业务员"" length=""255""/>";
            xml = xml + @"<column id=""field0003"" type=""0"" name=""经销客户名称"" length=""255""/>";
            xml = xml + @"<column id=""field0004"" type=""0"" name=""经销客户编号"" length=""255""/>";
            xml = xml + @"<column id=""field0005"" type=""0"" name=""卖场名称"" length=""255""/>";
            xml = xml + @"<column id=""field0006"" type=""0"" name=""LKA的CRM编号"" length=""255""/>";
            xml = xml + @"<column id=""field0007"" type=""0"" name=""卖场门店数量"" length=""255""/>";
            xml = xml + @"<column id=""field0008"" type=""0"" name=""已审批年度促销费用-元"" length=""255""/>";
            xml = xml + @"<column id=""field0009"" type=""0"" name=""累计申请的促销费用"" length=""255""/>";
            xml = xml + @"<column id=""field0010"" type=""0"" name=""已核销年度促销费用-元"" length=""255""/>";
            xml = xml + @"<column id=""field0011"" type=""0"" name=""参加活动门店数量"" length=""255""/>";
            xml = xml + @"<column id=""field0012"" type=""0"" name=""活动开始时间"" length=""255""/>";
            xml = xml + @"<column id=""field0013"" type=""0"" name=""活动结束时间"" length=""255""/>";
            xml = xml + @"<column id=""field0014"" type=""0"" name=""客户提货开始时间"" length=""255""/>";
            xml = xml + @"<column id=""field0015"" type=""0"" name=""客户提货结束时间"" length=""255""/>";
            xml = xml + @"<column id=""field0016"" type=""0"" name=""单品1"" length=""255""/>";
            xml = xml + @"<column id=""field0017"" type=""0"" name=""单品2"" length=""255""/>";
            xml = xml + @"<column id=""field0018"" type=""0"" name=""出厂价-元卡"" length=""255""/>";
            xml = xml + @"<column id=""field0019"" type=""0"" name=""正常供价-元卡"" length=""255""/>";
            xml = xml + @"<column id=""field0020"" type=""0"" name=""促销供价-元卡"" length=""255""/>";
            xml = xml + @"<column id=""field0021"" type=""0"" name=""正常售价-元卡"" length=""255""/>";
            xml = xml + @"<column id=""field0022"" type=""0"" name=""促销售价-元卡"" length=""255""/>";
            xml = xml + @"<column id=""field0023"" type=""0"" name=""该单品月均销售-零售"" length=""255""/>";
            xml = xml + @"<column id=""field0024"" type=""0"" name=""预计活动期间销售-零售"" length=""255""/>";
            xml = xml + @"<column id=""field0025"" type=""0"" name=""预计费比"" length=""255""/>";
            xml = xml + @"<column id=""field0026"" type=""0"" name=""备注-活动方案说明"" length=""255""/>";
            xml = xml + @"<column id=""field0027"" type=""0"" name=""数据来源"" length=""255""/>";
            xml = xml + @"<column id=""field0031"" type=""0"" name=""当前审批意见"" length=""255""/>";
            xml = xml + @"<column id=""field0034"" type=""0"" name=""KA管辖的LKA"" length=""255""/>";
            xml = xml + @"<column id=""field0037"" type=""0"" name=""标题"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            xml = xml + @"<column name=""合同年份"">";
            xml = xml + @"<value><![CDATA[" + model.HTYEAR + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""业务员"">";
            //xml = xml + @"<value><![CDATA[" + model.YWY + "]]></value>";
            xml = xml + @" <value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""经销客户名称"">";
            xml = xml + @"<value><![CDATA[" + model.JXSNAME + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""经销客户编号"">";
            xml = xml + @"<value><![CDATA[" + model.JXSSAPSN + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""卖场名称"">";
            xml = xml + @"<value><![CDATA[" + model.LKANAME + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""LKA的CRM编号"">";
            xml = xml + @"<value><![CDATA[" + model.LKACRMID + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""卖场门店数量"">";
            xml = xml + @"<value><![CDATA[" + model.MDSL + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""已审批年度促销费用-元"">";
            xml = xml + @"<value><![CDATA[" + model.YSPFY + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""累计申请的促销费用"">";
            xml = xml + @"<value><![CDATA[" + model.LJSPFY + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""已核销年度促销费用-元"">";
            xml = xml + @"<value><![CDATA[" + model.YHXFY + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""参加活动门店数量"">";
            xml = xml + @"<value><![CDATA[" + model.CJHDMDSL + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""活动开始时间"">";
            xml = xml + @"<value><![CDATA[" + model.HDBEGINDATE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""活动结束时间"">";
            xml = xml + @"<value><![CDATA[" + model.HDENDDATE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""客户提货开始时间"">";
            xml = xml + @"<value><![CDATA[" + model.KHTHBEGINDATE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""客户提货结束时间"">";
            xml = xml + @"<value><![CDATA[" + model.KHTHENDDATE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""单品1"">";
            xml = xml + @"<value><![CDATA[" + model.DP1 + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""单品2"">";
            xml = xml + @"<value><![CDATA[" + model.DP2 + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""出厂价-元卡"">";
            xml = xml + @"<value><![CDATA[" + model.CCJ + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""正常供价-元卡"">";
            xml = xml + @"<value><![CDATA[" + model.ZCGJ + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""促销供价-元卡"">";
            xml = xml + @"<value><![CDATA[" + model.CXGJ + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""正常售价-元卡"">";
            xml = xml + @"<value><![CDATA[" + model.ZCSJ + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""促销售价-元卡"">";
            xml = xml + @"<value><![CDATA[" + model.CXSJ + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""该单品月均销售-零售"">";
            xml = xml + @"<value><![CDATA[" + model.DPYJXS + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""预计活动期间销售-零售"">";
            xml = xml + @"<value><![CDATA[" + model.YJHDQJXS + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""预计费比"">";
            xml = xml + @"<value><![CDATA[" + model.YJFB + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""备注-活动方案说明"">";
            xml = xml + @"<value><![CDATA[" + model.HDFASM + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""数据来源"">";
            xml = xml + @"<value><![CDATA[CRM]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""当前审批意见"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""KA管辖的LKA"">";
            xml = xml + @"<value><![CDATA[" + model.BELONGKA + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""标题"">";
            xml = xml + @"<value><![CDATA[" + model.TITLE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"</values>";
            xml = xml + @"<subForms>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0028"" type=""4"" name=""序号"" length=""20""/>";
            xml = xml + @"<column id=""field0029"" type=""0"" name=""费用类型"" length=""255""/>";
            xml = xml + @"<column id=""field0030"" type=""0"" name=""费用金额"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            for (int i = 0; i < model.HaiBao_MX.Count; i++)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""序号"">";
                xml = xml + @"<value><![CDATA[]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""费用类型"">";
                xml = xml + @"<value><![CDATA[" + model.HaiBao_MX[i].FYLX + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""费用金额"">";
                xml = xml + @"<value><![CDATA[" + model.HaiBao_MX[i].CXFY + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }

            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0032"" type=""1"" name=""历史审批意见"" length=""255""/>";
            xml = xml + @"<column id=""field0033"" type=""1"" name=""历史审批意见2"" length=""255""/>";
            xml = xml + @"<column id=""field0036"" type=""1"" name=""历史3"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            for (int i = 0; i < model.OPINION.Count; i++)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""历史审批意见"">";
                xml = xml + @" <value><![CDATA[" + model.OPINION[i].OPINION + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""历史审批意见2"">";
                xml = xml + @" <value><![CDATA[" + model.OPINION[i].HFNR + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""历史3"">";
                xml = xml + @" <value><![CDATA[" + model.OPINION[i].MS + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }

            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"</subForms>";
            xml = xml + @"</formExport>";


            return xml;
        }

        public string XML_LKA_DT_HB_CXZ(CRM_OA_HaiBao model)
        {
            string xml = "";
            xml = xml + @"<formExport version=""2.0"">";
            xml = xml + @"<summary id=""5246032944690711689"" name=""formmain_3130""/>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0001"" type=""0"" name=""合同年份"" length=""255""/>";
            xml = xml + @"<column id=""field0002"" type=""0"" name=""业务员"" length=""255""/>";
            xml = xml + @"<column id=""field0003"" type=""0"" name=""经销客户名称"" length=""255""/>";
            xml = xml + @"<column id=""field0004"" type=""0"" name=""经销客户编号"" length=""255""/>";
            xml = xml + @"<column id=""field0005"" type=""0"" name=""卖场名称"" length=""255""/>";
            xml = xml + @"<column id=""field0006"" type=""0"" name=""LKA的CRM编号"" length=""255""/>";
            xml = xml + @"<column id=""field0007"" type=""0"" name=""卖场门店数量"" length=""255""/>";
            xml = xml + @"<column id=""field0011"" type=""0"" name=""参加活动门店数量"" length=""255""/>";
            xml = xml + @"<column id=""field0012"" type=""0"" name=""活动开始时间"" length=""255""/>";
            xml = xml + @"<column id=""field0013"" type=""0"" name=""活动结束时间"" length=""255""/>";
            xml = xml + @"<column id=""field0014"" type=""0"" name=""客户提货开始时间"" length=""255""/>";
            xml = xml + @"<column id=""field0015"" type=""0"" name=""客户提货结束时间"" length=""255""/>";
            xml = xml + @"<column id=""field0016"" type=""0"" name=""单品1"" length=""255""/>";
            xml = xml + @"<column id=""field0017"" type=""0"" name=""单品2"" length=""255""/>";
            xml = xml + @"<column id=""field0018"" type=""0"" name=""出厂价-元卡"" length=""255""/>";
            xml = xml + @"<column id=""field0019"" type=""0"" name=""正常供价-元卡"" length=""255""/>";
            xml = xml + @"<column id=""field0020"" type=""0"" name=""促销供价-元卡"" length=""255""/>";
            xml = xml + @"<column id=""field0021"" type=""0"" name=""正常售价-元卡"" length=""255""/>";
            xml = xml + @"<column id=""field0022"" type=""0"" name=""促销售价-元卡"" length=""255""/>";
            xml = xml + @"<column id=""field0023"" type=""0"" name=""该单品月均销售-零售"" length=""255""/>";
            xml = xml + @"<column id=""field0024"" type=""0"" name=""预计活动期间销售-零售"" length=""255""/>";
            xml = xml + @"<column id=""field0025"" type=""0"" name=""预计费比"" length=""255""/>";
            xml = xml + @"<column id=""field0026"" type=""0"" name=""备注-活动方案说明"" length=""255""/>";
            xml = xml + @"<column id=""field0027"" type=""0"" name=""数据来源"" length=""255""/>";
            xml = xml + @"<column id=""field0031"" type=""0"" name=""当前审批意见"" length=""255""/>";
            xml = xml + @"<column id=""field0035"" type=""4"" name=""费用金额合计"" length=""20""/>";
            xml = xml + @"<column id=""field0037"" type=""0"" name=""标题"" length=""255""/>";
            xml = xml + @"<column id=""field0009"" type=""0"" name=""累计申请的促销费用"" length=""255""/>";
            xml = xml + @"<column id=""field0010"" type=""0"" name=""已核销年度促销费用-元"" length=""255""/>";
            xml = xml + @"<column id=""field0008"" type=""0"" name=""已审批年度促销费用-元"" length=""255""/>";
            xml = xml + @"<column id=""field0038"" type=""0"" name=""当前审批意见-新"" length=""4000""/>";
            xml = xml + @"<column id=""field0034"" type=""0"" name=""KA管辖的LKA"" length=""255""/>";
            xml = xml + @"<column id=""field0047"" type=""4"" name=""是否促销装合计"" length=""20""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            xml = xml + @"<column name=""合同年份"">";
            xml = xml + @"<value><![CDATA[" + model.HTYEAR + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""业务员"">";
            //xml = xml + @"<value><![CDATA[4194125152346851129]]></value>";
            xml = xml + @" <value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""经销客户名称"">";
            xml = xml + @"<value><![CDATA[" + model.JXSNAME + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""经销客户编号"">";
            xml = xml + @"<value><![CDATA[" + model.JXSSAPSN + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""卖场名称"">";
            xml = xml + @"<value><![CDATA[" + model.LKANAME + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""LKA的CRM编号"">";
            xml = xml + @"<value><![CDATA[" + model.LKACRMID + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""卖场门店数量"">";
            xml = xml + @"<value><![CDATA[" + model.MDSL + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""参加活动门店数量"">";
            xml = xml + @"<value><![CDATA[" + model.CJHDMDSL + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""活动开始时间"">";
            xml = xml + @"<value><![CDATA[" + model.HDBEGINDATE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""活动结束时间"">";
            xml = xml + @"<value><![CDATA[" + model.HDENDDATE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""客户提货开始时间"">";
            xml = xml + @"<value><![CDATA[" + model.KHTHBEGINDATE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""客户提货结束时间"">";
            xml = xml + @"<value><![CDATA[" + model.KHTHENDDATE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""单品1"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""单品2"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""出厂价-元卡"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""正常供价-元卡"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""促销供价-元卡"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""正常售价-元卡"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""促销售价-元卡"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""该单品月均销售-零售"">";
            xml = xml + @"<value><![CDATA[" + model.DPYJXS + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""预计活动期间销售-零售"">";
            xml = xml + @"<value><![CDATA[" + model.YJHDQJXS + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""预计费比"">";
            xml = xml + @"<value><![CDATA[" + model.YJFB + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""备注-活动方案说明"">";
            xml = xml + @"<value><![CDATA[" + model.HDFASM + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""数据来源"">";
            xml = xml + @"<value><![CDATA[CRM]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""当前审批意见"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""费用金额合计"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""标题"">";
            xml = xml + @"<value><![CDATA[" + model.TITLE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""累计申请的促销费用"">";
            xml = xml + @"<value><![CDATA[" + model.LJSPFY + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""已核销年度促销费用-元"">";
            xml = xml + @"<value><![CDATA[" + model.YHXFY + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""已审批年度促销费用-元"">";
            xml = xml + @"<value><![CDATA[" + model.YSPFY + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""当前审批意见-新"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""KA管辖的LKA"">";
            xml = xml + @"<value><![CDATA[" + model.BELONGKA + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""是否促销装合计"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"</values>";
            xml = xml + @"<subForms>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0028"" type=""4"" name=""序号"" length=""20""/>";
            xml = xml + @"<column id=""field0029"" type=""0"" name=""费用类型"" length=""255""/>";
            xml = xml + @"<column id=""field0030"" type=""4"" name=""费用金额"" length=""20""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            for (int i = 0; i < model.HaiBao_MX.Count; i++)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""序号"">";
                xml = xml + @"<value><![CDATA[]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""费用类型"">";
                xml = xml + @"<value><![CDATA[" + model.HaiBao_MX[i].FYLX + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""费用金额"">";
                xml = xml + @"<value><![CDATA[" + model.HaiBao_MX[i].CXFY + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }

            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0032"" type=""1"" name=""历史审批意见"" length=""255""/>";
            xml = xml + @"<column id=""field0033"" type=""1"" name=""历史审批意见2"" length=""255""/>";
            xml = xml + @"<column id=""field0036"" type=""1"" name=""历史3"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            for (int i = 0; i < model.OPINION.Count; i++)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""历史审批意见"">";
                xml = xml + @"<value><![CDATA[" + model.OPINION[i].OPINION + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""历史审批意见2"">";
                xml = xml + @"<value><![CDATA[" + model.OPINION[i].HFNR + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""历史3"">";
                xml = xml + @"<value><![CDATA[" + model.OPINION[i].MS + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }

            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0039"" type=""0"" name=""促销单品名称N"" length=""255""/>";
            xml = xml + @"<column id=""field0040"" type=""0"" name=""提货数量-件N"" length=""255""/>";
            xml = xml + @"<column id=""field0041"" type=""0"" name=""出厂价-元卡N"" length=""255""/>";
            xml = xml + @"<column id=""field0042"" type=""0"" name=""正常供价-元卡N"" length=""255""/>";
            xml = xml + @"<column id=""field0043"" type=""0"" name=""促销供价-元卡N"" length=""255""/>";
            xml = xml + @"<column id=""field0044"" type=""0"" name=""正常售价-元卡N"" length=""255""/>";
            xml = xml + @"<column id=""field0045"" type=""0"" name=""促销售价-元卡N"" length=""255""/>";
            xml = xml + @"<column id=""field0046"" type=""0"" name=""是否促销装"" length=""255""/>";
            xml = xml + @"<column id=""field0048"" type=""4"" name=""是否促销装计数"" length=""20""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            for (int i = 0; i < model.HaiBao_DP.Count; i++)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""促销单品名称N"">";
                xml = xml + @"<value><![CDATA[" + model.HaiBao_DP[i].CPMC + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""提货数量-件N"">";
                xml = xml + @"<value><![CDATA[" + model.HaiBao_DP[i].JHSL + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""出厂价-元卡N"">";
                xml = xml + @"<value><![CDATA[" + model.HaiBao_DP[i].CCJ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""正常供价-元卡N"">";
                xml = xml + @"<value><![CDATA[" + model.HaiBao_DP[i].ZCGJ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""促销供价-元卡N"">";
                xml = xml + @"<value><![CDATA[" + model.HaiBao_DP[i].CXGJ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""正常售价-元卡N"">";
                xml = xml + @"<value><![CDATA[" + model.HaiBao_DP[i].ZCSJ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""促销售价-元卡N"">";
                xml = xml + @"<value><![CDATA[" + model.HaiBao_DP[i].CXSJ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""是否促销装"">";
                xml = xml + @"<value><![CDATA[" + model.HaiBao_DP[i].ISCXZ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""是否促销装计数"">";
                xml = xml + @"<value><![CDATA[" + model.HaiBao_DP[i].ISCXZCOUNT + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }

            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"</subForms>";
            xml = xml + @"</formExport>";



            return xml;
        }

        public string XML_TSCL(CRM_OA_TSCL model)
        {
            string xml = "";
            xml = xml + @"<formExport version=""2.0"">";
            xml = xml + @"<summary id="""" name=""formmain_2461""/>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0001"" type=""0"" name=""合同年份"" length=""255""/>";
            xml = xml + @"<column id=""field0002"" type=""0"" name=""业务员"" length=""255""/>";
            xml = xml + @"<column id=""field0003"" type=""0"" name=""经销客户名称"" length=""255""/>";
            xml = xml + @"<column id=""field0004"" type=""0"" name=""经销客户编号"" length=""255""/>";
            xml = xml + @"<column id=""field0005"" type=""0"" name=""卖场名称"" length=""255""/>";
            xml = xml + @"<column id=""field0006"" type=""0"" name=""LKA的CRM编号"" length=""255""/>";
            xml = xml + @"<column id=""field0007"" type=""0"" name=""卖场门店数量"" length=""255""/>";
            xml = xml + @"<column id=""field0008"" type=""0"" name=""已审批年度特殊陈列费-元"" length=""255""/>";
            xml = xml + @"<column id=""field0009"" type=""0"" name=""累计申请的特殊陈列费-元"" length=""255""/>";
            xml = xml + @"<column id=""field0010"" type=""0"" name=""已核销年度特殊陈列费-元"" length=""255""/>";
            xml = xml + @"<column id=""field0011"" type=""0"" name=""费用类型"" length=""255""/>";
            xml = xml + @"<column id=""field0013"" type=""0"" name=""数据来源"" length=""255""/>";
            xml = xml + @"<column id=""field0014"" type=""4"" name=""合计一"" length=""20""/>";
            xml = xml + @"<column id=""field0015"" type=""4"" name=""合计二"" length=""20""/>";
            xml = xml + @"<column id=""field0016"" type=""4"" name=""合计三"" length=""20""/>";
            xml = xml + @"<column id=""field0028"" type=""0"" name=""是否KA管辖的LKA"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            xml = xml + @"<column name=""合同年份"">";
            xml = xml + @"<value><![CDATA[" + model.HTYEAR + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""业务员"">";
            xml = xml + @"<value><![CDATA[" + model.YWY + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""经销客户名称"">";
            xml = xml + @"<value><![CDATA[" + model.JXSNAME + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""经销客户编号"">";
            xml = xml + @"<value><![CDATA[" + model.JXSSAPSN + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""卖场名称"">";
            xml = xml + @"<value><![CDATA[" + model.LKANAME + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""LKA的CRM编号"">";
            xml = xml + @"<value><![CDATA[" + model.LKACRMID + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""卖场门店数量"">";
            xml = xml + @"<value><![CDATA[" + model.MDSL + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""已审批年度特殊陈列费-元"">";
            xml = xml + @"<value><![CDATA[" + model.YSPFY + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""累计申请的特殊陈列费-元"">";
            xml = xml + @"<value><![CDATA[" + model.LJSPFY + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""已核销年度特殊陈列费-元"">";
            xml = xml + @"<value><![CDATA[" + model.YHXFY + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""费用类型"">";
            xml = xml + @"<value><![CDATA[" + model.FYLX + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""数据来源"">";
            xml = xml + @"<value><![CDATA[CRM]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""合计一"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""合计二"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""合计三"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""是否KA管辖的LKA"">";
            xml = xml + @"<value><![CDATA[" + model.BELONGKA + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"</values>";
            xml = xml + @"<subForms>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0017"" type=""0"" name=""序号"" length=""255""/>";
            xml = xml + @"<column id=""field0019"" type=""0"" name=""门店名称"" length=""255""/>";
            xml = xml + @"<column id=""field0020"" type=""0"" name=""陈列方式"" length=""255""/>";
            xml = xml + @"<column id=""field0021"" type=""0"" name=""开始时间"" length=""255""/>";
            xml = xml + @"<column id=""field0022"" type=""0"" name=""结束时间"" length=""255""/>";
            xml = xml + @"<column id=""field0023"" type=""4"" name=""申请的费用金额"" length=""20""/>";
            xml = xml + @"<column id=""field0024"" type=""4"" name=""预计的销售"" length=""20""/>";
            xml = xml + @"<column id=""field0025"" type=""4"" name=""预计费比"" length=""20""/>";
            xml = xml + @"<column id=""field0026"" type=""0"" name=""备注"" length=""255""/>";
            xml = xml + @"<column id=""field0018"" type=""0"" name=""门店数量-废"" length=""255""/>";
            xml = xml + @"<column id=""field0032"" type=""4"" name=""日常月均销售-零售"" length=""20""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            for (int i = 0; i < model.TSCL_MX.Count; i++)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""序号"">";
                xml = xml + @"<value><![CDATA[]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""门店名称"">";
                xml = xml + @"<value><![CDATA[" + model.TSCL_MX[i].MDMC + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""陈列方式"">";
                xml = xml + @"<value><![CDATA[" + model.TSCL_MX[i].DISPLAY + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""开始时间"">";
                xml = xml + @"<value><![CDATA[" + model.TSCL_MX[i].BEGINDATE + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""结束时间"">";
                xml = xml + @"<value><![CDATA[" + model.TSCL_MX[i].ENDDATE + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""申请的费用金额"">";
                xml = xml + @"<value><![CDATA[" + model.TSCL_MX[i].SQFY + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""预计的销售"">";
                xml = xml + @"<value><![CDATA[" + model.TSCL_MX[i].YJXS + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""预计费比"">";
                xml = xml + @"<value><![CDATA[" + model.TSCL_MX[i].YJFB + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""备注"">";
                xml = xml + @"<value><![CDATA[" + model.TSCL_MX[i].BEIZ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""门店数量-废"">";
                xml = xml + @"<value/>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""日常月均销售-零售"">";
                xml = xml + @"<value><![CDATA[" + model.TSCL_MX[i].RCYJXS + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }

            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0029"" type=""1"" name=""历史1"" length=""255""/>";
            xml = xml + @"<column id=""field0030"" type=""1"" name=""历史2"" length=""255""/>";
            xml = xml + @"<column id=""field0031"" type=""1"" name=""历史3"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            for (int i = 0; i < model.OPINION.Count; i++)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""历史1"">";
                xml = xml + @" <value><![CDATA[" + model.OPINION[i].OPINION + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""历史2"">";
                xml = xml + @" <value><![CDATA[" + model.OPINION[i].HFNR + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""历史3"">";
                xml = xml + @" <value><![CDATA[" + model.OPINION[i].MS + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }

            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"</subForms>";
            xml = xml + @"</formExport>";



            return xml;
        }

        public string XML_ZZF(CRM_OA_ZZF model)
        {
            string xml = "";
            xml = xml + @"<formExport version=""2.0"">";
            xml = xml + @"<summary id="""" name=""formmain_2434""/>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0001"" type=""0"" name=""制作类型"" length=""255""/>";
            xml = xml + @"<column id=""field0002"" type=""0"" name=""客户性质"" length=""255""/>";
            xml = xml + @"<column id=""field0003"" type=""0"" name=""客户类型"" length=""255""/>";
            xml = xml + @"<column id=""field0004"" type=""0"" name=""上级客户名称"" length=""255""/>";
            xml = xml + @"<column id=""field0005"" type=""0"" name=""客户名称"" length=""255""/>";
            xml = xml + @"<column id=""field0006"" type=""0"" name=""广告地址"" length=""255""/>";
            xml = xml + @"<column id=""field0007"" type=""0"" name=""店主联系人"" length=""255""/>";
            xml = xml + @"<column id=""field0008"" type=""0"" name=""店主联系电话"" length=""255""/>";
            xml = xml + @"<column id=""field0009"" type=""0"" name=""情况说明"" length=""255""/>";
            xml = xml + @"<column id=""field0010"" type=""0"" name=""位置评估"" length=""255""/>";
            xml = xml + @"<column id=""field0011"" type=""0"" name=""制作前双鹿电池月销售额-元"" length=""255""/>";
            xml = xml + @"<column id=""field0012"" type=""0"" name=""制作后预计双鹿电池月销售额-元"" length=""255""/>";
            xml = xml + @"<column id=""field0013"" type=""0"" name=""是否有促销员支持"" length=""255""/>";
            xml = xml + @"<column id=""field0014"" type=""0"" name=""促销员费用"" length=""255""/>";
            xml = xml + @"<column id=""field0015"" type=""0"" name=""是否产生陈列费用"" length=""255""/>";
            xml = xml + @"<column id=""field0016"" type=""0"" name=""陈列费用-元"" length=""255""/>";
            xml = xml + @"<column id=""field0017"" type=""0"" name=""县区人口-万"" length=""255""/>";
            xml = xml + @"<column id=""field0018"" type=""0"" name=""距最近一家广告距离-千米"" length=""255""/>";
            xml = xml + @"<column id=""field0019"" type=""0"" name=""此县区已有广告数量"" length=""255""/>";
            xml = xml + @"<column id=""field0020"" type=""0"" name=""广告制作费小计"" length=""255""/>";
            xml = xml + @"<column id=""field0021"" type=""0"" name=""广告租赁费"" length=""255""/>";
            xml = xml + @"<column id=""field0022"" type=""0"" name=""租赁开始时间"" length=""255""/>";
            xml = xml + @"<column id=""field0023"" type=""0"" name=""租赁结束时间"" length=""255""/>";
            xml = xml + @"<column id=""field0024"" type=""0"" name=""申请金额合计"" length=""255""/>";
            xml = xml + @"<column id=""field0025"" type=""0"" name=""广告公司名称"" length=""255""/>";
            xml = xml + @"<column id=""field0026"" type=""0"" name=""审批意见"" length=""255""/>";
            xml = xml + @"<column id=""field0032"" type=""0"" name=""数据来源"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            xml = xml + @"<column name=""制作类型"">";
            xml = xml + @"<value><![CDATA[" + model.ZZLX + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""客户性质"">";
            xml = xml + @"<value><![CDATA[" + model.KHXZ + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""客户类型"">";
            xml = xml + @"<value><![CDATA[" + model.KHLX + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""上级客户名称"">";
            xml = xml + @"<value><![CDATA[" + model.PKHMC + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""客户名称"">";
            xml = xml + @"<value><![CDATA[" + model.KHMC + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""广告地址"">";
            xml = xml + @"<value><![CDATA[" + model.ADDRESS + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""店主联系人"">";
            xml = xml + @"<value><![CDATA[" + model.LXR + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""店主联系电话"">";
            xml = xml + @"<value><![CDATA[" + model.LXDH + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""情况说明"">";
            xml = xml + @"<value><![CDATA[" + model.QKSM + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""位置评估"">";
            xml = xml + @"<value><![CDATA[" + model.WZPG + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""制作前双鹿电池月销售额-元"">";
            xml = xml + @"<value><![CDATA[" + model.SALE_BEFORE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""制作后预计双鹿电池月销售额-元"">";
            xml = xml + @"<value><![CDATA[" + model.SALE_AFTER + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""是否有促销员支持"">";
            xml = xml + @"<value><![CDATA[" + model.CXY + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""促销员费用"">";
            xml = xml + @"<value><![CDATA[" + model.CXYFY + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""是否产生陈列费用"">";
            xml = xml + @"<value><![CDATA[" + model.HAVEDISPLAYCOST + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""陈列费用-元"">";
            xml = xml + @"<value><![CDATA[" + model.DISPLAYCOST + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""县区人口-万"">";
            xml = xml + @"<value><![CDATA[" + model.POPULATION + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""距最近一家广告距离-千米"">";
            xml = xml + @"<value><![CDATA[" + model.DISCOUNT + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""此县区已有广告数量"">";
            xml = xml + @"<value><![CDATA[" + model.ADVER_COUNT + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""广告制作费小计"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""广告租赁费"">";
            xml = xml + @"<value><![CDATA[" + model.ZLF + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""租赁开始时间"">";
            xml = xml + @"<value><![CDATA[" + model.BEGINDATE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""租赁结束时间"">";
            xml = xml + @"<value><![CDATA[" + model.ENDDATE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""申请金额合计"">";
            xml = xml + @"<value><![CDATA[" + model.SQJE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""广告公司名称"">";
            xml = xml + @"<value><![CDATA[" + model.GGGSMC + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""审批意见"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""数据来源"">";
            xml = xml + @"<value><![CDATA[CRM]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"</values>";
            xml = xml + @"<subForms>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0027"" type=""0"" name=""材质-项目"" length=""255""/>";
            xml = xml + @"<column id=""field0028"" type=""0"" name=""面积"" length=""255""/>";
            xml = xml + @"<column id=""field0029"" type=""0"" name=""单价-元"" length=""255""/>";
            xml = xml + @"<column id=""field0030"" type=""0"" name=""小计-元"" length=""255""/>";
            xml = xml + @"<column id=""field0031"" type=""0"" name=""备注"" length=""255""/>";
            xml = xml + @"<column id=""field0027"" type=""0"" name=""材质-项目"" length=""255""/>";
            xml = xml + @"<column id=""field0028"" type=""0"" name=""面积"" length=""255""/>";
            xml = xml + @"<column id=""field0029"" type=""0"" name=""单价-元"" length=""255""/>";
            xml = xml + @"<column id=""field0030"" type=""0"" name=""小计-元"" length=""255""/>";
            xml = xml + @"<column id=""field0031"" type=""0"" name=""备注"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            for (int i = 0; i < model.ZZF_MX.Count; i++)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""材质-项目"">";
                xml = xml + @"<value><![CDATA[" + model.ZZF_MX[i].ITEM + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""面积"">";
                xml = xml + @"<value><![CDATA[" + model.ZZF_MX[i].MJ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""单价-元"">";
                xml = xml + @"<value><![CDATA[" + model.ZZF_MX[i].PRICE + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""小计-元"">";
                xml = xml + @"<value><![CDATA[" + model.ZZF_MX[i].XJ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""备注"">";
                xml = xml + @"<value><![CDATA[" + model.ZZF_MX[i].BEIZ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }

            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0033"" type=""1"" name=""历史审批意见"" length=""255""/>";
            xml = xml + @"<column id=""field0034"" type=""1"" name=""历史审批意见2"" length=""255""/>";
            xml = xml + @"<column id=""field0033"" type=""1"" name=""历史审批意见"" length=""255""/>";
            xml = xml + @"<column id=""field0034"" type=""1"" name=""历史审批意见2"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            for (int i = 0; i < model.OPINION.Count; i++)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""历史审批意见"">";
                xml = xml + @" <value><![CDATA[" + model.OPINION[i].OPINION + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""历史审批意见2"">";
                xml = xml + @" <value><![CDATA[" + model.OPINION[i].HFNR + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }


            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"</subForms>";
            xml = xml + @"</formExport>";



            return xml;
        }

        public string XML_KHTS(CRM_OA_KHTS model)
        {
            string xml = "";
            xml = xml + @"<formExport version=""2.0"">";
            xml = xml + @"<summary id="""" name=""formmain_2467""/>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0001"" type=""0"" name=""投诉来源"" length=""255""/>";
            xml = xml + @"<column id=""field0002"" type=""0"" name=""投诉信息提供"" length=""255""/>";
            xml = xml + @"<column id=""field0003"" type=""0"" name=""是否造成用电器损坏"" length=""255""/>";
            xml = xml + @"<column id=""field0004"" type=""0"" name=""用电器价格"" length=""255""/>";
            xml = xml + @"<column id=""field0005"" type=""0"" name=""用电器规格"" length=""255""/>";
            xml = xml + @"<column id=""field0006"" type=""0"" name=""初步判断原因"" length=""255""/>";
            xml = xml + @"<column id=""field0007"" type=""0"" name=""客户名称"" length=""255""/>";
            xml = xml + @"<column id=""field0008"" type=""0"" name=""电话"" length=""255""/>";
            xml = xml + @"<column id=""field0009"" type=""0"" name=""客户地址"" length=""255""/>";
            xml = xml + @"<column id=""field0010"" type=""0"" name=""业务员"" length=""255""/>";
            xml = xml + @"<column id=""field0011"" type=""0"" name=""分管领导"" length=""255""/>";
            xml = xml + @"<column id=""field0012"" type=""0"" name=""客户要求或建议"" length=""255""/>";
            xml = xml + @"<column id=""field0013"" type=""0"" name=""审核意见栏"" length=""255""/>";
            xml = xml + @"<column id=""field0014"" type=""0"" name=""发出时间"" length=""255""/>";
            xml = xml + @"<column id=""field0015"" type=""0"" name=""物流信息"" length=""255""/>";
            xml = xml + @"<column id=""field0016"" type=""0"" name=""件数"" length=""255""/>";
            xml = xml + @"<column id=""field0017"" type=""0"" name=""投诉是否有效"" length=""255""/>";
            xml = xml + @"<column id=""field0018"" type=""0"" name=""投诉结果"" length=""255""/>";
            xml = xml + @"<column id=""field0019"" type=""0"" name=""快递单号"" length=""255""/>";
            xml = xml + @"<column id=""field0020"" type=""0"" name=""备注"" length=""255""/>";
            xml = xml + @"<column id=""field0021"" type=""0"" name=""数据来源"" length=""255""/>";
            xml = xml + @"<column id=""field0027"" type=""0"" name=""流程类型"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            xml = xml + @"<column name=""投诉来源"">";
            xml = xml + @"<value><![CDATA[" + model.TSLY + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""投诉信息提供"">";
            xml = xml + @"<value><![CDATA[" + model.TSXX + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""是否造成用电器损坏"">";
            xml = xml + @"<value><![CDATA[" + model.DAMAGE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""用电器价格"">";
            xml = xml + @"<value><![CDATA[" + model.PRICE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""用电器规格"">";
            xml = xml + @"<value><![CDATA[" + model.GG + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""初步判断原因"">";
            xml = xml + @"<value><![CDATA[" + model.REASON + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""客户名称"">";
            xml = xml + @"<value><![CDATA[" + model.MC + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""电话"">";
            xml = xml + @"<value><![CDATA[" + model.TEL + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""客户地址"">";
            xml = xml + @"<value><![CDATA[" + model.ADDRESS + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""业务员"">";
            //xml = xml + @"<value><![CDATA[" + model.YWY + "]]></value>";
            xml = xml + @" <value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""分管领导"">";
            xml = xml + @"<value><![CDATA[" + model.FGLD + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""客户要求或建议"">";
            xml = xml + @"<value><![CDATA[" + model.KHYQ + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""审核意见栏"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""发出时间"">";
            xml = xml + @"<value><![CDATA[" + model.FCSJ + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""物流信息"">";
            xml = xml + @"<value><![CDATA[" + model.WLXX + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""件数"">";
            xml = xml + @"<value><![CDATA[" + model.JS + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""投诉是否有效"">";
            xml = xml + @"<value><![CDATA[" + model.TSSFYX + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""投诉结果"">";
            xml = xml + @"<value><![CDATA[" + model.TSJG + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""快递单号"">";
            xml = xml + @"<value><![CDATA[" + model.KDDH + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""备注"">";
            xml = xml + @"<value><![CDATA[" + model.BEIZ + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""数据来源"">";
            xml = xml + @"<value><![CDATA[CRM]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""流程类型"">";
            xml = xml + @"<value><![CDATA[" + model.LCLX + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"</values>";
            xml = xml + @"<subForms>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0022"" type=""0"" name=""品牌-产品名称"" length=""255""/>";
            xml = xml + @"<column id=""field0023"" type=""0"" name=""型号-包装规格"" length=""255""/>";
            xml = xml + @"<column id=""field0024"" type=""0"" name=""不良品数量-只"" length=""255""/>";
            xml = xml + @"<column id=""field0025"" type=""0"" name=""日期唛"" length=""255""/>";
            xml = xml + @"<column id=""field0026"" type=""0"" name=""投诉原因"" length=""255""/>";
            xml = xml + @"<column id=""field0022"" type=""0"" name=""品牌-产品名称"" length=""255""/>";
            xml = xml + @"<column id=""field0023"" type=""0"" name=""型号-包装规格"" length=""255""/>";
            xml = xml + @"<column id=""field0024"" type=""0"" name=""不良品数量-只"" length=""255""/>";
            xml = xml + @"<column id=""field0025"" type=""0"" name=""日期唛"" length=""255""/>";
            xml = xml + @"<column id=""field0026"" type=""0"" name=""投诉原因"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            for (int i = 0; i < model.KHTSMX.Count; i++)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""品牌-产品名称"">";
                xml = xml + @"<value><![CDATA[" + model.KHTSMX[i].CPMC + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""型号-包装规格"">";
                xml = xml + @"<value><![CDATA[" + model.KHTSMX[i].BZGG + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""不良品数量-只"">";
                xml = xml + @"<value><![CDATA[" + model.KHTSMX[i].BLPSL + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""日期唛"">";
                xml = xml + @"<value><![CDATA[" + model.KHTSMX[i].RQM + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""投诉原因"">";
                xml = xml + @"<value><![CDATA[" + model.KHTSMX[i].REASON + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }

            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"</subForms>";
            xml = xml + @"</formExport>";




            return xml;
        }

        public string XML_MDBS(CRM_OA_MDBS model)
        {
            string xml = "";
            xml = xml + @"<formExport version=""2.0"">";
            xml = xml + @"<summary id="""" name=""formmain_2575""/>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0003"" type=""1"" name=""审批意见"" length=""255""/>";
            //xml = xml + @"<column id=""field0001"" type=""0"" name=""区域-作废"" length=""255""/>";
            xml = xml + @"<column id=""field0002"" type=""0"" name=""月份-废"" length=""255""/>";
            xml = xml + @"<column id=""field0023"" type=""0"" name=""月份-新"" length=""255""/>";
            xml = xml + @"<column id=""field0024"" type=""0"" name=""流程编号"" length=""255""/>";
            xml = xml + @"<column id=""field0027"" type=""0"" name=""客户类型"" length=""255""/>";
            xml = xml + @"<column id=""field0028"" type=""0"" name=""标题"" length=""255""/>";
            xml = xml + @"<column id=""field0033"" type=""0"" name=""流程类型-新"" length=""255""/>";
            xml = xml + @"<column id=""field0034"" type=""0"" name=""系统类型-新"" length=""255""/>";
            xml = xml + @"<column id=""field0001"" type=""0"" name=""数据来源"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            xml = xml + @"<column name=""审批意见"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            //xml = xml + @"<column name=""区域-作废"">";
            //xml = xml + @"<value/>";
            //xml = xml + @"</column>";
            xml = xml + @"<column name=""月份-废"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""月份-新"">";
            xml = xml + @"<value><![CDATA[" + model.MONTH + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""流程编号"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""客户类型"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""标题"">";
            xml = xml + @"<value><![CDATA[" + model.TITLE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""流程类型-新"">";
            xml = xml + @"<value><![CDATA[" + model.LCTYPE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""系统类型-新"">";
            xml = xml + @"<value><![CDATA[" + model.XTTYPE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""数据来源"">";
            xml = xml + @"<value><![CDATA[CRM]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"</values>";
            xml = xml + @"<subForms>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0004"" type=""0"" name=""系统"" length=""255""/>";
            xml = xml + @"<column id=""field0005"" type=""0"" name=""门店"" length=""255""/>";
            xml = xml + @"<column id=""field0006"" type=""0"" name=""陈列项目"" length=""255""/>";
            xml = xml + @"<column id=""field0011"" type=""0"" name=""费用比例"" length=""255""/>";
            xml = xml + @"<column id=""field0012"" type=""0"" name=""支付方式"" length=""255""/>";
            xml = xml + @"<column id=""field0013"" type=""4"" name=""本月实际销售"" length=""20""/>";
            xml = xml + @"<column id=""field0014"" type=""4"" name=""实际费用"" length=""20""/>";
            xml = xml + @"<column id=""field0015"" type=""0"" name=""效果评估-费用比例"" length=""255""/>";
            xml = xml + @"<column id=""field0016"" type=""0"" name=""备注"" length=""255""/>";
            xml = xml + @"<column id=""field0009"" type=""4"" name=""预计费用"" length=""20""/>";
            xml = xml + @"<column id=""field0007"" type=""0"" name=""陈列开始时间"" length=""255""/>";
            xml = xml + @"<column id=""field0017"" type=""0"" name=""城市"" length=""255""/>";
            xml = xml + @"<column id=""field0018"" type=""0"" name=""陈列位置"" length=""255""/>";
            xml = xml + @"<column id=""field0019"" type=""0"" name=""省份"" length=""255""/>";
            xml = xml + @"<column id=""field0020"" type=""0"" name=""陈列结束时间"" length=""255""/>";
            xml = xml + @"<column id=""field0021"" type=""4"" name=""实际核销金额"" length=""20""/>";
            xml = xml + @"<column id=""field0022"" type=""0"" name=""核销日期"" length=""255""/>";
            xml = xml + @"<column id=""field0025"" type=""0"" name=""有无促销员"" length=""255""/>";
            xml = xml + @"<column id=""field0026"" type=""0"" name=""有无形象地堆"" length=""255""/>";
            xml = xml + @"<column id=""field0010"" type=""4"" name=""预计本月销售"" length=""20""/>";
            xml = xml + @"<column id=""field0008"" type=""4"" name=""前三月均销售"" length=""20""/>";
            xml = xml + @"<column id=""field0035"" type=""0"" name=""备注2"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            for (int i = 0; i < model.MDBSMX.Count; i++)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""系统"">";
                xml = xml + @"<value><![CDATA[" + model.MDBSMX[i].MC + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""门店"">";
                xml = xml + @"<value><![CDATA[" + model.MDBSMX[i].MDMC + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""陈列项目"">";
                xml = xml + @"<value><![CDATA[" + model.MDBSMX[i].DISPLAY + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""费用比例"">";
                xml = xml + @"<value><![CDATA[" + model.MDBSMX[i].FB + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""支付方式"">";
                xml = xml + @"<value><![CDATA[" + model.MDBSMX[i].PAYWAY + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""本月实际销售"">";
                xml = xml + @"<value><![CDATA[" + model.MDBSMX[i].HX_SJXS + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""实际费用"">";
                xml = xml + @"<value><![CDATA[" + model.MDBSMX[i].SJFY + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""效果评估-费用比例"">";
                xml = xml + @"<value><![CDATA[" + model.MDBSMX[i].HX_FB + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""备注"">";
                xml = xml + @"<value><![CDATA[" + model.MDBSMX[i].BEIZ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""预计费用"">";
                xml = xml + @"<value><![CDATA[" + model.MDBSMX[i].YJFY + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""陈列开始时间"">";
                xml = xml + @"<value><![CDATA[" + model.MDBSMX[i].BEGINDATE + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""城市"">";
                xml = xml + @"<value><![CDATA[" + model.MDBSMX[i].CS + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""陈列位置"">";
                xml = xml + @"<value><![CDATA[" + model.MDBSMX[i].POSITION + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""省份"">";
                xml = xml + @"<value><![CDATA[" + model.MDBSMX[i].SF + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""陈列结束时间"">";
                xml = xml + @"<value><![CDATA[" + model.MDBSMX[i].ENDDATE + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""实际核销金额"">";
                xml = xml + @"<value><![CDATA[" + model.MDBSMX[i].HX_JE + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""核销日期"">";
                xml = xml + @"<value><![CDATA[" + model.MDBSMX[i].HXRQ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""有无促销员"">";
                xml = xml + @"<value><![CDATA[" + model.MDBSMX[i].CXY + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""有无形象地堆"">";
                xml = xml + @"<value><![CDATA[" + model.MDBSMX[i].XXDD + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""预计本月销售"">";
                xml = xml + @"<value><![CDATA[" + model.MDBSMX[i].YJXS + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""前三月均销售"">";
                xml = xml + @"<value><![CDATA[" + model.MDBSMX[i].QSYJXS + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""备注2"">";
                xml = xml + @"<value><![CDATA[" + model.MDBSMX[i].BEIZ2 + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }

            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0029"" type=""0"" name=""历史1"" length=""255""/>";
            xml = xml + @"<column id=""field0030"" type=""0"" name=""历史2"" length=""255""/>";
            xml = xml + @"<column id=""field0036"" type=""0"" name=""历史3"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            for (int i = 0; i < model.OPINION.Count; i++)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""历史1"">";
                xml = xml + @"<value><![CDATA[" + model.OPINION[i].OPINION + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""历史2"">";
                xml = xml + @"<value><![CDATA[" + model.OPINION[i].HFNR + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""历史3"">";
                xml = xml + @"<value><![CDATA[" + model.OPINION[i].MS + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }

            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"</subForms>";
            xml = xml + @"</formExport>";




            return xml;
        }

        public string XML_KAYEAR(CRM_OA_KAYEAR model)
        {
            string xml = "";
            xml = xml + @"<formExport version=""2.0"">";
            xml = xml + @"<summary id="""" name=""formmain_2577""/>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0001"" type=""0"" name=""客户名称"" length=""255""/>";
            xml = xml + @"<column id=""field0002"" type=""0"" name=""年度合同开始日期"" length=""255""/>";
            xml = xml + @"<column id=""field0003"" type=""0"" name=""年度合同结束日期"" length=""255""/>";
            xml = xml + @"<column id=""field0004"" type=""0"" name=""年度"" length=""255""/>";
            xml = xml + @"<column id=""field0005"" type=""0"" name=""年度2"" length=""255""/>";
            xml = xml + @"<column id=""field0006"" type=""0"" name=""账期"" length=""255""/>";
            xml = xml + @"<column id=""field0007"" type=""0"" name=""账期2"" length=""255""/>";
            xml = xml + @"<column id=""field0008"" type=""0"" name=""门店数量"" length=""255""/>";
            xml = xml + @"<column id=""field0009"" type=""4"" name=""POS零售额"" length=""20""/>";
            xml = xml + @"<column id=""field0010"" type=""4"" name=""POS零售额2"" length=""20""/>";
            xml = xml + @"<column id=""field0011"" type=""4"" name=""进货额"" length=""20""/>";
            xml = xml + @"<column id=""field0012"" type=""4"" name=""进货额2"" length=""20""/>";
            xml = xml + @"<column id=""field0013"" type=""4"" name=""开票额"" length=""20""/>";
            xml = xml + @"<column id=""field0014"" type=""4"" name=""开票额2"" length=""20""/>";
            xml = xml + @"<column id=""field0015"" type=""0"" name=""备注"" length=""255""/>";
            xml = xml + @"<column id=""field0016"" type=""0"" name=""门店数量2"" length=""255""/>";
            xml = xml + @"<column id=""field0017"" type=""4"" name=""金额合计"" length=""20""/>";
            xml = xml + @"<column id=""field0018"" type=""4"" name=""费用率合计"" length=""20""/>";
            xml = xml + @"<column id=""field0019"" type=""4"" name=""费用率合计2"" length=""20""/>";
            xml = xml + @"<column id=""field0020"" type=""4"" name=""金额合计2"" length=""20""/>";
            xml = xml + @"<column id=""field0021"" type=""0"" name=""备注3"" length=""255""/>";
            xml = xml + @"<column id=""field0022"" type=""0"" name=""备注4"" length=""255""/>";
            xml = xml + @"<column id=""field0023"" type=""0"" name=""备注5"" length=""255""/>";
            xml = xml + @"<column id=""field0024"" type=""0"" name=""备注6"" length=""255""/>";
            xml = xml + @"<column id=""field0025"" type=""0"" name=""备注7"" length=""255""/>";
            xml = xml + @"<column id=""field0034"" type=""0"" name=""数据来源"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            xml = xml + @"<column name=""客户名称"">";
            xml = xml + @"<value><![CDATA[" + model.MC + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""年度合同开始日期"">";
            xml = xml + @"<value><![CDATA[" + model.BEGINDATE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""年度合同结束日期"">";
            xml = xml + @"<value><![CDATA[" + model.ENDDATE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""年度"">";
            xml = xml + @"<value><![CDATA[" + model.YEAR + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""年度2"">";
            xml = xml + @"<value><![CDATA[" + model.YEAR2 + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""账期"">";
            xml = xml + @"<value><![CDATA[" + model.ZQ + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""账期2"">";
            xml = xml + @"<value><![CDATA[" + model.ZQ2 + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""门店数量"">";
            xml = xml + @"<value><![CDATA[" + model.MDSL + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""POS零售额"">";
            xml = xml + @"<value><![CDATA[" + model.POS + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""POS零售额2"">";
            xml = xml + @"<value><![CDATA[" + model.POS2 + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""进货额"">";
            xml = xml + @"<value><![CDATA[" + model.JH + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""进货额2"">";
            xml = xml + @"<value><![CDATA[" + model.JH2 + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""开票额"">";
            xml = xml + @"<value><![CDATA[" + model.KP + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""开票额2"">";
            xml = xml + @"<value><![CDATA[" + model.KP2 + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""备注"">";
            xml = xml + @"<value><![CDATA[" + model.BEIZ1 + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""门店数量2"">";
            xml = xml + @"<value><![CDATA[" + model.MDSL2 + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""金额合计"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""费用率合计"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""费用率合计2"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""金额合计2"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""备注3"">";
            xml = xml + @"<value><![CDATA[" + model.BEIZ2 + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""备注4"">";
            xml = xml + @"<value><![CDATA[" + model.BEIZ3 + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""备注5"">";
            xml = xml + @"<value><![CDATA[" + model.BEIZ4 + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""备注6"">";
            xml = xml + @"<value><![CDATA[" + model.BEIZ5 + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""备注7"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""数据来源"">";
            xml = xml + @"<value><![CDATA[CRM]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"</values>";
            xml = xml + @"<subForms>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0026"" type=""0"" name=""费用项目"" length=""255""/>";
            xml = xml + @"<column id=""field0027"" type=""0"" name=""合同条款"" length=""255""/>";
            xml = xml + @"<column id=""field0028"" type=""4"" name=""金额"" length=""20""/>";
            xml = xml + @"<column id=""field0029"" type=""4"" name=""费用率"" length=""20""/>";
            xml = xml + @"<column id=""field0030"" type=""0"" name=""合同条款2"" length=""255""/>";
            xml = xml + @"<column id=""field0031"" type=""4"" name=""金额2"" length=""20""/>";
            xml = xml + @"<column id=""field0032"" type=""4"" name=""费用率2"" length=""20""/>";
            xml = xml + @"<column id=""field0033"" type=""0"" name=""备注2"" length=""255""/>";
            xml = xml + @"<column id=""field0035"" type=""4"" name=""修改前的历史数据"" length=""20""/>";
            xml = xml + @"<column id=""field0026"" type=""0"" name=""费用项目"" length=""255""/>";
            xml = xml + @"<column id=""field0027"" type=""0"" name=""合同条款"" length=""255""/>";
            xml = xml + @"<column id=""field0028"" type=""4"" name=""金额"" length=""20""/>";
            xml = xml + @"<column id=""field0029"" type=""4"" name=""费用率"" length=""20""/>";
            xml = xml + @"<column id=""field0030"" type=""0"" name=""合同条款2"" length=""255""/>";
            xml = xml + @"<column id=""field0031"" type=""4"" name=""金额2"" length=""20""/>";
            xml = xml + @"<column id=""field0032"" type=""4"" name=""费用率2"" length=""20""/>";
            xml = xml + @"<column id=""field0033"" type=""0"" name=""备注2"" length=""255""/>";
            xml = xml + @"<column id=""field0035"" type=""4"" name=""修改前的历史数据"" length=""20""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            for (int i = 0; i < model.KAYEARMX.Count; i++)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""费用项目"">";
                xml = xml + @"<value><![CDATA[" + model.KAYEARMX[i].ITEM + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""合同条款"">";
                xml = xml + @"<value><![CDATA[" + model.KAYEARMX[i].HTTK + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""金额"">";
                xml = xml + @"<value><![CDATA[" + model.KAYEARMX[i].JE + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""费用率"">";
                xml = xml + @"<value><![CDATA[" + model.KAYEARMX[i].FYL + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""合同条款2"">";
                xml = xml + @"<value><![CDATA[" + model.KAYEARMX[i].HTTK2 + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""金额2"">";
                xml = xml + @"<value><![CDATA[" + model.KAYEARMX[i].JE2XG + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""费用率2"">";
                xml = xml + @"<value><![CDATA[" + model.KAYEARMX[i].FYL2 + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""备注2"">";
                xml = xml + @"<value><![CDATA[" + model.KAYEARMX[i].BEIZ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""修改前的历史数据"">";
                xml = xml + @"<value><![CDATA[" + model.KAYEARMX[i].JE2 + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }

            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0036"" type=""0"" name=""历史1"" length=""255""/>";
            xml = xml + @"<column id=""field0037"" type=""0"" name=""历史2"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            for (int i = 0; i < model.OPINION.Count; i++)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""历史1"">";
                xml = xml + @"<value><![CDATA[" + model.OPINION[i].OPINION + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""历史2"">";
                xml = xml + @"<value><![CDATA[" + model.OPINION[i].HFNR + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }
            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"</subForms>";
            xml = xml + @"</formExport>";




            return xml;
        }

        public string XML_KADT(CRM_OA_KADT model)
        {
            string xml = "";
            xml = xml + @"<formExport version=""2.0"">";
            xml = xml + @"<summary id="""" name=""formmain_2581""/>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0001"" type=""0"" name=""合同年份"" length=""255""/>";
            xml = xml + @"<column id=""field0002"" type=""0"" name=""业务员"" length=""255""/>";
            xml = xml + @"<column id=""field0003"" type=""0"" name=""卖场名称"" length=""255""/>";
            xml = xml + @"<column id=""field0004"" type=""0"" name=""卖场CRM编号"" length=""255""/>";
            xml = xml + @"<column id=""field0005"" type=""0"" name=""卖场门店数量"" length=""255""/>";
            xml = xml + @"<column id=""field0006"" type=""0"" name=""累计申请的堆头-海报档期金额"" length=""255""/>";
            xml = xml + @"<column id=""field0007"" type=""0"" name=""已核销堆头-海报费用"" length=""255""/>";
            xml = xml + @"<column id=""field0008"" type=""0"" name=""活动方案说明"" length=""255""/>";
            xml = xml + @"<column id=""field0009"" type=""0"" name=""活动开始日期"" length=""255""/>";
            xml = xml + @"<column id=""field0010"" type=""0"" name=""活动结束日期"" length=""255""/>";
            xml = xml + @"<column id=""field0011"" type=""0"" name=""最晚发货日期"" length=""255""/>";
            xml = xml + @"<column id=""field0012"" type=""0"" name=""档期"" length=""255""/>";
            xml = xml + @"<column id=""field0013"" type=""0"" name=""促销级别"" length=""255""/>";
            xml = xml + @"<column id=""field0014"" type=""0"" name=""日常月均销售"" length=""255""/>";
            xml = xml + @"<column id=""field0015"" type=""0"" name=""预计活动期间销售"" length=""255""/>";
            xml = xml + @"<column id=""field0016"" type=""0"" name=""预计费比"" length=""255""/>";
            xml = xml + @"<column id=""field0017"" type=""0"" name=""数据来源"" length=""255""/>";
            xml = xml + @"<column id=""field0041"" type=""0"" name=""备注1"" length = ""255"" />";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            xml = xml + @"<column name=""合同年份"">";
            xml = xml + @"<value><![CDATA[" + model.HTYEAR + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""业务员"">";
            xml = xml + @"<value><![CDATA[" + model.YWY + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""卖场名称"">";
            xml = xml + @"<value><![CDATA[" + model.MC + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""卖场CRM编号"">";
            xml = xml + @"<value><![CDATA[" + model.CRMID + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""卖场门店数量"">";
            xml = xml + @"<value><![CDATA[" + model.MDSL + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""累计申请的堆头-海报档期金额"">";
            xml = xml + @"<value><![CDATA[" + model.LJSQJE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""已核销堆头-海报费用"">";
            xml = xml + @"<value><![CDATA[" + model.YHXJE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""活动方案说明"">";
            xml = xml + @"<value><![CDATA[" + model.HDFASM + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""活动开始日期"">";
            xml = xml + @"<value><![CDATA[" + model.BEGINDATE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""活动结束日期"">";
            xml = xml + @"<value><![CDATA[" + model.ENDDATE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""最晚发货日期"">";
            xml = xml + @"<value><![CDATA[" + model.FAHUO + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""档期"">";
            xml = xml + @"<value><![CDATA[" + model.DQ + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""促销级别"">";
            xml = xml + @"<value><![CDATA[" + model.CXJB + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""日常月均销售"">";
            xml = xml + @"<value><![CDATA[" + model.RCYJXS + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""预计活动期间销售"">";
            xml = xml + @"<value><![CDATA[" + model.YJXS + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""预计费比"">";
            xml = xml + @"<value><![CDATA[" + model.YJFB + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""数据来源"">";
            xml = xml + @"<value><![CDATA[CRM]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""备注1"">";
            xml = xml + @"<value><![CDATA[" + model.BEIZ + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"</values>";
            xml = xml + @"<subForms>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0018"" type=""0"" name=""序号"" length=""255""/>";
            xml = xml + @"<column id=""field0019"" type=""0"" name=""SAP产品编号"" length=""255""/>";
            xml = xml + @"<column id=""field0020"" type=""0"" name=""产品名称"" length=""255""/>";
            xml = xml + @"<column id=""field0021"" type=""0"" name=""正常供价"" length=""255""/>";
            xml = xml + @"<column id=""field0022"" type=""0"" name=""促销供价"" length=""255""/>";
            xml = xml + @"<column id=""field0023"" type=""0"" name=""正常售价"" length=""255""/>";
            xml = xml + @"<column id=""field0024"" type=""0"" name=""促销售价"" length=""255""/>";
            xml = xml + @"<column id=""field0025"" type=""0"" name=""备货数量"" length=""255""/>";
            xml = xml + @"<column id=""field0026"" type=""0"" name=""备注"" length=""255""/>";
            xml = xml + @"<column id=""field0018"" type=""0"" name=""序号"" length=""255""/>";
            xml = xml + @"<column id=""field0019"" type=""0"" name=""SAP产品编号"" length=""255""/>";
            xml = xml + @"<column id=""field0020"" type=""0"" name=""产品名称"" length=""255""/>";
            xml = xml + @"<column id=""field0021"" type=""0"" name=""正常供价"" length=""255""/>";
            xml = xml + @"<column id=""field0022"" type=""0"" name=""促销供价"" length=""255""/>";
            xml = xml + @"<column id=""field0023"" type=""0"" name=""正常售价"" length=""255""/>";
            xml = xml + @"<column id=""field0024"" type=""0"" name=""促销售价"" length=""255""/>";
            xml = xml + @"<column id=""field0025"" type=""0"" name=""备货数量"" length=""255""/>";
            xml = xml + @"<column id=""field0026"" type=""0"" name=""备注"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            for (int i = 0; i < model.KADTCP.Count; i++)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""序号"">";
                xml = xml + @"<value/>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""SAP产品编号"">";
                xml = xml + @"<value><![CDATA[" + model.KADTCP[i].SAPCP + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""产品名称"">";
                xml = xml + @"<value><![CDATA[" + model.KADTCP[i].CPMC + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""正常供价"">";
                xml = xml + @"<value><![CDATA[" + model.KADTCP[i].ZCGJ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""促销供价"">";
                xml = xml + @"<value><![CDATA[" + model.KADTCP[i].CXGJ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""正常售价"">";
                xml = xml + @"<value><![CDATA[" + model.KADTCP[i].ZCSJ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""促销售价"">";
                xml = xml + @"<value><![CDATA[" + model.KADTCP[i].CXSJ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""备货数量"">";
                xml = xml + @"<value><![CDATA[" + model.KADTCP[i].BHSL + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""备注"">";
                xml = xml + @"<value><![CDATA[" + model.KADTCP[i].BEIZ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }

            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0027"" type=""0"" name=""序号2"" length=""255""/>";
            xml = xml + @"<column id=""field0028"" type=""0"" name=""费用类型"" length=""255""/>";
            xml = xml + @"<column id=""field0029"" type=""0"" name=""促销类型"" length=""255""/>";
            xml = xml + @"<column id=""field0030"" type=""4"" name=""费用金额"" length=""20""/>";
            xml = xml + @"<column id=""field0031"" type=""0"" name=""参加活动门店数量"" length=""255""/>";
            xml = xml + @"<column id=""field0035"" type=""0"" name=""是否合同约定"" length=""255""/>";
            xml = xml + @"<column id=""field0036"" type=""0"" name=""活动结束总结"" length=""255"" />";
            xml = xml + @"<column id=""field0037"" type=""4"" name=""实际费用"" length=""20"" />";
            xml = xml + @"<column id=""field0039"" type=""4"" name=""实际销售"" length=""20"" />";
            xml = xml + @"<column id=""field0042"" type=""0"" name=""备注2"" length=""255"" />";
            xml = xml + @"<column id=""field0043"" type=""4"" name=""实际费比"" length=""20"" />";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            for (int i = 0; i < model.KADTMX.Count; i++)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""序号2"">";
                xml = xml + @"<value/>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""费用类型"">";
                xml = xml + @"<value><![CDATA[" + model.KADTMX[i].FYLX + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""促销类型"">";
                xml = xml + @"<value><![CDATA[" + model.KADTMX[i].CXLX + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""费用金额"">";
                xml = xml + @"<value><![CDATA[" + model.KADTMX[i].FYJE + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""参加活动门店数量"">";
                xml = xml + @"<value><![CDATA[" + model.KADTMX[i].CJHDMDSL + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""是否合同约定"">";
                xml = xml + @"<value><![CDATA[" + model.KADTMX[i].PROMISE + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""实际销售"">";
                xml = xml + @"<value><![CDATA[" + model.KADTMX[i].SJXS + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""实际费用"">";
                xml = xml + @"<value><![CDATA[" + model.KADTMX[i].SJFY + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""实际费比"">";
                xml = xml + @"<value><![CDATA[" + model.KADTMX[i].SJFB + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""活动结束总结"">";
                xml = xml + @"<value><![CDATA[" + model.KADTMX[i].HDJSZJ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""备注2"">";
                xml = xml + @"<value><![CDATA[" + model.KADTMX[i].BEIZ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }

            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0032"" type=""0"" name=""历史1"" length=""255""/>";
            xml = xml + @"<column id=""field0033"" type=""0"" name=""历史2"" length=""255""/>";
            xml = xml + @"<column id=""field0034"" type=""0"" name=""描述"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            for (int i = 0; i < model.OPINION.Count; i++)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""历史1"">";
                xml = xml + @"<value><![CDATA[" + model.OPINION[i].OPINION + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""历史2"">";
                xml = xml + @"<value><![CDATA[" + model.OPINION[i].HFNR + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""描述"">";
                xml = xml + @"<value><![CDATA[" + model.OPINION[i].MS + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }

            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"</subForms>";
            xml = xml + @"</formExport>";




            return xml;
        }

        public string XML_KATSCL(CRM_OA_KATSCL model)
        {
            string xml = "";
            xml = xml + @"<formExport version=""2.0"">";
            xml = xml + @"<summary id="""" name=""formmain_2584""/>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0001"" type=""0"" name=""合同年份"" length=""255""/>";
            xml = xml + @"<column id=""field0002"" type=""0"" name=""业务员"" length=""255""/>";
            xml = xml + @"<column id=""field0003"" type=""0"" name=""卖场名称"" length=""255""/>";
            xml = xml + @"<column id=""field0004"" type=""0"" name=""卖场CRM编号"" length=""255""/>";
            xml = xml + @"<column id=""field0005"" type=""0"" name=""卖场门店数量"" length=""255""/>";
            xml = xml + @"<column id=""field0006"" type=""0"" name=""累计申请的特殊陈列费"" length=""255""/>";
            xml = xml + @"<column id=""field0007"" type=""0"" name=""已核销特殊陈列费"" length=""255""/>";
            xml = xml + @"<column id=""field0008"" type=""0"" name=""数据来源"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            xml = xml + @"<column name=""合同年份"">";
            xml = xml + @"<value><![CDATA[" + model.HTYEAR + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""业务员"">";
            xml = xml + @"<value><![CDATA[" + model.YWY + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""卖场名称"">";
            xml = xml + @"<value><![CDATA[" + model.MC + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""卖场CRM编号"">";
            xml = xml + @"<value><![CDATA[" + model.CRMID + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""卖场门店数量"">";
            xml = xml + @"<value><![CDATA[" + model.MDSL + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""累计申请的特殊陈列费"">";
            xml = xml + @"<value><![CDATA[" + model.LJSQJE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""已核销特殊陈列费"">";
            xml = xml + @"<value><![CDATA[" + model.YHXJE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""数据来源"">";
            xml = xml + @"<value><![CDATA[CRM]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"</values>";
            xml = xml + @"<subForms>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0009"" type=""0"" name=""序号"" length=""255""/>";
            xml = xml + @"<column id=""field0010"" type=""0"" name=""卖场系统-门店名称"" length=""255""/>";
            xml = xml + @"<column id=""field0011"" type=""0"" name=""陈列方式"" length=""255""/>";
            xml = xml + @"<column id=""field0012"" type=""0"" name=""开始日期"" length=""255""/>";
            xml = xml + @"<column id=""field0013"" type=""0"" name=""结束日期"" length=""255""/>";
            xml = xml + @"<column id=""field0014"" type=""4"" name=""费用金额"" length=""20""/>";
            xml = xml + @"<column id=""field0015"" type=""4"" name=""日常月均销售"" length=""20""/>";
            xml = xml + @"<column id=""field0016"" type=""4"" name=""预计销售"" length=""20""/>";
            xml = xml + @"<column id=""field0017"" type=""0"" name=""预计费比"" length=""255""/>";
            xml = xml + @"<column id=""field0018"" type=""0"" name=""备注"" length=""255""/>";
            xml = xml + @"<column id=""field0026"" type=""0"" name=""活动结束总结"" length=""255"" />";
            xml = xml + @"<column id=""field0028"" type=""4"" name=""实际费用"" length=""20"" />";
            xml = xml + @"<column id=""field0030"" type=""4"" name=""实际销售"" length=""20"" />";
            xml = xml + @"<column id=""field0032"" type=""0"" name=""备注1"" length=""255"" />";
            xml = xml + @"<column id=""field0033"" type=""4"" name=""实际费比"" length=""20"" />";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            for (int i = 0; i < model.KATSCLMX.Count; i++)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""序号"">";
                xml = xml + @"<value/>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""卖场系统-门店名称"">";
                xml = xml + @"<value><![CDATA[" + model.KATSCLMX[i].MC + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""陈列方式"">";
                xml = xml + @"<value><![CDATA[" + model.KATSCLMX[i].DISPLAY + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""开始日期"">";
                xml = xml + @"<value><![CDATA[" + model.KATSCLMX[i].BEGINDATE + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""结束日期"">";
                xml = xml + @"<value><![CDATA[" + model.KATSCLMX[i].ENDDATE + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""费用金额"">";
                xml = xml + @"<value><![CDATA[" + model.KATSCLMX[i].FYJE + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""日常月均销售"">";
                xml = xml + @"<value><![CDATA[" + model.KATSCLMX[i].RCYJXS + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""预计销售"">";
                xml = xml + @"<value><![CDATA[" + model.KATSCLMX[i].YJXS + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""预计费比"">";
                xml = xml + @"<value><![CDATA[" + model.KATSCLMX[i].YJFB + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""备注"">";
                xml = xml + @"<value><![CDATA[" + model.KATSCLMX[i].BEIZ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""实际销售"">";
                xml = xml + @"<value><![CDATA[" + model.KATSCLMX[i].SJXS + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""实际费用"">";
                xml = xml + @"<value><![CDATA[" + model.KATSCLMX[i].SJFY + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""实际费比"">";
                xml = xml + @"<value><![CDATA[" + model.KATSCLMX[i].SJFB + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""活动结束总结"">";
                xml = xml + @"<value><![CDATA[" + model.KATSCLMX[i].HDJSZJ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""备注1"">";
                xml = xml + @"<value><![CDATA[" + model.KATSCLMX[i].BEIZ2 + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }

            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0019"" type=""0"" name=""历史1"" length=""255""/>";
            xml = xml + @"<column id=""field0020"" type=""0"" name=""历史2"" length=""255""/>";
            xml = xml + @"<column id=""field0021"" type=""0"" name=""描述"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            for (int i = 0; i < model.OPINION.Count; i++)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""历史1"">";
                xml = xml + @"<value><![CDATA[" + model.OPINION[i].OPINION + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""历史2"">";
                xml = xml + @"<value><![CDATA[" + model.OPINION[i].HFNR + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""描述"">";
                xml = xml + @"<value><![CDATA[" + model.OPINION[i].MS + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }

            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"</subForms>";
            xml = xml + @"</formExport>";




            return xml;
        }

        public string XML_KACXY(CRM_OA_KACXY model)
        {
            string xml = "";
            xml = xml + @"<formExport version=""2.0"">";
            xml = xml + @"<summary id="""" name=""formmain_2612""/>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0001"" type=""0"" name=""申请人"" length=""255""/>";
            xml = xml + @"<column id=""field0002"" type=""0"" name=""申请日期"" length=""255""/>";
            xml = xml + @"<column id=""field0003"" type=""0"" name=""审批意见"" length=""255""/>";
            xml = xml + @"<column id=""field0004"" type=""0"" name=""门店名称"" length=""255""/>";
            xml = xml + @"<column id=""field0005"" type=""0"" name=""流程编号"" length=""255""/>";
            xml = xml + @"<column id=""field0006"" type=""0"" name=""系统名称-新"" length=""255""/>";
            xml = xml + @"<column id=""field0007"" type=""0"" name=""数据来源"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            xml = xml + @"<column name=""申请人"">";
            //xml = xml + @"<value><![CDATA[" + model.SQR + "]]></value>";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""申请日期"">";
            xml = xml + @"<value><![CDATA[" + model.SQRQ + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""审批意见"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""门店名称"">";
            xml = xml + @"<value><![CDATA[" + model.MDMC + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""流程编号"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""系统名称-新"">";
            xml = xml + @"<value><![CDATA[" + model.MC + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""数据来源"">";
            xml = xml + @"<value><![CDATA[CRM]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"</values>";
            xml = xml + @"<subForms>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0008"" type=""0"" name=""省份"" length=""255""/>";
            xml = xml + @"<column id=""field0009"" type=""0"" name=""城市"" length=""255""/>";
            xml = xml + @"<column id=""field0010"" type=""0"" name=""负责人"" length=""255""/>";
            xml = xml + @"<column id=""field0011"" type=""0"" name=""岗位"" length=""255""/>";
            xml = xml + @"<column id=""field0012"" type=""4"" name=""考核基数"" length=""20""/>";
            xml = xml + @"<column id=""field0013"" type=""0"" name=""姓名"" length=""255""/>";
            xml = xml + @"<column id=""field0014"" type=""0"" name=""性别"" length=""255""/>";
            xml = xml + @"<column id=""field0015"" type=""0"" name=""身份证号码"" length=""255""/>";
            xml = xml + @"<column id=""field0016"" type=""0"" name=""联系电话"" length=""255""/>";
            xml = xml + @"<column id=""field0017"" type=""0"" name=""上岗日期"" length=""255""/>";
            xml = xml + @"<column id=""field0018"" type=""0"" name=""全职厂商"" length=""255""/>";
            xml = xml + @"<column id=""field0019"" type=""4"" name=""销售额1"" length=""20""/>";
            xml = xml + @"<column id=""field0020"" type=""4"" name=""销售额2"" length=""20""/>";
            xml = xml + @"<column id=""field0021"" type=""4"" name=""销售额3"" length=""20""/>";
            xml = xml + @"<column id=""field0022"" type=""4"" name=""所有电池品牌月均销售总额"" length=""20""/>";
            xml = xml + @"<column id=""field0023"" type=""0"" name=""资源支持"" length=""255""/>";
            xml = xml + @"<column id=""field0024"" type=""0"" name=""人员更换"" length=""255""/>";
            xml = xml + @"<column id=""field0025"" type=""4"" name=""上岗后预估月销售额"" length=""20""/>";
            xml = xml + @"<column id=""field0026"" type=""0"" name=""开户银行"" length=""255""/>";
            xml = xml + @"<column id=""field0027"" type=""0"" name=""银行卡号"" length=""255""/>";
            xml = xml + @"<column id=""field0028"" type=""0"" name=""系统"" length=""255""/>";
            xml = xml + @"<column id=""field0031"" type=""0"" name=""备注"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            for (int i = 0; i < model.KACXYMX.Count; i++)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""省份"">";
                xml = xml + @"<value><![CDATA[" + model.KACXYMX[i].SF + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""城市"">";
                xml = xml + @"<value><![CDATA[" + model.KACXYMX[i].CS + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""负责人"">";
                xml = xml + @"<value><![CDATA[" + model.KACXYMX[i].FZR + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""岗位"">";
                xml = xml + @"<value><![CDATA[" + model.KACXYMX[i].GW + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""考核基数"">";
                xml = xml + @"<value><![CDATA[" + model.KACXYMX[i].KHJS + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""姓名"">";
                xml = xml + @"<value><![CDATA[" + model.KACXYMX[i].NAME + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""性别"">";
                xml = xml + @"<value><![CDATA[" + model.KACXYMX[i].SEX + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""身份证号码"">";
                xml = xml + @"<value><![CDATA[" + model.KACXYMX[i].SFZ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""联系电话"">";
                xml = xml + @"<value><![CDATA[" + model.KACXYMX[i].TEL + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""上岗日期"">";
                xml = xml + @"<value><![CDATA[" + model.KACXYMX[i].SGRQ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""全职厂商"">";
                xml = xml + @"<value><![CDATA[" + model.KACXYMX[i].QZCS + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""销售额1"">";
                xml = xml + @"<value><![CDATA[" + model.KACXYMX[i].XS1 + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""销售额2"">";
                xml = xml + @"<value><![CDATA[" + model.KACXYMX[i].XS2 + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""销售额3"">";
                xml = xml + @"<value><![CDATA[" + model.KACXYMX[i].XS3 + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""所有电池品牌月均销售总额"">";
                xml = xml + @"<value><![CDATA[" + model.KACXYMX[i].XSZE + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""资源支持"">";
                xml = xml + @"<value><![CDATA[" + model.KACXYMX[i].SUPPORT + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""人员更换"">";
                xml = xml + @"<value><![CDATA[" + model.KACXYMX[i].CHANGE + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""上岗后预估月销售额"">";
                xml = xml + @"<value><![CDATA[" + model.KACXYMX[i].YJXS + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""开户银行"">";
                xml = xml + @"<value><![CDATA[" + model.KACXYMX[i].BANK + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""银行卡号"">";
                xml = xml + @"<value><![CDATA[" + model.KACXYMX[i].BANKCARD + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""系统"">";
                xml = xml + @"<value/>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""备注"">";
                xml = xml + @"<value><![CDATA[" + model.KACXYMX[i].BEIZ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }

            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0029"" type=""0"" name=""历史1"" length=""255""/>";
            xml = xml + @"<column id=""field0030"" type=""0"" name=""历史2"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            for (int i = 0; i < model.OPINION.Count; i++)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""历史1"">";
                xml = xml + @"<value><![CDATA[" + model.OPINION[i].OPINION + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""历史2"">";
                xml = xml + @"<value><![CDATA[" + model.OPINION[i].HFNR + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }

            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"</subForms>";
            xml = xml + @"</formExport>";





            return xml;
        }

        public string XML_CXHD(CRM_OA_CXHD model)
        {
            string xml = "";

            xml = xml + @"<formExport version=""2.0"">";
            xml = xml + @"<summary id="""" name=""formmain_2983""/>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0001"" type=""0"" name=""申请人"" length=""255""/>";
            xml = xml + @"<column id=""field0002"" type=""0"" name=""申请日期"" length=""255""/>";
            xml = xml + @"<column id=""field0003"" type=""0"" name=""归属年份"" length=""255""/>";
            xml = xml + @"<column id=""field0004"" type=""0"" name=""经销商名称"" length=""255""/>";
            xml = xml + @"<column id=""field0005"" type=""0"" name=""经销商客户编号"" length=""255""/>";
            xml = xml + @"<column id=""field0006"" type=""0"" name=""活动名称"" length=""255""/>";
            xml = xml + @"<column id=""field0007"" type=""0"" name=""活动编号"" length=""255""/>";
            xml = xml + @"<column id=""field0008"" type=""0"" name=""促销活动开展时间"" length=""255""/>";
            xml = xml + @"<column id=""field0009"" type=""0"" name=""向公司提货时间"" length=""255""/>";
            xml = xml + @"<column id=""field0010"" type=""0"" name=""活动对象"" length=""255""/>";
            xml = xml + @"<column id=""field0011"" type=""0"" name=""活动目的和内容"" length=""255""/>";
            xml = xml + @"<column id=""field0012"" type=""0"" name=""公司支持说明"" length=""255""/>";
            xml = xml + @"<column id=""field0013"" type=""4"" name=""合计1"" length=""20""/>";
            xml = xml + @"<column id=""field0014"" type=""4"" name=""合计2"" length=""20""/>";
            xml = xml + @"<column id=""field0015"" type=""4"" name=""合计3"" length=""20""/>";
            xml = xml + @"<column id=""field0016"" type=""4"" name=""合计4"" length=""20""/>";
            xml = xml + @"<column id=""field0017"" type=""4"" name=""合计5"" length=""20""/>";
            xml = xml + @"<column id=""field0018"" type=""4"" name=""合计6"" length=""20""/>";
            xml = xml + @"<column id=""field0019"" type=""4"" name=""促销活动费比"" length=""20""/>";
            xml = xml + @"<column id=""field0020"" type=""4"" name=""经销商承担费用"" length=""20""/>";
            xml = xml + @"<column id=""field0021"" type=""4"" name=""预计活动网点参加数量"" length=""20""/>";
            xml = xml + @"<column id=""field0022"" type=""4"" name=""已经在OA备案的网点数量"" length=""20""/>";
            xml = xml + @"<column id=""field0023"" type=""4"" name=""经销商本年度销售任务"" length=""20""/>";
            xml = xml + @"<column id=""field0024"" type=""4"" name=""经销商本年度A类任务"" length=""20""/>";
            xml = xml + @"<column id=""field0025"" type=""0"" name=""审批意见"" length=""4000""/>";
            xml = xml + @"<column id=""field0026"" type=""1"" name=""区域负责人评估"" length=""4000""/>";
            xml = xml + @"<column id=""field0027"" type=""0"" name=""参加本次活动的网点"" length=""255""/>";
            xml = xml + @"<column id=""field0028"" type=""4"" name=""合计7"" length=""20""/>";
            xml = xml + @"<column id=""field0029"" type=""4"" name=""合计8"" length=""20""/>";
            xml = xml + @"<column id=""field0030"" type=""4"" name=""合计9"" length=""20""/>";
            xml = xml + @"<column id=""field0031"" type=""0"" name=""核算意见"" length=""4000""/>";
            xml = xml + @"<column id=""field0032"" type=""0"" name=""流程类型"" length=""255""/>";
            xml = xml + @"<column id=""field0033"" type=""0"" name=""数据来源"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            xml = xml + @"<column name=""申请人"">";
            //xml = xml + @"<value><![CDATA[4194125152346851129]]></value>";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""申请日期"">";
            xml = xml + @"<value><![CDATA[" + model.SQRQ + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""归属年份"">";
            xml = xml + @"<value><![CDATA[" + model.GSYEAR + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""经销商名称"">";
            xml = xml + @"<value><![CDATA[" + model.JXSMC + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""经销商客户编号"">";
            xml = xml + @"<value><![CDATA[" + model.JXSSAPSN + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""活动名称"">";
            xml = xml + @"<value><![CDATA[" + model.HDMC + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""活动编号"">";
            xml = xml + @"<value><![CDATA[" + model.HDBH + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""促销活动开展时间"">";
            xml = xml + @"<value><![CDATA[" + model.HDDATE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""向公司提货时间"">";
            xml = xml + @"<value><![CDATA[" + model.THDATE + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""活动对象"">";
            xml = xml + @"<value><![CDATA[" + model.HDDX + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""活动目的和内容"">";
            xml = xml + @"<value><![CDATA[" + model.HDMD + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""公司支持说明"">";
            xml = xml + @"<value><![CDATA[" + model.GSZCSM + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""合计1"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""合计2"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""合计3"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""合计4"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""合计5"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""合计6"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""促销活动费比"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""经销商承担费用"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""预计活动网点参加数量"">";
            xml = xml + @"<value><![CDATA[" + model.YJCJHDWDSL + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""已经在OA备案的网点数量"">";
            xml = xml + @"<value><![CDATA[" + model.BASL + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""经销商本年度销售任务"">";
            xml = xml + @"<value><![CDATA[" + model.JXSXSRW + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""经销商本年度A类任务"">";
            xml = xml + @"<value><![CDATA[" + model.JXSARW + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""审批意见"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""区域负责人评估"">";
            xml = xml + @"<value><![CDATA[" + model.PG + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""参加本次活动的网点"">";
            xml = xml + @"<value><![CDATA[" + model.CJHDWDSL + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""合计7"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""合计8"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""合计9"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""核算意见"">";
            xml = xml + @"<value/>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""流程类型"">";
            xml = xml + @"<value><![CDATA[" + model.LCLX + "]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"<column name=""数据来源"">";
            xml = xml + @"<value><![CDATA[CRM]]></value>";
            xml = xml + @"</column>";
            xml = xml + @"</values>";
            xml = xml + @"<subForms>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0034"" type=""0"" name=""活动套餐类型"" length=""255""/>";
            xml = xml + @"<column id=""field0035"" type=""0"" name=""套餐内容"" length=""255""/>";
            xml = xml + @"<column id=""field0036"" type=""4"" name=""套餐金额"" length=""20""/>";
            xml = xml + @"<column id=""field0037"" type=""0"" name=""赠送礼品"" length=""255""/>";
            xml = xml + @"<column id=""field0038"" type=""4"" name=""单套礼品金额"" length=""20""/>";
            xml = xml + @"<column id=""field0039"" type=""4"" name=""预计套餐数量"" length=""20""/>";
            xml = xml + @"<column id=""field0040"" type=""4"" name=""预计活动销售"" length=""20""/>";
            xml = xml + @"<column id=""field0041"" type=""4"" name=""预计礼品金额"" length=""20""/>";
            xml = xml + @"<column id=""field0042"" type=""4"" name=""费比"" length=""20""/>";
            xml = xml + @"<column id=""field0043"" type=""0"" name=""备注1"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            for (int i = 0; i < model.CXHDTC.Count; i++)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""活动套餐类型"">";
                xml = xml + @"<value><![CDATA[" + model.CXHDTC[i].HDTCLX + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""套餐内容"">";
                xml = xml + @"<value><![CDATA[" + model.CXHDTC[i].TCNR + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""套餐金额"">";
                xml = xml + @"<value><![CDATA[" + model.CXHDTC[i].TCJE + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""赠送礼品"">";
                xml = xml + @"<value><![CDATA[" + model.CXHDTC[i].GIFT + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""单套礼品金额"">";
                xml = xml + @"<value><![CDATA[" + model.CXHDTC[i].PRICE + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""预计套餐数量"">";
                xml = xml + @"<value><![CDATA[" + model.CXHDTC[i].TCCOUNT + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""预计活动销售"">";
                xml = xml + @"<value><![CDATA[" + model.CXHDTC[i].YJXS + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""预计礼品金额"">";
                xml = xml + @"<value><![CDATA[" + model.CXHDTC[i].YJLPJE + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""费比"">";
                xml = xml + @"<value><![CDATA[" + model.CXHDTC[i].FB + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""备注1"">";
                xml = xml + @"<value><![CDATA[" + model.CXHDTC[i].BEIZ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }

            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0044"" type=""0"" name=""产品分类"" length=""255""/>";
            xml = xml + @"<column id=""field0045"" type=""0"" name=""单品名称"" length=""255""/>";
            xml = xml + @"<column id=""field0046"" type=""4"" name=""预计活动数量"" length=""20""/>";
            xml = xml + @"<column id=""field0047"" type=""4"" name=""预计活动销售2"" length=""20""/>";
            xml = xml + @"<column id=""field0048"" type=""0"" name=""费用支持方式"" length=""255""/>";
            xml = xml + @"<column id=""field0049"" type=""4"" name=""费用支持额度"" length=""20""/>";
            xml = xml + @"<column id=""field0050"" type=""4"" name=""费用支持金额"" length=""20""/>";
            xml = xml + @"<column id=""field0051"" type=""4"" name=""上年活动单品月均销售"" length=""20""/>";
            xml = xml + @"<column id=""field0052"" type=""4"" name=""上年活动单品月均数量"" length=""20""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            for (int i = 0; i < model.GSZCFS.Count; i++)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""产品分类"">";
                xml = xml + @"<value><![CDATA[" + model.GSZCFS[i].CPFL + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""单品名称"">";
                xml = xml + @"<value><![CDATA[" + model.GSZCFS[i].DPMC + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""预计活动数量"">";
                xml = xml + @"<value><![CDATA[" + model.GSZCFS[i].YJHDSL + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""预计活动销售2"">";
                xml = xml + @"<value><![CDATA[" + model.GSZCFS[i].YJXS + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""费用支持方式"">";
                xml = xml + @"<value><![CDATA[" + model.GSZCFS[i].FYZCFS + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""费用支持额度"">";
                xml = xml + @"<value><![CDATA[" + model.GSZCFS[i].FYZC + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""费用支持金额"">";
                xml = xml + @"<value><![CDATA[" + model.GSZCFS[i].FYZCJE + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""上年活动单品月均销售"">";
                xml = xml + @"<value><![CDATA[" + model.GSZCFS[i].SNYJXS + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""上年活动单品月均数量"">";
                xml = xml + @"<value><![CDATA[" + model.GSZCFS[i].SNYJSL + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }

            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0053"" type=""0"" name=""产品分类2"" length=""255""/>";
            xml = xml + @"<column id=""field0054"" type=""0"" name=""单品名称2"" length=""255""/>";
            xml = xml + @"<column id=""field0055"" type=""4"" name=""实际活动数量"" length=""20""/>";
            xml = xml + @"<column id=""field0056"" type=""4"" name=""实际活动销售"" length=""20""/>";
            xml = xml + @"<column id=""field0057"" type=""0"" name=""费用支持方式2"" length=""255""/>";
            xml = xml + @"<column id=""field0058"" type=""4"" name=""费用支持额度2"" length=""20""/>";
            xml = xml + @"<column id=""field0059"" type=""4"" name=""费用支持金额2"" length=""20""/>";
            xml = xml + @"<column id=""field0060"" type=""0"" name=""实际提货率"" length=""255""/>";
            xml = xml + @"<column id=""field0061"" type=""0"" name=""倍数"" length=""255""/>";
            xml = xml + @"<column id=""field0062"" type=""0"" name=""备注2"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            for (int i = 0; i < model.CXHDPG.Count; i++)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""产品分类2"">";
                xml = xml + @"<value><![CDATA[" + model.CXHDPG[i].CPFL + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""单品名称2"">";
                xml = xml + @"<value><![CDATA[" + model.CXHDPG[i].DPMC + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""实际活动数量"">";
                xml = xml + @"<value><![CDATA[" + model.CXHDPG[i].SJHDSL + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""实际活动销售"">";
                xml = xml + @"<value><![CDATA[" + model.CXHDPG[i].SJHDXS + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""费用支持方式2"">";
                xml = xml + @"<value><![CDATA[" + model.CXHDPG[i].FYZCFS + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""费用支持额度2"">";
                xml = xml + @"<value><![CDATA[" + model.CXHDPG[i].FYZC + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""费用支持金额2"">";
                xml = xml + @"<value><![CDATA[" + model.CXHDPG[i].FYZCJE + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""实际提货率"">";
                xml = xml + @"<value><![CDATA[" + model.CXHDPG[i].SJTHL + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""倍数"">";
                xml = xml + @"<value><![CDATA[" + model.CXHDPG[i].BS + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""备注2"">";
                xml = xml + @"<value><![CDATA[" + model.CXHDPG[i].BEIZ + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }

            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0063"" type=""0"" name=""历史审批意见1"" length=""255""/>";
            xml = xml + @"<column id=""field0064"" type=""0"" name=""历史审批意见2"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            for (int i = 0; i < model.OPINION.Count; i++)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""历史审批意见1"">";
                xml = xml + @"<value><![CDATA[" + model.OPINION[i].OPINION + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""历史审批意见2"">";
                xml = xml + @"<value><![CDATA[" + model.OPINION[i].HFNR + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }

            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"<subForm>";
            xml = xml + @"<definitions>";
            xml = xml + @"<column id=""field0065"" type=""0"" name=""历史审批意见3"" length=""255""/>";
            xml = xml + @"<column id=""field0066"" type=""0"" name=""历史审批意见4"" length=""255""/>";
            xml = xml + @"</definitions>";
            xml = xml + @"<values>";
            for (int i = 0; i < model.OPINION2.Count; i++)
            {
                xml = xml + @"<row>";
                xml = xml + @"<column name=""历史审批意见3"">";
                xml = xml + @"<value><![CDATA[" + model.OPINION2[i].OPINION + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""历史审批意见4"">";
                xml = xml + @"<value><![CDATA[" + model.OPINION2[i].HFNR + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</row>";
            }

            xml = xml + @"</values>";
            xml = xml + @"</subForm>";
            xml = xml + @"</subForms>";
            xml = xml + @"</formExport>";





            return xml;
        }



        #endregion

        #region   OA发送流程
        /// <summary>
        /// 请假的OA流程
        /// </summary>
        /// <param name="basic"></param>
        /// <param name="QJ_model"></param>
        /// <returns></returns>
        public MessageInfo Launch_QJ(CRM_OA_BASIC basic, CRM_OA_QJList QJ_model)
        {
            //string filepath = Excel_Path(ExcelType.QJ, QJ_model);
            //return filepath;
            string token = GetAuthority();
            #region  附件需要的调用函数
            //string fileID = HttpUploadFile(url + token, filepath);
            //fileID = fileID.Substring(0, fileID.Length - 2);
            #endregion
            long[] att = new long[1];
            //att[0] = long.Parse(fileID);
            return _DataAccess.Launch(token, basic.LoginName, basic.TemplateCode, basic.Subject + DateTime.Now.ToString() + ")", XML_QJ(QJ_model), att, "0", "");
            //if (string.IsNullOrEmpty(result) == false)
            //{
            //    if (result.Length > 5 && filepath.Length > 0)
            //    {
            //        FileInfo fi = new FileInfo(filepath);
            //        fi.Delete();
            //    }
            //}

        }
        public MessageInfo Launch_QJ_Test(CRM_OA_BASIC basic, CRM_OA_QJList QJ_model)
        {
            //string filepath = Excel_Path(ExcelType.QJ, QJ_model);
            //return filepath;
            string token = GetAuthority();
            #region  附件需要的调用函数
            //string fileID = HttpUploadFile(url + token, filepath);
            //fileID = fileID.Substring(0, fileID.Length - 2);
            #endregion
            long[] att = new long[1];
            //att[0] = long.Parse(fileID);
            return _DataAccess.Launch(token, basic.LoginName, basic.TemplateCode, basic.Subject + DateTime.Now.ToString() + ")", XML_QJ_Test(QJ_model), att, "0", "");
            //if (string.IsNullOrEmpty(result) == false)
            //{
            //    if (result.Length > 5 && filepath.Length > 0)
            //    {
            //        FileInfo fi = new FileInfo(filepath);
            //        fi.Delete();
            //    }
            //}

        }
        /// <summary>
        /// 出差OA流程
        /// </summary>
        /// <param name="basic"></param>
        /// <param name="CC_model"></param>
        /// <returns></returns>
        public MessageInfo Launch_CC(CRM_OA_BASIC basic, CRM_OA_CC CC_model)
        {

            long[] att = new long[100];
            string xml = "";
            if (basic.TemplateCode == "10004")
            {
                xml = XML_CC_HX(CC_model);
                for (int i = 0; i < CC_model.IMG.Length; i++)
                {
                    if (string.IsNullOrEmpty(CC_model.IMG[i]) == false)
                    {
                        att[i] = long.Parse(HttpUploadFile("", CC_model.IMG[i], ""));
                    }
                }

            }
            else if (basic.TemplateCode == "10002")
            {
                xml = XML_CC(CC_model);

            }

            return Launch_OA(GetAuthority(), basic.LoginName, basic.TemplateCode, basic.Subject + DateTime.Now.ToString() + ")", xml, att, "0", "");
        }

        public MessageInfo Launch_KH(CRM_OA_BASIC basic, CRM_OA_KH KH_model)
        {
            long[] att = new long[100];
            List<long> all_att = new List<long>();
            string xml = "";
            if (basic.TemplateCode == "10003")
            {
                //xml = XML_KH_JXS(KH_model);
            }
            else if (basic.TemplateCode == "10005")
            {
                xml = XML_KH_ZDWD(KH_model);
                for (int i = 0; i < KH_model.CRM_OA_KH_subWDList.Count; i++)
                {
                    for (int j = 0; j < KH_model.CRM_OA_KH_subWDList[i].IMG.Count; j++)
                    {
                        if (string.IsNullOrEmpty(KH_model.CRM_OA_KH_subWDList[i].IMG[j].MTZP) == false)
                        {
                            long temp = long.Parse(HttpUploadFile("", KH_model.CRM_OA_KH_subWDList[i].IMG[j].MTZP, KH_model.CRM_OA_KH_subWDList[i].IMG[j].MTZPMC));
                            all_att.Add(temp);
                        }
                    }


                }
                att = all_att.ToArray();
            }
            else if (basic.TemplateCode == "10006")
            {
                xml = XML_KH_LKA(KH_model);
            }
            else if (basic.TemplateCode == "10007")
            {
                xml = XML_KH_ZXS(KH_model);
            }
            else if (basic.TemplateCode == "10009")
            {
                xml = XML_KH_JXS(KH_model);
                //CRM_OA_KH_WD

            }


            return Launch_OA(GetAuthority(), basic.LoginName, basic.TemplateCode, basic.Subject, xml, att, "0", "");
        }
        public MessageInfo Launch_YCKQSM(CRM_OA_BASIC basic, CRM_OA_YCKQSM model)
        {
            return Launch_OA(GetAuthority(), basic.LoginName, basic.TemplateCode, basic.Subject + DateTime.Now.ToString() + ")", XML_YCKQSM(model), new long[1], "0", "");
        }
        public MessageInfo Launch_ZDF(CRM_OA_BASIC basic, CRM_OA_ZDF model)
        {
            return Launch_OA(GetAuthority(), basic.LoginName, basic.TemplateCode, basic.Subject + DateTime.Now.ToString() + ")", XML_ZDF(model), new long[1], "0", "");
        }
        public MessageInfo Launch_LKAYEAR(CRM_OA_BASIC basic, CRM_OA_LKAYEAR model)
        {
            long[] att = new long[100];
            for (int i = 0; i < model.IMG.Count; i++)
            {
                if (string.IsNullOrEmpty(model.IMG[i].IMGML) == false)
                {
                    att[i] = long.Parse(HttpUploadFile("", model.IMG[i].IMGML, model.IMG[i].IMGMS));
                }
            }
            return Launch_OA(GetAuthority(), basic.LoginName, basic.TemplateCode, null, XML_LKAYEAR(model), att, "0", "");
        }
        public MessageInfo Launch_HaiBao(CRM_OA_BASIC basic, CRM_OA_HaiBao model)
        {
            long[] att = new long[100];
            for (int i = 0; i < model.IMG.Count; i++)
            {
                if (string.IsNullOrEmpty(model.IMG[i].IMGML) == false)
                {
                    att[i] = long.Parse(HttpUploadFile("", model.IMG[i].IMGML, model.IMG[i].IMGMS));
                }
            }
            return Launch_OA(GetAuthority(), basic.LoginName, basic.TemplateCode, null, XML_LKA_DT_HB_CXZ(model), att, "0", "");
        }
        public MessageInfo Launch_TSCL(CRM_OA_BASIC basic, CRM_OA_TSCL model)
        {
            long[] att = new long[100];
            for (int i = 0; i < model.IMG.Count; i++)
            {
                if (string.IsNullOrEmpty(model.IMG[i].IMGML) == false)
                {
                    att[i] = long.Parse(HttpUploadFile("", model.IMG[i].IMGML, model.IMG[i].IMGMS));
                }
            }
            return Launch_OA(GetAuthority(), basic.LoginName, basic.TemplateCode, null, XML_TSCL(model), att, "0", "");
        }
        public MessageInfo Launch_ZZF(CRM_OA_BASIC basic, CRM_OA_ZZF model)
        {
            long[] att = new long[100];
            for (int i = 0; i < model.IMG.Count; i++)
            {
                if (string.IsNullOrEmpty(model.IMG[i].IMGML) == false)
                {
                    att[i] = long.Parse(HttpUploadFile("", model.IMG[i].IMGML, model.IMG[i].IMGMS));
                }
            }
            return Launch_OA(GetAuthority(), basic.LoginName, basic.TemplateCode, null, XML_ZZF(model), att, "0", "");
        }
        public MessageInfo Launch_KHTS(CRM_OA_BASIC basic, CRM_OA_KHTS model)
        {
            long[] att = new long[100];
            for (int i = 0; i < model.IMG.Count; i++)
            {
                if (string.IsNullOrEmpty(model.IMG[i].IMGML) == false)
                {
                    att[i] = long.Parse(HttpUploadFile("", model.IMG[i].IMGML, model.IMG[i].IMGMS));
                }
            }
            return Launch_OA(GetAuthority(), basic.LoginName, basic.TemplateCode, null, XML_KHTS(model), att, "0", "");
        }
        public MessageInfo Launch_MDBS(CRM_OA_BASIC basic, CRM_OA_MDBS model)
        {
            long[] att = new long[100];
            for (int i = 0; i < model.IMG.Count; i++)
            {
                if (string.IsNullOrEmpty(model.IMG[i].IMGML) == false)
                {
                    att[i] = long.Parse(HttpUploadFile("", model.IMG[i].IMGML, model.IMG[i].IMGMS));
                }
            }
            return Launch_OA(GetAuthority(), basic.LoginName, basic.TemplateCode, basic.Subject, XML_MDBS(model), att, "0", "");
        }
        public MessageInfo Launch_KAYEAR(CRM_OA_BASIC basic, CRM_OA_KAYEAR model)
        {
            long[] att = new long[100];
            for (int i = 0; i < model.IMG.Count; i++)
            {
                if (string.IsNullOrEmpty(model.IMG[i].IMGML) == false)
                {
                    att[i] = long.Parse(HttpUploadFile("", model.IMG[i].IMGML, ""));
                }
            }
            return Launch_OA(GetAuthority(), basic.LoginName, basic.TemplateCode, null, XML_KAYEAR(model), att, "0", "");
        }
        public MessageInfo Launch_KADT(CRM_OA_BASIC basic, CRM_OA_KADT model)
        {
            long[] att = new long[100];
            for (int i = 0; i < model.IMG.Count; i++)
            {
                if (string.IsNullOrEmpty(model.IMG[i].IMGML) == false)
                {
                    att[i] = long.Parse(HttpUploadFile("", model.IMG[i].IMGML, model.IMG[i].IMGMS));
                }
            }
            return Launch_OA(GetAuthority(), basic.LoginName, basic.TemplateCode, null, XML_KADT(model), att, "0", "");
        }
        public MessageInfo Launch_KATSCL(CRM_OA_BASIC basic, CRM_OA_KATSCL model)
        {
            long[] att = new long[100];
            for (int i = 0; i < model.IMG.Count; i++)
            {
                if (string.IsNullOrEmpty(model.IMG[i].IMGML) == false)
                {
                    att[i] = long.Parse(HttpUploadFile("", model.IMG[i].IMGML, model.IMG[i].IMGMS));
                }
            }
            return Launch_OA(GetAuthority(), basic.LoginName, basic.TemplateCode, null, XML_KATSCL(model), att, "0", "");
        }
        public MessageInfo Launch_KACXY(CRM_OA_BASIC basic, CRM_OA_KACXY model)
        {
            long[] att = new long[100];
            for (int i = 0; i < model.IMG.Count; i++)
            {
                if (string.IsNullOrEmpty(model.IMG[i].IMGML) == false)
                {
                    att[i] = long.Parse(HttpUploadFile("", model.IMG[i].IMGML, ""));
                }
            }
            return Launch_OA(GetAuthority(), basic.LoginName, basic.TemplateCode, null, XML_KACXY(model), att, "0", "");
        }
        public MessageInfo Launch_CXHD(CRM_OA_BASIC basic, CRM_OA_CXHD model)
        {
            long[] att = new long[100];
            for (int i = 0; i < model.IMG.Count; i++)
            {
                if (string.IsNullOrEmpty(model.IMG[i].IMGML) == false)
                {
                    att[i] = long.Parse(HttpUploadFile("", model.IMG[i].IMGML, ""));
                }
            }
            return Launch_OA(GetAuthority(), basic.LoginName, basic.TemplateCode, null, XML_CXHD(model), att, "0", "");
        }


        /// <summary>
        /// 统一发送OA接口
        /// </summary>
        /// <param name="tokenid"></param>
        /// <param name="loginName"></param>
        /// <param name="templateCode"></param>
        /// <param name="subject"></param>
        /// <param name="xml"></param>
        /// <param name="att"></param>
        /// <param name="isPass"></param>
        /// <param name="relative"></param>
        /// <returns></returns>
        public MessageInfo Launch_OA(string tokenid, string loginName, string templateCode, string subject, string xml, long[] att, string isPass, string relative)
        {
            return _DataAccess.Launch(tokenid, loginName, templateCode, subject, xml, att, isPass, relative);
        }
        #endregion

        #region OA通用化-单独处理

        /// <summary>
        /// KA特殊陈列费（模板号：10020）
        /// </summary>
        /// <param name="staffID">用户ID</param>
        /// <param name="id">KATSCLTTID</param>
        /// <returns></returns>
        public MessageInfo KATSCLFlow(int staffID, string id)
        {
            //查询
            CRM_OA_BASIC basic = new CRM_OA_BASIC()
            {
                LoginName = new HG_STAFF().RaedBySTAFFID(staffID).STAFFNO,
                TemplateCode = "10020" //new SYS_CS().Read(22)[0].CS.ToString()
            };
            CRM_COST_KATSCLTT KATSCLTT = new COST_KATSCLTT().ReadByParam(new CRM_COST_KATSCLTT() { KATSCLTTID = Convert.ToInt32(id) }, staffID)[0]; //TTdata
            IList<CRM_COST_KATSCLMX> KATSCLMX = new COST_KATSCLMX().ReadByParam(new CRM_COST_KATSCLMX() { KATSCLTTID = Convert.ToInt32(id) });//MXmodel
            List<CRM_OA_KATSCL.CRM_OA_KATSCL_IMG> IMG = new List<CRM_OA_KATSCL.CRM_OA_KATSCL_IMG>();//all_img
            List<CRM_OA_KATSCL.CRM_OA_KATSCL_OPINION> OPINION = new List<CRM_OA_KATSCL.CRM_OA_KATSCL_OPINION>();//all_opinion
            for (int i = 0; i < KATSCLMX.Count; i++)
            {
                CRM_OA_OPINION cx_opinion = new CRM_OA_OPINION
                {
                    OACSLB = 2024,
                    OACSBH = KATSCLMX[i].KATSCLMXID
                };
                IList<CRM_OA_OPINION> opinion = new OA_OPINION().ReadByParam(cx_opinion);
                for (int j = 0; j < opinion.Count; j++)
                {
                    CRM_OA_KATSCL.CRM_OA_KATSCL_OPINION temp = new CRM_OA_KATSCL.CRM_OA_KATSCL_OPINION
                    {
                        OPINION = opinion[j].SPSJ + " " + opinion[j].SPRNAME + " " + opinion[j].ATTITUDE + " " + opinion[j].OPINION,
                        HFNR = opinion[j].HFSJ + " " + opinion[j].STAFFNAME + " 回复内容： " + opinion[j].HFNR,
                        MS = KATSCLMX[i].MC
                    };
                    OPINION.Add(temp);
                }
                IList<CRM_HG_WJJL> FJ = new HG_WJJL().Read(27, KATSCLMX[i].KATSCLMXID);
                for (int j = 0; j < FJ.Count; j++)
                {
                    CRM_OA_KATSCL.CRM_OA_KATSCL_IMG temp = new CRM_OA_KATSCL.CRM_OA_KATSCL_IMG
                    {
                        IMGML = FJ[j].ML,
                        IMGMS = FJ[j].WJM.Replace(".jpg", " ")
                    };
                    IMG.Add(temp);
                }
            }

            //转换
            List<Dictionary<string, object>> newDataList0 = new List<Dictionary<string, object>>();
            List<Dictionary<string, object>> newDataList1 = new List<Dictionary<string, object>>();
            for (int i = 0; i < KATSCLMX.Count; i++)
            {
                newDataList0.Add(new Dictionary<string, object>
                {
                    { "卖场系统-门店名称", KATSCLMX[i].MC },
                    { "陈列方式", KATSCLMX[i].CLFSDES },
                    { "开始日期", KATSCLMX[i].BEGINDATE },
                    { "结束日期", KATSCLMX[i].ENDDATE },
                    { "费用金额", KATSCLMX[i].FYJE.ToString() },
                    { "日常月均销售", KATSCLMX[i].RCYJXS.ToString() },
                    { "预计销售", KATSCLMX[i].YJXS.ToString() },
                    { "预计费比", (KATSCLMX[i].YJFB / 100).ToString() },
                    { "备注", KATSCLMX[i].BEIZ }
                });
            }
            for (int i = 0; i < OPINION.Count; i++)
            {
                newDataList1.Add(new Dictionary<string, object>
                {
                    { "历史1", OPINION[i].OPINION },
                    { "历史2", OPINION[i].HFNR },
                    { "描述", OPINION[i].MS }
                });
            }
            Dictionary<string, object> newData = new Dictionary<string, object>
            {
                { "合同年份", KATSCLTT.HTYEAR },
                { "业务员", KATSCLTT.CJRNAME },
                { "卖场名称", KATSCLTT.MC },
                { "卖场CRM编号", KATSCLTT.CRMID },
                { "卖场门店数量", KATSCLTT.MDSL.ToString() },
                { "累计申请的特殊陈列费", KATSCLTT.LJSQJE.ToString() },
                { "已核销特殊陈列费", KATSCLTT.YHXNDJE.ToString() },
                { "0", newDataList0 },
                { "1", newDataList1 }
            };

            //发起并记录
            long[] att = new long[100];
            for (int i = 0; i < IMG.Count; i++)
            {
                if (string.IsNullOrEmpty(IMG[i].IMGML) == false)
                {
                    att[i] = long.Parse(HttpUploadFile("", IMG[i].IMGML, IMG[i].IMGMS));
                }
            }
            MessageInfo info = Launch_OA(GetAuthority(), basic.LoginName, basic.TemplateCode, null, CreateFlow(basic.TemplateCode, newData), att, "0", "");
            if (info.Key != "0" && info.Key != "-1")
            {
                for (int j = 0; j < KATSCLMX.Count; j++)
                {
                    KATSCLMX[j].ISACTIVE = 20;
                    new COST_KATSCLMX().Update(KATSCLMX[j]);
                    CRM_OA_TRANSMIT model = new CRM_OA_TRANSMIT
                    {
                        OAID = info.Key,
                        OACSBH = KATSCLMX[j].KATSCLMXID,
                        OACSLB = 2024,
                        OAZT = 1,
                        CJSJ = DateTime.Now.ToString("yyyy-MM-dd")
                    };
                    new OA_TRANSMIT().Create(model);
                }
            }
            return info;
        }

        /// <summary>
        /// KA堆头海报费用（模板号：10019）
        /// </summary>
        /// <param name="staffID">用户ID</param>
        /// <param name="id">KADTTTID</param>
        /// <returns></returns>
        public MessageInfo KADTFlow(int staffID, string id)
        {
            //查询
            CRM_OA_BASIC basic = new CRM_OA_BASIC()
            {
                LoginName = new HG_STAFF().RaedBySTAFFID(staffID).STAFFNO,
                TemplateCode = "10019" //new SYS_CS().Read(21)[0].CS.ToString()
            };
            CRM_COST_KADTTT KADTTT = new COST_KADTTT().ReadByParam(new CRM_COST_KADTTT() { KADTTTID = Convert.ToInt32(id) }, staffID)[0];
            IList<CRM_COST_KADTDP> KADTDP = new COST_KADTDP().ReadByParam(new CRM_COST_KADTDP() { KADTTTID = Convert.ToInt32(id) });
            IList<CRM_COST_KADTMX> KADTMX = new COST_KADTMX().ReadByParam(new CRM_COST_KADTMX() { KADTTTID = Convert.ToInt32(id) });
            IList<CRM_HG_WJJL> IMG = new HG_WJJL().Read(26, Convert.ToInt32(id));
            List<CRM_OA_KADT.CRM_OA_KADT_OPINION> OPINION = new List<CRM_OA_KADT.CRM_OA_KADT_OPINION>();
            for (int i = 0; i < KADTMX.Count; i++)
            {
                CRM_OA_OPINION cx_opinion = new CRM_OA_OPINION
                {
                    OACSLB = 2023,
                    OACSBH = KADTMX[i].KADTMXID
                };
                IList<CRM_OA_OPINION> opinion = new OA_OPINION().ReadByParam(cx_opinion);
                for (int j = 0; j < opinion.Count; j++)
                {
                    CRM_OA_KADT.CRM_OA_KADT_OPINION temp = new CRM_OA_KADT.CRM_OA_KADT_OPINION
                    {
                        OPINION = opinion[j].SPSJ + " " + opinion[j].SPRNAME + " " + opinion[j].ATTITUDE + " " + opinion[j].OPINION,
                        HFNR = opinion[j].HFSJ + " " + opinion[j].STAFFNAME + " 回复内容： " + opinion[j].HFNR,
                        MS = KADTMX[i].COSTITEMIDDES + "-" + KADTMX[i].CXLXDES
                    };
                    OPINION.Add(temp);
                }
            }

            //转换
            List<Dictionary<string, object>> newDataList0 = new List<Dictionary<string, object>>();
            List<Dictionary<string, object>> newDataList1 = new List<Dictionary<string, object>>();
            List<Dictionary<string, object>> newDataList2 = new List<Dictionary<string, object>>();
            decimal SQJE = 0;
            for (int i = 0; i < KADTMX.Count; i++)
            {
                newDataList0.Add(new Dictionary<string, object>
                {
                    { "费用类型", KADTMX[i].COSTITEMIDDES },
                    { "促销类型", KADTMX[i].CXLXDES },
                    { "费用金额", KADTMX[i].FYJE.ToString() },
                    { "参加活动门店数量", KADTMX[i].CJHDMDSL.ToString() },
                    { "是否合同约定", KADTMX[i].PROMISE == 1 ? "是" : "否" }
                });
                SQJE = SQJE + KADTMX[i].FYJE;
            }
            for (int i = 0; i < KADTDP.Count; i++)
            {
                newDataList1.Add(new Dictionary<string, object>
                {
                    { "SAP产品编号", KADTDP[i].SAPCP },
                    { "产品名称", KADTDP[i].CPMC },
                    { "正常供价", KADTDP[i].ZCGJ },
                    { "促销供价", KADTDP[i].CXGJ },
                    { "正常售价", KADTDP[i].ZCSJ },
                    { "促销售价", KADTDP[i].CXSJ },
                    { "备货数量", KADTDP[i].BHSL },
                    { "备注", KADTDP[i].BEIZ }
                });
            }
            for (int i = 0; i < OPINION.Count; i++)
            {
                newDataList2.Add(new Dictionary<string, object>
                {
                    { "历史1", OPINION[i].OPINION },
                    { "历史2", OPINION[i].HFNR },
                    { "描述", OPINION[i].MS }
                });
            }
            Dictionary<string, object> newData = new Dictionary<string, object>
            {
                { "合同年份", KADTTT.HTYEAR },
                { "业务员", KADTTT.YWY },
                { "卖场名称", KADTTT.MC },
                { "卖场CRM编号", KADTTT.CRMID },
                { "卖场门店数量", KADTTT.MDSL },
                { "累计申请的堆头-海报档期金额", KADTTT.LJSQJE },
                { "已核销堆头-海报费用", KADTTT.YHXNDJE },
                { "活动方案说明", KADTTT.HDFASM },
                { "活动开始日期", KADTTT.HDBEGINDATE },
                { "活动结束日期", KADTTT.HDENDDATE },
                { "最晚发货日期", KADTTT.FHDATE },
                { "档期", KADTTT.DQ },
                { "促销级别", KADTTT.CXJB },
                { "日常月均销售", KADTTT.RCYJXS },
                { "预计活动期间销售", KADTTT.YJHDQJXS },
                { "预计费比", Math.Round((SQJE / KADTTT.YJHDQJXS * 100), 2, MidpointRounding.AwayFromZero).ToString() + "%" },
                { "0", newDataList0 },
                { "1", newDataList1 },
                { "2", newDataList2 }
            };

            //发起并记录
            long[] att = new long[100];
            for (int i = 0; i < IMG.Count; i++)
            {
                if (string.IsNullOrEmpty(IMG[i].ML) == false)
                {
                    att[i] = long.Parse(HttpUploadFile("", IMG[i].ML, IMG[i].WJM.Replace(".jpg", " ")));
                }
            }
            MessageInfo info = Launch_OA(GetAuthority(), basic.LoginName, basic.TemplateCode, null, CreateFlow(basic.TemplateCode, newData), att, "0", "");
            if (info.Key != "0" && info.Key != "-1")
            {
                for (int j = 0; j < KADTMX.Count; j++)
                {
                    KADTMX[j].ISACTIVE = 20;
                    new COST_KADTMX().Update(KADTMX[j]);
                    CRM_OA_TRANSMIT model = new CRM_OA_TRANSMIT
                    {
                        OAID = info.Key,
                        OACSBH = KADTMX[j].KADTMXID,
                        OACSLB = 2023,
                        OAZT = 1,
                        CJSJ = DateTime.Now.ToString("yyyy-MM-dd")
                    };
                    new OA_TRANSMIT().Create(model);
                }
            }
            return info;
        }

        #endregion

        #region OA通用化-通用方法

        /// <summary>
        /// 直接发起流程
        /// </summary>
        /// <param name="staffID">用户ID</param>
        /// <param name="templateCode">模板号</param>
        /// <param name="data">键值对数据</param>
        /// <param name="att">附件号</param>
        /// <returns></returns>
        public ApiReturn Launch(int staffID, string templateCode, Dictionary<string, object> data, long[] att)
        {
            MessageInfo info = Launch_OA(GetAuthority(), new HG_STAFF().RaedBySTAFFID(staffID).STAFFNO, templateCode, null, CreateFlow(templateCode, data), att, "0", "");
            if (info.Key != "0" && info.Key != "-1")
            {
                CRM_OA_TRANSMIT model = new CRM_OA_TRANSMIT
                {
                    OAID = info.Key,
                    OACSBH = 0,
                    OACSLB = 0,
                    OAZT = 0,
                    CJSJ = DateTime.Now.ToString("yyyy-MM-dd")
                };
                new OA_TRANSMIT().Create(model);
                return new ApiReturn<MessageInfo>(info, true);
            }
            else
            {
                return new ApiReturn(false, "00001");
            }
        }

        /// <summary>
        /// 通过单个ID查询数据然后发起流程
        /// </summary>
        /// <param name="staffID">用户ID</param>
        /// <param name="code">模板号</param>
        /// <param name="id">查询ID</param>
        /// <returns></returns>
        public ApiReturn LaunchByID(int staffID, string code, string id)
        {
            return LaunchByIDs(staffID, code, new List<string> { id });
        }

        /// <summary>
        /// 通过ID集查询数据然后发起流程
        /// </summary>
        /// <param name="staffID">用户ID</param>
        /// <param name="code">模板号</param>
        /// <param name="ids">查询ID集</param>
        /// <returns></returns>
        public ApiReturn LaunchByIDs(int staffID, string code, List<string> ids)
        {
            ApiReturn<List<MessageInfo>> mi = new ApiReturn<List<MessageInfo>>()
            {
                data = new List<MessageInfo>(),
                success = true
            };
            switch (code)
            {
                case "10019":
                    foreach (string item in ids)
                    {
                        mi.data.Add(KADTFlow(staffID, item));
                        if (!mi.data.Last().Success) mi.AddCode("00001");//创建失败代码
                    }
                    break;
                case "10020":
                    foreach (string item in ids)
                    {
                        mi.data.Add(KATSCLFlow(staffID, item));
                        if (!mi.data.Last().Success) mi.AddCode("00001");//创建失败代码
                    }
                    break;
                default:
                    mi.AddCode(false, "00001");//方法不存在代码
                    break;
            }
            return mi;
        }

        /// <summary>
        /// 根据模板号获取模板
        /// </summary>
        /// <param name="templateCode">模板号</param>
        /// <returns></returns>
        public ApiReturn ReadTemplate(string templateCode)
        {
            try
            {
                string template = ReadTemplateDefinition(templateCode)[1];
                if (template != null) return new ApiReturn<string>(template, true);
                else return new ApiReturn(false, "00001");
            }
            catch (Exception e)
            {
                return new ApiReturn(false, "00009", e.Message);
            }
        }

        /// <summary>
        /// 根据模板号给对应模板赋值（返回xml字符串）
        /// </summary>
        /// <param name="templateCode">模板号</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        private string CreateFlow(string templateCode, Dictionary<string, object> data)
        {
            return xmlHelper.CreateOAFlowByTemplate(ReadTemplateDefinition(templateCode)[0], data);
        }

        /// <summary>
        /// 根据流程ID给对应模板赋值（返回xml字符串）
        /// </summary>
        /// <param name="flowId">流程ID</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        private string CreateFlow(long flowId, Dictionary<string, object> data)
        {
            return xmlHelper.CreateOAFlowByFlow(ReadFlow(flowId), data);
        }

        /// <summary>
        /// 根据流程ID获取流程
        /// </summary>
        /// <param name="flowId">流程ID</param>
        /// <returns></returns>
        private string ReadFlow(long flowId)
        {
            return _DataAccess.ReadFlow(GetAuthority(), flowId);
        }

        /// <summary>
        /// 根据模板号获取模板
        /// </summary>
        /// <param name="templateCode">模板号</param>
        /// <returns></returns>
        private string[] ReadTemplateDefinition(string templateCode)
        {
            return _DataAccess.ReadTemplateDefinition(GetAuthority(), templateCode);
        }

        #endregion

    }
}

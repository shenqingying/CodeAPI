using Sonluk.DAFactory;
using Sonluk.Entities.Account;
using Sonluk.Entities.OA;
using Sonluk.IDataAccess.OA;
using Sonluk.Utility;
using Sonluk.Utility.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace Sonluk.BusinessLogic.OA
{
    public class Pending
    {
        private static readonly IAffair detaAccess = OADataAccess.CreateAffair();

        public IList<PendingInfo> Read(string ticketId, int firstNum, int pageSize, string address)
        {

            SSO sso = new SSO();
            sso.Login(ticketId);

            Authority auth = new Authority();
            string xml = detaAccess.Pending(auth.Authenticate().ToString(), ticketId, firstNum, pageSize);

            IList<PendingInfo> nodes = new List<PendingInfo>();

            string oaAddress = AppConfig.Settings("OA");
            string oaInternetAddress = AppConfig.Settings("OA.Internet");
            Address addressBL = new Address();
            int addressType = addressBL.Type(address);

            if (!xml.Equals(""))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);
                XmlNode root = xmlDoc.SelectSingleNode("/B/P/L");
                XmlNodeList nodeList = root.ChildNodes;
                foreach (XmlNode xmlNode in nodeList)
                {
                    PendingInfo node = new PendingInfo();
                    int index = 0;
                    node.Subject = xmlNode.ChildNodes[index++].InnerText;
                    if (xmlNode.ChildNodes.Count > 11)
                    {
                        node.Link = xmlNode.ChildNodes[index++].InnerText;
                        if (addressType == 2)
                            node.Link = node.Link.Replace(oaAddress, oaInternetAddress);
                    }

                    node.ApplicationCategory = ApplicationCategory(xmlNode.ChildNodes[index++].InnerText);
                    node.Creator = xmlNode.ChildNodes[index++].InnerText;
                    node.Distinct = xmlNode.ChildNodes[index++].InnerText;
                    node.BodyType = xmlNode.ChildNodes[index++].InnerText;
                    node.ID = xmlNode.ChildNodes[index++].InnerText;
                    node.ObjectID = xmlNode.ChildNodes[index++].InnerText;
                    node.HasAttachments = xmlNode.ChildNodes[index++].InnerText;

                    string dateString = xmlNode.ChildNodes[index++].InnerText.Substring(0, 10);
                    DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                    dateTime = dateTime.AddSeconds(Convert.ToDouble(dateString)).ToLocalTime();
                    node.CreateDate = dateTime.ToString("yyyy-MM-dd HH:mm:ss");

                    node.SubObjectID = xmlNode.ChildNodes[index++].InnerText;
                    node.ImportantLevel = ImportantLevel(xmlNode.ChildNodes[index++].InnerText);
                    nodes.Add(node);
                }
            }
            return nodes;
        }

        public int Count(string ticketID)
        {
            int count = 0;
            try
            {
                Authority auth = new Authority();
                string xml = detaAccess.Pending(auth.Authenticate().ToString(), ticketID, 0, 100);
                if (!xml.Equals(""))
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);
                    XmlNode root = xmlDoc.SelectSingleNode("/B/P/L");
                    count = root.ChildNodes.Count;
                }
            }
            catch 
            {
            
            
            }
            return count;
        }

        private string ApplicationCategory(string key)
        {
            string description = "";
            switch (key)
            {
                case "1": description = "协同"; break;
                case "4": description = "公文"; break;
                case "6": description = "会议"; break;
                case "7": description = "公告"; break;
                case "8": description = "新闻"; break;
                case "10": description = "调查"; break;
                case "21": description = "签报"; break;
                case "22": description = "待发送"; break;
                case "23": description = "待签收"; break;
                case "24": description = "待登记"; break;
            }

            return description;
        }

        private string ImportantLevel(string key)
        {
            string description = "";
            switch (key)
            {
                case "1": description = "一般"; break;
                case "2": description = "重要"; break;
                case "3": description = "紧急"; break;

            }

            return description;
        }
    }
}

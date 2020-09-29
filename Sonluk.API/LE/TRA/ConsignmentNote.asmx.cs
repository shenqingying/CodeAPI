using Sonluk.API.Models;
using Sonluk.Entities.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.LE.TRA
{
    /// <summary>
    /// ConsignmentNote 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://Sonluk.com/API/LE/TRA/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class ConsignmentNote : System.Web.Services.WebService
    {
        LETRAModels models = new LETRAModels();

        [WebMethod]
        public int Exists(string serialNumber)
        {
            return models.ConsignmentNote.Exists(serialNumber);
        }

        [WebMethod]
        public string CurrentNumber(int carrierID) 
        {
            return models.ConsignmentNote.CurrentNumber(carrierID);
        }

        [WebMethod]
        public CNInfo Generate(List<string> deliverySet, int carrier, bool replace)
        {
            return models.ConsignmentNote.Generate(deliverySet, carrier, replace);
        }

        [WebMethod]
        public int Create(CNInfo node)
        {
            return models.ConsignmentNote.Create(node);
        }

        [WebMethod]
        public List<CNInfo> Select(CNInfo keywords)
        {
            return models.ConsignmentNote.Read(keywords).ToList();
        }

        [WebMethod]
        public CNInfo Read(int ID)
        {
            return models.ConsignmentNote.Read(ID);
        }

        [WebMethod]
        public List<CNDeliveryInfo> ReadCNDeliveryByID(int ID)
        {
            return models.ConsignmentNote.ReadCNDeliveryByID(ID).ToList();
        }

        [WebMethod]
        public List<CNDeliveryInfo> ReadCNDelivery(string VBELN)
        {
            return models.ConsignmentNote.ReadCNDelivery(VBELN).ToList();
        }

        [WebMethod]
        public List<CNInfo> Report(CNInfo keywords)
        {
            return models.ConsignmentNote.Report(keywords).ToList();
        }

        [WebMethod]
        public bool Update(CNInfo node)
        {
            return models.ConsignmentNote.Update(node);
        }

        [WebMethod]
        public int Delete(int ID)
        {
            return models.ConsignmentNote.Delete(ID);
        }

        [WebMethod]
        public List<CNDeliveryInfo> CNDeliveryUPDATE(string serialNumber, int TYDID, int STATUS, string FILLNAME, string FILLID)
        {
            return models.ConsignmentNote.CNDeliveryUPDATE(serialNumber, TYDID, STATUS, FILLNAME, FILLID).ToList();
        }

        [WebMethod]
        public byte[] Export(string type, List<CNInfo> nodes)
        {
            return models.ConsignmentNote.Export(type, nodes).ToArray();
        }
    }
}

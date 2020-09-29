using Sonluk.API.Models;
using Sonluk.Entities.LE;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.LE.TRA
{
    /// <summary>
    /// Exception 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://Sonluk.com/API/LE/TRA/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Complaint : System.Web.Services.WebService
    {
        LETRAModels models = new LETRAModels();

        [WebMethod]
        public List<ComplaintInfo> Select(ComplaintInfo keywords)
        {
            return models.Complaint.Read(keywords).ToList();
        }

        [WebMethod]
        public ComplaintInfo Read(int ID)
        {
            return models.Complaint.Read(ID);
        }

        [WebMethod]
        public ComplaintInfo Generate(int consignmentNote)
        {
            return models.Complaint.Generate(consignmentNote);
        }

        [WebMethod]
        public int Create(ComplaintInfo node)
        {
            return models.Complaint.Create(node);
        }

        [WebMethod]
        public int Update(ComplaintInfo node)
        {
            return models.Complaint.Update(node);
        }

        [WebMethod]
        public int Modify(ComplaintInfo node)
        {
            return models.Complaint.Modify(node);
        }

        [WebMethod]
        public List<ComplaintInfo> Report(ComplaintInfo keywords)
        {
            return models.Complaint.Report(keywords).ToList();
        }

        [WebMethod]
        public byte[] Export(string type, List<ComplaintInfo> nodes)
        {
            return models.Complaint.Export(type, nodes).ToArray();
        }
    }
}

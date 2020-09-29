using Sonluk.API.Models;
using Sonluk.Entities.LE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.LE.TRA
{
    /// <summary>
    /// Feedback 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://Sonluk.com/API/LE/TRA/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Feedback : System.Web.Services.WebService
    {
        LETRAModels models = new LETRAModels();

        [WebMethod]
        public List<FeedbackInfo> Select(FeedbackInfo keywords) 
        {
            return models.Feedback.Read(keywords).ToList();
        }

        [WebMethod]
        public FeedbackInfo Read(int ID)
        {
            return models.Feedback.Read(ID);
        }

        [WebMethod]
        public string Verify(FeedbackInfo node)
        {
            return models.Feedback.Verify(node);
        }

        [WebMethod]
        public int Modify(FeedbackInfo node)
        {
            return models.Feedback.Modify(node);
        }

        [WebMethod]
        public List<FeedbackItemInfo> Import(byte[] file)
        {
            MemoryStream memoryStream = new MemoryStream(file);
            return models.Feedback.Import(memoryStream).ToList();
        }

        [WebMethod]
        public List<FeedbackInfo> Report(FeedbackInfo keywords)
        {
            return models.Feedback.Report(keywords).ToList();
        }

        [WebMethod]
        public byte[] Export(string type, List<FeedbackInfo> nodes)
        {
            return models.Feedback.Export(type, nodes).ToArray();
        }
    }
}

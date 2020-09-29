using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using Sonluk.API.Models;
using Sonluk.Entities.MM;
using Sonluk.Entities.SD;
using Sonluk.Entities.System;
using Sonluk.Entities.Print;
using Sonluk.Entities.Common;
using Sonluk.Entities.BC;

namespace Sonluk.API.MM
{
    /// <summary>
    /// PurchaseOrder 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://Sonluk.com/API/MM")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class PurchaseOrder : System.Web.Services.WebService
    {
        MMModels models = new MMModels();


        [WebMethod]
        public List<POItemInfo> Read(POKeywordInfo keyword)
        {
            return models.PurchaseOrder.Read(keyword).ToList();
        }

        [WebMethod]
        public List<POItemInfo> ReadBySO(SOKeywordInfo keyword)
        {
            return models.PurchaseOrder.Read(keyword).ToList();
        }

        [WebMethod]
        public List<POItemInfo> ReadBySOFile(byte[] file)
        {
            MemoryStream memoryStream = new MemoryStream(file);
            return models.PurchaseOrder.Read(memoryStream).ToList();
        }

        [WebMethod]
        public List<POItemHistoryInfo> History(string number, int itemNumber)
        {
            return models.PurchaseOrder.History(number, itemNumber).ToList();
        }

        [WebMethod]
        public List<MessageInfo> UpdateDeliveryDate(List<POItemInfo> nodes)
        {
            return models.PurchaseOrder.UpdateDeliveryDateParallel(nodes).ToList();
        }

        [WebMethod]
        public byte[] ExportSet(string type, List<POItemInfo> itemNodes)
        {
            MemoryStream memoryStream = models.PurchaseOrder.Export(type, itemNodes);
            return memoryStream.ToArray();
        }

        [WebMethod]
        public List<FileStreamInfo> Export(List<POItemInfo> itemNodes,int type)
        {
            return models.PurchaseOrder.Export(itemNodes, type).ToList();
        }

        [WebMethod]
        public List<PageInfo<POInfo>> AnalysePrintData(string type, int status, string pageSize, List<POItemInfo> itemNodes)
        {
            return models.PurchaseOrder.AnalysePrintData(type, status, pageSize, itemNodes).ToList();
        }

        [WebMethod]
        public List<FileStreamInfo> GetStorageIdentificationPDF(string CGXM, string TPM, string GYS, int TS, int XS, int SL, string MODE, string LTBS)
        {
            return models.PurchaseOrder.GetStorageIdentificationPDF(CGXM, TPM, GYS, TS, XS, SL, MODE, LTBS).ToList();
        }

        [WebMethod]
        public List<ZSL_BCS104> GetStorageIdentificationList(string CGXM, string TPM, string GYS, int TS, int XS, int SL, string MODE, string LTBS)
        {
            return models.PurchaseOrder.GetStorageIdentificationList(CGXM, TPM, GYS, TS, XS, SL, MODE, LTBS).ToList();
        }

        [WebMethod]
        public string GenerateStorageIdentification(string CGXM, string TPM, string GYS, int TS, int XS, int SL, string MODE, string LTBS)
        {
            return models.PurchaseOrder.GenerateStorageIdentification(CGXM, TPM, GYS, TS, XS, SL, MODE, LTBS);
        }

        [WebMethod]
        public List<FileStreamInfo> GetStorageIdentificationZHPDF(int GLTS, string DYFS, string USER, string MODE, int FS, List<ZSL_BCS104> itemNodes)
        {
            return models.PurchaseOrder.GetStorageIdentificationZHPDF(GLTS, DYFS, USER, MODE, FS, itemNodes).ToList();
        }

        [WebMethod]
        public List<ZSL_BCS104> GetStorageIdentificationZHList(int GLTS, string DYFS, string USER, string MODE, int FS, List<ZSL_BCS104> itemNodes)
        {
            return models.PurchaseOrder.GetStorageIdentificationZHList(GLTS, DYFS, USER, MODE, FS, itemNodes).ToList();
        }

        [WebMethod]
        public string GenerateStorageIdentificationZH(int GLTS, string DYFS, string USER, string MODE, int FS, List<ZSL_BCS104> itemNodes)
        {
            return models.PurchaseOrder.GenerateStorageIdentificationZH(GLTS, DYFS, USER, MODE, FS, itemNodes);
        }

        [WebMethod]
        public string ZBCFUN_RKBS_CHANGE(string IV_TPM, string IV_MODE, string IV_USER)
        {
            return models.PurchaseOrder.ZBCFUN_RKBS_CHANGE(IV_TPM, IV_MODE, IV_USER);
        }
        [WebMethod]
        public string ZMMFUN_GCDZ_READ(string werks)
        {
            return models.PurchaseOrder.ZMMFUN_GCDZ_READ(werks);
        }
        [WebMethod]
        public ZMMFUN_PURBS_READ ZMMFUN_PURBS_READ(List<ZSL_BCS303_CT> IT_PURCT)
        {
            return models.PurchaseOrder.ZMMFUN_PURBS_READ(IT_PURCT);
        }

    }
}

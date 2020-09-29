using Sonluk.API.Models;
using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.CRM
{
    /// <summary>
    /// BC_PMLIST 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class BC_PMLIST : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(CRM_BC_PMLIST model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_PMLIST.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_BC_PMLIST> SelectByModel(CRM_BC_PMLIST model, string BEGIN_DATE, string END_DATE, string ptoken)
        {

            List<CRM_BC_PMLIST> node = new List<CRM_BC_PMLIST>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_PMLIST.SelectByModel(model, BEGIN_DATE, END_DATE).ToList();
            }
            return node;
        }
        [WebMethod]
        public List<CRM_BC_PMLISTList> SelectGD(CRM_BC_PMLIST model, string BEGIN_DATE, string END_DATE, string ptoken)
        {
            List<CRM_BC_PMLISTList> node = new List<CRM_BC_PMLISTList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_PMLIST.SelectGD(model, BEGIN_DATE, END_DATE).ToList();
            }
            return node;
        }
        [WebMethod]
        public List<CRM_BC_PMLISTList> SelectByGD(string AUFNR, string ptoken)
        {
            List<CRM_BC_PMLISTList> node = new List<CRM_BC_PMLISTList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_PMLIST.SelectByGD(AUFNR).ToList();
            }
            return node;
        }
        [WebMethod]
        public List<CRM_BC_PMLISTList> SelectByGDandParam(CRM_BC_PMLIST model, string BEGIN_DATE, string END_DATE, string ptoken)
        {
            List<CRM_BC_PMLISTList> node = new List<CRM_BC_PMLISTList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_PMLIST.SelectByGDandParam(model, BEGIN_DATE, END_DATE).ToList();
            }
            return node;
        }
        [WebMethod]
        public CRM_BC_PMLISTList SelectByDXM(string DXM, string ptoken)
        {
            CRM_BC_PMLISTList node = new CRM_BC_PMLISTList();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_PMLIST.SelectByDXM(DXM);
            }
            return node;
        }
        [WebMethod]
        public List<CRM_BC_PMLISTList> SelectOtherBigByDXM(string DXM, string ptoken)
        {
            List<CRM_BC_PMLISTList> node = new List<CRM_BC_PMLISTList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_PMLIST.SelectOtherBigByDXM(DXM).ToList();
            }
            return node;
        }
        [WebMethod]
        public int Delete(int PMID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_PMLIST.Delete(PMID);
            }
            return -100;

        }
        [WebMethod]
        public int DeleteByGD(string AUFNR, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_PMLIST.DeleteByGD(AUFNR);
            }
            return -100;
        }
        [WebMethod]
        public int UpdatePM(string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_PMLIST.UpdatePM();
            }
            return -100;
        }
        [WebMethod]
        public List<CRM_BC_PMLIST> SelectMATNRbyCHARGandPM(CRM_BC_PMLIST model, string ptoken)
        {
            List<CRM_BC_PMLIST> node = new List<CRM_BC_PMLIST>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_PMLIST.SelectMATNRbyCHARGandPM(model).ToList();
            }
            return node;
        }
        [WebMethod]
        public List<CRM_BC_PMLIST> SelectMATNRbyCHARGandPM2(string charg, string pm)
        {
            CRM_BC_PMLIST model = new CRM_BC_PMLIST();
            model.CHARG = charg;
            model.PM = pm;
            return models.BC_PMLIST.SelectMATNRbyCHARGandPM(model).ToList();

        }
        [WebMethod]
        public List<CRM_BC_KH> SelectKHbyMCP(CRM_BC_PMLIST model, string ptoken)
        {
            List<CRM_BC_KH> node = new List<CRM_BC_KH>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_PMLIST.SelectKHbyMCP(model).ToList();
            }
            return node;
        }
        [WebMethod]
        public List<CRM_BC_KH> SelectKHbyMCP2(string charg, string pm, string matnr)
        {

            CRM_BC_PMLIST model = new CRM_BC_PMLIST();
            model.CHARG = charg;
            model.PM = pm;
            model.MATNR = matnr;
            return models.BC_PMLIST.SelectKHbyMCP(model).ToList();

        }
        [WebMethod]
        public List<CRM_BC_KH> SelectKHbyDXM(CRM_BC_PMLIST model, string ptoken)
        {
            List<CRM_BC_KH> node = new List<CRM_BC_KH>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_PMLIST.SelectKHbyDXM(model).ToList();
            }
            return node;
        }
        [WebMethod]
        public List<CRM_BC_KH> SelectKHbyNHM(CRM_BC_CHMX model, string ptoken)
        {
            List<CRM_BC_KH> node = new List<CRM_BC_KH>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_PMLIST.SelectKHbyNHM(model).ToList();
            }
            return node;
        }
        [WebMethod]
        public int Create_WLM(CRM_BC_WLM_TEMP model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_PMLIST.Create_WLM(model);
            }
            return -100;
        }
        [WebMethod]
        public int Delete_WLM(string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_PMLIST.Delete_WLM();
            }
            return -100;
        }
        [WebMethod]
        public int Modify_WLM(string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_PMLIST.Modify_WLM();
            }
            return -100;
        }
        [WebMethod]
        public CRM_WebMSG GetNewWLM()
        {

            return models.BC_PMLIST.GetNewWLM();

        }


    }
}

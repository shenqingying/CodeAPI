using Sonluk.API.Models;
using Sonluk.Entities.CRM;
using Sonluk.Entities.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.CRM
{
    /// <summary>
    /// CRM_OA 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class CRM_OA : System.Web.Services.WebService
    {
        //OAModels models = new OAModels();
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]


        public string GetAuthority(string ptoken)
        {
            string res = "";
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.CRM_OA.GetAuthority();
            }
            return res;
            
        }

        [WebMethod]
        public MessageInfo Launch(CRM_OA_BASIC basic, object model, string ptoken)
        {
            //string res = "";
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.CRM_OA.Launch(basic, model);
            }
            return new MessageInfo();
        }
        //[WebMethod]
        //public MessageInfo Launch_Test(CRM_OA_BASIC basic, object model, string ptoken)
        //{
        //    //string res = "";
        //    if (models.CRM_Login.ValidateToken(ptoken))
        //    {
        //        return models.CRM_OA.Launch_Test(basic, model);
        //    }
        //    return new MessageInfo();
        //}
        [WebMethod]
        public int GetFlowState( string ID,string ptoken)
        {
            //int res = 0;
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.CRM_OA.GetFlowState( ID);
            }
            return -100;
           
        }
        [WebMethod]
        public List<CRM_OA_INFO> Pending(string ticketId, int firstNum, int pageSize,string address, string ptoken)
        {
            List<CRM_OA_INFO> node = new List<CRM_OA_INFO>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.CRM_OA.Pending(ticketId,firstNum,pageSize,address).ToList();
            }
            return node;
           
        }
        [WebMethod]
        public List<CRM_OA_INFO> Track(string ticketId, int firstNum, int pageSize,string address, string ptoken)
        {
            List<CRM_OA_INFO> node = new List<CRM_OA_INFO>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.CRM_OA.Track(ticketId, firstNum, pageSize,address).ToList();
            }
            return node;
            
        }
        [WebMethod]
        public Boolean Logout(string ticketID,string ptoken)
        {

            bool res = false;
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.CRM_OA.Logout(ticketID);
            }
            return res;
        }



        [WebMethod]
        public void CRM_OA_FLOW()
        {

          models.CRM_OA_FLOW.Aotu_UPDATE();
        }
        [WebMethod]
        public void CRM_OA_FLOW_DaoFa()
        {

            models.CRM_OA_FLOW.Auto_UPDATE_DaiFa();
        }
        //请假类
        [WebMethod]
        public void StructQJ(CRM_OA_QJList model){

        }
        [WebMethod]
        public void StructCC(CRM_OA_CC model)
        {

        }
        [WebMethod]
        public void StructKH(CRM_OA_KH model)
        {

        }
       [WebMethod]
        public void StructKH_WD(CRM_OA_KH_WD model)
        {

        }
        [WebMethod]
       public void StructYCKQSM(CRM_OA_YCKQSM model)
       {

       }
        [WebMethod]
        public void StructZDF(CRM_OA_ZDF model)
        {

        }

        [WebMethod]
        public string Upload(string path)
        {
            return models.CRM_OA.HttpUploadFile("", path,"");
        }

        [WebMethod]
        public int ReadOAFinishStatus()
        {
            return models.CRM_OA_FLOW.ReadOAFinishStatus();
        }

        [WebMethod]
        public void Auto_UPDATE_All()
        {
            models.CRM_OA_FLOW.Aotu_UPDATE();
            models.CRM_OA_FLOW.Auto_UPDATE_DaiFa();
            //models.CRM_OA_FLOW.CheckStatus();
        }

        [WebMethod]
        public void StructLKAYEAR(CRM_OA_LKAYEAR model)
        {

        }

        [WebMethod]
        public void StructHaiBao(CRM_OA_HaiBao model)
        {

        }

        [WebMethod]
        public void StructTSCL(CRM_OA_TSCL model)
        {

        }
        [WebMethod]
        public void StructZZF(CRM_OA_ZZF model)
        {

        }
        [WebMethod]
        public void StructKHTS(CRM_OA_KHTS model)
        {

        }
        [WebMethod]
        public void StructMDBS(CRM_OA_MDBS model)
        {

        }
        [WebMethod]
        public void StructKAYEAR(CRM_OA_KAYEAR model)
        {

        }
        [WebMethod]
        public void StructKADT(CRM_OA_KADT model)
        {

        }
        [WebMethod]
        public void StructKATSCL(CRM_OA_KATSCL model)
        {

        }
        [WebMethod]
        public void StructKACXY(CRM_OA_KACXY model)
        {

        }
        [WebMethod]
        public void StructCXHD(CRM_OA_CXHD model)
        {

        }
        [WebMethod]
        public void LKAYEAR_Finish(int LKAYEARTT)
        {
            models.CRM_OA_FLOW.LKAYEAR_Finish(LKAYEARTT);
        }
        [WebMethod]
        public void KAYEAR_Finish(int KAYEARTT)
        {
            models.CRM_OA_FLOW.KAYEAR_Finish(KAYEARTT);
        }
        


    }
}

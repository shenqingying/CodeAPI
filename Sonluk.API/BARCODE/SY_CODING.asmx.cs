using Sonluk.API.Models;
using Sonluk.Entities.BARCODE;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.BARCODE
{
    /// <summary>
    /// SY_CODING 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class SY_CODING : System.Web.Services.WebService
    {
        RMSModels rmsmodel = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public List<BARCODE_SY_CODING> ReadByParam(BARCODE_SY_CODING model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_CODING.ReadByParam(model).ToList();
            }
            else
            {
                List<BARCODE_SY_CODING> rst = new List<BARCODE_SY_CODING>();
                return rst;
            }
        }

        //[WebMethod]
        //public MES_RETURN Create(BARCODE_SY_CODING model, string ptoken)
        //{
        //    if (rmsmodel.CRM_Login.ValidateToken(ptoken))
        //    {
        //        return rmsmodel.SY_CODING.Create(model);
        //    }
        //    else
        //    {
        //        MES_RETURN rst = new MES_RETURN();
        //        rst.TYPE = "E";
        //        rst.MESSAGE = "ptoken不正确，请重新登录！";
        //        return rst;
        //    }
        //}
        [WebMethod]
        public MES_RETURN UPDATE(BARCODE_SY_CODING model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_CODING.Update(model);
            }
            else
            {
                MES_RETURN rst = new MES_RETURN();
                rst.TYPE = "E";
                rst.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN DELETE(int ID, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_CODING.Delete(ID);
            }
            else
            {
                MES_RETURN rst = new MES_RETURN();
                rst.TYPE = "E";
                rst.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }
    }
}

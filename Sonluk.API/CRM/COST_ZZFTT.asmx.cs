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
        /// COST_ZZFTT 的摘要说明
        /// </summary>
        [WebService(Namespace = "http://tempuri.org/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [System.ComponentModel.ToolboxItem(false)]
        // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
        // [System.Web.Script.Services.ScriptService]
        public class COST_ZZFTT : System.Web.Services.WebService
        {
            RMSModels models = new RMSModels();

            [WebMethod]
            public string HelloWorld()
            {
                return "Hello World";
            }

            [WebMethod]
            public int Create(CRM_COST_ZZFTT model, string ptoken)
            {
                if (models.CRM_Login.ValidateToken(ptoken))
                {
                    return models.COST_ZZFTT.Create(model);
                }
                return -100;

            }

            [WebMethod]
            public int Update(CRM_COST_ZZFTT model, string ptoken)
            {
                if (models.CRM_Login.ValidateToken(ptoken))
                {
                    return models.COST_ZZFTT.Update(model);
                }
                return -100;

            }

            [WebMethod]
            public List<CRM_COST_ZZFTT> ReadByParam(CRM_COST_ZZFTT model,int STAFFID, string ptoken)
            {
                List<CRM_COST_ZZFTT> node = new List<CRM_COST_ZZFTT>();
                if (models.CRM_Login.ValidateToken(ptoken))
                {
                    return models.COST_ZZFTT.ReadByParam(model,STAFFID).ToList();
                }
                return node;

            }
            [WebMethod]
            public List<CRM_COST_ZZFTT> Read_KA(CRM_COST_ZZFTT model,int STAFFID, string ptoken)
            {
                List<CRM_COST_ZZFTT> node = new List<CRM_COST_ZZFTT>();
                if (models.CRM_Login.ValidateToken(ptoken))
                {
                    return models.COST_ZZFTT.Read_KA(model, STAFFID).ToList();
                }
                return node;

            }
            [WebMethod]
            public List<CRM_COST_ZZFTT> Read_LKA(CRM_COST_ZZFTT model, int STAFFID, string ptoken)
            {
                List<CRM_COST_ZZFTT> node = new List<CRM_COST_ZZFTT>();
                if (models.CRM_Login.ValidateToken(ptoken))
                {
                    return models.COST_ZZFTT.Read_LKA(model, STAFFID).ToList();
                }
                return node;

            }
            [WebMethod]
            public List<CRM_COST_ZZFTT> ReadByCostitemid(CRM_COST_ZZFTT model, string ptoken)
            {
                List<CRM_COST_ZZFTT> node = new List<CRM_COST_ZZFTT>();
                if (models.CRM_Login.ValidateToken(ptoken))
                {
                    return models.COST_ZZFTT.ReadByCostitemid(model).ToList();
                }
                return node;

            }

            [WebMethod]
            public List<CRM_COST_ZZFTT> Read_LKAUnconnected(CRM_COST_ZZFTT model, string ptoken)
            {
                List<CRM_COST_ZZFTT> node = new List<CRM_COST_ZZFTT>();
                if (models.CRM_Login.ValidateToken(ptoken))
                {
                    return models.COST_ZZFTT.Read_LKAUnconnected(model).ToList();
                }
                return node;
            }

            [WebMethod]
            public List<CRM_COST_ZZFTT> Read_KAUnconnected(CRM_COST_ZZFTT model, string ptoken)
            {
                List<CRM_COST_ZZFTT> node = new List<CRM_COST_ZZFTT>();
                if (models.CRM_Login.ValidateToken(ptoken))
                {
                    return models.COST_ZZFTT.Read_KAUnconnected(model).ToList();
                }
                return node;
            }

            [WebMethod]
            public int Delete(int TTID, string ptoken)
            {
                if (models.CRM_Login.ValidateToken(ptoken))
                {
                    return models.COST_ZZFTT.Delete(TTID);
                }
                return -100;

            }
            [WebMethod]
            public List<CRM_COST_ZZFTT> Read_Unconnected(CRM_COST_ZZFTT model, string ptoken)
            {
                List<CRM_COST_ZZFTT> node = new List<CRM_COST_ZZFTT>();
                if (models.CRM_Login.ValidateToken(ptoken))
                {
                    return models.COST_ZZFTT.Read_Unconnected(model).ToList();
                }
                return node;
            }
            [WebMethod]
            public List<CRM_COST_ZZFTT> Read_Unconnected2(CRM_COST_ZZFTT model, string ptoken)
            {
                List<CRM_COST_ZZFTT> node = new List<CRM_COST_ZZFTT>();
                if (models.CRM_Login.ValidateToken(ptoken))
                {
                    return models.COST_ZZFTT.Read_Unconnected2(model).ToList();
                }
                return node;
            }
        }
    }


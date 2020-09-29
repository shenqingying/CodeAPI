﻿using Sonluk.API.Models;
using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.CRM
{
    /// <summary>
    /// HG_BZGZSJ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class HG_BZGZSJ : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(CRM_HG_BZGZSJ model,string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_BZGZSJ.Create(model);
            }
            return -100;
            
        }
        [WebMethod]
        public int Update(CRM_HG_BZGZSJ model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_BZGZSJ.Update(model);
            }
            return -100;
            
        }
        [WebMethod]
        public int Delete(int BZID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_BZGZSJ.Delete(BZID);
            }
            return -100;
            
        }
        [WebMethod]
        public List<CRM_HG_BZGZSJ> Read(int STAFFID,string ptoken)
        {
            List<CRM_HG_BZGZSJ> node = new List<CRM_HG_BZGZSJ>(); 
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_BZGZSJ.Read(STAFFID).ToList();
            }
            return node;
            
        }
        [WebMethod]
        public CRM_HG_BZGZSJ ReadByBZNAME(string BZNAME,string ptoken)
        {
            CRM_HG_BZGZSJ node = new CRM_HG_BZGZSJ();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_BZGZSJ.ReadByBZNAME(BZNAME);
            }
            return node;
           
        }
        [WebMethod]
        public CRM_HG_BZGZSJ ReadByBZID(int BZID,string ptoken)
        {
            CRM_HG_BZGZSJ node = new CRM_HG_BZGZSJ();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_BZGZSJ.ReadByBZID(BZID);
            }
            return node;
            
        }
    }
}
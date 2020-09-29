using Sonluk.API.Models;
using Sonluk.Entities.PS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.PS
{
    /// <summary>
    /// CNFH 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class CNFH : System.Web.Services.WebService
    {

        PSModels models = new PSModels();
        [WebMethod]
        public CNFHLIST ModifyCNFH(List<ZSL_GXCN> ZSL_GXCNList,string ptoken)
        {
            return models.CNFH.ModifyCNFH(ZSL_GXCNList);
        }
        [WebMethod]
        public WBSPARMS ReadWBSPARMS(string ptoken)
        {
            return models.CNFH.ReadWBSPARMS();
        }
        [WebMethod]
        public ZSL_NetworkList SELECTJGNETWORK(string I_PSPNR, List<ET_TCNRFPT> IT_RFPNT,string ptoken)
        {
            return models.CNFH.SELECTJGNETWORK(I_PSPNR, IT_RFPNT);
        }
        [WebMethod]
        public PS_MSG UpdateNetwork(List<ZSL_NETWORK> nodes)
        {
            return models.CNFH.UpdateNetwork(nodes);
        }
        [WebMethod]
        public ZSL_GXFHTABLE GXFHTABLE(PS_CXFHCS parslist)
        {
            return models.CNFH.GXFHTABLE(parslist);
        }
        [WebMethod]
        public PS_MSG SYNCCNDATA()
        {
            return models.CNFH.SYNCCNDATA();
        }
        [WebMethod]
        public ZSL_NetworkList NETWORKWARNING(int I_ROWS)
        {
            return models.CNFH.NETWORKWARNING(I_ROWS);
        }
         [WebMethod]
        public PS_MSG ZPSFUG_M_GZCN(ZSL_GZCN I_GZCN, List<ZSL_GZ_VLSCH> relationList,string flag)
        {
            return models.CNFH.ZPSFUG_M_GZCN(I_GZCN,relationList,flag);
        }
         [WebMethod]
        public ZSL_GZCNList ZPSFUG_Q_GZCN(string GZMS)
        {
            return models.CNFH.ZPSFUG_Q_GZCN(GZMS);
        }
        [WebMethod]
         public PS_MSG ZPSFUG_M_CALENDAR(ZSL_CALENDARList nodes, string I_CALENDAY, string I_WORKDAY)
         {
             return models.CNFH.ZPSFUG_M_CALENDAR(nodes, I_CALENDAY, I_WORKDAY);
         }
        [WebMethod]
        public ZSL_CALENDARList ZPSFUG_Q_CALENDAR(string ksdate, string jsdate)
        {
            return models.CNFH.ZPSFUG_Q_CALENDAR(ksdate, jsdate);
        }
        [WebMethod]
        public GZCNREPORT ZPSFUG_Q_GZCNREPORT(string ksdate, string jsdate,string flag)
        {
            return models.CNFH.ZPSFUG_Q_GZCNREPORT(ksdate, jsdate,flag);
        }
      
    }
}

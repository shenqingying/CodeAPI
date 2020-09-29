using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Sonluk.API.Models;
using Sonluk.Entities.MES;
using Sonluk.Entities.FIVES;
namespace Sonluk.API.FIVES
{
    /// <summary>
    /// SY_CHECKPOINT 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class SY_CHECKPOINT : System.Web.Services.WebService
    {
        RMSModels rmsmodel = new RMSModels();
        [WebMethod]
        public List<FIVES_SY_CHECKPOINT> Read(FIVES_SY_CHECKPOINT model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_CHECKPOINT.Read(model).ToList();
            }
            else
            {
                List<FIVES_SY_CHECKPOINT> rst = new List<FIVES_SY_CHECKPOINT>();
                return rst;
            }
        }
        [WebMethod]
        public List<FIVES_SY_CHECKPOINT> Compare(FIVES_SY_CHECKPOINT model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_CHECKPOINT.Compare(model).ToList();
            }
            else
            {
                List<FIVES_SY_CHECKPOINT> rst = new List<FIVES_SY_CHECKPOINT>();
                return rst;
            }
        }
        [WebMethod]
        public List<FIVES_SY_CHECKPOINTList> ReadaddDepName(FIVES_SY_CHECKPOINT model,string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_CHECKPOINT.ReadaddDepName(model).ToList();
            }
            else
            {
                List<FIVES_SY_CHECKPOINTList> rst = new List<FIVES_SY_CHECKPOINTList>();
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN Create(FIVES_SY_CHECKPOINT model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_CHECKPOINT.Create(model);
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
        public MES_RETURN Create_All(FIVES_SY_CHECKPOINT_CREATE model,string ptoken){
             if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_CHECKPOINT.Create_All(model);
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
        public MES_RETURN Update_All(FIVES_SY_CHECKPOINT_CREATE model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_CHECKPOINT.Update_All(model);
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
        public MES_RETURN Delete_All(int pointid, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_CHECKPOINT.Delete_All(pointid);
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
        public FIVES_SY_CHECKPOINT_CREATE Select_ByPointID(int PointID, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_CHECKPOINT.Select_ByPointID(PointID);
            }
            else
            {
                FIVES_SY_CHECKPOINT_CREATE rst = new FIVES_SY_CHECKPOINT_CREATE();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        
        [WebMethod]
        public MES_RETURN UPDATE(FIVES_SY_CHECKPOINT model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_CHECKPOINT.Update(model);
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
                return rmsmodel.SY_CHECKPOINT.Delete(ID);
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
        public FIVES_SY_CHECKPOINT_CREATE Select_CHECKPOINT_byParms(int pointId,int staffid,string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_CHECKPOINT.CheckpointInfo_SelectAll(staffid,pointId);
            }
            else
            {
                MES_RETURN rst = new MES_RETURN();
                rst.TYPE = "E";
                rst.MESSAGE = "ptoken不正确，请重新登录！";
                FIVES_SY_CHECKPOINT_CREATE node = new FIVES_SY_CHECKPOINT_CREATE();
                node.MES_RETURN = rst;
                return node;
            }
        }

       
       
    }
}

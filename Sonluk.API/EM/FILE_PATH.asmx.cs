using Sonluk.API.Models;
using Sonluk.Entities.EM;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.EM
{
    /// <summary>
    /// FILE_PATH 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class FILE_PATH : System.Web.Services.WebService
    {
        RMSModels rmsmodel = new RMSModels();
        /// <summary>
        /// 上传文件接口
        /// </summary>
        /// <param name="type">EM_FILE_PATH表的type字段 从数据库中直接找到路径EM_FILE_PATH表的path字段</param>
        /// <param name="fileData">文件二进制字节流</param>
        /// <param name="fileName">文件名字</param>
        /// <param name="Directorys">多级文件夹名</param>
        /// <returns></returns>
        /// 
        [WebMethod]
        public MES_RETURN UploadService(string type, byte[] fileData, string fileName, string[] Directorys)
        {
            return rmsmodel.FILE_PATH.UploadService(type, fileData, fileName, Directorys);
        }
        [WebMethod]
        public MES_RETURN DeleteFileService(string[] filename)
        {
            return rmsmodel.FILE_PATH.DeleteFileService(filename);
        }
        [WebMethod]
        public MES_RETURN GetURLByReadID(int id, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.FILE_PATH.GetURLByReadID(id);
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
        public EM_FILE_PATH Read(string type, string ptoken)
        {
            
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.FILE_PATH.Read(type);
            }
            else
            {
                EM_FILE_PATH rst = new EM_FILE_PATH();
                return rst;
            }
        }
        [WebMethod]
        public EM_FILE_PATH ReadByID(int pathid, string ptoken)
        {

            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.FILE_PATH.ReadByID(pathid);
            }
            else
            {
                EM_FILE_PATH rst = new EM_FILE_PATH();
                return rst;
            }
        }
        
    }
}

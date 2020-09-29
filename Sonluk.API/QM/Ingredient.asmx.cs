using Sonluk.API.Models;
using Sonluk.Entities.Master;
using Sonluk.Entities.QM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.QM
{
    /// <summary>
    /// Ingredient 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://Sonluk.com/API/QM/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Ingredient : System.Web.Services.WebService
    {
        QMModels models = new QMModels();

        [WebMethod]
        public List<IngredientItemInfo> Read(string serialNumber)
        {
            return models.Ingredient.Read(serialNumber).ToList();
        }

        [WebMethod]
        public List<IngredientInfo> Select(string material, string batch, string vendorBatch)
        {
            return models.Ingredient.Read(material, batch, vendorBatch).ToList();
        }

        [WebMethod]
        public List<MaterialInfo> Material()
        {
            return models.Ingredient.Material().ToList();
        }

        [WebMethod]
        public List<JSJYBBInfo> JSJYBBREAD(string VBELN, string POSNR)
        {
            return models.Ingredient.JSJYBBREAD(VBELN, POSNR).ToList();
        }
    }
}

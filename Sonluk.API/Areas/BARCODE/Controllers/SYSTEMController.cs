using Sonluk.API.Models;
using Sonluk.Entities.API;
using Sonluk.Entities.BARCODE;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Http;

namespace Sonluk.API.Areas.BARCODE.Controllers
{
    [ApiReturn]
    [ApiAuthorize]
    public class SYSTEMController : ApiController
    {
        RMSModels RMSmodel = new RMSModels();
        HelperModels HELPmodel = new HelperModels();
        string FileSavePath = System.Configuration.ConfigurationManager.AppSettings["FileSavePath"];
        [HttpGet]
        public ApiReturn ReadByParam(string data, string ptoken)
        {

            BARCODE_SY_CODING model = Newtonsoft.Json.JsonConvert.DeserializeObject<BARCODE_SY_CODING>(data);

            return new ApiReturn<string>(Newtonsoft.Json.JsonConvert.SerializeObject(RMSmodel.SY_CODING.ReadByParam(model)),true);
        }
        [HttpPost]
        public ApiReturn Create([FromBody]BARCODE_SY_CODING data, string width, string height, string ptoken)
        {
          //  BARCODE_SY_CODING model = Newtonsoft.Json.JsonConvert.DeserializeObject<BARCODE_SY_CODING>(data);
            return RMSmodel.SY_CODING.Create(data, width, height);
        }
        [HttpPost]
        public ApiReturn UPDATE([FromBody]BARCODE_SY_CODING data, string ptoken)
        {
            return new ApiReturn(RMSmodel.SY_CODING.Update(data));
        }
        [HttpPost]
        public ApiReturn DELETE(dynamic ID, string ptoken)
        {
            return RMSmodel.SY_CODING.Delete(ID);
        }
        [HttpPost]
        public ApiReturn CreateByImport(string ptoken)
        {
            try
            {
                HttpPostedFile QueryFile = HttpContext.Current.Request.Files[0];
                string FileName;
                string savePath;
                if (QueryFile == null || QueryFile.ContentLength <= 0)
                {
                    return new ApiReturn(false, "00001");
                }
                FileName = Path.GetFileName(QueryFile.FileName);

                // FileName = Path.Combine(HttpContext.Current.Request.MapPath("~/SaveFile"), Path.GetFileName(QueryFile.FileName));

                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();

                savePath = FileSavePath + @"\excel\" + year + @"\" + month + @"\" + FileName;
                if (Directory.Exists(FileSavePath + @"\excel\" + year + @"\" + month) == false)
                {
                    Directory.CreateDirectory(FileSavePath + @"\excel\" + year + @"\" + month);
                }
                QueryFile.SaveAs(FileName);

                FileInfo fi = new FileInfo(savePath);
                if (fi.Exists == true)
                {

                    //删除文件
                    System.IO.File.Delete(savePath);
                }
                DataTable DT = HELPmodel.ExcelHelper.ExcelToDataTable(FileName, true);

                string[] columnsName = new string[] { "描述", "条形码", "品牌", "产品类型", "型号", "数量", "包装形式", "包装数量", "版本", "备注", "业务员", "申请人" };

                if (DT != null)
                {
                    for (int i = 0; i < columnsName.Length; i++)
                    {
                        if (!DT.Columns.Contains(columnsName[i]))
                        {
                            return new ApiReturn(false, "10018");
                        }

                    }
                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        if (string.IsNullOrEmpty(DT.Rows[i]["描述"].ToString()))
                        {
                            return new ApiReturn(false, "10019", i, "描述");
                        }
                        if (string.IsNullOrEmpty(DT.Rows[i]["条形码"].ToString()))
                        {
                            return new ApiReturn(false, "10019", i, "条形码");
                        }
                        if (DT.Rows[i]["条形码"].ToString().Length != 13)
                        {
                            return new ApiReturn(false, "10019", i, "条形码");
                        }
                        if (string.IsNullOrEmpty(DT.Rows[i]["品牌"].ToString()))
                        {
                            return new ApiReturn(false, "10019", i, "品牌");
                        }
                    }
                }
                List<BARCODE_SY_CODING> nodes = new List<BARCODE_SY_CODING>();
                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    int index = 0;

                    BARCODE_SY_CODING node = new BARCODE_SY_CODING();
                    node.DESCRIPTION = DT.Rows[i][columnsName[index]].ToString();
                    node.BARCODE = DT.Rows[i][columnsName[index++]].ToString();
                    node.PP = RMSmodel.HG_DICT.ReadByDICNAME(DT.Rows[i][columnsName[index++]].ToString(), 128);
                    node.CPZL = RMSmodel.HG_DICT.ReadByDICNAME(DT.Rows[i][columnsName[index++]].ToString(), 124);
                    node.XH = RMSmodel.HG_DICT.ReadByDICNAME(DT.Rows[i][columnsName[index++]].ToString(), 126);
                    node.QUANTITY = RMSmodel.HG_DICT.ReadByDICNAME(DT.Rows[i][columnsName[index++]].ToString(), 125);
                    node.BZXS = RMSmodel.HG_DICT.ReadByDICNAME(DT.Rows[i][columnsName[index++]].ToString(), 123);
                    node.BZSL = DT.Rows[i][columnsName[index++]].ToString();
                    node.SERIES = RMSmodel.HG_DICT.ReadByDICNAME(DT.Rows[i][columnsName[index++]].ToString(), 54);
                    node.VERSION = DT.Rows[i][columnsName[index++]].ToString();
                    node.BEIZ = DT.Rows[i][columnsName[index++]].ToString();
                    node.YWY = DT.Rows[i][columnsName[index]].ToString();
                    node.SQR = DT.Rows[i][columnsName[index++]].ToString();
                    node.BEIZ = DT.Rows[i][columnsName[index++]].ToString();
                    node.PIPECODE = DT.Rows[i]["条形码"].ToString().Substring(6, 5);
                    node.CJR = ApiReceive.GetStaffID(ptoken);
                    node.XGR = ApiReceive.GetStaffID(ptoken);
                    nodes.Add(node);
                }
                return new ApiReturn(RMSmodel.SY_CODING.CreateByImport(nodes));
            }
            catch (Exception e)
            {
                MES_RETURN RES = new MES_RETURN();
                RES.TYPE = "E";
                RES.MESSAGE = e.Message;
                return new ApiReturn(RES);
            }
        }

    }
}

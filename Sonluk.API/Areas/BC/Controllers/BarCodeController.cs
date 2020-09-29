using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sonluk.API.Models;
using Sonluk.Entities.BC;
using System.Collections.Specialized;
using Sonluk.Entities.Account;
using Sonluk.Entities.MM;
using Sonluk.Entities.SD;
using Sonluk.Entities.MES;

namespace Sonluk.API.Areas.BC.Controllers
{
    public class BarCodeController : ApiController
    {
        BCModels models = new BCModels();
        LETRAModels lemodels = new LETRAModels();
        SSOModels ssomodels = new SSOModels();
        MMModels mmmodels = new MMModels();
        SDModels sdmodels = new SDModels();

        [HttpGet]
        public PickingtaskInfo ZBCFUN_CKGDP_DISPLAY(string IV_CJRQ, string IV_LGNUM)
        {
            return models.BarCode.ZBCFUN_CKGDP_DISPLAY(IV_CJRQ, IV_LGNUM);
        }

        [HttpGet]
        public PickingtaskInfo ZBCFUN_CKGDP_DISPLAY(string ptoken, string IV_CJRQ, string IV_LGNUM)
        {
            PickingtaskInfo rtn = new PickingtaskInfo();
            if (ssomodels.User.ValidateToken(ptoken))
            {
                rtn = models.BarCode.ZBCFUN_CKGDP_DISPLAY(IV_CJRQ, IV_LGNUM);
            }
            return rtn;
        }

        [HttpPost]
        public PickingtaskInfo ZBCFUN_CKGDP_DISPLAY()
        {
            string IV_CJRQ = "";
            string IV_LGNUM = "";
            string ptoken = "";

            if (Request.Content.IsFormData())
            {
                NameValueCollection values = Request.Content.ReadAsFormDataAsync().Result;
                IV_CJRQ = values["IV_CJRQ"].ToString();
                IV_LGNUM = values["IV_LGNUM"].ToString();
                ptoken = values["ptoken"].ToString();
            }

            PickingtaskInfo rtn = new PickingtaskInfo();
            if (ssomodels.User.ValidateToken(ptoken))
            {
                rtn = models.BarCode.ZBCFUN_CKGDP_DISPLAY(IV_CJRQ, IV_LGNUM);
            }

            return rtn;
        }

        [HttpGet]
        public TrackInfo ZBCFUN_WLZS_READ(string id)
        {
            TrackInfo ti = models.BarCode.ZBCFUN_WLZS_READ(id);

            return ti;
        }

        [HttpPost]
        public TrackInfo ZBCFUN_WLZS_READ()
        {
            string id = "";
            string ptoken = "";

            if (Request.Content.IsFormData())
            {
                NameValueCollection values = Request.Content.ReadAsFormDataAsync().Result;
                id = values["id"].ToString();
                ptoken = values["ptoken"].ToString();
            }

            TrackInfo rtn = new TrackInfo();
            if (ssomodels.User.ValidateToken(ptoken))
            {
                rtn = models.BarCode.ZBCFUN_WLZS_READ(id);
            }

            return rtn;

        }

        [HttpGet]
        public RktjInfo ZBCFUN_RKTJ_READ(string IV_START, string IV_END)
        {
            RktjInfo ti = models.BarCode.ZBCFUN_RKTJ_READ(IV_START, IV_END);

            return ti;
        }

        [HttpPost]
        public RktjInfo ZBCFUN_RKTJ_READ()//[FromBody]string IV_START, [FromBody]string IV_END
        {
            string IV_START = "";
            string IV_END = "";
            string ptoken = "";

            if (Request.Content.IsFormData())
            {
                NameValueCollection values = Request.Content.ReadAsFormDataAsync().Result;
                IV_START = values["IV_START"].ToString();
                IV_END = values["IV_END"].ToString();
                ptoken = values["ptoken"].ToString();
            }
            RktjInfo rtn = new RktjInfo();
            if (ssomodels.User.ValidateToken(ptoken))
            {
                rtn = models.BarCode.ZBCFUN_RKTJ_READ(IV_START, IV_END);
            }

            return rtn;
        }

        [HttpGet]
        public DeliveryNoteInfo ZSD_JH_READ(string I_VBELN, string ptoken)
        {
            AccountInfo userinfo = ssomodels.User.AcceptToken(ptoken);
            DeliveryNoteInfo ti = models.BarCode.ZSD_JH_READ(I_VBELN, userinfo.ID);

            return ti;
        }

        [HttpPost]
        public DeliveryNoteInfo ZSD_JH_READ()
        {
            string I_VBELN = "";
            string ptoken = "";

            if (Request.Content.IsFormData())
            {
                NameValueCollection values = Request.Content.ReadAsFormDataAsync().Result;
                I_VBELN = values["I_VBELN"].ToString();
                ptoken = values["ptoken"].ToString();
            }
            DeliveryNoteInfo rtn = new DeliveryNoteInfo();
            if (ssomodels.User.ValidateToken(ptoken))
            {
                AccountInfo userinfo = ssomodels.User.AcceptToken(ptoken);
                rtn = models.BarCode.ZSD_JH_READ(I_VBELN, userinfo.ID);
            }

            return rtn;
        }

        [HttpGet]
        public SalesOrderInfo ZSD_DD_READ(string I_VBELN, string ptoken)
        {
            AccountInfo userinfo = ssomodels.User.AcceptToken(ptoken);
            SalesOrderInfo ti = models.BarCode.ZSD_DD_READ(I_VBELN, userinfo.ID);

            return ti;
        }

        [HttpPost]
        public SalesOrderInfo ZSD_DD_READ()
        {
            string I_VBELN = "";
            string ptoken = "";

            if (Request.Content.IsFormData())
            {
                NameValueCollection values = Request.Content.ReadAsFormDataAsync().Result;
                I_VBELN = values["I_VBELN"].ToString();
                ptoken = values["ptoken"].ToString();
            }

            SalesOrderInfo rtn = new SalesOrderInfo();
            if (ssomodels.User.ValidateToken(ptoken))
            {
                AccountInfo userinfo = ssomodels.User.AcceptToken(ptoken);
                rtn = models.BarCode.ZSD_DD_READ(I_VBELN, userinfo.ID);
            }

            return rtn;
        }

        [HttpGet]
        public CKInfo ZSD_CK_READ(string I_START, string I_END, string ptoken)
        {
            AccountInfo userinfo = ssomodels.User.AcceptToken(ptoken);
            CKInfo ti = models.BarCode.ZSD_CK_READ(I_START, I_END, userinfo.ID);

            return ti;
        }

        [HttpPost]
        public CKInfo ZSD_CK_READ()
        {
            string I_START = "";
            string I_END = "";
            string ptoken = "";

            if (Request.Content.IsFormData())
            {
                NameValueCollection values = Request.Content.ReadAsFormDataAsync().Result;
                I_START = values["I_START"].ToString();
                I_END = values["I_END"].ToString();
                ptoken = values["ptoken"].ToString();
            }
            CKInfo rtn = new CKInfo();
            if (ssomodels.User.ValidateToken(ptoken))
            {
                AccountInfo userinfo = ssomodels.User.AcceptToken(ptoken);
                rtn = models.BarCode.ZSD_CK_READ(I_START, I_END, userinfo.ID);
            }

            return rtn;
        }

        [HttpGet]
        public TpmInfo ZBCFUN_TPM_READ(string IV_TPM)
        {
            TpmInfo ti = models.BarCode.ZBCFUN_TPM_READ(IV_TPM);

            return ti;
        }

        [HttpPost]
        public TpmInfo ZBCFUN_TPM_READ()
        {
            string IV_TPM = "";
            string ptoken = "";

            if (Request.Content.IsFormData())
            {
                NameValueCollection values = Request.Content.ReadAsFormDataAsync().Result;
                IV_TPM = values["IV_TPM"].ToString();
                ptoken = values["ptoken"].ToString();
            }

            TpmInfo rtn = new TpmInfo();
            if (ssomodels.User.ValidateToken(ptoken))
            {
                rtn = models.BarCode.ZBCFUN_TPM_READ(IV_TPM);
            }

            return rtn;
        }

        [HttpGet]
        public GdInfo ZBCFUN_GD_READ(string IV_GD)
        {
            GdInfo ti = models.BarCode.ZBCFUN_GD_READ(IV_GD);

            return ti;
        }

        [HttpPost]
        public GdInfo ZBCFUN_GD_READ()
        {
            string IV_GD = "";
            string ptoken = "";

            if (Request.Content.IsFormData())
            {
                NameValueCollection values = Request.Content.ReadAsFormDataAsync().Result;
                IV_GD = values["IV_GD"].ToString();
                ptoken = values["ptoken"].ToString();
            }

            GdInfo rtn = new GdInfo();
            if (ssomodels.User.ValidateToken(ptoken))
            {
                rtn = models.BarCode.ZBCFUN_GD_READ(IV_GD);
            }

            return rtn;
        }

        [HttpGet]
        public ZBCFUN_DRFDD_CRT_RETURN ZBCFUN_DRFDD_CRT(string IS_HEADDATA, string IT_ITEMDATA)
        {
            ZSL_BCS111 model_IS_HEADDATA = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_BCS111>(IS_HEADDATA);
            List<ZSL_BCS112> model_IT_ITEMDATA = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ZSL_BCS112>>(IT_ITEMDATA);
            ZBCFUN_DRFDD_CRT_RETURN ti = models.DRF.ZBCFUN_DRFDD_CRT(model_IS_HEADDATA, model_IT_ITEMDATA);
            return ti;
        }

        [HttpPost]
        public ZBCFUN_DRFDD_CRT_RETURN ZBCFUN_DRFDD_CRT()
        {
            ZSL_BCS111 model_IS_HEADDATA = new ZSL_BCS111();
            List<ZSL_BCS112> model_IT_ITEMDATA = new List<ZSL_BCS112>();
            if (Request.Content.IsFormData())
            {
                NameValueCollection values = Request.Content.ReadAsFormDataAsync().Result;
                model_IS_HEADDATA = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_BCS111>(values["IS_HEADDATA"].ToString());
                model_IT_ITEMDATA = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ZSL_BCS112>>(values["IT_ITEMDATA"].ToString());
            }

            ZBCFUN_DRFDD_CRT_RETURN rtn = new ZBCFUN_DRFDD_CRT_RETURN();
            rtn = models.DRF.ZBCFUN_DRFDD_CRT(model_IS_HEADDATA, model_IT_ITEMDATA);

            return rtn;
        }


        [HttpGet]
        public ZBCFUN_MMINFO_READ_RETURN ZBCFUN_MMINFO_READ(string IS_MATDATA)
        {
            ZSL_BCS112 model_IS_MATDATA = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_BCS112>(IS_MATDATA);
            ZBCFUN_MMINFO_READ_RETURN ti = mmmodels.MATERIALINFO.ZBCFUN_MMINFO_READ(model_IS_MATDATA);
            return ti;
        }

        [HttpPost]
        public ZBCFUN_MMINFO_READ_RETURN ZBCFUN_MMINFO_READ()
        {
            ZSL_BCS112 model_IS_MATDATA = new ZSL_BCS112();
            if (Request.Content.IsFormData())
            {
                NameValueCollection values = Request.Content.ReadAsFormDataAsync().Result;
                model_IS_MATDATA = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_BCS112>(values["IS_MATDATA"].ToString());
            }
            ZBCFUN_MMINFO_READ_RETURN rtn = new ZBCFUN_MMINFO_READ_RETURN();
            rtn = mmmodels.MATERIALINFO.ZBCFUN_MMINFO_READ(model_IS_MATDATA);
            return rtn;
        }
        [HttpGet]
        public ZBCFUN_KHXX_READ_RETURN ZBCFUN_KHXX_READ(string IS_HEADDATA)
        {
            ZSL_BCS111 model_IS_HEADDATA = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_BCS111>(IS_HEADDATA);
            ZBCFUN_KHXX_READ_RETURN ti = sdmodels.CLIENTINFO.ZBCFUN_KHXX_READ(model_IS_HEADDATA);
            return ti;
        }

        [HttpPost]
        public ZBCFUN_KHXX_READ_RETURN ZBCFUN_KHXX_READ()
        {
            ZSL_BCS111 model_IS_HEADDATA = new ZSL_BCS111();
            if (Request.Content.IsFormData())
            {
                NameValueCollection values = Request.Content.ReadAsFormDataAsync().Result;
                model_IS_HEADDATA = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_BCS111>(values["IS_HEADDATA"].ToString());
            }
            ZBCFUN_KHXX_READ_RETURN rtn = new ZBCFUN_KHXX_READ_RETURN();
            rtn = sdmodels.CLIENTINFO.ZBCFUN_KHXX_READ(model_IS_HEADDATA);
            return rtn;
        }

        // GET api/barcode
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/barcode/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/barcode
        public void Post([FromBody]string value)
        {

        }

        // PUT api/barcode/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/barcode/5
        public void Delete(int id)
        {
        }
    }
}

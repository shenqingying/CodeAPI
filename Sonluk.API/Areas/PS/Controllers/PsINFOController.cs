using Sonluk.API.Models;
using Sonluk.Entities.PS;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sonluk.API.Areas.PS.Controllers
{
    public class PsINFOController : ApiController
    {
        PSModels models = new PSModels();
        SSOModels ssomodels = new SSOModels();

        //[HttpGet]
        //public NetworkRead PS_read(string I_AUFNR)
        //{
        //    return models.NetWork.read(I_AUFNR);
        //}

        [HttpPost]
        public NetworkRead PS_read()
        {
            string I_AUFNR = "";
            string ptoken = "";

            if (Request.Content.IsFormData())
            {
                NameValueCollection values = Request.Content.ReadAsFormDataAsync().Result;
                I_AUFNR = values["I_AUFNR"].ToString();
                ptoken = values["ptoken"].ToString();
            }

            NetworkRead rtn = new NetworkRead();
            if (ssomodels.User.ValidateToken(ptoken))
            {
                rtn = models.NetWork.read(I_AUFNR);
            }

            return rtn;
        }


        //[HttpGet]
        //public Ps_cgds Component_DSXX(string I_NPLNR)
        //{
        //    return models.ComponentMove.Component_DSXX(I_NPLNR);
        //}

        [HttpPost]
        public PS_ZPSFUG_Q_CGDS Component_DSXX()
        {
            string I_NPLNR = "";
            string ptoken = "";

            if (Request.Content.IsFormData())
            {
                NameValueCollection values = Request.Content.ReadAsFormDataAsync().Result;
                I_NPLNR = values["I_NPLNR"].ToString();
                ptoken = values["ptoken"].ToString();
            }

            PS_ZPSFUG_Q_CGDS rtn = new PS_ZPSFUG_Q_CGDS();
            if (ssomodels.User.ValidateToken(ptoken))
            {
                rtn = models.ComponentMove.Component_DSXX(I_NPLNR);
            }

            return rtn;
        }


        //[HttpGet]
        //public string Component_ljds(string I_ERFMG, string I_EBELN, string I_BKTXT)
        //{
        //    return models.ComponentMove.Component_ljds(I_ERFMG, I_EBELN, I_BKTXT);
        //}

        //[HttpPost]
        //public string Component_ljds()
        //{
        //    string rst = "";
        //    string I_ERFMG = "";
        //    string I_EBELN = "";
        //    string I_BKTXT = "";
        //    string ptoken = "";

        //    if (Request.Content.IsFormData())
        //    {
        //        NameValueCollection values = Request.Content.ReadAsFormDataAsync().Result;
        //        I_ERFMG = values["I_ERFMG"].ToString();
        //        I_EBELN = values["I_EBELN"].ToString();
        //        I_BKTXT = values["I_BKTXT"].ToString();
        //        ptoken = values["ptoken"].ToString();
        //    }

        //    if (ssomodels.User.ValidateToken(ptoken))
        //    {
        //        rst = models.ComponentMove.Component_ljds(I_ERFMG, I_EBELN, I_BKTXT);
        //    }

        //    return rst;
        //}
    }
}

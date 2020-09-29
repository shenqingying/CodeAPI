using Sonluk.DAFactory;
using Sonluk.Entities.BC;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.BC;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class BC_PMLIST
    {
        private static readonly IBC_PMLIST _DataAccess_PMLIST = RMSDataAccess.CreateIBC_PMLIST();
        private static readonly IBarCode _DataAccess_Barcode = BCDataAccess.CreateBarCode();

        public int Create(CRM_BC_PMLIST model)
        {
            return _DataAccess_PMLIST.Create(model);
        }
        public IList<CRM_BC_PMLIST> SelectByModel(CRM_BC_PMLIST model, string BEGIN_DATE, string END_DATE)
        {
            return _DataAccess_PMLIST.SelectByModel(model, BEGIN_DATE, END_DATE);
        }
        public IList<CRM_BC_PMLISTList> SelectGD(CRM_BC_PMLIST model, string BEGIN_DATE, string END_DATE)
        {
            return _DataAccess_PMLIST.SelectGD(model, BEGIN_DATE, END_DATE);
        }
        public IList<CRM_BC_PMLISTList> SelectByGD(string AUFNR)
        {
            return _DataAccess_PMLIST.SelectByGD(AUFNR);
        }
        public IList<CRM_BC_PMLISTList> SelectByGDandParam(CRM_BC_PMLIST model, string BEGIN_DATE, string END_DATE)
        {
            return _DataAccess_PMLIST.SelectByGDandParam(model, BEGIN_DATE, END_DATE);
        }
        public CRM_BC_PMLISTList SelectByDXM(string DXM)
        {
            CRM_BC_PMLISTList model = _DataAccess_PMLIST.SelectByDXM(DXM);
            model.SUOSHU = model.ZBON * model.ZPKS;
            return model;
        }
        public IList<CRM_BC_PMLISTList> SelectOtherBigByDXM(string DXM)
        {
            IList<CRM_BC_PMLISTList> model = _DataAccess_PMLIST.SelectOtherBigByDXM(DXM);
            for (int i = 0; i < model.Count; i++)
            {
                model[i].SUOSHU = model[i].ZBON * model[i].ZPKS;
            }
            return model;
        }
        public int Delete(int PMID)
        {
            return _DataAccess_PMLIST.Delete(PMID);
        }
        public int DeleteByGD(string AUFNR)
        {
            return _DataAccess_PMLIST.DeleteByGD(AUFNR);
        }
        public int UpdatePM()
        {
            return _DataAccess_PMLIST.UpdatePM();
        }
        public IList<CRM_BC_PMLIST> SelectMATNRbyCHARGandPM(CRM_BC_PMLIST model)
        {
            return _DataAccess_PMLIST.SelectMATNRbyCHARGandPM(model);
        }
        public IList<CRM_BC_KH> SelectKHbyMCP(CRM_BC_PMLIST model)
        {
            return _DataAccess_PMLIST.SelectKHbyMCP(model);
        }
        public IList<CRM_BC_KH> SelectKHbyDXM(CRM_BC_PMLIST model)
        {
            return _DataAccess_PMLIST.SelectKHbyDXM(model);
        }
        public IList<CRM_BC_KH> SelectKHbyNHM(CRM_BC_CHMX model)
        {
            return _DataAccess_PMLIST.SelectKHbyNHM(model);
        }
        public int Create_WLM(CRM_BC_WLM_TEMP model)
        {
            return _DataAccess_PMLIST.Create_WLM(model);
        }
        public int Delete_WLM()
        {
            return _DataAccess_PMLIST.Delete_WLM();
        }
        public int Modify_WLM()
        {
            return _DataAccess_PMLIST.Modify_WLM();
        }

        public CRM_WebMSG GetNewWLM()
        {
            CRM_WebMSG msg = new CRM_WebMSG();
            msg.SUCCESS = false;
            msg.MSG = "";
            MODEL_ZBCFUN_THLOG_READ data = _DataAccess_Barcode.GET_ZBCFUN_THLOG_READ();
            if (data.ET_THLOG.Count == 0)
            {
                msg.MSG = "没有需要更新的数据";
                return msg;
            }

            _DataAccess_PMLIST.Delete_WLM();
            CRM_BC_WLM_TEMP model = new CRM_BC_WLM_TEMP();
            for (int i = 0; i < data.ET_THLOG.Count; i++)
            {
                model.MANDT = "";
                model.TGWLM = data.ET_THLOG[i].TGWLM;
                model.SRWLM = data.ET_THLOG[i].SRWLM;
                model.CJRQ = data.ET_THLOG[i].CJRQ;
                model.CJSJ = data.ET_THLOG[i].CJSJ;
                model.CJR = data.ET_THLOG[i].CJR;
                model.XGRQ = data.ET_THLOG[i].XGRQ;
                model.XGSJ = data.ET_THLOG[i].XGSJ;
                model.XGR = data.ET_THLOG[i].XGR;
                int id = _DataAccess_PMLIST.Create_WLM(model);
                if (id == 0)
                {
                    msg.MSG = "没有需要更新的数据！";
                    return msg;
                }
            }
            _DataAccess_PMLIST.Modify_WLM();

            msg.SUCCESS = true;
            msg.MSG = "更新成功！";
            return msg;
        }

    }
}

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
    public class BC_CHTT
    {
        private static readonly IBC_CHTT _DataAccess_CHTT = RMSDataAccess.CreateIBC_CHTT();
        private static readonly IBC_CHTT_FAKE _DataAccess_CHTT_FAKE = RMSDataAccess.CreateIBC_CHTT_FAKE();
        private static readonly IBarCode _DataAccess_Barcode = BCDataAccess.CreateBarCode();

        public int Modify()
        {
            return _DataAccess_CHTT.Modify();
        }
        public int SelectMXIDbyDXM(string DXM)
        {
            return _DataAccess_CHTT.SelectMXIDbyDXM(DXM);
        }
        public string SelectKUNAGbyTTID(int PMCHTTID)
        {
            return _DataAccess_CHTT.SelectKUNAGbyTTID(PMCHTTID);
        }
        public CRM_WebMSG TongBuSAP_CH()
        {
            CRM_WebMSG msg = new CRM_WebMSG();
            msg.SUCCESS = false;
            msg.MSG = "";
            string yesterday = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            MODEL_ZBCFUN_DLV_GET SAPdata = _DataAccess_Barcode.GET_ZBCFUN_DLV_GET(yesterday, "C");        //获取SAP数据
            if (SAPdata.ET_TTXX.Count == 0)
            {
                msg.MSG = "没有需要同步的信息";
                return msg;
            }
            int delete = _DataAccess_CHTT_FAKE.TTMXDelete();        //把FAKE表的数据清光
            if (delete != 0)
            {
                msg.MSG = "出货抬头同步发生异常，请重试";
                return msg;
            }
            for (int i = 0; i < SAPdata.ET_TTXX.Count; i++)       //抬头新增
            {
                CRM_BC_CHTT TTmodel = new CRM_BC_CHTT();
                TTmodel.VBELN = SAPdata.ET_TTXX[i].VBELN;
                TTmodel.WERKS = SAPdata.ET_TTXX[i].WERKS;
                TTmodel.POSNR = SAPdata.ET_TTXX[i].POSNR;
                TTmodel.MATNR = SAPdata.ET_TTXX[i].MATNR;
                TTmodel.KUNAG = SAPdata.ET_TTXX[i].KUNAG;
                TTmodel.LGORT = SAPdata.ET_TTXX[i].LGORT;
                TTmodel.WADAT_IST = SAPdata.ET_TTXX[i].WADAT_IST;
                TTmodel.XGR = SAPdata.ET_TTXX[i].XGR;

                int id = _DataAccess_CHTT_FAKE.TTCreate(TTmodel);
                if (id == 0)
                {
                    msg.MSG = "出货抬头同步失败，请重试";
                    return msg;
                }

            }
            for (int i = 0; i < SAPdata.ET_HXMXX.Count; i++)      //行项目新增
            {
                CRM_BC_CHMX MXmodel = new CRM_BC_CHMX();
                MXmodel.VBELN = SAPdata.ET_HXMXX[i].VBELN;
                MXmodel.POSNR = SAPdata.ET_HXMXX[i].POSNR;
                MXmodel.TPM = SAPdata.ET_HXMXX[i].TPM;
                MXmodel.DXM = SAPdata.ET_HXMXX[i].DXM;
                MXmodel.NHM = SAPdata.ET_HXMXX[i].NHM;
                MXmodel.CHARG = SAPdata.ET_HXMXX[i].CHARG;
                MXmodel.LWEDT = SAPdata.ET_HXMXX[i].LWEDT;
                MXmodel.QXBS = SAPdata.ET_HXMXX[i].QXBS;

                int id = _DataAccess_CHTT_FAKE.MXCreate(MXmodel);
                if (id == 0)
                {
                    msg.MSG = "出货行项目同步失败，请重试";
                    return msg;
                }

            }

            int error = _DataAccess_CHTT.Modify();      //数据更新

            if (error == 0)
            {
                msg.MSG = "同步完成";
                msg.SUCCESS = true;
                return msg;
            }
            else
            {
                msg.MSG = "同步失败，请重试";
                return msg;
            }



        }


        public IList<CRM_BC_CHMX> SelectCHMXbyDXM(string DXM, string TPM)
        {
            return _DataAccess_CHTT.SelectCHMXbyDXM(DXM, TPM);
        }

        public IList<CRM_BC_CHMX> ReadMXbyParam(CRM_BC_CHMX model)
        {
            return _DataAccess_CHTT.ReadMXbyParam(model);
        }

        public IList<CRM_BC_CHMX> ReadDXMbyTPM(string TPM)
        {
            return _DataAccess_CHTT.ReadDXMbyTPM(TPM);
        }


    }
}

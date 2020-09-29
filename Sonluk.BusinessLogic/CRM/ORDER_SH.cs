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
    public class ORDER_SH
    {
        private static readonly IORDER_SH _DataAccess = RMSDataAccess.CreateORDER_SH();
        private static readonly IORDER_TT _orderDataAccess = RMSDataAccess.CreateIORDER_TT();
        private static readonly IDRF detaAccess_DRF = BCDataAccess.CreateIDRF();

        public RETURN_MSG Modify(IList<CRM_ORDER_SH> model)
        {
            RETURN_MSG msg = new RETURN_MSG();
            List<ZSL_BCS113> IT_ORDERDATA = new List<ZSL_BCS113>();
            //先把关联到的SAP订单号放到一起
            for (int i = 0; i < model.Count; i++)
            {
                CRM_ORDER_TT cxorder = new CRM_ORDER_TT();
                cxorder.NotTB = 2;    //只查询有SAP订单号的数据
                cxorder.StoreNum = model[i].StoreNum;
                cxorder.KHPO = model[i].KHPO;
                cxorder.OrderSrc = model[i].OrderSrc;
                IList<CRM_ORDER_TT> order = _orderDataAccess.ReadTTbyParam(cxorder, 0, 0, 0);

                ZSL_BCS113 table_ET_ORDERDATA = new ZSL_BCS113();
                if (order.Count == 1)
                {
                    table_ET_ORDERDATA.VBELN = order[0].SAPORDER;
                    IT_ORDERDATA.Add(table_ET_ORDERDATA);

                    CRM_ORDER_MX cxmx = new CRM_ORDER_MX();
                    cxmx.StoreNum = model[i].StoreNum;
                    cxmx.KHPO = model[i].KHPO;
                    cxmx.OrderSrc = model[i].OrderSrc;
                    cxmx.ProdNum = model[i].ProdNum;
                    IList<CRM_ORDER_MX> mxdata = _orderDataAccess.ReadMXbyParam(cxmx);
                    if (mxdata.Count > 0)
                    {
                        model[i].OrderItem = mxdata[0].OrderItem;
                        model[i].SAPORDER = mxdata[0].SAPORDER;
                        model[i].POSNR = mxdata[0].OrderItem;
                    }




                }
                else
                {
                    continue;
                }


            }
            //return model;
            ZBCFUN_DRFDD_DT_RETURN result = detaAccess_DRF.ZBCFUN_DRFDD_DT(IT_ORDERDATA);

            if (result.MES_RETURN.TYPE == "S")
            {
                //RFC返回成功，开始进行匹配
                for (int i = 0; i < model.Count; i++)
                {
                    for (int j = 0; j < result.ET_ORDERDATA.Count; j++)
                    {
                        if (model[i].SAPORDER == null)
                        {

                        }
                        else    //只循环匹配得到的数据
                        {
                            if (model[i].SAPORDER.TrimStart('0') == result.ET_ORDERDATA[j].VBELN.TrimStart('0') && model[i].POSNR.TrimStart('0') == result.ET_ORDERDATA[j].POSNR.TrimStart('0'))
                            {
                                model[i].JHD = result.ET_ORDERDATA[j].JHD;
                                model[i].JHDItem = result.ET_ORDERDATA[j].POSNR_VL;
                                model[i].CPPH = result.ET_ORDERDATA[j].MATNR;
                                model[i].CPMC = result.ET_ORDERDATA[j].ARKTX;
                                model[i].JHSL = Convert.ToInt32(Convert.ToDouble(result.ET_ORDERDATA[j].LFIMG));
                                model[i].JHUnit = result.ET_ORDERDATA[j].VRKME;
                                model[i].SJJHSL = Convert.ToInt32(Convert.ToDouble(result.ET_ORDERDATA[j].LGMNG));
                                model[i].BaseUnit = result.ET_ORDERDATA[j].MEINS;
                                model[i].SDF = result.ET_ORDERDATA[j].KUNAG;
                                model[i].SDFNAME = result.ET_ORDERDATA[j].NAMEG;
                                model[i].SDF2 = result.ET_ORDERDATA[j].KUNNR;
                                model[i].SDF2NAME = result.ET_ORDERDATA[j].NAMER;
                                model[i].DJH = result.ET_ORDERDATA[j].KNUMV;
                                model[i].HSJE = Convert.ToDecimal(result.ET_ORDERDATA[j].HSJE);
                                model[i].ZKL = Convert.ToDecimal(result.ET_ORDERDATA[j].ZKRATE);
                                model[i].ZKJE = Convert.ToDecimal(result.ET_ORDERDATA[j].ZKJE);
                                model[i].SL = Convert.ToDecimal(result.ET_ORDERDATA[j].TAXRATE);
                                model[i].SE = Convert.ToDecimal(result.ET_ORDERDATA[j].TAXJE);
                                model[i].KPJE = Convert.ToDecimal(result.ET_ORDERDATA[j].KPJE);
                                model[i].WSJE = Convert.ToDecimal(result.ET_ORDERDATA[j].HWJE);


                                CRM_ORDER_SH cxmodel = new CRM_ORDER_SH();
                                cxmodel.OrderSrc = model[i].OrderSrc;
                                cxmodel.StoreNum = model[i].StoreNum;
                                cxmodel.KHPO = model[i].KHPO;
                                cxmodel.ProdNum = model[i].ProdNum;
                                IList<CRM_ORDER_SH> cxdata = _DataAccess.ReadByParam(cxmodel);
                                if (cxdata.Count > 0)
                                {
                                    int id = _DataAccess.UpdateByParam(model[i]);
                                }
                                else
                                {
                                    int id = _DataAccess.Create(model[i]);
                                }



                            }
                            else
                            {
                                //导入的数据与SAP的数据没有匹配项

                            }
                        }





                    }

                }

                msg.TYPE = result.MES_RETURN.TYPE;
                msg.MESSAGE = result.MES_RETURN.MESSAGE;
            }
            else
            {
                msg.TYPE = result.MES_RETURN.TYPE;
                msg.MESSAGE = result.MES_RETURN.MESSAGE;
            }



            return msg;
            //return model;
        }
        public IList<CRM_ORDER_SH> ReadByParam(CRM_ORDER_SH model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public IList<CRM_ORDER_SH> Report(CRM_ORDER_SH model)
        {
            return _DataAccess.Report(model);
        }


    }
}

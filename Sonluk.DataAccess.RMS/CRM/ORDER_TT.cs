using Sonluk.DataAccess.RMS.MES;
using Sonluk.Entities.CRM;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.CRM
{
    public class ORDER_TT : IORDER_TT
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_CreateTT = "CRM_ORDER_TT_CreateTT";
        private const string SQL_UpdateTT = "CRM_ORDER_TT_UpdateTT";
        private const string SQL_UpdateTT_KHinfo = "CRM_ORDER_TT_UpdateTT_KHinfo";
        private const string SQL_UpdateTT_BJ = "CRM_ORDER_TT_UpdateTT_BJ";
        private const string SQL_ReadTTbyID = "CRM_ORDER_TT_ReadTTbyID";
        private const string SQL_ReadTTbyParam = "CRM_ORDER_TT_ReadTTbyParam";
        private const string SQL_DeleteTT = "CRM_ORDER_TT_DeleteTT";

        private const string SQL_AddPrintCount = "CRM_ORDER_TT_AddPrintCount";
        private const string SQL_UpdateOrderIsactive = "CRM_ORDER_TT_UpdateOrderIsactive";
        private const string SQL_UpdateOrder_SAPORDER = "CRM_ORDER_TT_UpdateOrder_SAPORDER";
        private const string SQL_UpdateOrder_LOCK = "CRM_ORDER_TT_UpdateOrder_LOCK";


        private const string SQL_CreateMX = "CRM_ORDER_TT_CreateMX";
        private const string SQL_UpdateMX = "CRM_ORDER_TT_UpdateMX";
        private const string SQL_UpdateMX_WLinfo = "CRM_ORDER_TT_UpdateMX_WLinfo";
        private const string SQL_ReadMXbyTTID = "CRM_ORDER_TT_ReadMXbyTTID";
        private const string SQL_ReadMXbyMXID = "CRM_ORDER_TT_ReadMXbyMXID";
        private const string SQL_ReadMXbyParam = "CRM_ORDER_TT_ReadMXbyParam";
        private const string SQL_DeleteMX = "CRM_ORDER_TT_DeleteMX";
        private const string SQL_DeleteMXbyFItem = "CRM_ORDER_TT_DeleteMXbyFItem";

        private const string SQL_DRF_SYNC_INSERT = "CRM_ORDER_DRF_SYNC_INSERT";
        private const string SQL_DRF_SYNC_SELECT = "CRM_ORDER_DRF_SYNC_SELECT";
        private const string SQL_DRF_SYNC_UPDATE = "CRM_ORDER_DRF_SYNC_UPDATE";


        private const string SQL_DRF_USER_SELECT = "CRM_ORDER_DRF_USER_SELECT";

        private const string SQL_DRF_SYNC_TD_SELECT = "CRM_ORDER_DRF_SYNC_TD_SELECT";
        public int CreateTT(CRM_ORDER_TT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@DDLX", model.DDLX),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@KHSAP", model.KHSAP),
                                        new SqlParameter("@KHNAME", model.KHNAME),
                                        new SqlParameter("@SDFID", model.SDFID),
                                        new SqlParameter("@SDFNAME", model.SDFNAME),
                                        new SqlParameter("@SHIPID", model.SHIPID),
                                        new SqlParameter("@SHIPADD", model.SHIPADD),
                                        new SqlParameter("@FKSJ", model.FKSJ),
                                        new SqlParameter("@TEL", model.TEL),
                                        new SqlParameter("@XSZZ", model.XSZZ),
                                        new SqlParameter("@FXQD", model.FXQD),
                                        new SqlParameter("@CPZ", model.CPZ),
                                        new SqlParameter("@SAPORDER", model.SAPORDER),
                                        new SqlParameter("@KHPO", model.KHPO),
                                        new SqlParameter("@SUCCESS", model.SUCCESS),
                                        new SqlParameter("@REASON", model.REASON),
                                        new SqlParameter("@TOTAL", model.TOTAL),
                                        new SqlParameter("@DISCOUNT", model.DISCOUNT),
                                        new SqlParameter("@DISCOUNT_THIS", model.DISCOUNT_THIS),
                                        new SqlParameter("@DISCOUNT_BALANCE", model.DISCOUNT_BALANCE),
                                        new SqlParameter("@RATE", model.RATE),
                                        new SqlParameter("@ACTUAL", model.ACTUAL),
                                        new SqlParameter("@PREVIOUS_BALANCE", model.PREVIOUS_BALANCE),
                                        new SqlParameter("@PAY", model.PAY),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@BEIZ2", model.BEIZ2),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR),
                                        new SqlParameter("@CJSJ", model.CJSJ),
                                        new SqlParameter("@TJR", model.TJR),
                                        new SqlParameter("@SHR", model.SHR),
                                        new SqlParameter("@GDR", model.GDR),

                                        //为适用大润发订单系统追加如下
                                        new SqlParameter("@OrderSrc", model.OrderSrc),
                                        new SqlParameter("@OrderST", model.OrderST),
                                        new SqlParameter("@StoreNum", model.StoreNum),
                                        new SqlParameter("@StoreFax", model.StoreFax),
                                        new SqlParameter("@OrderDate", model.OrderDate),
                                        new SqlParameter("@DeliveryDate", model.DeliveryDate),
                                        new SqlParameter("@StoreNews", model.StoreNews),
                                        new SqlParameter("@CJZH", model.CJZH),
                                        new SqlParameter("@PDFPATH", model.PDFPATH)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_CreateTT, parms);
        }

        public int CreateMX(CRM_ORDER_MX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ORDERTTID", model.ORDERTTID),
                                        new SqlParameter("@PRODUCTID", model.PRODUCTID),
                                        new SqlParameter("@CPPH", model.CPPH),
                                        new SqlParameter("@CPMC", model.CPMC),
                                        new SqlParameter("@DDDW", model.DDDW),
                                        new SqlParameter("@DDSL", model.DDSL),
                                        new SqlParameter("@RATE", model.RATE),
                                        new SqlParameter("@BZDW", model.BZDW),
                                        new SqlParameter("@BZSL", model.BZSL),
                                        new SqlParameter("@PRICE", model.PRICE),
                                        new SqlParameter("@AMOUNT", model.AMOUNT),
                                        new SqlParameter("@KYSL", model.KYSL),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),

                                        //为适用大润发订单系统追加如下
                                        new SqlParameter("@StoreNum", model.StoreNum),
                                        new SqlParameter("@KHPO", model.KHPO),
                                        new SqlParameter("@OrderItem", model.OrderItem),
                                        new SqlParameter("@BarCode", model.BarCode),
                                        new SqlParameter("@ProdNum", model.ProdNum),
                                        new SqlParameter("@ProdName", model.ProdName),
                                        new SqlParameter("@ProdSpec", model.ProdSpec),
                                        new SqlParameter("@OrderUnit", model.OrderUnit),
                                        new SqlParameter("@XGR", model.XGR),
                                        new SqlParameter("@FItem", model.FItem),
                                        new SqlParameter("@ISCXP", model.ISCXP),
                                        new SqlParameter("@GC", model.GC),
                                        new SqlParameter("@KCDD", model.KCDD),
                                        new SqlParameter("@ISCF", model.ISCF),

                                   };
            return Binning(CommandType.StoredProcedure, SQL_CreateMX, parms);
        }

        public int UpdateTT(CRM_ORDER_TT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ORDERTTID", model.ORDERTTID),
                                        new SqlParameter("@SHIPID", model.SHIPID),
                                        new SqlParameter("@SHIPADD", model.SHIPADD),
                                        new SqlParameter("@FKSJ", model.FKSJ),
                                        new SqlParameter("@TOTAL", model.TOTAL),
                                        new SqlParameter("@DISCOUNT", model.DISCOUNT),
                                        new SqlParameter("@DISCOUNT_THIS", model.DISCOUNT_THIS),
                                        new SqlParameter("@DISCOUNT_BALANCE", model.DISCOUNT_BALANCE),
                                        new SqlParameter("@RATE", model.RATE),
                                        new SqlParameter("@ACTUAL", model.ACTUAL),
                                        new SqlParameter("@PREVIOUS_BALANCE", model.PREVIOUS_BALANCE),
                                        new SqlParameter("@PAY", model.PAY),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@BEIZ2", model.BEIZ2),
                                        new SqlParameter("@XGR", model.XGR),
                                        new SqlParameter("@TJR", model.TJR),
                                        new SqlParameter("@TJSJ", model.TJSJ),
                                        new SqlParameter("@SHR", model.SHR),
                                        new SqlParameter("@SHSJ", model.SHSJ),
                                        new SqlParameter("@GDR", model.GDR),
                                        new SqlParameter("@GDSJ", model.GDSJ),

                                        //为适用大润发订单系统追加如下
                                        new SqlParameter("@OrderST", model.OrderST),
                                        new SqlParameter("@StoreFax", model.StoreFax),
                                        new SqlParameter("@OrderDate", model.OrderDate),
                                        new SqlParameter("@DeliveryDate", model.DeliveryDate),
                                        new SqlParameter("@StoreNews", model.StoreNews),
                                        new SqlParameter("@BJR", model.BJR),
                                        new SqlParameter("@BJSJ", model.BJSJ),
                                        new SqlParameter("@PDFPATH", model.PDFPATH),
                                        new SqlParameter("@QRR", model.QRR),
                                        new SqlParameter("@QRSJ", model.QRSJ)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_UpdateTT, parms);
        }

        public int UpdateTT_KHinfo(CRM_ORDER_TT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ORDERTTID", model.ORDERTTID),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@KHSAP", model.KHSAP),
                                        new SqlParameter("@SDFID", model.SDFID),
                                        new SqlParameter("@SDFNAME", model.SDFNAME),


                                   };
            return Binning(CommandType.StoredProcedure, SQL_UpdateTT_KHinfo, parms);
        }

        public int UpdateTT_BJ(CRM_ORDER_TT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ORDERTTID", model.ORDERTTID),
                                        new SqlParameter("@BJR", model.BJR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_UpdateTT_BJ, parms);
        }

        public int UpdateOrderIsactive(int ORDERTTID, int ISACTIVE)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ORDERTTID", ORDERTTID),
                                        new SqlParameter("@ISACTIVE", ISACTIVE)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_UpdateOrderIsactive, parms);
        }

        public int UpdateOrder_SAPORDER(CRM_ORDER_TT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ORDERTTID", model.ORDERTTID),
                                        new SqlParameter("@SUCCESS", model.SUCCESS),
                                        new SqlParameter("@SAPORDER", model.SAPORDER),
                                        new SqlParameter("@JHD", model.JHD),
                                        new SqlParameter("@KHPO", model.KHPO)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_UpdateOrder_SAPORDER, parms);
        }

        public int UpdateOrder_LOCK(int ORDERTTID, int ISLOCK)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ORDERTTID", ORDERTTID),
                                        new SqlParameter("@ISLOCK", ISLOCK)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_UpdateOrder_LOCK, parms);
        }

        public int UpdateMX(CRM_ORDER_MX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ORDERMXID", model.ORDERMXID),
                                        new SqlParameter("@DDSL", model.DDSL),
                                        new SqlParameter("@AMOUNT", model.AMOUNT.ToString()),
                                        new SqlParameter("@BZSL", model.BZSL),
                                        new SqlParameter("@KYSL", model.KYSL),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@XGR", model.XGR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_UpdateMX, parms);
        }

        public int UpdateMX_WLinfo(CRM_ORDER_MX model, int STAFFID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ORDERMXID", model.ORDERMXID),
                                        new SqlParameter("@PRODUCTID", model.PRODUCTID),
                                        new SqlParameter("@CPPH", model.CPPH),
                                        new SqlParameter("@CPMC", model.CPMC),
                                        new SqlParameter("@DDSL", model.DDSL),
                                        new SqlParameter("@DDDW", model.DDDW),
                                        new SqlParameter("@ISCF", model.ISCF),
                                        new SqlParameter("@GC", model.GC),
                                        new SqlParameter("@KCDD", model.KCDD),
                                        new SqlParameter("@LB", model.LB),
                                        new SqlParameter("@STAFFID", STAFFID),

                                   };
            return Binning(CommandType.StoredProcedure, SQL_UpdateMX_WLinfo, parms);
        }

        public CRM_ORDER_TT ReadTTbyID(int ORDERTTID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@ORDERTTID",ORDERTTID)
                                   };
            CRM_ORDER_TT nodes = new CRM_ORDER_TT();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadTTbyID, parms))
                {
                    if (sdr.Read())
                    {
                        nodes = ReadTTDataToObj(sdr);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_ORDER_TT> ReadTTbyParam(CRM_ORDER_TT model, int STAFFID, int forCopy, int isGun)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@ORDERTTID",model.ORDERTTID),
                                       new SqlParameter("@OrderSrc",model.OrderSrc),
                                       new SqlParameter("@OrderST",model.OrderST),
                                       new SqlParameter("@DDLX",model.DDLX),
                                       new SqlParameter("@ISACTIVE",model.ISACTIVE),
                                       new SqlParameter("@KHSAP",model.KHSAP),
                                       new SqlParameter("@KHNAME",model.KHNAME),
                                       new SqlParameter("@StoreNum",model.StoreNum),
                                       new SqlParameter("@SDFID",model.SDFID),
                                       new SqlParameter("@SDFNAME",model.SDFNAME),
                                       new SqlParameter("@CJSJ_BEGIN",model.CJSJ_BEGIN),
                                       new SqlParameter("@CJSJ_END",model.CJSJ_END),
                                       new SqlParameter("@CJR",model.CJR),
                                       new SqlParameter("@STAFFID",STAFFID),
                                       new SqlParameter("@forCopy",forCopy),
                                       new SqlParameter("@isGun",isGun),

                                       //为适用大润发订单系统追加如下
                                       new SqlParameter("@KHPO",model.KHPO),
                                       new SqlParameter("@MDMCID",model.MDMCID),
                                       new SqlParameter("@OrderDateBEGIN",model.OrderDateBEGIN),
                                       new SqlParameter("@OrderDateEND",model.OrderDateEND),
                                       new SqlParameter("@OrderSTstr",model.OrderSTstr),
                                       new SqlParameter("@NotTB",model.NotTB),
                                       new SqlParameter("@YiDong",model.YiDong),
                                       new SqlParameter("@OrderSrc2",model.OrderSrc2),
                                       new SqlParameter("@CJZH",model.CJZH),
                                       new SqlParameter("@OrderST2",model.OrderST2),
                                       new SqlParameter("@OrderSrcstr",model.OrderSrcstr),
                                       new SqlParameter("@FuntionTYPE",model.FuntionTYPE),
                                       new SqlParameter("@NotQR",model.NotQR),

                                   };
            IList<CRM_ORDER_TT> nodes = new List<CRM_ORDER_TT>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadTTbyParam, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadTTDataListToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_ORDER_MX> ReadMXbyTTID(int ORDERTTID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@ORDERTTID",ORDERTTID)
                                   };
            IList<CRM_ORDER_MX> nodes = new List<CRM_ORDER_MX>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadMXbyTTID, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadMXDataToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_ORDER_MX> ReadMXbyParam(CRM_ORDER_MX model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@ORDERMXID",model.ORDERMXID),
                                       new SqlParameter("@ORDERTTID",model.ORDERTTID),
                                       new SqlParameter("@StoreNum",model.StoreNum),
                                       new SqlParameter("@KHPO",model.KHPO),
                                       new SqlParameter("@OrderItem",model.OrderItem),
                                       new SqlParameter("@BarCode",model.BarCode),
                                       new SqlParameter("@ProdNum",model.ProdNum),
                                       new SqlParameter("@ProdName",model.ProdName),
                                       new SqlParameter("@OrderSrc",model.OrderSrc),
                                       new SqlParameter("@FItem",model.FItem),
                                       new SqlParameter("@ReadyForSAP",model.ReadyForSAP),
                                       new SqlParameter("@FuntionTYPE",model.FuntionTYPE),
                                       new SqlParameter("@OrderSrcSTR",model.OrderSrcSTR),
                                       new SqlParameter("@ORDERSTSTR",model.ORDERSTSTR),
                                       new SqlParameter("@OrderDate_BEGIN",model.OrderDate_BEGIN),
                                       new SqlParameter("@OrderDate_END",model.OrderDate_END),
                                       new SqlParameter("@MDMCID",model.MDMCID),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };
            IList<CRM_ORDER_MX> nodes = new List<CRM_ORDER_MX>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadMXbyParam, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadMXDataListToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public CRM_ORDER_MX ReadMXbyMXID(int ORDERMXID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@ORDERMXID",ORDERMXID)
                                   };
            CRM_ORDER_MX nodes = new CRM_ORDER_MX();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadMXbyMXID, parms))
                {
                    if (sdr.Read())
                    {
                        nodes = ReadMXDataToObj(sdr);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }


        public int DeleteTT(int ORDERTTID, string which)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ORDERTTID", ORDERTTID),
                                        new SqlParameter("@WHICH", which)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_DeleteTT, parms);
        }

        public int AddPrintCount(int ORDERTTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ORDERTTID", ORDERTTID)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_AddPrintCount, parms);
        }

        public int DeleteMX(int ORDERMXID, int XGR)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ORDERMXID", ORDERMXID),
                                        new SqlParameter("@XGR", XGR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_DeleteMX, parms);
        }

        public int DeleteMXbyFItem(CRM_ORDER_MX model, int STAFFID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ORDERTTID", model.ORDERTTID),
                                        new SqlParameter("@FItem", model.FItem),
                                        new SqlParameter("@STAFFID", STAFFID)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_DeleteMXbyFItem, parms);
        }

        public MES_RETURN INSERT_DRF_SYNC(CRM_ORDER_DRF_SYNC model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ORDERTTID",model.ORDERTTID),
                                       new SqlParameter("@ACCOUNT",model.ACCOUNT),
                                       new SqlParameter("@STORENUM",model.STORENUM),
                                       new SqlParameter("@ORDERNUM",model.ORDERNUM),
                                       new SqlParameter("@BARCODE",model.BARCODE),
                                       new SqlParameter("@PRODNUM",model.PRODNUM),
                                       new SqlParameter("@PRODNAME",model.PRODNAME),
                                       new SqlParameter("@PRODSPEC",model.PRODSPEC),
                                       new SqlParameter("@ORDERUNIT",model.ORDERUNIT),
                                       new SqlParameter("@ORDERACTUAL",model.ORDERACTUAL),
                                       new SqlParameter("@QUANTITY",model.QUANTITY),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@ITEMTIME",model.ITEMTIME)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DRF_SYNC_INSERT, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "CRM_ORDER_DRF_SYNC_INSERT", "CRM");
            }
            return rst;
        }

        public CRM_ORDER_DRF_SYNC_SELECT SELECT_DRF_SYNC(CRM_ORDER_DRF_SYNC model)
        {
            CRM_ORDER_DRF_SYNC_SELECT rst = new CRM_ORDER_DRF_SYNC_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<CRM_ORDER_DRF_SYNC> child_CRM_ORDER_DRF_SYNC = new List<CRM_ORDER_DRF_SYNC>();
            try
            {
                SqlParameter[] parms = { 
                                       new SqlParameter("@ORDERTTID",model.ORDERTTID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DRF_SYNC_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        CRM_ORDER_DRF_SYNC child = new CRM_ORDER_DRF_SYNC();
                        child.ORDERTTID = Convert.ToInt32(sdr["ORDERTTID"]);
                        child.ACCOUNT = Convert.ToString(sdr["ACCOUNT"]);
                        child.STORENUM = Convert.ToString(sdr["STORENUM"]);
                        child.ORDERNUM = Convert.ToString(sdr["ORDERNUM"]);
                        child.BARCODE = Convert.ToString(sdr["BARCODE"]);
                        child.PRODNUM = Convert.ToString(sdr["PRODNUM"]);
                        child.PRODNAME = Convert.ToString(sdr["PRODNAME"]);
                        child.PRODSPEC = Convert.ToString(sdr["PRODSPEC"]);
                        child.ORDERUNIT = Convert.ToString(sdr["ORDERUNIT"]);
                        child.ORDERACTUAL = Convert.ToString(sdr["ORDERACTUAL"]);
                        child.QUANTITY = Convert.ToString(sdr["QUANTITY"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.ITEMTIME = Convert.ToString(sdr["ITEMTIME"]);
                        child_CRM_ORDER_DRF_SYNC.Add(child);
                    }
                }
                rst.CRM_ORDER_DRF_SYNC = child_CRM_ORDER_DRF_SYNC;
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
                rst.MES_RETURN = child_MES_RETURN;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "CRM_ORDER_DRF_SYNC_SELECT", "CRM");
            }
            return rst;
        }

        public CRM_ORDER_DRF_SYNC_TD_SELECT SELECT_DRF_SYNC_TD(CRM_ORDER_DRF_SYNC_TD model)
        {
            CRM_ORDER_DRF_SYNC_TD_SELECT rst = new CRM_ORDER_DRF_SYNC_TD_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<CRM_ORDER_DRF_SYNC_TD> child_CRM_ORDER_DRF_SYNC_TD = new List<CRM_ORDER_DRF_SYNC_TD>();
            try
            {
                SqlParameter[] parms = { 
                                       new SqlParameter("@ACCOUNT",model.ACCOUNT),
                                       new SqlParameter("@ORDERNUM",model.ORDERNUM),
                                       new SqlParameter("@STORENUM",model.STORENUM),
                                       new SqlParameter("@LBNAME",model.LBNAME)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DRF_SYNC_TD_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        CRM_ORDER_DRF_SYNC_TD child = new CRM_ORDER_DRF_SYNC_TD();
                        child.ACCOUNT = Convert.ToString(sdr["ACCOUNT"]);
                        child.STORENUM = Convert.ToString(sdr["STORENUM"]);
                        child.ORDERNUM = Convert.ToString(sdr["ORDERNUM"]);
                        child.TD = Convert.ToString(sdr["TD"]);
                        child_CRM_ORDER_DRF_SYNC_TD.Add(child);
                    }
                }
                rst.CRM_ORDER_DRF_SYNC_TD = child_CRM_ORDER_DRF_SYNC_TD;
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
                rst.MES_RETURN = child_MES_RETURN;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "CRM_ORDER_DRF_SYNC_SELECT", "CRM");
            }
            return rst;
        }

        public MES_RETURN UPDATE_DRF_SYNC(CRM_ORDER_DRF_SYNC model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ORDERTTID",model.ORDERTTID),
                                       new SqlParameter("@LB",model.LB)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DRF_SYNC_UPDATE, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "CRM_ORDER_DRF_SYNC_UPDATE", "CRM");
            }
            return rst;
        }
        public CRM_ORDER_DRF_USER_SELECT SELECT_USER_SYNC(CRM_ORDER_DRF_USER model)
        {
            CRM_ORDER_DRF_USER_SELECT rst = new CRM_ORDER_DRF_USER_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<CRM_ORDER_DRF_USER> child_CRM_ORDER_DRF_USER = new List<CRM_ORDER_DRF_USER>();
            try
            {
                SqlParameter[] parms = { 
                                       new SqlParameter("@USERACCOUNT",model.USERACCOUNT),
                                       new SqlParameter("@USERNAME",model.USERNAME),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@LB",model.LB)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DRF_USER_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        CRM_ORDER_DRF_USER child = new CRM_ORDER_DRF_USER();
                        child.USERACCOUNT = Convert.ToInt32(sdr["USERACCOUNT"]);
                        child.USERNAME = Convert.ToString(sdr["USERNAME"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child_CRM_ORDER_DRF_USER.Add(child);
                    }
                }
                rst.CRM_ORDER_DRF_USER = child_CRM_ORDER_DRF_USER;
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
                rst.MES_RETURN = child_MES_RETURN;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "CRM_ORDER_DRF_USER_SELECT", "CRM");
            }
            return rst;
        }


        private int Binning(CommandType type, string sql, SqlParameter[] parms)
        {
            int ID = 0;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(type, sql, parms))
                {
                    if (sdr.Read())
                    {
                        ID = Convert.ToInt32(sdr["ID"]);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return ID;
        }




        private CRM_ORDER_TT ReadTTDataToObj(SqlDataReader sdr)
        {
            CRM_ORDER_TT node = new CRM_ORDER_TT();
            node.ORDERTTID = Convert.ToInt32(sdr["ORDERTTID"]);
            node.DDLX = Convert.ToInt32(sdr["DDLX"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.KHSAP = Convert.ToString(sdr["KHSAP"]);
            node.KHNAME = Convert.ToString(sdr["KHNAME"]);
            node.SDFID = Convert.ToString(sdr["SDFID"]);
            node.SDFNAME = Convert.ToString(sdr["SDFNAME"]);
            node.SHIPID = Convert.ToString(sdr["SHIPID"]);
            node.SHIPADD = Convert.ToString(sdr["SHIPADD"]);
            node.FKSJ = Convert.ToString(sdr["FKSJ"]);
            node.TEL = Convert.ToString(sdr["TEL"]);
            node.XSZZ = Convert.ToString(sdr["XSZZ"]);
            node.FXQD = Convert.ToString(sdr["FXQD"]);
            node.CPZ = Convert.ToString(sdr["CPZ"]);
            node.SAPORDER = Convert.ToString(sdr["SAPORDER"]).TrimStart('0');
            node.JHD = Convert.ToString(sdr["JHD"]).TrimStart('0');
            node.KHPO = Convert.ToString(sdr["KHPO"]);
            node.SUCCESS = Convert.ToInt32(sdr["SUCCESS"]);
            node.REASON = Convert.ToString(sdr["REASON"]);
            node.TOTAL = Convert.ToDouble(sdr["TOTAL"]);
            node.DISCOUNT = Convert.ToDouble(sdr["DISCOUNT"]);
            node.DISCOUNT_THIS = Convert.ToDouble(sdr["DISCOUNT_THIS"]);
            node.DISCOUNT_BALANCE = Convert.ToDouble(sdr["DISCOUNT_BALANCE"]);
            node.RATE = Convert.ToDouble(sdr["RATE"]);
            node.ACTUAL = Convert.ToDouble(sdr["ACTUAL"]);
            node.PREVIOUS_BALANCE = Convert.ToDouble(sdr["PREVIOUS_BALANCE"]);
            node.PAY = Convert.ToDouble(sdr["PAY"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.BEIZ2 = Convert.ToString(sdr["BEIZ2"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.TJR = Convert.ToInt32(sdr["TJR"]);
            node.TJSJ = Convert.ToDateTime(sdr["TJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.SHR = Convert.ToInt32(sdr["SHR"]);
            node.SHSJ = Convert.ToDateTime(sdr["SHSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.GDR = Convert.ToInt32(sdr["GDR"]);
            node.GDSJ = Convert.ToDateTime(sdr["GDSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.PRINTCOUNT = Convert.ToInt32(sdr["PRINTCOUNT"]);
            node.KHLX = Convert.ToInt32(sdr["KHLX"]);

            //为适用大润发订单系统追加如下
            node.OrderSrc = Convert.ToInt32(sdr["OrderSrc"]);
            node.OrderST = Convert.ToInt32(sdr["OrderST"]);
            node.StoreNum = Convert.ToString(sdr["StoreNum"]);
            node.StoreFax = Convert.ToString(sdr["StoreFax"]);
            node.OrderDate = Convert.ToString(sdr["OrderDate"]);
            node.DeliveryDate = Convert.ToString(sdr["DeliveryDate"]);
            node.StoreNews = Convert.ToString(sdr["StoreNews"]);
            node.TBSJ = Convert.ToString(sdr["TBSJ"]);
            node.BJR = Convert.ToInt32(sdr["BJR"]);
            node.BJSJ = Convert.ToString(sdr["BJSJ"]);
            node.DYSJ = Convert.ToString(sdr["DYSJ"]);
            node.CJZH = Convert.ToString(sdr["CJZH"]);
            node.PDFPATH = Convert.ToString(sdr["PDFPATH"]);
            node.ISLOCK = Convert.ToInt32(sdr["ISLOCK"]);
            node.QRR = Convert.ToInt32(sdr["QRR"]);
            node.QRSJ = Convert.ToString(sdr["QRSJ"]);



            return node;
        }

        private CRM_ORDER_TT ReadTTDataListToObj(SqlDataReader sdr)
        {
            CRM_ORDER_TT node = new CRM_ORDER_TT();
            node.ORDERTTID = Convert.ToInt32(sdr["ORDERTTID"]);
            node.DDLX = Convert.ToInt32(sdr["DDLX"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.KHSAP = Convert.ToString(sdr["KHSAP"]);
            node.KHNAME = Convert.ToString(sdr["KHNAME"]);
            node.SDFID = Convert.ToString(sdr["SDFID"]);
            node.SDFNAME = Convert.ToString(sdr["SDFNAME"]);
            node.SHIPID = Convert.ToString(sdr["SHIPID"]);
            node.SHIPADD = Convert.ToString(sdr["SHIPADD"]);
            node.FKSJ = Convert.ToString(sdr["FKSJ"]);
            node.TEL = Convert.ToString(sdr["TEL"]);
            node.XSZZ = Convert.ToString(sdr["XSZZ"]);
            node.FXQD = Convert.ToString(sdr["FXQD"]);
            node.CPZ = Convert.ToString(sdr["CPZ"]);
            node.SAPORDER = Convert.ToString(sdr["SAPORDER"]).TrimStart('0');
            node.JHD = Convert.ToString(sdr["JHD"]).TrimStart('0');
            node.KHPO = Convert.ToString(sdr["KHPO"]);
            node.SUCCESS = Convert.ToInt32(sdr["SUCCESS"]);
            node.REASON = Convert.ToString(sdr["REASON"]);
            node.TOTAL = Convert.ToDouble(sdr["TOTAL"]);
            node.DISCOUNT = Convert.ToDouble(sdr["DISCOUNT"]);
            node.DISCOUNT_THIS = Convert.ToDouble(sdr["DISCOUNT_THIS"]);
            node.DISCOUNT_BALANCE = Convert.ToDouble(sdr["DISCOUNT_BALANCE"]);
            node.RATE = Convert.ToDouble(sdr["RATE"]);
            node.ACTUAL = Convert.ToDouble(sdr["ACTUAL"]);
            node.PREVIOUS_BALANCE = Convert.ToDouble(sdr["PREVIOUS_BALANCE"]);
            node.PAY = Convert.ToDouble(sdr["PAY"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.BEIZ2 = Convert.ToString(sdr["BEIZ2"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.ISCANCEL = Convert.ToInt32(sdr["ISCANCEL"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.TJR = Convert.ToInt32(sdr["TJR"]);
            node.TJSJ = Convert.ToDateTime(sdr["TJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.SHR = Convert.ToInt32(sdr["SHR"]);
            node.SHSJ = Convert.ToDateTime(sdr["SHSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.GDR = Convert.ToInt32(sdr["GDR"]);
            node.GDSJ = Convert.ToDateTime(sdr["GDSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.PRINTCOUNT = Convert.ToInt32(sdr["PRINTCOUNT"]);
            node.DDLXDES = Convert.ToString(sdr["DDLXDES"]);
            node.CJRDES = Convert.ToString(sdr["CJRDES"]);
            node.XGRDES = Convert.ToString(sdr["XGRDES"]);
            node.SHRDES = Convert.ToString(sdr["SHRDES"]);
            node.GDRDES = Convert.ToString(sdr["GDRDES"]);

            //为适用大润发订单系统追加如下
            node.OrderSrc = Convert.ToInt32(sdr["OrderSrc"]);
            node.OrderST = Convert.ToInt32(sdr["OrderST"]);
            node.StoreNum = Convert.ToString(sdr["StoreNum"]);
            node.StoreFax = Convert.ToString(sdr["StoreFax"]);
            node.OrderDate = Convert.ToString(sdr["OrderDate"]);
            node.DeliveryDate = Convert.ToString(sdr["DeliveryDate"]);
            node.StoreNews = Convert.ToString(sdr["StoreNews"]);
            node.TBSJ = Convert.ToString(sdr["TBSJ"]);
            node.BJR = Convert.ToInt32(sdr["BJR"]);
            node.BJSJ = Convert.ToString(sdr["BJSJ"]);
            node.DYSJ = Convert.ToString(sdr["DYSJ"]);
            node.CJZH = Convert.ToString(sdr["CJZH"]);
            node.PDFPATH = Convert.ToString(sdr["PDFPATH"]);
            node.ISLOCK = Convert.ToInt32(sdr["ISLOCK"]);
            node.QRR = Convert.ToInt32(sdr["QRR"]);
            node.QRSJ = Convert.ToString(sdr["QRSJ"]);
            node.OrderSrcDES = Convert.ToString(sdr["OrderSrcDES"]);
            node.BJRNAME = Convert.ToString(sdr["BJRNAME"]);
            node.QRRNAME = Convert.ToString(sdr["QRRNAME"]);

            return node;
        }

        private CRM_ORDER_MX ReadMXDataToObj(SqlDataReader sdr)
        {
            CRM_ORDER_MX node = new CRM_ORDER_MX();
            node.ORDERMXID = Convert.ToInt32(sdr["ORDERMXID"]);
            node.ORDERTTID = Convert.ToInt32(sdr["ORDERTTID"]);
            node.PRODUCTID = Convert.ToInt32(sdr["PRODUCTID"]);
            node.CPPH = Convert.ToString(sdr["CPPH"]);
            node.CPMC = Convert.ToString(sdr["CPMC"]);
            node.DDDW = Convert.ToString(sdr["DDDW"]);
            node.DDSL = Convert.ToInt32(sdr["DDSL"]);
            node.RATE = Convert.ToInt32(sdr["RATE"]);
            node.BZDW = Convert.ToString(sdr["BZDW"]);
            node.BZSL = Convert.ToInt32(sdr["BZSL"]);
            node.PRICE = Convert.ToDouble(sdr["PRICE"]);
            node.AMOUNT = Convert.ToDouble(sdr["AMOUNT"]);
            node.KYSL = Convert.ToInt32(sdr["KYSL"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);

            //为适用大润发订单系统追加如下
            node.StoreNum = Convert.ToString(sdr["StoreNum"]);
            node.KHPO = Convert.ToString(sdr["KHPO"]);
            node.OrderItem = Convert.ToString(sdr["OrderItem"]);
            node.BarCode = Convert.ToString(sdr["BarCode"]);
            node.ProdNum = Convert.ToString(sdr["ProdNum"]);
            node.ProdName = Convert.ToString(sdr["ProdName"]);
            node.ProdSpec = Convert.ToString(sdr["ProdSpec"]);
            node.OrderUnit = Convert.ToString(sdr["OrderUnit"]);
            node.FItem = Convert.ToString(sdr["FItem"]);
            node.ISCF = Convert.ToInt32(sdr["ISCF"]);
            node.ISCXP = Convert.ToInt32(sdr["ISCXP"]);
            node.GC = Convert.ToString(sdr["GC"]);
            node.KCDD = Convert.ToString(sdr["KCDD"]);
            return node;
        }

        private CRM_ORDER_MX ReadMXDataListToObj(SqlDataReader sdr)
        {
            CRM_ORDER_MX node = new CRM_ORDER_MX();
            node.ORDERMXID = Convert.ToInt32(sdr["ORDERMXID"]);
            node.ORDERTTID = Convert.ToInt32(sdr["ORDERTTID"]);
            node.PRODUCTID = Convert.ToInt32(sdr["PRODUCTID"]);
            node.CPPH = Convert.ToString(sdr["CPPH"]);
            node.CPMC = Convert.ToString(sdr["CPMC"]);
            node.DDDW = Convert.ToString(sdr["DDDW"]);
            node.DDSL = Convert.ToInt32(sdr["DDSL"]);
            node.RATE = Convert.ToInt32(sdr["RATE"]);
            node.BZDW = Convert.ToString(sdr["BZDW"]);
            node.BZSL = Convert.ToInt32(sdr["BZSL"]);
            node.PRICE = Convert.ToDouble(sdr["PRICE"]);
            node.AMOUNT = Convert.ToDouble(sdr["AMOUNT"]);
            node.KYSL = Convert.ToInt32(sdr["KYSL"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CPLXDES = Convert.ToString(sdr["CPLXDES"]);
            node.CPXLDES = Convert.ToString(sdr["CPXLDES"]);
            node.CPXHDES = Convert.ToString(sdr["CPXHDES"]);
            node.CODE = Convert.ToString(sdr["CODE"]);

            //为适用大润发订单系统追加如下
            node.StoreNum = Convert.ToString(sdr["StoreNum"]);
            node.KHPO = Convert.ToString(sdr["KHPO"]);
            node.OrderItem = Convert.ToString(sdr["OrderItem"]);
            node.BarCode = Convert.ToString(sdr["BarCode"]);
            node.ProdNum = Convert.ToString(sdr["ProdNum"]);
            node.ProdName = Convert.ToString(sdr["ProdName"]);
            node.ProdSpec = Convert.ToString(sdr["ProdSpec"]);
            node.OrderUnit = Convert.ToString(sdr["OrderUnit"]);
            node.SAPORDER = Convert.ToString(sdr["SAPORDER"]).TrimStart('0');
            node.JHD = Convert.ToString(sdr["JHD"]).TrimStart('0');
            node.FItem = Convert.ToString(sdr["FItem"]);
            node.ISCF = Convert.ToInt32(sdr["ISCF"]);
            node.ISCXP = Convert.ToInt32(sdr["ISCXP"]);
            node.GC = Convert.ToString(sdr["GC"]);
            node.KCDD = Convert.ToString(sdr["KCDD"]);
            node.KCDDMS = Convert.ToString(sdr["KCDDMS"]);
            node.SonCount = Convert.ToInt32(sdr["SonCount"]);

            node.OrderSrc = Convert.ToInt32(sdr["OrderSrc"]);
            node.OrderSrcDES = Convert.ToString(sdr["OrderSrcDES"]);
            node.MDMC = Convert.ToString(sdr["MDMC"]);
            node.KHNAME = Convert.ToString(sdr["KHNAME"]);

            return node;
        }



    }
}

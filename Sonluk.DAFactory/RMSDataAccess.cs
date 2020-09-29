using Sonluk.IDataAccess.RMS;
using Sonluk.IDataAccess.CRM;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Sonluk.IDataAccess.SonlukRegex;
using Sonluk.IDataAccess.FIVES;
using Sonluk.IDataAccess.EM;
using Sonluk.IDataAccess.FICO;
using Sonluk.IDataAccess.MSG;
using Sonluk.IDataAccess.BARCODE;

namespace Sonluk.DAFactory
{
    public class RMSDataAccess
    {
        private static readonly string assembly = AppConfig.Settings("RMS.DataAccess");
        private static readonly string SAPAssembly = AppConfig.Settings("SAP");
        private static readonly string OAassembly = AppConfig.Settings("OA.DataAccess");
        private RMSDataAccess() { }

        /// <summary>
        /// 反射“产品”数据操作类
        /// </summary>
        /// <returns></returns>
        public static IProduct CreateProduct()
        {
            return (IProduct)Assembly.Load(assembly).CreateInstance(assembly + ".Product");
        }

        public static ICRM_KH  CreateCRM_KH()
        {
            return (ICRM_KH)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.CRM_KH");
        }

        public static ICRM_HG CreateCRM_HG()
        {
            return (ICRM_HG)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.CRM_HG");
        }
        public static ICRM_BF CreateCRM_BF()
        {
            return (ICRM_BF)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.CRM_BF");
        }
        public static ICRM_HD CreateCRM_HD()
        {
            return (ICRM_HD)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.CRM_HD");
        }
        public static ICRM_KQ CreateCRM_KQ()
        {
            return (ICRM_KQ)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.CRM_KQ");
        }


        public static IKH_KH CreateKH_KH()
        {
            return (IKH_KH)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.KH_KH");
        }

        public static IKH_LXR CreateKH_LXR()
        {
            return (IKH_LXR)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.KH_LXR");
        }
        public static IKH_GXQY CreateKH_GXQY()
        {
            return (IKH_GXQY)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.KH_GXQY");
        }
        public static IKH_KHQTXX CreateKH_KHQTXX()
        {
            return (IKH_KHQTXX)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.KH_KHQTXX");
        }
        public static IHG_WJJL CreateHG_WJJL()
        {
            return (IHG_WJJL)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.HG_WJJL");
        }
        public static IHG_DICT CreateHG_DICT()
        {
            return (IHG_DICT)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.HG_DICT");
        }
        public static IHG_TYPE CreateHG_TYPE()
        {
            return (IHG_TYPE)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.HG_TYPE");
        }
        public static IKH_GROUP CreateKH_GROUP()
        {
            return (IKH_GROUP)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.KH_GROUP");
        }
        public static IKH_HZHB CreateKH_HZHB()
        {
            return (IKH_HZHB)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.KH_HZHB");
        }

        public static IKH_HZHB_SAP CreateKH_HZHB_SAP()
        {
            return (IKH_HZHB_SAP)Assembly.Load(SAPAssembly).CreateInstance(SAPAssembly + ".CRM.KH_HZHB");
        }
        public static IKH_GROUP_KH CreateKH_GROUP_KH()
        {
            return (IKH_GROUP_KH)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.KH_GROUP_KH");
        }
        public static IKH_XSQYSJ CreateKH_XSQYSJ()
        {
            return (IKH_XSQYSJ)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.KH_XSQYSJ");
        }
        public static IHG_STAFF CreateHG_STAFF()
        {
            return (IHG_STAFF)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.HG_STAFF");
        }

        public static IHG_DEPT CreateHG_DEPT()
        {
            return (IHG_DEPT)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.HG_DEPT");
        }
        public static IHG_DUTY CreateHG_DUTY()
        {
            return (IHG_DUTY)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.HG_DUTY");
        }
        public static IHG_STAFFDUTY CreateHG_STAFFDUTY()
        {
            return (IHG_STAFFDUTY)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.HG_STAFFDUTY");
        }
        public static IHG_BZGZSJ CreateHG_BZGZSJ()
        {
            return (IHG_BZGZSJ)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.HG_BZGZSJ");
        }
        public static IHG_KQDZ CreateHG_KQDZ()
        {
            return (IHG_KQDZ)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.HG_KQDZ");
        }
        public static IHG_RYKQ CreateHG_RYKQ()
        {
            return (IHG_RYKQ)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.HG_RYKQ");
        }
        public static IKQ_GZRL CreateKQ_GZRL()
        {
            return (IKQ_GZRL)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.KQ_GZRL");
        }

        public static IKQ_GZRLMX CreateKQ_GZRLMX()
        {
            return (IKQ_GZRLMX)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.KQ_GZRLMX");
        }

        public static IHG_ROLE CreateHG_ROLE()
        {
            return (IHG_ROLE)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.HG_ROLE");
        }

        public static IHG_RIGHT CreateHG_RIGHT()
        {
            return (IHG_RIGHT)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.HG_RIGHT");
        }
        public static IHG_RIGHTGROUP CreateHG_RIGHTGROUP()
        {
            return (IHG_RIGHTGROUP)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.HG_RIGHTGROUP");
        }

        public static IKQ_YGQJ CreateKQ_YGQJ()
        {
            return (IKQ_YGQJ)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.KQ_YGQJ");
        }
        public static IKQ_QD CreateKQ_QD()
        {
            return (IKQ_QD)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.KQ_QD");
        }
        public static ICRM_Login CreateCRM_Login()
        {
            return (ICRM_Login)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.CRM_Login");
        }
        public static ICRM_OA CreateCRM_OA()
        {
            return (ICRM_OA)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.CRM_OA");
        }
        
        public static IKH_GROUP_STAFF CreateKH_GROUP_STAFF()
        {
            return (IKH_GROUP_STAFF)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.KH_GROUP_STAFF");
        }
        public static IKQ_YCKQSM CreateKQ_YCKQSM()
        {
            return (IKQ_YCKQSM)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.KQ_YCKQSM");
        }
        public static IKH_DZ CreateKH_DZ()
        {
            return (IKH_DZ)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.KH_DZ");
        }
        public static IKQ_CC CreateKQ_CC()
        {
            return (IKQ_CC)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.KQ_CC");
        }
       
        public static IBF_BFDJ CreateBF_BFDJ()
        {
            return (IBF_BFDJ)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.BF_BFDJ");
        }
        public static IBF_BFJH CreateBF_BFJH()
        {
            return (IBF_BFJH)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.BF_BFJH");
        }
        public static IKH_GROUP_XSQY CreateKH_GROUP_XSQY()
        {
            return (IKH_GROUP_XSQY)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.KH_GROUP_XSQY");
        }
        public static IBF_BFQD CreateBF_BFQD()
        {
            return (IBF_BFQD)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.BF_BFQD");
        }
        public static ICRM_KQ_Report CreateCRM_KQ_Report()
        {
            return (ICRM_KQ_Report)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.CRM_KQ_Report");
        }
        public static IOA_TRANSMIT CreateOA_TRANSMIT()
        {
            return (IOA_TRANSMIT)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.OA_TRANSMIT");
        }
        public static ICRM_OA_FLOW CreateCRM_OA_FLOW()
        {
            return (ICRM_OA_FLOW)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.CRM_OA_FLOW");
        }
        public static IHD_ZDF CreateHD_ZDF()
        {
            return (IHD_ZDF)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.HD_ZDF");
        }
        public static IHD_ZYCXYTT CreateHD_ZYCXYTT()
        {
            return (IHD_ZYCXYTT)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.HD_ZYCXYTT");
        }
        public static IHD_ZYCXYMX CreateHD_ZYCXYMX()
        {
            return (IHD_ZYCXYMX)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.HD_ZYCXYMX");
        }
        public static IHD_NKAXTTT CreateHD_NKAXTTT()
        {
            return (IHD_NKAXTTT)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.HD_NKAXTTT");
        }
        public static IHD_NKAXTMX CreateHD_NKAXTMX()
        {
            return (IHD_NKAXTMX)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.HD_NKAXTMX");
        }
        public static IHD_NKAMDTT CreateHD_NKAMDTT()
        {
            return (IHD_NKAMDTT)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.HD_NKAMDTT");
        }
        public static IHD_NKAMDMX CreateHD_NKAMDMX()
        {
            return (IHD_NKAMDMX)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.HD_NKAMDMX");
        }
        public static IWX_OPENID CreateWX_OPENID()
        {
            return (IWX_OPENID)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.WX_OPENID");
        }
        public static ISYS_CS CreateSYS_CS()
        {
            return (ISYS_CS)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.SYS_CS");
        }
        public static IKH_BF CreateKH_BF()
        {
            return (IKH_BF)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.KH_BF");
        }
        public static IKH_KHBF CreateKH_KHBF()
        {
            return (IKH_KHBF)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.KH_KHBF");
        }
        public static IBF_BFJHMX CreateBF_BFJHMX()
        {
            return (IBF_BFJHMX)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.BF_BFJHMX");
        }
        public static ICRM_PENDING CreateCRM_PENDING()
        {
            return (ICRM_PENDING)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.CRM_PENDING");
        }
        public static IHG_STAFFKHLX CreateHG_STAFFKHLX()
        {
            return (IHG_STAFFKHLX)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.HG_STAFFKHLX");
        }
        public static IHG_KHLX CreateHG_KHLX()
        {
            return (IHG_KHLX)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.HG_KHLX");
        }
        public static IKH_KHXS CreateKH_KHXS()
        {
            return (IKH_KHXS)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.KH_KHXS");
        }
        //public static ISonluk CreateSonlukRegex()
        //{
        //    return (ISonluk)Assembly.Load(assembly).CreateInstance(assembly + ".SonlukRegex.Sonluk");
        //}
        public static ISAP_Report CreateSAP_Report()
        {
            return (ISAP_Report)Assembly.Load(SAPAssembly).CreateInstance(SAPAssembly + ".CRM.SAP_Report");
        }
        public static IKH_XSYWJZ CreateKH_XSYWJZ()
        {
            return (IKH_XSYWJZ)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.KH_XSYWJZ");
        }
        public static IKH_KHZZ CreateKH_KHZZ()
        {
            return (IKH_KHZZ)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.KH_KHZZ");
        }
        public static IKH_HD CreateKH_HD()
        {
            return (IKH_HD)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.KH_HD");
        }
        public static IBC_PMLIST CreateIBC_PMLIST()
        {
            return (IBC_PMLIST)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.BC_PMLIST");
        }
        public static IBC_CHTT CreateIBC_CHTT()
        {
            return (IBC_CHTT)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.BC_CHTT");
        }
        public static IBC_CHTT_FAKE CreateIBC_CHTT_FAKE()
        {
            return (IBC_CHTT_FAKE)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.BC_CHTT_FAKE");
        }
        public static IBC_FXCH CreateIBC_FXCH()
        {
            return (IBC_FXCH)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.BC_FXCH");
        }
        public static IMSG_INVOICE CreateIMSG_INVOICE()
        {
            return (IMSG_INVOICE)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.MSG_INVOICE");
        }
        public static IMSG_NOTICE CreateIMSG_NOTICE()
        {
            return (IMSG_NOTICE)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.MSG_NOTICE");
        }
        public static IPRODUCT_PRODUCT CreateIPRODUCT_PRODUCT()
        {
            return (IPRODUCT_PRODUCT)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.PRODUCT_PRODUCT");
        }
        public static IPRODUCT_PRODUCTGROUP CreateIPRODUCT_PRODUCTGROUP()
        {
            return (IPRODUCT_PRODUCTGROUP)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.PRODUCT_PRODUCTGROUP");
        }
        public static IPRODUCT_GROUP CreateIPRODUCT_GROUP()
        {
            return (IPRODUCT_GROUP)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.PRODUCT_GROUP");
        }
        public static IPRODUCT_KHGROUP CreateIPRODUCT_KHGROUP()
        {
            return (IPRODUCT_KHGROUP)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.PRODUCT_KHGROUP");
        }
        public static IPRODUCT_WARN CreateIPRODUCT_WARN()
        {
            return (IPRODUCT_WARN)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.PRODUCT_WARN");
        }
        public static IORDER_TT CreateIORDER_TT()
        {
            return (IORDER_TT)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.ORDER_TT");
        }
        public static IQYJS_MENU CreateIIQYJS_MENU()
        {
            return (IQYJS_MENU)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.QYJS_MENU");
        }
        public static IQYJS_FILE CreateQYJS_FILE()
        {
            return (IQYJS_FILE)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.QYJS_FILE");
        }
        public static IOA_OPINION CreateOA_OPINION()
        {
            return (IOA_OPINION)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.OA_OPINION");
        }
        public static ICOST_LKAPRODUCT CreateCOST_LKAPRODUCT()
        {
            return (ICOST_LKAPRODUCT)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_LKAPRODUCT");
        }
        public static ICOST_LKAXS CreateCOST_LKAXS()
        {
            return (ICOST_LKAXS)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_LKAXS");
        }
        public static ICOST_GGGS CreateCOST_GGGS()
        {
            return (ICOST_GGGS)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_GGGS");
        }
        public static ICOST_ITEM CreateCOST_ITEM()
        {
            return (ICOST_ITEM)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_ITEM");
        }
        public static ICOST_CP CreateCOST_CP()
        {
            return (ICOST_CP)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_CP");
        }
        public static ICOST_LKAYEARCOST CreateCOST_LKAYEARCOST()
        {
            return (ICOST_LKAYEARCOST)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_LKAYEARCOST");
        }
        public static ICOST_LKAYEARLIST CreateCOST_LKAYEARLIST()
        {
            return (ICOST_LKAYEARLIST)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_LKAYEARLIST");
        }
        public static ICOST_LKAYEARMD CreateCOST_LKAYEARMD()
        {
            return (ICOST_LKAYEARMD)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_LKAYEARMD");
        }
        public static ICOST_LKAYEARTT CreateCOST_LKAYEARTT()
        {
            return (ICOST_LKAYEARTT)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_LKAYEARTT");
        }
        public static ICOST_LKAYEARXS CreateCOST_LKAYEARXS()
        {
            return (ICOST_LKAYEARXS)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_LKAYEARXS");
        }
        public static ICOST_ZZFSJT CreateCOST_ZZFSJT()
        {
            return (ICOST_ZZFSJT)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_ZZFSJT");
        }
        public static ICOST_ZZFMX CreateCOST_ZZFMX()
        {
            return (ICOST_ZZFMX)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_ZZFMX");
        }
        public static ICOST_ZZFTT CreateCOST_ZZFTT()
        {
            return (ICOST_ZZFTT)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_ZZFTT");
        }
        public static ICOST_LKAFYTT CreateCOST_LKAFYTT()
        {
            return (ICOST_LKAFYTT)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_LKAFYTT");
        }
        public static ICOST_LKAFYMXDT CreateCOST_LKAFYMXDT()
        {
            return (ICOST_LKAFYMXDT)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_LKAFYMXDT");
        }
        public static ICOST_LKAFYMXTSCL CreateCOST_LKAFYMXTSCL()
        {
            return (ICOST_LKAFYMXTSCL)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_LKAFYMXTSCL");
        }
        public static ICOST_LKAYEARCOST_LKAHXZLMX CreateCOST_LKAYEARCOST_LKAHXZLMX()
        {
            return (ICOST_LKAYEARCOST_LKAHXZLMX)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_LKAYEARCOST_LKAHXZLMX");
        }
        public static ICOST_LKAHXZLMX_LKAHXDJMX CreateCOST_LKAHXZLMX_LKAHXDJMX()
        {
            return (ICOST_LKAHXZLMX_LKAHXDJMX)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_LKAHXZLMX_LKAHXDJMX");
        }
        public static ICOST_LKAHXZLTT CreateCOST_LKAHXZLTT()
        {
            return (ICOST_LKAHXZLTT)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_LKAHXZLTT");
        }
        public static ICOST_LKAHXZLMX CreateCOST_LKAHXZLMX()
        {
            return (ICOST_LKAHXZLMX)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_LKAHXZLMX");
        }
        public static ICOST_LKAHXZLMD CreateCOST_LKAHXZLMD()
        {
            return (ICOST_LKAHXZLMD)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_LKAHXZLMD");
        }
        public static ICOST_LKAHXDJTT CreateCOST_LKAHXDJTT()
        {
            return (ICOST_LKAHXDJTT)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_LKAHXDJTT");
        }
        public static ICOST_LKAHXDJMX CreateCOST_LKAHXDJMX()
        {
            return (ICOST_LKAHXDJMX)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_LKAHXDJMX");
        }
        public static IWL_TT CreateWL_TT()
        {
            return (IWL_TT)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.WL_TT");
        }
        public static ICOST_FI CreateCOST_FI()
        {
            return (ICOST_FI)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_FI");
        }
        public static ICOST_CLFMX CreateCOST_CLFMX()
        {
            return (ICOST_CLFMX)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_CLFMX");
        }
        public static ICOST_CLFTT CreateCOST_CLFTT()
        {
            return (ICOST_CLFTT)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_CLFTT");
        }
        public static ICOST_CLFTT_STAFF CreateCOST_CLFTT_STAFF()
        {
            return (ICOST_CLFTT_STAFF)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_CLFTT_STAFF");
        }
        public static ICOST_CBZX CreateCOST_CBZX()
        {
            return (ICOST_CBZX)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_CBZX");
        }
        public static ICOST_TS CreateCOST_TS()
        {
            return (ICOST_TS)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_TS");
        }
        public static ICOST_TSMX CreateCOST_TSMX()
        {
            return (ICOST_TSMX)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_TSMX");
        }
        public static ICOST_CLFHX CreateCOST_CLFHX()
        {
            return (ICOST_CLFHX)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_CLFHX");
        }
        public static ICOST_CLFMX_CLFHX CreateCOST_CLFMX_CLFHX()
        {
            return (ICOST_CLFMX_CLFHX)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_CLFMX_CLFHX");
        }
        public static ICOST_KAXS CreateCOST_KAXS()
        {
            return (ICOST_KAXS)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_KAXS");
        }
        public static ICOST_KAYEARTT CreateCOST_KAYEARTT()
        {
            return (ICOST_KAYEARTT)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_KAYEARTT");
        }
        public static ICOST_KAYEARCOST CreateCOST_KAYEARCOST()
        {
            return (ICOST_KAYEARCOST)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_KAYEARCOST");
        }
        public static ICOST_PSF CreateCOST_PSF()
        {
            return (ICOST_PSF)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_PSF");
        }
        public static ICOST_OTHER CreateCOST_OTHER()
        {
            return (ICOST_OTHER)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_OTHER");
        }
        public static ICOST_KADTTT CreateCOST_KADTTT()
        {
            return (ICOST_KADTTT)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_KADTTT");
        }
        public static ICOST_KADTDP CreateCOST_KADTDP()
        {
            return (ICOST_KADTDP)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_KADTDP");
        }
        public static ICOST_KADTMX CreateCOST_KADTMX()
        {
            return (ICOST_KADTMX)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_KADTMX");
        }
        public static ICOST_LKAEachYEAR CreateCOST_LKAEachYEAR()
        {
            return (ICOST_LKAEachYEAR)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_LKAEachYEAR");
        }
        public static ICOST_KATSCLTT CreateCOST_KATSCLTT()
        {
            return (ICOST_KATSCLTT)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_KATSCLTT");
        }
        public static ICOST_KATSCLMX CreateCOST_KATSCLMX()
        {
            return (ICOST_KATSCLMX)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_KATSCLMX");
        }
        public static ICOST_MDBS CreateCOST_MDBS()
        {
            return (ICOST_MDBS)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_MDBS");
        }
        public static ICOST_KAHXZLTT CreateCOST_KAHXZLTT()
        {
            return (ICOST_KAHXZLTT)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_KAHXZLTT");
        }
        public static ICOST_KAHXZLMX CreateCOST_KAHXZLMX()
        {
            return (ICOST_KAHXZLMX)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_KAHXZLMX");
        }
        public static ICOST_CXY CreateCOST_CXY()
        {
            return (ICOST_CXY)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_CXY");
        }
        public static ICOST_CXYGZ CreateCOST_CXYGZ()
        {
            return (ICOST_CXYGZ)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_CXYGZ");
        }
        public static ICOST_KAHXDJTT CreateCOST_KAHXDJTT()
        {
            return (ICOST_KAHXDJTT)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_KAHXDJTT");
        }
        public static ICOST_KAHXDJMX CreateCOST_KAHXDJMX()
        {
            return (ICOST_KAHXDJMX)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_KAHXDJMX");
        }
        public static ICOST_KAYEARCOST_KAHXDJMX CreateCOST_KAYEARCOST_KAHXDJMX()
        {
            return (ICOST_KAYEARCOST_KAHXDJMX)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_KAYEARCOST_KAHXDJMX");
        }
        public static ICOST_KAHXZLMX_KAHXDJMX CreateCOST_KAHXZLMX_KAHXDJMX()
        {
            return (ICOST_KAHXZLMX_KAHXDJMX)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_KAHXZLMX_KAHXDJMX");
        }
        public static ICOST_MDBS_KAHXDJMX CreateCOST_MDBS_KAHXDJMX()
        {
            return (ICOST_MDBS_KAHXDJMX)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_MDBS_KAHXDJMX");
        }
        public static ICOST_OTHER_KAHXDJMX CreateCOST_OTHER_KAHXDJMX()
        {
            return (ICOST_OTHER_KAHXDJMX)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_OTHER_KAHXDJMX");
        }
        public static ICOST_PSF_KAHXDJMX CreateCOST_PSF_KAHXDJMX()
        {
            return (ICOST_PSF_KAHXDJMX)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_PSF_KAHXDJMX");
        }
        public static ICOST_JXSHXDJTT CreateCOST_JXSHXDJTT()
        {
            return (ICOST_JXSHXDJTT)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_JXSHXDJTT");
        }
        public static ICOST_JXSHXDJMX CreateCOST_JXSHXDJMX()
        {
            return (ICOST_JXSHXDJMX)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_JXSHXDJMX");
        }
        public static ICOST_CPLX CreateCOST_CPLX()
        {
            return (ICOST_CPLX)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_CPLX");
        }
        public static ICOST_CXHD CreateCOST_CXHD()
        {
            return (ICOST_CXHD)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_CXHD");
        }
        public static ICOST_CXHDTC CreateCOST_CXHDTC()
        {
            return (ICOST_CXHDTC)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_CXHDTC");
        }
        public static ICOST_GSZCFS CreateCOST_GSZCFS()
        {
            return (ICOST_GSZCFS)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_GSZCFS");
        }
        public static ICOST_CXHDPGQD CreateCOST_CXHDPGQD()
        {
            return (ICOST_CXHDPGQD)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_CXHDPGQD");
        }
        public static ICOST_CXHDPGHZ CreateCOST_CXHDPGHZ()
        {
            return (ICOST_CXHDPGHZ)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_CXHDPGHZ");
        }
        public static ICOST_JXSHXDJMX_COST CreateCOST_JXSHXDJMX_COST()
        {
            return (ICOST_JXSHXDJMX_COST)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_JXSHXDJMX_COST");
        }
        public static ICOST_CJHDWD CreateCOST_CJHDWD()
        {
            return (ICOST_CJHDWD)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_CJHDWD");
        }
        public static ICOST_WDTC CreateCOST_WDTC()
        {
            return (ICOST_WDTC)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_WDTC");
        }
        public static ICOST_MDBSHX CreateCOST_MDBSHX()
        {
            return (ICOST_MDBSHX)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_MDBSHX");
        }
        public static ICOST_ZZFTT_LKAHXDJMX CreateCOST_ZZFTT_LKAHXDJMX()
        {
            return (ICOST_ZZFTT_LKAHXDJMX)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_ZZFTT_LKAHXDJMX");
        }
        public static ICOST_ZZFTT_KAHXDJMX CreateCOST_ZZFTT_KAHXDJMX()
        {
            return (ICOST_ZZFTT_KAHXDJMX)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_ZZFTT_KAHXDJMX");
        }
        public static ICOST_LKADTDP CreateCOST_LKADTDP()
        {
            return (ICOST_LKADTDP)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.COST_LKADTDP");
        }





        public static ISYS_SYSINFO CreateSYS_SYSINFO()
        {
            return (ISYS_SYSINFO)Assembly.Load(assembly).CreateInstance(assembly + ".MSG.SYS_SYSINFO");
        }
        public static ISYS_STAFF CreateSYS_STAFF()
        {
            return (ISYS_STAFF)Assembly.Load(assembly).CreateInstance(assembly + ".MSG.SYS_STAFF");
        }
        public static ISEND_INFO CreateSEND_INFO()
        {
            return (ISEND_INFO)Assembly.Load(assembly).CreateInstance(assembly + ".MSG.SEND_INFO");
        }
        public static IMSG_TYPE CreateMSG_TYPE()
        {
            return (IMSG_TYPE)Assembly.Load(assembly).CreateInstance(assembly + ".MSG.MSG_TYPE");
        }
        public static IMSGTYPE_WAY CreateMSGTYPE_WAY()
        {
            return (IMSGTYPE_WAY)Assembly.Load(assembly).CreateInstance(assembly + ".MSG.MSGTYPE_WAY");
        }
        public static IMSG_SENDWAY CreateMSG_SENDWAY()
        {
            return (IMSG_SENDWAY)Assembly.Load(assembly).CreateInstance(assembly + ".MSG.MSG_SENDWAY");
        }


















        public static ISY_XTBB CreateEMSY_XTBB()
        {
            return (ISY_XTBB)Assembly.Load(assembly).CreateInstance(assembly + ".EM.SY_XTBB");
        }
        public static ISY_MANUAL CreateEMSY_MANUAL()
        {
            return (ISY_MANUAL)Assembly.Load(assembly).CreateInstance(assembly + ".EM.SY_MANUAL");
        }
        public static ISY_DEVICE_CONTRACT CreateSY_DEVICE_CONTRACT()
        {
            return (ISY_DEVICE_CONTRACT)Assembly.Load(assembly).CreateInstance(assembly + ".EM.SY_DEVICE_CONTRACT");
        }
        public static ISY_INFOREPORT CreateSY_INFOREPORT()
        {
            return (ISY_INFOREPORT)Assembly.Load(assembly).CreateInstance(assembly + ".EM.SY_INFOREPORT");
        }
        
        public static ISY_BINDINGDEVICE CreateSY_BINDINGDEVICE()
        {
            return (ISY_BINDINGDEVICE)Assembly.Load(assembly).CreateInstance(assembly + ".EM.SY_BINDINGDEVICE");
        }
        public static ISY_DEVICEDETAILDOC CreateEMSY_DEVICEDETAILDOC()
        {
            return (ISY_DEVICEDETAILDOC)Assembly.Load(assembly).CreateInstance(assembly + ".EM.SY_DEVICEDETAILDOC");
        }
        public static ISY_DEVICEQRJL CreateEMSY_DEVICEQRJL()
        {
            return (ISY_DEVICEQRJL)Assembly.Load(assembly).CreateInstance(assembly + ".EM.SY_DEVICEQRJL");
        }

        
        
        public static ISY_MANUALBB CreateEMSY_MANUALBB()
        {
            return (ISY_MANUALBB)Assembly.Load(assembly).CreateInstance(assembly + ".EM.SY_MANUALBB");
        }
        public static ISY_DEVICETYPE CreateEMSY_DEVICETYPE()
        {
            return (ISY_DEVICETYPE)Assembly.Load(assembly).CreateInstance(assembly + ".EM.SY_DEVICETYPE");
        }


        
        public static ISY_MANUALPATH CreateEMSY_MANUALPATH()
        {
            return (ISY_MANUALPATH)Assembly.Load(assembly).CreateInstance(assembly + ".EM.SY_MANUALPATH");
        }
        public static ISY_STAFF_EMTYPE CreateEMSY_STAFF_EMTYPE()
        {
            return (ISY_STAFF_EMTYPE)Assembly.Load(assembly).CreateInstance(assembly + ".EM.SY_STAFF_EMTYPE");
        }
        public static ISY_SBBHMANUAL CreateEMSY_SBBHMANUAL()
        {
            return (ISY_SBBHMANUAL)Assembly.Load(assembly).CreateInstance(assembly + ".EM.SY_SBBHMANUAL");
        }
        public static ISY_PB CreateEMSY_PB()
        {
            return (ISY_PB)Assembly.Load(assembly).CreateInstance(assembly + ".EM.SY_PB");
        }
        public static ISY_SBBINDPB CreateEMSY_SBBINDPB()
        {
            return (ISY_SBBINDPB)Assembly.Load(assembly).CreateInstance(assembly + ".EM.SY_SBBINDPB");
        }
        public static ISY_STAFFIDBINDPB CreateEMSY_STAFFIDBINDPB()
        {
            return (ISY_STAFFIDBINDPB)Assembly.Load(assembly).CreateInstance(assembly + ".EM.SY_STAFFIDBINDPB");
        }
        
        
        public static ISY_SBBHDEVICETYPE CreateEMSY_SBBHDEVICETYPE()
        {
            return (ISY_SBBHDEVICETYPE)Assembly.Load(assembly).CreateInstance(assembly + ".EM.SY_SBBHDEVICETYPE");
        }
        

        public static IFILE_PATH CreateEMFILE_PATH()
        {
            return (IFILE_PATH)Assembly.Load(assembly).CreateInstance(assembly + ".EM.FILE_PATH");
        }
        






















        public static ISAP_ORDER CreateISAP_ORDER()
        {
            return (ISAP_ORDER)Assembly.Load(SAPAssembly).CreateInstance(SAPAssembly + ".CRM.SAP_ORDER");
        }
        public static ISY_TYPE CreateSY_TYPE() 
        {
            return (ISY_TYPE)Assembly.Load(assembly).CreateInstance(assembly + ".FIVES.SY_TYPE"); 
        }
        public static ISY_STAFF_DEP CreateSY_STAFF_DEP() 
        {
            return (ISY_STAFF_DEP)Assembly.Load(assembly).CreateInstance(assembly + ".FIVES.SY_STAFF_DEP"); 
        }
        public static ISTAFF_DEP CreateSTAFF_DEP()
        {
            return (ISTAFF_DEP)Assembly.Load(assembly).CreateInstance(assembly + ".FIVES.STAFF_DEP");
        }
        public static ISY_DICT CreateSY_DICT() 
        {
            return (ISY_DICT)Assembly.Load(assembly).CreateInstance(assembly + ".FIVES.SY_DICT"); 
        }
        public static ISY_CHECKGROUP_STAFF CreateSY_CHECKGROUP_STAFF() {
            return (ISY_CHECKGROUP_STAFF)Assembly.Load(assembly).CreateInstance(assembly + ".FIVES.SY_CHECKGROUP_STAFF");
        }
        public static ISY_CHECKGROUP CreateSY_CHECKGROUP()
        {
            return (ISY_CHECKGROUP)Assembly.Load(assembly).CreateInstance(assembly + ".FIVES.SY_CHECKGROUP");
        }
        public static ISY_CHECKGROUP_DEPARTMENT CreateSY_CHECKGROUP_DEPARTMENT() 
        {
            return (ISY_CHECKGROUP_DEPARTMENT)Assembly.Load(assembly).CreateInstance(assembly + ".FIVES.SY_CHECKGROUP_DEPARTMENT"); 
        }
        public static ICHECK_INFO CreateCHECK_INFO() {
            return (ICHECK_INFO)Assembly.Load(assembly).CreateInstance(assembly + ".FIVES.CHECK_INFO");
        }
        public static ICHECK_INFODETAIL CreateCHECK_INFODETAIL() 
        {
            return (ICHECK_INFODETAIL)Assembly.Load(assembly).CreateInstance(assembly + ".FIVES.CHECK_INFODETAIL"); 
        }
        public static ISY_STATION CreateSY_STATION() 
        {
            return (ISY_STATION)Assembly.Load(assembly).CreateInstance(assembly + ".FIVES.SY_STATION");
        }
        public static ISY_PRINCIPALCATEGROY CreateSY_PRINCIPALCATEGROY() 
        {
            return (ISY_PRINCIPALCATEGROY)Assembly.Load(assembly).CreateInstance(assembly + ".FIVES.SY_PRINCIPALCATEGROY");
        }
        public static ISY_RELATIONSHIPBIND CreateSY_RELATIONSHIPBIND() 
        {
            return (ISY_RELATIONSHIPBIND)Assembly.Load(assembly).CreateInstance(assembly + ".FIVES.SY_RELATIONSHIPBIND");
        }
        public static ISY_CHECKPOINTCATEGROY CreateSY_CHECKPOINTCATEGROY() 
        {
            return (ISY_CHECKPOINTCATEGROY)Assembly.Load(assembly).CreateInstance(assembly + ".FIVES.SY_CHECKPOINTCATEGROY"); 
        }
        public static ISY_CHECKPOINT_CHECKDETAIL CreateSY_CHECKPOINT_CHECKDETAIL() 
        {
            return (ISY_CHECKPOINT_CHECKDETAIL)Assembly.Load(assembly).CreateInstance(assembly + ".FIVES.SY_CHECKPOINT_CHECKDETAIL"); 
        }
        public static ISY_CHECKPOINT_POINTCATEGROY CreateSY_CHECKPOINT_POINTCATEGROY() 
        {
            return (ISY_CHECKPOINT_POINTCATEGROY)Assembly.Load(assembly).CreateInstance(assembly + ".FIVES.SY_CHECKPOINT_POINTCATEGROY"); 
        }
        public static ISY_CHECKPOINT CreateSY_CHECKPOINT() 
        {
            return (ISY_CHECKPOINT)Assembly.Load(assembly).CreateInstance(assembly + ".FIVES.SY_CHECKPOINT");
        }
        public static ISY_POINTCATEGROYDETAIL CreateSY_POINTCATEGROY_DETAIL() 
        {
            return (ISY_POINTCATEGROYDETAIL)Assembly.Load(assembly).CreateInstance(assembly + ".FIVES.SY_POINTCATEGROY_DETAIL");
        }
        public static ISY_CHECKDETAILCATEGROY CreateSY_CHECKDETAILCATEGROY() 
        {
            return (ISY_CHECKDETAILCATEGROY)Assembly.Load(assembly).CreateInstance(assembly + ".FIVES.SY_CHECKDETAILCATEGROY");
        }
        public static ISY_CHECKDETAILS CreateSY_CHECKDETAILS() 
        {
            return (ISY_CHECKDETAILS)Assembly.Load(assembly).CreateInstance(assembly + ".FIVES.SY_CHECKDETAILS");
        }
         public static ISY_DEPTPUSHRY CreateSY_DEPTPUSHRY() 
        {
            return (ISY_DEPTPUSHRY)Assembly.Load(assembly).CreateInstance(assembly + ".FIVES.SY_DEPTPUSHRY");
        }

        








        //kaorder
        public static IHG_STAFFDICT CreateHG_STAFFDICT()
        {
            return (IHG_STAFFDICT)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.HG_STAFFDICT");
        }
        public static IPRODUCT_HH CreatePRODUCT_HH()
        {
            return (IPRODUCT_HH)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.PRODUCT_HH");
        }
        public static IPRODUCT_PRODUCT_HH CreatePRODUCT_PRODUCT_HH()
        {
            return (IPRODUCT_PRODUCT_HH)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.PRODUCT_PRODUCT_HH");
        }
        public static IORDER_SH CreateORDER_SH()
        {
            return (IORDER_SH)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.ORDER_SH");
        }
        public static IPRODUCT_KB CreatePRODUCT_KB()
        {
            return (IPRODUCT_KB)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.PRODUCT_KB");
        }
        public static IPRODUCT_KBMX CreatePRODUCT_KBMX()
        {
            return (IPRODUCT_KBMX)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.PRODUCT_KBMX");
        }
        public static IDuiBiReport CreateDuiBiReport()
        {
            return (IDuiBiReport)Assembly.Load(assembly).CreateInstance(assembly + ".CRM.DuiBiReport");
        }

        //FICO
        public static IFM_ElectricInvoice CreateFM_ElectricInvoice()
        {
            return (IFM_ElectricInvoice)Assembly.Load(assembly).CreateInstance(assembly + ".FICO.FM_ElectricInvoice");
        }
        //BARCODE
        public static ISY_CODING CreateSY_CODING()
        {
            return (ISY_CODING)Assembly.Load(assembly).CreateInstance(assembly + ".BARCODE.SY_CODING");
        }

    }
}
